// Native adapter for the hash-guarded supplied build. Called synchronously by
// the injected StartRound hook, before C4 selection or player spawning.
window.createKourStrikeRules=function(module,{log=console.log,onSwap=()=>{}}={}){
 const contracts={room:[27666,'24867',1],localPlayer:[27667,'24943',1],players:[27670,'24946',1],offline:[27672,'24948',1],team:[28158,'74087',2],switchTeam:[28163,'74109',3],round:[20450,'74519',2],clone:[26337,'80828',2],get:[3727,'80818',3],put:[3780,'80819',4],publish:[27522,'23926',5],name:[3300,'84181',2],startRound:[20444,'74516',4],setState:[20451,'74513',5],endRound:[20446,'74520',3],box:[1036,'2162',2]};
 const table=module.asm.__indirect_function_table,functions={};
 function fn(name){if(!functions[name]){const [slot,identity,arity]=contracts[name],f=table.get(slot);if(f.name!==identity||f.length!==arity)throw Error('Unsupported native round API: '+name);functions[name]=f}return functions[name]}
 const u32=p=>module.HEAPU32[p>>>2],valid=p=>Number.isInteger(p)&&p>=1024&&p%4===0&&p+128<module.HEAPU8.length;
 function text(p){if(!valid(p))return'';const length=u32(p+8);if(length>256||p+12+length*2>module.HEAPU8.length)return'';return String.fromCharCode(...module.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+length))}
 function key(name,required=true){const address={CurrentRound:7013824,T1S:7033132,T2S:7033136}[name],p=u32(address);if(!valid(p)||text(p)!==name){if(required)throw Error('Round properties are not initialized: '+name);return 0}return p}
 function property(props,name){const k=key(name,false);if(!k||!valid(props))return{box:0,value:0};const box=fn('get')(props,k,0);return{box,value:valid(box)?module.HEAP32[(box+8)>>>2]:0}}
 function context(){const room=fn('room')(0);if(!valid(room))return null;const klass=u32(6910428);if(!valid(klass))return null;const statics=u32(klass+92);if(!valid(statics))return null;const manager=u32(statics+20),local=fn('localPlayer')(0);if(!valid(manager)||!valid(local))return null;const team=fn('team')(local,0),code=valid(team)?module.HEAPU8[team+12]:0;return{room,manager,local,props:u32(room+12),code,team:text(valid(team)?u32(team+8):0),round:fn('round')(manager,0),phase:module.HEAP32[(manager+100)>>>2],offline:!!fn('offline')(0)}}
 function publish(room,props){if(!fn('publish')(room,props,0,0,0))throw Error('Could not update the local round properties')}
 function boxInt(value){
  const klass=u32(8037700);if(!valid(klass))throw Error('The match is still initializing.');
  const scratch=module.asm.malloc(4);if(!scratch)throw Error('Could not allocate the round property value.');
  try{module.HEAP32[scratch>>>2]=value;return fn('box')(klass,scratch)}finally{module.asm.free(scratch)}
 }
 function players(){const array=fn('players')(0),result=[];if(!valid(array)||u32(array+12)>256)throw Error('Invalid player list');for(let i=0;i<u32(array+12);i++){const player=u32(array+16+i*4),team=fn('team')(player,0);if(valid(team)){const code=module.HEAPU8[team+12];if(code===1||code===2)result.push({player,code})}}return result}
 let state=null;
 function refreshTeamCaches(){
  const teams=table.get(12380),update=table.get(28139);
  if(teams.name!=='74078'||update.name!=='74086')throw Error('Unsupported team roster API');
  update(teams(0),0);
  const ctx=context(),canvas=ctx?u32(ctx.manager+76):0;
  if(valid(canvas)&&table.get(11431)(canvas,0)){
   const refresh=table.get(18158);
   if(refresh.name!=='74670'||refresh.length!==2)throw Error('Unsupported buy-menu team refresh API');
   refresh(canvas,0);
  }
 }
 function replaceLocalPlayer(){
  const klass=u32(6908040),statics=valid(klass)?u32(klass+92):0,network=valid(statics)?u32(statics+56):0;
  if(!valid(network))return;
  const get=table.get(19879),destroy=table.get(27756),finish=table.get(3127);
  if(get.name!=='74902'||get.length!==3||destroy.name!=='25040'||destroy.length!==2||finish.name!=='84199'||finish.length!==2)throw Error('Unsupported native player respawn API');
  const out=module.asm.malloc(4);
  try{
   if(!get(network,out,0))return;
   const player=u32(out);
   // Photon teardown removes view registrations and disables the old player.
   // Finish destroying that instance now so the native round-start code sees
   // no player and takes its original SpawnPlayer branch, creating fresh
   // camera, controller, input, recoil and team components together.
   destroy(player,0);finish(player,0);
   if(get(network,out,0))throw Error('The previous player did not finish respawning.');
   log('Halftime: player and camera lifecycle reset.');
  }finally{module.asm.free(out)}
 }
 function remember(ctx){if(!state||state.room!==ctx.room||state.manager!==ctx.manager)state={room:ctx.room,manager:ctx.manager,initialTeam:ctx.code,half:0,roundStarts:0,swaps:0};if(!state.roundStarts&&ctx.round===0)state.initialTeam=ctx.code;return state}
 function beforeRound(){
  const ctx=context();if(!ctx?.offline||![1,2].includes(ctx.code))return;
  const match=remember(ctx),nextRound=ctx.round+1,targetHalf=nextRound>=13?1:0;
  if(targetHalf!==match.half){
   const roster=players(),changed=[],t=property(ctx.props,'T1S'),ct=property(ctx.props,'T2S');
   try{
    // Native rooms omit a side's score until it earns points. Missing means
    // zero, including when neither side has scored. Prepare both values before
    // changing any memberships, then publish the score exchange atomically.
    const tKey=key('T1S',false),ctKey=key('T2S',false);
    let scores=null;
    if(tKey&&ctKey){
     const zero=!t.box||!ct.box?boxInt(0):0;
     scores=fn('clone')(ctx.props,0);
     fn('put')(scores,tKey,ct.box||zero,0);fn('put')(scores,ctKey,t.box||zero,0);
    }
    for(const entry of roster){const next=entry.code===1?2:1;if(!fn('switchTeam')(entry.player,next,0))throw Error('Could not change player side');changed.push(entry);const team=fn('team')(entry.player,0);if(!valid(team)||module.HEAPU8[team+12]!==next)throw Error('Player side change did not complete')}
    refreshTeamCaches();
    replaceLocalPlayer();
    if(scores)publish(ctx.room,scores);
    match.half=targetHalf;match.swaps++;
   }catch(error){for(const entry of changed.reverse())fn('switchTeam')(entry.player,entry.code,0);refreshTeamCaches();throw error}
   const after=context();log('Sides swapped before round '+nextRound+'.');onSwap({round:nextRound,team:after.team,teamCode:after.code,swaps:match.swaps});
  }
  match.roundStarts++;
 }
 function inspect(){const ctx=context();if(!ctx)return null;const match=remember(ctx);return{round:ctx.round,phase:ctx.phase,team:ctx.team,teamCode:ctx.code,offline:ctx.offline,tScore:property(ctx.props,'T1S').value,ctScore:property(ctx.props,'T2S').value,half:match.half,swaps:match.swaps,bombHolder:module.HEAP32[(ctx.manager+104)>>>2]}}
 return{beforeRound,inspect,reset(){state=null},native:{module,fn,context,key,property,publish,valid,u32}};
};
