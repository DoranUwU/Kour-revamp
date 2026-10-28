# Kour.io build investigation

Later milestone: the original client now loads Kour2 in a local KourStrike/Search And Destroy room. Team selection, player spawn, shooting, reload and movement were verified. See [KOURSTRIKE.md](runtime/KOURSTRIKE.md) for current launch instructions and [the gameplay report](runtime/kourstrike-ui-playable-report.md). The earlier boundaries below describe the initial supplied lobby-only files; the map was acquired separately with explicit user authorization.

Weapon visibility follow-up: 36 LoadMyMesh components had empty serialized mesh references and required 34 separate bundles absent from the original files. All 34 are now acquired and served locally; see [asset diagnosis and acquisition](runtime/WEAPON-VISIBILITY-ASSETS.md). The native renderWeapon preference can independently disable the weapon camera; startup and the Show gun launcher button restore it through the original settings handler. [Native control contract](runtime/weapon-visibility-report.md).

The supplied files now support a substantial reconstruction kit: original asset exports, serialized gameplay settings, recovered declarations, named compiled-method linkage, selected gameplay pseudocode, and an offline replay that rendered the original menu. They do not restore the original Unity editor project or multiplayer server.

## Browse the recovery

Run `npm.cmd run inspect` from the workspace and open **http://localhost:8081/explorer/**. The explorer has searchable textures, playable audio, rotating mesh previews, serialized gameplay settings and code declarations. It reads recovered files without running the original game.

