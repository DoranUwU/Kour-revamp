const encode=value=>{const out=[];do{const b=value&127;value>>>=7;out.push(b|(value?128:0))}while(value);return Buffer.from(out)};
function read(bytes,cursor){let value=0,shift=0,b;do{b=bytes[cursor.p++];value|=(b&127)<<shift;shift+=7;if(shift>35)throw Error('Invalid WASM integer')}while(b&128);return value>>>0}
export function insertRoundHook(source,{photon=false}={}){
 if(photon)return insertPhotonRoundHook(source);
 const imported=WebAssembly.Module.imports(new WebAssembly.Module(source)).filter(x=>x.kind==='function');
 if(imported[166]?.module!=='env'||imported[166]?.name!=='JS_Eval_EvalJS')throw Error('Unexpected round-hook import');
 const cursor={p:8};
 while(cursor.p<source.length){
  const id=source[cursor.p++],sizeOffset=cursor.p,size=read(source,cursor),payloadStart=cursor.p,end=payloadStart+size;
  if(id!==10){cursor.p=end;continue}
  const count=read(source,cursor),wanted=74516-imported.length;
  if(wanted<0||wanted>=count)throw Error('Missing round function');
  for(let i=0;i<count;i++){
   const bodySizeOffset=cursor.p,bodySize=read(source,cursor),bodyStart=cursor.p,bodyEnd=bodyStart+bodySize;
   if(i!==wanted){cursor.p=bodyEnd;continue}
   if(bodyStart!==23703165||bodySize!==422||source.subarray(bodyStart,bodyStart+3).toString('hex')!=='01037f')throw Error('Unexpected round function body');
   const codeStart=bodyStart+3,prefix=Buffer.from('417f10a601','hex');
   const payload=Buffer.concat([source.subarray(payloadStart,bodySizeOffset),encode(bodySize+prefix.length),source.subarray(bodyStart,codeStart),prefix,source.subarray(codeStart,end)]);
   const result=Buffer.concat([source.subarray(0,sizeOffset),encode(payload.length),payload,source.subarray(end)]);
   return{source:result,manifest:{function_index:74516,import_index:166,import_name:'env.JS_Eval_EvalJS',original_code_offset:codeStart,prefix:prefix.toString('hex'),added_bytes:result.length-source.length,original_body_bytes:bodySize,served_body_bytes:bodySize+prefix.length}};
  }
 }
 throw Error('Missing WASM code section');
}


// The Photon profile adds globals, not imports: existing function/table/global
// indices remain stable. A mutable exported gate lets JS await server acks
// before the original StartRound selects its bomb holder and publishes BuyPhase.
function insertPhotonRoundHook(source){
 const module=new WebAssembly.Module(source),imports=WebAssembly.Module.imports(module);
 const importedFunctions=imports.filter(x=>x.kind==='function').length;
 if(imports.filter(x=>x.kind==='function')[166]?.name!=='JS_Eval_EvalJS')throw Error('Unexpected Photon bridge import');
 const importedGlobals=imports.filter(x=>x.kind==='global').length,sections=[],cursor={p:8};
 while(cursor.p<source.length){const start=cursor.p,id=source[cursor.p++],size=read(source,cursor),payloadStart=cursor.p,end=payloadStart+size;sections.push({start,id,payloadStart,end,payload:source.subarray(payloadStart,end)});cursor.p=end}
 const globals=sections.find(x=>x.id===6),exports=sections.find(x=>x.id===7);
 if(!globals||!exports)throw Error('Missing Photon hook sections');
 const gc={p:0},globalCount=read(globals.payload,gc),gate=importedGlobals+globalCount,incoming=gate+1;
 const globalEntries=Buffer.from('7f0141000b7f0141000b','hex');
 const globalPayload=Buffer.concat([encode(globalCount+2),globals.payload.subarray(gc.p),globalEntries]);
 const ec={p:0},exportCount=read(exports.payload,ec);
 const globalExport=(name,index)=>{const n=Buffer.from(name);return Buffer.concat([encode(n.length),n,Buffer.from([3]),encode(index)])};
 const exportPayload=Buffer.concat([encode(exportCount+2),exports.payload.subarray(ec.p),globalExport('kourstrikeRoundGate',gate),globalExport('kourstrikeIncomingState',incoming)]);
 const startPrefix=Buffer.concat([Buffer.from('417f10a60123','hex'),encode(gate),Buffer.from('04400f0b','hex')]);
 const statePrefix=Buffer.concat([Buffer.from('200124','hex'),encode(incoming),Buffer.from('417d10a601','hex')]);
 const targets=new Map([[74516,{body:23703165,code:23703168,size:422,prefix:startPrefix}],[74503,{body:23690420,code:23690427,size:5806,prefix:statePrefix}]]);
 const relocations=[],functionHooks=[];const chunks=[source.subarray(0,8)];
 for(const section of sections){
  let payload=section.payload;
  if(section.id===6)payload=globalPayload;
  if(section.id===7)payload=exportPayload;
  if(section.id===10){
   const c={p:0},count=read(payload,c),parts=[encode(count)];
   for(let i=0;i<count;i++){
    const size=read(payload,c),start=c.p,end=start+size,identity=i+importedFunctions,target=targets.get(identity);
    let body=payload.subarray(start,end);
    if(target){
     const originalBody=section.payloadStart+start;
     if(originalBody!==target.body||size!==target.size)throw Error('Unexpected Photon round function body');
     const locals=target.code-target.body;
     body=Buffer.concat([body.subarray(0,locals),target.prefix,body.subarray(locals)]);
     relocations.push({original_offset:target.code,added_bytes:target.prefix.length});
     functionHooks.push({function_index:identity,original_body_bytes:size,served_body_bytes:body.length,original_code_offset:target.code,prefix:target.prefix.toString('hex')});
    }
    parts.push(encode(body.length),body);c.p=end;
   }
   if(c.p!==payload.length)throw Error('Unexpected Photon code section boundary');
   payload=Buffer.concat(parts);
  }
  const encoded=Buffer.concat([Buffer.from([section.id]),encode(payload.length),payload]);chunks.push(encoded);
  if(section.id!==10&&encoded.length!==section.end-section.start)relocations.push({original_offset:section.end,added_bytes:encoded.length-(section.end-section.start)});
  if(section.id===10){const oldHeader=section.payloadStart-section.start,newHeader=1+encode(payload.length).length;if(newHeader!==oldHeader)relocations.push({original_offset:section.payloadStart,added_bytes:newHeader-oldHeader})}
 }
 const result=Buffer.concat(chunks);
 if(!WebAssembly.validate(result))throw Error('Photon round gate failed WASM validation');
 relocations.sort((a,b)=>a.original_offset-b.original_offset);
 return{source:result,manifest:{profile:'photon',import_index:166,import_name:'env.JS_Eval_EvalJS',added_bytes:result.length-source.length,globals:{kourstrikeRoundGate:gate,kourstrikeIncomingState:incoming},relocations,function_hooks:functionHooks}};
}
