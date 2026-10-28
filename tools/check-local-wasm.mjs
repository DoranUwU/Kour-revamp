import fs from 'node:fs';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
const original=fs.readFileSync('source.wasm'),result=prepareLocalWasm(original),m=result.manifest;
assert.equal(original.length,result.source.length);
assert.ok(original.subarray(0,m.offset).equals(result.source.subarray(0,m.offset)));
assert.ok(original.subarray(m.offset+m.before.length/2,m.network_probe.start).equals(result.source.subarray(m.offset+m.before.length/2,m.network_probe.start)));
assert.ok(original.subarray(m.network_probe.end).equals(result.source.subarray(m.network_probe.end)));
assert.equal(result.source.subarray(m.network_probe.start,m.network_probe.start+3).toString('hex'),'41000f');
assert.equal(result.source.subarray(m.offset,m.offset+m.after.length/2).toString('hex'),m.after);
assert.ok(WebAssembly.validate(result.source));
// Execute the exact replacement body in a tiny isolated module. This verifies
// its return semantics without instantiating the original game and its imports.
const leb=value=>{const bytes=[];do{const byte=value&127;value>>>=7;bytes.push(byte|(value?128:0))}while(value);return Buffer.from(bytes)};
const section=(id,payload)=>Buffer.concat([Buffer.from([id]),leb(payload.length),payload]);
const body=result.source.subarray(m.network_probe.body_start,m.network_probe.end);
const standalone=Buffer.concat([Buffer.from('0061736d01000000','hex'),section(1,Buffer.from([1,0x60,2,0x7f,0x7f,1,0x7f])),section(3,Buffer.from([1,0])),section(7,Buffer.from([1,5,...Buffer.from('probe'),0,0])),section(10,Buffer.concat([Buffer.from([1]),leb(body.length),body]))]);
const probe=new WebAssembly.Instance(new WebAssembly.Module(standalone)).exports.probe;
assert.equal(probe(0,0),0);assert.equal(probe(123,456),0);
const altered=Buffer.from(original);altered[100]^=1;assert.throws(()=>prepareLocalWasm(altered),/Unknown WASM build/);
fs.writeFileSync('analysis/runtime/local-host-wasm-manifest.json',JSON.stringify(m,null,2));
console.log('Local patches verified: exact build, host quit and offline probe only, unchanged surrounding bytes, valid WASM, unknown inputs rejected.');
