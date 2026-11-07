# Game sound and spatial footsteps

The game uses its original Unity Web Audio sources and original audio clips. Sound is enabled after loading; click inside the game or use **Sound → Enable sound** if the browser pauses audio. The Sound panel provides master volume and mute, saved locally in your browser.

Native remote footsteps already follow replicated player motion. Opponents hear directional footsteps that become quieter with distance and stop when the player stands still or is airborne. Existing native crouch volume behavior is retained. There is no added audio stream or footstep RPC: Photon already carries the movement and animation state used by these sources. Volume and mute control your playback locally.

## Browser API

After the game has loaded:

```js
gameAudio.setVolume(0.8); // Range 0–1; values outside it are clamped.
gameAudio.setMuted(false);
await gameAudio.resume(); // Call from a user interaction if playback is paused.
gameAudio.inspect(); // Readiness, volume, decoded clips and active channels.
```

## Repair

The reconstructed host omitted Unity's `Module.setInterval` and `Module.clearInterval` contract. The audio initializer called the missing helper before setting its enabled flag, caught the exception as an unsupported-audio error, then left native clip loading disabled. This caused misleading `Loading FSB failed` messages even though the original AAC payloads decode in the browser.

The loader now supplies owned timer helpers and clears them during teardown. Guarded framework changes expose readiness and route native source gains through one master gain. Native clip decoding, position/panning, attenuation, motion gating and playback timing remain in Unity. No original game/audio asset bytes or WASM instructions change for this repair.

## Verification

- The exact original initializer reproduces disabled audio without host timers and initializes successfully with them.
- Native map playback decoded 11 clips with nonzero PCM and no load errors in the sampled run; clips load on demand, so this does not claim every clip was exercised.
- Two real clients on opposing teams rendered the remote player's actual footstep loop. Stereo RMS measurements favored the left ear for a left-side enemy and the right ear for a right-side enemy. Idle footstep output was zero; distant footsteps were strongly attenuated. This is distance falloff, not a claimed hard silence cutoff.
- Volume and mute controls passed, including measured zero master output while muted. A native weapon AudioSource also played its original gunshot clip without decode errors.
- Tests inspect rendered audio graphs; physical speaker/headphone output was not recorded. Raw evidence stays in ignored `local/audio/` and `local/multiplayer/`.

Core checks include `tools/check-audio-backend.mjs` and `tools/check-game-audio.mjs`. Live two-client test: `node tools/test-spatial-audio.mjs` with a Photon preview on port 8088, or set `PHOTON_TEST_URL` to a hosted build. Use `PHOTON_TEST_REGION=hk`. Browser test requirements match the existing multiplayer suite.
