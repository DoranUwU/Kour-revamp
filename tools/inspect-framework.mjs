import fs from 'node:fs';
import {createRequire} from 'node:module';
import crypto from 'node:crypto';
const require=createRequire(import.meta.url);
const parserPath=process.argv[2]||'C:/Users/Admin/AppData/Local/npm-cache/_npx/da7caeae9db9c589/node_modules/@babel/parser';
const parser=require(parserPath),text=fs.readFileSync('framework.js','utf8');
const ast=parser.parse(text,{sourceType:'unambiguous',ranges:true});
const funcs=[],strings=[],calls=[];
function calleeName(n){if(!n)return'';if(n.type==='Identifier')return n.name;if(n.type==='MemberExpression')return calleeName(n.object)+'.'+(n.property.name||n.property.value||'[dynamic]');return n.type}
const stack=[{node:ast,owner:null,parent:null}];
while(stack.length){let{node,owner,parent}=stack.pop();if(!node||typeof node!=='object')continue;
 if(['FunctionDeclaration','FunctionExpression','ArrowFunctionExpression'].includes(node.type)){
 const name=node.id?.name||(parent?.type==='VariableDeclarator'?parent.id.name:parent?.type==='AssignmentExpression'?calleeName(parent.left):parent?.type==='ObjectProperty'?parent.key.name||parent.key.value:null)||`anonymous@${node.start}`;
 const f={name,start:node.start,end:node.end,parameters:node.params.map(n=>text.slice(n.start,n.end)),calls:[]};funcs.push(f);owner=f;
 }
 if(node.type==='StringLiteral')strings.push({value:node.value,offset:node.start,owner:owner?.name||null});
 if(node.type==='CallExpression'||node.type==='NewExpression'){const c={callee:calleeName(node.callee),offset:node.start,end:node.end,owner:owner?.name||null};calls.push(c);owner?.calls.push(c.callee)}
 for(const [key,value]of Object.entries(node)){if(['loc','range','extra','tokens','comments'].includes(key))continue;if(Array.isArray(value))for(let i=value.length-1;i>=0;i--)if(value[i]?.type)stack.push({node:value[i],owner,parent:node});else{}else if(value&&typeof value==='object'&&value.type)stack.push({node:value,owner,parent:node})}
}
funcs.sort((a,b)=>a.start-b.start);
const network=calls.filter(c=>/fetch|WebSocket|XMLHttpRequest|sendBeacon|\.open$|\.send$/.test(c.callee));
const bridges=funcs.filter(f=>/^_(?!emscripten|gl|al|alc|SDL|JS_|dl|pthread|fd_|clock|environ|wasi|abort|exit|time|tz|localtime|mktime|strftime|get|set|malloc|free|mem|str|sys|stack|net|socket|select|listen|bind|accept|poll|ioctl|dup|close|fstat|lstat|stat|fcntl|read|write|fopen|fclose|fread|fwrite|fseek|ftell|unlink|mkdir|rmdir|rename|access|chmod|opendir|readdir|closedir|chdir|getcwd|fileno|fflush|feof|ferror|clearerr|ungetc|puts|printf|putchar|scanf|__)/.test(f.name));
fs.mkdirSync('analysis/framework',{recursive:true});
fs.writeFileSync('analysis/framework/inventory.json',JSON.stringify({artifact:'framework.js',sha256:crypto.createHash('sha256').update(text).digest('hex'),parser:parserPath,parse_errors:ast.errors||[],function_count:funcs.length,functions:funcs,network_calls:network,strings},null,2));
fs.writeFileSync('analysis/framework/game-bridges.js',bridges.map(f=>`// Source framework.js UTF-16 offsets ${f.start}..${f.end}\n${text.slice(f.start,f.end)}`).join('\n\n'));
const ts=require('C:/Users/Admin/AppData/Roaming/npm/node_modules/typescript');
const source=ts.createSourceFile('framework.js',text,ts.ScriptTarget.Latest,true,ts.ScriptKind.JS);
fs.writeFileSync('analysis/framework/framework.readable.js',ts.createPrinter().printFile(source));
console.log(JSON.stringify({functions:funcs.length,strings:strings.length,network_calls:network.length,bridge_candidates:bridges.map(f=>f.name),output:'analysis/framework'}));
