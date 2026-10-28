import fs from 'node:fs';
import crypto from 'node:crypto';
import assert from 'node:assert/strict';
const names=JSON.parse(fs.readFileSync('tools/local-asset-names.json','utf8')).names;
const manifest=JSON.parse(fs.readFileSync('analysis/runtime/mesh-acquisition-manifest.json','utf8'));
const loaders=JSON.parse(fs.readFileSync('analysis/runtime/weapon-missing-meshes.json','utf8'));
assert.equal(new Set(names).size,34);
assert.deepEqual([...new Set(loaders.map(x=>x.myMeshName))].sort(),[...names].sort());
assert.equal(manifest.assets.length,34);
assert.deepEqual(manifest.missing_names,[]);
let total=0;
for(const name of names){
 const row=manifest.assets.find(x=>x.name===name);assert.ok(row,name);
 assert.equal(row.local_path,'original-preview/StreamingAssets/'+name);
 const bytes=fs.readFileSync(row.local_path);assert.equal(bytes.length,row.bytes);
 assert.equal(crypto.createHash('sha256').update(bytes).digest('hex'),row.sha256);
 assert.equal(bytes.subarray(0,8).toString(),'UnityFS\0');assert.equal(bytes.readUInt32BE(8),8);
 let cursor=12;for(let i=0;i<2;i++)cursor=bytes.indexOf(0,cursor)+1;
 assert.equal(Number(bytes.readBigUInt64BE(cursor)),bytes.length);
 assert.equal(row.status,200);assert.equal(row.body_redacted,false);assert.equal(row.mesh_objects.length,1);
 assert.ok(row.evidence_id.startsWith('ev_'));total+=bytes.length;
}
console.log(JSON.stringify({native_loader_components:loaders.length,exact_mesh_bundle_names:names.length,validated_bundles:manifest.assets.length,total_bytes:total,checks:['Exact names agree with serialized LoadMyMesh fields','All local bytes match native REA response identities','UnityFS format and declared lengths','Each bundle has one statically decoded Mesh','No unresolved bundle names']}));
