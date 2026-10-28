# Offline original-build runtime and explorer verification

Latest result: [FREEZE-FIX.md](FREEZE-FIX.md) replaces the earlier unverified startup status with independent responsiveness and native offline-prompt tests. The current preview reaches the original lobby without a page-wide hang in those tests; a playable match is not established.

Latest update: [LOCAL-MODE.md](LOCAL-MODE.md) documents explicit network isolation and the disabled engine link bridge. Earlier captures below describe behavior before this update.

## Startup error correction

The later loader fix supplies an idempotent Module.QuitCleanup that drains registered deinitializers, implements local cursor/device helpers, and explicitly marks unavailable host services without fabricating account/ad/version responses. Popup requests remain blocked, with duplicate messages reduced and URL query values excluded from logs. Empty status messages are no longer printed.

REA retest `ev_2c9ff968c650d05376e1aadf49a047709b9eb218d9fe76c96934796febc6b43f` loaded the original client and waited 20 seconds. It captured no page errors, no missing-host ReferenceErrors, and no QuitCleanup TypeError. The client still requests shutdown after attempting a link to https://kour.io/ in the offline preview. The loader now cleans up and reports that outcome instead of throwing. The exact cause of the client's shutdown is not established merely by this sequence. Shader/audio diagnostics remain separate limitations.

Evidence: `../runtime-startup-fix.json`; concise checks: [startup-fix-verification.json](startup-fix-verification.json). `node tools/check-original-loader.mjs` verifies one-time cleanup, callback-failure isolation, cursor behavior and offline-message handling. The earlier runs below describe historical failures before this correction.

## Result

The supplied original WASM/data **did reach a rendered KOUR.IO menu/background** in a local, headless Microsoft Edge/Chromium session after three narrowly scoped compatibility fixes to served JavaScript and reconstruction of missing loader configuration. It did not reach a verified playable match. The screenshot is [original-wait_runtime.png](original-wait_runtime.png).

The runtime itself logged Unity **6000.2.7f2 (2b518236b676)**, WebGL 2.0, PhysX 4.1.2, and loading player data from `data.unity3d`. This corroborates static asset version identification with actual execution.

The screenshot shows the KOUR.IO header, Login/Signup, Discord button, currency UI, a guest menu entry and original town background. A status says `Connecting...`. Missing host-page JavaScript and quit-cleanup integration produced errors and ultimately halted the runtime. No multiplayer functionality, login, or online service behavior was established.

Captured missing host functions were `setCursor`, `testDevice`, `SetAds`, `checkVersion`, and `requestUserData`; the final quit path also expected `Module.QuitCleanup`. These are concrete missing dependencies of the supplied build's surrounding page, not recovered service implementations. The diagnostic deliberately does not invent working login/ads/backend replacements.

## Reconstructed offline harness

Run `node tools/serve-original.mjs`, then open http://127.0.0.1:8082/ and click **Load original files offline**. This harness is diagnostic only. It mounts the eight supplied UnityWebData members, supplies `SystemInfo` and Emscripten/Unity loader arrays, and maps the WASM request to `source.wasm`.

The server allows only five local paths. CSP blocks nonlocal connection/resource/frame/form endpoints; `window.open` is replaced with a blocking diagnostic function. No live Kour.io/Photon backend was intentionally contacted. The game attempted a remote connection and CSP blocked it. Browser background networking is outside the page evidence's coverage; this claim concerns page requests, not every process packet.

### Input defect and exact compatibility changes

The supplied `framework.js` contains `build.wasm.html` and standard stream opens for `dev/stdin.html`, `dev/stdout.html`, `dev/stderr.html`. The standard devices created elsewhere in that same file are `/dev/stdin`, `/dev/stdout`, `/dev/stderr`. This mismatch caused the first post-mount filesystem failure. A download/save rewrite is a plausible explanation, but its origin is unknown.

`tools/serve-original.mjs` replaces exactly one occurrence of each of those three stream paths in the HTTP response. The on-disk original file remains unchanged. The WASM path is handled by the diagnostic loader's `locateFile`, not a binary patch. Exact source/served SHA-256 and replacement source offsets are in [compatibility-manifest.json](compatibility-manifest.json). Consequently this execution is a controlled compatibility replay, not evidence that the untouched supplied framework runs as-is.

## REA MCP evidence

All runs used `capture_browser_scenario` launch mode with the installed Edge executable, a new owned temporary browser profile, explicit click/wait actions, and console/page-error/network plus final screenshot/DOM selection.

| Run | Evidence ID | Outcome |
|---|---|---|
| First | `ev_630510d0c6af5d60443a899b3eda6163337e07a90f1ca2585bbb6efbff1656d4` | Literal `build.wasm.html` not found; corrected diagnostic `locateFile` afterwards. |
| Second | `ev_9ebc75afa77311dc650e4cda74660ccc596fafce1bdf98a51b936cd5b0fafe34` | WASM loaded and eight files mounted; standard-stream FS error. |
| Third | `ev_f2e37d34f245e2a64e9a8544a7f9c79fcb9845e7db4ca1fe8549ee2f10c9db31` | Fixed stream mismatch; runtime initialized; missing `Module.deinitializers` integration caused failure. |
| Final | `ev_38c7bbb73d006c8479b13b9040aba7e294bc636d03b705fd8b7b9d1bcbaa5701` | Added loader deinitializers array; Unity loaded original assets and rendered original menu; missing host callbacks and quit integration limited operation. |

Full captured records: `../runtime-first.json`, `../runtime-second.json`, `../runtime-third.json`, `../runtime-final.json`. All successful REA results report `browser.cleanup: terminated-owned-process`.

## Explorer browser QA

REA capture `ev_47031fe7642d39ff79e620350a31060c7db8a63043b832ce599a488dda1d7b9c` performed these completed actions: load catalog, select Meshes, preview the first OBJ, wait for geometry, select Gameplay settings, search Weapon, expand the first matching settings record, return to Textures. There were no captured page errors; a harmless missing favicon returned 404. The browser was terminated by REA after capture.

The mesh screenshot visually confirms exported original geometry appears in the rotating wireframe preview: [explorer-preview_mesh.png](explorer-preview_mesh.png). The final texture screenshot and expanded weapon settings screenshots are in this directory. Full evidence is `../runtime-explorer.json`.

This QA verifies those specific interactions on the generated catalog. It does not establish every exported asset renders correctly or that all audio files play on every browser. The first browser test had a test-selector ambiguity (`.card button` matched all mesh buttons); the corrected selector targeted `.card:first-child button` and completed all actions.
