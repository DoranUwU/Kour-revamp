# Recovered gameplay logic from the supplied WebAssembly

These are **manual pseudocode reconstructions of actual compiled bodies**, not guesses based on method names and not original C# source. Scalar instructions were decoded from `source.wasm`, linked to metadata tokens through the module's initialized IL2CPP tables, and interpreted using the same build's field-offset and type tables. `wasm-gameplay-disassembly.json` retains exact instruction byte offsets, signatures and method identity; its Markdown companion provides readable disassembly. No supplied game code was instantiated or executed.

## How method names were linked to compiled code

`source.wasm` has no custom/name sections, but its initialized data contains the IL2CPP codegen module records. The `Assembly-CSharp.dll` record is at linear-memory address **4,695,912**, with **4,833 method-table entries** at address **7,072,160**. Metadata method tokens' 24-bit RIDs select those entries. Each nonzero entry is a Wasm table index; the module's active element segment resolves it to a Wasm function index and the code section resolves its exact file byte range. **4,811 game methods have nonzero entries**; others include abstract/generic methods with no direct body there. A later check handles suffix-shared assembly names (for example `System.dll` inside `Unity.InputSystem.dll`) and links all 73 image records.

The unique count/pointer pair at linear-memory address **5,623,844** contains count **73** and points to array **7,438,624**. Its 73 pointers exactly match the 73 recovered codegen module records, with no duplicates. This provides independent structural corroboration of the complete module set.

The unique structurally matching metadata registration is at linear-memory address **4,267,652**. Its types array contains **32,932 Il2CppType pointers**, and its field-offset array has **10,670 entries**, exactly matching the metadata type count. See `wasm-metadata-registration.json` for the record and limitations.

Node/V8 validates the entire Wasm module and compiles it without instantiation. Its import/export inventory is compared with the custom parser, and all **74,584 method names and declaring-type indices** are compared with the REA-decoded metadata. See `wasm-verification.json` for the actual completed checks. Runtime reachability is unobserved, and shared compiled bodies can have multiple named owners.

## Movement: recovered arithmetic

The field layout establishes `vel` at offset 180 (`x=180,y=184,z=188`) and `inputDir` at 192. The following pseudocode suppresses IL2CPP initialization checks and preserves the meaningful arithmetic.

```csharp
// PlayerController::GroundAccelerate
// func[75573], code bytes 0x016f8b6f..0x016f8d79
float limit = shooter.isCrouching ? crouchGroundLimit : groundLimit;
float remaining = limit - Dot(vel, inputDir);
if (remaining <= 0) return;
float accelerationStep = Min(remaining, groundAcceleration * Time.deltaTime);
vel += accelerationStep * inputDir;
if (clampGroundSpeed && vel.magnitude > groundLimit)
    vel = vel.normalized * groundLimit;

// PlayerController::AirAccelerate, func[75576]
float remaining = airLimit - Dot(new Vector3(vel.x, 0, vel.z), inputDir);
if (remaining > 0) {
    float accelerationStep = Min(remaining, airAcceleration * Time.deltaTime);
    vel += accelerationStep * inputDir;
}

// PlayerController::ApplyFriction, func[75574]
vel *= Clamp01(1 - Time.deltaTime * friction);

// PlayerController::ApplyAirFriction, func[75577]
float multiplier = Clamp01(1 - Time.deltaTime * airFriction);
vel.x *= multiplier;
vel.z *= multiplier; // y is unchanged here

// PlayerController::ApplyGravity, func[75575]
vel.y -= gravity * Time.deltaTime;

// PlayerController::SetSpeedMultis(ground, air), func[75562]
groundLimit = initialGroundLimit * ground;
airLimit = initialAirLimit * air;

// PlayerController::CalculateVerticalVelocity(height), func[75589]
return Sqrt(2 * Abs(gravity) * height);
```

The ground-speed clamp is conditional, occurs only after positive remaining acceleration, and uses `groundLimit` even though the earlier acceleration cap selects the crouched limit. Air acceleration's dot product uses zero vertical velocity; the compiled vector update still writes all three velocity components.

### Jump

`PlayerController::Jump(bool force)`, func[75572], code bytes `0x016f8ab9..0x016f8b69`:

```csharp
if (!force && !ableToJump) return;
if (vel.y < 0 || !additiveJump) vel.y = 0;
lastJumpTime = Time.time;
onGround = false;
vel.y += jumpHeight;
if (!autoJump) jumpPending = false;
StartCoroutine(JumpTimer());
```

Notably, `Jump` adds the field `jumpHeight` **directly as vertical velocity**. Although a separate square-root helper exists, this body does not call it. A faithful reconstruction should retain that distinction rather than assuming physical jump height from the field name.

### Verified constructor defaults

The compiled constructor's packed 64-bit stores were split using verified scalar field types and offsets. Key defaults are ground/air acceleration **100**, ground limit **12**, crouch ground limit **4**, air limit **1**, air friction **50**, friction **6**, gravity **16**, jumpHeight **6**, slope limit **45**, and `autoJump`/`additiveJump` **true**. These are constructor defaults, **not guaranteed active game settings**: serialized assets, map configuration and runtime code may replace them. See `wasm-constructor-defaults.md` for all recovered writes and exact instruction offsets.

