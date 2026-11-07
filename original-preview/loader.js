const logElement=document.querySelector('#log');
function log(...args){const text=args.map(String).join(' ');console.log(text);logElement.textContent+='\n'+text;logElement.scrollTop=logElement.scrollHeight}
window.addEventListener('error',e=>log('ERROR',e.message));
window.addEventListener('unhandledrejection',e=>log('REJECTION',e.reason));
document.querySelector('#check-response').onclick=()=>log('HOST PAGE RESPONSIVE');
let activeModule;
let activeRoundRules,activeRoundDebug;
function showModeStatus(text){document.querySelector('#mode-status').textContent=text;log(text)}
// Verified against the supplied WASM build: this original settings handler
// persists renderWeapon and toggles the live first-person weapon camera.
// Its instance argument is unused; the method also handles absent cameras.
function restoreWeaponVisibility(){
 const table=activeModule?.asm?.__indirect_function_table;
 const setRenderWeapon=table?.get(20593);
 if(typeof setRenderWeapon!=='function'||setRenderWeapon.name!=='74636'||setRenderWeapon.length!==3)throw Error('Weapon visibility is unavailable for this runtime build.');
 setRenderWeapon(0,1,0);
 log('Weapon rendering enabled through the original game settings.');
}
document.querySelector('#show-weapon').onclick=()=>{
 try{restoreWeaponVisibility()}catch(error){log('WEAPON VISIBILITY',error.message)}
};
window.startKourStrikeOffline=async()=>{
 try{
  const config=await(await fetch('/local-config.json')).json();
  if(!config.mapAvailable){showModeStatus('KourStrike needs the missing Kour2 map bundle: original-preview/StreamingAssets/map7');return false}
  const table=activeModule?.asm?.__indirect_function_table;
  if(!table)throw Error('Load the local build before starting a match.');
  restoreWeaponVisibility();
  activeRoundRules?.reset();
  activeModule.SendMessage('Canvas','ForceSetGameMode','Search And Destroy');
  table.get(27673)(1,0); // PhotonNetwork.set_OfflineMode(bool, MethodInfo*)
  table.get(21283)(7,0); // UIManager.LoadForceMap(mapNumber, MethodInfo*)
  showModeStatus('KourStrike offline / Kour2. Select a team; the initial warmup can take up to 2 minutes.');return true;
 }catch(error){showModeStatus('KourStrike startup failed: '+error.message);return false}
};
document.querySelector('#start-match').onclick=window.startKourStrikeOffline;
const reported=new Set();
function logOnce(key,...args){if(!reported.has(key)){reported.add(key);log(...args)}}

// Contract consumed by the supplied framework's _JS_WebRequest_Send. Buffered
// delivery is intentional: one complete chunk also works without Content-Length.
async function fetchUnityWithProgress(url,options={}){
 const {onProgress,enableStreamingDownload,...init}=options;
 const response=await fetch(url,init);
 const body=new Uint8Array(await response.arrayBuffer());
 response.parsedBody=body;
 onProgress?.({response,loaded:body.length,total:body.length,lengthComputable:true,...(enableStreamingDownload?{chunk:body}:{})});
 return response;
}
document.addEventListener('securitypolicyviolation',e=>logOnce('policy:'+e.violatedDirective,'OFFLINE: external resource unavailable',e.violatedDirective));
window.open=()=>{if(window.OfflinePolicy)window.OfflinePolicy.blocked('external links');else logOnce('popup','LOCAL MODE: external links disabled');return null};

// These functions belonged to the missing original host page. Implement local
// browser behavior where possible; do not fabricate accounts, ads or responses.
window.setCursor=value=>{const cursor=typeof value==='string'&&CSS.supports('cursor',value)?value:value===false?'none':'default';document.querySelector('#canvas').style.cursor=cursor};
window.testDevice=()=>/Android|iPhone|iPad|iPod/i.test(navigator.userAgent);
window.UnlockCursor=()=>document.exitPointerLock?.();
window.LockCursor=()=>{if(navigator.userActivation&&!navigator.userActivation.isActive)return;try{document.querySelector('#canvas').requestPointerLock?.()?.catch?.(()=>{})}catch{}};
window.AllowCtrlW=()=>logOnce('host:AllowCtrlW','LOCAL MODE: browser close shortcut uses its normal behavior');
window.PreventCtrlW=window.AllowCtrlW;
window.gameplayStart=()=>logOnce('host:gameplayStart','LOCAL MODE: external gameplay telemetry disabled');
for(const name of ['SetAds','checkVersion','requestUserData','SetURL'])window[name]=()=>{logOnce('host:'+name,'OFFLINE: host service unavailable',name)};

