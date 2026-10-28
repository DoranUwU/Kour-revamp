import http from 'node:http';
import fs from 'node:fs';
import path from 'node:path';
import {prepareFramework} from './original-framework.mjs';
import {prepareLocalWasm} from './original-wasm.mjs';
import {prepareKourStrikeData} from './kourstrike-data.mjs';
import {localBundles} from './local-bundles.mjs';
const files={'/':'original-preview/index.html','/offline-policy.js':'original-preview/offline-policy.js','/loader.js':'original-preview/loader.js','/framework.js':'framework.js','/source.wasm':'source.wasm','/game.data':'game.data'};
const types={'.html':'text/html','.js':'text/javascript','.wasm':'application/wasm','.data':'application/octet-stream'};
const port=Number(process.env.ORIGINAL_PREVIEW_PORT||8082);
const kourstrike=process.argv.includes('--kourstrike')||process.env.LOCAL_GAME_MODE!=='lobby';
const framework=prepareFramework(fs.readFileSync('framework.js','utf8'));
const wasm=prepareLocalWasm(fs.readFileSync('source.wasm'),{kourstrike});
const data=kourstrike?prepareKourStrikeData():null;
const mapRoot=path.resolve('original-preview/StreamingAssets');fs.mkdirSync(mapRoot,{recursive:true});
const bundleNames=new Set(localBundles);
const policy="default-src 'self' blob: data:; script-src 'self' 'unsafe-inline' 'unsafe-eval' 'wasm-unsafe-eval'; style-src 'self' 'unsafe-inline'; connect-src 'self'; worker-src 'none'; object-src 'none'; frame-src 'none'; form-action 'none'; base-uri 'none'";
http.createServer((req,res)=>{
 const pathname=new URL(req.url,'http://localhost').pathname;
 if(pathname==='/local-config.json'){res.writeHead(200,{'Content-Type':'application/json','Cache-Control':'no-store'}).end(JSON.stringify({profile:kourstrike?'kourstrike':'lobby',gameType:kourstrike?1:0,gameMode:8,mapName:'Kour2',mapBundle:'map7',mapAvailable:fs.existsSync(path.join(mapRoot,'map7')),requiredFiles:['map7','map8','map10'],wasmSha256:wasm.manifest.served_sha256}));return}
 if(pathname.startsWith('/StreamingAssets/')){const name=pathname.slice('/StreamingAssets/'.length);if(!bundleNames.has(name)){res.writeHead(404).end('Unknown local bundle');return}const target=path.join(mapRoot,name);if(!fs.existsSync(target)){res.writeHead(404,{'Content-Type':'text/plain','Cache-Control':'no-store'}).end(`Missing KourStrike asset bundle: ${name}. Place the original bundle in original-preview/StreamingAssets/${name}.`);return}res.writeHead(200,{'Content-Type':'application/octet-stream','Content-Length':fs.statSync(target).size,'Cache-Control':'no-store'});fs.createReadStream(target).pipe(res);return}
 const file=files[pathname];
 if(!file){res.writeHead(404).end('Not supplied');return}
 res.writeHead(200,{'Content-Type':types[path.extname(file)],'Content-Security-Policy':policy,'Cross-Origin-Opener-Policy':'same-origin','Cross-Origin-Embedder-Policy':'require-corp','Cache-Control':'no-store'});
 if(file==='framework.js')res.end(framework.source);
 else if(file==='source.wasm')res.end(wasm.source);
 else if(file==='game.data'&&data)res.end(data.source);
 else fs.createReadStream(file).pipe(res);
}).listen(port,'127.0.0.1',()=>console.log(`Local ${kourstrike?'KourStrike':'original-build'} preview http://127.0.0.1:${port}`));
