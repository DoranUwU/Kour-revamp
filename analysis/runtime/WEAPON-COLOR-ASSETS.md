# MP5, AWP and Beretta source colors

## MP5 and AWP: missing original default textures

Both weapons deliberately have an empty `_Pattern_Texture` in their serialized skin material. Their native `Weapon.SetSkin` path must fill it with the original PNG named by the weapon's `defaultSkinName`.

| Weapon | Weapon pathID | Default skin | Custom material | Pattern-mask texture | Missing pattern texture |
|---|---:|---|---:|---:|---|
| MP5 | 8325 | mp5 | 22, mp5Skins | 279 | null |
| AWP | 8423 | awp | 18, AwpSkins | 313 | null |

All pathIDs above refer to `sharedassets0.assets`. Material records consumed their exact serialized lengths. The verified native loader builds `https://kour.io/content/stream/weapon-skins/texture/<defaultSkinName>.png?size=<width>x<height>`; blocking that original-service request without a local copy leaves the default texture unfilled.

The two exact public static PNGs were acquired with native REA and retained locally:

- `original-preview/content/stream/weapon-skins/texture/mp5.png`: 270,479 bytes, 1024×1024 RGB8, SHA-256 `ec90a8b08c4e6c53883222c95ee5bf5b93dd03205c756c320d29b7ed4c04a953`.
- `original-preview/content/stream/weapon-skins/texture/awp.png`: 1,421,366 bytes, 2048×2048 RGB8, SHA-256 `da91139ac4ec61b0f4e494eb1a1b907790e8d3ae7f28a33be0c039c967ef1789`.

These are the unresized original images. MP5 is a dark charcoal UV atlas with metal details; AWP is an olive-green/charcoal UV atlas. No skin was invented or recolored. Both returned HTTP200, complete unredacted bodies. Their PNG signatures, all chunk CRCs, dimensions and inflated payload lengths were checked. Runtime routing may reuse each image for the corresponding native `size` query variants without contacting the original service.

Native REA Evidence ID: `ev_b7ba0d0b4cc1c565d7c7e9c9c639a4f9cd40e42c48df80562780bdc661385fd3`. Portable Evidence: `default-weapon-texture-evidence.json`; file identities: `default-weapon-texture-manifest.json`.

## Beretta92fs: original flat materials, not an identified missing PNG

Beretta's serialized Weapon pathID8320 has `defaultSkinName=""`, null customMaterialForSkins and an empty weaponRenderers array. There is no LoadMyMaterialTexture component or default texture path on the Beretta prefab.

Its main MeshRenderer pathID6988 references three embedded Standard-shader materials:

| Material pathID | Name | Original linear RGB | Alpha |
|---:|---|---|---:|
| 66 | Material.006 | 0.415094, 0.415094, 0.415094 | 1 |
| 67 | Material.007 | 0.283019, 0.283019, 0.283019 | 1 |
| 68 | Material.008 | 0.150943, 0.150943, 0.150943 | 1 |

All `_MainTex` references are null by design; these materials obtain their appearance from the embedded gray tint values. The acquired original `beretta` Mesh has exactly three submeshes, matching those three material slots. A second magazine MeshRenderer pathID7059 uses the original white Default-Material pathID3.

The LoadMyMesh component pathID8405 and MeshFilter pathID7119 are on the same GameObject3989 (`Beretta92fs/Beretta M1951/Cube`) as the three-material MeshRenderer6988. Thus the downloaded body mesh targets the gray renderer, not the white magazine renderer. The latter is on GameObject1152 with embedded Mesh472 (`mag_beretta`) and has no LoadMyMesh component.

All three body materials reference source Shader523. Its exact length-prefixed shader-name string is **Standard**, and its decoded property table contains `_Color`, `_MainTex` and `_EmissionColor`, with **no `_BaseColor` property**. This rules out an asset-side URP-Lit `_BaseColor` versus `_Color` naming mismatch. Material keywords are empty, `_Mode=0`, `_SrcBlend=1`, `_DstBlend=0`, `_ZWrite=1`, and emission RGB is zero. The original colors are ordinary opaque gray Standard materials. Shader proof is in `beretta-shader-properties.json`; this does not claim to observe their live runtime copies after native equip code runs.

No Beretta PNG was downloaded because no source-derived path was established. If the entire main Beretta remains pure white at runtime, inspect the native renderer's actual materials and `_Color` values after equipping; restoring the serialized gray palette would be a different repair from downloading a speculative texture.

Detailed source proof: `weapon-color-source-materials.json`, `beretta-materials.json`, `beretta-mesh-submeshes.json`. Original code/data were not modified by this asset pass. Shared URL routing and runtime validation are separate integration work.

## Reproduce static checks

```powershell
python analysis/runtime/inspect-weapon-color-assets.py
node tools/check-default-textures.mjs
```
