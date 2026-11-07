import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
import {prepareFramework} from './original-framework.mjs';
import {insertRoundHook} from './wasm-round-hook.mjs';
const original=fs.readFileSync('source.wasm'),plain=prepareLocalWasm(original,{kourstrike:true,roundStartHook:false}),hooked=prepareLocalWasm(original,{kourstrike:true});
function integer(bytes,c){let value=0,shift=0,b;do{b=bytes[c.p++];value|=(b&127)<<shift;shift+=7}while(b&128);return value>>>0}
function sections(bytes){const out=[],c={p:8};while(c.p<bytes.length){const id=bytes[c.p++],length=integer(bytes,c);out.push({id,bytes:bytes.subarray(c.p,c.p+length)});c.p+=length}return out}
function bodies(bytes){const c={p:0},count=integer(bytes,c),out=[];for(let i=0;i<count;i++){const length=integer(bytes,c);out.push(bytes.subarray(c.p,c.p+length));c.p+=length}assert.equal(c.p,bytes.length);return out}
const before=sections(plain.source),after=sections(hooked.source);assert.equal(before.length,after.length);
const imports=WebAssembly.Module.imports(new WebAssembly.Module(plain.source));
assert.deepEqual(WebAssembly.Module.imports(new WebAssembly.Module(hooked.source)),imports);
const target=74516-imports.filter(x=>x.kind==='function').length;
for(let i=0;i<before.length;i++){
 assert.equal(before[i].id,after[i].id);
 if(before[i].id!==10){assert.ok(before[i].bytes.equals(after[i].bytes),'Unrelated section preserved');continue}
 const old=bodies(before[i].bytes),now=bodies(after[i].bytes);assert.equal(old.length,now.length);
 for(let j=0;j<old.length;j++){
  if(j!==target){assert.ok(old[j].equals(now[j]),'Unrelated function preserved');continue}
  assert.ok(now[j].subarray(0,3).equals(old[j].subarray(0,3)));
  assert.equal(now[j].subarray(3,8).toString('hex'),'417f10a601');
  assert.ok(now[j].subarray(8).equals(old[j].subarray(3)));
 }
}
assert.equal(plain.manifest.network_probe.after_sha256,hooked.manifest.network_probe.after_sha256);
const change=prepareFramework(fs.readFileSync('framework.js','utf8')).manifest.changes.find(x=>x.from.startsWith('function _JS_Eval_EvalJS'));
let hooks=0,reads=0,errors=0;
const context={Module:{onKourStrikeRoundStart(){hooks++}},UTF8ToString(){reads++;return'globalThis.ordinaryEvalWorked=123'},console:{error(){errors++}}};
vm.createContext(context);vm.runInContext('const bridge='+change.to+'; bridge(-1); bridge(42);',context);
assert.equal(hooks,1);assert.equal(reads,1);assert.equal(context.ordinaryEvalWorked,123);
context.Module.onKourStrikeRoundStart=()=>{throw Error('round failed')};assert.throws(()=>vm.runInContext('bridge(-1)',context),/round failed/);
context.UTF8ToString=()=>{return'throw Error("ordinary eval error")'};vm.runInContext('bridge(42)',context);assert.equal(errors,1);
console.log('Round hook verified: only StartRound grows, imports/data/other functions preserved, sentinel precedes decoding, ordinary eval behavior retained.');


const photon=insertRoundHook(plain.source,{photon:true});
assert.deepEqual(WebAssembly.Module.imports(new WebAssembly.Module(photon.source)),imports);
const photonExports=WebAssembly.Module.exports(new WebAssembly.Module(photon.source));
for(const name of ['kourstrikeRoundGate','kourstrikeIncomingState'])assert.ok(photonExports.some(e=>e.name===name&&e.kind==='global'));
const photonSections=sections(photon.source);
for(let i=0;i<before.length;i++){
 assert.equal(before[i].id,photonSections[i].id);
 if(![6,7,10].includes(before[i].id)){assert.ok(before[i].bytes.equals(photonSections[i].bytes),'Photon preserves unrelated sections');continue}
 if(before[i].id!==10)continue;
 const old=bodies(before[i].bytes),now=bodies(photonSections[i].bytes);assert.equal(old.length,now.length);
 for(let j=0;j<old.length;j++){
  const identity=j+imports.filter(e=>e.kind==='function').length,hook=photon.manifest.function_hooks.find(h=>h.function_index===identity);
  if(!hook){assert.ok(old[j].equals(now[j]),'Photon preserves unrelated native bodies');continue}
  const locals=identity===74516?3:7,prefix=Buffer.from(hook.prefix,'hex');
  assert.ok(old[j].subarray(0,locals).equals(now[j].subarray(0,locals)));
  assert.ok(prefix.equals(now[j].subarray(locals,locals+prefix.length)));
  assert.ok(old[j].subarray(locals).equals(now[j].subarray(locals+prefix.length)));
 }
}
// Execute the exact injected gate prefix in a small WASM fixture. This catches
// a missing/negated return guard independently of the native game lifecycle.
const leb=n=>{const out=[];do{const b=n&127;n>>>=7;out.push(b|(n?128:0))}while(n);return Buffer.from(out)};
const vector=entries=>Buffer.concat([leb(entries.length),...entries]);
const named=s=>{const b=Buffer.from(s);return Buffer.concat([leb(b.length),b])};
const section=(id,payload)=>Buffer.concat([Buffer.from([id]),leb(payload.length),payload]);
const gateIndex=photon.manifest.globals.kourstrikeRoundGate,counterIndex=gateIndex+2;
const fixtureImports=Array.from({length:167},(_,i)=>Buffer.concat([named('env'),named('f'+i),Buffer.from([0,1])]));
const body=Buffer.concat([Buffer.from([0]),Buffer.from(photon.manifest.function_hooks.find(h=>h.function_index===74516).prefix,'hex'),Buffer.from([0x23]),leb(counterIndex),Buffer.from([0x41,1,0x6a,0x24]),leb(counterIndex),Buffer.from([0x0b])]);
const fixture=Buffer.concat([Buffer.from('0061736d01000000','hex'),section(1,vector([Buffer.from('600000','hex'),Buffer.from('60017f00','hex')])),section(2,vector(fixtureImports)),section(3,vector([Buffer.from([0])])),section(6,vector(Array.from({length:counterIndex+1},()=>Buffer.from('7f0141000b','hex')))),section(7,vector([Buffer.concat([named('run'),Buffer.from([0]),leb(167)]),Buffer.concat([named('gate'),Buffer.from([3]),leb(gateIndex)]),Buffer.concat([named('counter'),Buffer.from([3]),leb(counterIndex)])])),section(10,vector([Buffer.concat([leb(body.length),body])]))]);
let pause=false,fixtureInstance;
const env=Object.fromEntries(Array.from({length:167},(_,i)=>['f'+i,i===166?(marker)=>{assert.equal(marker,-1);fixtureInstance.exports.gate.value=pause?1:0}:()=>{}]));
fixtureInstance=new WebAssembly.Instance(new WebAssembly.Module(fixture),{env});
fixtureInstance.exports.run();assert.equal(fixtureInstance.exports.counter.value,1);
pause=true;fixtureInstance.exports.run();assert.equal(fixtureInstance.exports.counter.value,1,'Pending ack must prevent native round body');
pause=false;fixtureInstance.exports.run();assert.equal(fixtureInstance.exports.counter.value,2,'Acknowledged retry must resume native round body');
console.log('Photon round gate verified: unchanged imports and unrelated bodies, two exported globals, exact gate prefix blocks and resumes native execution.');