function createQuitCleanup(module){
 let cleaned=false;
 return()=>{
  if(cleaned)return;
  cleaned=true;
  // Drain once before invoking callbacks so reentrant quit cannot run twice.
  const callbacks=module.deinitializers.splice(0);
  for(const callback of callbacks){try{callback()}catch(error){log('CLEANUP CALLBACK FAILED',error.message||error)}}
  log('RUNTIME STOPPED: original client requested shutdown; reload to restart.');
 };
}
document.querySelector('#start').onclick=async()=>{
 document.querySelector('#start').disabled=true;
 try{
 const config=await(await fetch('/local-config.json')).json();
 showModeStatus(config.profile==='kourstrike'?(config.mapAvailable?'KourStrike: local Kour2 map is ready.':'KourStrike selected; Kour2 map7 is missing from original-preview/StreamingAssets/.'):'Original lobby profile');
 const bytes=new Uint8Array(await(await fetch('/game.data')).arrayBuffer());
 const view=new DataView(bytes.buffer),header=view.getUint32(16,true),files=[];
 for(let i=20;i<header;){const offset=view.getUint32(i,true),size=view.getUint32(i+4,true),len=view.getUint32(i+8,true);i+=12;const name=new TextDecoder().decode(bytes.subarray(i,i+len));i+=len;files.push({name,offset,size})}
 const canvas=document.querySelector('#canvas');
 const module={canvas,preRun:[],postRun:[],deinitializers:[],print:log,printErr:log,noExitRuntime:true,fetchWithProgress:fetchUnityWithProgress,
 onKourStrikeRoundStart:()=>activeRoundRules?.beforeRound(),
 locateFile:name=>name.includes('.wasm')?'/source.wasm':('/'+name),dataUrl:'/game.data',codeUrl:'/source.wasm',streamingAssetsUrl:new URL('/StreamingAssets',location.href).href,companyName:'Offline analysis',productName:'Supplied build',productVersion:'unknown',webglContextAttributes:{preserveDrawingBuffer:true},
 SystemInfo:{width:screen.width,height:screen.height,userAgent:navigator.userAgent,browser:'Edge',browserVersion:'130',mobile:false,os:'Windows',osVersion:'10',gpu:'Local browser',language:navigator.language,hasWebGL:2,hasWebGPU:false,hasCursorLock:true,hasFullscreen:true,hasThreads:typeof SharedArrayBuffer!=='undefined',hasWasm:true},
 disabledCanvasEvents:['contextmenu','dragstart'],startupErrorHandler:e=>log('STARTUP ERROR',e),errorHandler:e=>log('UNITY ERROR',e),onAbort:e=>log('ABORT',e),onRuntimeInitialized:()=>log('RUNTIME INITIALIZED'),setStatus:s=>{if(s)log('STATUS',s)},monitorRunDependencies:n=>log('DEPENDENCIES',n)};
 module.QuitCleanup=createQuitCleanup(module);
 module.preRun.push(()=>{for(const f of files){const slash=f.name.lastIndexOf('/'),dir=slash<0?'/':'/'+f.name.slice(0,slash),name=f.name.slice(slash+1);if(dir!=='/')module.FS_createPath('/',dir.slice(1),true,true);module.FS_createDataFile(dir,name,bytes.subarray(f.offset,f.offset+f.size),true,true,true)}log('MOUNTED',files.length,'files')});
 window.originalModule=module;
 activeModule=module;
 log('Starting local original runtime; remote services blocked');
 await unityFramework(module);document.querySelector('#start').dataset.state='ready';log('FRAMEWORK READY');
 if(config.profile==='kourstrike'){
  activeRoundRules=window.createKourStrikeRules(module,{log,onSwap:state=>showModeStatus(`${state.round>=13?'Halftime':'First half'}: now playing ${state.team==='t'?'Terrorists':'Counter-Terrorists'}.`)});
  window.localKourStrikeRules=activeRoundRules;
  activeRoundDebug=window.installKourStrikeRoundDebug?.(activeRoundRules);
  module.deinitializers.push(()=>activeRoundDebug?.dispose());
 }
 document.querySelector('#show-weapon').disabled=false;
 document.querySelector('#start-match').disabled=config.profile!=='kourstrike';
 if(config.profile==='kourstrike')setTimeout(()=>{try{module.SendMessage('Canvas','ForceSetGameMode','Search And Destroy')}catch(error){log('MODE SELECTION',error.message)}},1000);
 }catch(e){log('LOADER FAILED',e.stack||e)}
};
