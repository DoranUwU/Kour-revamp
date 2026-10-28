# Asset recovery

All work is static; no supplied game code or network service was executed.

## Scope and results

| Item | Recovered |
|---|---:|
| all serialized files | 7 |
| all objects | 21,626 |
| game bundle objects | 21,539 |
| game objects | 5,562 |
| textures | 320 |
| png textures | 190 |
| crunch textures | 127 |
| zero size textures | 3 |
| game textures | 283 |
| meshes | 124 |
| obj meshes | 124 |
| triangles | 35,100 |
| game meshes | 111 |
| audio clips | 114 |
| weapon prefabs | 39 |
| classes | 13 |
| modes | 11 |

The UnityFS bundle reports **Unity 6000.2.7f2**. Seven serialized files were read: six from `data.unity3d` and the separately supplied `Resources/unity default resources` (whose embedded engine revision is 6000.2.0b3). All use serialized-file format 22 and have stripped type trees. The bundle contributes 283 textures and 111 meshes; built-in defaults add 37 textures and 13 meshes.

## What is usable

- `textures/*.png`: 190 decoded image files, vertically flipped to ordinary image orientation. Raw texture payloads are preserved as `.bin` alongside the images.
- 127 DXT1/DXT5 Crunch payloads are retained raw; a Crunch decoder was unavailable. Three 0×0 texture placeholders have no image to export.
- `audio/*.m4a`: all 114 original ISO BMFF/AAC payload slices, with audio names, channels, sample rates and durations in the audio JSON inventories.
- `meshes/*.obj`: all 124 meshes, with positions, triangles and normals/UVs where present. Mesh compression was decoded for the packed meshes. Skinning, animation tracks and material assignments are not exported to OBJ.
- `scene-objects/*.json`: all 5,562 GameObject names, component references and hierarchy paths. `hierarchy/*.json` also preserves local transforms.
- `decoded-behaviours/*.json`: 3,943 of 4,049 complete serialized MonoBehaviour objects decoded using recovered field schemas. Remaining 106 objects are explicitly partial.
- `gameplay-settings.json`: 1,044 Assembly-CSharp objects, 1,043 with complete object consumption. The sole incomplete gameplay object is SimpleTooltipStyle (UI styling), not a weapon/controller.
- `recovered-game-config.json`, `weapons.csv`, `classes.csv`, `game-modes.csv`: compact, indexed tables for the 39 weapon-family prefabs, 13 character classes, 11 modes and player movement settings. Weapon indices are resolved using the serialized WeaponCarrierData.allWeapons array.

## Selected original settings

PlayerController (`resources.assets`, pathID 7063): groundAcceleration 600, airAcceleration 100, airFriction 50, groundLimit 15, crouchGroundLimit 9, airLimit ≈0.9, gravity 21, friction 20, jumpHeight ≈7.8, additiveJump and autoJump true. `landedBrTime` is serialized negative infinity and represented as the string `-Infinity`. These are field values, not a claim that jumpHeight is a distance in metres.

