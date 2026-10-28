import fs from 'node:fs';
import path from 'node:path';
import assert from 'node:assert/strict';
import zlib from 'node:zlib';
import crypto from 'node:crypto';
const hash=b=>crypto.createHash('sha256').update(b).digest('hex');
const rows=folder=>fs.readdirSync(folder).filter(n=>n.endsWith('.json')).flatMap(n=>{const r=JSON.parse(fs.readFileSync(path.join(folder,n)));return Array.isArray(r)?r.map(x=>({...x,source_file:n.replace(/\.json$/,'')})):[]});
const packed=fs.readFileSync('game.data.br'),data=zlib.brotliDecompressSync(packed);
assert.ok(data.equals(fs.readFileSync('game.data')),'Supplied game.data must equal Brotli-decoded input');
const members=JSON.parse(fs.readFileSync('analysis/data-inventory.json'));
const verified=members.map(r=>{const b=fs.readFileSync(path.join('analysis/extracted',r.name));assert.ok(b.equals(data.subarray(r.offset,r.offset+r.size)),'Archive payload mismatch: '+r.name);return{file:r.name,bytes:b.length,sha256:hash(b)}});
const bundleRows=JSON.parse(fs.readFileSync('analysis/assets/serialized-summary.json'));
const textures=rows('analysis/assets/textures'),audio=rows('analysis/assets/audio'),meshes=rows('analysis/assets/meshes');
let png=0,triangles=0;
for(const t of textures){if(!t.png_export)continue;const b=fs.readFileSync(path.join('analysis/assets',t.png_export));assert.equal(b.subarray(0,8).toString('hex'),'89504e470d0a1a0a');assert.equal(b.readUInt32BE(16),t.width);assert.equal(b.readUInt32BE(20),t.height);assert.equal(b[25],6,'PNG exporter uses RGBA');const chunks=[];for(let off=8;off<b.length;){const n=b.readUInt32BE(off),kind=b.subarray(off+4,off+8).toString();assert.ok(off+12+n<=b.length);if(kind==='IDAT')chunks.push(b.subarray(off+8,off+8+n));off+=12+n}assert.equal(zlib.inflateSync(Buffer.concat(chunks)).length,t.height*(1+t.width*4));png++}
for(const a of audio){const payload=fs.readFileSync(path.join('analysis/assets',a.export));const resource=fs.readFileSync(path.join('analysis/extracted',a.source));assert.ok(payload.equals(resource.subarray(a.stream_offset,a.stream_offset+a.stream_size)),a.name+' audio bytes');assert.equal(payload.subarray(4,8).toString(),'ftyp')}
for(const m of meshes){if(!m.obj_export)continue;const text=fs.readFileSync(path.join('analysis/assets',m.obj_export),'utf8');let vertexCount=0;const faces=[];for(const line of text.split('\n')){if(line.startsWith('v ')){const coords=line.slice(2).trim().split(/\s+/).map(Number);assert.equal(coords.length,3);assert.ok(coords.every(Number.isFinite));vertexCount++}if(line.startsWith('f '))faces.push(line.slice(2).trim().split(/\s+/).map(x=>Number(x.split('/')[0])))}assert.equal(vertexCount,m.decompressed_vertex_count||m.vertex_count,m.name+' vertex count');for(const f of faces){assert.ok(f.length>=3&&f.every(i=>Number.isInteger(i)&&i>0&&i<=vertexCount),m.name+' face bounds');triangles+=f.length-2}}
const settings=JSON.parse(fs.readFileSync('analysis/assets/gameplay-settings.json'));
for(const s of settings.filter(s=>s.coverage==='complete-object')){assert.equal(s.remaining_bytes,0);for(const f of s.field_offsets){assert.ok(f.start>=s.fields_offset&&f.end<=s.object_bytes&&f.start<=f.end)}}
const codes=JSON.parse(fs.readFileSync('analysis/metadata/gameplay.json'));
assert.equal(codes.length,786);assert.equal(codes.reduce((n,t)=>n+t.methods.length,0),4833);
const player=settings.find(s=>s.script==='PlayerController');assert.equal(player.coverage,'complete-object');assert.equal(player.values.groundLimit,15);assert.equal(player.values.gravity,21);
const network=codes.find(t=>t.name==='NetworkManager');assert.equal(network.fields.find(f=>f.name==='KOUR_MOBILE_MAP').default,3);
const result={archive_members:verified,pngs_validated:png,audio_byte_exact:audio.length,obj_meshes:meshes.filter(m=>m.obj_export).length,triangles,gameplay_settings_objects:settings.length,gameplay_classes:codes.length,gameplay_methods:4833,checks:['Original Brotli/decompressed files agree','All eight extracted archive members are byte-exact','PNG signatures/dimensions/deflated payload lengths','AAC exports match original resource byte slices','OBJ vertex counts/finite coordinates/face index bounds','Complete decoded field byte ranges stay within objects','Gameplay counts and selected code/asset constants agree'],limitations:['PNG checks do not compare rendered colors to Unity','OBJ checks do not establish original material/rig/animation fidelity','Serialized decoding without original type trees can be incomplete','Runtime game reachability is separate from static verification']};
fs.writeFileSync('analysis/recovery-verification.json',JSON.stringify(result,null,2));console.log(JSON.stringify({...result,archive_members:verified.length}));
