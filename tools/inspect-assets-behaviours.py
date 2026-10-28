"""Deserialize stripped Unity MonoBehaviours using matching recovered metadata schemas.

Requires inspect-assets.py output and analysis/metadata/all-types.json from REA/WASM
analysis. Values are marked exact only when the complete serialized object is consumed.
Unsupported Unity builtins/managed references remain explicit partials.
"""
from pathlib import Path
import importlib.util,json,re,collections,struct,hashlib,math
spec=importlib.util.spec_from_file_location('assets',Path(__file__).with_name('inspect-assets.py'));a=importlib.util.module_from_spec(spec);spec.loader.exec_module(a)
OUT=a.OUT
def load(p):return json.loads(Path(p).read_text(encoding='utf8'))
types=load('analysis/metadata/all-types.json');byid={x['index']:x for x in types};byname={x['full_name']:x for x in types}
# Metadata names for nested types can collide with top-level names. Prefer the
# top-level definition when matching MonoScript class names (e.g. game Item).
for x in types:
 if x['declaring_type']<0:byname[x['full_name']]=x
byshort=collections.defaultdict(list)
for t in types:byshort[t['name']].append(t)
def findtype(name):
 if name in byname:return byname[name]
 values=byshort.get(name,[])
 return values[0] if len(values)==1 else None
def chain(t):
 seen=set()
 while t and t['index']not in seen:
  yield t;seen.add(t['index']);t=byid.get(t.get('parent_definition'))
def isobject(t):return any(x['full_name']=='UnityEngine.Object'for x in chain(t))
def serializable_type(name):
 if name in PRIMITIVES or name=='string'or name in VECTORS or name in ['UnityEngine.Vector2Int','UnityEngine.Vector3Int','UnityEngine.Color32','UnityEngine.LayerMask','UnityEngine.AnimationCurve']:return True
 if name.endswith('[]'):return serializable_type(name[:-2])
 if name.startswith('System.Collections.Generic.List<'):return serializable_type(name[len('System.Collections.Generic.List<'):-1])
 t=findtype(name)
 return bool(t and (isobject(t)or t.get('parent')=='System.Enum'or(t['flags']&8192 and not name.startswith('System.'))))
def fields(t):
 rows=[]
 for base in reversed(list(chain(t))):
  if base['full_name']in ['UnityEngine.Object','UnityEngine.MonoBehaviour','UnityEngine.Behaviour','UnityEngine.Component','UnityEngine.ScriptableObject']:continue
  for f in base['fields']:
   if not f.get('serialization_candidate')or f['attributes']&32:continue
   typ=f['type']
   if typ.startswith(('System.Collections.Generic.Dictionary<','System.Action','System.Func','System.EventHandler')):continue
   if not f.get('serialize_reference')and not serializable_type(typ):continue
   rows.append(f)
 return rows
PRIMITIVES={'bool':'B','byte':'B','sbyte':'b','char':'H','short':'h','ushort':'H','int':'i','uint':'I','long':'q','ulong':'Q','float':'f','double':'d'}
VECTORS={'UnityEngine.Vector2':2,'UnityEngine.Vector3':3,'UnityEngine.Vector4':4,'UnityEngine.Quaternion':4,'UnityEngine.Color':4,'UnityEngine.Rect':4,'UnityEngine.Bounds':6,'UnityEngine.Matrix4x4':16}
def readtype(r,name,depth=0,array=False):
 if depth>24:raise ValueError('Schema recursion depth')
 if name in PRIMITIVES:
  value=r.num(PRIMITIVES[name]);
  if name in ['bool','byte','sbyte','char','short','ushort']and not array:r.align()
  if name=='bool':
   if value not in (0,1):raise ValueError('Invalid serialized bool')
   return bool(value)
  if name in ['float','double']and not math.isfinite(value):return '-Infinity' if value<0 else 'Infinity' if value>0 else 'NaN'
  return value
 if name=='string':return r.string()
 if name=='UnityEngine.LayerMask':return r.i32()
 if name in VECTORS:return [r.num('f')for _ in range(VECTORS[name])]
 if name in ['UnityEngine.Vector2Int','UnityEngine.Vector3Int']:return [r.i32()for _ in range(2 if '2Int'in name else 3)]
 if name=='UnityEngine.Color32':v=list(r.read(4));r.align();return v
 if name=='UnityEngine.AnimationCurve':
  n=r.i32()
  if not 0<=n<=10000:raise ValueError('Invalid curve length')
  keys=[]
  for _ in range(n):keys.append(dict(time=r.num('f'),value=r.num('f'),in_slope=r.num('f'),out_slope=r.num('f'),weighted_mode=r.i32(),in_weight=r.num('f'),out_weight=r.num('f')))
  return dict(keys=keys,pre_infinity=r.i32(),post_infinity=r.i32(),rotation_order=r.i32())
 element=None
 if name.endswith('[]'):element=name[:-2]
 if name.startswith('System.Collections.Generic.List<'):element=name[len('System.Collections.Generic.List<'):-1]
 if element:
  n=r.i32()
  if not 0<=n<=100000:raise ValueError('Invalid array length '+str(n))
  values=[readtype(r,element,depth+1,True)for _ in range(n)];r.align();return values
 t=findtype(name)
 if not t:raise ValueError('Unknown type '+name)
 if t.get('parent')=='System.Enum':return r.i32()
 if isobject(t):return a.ptr(r)
 if name.startswith('System.')or not t['flags']&8192:raise ValueError('Unsupported nonserializable type '+name)
 result={}
 for f in fields(t):
  if f.get('serialize_reference'):raise ValueError('SerializeReference '+f['name'])
  result[f['name']]=readtype(r,f['type'],depth+1)
 return result

