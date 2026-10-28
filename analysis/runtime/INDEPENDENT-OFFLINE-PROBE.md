# Independent offline-startup verification

This is a later verification of the reconstructed local harness at `http://127.0.0.1:8083/`, after the parent implementation added a served-WASM offline probe override for `NetworkManager.IsInternetAvailable`. That override returns false to avoid the original synchronous external internet probe. It is a deliberate offline compatibility change; these results do not describe the unmodified build.

REA launched a fresh installed Edge/Chromium browser and performed:

1. Click `#start`.
2. Wait ten seconds.
3. Click `#check-response`.
4. Wait another ten seconds.
5. Click `#check-response` again.

All actions completed. Console evidence contains two `HOST PAGE RESPONSIVE` messages, runtime/input initialization, zero page-error events, and no `Halting program` or shutdown messages during this observation. The page still logged caught ReferenceErrors for missing host callbacks `AllowCtrlW`, `UnlockCursor`, and `gameplayStart`. This verifies browser-host JavaScript responsiveness over the twenty-second test window; it does not by itself verify gameplay simulation, framerate, or multiplayer.

Evidence: `ev_0194f7ad68e4dd2a8c1e41edcc19d2b629f66553c031fe008b001dad2fe40712`, saved in [offline-probe-independent.json](offline-probe-independent.json). REA reports `browser.cleanup: terminated-owned-process`.

A separate fresh browser run clicked start, waited ten seconds, clicked the response check, and captured a screenshot. It completed and cleaned up. Evidence: `ev_5f3d78a518f11299a53551a777c8720b7dc1dd06a9b2a442a13e39e7dd42794e`, saved in [offline-probe-screenshot.json](offline-probe-screenshot.json).

The visually inspected screenshot [offline-responsive-menu.png](offline-responsive-menu.png) shows the original KOUR.IO menu, character/rifle and side navigation, with the game's modal **No Internet Connection! Try Offline mode?** and Cancel/OK buttons. No interaction with those canvas buttons was performed in this verification. A verified playable offline match remains a separate question.

These were new provider-owned browser launches. They did not attach to, inspect, or clean up another agent's previously frozen browser. The parent-owned test server was left running for the parent's continued work.
