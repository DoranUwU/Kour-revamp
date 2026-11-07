import {readAudioState} from './audio-state-probe.mjs';
import fs from 'node:fs';
import assert from 'node:assert/strict';
import {createRequire} from 'node:module';
import os from 'node:os';
import path from 'node:path';
const require=createRequire(import.meta.url);
const cache=path.join(os.homedir(),'AppData/Local/npm-cache/_npx');
const cached=fs.existsSync(cache)?fs.readdirSync(cache).map(name=>path.join(cache,name,'node_modules/playwright-core')).find(p=>fs.existsSync(path.join(p,'package.json'))):null;
const {chromium}=require(process.env.PLAYWRIGHT_MODULE||cached||'playwright-core');
const target=process.env.PHOTON_TEST_URL||('http://127.0.0.1:'+(process.env.ORIGINAL_PREVIEW_PORT||8088));
const origin=new URL(target).origin;
fs.mkdirSync('local/multiplayer',{recursive:true});
const lockPath='local/multiplayer/browser-test.lock',lock=fs.openSync(lockPath,'wx');
const delayMs=Number(process.env.PHOTON_TEST_DELAY_MS||0),evidence={started:new Date().toISOString(),delayMs,clients:[],errors:[],sockets:[],actions:[]};
const save=()=>fs.writeFileSync('local/multiplayer/spatial-audio-test.json',JSON.stringify(evidence,null,2));
let browser;
async function boot(label){
 const ctx=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'}),page=await ctx.newPage();
 if(delayMs)await ctx.addInitScript(delay=>{
  const Native=window.WebSocket;window.photonTestDelays={sent:0,received:0};
  window.WebSocket=class extends Native{
   constructor(...args){super(...args);let handler=null,wrapped=null;Object.defineProperty(this,'onmessage',{get:()=>handler,set:value=>{if(wrapped)super.removeEventListener('message',wrapped);handler=value;wrapped=typeof value==='function'?event=>{window.photonTestDelays.received++;setTimeout(()=>{if(this.readyState===Native.OPEN)value.call(this,event)},delay)}:null;if(wrapped)super.addEventListener('message',wrapped)}})}
   send(value){const copy=ArrayBuffer.isView(value)?value.slice():value instanceof ArrayBuffer?value.slice(0):value;window.photonTestDelays.sent++;setTimeout(()=>{if(this.readyState===Native.OPEN)super.send(copy)},delay)}
  };
 },delayMs);
 const record={label,console:[],requests:[]};evidence.clients.push(record);
 page.on('pageerror',e=>{evidence.errors.push({label,error:e.stack||e.message});save()});
 page.on('console',m=>{record.console.push(m.text());save()});
 page.on('websocket',ws=>{const socket={label,url:ws.url(),received:0,sent:0};evidence.sockets.push(socket);for(const [event,key]of [['framereceived','received'],['framesent','sent']])ws.on(event,()=>{socket[key]++});save()});
 page.on('request',r=>{record.requests.push(r.url());save()});
 await page.goto(target);await page.evaluate(()=>{window.PhotonDebug=true});await page.locator('#start').click();
 await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',null,{timeout:45000});await page.waitForTimeout(1600);await page.selectOption('#photon-region',process.env.PHOTON_TEST_REGION||'asia');
 return page;
}
async function snapshot(page,label){const value=await page.evaluate(()=>({photon:photonClient.inspect(),match:localKourStrikeRules.inspect()}));evidence.actions.push({label,value});save();console.log(label,JSON.stringify(value));return value}
async function actors(page){return page.evaluate(()=>{
 const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6908788>>>2],sf=h[(c+92)>>>2],set=h[(sf+4)>>>2],slots=h[(set+12)>>>2],last=m.HEAP32[(set+20)>>>2],out=m.asm.malloc(16),result=[];
 try{for(let i=0;i<last;i++){const slot=slots+16+i*12;if(m.HEAP32[slot>>>2]<0)continue;const shooter=h[(slot+8)>>>2];if(!shooter)continue;const view=t.get(27903)(shooter,0),health=h[(shooter+108)>>>2],transform=t.get(2964)(shooter,0);t.get(2965)(out,transform,0);result.push({shooter,actor:t.get(27871)(view,0),mine:!!t.get(27860)(view,0),hp:t.get(15309)(health+108,0),position:Array.from(m.HEAPF32.subarray(out>>>2,(out>>>2)+3))})}return result}finally{m.asm.free(out)}
})}
async function teleport(page,position,reverse=false){await page.evaluate(({position,reverse})=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],p=m.asm.malloc(28);try{m.HEAPF32.set(position,p>>>2);m.HEAPF32.set(reverse?[0,1,0,0]:[0,0,0,1],(p+12)>>>2);t.get(20673)(shooter,p,p+12,0)}finally{m.asm.free(p)}},{position,reverse});await page.waitForTimeout(800)}
async function playerSnapshot(host,guest,label){const pair=[await actors(host),await actors(guest)];evidence.actions.push({label,actors:pair});save();console.log(label,JSON.stringify(pair));return pair}
async function choose(page,side){
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c)return false;const sf=h[(c+92)>>>2];return !!h[sf>>>2]&&!!localKourStrikeRules.inspect()},null,{timeout:30000});await page.waitForTimeout(650);
 await page.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(21203)(h[sf>>>2],photonClient.native.string(side),0)},side);
 await page.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
}
async function enter(page,room,create){await page.evaluate(async({room,create})=>{await photonClient[create?'create':'join']({appId:document.querySelector('#photon-app-id').value,nickname:create?'Walker':'Listener',region:document.querySelector('#photon-region').value,room})},{room,create})}
async function facing(page){await page.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],controller=h[(shooter+116)>>>2];t.get(17469)(controller,1,0);t.get(17472)(controller,0)})}
async function meter(page){return page.evaluate(()=>{
 const b=originalModule.audioBackend,ctx=b.audioContext;
 window.audioQATaps??=new Map();
 for(const [id,c]of Object.entries(b.audioInstances))if(c.gain&&c.loop&&c.spatialBlendLevel>0&&c.source?.buffer?.duration<1&&c.source?.buffer?.duration>0.2&&!audioQATaps.has(id)){
  const split=ctx.createChannelSplitter(2),left=ctx.createAnalyser(),right=ctx.createAnalyser(),sink=ctx.createGain();left.fftSize=right.fftSize=2048;sink.gain.value=0;c.gain.connect(split);split.connect(left,0);split.connect(right,1);left.connect(sink);right.connect(sink);sink.connect(ctx.destination);audioQATaps.set(id,{left,right});
 }
 const rms=node=>{const a=new Float32Array(node.fftSize);node.getFloatTimeDomainData(a);return Math.sqrt(a.reduce((s,v)=>s+v*v,0)/a.length)};
 return [...audioQATaps].map(([id,t])=>({id,left:rms(t.left),right:rms(t.right),gain:b.audioInstances[id]?.gain?.gain.value??0}));
})}
async function audioSnapshot(page,label){const state=await page.evaluate(readAudioState);evidence.actions.push({label,state});save();return state}
async function walkSample(walker,listener,label){await walker.bringToFront();await walker.keyboard.down('w');const readings=[];try{for(let i=0;i<8;i++){await listener.waitForTimeout(120);readings.push(await meter(listener))}}finally{await walker.keyboard.up('w')}const state=await audioSnapshot(listener,label);evidence.actions.push({label:label+'-meter',readings});save();const left=Math.max(0,...readings.flat().map(x=>x.left)),right=Math.max(0,...readings.flat().map(x=>x.right));console.log(label,JSON.stringify({left,right,nativeError:state.nativeError,remote:state.players.find(p=>!p.mine)}));return{left,right,energy:left+right,state}}
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const room='AUDIO-'+Date.now().toString(36).toUpperCase(),walker=await boot('walker');await enter(walker,room,true);
 const listener=await boot('listener');await enter(listener,room,false);await choose(walker,'t');await choose(listener,'ct');
 await walker.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),0,0)});
 for(const p of [walker,listener])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000});
 await walker.bringToFront();await walker.mouse.click(1060,418);await walker.waitForTimeout(650);await walker.mouse.click(640,270);await walker.waitForTimeout(300);
 for(const p of [walker,listener]){await p.evaluate(async()=>{await gameAudio.resume();gameAudio.setMuted(false);gameAudio.setVolume(1)});await p.waitForTimeout(100);const s=await p.evaluate(()=>gameAudio.inspect());assert.equal(s.enabled,true);assert.equal(s.state,'running');assert.equal(s.failedClips,0);assert.ok(s.decodedClips>0)}
 await teleport(listener,[34,6.6,-38]);await facing(listener);await teleport(walker,[29,6.6,-44]);await facing(walker);
 const left=await walkSample(walker,listener,'enemy-left');assert.equal(left.state.nativeError,null);assert.ok(left.energy>0.0001,'Enemy footsteps must render nonzero PCM');assert.ok(left.left>left.right*1.1,'Enemy on the left must be louder in the left channel');
 await listener.waitForTimeout(1200);const idle=await meter(listener);evidence.actions.push({label:'idle-meter',readings:idle});save();assert.ok(Math.max(0,...idle.map(x=>x.left+x.right))<left.energy*0.05,'Stationary enemy footsteps must be silent');
 await teleport(listener,[24,6.6,-38]);await facing(listener);await teleport(walker,[29,6.6,-44]);await facing(walker);
 const right=await walkSample(walker,listener,'enemy-right');assert.ok(right.energy>0.0001);assert.ok(right.right>right.left*1.1,'Enemy on the right must be louder in the right channel');
 await teleport(listener,[80,-2.9,115]);await facing(listener);await teleport(walker,[29,6.6,-44]);await facing(walker);
 const far=await walkSample(walker,listener,'enemy-out-of-range');assert.ok(far.energy<Math.max(left.energy,right.energy)*0.05,'Distant footsteps must be strongly attenuated');
 await listener.evaluate(()=>{gameAudio.setVolume(0.25);gameAudio.setMuted(true)});await listener.waitForTimeout(100);let controls=await listener.evaluate(()=>gameAudio.inspect());assert.equal(controls.gain,0);await listener.evaluate(()=>gameAudio.setMuted(false));await listener.waitForTimeout(100);controls=await listener.evaluate(()=>gameAudio.inspect());assert.ok(Math.abs(controls.gain-0.25)<0.0001);evidence.actions.push({label:'volume-mute-controls',state:controls});
 // Exercise an existing native sound effect as well as looping footsteps.
 const shot=await walker.evaluate(async()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2];t.get(20724)(shooter,1,1,0);await new Promise(r=>setTimeout(r,1000));const weapon=h[(shooter+224)>>>2],source=h[(weapon+192)>>>2],clip=t.get(38049)(source,0);if(!clip)throw Error('Native weapon sound clip missing');const name=t.get(3300)(clip,0),length=h[(name+8)>>>2],clipName=String.fromCharCode(...m.HEAPU16.subarray((name+12)>>>1,((name+12)>>>1)+length)),duration=t.get(38028)(clip,0);t.get(20706)(shooter,0,0);let playing=false;for(let i=0;i<6;i++){await new Promise(r=>setTimeout(r,35));playing ||= !!t.get(38060)(source,0)}return{clipName,duration,playing,audio:gameAudio.inspect()}});
 evidence.actions.push({label:'native-gunshot',state:shot});save();assert.ok(shot.playing,'Native gunshot AudioSource must play');assert.equal(shot.audio.failedClips,0);
 assert.deepEqual(evidence.errors,[]);for(const client of evidence.clients)assert.ok(!client.console.some(s=>s.includes('Loading FSB failed')||s.includes('Decode error:')),'Native clip loading must remain healthy');evidence.passed=true;
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure)}
finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,failure:evidence.failure}))}
