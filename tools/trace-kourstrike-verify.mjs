// Validate proposed original-build mode/map changes in memory only.
import fs from 'node:fs';
import crypto from 'node:crypto';
import assert from 'node:assert/strict';
const original=fs.readFileSync('source.wasm');
const hash=b=>crypto.createHash('sha256').update(b).digest('hex');
assert.equal(hash(original),'dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2');
const source=Buffer.from(original);
const patches=[
 {method:'NetworkManager.OnDisconnected',function_index:75076,table_index:19919,body_offset:23889485,code_offset:23889488,end_offset:23891564,signature:{params:['i32','i32','i32'],results:[]},offset:23889930,before:'4102',after:'4107',meaning:'Emergency offline disconnect callback also uses LoadForceMap(7); covers an initially connected client that disconnects before offline entry.'},
 {method:'UIManager.GoOfflineEmergency',function_index:76743,table_index:21338,body_offset:24448303,code_offset:24448306,end_offset:24448535,signature:{params:['i32','i32'],results:[]},offset:24448525,before:'4102',after:'4107',meaning:'Existing emergency offline flow: LoadForceMap(mapNumber=2) -> LoadForceMap(mapNumber=7); room map property C1=8, scene bundle map7 (Kour2).'},
 {method:'UIManager.LoadForceMap',function_index:76698,table_index:21283,body_offset:24435698,code_offset:24435701,end_offset:24436027,signature:{params:['i32','i32'],results:[]},offset:24435819,before:'4100',after:'4106',meaning:'GetGameModeFromIndex(0) -> GetGameModeFromIndex(6); serialized gameModes[6] is Search And Destroy, id8.'},
];
for(const p of patches){const before=Buffer.from(p.before,'hex'),after=Buffer.from(p.after,'hex');assert.equal(before.length,after.length);assert.ok(source.subarray(p.offset,p.offset+before.length).equals(before));after.copy(source,p.offset);}
assert.ok(WebAssembly.validate(original));
assert.ok(WebAssembly.validate(source));
const changed=[];for(let i=0;i<source.length;i++)if(source[i]!==original[i])changed.push(i);
assert.deepEqual(changed,[23889931,24435820,24448526]);
const manifest={original_sha256:hash(original),candidate_sha256:hash(source),candidate_only:true,original_modified:false,original_valid:true,candidate_valid:true,patches,changed_byte_offsets:changed,limitations:['The candidate is not written or served by this verification script.','It leaves all existing local-host/freeze compatibility changes to the parent preview builder; these proposed changes should be combined with those changes and revalidated.','Missing map7/map8/map10 bundles remain required; mode selection alone does not create an arena or prove playability.']};
fs.writeFileSync('analysis/runtime/kourstrike-static-patch-manifest.json',JSON.stringify(manifest,null,2));
console.log(JSON.stringify(manifest,null,2));
