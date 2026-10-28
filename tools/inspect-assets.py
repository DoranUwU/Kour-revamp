"""Offline UnityFS/serialized-file reader for this supplied build; no target code runs."""
from pathlib import Path
import struct,json,collections,hashlib,re,zlib,binascii,math

OUT=Path('analysis/assets'); OUT.mkdir(exist_ok=True)
def dump(p,v):
 p=OUT/p; p.parent.mkdir(parents=True,exist_ok=True);p.write_text(json.dumps(v,indent=2,ensure_ascii=False),encoding='utf8')
class Reader:
 def __init__(self,b,endian='>'):self.b=b;self.p=0;self.e=endian
 def read(self,n):
  if n<0 or self.p+n>len(self.b):raise ValueError(f'Invalid read {self.p}+{n}/{len(self.b)}')
  o=self.b[self.p:self.p+n];self.p+=n;return o
 def num(self,f):return struct.unpack(self.e+f,self.read(struct.calcsize(f)))[0]
 def u8(self):return self.num('B')
 def i32(self):return self.num('i')
 def u32(self):return self.num('I')
 def i64(self):return self.num('q')
 def u64(self):return self.num('Q')
 def cstr(self):
  end=self.b.index(0,self.p);v=self.b[self.p:end].decode('utf8','replace');self.p=end+1;return v
 def align(self,n=4):self.p=(self.p+n-1)//n*n
 def string(self):v=self.read(self.i32()).decode('utf8','replace');self.align();return v

def lz4(b,expected):
 out=bytearray();i=0
 while i<len(b):
  token=b[i];i+=1;lit=token>>4
  if lit==15:
   while True:
    n=b[i];i+=1;lit+=n
    if n!=255:break
  out.extend(b[i:i+lit]);i+=lit
  if i>=len(b):break
  off=b[i]|b[i+1]<<8;i+=2
  if off==0 or off>len(out):raise ValueError('Invalid LZ4 offset')
  length=(token&15)+4
  if token&15==15:
   while True:
    n=b[i];i+=1;length+=n
    if n!=255:break
  start=len(out)-off
  for j in range(length):out.append(out[start+j])
 if len(out)!=expected:raise ValueError(f'LZ4 size {len(out)} != {expected}')
 return bytes(out)
def decompress(b,n,flags):
 kind=flags&63
 if kind==0:
  if len(b)!=n:raise ValueError('Raw block size mismatch')
  return b
 if kind in (2,3):return lz4(b,n)
 raise ValueError(f'Unsupported compression {kind}')

COMMON={0:'AABB',5:'AnimationClip',19:'AnimationCurve',34:'AnimationState',49:'Array',55:'Base',60:'BitField',69:'bitset',76:'bool',81:'char',86:'ColorRGBA',96:'Component',106:'data',111:'deque',117:'double',124:'dynamic_array',138:'FastPropertyName',155:'first',161:'float',167:'Font',172:'GameObject',183:'Generic Mono',196:'GradientNEW',208:'GUID',213:'GUIStyle',222:'int',226:'list',231:'long long',241:'map',245:'Matrix4x4f',257:'MdFour',264:'MonoBehaviour',278:'MonoScript',289:'m_ByteSize',300:'m_Curve',308:'m_EditorClassIdentifier',332:'m_EditorHideFlags',350:'m_Enabled',360:'m_ExtensionPtr',375:'m_GameObject',388:'m_Index',396:'m_IsArray',406:'m_IsStatic',417:'m_MetaFlag',428:'m_Name',435:'m_ObjectHideFlags',453:'m_PrefabInternal',470:'m_PrefabParentObject',491:'m_Script',500:'m_StaticEditorFlags',520:'m_Type',527:'m_Version',537:'Object',544:'pair',549:'PPtr<Component>',565:'PPtr<GameObject>',582:'PPtr<Material>',597:'PPtr<MonoBehaviour>',617:'PPtr<MonoScript>',634:'PPtr<Object>',647:'PPtr<Prefab>',660:'PPtr<Sprite>',673:'PPtr<TextAsset>',689:'PPtr<Texture>',703:'PPtr<Texture2D>',719:'PPtr<Transform>',735:'Prefab',742:'Quaternionf',754:'Rectf',760:'RectInt',768:'RectOffset',779:'second',786:'set',790:'short',796:'size',801:'SInt16',808:'SInt32',815:'SInt64',822:'SInt8',828:'staticvector',841:'string',848:'TextAsset',858:'TextMesh',867:'Texture',875:'Texture2D',885:'Transform',895:'TypelessData',908:'UInt16',915:'UInt32',922:'UInt64',929:'UInt8',935:'unsigned int',948:'unsigned long long',967:'unsigned short',982:'vector',989:'Vector2f',998:'Vector3f',1007:'Vector4f',1016:'m_ScriptingClassIdentifier',1043:'Gradient',1052:'Type*',1058:'int2_storage',1071:'int3_storage',1084:'BoundsInt',1094:'m_CorrespondingSourceObject',1121:'m_PrefabInstance',1138:'m_PrefabAsset',1152:'FileSize',1161:'Hash128'}

