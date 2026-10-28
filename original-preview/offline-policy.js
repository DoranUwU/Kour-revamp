// Loaded before the supplied framework. No original service is emulated here.
(() => {
 const allowedPaths=new Set(['/','/offline-policy.js','/framework.js','/loader.js','/game.data','/source.wasm','/local-config.json']);
 const allowedMaps=new Set(['/StreamingAssets/map7','/StreamingAssets/map8','/StreamingAssets/map10']);
 // Static mesh dependencies from the supplied prefabs, served only locally.
 const meshBundles=['ak109','awp','axe','beretta','bomb','cz','deagle','famas','flamethrower','grenades/mesh/flash','grenades/mesh/grenade','grenades/mesh/molotov','grenades/mesh/smoke','kar98','knife','lasergun1','lasergun2','m4a4','minigun','mp5','p90','pkm','revolver','scar','tec9','thompson','umbrella','ump45','usps','uzi','vector1','vector2','vector3','xm1014'];
 for(const name of meshBundles)allowedMaps.add('/StreamingAssets/'+name);
 const counts=Object.create(null);
 function blocked(kind){counts[kind]=(counts[kind]||0)+1;if(counts[kind]===1)console.info('LOCAL MODE: disabled '+kind)}
 function isLocalAsset(input){try{const value=typeof input==='string'||input instanceof URL?String(input):input.url;const url=new URL(value,location.href);if(url.origin!==location.origin||url.username||url.password)return false;if(allowedMaps.has(url.pathname))return [...url.searchParams.keys()].every(k=>k==='v')&&url.search.length<128;return allowedPaths.has(url.pathname)&&!url.search}catch{return false}}
 const nativeFetch=window.fetch.bind(window);
 window.fetch=(input,options)=>{if(isLocalAsset(input))return nativeFetch(input,options);blocked('service requests');return Promise.reject(new DOMException('External services are disabled in local mode.','SecurityError'))};
 const nativeOpen=XMLHttpRequest.prototype.open;
 XMLHttpRequest.prototype.open=function(method,url,...rest){if(!isLocalAsset(url)){blocked('service requests');throw new DOMException('External services are disabled in local mode.','SecurityError')}return nativeOpen.call(this,method,url,...rest)};
 class DisconnectedSocket extends EventTarget {
  static CONNECTING=0;static OPEN=1;static CLOSING=2;static CLOSED=3;
  CONNECTING=0;OPEN=1;CLOSING=2;CLOSED=3;readyState=0;bufferedAmount=0;extensions='';protocol='';binaryType='blob';
  constructor(url){super();this.url=String(url);blocked('multiplayer connections');setTimeout(()=>{if(this.readyState!==0)return;this.readyState=3;this.emit(new Event('error'));this.emit(new CloseEvent('close',{code:1006,reason:'Multiplayer is unavailable in local mode.',wasClean:false}))},0)}
  emit(event){this.dispatchEvent(event);this['on'+event.type]?.call(this,event)}
  send(){throw new DOMException('No local multiplayer server is configured.','InvalidStateError')}
  close(){if(this.readyState===3)return;this.readyState=3;setTimeout(()=>this.emit(new CloseEvent('close',{code:1000,wasClean:true})),0)}
 }
 window.WebSocket=DisconnectedSocket;
 window.EventSource=class extends EventTarget {static CONNECTING=0;static OPEN=1;static CLOSED=2;readyState=0;constructor(){super();blocked('event streams');setTimeout(()=>{this.readyState=2;const event=new Event('error');this.dispatchEvent(event);this.onerror?.call(this,event)},0)}close(){this.readyState=2}};
 navigator.sendBeacon=()=>{blocked('analytics');return false};
 window.open=()=>{blocked('external links');return null};
 // Covers HTML links as well as the supplied engine's OpenURL bridge.
 document.addEventListener('click',event=>{const link=event.target.closest?.('a[href]');if(link&&!isLocalAsset(link.href)){event.preventDefault();blocked('external links')}},true);
 window.OfflinePolicy={blocked,counts,isLocalAsset};
})();
