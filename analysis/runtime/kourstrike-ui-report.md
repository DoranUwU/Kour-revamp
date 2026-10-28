# Native KourStrike selection UI investigation

## Verified result

The original client can select **Search And Destroy** in the supplied lobby. A concrete recovered method call changes its own GAME MODE label and icon. A playable original KourStrike scene was not loaded in this test.

The ordinary Playwright driver used an independent local server on port8085, a new owned installed Edge browser, the existing offline policy/CSP, and an additional route abort for any nonlocal request. No original client, loader or server source was changed for this investigation. Screenshots and console/request captures are local artifacts prefixed `kourstrike-ui`.

## Concrete method provenance

- `analysis/metadata/gameplay.json` has `UIManager.ForceSetGameMode(string x)`, method index33649, token `0x06000f7a`, instance flags134.
- `analysis/assets/decoded-behaviours/level0.json` locates the `UIManager` component on GameObject **Canvas**.
- The asset's exact game-mode name is **Search And Destroy**, ID8, with forced map indices8/9/11 (`analysis/assets/game-modes.csv`).

The driver therefore used only this established Unity bridge call:

```js
window.originalModule.SendMessage('Canvas', 'ForceSetGameMode', 'Search And Destroy');
```

The resulting original lobby screenshot [kourstrike-ui-forced-search-and-destroy.png](kourstrike-ui-forced-search-and-destroy.png) visibly shows **Search And Destroy** with the yellow crossed-swords icon. This is native game UI, not an HTML imitation.

## Native click attempts and limitations

After original Start and acceptance of the native offline prompt:

- Clicking the lobby GAME MODE selector at viewport(1195,375) did not open a selection panel.
- Clicking SERVER FINDER at(1140,488) did not open a room list or creation panel.
- After the proven ForceSetGameMode call, clicking PLAY NOW at(1140,426) and waiting ten seconds left the client in the lobby. Screenshot: [kourstrike-ui-search-and-destroy-play.png](kourstrike-ui-search-and-destroy-play.png).

The recorded requests during the ForceSetGameMode/Play Now test were only the initial six local paths: `/`, `/offline-policy.js`, `/framework.js`, `/loader.js`, `/game.data`, `/source.wasm`. There was no captured map/prefab-bundle request and no page-error event. This bounded UI test alone does not prove the cause of the failed match transition. The wider static asset investigation separately establishes the supplied registered scene table contains only Lobby and does not include required KourStrike map scenes8/9/11.

The test did not invent a backend, fabricate a room, change matchmaking state, guess an emergency password, or invoke an unknown compiled function. It cannot establish original online match operation from these client files alone.

## Reproduction and evidence

`tools/test-kourstrike-ui.mjs --force-search` launches the local browser and selects the proven native mode. It uses the already-installed Playwright dependency because the REA scenario click schema has no coordinate position argument. Its evidence is ordinary Playwright output, not a REA Evidence record. Final console/network/actions/cleanup are in [kourstrike-ui-evidence.json](kourstrike-ui-evidence.json). The first exploratory native selector/server-finder screenshots are also retained, although the final JSON belongs to the later mode-selection run.
