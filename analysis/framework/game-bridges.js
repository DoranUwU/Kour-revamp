// Source framework.js UTF-16 offsets 9464..9533
function _WaitForInitialization(){return _playerIsInitializedPromise}

// Source framework.js UTF-16 offsets 17115..17335
function _GetJSLoadTimeInfo(loadTimePtr){loadTimePtr=loadTimePtr>>2;HEAPU32[loadTimePtr]=Module.pageStartupTime||0;HEAPU32[loadTimePtr+1]=Module.dataUrlLoadEndTime||0;HEAPU32[loadTimePtr+2]=Module.codeDownloadTimeEnd||0}

// Source framework.js UTF-16 offsets 17335..17615
function _GetJSMemoryInfo(totalJSptr,usedJSptr){totalJSptr=totalJSptr>>3;usedJSptr=usedJSptr>>3;if(performance.memory){HEAPF64[totalJSptr]=performance.memory.totalJSHeapSize;HEAPF64[usedJSptr]=performance.memory.usedJSHeapSize}else{HEAPF64[totalJSptr]=NaN;HEAPF64[usedJSptr]=NaN}}

// Source framework.js UTF-16 offsets 35235..35303
function(event){if(event.target.localName!=="canvas")_ReleaseKeys()}

// Source framework.js UTF-16 offsets 35652..35921
function(event){if(document.activeElement==canvas||!!mobile_input)event.preventDefault();const data=event.clipboardData.getData("text");if(!!mobile_input){mobile_input.input.value+=data}else{var str_wasm=stringToNewUTF8(data);_SendPasteEvent(str_wasm);_free(str_wasm)}}

// Source framework.js UTF-16 offsets 35940..36221
function(event){if(document.activeElement==canvas)event.preventDefault();const data=!!mobile_input?mobile_input.input.value.slice(mobile_input.input.selectionStart,mobile_input.input.selectionEnd):UTF8ToString(_GetCopyBufferAsCStr());event.clipboardData.setData("text/plain",data)}

// Source framework.js UTF-16 offsets 98154..98307
function _proc_exit(code){EXITSTATUS=code;if(!keepRuntimeAlive()){if(Module["onExit"])Module["onExit"](code);ABORT=true}quit_(code,new ExitStatus(code))}

// Source framework.js UTF-16 offsets 127112..127488
function(){try{if(WEBAudio.audioContext.state!=="running"&&WEBAudio.audioContext.state!=="closed"){WEBAudio.audioContext.resume().catch(function(error){console.warn("Could not resume audio context. Exception: "+error)})}var audioCacheSize=20;while(WEBAudio.audioCache.length<audioCacheSize){var audio=new Audio;audio.autoplay=false;WEBAudio.audioCache.push(audio)}}catch(e){}}

// Source framework.js UTF-16 offsets 162983..163089
function _SocketClose(socketInstance){var socket=webSocketInstances[socketInstance];socket.socket.close()}

// Source framework.js UTF-16 offsets 163089..163986
function _SocketCreate(url,protocols){var str=UTF8ToString(url);var prot=UTF8ToString(protocols);var socket={socket:new WebSocket(str,[prot]),buffer:new Uint8Array(0),error:null,messages:[]};socket.socket.binaryType="arraybuffer";socket.socket.onmessage=function(e){if(e.data instanceof ArrayBuffer){var array=new Uint8Array(e.data);socket.messages.push(array)}};socket.socket.onclose=function(e){if(e.code!=1e3){if(e.reason!=null&&e.reason.length>0)socket.error=e.reason;else{switch(e.code){case 1001:socket.error="Endpoint going away.";break;case 1002:socket.error="Protocol error.";break;case 1003:socket.error="Unsupported message.";break;case 1005:socket.error="No status.";break;case 1006:socket.error="Abnormal disconnection.";break;case 1009:socket.error="Data frame too large.";break;default:socket.error="Error "+e.code}}}};var instance=webSocketInstances.push(socket)-1;return instance}

// Source framework.js UTF-16 offsets 163986..164161
function _SocketError(socketInstance,ptr,bufsize){var socket=webSocketInstances[socketInstance];if(socket.error==null)return 0;stringToUTF8(socket.error,ptr,bufsize);return 1}

// Source framework.js UTF-16 offsets 164161..164414
function _SocketRecv(socketInstance,ptr,length){var socket=webSocketInstances[socketInstance];if(socket.messages.length==0)return 0;if(socket.messages[0].length>length)return 0;HEAPU8.set(socket.messages[0],ptr);socket.messages=socket.messages.slice(1)}

// Source framework.js UTF-16 offsets 164414..164574
function _SocketRecvLength(socketInstance){var socket=webSocketInstances[socketInstance];if(socket.messages.length==0)return 0;return socket.messages[0].length}

