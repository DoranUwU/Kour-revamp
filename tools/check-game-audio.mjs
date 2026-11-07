import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
const stored=new Map(),listeners=new Map(),contextListeners=new Set();
const sandbox={console,localStorage:{getItem:key=>stored.get(key)||null,setItem:(key,value)=>stored.set(key,value)},document:{querySelector:()=>null,addEventListener:(key,callback)=>listeners.set(key,callback),removeEventListener:(key,callback)=>{if(listeners.get(key)===callback)listeners.delete(key)}},window:{}};
vm.createContext(sandbox);vm.runInContext(fs.readFileSync('original-preview/game-audio.js','utf8'),sandbox);
const module={deinitializers:[],audioBackend:{audioWebEnabled:1,audioInstances:{}}},gain={gain:{value:1,cancelScheduledValues(){},setValueAtTime(value){this.value=value}}},context={state:'running',currentTime:0,addEventListener:(_,fn)=>contextListeners.add(fn),removeEventListener:(_,fn)=>contextListeners.delete(fn),async resume(){this.state='running'}};
const api=sandbox.window.createGameAudio(module);module.onAudioReady(context,gain);
assert.equal(gain.gain.value,0.8);api.setVolume(0.25);assert.equal(gain.gain.value,0.25);api.setMuted(true);assert.equal(gain.gain.value,0);api.setMuted(false);assert.equal(gain.gain.value,0.25);
assert.deepEqual(JSON.parse(stored.get('kour-revamp-audio')),{volume:0.25,muted:false});assert.throws(()=>api.setVolume(NaN));assert.equal(await api.resume(),true);
api.dispose();api.dispose();assert.equal(listeners.size,0);assert.equal(contextListeners.size,0);
// Execute the loader's real timer contract and verify ownership/cleanup.
const loader=fs.readFileSync('original-preview/loader.js','utf8'),start=loader.indexOf('function installRuntimeTimers('),end=loader.indexOf("document.querySelector('#start').onclick",start);
let next=1;const intervals=new Set(),timeouts=new Map();Object.assign(sandbox.window,{setInterval(){const id=next++;intervals.add(id);return id},clearInterval:id=>intervals.delete(id),setTimeout(callback){const id=next++;timeouts.set(id,callback);return id},clearTimeout:id=>timeouts.delete(id)});
vm.runInContext(loader.slice(start,end),sandbox);sandbox.timerModule={deinitializers:[]};vm.runInContext('installRuntimeTimers(timerModule)',sandbox);
const first=sandbox.timerModule.setInterval(()=>{},400);sandbox.timerModule.clearInterval(first);sandbox.timerModule.setInterval(()=>{},400);const timeout=sandbox.timerModule.setTimeout(()=>{},1);sandbox.timerModule.clearTimeout(timeout);sandbox.timerModule.setTimeout(()=>{},100);
for(const fn of sandbox.timerModule.deinitializers)fn();assert.equal(intervals.size,0);assert.equal(timeouts.size,0);
console.log('Game audio controls verified: native master gain, mute/volume persistence, listener disposal and loader-owned timer cleanup.');
