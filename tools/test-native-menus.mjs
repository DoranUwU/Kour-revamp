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
const save=()=>fs.writeFileSync('local/multiplayer/native-menus-test.json',JSON.stringify(evidence,null,2));
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
async function settings(page){return page.evaluate(()=>{const m=originalModule,t=m.asm.__indirect_function_table,p=m.asm.malloc(4);try{if(!t.get(12367)(p,0))return null;const ui=m.HEAPU32[p>>>2],panel=m.HEAPU32[(ui+256)>>>2];if(!panel)return null;return{panel,active:t.get(11431)(panel,0),fov:t.get(58679)(m.HEAPU32[(panel+180)>>>2],0)}}finally{m.asm.free(p)}})}
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true});
 const page=await boot('native-menus');await page.locator('#open-settings').click();
 await page.waitForFunction(()=>{const m=originalModule,t=m.asm.__indirect_function_table,p=m.asm.malloc(4);try{if(!t.get(12367)(p,0))return false;const ui=m.HEAPU32[p>>>2],panel=m.HEAPU32[(ui+256)>>>2];return panel&&t.get(11431)(panel,0)}finally{m.asm.free(p)}},null,{timeout:15000});
 await page.screenshot({path:"local/multiplayer/settings-before-close.png"});const initial=await settings(page);assert.equal(initial.active,1);
 await page.evaluate(panel=>{const m=originalModule;m.asm.__indirect_function_table.get(58680)(m.HEAPU32[(panel+180)>>>2],95,0)},initial.panel);
 assert.equal((await settings(page)).fov,95);
 await page.mouse.click(24,21,{delay:120});await page.waitForTimeout(1800);assert.equal((await settings(page)).active,0);assert.equal(await page.evaluate(()=>document.body.classList.contains('native-menu-open')),false);
 await page.locator('#open-settings').click();await page.waitForTimeout(700);assert.equal((await settings(page)).fov,95,'Native FOV preference survives reopening');await page.screenshot({path:'local/multiplayer/settings-restored.png'});
 await page.mouse.click(24,21,{delay:120});await page.waitForTimeout(1800);await page.locator('#open-customize').click();await page.waitForTimeout(2000);
 await page.mouse.click(738,80,{delay:120});await page.waitForTimeout(700);await page.mouse.click(300,270,{delay:120});await page.waitForTimeout(1000);await page.mouse.click(623,214,{delay:120});await page.waitForTimeout(1500);await page.screenshot({path:'local/multiplayer/customize-restored.png'});
 await page.keyboard.press('Escape');await page.waitForTimeout(1800);assert.equal(await page.evaluate(()=>document.body.classList.contains('native-menu-open')),false,'Escape closes Customize without opening Settings');
 const requests=evidence.clients[0].requests;for(const name of ['settingspanel','classselectpanel'])assert.ok(requests.some(u=>u.includes('/StreamingAssets/'+name)));
 assert.ok(requests.some(u=>u.includes('/content/stream/characters/icons/P0.png')),'Character icon is served locally');
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;evidence.actions.push({label:'native-settings-change',initial,after:await settings(page)});
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure)}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,failure:evidence.failure}))}
