// Static acquisition only, explicitly authorized by the user. Never execute
// remote page/scripts and never enable the original client's service access.
import fs from 'node:fs';
import crypto from 'node:crypto';
const args=process.argv.slice(2),url=args[0]||'https://kourstrike.io/';
const response=await fetch(url,{signal:AbortSignal.timeout(20000)});
if(!response.ok)throw Error(`HTTP ${response.status}: ${url}`);
const bytes=Buffer.from(await response.arrayBuffer());
if(args[1]==='--map'){
 const name=args[2];if(!['map7','map8','map10'].includes(name))throw Error('Select a known KourStrike bundle name');
 if(bytes.subarray(0,8).toString()!=='UnityFS\0')throw Error('Response is not a UnityFS map bundle; refusing to save it as a map.');
 const destination=`original-preview/StreamingAssets/${name}`;
 fs.mkdirSync('original-preview/StreamingAssets',{recursive:true});fs.writeFileSync(destination,bytes);
 const receipt={source:url,destination,bytes:bytes.length,sha256:crypto.createHash('sha256').update(bytes).digest('hex'),retrieved:new Date().toISOString(),purpose:'Static map acquisition; original client remains isolated'};
 fs.writeFileSync(`analysis/runtime/${name}-acquisition.json`,JSON.stringify(receipt,null,2));console.log(JSON.stringify(receipt));
}else{
 const text=bytes.toString('utf8');fs.writeFileSync('analysis/runtime/kourstrike-public-page.html',text);
 const scripts=[...text.matchAll(/(?:src|href)=["']([^"']+)["']/g)].map(m=>new URL(m[1],url).href);
 console.log(JSON.stringify({url:response.url,bytes:bytes.length,links:scripts},null,2));
}
