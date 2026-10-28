# Counter-Terrorist first-person weapon visibility verification

## Result

The native Counter-Terrorist **USPS is visible after spawn** with the recovered local mesh bundles and the original render-weapon setting enabled. I inspected [weapon-ct-spawn.png](weapon-ct-spawn.png): it clearly shows the first-person suppressed black pistol and hands near the bottom center/right, ammo **12/12**, and the separate third-person M4 preview on the buy screen. The first-person pistol is not merely an ammo counter or preview model.

## Test

A fresh independent server on port8087 served the integrated local bundle allowlist. A fresh owned installed Edge browser loaded the existing local KourStrike profile, clicked Start match and selected the native **Counter-Terrorists** card before auto-selection. The test used a validated read-only TeamSelectPanel active-state probe to time that ordinary UI click; it did not assign a team by modifying game memory.

The [CT-selected screenshot](weapon-ct-ct-chosen.png) shows **You** on the right-hand blue CT side. After the unmodified native warmup, the game spawned the CT player and the first-person USPS mesh rendered during the native buy phase.

Captured local responses:

| Native request | Status |
|---|---:|
| `/StreamingAssets/map7?v=4.24` | 200 |
| `/StreamingAssets/m4a4?v=4.24` | 200 |
| `/StreamingAssets/usps?v=4.24` | 200 |

There were **zero captured page errors and zero external requests**. A test-driver route guard would abort nonlocal requests; none were attempted. Full actions, URLs/statuses, console output and cleanup are retained in [weapon-ct-browser.json](weapon-ct-browser.json).

## Scope and limits

This confirms the previously missing separately bundled CT firearm mesh is now loaded by the original game and visible in the first-person view. Static null-mesh findings and bundle acquisition provenance are recorded in the separate asset report. This CT run did not capture a pre-acquisition invisible-USPS screenshot, so it is an after-integration verification rather than a complete CT before/after reproduction.

The run ended after the spawn screenshot; it did not execute the optional later hide/show, fire, reload or resize checks. Those actions should not be attributed to this CT evidence. The parent separately retained Glock hide/show and resize screenshots, and the earlier native gameplay report separately verifies Glock firing/reloading/movement.

The browser closed successfully (`cleanup: closed-owned-browser`) and the owned port8087 server was stopped. No shared launcher/server source was edited by this test. The driver is [test-kourstrike-ct-weapon.mjs](../../tools/test-kourstrike-ct-weapon.mjs).