// Source framework.js UTF-16 offsets 164574..164724
function _SocketSend(socketInstance,ptr,length){var socket=webSocketInstances[socketInstance];socket.socket.send(HEAPU8.buffer.slice(ptr,ptr+length))}

// Source framework.js UTF-16 offsets 164724..164840
function _SocketState(socketInstance){var socket=webSocketInstances[socketInstance];return socket.socket.readyState}

// Source framework.js UTF-16 offsets 201269..201336
function __emscripten_get_now_is_monotonic(){return nowIsMonotonic}

// Source framework.js UTF-16 offsets 201336..201389
function __emscripten_throw_longjmp(){throw Infinity}

// Source framework.js UTF-16 offsets 201389..201871
function __gmtime_js(time,tmPtr){var date=new Date(readI53FromI64(time)*1e3);HEAP32[tmPtr>>2]=date.getUTCSeconds();HEAP32[tmPtr+4>>2]=date.getUTCMinutes();HEAP32[tmPtr+8>>2]=date.getUTCHours();HEAP32[tmPtr+12>>2]=date.getUTCDate();HEAP32[tmPtr+16>>2]=date.getUTCMonth();HEAP32[tmPtr+20>>2]=date.getUTCFullYear()-1900;HEAP32[tmPtr+24>>2]=date.getUTCDay();var start=Date.UTC(date.getUTCFullYear(),0,1,0,0,0,0);var yday=(date.getTime()-start)/(1e3*60*60*24)|0;HEAP32[tmPtr+28>>2]=yday}

// Source framework.js UTF-16 offsets 202329..203053
function __localtime_js(time,tmPtr){var date=new Date(readI53FromI64(time)*1e3);HEAP32[tmPtr>>2]=date.getSeconds();HEAP32[tmPtr+4>>2]=date.getMinutes();HEAP32[tmPtr+8>>2]=date.getHours();HEAP32[tmPtr+12>>2]=date.getDate();HEAP32[tmPtr+16>>2]=date.getMonth();HEAP32[tmPtr+20>>2]=date.getFullYear()-1900;HEAP32[tmPtr+24>>2]=date.getDay();var yday=ydayFromDate(date)|0;HEAP32[tmPtr+28>>2]=yday;HEAP32[tmPtr+36>>2]=-(date.getTimezoneOffset()*60);var start=new Date(date.getFullYear(),0,1);var summerOffset=new Date(date.getFullYear(),6,1).getTimezoneOffset();var winterOffset=start.getTimezoneOffset();var dst=(summerOffset!=winterOffset&&date.getTimezoneOffset()==Math.min(winterOffset,summerOffset))|0;HEAP32[tmPtr+32>>2]=dst}

// Source framework.js UTF-16 offsets 203053..204120
function __mktime_js(tmPtr){var date=new Date(HEAP32[tmPtr+20>>2]+1900,HEAP32[tmPtr+16>>2],HEAP32[tmPtr+12>>2],HEAP32[tmPtr+8>>2],HEAP32[tmPtr+4>>2],HEAP32[tmPtr>>2],0);var dst=HEAP32[tmPtr+32>>2];var guessedOffset=date.getTimezoneOffset();var start=new Date(date.getFullYear(),0,1);var summerOffset=new Date(date.getFullYear(),6,1).getTimezoneOffset();var winterOffset=start.getTimezoneOffset();var dstOffset=Math.min(winterOffset,summerOffset);if(dst<0){HEAP32[tmPtr+32>>2]=Number(summerOffset!=winterOffset&&dstOffset==guessedOffset)}else if(dst>0!=(dstOffset==guessedOffset)){var nonDstOffset=Math.max(winterOffset,summerOffset);var trueOffset=dst>0?dstOffset:nonDstOffset;date.setTime(date.getTime()+(trueOffset-guessedOffset)*6e4)}HEAP32[tmPtr+24>>2]=date.getDay();var yday=ydayFromDate(date)|0;HEAP32[tmPtr+28>>2]=yday;HEAP32[tmPtr>>2]=date.getSeconds();HEAP32[tmPtr+4>>2]=date.getMinutes();HEAP32[tmPtr+8>>2]=date.getHours();HEAP32[tmPtr+12>>2]=date.getDate();HEAP32[tmPtr+16>>2]=date.getMonth();HEAP32[tmPtr+20>>2]=date.getYear();return date.getTime()/1e3|0}

// Source framework.js UTF-16 offsets 204120..204430
function __mmap_js(len,prot,flags,fd,off,allocated,addr){try{var stream=SYSCALLS.getStreamFromFD(fd);var res=FS.mmap(stream,len,off,prot,flags);var ptr=res.ptr;HEAP32[allocated>>2]=res.allocated;HEAPU32[addr>>2]=ptr;return 0}catch(e){if(typeof FS=="undefined"||!(e.name==="ErrnoError"))throw e;return-e.errno}}

