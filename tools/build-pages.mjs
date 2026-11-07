import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import {gzipSync} from 'node:zlib';
import {prepareFramework} from './original-framework.mjs';
import {prepareLocalWasm} from './original-wasm.mjs';
import {prepareKourStrikeData} from './kourstrike-data.mjs';
import {localBundles} from './local-bundles.mjs';
import {textureAssets,prepareOfflinePolicy} from './local-textures.mjs';
const base=process.env.PAGES_BASE_PATH||'/Kour-revamp/';
if(!/^\/(?:[A-Za-z0-9_-]+\/)*$/.test(base))throw Error('PAGES_BASE_PATH must be a directory path with leading/trailing slashes.');
const output=path.resolve('local/pages-dist');fs.mkdirSync(output,{recursive:true});
const read=file=>fs.readFileSync(file,'utf8'),hash=b=>crypto.createHash('sha256').update(b).digest('hex');
const wasm=prepareLocalWasm(fs.readFileSync('source.wasm'),{kourstrike:true,photon:true});
const data=prepareKourStrikeData(),manifest={basePath:base,wasmSha256:wasm.manifest.served_sha256,files:{}};
function write(name,bytes){const file=path.join(output,name);fs.mkdirSync(path.dirname(file),{recursive:true});fs.writeFileSync(file,bytes);manifest.files[name]={bytes:fs.statSync(file).size,sha256:hash(bytes)}}
let loader=read('original-preview/loader.js');
for(const name of ['local-config.json','game.data','source.wasm','StreamingAssets'])loader=loader.replaceAll("'/"+name+"'",JSON.stringify(base+name));
loader=loader.replace("('/'+name)","("+JSON.stringify(base)+"+name)");
const policy="default-src 'self' blob: data:; script-src 'self' 'unsafe-inline' 'unsafe-eval' 'wasm-unsafe-eval'; style-src 'self' 'unsafe-inline'; connect-src 'self' wss://*.photonengine.io:* wss://*.photonengine.com:* wss://*.exitgames.com:*; worker-src 'none'; object-src 'none'; frame-src 'none'; form-action 'none'; base-uri 'none'";
let html=read('original-preview/index.html').replaceAll('src="/','src="'+base);
html=html.replace('<head>','<head><meta http-equiv="Content-Security-Policy" content="'+policy+'">');
html=html.replace('<script src="'+base+'offline-policy.js">','<script src="'+base+'static-host.js"></script><script src="'+base+'offline-policy.js">');
write('index.html',html);write('.nojekyll','');
write('loader.js',loader);write('framework.js',prepareFramework(read('framework.js')).source);
write('offline-policy.js','window.BuildBasePath='+JSON.stringify(base)+';\n'+prepareOfflinePolicy(read('original-preview/offline-policy.js')));
write('static-host.js','window.BuildBasePath='+JSON.stringify(base)+';\n'+read('original-preview/static-host.js'));
for(const name of ['game-audio.js','photon-client.js','kourstrike-rules.js','round-debug.js'])write(name,read('original-preview/'+name));
for(const [name,bytes]of [['source.wasm',wasm.source],['game.data',data.source]]){
 const file=path.join(output,name);if(fs.existsSync(file))fs.unlinkSync(file);
 write(name+'.gz',gzipSync(bytes,{level:9}));
}
for(const name of localBundles){const file='original-preview/StreamingAssets/'+name;if(fs.existsSync(file))write('StreamingAssets/'+name,fs.readFileSync(file))}
for(const asset of textureAssets)write(asset.pathname.slice(1),fs.readFileSync(asset.file));
write('local-config.json',JSON.stringify({profile:'kourstrike',photonEnabled:true,photonAppId:process.env.PHOTON_APP_ID||'',photonRegion:'hk',gameType:1,gameMode:8,mapName:'Kour2',mapBundle:'map7',mapAvailable:true,requiredFiles:['map7'],wasmSha256:wasm.manifest.served_sha256}));
write('build-manifest.json',JSON.stringify(manifest,null,2));
console.log('Pages export ready:',Object.keys(manifest.files).length,'files; base path',base);
