import fs from 'node:fs';
import assert from 'node:assert/strict';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const sparse=process.argv.includes('--sparse-scores'),prefix=process.argv.includes('--debug-swap')?'camera-halftime-debug':'camera-halftime',originalTScore=sparse?0:7;
const origin='http://127.0.0.1:8088',evidence={actions:[],errors:[],external:[],console:[],cleanup:'pending'};
const save=()=>fs.writeFileSync(`analysis/runtime/${prefix}-browser.json`,JSON.stringify(evidence,null,2));
let browser;
async function snapshot(page,label){
 const state=await page.evaluate(()=>{
  const rules=window.localKourStrikeRules,m=originalModule,h=m.HEAPU32,s=rules.inspect(),c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],array=h[(sf+8)>>>2];
  const inventory=array?Array.from(m.HEAP32.subarray((array+16)>>>2,((array+16)>>>2)+h[(array+12)>>>2])):[];
  let position=null;if(shooter){const out=m.asm.malloc(16);try{const transform=m.asm.__indirect_function_table.get(2964)(shooter,0);m.asm.__indirect_function_table.get(2965)(out,transform,0);position=Array.from(m.HEAPF32.subarray(out>>>2,(out>>>2)+3))}finally{m.asm.free(out)}}
  const ctx=rules.native.context(),canvas=h[(ctx.manager+76)>>>2],image=h[(canvas+28)>>>2],sprite=m.asm.__indirect_function_table.get(57882)(image,0),expected=h[(canvas+(s.teamCode===1?16:20))>>>2];
  return{...s,inventory,position,buyTeamIconMatches:sprite===expected,storedScores:{t:!!rules.native.property(ctx.props,'T1S').box,ct:!!rules.native.property(ctx.props,'T2S').box}};
 });
 const path=`analysis/runtime/${prefix}-${label}.png`;await page.screenshot({path});evidence.actions.push({label,state,screenshot:path});save();console.log(JSON.stringify({label,state}));return state;
}
async function seedScores(page,entries){await page.evaluate(entries=>{const r=localKourStrikeRules,{module:m,fn,context,key,publish,u32}=r.native,c=context(),p=fn('clone')(c.props,0),out=m.asm.malloc(4);try{for(const [k,v]of entries){m.HEAP32[out>>>2]=v;fn('put')(p,key(k),fn('box')(u32(8037700),out),0)}publish(c.room,p)}finally{m.asm.free(out)}},entries)}
async function setRound(page,round){await page.evaluate(()=>document.exitPointerLock?.());await page.waitForTimeout(150);await page.locator('#round-debug input').fill(String(round));await page.locator('[data-set-round]').click();await page.waitForFunction(n=>window.localKourStrikeRules.inspect()?.round===n,round,{timeout:5000});await page.waitForTimeout(350)}
async function boot(side){
 const context=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'});
 await context.route('**/*',r=>new URL(r.request().url()).origin===origin?r.continue():(evidence.external.push(r.request().url()),r.abort()));
 const page=await context.newPage();page.setDefaultTimeout(10000);
 page.on('pageerror',e=>evidence.errors.push(e.stack||e.message));page.on('console',m=>{if(evidence.console.length<3000)evidence.console.push(m.text())});
 await page.goto(origin);await page.locator('#start').click();await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',null,{timeout:45000});
 await page.waitForTimeout(1500); // Let the original lobby/disconnection callbacks settle.
 await page.locator('#start-match').click();
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,c=h[6911608>>>2];if(!c||c>m.HEAPU8.length)return false;const sf=h[(c+92)>>>2],panel=h[sf>>>2];return panel&&panel<m.HEAPU8.length&&m.asm.__indirect_function_table.get(11431)(panel,0)===1},null,{timeout:30000});
 await page.waitForTimeout(500);await page.mouse.click(side==='t'?350:930,300);await page.waitForTimeout(800);await page.locator('#round-debug summary').click();
 await page.waitForFunction(code=>window.localKourStrikeRules.inspect()?.teamCode===code,side==='t'?2:1,{timeout:5000});
 await page.waitForFunction(()=>!document.querySelector('[data-set-round]').disabled);return{page,context};
}
async function camera(page){return page.evaluate(()=>{
 const m=originalModule,h=m.HEAPU32,t=m.asm.__indirect_function_table,c=h[6910700>>>2],sf=h[(c+92)>>>2],shooter=h[sf>>>2],controller=h[(shooter+116)>>>2],input=h[(shooter+200)>>>2],cam=h[(shooter+184)>>>2],out=m.asm.malloc(16);
 const vector=p=>Array.from(m.HEAPF32.subarray(p>>>2,(p>>>2)+3));
 try{const transform=t.get(2964)(shooter,0);t.get(41055)(out,transform,0);const root=vector(out);t.get(41055)(out,t.get(2964)(cam,0),0);const view=vector(out);
 const keys=[h[7024776>>>2],h[7024780>>>2]];
 return{shooter,controller,input,cam,time:performance.now(),round:localKourStrikeRules.inspect().round,root,view,inputRot:vector(controller+204),look:Array.from(m.HEAPF32.subarray((input+44)>>>2,(input+52)>>>2)),raw:keys.map(k=>k>1024&&k<m.HEAPU8.length?t.get(44812)(k,0):null),paused:!!m.HEAPU8[input+80],bypass:!!m.HEAPU8[controller+284],pointerLock:document.pointerLockElement?.id||null,focus:document.hasFocus(),active:document.activeElement?.id};
 }finally{m.asm.free(out)}
})}
async function samples(page,label){const values=[];for(let i=0;i<9;i++){values.push(await camera(page));await page.waitForTimeout(150)}evidence.actions.push({label,values});save();console.log(JSON.stringify({label,values}));return values}
async function closeBuy(page){await page.mouse.click(1060,418);await page.waitForTimeout(750);await page.mouse.click(640,270);await page.waitForTimeout(500)}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const {page}=await boot('t');await setRound(page,12);await closeBuy(page);
 await samples(page,'before-swap-idle');await page.mouse.move(720,290,{steps:5});await page.waitForTimeout(500);await samples(page,'before-swap-after-mouse');
 if(process.argv.includes('--debug-swap'))await setRound(page,13);else{
 await page.waitForFunction(()=>localKourStrikeRules.inspect().phase===2,null,{timeout:15000});
 await page.evaluate(()=>{const r=localKourStrikeRules,c=r.native.context();r.native.fn('endRound')(c.manager,r.native.fn('name')(c.manager,0),0)});}
 await page.waitForFunction(()=>localKourStrikeRules.inspect().round===13,null,{timeout:25000});await page.waitForTimeout(1000);
 await samples(page,'after-swap-menu');await closeBuy(page);const idle=await samples(page,'after-swap-idle');assert.ok(Math.max(...idle.map(v=>v.root[1]))-Math.min(...idle.map(v=>v.root[1]))<0.1,'Idle camera must not spin');const before=evidence.actions.find(a=>a.label==='before-swap-idle').values[0];assert.notEqual(idle[0].shooter,before.shooter,'Halftime must replace player');assert.notEqual(idle[0].cam,before.cam,'Halftime must replace camera');
 await page.mouse.move(800,320,{steps:5});await page.waitForTimeout(500);const moved=await samples(page,'after-swap-after-mouse');assert.ok(Math.abs(moved[0].root[1]-idle[0].root[1])>1,'Mouse must turn camera');
 await page.waitForFunction(()=>localKourStrikeRules.inspect().phase===2,null,{timeout:15000});const standing=await snapshot(page,'before-movement');await page.keyboard.down('w');await page.waitForTimeout(700);await page.keyboard.up('w');const walking=await snapshot(page,'camera-after-movement');assert.ok(Math.hypot(...walking.position.map((v,i)=>v-standing.position[i]))>0.2,'Player must move after swap');
 assert.deepEqual(evidence.errors,[]);evidence.passed=true;
}catch(error){evidence.failure=error.stack||error.message;console.log(evidence.failure);process.exitCode=1}
finally{await browser?.close();evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,cleanup:evidence.cleanup}))}
