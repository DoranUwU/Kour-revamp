# Local-only preview

Latest result: [FREEZE-FIX.md](FREEZE-FIX.md). The served build now skips the hostname-failure quit and returns offline immediately from the synchronous internet probe. Independent tests reached a responsive original lobby; map entry is still unresolved.

Update: [LOCAL-HOST.md](LOCAL-HOST.md) describes the later targeted change to the served WASM's hostname-failure quit. Shutdown observations below are from the earlier, unpatched runtime. The new runtime capture did not complete.

The preview disables external HTTP requests, WebSockets, EventSource streams, beacons, popup/HTML links and the engine OpenURL bridge. Only allowlisted local asset paths are permitted. CSP also restricts connections/resources, workers, frames and form submissions. Original inputs are preserved; the engine bridge changes only in served JavaScript. No original service is emulated.

Restart the server after this update with `npm.cmd run preview:original`, reload http://localhost:8082/ and select **Load local build**.

The original branding and service strings remain inside the preserved compiled files. Disabling outgoing behavior does not change licensing or replace server functionality. The original client still requests shutdown in local mode. Making it independently playable requires replacing service-dependent gameplay systems.

The separate original-code bot arena (`npm.cmd start`, port8080) now uses system fonts without remote font requests. It does not use the supplied original client/services.

## Verification

`node tools/check-offline-policy.mjs` checks fetch/XHR allowlisting, rejected external requests, disconnected sockets, disabled beacons/links, the neutralized engine bridge and removal of remote fonts. `node tools/check-original-loader.mjs` covers cleanup and host callbacks.

REA scenario `ev_06d4cd3c6e297b928f30909184174cc15eaddec57a3220d4b22dc459c64aaae0` observed 20 seconds of startup, with no page errors and no nonlocal page requests. The framework reached ready state and the original client requested shutdown. The owned browser was terminated. Full capture: ../runtime-offline-policy.json; summary: offline-policy-verification.json. This is page-level observation, not a process-wide packet capture.
