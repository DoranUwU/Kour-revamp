import fs from 'node:fs';
import assert from 'node:assert/strict';
import {prepareLocalWasm} from './original-wasm.mjs';
import {economyRules,economyPatches} from './kourstrike-economy.mjs';
const original=fs.readFileSync('source.wasm'),built=prepareLocalWasm(original,{kourstrike:true,roundStartHook:false});
for(const patch of economyPatches){assert.equal(original.subarray(patch.offset,patch.offset+patch.before.length/2).toString('hex'),patch.before);assert.equal(built.source.subarray(patch.offset,patch.offset+patch.after.length/2).toString('hex'),patch.after)}
assert.deepEqual(economyRules,{startingCredits:800,walletCap:14000,win:3000,lossBase:1500,lossStep:500,maxLossStreak:3});
const leb=value=>{const out=[];do{const b=value&127;value>>>=7;out.push(b|(value?128:0))}while(value);return Buffer.from(out)},section=(id,bytes)=>Buffer.concat([Buffer.from([id]),leb(bytes.length),bytes]);
let selector=Buffer.from(economyPatches[1].after,'hex');
// Rebind only the native player/team/string helpers to controlled imports.
for(const [from,to]of [['10efc201','10000101'],['10e7c204','10010101'],['10a4c905','10020101']]){const offset=selector.indexOf(Buffer.from(from,'hex'));assert.ok(offset>=0);Buffer.from(to,'hex').copy(selector,offset)}
const name=text=>Buffer.concat([leb(text.length),Buffer.from(text)]),imp=(text,type)=>Buffer.concat([name('env'),name(text),Buffer.from([0]),leb(type)]);
const imports=Buffer.concat([leb(4),imp('player',0),imp('team',1),imp('equals',2),name('env'),name('memory'),Buffer.from([2,0,1])]);
const types=Buffer.from('0460017f017f60027f7f017f60037f7f7f017f60057f7f7f7f7f017f','hex');
const body=Buffer.concat([Buffer.from('01037f','hex'),selector,Buffer.from('20002005','hex'),Buffer.from(economyPatches[2].after,'hex'),Buffer.from('20050b','hex')]);
const bytes=Buffer.concat([Buffer.from('0061736d01000000','hex'),section(1,types),section(2,imports),section(3,Buffer.from([1,3])),section(7,Buffer.concat([leb(1),name('reward'),Buffer.from([0,3])])),section(10,Buffer.concat([leb(1),leb(body.length),body]))]);
const memory=new WebAssembly.Memory({initial:1}),heap=new Int32Array(memory.buffer);heap[(2048+8)/4]=3000;
const reward=new WebAssembly.Instance(new WebAssembly.Module(bytes),{env:{memory,player:()=>2000,team:()=>2048,equals:(a,b)=>Number(a===b)}}).exports.reward;
const lose=()=>reward(1024,0,0,0,3004),win=()=>reward(1024,0,0,0,3000),streak=()=>heap[(1024+160)/4];
assert.deepEqual([lose(),lose(),lose(),lose()],[2000,2500,3000,3000]);assert.equal(streak(),3);
assert.equal(win(),3000);assert.equal(streak(),0);assert.equal(lose(),2000);assert.equal(streak(),1);
for(let i=0;i<20;i++)lose();assert.equal(streak(),3);assert.equal(lose(),3000);
for(const photon of [false,true]){const p=prepareLocalWasm(original,{kourstrike:true,photon});for(const patch of p.manifest.economy.patches)assert.equal(p.source.subarray(patch.served_offset,patch.served_offset+patch.after.length/2).toString('hex'),patch.after)}
console.log('Native economy verified: 3000 win, 2000/2500/3000 losses, cap, reset, retained streak storage and offline/Photon instruction identities.');
