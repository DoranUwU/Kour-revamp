# Kour Revamp multiplayer investigation

## Scope and identity

- User requested private Photon multiplayer using their own application, preserving the existing local KourStrike mode.
- Supplied Unity WebGL / IL2CPP build: Unity 6000.2.7f2. Original source.wasm SHA-256: dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2. Store/build identifier: unknown.
- Existing native Photon/PUN code is present. Original game source is unavailable. Original input files remain immutable; derived WASM and host scripts implement compatibility changes.

## Sources and workflow

- [Co-op Anything AGENTS.md](https://github.com/cranebeaker/coop-anything/blob/main/AGENTS.md): identify the build, preserve inputs, record evidence, and test real clients before claiming multiplayer works.
- [Networking](https://github.com/cranebeaker/coop-anything/blob/main/playbook/networking.md): reuse engine networking where available. User chose Photon rather than Steam relay.
- [Automated QA](https://github.com/cranebeaker/coop-anything/blob/main/playbook/automated-qa.md): use at least two real clients and compare shared state.
- [Photon PUN setup](https://doc.photonengine.com/pun/current/getting-started/initial-setup): PUN uses a Realtime App ID; WebGL uses WSS.
- Public directory and web searches did not identify a Kour-specific Co-op Anything project. Repository is being consulted as a playbook, not installed or executed. No account access, upstream issue, PR, or publication has been performed.

## Observed baseline

- Offline KourStrike, default weapon textures, cash experiment, halftime and fresh player/camera lifecycle were tested in previous work. User confirmed the camera correction works.
- Native networking and original service requests are currently disabled by separate WASM and browser-policy changes.

## Current work

- Map native connection configuration and original room lifecycle independently.
- Add an explicit opt-in Photon connection policy while retaining blocked original services.
- Validate two-client join, spawning, replicated state, and shared round transitions.

## Unknowns

- Compatibility with the user's Photon application; native room/authentication requirements; reconnect/master migration behavior; measured network usage.
- Online behavior is not verified yet. Runtime logs, dumps, local paths and private App ID configuration belong under ignored local/.


## Verified outcome

- User selected Hong Kong. Their App ID is stored only in ignored local configuration, not project source or shared notes.
- Two real browser clients authenticated with the user's application, joined one unlisted room, loaded Kour2, selected opposite teams, and observed the same native round.
- Ordinary keyboard walking converged on the observer; native raycast shooting reduced remote HP on both clients. Normal round-12 end flow advanced both clients to 13 with roster/score exchange and fresh local actors.
- Repeated with 150 ms ordered WebSocket message delay each way; walking, shooting, halftime and guest departure passed. This is message delay, not packet-loss simulation. A first delayed test stopped because it incorrectly required an already-dismissed team panel to remain active; corrected harness waits for the initialized panel/context and selects the native team directly.
- Final normal live suite passed after native GCHandle rooting was added. No uncaught page errors; all asset/service requests stayed local. Hong Kong ping shown in this test is not a measurement of the user's Vietnamese connections.
- Core KourStrike, Photon profile/gate/lifetime fixtures, offline preview checks and syntax checks passed. Raw evidence is ignored under local/multiplayer/.
- Remaining: full-match/endurance play, abrupt connection recovery, and automatic recovery if the master disconnects during halftime. Interrupted halftime pauses; start a new room.
- No upstream claim issue, PR, account publication, game asset upload, commit or push was performed for this feature. Shared playbook contributions remain a separate review step.
