import fs from 'node:fs';
import assert from 'node:assert/strict';
import {prepareKourStrikeData} from './kourstrike-data.mjs';
import {prepareLocalWasm} from './original-wasm.mjs';
const original=fs.readFileSync('game.data'),derived=prepareKourStrikeData();
function members(bytes){assert.equal(bytes.subarray(0,16).toString(),'UnityWebData1.0\0');const end=bytes.readUInt32LE(16),out=new Map();let p=20;while(p<end){const off=bytes.readUInt32LE(p),size=bytes.readUInt32LE(p+4),n=bytes.readUInt32LE(p+8);p+=12;const name=bytes.subarray(p,p+n).toString();p+=n;assert.ok(off>=end&&off+size<=bytes.length);out.set(name,bytes.subarray(off,off+size))}assert.equal(p,end);return out}
const old=members(original),now=members(derived.source);assert.equal(old.size,8);assert.equal(now.size,old.size);
for(const [name,data]of old)if(name!=='data.unity3d')assert.ok(data.equals(now.get(name)),name+' unchanged');
const b=now.get('data.unity3d');let p=0;const cstr=()=>{const n=b.indexOf(0,p),s=b.subarray(p,n).toString();p=n+1;return s};
assert.equal(cstr(),'UnityFS');assert.equal(b.readUInt32BE(p),8);p+=4;cstr();assert.equal(cstr(),'6000.2.7f2');assert.equal(Number(b.readBigUInt64BE(p)),b.length);p+=8;const infoSize=b.readUInt32BE(p);p+=4;assert.equal(b.readUInt32BE(p),infoSize);p+=4;assert.equal(b.readUInt32BE(p),0x240);p+=4;p=Math.ceil(p/16)*16;
const info=b.subarray(p,p+infoSize);p+=infoSize;p=Math.ceil(p/16)*16;const raw=b.subarray(p);let q=16;
assert.equal(info.readUInt32BE(q),1);q+=4;assert.equal(info.readUInt32BE(q),raw.length);q+=4;assert.equal(info.readUInt32BE(q),raw.length);q+=4;assert.equal(info.readUInt16BE(q),0);q+=2;
const count=info.readUInt32BE(q);q+=4;let sceneVerified=false;
for(let i=0;i<count;i++){const off=Number(info.readBigUInt64BE(q)),size=Number(info.readBigUInt64BE(q+8));q+=20;const end=info.indexOf(0,q),name=info.subarray(q,end).toString();q=end+1;const data=raw.subarray(off,off+size),originalFile=fs.readFileSync('analysis/assets/bundle/'+name);assert.equal(data.length,originalFile.length);if(name==='level0'){const field=458856;assert.ok(data.subarray(0,field).equals(originalFile.subarray(0,field)));assert.equal(originalFile.readInt32LE(field),0);assert.equal(data.readInt32LE(field),1);assert.ok(data.subarray(field+4).equals(originalFile.subarray(field+4)));sceneVerified=true}else assert.ok(data.equals(originalFile),name+' unchanged')}
assert.ok(sceneVerified);assert.equal(q,info.length);
const input=fs.readFileSync('source.wasm'),base=prepareLocalWasm(input).source,kour=prepareLocalWasm(input,{kourstrike:true,roundStartHook:false});
const cash=kour.manifest.round_start_cash;assert.equal(cash.amount,14000);assert.equal(cash.offset,23693680);
assert.equal(input.subarray(cash.offset,cash.offset+7).toString('hex'),'10a99c0320056a');
assert.equal(kour.source.subarray(cash.offset,cash.offset+7).toString('hex'),'1a1a41b0ed0001');
const changed=[];for(let i=0;i<base.length;i++)if(base[i]!==kour.source[i])changed.push(i);
assert.deepEqual(changed,[23691669,...Array.from({length:7},(_,i)=>cash.offset+i),23703302,23889931,24435820,24448526]);
assert.ok(WebAssembly.validate(kour.source));assert.equal(kour.manifest.bootstrap.length,3);assert.equal(prepareLocalWasm(input).manifest.round_start_cash,null);
// Run the exact patch instructions in isolation: preserve the destination
// pointer, discard both former decode arguments, and produce the native cap.
const probeBody=Buffer.concat([Buffer.from('00200020012002','hex'),kour.source.subarray(cash.offset,cash.offset+7),Buffer.from([0x0b])]);
const section=(id,bytes)=>Buffer.concat([Buffer.from([id,bytes.length]),bytes]);
const standalone=Buffer.concat([Buffer.from('0061736d01000000','hex'),section(1,Buffer.from('0160037f7f7f027f7f','hex')),section(3,Buffer.from([1,0])),section(7,Buffer.from([1,4,...Buffer.from('cash'),0,0])),section(10,Buffer.concat([Buffer.from([1,probeBody.length]),probeBody]))]);
const hooked=prepareLocalWasm(input,{kourstrike:true});assert.equal(hooked.source.length,kour.source.length+5);assert.equal(hooked.manifest.round_start_hook.prefix,'417f10a601');assert.ok(WebAssembly.validate(hooked.source));
const cashProbe=new WebAssembly.Instance(new WebAssembly.Module(standalone)).exports.cash;
assert.deepEqual(cashProbe(4096,123,0),[4096,14000]);assert.deepEqual(cashProbe(8192,-999,456),[8192,14000]);
fs.writeFileSync('analysis/runtime/kourstrike-profile-manifest.json',JSON.stringify({data:derived.manifest,wasm:hooked.manifest,checks:['8 archive members,7 unchanged','6 UnityFS nodes,only SDK gameType changed0->1','UnityFS directory/blocks/sizes verified','3 bootstrap operands, 7-byte cash patch, 2 halftime constants and synchronous round hook','Full WASM validation and isolated cash stack-effect execution']},null,2));
console.log('KourStrike profile verified: SDK1,SearchAndDestroy index6,map7,$14000 round-start cash; original inputs and unrelated bytes preserved.');