// Source framework.js UTF-16 offsets 204430..204687
function __munmap_js(addr,len,prot,flags,fd,offset){try{var stream=SYSCALLS.getStreamFromFD(fd);if(prot&2){SYSCALLS.doMsync(addr,stream,len,flags,offset)}FS.munmap(stream)}catch(e){if(typeof FS=="undefined"||!(e.name==="ErrnoError"))throw e;return-e.errno}}

// Source framework.js UTF-16 offsets 204687..205537
function __tzset_js(timezone,daylight,tzname){var currentYear=(new Date).getFullYear();var winter=new Date(currentYear,0,1);var summer=new Date(currentYear,6,1);var winterOffset=winter.getTimezoneOffset();var summerOffset=summer.getTimezoneOffset();var stdTimezoneOffset=Math.max(winterOffset,summerOffset);HEAPU32[timezone>>2]=stdTimezoneOffset*60;HEAP32[daylight>>2]=Number(winterOffset!=summerOffset);function extractZone(date){var match=date.toTimeString().match(/\(([A-Za-z ]+)\)$/);return match?match[1]:"GMT"}var winterName=extractZone(winter);var summerName=extractZone(summer);var winterNamePtr=stringToNewUTF8(winterName);var summerNamePtr=stringToNewUTF8(summerName);if(summerOffset<winterOffset){HEAPU32[tzname>>2]=winterNamePtr;HEAPU32[tzname+4>>2]=summerNamePtr}else{HEAPU32[tzname>>2]=summerNamePtr;HEAPU32[tzname+4>>2]=winterNamePtr}}

// Source framework.js UTF-16 offsets 207741..207901
function(i){var h=JSEvents.eventHandlers[i];h.target.removeEventListener(h.eventTypeString,h.eventListenerFunc,h.useCapture);JSEvents.eventHandlers.splice(i,1)}

// Source framework.js UTF-16 offsets 276375..276634
function __glGenObject(n,buffers,createFunction,objectTable){for(var i=0;i<n;i++){var buffer=GLctx[createFunction]();var id=buffer&&GL.getNewId(objectTable);if(buffer){buffer.name=id;objectTable[id]=buffer}else{GL.recordError(1282)}HEAP32[buffers+i*4>>2]=id}}

// Source framework.js UTF-16 offsets 277328..277690
function __glGetActiveAttribOrUniform(funcName,program,index,bufSize,length,size,type,name){program=GL.programs[program];var info=GLctx[funcName](program,index);if(info){var numBytesWrittenExclNull=name&&stringToUTF8(info.name,name,bufSize);if(length)HEAP32[length>>2]=numBytesWrittenExclNull;if(size)HEAP32[size>>2]=info.size;if(type)HEAP32[type>>2]=info.type}}

// Source framework.js UTF-16 offsets 302221..302264
()=>source.includes("#version 300")?300:100

// Source framework.js UTF-16 offsets 316658..317052
function _isCursorLocked(){if(this.isMobileDevice()){return false}var locked=(document.pointerLockElement?document.pointerLockElement!==null:false)||(document.mozPointerLockElement?document.mozPointerLockElement!==null:false)||(document.webkitPointerLockElement?document.webkitPointerLockElement!==null:false);return locked||screen.height===window.innerHeight&&screen.width===window.innerWidth}

// Source framework.js UTF-16 offsets 317052..317512
function _isMobileDevice(){var userAgent=navigator.userAgent.toLowerCase();if(/windows nt/.test(userAgent)&&!/windows phone/.test(userAgent)){return false}if(/CrOS/.test(userAgent)){return false}if(/mobile/.test(userAgent)){return true}var isIPad=/ipad|macintosh/.test(userAgent)&&navigator.maxTouchPoints&&navigator.maxTouchPoints>1;var isAndroidTablet=/android/.test(userAgent)&&!/mobile/.test(userAgent);if(isIPad||isAndroidTablet){return true}return false}

// Source framework.js UTF-16 offsets 317512..317559
function _llvm_eh_typeid_for(type){return type}

// Source framework.js UTF-16 offsets 318567..318711
function _navigator_gpu_get_preferred_canvas_format(){return GPUTextureAndVertexFormats.indexOf(navigator["gpu"]["getPreferredCanvasFormat"]())}

// Source framework.js UTF-16 offsets 318711..318786
function _wgpuMuteJsExceptions(fn){return p=>{try{return fn(p)}catch(e){}}}

// Source framework.js UTF-16 offsets 318786..319347
function _navigator_gpu_request_adapter_async(options,adapterCallback,userData){options>>=2;let gpu=navigator["gpu"],powerPreference=[,"low-power","high-performance"][HEAPU32[options]],opts={};if(gpu){if(options){opts["forceFallbackAdapter"]=!!HEAPU32[options+1];opts["xrCompatible"]=!!HEAPU32[options+2];if(powerPreference)opts["powerPreference"]=powerPreference}function cb(adapter){((a1,a2)=>dynCall_vii.apply(null,[adapterCallback,a1,a2]))(wgpuStore(adapter),userData)}gpu["requestAdapter"](opts).then(_wgpuMuteJsExceptions(cb)).catch(()=>{cb()});return 1}}

