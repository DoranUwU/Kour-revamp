# Play with friends through your own Photon application

## GitHub Pages

The Pages workflow exports only the runtime, required map/mesh/texture files and public client configuration. Live project URL: https://doranuwu.github.io/Kour-revamp/. Friends using the hosted site need only their browser.

Repository Settings → Pages must use **GitHub Actions**. Set repository Actions variable `PHOTON_APP_ID` to your Realtime/PUN App ID; it is public client configuration, not an account credential. The workflow retrieves the required Git LFS inputs, generates the patched runtime and deploys the static artifact. Private `local/` configuration and diagnostics are not copied into the website. The build output under `local/pages-dist/` is ignored by Git.

For a local static-host check, run `npm.cmd run build:pages`, then `npm.cmd run preview:pages`, and open http://localhost:8088/Kour-revamp/. `PAGES_BASE_PATH` controls the project subdirectory. The exported WASM and startup data use gzip files with a small browser-side decoder, so no custom Content-Encoding server headers are needed. A current browser with DecompressionStream support is required. This single-thread build was tested without COOP/COEP server headers. A meta CSP retains the asset and Photon connection restrictions; Pages requires no Node server at runtime.

## Local preview

Requires the same local game files on every player's computer, Node.js and Python 3. Photon carries multiplayer messages; each computer serves its own browser assets. No port forwarding or public web host is required for this setup.

1. Run `npm.cmd run preview:photon` in the project folder.
2. Open `http://localhost:8082/` and click **Load KourStrike**.
3. Open **Play online with friends (Photon)**. Enter the same Realtime/PUN App ID on every computer, choose **Hong Kong**, and enter your player name.
4. The host enters a room code and clicks **Create room**. Friends enter the same code and click **Join room**.
5. Choose T or CT in the game. The original warmup precedes normal rounds. Keep the game tab active while playing.

Rooms are unlisted and support the original mode's eight-player limit. A room code is an invitation, not a password or account authentication system. Reload the page to leave or change rooms. An existing offline match must be reloaded before connecting online.

For local convenience, create an ignored `local/photon.json`:

```json
{"appId":"YOUR-REALTIME-APP-ID","region":"hk"}
```

Alternatively, set `PHOTON_APP_ID` before starting the server. The App ID is delivered to your game clients; it is not an account password. Do not put account credentials in this file. Configuration changes require restarting the server.

## Scope

The online profile uses the supplied client's native Photon/PUN connection, replication, room lifecycle, map loader and combat. It suppresses the original game's automatic connection, random-room matchmaking and forced-offline fallback. Explicit opt-in permits only Photon WSS domains. Original game services, accounts, ads, telemetry and external links remain disabled. Maps, meshes and textures load from local files.

The offline command `npm.cmd run preview:kourstrike` remains available. The $14,000 round-start cash experiment also applies online. Temporary debug round buttons remain offline-only.

Online halftime is controlled by the Photon master client. It waits for server acknowledgements of roster changes and score exchange before starting round 13. Each client replaces its own player/camera through native lifecycle calls. A persisted transaction marker prevents a second master from blindly repeating an interrupted swap.

## Verification and limits

Two real isolated browser clients joined one private room in the supplied application, loaded Kour2, selected opposite teams and started the same native round. Ordinary keyboard walking and native teleport positions converged across both clients. An actual native raycast pistol shot reduced the victim from 100 to 67 HP on both clients. The ordinary round-12 end flow advanced both to round 13, exchanged teams/scores, selected actor 2 as C4 holder, and left exactly one fresh actor per player on each client. No uncaught page errors occurred in that run. The final normal run, including native GCHandle lifetime handling, also passed with the victim at 68 HP after shooting. A repeat with 150 ms ordered WebSocket-message delay in each direction also passed walking, shooting (100 to 69 HP), halftime and guest disconnect, with displayed round-trip times around 390?425 ms. This models message latency, not packet loss.

Hong Kong authentication and room creation passed. Singapore returned Photon authentication debug message `Regions mismatch` for this application; Hong Kong is the selected working region. This does not establish that Singapore is unavailable generally. [Photon's discussion of this error](https://forum.photonengine.com/discussion/19264/urgent-help-operationresponse-230-returncode-32767-regions-mismatch).

A master disconnect or timeout during an unfinished halftime transaction pauses the round rather than risking duplicate swaps; create a new room if this occurs. Automatic recovery of interrupted swaps is not implemented. Public deployment, matchmaking security, voice, and full-match or cross-country endurance testing have not been established. Native sound effects and spatial footsteps are enabled; the [Sound panel and audio API](AUDIO.md) control local playback.

Core checks: `npm.cmd run test:kourstrike` and `npm.cmd run check`. Optional live test: `node tools/test-photon-multiplayer.mjs`, with a separately running preview on port 8088 and an existing Playwright installation selected by `PLAYWRIGHT_MODULE`. `BROWSER_PATH` selects a Chromium executable. The test uses real Photon traffic and writes private evidence only to ignored `local/multiplayer/`. `PHOTON_TEST_REGION=hk` selects the tested region; `PHOTON_TEST_DELAY_MS` optionally delays ordered WebSocket messages in both directions. Such a test models application-message delay, not TCP packet loss. No native threaded network simulator is enabled in this single-threaded WebGL build.


## Hosted verification

The compressed build deployed successfully through GitHub Actions. Two real browser clients loaded the public HTTPS URL, joined one Hong Kong room, selected opposite teams and agreed on round state. Ordinary walking and native teleport positions converged. The original round-12 end flow advanced both to 13 with the expected side exchange, actor replacement and C4-holder state. A native raycast pistol shot reduced the victim from 100 to 69 HP on both clients. Guest departure reduced the remaining client's player count to one. The suite reported zero uncaught page errors and all non-WebSocket requests stayed on the website origin. The owned test browsers were closed afterwards.

The initial uncompressed deployment timed out during GitHub's syncing_files stage; the gzip retry deployed successfully. This observation does not establish whether payload size or a transient service delay caused the initial timeout. Runtime compression reduces the two major downloads from about 85 MB to 27 MB without changing decoded game bytes. Raw hosted-test evidence remains under ignored local/multiplayer/.


## Passive C4 handoff

When the C4 holder dies, the native handoff still assigns C4 to a surviving Terrorist and adds it to inventory. The handoff no longer selects C4 automatically: the recipient keeps the same active weapon instance and can select C4 manually. The generated-WASM correction reserves the previously unused SetBomb(true,true) combination for this handoff and changes its equip predicate to XOR; normal round grants, clear/reset and planting cleanup retain their existing behavior. Two guarded bytes change in the KourStrike profile; original source.wasm stays immutable.

A three-client native-death regression reproduced the original forced pistol-to-C4 switch, then passed with the patched recipient keeping its pistol and receiving inventory weapon31. Manual C4 selection and normal grant/clear/planting-cleanup cases passed. Fixtures use authentic native team-property APIs to establish two T players and one CT, then native lethal damage and the real handoff callback; they do not write C4 inventory memory. Run `node tools/test-c4-transfer.mjs` against the local Photon preview, or set PHOTON_TEST_URL to test a hosted build. `--rifle` checks a native-granted rifle loadout instead of a pistol. Raw captures remain ignored under local/.


The deployed Pages build also passed the three-client death-handoff check with an AK loadout selected in slot0: the recipient's active weapon pointer and slot stayed identical while slot2 changed from knife3 to C4 weapon31. Manual C4 selection and native flag regression cases passed without uncaught page errors. The test uses native lethal damage to invoke the real death/handoff path; it is not an endurance or human combat playthrough.