def unpack_bundle(path):
 b=path.read_bytes();r=Reader(b);signature=r.cstr();version=r.u32();unity=r.cstr();revision=r.cstr();size=r.u64();compressed=r.u32();raw=r.u32();flags=r.u32()
 if signature!='UnityFS':raise ValueError(signature)
 if version>=7:r.align(16)
 if flags&128:
  info=decompress(b[len(b)-compressed:],raw,flags)
 else:info=decompress(r.read(compressed),raw,flags)
 if flags&512:r.align(16)
 ir=Reader(info);digest=ir.read(16).hex();blocks=[]
 for _ in range(ir.i32()):blocks.append({'raw':ir.u32(),'compressed':ir.u32(),'flags':ir.num('H')})
 nodes=[]
 for _ in range(ir.i32()):nodes.append({'offset':ir.u64(),'size':ir.u64(),'flags':ir.u32(),'name':ir.cstr()})
 data=b''.join(decompress(r.read(x['compressed']),x['raw'],x['flags']) for x in blocks)
 target=OUT/'bundle';target.mkdir(exist_ok=True)
 for node in nodes:
  dest=target/node['name'];dest.parent.mkdir(parents=True,exist_ok=True)
  if not dest.resolve().is_relative_to(target.resolve()):raise ValueError('Unsafe bundle path')
  payload=data[node['offset']:node['offset']+node['size']]
  if len(payload)!=node['size']:raise ValueError('Invalid node bounds')
  dest.write_bytes(payload);node['sha256']=hashlib.sha256(payload).hexdigest()
 summary=dict(signature=signature,format=version,unity=unity,revision=revision,size=size,flags=flags,blocks=blocks,nodes=nodes)
 dump(Path('bundle-inventory.json'),summary)
 return nodes

def tree(r,version):
 count=r.i32();length=r.i32();nodes=[]
 for _ in range(count):
  node=dict(version=r.num('H'),level=r.u8(),flags=r.u8(),typeoff=r.u32(),nameoff=r.u32(),bytesize=r.i32(),index=r.i32(),metaflag=r.i32())
  if version>=19:node['refhash']=r.u64()
  nodes.append(node)
 strings=r.read(length)
 def name(off):
  if off&0x80000000:return COMMON.get(off&0x7fffffff,f'COMMON_{off&0x7fffffff}')
  return strings[off:strings.index(0,off)].decode('utf8','replace')
 for n in nodes:n['type']=name(n.pop('typeoff'));n['name']=name(n.pop('nameoff'))
 return nodes

