"""Link IL2CPP method tokens to Wasm table slots and decode selected bodies.

All inputs are static local files. Output is disassembly, not original C#.
Unsupported opcodes stop a body instead of guessing subsequent boundaries.
"""
import collections
import hashlib
import json
import math
import pathlib
import struct

ROOT=pathlib.Path(__file__).resolve().parent.parent
OUT=ROOT/'analysis'
wasm=(ROOT/'source.wasm').read_bytes()
metadata=(OUT/'global-metadata.dat').read_bytes()
inventory=json.loads((OUT/'wasm-inventory.json').read_text())
functions=json.loads((OUT/'wasm-functions.json').read_text())
interface=json.loads((OUT/'wasm-interface.json').read_text())
codegen=json.loads((OUT/'wasm-codegen.json').read_text())
memory=(OUT/'wasm-initialized-memory.bin').read_bytes()
func_by_index={f['index']:f for f in functions}
module_by_name={m['image']:m for m in codegen}


def u32(b,p):return struct.unpack_from('<I',b,p)[0]
def text_at(b,p):
    if p<0 or p>=len(b):return None
    stop=b.find(b'\0',p,min(len(b),p+4000))
    if stop<0:return None
    try:return b[p:stop].decode('utf-8')
    except UnicodeDecodeError:return None


