const logElement=document.querySelector('#log');
function log(...args){const text=args.map(String).join(' ');console.log(text);logElement.textContent+='\n'+text;logElement.scrollTop=logElement.scrollHeight}
window.addEventListener('error',e=>log('ERROR',e.message));
window.addEventListener('unhandledrejection',e=>log('REJECTION',e.reason));
document.querySelector('#check-response').onclick=()=>log('HOST PAGE RESPONSIVE');
let activeModule;
let activeRoundRules,activeRoundDebug;
// Host diagnostics stay available in the lobby and local games only.
function updateOnlinePresentation(){
 const connection=window.photonClient?.inspect();
 const online=!!connection?.inRoom&&!connection.offline&&!!nativeSettingsContext()?.map;
 document.body.classList.toggle('online-match',online);
}
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
// Exact supplied-build entry points for lobby and active-map Settings owners.
function menuFunction(slot,name,arity){const f=activeModule?.asm?.__indirect_function_table?.get(slot);if(typeof f!=='function'||f.name!==name||f.length!==arity)throw Error('Native menus are unavailable for this runtime build.');return f}
function nativeSettingsContext(){
 const m=activeModule;if(!m?.asm)return null;const out=m.asm.malloc(4);
 try{for(const [slot,name,offset,map]of [[19576,'77518',340,true],[12367,'76597',256,false]]){m.HEAPU32[out>>>2]=0;if(menuFunction(slot,name,2)(out,0)){const owner=m.HEAPU32[out>>>2];return{owner,panel:m.HEAPU32[(owner+offset)>>>2],map}}}return null}finally{m.asm.free(out)}
}
function nativeCustomizePanel(){const h=activeModule?.HEAPU32;if(!h)return 0;const klass=h[6901068>>>2],statics=klass?h[(klass+92)>>>2]:0,owner=statics?h[(statics+4)>>>2]:0;return owner?h[(owner+64)>>>2]:0}
let settingsPauseOwner=0,settingsInputFlags=null,settingsSeenOpen=false;
function localMenuInput(){const h=activeModule.HEAPU32,k=h[6910700>>>2],sf=k?h[(k+92)>>>2]:0,sh=sf?h[sf>>>2]:0;return sh>1024&&sh+204<h.byteLength?h[(sh+200)>>>2]:0}