def serialized(path):
 b=path.read_bytes();r=Reader(b);metadata=r.u32();size=r.u32();version=r.u32();dataoff=r.u32();endian=r.u8();r.read(3)
 if version>=22:metadata=r.u32();size=r.u64();dataoff=r.u64();r.u64()
 r.e='>' if endian else '<';unity=r.cstr();platform=r.i32();enabled=r.u8();types=[]
 def gettype(ref=False):
  t=dict(class_id=r.i32(),stripped=r.u8(),script_index=r.num('h'))
  if t['class_id']==114:t['script_id']=r.read(16).hex()
  t['hash']=r.read(16).hex()
  if enabled:t['tree']=tree(r,version)
  if enabled and version>=21:
   if ref:t.update(classname=r.cstr(),namespace=r.cstr(),assembly=r.cstr())
   else:t['dependencies']=[r.i32() for _ in range(r.i32())]
  return t
 for _ in range(r.i32()):types.append(gettype())
 objects=[]
 for _ in range(r.i32()):
  r.align();pid=r.i64();offset=r.u64() if version>=22 else r.u32();length=r.u32();tid=r.i32();objects.append(dict(path_id=pid,offset=offset+dataoff,size=length,type_index=tid,class_id=types[tid]['class_id']))
 scripts=[]
 for _ in range(r.i32()):
  file_id=r.i32();r.align();scripts.append(dict(file_id=file_id,path_id=r.i64()))
 externals=[]
 for _ in range(r.i32()):
  r.cstr();guid=r.read(16).hex();kind=r.i32();externals.append(dict(guid=guid,type=kind,path=r.cstr()))
 refs=[]
 if version>=20:
  for _ in range(r.i32()):refs.append(gettype(True))
 user=r.cstr()
 return dict(path=path.name,bytes=len(b),metadata_size=metadata,declared_size=size,version=version,unity=unity,platform=platform,type_tree_enabled=bool(enabled),data_offset=dataoff,types=types,objects=objects,scripts=scripts,externals=externals,ref_types=refs,user=user,metadata_end=r.p),b

