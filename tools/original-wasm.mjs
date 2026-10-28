import crypto from 'node:crypto';
const expectedSha256='dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2';
const offset=23683617;
const hash=data=>crypto.createHash('sha256').update(data).digest('hex');
function leb(value){const bytes=[];do{const byte=value&127;value>>>=7;bytes.push(byte|(value?128:0))}while(value);return Buffer.from(bytes)}
export function prepareLocalWasm(original,{kourstrike=false}={}){
 if(hash(original)!==expectedSha256)throw Error('Unknown WASM build: refusing a fixed-offset local-preview change.');
 // Validated disassembly: SdkManager.CheckHost -> Application.Quit(MethodInfo*).
 // Consume that one argument without calling Quit; retain identical body size.
 const before=Buffer.concat([Buffer.from([0x10]),leb(72207)]);
 if(!original.subarray(offset,offset+before.length).equals(before))throw Error('Host-check quit instruction differs from verified disassembly.');
 const source=Buffer.from(original),after=Buffer.alloc(before.length,0x01);after[0]=0x1a;
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
 if(kourstrike){for(const item of [{method:'NetworkManager.OnDisconnected',offset:23889930,before:'4102',after:'4107',meaning:'Disconnected offline first map2 ->7 (room index8/Kour2)'},{method:'UIManager.GoOfflineEmergency',offset:24448525,before:'4102',after:'4107',meaning:'Offline first map argument2 ->7 (room index8/Kour2)'},{method:'UIManager.LoadForceMap',offset:24435819,before:'4100',after:'4106',meaning:'GameModes array index0 ->6 (Search And Destroy/mode8)'}]){const beforeBytes=Buffer.from(item.before,'hex');if(!original.subarray(item.offset,item.offset+beforeBytes.length).equals(beforeBytes))throw Error('Unknown KourStrike bootstrap instruction');Buffer.from(item.after,'hex').copy(source,item.offset);bootstrap.push(item)}}
 if(!WebAssembly.validate(source))throw Error('Local-preview WASM failed full module validation.');
 return{source,manifest:{original_sha256:expectedSha256,served_sha256:hash(source),original_modified:false,method:'SdkManager.CheckHost',function_index:74474,offset,before:before.toString('hex'),after:after.toString('hex'),network_probe:{method:'NetworkManager.IsInternetAvailable',function_index:75077,body_start:23891566,start:networkStart,end:networkEnd,before_sha256:hash(networkBefore),after_sha256:hash(source.subarray(networkStart,networkEnd)),replacement:'return false in local-only mode'},bootstrap,scope:'Local hostname/probe compatibility and optional KourStrike offline selection; external services remain disabled.'}};
}