def main():
 inventories={p.name[:-5]:load(p)for p in (OUT/'inventory').glob('*.json')}
 metas={p.name[:-5]:load(p)for p in (OUT/'serialized').glob('*.json')}
 indexes={name:{row['path_id']:row for row in rows}for name,rows in inventories.items()}
 bundle_paths={p.name:p for p in (OUT/'bundle').rglob('*')if p.is_file()}
 bundle_paths['unity default resources']=Path('analysis/extracted/Resources/unity default resources')
 payloads={name:bundle_paths[name].read_bytes()for name in metas}
 def resolve(file,ptr):
  name=file
  if ptr['file_id']:
   externals=metas[file]['externals'];idx=ptr['file_id']-1
   if idx>=len(externals):return None,None
   name=Path(externals[idx]['path']).name
  return name,indexes.get(name,{}).get(ptr['path_id'])
 def fullpath(file,obj,seen=None):
  if obj is None:return None
  seen=seen or set()
  if obj['path_id']in seen:return '[cycle]'
  seen.add(obj['path_id']);components=obj.get('components',[])
  for ref in components:
   f,comp=resolve(file,ref)
   if comp and comp['class_id']in(4,224):
    f,parent=resolve(file,comp['parent'])
    if parent:
     f,go=resolve(f,parent['game_object']);prefix=fullpath(f,go,seen)
     if prefix:return prefix+'/'+obj['name']
  return obj.get('name')
 totals=collections.Counter();allresults=[]
 for file,rows in inventories.items():
  results=[];hierarchy=[]
  for o in rows:
   if o['class_id']==1:
    hierarchy.append(dict(path_id=o['path_id'],name=o['name'],path=fullpath(file,o),active=o['active'],components=[{'ref':p,'class':(resolve(file,p)[1]or{}).get('class'),'script':(resolve(file,(resolve(file,p)[1]or{}).get('script',{'file_id':0,'path_id':0}))[1]or{}).get('class_name')}for p in o['components']]))
   if o['class_id']!=114:continue
   _,script=resolve(file,o['script']);script=script or{};classname=script.get('class_name','?');namespace=script.get('namespace','');full=namespace+'.'+classname if namespace else classname;t=findtype(full);_,go=resolve(file,o['game_object']);result={'file':file,'path_id':o['path_id'],'name':o['name'],'game_object':go.get('name')if go else None,'hierarchy_path':fullpath(file,go),'script':full,'assembly':script.get('assembly'),'fields_offset':o['fields_offset'],'object_bytes':o['size'],'values':{},'schema_type':t['index']if t else None}
   raw=payloads[file][o['offset']:o['offset']+o['size']];r=a.Reader(raw,'<');r.p=o['fields_offset'];offsets=[]
   try:
    if not t:raise ValueError('No metadata type')
    for f in fields(t):
     if f.get('serialize_reference'):raise ValueError('SerializeReference '+f['name'])
     start=r.p;value=readtype(r,f['type']);offsets.append({'field':f['name'],'type':f['type'],'start':start,'end':r.p})
     if re.search(r'(api.?key|app.?id|password|secret|token|credential)',f['name'],re.I)and isinstance(value,str)and value:value={'redacted':True,'bytes':len(value.encode()),'sha256':hashlib.sha256(value.encode()).hexdigest()}
     result['values'][f['name']]=value
    result['coverage']='complete-object' if r.p==o['size']else 'partial-object';result['remaining_bytes']=o['size']-r.p
   except Exception as e:result['coverage']='partial-object';result['error']=str(e);result['remaining_bytes']=o['size']-r.p
   result['field_offsets']=offsets;totals[result['coverage']]+=1;totals['objects']+=1
   results.append(result);allresults.append(result)
  if results:a.dump(Path('decoded-behaviours')/(file+'.json'),results)
  if hierarchy:a.dump(Path('scene-objects')/(file+'.json'),hierarchy)
 a.dump(Path('behaviour-decode-summary.json'),dict(totals));a.dump(Path('gameplay-settings.json'),[x for x in allresults if x['assembly']in ['Assembly-CSharp','Assembly-CSharp.dll']])
 print(json.dumps(dict(totals)));print('Gameplay complete',sum(x['coverage']=='complete-object'for x in allresults if x['assembly']in ['Assembly-CSharp','Assembly-CSharp.dll']))
 print('Relevant',[(x['file'],x['name']or x['game_object'],x['script'],x['coverage'],x.get('error'),x.get('remaining_bytes'))for x in allresults if x['script']in ['Weapon','PlayerController','Shooter','WeaponClass','GameMode']])
if __name__=='__main__':main()
