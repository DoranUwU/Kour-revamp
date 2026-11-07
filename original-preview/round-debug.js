// TEMPORARY test controls. Remove this script and the #round-debug panel when
// shipping; the normal halftime rule is entirely in kourstrike-rules.js.
window.installKourStrikeRoundDebug=function(rules){
 const {module,fn,context,key,publish,valid,u32}=rules.native;
 const panel=document.querySelector('#round-debug'),input=panel.querySelector('input'),set=panel.querySelector('[data-set-round]'),end=panel.querySelector('[data-end-round]'),status=panel.querySelector('[data-round-status]');
 function requireMatch(){const ctx=context();if(!ctx?.offline||![1,2].includes(ctx.code))throw Error('Start a local match and choose a team first.');return ctx}
 function boxInt(value){const klass=u32(8037700);if(!valid(klass))throw Error('The match is still initializing.');const scratch=module.asm.malloc(4);try{module.HEAP32[scratch>>>2]=value;return fn('box')(klass,scratch)}finally{module.asm.free(scratch)}}
 function setRound(value){
  if(!Number.isInteger(value)||value<1||value>99)throw Error('Enter a round from 1 to 99.');
  const ctx=requireMatch();rules.inspect(); // Capture the selected starting side before a first debug jump.
  const reason=fn('name')(ctx.manager,0);
  fn('setState')(ctx.manager,reason,0,0,0);
  const props=fn('clone')(u32(ctx.room+12),0);fn('put')(props,key('CurrentRound'),boxInt(value-1),0);publish(ctx.room,props);
  fn('startRound')(ctx.manager,reason,0,0);
  const result=rules.inspect();if(result.round!==value)throw Error('The requested round did not start.');return result;
 }
 function endRound(){const ctx=requireMatch();if(ctx.phase!==2)throw Error('Wait until the buy phase finishes.');fn('endRound')(ctx.manager,fn('name')(ctx.manager,0),0);return rules.inspect()}
 function refresh(){const s=rules.inspect();set.disabled=!s?.offline||![1,2].includes(s.teamCode);end.disabled=set.disabled||s.phase!==2;if(!status.dataset.error)status.textContent=s?`Round ${s.round} · ${s.team==='t'?'Terrorists':s.team==='ct'?'Counter-Terrorists':'Choose a team'}`:'Load a local match to test rounds.'}
 function run(action){try{const result=action();delete status.dataset.error;refresh();return result}catch(error){status.dataset.error='true';status.textContent=error.message;return null}}
 set.onclick=()=>run(()=>setRound(Number(input.value)));end.onclick=()=>run(endRound);
 function safeRefresh(){try{refresh()}catch(error){status.dataset.error='true';status.textContent='Round controls unavailable: '+error.message;set.disabled=true;end.disabled=true}}
 const timer=setInterval(safeRefresh,500);safeRefresh();
 return{setRound,endRound,dispose(){clearInterval(timer);set.onclick=null;end.onclick=null}};
};
