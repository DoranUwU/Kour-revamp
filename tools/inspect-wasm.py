"""Read-only WebAssembly inventory and IL2CPP codegen table candidate recovery.

No Wasm is instantiated/executed. The parser records source byte offsets and
decodes core section structure; it is not an upstream WABT validation substitute.
"""
import collections
import hashlib
import json
import pathlib
import re
import struct
import sys

ROOT = pathlib.Path(__file__).resolve().parent.parent
OUT = ROOT / 'analysis'
SOURCE = ROOT / (sys.argv[1] if len(sys.argv) > 1 else 'source.wasm')
blob = SOURCE.read_bytes()


class Reader:
    def __init__(self, b, start=0, end=None):
        self.b, self.p, self.end = b, start, len(b) if end is None else end

    def byte(self):
        if self.p >= self.end:
            raise ValueError(f'Unexpected end at {self.p}')
        v = self.b[self.p]
        self.p += 1
        return v

    def take(self, n):
        if n < 0 or self.p+n > self.end:
            raise ValueError(f'Invalid byte length {n} at {self.p}')
        v = self.b[self.p:self.p+n]
        self.p += n
        return v

    def uint(self):
        v = shift = 0
        for _ in range(10):
            n = self.byte()
            v |= (n & 127) << shift
            if n < 128:
                return v
            shift += 7
        raise ValueError('Overlong integer')

    def sint(self):
        v = shift = 0
        for _ in range(10):
            n = self.byte()
            v |= (n & 127) << shift
            shift += 7
            if n < 128:
                return v - (1 << shift) if n & 64 else v
        raise ValueError('Overlong signed integer')

    def name(self):
        return self.take(self.uint()).decode('utf-8', errors='replace')

    def limits(self):
        flags = self.uint()
        result = {'flags':flags, 'min':self.uint()}
        if flags & 1:
            result['max'] = self.uint()
        return result


valtypes={0x7f:'i32',0x7e:'i64',0x7d:'f32',0x7c:'f64',0x7b:'v128',0x70:'funcref',0x6f:'externref'}


def initializer(r):
    op = r.byte()
    if op in (0x41,0x42):
        result = {'op':'i32.const' if op==0x41 else 'i64.const','value':r.sint()}
    elif op==0x23:
        result={'op':'global.get','index':r.uint()}
    elif op==0xd0:
        result={'op':'ref.null','type':r.sint()}
    elif op==0xd2:
        result={'op':'ref.func','index':r.uint()}
    elif op==0x43:
        result={'op':'f32.const','value':struct.unpack('<f',r.take(4))[0]}
    elif op==0x44:
        result={'op':'f64.const','value':struct.unpack('<d',r.take(8))[0]}
    else:
        raise ValueError(f'Unsupported initializer opcode {op:02x}')
    if r.byte()!=0x0b:
        raise ValueError('Multi-op initializer not implemented')
    return result


