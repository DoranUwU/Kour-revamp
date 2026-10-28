import fs from 'node:fs';
import readline from 'node:readline';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const origin='http://127.0.0.1:8087',output='analysis/runtime/weapon-ct-browser.json';
const evidence={provider:'ordinary-playwright',actions:[],errors:[],external:[],requests:[],responses:[],console:[],cleanup:'pending',started:new Date().toISOString()};
let browser,timer,page;
const save=()=>fs.writeFileSync(output,JSON.stringify(evidence,null,2));
async function close(){clearTimeout(timer);try{await browser?.close();evidence.cleanup='closed-owned-browser'}catch(e){evidence.cleanup=e.message}evidence.finished=new Date().toISOString();save()}
async function shot(name){const file=`analysis/runtime/weapon-ct-${name}.png`;await page.screenshot({path:file,timeout:5000});evidence.actions.push({screenshot:file});save();return file}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const context=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'});
 await context.route('**/*',route=>{if(new URL(route.request().url()).origin!==origin){evidence.external.push(route.request().url());return route.abort('blockedbyclient')}return route.continue()});
 page=await context.newPage();page.setDefaultTimeout(10000);
 page.on('pageerror',e=>evidence.errors.push({message:e.message,stack:e.stack}));
 page.on('console',m=>{if(evidence.console.length<3000)evidence.console.push(m.text())});
 page.on('request',r=>evidence.requests.push(r.url()));page.on('response',r=>evidence.responses.push({url:r.url(),status:r.status()}));
 await page.goto(origin);await page.locator('#start').click();await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',{},{timeout:45000});await page.waitForTimeout(1500);
 await page.locator('#start-match').click();evidence.actions.push({click:'Start KourStrike offline'});
 // TypeUsage slot is derived from TeamSelectPanel metadata.byval_type_index21725.
 // The parent-verified Behaviour getter is called only for validated pointers.
 await page.waitForFunction(()=>{const m=originalModule,h=m.HEAPU32,n=m.HEAPU8.byteLength,valid=p=>p>1024&&p%4===0&&p+128<n;const c=h[6911608>>>2];if(!valid(c))return false;const s=h[(c+92)>>>2];if(!valid(s))return false;const panel=h[s>>>2];return valid(panel)&&m.asm.__indirect_function_table.get(11431)(panel,0)===1},{},{timeout:30000,polling:100});
 await shot('team-selector');await page.mouse.click(930,300);evidence.actions.push({native_click:'Counter-Terrorists team card',x:930,y:300});await page.waitForTimeout(1500);await shot('ct-chosen');
 console.log(JSON.stringify({stage:'CT chosen; waiting native warmup',requests:evidence.requests.filter(x=>/StreamingAssets/.test(x))}));
 for(let i=0;i<5;i++){await page.waitForTimeout(25000);console.log(JSON.stringify({stage:'native warmup',elapsed:(i+1)*25}));save()}
 await shot('spawn');console.log(JSON.stringify({ready:true,meshResponses:evidence.responses.filter(x=>/StreamingAssets/.test(x.url)),errors:evidence.errors}));save();
 timer=setTimeout(()=>close().then(()=>process.exit(0)),180000);
 for await(const line of readline.createInterface({input:process.stdin})){try{const c=JSON.parse(line);clearTimeout(timer);timer=setTimeout(()=>close().then(()=>process.exit(0)),180000);if(c.close){await close();break}if(c.click){await page.mouse.click(...c.click);evidence.actions.push({click:c.click})}if(c.key){await page.keyboard.press(c.key,{delay:c.duration||0});evidence.actions.push({key:c.key,duration:c.duration||0})}if(c.hide){await page.evaluate(()=>{const f=originalModule.asm.__indirect_function_table.get(20593);if(f.name!=='74636')throw Error('Unexpected original settings function');f(0,0,0)});evidence.actions.push({native_renderWeapon:false})}if(c.show){await page.locator('#show-weapon').click();evidence.actions.push({click:'Show gun'})}if(c.viewport){await page.setViewportSize(c.viewport);evidence.actions.push({viewport:c.viewport})}if(c.wait)await page.waitForTimeout(Math.min(c.wait,15000));const screenshot=c.shot?await shot(c.shot):null;save();console.log(JSON.stringify({done:true,screenshot,errors:evidence.errors,meshResponses:evidence.responses.filter(x=>/StreamingAssets/.test(x.url))}))}catch(error){evidence.operation_error=error.message;save();console.log(JSON.stringify({error:error.message}))}}
 await close();
}catch(error){evidence.error={message:error.message,stack:error.stack};save();console.log(JSON.stringify(evidence.error));await close();process.exitCode=1}