# v31 header has 31 offset/size pairs. Validated against REA collection totals.
assert u32(metadata,0)==0xfab11baf and u32(metadata,4)==31
pairs=[struct.unpack_from('<II',metadata,8+i*8) for i in range(31)]
strings_offset=pairs[2][0]
method_offset,method_bytes=pairs[5]
type_offset,type_bytes=pairs[19]
image_offset,image_bytes=pairs[20]
assert method_bytes//36==74584 and type_bytes//88==10670 and image_bytes//40==73
images=[]
for i in range(image_bytes//40):
    words=struct.unpack_from('<10I',metadata,image_offset+40*i)
    images.append({'index':i,'name':text_at(metadata,strings_offset+words[0]),'type_start':words[2],'type_count':words[3]})
type_rows=[]
for i in range(type_bytes//88):
    words=struct.unpack_from('<22I',metadata,type_offset+i*88)
    type_rows.append({'index':i,'name':text_at(metadata,strings_offset+words[0]),'namespace':text_at(metadata,strings_offset+words[1])})
image_by_type={t:im for im in images for t in range(im['type_start'],im['type_start']+im['type_count'])}
methods=[]
by_func=collections.defaultdict(list)
for i in range(method_bytes//36):
    vals=struct.unpack_from('<7I4H',metadata,method_offset+i*36)
    name,owner,returntype,returntoken,paramstart,generic,token,flags,iflags,slot,paramcount=vals
    image=image_by_type[owner]
    type_=type_rows[owner]
    mod=module_by_name.get(image['name'])
    rid=token&0xffffff
    pointer=mod['methods'][rid-1] if mod and 1<=rid<=len(mod['methods']) else None
    entry={'metadata_index':i,'name':name and text_at(metadata,strings_offset+name) or text_at(metadata,strings_offset),'declaring_type_index':owner,'type':type_['name'],'namespace':type_['namespace'],'image':image['name'],'token':hex(token),'token_rid':rid,'flags':flags,'implementation_flags':iflags,'slot':slot,'parameter_count':paramcount,'parameter_start':paramstart,'return_type_index':returntype,'function_table_index':pointer['table_index'] if pointer else None,'function_index':pointer['function_index'] if pointer else None}
    methods.append(entry)
    if pointer and pointer['function_index'] is not None:by_func[pointer['function_index']].append(entry)

simple={0:'unreachable',1:'nop',5:'else',0x0b:'end',0x0f:'return',0x1a:'drop',0x1b:'select',0xd1:'ref.is_null'}
control={2:'block',3:'loop',4:'if',0x0c:'br',0x0d:'br_if',0x0e:'br_table',0x10:'call',0x11:'call_indirect',0x12:'return_call',0x13:'return_call_indirect',0x20:'local.get',0x21:'local.set',0x22:'local.tee',0x23:'global.get',0x24:'global.set',0x25:'table.get',0x26:'table.set',0xd0:'ref.null',0xd2:'ref.func'}
memory_names=['i32.load','i64.load','f32.load','f64.load','i32.load8_s','i32.load8_u','i32.load16_s','i32.load16_u','i64.load8_s','i64.load8_u','i64.load16_s','i64.load16_u','i64.load32_s','i64.load32_u','i32.store','i64.store','f32.store','f64.store','i32.store8','i32.store16','i64.store8','i64.store16','i64.store32']
numeric_names='i32.eqz i32.eq i32.ne i32.lt_s i32.lt_u i32.gt_s i32.gt_u i32.le_s i32.le_u i32.ge_s i32.ge_u i64.eqz i64.eq i64.ne i64.lt_s i64.lt_u i64.gt_s i64.gt_u i64.le_s i64.le_u i64.ge_s i64.ge_u f32.eq f32.ne f32.lt f32.gt f32.le f32.ge f64.eq f64.ne f64.lt f64.gt f64.le f64.ge i32.clz i32.ctz i32.popcnt i32.add i32.sub i32.mul i32.div_s i32.div_u i32.rem_s i32.rem_u i32.and i32.or i32.xor i32.shl i32.shr_s i32.shr_u i32.rotl i32.rotr i64.clz i64.ctz i64.popcnt i64.add i64.sub i64.mul i64.div_s i64.div_u i64.rem_s i64.rem_u i64.and i64.or i64.xor i64.shl i64.shr_s i64.shr_u i64.rotl i64.rotr f32.abs f32.neg f32.ceil f32.floor f32.trunc f32.nearest f32.sqrt f32.add f32.sub f32.mul f32.div f32.min f32.max f32.copysign f64.abs f64.neg f64.ceil f64.floor f64.trunc f64.nearest f64.sqrt f64.add f64.sub f64.mul f64.div f64.min f64.max f64.copysign i32.wrap_i64 i32.trunc_f32_s i32.trunc_f32_u i32.trunc_f64_s i32.trunc_f64_u i64.extend_i32_s i64.extend_i32_u i64.trunc_f32_s i64.trunc_f32_u i64.trunc_f64_s i64.trunc_f64_u f32.convert_i32_s f32.convert_i32_u f32.convert_i64_s f32.convert_i64_u f32.demote_f64 f64.convert_i32_s f64.convert_i32_u f64.convert_i64_s f64.convert_i64_u f64.promote_f32 i32.reinterpret_f32 i64.reinterpret_f64 f32.reinterpret_i32 f64.reinterpret_i64 i32.extend8_s i32.extend16_s i64.extend8_s i64.extend16_s i64.extend32_s'.split()
numeric={0x45+i:n for i,n in enumerate(numeric_names)}


class Reader:
    def __init__(self,start,end):self.p,self.end=start,end
    def byte(self):
        if self.p>=self.end:raise ValueError('Instruction outside body')
        v=wasm[self.p];self.p+=1;return v
    def take(self,n):
        if self.p+n>self.end:raise ValueError('Immediate outside body')
        v=wasm[self.p:self.p+n];self.p+=n;return v
    def uint(self):
        v=s=0
        for _ in range(10):
            n=self.byte();v|=(n&127)<<s
            if n<128:return v
            s+=7
        raise ValueError('Overlong integer')
    def sint(self):
        v=s=0
        for _ in range(10):
            n=self.byte();v|=(n&127)<<s;s+=7
            if n<128:return v-(1<<s) if n&64 else v
        raise ValueError('Overlong integer')


def decode(index):
    f=func_by_index.get(index)
    if not f:return {'index':index,'status':'import'}
    r=Reader(f['code_offset'],f['end_offset'])
    ops=[]
    status='complete'
    try:
        while r.p<r.end:
            pos=r.p;op=r.byte();item={'offset':pos}
            if op in simple:item['op']=simple[op]
            elif op in control:
                item['op']=control[op]
                if op in (2,3,4,0xd0):item['immediate']=r.sint()
                elif op in (0x11,0x13):item.update(type_index=r.uint(),table_index=r.uint())
                elif op==0x0e:item.update(labels=[r.uint() for _ in range(r.uint())],default=r.uint())
                else:item['immediate']=r.uint()
                if op in (0x10,0x12):
                    aliases=by_func.get(item['immediate'],[])
                    if aliases:item['method_candidates']=[a['type']+'::'+a['name'] for a in aliases[:12]]
                    elif item['immediate']<len(interface['imports']):
                        imp=interface['imports'][item['immediate']]
                        item['import']=imp['module']+'.'+imp['name']
            elif 0x28<=op<=0x3e:
                item.update(op=memory_names[op-0x28],align=r.uint(),memory_offset=r.uint())
            elif op in (0x3f,0x40):item.update(op='memory.size' if op==0x3f else 'memory.grow',memory_index=r.uint())
            elif op in (0x41,0x42):item.update(op='i32.const' if op==0x41 else 'i64.const',immediate=r.sint())
            elif op in (0x43,0x44):
                value=struct.unpack('<f' if op==0x43 else '<d',r.take(4 if op==0x43 else 8))[0]
                item.update(op='f32.const' if op==0x43 else 'f64.const',immediate=value if math.isfinite(value) else str(value))
            elif op in numeric:item['op']=numeric[op]
            elif op==0x1c:item.update(op='select_t',types=[r.byte() for _ in range(r.uint())])
            elif op==0xfc:
                sub=r.uint()
                if sub<=7:item.update(op=['i32.trunc_sat_f32_s','i32.trunc_sat_f32_u','i32.trunc_sat_f64_s','i32.trunc_sat_f64_u','i64.trunc_sat_f32_s','i64.trunc_sat_f32_u','i64.trunc_sat_f64_s','i64.trunc_sat_f64_u'][sub])
                elif sub==8:item.update(op='memory.init',data_index=r.uint(),memory_index=r.uint())
                elif sub==9:item.update(op='data.drop',data_index=r.uint())
                elif sub==10:item.update(op='memory.copy',dst_memory=r.uint(),src_memory=r.uint())
                elif sub==11:item.update(op='memory.fill',memory_index=r.uint())
                elif sub==12:item.update(op='table.init',element_index=r.uint(),table_index=r.uint())
                elif sub==13:item.update(op='elem.drop',element_index=r.uint())
                elif sub==14:item.update(op='table.copy',dst_table=r.uint(),src_table=r.uint())
                elif sub in (15,16,17):item.update(op={15:'table.grow',16:'table.size',17:'table.fill'}[sub],table_index=r.uint())
                else:raise ValueError(f'Unsupported prefixed opcode fc:{sub}')
            else:raise ValueError(f'Unsupported opcode 0x{op:02x} at {pos}')
            ops.append(item)
    except ValueError as err:status=str(err)
    return {'index':index,'signature':interface['types'][f['type_index']],**f,'status':status,'instructions':ops}


game_methods=[m for m in methods if m['image']=='Assembly-CSharp.dll']
assert len(game_methods)==4833
assert all(m['token_rid']==i+1 for i,m in enumerate(game_methods))
assert all(m['function_index'] is None or m['function_index'] in func_by_index for m in game_methods)
selected_types={'PlayerController','Weapon','WeaponCarrier','AimableWeapon','BurstWeapon','Shotgun','Minigun','Bullet','NetworkManager','PlayerInputHandler','SmoothPlayerCamera','Health','PlayerHealth','Settings','GameSettings','MapSettings','Class','WeaponClass','WeaponCarrierData','Shooter','Recoil','Sniper','RocketLauncher','Rocket','Grenade','WorldGrenade','WorldBomb','Bomb','Knife','Flamethrower','KourBot','GameMode','SearchAndDestroyManager','HardpointManager','HardpointArea','BattleRoyaleManager','ZoneManager','JumpPad','MapConfig','MapSettings','CameraConfig','NewInputManager','KeybindManager','OptionsMenu','SettingsPanel','StepsManager','TeamMember','GunGameProgress','CharacterAnimatorManager'}
selected=[m for m in game_methods if m['type'] in selected_types or m['type'] in {'<IenuReload>d__121','<IenuShootAgain>d__114','<IenuRegenHealth>d__41'}]
decoded={m['function_index']:decode(m['function_index']) for m in selected if m['function_index'] is not None}
output={'method':'Metadata v31 tokens -> codegen module method pointers -> active Wasm element table -> function body offsets','wasm_sha256':inventory['artifact']['sha256'],'metadata_sha256':hashlib.sha256(metadata).hexdigest(),'all_game_methods':len(game_methods),'selected_method_count':len(selected),'decoded_function_count':len(decoded),'methods':selected,'functions':list(decoded.values()),'limitations':['Method names and tokens read from exact metadata bytes; table registration candidates validated structurally, not through execution.','Function bodies may be shared across names; each call shows candidate names rather than claiming unique identity.','Disassembly is structured instruction decoding, not decompiled C# or a recovered Unity project.','Scalar field load/store offsets are not named without native field-offset registration mapping.']}
(OUT/'wasm-method-map.json').write_text(json.dumps(methods,indent=2),encoding='utf-8')
(OUT/'wasm-gameplay-disassembly.json').write_text(json.dumps(output,indent=2),encoding='utf-8')
lines=['# Selected gameplay WebAssembly disassembly','','Static token/table linkage; not original C# source.','','```text']
for m in selected:
    f=decoded.get(m['function_index'])
    lines.append(f"\n;; {m['type']}::{m['name']} metadata[{m['metadata_index']}] token {m['token']} table[{m['function_table_index']}] func[{m['function_index']}]")
    if not f:lines.append(';; No compiled body in this module');continue
    lines.append(f";; signature {f['signature']} body [{f['body_offset']}, {f['end_offset']}) {f['body_bytes']} bytes; {f['status']}")
    indent=0
    for op in f['instructions']:
        if op['op'] in ('end','else'):indent=max(0,indent-1)
        args=' '.join(str(v) for k,v in op.items() if k not in ('offset','op','method_candidates','import'))
        annotation=' ; '+', '.join(op['method_candidates']) if 'method_candidates' in op else ' ; '+op['import'] if 'import' in op else ''
        lines.append(f"{op['offset']:08x} {'  '*indent}{op['op']} {args}{annotation}".rstrip())
        if op['op'] in ('block','loop','if','else'):indent+=1
lines.extend(['```',''])
(OUT/'wasm-gameplay-disassembly.md').write_text('\n'.join(lines),encoding='utf-8')
print(json.dumps({'game_methods':len(game_methods),'selected':len(selected),'functions':len(decoded),'complete':sum(f['status']=='complete' for f in decoded.values()),'sample_mappings':[{k:m[k] for k in ('type','name','metadata_index','token','function_table_index','function_index')} for m in selected if m['type']=='PlayerController'],'failures':[{k:f[k] for k in ('index','status')} for f in decoded.values() if f['status']!='complete']},indent=2))
