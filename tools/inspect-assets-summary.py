"""Build concise tables from already recovered asset records; no game execution."""
from pathlib import Path
import json,collections,csv,io,hashlib
ROOT=Path('analysis/assets')
def load(p):return json.loads(p.read_text(encoding='utf8'))
def allrows(folder):return sum([load(p)for p in (ROOT/folder).glob('*.json')],[])
def save(name,obj):(ROOT/name).write_text(json.dumps(obj,indent=2,ensure_ascii=False),encoding='utf8')
def source(row):return {'file':row['file'],'path_id':row['path_id'],'coverage':row['coverage']}
game=load(ROOT/'gameplay-settings.json');index={(x['file'],x['path_id']):x for x in game}
carrier=next(x for x in game if x['script']=='WeaponCarrierData')
weapons=[];names={}
for i,ref in enumerate(carrier['values']['allWeapons']):
 row=index[(carrier['file'],ref['path_id'])];values=row['values'];name=row['game_object']or row['name'];names[i]=name
 fields=['damage','maxAmmo','fireRate','reloadTime','minDistance','maxDistance','groundSpeedMulti','airSpeedMulti','holdToShoot','shootOnRelease','holdToAim','weaponType','instabilityMultiplier','relativeWeaponSize','recoilCrazinessPhysical','recoilCrazinessCrosshair','recoilReturnSpeed','realisticIconPath']
 weapons.append({'index':i,'name':name,'script':row['script'],'source':source(row),**{k:values[k]for k in fields if k in values}})
classes=[]
for i,ref in enumerate(carrier['values']['classes']):
 row=index[(carrier['file'],ref['path_id'])];v=row['values'];classes.append({'index':i,'name':row['name'],'source':source(row),**v,'resolved_weapons':[names.get(n,'none'if n==-1 else 'unknown')for n in v['weaponIndexes']]})
modes=[{'name':x['name'],'source':source(x),**x['values']}for x in game if x['script']=='GameMode']
player=next(x for x in game if x['script']=='PlayerController')
movement={'source':source(player),'values':{k:v for k,v in player['values'].items()if not isinstance(v,(dict,list))},'field_offsets':player['field_offsets']}
config={'provenance':'Serialized prefab/ScriptableObject values decoded with metadata-derived schemas, not measured runtime values. Modifiers and code can change effective behavior. Weapon fireRate units have not been independently confirmed.','weapons':weapons,'classes':classes,'game_modes':modes,'movement':movement}
save('recovered-game-config.json',config)
for name,rows in [('weapons',weapons),('classes',classes),('game-modes',modes)]:
 keys=[]
 for row in rows:
  for k in row:
   if k not in keys and k!='source':keys.append(k)
 output=io.StringIO(newline='');writer=csv.DictWriter(output,fieldnames=keys);writer.writeheader()
 for row in rows:writer.writerow({k:json.dumps(row[k],ensure_ascii=False)if isinstance(row.get(k),(dict,list))else row.get(k)for k in keys})
 (ROOT/(name+'.csv')).write_text(output.getvalue(),encoding='utf8')
textures=allrows('textures');meshes=allrows('meshes');audio=allrows('audio');inventories=allrows('inventory');summary=load(ROOT/'serialized-summary.json')
counts={'all_serialized_files':len(summary),'all_objects':len(inventories),'game_bundle_objects':sum(x['objects']for x in summary if x['path']!='unity default resources'),'game_objects':sum(x['class_id']==1 for x in inventories),'textures':len(textures),'png_textures':sum('png_export'in x for x in textures),'crunch_textures':sum(x['format']in(28,29)for x in textures),'zero_size_textures':sum(x['width']==0 or x['height']==0 for x in textures),'game_textures':sum(len(load(p))for p in (ROOT/'textures').glob('*.json')if p.name!='unity default resources.json'),'meshes':len(meshes),'obj_meshes':sum('obj_export'in x for x in meshes),'triangles':sum(x.get('triangle_count',0)for x in meshes),'game_meshes':sum(len(load(p))for p in (ROOT/'meshes').glob('*.json')if p.name!='unity default resources.json'),'audio_clips':len(audio),'weapon_prefabs':len(weapons),'classes':len(classes),'modes':len(modes),'behaviour_decode':load(ROOT/'behaviour-decode-summary.json')}
save('recovery-counts.json',counts)
# Remove only earlier duplicate generated audio exports, after verifying byte equality.
for row in audio:
 p=ROOT/row['export'];old=p.with_suffix('.bin')
 if p.suffix=='.m4a'and old.exists()and hashlib.sha256(old.read_bytes()).digest()==hashlib.sha256(p.read_bytes()).digest():old.unlink()
rows=['# Asset recovery','', 'All work is static; no supplied game code or network service was executed.','', '## Scope and results','', '| Item | Recovered |','|---|---:|']
for k,v in counts.items():
 if isinstance(v,int):rows.append(f'| {k.replace("_"," ")} | {v:,} |')
