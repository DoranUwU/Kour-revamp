// Native fire geometry and native Health.TakeHealth; Photon teams decide immunity.
window.createMolotovRules=function(module,{rules,log=console.log}={}){
 const table=module.asm.__indirect_function_table,handles=[];
 if(table.get(19122)?.name!=='77476'||table.get(19122)?.length!==8)throw Error('Unknown native Molotov damage contract');
 const fn=slot=>table.get(slot),u32=p=>module.HEAPU32[p>>>2],valid=p=>p>1024&&p%4===0&&p+128<module.HEAPU8.length;
 function root(p){if(!valid(p))throw Error('Invalid Molotov runtime reference');handles.push(fn(2105)(p,0));return p}
 function string(value){const p=fn(75048)(value.length,0);for(let i=0;i<value.length;i++)module.HEAPU16[((p+12)>>>1)+i]=value.charCodeAt(i);return root(p)}
 function text(p){if(!valid(p))return'';const length=u32(p+8);return length<128?String.fromCharCode(...module.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+length)):''}
 const tag=string('MolotovZone'),weapon=string('Molotov'),typeName=string('UnityEngine.BoxCollider, UnityEngine.PhysicsModule'),boxType=root(fn(76660)(typeName,0)),scratch=module.asm.malloc(64);
 let burns=0,last=null,disposed=false,faulted=false;
 function tick(){
  if(disposed||faulted)return;
  try{
   const ctx=rules.native.context();if(!ctx||![2,3].includes(ctx.phase))return;
   const klass=u32(6910700),statics=valid(klass)?u32(klass+92):0,shooter=valid(statics)?u32(statics):0;
   if(!valid(shooter))return;const view=fn(27903)(shooter,0);if(!view||!fn(27860)(view,0))return;
   const health=u32(shooter+108);if(!valid(health)||fn(15309)(health+108,0)<=0)return;
   const zones=fn(40621)(tag,0);if(!zones)return;const count=u32(zones+12);if(count>128)throw Error('Unexpected fire zone count');
   fn(2965)(scratch,fn(2964)(shooter,0),0);module.HEAPF32[(scratch>>>2)+1]+=0.9;
   const localActor=module.HEAP32[(ctx.local+12)>>>2];last={zones:count,eligible:0,inside:false};
   for(let i=0;i<count;i++){
    const zone=u32(zones+16+i*4),name=text(fn(3300)(zone,0));if(!/^[1-9]\d*$/.test(name))continue;
    const actor=Number(name),owner=fn(27529)(ctx.room,actor,0,0);if(!valid(owner))continue;
    const team=rules.native.fn('team')(owner,0),code=valid(team)?module.HEAPU8[team+12]:0;
    if(actor!==localActor&&(!code||!ctx.code||code===ctx.code))continue;
    const collider=fn(40607)(zone,boxType,0);if(!collider||!fn(3170)(collider,0))continue;last.eligible++;
    const transform=fn(3125)(zone,0);fn(41092)(scratch+12,transform,scratch,0);fn(3197)(scratch+24,collider,0);fn(3198)(scratch+36,collider,0);
    let inside=true;for(let axis=0;axis<3;axis++){const h=module.HEAPF32,point=h[((scratch+12)>>>2)+axis],center=h[((scratch+24)>>>2)+axis],size=h[((scratch+36)>>>2)+axis];if(!Number.isFinite(point)||Math.abs(point-center)>Math.abs(size)*0.5){inside=false;break}}
    if(!inside)continue;last.inside=true;last.owner=actor;
    // Preserve the original 14..21 damage every 0.33 s; overlapping flames do not stack.
    const damage=14+Math.floor(Math.random()*8);fn(19122)(health,1,damage,weapon,owner,0,scratch,0);burns++;last.damage=damage;break;
   }
  }catch(error){faulted=true;log('MOLOTOV',error.message||error)}
 }
 const timer=module.setInterval(tick,330);
 return{inspect:()=>({burns,last,faulted}),dispose(){if(disposed)return;disposed=true;module.clearInterval(timer);for(const handle of handles)fn(2577)(handle,0);module.asm.free(scratch)}};
};
