// Adapter for the hash-guarded native PUN build; uses its existing replication.
window.createPhotonClient=function(module,{log=console.log,onStatus=()=>{}}={}){
 const table=module.asm.__indirect_function_table;
 const contracts={settings:[27652,'24872',1],offline:[27672,'24948',1],setOffline:[27673,'24949',2],disconnect:[27715,'24993',1],connect:[27711,'24988',3],state:[27661,'24939',1],connected:[27659,'24933',1],inRoom:[27689,'24964',1],room:[27666,'24867',1],players:[27670,'24946',1],region:[27655,'24932',1],ping:[27720,'24997',1],nick:[27669,'24945',2],auth:[27664,'24941',2],string:[75048,'91484',2],roomOptions:[19898,'75052',5],create:[27729,'25007',5],put:[3780,'80819',4],box:[1036,'2162',2]};
 const u32=p=>module.HEAPU32[p>>>2],valid=p=>Number.isInteger(p)&&p>=1024&&p+128<module.HEAPU8.length;
 function fn(name){const [slot,identity,arity]=contracts[name],f=table.get(slot);if(f.name!==identity||f.length!==arity)throw Error('Unsupported native Photon API: '+name);return f}
 function string(value){const p=fn('string')(value.length,0);for(let i=0;i<value.length;i++)module.HEAPU16[((p+12)>>>1)+i]=value.charCodeAt(i);return p}
 function text(p){if(!valid(p))return'';const n=u32(p+8);return n<=256?String.fromCharCode(...module.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+n)):''}
 function network(){const klass=u32(6908040),statics=valid(klass)?u32(klass+92):0,p=valid(statics)?u32(statics+56):0;if(!valid(p))throw Error('The game is still initializing.');return p}
 function box(value){const out=module.asm.malloc(4);try{module.HEAP32[out>>>2]=value;return fn('box')(u32(8037700),out)}finally{module.asm.free(out)}}
 let busy=false,lastStatus='',lastState=-1,online=false;
 function inspect(){const state=fn('state')(0),room=fn('room')(0),players=fn('players')(0);return{state,connected:!!fn('connected')(0),offline:!!fn('offline')(0),inRoom:!!fn('inRoom')(0),players:valid(players)?u32(players+12):0,region:text(fn('region')(0)),ping:fn('connected')(0)?fn('ping')(0):null,room:valid(room)?text(u32(room+36)):'',online,busy}}
 function status(message){lastStatus=message;onStatus(message);log('PHOTON',message)}
 async function wait(predicate,label,timeout=20000){const start=performance.now();while(!predicate()){const state=fn('state')(0);if(label==='Photon connection'&&state===14){const klass=u32(6908632),statics=u32(klass+92),client=u32(statics+4),cause=module.HEAP32[(client+120)>>>2];throw Error('Photon disconnected (cause '+cause+'). Check the App ID, region and network connection.')}if(performance.now()-start>timeout)throw Error(label+' timed out (connection state '+state+').');await new Promise(resolve=>setTimeout(resolve,100))}}
 async function connect({appId,nickname='Player',region='asia'}){
  if(!/^[0-9a-f]{8}(?:-[0-9a-f]{4}){3}-[0-9a-f]{12}$/i.test(appId))throw Error('Enter your Photon Realtime App ID.');
  if(!['asia','hk'].includes(region))throw Error('Choose Singapore or Hong Kong.');
  if(fn('inRoom')(0)&&!fn('offline')(0))throw Error('Already in an online room. Reload before changing rooms.');
  if(fn('inRoom')(0))throw Error('Reload the page before switching from an offline match to online.');
  window.OfflinePolicy.enablePhoton(appId);
  if(fn('offline')(0))fn('setOffline')(0,0);
  if(fn('connected')(0)){fn('disconnect')(0);await wait(()=>[0,14].includes(fn('state')(0)),'Disconnect');}
  const settings=fn('settings')(0),app=u32(settings+12);
  if(!valid(app))throw Error('Native Photon settings are unavailable.');
  module.HEAPU32[(app+8)>>>2]=string(appId);
  module.HEAPU32[(app+24)>>>2]=string('kour-revamp-1');
  module.HEAPU32[(app+32)>>>2]=string(region);
  module.HEAPU32[(app+40)>>>2]=0;module.HEAPU16[(app+44)>>>1]=0;
  module.HEAPU8[app+28]=1;module.HEAPU8[app+52]=5;module.HEAPU8[app+53]=0;module.HEAPU8[settings+26]=0;
  module.HEAPU32[(settings+16)>>>2]=string(region);
  if(window.PhotonDebug){module.HEAPU8[app+61]=5;module.HEAP32[(settings+20)>>>2]=2;module.HEAPU8[settings+24]=1;}
  fn('auth')(0,0);fn('nick')(string(nickname.trim().slice(0,24)||'Player'),0);
  online=true;status('Connecting to '+(region==='asia'?'Singapore':'Hong Kong')+'…');
  if(!fn('connect')(app,0,0))throw Error('Photon rejected the connection attempt.');
  await wait(()=>fn('state')(0)===15,'Photon connection');status('Connected.');
 }
 async function enter(options,create){
  if(busy)throw Error('A connection is already in progress.');busy=true;
  try{
   const name=String(options.room||'').trim().toUpperCase();if(!/^[A-Z0-9-]{4,32}$/.test(name))throw Error('Use a room code with 4–32 letters, digits or hyphens.');
   await connect(options);module.SendMessage('Canvas','ForceSetGameMode','Search And Destroy');
   const net=network();
   if(create){
    const root=module.asm.malloc(4),alloc=table.get(2105),release=table.get(2577);let held=false;
    if(alloc.name!=='95579'||release.name!=='95581')throw Error('Unsupported managed object lifetime API.');
    try{
     const opts=fn('roomOptions')(net,1,0,8,0);module.HEAPU32[root>>>2]=alloc(opts,0);held=true;
     const props=u32(opts+28);
     for(const [key,value]of [[7010548,8],[7010556,8],[7010564,600]])fn('put')(props,u32(key),box(value),0);
     if(!fn('create')(string(name),opts,0,0,0))throw Error('Could not send the create-room request.');
    }finally{if(held)release(root,0);module.asm.free(root)}
   }else{
    const join=table.get(27731);if(join.name!=='25009')throw Error('Unsupported native join-room API.');
    if(!join(string(name),0,0))throw Error('Could not send the join-room request.');
   }
   status((create?'Creating ':'Joining ')+name+'…');
   await wait(()=>fn('inRoom')(0)&&!fn('offline')(0),'Room entry');status('Room '+name+' joined. Loading Kour2…');
   return inspect();
  }catch(error){status(error.message);throw error}finally{busy=false}
 }
 const timer=setInterval(()=>{try{const s=inspect();if(online&&s.state!==lastState){lastState=s.state;log('PHOTON state',s.state)}if(online&&s.inRoom)onStatus('Online · '+s.region+' · '+s.players+' player'+(s.players===1?'':'s')+' · '+s.ping+' ms')}catch{}},500);
 return{create:options=>enter(options,true),join:options=>enter(options,false),inspect,dispose(){clearInterval(timer)},native:{fn,string,text,network,u32},get status(){return lastStatus}};
};
