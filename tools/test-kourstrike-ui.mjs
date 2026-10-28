import fs from 'node:fs';
import readline from 'node:readline';
import crypto from 'node:crypto';
import {createRequire} from 'node:module';
const require=createRequire(import.meta.url);
const {chromium}=require('C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/playwright-core');
const origin='http://127.0.0.1:8085';
const matchTest=process.argv.includes('--load-kourstrike');
const evidence={provider:'ordinary-playwright',purpose:'Native KourStrike offline UI route',console:[],requests:[],responses:[],failures:[],page_errors:[],actions:[],started:new Date().toISOString(),cleanup:'pending'};
let browser,page,idle;
const save=()=>fs.writeFileSync(`analysis/runtime/kourstrike-ui-${matchTest?'match-':''}evidence.json`,JSON.stringify(evidence,null,2));
async function close(){clearTimeout(idle);try{await browser?.close();evidence.cleanup='closed-owned-browser'}catch(e){evidence.cleanup=e.message}evidence.finished=new Date().toISOString();save();process.exit(0)}
function renew(){clearTimeout(idle);idle=setTimeout(close,180000)}
async function shot(name){const file='analysis/runtime/kourstrike-ui-'+(matchTest?'match-':'')+name.replace(/[^a-z0-9_-]/gi,'')+'.png';await page.screenshot({path:file,timeout:5000});evidence.actions.push({screenshot:file});save();return file}
async function nativeProbe(name){
 if(name==='approved_operation'){const source=fs.readFileSync('analysis/runtime/kourstrike-ui-approved-operation.js','utf8');const sha256=crypto.createHash('sha256').update(source).digest('hex');evidence.actions.push({approved_operation_source:source,sha256});return page.evaluate(source)}
 if(name==='load_map7'){await page.evaluate(()=>window.originalModule.SendMessage('MainManager','LoadMapByName','map7'));return{called:'MainManager.LoadMapByName',argument:'map7'}}
 if(name==='network_state')return page.evaluate(()=>{const t=originalModule.asm.__indirect_function_table;return{setName:t.get(27673).name,loadName:t.get(21283).name,offline:t.get(27672)(0),inRoom:t.get(27689)(0),isConnected:t.get(27659)(0),ready:t.get(27660)(0),networkState:t.get(27661)(0),roomPointer:t.get(27666)(0),queue:t.get(27682)(0),master:t.get(27688)(0)}});
 throw Error('Probe is not in the explicit metadata-verified whitelist');
}
try{
 browser=await chromium.launch({executablePath:'C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe',headless:true,timeout:10000});
 const context=await browser.newContext({viewport:{width:1280,height:720},serviceWorkers:'block'});
 await context.route('**/*',route=>{const u=new URL(route.request().url());if(u.origin!==origin){evidence.failures.push({blocked:u.origin+u.pathname});return route.abort('blockedbyclient')}return route.continue()});
 page=await context.newPage();page.setDefaultTimeout(5000);
 page.on('console',m=>{if(evidence.console.length<3000)evidence.console.push({type:m.type(),text:m.text(),time:Date.now()})});
 page.on('pageerror',e=>evidence.page_errors.push({message:e.message,stack:e.stack}));
 page.on('request',r=>{const u=new URL(r.url());evidence.requests.push({method:r.method(),origin:u.origin,path:u.pathname,url:r.url()})});
 page.on('response',r=>evidence.responses.push({url:r.url(),status:r.status()}));
 page.on('requestfailed',r=>{const u=new URL(r.url());evidence.failures.push({origin:u.origin,path:u.pathname,error:r.failure()})});
 await page.goto(origin+'/',{waitUntil:'domcontentloaded',timeout:10000});await page.locator('#start').click();await page.waitForTimeout(9000);
 if(matchTest){const wait=process.argv.includes('--quick')?3000:25000;await page.locator('#start-match').click();evidence.actions.push({initial:`Start, wait9sec, Start KourStrike offline, wait${wait}ms`});await page.waitForTimeout(wait);await page.locator('#check-response').click();await shot('after-start')}
 else{await page.mouse.click(732,332);await page.waitForTimeout(3000);evidence.actions.push({initial:'Start, wait9sec, native OfflineOK732,332, wait3sec'});await shot('lobby')}
 if(process.argv.includes('--force-search')){await page.evaluate(()=>window.originalModule.SendMessage('Canvas','ForceSetGameMode','Search And Destroy'));evidence.actions.push({native_send_message:{game_object:'Canvas',method:'ForceSetGameMode',argument:'Search And Destroy',provenance:'UIManager method33649, owner Canvas in level0 decoded behaviours'}});await page.waitForTimeout(2000);await shot('forced-search-and-destroy')}
 if(process.argv.includes('--load-map-native')){await page.evaluate(()=>window.originalModule.SendMessage('MainManager','LoadMapByName','map7'));evidence.actions.push({native_send_message:{game_object:'MainManager',method:'LoadMapByName',argument:'map7',provenance:'StreamingAssetsLoader33459, explicit parent-verified coroutine76590'}});await page.waitForTimeout(20000);await page.locator('#check-response').click();await shot('native-map-route')}
 if(process.argv.includes('--approved-operation')){const result=await nativeProbe('approved_operation');evidence.actions.push({probe:'approved_operation',result});console.log(JSON.stringify({approved_operation:result}));await page.waitForTimeout(20000);await page.locator('#check-response').click();await shot('approved-operation')}
 if(process.argv.includes('--network-state')){const state=await page.evaluate(()=>{const t=originalModule.asm.__indirect_function_table;return{setName:t.get(27673).name,loadName:t.get(21283).name,offline:t.get(27672)(0),inRoom:t.get(27689)(0),isConnected:t.get(27659)(0),ready:t.get(27660)(0),networkState:t.get(27661)(0),roomPointer:t.get(27666)(0),queue:t.get(27682)(0),master:t.get(27688)(0)}});evidence.network_state=state;save();console.log(JSON.stringify({network_state:state}))}
 console.log(JSON.stringify({ready:true,pid:process.pid,screenshot:'analysis/runtime/kourstrike-ui-lobby.png'}));renew();
 const lines=readline.createInterface({input:process.stdin});for await(const line of lines){renew();try{const c=JSON.parse(line);if(c.close){await close();break}if(c.probe){const result=await nativeProbe(c.probe);evidence.actions.push({probe:c.probe,result});console.log(JSON.stringify({probe:c.probe,result}))}if(c.click){await page.mouse.click(c.click[0],c.click[1]);evidence.actions.push({click:c.click})}if(c.key){await page.keyboard.press(c.key);evidence.actions.push({key:c.key})}if(c.wait)await page.waitForTimeout(Math.min(c.wait,15000));const screenshot=c.shot?await shot(c.shot):null;save();console.log(JSON.stringify({done:true,screenshot,errors:evidence.page_errors,requests:evidence.requests.slice(-8),console:evidence.console.slice(-8).map(x=>x.text)}))}catch(error){save();console.log(JSON.stringify({error:error.message}))}}
 await close();
}catch(error){evidence.error={message:error.message,stack:error.stack};save();console.log(JSON.stringify(evidence.error));await close()}
