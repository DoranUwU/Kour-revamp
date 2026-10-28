"""Focused offline method disassembly for the original KourStrike bootstrap."""
import json
import pathlib
import struct

root=pathlib.Path(__file__).resolve().parent.parent
ns={'__file__':str(root/'tools/inspect-wasm-methods.py')}
exec((root/'tools/inspect-wasm-methods.py').read_text().split('\ngame_methods=')[0],ns)
memory=ns['memory'];metadata=ns['metadata'];methods=ns['methods']
literal_offset=struct.unpack_from('<I',metadata,8)[0]
literal_data=struct.unpack_from('<I',metadata,16)[0]
literal_count=struct.unpack_from('<I',metadata,12)[0]//8
def literal_at(address):
    if address<0 or address+4>len(memory):return None
    word=struct.unpack_from('<I',memory,address)[0]
    if word>>29!=5:return None
    index=(word&0x1fffffff)>>1
    if index>=literal_count:return None
    length,offset=struct.unpack_from('<II',metadata,literal_offset+index*8)
    return metadata[literal_data+offset:literal_data+offset+length].decode('utf-8',errors='replace')
wanted={
'AlltimeUIManager':{'SceneNameFromBuildIndex','.cctor'},
'SdkManager':{'Awake','.ctor'},
'NetworkManager':{'GetRoomGameMode','GetRoomMapBuildIndex','get_MOBILE_MAP','get_AUTOPLAY_MAPS','GetGameMode','GetGameModeFromIndex','SetCurrentGameMode','CreateCustom','PlayPressed','GetRoomOptions','OnJoinedRoom','OnJoinRandomFailed','OnGameSceneLoad','SpawnPlayer','OnDisconnected','.cctor'},
'StreamingAssetsLoader':{'StreamingAssetsPath','PrepareMap','PrepareMapString','LoadLevel','IenuLoadMapAndJoin','IenuLoadMap','LoadMapAndJoin','NowLoadLevel','MapNameToURL','LoadMapByName','IenuLoadMapByName'},
'UIManager':{'LoadScene','LoadForceMap','ForceSetGameMode','GoOfflineEmergency','CanPlay','PlayForce','PlayPressed'},
'HostPanel':{'HostButtonPressed','OnGameModeDropdownChanged','Init','KeepGameMode'},
'SearchAndDestroyManager':{'Start','Awake','OnGameplaySceneLoad','OnGameSceneLoad','Update','.ctor'},
'GameModeSelectPanel':{'OnChoseGameMode'},
}
selected=[m for m in methods if m['image']=='Assembly-CSharp.dll' and (m['name'] in wanted.get(m['type'],set()) or ('IenuLoadMap' in m['type'] and m['name']=='MoveNext'))]
records=[]
for m in selected:
    if m['function_index'] is None:continue
    f=ns['decode'](m['function_index'])
    for o in f.get('instructions',[]):
        if o['op']=='i32.const':
            value=literal_at(o['immediate'])
            if value is not None:o['literal_candidate']=value
    records.append({'method':m,'disassembly':f})
(root/'analysis/runtime/kourstrike-static-disassembly.json').write_text(json.dumps(records,indent=2),encoding='utf-8')
lines=['# KourStrike bootstrap focused disassembly','', 'Static original bytes; string annotations identify initialized metadata-literal references.','']
for rec in records:
    m=rec['method'];f=rec['disassembly'];lines.extend([f"## {m['type']}::{m['name']} func[{m['function_index']}]",'',f"Metadata index {m['metadata_index']}; flags {m['flags']}; code [{f.get('code_offset')},{f.get('end_offset')}); status {f['status']}",'','```text'])
    for o in f.get('instructions',[]):
        annotation=' // '+', '.join(o['method_candidates']) if 'method_candidates'in o else ' // '+o['import'] if 'import'in o else ''
        if 'literal_candidate'in o:annotation+=' // '+repr(o['literal_candidate'])
        args=' '.join(str(v)for k,v in o.items() if k not in ['offset','op','method_candidates','import','literal_candidate'])
        lines.append(f"{o['offset']}: {o['op']} {args}{annotation}")
    lines.extend(['```',''])
(root/'analysis/runtime/kourstrike-static-disassembly.md').write_text('\n'.join(lines),encoding='utf-8')
print(json.dumps([{'type':r['method']['type'],'name':r['method']['name'],'function_index':r['method']['function_index'],'body_bytes':r['disassembly'].get('body_bytes'),'status':r['disassembly']['status']} for r in records],indent=2))
