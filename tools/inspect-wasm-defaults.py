"""Recover primitive constructor writes and annotate core Wasm field accesses."""
import collections
import json
import pathlib
import struct

ROOT=pathlib.Path(__file__).resolve().parent.parent
OUT=ROOT/'analysis'
memory=(OUT/'wasm-initialized-memory.bin').read_bytes()
metadata=(OUT/'global-metadata.dat').read_bytes()
disassembly=json.loads((OUT/'wasm-gameplay-disassembly.json').read_text())
u32=lambda b,p:struct.unpack_from('<I',b,p)[0]
text=lambda p:metadata[p:metadata.index(b'\0',p)].decode('utf-8')
pairs=[struct.unpack_from('<II',metadata,8+i*8) for i in range(31)]
strings=pairs[2][0]
types_offset,types_bytes=pairs[19]
fields_offset,fields_bytes=pairs[11]

# Discover the count/pointer signature instead of assuming a fixed location.
candidates=[]
needle=struct.pack('<I',10670)
p=0
while True:
    p=memory.find(needle,p)
    if p<0:break
    if p%4==0 and p>=40 and p+28<len(memory) and u32(memory,p+8)==10670:
        words=struct.unpack_from('<16I',memory,p-40)
        if words[6]>10670 and words[7]+words[6]*4<=len(memory):
            candidates.append({'address':p-40,'words':words})
    p+=1
assert len(candidates)==1
reg=candidates[0]
types_count,types_array,field_offsets_count,field_offsets_array=reg['words'][6],reg['words'][7],reg['words'][10],reg['words'][11]
type_info=[]
for i in range(types_count):
    address=u32(memory,types_array+i*4)
    assert address+8<=len(memory)
    data,bits=struct.unpack_from('<II',memory,address)
    type_info.append({'index':i,'address':address,'data':data,'bits':bits,'type_code':(bits>>16)&255,'attributes':bits&65535,'byref':bool(bits&(1<<29))})

