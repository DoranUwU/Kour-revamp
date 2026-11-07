import crypto from 'node:crypto';
import {insertRoundHook} from './wasm-round-hook.mjs';
const expectedSha256='dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2';
const offset=23683617;
const hash=data=>crypto.createHash('sha256').update(data).digest('hex');
function leb(value){const bytes=[];do{const byte=value&127;value>>>=7;bytes.push(byte|(value?128:0))}while(value);return Buffer.from(bytes)}
export function prepareLocalWasm(original,{kourstrike=false,roundStartHook=true,photon=false}={}){
 if(hash(original)!==expectedSha256)throw Error('Unknown WASM build: refusing a fixed-offset local-preview change.');
 // Validated disassembly: SdkManager.CheckHost -> Application.Quit(MethodInfo*).
 // Consume that one argument without calling Quit; retain identical body size.
 const before=Buffer.concat([Buffer.from([0x10]),leb(72207)]);
 if(!original.subarray(offset,offset+before.length).equals(before))throw Error('Host-check quit instruction differs from verified disassembly.');
 let source=Buffer.from(original);const after=Buffer.alloc(before.length,0x01);after[0]=0x1a;
 after.copy(source,offset);
 // NetworkManager.IsInternetAvailable synchronously calls WebClient.OpenRead.
 // With all original services disabled, report offline instead of blocking the
 // WebGL main thread on that legacy probe. Retain locals, section sizes and all
 // unrelated code. Signature: (i32 this, i32 MethodInfo*) -> i32 bool.
 const networkStart=23891569,networkEnd=23892782;
 const networkBefore=Buffer.from(original.subarray(networkStart,networkEnd));
 if(original[networkEnd-1]!==0x0b)throw Error('Internet probe body does not match the known function boundary.');
 source.fill(0x01,networkStart,networkEnd);
 source.set([0x41,0x00,0x0f],networkStart);source[networkEnd-1]=0x0b;
 const bootstrap=[];
 let roundStartCash=null;
 const halftime=[],photonCallbacks=[],c4Handoff=[];let hook=null;
 if(kourstrike){for(const item of [{method:'NetworkManager.OnDisconnected',offset:23889930,before:'4102',after:'4107',meaning:'Disconnected offline first map2 ->7 (room index8/Kour2)'},{method:'UIManager.GoOfflineEmergency',offset:24448525,before:'4102',after:'4107',meaning:'Offline first map argument2 ->7 (room index8/Kour2)'},{method:'UIManager.LoadForceMap',offset:24435819,before:'4100',after:'4106',meaning:'GameModes array index0 ->6 (Search And Destroy/mode8)'}]){const beforeBytes=Buffer.from(item.before,'hex');if(!original.subarray(item.offset,item.offset+beforeBytes.length).equals(beforeBytes))throw Error('Unknown KourStrike bootstrap instruction');Buffer.from(item.after,'hex').copy(source,item.offset);bootstrap.push(item)}}
 if(kourstrike){
  // Buy-phase entry: replace previous cash + round bonus with the native cap.
  // Keep the existing ObscuredInt constructor, money setter and UI callbacks.
  // The two drops consume the old decode arguments, retaining its output ptr.
  roundStartCash={method:'SearchAndDestroyManager.OnStateChanged',function_index:74503,amount:14000,offset:23693680,before:'10a99c0320056a',after:'1a1a41b0ed0001'};
  const patch=roundStartCash,beforeBytes=Buffer.from(patch.before,'hex');
  if(!original.subarray(patch.offset,patch.offset+beforeBytes.length).equals(beforeBytes))throw Error('Unknown round-start cash instructions.');
  Buffer.from(patch.after,'hex').copy(source,patch.offset);
  for(const patch of [
   {method:'SearchAndDestroyManager.OnStateChanged',offset:23691668,before:'410d',after:'410b',meaning:'First-half warnings move to rounds11 and12'},
   {method:'SearchAndDestroyManager.StartRound',offset:23703301,before:'410e',after:'417f',meaning:'Remove legacy round15 CT C4 assignment; select current T roster'}
  ]){
   if(source.subarray(patch.offset,patch.offset+2).toString('hex')!==patch.before)throw Error('Unknown halftime instructions');
   Buffer.from(patch.after,'hex').copy(source,patch.offset);halftime.push(patch);
  }
  // Reserve the otherwise unused SetBomb(true,true) combination for a passive
  // death handoff. The giveBomb branch skips planting-specific state changes.
  // XOR preserves ordinary grant(1,0), planting(0,1), and clear(0,0) behavior.
  for(const item of [
   {method:'Shooter.SetBomb',offset:23584095,before:'2001200272',after:'2001200273',meaning:'Reserved handoff grant retains equipped weapon'},
   {method:'SearchAndDestroyManager.OnEvent',offset:23706649,before:'200228020841014100410010b2c404',after:'200228020841014101410010b2c404',meaning:'Only C4 handoff event uses SetBomb(true,true)'}
  ]){
   const bytes=Buffer.from(item.before,'hex');if(!original.subarray(item.offset,item.offset+bytes.length).equals(bytes))throw Error('Unknown C4 handoff instructions');
   Buffer.from(item.after,'hex').copy(source,item.offset);c4Handoff.push(item);
  }
  if(photon){
   const autoConnect={method:'NetworkManager.NewConnectUsingSettings',function_index:75044,start:23867347,end:23867494};
   if(original[autoConnect.end-1]!==0x0b)throw Error('Unknown Photon startup boundary');
   autoConnect.before_sha256=hash(original.subarray(autoConnect.start,autoConnect.end));
   source.fill(0x01,autoConnect.start,autoConnect.end);source.set([0x41,0x00,0x0f],autoConnect.start);source[autoConnect.end-1]=0x0b;
   photonCallbacks.push(autoConnect);
   // Keep Photon library dispatch and OnJoinedRoom intact. The custom launcher
   // owns matchmaking and failure UI instead of the original random-room and
   // forced-offline fallbacks. Function locals and body lengths stay unchanged.
   for(const item of [{method:'NetworkManager.OnConnectedToMaster',function_index:75069,start:23883433,end:23885437},{method:'NetworkManager.OnDisconnected',function_index:75076,start:23889488,end:23891564}]){
    if(original[item.end-1]!==0x0b)throw Error('Unknown Photon callback boundary');
    item.before_sha256=hash(original.subarray(item.start,item.end));
    source.fill(0x01,item.start,item.end);source[item.start]=0x0f;source[item.end-1]=0x0b;
    photonCallbacks.push(item);
   }
  }
  if(roundStartHook){const result=insertRoundHook(source,{photon});source=result.source;hook=result.manifest}
 }
 if(!WebAssembly.validate(source))throw Error('Local-preview WASM failed full module validation.');
 const servedOffset=p=>p+(hook?.profile==='photon'?hook.relocations.filter(x=>p>=x.original_offset).reduce((sum,x)=>sum+x.added_bytes,0):(hook&&p>=hook.original_code_offset?hook.added_bytes:0));
 for(const patch of [...bootstrap,...halftime,...c4Handoff])patch.served_offset=servedOffset(patch.offset);
 return{source,manifest:{original_sha256:expectedSha256,served_sha256:hash(source),original_modified:false,method:'SdkManager.CheckHost',function_index:74474,offset,before:before.toString('hex'),after:after.toString('hex'),network_probe:{method:'NetworkManager.IsInternetAvailable',function_index:75077,body_start:23891566,start:networkStart,end:networkEnd,before_sha256:hash(networkBefore),served_start:servedOffset(networkStart),served_end:servedOffset(networkEnd),after_sha256:hash(source.subarray(servedOffset(networkStart),servedOffset(networkEnd))),replacement:'return false in local-only mode'},bootstrap,round_start_cash:roundStartCash,c4_handoff:c4Handoff,halftime,round_start_hook:hook,photon_callbacks:photonCallbacks,scope:photon?'Opt-in user Photon application; original services remain disabled.':'Local compatibility, KourStrike round rules and maximum round-start cash; external services remain disabled.'}};
}
