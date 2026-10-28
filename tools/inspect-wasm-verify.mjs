import fs from 'node:fs';
import assert from 'node:assert/strict';
const bytes=fs.readFileSync('source.wasm');
assert.ok(WebAssembly.validate(bytes),'Node/V8 rejected Wasm');
// Compilation only: do not instantiate or call the supplied module.
const module=new WebAssembly.Module(bytes);
const intf=JSON.parse(fs.readFileSync('analysis/wasm-interface.json','utf8'));
assert.deepEqual(WebAssembly.Module.imports(module),intf.imports.map(({module,name,kind})=>({module,name,kind})));
assert.deepEqual(WebAssembly.Module.exports(module),intf.exports.map(({name,kind})=>({name,kind})));
const evidence=JSON.parse(fs.readFileSync('analysis/rea-evidence-initial.json','utf8'));
const metadata=evidence.records.find(r=>r.operation==='inspect_il2cpp_metadata').normalized_result;
const map=JSON.parse(fs.readFileSync('analysis/wasm-method-map.json','utf8'));
assert.equal(map.length,metadata.methods.length);
for(let i=0;i<map.length;i++){
  assert.equal(map[i].name,metadata.methods[i].name,`Method name mismatch at ${i}`);
  assert.equal(map[i].declaring_type_index,metadata.methods[i].declaring_type,`Owner mismatch at ${i}`);
}
const codegen=JSON.parse(fs.readFileSync('analysis/wasm-codegen.json','utf8'));
assert.equal(codegen.length,metadata.images.length);
assert.equal(new Set(codegen.map(m=>m.image)).size,metadata.images.length);
for(const image of metadata.images)assert.ok(codegen.some(m=>m.image===image.name),`Unlinked image ${image.name}`);
const game=map.filter(m=>m.image==='Assembly-CSharp.dll');
assert.equal(game.length,4833);
assert.equal(game.filter(m=>m.function_index!==null).length,4811);
const dis=JSON.parse(fs.readFileSync('analysis/wasm-gameplay-disassembly.json','utf8'));
for(const f of dis.functions){assert.equal(f.status,'complete');assert.equal(f.instructions.at(-1).op,'end');assert.equal(f.instructions.at(-1).offset+1,f.end_offset);}
const summary={validation:'Node/V8 WebAssembly.validate and compile-only module interface comparison passed; no instantiation',imports:intf.imports.length,exports:intf.exports.length,verified_metadata_methods:map.length,linked_images:codegen.length,game_methods:game.length,game_methods_with_bodies:4811,fully_decoded_selected_functions:dis.functions.length,limitations:['Does not establish execution, reachable behavior, original C# source or server availability.','Instruction decoding is a custom scalar opcode decoder; full Node validation covers module bytes independently.']};
fs.writeFileSync('analysis/wasm-verification.json',JSON.stringify(summary,null,2));
console.log(JSON.stringify(summary,null,2));