primitive={1:('void',0,None),2:('bool',1,'?'),3:('char',2,'H'),4:('sbyte',1,'b'),5:('byte',1,'B'),6:('short',2,'h'),7:('ushort',2,'H'),8:('int',4,'i'),9:('uint',4,'I'),10:('long',8,'q'),11:('ulong',8,'Q'),12:('float',4,'f'),13:('double',8,'d')}
type_names=[]
type_fields=[]
for i in range(types_bytes//88):
    offset=types_offset+i*88
    name=text(strings+u32(metadata,offset))
    type_names.append(name)
    fieldstart=u32(metadata,offset+32)
    fieldcount=struct.unpack_from('<H',metadata,offset+68)[0]
    offsets_pointer=u32(memory,field_offsets_array+i*4)
    rows=[]
    for j in range(fieldcount):
        fieldindex=fieldstart+j
        name_i,type_i,token=struct.unpack_from('<III',metadata,fields_offset+fieldindex*12)
        ti=type_info[type_i]
        rows.append({'metadata_field_index':fieldindex,'name':text(strings+name_i),'type_index':type_i,'type_code':ti['type_code'],'type_data':ti['data'],'type':primitive.get(ti['type_code'],('typecode_'+str(ti['type_code']),0,None))[0],'attributes':ti['attributes'],'static':bool(ti['attributes']&16),'literal':bool(ti['attributes']&64),'offset':u32(memory,offsets_pointer+j*4) if offsets_pointer else None})
    type_fields.append(rows)

function_by_index={f['index']:f for f in disassembly['functions']}
constructors=[]
for method in disassembly['methods']:
    if method['name']!='.ctor':continue
    f=function_by_index.get(method['function_index'])
    if not f:continue
    rows=type_fields[method['declaring_type_index']]
    stores=[]
    ops=f['instructions']
    for i in range(2,len(ops)):
        a,b,c=ops[i-2:i+1]
        if a['op']!='local.get' or a.get('immediate')!=0 or not b['op'].endswith('.const') or '.store' not in c['op']:continue
        try:
            value=b['immediate']
            if b['op']=='i64.const':raw=(value&((1<<64)-1)).to_bytes(8,'little')
            elif b['op']=='i32.const':raw=(value&0xffffffff).to_bytes(4,'little')
            elif b['op']=='f32.const':raw=struct.pack('<f',value)
            elif b['op']=='f64.const':raw=struct.pack('<d',value)
            else:continue
            width={'i32.store8':1,'i32.store16':2,'i64.store8':1,'i64.store16':2,'i64.store32':4}.get(c['op'],8 if c['op'].startswith(('i64','f64')) else 4)
            raw=raw[:width]
            base=c['memory_offset']
            recovered=[]
            for field in rows:
                if field['static'] or field['literal'] or field['offset'] is None:continue
                primitive_info=primitive.get(field['type_code'])
                if not primitive_info or not primitive_info[2]:continue
                typename,size,fmt=primitive_info
                start=field['offset']-base
                if 0<=start and start+size<=len(raw):
                    parsed=struct.unpack_from('<'+fmt,raw,start)[0]
                    recovered.append({'field':field['name'],'field_index':field['metadata_field_index'],'type':typename,'field_offset':field['offset'],'value':parsed})
            stores.append({'instruction_offset':c['offset'],'store_op':c['op'],'object_offset':base,'constant_bytes':raw.hex(),'recovered_fields':recovered})
        except (struct.error,OverflowError):continue
    if stores:constructors.append({'type':method['type'],'method_index':method['metadata_index'],'function_index':method['function_index'],'stores':stores})

registration={'method':'A unique initialized-memory record contains fieldOffsetsCount==typeDefinitionsSizesCount==10670 matching exact metadata type count; typesCount/pointer range checked and every Il2CppType pointer in bounds.','address':reg['address'],'record_pairs':[{'count':reg['words'][i],'pointer':reg['words'][i+1]} for i in range(0,16,2)],'type_code_histogram':dict(collections.Counter(t['type_code'] for t in type_info)),'limitations':['Metadata registration identity is structurally inferred; no registration function executed.','Field offsets describe this 32-bit WebAssembly build only.','Constructor values are code defaults; Unity serialized assets, map settings, options and runtime overrides can replace them.']}
(OUT/'wasm-metadata-registration.json').write_text(json.dumps(registration,indent=2),encoding='utf-8')
(OUT/'wasm-il2cpp-types.json').write_text(json.dumps(type_info,indent=2),encoding='utf-8')
(OUT/'wasm-field-layouts.json').write_text(json.dumps([{'index':i,'name':type_names[i],'fields':fields} for i,fields in enumerate(type_fields)],indent=2),encoding='utf-8')
(OUT/'wasm-constructor-defaults.json').write_text(json.dumps({'constructors':constructors,'limitations':registration['limitations']},indent=2),encoding='utf-8')
lines=['# Recovered constructor defaults','','These values are direct constant stores in named compiled constructors, interpreted with IL2CPP field types and offsets. They are **code defaults**, not measured gameplay settings; serialized assets and runtime settings may override them.','','| Class | Field | Type | Default | Wasm instruction byte offset |','|---|---|---|---:|---:|']
for ctor in constructors:
    for store in ctor['stores']:
        for field in store['recovered_fields']:
            lines.append(f"| {ctor['type']} | {field['field']} | {field['type']} | {field['value']} | {store['instruction_offset']} |")
lines.append('')
(OUT/'wasm-constructor-defaults.md').write_text('\n'.join(lines),encoding='utf-8')
print(json.dumps({'registration':registration,'constructor_count':len(constructors),'defaults':sum(len(s['recovered_fields']) for c in constructors for s in c['stores']),'player_defaults':[field for c in constructors if c['type']=='PlayerController' for store in c['stores'] for field in store['recovered_fields']]},indent=2))