// Source framework.js UTF-16 offsets 325463..325661
function _testFunctionggg(){Object.freeze(WebGLRenderingContext);Object.freeze(WebGL2RenderingContext);Object.freeze(WebGLRenderingContext.prototype);Object.freeze(WebGL2RenderingContext.prototype)}

// Source framework.js UTF-16 offsets 326016..326240
function _wgpu_adapter_or_device_get_features(adapterOrDevice){let id=1,featuresBitMask=0;for(let feature of _wgpuFeatures){if(wgpu[adapterOrDevice]["features"].has(feature)){featuresBitMask|=id}id*=2}return featuresBitMask}

// Source framework.js UTF-16 offsets 326999..327290
function _wgpu_adapter_or_device_get_limits(adapterOrDevice,limits){let l=wgpu[adapterOrDevice]["limits"];limits>>=2;for(let limitName of _wgpu64BitLimitNames){wgpuWriteI53ToU64HeapIdx(limits,l[limitName]);limits+=2}for(let limitName of _wgpu32BitLimitNames){HEAPU32[limits++]=l[limitName]}}

// Source framework.js UTF-16 offsets 328240..328605
function _wgpu_adapter_request_device_async(adapter,descriptor,deviceCallback,userData){function cb(device){if(device){wgpuStore(device["queue"])}((a1,a2)=>dynCall_vii.apply(null,[deviceCallback,a1,a2]))(wgpuStore(device),userData)}let desc=wgpuReadDeviceDescriptor(descriptor);wgpu[adapter]["requestDevice"](desc).then(_wgpuMuteJsExceptions(cb)).catch(()=>{cb()})}

// Source framework.js UTF-16 offsets 328605..328815
function _wgpu_buffer_get_mapped_range(gpuBuffer,offset,size){gpuBuffer=wgpu[gpuBuffer];try{gpuBuffer.mappedRanges[offset]=gpuBuffer["getMappedRange"](offset,size<0?void 0:size)}catch(e){return-1}return offset}

// Source framework.js UTF-16 offsets 328815..329066
function _wgpu_buffer_map_async(buffer,callback,userData,mode,offset,size){wgpu[buffer]["mapAsync"](mode,offset,size<0?void 0:size).then(()=>{((a1,a2,a3,a4,a5)=>dynCall_viiidd.apply(null,[callback,a1,a2,a3,a4,a5]))(buffer,userData,mode,offset,size)})}

// Source framework.js UTF-16 offsets 329066..329237
function _wgpu_buffer_read_mapped_range(gpuBuffer,startOffset,subOffset,dst,size){HEAPU8.set(new Uint8Array(wgpu[gpuBuffer].mappedRanges[startOffset],subOffset,size),dst)}

// Source framework.js UTF-16 offsets 329237..329349
function _wgpu_buffer_unmap(gpuBuffer){gpuBuffer=wgpu[gpuBuffer];gpuBuffer["unmap"]();gpuBuffer.mappedRanges={}}

// Source framework.js UTF-16 offsets 329759..330270
function _wgpu_canvas_context_configure(canvasContext,config){config>>=2;let desc={"device":wgpu[HEAPU32[config]],"format":GPUTextureAndVertexFormats[HEAPU32[config+1]],"usage":HEAPU32[config+2],"viewFormats":wgpuReadArrayOfItems(GPUTextureAndVertexFormats,HEAPU32[config+4],HEAPU32[config+3]),"colorSpace":HTMLPredefinedColorSpaces[HEAPU32[config+6]],"toneMapping":{"mode":GPUCanvasToneMappingModes[HEAPU32[config+7]]},"alphaMode":GPUCanvasAlphaModes[HEAPU32[config+8]]};wgpu[canvasContext]["configure"](desc)}

// Source framework.js UTF-16 offsets 330270..330535
function _wgpu_object_destroy(object){let o=wgpu[object];if(o){o.wid=0;if(o["destroy"])o["destroy"]();if(o.derivedObjects)o.derivedObjects.forEach((v,k)=>{_wgpu_object_destroy(k)});if(o.parentObject)o.parentObject.derivedObjects.delete(object);delete wgpu[object]}}

// Source framework.js UTF-16 offsets 330712..331022
function _wgpu_canvas_context_get_current_texture(canvasContext){canvasContext=wgpu[canvasContext];var canvasTexture=canvasContext["getCurrentTexture"]();if(canvasTexture!=wgpu[1]){_wgpu_object_destroy(1);wgpu[1]=canvasTexture;canvasTexture.wid=1;wgpuLinkParentAndChild(canvasContext,1,canvasTexture)}return 1}

