import fs from 'node:fs';
import crypto from 'node:crypto';
import assert from 'node:assert/strict';
import zlib from 'node:zlib';
import {textureAssets} from './local-textures.mjs';
const manifest=JSON.parse(fs.readFileSync('analysis/runtime/default-weapon-texture-manifest.json'));
assert.deepEqual(manifest.textures.map(x=>x.native_path).sort(),textureAssets.map(x=>x.pathname).sort());
for(const asset of textureAssets){
 const row=manifest.textures.find(x=>x.native_path===asset.pathname);
 assert.equal(row.local_path,asset.file);assert.equal(row.status,200);assert.equal(row.body_redacted,false);
 const bytes=fs.readFileSync(asset.file);
 assert.equal(bytes.length,row.bytes);assert.equal(crypto.createHash('sha256').update(bytes).digest('hex'),row.sha256);
 assert.equal(bytes.subarray(0,8).toString('hex'),'89504e470d0a1a0a');
 assert.equal(bytes.readUInt32BE(16),row.width);assert.equal(bytes.readUInt32BE(20),row.height);
 let cursor=8;const compressed=[];
 while(cursor<bytes.length){
  const length=bytes.readUInt32BE(cursor),kind=bytes.toString('ascii',cursor+4,cursor+8);
  assert.ok(cursor+12+length<=bytes.length,'PNG chunk bounds');
  if(kind==='IDAT')compressed.push(bytes.subarray(cursor+8,cursor+8+length));
  cursor+=12+length;if(kind==='IEND')break;
 }
 assert.equal(cursor,bytes.length);assert.equal(zlib.inflateSync(Buffer.concat(compressed)).length,row.inflated_bytes);
}
console.log(`Default weapon textures verified: ${textureAssets.length} original PNG identities, dimensions and explicit local routes.`);
