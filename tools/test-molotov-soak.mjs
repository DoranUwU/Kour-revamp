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
const save=()=>fs.writeFileSync('local/multiplayer/molotov-soak-test.json',JSON.stringify(evidence,null,2));
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
async function fixtureFire(page,owner){return page.evaluate(owner=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,k=h[6913232>>>2],sf=h[(k+92)>>>2],cfg=h[(h[(sf+4)>>>2]+16)>>>2],weapons=h[(cfg+56)>>>2],w=h[(weapons+16+33*4)>>>2],buf=m.asm.malloc(28);try{m.HEAPF32.set([29,5.95,-44,0,0,0,1],buf>>>2);const go=t.get(40774)(h[(w+264)>>>2],buf,buf+12,0);window.soakFire={go,handle:t.get(2105)(go,0)};const found=t.get(40621)(photonClient.native.string('MolotovZone'),0),hold=t.get(2105)(found,0);try{for(let i=0;i<h[(found+12)>>>2];i++)t.get(4956)(h[(found+16+i*4)>>>2],photonClient.native.string(String(owner)),0)}finally{m.HEAPU32[(buf+24)>>>2]=hold;t.get(2577)(buf+24,0)}}finally{m.asm.free(buf)}},owner)}
async function state(page){return page.evaluate(()=>{const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,k=h[6910700>>>2],sf=h[(k+92)>>>2],sh=h[sf>>>2],health=h[(sh+108)>>>2];return{hp:t.get(15309)(health+108,0),rules:molotovRules.inspect(),match:localKourStrikeRules.inspect(),gc:window.soakGC}})}
async function installStress(page){await page.evaluate(()=>{
 const t=originalModule.asm.__indirect_function_table,original=t.get(40607),enc=s=>[s.length,...Array.from(s,c=>c.charCodeAt(0))],section=(id,b)=>[id,b.length,...b];
 // A typed Wasm wrapper permits a JS hook at this exact native call boundary.
 const bytes=new Uint8Array([0,97,115,109,1,0,0,0,...section(1,[1,96,3,127,127,127,1,127]),...section(2,[1,...enc('env'),...enc('hook'),0,0]),...section(3,[1,0]),...section(7,[1,...enc('call'),0,1]),...section(10,[1,10,0,32,0,32,1,32,2,16,0,11])]);
 window.soakGC={runs:0,collections:0};
 const hook=(...args)=>{if(window.soakGcArmed){window.soakGcArmed=false;const before=t.get(9196)(0,0);t.get(77197)(1,0);window.soakGC.runs++;window.soakGC.collections+=t.get(9196)(0,0)-before}if(window.soakFaultArmed){window.soakFaultArmed=false;throw Error('Injected transient expired fire reference')}return original(...args)};
 const wrapper=new WebAssembly.Instance(new WebAssembly.Module(bytes),{env:{hook}}).exports.call;t.set(40607,wrapper);window.restoreSoakStress=()=>t.set(40607,original);
})}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,args:['--disable-background-timer-throttling','--disable-renderer-backgrounding','--disable-backgrounding-occluded-windows']});
 const room='SOAK-'+Date.now().toString(36).toUpperCase(),pages=[];
 for(let i=0;i<4;i++){const p=await boot(['thrower','teammate','enemy-one','enemy-two'][i]);await enter(p,room,i===0);pages.push(p)}
 for(let i=0;i<4;i++)await choose(pages[i],i<2?'t':'ct');
 const host=pages[0];for(const p of pages)await p.waitForFunction(()=>photonClient.inspect().players===4,null,{timeout:15000});
 await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('startRound')(c.manager,r.native.fn('name')(c.manager,0),800,0)});
 for(const p of pages){await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===1,null,{timeout:20000});await installStress(p)}
 for(let round=1;round<=6;round++){
  const actual=(await state(host)).match.round;
  for(let i=0;i<4;i++)await teleport(pages[i],[25.5+i*2.2,6.6,-44]);
  await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('setState')(c.manager,r.native.fn('name')(c.manager,0),2,0,0)});
  for(const p of pages)await p.waitForFunction(()=>localKourStrikeRules.inspect()?.phase===2,null,{timeout:10000});
  const before=await Promise.all(pages.map(state));
  for(const p of pages)await p.evaluate(inject=>{window.soakGcArmed=true;window.soakFaultArmed=inject},round===3);
  await Promise.all(pages.map(p=>fixtureFire(p,1)));
  await Promise.all([0,2,3].map(i=>pages[i].waitForFunction(burns=>molotovRules.inspect().burns>burns,before[i].rules.burns,{timeout:12000})));
  const after=await Promise.all(pages.map(state));
  for(const i of [0,2,3]){assert.ok(after[i].hp<before[i].hp,'Self and enemies take damage in every round');assert.equal(after[i].rules.transientRoots,0);assert.equal(after[i].rules.faulted,false);assert.ok(after[i].gc.runs>=round,'Native GC runs during each eligible scan');}
  assert.equal(after[1].hp,100,'Teammate stays immune across respawns');
  if(round===3)for(const i of [0,2,3])assert.ok(after[i].rules.errors>=1,'Injected error is recorded and recovered without reload');
  evidence.actions.push({round,actual,before,after});save();console.log(JSON.stringify({round,actual,hp:after.map(s=>s.hp),gc:after.map(s=>s.gc),errors:after.map(s=>s.rules.errors)}));
  await Promise.all(pages.map(p=>p.evaluate(()=>{const m=originalModule,t=m.asm.__indirect_function_table,f=window.soakFire;if(f){const out=m.asm.malloc(4);try{t.get(3089)(f.go,0);m.HEAPU32[out>>>2]=f.handle;t.get(2577)(out,0);window.soakFire=null}finally{m.asm.free(out)}}})));
  if(round<6){await host.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('endRound')(c.manager,r.native.fn('name')(c.manager,0),0)});for(const p of pages)await p.waitForFunction(previous=>{const s=localKourStrikeRules.inspect();return s?.phase===1&&s.round>previous},actual,{timeout:25000})}
 }
 await Promise.all(pages.map(p=>p.evaluate(()=>{window.restoreSoakStress();molotovRules.dispose();if(molotovRules.inspect().transientRoots!==0)throw Error('Leaked temporary fire roots')})));
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;console.log('Four clients and six rounds passed: native GC requests, error recovery, self/enemy damage, teammate immunity and released temporary roots.');
}catch(e){evidence.failure=e.stack||e.message;process.exitCode=1;console.error(evidence.failure)}finally{await browser?.close();fs.closeSync(lock);fs.unlinkSync(lockPath);save()}
