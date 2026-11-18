// Local-only ownership adapter; account records and original files are unchanged.
window.installLocalCosmetics=function(module){
 const table=module.asm.__indirect_function_table,restores=[];
 const enc=s=>[s.length,...new TextEncoder().encode(s)],section=(id,b)=>[id,b.length,...b];
 const bytes=new Uint8Array([0,97,115,109,1,0,0,0,...section(1,[1,96,2,127,127,1,127]),...section(2,[1,...enc('env'),...enc('hook'),0,0]),...section(3,[1,0]),...section(7,[1,...enc('call'),0,1]),...section(10,[1,8,0,32,0,32,1,16,0,11])]);
 const code=new WebAssembly.Module(bytes),allowed=new Set(['CharacterSkin','Hat','Emote']);
 function typeOf(p){const h=module.HEAPU32,b=module.HEAPU8;if(p<1024||p+8>=b.length)return'';const k=h[p>>>2],name=h[(k+8)>>>2];if(!name||name+128>=b.length)return'';let end=name;while(end<name+128&&b[end])end++;return new TextDecoder().decode(b.subarray(name,end))}
 for(const [slot,id]of [[19311,'75212'],[18651,'76220']]){
  const original=table.get(slot);if(original.name!==id||original.length!==2)throw Error('Unknown cosmetic ownership API');
  const hook=(item,method)=>allowed.has(typeOf(item))?1:original(item,method);
  const wrapper=new WebAssembly.Instance(code,{env:{hook}}).exports.call;table.set(slot,wrapper);restores.push(()=>table.set(slot,original));
 }
 return{inspect:()=>({types:[...allowed],scope:'local build'}),dispose(){for(const restore of restores)restore()}};
};