// Source framework.js UTF-16 offsets 331022..331219
function _wgpu_canvas_get_webgpu_context(canvasSelector){let canvas=document.querySelector(utf8(canvasSelector));let ctx=canvas.getContext("webgpu");if(ctx.wid)return ctx.wid;return wgpuStore(ctx)}

// Source framework.js UTF-16 offsets 331574..331844
function _wgpu_command_encoder_begin_compute_pass(commandEncoder,descriptor){commandEncoder=wgpu[commandEncoder];descriptor>>=2;let desc=descriptor?{"timestampWrites":wgpuReadTimestampWrites(descriptor)}:void 0;return wgpuStore(commandEncoder["beginComputePass"](desc))}

// Source framework.js UTF-16 offsets 332398..333631
function _wgpu_command_encoder_begin_render_pass(commandEncoder,descriptor){descriptor>>=2;let colorAttachments=[],numColorAttachments=HEAP32[descriptor+4],colorAttachmentsIdx=HEAPU32[descriptor+2]>>2,colorAttachmentsIdxDbl=colorAttachmentsIdx+6>>1,maxDrawCount=HEAPF64[descriptor>>1],depthStencilAttachment=HEAPU32[descriptor+5];while(numColorAttachments--){colorAttachments.push(HEAPU32[colorAttachmentsIdx]?{"view":wgpu[HEAPU32[colorAttachmentsIdx]],"depthSlice":HEAP32[colorAttachmentsIdx+1]<0?void 0:HEAP32[colorAttachmentsIdx+1],"resolveTarget":wgpu[HEAPU32[colorAttachmentsIdx+2]],"storeOp":GPUStoreOps[HEAPU32[colorAttachmentsIdx+3]],"loadOp":GPULoadOps[HEAPU32[colorAttachmentsIdx+4]],"clearValue":[HEAPF64[colorAttachmentsIdxDbl],HEAPF64[colorAttachmentsIdxDbl+1],HEAPF64[colorAttachmentsIdxDbl+2],HEAPF64[colorAttachmentsIdxDbl+3]]}:null);colorAttachmentsIdx+=14;colorAttachmentsIdxDbl+=7}let desc={"colorAttachments":colorAttachments,"depthStencilAttachment":wgpuReadRenderPassDepthStencilAttachment(descriptor+5),"occlusionQuerySet":wgpu[HEAPU32[descriptor+14]],"maxDrawCount":maxDrawCount||void 0,"timestampWrites":wgpuReadTimestampWrites(descriptor+15)};return wgpuStore(wgpu[commandEncoder]["beginRenderPass"](desc))}

// Source framework.js UTF-16 offsets 333631..333882
function _wgpu_command_encoder_copy_buffer_to_buffer(commandEncoder,source,sourceOffset,destination,destinationOffset,size){wgpu[commandEncoder]["copyBufferToBuffer"](wgpu[source],sourceOffset,wgpu[destination],destinationOffset,size<1/0?size:void 0)}

// Source framework.js UTF-16 offsets 334353..334661
function _wgpu_command_encoder_copy_texture_to_buffer(commandEncoder,source,destination,copyWidth,copyHeight,copyDepthOrArrayLayers){wgpu[commandEncoder]["copyTextureToBuffer"](wgpuReadGpuTexelCopyTextureInfo(source),wgpuReadGpuTexelCopyBufferInfo(destination),[copyWidth,copyHeight,copyDepthOrArrayLayers])}

// Source framework.js UTF-16 offsets 334661..334972
function _wgpu_command_encoder_copy_texture_to_texture(commandEncoder,source,destination,copyWidth,copyHeight,copyDepthOrArrayLayers){wgpu[commandEncoder]["copyTextureToTexture"](wgpuReadGpuTexelCopyTextureInfo(source),wgpuReadGpuTexelCopyTextureInfo(destination),[copyWidth,copyHeight,copyDepthOrArrayLayers])}

// Source framework.js UTF-16 offsets 334972..335170
function _wgpu_compute_pass_encoder_dispatch_workgroups(encoder,workgroupCountX,workgroupCountY,workgroupCountZ){wgpu[encoder]["dispatchWorkgroups"](workgroupCountX,workgroupCountY,workgroupCountZ)}

// Source framework.js UTF-16 offsets 335170..335355
function _wgpu_compute_pass_encoder_dispatch_workgroups_indirect(encoder,indirectBuffer,indirectOffset){wgpu[encoder]["dispatchWorkgroupsIndirect"](wgpu[indirectBuffer],indirectOffset)}

