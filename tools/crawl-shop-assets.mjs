import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
const catalog=JSON.parse(fs.readFileSync('tools/shop-catalog.json'));
const images=JSON.parse(fs.readFileSync('tools/menu-images.json')),bundles=JSON.parse(fs.readFileSync('tools/menu-bundles.json'));
const targets=new Map();
function add(kind,name){if(name&&!targets.has(kind+name))targets.set(kind+name,{kind,name})}
for(const item of catalog){const v=item.values;add('image',v.iconPath);if(item.type==='Hat'){add('bundle',v.meshPath);add('image',v.texturePath)}if(item.type==='CharacterSkin'){for(const part of ['head','body','body-attachments'])add('image','characters/textures/'+part+'/'+v.skinIndex);for(const part of ['head','body-attachments'])add('bundle','characters/meshes/'+part+'/'+v.skinIndex)}}
const results=[],queue=[...targets.values()];let done=0;
async function worker(){while(queue.length){const target=queue.shift(),{kind,name}=target,pathname=kind==='image'?'/content/stream/'+name+'.png':'/StreamingAssets/'+name,file='original-preview'+pathname;let entry=(kind==='image'?images:bundles).find(a=>kind==='image'?a.pathname===pathname:a.name===name);if(entry&&fs.existsSync(file)){results.push({...target,status:'retained'});continue}
 const url=(kind==='image'?'https://kour.io':'https://kourstrike.io')+pathname;
 try{const response=await fetch(url,{signal:AbortSignal.timeout(25000)});if(!response.ok){results.push({...target,status:'missing',http:response.status});continue}const bytes=Buffer.from(await response.arrayBuffer());if(kind==='image'?bytes.subarray(0,8).toString('hex')!=='89504e470d0a1a0a':bytes.subarray(0,8).toString()!=='UnityFS\0')throw Error('Unexpected asset format');fs.mkdirSync(path.dirname(file),{recursive:true});fs.writeFileSync(file,bytes);entry={...(kind==='image'?{pathname,file}:{name,source:url}),bytes:bytes.length,sha256:crypto.createHash('sha256').update(bytes).digest('hex')};(kind==='image'?images:bundles).push(entry);results.push({...target,status:'downloaded',bytes:bytes.length})}catch(error){results.push({...target,status:'error',error:String(error)})}finally{if(++done%50===0)console.log('Processed',done,'remaining',queue.length)}
}}
await Promise.all(Array.from({length:6},worker));
fs.writeFileSync('tools/menu-images.json',JSON.stringify(images,null,2)+'\n');fs.writeFileSync('tools/menu-bundles.json',JSON.stringify(bundles,null,2)+'\n');
const summary=results.reduce((r,i)=>(r[i.status]=(r[i.status]||0)+1,r),{});fs.writeFileSync('tools/shop-asset-report.json',JSON.stringify({catalogItems:catalog.length,summary,results},null,2)+'\n');console.log(JSON.stringify(summary));
