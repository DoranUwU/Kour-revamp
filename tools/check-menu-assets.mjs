import fs from 'node:fs';
import crypto from 'node:crypto';
import assert from 'node:assert/strict';
import {localBundles} from './local-bundles.mjs';
import {menuTextureAssets,prepareOfflinePolicy} from './local-textures.mjs';
const bundles=JSON.parse(fs.readFileSync('tools/menu-bundles.json','utf8'));
for(const asset of [...bundles.map(a=>({...a,file:'original-preview/StreamingAssets/'+a.name})),...menuTextureAssets]){
 const bytes=fs.readFileSync(asset.file);assert.equal(bytes.length,asset.bytes);assert.equal(crypto.createHash('sha256').update(bytes).digest('hex'),asset.sha256);
 if(asset.name){assert.ok(localBundles.includes(asset.name));assert.equal(bytes.subarray(0,8).toString(),'UnityFS\0');let offset=12;for(let i=0;i<2;i++)offset=bytes.indexOf(0,offset)+1;assert.equal(Number(bytes.readBigUInt64BE(offset)),bytes.length)}
 else assert.equal(bytes.subarray(0,8).toString('hex'),'89504e470d0a1a0a');
}
const policy=prepareOfflinePolicy(fs.readFileSync('original-preview/offline-policy.js','utf8'));
for(const asset of menuTextureAssets)assert.ok(policy.includes(asset.pathname));
console.log('Native menu bundles, preview meshes and local character PNG identities verified.');