// Source framework.js UTF-16 offsets 335507..335998
function _wgpu_device_create_bind_group(device,layout,entries,numEntries){device=wgpu[device];entries>>=2;let e=[];while(numEntries--){let resource=wgpu[HEAPU32[entries+1]];e.push({"binding":HEAPU32[entries],"resource":resource.isBuffer?{"buffer":resource,"offset":wgpuReadI53FromU64HeapIdx(entries+2),"size":wgpuReadI53FromU64HeapIdx(entries+4)||void 0}:resource});entries+=6}let desc={"layout":wgpu[layout],"entries":e};return wgpuStoreAndSetParent(device["createBindGroup"](desc),device)}

// Source framework.js UTF-16 offsets 337349..337581
function _wgpu_device_create_bind_group_layout(device,entries,numEntries){device=wgpu[device];let desc=wgpuReadBindGroupLayoutDescriptor(entries,numEntries);return wgpuStoreAndSetParent(device["createBindGroupLayout"](desc),device)}

// Source framework.js UTF-16 offsets 337581..337925
function _wgpu_device_create_buffer(device,descriptor){device=wgpu[device];descriptor>>=2;let desc={"size":wgpuReadI53FromU64HeapIdx(descriptor),"usage":HEAPU32[descriptor+2],"mappedAtCreation":!!HEAPU32[descriptor+3]};let buffer=device["createBuffer"](desc);buffer.mappedRanges={};buffer.isBuffer=1;return wgpuStoreAndSetParent(buffer,device)}

// Source framework.js UTF-16 offsets 337925..338091
function _wgpu_device_create_command_encoder(device,descriptor){let desc=void 0;return wgpuStoreAndSetParent(wgpu[device]["createCommandEncoder"](desc),wgpu[device])}

// Source framework.js UTF-16 offsets 338091..338233
function _wgpu_device_create_command_encoder_simple(device){return wgpuStoreAndSetParent(wgpu[device]["createCommandEncoder"](),wgpu[device])}

// Source framework.js UTF-16 offsets 338424..338821
function _wgpu_device_create_compute_pipeline(device,computeModule,entryPoint,layout,constants,numConstants){device=wgpu[device];let desc={"layout":layout>1?wgpu[layout]:GPUAutoLayoutMode,"compute":{"module":wgpu[computeModule],"entryPoint":utf8(entryPoint)||void 0,"constants":wgpuReadConstants(constants,numConstants)}};return wgpuStoreAndSetParent(device["createComputePipeline"](desc),device)}

// Source framework.js UTF-16 offsets 338821..339072
function _wgpu_device_create_pipeline_layout(device,layouts,numLayouts){device=wgpu[device];let desc={"bindGroupLayouts":wgpuReadArrayOfItemsMaybeNull(wgpu,layouts,numLayouts)};return wgpuStoreAndSetParent(device["createPipelineLayout"](desc),device)}

// Source framework.js UTF-16 offsets 342977..343181
function _wgpu_device_create_render_pipeline(device,descriptor){let desc=wgpuReadRenderPipelineDescriptor(descriptor);return wgpuStoreAndSetParent(wgpu[device]["createRenderPipeline"](desc),wgpu[device])}

// Source framework.js UTF-16 offsets 343374..344043
function _wgpu_device_create_sampler(device,descriptor){device=wgpu[device];descriptor>>=2;let desc=descriptor?{"addressModeU":GPUAddressModes[HEAPU32[descriptor]],"addressModeV":GPUAddressModes[HEAPU32[descriptor+1]],"addressModeW":GPUAddressModes[HEAPU32[descriptor+2]],"magFilter":GPUFilterModes[HEAPU32[descriptor+3]],"minFilter":GPUFilterModes[HEAPU32[descriptor+4]],"mipmapFilter":GPUMipmapFilterModes[HEAPU32[descriptor+5]],"lodMinClamp":HEAPF32[descriptor+6],"lodMaxClamp":HEAPF32[descriptor+7],"compare":GPUCompareFunctions[HEAPU32[descriptor+8]],"maxAnisotropy":HEAPU32[descriptor+9]}:void 0;return wgpuStoreAndSetParent(device["createSampler"](desc),device)}

// Source framework.js UTF-16 offsets 344536..344734
function _wgpu_device_create_shader_module(device,descriptor){let desc=wgpuReadShaderModuleDescriptor(descriptor);return wgpuStoreAndSetParent(wgpu[device]["createShaderModule"](desc),wgpu[device])}

// Source framework.js UTF-16 offsets 344734..345300
function _wgpu_device_create_texture(device,descriptor){device=wgpu[device];descriptor>>=2;let desc={"viewFormats":wgpuReadArrayOfItems(GPUTextureAndVertexFormats,HEAPU32[descriptor],HEAPU32[descriptor+2]),"size":[HEAP32[descriptor+3],HEAP32[descriptor+4],HEAP32[descriptor+5]],"mipLevelCount":HEAP32[descriptor+6],"sampleCount":HEAP32[descriptor+7],"dimension":HEAPU32[descriptor+8]+"d","format":GPUTextureAndVertexFormats[HEAPU32[descriptor+9]],"usage":HEAPU32[descriptor+10]};let texture=device["createTexture"](desc);return wgpuStoreAndSetParent(texture,device)}