## Shooting and damage

### Distance falloff

`Shooter::CalculateDamageByDistance(currentDistance,minDistance,maxDistance,maxDamage)` and `WorldGrenade::CalculateDamageByDistance` share compiled func[74329], whose body starts at `0x016869f2`:

```csharp
float distance = Clamp(currentDistance, minDistance, maxDistance);
return (1 - (distance - minDistance) / (maxDistance - minDistance)) * maxDamage;
```

The body has no separate guard for `minDistance == maxDistance`. It is linear falloff from maxDamage to zero over that interval. This establishes the helper's behavior, not that every weapon always calls it.

### Hit location multipliers

`Shooter::GetMultiFromRaycastHit(hit, out otherView)`, func[74321], code bytes `0x01685ba6..0x01685c97`:

```csharp
if (hit.transform.TryGetComponent<PhotonView>(out otherView)) return 1.0f;
if (hit.transform.parent == null) return 0.0f;
if (!hit.transform.parent.TryGetComponent<PhotonView>(out otherView)) return 0.0f;
if (hit.transform.CompareTag("Head")) return 1.5f;
if (hit.transform.CompareTag("Legs")) return 0.5f;
return 0.0f;
```

The `Head` and `Legs` literals are resolved from initialized metadata-usage words at linear-memory addresses **7,018,712** (`0xa0002415`) and **7,023,188** (`0xa0002cd7`). The kind-5 usage index is `(word & 0x1fffffff) >> 1`, selecting literal rows 4618 and 5739. The generic method usage word at **6,958,984** (`0xc0033fbd`) selects method-spec row 106462, which resolves to metadata method 48406, `Component.TryGetComponent`, with method-instantiation 1479, `PhotonView`. This resolves the call's generic identity rather than relying only on a shared function address. The `out` parameter is also supported by its Il2CppType byref flag.

### Shoot pipeline coverage

`Shooter::Shoot` is a 9,956-byte body, func[74319]. Decoded calls establish current ammo decrement, obscured-number conversion, recoil, random spread generation, Physics.Raycast, hit-multiplier evaluation, team comparisons, health interactions and PhotonView.RPC. Examples include `Physics.Raycast` at instruction byte offsets `0x01684294` and `0x0168456c`, `GetMultiFromRaycastHit` at `0x01684709`, and `PhotonView.RPC` at `0x016859f1`.

This large routine contains weapon- and mode-dependent branches. The call inventory alone does not establish one universal bullet algorithm, RPC payload schema, server authority or all conditions under which those branches execute. It is retained for further reconstruction rather than presented as a fully decompiled shoot method.

### Reload coroutine

`Shooter/<IenuReload>d__121::MoveNext` is a 1,422-byte body. It reads the current and maximum ammo for the selected weapon, computes missing bullets, and adds available `currentLocalWeapon.bulletAddReloadTimes[i]` values to the passed reload timer for those bullets (missing entries add zero). It exits early if already reloading or ammo is full. Otherwise it invokes the weapon reload callback, marks reloading, displays a progress indicator, decrements the remaining timer by `Time.deltaTime` on successive yields, and finally copies maximum ammo into current ammo and clears the reloading state. This is not a universal fixed-duration reload: weapon configuration affects timing.

## Health timing

`Health::IsSpawnProtected`, func[77466], code bytes `0x01785dd6..0x01785e4d`, compares synchronized Photon time with `spawnTime`:

```csharp
double duration = photonView.IsMine ? 3.4f : 3.3f;
return PhotonNetwork.Time - spawnTime < duration && spawnTime > -1;
```

The emitted constants are the exact widened float values 3.4000000953674316 and 3.299999952316284. Other damage guards, modes and ownership checks can also affect whether damage is accepted.

`Health::TryStartHealthRegen` only schedules regeneration for the local owner when current health is below max health, stopping an existing regeneration coroutine before starting another. Its generated `IenuRegenHealth` state machine initializes a delay threshold of **4 seconds**, yields **4.5 seconds** initially, and while the player remains below max health and `Time.time - lastHitOrShotTime > 4`, yields **0.4 seconds** and then calls `AddHealth(5)`. New hits/shots and coroutine restart behavior affect the actual regeneration timeline. `AddHealth` is an API operation here, not proof that arbitrary client requests are accepted by an authoritative server.

## Limits and next reconstruction boundary

The exact artifacts support much more than class-name inspection: named compiled method linkage, all image module records, field/type layouts, actual arithmetic, hit-location multipliers and several gameplay timings. They still do not include original source comments, editor project state, a live server implementation, or observations of an actual network match. No WABT output or REA Wasm decompilation is claimed; the REA metadata and independently checked custom Wasm decoding are separate evidence sources. A compiled WebGL client cannot by itself establish current server rules or live service availability.
