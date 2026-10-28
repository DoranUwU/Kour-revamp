# Responsive offline startup

The local-host quit change alone did not address the later page-wide hang. Static inspection found a subsequent disconnect path: NetworkManager.OnDisconnected -> IsInternetAvailable -> synchronous System.Net.WebClient.OpenRead("https://google.com"). The compiled call sites and exact string linkage are retained in freeze-static-report.md. A paused CPU stack could not be acquired, so that static path should not be misrepresented as a captured runtime stack.

For this explicitly disconnected preview, the served copy now returns false immediately from NetworkManager.IsInternetAvailable. Its signature is `(i32 this, i32 MethodInfo*) -> i32 bool`; the local variables, module size, surrounding functions and original source file are preserved. The prior hostname-failure quit change remains. Neither change enables external services.

## Verification

- The complete transformed module validates with V8; byte comparisons bound both changes precisely and reject an unknown original build.
- The exact modified offline-probe body was extracted into an isolated minimal WASM module and executed with different arguments; it immediately returns false. This is not execution of the whole original game.
- HTTP response SHA-256 matched the transformed module manifest.
- Independent REA run `ev_0194f7ad68e4dd2a8c1e41edcc19d2b629f66553c031fe008b001dad2fe40712` performed two successful host response-check clicks separated by ten-second startup/observation windows. There were no page errors or shutdown messages. Its owned browser was terminated.
- A separate REA capture `ev_5f3d78a518f11299a53551a777c8720b7dc1dd06a9b2a442a13e39e7dd42794e` showed the original native offline-mode prompt.
- Ordinary installed Playwright tests clicked the native Offline OK and Play Now canvas controls. OK exposed the original lobby. Play Now did not load a map in twelve seconds; the host remained responsive with zero page errors. These coordinate-click observations are not REA Evidence. See NATIVE-OFFLINE-INTERACTION.md.

The independent runs used fresh browser instances and confirmed their cleanup. Earlier root-agent capture/probe attempts stalled or lost debugger connections and did not yield successful verification; their temporary browser cleanup was not universally confirmed. They are not substituted for the independent successful runs above.

## Restart the actual updated preview

Close the already-frozen tab; its old running WASM cannot be replaced in place. Stop the preview server with Ctrl+C, then run:

```powershell
npm.cmd run preview:original
```

Open http://localhost:8082/ in a new tab, select **Load local build**, then choose **OK** when the original client asks to try offline mode. **Check page response** appends HOST PAGE RESPONSIVE to the log when the browser's main thread is responding.

## Remaining scope

This verifies responsive original-client startup and an accessible lobby, not a playable original match. Map entry remains unresolved. Original backend/account services remain disabled, and some native audio payloads produce FMOD decode warnings. Local cursor/telemetry/room-link callbacks now have explicit local behavior, including disabling SetURL room sharing rather than navigating to original services.

Regression commands: `node tools/check-local-wasm.mjs`, `node tools/check-original-loader.mjs`, `node tools/check-offline-policy.mjs`. The exact hashes and ranges are in local-host-wasm-manifest.json.
