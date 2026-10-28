# Native first-person weapons: asset diagnosis and repair

## Confirmed asset failure

The supplied client deliberately leaves mesh references empty on **36 LoadMyMesh components**, corresponding to **34 unique external mesh bundles**. The native `LoadMyMesh` callback is expected to populate those references. Initially, none of these bundles existed in the local StreamingAssets folder, and the isolated client could not fetch them from the original service.

The Counter-Terrorist starter **USPS** is a concrete example:

- `sharedassets0.assets`, LoadMyMesh pathID **8338**, hierarchy `USPS/Cube.001`.
- Serialized `myMeshName=usps`.
- The target SkinnedMeshRenderer is enabled but its serialized mesh reference is null.
- Its native bundle is `StreamingAssets/usps?v=4.24`.

This is missing geometry, not merely a missing skin. Changing a weapon-camera culling mask cannot create an absent mesh.

The Terrorist starter **Glock** differs: it has no LoadMyMesh component. Its enabled SkinnedMeshRenderer pathID **7521** references embedded mesh **446**, `glock19`, which contains **3,319 vertices and 2,869 triangles**, and embedded opaque materials **38** and **41**. Any separate Glock invisibility requires checking runtime render preferences, activation and layer assignment rather than blaming an absent Glock bundle.

## Camera and renderer boundary

The original Player prefab camera records consume their exact serialized lengths:

- MainCamera (`resources.assets`, pathID2276): enabled, depth−1, near0.1/far200.
- WeaponCamera (pathID2277): enabled, depth1, depth-only clear, near0.1/far200, culling mask557056, layers15 and19.
- TagManager names layer15 **MyHands** and layer19 **GlobalCanvas**.
- Serialized weapon source children are active on layer0; the native equip path must apply the first-person layer at runtime.

These original camera values provide no justification for changing their clip planes or culling masks as a data repair. The source Glock mesh/material references are present and enabled. A later runtime render-preference change can independently affect visibility; this static asset diagnosis does not claim to observe that runtime state.

Detailed source records are retained in `weapon-visibility-assets.json` and `weapon-missing-meshes.json`. Renderer decoding preserves eight newer engine-prefix bytes as opaque data and accepts the remainder only on complete object consumption, rather than inventing names for those bytes.

## Original missing meshes acquired

Within the user's authorization, two native REA browser scenarios issued declared static GET requests to `https://kourstrike.io/StreamingAssets/<exact-name>?v=4.24`. They did not run the remote game or enable original-service access in the local client.

All **34 responses were HTTP200, complete, unredacted UnityFS8 bundles**, each with matching declared byte length and one statically decoded Mesh. Each bundle reports Unity6000.0.10f1, consistent with the previously acquired public map. Runtime loading by the supplied newer client remains a separate validation step.

Runtime follow-up: a fresh local browser selected Counter-Terrorists through the native team panel, waited through the original warmup, and rendered the first-person USPS pistol with12/12 ammo. The native buy preview also displayed its rifle. The parent inspected weapon-ct-spawn.png visually. This verifies the previously missing CT pistol geometry, rather than inferring visibility from its ammo counter. Subsequent actions and cleanup are retained in weapon-ct-browser.json.

Saved exact paths:

```text
ak109, awp, axe, beretta, bomb, cz, deagle, famas, flamethrower,
grenades/mesh/flash, grenades/mesh/grenade, grenades/mesh/molotov,
grenades/mesh/smoke, kar98, knife, lasergun1, lasergun2, m4a4,
minigun, mp5, p90, pkm, revolver, scar, tec9, thompson, umbrella,
ump45, usps, uzi, vector1, vector2, vector3, xm1014
```

The files live under `original-preview/StreamingAssets/`. Original code/data inputs and previously extracted asset records were preserved. No fallback mesh was substituted and no gun was replaced with an unrelated model.

## Provenance and verification

- Exact native allowlist: `tools/local-asset-names.json`.
- Per-file identities: `mesh-acquisition-manifest.json`.
- Native REA Evidence: `ev_4c2bd68613a72e36ac1b4fb3529aef3253cf5294f037613d339ef2eabfe9630d` (USPS) and `ev_247f43590619ffe806b2bfb757b5badfed326116165442489d6820539ecff163` (remaining33).
- Portable retained Evidence: `mesh-acquisition-evidence.json`.
- Bundle directories and Mesh identities: `analysis/meshes/bundles/<name>/receipt.json`.
- Offline identity verification: `node tools/check-mesh-assets.mjs`.

`tools/retain-mesh-bundles.py` performs no network operations. It verifies selected exported REA response bodies and saves only exact allowlisted native bundle names with valid UnityFS and Mesh structures. Runtime HTTP allowlists must explicitly permit the same local names, including the nested grenade paths. External game-service connections can stay disabled after this one-time acquisition.
