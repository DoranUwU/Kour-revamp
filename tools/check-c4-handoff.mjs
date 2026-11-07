import fs from 'node:fs';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
const original=fs.readFileSync('source.wasm'),plain=prepareLocalWasm(original,{kourstrike:true,roundStartHook:false});
assert.equal(plain.manifest.c4_handoff.length,2);
assert.equal(original[23584099],0x72);assert.equal(plain.source[23584099],0x73);
assert.equal(original[23706657],0);assert.equal(plain.source[23706657],1);
// Execute the exact native predicate in a standalone WASM function, rather
// than reimplementing it in JS. Existing clear/grant/planting cases stay equal;
// the previously unused pair marks the death handoff and must not equip.
function predicate(bytes){const body=Buffer.concat([Buffer.from([0]),bytes,Buffer.from([0x0b])]);const section=(id,payload)=>Buffer.concat([Buffer.from([id,payload.length]),payload]);const module=Buffer.concat([Buffer.from('0061736d01000000','hex'),section(1,Buffer.from('0160037f7f7f017f','hex')),section(3,Buffer.from([1,0])),section(7,Buffer.from([1,4,101,113,117,105,0,0])),section(10,Buffer.concat([Buffer.from([1,body.length]),body]))]);return new WebAssembly.Instance(new WebAssembly.Module(module)).exports.equi}
const before=predicate(original.subarray(23584095,23584100)),after=predicate(plain.source.subarray(23584095,23584100));
for(const [give,plant]of [[0,0],[1,0],[0,1]])assert.equal(after(0,give,plant),before(0,give,plant));
assert.equal(before(0,1,0),1);assert.equal(after(0,1,1),0);
for(const photon of [false,true]){const built=prepareLocalWasm(original,{kourstrike:true,photon});for(const patch of built.manifest.c4_handoff)assert.equal(built.source.subarray(patch.served_offset,patch.served_offset+patch.after.length/2).toString('hex'),patch.after);assert.ok(WebAssembly.validate(built.source))}
console.log('C4 handoff verified: exact native predicate, passive transfer marker, normal grant/clear/planting behavior, and relocated offline/Photon bytes.');
