# First-person weapon visibility: original native controls

This report describes the exact supplied build (`source.wasm` SHA-256 `dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2`). It identifies a native visibility setting and separate asset/camera diagnostics; it does not assert that every missing-gun report has the same cause.

## Local repair and observed preference behavior

The local loader calls the original SetRenderWeapon(true) before starting a match, and exposes the same operation through Show gun. It guards the native function name and arity. It does not change meshes, camera masks, player stats or unrelated preferences.

In the controlled native Glock run, startup restored a deliberately disabled renderWeapon setting. Once spawned, calling the original handler with false removed the first-person pistol, and clicking Show gun restored it. Screenshots inspected visually: weapon-visibility-startup-restored.png, weapon-visibility-hidden.png, and weapon-visibility-restored.png. The restored gun also remained visible after resizing to1920x1080 (weapon-visibility-resized.png). These screenshots include the native buy wheel; they do not establish a firing test. The first diagnostic timer later overwrote the automatic run's shared JSON trace, so the full automatic action trace is not retained; the screenshots remain. The test driver now gives automatic runs a separate JSON filename.

Separate missing mesh dependencies are addressed by the locally acquired bundles in [WEAPON-VISIBILITY-ASSETS.md](WEAPON-VISIBILITY-ASSETS.md). A working weapon camera alone cannot render an empty mesh.

## Native hide/show preference

`Shooter.Start` reads `PlayerPrefs.GetInt("renderWeapon",1)` at Wasm file offset **23,598,859**. At **23,598,880**, it sets the player's `weaponCamera.enabled` to whether that preference equals1. When false, it enables the main camera's `PostProcessLayer` at23,598,911. Thus a persisted `renderWeapon=0` intentionally hides the first-person gun. Fresh preferences default to1; a hidden gun with a verified preference1 requires further diagnosis.

The original settings method **SettingsPanel.SetRenderWeapon(bool)** persists this key and applies the intended camera/postprocessing state:

```csharp
PlayerPrefs.SetInt("renderWeapon", v ? 1 : 0);
if (GameObject.Find("WeaponCamera").TryGetComponent<Camera>(out var camera))
    camera.enabled = v;
if (GameObject.Find("MainCamera").TryGetComponent<PostProcessLayer>(out var post))
    post.enabled = !v;
```

Generic method instantiations at metadata-usage addresses6,965,712 and6,965,756 were resolved through the method-spec/type tables to verify these exact component types. Both searches check for a nonnull GameObject first, so calling the settings method before a player spawns still persists the preference even when no player camera exists yet.

## Complete direct native caller contract

The method is Wasm **func[74636]**, active function-table slot **20593**, body bytes **[23,737,419,23,737,722)** and code starts23,737,422. Its signature is `(i32 nominalThis,i32 bool,i32 MethodInfo*) -> void`.

```javascript
const table = module.asm.__indirect_function_table;
// Exact-build guard: numeric Wasm name and arity must match this recovered body.
if (table.get(20593).name !== "74636" || table.get(20593).length !== 3)
    throw Error("Unexpected native weapon-visibility function");
table.get(20593)(0, 1, 0); // show; use bool0 to reproduce the native hide setting
table.get(9039)(0);       // PlayerPrefs.Save()
```

Passing a zero nominal receiver is justified **only for this exact inspected body**. Its unconditional first instructions are:

```text
23737422 global.get 0
23737424 i32.const 16
23737426 i32.sub
23737427 local.tee 0
23737429 global.set 0
```

The compiler overwrites local0, which originally held `this`, with a stack-frame pointer before reading it or aliasing it anywhere. Every subsequent local.get0 refers to that frame. No original receiver is dereferenced by any branch. This is direct function-table invocation, not a claim that invoking an arbitrary instance method on null is safe.

The parent server already verifies the original Wasm hash before constructing its served compatibility variant. Preserve that identity guard and the table checks; these offsets/slots must not be applied to a different build. No shared Wasm/loader/server source was edited by this static-analysis task.

## Preference probes

| API | Table | Signature |
|---|---:|---|
| PlayerPrefs.SetInt | 40391 | `(i32 Il2CppString*,i32 value,i32 MethodInfo*) -> void` |
| PlayerPrefs.GetInt with default | 40392 | `(i32 Il2CppString*,i32 default,i32 MethodInfo*) -> i32` |
| PlayerPrefs.GetInt without default | 40393 | `(i32 Il2CppString*,i32 MethodInfo*) -> i32` |
| PlayerPrefs.Save | 9039 | `(i32 MethodInfo*) -> void` |

The shared `renderWeapon` string usage lives at linear-memory address **7,054,836**. Once SetRenderWeapon or Shooter.Start has initialized it, `HEAPU32[7054836>>>2]` is an Il2CppString pointer suitable for the getters. Before initialization it may still be encoded metadata value0xa..., which must not be passed as a string pointer. Check the pointer falls within memory and its length/text match before use. Calling the native settings method resolves its own metadata references, so the parent does not need to allocate a managed string merely to show the weapon.

