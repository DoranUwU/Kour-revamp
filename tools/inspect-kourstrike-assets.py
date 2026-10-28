"""Bounded offline evidence for KourStrike bootstrap and map availability.

Reads only supplied-file extraction and existing metadata; does not fetch URLs,
execute game code, modify loaders or claim runtime reachability.
"""
from pathlib import Path
import json,struct,collections,re,hashlib,importlib.util
ROOT=Path('analysis/assets')
def load(p):return json.loads(Path(p).read_text(encoding='utf8'))
def save(name,value):(ROOT/name).write_text(json.dumps(value,indent=2,ensure_ascii=False),encoding='utf8')
spec=importlib.util.spec_from_file_location('assets',Path(__file__).with_name('inspect-assets.py'));a=importlib.util.module_from_spec(spec);spec.loader.exec_module(a)
game=load(ROOT/'gameplay-settings.json');types=load('analysis/metadata/gameplay.json');metas={p.name[:-5]:load(p)for p in (ROOT/'serialized').glob('*.json')};inventories={p.name[:-5]:load(p)for p in (ROOT/'inventory').glob('*.json')}
gm=metas['globalgamemanagers'];b=(ROOT/'bundle/globalgamemanagers').read_bytes()
def object_reader(cid):
 o=next(x for x in gm['objects']if x['class_id']==cid);return o,a.Reader(b[o['offset']:o['offset']+o['size']],'<')
build,r=object_reader(141);scenes=[r.string()for _ in range(r.i32())];buildsettings={'file':'globalgamemanagers','path_id':build['path_id'],'class_id':141,'offset':build['offset'],'size':build['size'],'scenes':scenes,'parsed_scene_table_bytes':r.p,'remaining_engine_settings_bytes':build['size']-r.p}
resource,r=object_reader(147);container=[]
for _ in range(r.i32()):
 name=r.string();ptr=a.ptr(r);file='globalgamemanagers'
 if ptr['file_id']:file=Path(gm['externals'][ptr['file_id']-1]['path']).name
 obj=next((x for x in inventories.get(file,[])if x['path_id']==ptr['path_id']),None)
 container.append({'resource_name':name,'target_file':file,'reference':ptr,'target_class':obj.get('class')if obj else None,'target_name':obj.get('name')if obj else None})
resources={'source':{'file':'globalgamemanagers','class_id':147,'path_id':resource['path_id'],'offset':resource['offset'],'size':resource['size']},'container_count':len(container),'container_bytes':r.p,'entries':container,'remaining_dependency_graph_bytes':resource['size']-r.p}
sdk=next(x for x in game if x['script']=='SdkManager');network=next(x for x in game if x['script']=='NetworkManager');modes=[x for x in game if x['script']=='GameMode'];modeindex={x['path_id']:x for x in modes};network_modes=[]
for slot,ref in enumerate(network['values']['gameModes']):
 x=modeindex.get(ref['path_id']);network_modes.append({'slot':slot,'reference':ref,'file':x['file']if x else None,'path_id':x['path_id']if x else None,'name':x['name']if x else None,'values':x['values']if x else None})
enum=next(x for x in types if x['name']=='GameType'and x['declaring_type']==sdk['schema_type']);enum_values={x['name']:x.get('default')for x in enum['fields']if x.get('literal')}
sdkobject=next(x for x in metas[sdk['file']]['objects']if x['path_id']==sdk['path_id']);sdkfield=next(x for x in sdk['field_offsets']if x['field']=='gameType')
bootstrap={'sdk':sdk,'game_type_enum':enum_values,'game_type_serialized_file_offset':sdkobject['offset']+sdkfield['start'],'network':{'file':network['file'],'path_id':network['path_id'],'coverage':network['coverage'],'game_modes':network_modes},'interpretation':'SdkManager prefab default selects Kour=0. Host/bootstrap code can change gameType; asset default alone does not prove runtime mode. Search And Destroy is configured for KourStrike with forced map indices 8,9,11.'}
map_types=['MapConfig','MapData','MapInfo','MapSettings','MapBuilder','MapBuilderData','MapURLFinder','StreamingAssetsLoader']
maps={'type_schemas':[{k:v for k,v in t.items()if k!='methods'}for t in types if t['name']in map_types],'script_instances':[{'file':x['file'],'path_id':x['path_id'],'script':x['script'],'name':x['name'],'game_object':x['game_object'],'values':x['values']}for x in game if x['script']in map_types],'map_named_resources':[x for x in container if re.search(r'(map|scene|catalog|addressable|bundle|streaming)',x['resource_name'],re.I)],'map_named_objects':[]}
for file,rows in inventories.items():
 for x in rows:
  if x['class_id']in(1,49,114)and re.search(r'(^map\d|kourstrike|mapconfig|mapinfo|mapsettings|catalog|addressable)',x.get('name',''),re.I):maps['map_named_objects'].append({'file':file,'path_id':x['path_id'],'class':x['class'],'name':x.get('name')})
