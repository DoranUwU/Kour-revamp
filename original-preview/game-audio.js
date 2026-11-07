// Public sound controls for the existing Unity Web Audio graph. No microphone
// or second sound engine: native sources keep their position, range and timing.
window.createGameAudio=function(module,{log=console.log}={}){
 const panel=document.querySelector('#sound-panel'),volumeInput=panel?.querySelector('[data-volume]'),muteInput=panel?.querySelector('[data-muted]'),enableButton=panel?.querySelector('[data-enable-audio]'),status=panel?.querySelector('output');
 let volume=0.8,muted=false,context=null,master=null,disposed=false;
 try{const saved=JSON.parse(localStorage.getItem('kour-revamp-audio')||'null');if(saved){if(Number.isFinite(saved.volume))volume=Math.max(0,Math.min(1,saved.volume));muted=saved.muted===true}}catch{}
 function persist(){try{localStorage.setItem('kour-revamp-audio',JSON.stringify({volume,muted}))}catch{}}
 function render(){if(volumeInput)volumeInput.value=String(Math.round(volume*100));if(muteInput)muteInput.checked=muted;if(status)status.textContent=!context?'Load the game to enable sound.':context.state==='running'?(muted?'Sound muted.':'Sound enabled · spatial footsteps'):'Click Enable sound or inside the game.';if(enableButton)enableButton.disabled=!context||context.state==='running'}
 function apply(){if(master&&context){master.gain.cancelScheduledValues(context.currentTime);master.gain.setValueAtTime(muted?0:volume,context.currentTime)}render()}
 async function resume(){if(!context||disposed)return false;try{await context.resume();render();return context.state==='running'}catch(error){log('AUDIO',error.message);render();return false}}
 function setVolume(value){if(!Number.isFinite(value))throw Error('Audio volume must be a number from 0 to 1.');volume=Math.max(0,Math.min(1,value));persist();apply();return volume}
 function setMuted(value){muted=!!value;persist();apply();return muted}
 function ready(ctx,gain){context=ctx;master=gain;context.addEventListener('statechange',render);apply()}
 module.onAudioReady=ready;
 if(module.audioBackend?.masterGain)ready(module.audioBackend.audioContext,module.audioBackend.masterGain);
 const unlock=()=>{if(context?.state==='suspended')void resume()};
 document.addEventListener('pointerdown',unlock);document.addEventListener('keydown',unlock);
 if(volumeInput)volumeInput.oninput=()=>setVolume(Number(volumeInput.value)/100);
 if(muteInput)muteInput.onchange=()=>setMuted(muteInput.checked);
 if(enableButton)enableButton.onclick=resume;
 const api={setVolume,setMuted,resume,inspect(){const backend=module.audioBackend,instances=Object.values(backend?.audioInstances||{});return{enabled:!!backend?.audioWebEnabled,state:context?.state||'not-initialized',volume,muted,gain:master?.gain.value??null,decodedClips:instances.filter(s=>s.buffer).length,failedClips:instances.filter(s=>s.error).length,activeChannels:instances.filter(s=>s.source&&!s.source.isStopped).length}},dispose(){if(disposed)return;disposed=true;document.removeEventListener('pointerdown',unlock);document.removeEventListener('keydown',unlock);context?.removeEventListener('statechange',render);if(volumeInput)volumeInput.oninput=null;if(muteInput)muteInput.onchange=null;if(enableButton)enableButton.onclick=null}};
 module.deinitializers.push(api.dispose);render();return api;
};
