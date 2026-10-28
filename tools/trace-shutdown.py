"""Find validated direct calls into the matching build's quit/URL APIs."""
import pathlib,json
root=pathlib.Path(__file__).resolve().parent.parent
source=(root/'tools/inspect-wasm-methods.py').read_text(encoding='utf8')
scope={'__file__':str(root/'tools/inspect-wasm-methods.py')}
exec(compile(source.split('\ngame_methods=')[0],str(root/'tools/inspect-wasm-methods.py'),'exec'),scope)
targets={72206,72207,72229,72230,74474}
def leb(n):
 out=bytearray()
 while True:
  v=n&127;n>>=7;out.append(v|(128 if n else 0))
  if not n:return bytes(out)
patterns=[b'\x10'+leb(i)for i in targets]
wasm=scope['wasm'];out=[]
for f in scope['functions']:
 raw=wasm[f['body_offset']:f['end_offset']]
 if not any(p in raw for p in patterns):continue
 decoded=scope['decode'](f['index'])
 hits=[op for op in decoded['instructions']if op['op']=='call'and op.get('immediate')in targets]
 if hits:out.append({'index':f['index'],'methods':scope['by_func'].get(f['index'],[]),'hits':hits,'disassembly':decoded})
(root/'analysis/runtime/shutdown-calls.json').write_text(json.dumps(out,indent=2),encoding='utf8')
print(json.dumps([{'index':f['index'],'methods':[m['type']+'::'+m['name']for m in f['methods']],'hits':f['hits']}for f in out],indent=2))
