import fs from 'node:fs';
import assert from 'node:assert/strict';
import {createRequire} from 'node:module';
import os from 'node:os';
import path from 'node:path';
const require=createRequire(import.meta.url);
const cache=path.join(os.homedir(),'AppData/Local/npm-cache/_npx');
const cached=fs.existsSync(cache)?fs.readdirSync(cache).map(name=>path.join(cache,name,'node_modules/playwright-core')).find(p=>fs.existsSync(path.join(p,'package.json'))):null;
const {chromium}=require(process.env.PLAYWRIGHT_MODULE||cached||'playwright-core');
const origin='http://127.0.0.1:'+(process.env.ORIGINAL_PREVIEW_PORT||8088);
fs.mkdirSync('local/multiplayer',{recursive:true});
const lockPath='local/multiplayer/browser-test.lock',lock=fs.openSync(lockPath,'wx');
const delayMs=Number(process.env.PHOTON_TEST_DELAY_MS||0),evidence={started:new Date().toISOString(),delayMs,clients:[],errors:[],sockets:[],actions:[]};
const save=()=>fs.writeFileSync('local/multiplayer/browser-test.json',JSON.stringify(evidence,null,2));
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
 await page.goto(origin);await page.evaluate(()=>{window.PhotonDebug=true});await page.locator('#start').click();
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
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const host=await boot('host'),room='TEST-'+Date.now().toString(36).toUpperCase();
 await host.evaluate(room=>{restoreWeaponVisibility();window.testEntry=photonClient.create({appId:document.querySelector('#photon-app-id').value,nickname:'Host',region:document.querySelector('#photon-region').value,room}).then(()=>({ok:true}),e=>({error:e.stack||e.message}))},room);
 await host.waitForFunction(()=>photonClient.inspect().inRoom&&!photonClient.inspect().offline||!photonClient.inspect().busy,null,{timeout:35000});
 const hostEntry=await host.evaluate(()=>window.testEntry);assert.equal(hostEntry.error,undefined,hostEntry.error);
 await snapshot(host,'host-in-room');
 if(process.argv.includes('--connect-only')){assert.deepEqual(evidence.errors,[]);evidence.passed=true;}
 else{
  const guest=await boot('guest');
  await guest.evaluate(room=>{restoreWeaponVisibility();window.testEntry=photonClient.join({appId:document.querySelector('#photon-app-id').value,nickname:'Guest',region:document.querySelector('#photon-region').value,room}).then(()=>({ok:true}),e=>({error:e.stack||e.message}))},room);
  await guest.waitForFunction(()=>photonClient.inspect().inRoom&&!photonClient.inspect().offline,null,{timeout:35000});
  for(const p of [host,guest])await p.waitForFunction(()=>photonClient.inspect().players===2,null,{timeout:15000});
  await snapshot(host,'host-with-guest');await snapshot(guest,'guest-in-room');
  for(const [p,side]of [[host,'t'],[guest,'ct']]){
   await p.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c||c>m.HEAPU8.length)return false;const sf=h[(c+92)>>>2],panel=h[sf>>>2];return panel&&panel<m.HEAPU8.length&&!!localKourStrikeRules.inspect()},null,{timeout:30000});
   await p.waitForTimeout(500);await p.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2],panel=h[sf>>>2];m.asm.__indirect_function_table.get(21203)(panel,photonClient.native.string(side),0)},side);
   await p.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
  }
  await snapshot(host,'host-team');await snapshot(guest,'guest-team');
  await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),0,0)});
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round>=1,null,{timeout:15000});
  await host.waitForTimeout(1500);await snapshot(host,'host-round1');await snapshot(guest,'guest-round1');
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000});
  await host.bringToFront();await host.mouse.click(1060,418);await host.waitForTimeout(650);await host.mouse.click(640,270);await host.waitForTimeout(350);
  const walkingBefore=await actors(host),walker=walkingBefore.find(a=>a.mine);
  await host.keyboard.down('w');await host.waitForTimeout(700);await host.keyboard.up('w');await host.waitForTimeout(700);
  const walking=await playerSnapshot(host,guest,'ordinary-walking'),walked=walking[0].find(a=>a.mine),observed=walking[1].find(a=>a.actor===walked.actor);
  assert.ok(Math.hypot(...walked.position.map((v,i)=>v-walker.position[i]))>1,'Keyboard walking must move the local player');
  assert.ok(Math.hypot(...walked.position.map((v,i)=>v-observed.position[i]))<1,'Ordinary walking must replicate to the other client');
  await teleport(host,[29,6.6,-44]);await teleport(guest,[29,6.6,-38],true);
  const first=await playerSnapshot(host,guest,'replicated-positions');
  for(const list of first){assert.equal(list.length,2);assert.equal(list.filter(a=>a.mine).length,1)}
  for(const a of first[0]){const b=first[1].find(b=>b.actor===a.actor);assert.ok(b);assert.ok(Math.hypot(...a.position.map((v,i)=>v-b.position[i]))<1,'Native player transforms must converge')}
  if(!process.argv.includes('--movement-only')){
  // Test setup publishes round 11 then calls the same native StartRound used
  // by the game. Round 12 -> 13 itself uses the ordinary round-end flow.
  await host.evaluate(()=>{const r=localKourStrikeRules,{module:m,fn,context,key,publish,u32}=r.native,c=context(),out=m.asm.malloc(4);try{fn('setState')(c.manager,fn('name')(c.manager,0),0,0,0);m.HEAP32[out>>>2]=11;const value=fn('box')(u32(8037700),out),props=fn('clone')(u32(c.room+12),0);fn('put')(props,key('CurrentRound'),value,0);publish(c.room,props)}finally{m.asm.free(out)}});
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round===11,null,{timeout:10000});
  await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),0,0)});
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round===12&&localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000});
  await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('endRound')(c.manager,r.native.fn('name')(c.manager,0),0)});
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round===13,null,{timeout:30000});
  await host.waitForTimeout(1200);
  const h13=await snapshot(host,'host-halftime'),g13=await snapshot(guest,'guest-halftime');
  assert.equal(h13.match.teamCode,1);assert.equal(g13.match.teamCode,2);assert.equal(h13.match.bombHolder,g13.match.bombHolder);assert.equal(g13.match.bombHolder,2);
  const after=await playerSnapshot(host,guest,'halftime-actors');for(const list of after)assert.equal(list.length,2,'Each client must have exactly one actor per player after swap');
  for(let i=0;i<2;i++)assert.notEqual(after[i].find(a=>a.mine).shooter,first[i].find(a=>a.mine).shooter,'Halftime must replace each local player');
  for(const p of [host,guest])await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000});
  await teleport(host,[29,6.6,-44]);await teleport(guest,[29,6.6,-38],true);await host.waitForTimeout(3500);
  const hpBefore=(await actors(guest)).find(a=>a.mine).hp;
  await host.evaluate(()=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],controller=h[(shooter+116)>>>2],t=m.asm.__indirect_function_table;t.get(17469)(controller,1,0);t.get(17472)(controller,0);t.get(20706)(shooter,0,0)});
  await host.waitForTimeout(1000);const combat=await playerSnapshot(host,guest,'native-shot');const victim=combat[1].find(a=>a.mine);assert.ok(!victim||victim.hp<hpBefore,'Actual native raycast shooting must damage the remote player');
  if(victim)assert.equal(combat[0].find(a=>a.actor===victim.actor).hp,victim.hp,'Damage must agree across clients');
  }
  if(delayMs){const counters=await Promise.all([host,guest].map(p=>p.evaluate(()=>window.photonTestDelays)));for(const count of counters){assert.ok(count.sent>0);assert.ok(count.received>0)}evidence.delayCounters=counters;}
  await guest.evaluate(()=>photonClient.native.fn('disconnect')(0));
  await host.waitForFunction(()=>photonClient.inspect().players===1,null,{timeout:15000});await snapshot(host,'guest-disconnected');
  await host.screenshot({path:'local/multiplayer/host.png'});await guest.screenshot({path:'local/multiplayer/guest.png'});
  for(const client of evidence.clients)assert.ok(client.requests.every(url=>new URL(url).origin===origin),'Game assets/services must stay local');assert.deepEqual(evidence.errors,[]);evidence.passed=true;
 }
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure)}
finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,failure:evidence.failure}))}
