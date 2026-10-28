import fs from 'node:fs';
import readline from 'node:readline';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const origin='http://127.0.0.1:8086';
const evidence={actions:[],errors:[],external:[],console:[],cleanup:'pending'};
const output=`analysis/runtime/weapon-visibility-browser${process.argv.includes('--auto')?'-auto':''}.json`;
const save=()=>fs.writeFileSync(output,JSON.stringify(evidence,null,2));
let browser,timer;
async function close(){clearTimeout(timer);await browser?.close();evidence.cleanup='closed-owned-browser';save()}
async function shot(page,name){const path=`analysis/runtime/weapon-visibility-${name}.png`;await page.screenshot({path});evidence.actions.push({screenshot:path});save();return path}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:15000});
 const context=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'});
 await context.route('**/*',route=>{if(new URL(route.request().url()).origin!==origin){evidence.external.push(route.request().url());return route.abort()}return route.continue()});
 const page=await context.newPage();page.setDefaultTimeout(10000);
 page.on('pageerror',e=>evidence.errors.push(e.message));
 page.on('console',m=>{if(evidence.console.length<3000)evidence.console.push(m.text())});
 await page.goto(origin);await page.locator('#start').click();
 await page.waitForFunction(()=>document.querySelector('#start').dataset.state==='ready',{},{timeout:45000});
 await page.waitForTimeout(4000);
 // Reproduce an existing player's disabled preference before match startup.
 const handler=await page.evaluate(()=>{const f=originalModule.asm.__indirect_function_table.get(20593);if(f.name!=='74636')throw Error('Unexpected build');f(0,0,0);return f.name});
 evidence.actions.push({setRenderWeapon:false,handler});
 await page.locator('#start-match').click();await page.waitForTimeout(20000);await shot(page,'team');
 console.log(JSON.stringify({ready:true,actions:evidence.actions}));save();
 if(process.argv.includes('--auto')){
  await page.waitForTimeout(125000);
  await shot(page,'startup-restored');
  await page.evaluate(()=>originalModule.asm.__indirect_function_table.get(20593)(0,0,0));
  await page.waitForTimeout(1500);await shot(page,'hidden');
  await page.locator('#show-weapon').click();
  await page.waitForTimeout(1500);await shot(page,'restored');
  await page.mouse.click(1060,418); // Close the native buy wheel before firing.
  await page.waitForTimeout(500);
  await page.mouse.click(650,300);await page.waitForTimeout(500);await shot(page,'fired');
  await page.setViewportSize({width:1920,height:1080});await page.waitForTimeout(1500);await shot(page,'resized');
  await close();console.log(JSON.stringify({complete:true,errors:evidence.errors,external:evidence.external}));process.exit(0);
 }
 timer=setTimeout(()=>close().then(()=>process.exit(0)),240000);
 for await(const line of readline.createInterface({input:process.stdin})){
  try{
   const c=JSON.parse(line);
   if(c.close){await close();break}
   if(c.wait)await page.waitForTimeout(Math.min(c.wait,15000));
   if(c.hide){await page.evaluate(()=>originalModule.asm.__indirect_function_table.get(20593)(0,0,0));evidence.actions.push({setRenderWeapon:false})}
   if(c.show){await page.locator('#show-weapon').click();evidence.actions.push({click:'Show gun'})}
   if(c.key){await page.keyboard.press(c.key);evidence.actions.push({key:c.key})}
   if(c.click)await page.mouse.click(...c.click);
   if(c.viewport){await page.setViewportSize(c.viewport);evidence.actions.push({viewport:c.viewport})}
   const screenshot=c.shot?await shot(page,c.shot):null;save();console.log(JSON.stringify({done:true,screenshot,errors:evidence.errors}));
  }catch(error){console.log(JSON.stringify({error:error.message}));save()}
 }
}catch(error){evidence.error=error.stack;console.log(error.stack);await close();process.exitCode=1}
