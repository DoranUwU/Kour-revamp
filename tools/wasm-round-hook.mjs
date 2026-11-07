const encode=value=>{const out=[];do{const b=value&127;value>>>=7;out.push(b|(value?128:0))}while(value);return Buffer.from(out)};
function read(bytes,cursor){let value=0,shift=0,b;do{b=bytes[cursor.p++];value|=(b&127)<<shift;shift+=7;if(shift>35)throw Error('Invalid WASM integer')}while(b&128);return value>>>0}
export function insertRoundHook(source){
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