## Camera/layer diagnostics if preference1 is not enough

`Shooter.current` uses the class-reference slot **6,910,700**. After initialization, read class+92 for the static-field block, then static+0 for the current Shooter pointer. Its relevant fields are `cam+184`, `weaponCamera+188`, `localWeaponParent+204`, `currentLocalWeapon+224`, and `currentGlobalWeapon+228`.

`Shooter.SetWeapon` sets **all transforms under the local weapon to layer15** at instruction23,587,150. A weapon camera's culling mask must therefore include **bit15 =32768**. Native SetRenderWeapon restores enabled/postprocess state but does not modify that mask or resurrect missing geometry.

Read-only native getters:

| Query | Table | Signature |
|---|---:|---|
| Behaviour.enabled | 3167 | `(receiver,0) -> i32` |
| Camera.cullingMask | 11420 | `(camera,0) -> i32` |
| Camera.fieldOfView | 4853 | `(camera,0) -> f32` |
| Component.gameObject | 2954 | `(component,0) -> GameObject*` |
| GameObject.layer | 3181 | `(gameObject,0) -> i32` |
| Renderer.enabled | 39081 | `(renderer,0) -> i32` |
| Renderer.isVisible | 39083 | `(renderer,0) -> i32` |

Use valid initialized object pointers and distinguish component enabled, hierarchy activity, mask inclusion, assigned mesh, and actual rendered pixels. Renderer.isVisible is not itself proof of a first-person view: other cameras can affect it. Avoid blanket culling-mask/layer changes unless a probe establishes that specific fault.

`WeaponSway.Start` reads fov with default95 and sets the main camera FOV to that value and the weapon camera FOV to **0.68×** it (64.6 at default95). OnFOVChanged applies the same relationship. These methods do not contain hide/show calls; no basis was found here for forcing their FOV as the first visibility fix.

## Dynamic mesh dependency

`LoadMyMesh.Start`, func77557/table19430, reads serialized `myMeshName` at receiver+16 and requests `TextureLoader.LoadAssetBundleMesh`. The latter constructs `Path.Combine(StreamingAssetsLoader.StreamingAssetsPath(),myMeshName)`, strips an existing query, and appends `?v=Application.version`. A serialized name `usps` therefore requests **`/StreamingAssets/usps?v=...`** with the local host's current base. No `meshes/` prefix is added by these methods.

The callback func77558 first checks that both its returned mesh and LoadMyMesh receiver still exist. It then assigns the mesh to a `MeshFilter.mesh` at instruction24,705,372, or a `SkinnedMeshRenderer.sharedMesh` at24,705,410. Null mesh/component completion leaves no replacement. This supports a separate missing/delayed mesh-bundle failure mode for otherwise visible cameras. It does not prove an initialization race occurred in the current runtime. Fresh screenshots reportedly showing an actual gun favor checking the persisted hide setting first.

Raw focused disassembly is retained in `weapon-visibility-static.json` and `weapon-visibility-static-mesh.json`. Values above are derived from matching metadata/type/field-offset/element-table records and exact compiled instruction bodies. Live hide→show reproduction and pixel verification remain the parent's runtime task.

## Evidence sources

- REA `inspect_il2cpp_metadata` parent Evidence **ev_effaaa217c77804598ae99af2a44e70d65dbbc3f089e7b1f838f7d9c14711f3e**, retained in `../rea-evidence-initial.json`, establishes method names and declaring owners in metadata SHA-256 `3b5d4c385596b555cb760bf42855e5ded84f9cbe360afb93f3f2bcb7e3f2de24`. Focused rechecks matched LoadMyMesh.Start index31717, SettingsPanel.SetRenderWeapon index32903, Shooter.Start index33011, and WeaponSway indices33835/33836 to that REA record.
- `../metadata/gameplay.json` provides reconstructed matching type signatures and fields; `../wasm-method-map.json`, `../wasm-elements.json`, `../wasm-functions.json`, and `../wasm-interface.json` link metadata tokens to actual Wasm table slots, code offsets and signatures. The custom parser's independently completed module/interface checks are in `../wasm-verification.json`.
- `weapon-visibility-contract.json` records the exact function/body identity and unconditional receiver-overwrite proof. Focused instruction files retain the setting, camera, layer, FOV and dynamic-mesh call sites. These are custom static Wasm observations, **not a claim that REA performed Wasm decompilation**.
- Serialized LoadMyMesh names are in `../assets/gameplay-settings.json`. The existence of that component is evidence of a dynamic mesh dependency, not proof that a particular mesh request failed in a live run.
