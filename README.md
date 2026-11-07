# Kour.io reconstruction workspace

Deep recovery of the supplied Unity WebGL build, with REA metadata, original asset exports, compiled-method analysis, serialized gameplay configuration and an offline original-menu diagnostic. Start with [analysis/FINDINGS.md](analysis/FINDINGS.md).

Play the hosted game: **https://doranuwu.github.io/Kour-revamp/**. Choose Hong Kong, create or join the same Photon room code, and select a team. Friends need only a current browser. [Hosting and verification](PHOTON.md).

## Clone and requirements

Requires Node.js, Python 3, and Git LFS. The game build, native mesh/map bundles, and binary test fixtures are tracked with Git LFS:

```powershell
git lfs install
git clone https://github.com/DoranUwU/Kour-revamp.git
cd Kour-revamp
git lfs pull
npm.cmd run preview:kourstrike
```

The runtime uses Node/Python standard libraries; no npm dependency installation is needed to play. `npm.cmd run test:kourstrike` checks the startup archive, static mesh identities, loader and offline policy. Browser diagnostic drivers use the original analyst's local Playwright installation and are optional.

Generated startup archives, raw browser captures and large intermediate analysis tables are excluded from Git. Historical investigation reports may link to those local-only outputs; full recovery audits require regenerating the omitted analysis first. Exported asset previews and the files required by the playable build and its core checks are included.

## Play KourStrike locally

For private online play through your own Photon application, run `npm.cmd run preview:photon` and follow [Photon setup and multiplayer verification](PHOTON.md). Each friend can serve their own local copy and join the same Photon room without port forwarding.

The original client now runs **Search And Destroy on Kour2** in a local offline room. Team selection, spawning, movement, pistol firing and reload were verified in a browser.

Close any old/frozen preview tab and stop its server before restarting:

```powershell
npm.cmd run preview:kourstrike
```

Open http://localhost:8082/, choose **Load KourStrike**, then **Start KourStrike offline**. Choose a team (or allow auto-selection), wait for the initial native warmup (up to about two minutes), close the buy menu if needed, and click the game to focus it. WASD moves, mouse aims, left click fires and R reloads.

The local build includes the 34 separate mesh bundles referenced by the supplied weapon prefabs, including the CT-side USPS pistol. Startup enables weapon rendering; **Show gun** restores the original weapon-camera setting during play. Restart the preview server after updating these files.

Eight original default PNGs are mirrored locally: MP5, AWP, revolver, HE grenade, smoke, flashbang, Molotov and C4. Their exact native image URLs are translated into local requests by the offline policy; other external requests remain blocked. Texture identities, image structure and route behavior are included in the core checks.

Beretta's original default uses embedded silver/gray materials and does not request a separate default skin PNG. Native local purchases and the visible finishes of MP5, Beretta92fs and AWP were checked in the browser.

The revolver, all four buyable grenade types (HE, smoke, flashbang, Molotov) and the T player's C4 were also equipped and visually verified with their original textures. Appearance verification and its gameplay limits are recorded in analysis/runtime/equipment-colors-report.md.

Current local experiment: each round starts with the native maximum **$14,000** when the buy phase begins. Purchases still deduct normally. The seven-byte patch is recorded in tools/original-wasm.mjs and only applies to the KourStrike profile; the original source.wasm stays unchanged.

Sides swap automatically after12 completed rounds, so round13 starts on the opposite side with scores following the players. Open **Debug: rounds (temporary)** below the game to start a chosen round. To test the boundary, start round12, wait for the buy phase to finish, then choose **End current round**. [Halftime setup, verification and debug removal](analysis/runtime/HALFTIME.md).

This is solo offline play on the included Kour2/map7. No online multiplayer or AI opponents were verified. Audio decode warnings remain. Original code/data inputs are preserved, and original-service connections remain disabled during play. [Setup and implementation](analysis/runtime/KOURSTRIKE.md) · [Native gameplay verification](analysis/runtime/kourstrike-ui-playable-report.md).

## Browse recovered content

```powershell
npm.cmd run inspect
```

Open http://localhost:8081/explorer/ for textures, playable original audio, rotating original meshes, gameplay settings and declarations. The corpus includes 190 PNGs, 124 OBJ meshes, 114 original audio clips, and settings for 39 weapon-family prefabs, 13 classes and 11 modes. Mesh/texture totals include built-in Unity defaults.

`npm.cmd run verify:recovery` checks extracted bytes and geometry/image structures, metadata method linkage, and compile-only WASM interfaces. See [analysis/REPRODUCE.md](analysis/REPRODUCE.md) for the extraction dependency order.

## Original startup diagnostic

```powershell
npm.cmd run preview:original
```

The default original-client preview now uses the KourStrike profile described above. `npm.cmd run preview:original` is also supported. Historical lobby/freeze investigation remains in [analysis/runtime/FREEZE-FIX.md](analysis/runtime/FREEZE-FIX.md); later map loading, HTTP/cursor integration fixes and actual gameplay are documented in [analysis/runtime/KOURSTRIKE.md](analysis/runtime/KOURSTRIKE.md).

## Earlier original prototype

Rooftop Rush under game/ is a separate editable bot-arena prototype. It does not load the supplied Kour.io engine, assets or services and is not a recovered Unity project.

## Play locally

Requires Node.js (tested with v24.22.1). From this folder:

```powershell
npm.cmd start
```

Open http://localhost:8080 and select **Enter arena**. Use WASD to move, mouse to look, left mouse to fire, Space to jump, Shift to sprint, R to reload, and Escape to pause. First to 20 eliminations or three minutes ends the round. Bots respawn and attack; player death respawns immediately. Keyboard and mouse are required.

Game source lives in `game/`. Change the arena grid, movement speed, damage, bot logic, and weapon timing in `game/game.js`. No JavaScript runtime dependencies or build step. Fonts are local system fonts with no remote font requests. The server serves only this original-code prototype, not the supplied game artifacts.

## Verification

```powershell
npm.cmd run check
node tools/check-game.mjs
```

The simulation checks use a mocked canvas/DOM. Real browser rendering and pointer lock require a manual browser check.

## Reverse engineering

See `analysis/FINDINGS.md`, the data inventory and retained REA JSON evidence. Reproduce archive extraction with `node tools/extract-data.mjs`. Original input files are preserved. The prototype does not load their WASM, engine glue, assets, credentials, or multiplayer services.
