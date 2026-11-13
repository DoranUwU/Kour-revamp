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
const save=()=>fs.writeFileSync('local/multiplayer/molotov-test.json',JSON.stringify(evidence,null,2));
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
 await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',null,{timeout:120000});await page.waitForTimeout(1600);await page.selectOption('#photon-region',process.env.PHOTON_TEST_REGION||'hk');
 return page;
}
async function teleport(page,position,reverse=false){await page.evaluate(({position,reverse})=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],p=m.asm.malloc(28);try{m.HEAPF32.set(position,p>>>2);m.HEAPF32.set(reverse?[0,1,0,0]:[0,0,0,1],(p+12)>>>2);t.get(20673)(shooter,p,p+12,0)}finally{m.asm.free(p)}},{position,reverse});await page.waitForTimeout(800)}
async function choose(page,side){
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c)return false;const sf=h[(c+92)>>>2];const panel=h[sf>>>2],state=localKourStrikeRules.inspect();return !!panel&&!!state&&(m.asm.__indirect_function_table.get(11431)(panel,0)===1||state.teamCode===1||state.teamCode===2)},null,{timeout:30000});
 await page.waitForTimeout(650);await page.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(21203)(h[sf>>>2],photonClient.native.string(side),0)},side);
 const current=await page.evaluate(()=>localKourStrikeRules.inspect());if(current.teamCode!==(side==='t'?2:1))await page.evaluate(code=>{const r=localKourStrikeRules,c=r.native.context();if(c.code)r.native.fn('switchTeam')(c.local,code,0);else{const join=r.native.module.asm.__indirect_function_table.get(28160);if(join.name!=='74106')throw Error('Unknown native team fixture API');join(c.local,code,0)}},side==='t'?2:1);
 await page.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
}
async function enter(page,room,create){await page.evaluate(async({room,create})=>{restoreWeaponVisibility();await photonClient[create?'create':'join']({appId:document.querySelector('#photon-app-id').value,nickname:create?'Host':'Friend',region:document.querySelector('#photon-region').value,room})},{room,create})}
async function fireState(page){return page.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,k=h[6910700>>>2],sf=h[(k+92)>>>2],sh=h[sf>>>2],controller=h[(sh+116)>>>2],health=h[(sh+108)>>>2],tag=photonClient.native.string('MolotovZone'),array=t.get(40621)(tag,0),zones=[];if(array)for(let i=0;i<h[(array+12)>>>2];i++){const go=h[(array+16+i*4)>>>2],p=m.asm.malloc(12);try{t.get(2965)(p,t.get(3125)(go,0),0);zones.push({go,name:photonClient.native.text?.(t.get(3300)(go,0)),pos:Array.from(m.HEAPF32.subarray(p>>>2,(p>>>2)+3))})}finally{m.asm.free(p)}}return{rules:window.molotovRules?.inspect(),time:t.get(12372)(0),ammo:t.get(20725)(sh,0),slot:m.HEAP32[(sf+12)>>>2],hp:t.get(15309)(health+108,0),zone:m.HEAP32[(controller+292)>>>2],zones}})}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,args:['--disable-background-timer-throttling','--disable-renderer-backgrounding','--disable-backgrounding-occluded-windows']});
 const room='FIRE-'+Date.now().toString(36).toUpperCase(),host=await boot('thrower');await enter(host,room,true);const teammate=await boot('teammate');await enter(teammate,room,false);const enemy=await boot('enemy');await enter(enemy,room,false);const pages=[host,teammate,enemy];
 await choose(host,'t');await choose(teammate,'t');await choose(enemy,'ct');
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),800,0)});
 for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===1,null,{timeout:15000});

 await teleport(host,[26,6.6,-44]);await teleport(teammate,[29,6.6,-44]);await teleport(enemy,[32,6.6,-44]);
 // Deterministic fire fixture: instantiate the same native explosion prefab on
 // each replica, as RpcExploadAt does. Damage/ownership/team checks are untouched.
 await Promise.all(pages.map(p=>p.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,k=h[6913232>>>2],sf=h[(k+92)>>>2],cfg=h[(h[(sf+4)>>>2]+16)>>>2],weapons=h[(cfg+56)>>>2],w=h[(weapons+16+33*4)>>>2],buf=m.asm.malloc(28);try{m.HEAPF32.set([29,5.95,-44,0,0,0,1],buf>>>2);t.get(40774)(h[(w+264)>>>2],buf,buf+12,0);const zones=t.get(40621)(photonClient.native.string('MolotovZone'),0);for(let i=0;i<h[(zones+12)>>>2];i++)t.get(4956)(h[(zones+16+i*4)>>>2],photonClient.native.string('1'),0)}finally{m.asm.free(buf)}})));
await host.waitForTimeout(700);const buying=await Promise.all(pages.map(fireState));for(const state of buying)assert.equal(state.hp,100,'No fire damage during buy time');evidence.actions.push({label:'buy-phase-immunity',states:buying});await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('setState')(c.manager,r.native.fn('name')(c.manager,0),2,0,0)});for(let i=0;i<8;i++){await host.waitForTimeout(600);const states=await Promise.all(pages.map(fireState));evidence.actions.push({tick:i,states});save();if(i===0)await teleport(host,[44,6.6,-44]);console.log(JSON.stringify({tick:i,health:states.map(s=>s.hp),rules:states.map(s=>s.rules)}));}
 const ticks=evidence.actions.filter(a=>Number.isInteger(a.tick));assert.ok(ticks.some(a=>a.states[0].hp<100),'Thrower must take fire damage');assert.ok(ticks.some(a=>a.states[2].hp<100),'Enemy must take fire damage');assert.ok(ticks.every(a=>a.states[1].hp===100),'Teammate must remain immune');assert.ok(ticks.slice(1).every(a=>a.states[0].rules.burns===ticks[0].states[0].rules.burns&&!a.states[0].rules.last.inside),'Leaving the fire must stop self damage');assert.ok(ticks.every(a=>a.states.every(s=>s.rules&&!s.rules.faulted)),'Fire rules must remain healthy on every client');assert.deepEqual(evidence.errors,[]);evidence.passed=true;console.log('Molotov verified: self/enemy damage, teammate and buy-phase immunity, exit stops damage, no runtime errors.');
}catch(e){evidence.failure=e.stack||e.message;console.error(evidence.failure);process.exitCode=1}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save()}
