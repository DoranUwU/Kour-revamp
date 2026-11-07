import fs from 'node:fs';
import path from 'node:path';
import http from 'node:http';
const root=path.resolve('local/pages-dist'),manifest=JSON.parse(fs.readFileSync(path.join(root,'build-manifest.json'))),base=manifest.basePath;
const types={'.html':'text/html; charset=utf-8','.js':'text/javascript; charset=utf-8','.json':'application/json','.wasm':'application/wasm','.png':'image/png'};
http.createServer((req,res)=>{const pathname=new URL(req.url,'http://localhost').pathname;
 if(!pathname.startsWith(base)){res.writeHead(404).end();return}
 const name=pathname.slice(base.length)||'index.html',file=path.resolve(root,name);
 if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404).end();return}
 res.writeHead(200,{'Content-Type':types[path.extname(file)]||'application/octet-stream'});fs.createReadStream(file).pipe(res);
}).listen(Number(process.env.ORIGINAL_PREVIEW_PORT||8088),'127.0.0.1',()=>console.log('Static Pages test at http://127.0.0.1:'+(process.env.ORIGINAL_PREVIEW_PORT||8088)+base));