CLASSES={1:'GameObject',4:'Transform',20:'Camera',21:'Material',23:'MeshRenderer',28:'Texture2D',33:'MeshFilter',43:'Mesh',48:'Shader',49:'TextAsset',54:'Rigidbody',65:'BoxCollider',72:'ComputeShader',74:'AnimationClip',82:'AudioSource',83:'AudioClip',84:'RenderTexture',91:'AnimatorController',95:'Animator',114:'MonoBehaviour',115:'MonoScript',128:'Font',134:'PhysicMaterial',137:'SkinnedMeshRenderer',150:'PreloadData',213:'Sprite',222:'CanvasRenderer',223:'Canvas',224:'RectTransform'}
NAMED={21,28,43,48,49,72,74,83,84,91,115,128,134,213}
def ptr(r):return {'file_id':r.i32(),'path_id':r.i64()}
def safe_name(s):return re.sub(r'[^a-zA-Z0-9._-]+','_',s)[:120].strip('_') or 'unnamed'
def asset_data(meta,b):
 inventory=[];scenes=[];textures=[];audio=[];scripts=[];behaviours=[];errors=[];meshes=[]
 for o in meta['objects']:
  r=Reader(b[o['offset']:o['offset']+o['size']],'<');row={**o,'class':CLASSES.get(o['class_id'],str(o['class_id']))}
  try:
   cid=o['class_id']
   if cid in NAMED:row['name']=r.string()
   if cid==115:
    row.update(execution_order=r.i32(),properties_hash=r.read(16).hex(),class_name=r.string(),namespace=r.string(),assembly=r.string());scripts.append(row.copy())
   elif cid==1:
    row['components']=[ptr(r) for _ in range(r.i32())];row['layer']=r.u32();row['name']=r.string();row['tag']=r.num('H');row['active']=bool(r.u8());scenes.append(row.copy())
   elif cid in (4,224):
    row['game_object']=ptr(r);row['rotation']=[r.num('f') for _ in range(4)];row['position']=[r.num('f') for _ in range(3)];row['scale']=[r.num('f') for _ in range(3)];row['children']=[ptr(r) for _ in range(r.i32())];row['parent']=ptr(r);scenes.append(row.copy())
   elif cid==114:
    row['game_object']=ptr(r);row['enabled']=bool(r.u8());r.align();row['script']=ptr(r);row['name']=r.string();row['fields_offset']=r.p;row['fields_bytes']=o['size']-r.p;row['script_type_index']=meta['types'][o['type_index']]['script_index'];behaviours.append(row.copy())
   elif cid==33:row['game_object']=ptr(r);row['mesh']=ptr(r)
   elif cid==43:
    mesh=decode_mesh(r,row,meta['path']);row.update(mesh);meshes.append(row.copy())
   elif cid==28:
    row['forced_fallback_format']=r.i32();row['width']=r.i32();row['height']=r.i32();row['complete_image_size']=r.i32();row['mips_stripped']=r.i32();row['format']=r.i32();row['mip_count']=r.i32();row['flags']=[r.u8() for _ in range(4)];r.align();row['mipmap_limit_group']=r.string();row['streaming_mipmaps']=bool(r.u8());r.align();row['streaming_priority']=r.i32();row['image_count']=r.i32();row['dimension']=r.i32();row['filter_mode']=r.i32();row['aniso']=r.i32();row['mip_bias']=r.num('f');row['wrap']=[r.i32() for _ in range(3)];row['lightmap_format']=r.i32();row['color_space']=r.i32();blob=r.read(r.i32());r.align();row['platform_blob_size']=len(blob);length=r.i32();image=r.read(length);r.align();row['stream_offset']=r.u64();row['stream_size']=r.u32();row['stream_path']=r.string();row['parsed_end']=r.p
    if row['stream_size']:
     source=Path('analysis/extracted')/Path(row['stream_path']).name
     if not source.exists():source=OUT/'bundle'/Path(row['stream_path']).name
     image=source.read_bytes()[row['stream_offset']:row['stream_offset']+row['stream_size']]
    row['export_bytes']=len(image);stem=f"{safe_name(meta['path'])}_{o['path_id']}_{safe_name(row['name'])}";dest=OUT/'textures';dest.mkdir(exist_ok=True);(dest/(stem+'.bin')).write_bytes(image);row['raw_export']='textures/'+stem+'.bin'
    png=decode_texture(row,image)
    if png:(dest/(stem+'.png')).write_bytes(png);row['png_export']='textures/'+stem+'.png'
    textures.append(row.copy())
   elif cid==83:
    row.update(load_type=r.i32(),channels=r.i32(),frequency=r.i32(),bits_per_sample=r.i32(),length=r.num('f'),tracker=bool(r.u8()));r.align();row['subsound_index']=r.i32();row['preload']=bool(r.u8());row['load_background']=bool(r.u8());row['legacy_3d']=bool(r.u8());r.align();row['source']=r.string();row['stream_offset']=r.u64();row['stream_size']=r.u64();row['compression']=r.i32();row['parsed_end']=r.p
    source=Path('analysis/extracted')/Path(row['source']).name
    if not source.exists():source=OUT/'bundle'/Path(row['source']).name
    payload=source.read_bytes()[row['stream_offset']:row['stream_offset']+row['stream_size']];row['payload_header']=payload[:16].hex();ext='.m4a' if payload[4:8]==b'ftyp' else '.ogg' if payload.startswith(b'OggS') else '.fsb' if payload.startswith(b'FSB') else '.bin';stem=f"{safe_name(meta['path'])}_{o['path_id']}_{safe_name(row['name'])}";dest=OUT/'audio';dest.mkdir(exist_ok=True);(dest/(stem+ext)).write_bytes(payload);row['export']='audio/'+stem+ext;audio.append(row.copy())
   elif cid==49:
    payload=r.read(r.i32());dest=OUT/'text';dest.mkdir(exist_ok=True);stem=f"{safe_name(meta['path'])}_{o['path_id']}_{safe_name(row['name'])}";(dest/(stem+'.txt')).write_bytes(payload);row['export']='text/'+stem+'.txt'
   if r.p>o['size']:raise ValueError('Object overflow')
  except Exception as e:row['decode_error']=str(e);errors.append({'path_id':o['path_id'],'class_id':o['class_id'],'error':str(e)})
  inventory.append(row)
 dump(Path('inventory')/(meta['path']+'.json'),inventory)
 for name,rows in [('hierarchy',scenes),('textures',textures),('audio',audio),('scripts',scripts),('behaviours',behaviours),('meshes',meshes),('errors',errors)]:
  if rows:dump(Path(name)/(meta['path']+'.json'),rows)
 return {'named':sum('name' in x for x in inventory),'textures':len(textures),'audio':len(audio),'scripts':len(scripts),'behaviours':len(behaviours),'meshes':len(meshes),'errors':len(errors)}

