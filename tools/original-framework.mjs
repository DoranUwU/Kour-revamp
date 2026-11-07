import crypto from 'node:crypto';
export function prepareFramework(original){
 const changes=['stdin','stdout','stderr'].map(name=>({from:'dev/'+name+'.html',to:'/dev/'+name}));
 changes.push({from:'function _JS_Eval_OpenURL(ptr){var str=UTF8ToString(ptr);window.open(str,"_blank","")}',to:'function _JS_Eval_OpenURL(ptr){window.OfflinePolicy.blocked("external links")}'});
 changes.push({from:'function _isCursorLocked(){if(this.isMobileDevice())',to:'function _isCursorLocked(){if(_isMobileDevice())'});
 changes.push({from:'function _JS_Eval_EvalJS(ptr){var str=UTF8ToString(ptr);try{eval(str)}catch(exception){console.error(exception)}}',to:'function _JS_Eval_EvalJS(ptr){if(ptr===-1){if(typeof Module.onKourStrikeRoundStart!=="function")throw Error("Missing local round rules");Module.onKourStrikeRoundStart();return}if(ptr===-3){Module.onKourStrikeStateChange?.();return}var str=UTF8ToString(ptr);try{eval(str)}catch(exception){console.error(exception)}}'});
 let source=original;
 for(const change of changes){if(source.split(change.from).length!==2)throw Error('Unexpected framework bridge; refusing an ambiguous edit.');change.original_offset=original.indexOf(change.from);source=source.replace(change.from,change.to)}
 const hash=s=>crypto.createHash('sha256').update(s).digest('hex');
 return{source,manifest:{original_sha256:hash(original),served_sha256:hash(source),original_modified:false,changes}};
}