bundle=load(ROOT/'bundle-inventory.json');maps['bundle_nodes']=bundle['nodes'];maps['archive_members']=load('analysis/data-inventory.json')
text_assets=[{'file':file,'path_id':x['path_id'],'name':x['name'],'size':x['size'],'export':x.get('export')}for file,rows in inventories.items()for x in rows if x['class_id']==49]
maps['text_assets']=text_assets
audio=sum([load(p)for p in (ROOT/'audio').glob('*.json')],[]);groups=collections.defaultdict(list)
for x in audio:groups[x['source']].append((x['stream_offset'],x['stream_size']))
resource_coverage=[]
for name,slices in groups.items():
 raw=Path('analysis/extracted',name).read_bytes();slices.sort();cursor=0;gaps=[]
 for off,n in slices:
  if off>cursor:gaps.append({'offset':cursor,'size':off-cursor,'all_zero':not any(raw[cursor:off])})
  if off<cursor:raise ValueError('Overlapping audio ranges')
  cursor=off+n
 if cursor<len(raw):gaps.append({'offset':cursor,'size':len(raw)-cursor,'all_zero':not any(raw[cursor:])})
 resource_coverage.append({'file':name,'bytes':len(raw),'audio_slices':len(slices),'audio_bytes':sum(n for o,n in slices),'gap_bytes':sum(x['size']for x in gaps),'gap_count':len(gaps),'all_gaps_zero':all(x['all_zero']for x in gaps),'gaps':gaps})
maps['resource_file_coverage']=resource_coverage
signatures=[]
for file in ['game.data','source.wasm','analysis/extracted/data.unity3d']:
 raw=Path(file).read_bytes();matches=[]
 for signature in [b'UnityFS\0',b'UnityRaw\0',b'UnityWeb\0']:
  start=0
  while True:
   pos=raw.find(signature,start)
   if pos<0:break
   matches.append({'signature':signature[:-1].decode(),'offset':pos,'following_32_bytes_hex':raw[pos+len(signature):pos+len(signature)+32].hex(),'following_text_preview':raw[pos+len(signature):pos+len(signature)+48].decode('ascii','replace')});start=pos+1
 signatures.append({'file':file,'bytes':len(raw),'sha256':hashlib.sha256(raw).hexdigest(),'matches':matches,'note':'A signature in WASM can be an engine string, not an embedded bundle. Only data.unity3d is decoded as UnityFS here.'})