// Source framework.js UTF-16 offsets 345300..345373
function _wgpu_device_get_queue(device){return wgpu[device]["queue"].wid}

// Source framework.js UTF-16 offsets 345373..345758
function _wgpuReportErrorCodeAndMessage(device,callback,errorCode,stringMessage,userData){if(stringMessage){var stackTop=stackSave(),len=lengthBytesUTF8(stringMessage)+1,errorMessage=stackAlloc(len);stringToUTF8(stringMessage,errorMessage,len)}((a1,a2,a3,a4)=>dynCall_viiii.apply(null,[callback,a1,a2,a3,a4]))(device,errorCode,errorMessage,userData);if(stackTop)stackRestore(stackTop)}

// Source framework.js UTF-16 offsets 345758..345932
function _wgpuErrorObjectToErrorType(error){return error?error instanceof GPUInternalError?3:error instanceof GPUValidationError?2:error instanceof GPUOutOfMemoryError?1:3:0}

// Source framework.js UTF-16 offsets 345932..346119
function _wgpuDispatchWebGpuErrorEvent(device,callback,error,userData){_wgpuReportErrorCodeAndMessage(device,callback,_wgpuErrorObjectToErrorType(error),error&&error["message"],userData)}

// Source framework.js UTF-16 offsets 346119..346401
function _wgpu_device_pop_error_scope_async(device,callback,userData){function dispatchErrorCallback(error){_wgpuDispatchWebGpuErrorEvent(device,callback,error,userData)}wgpu[device]["popErrorScope"]().then(_wgpuMuteJsExceptions(dispatchErrorCallback)).catch(dispatchErrorCallback)}

// Source framework.js UTF-16 offsets 346401..346538
function _wgpu_device_push_error_scope(device,filter){wgpu[device]["pushErrorScope"]([,"out-of-memory","validation","internal"][filter])}

// Source framework.js UTF-16 offsets 346538..346771
function _wgpu_device_set_uncapturederror_callback(device,callback,userData){wgpu[device]["onuncapturederror"]=callback?function(uncapturedError){_wgpuDispatchWebGpuErrorEvent(device,callback,uncapturedError["error"],userData)}:null}

// Source framework.js UTF-16 offsets 346771..346860
function _wgpu_encoder_end(encoder){wgpu[encoder]["end"]();_wgpu_object_destroy(encoder)}

// Source framework.js UTF-16 offsets 346860..346997
function _wgpu_encoder_finish(encoder){let cmdBuffer=wgpu[encoder]["finish"]();_wgpu_object_destroy(encoder);return wgpuStore(cmdBuffer)}

// Source framework.js UTF-16 offsets 346997..347078
function _wgpu_encoder_pop_debug_group(encoder){wgpu[encoder]["popDebugGroup"]()}

// Source framework.js UTF-16 offsets 347078..347188
function _wgpu_encoder_push_debug_group(encoder,groupLabel){wgpu[encoder]["pushDebugGroup"](utf8(groupLabel))}

// Source framework.js UTF-16 offsets 347188..347381
function _wgpu_encoder_set_bind_group(encoder,index,bindGroup,dynamicOffsets,numDynamicOffsets){wgpu[encoder]["setBindGroup"](index,wgpu[bindGroup],HEAPU32,dynamicOffsets>>2,numDynamicOffsets)}

// Source framework.js UTF-16 offsets 347381..347480
function _wgpu_encoder_set_pipeline(encoder,pipeline){wgpu[encoder]["setPipeline"](wgpu[pipeline])}

// Source framework.js UTF-16 offsets 347480..347530
function _wgpu_is_valid_object(o){return!!wgpu[o]}

// Source framework.js UTF-16 offsets 347530..347600
function _wgpu_object_set_label(o,label){wgpu[o]["label"]=utf8(label)}

// Source framework.js UTF-16 offsets 347600..347732
function _wgpu_pipeline_get_bind_group_layout(pipelineBase,index){return wgpuStore(wgpu[pipelineBase]["getBindGroupLayout"](index))}

// Source framework.js UTF-16 offsets 347732..347997
function _wgpu_queue_submit_multiple_and_destroy(queue,commandBuffers,numCommandBuffers){wgpu[queue]["submit"](wgpuReadArrayOfItems(wgpu,commandBuffers,numCommandBuffers));commandBuffers>>=2;while(numCommandBuffers--)_wgpu_object_destroy(HEAPU32[commandBuffers++])}

// Source framework.js UTF-16 offsets 347997..348143
function _wgpu_queue_submit_one_and_destroy(queue,commandBuffer){wgpu[queue]["submit"]([wgpu[commandBuffer]]);_wgpu_object_destroy(commandBuffer)}

