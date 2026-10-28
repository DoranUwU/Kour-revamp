# Derived KourStrike profile verification

The parent implemented a derived-data KourStrike profile: served `game.data` changes the SDK game-type setting to1 through a UnityFS repack, and served WASM uses documented local bootstrap changes. This test verifies that current harness rather than the untouched original inputs.

An independent fresh server on port8085 served that profile. An owned fresh installed Edge browser loaded the page, clicked **Load KourStrike**, waited ten seconds, clicked **Start KourStrike offline**, captured the missing-map notice, clicked the native offline **OK**, waited another ten seconds, and clicked **Check page response**.

## Observed result

- Unity loaded `data.unity3d`, logged engine version **6000.2.7f2 (2b518236b676)**, initialized WebGL2 and rendered the original lobby. The derived UnityFS data therefore passes this actual startup test; there was no observed bundle-format startup failure.
- The original lobby's GAME MODE label was **Search And Destroy**.
- The HTML start-match control visibly reported: **KourStrike needs the missing Kour2 map bundle: original-preview/StreamingAssets/map7**.
- Native offline OK closed its prompt. It did not issue a map7 request during the ten-second observation.
- The host response check logged **HOST PAGE RESPONSIVE**. There were no page-error events. Original shader/audio compatibility console errors remained.
- All recorded page requests were local startup/config files. No external request interception occurred. The existing policy and CSP remained active, with an additional test-driver nonlocal request abort guard.
- The owned browser closed successfully. The test's owned8085 server was stopped afterwards.

`/local-config.json` reported `profile:kourstrike`, `gameType:1`, `gameMode:8`, `mapBundle:map7`, `mapAvailable:false`, and served WASM SHA-256 `8255e45380ed88733852e03191a7fcc1acdc5055add104e0f3c5051decc06d67`.

This establishes a bootable derived profile, native preferred-mode selection and a visible missing-file guard. It does not establish that original KourStrike maps load or that a playable match runs without the required bundle.

## Artifacts

- [kourstrike-ui-profile-evidence.json](kourstrike-ui-profile-evidence.json): console, requests/responses, local config, actions and cleanup.
- [kourstrike-ui-profile-after-offline-ok.png](kourstrike-ui-profile-after-offline-ok.png): visually inspected original lobby, Search And Destroy mode, visible missing-map status, and response log.
- [kourstrike-ui-profile-missing-map.png](kourstrike-ui-profile-missing-map.png): missing-map control result before native OfflineOK.
- [kourstrike-ui-profile.mjs](kourstrike-ui-profile.mjs): ordinary Playwright verification driver. This is not a REA Evidence record; REA's click schema lacks canvas coordinates.
