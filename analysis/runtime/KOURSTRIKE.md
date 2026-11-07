# Local KourStrike / Search And Destroy

The supplied client now loads the original **Kour2** scene and starts a local offline **Search And Destroy** room. Native team selection, player spawning, pistol firing, reload and forward movement were exercised in a fresh browser. This is the original engine/controller/map path, separate from the earlier canvas prototype.

## Play

Stop any old preview server and close its old/frozen tab. From the workspace:

```powershell
npm.cmd run preview:kourstrike
```

Open http://localhost:8082/ in a new tab:

1. Select **Load KourStrike** and let the original lobby initialize.
2. Select **Start KourStrike offline**.
3. Choose Terrorists or Counter-Terrorists, or allow auto-selection.
4. Allow the original initial warmup (up to about two minutes) to finish. Close the native buy menu when needed and click the game to focus it.
5. Move with WASD, aim with the mouse, fire with the left mouse button and reload with R.

The test used a single local player. It does not establish online multiplayer, AI opponents, a complete bomb-plant/defuse cycle, or every native feature. Only Kour2/map7 is acquired; other map choices are not included. Some audio clips still produce decode errors.

## What changed

- Twelve-round halftime swaps T/CT rosters and score ownership synchronously before round13. Native spawn and C4 logic use the new teams. A separate removable Debug: rounds panel can start a requested round or end an action phase. See HALFTIME.md for usage and runtime verification.

- The served startup archive sets SdkManager.gameType from0 to1 (KourStrike). The UnityFS archive and its containing UnityWebData offsets are rebuilt; every unrelated member/scene byte is checked against the originals.
- Three build-specific WASM immediate changes select Search And Destroy at gameModes index6 (modeID8), with room map index8 (bundlemap7). Earlier local hostname/probe compatibility remains.
- Local cash experiment: a seven-byte patch in SearchAndDestroyManager.OnStateChanged changes the buy-phase cash calculation to the native cap of14000. The existing ObscuredInt conversion, setter, HUD callbacks and purchase deductions remain. The state-change guard prevents repeated callbacks from replenishing cash during shopping. See round-cash-report.md for the exact original/replacement instructions.
- Original native Photon offline-mode and LoadForceMap calls create the local room; no account/backend response is fabricated.
- The asset-loading base is an absolute local StreamingAssets URL. The client/server allowlists cover map7/map8/map10 and the 34 exact mesh-bundle names recovered from LoadMyMesh components, including nested grenade meshes. All original service connections remain disabled.
- Missing weapon geometry is supplied by 34 separately acquired static mesh bundles (3,301,913 bytes total), served from original-preview/StreamingAssets/. Mesh records, UnityFS headers and acquisition hashes are verified by tools/check-mesh-assets.mjs. Source builds remain unchanged.
- Eight default PNG textures (MP5, AWP, revolver, HE grenade, smoke, flashbang, Molotov and C4) are mirrored under original-preview/content/stream/weapon-skins/texture/. The server injects only their explicit path allowlist into the offline policy; native legacy image URLs are translated to local fetch/XHR requests before reaching the browser network. Optional size queries are accepted and preserved; these local files are the unresized original images. Unknown images, unrelated hosts, redirects, and write requests through these aliases remain blocked. See WEAPON-COLOR-ASSETS.md, EQUIPMENT-COLOR-ASSETS.md and weapon-color-report.md.
- Match startup enables the native renderWeapon setting. The launcher Show gun button calls the same original settings handler to restore the weapon camera during play. It checks the expected compiled function name/signature; other settings are preserved.
- The missing Unity HTTP loader contract is now implemented: Module.fetchWithProgress returns a real Response with parsedBody Uint8Array and delivers native streaming progress chunks. Its absence previously caused caught native failures before any HTTP request.
- The served cursor-lock helper calls the framework's existing _isMobileDevice function instead of an absent external this.isMobileDevice hook. Original files are preserved.

Derived startup data is cached under original-preview/generated/. Builder/source hashes are checked before reuse. The exact changed ranges are in kourstrike-profile-manifest.json.

## Map acquisition and compatibility

The user explicitly authorized a one-time static map acquisition. The native REA GET to https://kourstrike.io/StreamingAssets/map7?v=4.24 returned200 and an exact unredacted retained body. After the normal MCP transport size limit, the official evidence export was used; no browser-download cancellation policy was bypassed. Receipt: kourstrike-ui-map7-receipt.json. REA evidence: `ev_eba811e12d3e015b4280236acf9424243cb4f31d128acbb3ca19d1de7a54d25b`.

The file is 5,611,470 bytes, SHA-256 `f86a722b8d0936beb3010ad0e9591c439b54c557d4289ab131368cfa3e945828`, Unity6000.0.10f1. It contains Assets/map7.unity as a streamed scene with no declared bundle dependencies. MapInfo and SearchAndDestroyManager serialization hashes match the supplied client. Some UI/console compatibility differences remain; see analysis/maps/map7/REPORT.md.

## Validation

`npm.cmd run test:kourstrike` verifies the derived archive, bounded code changes, native HTTP bridge contract, local bootstrap API calls, missing-file handling and external network rejection. The original static functions were also exercised with synthetic native callbacks to reproduce the missing-fetch-helper failure before fixing it.

Runtime proof is retained in kourstrike-ui-match-evidence.json and the match screenshots. Observed: local GET /StreamingAssets/map7?v=4.24 returned200; the native Photon offline room was joined and its queue resumed; team UI and the actual map rendered; Round1 displayed **Plant the bomb**; native pistol ammo changed16->14 after firing, then14->16 after R; forward input changed site-marker distances173m->171m and180m->178m. No page errors or original service connections occurred during the final local gameplay test.

These canvas interactions used the already installed Playwright driver because REA's scenario action schema does not expose canvas-coordinate clicks. They are ordinary runtime observations, not falsely labeled REA Evidence. Each successful owned test browser was closed by its driver. Earlier stalled probes and their limits remain documented separately.
