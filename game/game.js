const canvas=document.querySelector('#view'),ctx=canvas.getContext('2d');
const $=id=>document.getElementById(id);
// Original arena, rendered with a dependency-free raycaster. One cell = one metre.
const map=[
'11111111111111111111',
'10000000000000000001',
'10000000000000000001',
'10002220000003330001',
'10002000000000030001',
'10002000000000030001',
'10000000111000000001',
'10000000111000000001',
'10000000000000000001',
'10033000000002220001',
'10003000000002000001',
'10000000000000000001',
'10000000000000000001',
'10002220003330000001',
'10000000000000000001',
'10000000000000000001',
'11111111111111111111'];
const spawns=[[2.5,2.5],[17.5,2.5],[17.5,14.5],[2.5,14.5],[10.5,11.5],[6.5,6.5]];
let w,h,zbuffer,active=false,started=false,last=0,time=180,kills=0,deaths=0,ammo=30,reload=0,cooldown=0,flash=0,hurt=0,hit=0,muted=false,audio;
const keys=new Set(),p={x:6.5,y:11.5,a:-.7,pitch:0,z:0,vz:0,hp:100};
let bots=[];
function resize(){w=canvas.width=Math.min(innerWidth,1280);h=canvas.height=Math.round(w*innerHeight/innerWidth);zbuffer=new Float32Array(w)}
addEventListener('resize',resize);resize();
function solid(x,y){return map[Math.floor(y)]?.[Math.floor(x)]!=='0'}
function move(o,dx,dy){const r=.22;if(!solid(o.x+dx+Math.sign(dx)*r,o.y-r)&&!solid(o.x+dx+Math.sign(dx)*r,o.y+r))o.x+=dx;if(!solid(o.x-r,o.y+dy+Math.sign(dy)*r)&&!solid(o.x+r,o.y+dy+Math.sign(dy)*r))o.y+=dy}
function trace(x,y,a){const dx=Math.cos(a),dy=Math.sin(a);let mx=Math.floor(x),my=Math.floor(y),sx=dx<0?-1:1,sy=dy<0?-1:1,ddx=Math.abs(1/dx),ddy=Math.abs(1/dy),tx=(dx<0?x-mx:mx+1-x)*ddx,ty=(dy<0?y-my:my+1-y)*ddy,side=0;for(let n=0;n<80;n++){if(tx<ty){tx+=ddx;mx+=sx;side=0}else{ty+=ddy;my+=sy;side=1}if(map[my]?.[mx]!=='0')return{d:Math.max(.01,side?ty-ddy:tx-ddx),side,tile:map[my]?.[mx]||'1',u:side?x+(ty-ddy)*dx:y+(tx-ddx)*dy}}return{d:40,side:0,tile:'1',u:0}}
function tone(freq,dur=.06,type='square',gain=.025){if(muted)return;try{audio??=new AudioContext();const o=audio.createOscillator(),g=audio.createGain();o.type=type;o.frequency.setValueAtTime(freq,audio.currentTime);o.frequency.exponentialRampToValueAtTime(freq*.4,audio.currentTime+dur);g.gain.setValueAtTime(gain,audio.currentTime);g.gain.exponentialRampToValueAtTime(.001,audio.currentTime+dur);o.connect(g).connect(audio.destination);o.start();o.stop(audio.currentTime+dur)}catch{}}
function respawn(b,i){const s=spawns[i%spawns.length];b.x=s[0];b.y=s[1];b.hp=100;b.wait=0;b.fire=1+Math.random();b.seed=Math.random()*20}
function reset(){time=180;kills=0;deaths=0;ammo=30;reload=0;p.x=6.5;p.y=11.5;p.hp=100;p.z=0;p.vz=0;bots=Array.from({length:5},(_,i)=>{const b={};respawn(b,i);return b});started=true;$('result').textContent=''}
function pause(){active=false;keys.clear();document.body.classList.remove('playing');$('play').innerHTML='RESUME ROUND <span>↗</span>'}
function finish(){active=false;started=false;document.exitPointerLock?.();pause();$('play').innerHTML='PLAY AGAIN <span>↗</span>';$('result').textContent=`ROUND COMPLETE · ${kills} eliminations · ${deaths} deaths`}
$('play').onclick=()=>{if(!started)reset();try{const request=canvas.requestPointerLock();request?.catch(()=>{$('result').textContent='Click the arena to enable mouse look.'})}catch{$('result').textContent='Mouse lock unavailable in this browser.'}};
canvas.onclick=()=>{if(started&&!active)canvas.requestPointerLock?.()};
document.addEventListener('pointerlockchange',()=>{active=document.pointerLockElement===canvas;if(active){document.body.classList.add('playing');audio?.resume()}else pause()});
addEventListener('keydown',e=>{if(['Space','ArrowUp','ArrowDown','ArrowLeft','ArrowRight'].includes(e.code))e.preventDefault();keys.add(e.code);if(active&&e.code==='KeyR')startReload();if(active&&e.code==='Space'&&p.z===0)p.vz=4.3});
addEventListener('keyup',e=>keys.delete(e.code));addEventListener('blur',()=>{keys.clear();if(active)document.exitPointerLock?.()});
addEventListener('mousemove',e=>{if(active){p.a+=e.movementX*.0025;p.pitch=Math.max(-.4,Math.min(.4,p.pitch-e.movementY*.0015))}});
addEventListener('mousedown',e=>{if(active&&e.button===0){keys.add('Fire');shoot()}});addEventListener('mouseup',()=>keys.delete('Fire'));
$('sound').onclick=()=>{muted=!muted;$('sound').textContent=muted?'SOUND OFF':'SOUND ON'};
function startReload(){if(!reload&&ammo<30){reload=1.5;tone(280,.1,'triangle')}}
function shoot(){if(!active||reload||cooldown>0)return;if(ammo===0){startReload();return}ammo--;cooldown=.12;flash=.07;tone(150,.09,'sawtooth');let best=null,dist=Infinity;for(const b of bots){if(b.wait)continue;const dx=b.x-p.x,dy=b.y-p.y,d=Math.hypot(dx,dy),angle=Math.atan2(Math.sin(Math.atan2(dy,dx)-p.a),Math.cos(Math.atan2(dy,dx)-p.a));const aimHeight=.62+p.z+p.pitch*d;if(Math.abs(angle)<Math.atan2(.32,d)&&aimHeight>.05&&aimHeight<1.5&&d<trace(p.x,p.y,Math.atan2(dy,dx)).d&&d<dist){best=b;dist=d}}if(best){best.hp-=34;hit=.12;tone(650,.045,'triangle');if(best.hp<=0){kills++;best.wait=2;$('feed').textContent=`YOU eliminated BOT ${bots.indexOf(best)+1}`;if(kills>=20)finish()}}}
function update(dt){if(!active)return;time-=dt;if(time<=0){time=0;finish();return}cooldown=Math.max(0,cooldown-dt);flash=Math.max(0,flash-dt);hurt=Math.max(0,hurt-dt);hit=Math.max(0,hit-dt);if(reload){reload-=dt;if(reload<=0){reload=0;ammo=30}}if(keys.has('Fire'))shoot();let f=Number(keys.has('KeyW'))-Number(keys.has('KeyS')),s=Number(keys.has('KeyD'))-Number(keys.has('KeyA'));const norm=Math.hypot(f,s)||1,speed=(keys.has('ShiftLeft')?4.8:3.1)*dt;move(p,(Math.cos(p.a)*f-Math.sin(p.a)*s)/norm*speed,(Math.sin(p.a)*f+Math.cos(p.a)*s)/norm*speed);p.vz-=11*dt;p.z=Math.max(0,p.z+p.vz*dt);if(!p.z)p.vz=0;
for(let i=0;i<bots.length;i++){const b=bots[i];if(b.wait){b.wait-=dt;if(b.wait<=0)respawn(b,i);continue}const dx=p.x-b.x,dy=p.y-b.y,d=Math.hypot(dx,dy),a=Math.atan2(dy,dx),visible=trace(b.x,b.y,a).d>d;const turn=visible?a:a+Math.sin(performance.now()*.001+b.seed)*2;const strafe=Math.sin(performance.now()*.001+b.seed)*.6;move(b,(Math.cos(turn)*(d>3?1:-.5)-Math.sin(turn)*strafe)*dt,(Math.sin(turn)*(d>3?1:-.5)+Math.cos(turn)*strafe)*dt);b.fire-=dt;if(visible&&d<13&&b.fire<=0){b.fire=1.2+Math.random();if(Math.random()<.65&&p.z<.45){p.hp-=9;hurt=.2;tone(65,.09,'triangle');if(p.hp<=0){deaths++;p.hp=100;p.x=6.5;p.y=11.5;p.z=0;p.vz=0;ammo=30;reload=0;$('feed').textContent='RESPAWNED · Back in the fight'}}}}
}
function render(now){const horizon=h*(.5+p.pitch)+p.z*h*.32;const sky=ctx.createLinearGradient(0,0,0,h*.6);sky.addColorStop(0,'#399bc6');sky.addColorStop(1,'#c9e7dc');ctx.fillStyle=sky;ctx.fillRect(0,0,w,h);ctx.fillStyle='#f3e8b9';ctx.beginPath();ctx.arc(w*.76,h*.2,35,0,7);ctx.fill();for(let i=0;i<22;i++){const x=((i*103-p.a*160)%(w+150)+w+150)%(w+150)-75;ctx.fillStyle=i%2?'#7fbbc2':'#87c5cb';ctx.fillRect(x,horizon-60-i%4*22,65,120)}const ground=ctx.createLinearGradient(0,horizon,0,h);ground.addColorStop(0,'#879b9b');ground.addColorStop(1,'#3a5968');ctx.fillStyle=ground;ctx.fillRect(0,Math.max(0,horizon),w,h);const focal=w*.75;
for(let x=0;x<w;x+=2){const camera=(x-w/2)/focal,angle=p.a+Math.atan(camera),r=trace(p.x,p.y,angle),d=r.d*Math.cos(angle-p.a),height=focal/d,top=horizon-height*.65;zbuffer[x]=zbuffer[x+1]=d;let color=r.tile==='2'?[221,158,103]:r.tile==='3'?[78,155,160]:[198,201,175];const shade=(r.side?.75:1)*Math.max(.3,1-d/28);ctx.fillStyle=`rgb(${color.map(v=>v*shade).join(',')})`;ctx.fillRect(x,top,2,height);const u=r.u-Math.floor(r.u);ctx.fillStyle=`rgba(20,50,60,${u<.025?.4:.12})`;ctx.fillRect(x,top,2,u<.025?height:3);ctx.fillStyle='#203e4e55';ctx.fillRect(x,top+height*.7,2,2)}
const sprites=bots.filter(b=>!b.wait).map(b=>{const dx=b.x-p.x,dy=b.y-p.y;return{b,depth:dx*Math.cos(p.a)+dy*Math.sin(p.a),side:-dx*Math.sin(p.a)+dy*Math.cos(p.a)}}).sort((a,b)=>b.depth-a.depth);
for(const {b,depth,side}of sprites){if(depth<.2)continue;const size=focal/depth,x=w/2+side/depth*focal,y=horizon-size*.67;const left=Math.floor(x-size*.27),right=Math.ceil(x+size*.27);for(let col=Math.max(0,left);col<Math.min(w,right);col++){if(depth>zbuffer[col])continue;const u=(col-x)/size;ctx.fillStyle='#26374c';if(Math.abs(u)<.2)ctx.fillRect(col,y+size*.65,1,size*.35);ctx.fillStyle='#f46f65';if(Math.abs(u)<.25)ctx.fillRect(col,y+size*.26,1,size*.42);ctx.fillStyle='#ffe1ab';if(Math.abs(u)<.14)ctx.fillRect(col,y+size*.04,1,size*.23);ctx.fillStyle='#26374c';if(Math.abs(u)<.15)ctx.fillRect(col,y,1,size*.09);if(u>-.14&&u<.14){ctx.fillStyle='#243845';ctx.fillRect(col,y+size*.14,1,size*.045)}}}
// Weapon silhouette and muzzle feedback.
const bob=active&&(keys.has('KeyW')||keys.has('KeyA')||keys.has('KeyS')||keys.has('KeyD'))?Math.sin(now*.012)*4:0;ctx.save();ctx.translate(w*.64,h+bob+(reload?Math.sin(reload/1.5*Math.PI)*110:0)+(flash?18:0));ctx.fillStyle='#e6bc97';ctx.beginPath();ctx.moveTo(25,0);ctx.lineTo(75,-95);ctx.lineTo(125,-70);ctx.lineTo(110,0);ctx.fill();ctx.fillStyle='#182d3b';ctx.beginPath();ctx.moveTo(35,0);ctx.lineTo(-35,-145);ctx.lineTo(-22,-190);ctx.lineTo(15,-195);ctx.lineTo(125,-45);ctx.lineTo(135,0);ctx.fill();ctx.fillStyle='#425e6c';ctx.beginPath();ctx.moveTo(-35,-145);ctx.lineTo(-22,-190);ctx.lineTo(15,-195);ctx.lineTo(70,-110);ctx.lineTo(45,-85);ctx.fill();ctx.fillStyle='#d9ff69';ctx.fillRect(10,-140,12,35);ctx.fillStyle='#162936';ctx.fillRect(-15,-210,14,35);if(flash){ctx.fillStyle='#fff5ad';ctx.beginPath();ctx.moveTo(-10,-195);ctx.lineTo(-55,-235);ctx.lineTo(-18,-220);ctx.lineTo(-5,-270);ctx.lineTo(7,-222);ctx.lineTo(36,-240);ctx.lineTo(13,-195);ctx.fill()}ctx.restore();if(hurt){ctx.fillStyle=`rgba(240,55,50,${hurt})`;ctx.fillRect(0,0,w,h)}
$('health').textContent=p.hp;$('healthbar').style.width=p.hp+'%';$('score').textContent=String(kills).padStart(2,'0');$('ammo').innerHTML=`${ammo} <em>/ ∞</em>`;$('clock').textContent=`${Math.floor(time/60).toString().padStart(2,'0')}:${Math.floor(time%60).toString().padStart(2,'0')}`;$('reload').textContent=reload?'RELOADING…':'R TO RELOAD';$('hitmarker').style.display=hit?'block':'none';
}
function frame(now){const dt=Math.min(.04,(now-last)/1000||.016);last=now;if(!started)p.a+=dt*.045;update(dt);render(now);requestAnimationFrame(frame)}
reset();started=false;requestAnimationFrame(frame);
