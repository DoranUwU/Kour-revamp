# Revolver, four grenades and C4: exact original textures

The original mesh bundles were already retained locally. Their missing colors were a separate default-texture dependency. The selected equipment inherits the original Weapon.SetSkin path; neither Grenade nor Bomb declares a SetSkin override in the supplied metadata.

| Item | Source Weapon pathID | defaultSkinName | Assigned renderer | Custom skin material | Exact native PNG |
|---|---:|---|---:|---:|---|
| Revolver | 8331 | revolver | 7520 | 20 | weapon-skins/texture/revolver.png |
| HE grenade / Grenade | 8307 | grenade | 7047 | null | weapon-skins/texture/grenade.png |
| Smoke | 8313 | smoke | 6990 | null | weapon-skins/texture/smoke.png |
| Flashbang | 8318 | flash | 7048 | null | weapon-skins/texture/flash.png |
| Molotov | 8322 | molotov | 7049 | null | weapon-skins/texture/molotov.png |
| C4 / Bomb | 8464 | bomb | 7067 | null | weapon-skins/texture/bomb.png |

All source IDs refer to `sharedassets0.assets`. The Revolver configures a custom pattern material, while grenades and C4 configure ordinary renderer materials; these are serialized source settings. The native default-skin path can create a new Standard material at runtime, as described in weapon-color-report.md. A separate original `LoadMyMaterialTexture` on `WorldBomb/bomb` explicitly uses `texturePath=weapon-skins/texture/bomb`, so the same C4 PNG also serves the world/planted bomb's native texture loader.

The exact missing slots are observable in the original material data: RevolverSkins material20 has null `_Pattern_Texture` (mask413 is embedded); grenade material9, smoke12, flash8, molotov10 and bomb34 each have a null `_MainTex`. The source RevolverDefault material195 also has a null `_MainTex`. Thus retaining meshes alone cannot supply these albedo/pattern colors.

Complete material and renderer records are in `equipment-color-source-materials.json`, including shader refs, placeholder texture refs and tints. Native filename prefixes were verified from the inherited compiled loader rather than guessed from UI labels (HE grenade is `grenade`, Flashbang is `flash`, C4 is `bomb`).

## Static assets retained

Six declared public static GETs to `https://kour.io/content/stream/weapon-skins/texture/<name>.png` returned HTTP200 with complete unredacted PNG bodies. No game/service APIs were contacted. All files are saved under the corresponding `original-preview/content/stream/weapon-skins/texture/` path.

| PNG | Bytes | Dimensions |
|---|---:|---|
| revolver.png | 315,161 | 1024×1024 |
| bomb.png | 292,202 | 1024×1024 |
| grenade.png | 536,361 | 2048×2048 |
| smoke.png | 607,679 | 2048×2048 |
| flash.png | 891,993 | 2048×2048 |
| molotov.png | 816,073 | 2048×2048 |

PNG signatures, every chunk CRC, dimensions and inflated payload lengths were checked, and saved byte lengths/SHA-256 match native REA's retained response identities. The originals are unresized images, reusable for the matching native size-query variants. No placeholder skins were fabricated.

- Native REA Evidence: `ev_76c08b41369b59280451c7eeaf81f99a4952efc9102ff7c5ba641395180bdfe0`.
- Portable retained Evidence: `equipment-default-texture-evidence.json`.
- Merged receipts: `default-weapon-texture-manifest.json`, now eight exact PNGs, preserving MP5/AWP.
- Retention script: `tools/retain-default-textures.py`; it performs no network access and accepts only the eight source-verified names.

The original source archive/WASM and prior recovered asset records remain unchanged. Production URL routing and proof that the native equip/throw/plant paths display these textures are separate runtime integration checks; successful acquisition alone does not prove every animation or gameplay effect.