assert blob[:8] == b'\0asm\x01\0\0\0', 'Expected Wasm version 1'
sections=[]
types=[]
imports=[]
exports=[]
func_types=[]
functions=[]
tables=[]
memories=[]
globals_=[]
elements=[]
data=[]
custom=[]
start_func=None
imported_funcs=0
r=Reader(blob,8)
section_names={0:'custom',1:'type',2:'import',3:'function',4:'table',5:'memory',6:'global',7:'export',8:'start',9:'element',10:'code',11:'data',12:'data_count',13:'tag'}
while r.p<r.end:
    section_offset=r.p
    sid=r.byte()
    size=r.uint()
    begin=r.p
    finish=begin+size
    q=Reader(blob,begin,finish)
    entry={'id':sid,'name':section_names.get(sid,'unknown'),'section_offset':section_offset,'payload_offset':begin,'bytes':size}
    sections.append(entry)
    if sid==0:
        name=q.name()
        custom.append({'name':name,'offset':q.p,'bytes':finish-q.p})
        entry['custom_name']=name
    elif sid==1:
        for _ in range(q.uint()):
            tag=q.byte()
            if tag!=0x60:raise ValueError('Non-function type')
            params=[valtypes[q.byte()] for _ in range(q.uint())]
            results=[valtypes[q.byte()] for _ in range(q.uint())]
            types.append({'params':params,'results':results})
    elif sid==2:
        for _ in range(q.uint()):
            item={'module':q.name(),'name':q.name()}
            kind=q.byte()
            item['kind']=['function','table','memory','global','tag'][kind]
            if kind==0:
                item.update(type_index=q.uint(),function_index=imported_funcs)
                imported_funcs+=1
            elif kind==1:
                item.update(element_type=valtypes[q.byte()],limits=q.limits())
            elif kind==2:
                item['limits']=q.limits()
            elif kind==3:
                item.update(value_type=valtypes[q.byte()],mutable=q.byte())
            elif kind==4:
                item.update(attribute=q.byte(),type_index=q.uint())
            imports.append(item)
    elif sid==3:
        func_types=[q.uint() for _ in range(q.uint())]
    elif sid==4:
        for _ in range(q.uint()):
            tables.append({'element_type':valtypes[q.byte()],'limits':q.limits()})
    elif sid==5:
        memories=[q.limits() for _ in range(q.uint())]
    elif sid==6:
        for _ in range(q.uint()):
            globals_.append({'type':valtypes[q.byte()],'mutable':q.byte(),'init':initializer(q)})
    elif sid==7:
        for _ in range(q.uint()):
            exports.append({'name':q.name(),'kind':['function','table','memory','global','tag'][q.byte()],'index':q.uint()})
    elif sid==8:
        start_func=q.uint()
    elif sid==9:
        for _ in range(q.uint()):
            flags=q.uint()
            table_index=q.uint() if flags in (2,6) else 0
            offset=initializer(q) if flags in (0,2,4,6) else None
            element_type=None
            if flags in (1,2,3):element_type=q.byte()
            elif flags in (5,6,7):element_type=q.byte()
            count=q.uint()
            vals=[initializer(q) for _ in range(count)] if flags>=4 else [q.uint() for _ in range(count)]
            elements.append({'flags':flags,'table_index':table_index,'offset':offset,'element_type':element_type,'functions':vals})
    elif sid==10:
        count=q.uint()
        for i in range(count):
            body_size=q.uint()
            body_start=q.p
            body_end=q.p+body_size
            if body_end>finish:raise ValueError('Code outside section')
            locals_=[]
            for _ in range(q.uint()):locals_.append({'count':q.uint(),'type':valtypes[q.byte()]})
            functions.append({'index':imported_funcs+i,'type_index':func_types[i],'body_offset':body_start,'code_offset':q.p,'end_offset':body_end,'body_bytes':body_size,'locals':locals_})
            q.p=body_end
    elif sid==11:
        for _ in range(q.uint()):
            flags=q.uint()
            memory_index=q.uint() if flags==2 else 0
            offset=initializer(q) if flags in (0,2) else None
            n=q.uint()
            pos=q.p
            q.take(n)
            data.append({'flags':flags,'memory_index':memory_index,'offset':offset,'file_offset':pos,'bytes':n})
    elif sid==12:
        entry['declared_data_count']=q.uint()
    if sid!=0 and q.p!=finish:
        entry['unparsed_bytes']=finish-q.p
    r.p=finish

# Produce an addressable view of initialized memory; no code or initializers run.
memory_end=max((d['offset']['value']+d['bytes'] for d in data if d['offset'] and d['offset']['op']=='i32.const'),default=0)
memory=bytearray(memory_end)
for d in data:
    if d['offset'] and d['offset']['op']=='i32.const':
        addr=d['offset']['value']
        memory[addr:addr+d['bytes']]=blob[d['file_offset']:d['file_offset']+d['bytes']]

def read_u32(address):
    if address<0 or address+4>len(memory):return None
    return struct.unpack_from('<I',memory,address)[0]

def cstring(address):
    if address is None or address<0 or address>=len(memory):return None
    end=memory.find(0,address,min(len(memory),address+300))
    if end<0:return None
    raw=memory[address:end]
    try:return raw.decode('utf-8')
    except UnicodeDecodeError:return None

function_table={}
for segment in elements:
    if segment['offset'] and segment['offset']['op']=='i32.const':
        for i,f in enumerate(segment['functions']):
            function_table[segment['offset']['value']+i]=f if isinstance(f,int) else f.get('index')

strings=[]
for match in re.finditer(rb'[\x20-\x7e]{5,}',memory):
    value=match.group().decode('ascii')
    strings.append({'memory_address':match.start(),'value':value})
