# Local host shutdown

Latest result: [FREEZE-FIX.md](FREEZE-FIX.md) documents the additional immediate-offline probe and independently verified responsive menu. The hostname-only version described below is historical; current serving changes both identified functions, with exact ranges in local-host-wasm-manifest.json.

The compiled `SdkManager.CheckHost` (WASM function74474, metadata method32721) obtains Application.absoluteURL, parses its hostname, and checks the instance's allowedHosts strings. Its failure branch logs an error, calls Application.OpenURL four times, then Application.Quit. The four outbound-link attempts followed by shutdown therefore have a concrete code path independent of connection/cleanup failures.

The direct-call scan and complete CheckHost disassembly are retained in shutdown-calls.json. The scan validates decoded call instructions rather than treating arbitrary matching bytes as references. This is static evidence; runtime observations are recorded separately.

`tools/original-wasm.mjs` prepares a derived response for the local preview. For the exact supplied SHA-256 only, it replaces the Application.Quit call at byte23683617 with drop plus nops, consuming the hidden method-info argument and preserving body size. Other bytes, metadata, other quit call sites and all network isolation remain unchanged. The original source.wasm is never overwritten. The transformed module must pass full V8 WASM validation before serving.

Run `node tools/check-local-wasm.mjs` for byte-boundary, unknown-build rejection and module validation checks. The exact before/after bytes and hashes are in local-host-wasm-manifest.json. Restart `npm.cmd run preview:original` after updates to load the new served response.

This permits the local preview to continue past this hostname-failure quit. It does not implement the original online multiplayer, authentication, ads, maps or other missing services. The failed-host diagnostic can still appear, and outbound links remain disabled.

## Verification boundary

Static checks passed: exact source hash, validated target instruction, unchanged bytes outside that instruction, unchanged module length, valid derived WASM, and rejection of unknown builds. Loader/offline-policy regression checks also passed. The subsequent 30-second REA runtime scenario stalled before returning evidence and was cancelled; no new successful runtime capture is claimed, and browser cleanup was not confirmed by a returned REA result. The owned HTTP test server was stopped. The new runtime behavior and full menu responsiveness remain to be checked manually.
