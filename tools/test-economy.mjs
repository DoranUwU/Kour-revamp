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
const save=()=>fs.writeFileSync('local/multiplayer/economy-test.json',JSON.stringify(evidence,null,2));
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
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const host=await boot('terrorist'),guest=await boot('counter-terrorist'),pages=[host,guest],room='ECON-'+Date.now().toString(36).toUpperCase();
 await enter(host,room,true);await enter(guest,room,false);
 for(const p of pages)await p.waitForFunction(()=>photonClient.inspect().players===2,null,{timeout:15000});
 await choose(host,'t');await choose(guest,'ct');
 await host.evaluate(()=>{const r=localKourStrikeRules,{module:m,fn,context,key,publish,u32}=r.native,c=context(),out=m.asm.malloc(4);try{m.HEAP32[out>>>2]=0;const value=fn('box')(u32(8037700),out),props=fn('clone')(u32(c.room+12),0);fn('put')(props,key('CurrentRound'),value,0);publish(c.room,props)}finally{m.asm.free(out)}});
 for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round===0,null,{timeout:10000});
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),800,0)});
 for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===1,null,{timeout:15000});
 let previous=await Promise.all(pages.map(wallet));for(const state of previous)assert.equal(state.cash,800,'Native first-round allowance');
 evidence.actions.push({label:'initial-wallets',states:previous});save();
 for(let index=0;index<6;index++){
  await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('setState')(c.manager,r.native.fn('name')(c.manager,0),2,0,0)});
  await Promise.all(pages.map(p=>p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000}))); 
  if(index===4){
   // Native CT death produces a terrorist win without a credited killer.
   await guest.evaluate(()=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],health=h[(shooter+108)>>>2];m.asm.__indirect_function_table.get(19128)(health,1000,0)});
  }else await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('endRound')(c.manager,r.native.fn('name')(c.manager,0),0)});
  const rewards=index===4?[3000,2000]:[index===5?2000:[2000,2500,3000,3000][index],3000];
  await Promise.all(pages.map((p,i)=>p.waitForFunction(({cash,reward,streak})=>{const m=originalModule,t=m.asm.__indirect_function_table,out=m.asm.malloc(20);try{t.get(20425)(out,0);const manager=localKourStrikeRules.native.context().manager;return t.get(15309)(out,0)===cash&&m.HEAP32[(manager+156)>>>2]===reward&&m.HEAP32[(manager+160)>>>2]===streak}finally{m.asm.free(out)}},{cash:Math.min(14000,previous[i].cash+rewards[i]),reward:rewards[i],streak:i===0?(index===4?0:index===5?1:Math.min(index+1,3)):(index===4?1:0)},{timeout:12000})));
  const states=await Promise.all(pages.map(wallet));
  for(let i=0;i<2;i++){assert.equal(states[i].reward,rewards[i]);assert.equal(states[i].cash,Math.min(14000,previous[i].cash+rewards[i]));}
  assert.equal(states[0].streak,index===4?0:index===5?1:Math.min(index+1,3));
  evidence.actions.push({label:'round-result-'+(index+1),rewards,states});save();console.log('round',index+1,JSON.stringify(states.map(s=>({cash:s.cash,reward:s.reward,streak:s.streak}))));
  if(index<5){for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===1,null,{timeout:20000});previous=await Promise.all(pages.map(wallet));for(let i=0;i<2;i++)assert.equal(previous[i].cash,states[i].cash,'Next buy phase preserves balance without extra income');}
 }
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure);for(const ctx of browser?.contexts()||[])for(const p of ctx.pages())try{evidence.actions.push({label:'failure-wallet',state:await wallet(p)})}catch{}}
finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,failure:evidence.failure}))}