rows+=['','The UnityFS bundle reports **Unity 6000.2.7f2**. Seven serialized files were read: six from `data.unity3d` and the separately supplied `Resources/unity default resources` (whose embedded engine revision is 6000.2.0b3). All use serialized-file format 22 and have stripped type trees. The bundle contributes 283 textures and 111 meshes; built-in defaults add 37 textures and 13 meshes.','', '## What is usable','', '- `textures/*.png`: 190 decoded image files, vertically flipped to ordinary image orientation. Raw texture payloads are preserved as `.bin` alongside the images.','- 127 DXT1/DXT5 Crunch payloads are retained raw; a Crunch decoder was unavailable. Three 0×0 texture placeholders have no image to export.','- `audio/*.m4a`: all 114 original ISO BMFF/AAC payload slices, with audio names, channels, sample rates and durations in the audio JSON inventories.','- `meshes/*.obj`: all 124 meshes, with positions, triangles and normals/UVs where present. Mesh compression was decoded for the packed meshes. Skinning, animation tracks and material assignments are not exported to OBJ.','- `scene-objects/*.json`: all 5,562 GameObject names, component references and hierarchy paths. `hierarchy/*.json` also preserves local transforms.','- `decoded-behaviours/*.json`: 3,943 of 4,049 complete serialized MonoBehaviour objects decoded using recovered field schemas. Remaining 106 objects are explicitly partial.','- `gameplay-settings.json`: 1,044 Assembly-CSharp objects, 1,043 with complete object consumption. The sole incomplete gameplay object is SimpleTooltipStyle (UI styling), not a weapon/controller.','- `recovered-game-config.json`, `weapons.csv`, `classes.csv`, `game-modes.csv`: compact, indexed tables for the 39 weapon-family prefabs, 13 character classes, 11 modes and player movement settings. Weapon indices are resolved using the serialized WeaponCarrierData.allWeapons array.','', '## Selected original settings','', 'PlayerController (`resources.assets`, pathID 7063): groundAcceleration 600, airAcceleration 100, airFriction 50, groundLimit 15, crouchGroundLimit 9, airLimit ≈0.9, gravity 21, friction 20, jumpHeight ≈7.8, additiveJump and autoJump true. `landedBrTime` is serialized negative infinity and represented as the string `-Infinity`. These are field values, not a claim that jumpHeight is a distance in metres.','', '| Index | Weapon | Script | Damage field | Ammo | Fire-rate field | Reload field |','|---:|---|---|---:|---:|---:|---:|']
for row in weapons:
 def fmt(k):
  v=row.get(k,'');return f'{v:.5g}'if isinstance(v,float)else str(v)
 rows.append(f"| {row['index']} | {row['name']} | {row['script']} | {fmt('damage')} | {fmt('maxAmmo')} | {fmt('fireRate')} | {fmt('reloadTime')} |")
rows+=['','Damage fields on shotguns and special weapons can have different code interpretation; do not treat them as measured damage per hit. Negative ammo values occur for melee/throwable assets. Runtime upgrades and modifiers may change these values.','', '## Scene boundary','', 'Only `level0` is present as a serialized scene. Its roots include MainManager, KourConsole, LobbyRenderCamera, Main Camera, EventSystem, WebRequestHelper, LobbyPlayer, PPV, Canvas(UWI), Canvas and Directional Light. This is consistent with the lobby/start scene. No claim is made that absent remote maps can be rebuilt from their names or metadata.','', '## Validation and limits','', 'All 320 Texture2D records and all 114 AudioClip records consumed their exact object lengths. The mesh reader consumed 123 of 124 exact object lengths; `glock19` (`sharedassets0.assets`, pathID 446) has 12 uninterpreted trailing bytes after the known mesh structure. Its vertex/index geometry exports with valid indices. Packed geometry output was checked against vertex and submesh counts. Byte provenance (file, pathID, offset, size) is retained for every object.','', 'The original serialized bytes and hashes are retained in the unpacked bundle files. Stripped type trees were replaced by schemas reconstructed from matching IL2CPP metadata/WASM. Complete object consumption increases confidence but is not a Unity-editor reimport or runtime behavior proof. Field offsets in decoded behavior JSON are offsets in the serialized object; IL2CPP runtime offsets are not used as asset offsets.','', 'AnimationClip objects, shaders, fonts, sprite rectangles, skinning, material/shader parameter graphs and engine settings are inventoried but not fully reconstructed into an editable Unity project. Some UI/postprocessing behaviors use unsupported custom serializers and remain partial. No server implementation is recoverable from these client asset payloads.','', '## Reproduce','', '```powershell','python tools/inspect-assets.py','python tools/inspect-assets-behaviours.py','python tools/inspect-assets-summary.py','```','', 'The behavior pass requires `analysis/metadata/all-types.json`. All three scripts use only Python standard-library modules; the attempted UnityPy acquisition was blocked, and no third-party parser was installed.']
(ROOT/'REPORT.md').write_text('\n'.join(rows)+'\n',encoding='utf8')
print(json.dumps(counts,indent=2))