// PlayerInputHandler static +9/+10/+11 are movement, shooting and inventory gates.
// Reapply before each Unity frame so round/spawn callbacks cannot release them.
function holdSettingsInput(){
 if(!settingsPauseOwner)return;const context=nativeSettingsContext();if(context?.owner!==settingsPauseOwner)return;if(context.panel&&menuFunction(11431,'83962',2)(context.panel,0))settingsSeenOpen=true;const m=activeModule,h=m.HEAPU32,k=h[6908800>>>2],sf=k?h[(k+92)>>>2]:0;
 if(sf){m.HEAPU8[sf+9]=1;m.HEAPU8[sf+10]=1;m.HEAPU8[sf+11]=1}
 const input=localMenuInput();if(input&&!m.HEAPU8[input+80])menuFunction(20104,'75375',2)(input,0);
}
function pauseForSettings(ctx){
 if(!ctx?.map)return;
 const m=activeModule,pausePanel=m.HEAPU32[(ctx.owner+272)>>>2];if(!pausePanel)return;
 const manager=activeRoundRules?.native.context()?.manager,buy=manager?m.HEAPU32[(manager+76)>>>2]:0;
 // The buy canvas otherwise draws over Settings and intercepts pointer events.
 if(buy&&menuFunction(20427,'74499',2)(manager,0)){
  menuFunction(18165,'74678',2)(buy,0);
  menuFunction(3124,'84045',3)(menuFunction(2954,'83983',2)(buy,0),0,0);
 }
 const sf=m.HEAPU32[(m.HEAPU32[6908800>>>2]+92)>>>2];
 if(!settingsInputFlags)settingsInputFlags=[m.HEAPU8[sf+9],m.HEAPU8[sf+10],m.HEAPU8[sf+11]];
 menuFunction(18419,'74877',1)(0);
 menuFunction(3124,'84045',3)(pausePanel,1,0);
 const input=localMenuInput();if(input)menuFunction(20104,'75375',2)(input,0);
 settingsPauseOwner=ctx.owner;holdSettingsInput();
}
function resumeAfterSettings(){
 if(!settingsPauseOwner)return;const ctx=nativeSettingsContext(),owner=settingsPauseOwner;settingsPauseOwner=0;
 if(settingsInputFlags&&ctx?.map&&ctx.owner===owner){const m=activeModule,sf=m.HEAPU32[(m.HEAPU32[6908800>>>2]+92)>>>2];m.HEAPU8.set(settingsInputFlags,sf+9);settingsInputFlags=null}
 settingsInputFlags=null;
 if(ctx?.map&&ctx.owner===owner){menuFunction(19622,'77721',2)(owner,0);const input=localMenuInput();if(input&&activeModule.HEAPU8[input+80])menuFunction(20105,'75383',2)(input,0);}
}
function openNativeMenu(kind){
 const m=activeModule;let owner,open;
 if(kind==='settings'){const ctx=nativeSettingsContext();if(!ctx)throw Error('Load the lobby or a match before opening Settings.');settingsSeenOpen=false;pauseForSettings(ctx);owner=ctx.owner;open=ctx.map?menuFunction(19616,'77718',2):menuFunction(21301,'76709',2)}
 else{const out=m.asm.malloc(4);try{if(!menuFunction(12367,'76597',2)(out,0))throw Error('Customize is available from the lobby.');owner=m.HEAPU32[out>>>2]}finally{m.asm.free(out)}open=menuFunction(21331,'76737',2)}
 document.exitPointerLock?.();open(owner,0);document.body.classList.add('native-menu-open');window.nativeMenuOpenedAt=performance.now();
}
for(const [id,kind]of [['open-settings','settings'],['open-customize','customize']])document.querySelector('#'+id).onclick=()=>{try{openNativeMenu(kind)}catch(error){log('MENU',error.message)}};
window.openNativeMenu=openNativeMenu;
// Handle Escape once in the host; Unity must not process the same key again.
document.addEventListener('keydown',event=>{
 if(event.key!=='Escape'||!activeModule?.asm||event.target?.matches?.('input,textarea,select,[contenteditable="true"]'))return;
 event.preventDefault();event.stopImmediatePropagation();if(event.repeat)return;
 try{const custom=nativeCustomizePanel();if(custom&&menuFunction(11431,'83962',2)(custom,0)){menuFunction(18372,'74842',3)(custom,0,0);return}const ctx=nativeSettingsContext();if(!ctx)return;if(ctx.panel&&menuFunction(11431,'83962',2)(ctx.panel,0)){
  if(ctx.map)menuFunction(19640,'77734',2)(ctx.owner,0);else menuFunction(20547,'74593',3)(ctx.panel,0,0);
 }else if(!document.body.classList.contains('native-menu-open')||performance.now()-window.nativeMenuOpenedAt>1500)openNativeMenu('settings');
 }catch(error){log('MENU',error.message)}
},true);

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
window.LockCursor=()=>{if(settingsPauseOwner)return;if(navigator.userActivation&&!navigator.userActivation.isActive)return;try{document.querySelector('#canvas').requestPointerLock?.()?.catch?.(()=>{})}catch{}};
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

