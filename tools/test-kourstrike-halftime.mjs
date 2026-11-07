import fs from 'node:fs';
import assert from 'node:assert/strict';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const sparse=process.argv.includes('--sparse-scores'),prefix=sparse?'halftime-sparse':'halftime',originalTScore=sparse?0:7;
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
async function setRound(page,round){await page.locator('#round-debug input').fill(String(round));await page.locator('[data-set-round]').click();await page.waitForFunction(n=>window.localKourStrikeRules.inspect()?.round===n,round,{timeout:5000});await page.waitForTimeout(350)}
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
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const first=await boot('t'),page=first.page;
 await setRound(page,12);let s=await snapshot(page,'t-round12');assert.equal(s.team,'t');assert.equal(s.swaps,0);assert.ok(s.inventory.includes(31));assert.ok(s.position[2]<0);
 await seedScores(page,sparse?[['T2S',4]]:[['T1S',7],['T2S',4]]);
 if(sparse){s=await snapshot(page,'missing-t-before-boundary');assert.equal(s.storedScores.t,false);assert.equal(s.storedScores.ct,true)}
 await page.waitForFunction(()=>localKourStrikeRules.inspect().phase===2,null,{timeout:15000});await page.locator('[data-end-round]').click();
 await page.waitForFunction(()=>localKourStrikeRules.inspect().round===13,null,{timeout:25000});
 await page.waitForTimeout(650); // Native TeleportTo applies on the next player update.
 s=await snapshot(page,'t-to-ct-round13');assert.equal(s.team,'ct');assert.equal(s.swaps,1);assert.equal(s.tScore,5);assert.equal(s.ctScore,originalTScore);assert.ok(!s.inventory.includes(31));assert.ok(s.position[2]>50);assert.equal(s.buyTeamIconMatches,true);
 await setRound(page,13);s=await snapshot(page,'repeat-round13');assert.equal(s.team,'ct');assert.equal(s.swaps,1);assert.equal(s.ctScore,originalTScore);
 await setRound(page,14);s=await snapshot(page,'round14');assert.equal(s.team,'ct');assert.equal(s.swaps,1);
 await setRound(page,12);s=await snapshot(page,'rewind-round12');assert.equal(s.team,'t');assert.equal(s.swaps,2);assert.equal(s.tScore,originalTScore);
 await setRound(page,13);s=await snapshot(page,'forward-round13');assert.equal(s.team,'ct');assert.equal(s.swaps,3);assert.equal(s.ctScore,originalTScore);
 await first.context.close();
 const second=await boot('ct');await snapshot(second.page,'ct-selected');if(sparse){await setRound(second.page,12);await seedScores(second.page,[['T1S',3]]);const before=await snapshot(second.page,'missing-ct-before-jump');assert.equal(before.storedScores.ct,false);assert.equal(before.storedScores.t,true)}await setRound(second.page,13);s=await snapshot(second.page,'ct-to-t-round13');assert.equal(s.team,'t');assert.equal(s.swaps,1);assert.ok(s.inventory.includes(31));assert.ok(s.bombHolder>0);assert.ok(s.position[2]<0);assert.equal(s.buyTeamIconMatches,true);
 if(sparse){assert.equal(s.tScore,0);assert.equal(s.ctScore,3);assert.deepEqual(s.storedScores,{t:true,ct:true})}
 await setRound(second.page,15);s=await snapshot(second.page,'round15-c4');assert.equal(s.team,'t');assert.equal(s.swaps,1);assert.ok(s.inventory.includes(31));assert.ok(s.bombHolder>0);
 if(sparse){await second.context.close();const third=await boot('ct');const before=await snapshot(third.page,'both-missing-before-jump');assert.deepEqual(before.storedScores,{t:false,ct:false});await setRound(third.page,13);s=await snapshot(third.page,'both-zero-round13');assert.equal(s.team,'t');assert.equal(s.tScore,0);assert.equal(s.ctScore,0);assert.deepEqual(s.storedScores,{t:true,ct:true});await setRound(third.page,13);s=await snapshot(third.page,'both-zero-repeat');assert.equal(s.swaps,1)}
 assert.deepEqual(evidence.errors,[]);assert.deepEqual(evidence.external,[]);evidence.passed=true;
}catch(error){evidence.failure=error.stack||error.message;console.log(evidence.failure);process.exitCode=1}
finally{await browser?.close();evidence.cleanup='closed-owned-browser';save();console.log(JSON.stringify({passed:evidence.passed,errors:evidence.errors,external:evidence.external,cleanup:evidence.cleanup}))}