| Index | Weapon | Script | Damage field | Ammo | Fire-rate field | Reload field |
|---:|---|---|---:|---:|---:|---:|
| 0 | AK-47 | AimableWeapon | 21 | 30 | 11.1 | 1.4 |
| 1 | Deagle | Weapon | 76 | 6 | 10 | 1.6 |
| 2 | Awp | Sniper | 111 | 5 | 0.9 | 3 |
| 3 | Bayonet | Knife | 90 | -1 | 4.4 | -1 |
| 4 | Uzi | Weapon | 29 | 26 | 12 | 1.25 |
| 5 | PKM | Weapon | 26 | 70 | 13 | 4 |
| 6 | Revolver | Weapon | 130 | 6 | 1.3 | 2.4 |
| 7 | RPG | RocketLauncher | 100 | 1 | 0.5 | 2 |
| 8 | USPS | Weapon | 25 | 12 | 10 | 1.6 |
| 9 | MP5 | AimableWeapon | 22 | 35 | 11 | 1.2 |
| 10 | Shotgun | Shotgun | 310 | 2 | 1.5 | 1.55 |
| 11 | Glock | AimableWeapon | 22 | 16 | 11 | 0.9 |
| 12 | Karambit | Knife | 110 | -1 | 3.8 | -1 |
| 13 | Knife | Knife | 70 | -1 | 6.5 | -1 |
| 14 | FN-Scar | Weapon | 35 | 25 | 6.9 | 1.29 |
| 15 | Minigun | Minigun | 26 | 100 | 11.2 | 2.8 |
| 16 | Famas | BurstWeapon | 44 | 30 | 2.76 | 1.85 |
| 17 | Vector | AimableWeapon | 25 | 35 | 11.5 | 1.2 |
| 18 | Flamethrower | Flamethrower | 30 | -1 | 14 | 2 |
| 19 | Kar98k | Sniper | 110 | 4 | 1.3 | 2.5 |
| 20 | M4A4 | Weapon | 27 | 20 | 11.5 | 1.85 |
| 21 | Tec9 | Weapon | 38 | 18 | 9 | 0.9 |
| 22 | Beretta92fs | Weapon | 44 | 10 | 6 | 0.9 |
| 23 | Cz | AimableWeapon | 29 | 18 | 10 | 1.2 |
| 24 | AK-109 | Weapon | 38 | 30 | 8.5 | 1.85 |
| 25 | P90 | Weapon | 23 | 50 | 13 | 1.95 |
| 26 | Thompson | Weapon | 24 | 12 | 12 | 1.45 |
| 27 | UMP45 | AimableWeapon | 21 | 35 | 10 | 1.2 |
| 28 | XM1014 | Shotgun | 300 | 12 | 1.3 | 1.2 |
| 29 | Butterfly | Knife | 90 | -1 | 4.4 | -1 |
| 30 | LaserGun | AimableWeapon | 25 | 50 | 9.4 | 1.85 |
| 31 | Bomb | Bomb | 0 | -1 | 0.4 | 2 |
| 32 | Smoke | Grenade | 0 | -1 | 1 | 2 |
| 33 | Molotov | Grenade | 0 | -1 | 1 | 2 |
| 34 | Grenade | Grenade | 0 | -1 | 1 | 2 |
| 35 | Flashbang | Grenade | 0 | -1 | 1 | 2 |
| 36 | Glizzy | Knife | 30 | -1 | 4 | -1 |
| 37 | Axe | Knife | 70 | -1 | 1.6 | -1 |
| 38 | Bare Fists | Knife | 50 | -1 | 4.2 | -1 |

Damage fields on shotguns and special weapons can have different code interpretation; do not treat them as measured damage per hit. Negative ammo values occur for melee/throwable assets. Runtime upgrades and modifiers may change these values.

## Scene boundary

Only `level0` is present as a serialized scene. Its roots include MainManager, KourConsole, LobbyRenderCamera, Main Camera, EventSystem, WebRequestHelper, LobbyPlayer, PPV, Canvas(UWI), Canvas and Directional Light. This is consistent with the lobby/start scene. No claim is made that absent remote maps can be rebuilt from their names or metadata.

## Validation and limits

All 320 Texture2D records and all 114 AudioClip records consumed their exact object lengths. The mesh reader consumed 123 of 124 exact object lengths; `glock19` (`sharedassets0.assets`, pathID 446) has 12 uninterpreted trailing bytes after the known mesh structure. Its vertex/index geometry exports with valid indices. Packed geometry output was checked against vertex and submesh counts. Byte provenance (file, pathID, offset, size) is retained for every object.

The original serialized bytes and hashes are retained in the unpacked bundle files. Stripped type trees were replaced by schemas reconstructed from matching IL2CPP metadata/WASM. Complete object consumption increases confidence but is not a Unity-editor reimport or runtime behavior proof. Field offsets in decoded behavior JSON are offsets in the serialized object; IL2CPP runtime offsets are not used as asset offsets.

AnimationClip objects, shaders, fonts, sprite rectangles, skinning, material/shader parameter graphs and engine settings are inventoried but not fully reconstructed into an editable Unity project. Some UI/postprocessing behaviors use unsupported custom serializers and remain partial. No server implementation is recoverable from these client asset payloads.

## Reproduce

```powershell
python tools/inspect-assets.py
python tools/inspect-assets-behaviours.py
python tools/inspect-assets-summary.py
```

The behavior pass requires `analysis/metadata/all-types.json`. All three scripts use only Python standard-library modules; the attempted UnityPy acquisition was blocked, and no third-party parser was installed.