- [Asset recovery and weapon tables](assets/REPORT.md)
- [Compact movement, weapon, class and mode configuration](assets/recovered-game-config.json)
- [Recovered gameplay formulas and pseudocode](wasm-recovered-logic.md)
- [Gameplay field and method structure](GAMEPLAY-STRUCTURE.md)
- [Recovered C# declarations](metadata/Assembly-CSharp.declarations.cs)
- [Original startup replay and browser verification](runtime/REPORT.md)
- [Extraction verification](recovery-verification.json) and [WASM verification](wasm-verification.json)

## Inputs and identity

The files were renamed between investigation passes. Current names are framework.js (503,416 bytes), source.wasm (54,791,483), game.data.br (11,283,033), and decompressed game.data (21,587,596). Exact SHA-256 identities are in [input-identities.json](input-identities.json). Original inputs were preserved.

The Brotli payload exactly equals the supplied decompressed game.data. Its UnityWebData1.0 container holds eight members; every extracted member was compared byte-for-byte against its archive slice. The UnityFS bundle identifies **Unity 6000.2.7f2**, serialized-file format 22, with stripped type trees. The separate default resources identify Unity 6000.2.0b3; these revisions are retained separately.

## Recovered corpus

| Area | Result | Scope and limits |
|---|---|---|
| Assets | 21,626 objects in seven serialized files | Six files/21,539 objects from data.unity3d, plus 87 built-in default-resource objects |
| Textures | 320 records; 190 PNG exports | 127 Crunch payloads remain raw; 3 empty placeholders. Game-only bundle:283 textures |
| Geometry | 124 OBJ meshes; 35,100 triangles | Game-only bundle:111 meshes. Positions, triangles and available UVs/normals; no complete rig/material/animation project |
| Audio | 114 original M4A/AAC clips | Byte-exact slices of supplied resource files |
| Scene structure | 5,562 GameObjects with hierarchy/component references | Only level0 is supplied as a serialized scene; hierarchy is consistent with lobby/startup |
| Behaviors | 3,943/4,049 completely decoded | 106 explicitly partial; exact byte consumption is structural evidence, not runtime proof |
| Gameplay objects | 1,043/1,044 completely decoded | Remaining partial gameplay object is SimpleTooltipStyle, a UI style object |
| Configuration | 39 weapon-family prefabs, 13 classes, 11 modes | Includes original weapon indices and class loadouts; runtime modifiers can change effective values |
| Gameplay declarations | 786 types, 4,548 fields, 4,833 methods | Inheritance, types, signatures, serialization attributes and runtime offsets; not original source |
| Compiled gameplay linkage | 4,811 method entries resolve to bodies | Metadata token -> codegen module -> table -> exact body; shared bodies can have multiple owners |
| Instruction decoding | 648 selected unique bodies fully decoded | Structured scalar disassembly with byte offsets; not whole-program C# decompilation |
| Networking structure | Photon components, 25 [PunRPC] declarations and room constants | Static structure; no live match or server implementation recovered |
| JavaScript | Inert syntax parse; 2,146 functions indexed; readable source | REA semantic worker timed out; local Babel/TypeScript syntax processing succeeded |
| Original runtime | Actual KOUR.IO menu rendered offline | Controlled compatibility replay; missing host functions and blocked services prevent verified match play |

Whole-build texture/mesh counts include built-in Unity defaults. Game-only counts are stated separately.

## Findings supported by actual bytes

The serialized PlayerController prefab (resources.assets, pathID7063) sets ground acceleration 600, ground limit 15, crouched limit 9, air acceleration 100, air limit approximately 0.9, air friction 50, gravity 21, friction 20 and jumpHeight approximately 7.8. The compiled Jump body adds jumpHeight directly to vertical velocity; the field name does not mean physical height in metres.

Constructor defaults differ: ground acceleration 100, ground limit 12, crouched limit 4, gravity 16, friction 6 and jumpHeight 6. The serialized prefab demonstrates why constructor defaults alone cannot be treated as active settings. Weapon and runtime multipliers can modify movement further.

Decoded movement bodies use remaining-speed dot products, capped acceleration increments, separate ground/air friction and a gravity step. Equations and exact compiled locations are in [wasm-recovered-logic.md](wasm-recovered-logic.md).

The hit-location helper returns body 1.0 for a directly found PhotonView, head 1.5 and legs 0.5 for specified child-tag/parent-view cases, and zero in other paths. A separate helper calculates linear damage falloff. These helper semantics do not establish that every weapon/mode uses the same path.

Health code uses spawn-protection durations approximately 3.4 seconds for the local owner and 3.3 seconds for other owners. A regeneration coroutine uses an initial 4.5-second wait, a four-second since-hit/shot condition, and 0.4-second ticks adding5 health. Other ownership, mode and damage guards remain relevant.

Serialized examples include FN-Scar damage field 35, ammo 25, fireRate approximately 6.9 and reloadTime approximately 1.29; P90 damage 23, ammo 50 and fireRate 13. See all 39 weapon-family rows and resolved class loadouts in assets/recovered-game-config.json. Shotgun/burst/special-weapon fields need their corresponding implementation to interpret correctly.

## Actual original-build replay

A separate local loader mounted the eight supplied data files, loaded the original WASM, initialized Unity/WebGL2, and rendered the actual KOUR.IO header/menu/background. See [the captured screenshot](runtime/original-wait_runtime.png).

The supplied framework contains standard-stream opens for dev/stdin.html, dev/stdout.html, dev/stderr.html while its devices are /dev/stdin,/dev/stdout,/dev/stderr. The diagnostic server corrects exactly those three paths in served bytes; the original file is unchanged. The missing loader configuration was reconstructed, including WASM URL mapping and deinitializers. Hashes and exact edits are in runtime/compatibility-manifest.json.

The menu remained at Connecting, with external connections blocked. Missing host-page callbacks setCursor, testDevice, SetAds, checkVersion, requestUserData and Module.QuitCleanup caused errors/halt. No playable match, login or server behavior is claimed. This is controlled compatibility replay, not proof that the untouched build runs as-is. Detailed REA scenario results and browser cleanup are in [runtime/REPORT.md](runtime/REPORT.md).

## Evidence provenance

REA MCP decoded matching global-metadata.dat version 31, SHA-256 `3b5d4c385596b555cb760bf42855e5ded84f9cbe360afb93f3f2bcb7e3f2de24`. Parent evidence: `ev_effaaa217c77804598ae99af2a44e70d65dbbc3f089e7b1f838f7d9c14711f3e`; full initial export: [rea-evidence-initial.json](rea-evidence-initial.json).

REA reports 73 images, 10,670 types, 74,584 methods, 46,803 fields and 15,368 string literals across the entire client including dependencies. All 74,584 method names/owners were independently compared with raw metadata parsing. All 73 assembly codegen records were linked through matching initialized WASM data.

WABT was unavailable to REA. No WABT output or REA WASM decompilation is claimed. Workspace-local static parsers recovered sections, imports/exports, elements, initialized data, IL2CPP tables and selected instructions. Node/V8 independently validated/compiled the module and agreed with 616 imports and 580 exports. That compile-only check did not instantiate it; original-build execution is separately documented above.

REA JavaScript analysis timed out at 300,000ms initially and 45,000ms with bounded semantics in the deeper pass. Second partial evidence: `ev_eae3f64c01ea333b0c024b4202d3024f93126d299ab6a9de3d6b765eacb6ef22`. Successful local parser/printer outputs under framework/ are separate evidence, not a completed REA semantic graph.

Final runtime REA evidence: `ev_38c7bbb73d006c8479b13b9040aba7e294bc636d03b705fd8b7b9d1bcbaa5701`.
Explorer interaction QA: `ev_47031fe7642d39ff79e620350a31060c7db8a63043b832ce599a488dda1d7b9c`.
All owned browsers/servers were cleaned up after verification.

## Coverage checklist and remaining boundaries

- **Answered:** containers and identities; engine revisions; object inventory; audio payloads; mesh geometry; supported texture conversion; metadata structure; serialized weapon/class/mode/movement settings; named gameplay-body linkage; selected arithmetic/timings; original menu rendering.
- **Partial:** scene reconstruction(lobby only); 106 behavior objects; JavaScript host integration; shoot/reload state machines; client protocol; materials/animation/skinning; Crunch texture conversion.
- **Unresolved:** original project/editor organization/comments; complete gameplay map content absent from this scene bundle; all 4,811 compiled gameplay implementations; authoritative server behavior; online multiplayer/account/store services; full-game parity.

One glock19 mesh has12 uninterpreted trailing bytes; its exported geometry passes index bounds. Stripped type trees require reconstructed schemas: full byte consumption and matching metadata improve confidence but do not replace Unity editor reimport or behavioral verification.

The earlier Rooftop Rush prototype under game/ is a separate original implementation. It is not the recovered Kour.io client and is not evidence of its behavior.

## Verify and browse

```powershell
npm.cmd run check
npm.cmd run verify:recovery
npm.cmd run inspect
```

[REPRODUCE.md](REPRODUCE.md) gives extraction dependency order. No external game-service URL needs to be fetched to inspect the recovered corpus.
