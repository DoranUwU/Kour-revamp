import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
import {prepareFramework} from './original-framework.mjs';
import {meshBundles} from './local-bundles.mjs';
import {textureAssets,prepareOfflinePolicy} from './local-textures.mjs';
let fetches=0,xhrs=0,lastFetch,lastXHR;const listeners={};
class XHR{open(method,url){xhrs++;lastXHR=url}}
class TestCloseEvent extends Event{constructor(type,options){super(type);Object.assign(this,options)}}
class NativeSocket{constructor(url){this.url=url}}
const sandbox={URL,Request,Event,EventTarget,CloseEvent:TestCloseEvent,DOMException,setTimeout,console:{info(){}},location:{href:'http://localhost:8082/',origin:'http://localhost:8082'},navigator:{},XMLHttpRequest:XHR,document:{addEventListener:(name,fn)=>listeners[name]=fn},window:{WebSocket:NativeSocket,fetch:async(input)=>{fetches++;lastFetch=input;return{ok:true}}}};
vm.createContext(sandbox);vm.runInContext(prepareOfflinePolicy(fs.readFileSync('original-preview/offline-policy.js','utf8')),sandbox);
await sandbox.window.fetch('/game.data');assert.equal(fetches,1);
for(const target of ['https://kour.io/','https://example.com/','//example.com/game.data','/account','/game.data?remote=1','http://user:password@localhost:8082/game.data'])await assert.rejects(sandbox.window.fetch(target),{name:'SecurityError'});
assert.equal(fetches,1,'Forbidden fetches must never reach native fetch');
await sandbox.window.fetch('/StreamingAssets/map7?v=4.24');assert.equal(fetches,2);
await assert.rejects(sandbox.window.fetch('/StreamingAssets/map7?redirect=external'),{name:'SecurityError'});
await assert.rejects(sandbox.window.fetch('/StreamingAssets/map2?v=4.24'),{name:'SecurityError'});
await assert.rejects(sandbox.window.fetch('https://kour.io/StreamingAssets/map7?v=4.24'),{name:'SecurityError'});
for(const name of meshBundles){
 assert.equal(sandbox.window.OfflinePolicy.isLocalAsset('/StreamingAssets/'+name+'?v=4.24'),true);
 assert.equal(sandbox.window.OfflinePolicy.isLocalAsset('https://kourstrike.io/StreamingAssets/'+name),false);
}
assert.equal(sandbox.window.OfflinePolicy.isLocalAsset('/StreamingAssets/unknown-gun'),false);
assert.equal(sandbox.window.OfflinePolicy.isLocalAsset('/StreamingAssets/usps?redirect=external'),false);
const recovered=JSON.parse(fs.readFileSync('analysis/runtime/weapon-visibility-assets.json'));
assert.deepEqual([...new Set(recovered.dynamic_mesh_loaders.map(x=>x.myMeshName))].sort(),[...meshBundles].sort());
new sandbox.XMLHttpRequest().open('GET','/source.wasm');assert.equal(xhrs,1);
assert.throws(()=>new sandbox.XMLHttpRequest().open('POST','https://example.com/'),{name:'SecurityError'});assert.equal(xhrs,1);
for(const asset of textureAssets){
 const remote='https://kour.io'+asset.pathname+'?size=256x256',local='http://localhost:8082'+asset.pathname+'?size=256x256';
 await sandbox.window.fetch(remote);assert.equal(lastFetch,local,'Native fetch must receive only the local image URL');
 await sandbox.window.fetch(new Request(remote));assert.equal(lastFetch.url,local);
 new sandbox.XMLHttpRequest().open('GET',remote);assert.equal(lastXHR,local);
 await assert.rejects(sandbox.window.fetch(remote,{method:'POST'}),{name:'SecurityError'});
 assert.throws(()=>new sandbox.XMLHttpRequest().open('POST',remote),{name:'SecurityError'});
 for(const target of ['https://other.example'+asset.pathname,'https://kour.io'+asset.pathname+'?redirect=evil','https://kour.io'+asset.pathname+'?size=256x256&size=512x512','https://kour.io'+asset.pathname+'?size=not-a-size','https://kour.io/content/stream/unknown.png']){
  const before=fetches;await assert.rejects(sandbox.window.fetch(target),{name:'SecurityError'});assert.equal(fetches,before);
 }
}
const socket=new sandbox.window.WebSocket('wss://example.com');await new Promise(resolve=>socket.addEventListener('close',resolve));assert.equal(socket.readyState,3);
const policy=sandbox.window.OfflinePolicy;
assert.throws(()=>policy.enablePhoton('not-an-app-id'),/valid Photon/);
assert.ok(!(new sandbox.window.WebSocket('wss://ns.photonengine.io/') instanceof NativeSocket));
policy.enablePhoton('00000000-0000-0000-0000-000000000000');
for(const url of ['wss://ns.photonengine.io/','wss://asia.exitgames.com/Master/'])assert.ok(new sandbox.window.WebSocket(url) instanceof NativeSocket);
for(const url of ['ws://ns.photonengine.io/','wss://kour.io/','wss://ns.photonengine.io.evil.example/','wss://user:password@ns.photonengine.io/'])assert.ok(!(new sandbox.window.WebSocket(url) instanceof NativeSocket));
await assert.rejects(sandbox.window.fetch('https://kour.io/'),{name:'SecurityError'});
policy.disablePhoton();assert.ok(!(new sandbox.window.WebSocket('wss://ns.photonengine.io/') instanceof NativeSocket));
assert.equal(sandbox.navigator.sendBeacon('https://example.com/',new Uint8Array()),false);
assert.equal(sandbox.window.open('https://kour.io/'),null);
let prevented=false;listeners.click({target:{closest:()=>({href:'https://example.com/'})},preventDefault:()=>prevented=true});assert.ok(prevented);
const original=fs.readFileSync('framework.js','utf8'),prepared=prepareFramework(original);assert.equal(prepared.manifest.changes.length,6);assert.ok(!prepared.source.includes('function _JS_Eval_OpenURL(ptr){var str=UTF8ToString(ptr);window.open'));assert.ok(prepared.source.includes('function _isCursorLocked(){if(_isMobileDevice())'));
assert.ok(!fs.readFileSync('game/style.css','utf8').includes('https://'));
console.log('Offline checks passed: exact PNG aliases stay local; external service/socket/beacon/link routes disabled; engine URL bridge neutralized; prototype fonts local.');
