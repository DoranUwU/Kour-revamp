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
const save=()=>fs.writeFileSync('local/multiplayer/cosmetics-test.json',JSON.stringify(evidence,null,2));
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
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true});
 const page=await boot('cosmetics');
 const counts=await page.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,k=h[6913232>>>2],sf=h[(k+92)>>>2],cfg=h[(h[(sf+4)>>>2]+16)>>>2],out={};for(const [name,offset]of [['characters',48],['hats',52],['emotes',32]]){const a=h[(cfg+offset)>>>2],n=h[(a+12)>>>2];let owned=0;for(let i=0;i<n;i++)owned+=!!t.get(19313)(h[(a+16+i*4)>>>2],0);out[name]={total:n,owned}}return out});console.log(JSON.stringify(counts));for(const v of Object.values(counts))assert.equal(v.owned,v.total);assert.equal(counts.characters.total,84);assert.equal(counts.hats.total,56);assert.equal(counts.emotes.total,8);
 await page.locator('#open-customize').click();await page.waitForTimeout(3000);await page.screenshot({path:'local/multiplayer/cosmetics-unlocked.png'});assert.deepEqual(evidence.errors,[]);evidence.passed=true;
}catch(e){console.error(e);process.exitCode=1}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save()}