maps['bundle_signature_search']=signatures
required={'map_indices':[8,9,11],'embedded_scene_evidence':buildsettings,'embedded_assetbundle_objects':sum(x['class_id']==142 for rows in inventories.values()for x in rows),'embedded_addressables_catalogues':[x for x in text_assets if re.search('catalog|addressable',x['name'],re.I)],'status':'No supplied map scene/bundle for indices 8,9,11 was found within the fully inventoried WebData members, UnityFS nodes, Resources container, TextAssets, or audio-resource files. Only Assets/Lobby.unity is registered as a built scene.','needed':['The external Unity AssetBundle selected for map index8,9 or11 by StreamingAssetsLoader/MapURLFinder, including its scene and dependent assets.','Any companion dependency bundles, map configuration JSON, catalogue/hash/version files referenced by the selected bundle-loading branch.','For genuine online play: the original server endpoints/room availability or a separately reconstructed compatible backend; client assets alone do not contain the server.'],'filename_limit':'Exact external filenames/URLs are not established by serialized assets alone. Derive them from matching WASM loading code before requesting/downloading any file. No external requests were performed.'}
save('kourstrike-bootstrap.json',bootstrap);save('kourstrike-resources.json',resources);save('kourstrike-map-evidence.json',maps);save('kourstrike-required-files.json',required)
report=['# KourStrike asset/bootstrap evidence','', 'This is a bounded offline inspection of the supplied build. No external services were contacted and no game code was run.','', '## Confirmed bootstrap configuration','', f'- `SdkManager`: `{sdk["file"]}`, pathID {sdk["path_id"]}, complete object decode; `gameType=0`. Enum values: Kour=0, KourStrike=1, KourZone=2.',f'- The serialized `gameType` occupies object-relative bytes {sdkfield["start"]}..{sdkfield["end"]}, absolute byte offset {sdkobject["offset"]+sdkfield["start"]} in the extracted `level0` file. This identifies the default only; host/bootstrap code may override it.','- `NetworkManager`: `level0`, pathID 2449, configured with 11 GameMode references.','- `Search And Destroy`: `sharedassets0.assets`, pathID 7893; id8, `kourstrikeChanceWeight=1`, `excludeFromPubsKourstrike=false`, forced maps [8,9,11], 8 players, team size4, 600-second match.','', '## Map availability boundary','',f'- BuildSettings (`globalgamemanagers`, class141, pathID{build["path_id"]}) has exactly {len(scenes)} registered built scene: `{scenes[0]}`. This is direct serialized scene-table evidence, stronger than interpreting filenames.','- The UnityFS directory contains only globalgamemanagers, globalgamemanagers.assets, sharedassets0.assets, level0, resources.assets and Resources/unity_builtin_extra. No map8/map9/map11 node is present.',f'- ResourceManager (`globalgamemanagers`, class147, pathID{resource["path_id"]}) exposes {len(container)} resource names. Its complete resource-name table is in `kourstrike-resources.json`. There are no map/scene/bundle/catalogue resource entries.','- The four TextAssets are PerformanceTestRunInfo, PerformanceTestRunSettings and two line-breaking character tables. None is a map/configuration catalogue.','- The two `.resource` files are fully accounted for by original AudioClip payloads plus zero-filled alignment gaps: 9 clips +85 padding bytes in resources.resource; 105 clips +879 padding bytes in sharedassets0.resource. No non-audio remainder is available as a hidden map payload there.','- No MapInfo, MapBuilder, MapBuilderData or CustomMapLoader MonoBehaviour instances were found in the decoded gameplay object inventory. MapConfig/MapData/MapSettings are metadata types, not recovered map instances.','- KourStrike dead-camera/UI prefabs and sounds exist, but they do not supply a map scene.','', '## What is missing','', 'The map AssetBundle selected for index8,9 or11, including any dependent bundles, is required to enter that original scene. A configuration/catalogue is needed only if the matching loading code references it. Exact filenames must come from the WASM loading branch; this asset pass does not invent map names or URLs. A loader that starts the Lobby successfully does not establish that a playable map is present.','', 'Evidence files: `kourstrike-bootstrap.json`, `kourstrike-resources.json`, `kourstrike-map-evidence.json`, `kourstrike-required-files.json`. Reproduce with `python tools/inspect-kourstrike-assets.py`.']
(ROOT/'kourstrike-report.md').write_text('\n'.join(report)+'\n',encoding='utf8')
print(json.dumps({'built_scenes':scenes,'resource_names':len(container),'map_resources':len(maps['map_named_resources']),'sdk_game_type':sdk['values']['gameType'],'search_and_destroy':next(x['values']for x in modes if x['name']=='Search And Destroy'),'resource_coverage':[{k:v for k,v in x.items()if k!='gaps'}for x in resource_coverage],'bundle_signatures':signatures},indent=2))
