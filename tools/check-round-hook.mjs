import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
import {prepareFramework} from './original-framework.mjs';
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