def decode_mesh(r,row,filename):
 def bytearr():v=r.read(r.i32());r.align();return v
 def floats(n):return [r.num('f') for _ in range(n)]
 def skiparray(size):n=r.i32();r.read(n*size);return n
 def packedfloat():
  count=r.u32();rang=r.num('f');start=r.num('f');data=bytearr();bits=r.u8();r.align();return dict(count=count,bits=bits,bytes=len(data),range=rang,start=start,data_hex=data.hex())
 def packedint():
  count=r.u32();data=bytearr();bits=r.u8();r.align();return dict(count=count,bits=bits,bytes=len(data),data_hex=data.hex())
 out={'submeshes':[]}
 for _ in range(r.i32()):out['submeshes'].append(dict(first_byte=r.u32(),index_count=r.u32(),topology=r.i32(),base_vertex=r.u32(),first_vertex=r.u32(),vertex_count=r.u32(),aabb=floats(6)))
 out['blend_shape_vertices']=skiparray(40)
 for _ in range(r.i32()):r.read(10);r.align()
 for _ in range(r.i32()):r.string();r.read(12)
 skiparray(4);out['bind_poses']=skiparray(64);skiparray(4);r.u32();skiparray(24);skiparray(4)
 out['compression']=r.u8();out['readable']=bool(r.u8());r.u8();r.u8();out['index_format']=r.i32();indices=bytearr()
 out['vertex_count']=r.u32();channels=[]
 for _ in range(r.i32()):channels.append(dict(stream=r.u8(),offset=r.u8(),format=r.u8(),dimension=r.u8()))
 out['channels']=channels;vertices=bytearr();out['vertex_bytes']=len(vertices);packed={}
 for name in ['vertices','uv','normals','tangents']:packed[name]=packedfloat()
 for name in ['weights','normal_signs','tangent_signs']:packed[name]=packedint()
 packed['float_colors']=packedfloat()
 for name in ['bone_indices','triangles']:packed[name]=packedint()
 packed['uv_info']=r.u32();out['packed']=packed;out['aabb']=floats(6);out['usage_flags']=r.i32();bytearr();bytearr();out['metrics']=floats(2);out['stream_offset']=r.u64();out['stream_size']=r.u32();out['stream_path']=r.string();out['parsed_end']=r.p
 if out['stream_size']:
  source=Path('analysis/extracted')/Path(out['stream_path']).name
  if not source.exists():source=OUT/'bundle'/Path(out['stream_path']).name
  vertices=source.read_bytes()[out['stream_offset']:out['stream_offset']+out['stream_size']]
 dest=OUT/'meshes';dest.mkdir(exist_ok=True);stem=f"{safe_name(filename)}_{row['path_id']}_{safe_name(row['name'])}";(dest/(stem+'.vertex.bin')).write_bytes(vertices);(dest/(stem+'.index.bin')).write_bytes(indices)
 sizes={0:4,1:2,2:1,3:1,4:2,5:2,6:1,7:1,8:2,9:2,10:4,11:4};strides=collections.defaultdict(int)
 for c in channels:
  dim=c['dimension']&15
  if dim:strides[c['stream']]=max(strides[c['stream']],c['offset']+sizes.get(c['format'],4)*dim)
 bases={};offset=0
 for stream,stride in sorted(strides.items()):bases[stream]=offset;offset=(offset+stride*out['vertex_count']+15)//16*16
 positions=[];normals=[];uv=[]
 for channel,outlist,needed in [(0,positions,3),(1,normals,3),(4,uv,2)]:
  if channel>=len(channels):continue
  c=channels[channel];dim=c['dimension']&15
  if dim<needed or c['format'] not in (0,1):continue
  unit=sizes[c['format']];fmt='f' if unit==4 else 'e';stride=strides[c['stream']];base=bases[c['stream']]
  for i in range(out['vertex_count']):
   start=base+i*stride+c['offset'];v=struct.unpack('<'+fmt*needed,vertices[start:start+unit*needed]);outlist.append(v)
 if not positions and packed['vertices']['count']:
  def unpack(v,asfloat=False):
   raw=bytes.fromhex(v['data_hex']);bits=v['bits'];mask=(1<<bits)-1;values=[]
   for i in range(v['count']):
    bit=i*bits;start=bit//8;shift=bit%8;value=(int.from_bytes(raw[start:start+(bits+shift+7)//8],'little')>>shift)&mask
    values.append(value*v['range']/mask+v['start'] if asfloat and mask else v.get('start',0) if asfloat else value)
   return values
  raw=unpack(packed['vertices'],True);positions=list(zip(*[iter(raw)]*3));out['decompressed_vertex_count']=len(positions)
  raw=unpack(packed['uv'],True)
  if len(raw)>=len(positions)*2:uv=list(zip(*[iter(raw[:len(positions)*2])]*2))
  raw=unpack(packed['normals'],True);signs=unpack(packed['normal_signs'])
  if len(raw)>=len(positions)*2 and len(signs)>=len(positions):
   for i in range(len(positions)):
    x,y=raw[i*2:i*2+2];z=math.sqrt(max(0,1-x*x-y*y))*(1 if signs[i] else -1);normals.append((x,y,z))
  triangles=unpack(packed['triangles']);isize=2 if out['index_format']==0 else 4;indices=struct.pack('<'+('H' if isize==2 else 'I')*len(triangles),*triangles)
 if positions:
  lines=['# Original mesh recovered from '+filename+' pathID '+str(row['path_id']),'o '+safe_name(row['name'])]
  lines += ['v '+' '.join(format(x,'.9g')for x in p)for p in positions]
  lines += ['vt '+' '.join(format(x,'.9g')for x in p)for p in uv]
  lines += ['vn '+' '.join(format(x,'.9g')for x in p)for p in normals]
  isize=2 if out['index_format']==0 else 4;icode='H' if isize==2 else 'I';face_count=0
  for si,s in enumerate(out['submeshes']):
   lines.append('g submesh_'+str(si))
   if s['topology']!=0:continue
   for i in range(0,s['index_count']-2,3):
    start=s['first_byte']+i*isize;tri=struct.unpack('<'+icode*3,indices[start:start+isize*3]);tri=[v+s['base_vertex']+1 for v in tri]
    if any(v>len(positions)for v in tri):raise ValueError('Mesh index exceeds vertex count')
    face=lambda v:f'{v}/{v}/{v}' if uv and normals else f'{v}//{v}' if normals else f'{v}/{v}' if uv else str(v)
    lines.append('f '+' '.join(face(v)for v in tri));face_count+=1
  (dest/(stem+'.obj')).write_text('\n'.join(lines)+'\n',encoding='utf8');out['obj_export']='meshes/'+stem+'.obj';out['triangle_count']=face_count
 return out

