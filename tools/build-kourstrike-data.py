"""Prepare a derived KourStrike startup archive; preserve every original input."""
from pathlib import Path
import hashlib,struct,json,importlib.util
ROOT=Path(__file__).resolve().parent.parent
spec=importlib.util.spec_from_file_location('asset_reader',ROOT/'tools/inspect-assets.py')
a=importlib.util.module_from_spec(spec);spec.loader.exec_module(a)
sha=lambda b:hashlib.sha256(b).hexdigest()
original=(ROOT/'game.data').read_bytes()
if sha(original)!='77b76d5dfdee9e4a587fa69c22982bb72ef486f297a7dc2a9c252d4331e5a739':raise ValueError('Unknown input game.data')
header=struct.unpack_from('<I',original,16)[0];p=20;members=[]
while p<header:
 offset,size,length=struct.unpack_from('<III',original,p);p+=12;name=original[p:p+length].decode();p+=length
 members.append(dict(name=name,data=original[offset:offset+size]))
bundle=next(x for x in members if x['name']=='data.unity3d');b=bundle['data'];r=a.Reader(b)
signature=r.cstr();version=r.u32();unity=r.cstr();revision=r.cstr();oldsize=r.u64();compressed=r.u32();rawsize=r.u32();flags=r.u32()
if signature!='UnityFS' or version!=8 or oldsize!=len(b):raise ValueError('Unexpected UnityFS source')
r.align(16)
info=a.decompress(b[-compressed:],rawsize,flags) if flags&128 else a.decompress(r.read(compressed),rawsize,flags)
if flags&512:r.align(16)
ir=a.Reader(info);ir.read(16);blocks=[]
for _ in range(ir.i32()):blocks.append((ir.u32(),ir.u32(),ir.num('H')))
nodes=[]
for _ in range(ir.i32()):nodes.append(dict(offset=ir.u64(),size=ir.u64(),flags=ir.u32(),name=ir.cstr()))
payload=bytearray(b''.join(a.decompress(r.read(size),raw,flag)for raw,size,flag in blocks))
level=next(n for n in nodes if n['name']=='level0');start=level['offset'];end=start+level['size']
if sha(payload[start:end])!='206cd64ac0b60f1bcf68801f55a343dae1cb3f473b0b48179f3ea493c6acefa6':raise ValueError('Unknown lobby scene')
sdk_offset=458856
if struct.unpack_from('<i',payload,start+sdk_offset)[0]!=0:raise ValueError('Expected original Kour variant')
struct.pack_into('<i',payload,start+sdk_offset,1)
# UnityFS uncompressed blocks, combined directory, aligned block data.
directory=hashlib.md5(payload).digest()+struct.pack('>I',1)+struct.pack('>IIH',len(payload),len(payload),0)+struct.pack('>I',len(nodes))
for n in nodes:directory+=struct.pack('>QQI',n['offset'],n['size'],n['flags'])+n['name'].encode()+b'\0'
def make_header(size):
 h=b'UnityFS\0'+struct.pack('>I',version)+unity.encode()+b'\0'+revision.encode()+b'\0'+struct.pack('>QIII',size,len(directory),len(directory),0x240)
 return h+b'\0'*((-len(h))%16)
h=make_header(0);padding=b'\0'*((-(len(h)+len(directory)))%16)
rebuilt=make_header(len(h)+len(directory)+len(padding)+len(payload))+directory+padding+payload
bundle['data']=rebuilt
table_size=20+sum(12+len(m['name'].encode())for m in members);offset=table_size;table=b'';content=b''
for m in members:
 name=m['name'].encode();table+=struct.pack('<III',offset,len(m['data']),len(name))+name;content+=m['data'];offset+=len(m['data'])
derived=b'UnityWebData1.0\0'+struct.pack('<I',table_size)+table+content
out=ROOT/'original-preview/generated';out.mkdir(exist_ok=True)
manifest=dict(profile='kourstrike',gameType=1,gameMode=8,gameModeName='Search And Destroy',roomMapIndex=8,mapName='Kour2',bundle='map7',input_sha256=sha(original),output_sha256=sha(derived),builder_sha256=sha(Path(__file__).read_bytes()),original_modified=False,scene='level0',scene_field_offset=sdk_offset,scene_field_before=0,scene_field_after=1,member_count=len(members),bytes=len(derived))
(out/'kourstrike.data').write_bytes(derived);(out/'kourstrike-data.json').write_text(json.dumps(manifest,indent=2),encoding='utf8')
print(json.dumps(manifest))
