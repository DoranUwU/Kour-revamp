import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
import {prepareFramework} from './original-framework.mjs';
import {meshBundles} from './local-bundles.mjs';
let fetches=0,xhrs=0;const listeners={};
class XHR{open(){xhrs++}}
class TestCloseEvent extends Event{constructor(type,options){super(type);Object.assign(this,options)}}
const sandbox={URL,Event,EventTarget,CloseEvent:TestCloseEvent,DOMException,setTimeout,console:{info(){}},location:{href:'http://localhost:8082/',origin:'http://localhost:8082'},navigator:{},XMLHttpRequest:XHR,document:{addEventListener:(name,fn)=>listeners[name]=fn},window:{fetch:async()=>{fetches++;return{ok:true}}}};
vm.createContext(sandbox);vm.runInContext(fs.readFileSync('original-preview/offline-policy.js','utf8'),sandbox);
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
const socket=new sandbox.window.WebSocket('wss://example.com');await new Promise(resolve=>socket.addEventListener('close',resolve));assert.equal(socket.readyState,3);
assert.equal(sandbox.navigator.sendBeacon('https://example.com/',new Uint8Array()),false);
assert.equal(sandbox.window.open('https://kour.io/'),null);
let prevented=false;listeners.click({target:{closest:()=>({href:'https://example.com/'})},preventDefault:()=>prevented=true});assert.ok(prevented);
const original=fs.readFileSync('framework.js','utf8'),prepared=prepareFramework(original);assert.equal(prepared.manifest.changes.length,5);assert.ok(!prepared.source.includes('function _JS_Eval_OpenURL(ptr){var str=UTF8ToString(ptr);window.open'));assert.ok(prepared.source.includes('function _isCursorLocked(){if(_isMobileDevice())'));
assert.ok(!fs.readFileSync('game/style.css','utf8').includes('https://'));
console.log('Offline checks passed: local assets allowed; external fetch/XHR/socket/beacon/link routes disabled; engine URL bridge neutralized; prototype fonts local.');
