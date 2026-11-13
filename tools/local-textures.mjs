import fs from 'node:fs';
export const menuTextureAssets=Object.freeze(JSON.parse(fs.readFileSync(new URL('./menu-images.json',import.meta.url),'utf8')));
// Explicit static image dependencies; never proxy arbitrary remote URLs.
export const textureAssets=Object.freeze([
 {pathname:'/content/stream/weapon-skins/texture/mp5.png',file:'original-preview/content/stream/weapon-skins/texture/mp5.png'},
 {pathname:'/content/stream/weapon-skins/texture/awp.png',file:'original-preview/content/stream/weapon-skins/texture/awp.png'},
 {pathname:'/content/stream/weapon-skins/texture/revolver.png',file:'original-preview/content/stream/weapon-skins/texture/revolver.png'},
 {pathname:'/content/stream/weapon-skins/texture/grenade.png',file:'original-preview/content/stream/weapon-skins/texture/grenade.png'},
 {pathname:'/content/stream/weapon-skins/texture/smoke.png',file:'original-preview/content/stream/weapon-skins/texture/smoke.png'},
 {pathname:'/content/stream/weapon-skins/texture/flash.png',file:'original-preview/content/stream/weapon-skins/texture/flash.png'},
 {pathname:'/content/stream/weapon-skins/texture/molotov.png',file:'original-preview/content/stream/weapon-skins/texture/molotov.png'},
 {pathname:'/content/stream/weapon-skins/texture/bomb.png',file:'original-preview/content/stream/weapon-skins/texture/bomb.png'}
]);
export function prepareOfflinePolicy(source){
 return 'window.LocalTexturePaths=Object.freeze('+JSON.stringify([...textureAssets,...menuTextureAssets].map(x=>x.pathname))+');\n'+source;
}
