// Match roster remains available after the local Shooter has been destroyed.
window.createMatchLeaderboard=function(module,{rules,log=console.log}={}){
 const contracts={view:[27903,'25143',2],mine:[27860,'13440',2],chatFocused:[18292,'74771',2],players:[27670,'24946',1],local:[27667,'24943',1],team:[28158,'74087',2],nick:[27398,'2717',2],props:[27405,'7896',2],publish:[27419,'24258',5],clone:[26337,'80828',2],get:[3727,'80818',3],put:[3780,'80819',4],ping:[27720,'24997',1],health:[19878,'75038',3],hp:[15309,'52777',2],alloc:[2105,'95579',2],free:[2577,'95581',2],string:[75048,'91484',2],box:[1036,'2162',2]};
 const table=module.asm.__indirect_function_table;
 function fn(name){const [slot,id,arity]=contracts[name],f=table.get(slot);if(f.name!==id||f.length!==arity)throw Error('Unsupported leaderboard API: '+name);return f}
 const u32=p=>module.HEAPU32[p>>>2],valid=p=>p>1024&&p%4===0&&p+128<module.HEAPU8.length;
 function text(p){if(!valid(p))return'';const n=u32(p+8);return n<=256?String.fromCharCode(...module.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+n)):''}
 const scratch=module.asm.malloc(8),handles=[];
 function retain(p){const handle=fn('alloc')(p,0);if(!handle)throw Error('Cannot retain leaderboard data');handles.push(handle);return p}
 function release(handle){module.HEAPU32[scratch>>>2]=handle;fn('free')(scratch,0)}
 function string(value){const p=fn('string')(value.length,0);for(let i=0;i<value.length;i++)module.HEAPU16[((p+12)>>>1)+i]=value.charCodeAt(i);return retain(p)}
 const keys={ping:string('KR_Ping'),alive:string('KR_Alive'),round:string('KR_Round')};
 const panel=document.createElement('section');panel.id='match-leaderboard';panel.hidden=true;panel.setAttribute('aria-label','Match leaderboard');
 const style=document.createElement('style');style.textContent=`#match-leaderboard[hidden]{display:none}#match-leaderboard{position:fixed;inset:0;z-index:10;background:#07111be8;color:#eef5ff;padding:8vh max(16px,calc((100vw - 920px)/2));box-sizing:border-box;font:16px system-ui,sans-serif;pointer-events:none;overflow:auto}#match-leaderboard h2{font-size:24px;margin:0 0 6px}#match-leaderboard p{color:#9dafbf;margin:0 0 24px}#match-leaderboard h3{font-size:16px;margin:20px 0 8px;color:#82b8ff}#match-leaderboard h3[data-team="2"]{color:#edba75}#match-leaderboard table{border-collapse:collapse;width:100%;table-layout:fixed;background:#132231}#match-leaderboard th,#match-leaderboard td{padding:10px 12px;text-align:right;border-bottom:1px solid #ffffff16}#match-leaderboard th{font-size:12px;color:#afbdcc;text-transform:uppercase}#match-leaderboard th:first-child,#match-leaderboard td:first-child{text-align:left;width:36%;overflow:hidden;text-overflow:ellipsis;white-space:nowrap}#match-leaderboard tr[data-local="true"]{background:#ffffff0c}#match-leaderboard td[data-status="Alive"]{color:#90dca6}#match-leaderboard td[data-status="Dead"]{color:#ef9292}`;
 document.head.append(style);document.body.append(panel);
 let held=false,disposed=false,lastSent=null,lastPublish=0,rows=[],error=null;
 function hide(){held=false;panel.hidden=true}
 function active(){const k=u32(6902276),sf=valid(k)?u32(k+92):0,chat=valid(sf)?u32(sf):0;if(valid(chat)&&fn('chatFocused')(chat,0))return false;return !!rules.native.context()&&!!window.nativeSettingsContext?.()?.map&&!document.body.classList.contains('native-menu-open')}
 function typing(event){return event.target?.matches?.('input,textarea,select,[contenteditable="true"]')}
 function keydown(event){if(event.key!=='Tab'||typing(event)||!active())return;event.preventDefault();event.stopImmediatePropagation();held=true;refresh()}
 function keyup(event){if(event.key!=='Tab'||!held)return;event.preventDefault();event.stopImmediatePropagation();hide()}
 function visibility(){if(document.hidden)hide()}
 document.addEventListener('keydown',keydown,true);document.addEventListener('keyup',keyup,true);window.addEventListener('blur',hide);document.addEventListener('visibilitychange',visibility);
 function localAlive(){
  const k=u32(6908040),sf=valid(k)?u32(k+92):0,net=valid(sf)?u32(sf+56):0;if(!valid(net))return false;
  // A cached or spectated player must not report this client as alive.
  // Require ownership and the native death flags as well as positive HP.
  const health=fn('health')(net,scratch+4,0);if(!valid(health))return false;
  const shooter=u32(health+20),view=valid(shooter)?fn('view')(shooter,0):0;
  return !!view&&!!fn('mine')(view,0)&&!module.HEAPU8[health+128]&&!module.HEAPU8[health+168]&&fn('hp')(health+108,0)>0;
 }
 function publish(ctx,alive){
  if(ctx.offline)return;
  const now=Date.now(),signature=ctx.round+':'+Number(alive)+':'+ctx.room;
  if(signature===lastSent&&now-lastPublish<3000)return;
  const start=handles.length;
  try{
   // Clone the current Hashtable so all unrelated native properties survive.
   const props=retain(fn('clone')(fn('props')(ctx.local,0),0));
   for(const [key,value]of [[keys.ping,Math.max(0,fn('ping')(0))],[keys.alive,Number(alive)],[keys.round,ctx.round]]){
    module.HEAP32[(scratch+4)>>>2]=value;const box=retain(fn('box')(u32(8037700),scratch+4));fn('put')(props,key,box,0);
   }
   if(fn('publish')(ctx.local,props,0,0,0)){lastSent=signature;lastPublish=now}
  }finally{while(handles.length>start)release(handles.pop())}
 }
 function property(player,key){const props=fn('props')(player,0);if(!valid(props))return null;const value=fn('get')(props,key,0);return valid(value)?module.HEAP32[(value+8)>>>2]:null}
 function readRows(ctx,alive){
  const stats=new Map(),klass=u32(6906992),sf=valid(klass)?u32(klass+92):0,manager=valid(sf)?u32(sf+16):0,list=valid(manager)?u32(manager+72):0;
  if(valid(list)){const array=u32(list+8),count=u32(list+12);if(valid(array)&&count<=256&&count<=u32(array+12))for(let i=0;i<count;i++){const data=u32(array+16+i*4);if(valid(data))stats.set(module.HEAP32[(data+36)>>>2],{kills:module.HEAP32[(data+16)>>>2],deaths:module.HEAP32[(data+20)>>>2],score:module.HEAP32[(data+24)>>>2]})}}
  const array=fn('players')(0),result=[];if(!valid(array)||u32(array+12)>256)return result;
  for(let i=0;i<u32(array+12);i++){
   const player=u32(array+16+i*4);if(!valid(player))continue;const actor=module.HEAP32[(player+12)>>>2],team=fn('team')(player,0),code=valid(team)?module.HEAPU8[team+12]:0,local=player===ctx.local;
   const current=property(player,keys.round)===ctx.round,life=local?Number(alive):current?property(player,keys.alive):null;
   result.push({actor,name:text(fn('nick')(player,0))||'Player '+actor,team:code,local,...(stats.get(actor)||{kills:0,deaths:0,score:0}),ping:ctx.offline?null:local?fn('ping')(0):property(player,keys.ping),status:code!==1&&code!==2?'Spectating':life===1?'Alive':life===0?'Dead':'Spawning'});
  }
  return result.sort((a,b)=>b.kills-a.kills||a.deaths-b.deaths||a.actor-b.actor);
 }
 function render(ctx){
  panel.replaceChildren();const title=document.createElement('h2');title.textContent='Leaderboard';panel.append(title);const hint=document.createElement('p');hint.textContent='Round '+ctx.round+' · Hold Tab to view';panel.append(hint);
  for(const [code,label]of [[1,'Counter-Terrorists'],[2,'Terrorists'],[0,'Spectators']]){
   const teamRows=rows.filter(row=>code?row.team===code:![1,2].includes(row.team));if(!teamRows.length)continue;
   const heading=document.createElement('h3');heading.dataset.team=code;heading.textContent=label;panel.append(heading);
   const table=document.createElement('table'),head=table.createTHead().insertRow();for(const label of ['Player','Kills','Deaths','Score','Ping','Status']){const th=document.createElement('th');th.scope='col';th.textContent=label;head.append(th)}
   const body=table.createTBody();for(const row of teamRows){const tr=body.insertRow();tr.dataset.actor=row.actor;tr.dataset.local=row.local;for(const value of [row.name,row.kills,row.deaths,row.score,row.ping===null?'—':row.ping+' ms',row.status])tr.insertCell().textContent=value;tr.lastChild.dataset.status=row.status}panel.append(table);
  }
  panel.hidden=false;
 }
 function refresh(){
  if(disposed)return;const stack=module.asm.stackSave();
  try{const ctx=rules.native.context();if(!ctx){hide();return}const alive=localAlive();publish(ctx,alive);if(!held)return;if(!active()){hide();return}rows=readRows(ctx,alive);render(ctx);error=null}
  catch(e){module.asm.stackRestore(stack);if(error!==String(e)){error=String(e);log('LEADERBOARD',error)}hide()}
 }
 const timer=module.setInterval(refresh,250);
 return{inspect:()=>({visible:!panel.hidden,rows,error}),dispose(){disposed=true;module.clearInterval(timer);hide();document.removeEventListener('keydown',keydown,true);document.removeEventListener('keyup',keyup,true);window.removeEventListener('blur',hide);document.removeEventListener('visibilitychange',visibility);panel.remove();style.remove();while(handles.length)release(handles.pop());module.asm.free(scratch)}};
};