image_names=[s for s in strings if re.fullmatch(r'[A-Za-z0-9_.-]+\.dll',s['value'])]
# LLVM can suffix-share image names: System.dll is inside Unity.InputSystem.dll.
# Seed exact metadata image names and search their NUL-terminated occurrences.
metadata_path=OUT/'global-metadata.dat'
if metadata_path.exists():
    md=metadata_path.read_bytes()
    if len(md)>=256 and struct.unpack_from('<II',md,0)==(0xfab11baf,31):
        string_base=struct.unpack_from('<I',md,24)[0]
        image_base,image_size=struct.unpack_from('<II',md,168)
        known={(s['memory_address'],s['value']) for s in image_names}
        for i in range(image_size//40):
            np=string_base+struct.unpack_from('<I',md,image_base+i*40)[0]
            name=md[np:md.index(b'\0',np)].decode('utf-8')
            pattern=name.encode()+b'\0'
            pos=0
            while True:
                pos=memory.find(pattern,pos)
                if pos<0:break
                if (pos,name) not in known:image_names.append({'memory_address':pos,'value':name});known.add((pos,name))
                pos+=1
codegen_candidates=[]
for item in image_names:
    address=item['memory_address']
    packed=struct.pack('<I',address)
    pos=0
    while True:
        pos=memory.find(packed,pos)
        if pos<0:break
        if pos%4==0:
            count=read_u32(pos+4)
            ptr=read_u32(pos+8)
            if count is not None and 0<=count<200000 and ptr is not None and ptr+4*count<=len(memory):
                vals=[read_u32(ptr+i*4) for i in range(count)]
                valid=sum(v==0 or v in function_table for v in vals)
                if valid==count and (any(vals) or count==0 and ptr==0 and all(read_u32(pos+4*i)==0 for i in range(1,17))):
                    codegen_candidates.append({'image':item['value'],'name_address':address,'module_address':pos,'method_pointer_count':count,'method_table_address':ptr,'nonzero_methods':sum(v!=0 for v in vals),'raw_module_words':[read_u32(pos+i*4) for i in range(24)],'methods':[{'token_rid':i+1,'table_index':v,'function_index':function_table.get(v)} for i,v in enumerate(vals)]})
        pos+=1

module_array_candidates=[]
module_addresses={c['module_address'] for c in codegen_candidates}
needle=struct.pack('<I',len(codegen_candidates))
pos=0
while True:
    pos=memory.find(needle,pos)
    if pos<0:break
    if pos%4==0:
        pointer=read_u32(pos+4)
        count=len(codegen_candidates)
        if pointer and pointer+count*4<=len(memory):
            addresses=[read_u32(pointer+i*4) for i in range(count)]
            if len(addresses)==len(set(addresses)) and set(addresses)==module_addresses:
                module_array_candidates.append({'count_field_address':pos,'count':count,'array_address':pointer,'module_addresses':addresses})
    pos+=1

for imp in imports:
    if imp['kind']=='function':imp['signature']=types[imp['type_index']]
for exp in exports:
    if exp['kind']=='function':
        index=exp['index']
        ti=imports[index]['type_index'] if index<imported_funcs else func_types[index-imported_funcs]
        exp['signature']=types[ti]

summary={'artifact':{'path':str(SOURCE),'bytes':len(blob),'sha256':hashlib.sha256(blob).hexdigest()},'method':'custom static section parser; does not execute Wasm','version':1,'sections':sections,'custom_sections':custom,'counts':{'types':len(types),'imports':len(imports),'imported_functions':imported_funcs,'defined_functions':len(functions),'exports':len(exports),'element_segments':len(elements),'function_table_entries':len(function_table),'data_segments':len(data),'ascii_strings':len(strings),'initialized_memory_bytes':len(memory)},'memories':memories,'tables':tables,'globals':globals_,'start_function':start_func,'data_segments':data,'codegen_modules':[{k:v for k,v in c.items() if k!='methods'} for c in codegen_candidates],'codegen_module_array_candidates':module_array_candidates,'limitations':['Core-section structure and IL2CPP codegen candidates are custom-parser output, not REA or WABT evidence.','No Wasm instantiation, original source reconstruction or runtime observation.','Codegen candidates use module-name pointers, table bounds and complete function-table membership checks; semantic linkage requires metadata tokens.','ASCII string inventory includes dependencies and diagnostic text; strings do not establish reachable functionality.']}
OUT.mkdir(exist_ok=True)
for name,obj in [('inventory',summary),('interface',{'imports':imports,'exports':exports,'types':types}),('functions',functions),('elements',elements),('strings',strings),('codegen',codegen_candidates)]:
    (OUT/f'wasm-{name}.json').write_text(json.dumps(obj,indent=2),encoding='utf-8')
(OUT/'wasm-initialized-memory.bin').write_bytes(memory)
print(json.dumps({'counts':summary['counts'],'custom_sections':custom,'memories':memories,'codegen_modules':[{k:c[k] for k in ('image','module_address','method_pointer_count','nonzero_methods')} for c in codegen_candidates]},indent=2))
