import fs from 'node:fs';
import crypto from 'node:crypto';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
const hash=b=>crypto.createHash('sha256').update(b).digest('hex');
const original=fs.readFileSync('source.wasm'),identity=hash(original);
const {source,manifest}=prepareLocalWasm(original,{kourstrike:true,photon:true});
assert.equal(hash(original),identity,'Original input must remain immutable');
assert.ok(WebAssembly.validate(source));
assert.deepEqual(WebAssembly.Module.imports(new WebAssembly.Module(source)),WebAssembly.Module.imports(new WebAssembly.Module(original)));
assert.equal(manifest.photon_callbacks.length,3);
const relocate=p=>p+manifest.round_start_hook.relocations.filter(r=>p>=r.original_offset).reduce((sum,r)=>sum+r.added_bytes,0);
for(const patch of manifest.photon_callbacks){
 const start=relocate(patch.start),end=relocate(patch.end),prefix=patch.function_index===75044?'41000f':'0f';
 assert.equal(source.subarray(start,start+prefix.length/2).toString('hex'),prefix);
 assert.equal(source[end-1],0x0b);
 assert.equal(hash(original.subarray(patch.start,patch.end)),patch.before_sha256);
}
const probe=manifest.network_probe;
assert.equal(hash(source.subarray(probe.served_start,probe.served_end)),probe.after_sha256,'Probe manifest must follow both hooks and new global/export sections');
const exports=WebAssembly.Module.exports(new WebAssembly.Module(source));
for(const name of ['kourstrikeRoundGate','kourstrikeIncomingState'])assert.ok(exports.some(e=>e.name===name&&e.kind==='global'));
console.log('Photon profile verified: guarded startup/matchmaking callbacks, immutable original, unchanged imports, round globals and relocated probe identity.');
