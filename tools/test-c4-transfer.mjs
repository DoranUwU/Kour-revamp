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
const save=()=>fs.writeFileSync('local/multiplayer/c4-transfer-test.json',JSON.stringify(evidence,null,2));
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
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c)return false;const sf=h[(c+92)>>>2];const panel=h[sf>>>2],state=localKourStrikeRules.inspect();return !!panel&&!!state&&(m.asm.__indirect_function_table.get(11431)(panel,0)===1||state.teamCode===1||state.teamCode===2)},null,{timeout:30000});
 await page.waitForTimeout(650);await page.evaluate(side=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(21203)(h[sf>>>2],photonClient.native.string(side),0)},side);
 const current=await page.evaluate(()=>localKourStrikeRules.inspect());if(current.teamCode!==(side==='t'?2:1))await page.evaluate(code=>{const r=localKourStrikeRules,c=r.native.context();if(c.code)r.native.fn('switchTeam')(c.local,code,0);else{const join=r.native.module.asm.__indirect_function_table.get(28160);if(join.name!=='74106')throw Error('Unknown native team fixture API');join(c.local,code,0)}},side==='t'?2:1);
 await page.waitForFunction(code=>localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:10000});
}
async function gun(page){return page.evaluate(()=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],array=h[(sf+8)>>>2],view=m.asm.__indirect_function_table.get(27903)(shooter,0);return{actor:m.asm.__indirect_function_table.get(27871)(view,0),shooter,slot:m.HEAP32[(sf+12)>>>2],weapon:h[(shooter+224)>>>2],inventory:Array.from(m.HEAP32.subarray((array+16)>>>2,((array+16)>>>2)+h[(array+12)>>>2])),match:localKourStrikeRules.inspect()}})}
async function enter(page,room,create){await page.evaluate(async({room,create})=>{restoreWeaponVisibility();await photonClient[create?'create':'join']({appId:document.querySelector('#photon-app-id').value,nickname:create?'Host':'Friend',region:document.querySelector('#photon-region').value,room})},{room,create})}
try{
 browser=await chromium.launch({executablePath:process.env.BROWSER_PATH||'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const room='C4-'+Date.now().toString(36).toUpperCase(),host=await boot('host');await enter(host,room,true);
 const teammate=await boot('teammate');await enter(teammate,room,false);
 const enemy=await boot('enemy');await enter(enemy,room,false);
 await choose(host,'t');await choose(enemy,'ct');await choose(teammate,'t');
 const pages=[host,teammate,enemy];for(const p of pages)await p.waitForFunction(()=>photonClient.inspect().players===3,null,{timeout:15000});
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),0,0)});
 for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.round>=1&&localKourStrikeRules.inspect()?.phase>=1,null,{timeout:20000});
 const info=[await gun(host),await gun(teammate)],holder=info[0].match.bombHolder,holderPage=info[0].actor===holder?host:teammate,receiver=holderPage===host?teammate:host;
 const selectedSlot=process.argv.includes('--rifle')?0:1;
 await receiver.evaluate(slot=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],t=m.asm.__indirect_function_table;if(slot===0){t.get(20677)(h[sf>>>2],0,0,-1,0);t.get(20724)(h[sf>>>2],0,1,0)}else t.get(20724)(h[sf>>>2],1,1,0)},selectedSlot);await receiver.waitForTimeout(650);
 for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:20000});
 const before=await gun(receiver);evidence.actions.push({label:'recipient-loadout',state:before});save();assert.equal(before.slot,selectedSlot);assert.notEqual(before.inventory[2],31);
 evidence.actions.push({label:'before-holder-death',holder,receiver:before});save();
 // Native lethal damage on the holder exercises death, server C4 selection and
 // the receiving client's real SetBomb callback; no inventory writes are used.
 await holderPage.evaluate(()=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],health=h[(shooter+108)>>>2];m.asm.__indirect_function_table.get(19128)(health,1000,0)});
 await receiver.waitForFunction(actor=>localKourStrikeRules.inspect()?.bombHolder===actor,before.actor,{timeout:12000});
 await receiver.waitForTimeout(1000);const after=await gun(receiver);
 evidence.actions.push({label:'after-holder-death',receiver:after});save();console.log(JSON.stringify({before,after}));
 assert.equal(after.inventory[2],31,'C4 must transfer into the living teammate inventory');
 if(process.argv.includes('--expect-auto-equip'))assert.equal(after.slot,2,'Original bug must reproduce');else{assert.equal(after.slot,before.slot,'C4 transfer must preserve selected weapon');assert.equal(after.weapon,before.weapon,'C4 transfer must preserve the equipped weapon instance')}
 // Receiving player must still be able to select C4 deliberately.
 await receiver.evaluate(()=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2];m.asm.__indirect_function_table.get(20724)(h[sf>>>2],2,1,0)});await receiver.waitForTimeout(400);assert.equal((await gun(receiver)).slot,2);
 for(const [give,plant,expectedSlot]of [[0,0,1],[1,0,2],[0,1,2]]){
  await receiver.evaluate(({give,plant})=>{const m=originalModule,h=m.HEAPU32,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],t=m.asm.__indirect_function_table;t.get(20724)(shooter,1,1,0);t.get(20676)(shooter,give,plant,0)},{give,plant});
  await receiver.waitForTimeout(250);const state=await gun(receiver);assert.equal(state.slot,expectedSlot,'Existing grant/clear/planting cleanup equip behavior must remain');evidence.actions.push({label:'native-flags-'+give+plant,state});save();
 }

 assert.deepEqual(evidence.errors,[]);evidence.passed=true;
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure);for(const ctx of browser?.contexts()||[])for(const p of ctx.pages())try{evidence.actions.push({label:'failure-state',state:await p.evaluate(()=>({match:localKourStrikeRules.inspect(),photon:photonClient.inspect()}))})}catch{}}
finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,failure:evidence.failure}))}
