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
const save=()=>fs.writeFileSync('local/multiplayer/online-presentation-test.json',JSON.stringify(evidence,null,2));
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
 await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',null,{timeout:Number(process.env.PHOTON_TEST_BOOT_TIMEOUT||120000)});await page.waitForTimeout(1600);await page.selectOption('#photon-region',process.env.PHOTON_TEST_REGION||'hk');
 return page;
}
async function snapshot(page,label){const value=await page.evaluate(()=>({photon:photonClient.inspect(),match:localKourStrikeRules.inspect()}));evidence.actions.push({label,value});save();console.log(label,JSON.stringify(value));return value}
const debugIds=['start','start-match','show-weapon','check-response','round-debug','photon-panel','log','mode-status','native-menu-controls'];
async function visibility(page){return page.evaluate(ids=>Object.fromEntries(ids.map(id=>{const el=document.getElementById(id);return[id,!!el&&getComputedStyle(el).display!=='none'&&el.getBoundingClientRect().height>0]})),debugIds)}
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true});
 const online=await boot('online');for(const [id,visible]of Object.entries(await visibility(online)))assert.equal(visible,true,'Lobby retains '+id);
 await online.evaluate(async room=>{await photonClient.create({appId:document.querySelector('#photon-app-id').value,nickname:'UI test',region:'hk',room})},'UI-'+Date.now().toString(36).toUpperCase());
 await online.waitForFunction(()=>document.body.classList.contains('online-match'),null,{timeout:30000});for(const [id,visible]of Object.entries(await visibility(online)))assert.equal(visible,false,'Online match hides '+id);
 assert.equal(await online.evaluate(()=>Math.round(document.querySelector('#canvas').getBoundingClientRect().height)===innerHeight),true,'Online game uses the freed viewport');
 await online.keyboard.press('Escape');await online.waitForFunction(()=>{const c=nativeSettingsContext();return c?.panel&&originalModule.asm.__indirect_function_table.get(11431)(c.panel,0)},null,{timeout:15000});await online.keyboard.press('Escape');
 const offline=await boot('offline');await offline.locator('#start-match').click();await offline.waitForFunction(()=>nativeSettingsContext()?.map,null,{timeout:30000});assert.equal(await offline.evaluate(()=>document.body.classList.contains('online-match')),false);for(const [id,visible]of Object.entries(await visibility(offline)))assert.equal(visible,true,'Local game retains '+id);
 await online.evaluate(()=>photonClient.native.fn('disconnect')(0));await online.waitForFunction(()=>!document.body.classList.contains('online-match'),null,{timeout:15000});
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;console.log('Online presentation verified: lobby/local diagnostics visible, online diagnostics hidden, full-height canvas, Escape settings available, controls restored after disconnect.');
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure)}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save()}
