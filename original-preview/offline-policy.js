// Loaded before the supplied framework. No original service is emulated here.
(() => {
 const basePath=window.BuildBasePath||'/';
 const allowedPaths=new Set(['/','/offline-policy.js','/framework.js','/loader.js','/game-audio.js','/molotov-rules.js','/kourstrike-rules.js','/round-debug.js','/photon-client.js','/game.data','/source.wasm','/local-config.json']);
 const allowedMaps=new Set(['/StreamingAssets/map7','/StreamingAssets/map8','/StreamingAssets/map10','/StreamingAssets/settingspanel','/StreamingAssets/classselectpanel','/StreamingAssets/characters/meshes/head/40','/StreamingAssets/characters/meshes/body-attachments/34']);
 // Static mesh dependencies from the supplied prefabs, served only locally.
 const meshBundles=['ak109','awp','axe','beretta','bomb','cz','deagle','famas','flamethrower','grenades/mesh/flash','grenades/mesh/grenade','grenades/mesh/molotov','grenades/mesh/smoke','kar98','knife','lasergun1','lasergun2','m4a4','minigun','mp5','p90','pkm','revolver','scar','tec9','thompson','umbrella','ump45','usps','uzi','vector1','vector2','vector3','xm1014'];
 for(const name of meshBundles)allowedMaps.add('/StreamingAssets/'+name);
 const texturePaths=new Set(window.LocalTexturePaths||[]);
 function validTextureQuery(url){return url.search.length<128&&[...url.searchParams.keys()].every(k=>k==='size')&&url.searchParams.getAll('size').length<=1&&(!url.searchParams.has('size')||/^[1-9]\d{0,3}x[1-9]\d{0,3}$/.test(url.searchParams.get('size')))}
 function localTextureAlias(input){try{const value=typeof input==='string'||input instanceof URL?String(input):input.url;const url=new URL(value,location.href);if(url.origin!=='https://kour.io'||url.username||url.password||!texturePaths.has(url.pathname)||!validTextureQuery(url))return null;return new URL(basePath+url.pathname.slice(1)+url.search,location.href).href}catch{return null}}
 const counts=Object.create(null);
 function blocked(kind){counts[kind]=(counts[kind]||0)+1;if(counts[kind]===1)console.info('LOCAL MODE: disabled '+kind)}
 function isLocalAsset(input){try{const value=typeof input==='string'||input instanceof URL?String(input):input.url;const url=new URL(value,location.href);if(url.origin!==location.origin||url.username||url.password||!url.pathname.startsWith(basePath))return false;const pathname='/'+url.pathname.slice(basePath.length);if(texturePaths.has(pathname))return validTextureQuery(url);if(allowedMaps.has(pathname))return [...url.searchParams.keys()].every(k=>k==='v')&&url.search.length<128;return allowedPaths.has(pathname)&&!url.search}catch{return false}}
 const nativeFetch=window.fetch.bind(window);
 window.fetch=(input,options)=>{const alias=localTextureAlias(input);if(alias&&!['GET','HEAD'].includes(String(options?.method||input?.method||'GET').toUpperCase()))return Promise.reject(new DOMException('Static textures are read-only.','SecurityError'));const target=alias?(typeof input==='string'||input instanceof URL?alias:new Request(alias,input)):input;if(isLocalAsset(target))return nativeFetch(target,options);blocked('service requests');return Promise.reject(new DOMException('External services are disabled in local mode.','SecurityError'))};
 const nativeOpen=XMLHttpRequest.prototype.open;
 XMLHttpRequest.prototype.open=function(method,url,...rest){const alias=localTextureAlias(url);if(alias&&!['GET','HEAD'].includes(String(method).toUpperCase()))throw new DOMException('Static textures are read-only.','SecurityError');const target=alias||url;if(!isLocalAsset(target)){blocked('service requests');throw new DOMException('External services are disabled in local mode.','SecurityError')}return nativeOpen.call(this,method,target,...rest)};
 class DisconnectedSocket extends EventTarget {
  static CONNECTING=0;static OPEN=1;static CLOSING=2;static CLOSED=3;
  CONNECTING=0;OPEN=1;CLOSING=2;CLOSED=3;readyState=0;bufferedAmount=0;extensions='';protocol='';binaryType='blob';
  constructor(url){super();this.url=String(url);blocked('multiplayer connections');setTimeout(()=>{if(this.readyState!==0)return;this.readyState=3;this.emit(new Event('error'));this.emit(new CloseEvent('close',{code:1006,reason:'Multiplayer is unavailable in local mode.',wasClean:false}))},0)}
  emit(event){this.dispatchEvent(event);this['on'+event.type]?.call(this,event)}
  send(){throw new DOMException('No local multiplayer server is configured.','InvalidStateError')}
  close(){if(this.readyState===3)return;this.readyState=3;setTimeout(()=>this.emit(new CloseEvent('close',{code:1000,wasClean:true})),0)}
 }
 // Only an explicit online action enables Photon WSS. Original account, ad,
 // telemetry and matchmaking services remain blocked, including HTTP requests.
 const NativeWebSocket=window.WebSocket;
 let photonEnabled=false;
 function isPhotonSocket(value){try{const url=new URL(String(value));return url.protocol==='wss:'&&!url.username&&!url.password&&['photonengine.io','photonengine.com','exitgames.com'].some(domain=>url.hostname===domain||url.hostname.endsWith('.'+domain))}catch{return false}}
 if(NativeWebSocket){
  window.WebSocket=new Proxy(NativeWebSocket,{construct(Target,args){if(photonEnabled&&isPhotonSocket(args[0]))return Reflect.construct(Target,args);return new DisconnectedSocket(args[0])}});
 }else window.WebSocket=DisconnectedSocket;
 window.EventSource=class extends EventTarget {static CONNECTING=0;static OPEN=1;static CLOSED=2;readyState=0;constructor(){super();blocked('event streams');setTimeout(()=>{this.readyState=2;const event=new Event('error');this.dispatchEvent(event);this.onerror?.call(this,event)},0)}close(){this.readyState=2}};
 navigator.sendBeacon=()=>{blocked('analytics');return false};
 window.open=()=>{blocked('external links');return null};
 // Covers HTML links as well as the supplied engine's OpenURL bridge.
 document.addEventListener('click',event=>{const link=event.target.closest?.('a[href]');if(link&&!isLocalAsset(link.href)){event.preventDefault();blocked('external links')}},true);
 window.OfflinePolicy={blocked,counts,isLocalAsset,isPhotonSocket,enablePhoton(appId){if(!/^[0-9a-f]{8}(?:-[0-9a-f]{4}){3}-[0-9a-f]{12}$/i.test(appId))throw Error('Enter a valid Photon Realtime App ID.');photonEnabled=true},disablePhoton(){photonEnabled=false}};
})();
