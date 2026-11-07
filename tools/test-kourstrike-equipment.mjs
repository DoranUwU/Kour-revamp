import fs from 'node:fs';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const origin='http://127.0.0.1:8088',output='analysis/runtime/equipment-colors-browser.json';
const evidence={provider:'ordinary-playwright',started:new Date().toISOString(),actions:[],requests:[],responses:[],errors:[],external:[],console:[],cleanup:'pending'};
let browser,page;
const save=()=>fs.writeFileSync(output,JSON.stringify(evidence,null,2));
async function shot(name){const path=`analysis/runtime/equipment-colors-${name}.png`;await page.screenshot({path,timeout:5000});evidence.actions.push({screenshot:path});save()}
// Read metadata-verified native state only. This does not change money/items.
function readBuyState(){
 const m=originalModule,h=m.HEAPU32,n=m.HEAPU8.byteLength,t=m.asm.__indirect_function_table;
 const valid=p=>p>=1024&&p%4===0&&p+128<n;
 const c=h[6910428>>>2];if(!valid(c))throw Error('SearchAndDestroy class not initialized');
 const sf=h[(c+92)>>>2];if(!valid(sf))throw Error('Invalid static field pointer');
 const manager=h[(sf+20)>>>2];if(!valid(manager))throw Error('Invalid manager');
 const canvas=h[(manager+76)>>>2];if(!valid(canvas))throw Error('Invalid buy canvas');
 const nameGetter=t.get(3300);if(nameGetter.name!=='84181')throw Error('Unexpected Object.name getter');
 function str(p){if(!valid(p))return null;const len=h[(p+8)>>>2];if(len>256||p+12+len*2>n)return null;return String.fromCharCode(...m.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+len))}
 const items=[];
 for(const [category,field,slot]of [['rifle',56,0],['pistol',60,1],['smg',68,0],['grenade',72,3]]){const array=h[(canvas+field)>>>2];if(!valid(array))continue;const len=h[(array+12)>>>2];if(len>32)throw Error('Invalid buy array');for(let i=0;i<len;i++){const item=h[(array+16+i*4)>>>2];if(!valid(item))continue;const weapon=h[(item+12)>>>2];if(!valid(weapon))continue;items.push({category,slot,item,weapon,price:m.HEAP32[(item+8)>>>2],name:str(nameGetter(weapon,0))})}}
 return{c,sf,manager,canvas,phase:m.HEAP32[(manager+100)>>>2],cashCandidate:m.HEAP32[sf>>>2]^m.HEAP32[(sf+4)>>>2],cashInited:m.HEAPU8[sf+8],cashFake:m.HEAP32[(sf+12)>>>2],items};
}
function readLiveMaterials(){
 const m=originalModule,h=m.HEAPU32,n=m.HEAPU8.byteLength,t=m.asm.__indirect_function_table,valid=p=>p>=1024&&p%4===0&&p+128<n;
 const getName=t.get(3300),name=p=>{if(!valid(p))return null;const s=getName(p,0);if(!valid(s))return null;const len=m.HEAPU32[(s+8)>>>2];return len<256?String.fromCharCode(...m.HEAPU16.subarray((s+12)>>>1,((s+12)>>>1)+len)):null};
 const c=h[6908040>>>2];if(!valid(c))return{error:'NetworkManager class unavailable'};const sf=h[(c+92)>>>2];if(!valid(sf))return{error:'Network statics unavailable'};const network=h[(sf+56)>>>2];if(!valid(network))return{error:'Network instance unavailable'};
 const scratch=m.asm.malloc(16);if(!scratch)throw Error('Cannot allocate material read scratch');
 try{const health=t.get(19878)(network,scratch,0);if(!valid(health))return{network,error:'No local player health'};const shooter=m.HEAPU32[(health+20)>>>2],weapon=m.HEAPU32[(shooter+224)>>>2];if(!valid(shooter)||!valid(weapon))return{health,shooter,weapon,error:'No current local weapon'};const array=t.get(21439)(weapon,0),renderers=[];if(valid(array)){const len=m.HEAPU32[(array+12)>>>2];if(len>64)throw Error('Invalid renderer array');for(let i=0;i<len;i++){const renderer=m.HEAPU32[(array+16+i*4)>>>2];if(!valid(renderer))continue;const ma=t.get(39100)(renderer,0),materials=[];if(valid(ma)){const count=m.HEAPU32[(ma+12)>>>2];if(count>32)throw Error('Invalid material array');for(let j=0;j<count;j++){const material=m.HEAPU32[(ma+16+j*4)>>>2];if(!valid(material))continue;t.get(39161)(scratch,material,0);const color=Array.from(m.HEAPF32.subarray(scratch>>>2,(scratch>>>2)+4)),shader=t.get(5685)(material,0);materials.push({material,name:name(material),shader:name(shader),color})}}renderers.push({renderer,name:name(renderer),materials})}}return{health,shooter,weapon,weaponName:name(weapon),renderers}}finally{m.asm.free(scratch)}
}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const context=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'});
 await context.route('**/*',route=>{if(new URL(route.request().url()).origin!==origin){evidence.external.push(route.request().url());return route.abort('blockedbyclient')}return route.continue()});
 page=await context.newPage();page.setDefaultTimeout(10000);
 page.on('console',msg=>{if(evidence.console.length<3000)evidence.console.push(msg.text())});page.on('pageerror',e=>evidence.errors.push({message:e.message,stack:e.stack}));
 page.on('request',r=>evidence.requests.push(r.url()));page.on('response',r=>evidence.responses.push({url:r.url(),status:r.status()}));
 await page.goto(origin);await page.locator('#start').click();await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',{},{timeout:45000});await page.waitForTimeout(1500);
 await page.locator('#start-match').click();
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,n=m.HEAPU8.byteLength,valid=p=>p>1024&&p%4===0&&p+128<n;const c=h[6911608>>>2];if(!valid(c))return false;const s=h[(c+92)>>>2];if(!valid(s))return false;const panel=h[s>>>2];return valid(panel)&&m.asm.__indirect_function_table.get(11431)(panel,0)===1},{},{timeout:30000,polling:100});
 await page.mouse.click(350,300);evidence.actions.push({native_click:'T card',x:350,y:300});await page.waitForTimeout(1500);await shot('t-chosen');
 console.log(JSON.stringify({stage:'T chosen; waiting original warmup'}));
 if(process.argv.includes('--fast-native-test')){const state=await page.evaluate(readBuyState);const advance=await page.evaluate(({manager})=>{const m=originalModule,t=m.asm.__indirect_function_table,phase=m.HEAP32[(manager+100)>>>2];if(phase!==0)return{advanced:false,phase};const f=t.get(20444);if(f.name!=='74516'||f.length!==4)throw Error('Unexpected original StartRound contract');const reason=t.get(3300)(manager,0);f(manager,reason,0,0);return{advanced:true,phaseBefore:phase,method:'original SearchAndDestroyManager.StartRound',testOnly:true}},state);evidence.actions.push({controlled_native_phase_advance:advance});await page.waitForTimeout(1800)}else for(let i=0;i<5;i++){await page.waitForTimeout(25000);console.log(JSON.stringify({stage:'native warmup',elapsed:(i+1)*25}));save()}
 const initial=await page.evaluate(readBuyState);evidence.initial=initial;await shot('spawn');
 const player=await page.evaluate(readLiveMaterials);
 const bombEquip=await page.evaluate(({shooter,canvas,manager})=>{const m=originalModule,t=m.asm.__indirect_function_table,f=t.get(20724);if(f.name!=='74291'||f.length!==4)throw Error('Unexpected SetWeapon contract');t.get(18165)(canvas,0);f(shooter,2,1,0);return{slot:2,bombHolder:m.HEAP32[(manager+104)>>>2]}},{shooter:player.shooter,canvas:initial.canvas,manager:initial.manager});
 await page.waitForTimeout(2500);const bomb=await page.evaluate(readLiveMaterials);evidence.actions.push({native_equip:'C4',result:bombEquip,liveMaterials:bomb});await shot('c4');if(!bomb.weaponName?.startsWith('Bomb'))throw Error('Original T round did not equip C4: '+bomb.weaponName);
 for(const desired of ['Revolver','Smoke','Molotov','Grenade','Flashbang']){
  const before=await page.evaluate(readBuyState),item=before.items.find(x=>{const name=x.name?.replace(/\(Clone\)$/,'').trim().toLowerCase();return name===desired.toLowerCase()});
  if(!item)throw Error('No original buy-menu item '+desired+'; items='+before.items.map(x=>x.name).join(','));
  if(before.cashCandidate<item.price)throw Error('Insufficient original balance for '+desired);
  const result=await page.evaluate(({canvas,item})=>{const m=originalModule,t=m.asm.__indirect_function_table,buy=t.get(18164),close=t.get(18165);if(buy.name!=='74677'||buy.length!==4||close.name!=='74678'||close.length!==2)throw Error('Original buy method contract mismatch');const h=m.HEAPU32;if(h[(item.item+12)>>>2]!==item.weapon||m.HEAP32[(item.item+8)>>>2]!==item.price)throw Error('Original item changed');buy(canvas,item.slot,item.item,0);close(canvas,0);return{handler:buy.name,closedMenu:true}}, {canvas:before.canvas,item});
  await page.waitForTimeout(2500);const after=await page.evaluate(readBuyState);let materials;try{materials=await page.evaluate(readLiveMaterials)}catch(error){materials={error:error.message}}evidence.actions.push({native_purchase:desired,item,beforeCash:before.cashCandidate,afterCash:after.cashCandidate,expectedCash:before.cashCandidate-item.price,phase:after.phase,result,liveMaterials:materials});await shot(desired.toLowerCase());if(!materials.weaponName?.toLowerCase().startsWith(desired.toLowerCase()))throw Error('Wrong equipped weapon: '+materials.weaponName);if(after.cashCandidate!==before.cashCandidate-item.price)throw Error('Purchase debit mismatch');
  console.log(JSON.stringify({stage:'native purchase captured',weapon:desired,before:before.cashCandidate,after:after.cashCandidate,price:item.price}));
 }
 await page.locator('#check-response').click();evidence.actions.push({hostResponse:true});await shot('final');
}catch(error){evidence.error={message:error.message,stack:error.stack};console.log(JSON.stringify(evidence.error));process.exitCode=1}
finally{if(browser){try{await browser.close();evidence.cleanup='closed-owned-browser'}catch(e){evidence.cleanup=e.message}}evidence.finished=new Date().toISOString();save();console.log(JSON.stringify({finished:true,cleanup:evidence.cleanup,errors:evidence.errors,external:evidence.external,assetResponses:evidence.responses.filter(r=>/StreamingAssets|\.png/.test(r.url)),purchases:evidence.actions.filter(x=>x.native_purchase)},null,2))}
