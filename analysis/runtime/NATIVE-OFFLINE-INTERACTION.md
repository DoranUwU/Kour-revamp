# Native offline prompt and Play Now interaction

REA's installed `capture_browser_scenario` click schema supports a DOM locator, mouse button and click count, but no canvas coordinates. These two precise canvas-interaction tests therefore used the existing installed `playwright-core` dependency directly. Their JSON files are ordinary Playwright observations, **not REA Evidence records**. No game/loader/server source was changed by the test. The test driver is [verify-offline-click.mjs](verify-offline-click.mjs).

Each test launched a fresh owned installed Edge browser, opened the parent-owned local server at `http://127.0.0.1:8083/`, and routed any nonlocal request to `abort('blockedbyclient')` as an additional guard. The page's existing offline policy and CSP remained active. Both browsers were closed successfully. The test did not touch another agent's existing browser processes.

## Native Offline OK

After clicking Start and waiting ten seconds, the driver captured the original offline prompt, then clicked viewport coordinate **(732,332)**: the green native **OK** button. After another ten seconds it clicked the host response checker and captured the result.

Observed result: the native offline prompt closed and the original lobby became available, showing the character and **PLAY NOW / SERVER FINDER** controls. `HOST PAGE RESPONSIVE` was logged. There were no page-error events. Some caught missing-host callback errors and FMOD audio decode errors remained. A responsive lobby is established; a playable match is not.

Evidence and screenshots:

- [offline-native-ok-playwright.json](offline-native-ok-playwright.json)
- [offline-before-native-ok.png](offline-before-native-ok.png)
- [offline-after-native-ok.png](offline-after-native-ok.png)

## Native Play Now

A second fresh launch repeated native Offline OK, then clicked viewport coordinate **(1140,426)** in the green **PLAY NOW** button, waited twelve seconds, clicked the host response checker and captured the result.

Observed result: the original lobby remained visible rather than entering a map. Two host responsiveness checks completed; there were zero page errors. The console reported a caught missing host callback `SetURL`, plus audio decode errors. The driver observed only six local request paths: `/`, `/offline-policy.js`, `/framework.js`, `/loader.js`, `/game.data`, `/source.wasm`. No map-asset request or external request interception occurred during this bounded window. These observations do not establish why map entry failed or whether a different native configuration can load a supplied map.

Evidence and screenshot:

- [offline-native-play-playwright.json](offline-native-play-playwright.json)
- [offline-after-play-now.png](offline-after-play-now.png)

The parent updated missing local host callback implementations between the tests. Each JSON captures the actual console/request behavior of its own fresh launch; the two tests should not be interpreted as byte-identical loader comparisons.