// Unity's host contract includes tracked timer helpers. Audio initialization
// uses Module.setInterval before enabling playback; omitting it leaves sound
// disabled even though the browser successfully creates an AudioContext.
function installRuntimeTimers(module){
 const intervals=new Set(),timeouts=new Set();
 module.setInterval=(callback,delay)=>{const id=window.setInterval(callback,delay);intervals.add(id);return id};
 module.clearInterval=id=>{window.clearInterval(id);intervals.delete(id)};
 module.setTimeout=(callback,delay)=>{const id=window.setTimeout(()=>{timeouts.delete(id);callback()},delay);timeouts.add(id);return id};
 module.clearTimeout=id=>{window.clearTimeout(id);timeouts.delete(id)};
 module.deinitializers.push(()=>{for(const id of intervals)window.clearInterval(id);for(const id of timeouts)window.clearTimeout(id);intervals.clear();timeouts.clear()});
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
 preMainLoop:holdSettingsInput,
 onKourStrikeRoundStart:()=>activeRoundRules?.beforeRound(),
 onKourStrikeStateChange:()=>activeRoundRules?.beforeStateChange?.(),
 locateFile:name=>name.includes('.wasm')?'/source.wasm':('/'+name),dataUrl:'/game.data',codeUrl:'/source.wasm',streamingAssetsUrl:new URL('/StreamingAssets',location.href).href,companyName:'Offline analysis',productName:'Supplied build',productVersion:'unknown',webglContextAttributes:{preserveDrawingBuffer:true},
 SystemInfo:{width:screen.width,height:screen.height,userAgent:navigator.userAgent,browser:'Edge',browserVersion:'130',mobile:false,os:'Windows',osVersion:'10',gpu:'Local browser',language:navigator.language,hasWebGL:2,hasWebGPU:false,hasCursorLock:true,hasFullscreen:true,hasThreads:typeof SharedArrayBuffer!=='undefined',hasWasm:true},
 disabledCanvasEvents:['contextmenu','dragstart'],startupErrorHandler:e=>log('STARTUP ERROR',e),errorHandler:e=>log('UNITY ERROR',e),onAbort:e=>log('ABORT',e),onRuntimeInitialized:()=>log('RUNTIME INITIALIZED'),setStatus:s=>{if(s)log('STATUS',s)},monitorRunDependencies:n=>log('DEPENDENCIES',n)};
 installRuntimeTimers(module);
 window.gameAudio=window.createGameAudio?.(module,{log});
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
  window.molotovRules=window.createMolotovRules(module,{rules:activeRoundRules,log});module.deinitializers.push(()=>window.molotovRules.dispose());
  module.deinitializers.push(()=>activeRoundDebug?.dispose());
 }
 if(config.photonEnabled){
  const panel=document.querySelector('#photon-panel'),status=document.querySelector('#photon-status'),app=document.querySelector('#photon-app-id');
  app.value=config.photonAppId||'';document.querySelector('#photon-region').value=config.photonRegion||'asia';
  const client=window.createPhotonClient(module,{log,onStatus:message=>{status.textContent=message}});
  window.photonClient=client;panel.open=true;
  module.deinitializers.push(()=>client.dispose());
  for(const [id,action]of [['#photon-create','create'],['#photon-join','join']]){
   const button=document.querySelector(id);button.disabled=false;
   button.onclick=async()=>{const buttons=['#photon-create','#photon-join'].map(s=>document.querySelector(s));buttons.forEach(b=>b.disabled=true);document.querySelector('#start-match').disabled=true;
    try{restoreWeaponVisibility();activeRoundRules?.reset();await client[action]({appId:app.value.trim(),nickname:document.querySelector('#photon-name').value,room:document.querySelector('#photon-room').value,region:document.querySelector('#photon-region').value});panel.open=false}
    catch(error){log('PHOTON',error.message)}finally{buttons.forEach(b=>b.disabled=!!client.inspect().inRoom)}
   };
  }
  status.textContent='Ready. Create a room, or enter your friend?s room code and join.';
 }
 module.setInterval(updateOnlinePresentation,250);
 module.deinitializers.push(()=>document.body.classList.remove('online-match'));
 document.querySelector('#show-weapon').disabled=false;
 document.querySelector('#open-settings').disabled=false;document.querySelector('#open-customize').disabled=false;
 module.setInterval(()=>{
  if(!document.body.classList.contains('native-menu-open')||performance.now()-window.nativeMenuOpenedAt<1500)return;
  const h=module.HEAPU32,t=module.asm.__indirect_function_table,out=module.asm.malloc(4);
  try{h[out>>>2]=0;const settings=nativeSettingsContext()?.panel||0,klass=h[6901068>>>2],statics=klass?h[(klass+92)>>>2]:0,alltime=statics?h[(statics+4)>>>2]:0,customize=alltime?h[(alltime+64)>>>2]:0;
   if(settingsPauseOwner&&!settingsSeenOpen&&nativeSettingsContext()?.owner===settingsPauseOwner&&performance.now()-window.nativeMenuOpenedAt<15000)return;
   if(![settings,customize].some(p=>p>1024&&p+128<h.byteLength&&t.get(11431)(p,0))){document.body.classList.remove('native-menu-open');resumeAfterSettings()}
  }finally{module.asm.free(out)}
 },500);

 document.querySelector('#start-match').disabled=config.profile!=='kourstrike';
 if(config.profile==='kourstrike')setTimeout(()=>{try{module.SendMessage('Canvas','ForceSetGameMode','Search And Destroy')}catch(error){log('MODE SELECTION',error.message)}},1000);
 }catch(e){log('LOADER FAILED',e.stack||e)}
};