// Source framework.js UTF-16 offsets 348143..348285
function _wgpu_queue_write_buffer(queue,buffer,bufferOffset,data,size){wgpu[queue]["writeBuffer"](wgpu[buffer],bufferOffset,HEAPU8,data,size)}

// Source framework.js UTF-16 offsets 348285..348636
function _wgpu_queue_write_texture(queue,destination,data,bytesPerBlockRow,blockRowsPerImage,writeWidth,writeHeight,writeDepthOrArrayLayers){wgpu[queue]["writeTexture"](wgpuReadGpuTexelCopyTextureInfo(destination),HEAPU8,{"offset":data,"bytesPerRow":bytesPerBlockRow,"rowsPerImage":blockRowsPerImage},[writeWidth,writeHeight,writeDepthOrArrayLayers])}

// Source framework.js UTF-16 offsets 348636..348822
function _wgpu_render_commands_mixin_draw(passEncoder,vertexCount,instanceCount,firstVertex,firstInstance){wgpu[passEncoder]["draw"](vertexCount,instanceCount,firstVertex,firstInstance)}

// Source framework.js UTF-16 offsets 348822..349043
function _wgpu_render_commands_mixin_draw_indexed(passEncoder,indexCount,instanceCount,firstVertex,baseVertex,firstInstance){wgpu[passEncoder]["drawIndexed"](indexCount,instanceCount,firstVertex,baseVertex,firstInstance)}

// Source framework.js UTF-16 offsets 349043..349223
function _wgpu_render_commands_mixin_draw_indexed_indirect(passEncoder,indirectBuffer,indirectOffset){wgpu[passEncoder]["drawIndexedIndirect"](wgpu[indirectBuffer],indirectOffset)}

// Source framework.js UTF-16 offsets 349223..349388
function _wgpu_render_commands_mixin_draw_indirect(passEncoder,indirectBuffer,indirectOffset){wgpu[passEncoder]["drawIndirect"](wgpu[indirectBuffer],indirectOffset)}

// Source framework.js UTF-16 offsets 349388..349591
function _wgpu_render_commands_mixin_set_index_buffer(passEncoder,buffer,indexFormat,offset,size){wgpu[passEncoder]["setIndexBuffer"](wgpu[buffer],GPUIndexFormats[indexFormat],offset,size<0?void 0:size)}

// Source framework.js UTF-16 offsets 349591..349765
function _wgpu_render_commands_mixin_set_vertex_buffer(passEncoder,slot,buffer,offset,size){wgpu[passEncoder]["setVertexBuffer"](slot,wgpu[buffer],offset,size<0?void 0:size)}

// Source framework.js UTF-16 offsets 349765..349893
function _wgpu_render_pass_encoder_set_scissor_rect(encoder,x,y,width,height){wgpu[encoder]["setScissorRect"](x,y,width,height)}

// Source framework.js UTF-16 offsets 349893..350023
function _wgpu_render_pass_encoder_set_stencil_reference(encoder,stencilValue){wgpu[encoder]["setStencilReference"](stencilValue)}

// Source framework.js UTF-16 offsets 350023..350180
function _wgpu_render_pass_encoder_set_viewport(encoder,x,y,width,height,minDepth,maxDepth){wgpu[encoder]["setViewport"](x,y,width,height,minDepth,maxDepth)}

// Source framework.js UTF-16 offsets 350180..350704
function _wgpu_texture_create_view(texture,descriptor){descriptor>>=2;let desc=descriptor?{"format":GPUTextureAndVertexFormats[HEAPU32[descriptor]],"dimension":GPUTextureViewDimensions[HEAPU32[descriptor+1]],"usage":HEAPU32[descriptor+2],"aspect":GPUTextureAspects[HEAPU32[descriptor+3]],"baseMipLevel":HEAP32[descriptor+4],"mipLevelCount":HEAP32[descriptor+5],"baseArrayLayer":HEAP32[descriptor+6],"arrayLayerCount":HEAP32[descriptor+7]}:void 0;return wgpuStoreAndSetParent(wgpu[texture]["createView"](desc),wgpu[texture])}

// Source framework.js UTF-16 offsets 350704..350829
function _wgpu_texture_create_view_simple(texture){return wgpuStoreAndSetParent(wgpu[texture]["createView"](),wgpu[texture])}

// Source framework.js UTF-16 offsets 384420..384491
function(){return(_htonl=Module["asm"]["htonl"]).apply(null,arguments)}

// Source framework.js UTF-16 offsets 384503..384574
function(){return(_htons=Module["asm"]["htons"]).apply(null,arguments)}

// Source framework.js UTF-16 offsets 384586..384657
function(){return(_ntohs=Module["asm"]["ntohs"]).apply(null,arguments)}