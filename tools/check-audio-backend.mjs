import fs from 'node:fs';
import vm from 'node:vm';
import assert from 'node:assert/strict';
import {prepareFramework} from './original-framework.mjs';
const original=fs.readFileSync('framework.js','utf8'),source=prepareFramework(original).source;
const extract=(start,end)=>source.slice(source.indexOf(start),source.indexOf(end,source.indexOf(start)));
const init=extract('function _JS_Sound_Init(){','function jsAudioCreateUncompressedSoundClipFromCompressedAudio');
const channel=extract('function jsAudioCreateChannel(callback,userData){','function _JS_Sound_Create_Channel');
function fixture(timers){
 const alerts=[],edges=[],destination={},node=()=>({gain:{value:1},connect(target){edges.push([this,target])},disconnect(){}});
 const context={state:'suspended',currentTime:0,destination,createGain:node,createPanner:()=>({...node(),rolloffFactor:1}),resume:async()=>{}};
 const module={deinitializers:[],...(timers?{setInterval:()=>1,clearInterval(){}}:{})};
 const backend={audioWebEnabled:0,audioInstances:{},audioCache:[],soundsPendingContextResume:[]};
 let ready=null;module.onAudioReady=(ctx,master)=>ready={ctx,master};
 const sandbox={window:{addEventListener(){},removeEventListener(){},AudioContext:function(){return context}},AudioContext:function(){return context},Audio:function(){},WEBAudio:backend,Module:module,_GetFakemodTimeInSeconds:()=>0,console:{log(){},warn(){}},alert:message=>alerts.push(message)};
 vm.createContext(sandbox);vm.runInContext(init+';_JS_Sound_Init()',sandbox);
 return{sandbox,module,backend,ready,alerts,edges,destination};
}
const missing=fixture(false);assert.equal(missing.backend.audioWebEnabled,0);assert.equal(missing.alerts.length,1,'Missing host timers must reproduce the native audio-init failure');
const fixed=fixture(true);assert.equal(fixed.backend.audioWebEnabled,1);assert.deepEqual(fixed.alerts,[]);assert.equal(fixed.module.audioBackend,fixed.backend);assert.equal(fixed.ready.ctx,fixed.backend.audioContext);assert.equal(fixed.ready.master,fixed.backend.masterGain);
assert.ok(fixed.edges.some(([from,to])=>from===fixed.backend.masterGain&&to===fixed.destination));
vm.runInContext(channel+';testChannel=jsAudioCreateChannel(0,0);testChannel.source={connect(){},disconnect(){}};testChannel.configurePanningNodes()',fixed.sandbox);
assert.ok(fixed.edges.some(([from,to])=>from===fixed.sandbox.testChannel.gain&&to===fixed.backend.masterGain),'Actual native channel graph must route through the volume/mute master');
assert.ok(!fixed.edges.some(([from,to])=>from===fixed.sandbox.testChannel.gain&&to===fixed.destination),'Native channels must not bypass volume/mute controls');
console.log('Native audio backend verified: missing-timer reproduction, enabled initialization, backend exposure, master output and native channel routing.');
