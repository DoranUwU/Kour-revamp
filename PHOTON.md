# Play with friends through your own Photon application

## GitHub Pages

The Pages workflow exports only the runtime, required map/mesh/texture files and public client configuration. Expected project URL: https://doranuwu.github.io/Kour-revamp/. Friends using the hosted site need only their browser.

Repository Settings → Pages must use **GitHub Actions**. Set repository Actions variable `PHOTON_APP_ID` to your Realtime/PUN App ID; it is public client configuration, not an account credential. The workflow retrieves the required Git LFS inputs, generates the patched runtime and deploys the static artifact. Private `local/` configuration and diagnostics are not copied into the website. The build output under `local/pages-dist/` is ignored by Git.

For a local static-host check, run `npm.cmd run build:pages`, then `npm.cmd run preview:pages`, and open http://localhost:8088/Kour-revamp/. `PAGES_BASE_PATH` controls the project subdirectory. This single-thread build was tested without COOP/COEP server headers. A meta CSP retains the asset and Photon connection restrictions; Pages requires no Node server at runtime.

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

A master disconnect or timeout during an unfinished halftime transaction pauses the round rather than risking duplicate swaps; create a new room if this occurs. Automatic recovery of interrupted swaps is not implemented. Public deployment, matchmaking security, voice, and full-match or cross-country endurance testing have not been established. Audio decode warnings from the original assets remain.

Core checks: `npm.cmd run test:kourstrike` and `npm.cmd run check`. Optional live test: `node tools/test-photon-multiplayer.mjs`, with a separately running preview on port 8088 and an existing Playwright installation selected by `PLAYWRIGHT_MODULE`. `BROWSER_PATH` selects a Chromium executable. The test uses real Photon traffic and writes private evidence only to ignored `local/multiplayer/`. `PHOTON_TEST_REGION=hk` selects the tested region; `PHOTON_TEST_DELAY_MS` optionally delays ordered WebSocket messages in both directions. Such a test models application-message delay, not TCP packet loss. No native threaded network simulator is enabled in this single-threaded WebGL build.