def png_rgba(w,h,pixels):
 def chunk(kind,data):return struct.pack('>I',len(data))+kind+data+struct.pack('>I',binascii.crc32(kind+data)&0xffffffff)
 raw=b''.join(b'\0'+pixels[y*w*4:(y+1)*w*4] for y in range(h-1,-1,-1))
 return b'\x89PNG\r\n\x1a\n'+chunk(b'IHDR',struct.pack('>IIBBBBB',w,h,8,6,0,0,0))+chunk(b'IDAT',zlib.compress(raw))+chunk(b'IEND',b'')
def decode_texture(row,data):
 w,h,fmt=row['width'],row['height'],row['format']
 if not(0<w<=8192 and 0<h<=8192):return None
 size=w*h;rgba=bytearray(size*4)
 if fmt==4 and len(data)>=size*4:rgba[:]=data[:size*4]
 elif fmt==3 and len(data)>=size*3:
  for i in range(size):rgba[i*4:i*4+4]=data[i*3:i*3+3]+b'\xff'
 elif fmt==1 and len(data)>=size:
  for i in range(size):rgba[i*4:i*4+4]=b'\xff\xff\xff'+bytes([data[i]])
 elif fmt==2 and len(data)>=size*2:
  for i in range(size):
   word=int.from_bytes(data[i*2:i*2+2],'little');rgba[i*4:i*4+4]=bytes([(word>>8&15)*17,(word>>4&15)*17,(word&15)*17,(word>>12&15)*17])
 elif fmt==14 and len(data)>=size*4:
  for i in range(size):p=data[i*4:i*4+4];rgba[i*4:i*4+4]=bytes([p[2],p[1],p[0],p[3]])
 elif fmt in (10,12):
  # DXT1 / DXT5 block decoding, keeping top mip only.
  blocksize=8 if fmt==10 else 16;off=0
  for by in range((h+3)//4):
   for bx in range((w+3)//4):
    block=data[off:off+blocksize];off+=blocksize
    if len(block)!=blocksize:return None
    alpha=[255]*16
    if fmt==12:
     a0,a1=block[:2];table=[a0,a1]
     if a0>a1:table += [((7-i)*a0+i*a1)//7 for i in range(1,7)]
     else:table += [((5-i)*a0+i*a1)//5 for i in range(1,5)]+[0,255]
     indices=int.from_bytes(block[2:8],'little');alpha=[table[(indices>>(3*i))&7] for i in range(16)];block=block[8:]
    c0,c1,indices=struct.unpack('<HHI',block)
    def rgb(c):return [(c>>11&31)*255//31,(c>>5&63)*255//63,(c&31)*255//31,255]
    a,b=rgb(c0),rgb(c1);colors=[a,b]
    if c0>c1 or fmt==12:colors += [[(2*a[k]+b[k])//3 for k in range(3)]+[255],[(a[k]+2*b[k])//3 for k in range(3)]+[255]]
    else:colors += [[(a[k]+b[k])//2 for k in range(3)]+[255],[0,0,0,0]]
    for iy in range(4):
     for ix in range(4):
      x,y=bx*4+ix,by*4+iy;i=iy*4+ix
      if x<w and y<h:
       color=colors[(indices>>(2*i))&3].copy();color[3]=alpha[i] if fmt==12 else color[3];rgba[(y*w+x)*4:(y*w+x)*4+4]=bytes(color)
 else:return None
 return png_rgba(w,h,rgba)

def main():
 nodes=unpack_bundle(Path('analysis/extracted/data.unity3d'))
 result=[]
 paths=[OUT/'bundle'/n['name'] for n in nodes if not n['name'].endswith(('.resource','.resS'))]
 paths.append(Path('analysis/extracted/Resources/unity default resources'))
 for p in paths:
  try:
   meta,b=serialized(p);dump(Path('serialized')/(p.name+'.json'),meta);decoded=asset_data(meta,b);result.append({k:meta[k] for k in ['path','bytes','version','unity','type_tree_enabled','data_offset','metadata_end'] }|{'objects':len(meta['objects']),'types':len(meta['types']),'class_counts':dict(collections.Counter(x['class_id'] for x in meta['objects'])),'decoded':decoded})
  except Exception as e:result.append(dict(path=p.name,error=str(e)))
 dump(Path('serialized-summary.json'),result);print(json.dumps(result,indent=2))
if __name__=='__main__':main()
