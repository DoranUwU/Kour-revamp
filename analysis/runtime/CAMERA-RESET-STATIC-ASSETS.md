# Post-halftime camera: source component boundary

This is static evidence from the supplied Player prefab and its matching IL2CPP metadata. No production code or assets were edited. The symptom's live cause still needs runtime input/controller inspection.

## The targetForward coroutine is an editor camera

The recovered `<SetCameraRotation>d__11` type belongs to **EditorCamera** (metadata type4143), not PlayerController. Its targetForward argument is a runtime Vector3 at coroutine offset20. EditorCamera stores cameraRotateCoroutine at32, xRotation44 and yRotation48. Those methods are for the map editor; there is **no EditorCamera component on the supplied Player prefab** and no metadata type named CameraPositionMatch.

There is consequently no serialized FPS `targetForward` default to restore. Calling the editor's SetCameraRotation/RotateCameraInDirection on an FPS controller pointer would be a class/ABI mismatch rather than a valid camera reset. The diagnostic contains exact native method/table mappings to distinguish these classes.

## Actual first-person prefab references

The source Player lives in `resources.assets`:

| Component/ref | Asset pathID | Runtime field on PlayerController |
|---|---:|---:|
| PlayerController | 7063 | — |
| PlayerInputHandler | 5573 | playerInput +92 |
| CameraParent Transform | 2121 | playerCameraParent +96 |
| MainCamera Camera | 2276 | playerCamera +100 |
| Recoil | 6546 | recoil +84 |

PlayerInputHandler in turn references controller7063 through its runtime field+68. The serialized sensitivity is1, isPaused=false, isDancing=false. The private currentLook/currentMovement values are **not serialized**, so reading an initial asset transform cannot establish their live values after the swap.

Important runtime fields from the matching build:

- PlayerInputHandler.currentMovement: Vector2 at+36.
- PlayerInputHandler.currentLook: Vector2 at+44.
- PlayerInputHandler.isPaused: bool+80; isDancing: bool+88.
- PlayerInputHandler.prevDeltaX: float+108.
- PlayerController._inputRot: Vector3 at+204.
- PlayerController.bypassMouseLook: bool+284.
- Recoil.currentRotation: Vector3+20; targetRotation: Vector3+32.

These are IL2CPP object-memory offsets, **not serialized file offsets**. A stale look delta can continue turning the controller even if movement remains normal; a blocked/bypassed MouseLook path can leave movement working while aiming is frozen. Those are testable hypotheses, not observed live facts in this pass.

## Camera hierarchy and constraints

The normal hierarchy is Player/CameraParent/CrouchPos/CameraRecoiler/Parent/MainCamera, with the separate WeaponCamera beneath MainCamera. The additional controllers on this subtree are:

- **CMF.SmoothPosition**6043 on CameraParent: position smoothing, target initially null, lerpSpeed20, smoothDampTime≈0.03, updateType0, smoothType1. Its stored currentPosition/localPositionOffset/refVelocity are positions/velocities, not a persistent aim direction.
- **Recoil**6546 on CameraRecoiler.
- **CameraWalk**6940 and **WeaponSway**7173 on the weapon chain.
- **FallingCamera**7140 and **ThirdPersonCamera**7071 on alternative view objects.

No serialized EditorCamera, CameraPositionMatch or direct camera RotationConstraint was identified in this Player camera subtree. Bone/weapon animation rigging elsewhere in the player should not be confused with a first-person camera aim target.

Source camera transforms and all relevant component records are retained in `camera-reset-source-assets.json`, along with original metadata and method/table identities. Normal MainCamera/WeaponCamera local rotations are identity in the prefab; this does not prove their live rotations or owner state after halftime.

## Useful runtime checks

Inspect the live Shooter/controller/input references together before and after the native team/teleport operation. Confirm the same locally owned player is active, the first-person camera is enabled, `currentLook` settles when the mouse stops, `_inputRot` remains finite, and the expected MouseLook path resumes. If a valid native FPS reset is used, do not mix the editor's coroutine with the PlayerController's accumulated input rotation. Check browser pointer-lock/focus independently: successful movement alone does not establish mouse capture.

Reproduce this static export with `python analysis/runtime/inspect-camera-reset-assets.py`.
