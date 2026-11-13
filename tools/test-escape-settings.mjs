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
const save=()=>fs.writeFileSync('local/multiplayer/escape-settings-test.json',JSON.stringify(evidence,null,2));
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
async function choose(page,side){
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c)return false;const sf=h[(c+92)>>>2];const panel=h[sf>>>2],state=localKourStrikeRules.inspect();return !!panel&&!!state&&(m.asm.__indirect_function_table.get(11431)(panel,0)===1||state.teamCode===1||state.teamCode===2)},null,{timeout:30000});
 await page.waitForTimeout(650);await page.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(21203)(h[sf>>>2],photonClient.native.string(side),0)},side);
 const current=await page.evaluate(()=>localKourStrikeRules.inspect());if(current.teamCode!==(side==='t'?2:1))await page.evaluate(code=>{const r=localKourStrikeRules,c=r.native.context();if(c.code)r.native.fn('switchTeam')(c.local,code,0);else{const join=r.native.module.asm.__indirect_function_table.get(28160);if(join.name!=='74106')throw Error('Unknown native team fixture API');join(c.local,code,0)}},side==='t'?2:1);
 await page.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
}
async function enter(page,room,create){await page.evaluate(async({room,create})=>{restoreWeaponVisibility();await photonClient[create?'create':'join']({appId:document.querySelector('#photon-app-id').value,nickname:create?'Host':'Friend',region:document.querySelector('#photon-region').value,room})},{room,create})}
async function wallet(page){return page.evaluate(()=>{const r=localKourStrikeRules,m=originalModule,t=m.asm.__indirect_function_table,c=r.native.context(),p=m.asm.malloc(20);try{t.get(20425)(p,0);return{cash:t.get(15309)(p,0),streak:m.HEAP32[(c.manager+160)>>>2],reward:m.HEAP32[(c.manager+156)>>>2],...r.inspect()}}finally{m.asm.free(p)}})}
async function active(page){return page.evaluate(()=>{const c=nativeSettingsContext();return !!c?.panel&&originalModule.asm.__indirect_function_table.get(11431)(c.panel,0)===1})}
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true});
 const page=await boot('escape-settings');await page.locator('#start-match').click();await choose(page,'ct');
 await page.waitForFunction(()=>nativeSettingsContext()?.map,null,{timeout:20000});
 await page.locator('#canvas').focus();await page.keyboard.press('Escape');await page.waitForFunction(()=>{const c=nativeSettingsContext();return c?.panel&&originalModule.asm.__indirect_function_table.get(11431)(c.panel,0)},null,{timeout:15000});assert.equal(await active(page),true);evidence.actions.push({label:'escape-opens-match-settings'});
 await page.keyboard.press('Escape');await page.waitForTimeout(1800);assert.equal(await active(page),false);evidence.actions.push({label:'escape-closes-match-settings'});
 await page.evaluate(()=>document.querySelector('#canvas').requestPointerLock());await page.waitForTimeout(300);const locked=await page.evaluate(()=>!!document.pointerLockElement);evidence.actions.push({label:'pointer-lock-before-escape',locked});
 await page.keyboard.press('Escape');await page.waitForTimeout(1800);assert.equal(await active(page),true,'Escape with pointer lock must open settings');
 await page.screenshot({path:'local/multiplayer/escape-match-settings.png'});assert.deepEqual(evidence.errors,[]);evidence.passed=true;
}catch(e){evidence.failure=e.stack||e.message;console.error(evidence.failure);process.exitCode=1}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save();console.log(JSON.stringify({passed:evidence.passed,failure:evidence.failure,errors:evidence.errors}))}
