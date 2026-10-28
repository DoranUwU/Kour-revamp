import fs from 'node:fs';
import crypto from 'node:crypto';
import {spawnSync} from 'node:child_process';
const hash=b=>crypto.createHash('sha256').update(b).digest('hex');
export function prepareKourStrikeData(){
 const output='original-preview/generated/kourstrike.data',manifestPath='original-preview/generated/kourstrike-data.json';
 let manifest;try{manifest=JSON.parse(fs.readFileSync(manifestPath))}catch{}
 const sourceHash=hash(fs.readFileSync('game.data')),builderHash=hash(fs.readFileSync('tools/build-kourstrike-data.py'));
 if(!manifest||manifest.input_sha256!==sourceHash||manifest.builder_sha256!==builderHash||!fs.existsSync(output)){
  const result=spawnSync('python',['tools/build-kourstrike-data.py'],{windowsHide:true,encoding:'utf8'});
  if(result.status!==0)throw Error('KourStrike startup archive preparation failed: '+result.stderr);
  manifest=JSON.parse(fs.readFileSync(manifestPath));
 }
 const source=fs.readFileSync(output);if(hash(source)!==manifest.output_sha256)throw Error('Derived startup archive identity mismatch');
 return{source,manifest};
}
