// Pass this exported function directly to page.evaluate(readAudioState).
// It observes native player/Steps state and the existing WebAudio backend;
// no playback, movement, gain, mute or inventory state is changed.
export function readAudioState(){
 const m=window.originalModule;
 if(!m?.asm)return{ready:false,reason:'No Unity module'};
 const t=m.asm.__indirect_function_table,u32=p=>m.HEAPU32[p>>>2],f32=p=>m.HEAPF32[p>>>2],valid=p=>Number.isInteger(p)&&p>=1024&&p+128<m.HEAPU8.length;
 const text=p=>{if(!valid(p))return'';const n=u32(p+8);return n<=256?String.fromCharCode(...m.HEAPU16.subarray((p+12)>>>1,((p+12)>>>1)+n)):''};
 function api(slot,name){const fn=t.get(slot);if(fn.name!==name)throw Error('Unexpected native audio probe API '+slot);return fn}
 function string(value){const p=api(75048,'91484')(value.length,0);for(let i=0;i<value.length;i++)m.HEAPU16[((p+12)>>>1)+i]=value.charCodeAt(i);return p}
 function position(component,out){if(!valid(component))return null;const transform=api(2964,'83981')(component,0);api(2965,'82457')(out,transform,0);return Array.from(m.HEAPF32.subarray(out>>>2,(out>>>2)+3))}
 function clip(pointer){if(!valid(pointer))return null;return{pointer,name:text(api(3300,'84181')(pointer,0)),duration:api(38028,'73767')(pointer,0)}}
 function source(pointer,out){if(!valid(pointer))return null;return{pointer,position:position(pointer,out),clip:clip(api(38049,'73791')(pointer,0)),playing:!!api(38060,'73803')(pointer,0),volume:api(38045,'73787')(pointer,0),maxDistance:api(38067,'73815')(pointer,0)}}
 const backend=m.audioBackend,instances=backend?.audioInstances||{},channels=[],clips=[],bufferIds=new Map();
 for(const [id,entry]of Object.entries(instances))if(entry?.buffer&&!entry?.gain){const ids=bufferIds.get(entry.buffer)||[];ids.push(Number(id));bufferIds.set(entry.buffer,ids)}
 const param=(node,name,fallback)=>Number.isFinite(node?.[name]?.value)?node[name].value:Number.isFinite(node?.[fallback])?node[fallback]:null;
 for(const [id,entry]of Object.entries(instances)){
  if(entry?.buffer&&!entry?.gain)clips.push({id:Number(id),duration:entry.buffer.duration,length:entry.buffer.length,channels:entry.buffer.numberOfChannels,error:!!entry.error});
  if(!entry?.gain||!entry?.panner)continue;
  const src=entry.source,buffer=src?.buffer;
  channels.push({id:Number(id),active:!!src&&!src.isStopped,paused:!!src?.isPausedMockNode,loop:!!entry.loop,volume:entry.gain.gain.value,spatialBlend:entry.spatialBlendLevel,position:[param(entry.panner,'positionX','_x'),param(entry.panner,'positionY','_y'),param(entry.panner,'positionZ','_z')],duration:buffer?.duration??null,bufferLength:buffer?.length??null,pannerModel:entry.panner.panningModel,distanceModel:entry.panner.distanceModel,rolloffFactor:entry.panner.rolloffFactor,clipIds:bufferIds.get(buffer)||[]});
 }
 const listener=backend?.audioContext?.listener;
 const result={ready:true,time:performance.now(),contextState:backend?.audioContext?.state??null,audioEnabled:backend?.audioWebEnabled??null,masterGain:backend?.masterGain?.gain.value??null,listener:listener?{position:[param(listener,'positionX','_positionX'),param(listener,'positionY','_positionY'),param(listener,'positionZ','_positionZ')],forward:[param(listener,'forwardX','_forwardX'),param(listener,'forwardY','_forwardY'),param(listener,'forwardZ','_forwardZ')],up:[param(listener,'upX','_upX'),param(listener,'upY','_upY'),param(listener,'upZ','_upZ')]}:null,players:[],channels,clips,nativeError:null};
 const scratch=m.asm.malloc(20);let handle=0;
 try{
  const type=api(76660,'94302')(string('StepsManager, Assembly-CSharp'),0);
  if(!valid(type)){result.nativeError='StepsManager reflection type not found';return result}
  handle=api(2105,'95579')(type,0);if(!handle)throw Error('Could not root StepsManager reflection type');m.HEAPU32[scratch>>>2]=handle;
  const klass=u32(6908788),statics=valid(klass)?u32(klass+92):0,set=valid(statics)?u32(statics+4):0;
  if(!valid(set))return result;
  const slots=u32(set+12),last=m.HEAP32[(set+20)>>>2];if(!valid(slots)||last<0||last>256)throw Error('Invalid Shooter registry');
  for(let i=0;i<last;i++){
   const slot=slots+16+i*12;if(m.HEAP32[slot>>>2]<0)continue;
   const shooter=u32(slot+8);if(!valid(shooter))continue;
   const view=api(27903,'25143')(shooter,0),mine=!!api(27860,'13440')(view,0),controller=u32(shooter+116),anim=u32(shooter+68),steps=api(3029,'83985')(shooter,type,0),world=position(shooter,scratch+4),health=u32(shooter+108);
   const record={shooter,actor:api(27871,'8216')(view,0),mine,hp:valid(health)?api(15309,'52777')(health+108,0):null,position:world,grounded:mine?(valid(controller)?!!m.HEAPU8[controller+228]:null):(valid(anim)?!!m.HEAPU8[anim+44]:null),crouching:valid(anim)?!!m.HEAPU8[anim+45]:null,steps:null};
   if(valid(steps)){
    const stepSource=source(u32(steps+40),scratch+4),jumpSource=source(u32(steps+44),scratch+4);
    record.steps={pointer:steps,clip:clip(u32(steps+20)),jumpClip:clip(u32(steps+24)),landClip:clip(u32(steps+28)),maxDistance:f32(steps+48),jumpMaxDistance:f32(steps+52),velocityThreshold:f32(steps+56),defaultVolume:f32(steps+64),lastGrounded:!!m.HEAPU8[steps+68],source:stepSource,jumpSource};
    const expectedDuration=record.steps.clip?.duration||0.3192;
    record.steps.channelCandidates=channels.filter(c=>c.loop&&c.duration!==null&&Math.abs(c.duration-expectedDuration)<0.07).map(c=>{
     const p=stepSource?.position||world,direct=p&&c.position.every(Number.isFinite)?Math.hypot(...c.position.map((v,index)=>v-p[index])):null,flipZ=p&&c.position.every(Number.isFinite)?Math.hypot(c.position[0]-p[0],c.position[1]-p[1],c.position[2]+p[2]):null;
     return{id:c.id,volume:c.volume,spatialBlend:c.spatialBlend,positionError:direct,positionErrorWithZFlip:flipZ,duration:c.duration};
    }).sort((a,b)=>Math.min(a.positionError??Infinity,a.positionErrorWithZFlip??Infinity)-Math.min(b.positionError??Infinity,b.positionErrorWithZFlip??Infinity));
   }
   result.players.push(record);
  }
 }catch(error){result.nativeError=error.message}
 finally{try{if(handle)api(2577,'95581')(scratch,0)}finally{m.asm.free(scratch)}}
 return result;
}
