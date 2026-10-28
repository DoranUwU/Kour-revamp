# Verified native KourStrike offline gameplay

## Result

The original supplied client now loads the acquired public **map7 / Kour2** bundle locally, enters native **Search And Destroy**, selects a team, completes its original warmup, spawns a first-person player, fires the pistol, reloads and responds to forward movement input.

This is the native Unity game, not the separate original-code raycaster prototype. This test establishes local solo gameplay with the reconstructed host/loader and derived KourStrike profile. It does not establish online play, opponents, bots, or every game-mode feature.

## Reproduction observed

The final test restarted the independent server on port8085 after the parent added the real Unity fetch-progress bridge and narrowly fixed the supplied cursor-helper receiver. A fresh owned Edge browser:

1. Clicked **Load KourStrike**, waited nine seconds, then clicked **Start KourStrike offline**.
2. Requested `http://127.0.0.1:8085/StreamingAssets/map7?v=4.24` and received HTTP200.
3. Rendered the actual map and native **Select a Team!** panel, then auto-selected the Terrorist side during the native countdown.
4. Waited for the original warmup to complete. The native buy wheel appeared with $800, and the first-person player spawned with health100 and pistol ammo16/16.
5. Two ordinary canvas left-clicks fired the native pistol, reducing its ammo to14/16.
6. Pressing **R** and waiting for the native reload restored ammo16/16.
7. Twelve ordinary short **W** keypresses moved the player forward: on-screen site distances changed B173m to171m and A180m to178m, with corresponding wall/arch perspective changes. No mouse input occurred between the reload and forward-movement screenshots.
8. The original round displayed **Round1 / Plant the bomb** and a decreasing round timer. The host response check remained responsive.

The final test captured zero page-error events and only local startup/config/map requests. The additional browser route guard intercepted no external requests. No explicit queue unpause or speculative native operation was used in this successful run; the standard host button and original callbacks resumed the Photon message queue automatically.

## Runtime state

The parent-verified read-only native getters returned `offline:1`, `inRoom:1`, `isConnected:1`, `ready:1`, `networkState:9`, `queue:1`, and `master:1`. The function names matched the recovered method table (`set_OfflineMode` func24949 and `UIManager.LoadForceMap` func76698). This is an original Photon offline room, not a fabricated server response.

## Evidence and screenshots

- [kourstrike-ui-match-evidence.json](kourstrike-ui-match-evidence.json): final actions, request URLs/statuses, console output, errors, read-only state and owned-browser cleanup.
- [kourstrike-ui-match-after-start.png](kourstrike-ui-match-after-start.png): original team selector over map geometry.
- [kourstrike-ui-match-warmup.png](kourstrike-ui-match-warmup.png): original buy wheel and first-person pistol16/16 after native warmup.
- [kourstrike-ui-match-fired-pistol.png](kourstrike-ui-match-fired-pistol.png): native Round1, first-person pistol and ammo14/16 after the shots.
- [kourstrike-ui-match-reload-complete.png](kourstrike-ui-match-reload-complete.png): ammo restored16/16.
- [kourstrike-ui-match-after-w-input.png](kourstrike-ui-match-after-w-input.png): translated first-person view and reduced site distances after W input.

These are ordinary Playwright observations with screenshots inspected visually. The runtime driver used the existing installed Playwright dependency because the REA click schema does not provide canvas coordinates. The native REA response-body acquisition of map7 has its separate receipt and Evidence ID in [kourstrike-ui-map7-acquisition-report.md](kourstrike-ui-map7-acquisition-report.md).

## Failures resolved before this successful run

Earlier attempts issued no map HTTP request because the reconstructed loader lacked Unity's `fetchWithProgress` contract. The parent added a real local fetch/progress/body bridge, after which native requests reached the local bundle.

The first real map load then halted at `_isCursorLocked` with `this.isMobileDevice is not a function`. The parent changed only the served compatibility copy to call the already-existing internal `_isMobileDevice()` detector. The original input framework file remained unchanged. The final test restarted the server to use that prepared served source.

Earlier native-map/state probes are preserved separately and should not be confused with the successful standard-button path in the final evidence.

## Remaining limits

The engine logs audio decode failures (`Loading FSB failed`) for several original audio clips, including pistol/reload clips; sound was not verified. Shader, missing-script and negative-scale collider warnings also appear. The acquired bundle is Unity6000.0.10f1 while the supplied client is6000.2.7f2: this run verifies the observed scene and basic controls work across that difference, not complete compatibility of every asset or feature.

The owned test browser closed successfully and the independent port8085 server was stopped. The retained native warmup was not skipped or altered by the test.
