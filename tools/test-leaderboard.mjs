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
const save=()=>fs.writeFileSync('local/multiplayer/leaderboard-test.json',JSON.stringify(evidence,null,2));
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
async function choose(page,side){
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c)return false;const sf=h[(c+92)>>>2];const panel=h[sf>>>2],state=localKourStrikeRules.inspect();return !!panel&&!!state&&(m.asm.__indirect_function_table.get(11431)(panel,0)===1||state.teamCode===1||state.teamCode===2)},null,{timeout:30000});
 await page.waitForTimeout(650);await page.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(21203)(h[sf>>>2],photonClient.native.string(side),0)},side);
 const current=await page.evaluate(()=>localKourStrikeRules.inspect());if(current.teamCode!==(side==='t'?2:1))await page.evaluate(code=>{const r=localKourStrikeRules,c=r.native.context();if(c.code)r.native.fn('switchTeam')(c.local,code,0);else{const join=r.native.module.asm.__indirect_function_table.get(28160);if(join.name!=='74106')throw Error('Unknown native team fixture API');join(c.local,code,0)}},side==='t'?2:1);
 await page.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
}
async function enter(page,room,create){await page.evaluate(async({room,create})=>{restoreWeaponVisibility();await photonClient[create?'create':'join']({appId:document.querySelector('#photon-app-id').value,nickname:create?'Host':'Friend',region:document.querySelector('#photon-region').value,room})},{room,create})}
async function show(page){await page.bringToFront();await page.locator('#canvas').focus();await page.keyboard.down('Tab');await page.waitForFunction(()=>matchLeaderboard.inspect().visible);await page.waitForTimeout(500);const result=await page.evaluate(()=>matchLeaderboard.inspect());console.log(JSON.stringify(result));evidence.actions.push(result);save();return result}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,args:['--disable-background-timer-throttling','--disable-renderer-backgrounding','--disable-backgrounding-occluded-windows']});
 const room='BOARD-'+Date.now().toString(36).toUpperCase(),host=await boot('host');await enter(host,room,true);const guest=await boot('guest');await enter(guest,room,false);const enemy=await boot('enemy');await enter(enemy,room,false);
 await choose(host,'t');await choose(guest,'t');await choose(enemy,'ct');
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),800,0)});await host.waitForTimeout(1800);
 const alive=await show(host);assert.equal(alive.error,null);assert.equal(alive.rows.length,3);assert.ok(alive.rows.every(r=>r.status==='Alive'),'Spawned players must all be alive');assert.ok(alive.rows.every(r=>Number.isInteger(r.ping)&&r.ping>=0),'Each player publishes their own ping');
 await host.screenshot({path:'local/multiplayer/leaderboard-alive.png'});await host.keyboard.up('Tab');assert.equal(await host.locator('#match-leaderboard').isVisible(),false);
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('setState')(c.manager,r.native.fn('name')(c.manager,0),2,0,0)});
 // Native non-respawning death fixture and native death-stat update.
 await host.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,r=localKourStrikeRules,c=r.native.context(),k=h[6908040>>>2],net=h[(h[(k+92)>>>2]+56)>>>2],p=m.asm.malloc(16);try{const health=t.get(19878)(net,p,0);m.HEAPF32.set([0,0,0],p>>>2);t.get(19132)(health,c.local,0,photonClient.native.string('Molotov'),0,0);const lb=h[(h[(h[6906992>>>2]+92)>>>2]+16)>>>2];t.get(19385)(lb,0)}finally{m.asm.free(p)}});
 await host.waitForTimeout(800);const dead=await show(host);await host.screenshot({path:'local/multiplayer/leaderboard-dead.png'});assert.equal(dead.rows.find(r=>r.local).status,'Dead','Tab must work during native death/spectating');assert.ok(dead.rows.find(r=>r.local).deaths>alive.rows.find(r=>r.local).deaths,'Original death count must be preserved');
 await host.keyboard.up('Tab');const remote=await show(guest);assert.equal(remote.rows.find(r=>r.actor===dead.rows.find(r=>r.local).actor).status,'Dead','Remote client sees death');await guest.keyboard.up('Tab');
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),800,0)});await host.waitForTimeout(1200);const respawn=await show(host);assert.equal(respawn.rows.find(r=>r.local).status,'Alive');await host.keyboard.up('Tab');
 // Losing focus while holding Tab must not leave a stuck scoreboard.
 await show(host);await host.evaluate(()=>window.dispatchEvent(new Event('blur')));assert.equal(await host.locator('#match-leaderboard').isVisible(),false);await host.keyboard.up('Tab');
 await host.keyboard.press('Escape');await host.waitForTimeout(300);await host.keyboard.down('Tab');assert.equal(await host.locator('#match-leaderboard').isVisible(),false,'Settings retains keyboard focus');await host.keyboard.up('Tab');
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;console.log('Leaderboard verified: native death/spectating, local/remote ping and life status, native statistics, respawn, Tab release, blur and Settings.');
}catch(e){evidence.failure=e.stack||e.message;console.error(evidence.failure);process.exitCode=1}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save()}
