"""Save user-authorized static mesh bytes from exported native REA observations.

No network or target execution. Accepts only declared exact bundle names,
HTTP200, unredacted complete base64 bodies and valid UnityFS identities.
"""
from pathlib import Path
from urllib.parse import urlsplit,parse_qs
import json,base64,hashlib,struct,importlib.util,sys
ROOT=Path(__file__).resolve().parent.parent
def load(p):return json.loads(Path(p).read_text(encoding='utf8'))
allowed=set(load(ROOT/'tools/local-asset-names.json')['names']);evidence=Path(sys.argv[1]);bundle=load(evidence);receipts=[]
spec=importlib.util.spec_from_file_location('assets',ROOT/'tools/inspect-assets.py');a=importlib.util.module_from_spec(spec);spec.loader.exec_module(a)
for e in bundle['records']:
 if e['operation']!='capture_browser_scenario':continue
 result=e['normalized_result'];events=result.get('events',{}).get('items',[]);responses={x['transaction_id']:x for x in events if x.get('kind')=='response'}
 for event in events:
  if event.get('kind')!='network-content'or event.get('phase')!='response':continue
  response=responses.get(event['transaction_id']);body=event.get('body',{})
  if not response:continue
  url=response['url']['url'];parsed=urlsplit(url)
  if parsed.scheme!='https'or parsed.hostname!='kourstrike.io'or not parsed.path.startswith('/StreamingAssets/'):continue
  name=parsed.path.removeprefix('/StreamingAssets/')
  if name not in allowed:continue
  if response.get('status')!=200 or body.get('state')!='captured'or body.get('redacted')or body.get('encoding')!='base64':continue
  raw=base64.b64decode(body['content'],validate=True);sha=hashlib.sha256(raw).hexdigest()
  if len(raw)!=body['bytes']or sha!=body['sha256']:raise ValueError('Response body identity mismatch '+name)
  r=a.Reader(raw)
  if r.cstr()!='UnityFS':raise ValueError('Not UnityFS '+name)
  version=r.u32();player=r.cstr();unity=r.cstr();declared=r.u64()
  if version!=8 or declared!=len(raw):raise ValueError('Invalid UnityFS size/version '+name)
  destination=ROOT/'original-preview/StreamingAssets'/name;destination.parent.mkdir(parents=True,exist_ok=True)
  if not destination.resolve().is_relative_to((ROOT/'original-preview/StreamingAssets').resolve()):raise ValueError('Unsafe output path')
  if destination.exists()and destination.read_bytes()!=raw:raise ValueError('Refusing to replace different local bundle '+name)
  destination.write_bytes(raw)
  a.OUT=ROOT/'analysis/meshes/bundles'/name.replace('/','_');a.OUT.mkdir(parents=True,exist_ok=True);nodes=a.unpack_bundle(destination);serialized=[];mesh_names=[]
  for node in nodes:
   p=a.OUT/'bundle'/node['name']
   if p.suffix in('.resource','.resS'):continue
   m,b=a.serialized(p);serialized.append({'file':m['path'],'unity':m['unity'],'version':m['version'],'type_tree_enabled':m['type_tree_enabled'],'objects':len(m['objects'])})
   for o in m['objects']:
    if o['class_id']==43:
     nr=a.Reader(b[o['offset']:o['offset']+o['size']],'<');mesh_names.append({'file':m['path'],'path_id':o['path_id'],'name':nr.string(),'object_bytes':o['size']})
  if not mesh_names:raise ValueError('Mesh bundle has no serialized Mesh '+name)
  receipt={'name':name,'source_url':url,'status':200,'method':'GET','local_path':str(destination.relative_to(ROOT)).replace('\\','/'),'bytes':len(raw),'sha256':sha,'unityfs_version':version,'unity_revision':unity,'declared_bytes':declared,'serialized':serialized,'mesh_objects':mesh_names,'evidence_id':e['evidence_id'],'evidence_bundle':str(evidence).replace('\\','/'),'transaction_id':event['transaction_id'],'body_representation':body['representation'],'body_redacted':False,'cleanup':result.get('browser',{}).get('cleanup'),'purpose':'Restore exact missing native firearm/equipment mesh assets; original network service access remains disabled.'}
  (a.OUT/'receipt.json').write_text(json.dumps(receipt,indent=2),encoding='utf8');receipts.append(receipt)
path=ROOT/'analysis/runtime/mesh-acquisition-manifest.json';existing=load(path)if path.exists()else{'assets':[]};byname={x['name']:x for x in existing['assets']}
for row in receipts:byname[row['name']]=row
existing['assets']=sorted(byname.values(),key=lambda x:x['name']);existing['acquired_names']=list(byname);existing['allowed_names']=sorted(allowed);existing['missing_names']=sorted(allowed-byname.keys());path.write_text(json.dumps(existing,indent=2),encoding='utf8')
print(json.dumps({'saved':[{'name':x['name'],'bytes':x['bytes'],'sha256':x['sha256'],'unity':x['unity_revision'],'meshes':len(x['mesh_objects'])}for x in receipts],'total_assets':len(byname),'missing_names':existing['missing_names']},indent=2))
