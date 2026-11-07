"""Retain exact user-authorized original default PNGs from exported REA evidence.

No network. Exact known native texture paths only; verify PNG chunks/CRC/data.
"""
from pathlib import Path
from urllib.parse import urlsplit
import json,hashlib,base64,struct,binascii,zlib,sys
ROOT=Path(__file__).resolve().parent.parent
allowed={'/content/stream/weapon-skins/texture/'+name+'.png'for name in ['mp5','awp','revolver','bomb','grenade','smoke','flash','molotov']}
evidence=Path(sys.argv[1]);bundle=json.loads(evidence.read_text(encoding='utf8'));saved=[]
for record in bundle['records']:
 if record['operation']!='capture_browser_scenario':continue
 result=record['normalized_result'];events=result.get('events',{}).get('items',[]);responses={x['transaction_id']:x for x in events if x.get('kind')=='response'}
 for event in events:
  if event.get('kind')!='network-content'or event.get('phase')!='response':continue
  response=responses.get(event['transaction_id']);body=event.get('body',{})
  if not response:continue
  url=response['url']['url'];p=urlsplit(url)
  if p.scheme!='https'or p.hostname!='kour.io'or p.path not in allowed:continue
  if response.get('status')!=200 or body.get('state')!='captured'or body.get('redacted')or body.get('encoding')!='base64':continue
  raw=base64.b64decode(body['content'],validate=True);sha=hashlib.sha256(raw).hexdigest()
  if len(raw)!=body['bytes']or sha!=body['sha256']:raise ValueError('Response identity mismatch')
  if raw[:8]!=b'\x89PNG\r\n\x1a\n':raise ValueError('Not PNG')
  pos=8;chunks=[];data=bytearray();ihdr=None
  while pos<len(raw):
   length=struct.unpack_from('>I',raw,pos)[0];kind=raw[pos+4:pos+8];payload=raw[pos+8:pos+8+length];crc=struct.unpack_from('>I',raw,pos+8+length)[0]
   if binascii.crc32(kind+payload)&0xffffffff!=crc:raise ValueError('PNG CRC mismatch')
   chunks.append(kind.decode('ascii'));pos+=length+12
   if kind==b'IHDR':ihdr=struct.unpack('>IIBBBBB',payload)
   if kind==b'IDAT':data.extend(payload)
   if kind==b'IEND':break
  if pos!=len(raw)or not ihdr or chunks[0]!='IHDR'or chunks[-1]!='IEND':raise ValueError('Incomplete PNG')
  w,h,bits,color,compression,filtering,interlace=ihdr
  if compression or filtering or interlace:raise ValueError('Unexpected PNG coding mode')
  channels={0:1,2:3,3:1,4:2,6:4}[color];expected=h*(1+(w*bits*channels+7)//8);inflated=zlib.decompress(data)
  if len(inflated)!=expected:raise ValueError('PNG payload length mismatch')
  destination=ROOT/'original-preview'/p.path.lstrip('/');destination.parent.mkdir(parents=True,exist_ok=True)
  if destination.exists()and destination.read_bytes()!=raw:raise ValueError('Refusing to replace different texture')
  destination.write_bytes(raw)
  saved.append({'source_url':url,'native_path':p.path,'local_path':str(destination.relative_to(ROOT)).replace('\\','/'),'status':200,'bytes':len(raw),'sha256':sha,'width':w,'height':h,'bit_depth':bits,'color_type':color,'png_chunks':chunks,'inflated_bytes':len(inflated),'body_representation':body['representation'],'body_redacted':False,'evidence_id':record['evidence_id'],'transaction_id':event['transaction_id'],'evidence_bundle':str(evidence).replace('\\','/'),'browser_cleanup':result.get('browser',{}).get('cleanup'),'purpose':'Exact original default weapon colors, no fabricated skin or online service execution.'})
out=ROOT/'analysis/runtime/default-weapon-texture-manifest.json'
existing=json.loads(out.read_text(encoding='utf8')).get('textures',[])if out.exists()else[]
merged={x['native_path']:x for x in existing if x['native_path']in allowed}
for row in saved:merged[row['native_path']]=row
if set(merged)!=allowed:raise ValueError('Missing selected PNG responses '+str(sorted(allowed-merged.keys())))
out.write_text(json.dumps({'textures':[merged[path]for path in sorted(merged)],'native_paths':sorted(allowed),'original_inputs_modified':False,'capture_scope':'Eight source-verified public static default weapon/equipment PNG files only. Responses are unresized original files, usable with native size query variants.'},indent=2),encoding='utf8')
print(json.dumps(saved,indent=2))
