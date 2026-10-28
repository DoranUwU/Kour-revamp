import fs from 'node:fs';
import zlib from 'node:zlib';
import path from 'node:path';
const input=process.argv[2]||(fs.existsSync('game.data.br')?'game.data.br':'4670521ebea37069a00f84b72abc0894.data.br');
const bytes=zlib.brotliDecompressSync(fs.readFileSync(input));
if(!bytes.subarray(0,16).equals(Buffer.from('UnityWebData1.0\0')))throw Error('Not Unity Web Data');
const end=bytes.readUInt32LE(16),rows=[];
if(end<20||end>bytes.length)throw Error('Invalid archive table boundary');
fs.mkdirSync('analysis/extracted',{recursive:true});
for(let i=20;i<end;){if(i+12>end)throw Error('Truncated archive entry');const offset=bytes.readUInt32LE(i),size=bytes.readUInt32LE(i+4),length=bytes.readUInt32LE(i+8);i+=12;if(i+length>end)throw Error('Truncated member name');const name=bytes.subarray(i,i+length).toString();i+=length;
const root=path.resolve('analysis/extracted'),target=path.resolve(root,name);
if(!target.startsWith(root+path.sep)||offset<end||offset+size>bytes.length)throw Error('Invalid archive member');
fs.mkdirSync(path.dirname(target),{recursive:true});fs.writeFileSync(target,bytes.subarray(offset,offset+size));rows.push({name,offset,size});}
const metadataMember=rows.find(r=>r.name==='Il2CppData/Metadata/global-metadata.dat');
if(metadataMember)fs.writeFileSync('analysis/global-metadata.dat',bytes.subarray(metadataMember.offset,metadataMember.offset+metadataMember.size));
fs.writeFileSync('analysis/data-inventory.json',JSON.stringify(rows,null,2));console.log(`Extracted ${rows.length} files (${bytes.length} decompressed bytes).`);
