// GitHub Pages cannot set per-file Content-Encoding headers. Decode only our
// two precompressed runtime files; the offline policy still validates callers.
(() => {
 const base=window.BuildBasePath,nativeFetch=window.fetch.bind(window);
 const files=new Map([[base+'source.wasm','application/wasm'],[base+'game.data','application/octet-stream']]);
 window.fetch=async(input,options)=>{
  const url=new URL(typeof input==='string'||input instanceof URL?String(input):input.url,location.href);
  if(url.origin!==location.origin||!files.has(url.pathname)||url.search||!['GET','HEAD'].includes(String(options?.method||input?.method||'GET').toUpperCase()))return nativeFetch(input,options);
  const logical=url.pathname;url.pathname+='.gz';
  const response=await nativeFetch(typeof input==='string'||input instanceof URL?url.href:new Request(url.href,input),options);
  if(!response.ok)return response;
  let bytes=new Uint8Array(await response.arrayBuffer());
  if(bytes[0]===0x1f&&bytes[1]===0x8b){
   if(typeof DecompressionStream==='undefined')throw Error('This browser needs gzip decompression support. Use a current Chrome, Edge, Firefox or Safari.');
   bytes=new Uint8Array(await new Response(new Blob([bytes]).stream().pipeThrough(new DecompressionStream('gzip'))).arrayBuffer());
  }
  const headers=new Headers(response.headers);headers.delete('content-encoding');headers.set('content-type',files.get(logical));headers.set('content-length',String(bytes.length));
  return new Response(bytes,{status:response.status,statusText:response.statusText,headers});
 };
})();
