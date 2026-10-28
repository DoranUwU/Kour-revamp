# Gameplay structure recovered from the supplied build

Names and metadata structure originate from REA. Type signatures, custom attributes, field offsets and metadata constants are decoded by `tools/recover-metadata.mjs` from the same metadata and WASM initialized data. These are declarations and metadata, not decompiled method bodies.

## Coverage

Assembly-CSharp: 786 types, 4548 fields, 4833 methods.
Photon [PunRPC] declarations: 25. Their presence does not prove live calls or server validation.

## Relevant classes

### PlayerController

Parent: `Photon.Pun.MonoBehaviourPun`. Type definition 3935.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| disableForParkour | UnityEngine.GameObject[] |  |
| dashFill | UnityEngine.RectTransform |  |
| fastPS | ParticleSystemExtension |  |
| ladderClimbSpeed | float | 6.199999809265137 |
| umbrellaGfx | UnityEngine.GameObject |  |
| maxYVelocityFalling | float | -18 |
| umbrellaRotator | UnityEngine.Transform |  |
| myCollider | UnityEngine.CapsuleCollider |  |
| aimAssistIntensityPhone | float | 0.4000000059604645 |
| minAngleForAutoShootPhone | float | 3.5 |
| minAngleForAimAssistPhone | float | 6.5 |
| aimAssistIntensityLaptop | float | 0.03999999910593033 |
| minAngleForAutoShootLaptop | float | 0.8999999761581421 |
| minAngleForAimAssistLaptop | float | 2 |
| PLAYER_HEIGHT | float | 2.049999952316284 |
| SSCCs | ScreenSpaceCavityCurvature.SSCC[] |  |
| teamMember | TeamMember |  |
| characterAnimatorManager | CharacterAnimatorManager |  |
| shooter | Shooter |  |
| obstacleMask | UnityEngine.LayerMask |  |
| recoil | Recoil |  |
| crosshair | CrosshairReticle |  |
| playerInput | PlayerInputHandler |  |
| playerCameraParent | UnityEngine.Transform |  |
| playerCamera | UnityEngine.Camera |  |
| mouseSensitivity | float |  |
| groundAcceleration | float |  |
| airAcceleration | float |  |
| airFriction | float |  |
| groundLimit | float |  |
| crouchGroundLimit | float |  |
| airLimit | float |  |
| gravity | float |  |
| friction | float |  |
| jumpHeight | float |  |
| rampSlideLimit | float |  |
| slopeLimit | float |  |
| additiveJump | bool |  |
| autoJump | bool |  |
| clampGroundSpeed | bool |  |
| vel | UnityEngine.Vector3 |  |
| onGround | bool |  |
| currentInstability | float |  |
| landedBrTime | float |  |
| dealZoneDamage | bool |  |

Declared methods:

- `void ResetMomentum(bool resetRotation)` — metadata method 29727, token 0x6000028
- `void ResetJumps()` — metadata method 29728, token 0x6000029
- `UnityEngine.Vector3 get_InputRot()` — metadata method 29729, token 0x600002a
- `void Awake()` — metadata method 29730, token 0x600002b
- `System.Collections.IEnumerator IenuWaitForMapSettings()` — metadata method 29731, token 0x600002c
- `void Start()` — metadata method 29732, token 0x600002d
- `void SetYVelNormal(float normal)` — metadata method 29733, token 0x600002e
- `void MolotovUpdate()` — metadata method 29734, token 0x600002f
- `void ZoneUpdate()` — metadata method 29735, token 0x6000030
- `void SlowUpdate()` — metadata method 29736, token 0x6000031
- `void OnSettingsChanged()` — metadata method 29737, token 0x6000032
- `void SetSpeedMultis(float ground, float air)` — metadata method 29738, token 0x6000033
- `bool get_landedBr()` — metadata method 29739, token 0x6000034
- `void Update()` — metadata method 29740, token 0x6000035
- `void Dash(UnityEngine.Vector3 direction)` — metadata method 29741, token 0x6000036
- `void UpdateCrosshair()` — metadata method 29742, token 0x6000037
- `void RPCBRLand()` — metadata method 29743, token 0x6000038
- `void FixedUpdate()` — metadata method 29744, token 0x6000039
- `void GetMovementInput()` — metadata method 29745, token 0x600003a
- `void MouseLook()` — metadata method 29746, token 0x600003b
- `void GatherAimAssist(float autoShootAngle, float aimAssistAngle, float aimAssistIntensity, out float aimAssistX, out float aimAssistY)` — metadata method 29747, token 0x600003c
- `void GroundAccelerate()` — metadata method 29748, token 0x600003d
- `float NormalizeAngle(float angle)` — metadata method 29749, token 0x600003e
- `void AirAccelerate()` — metadata method 29750, token 0x600003f
- `void ApplyFriction()` — metadata method 29751, token 0x6000040
- `void ApplyAirFriction()` — metadata method 29752, token 0x6000041
- `void Jump(bool force)` — metadata method 29753, token 0x6000042
- `void ApplyGravity()` — metadata method 29754, token 0x6000043
- `void OnCollisionEnter(UnityEngine.Collision collision)` — metadata method 29755, token 0x6000044
- `void OnCollisionStay(UnityEngine.Collision other)` — metadata method 29756, token 0x6000045
- `void ResetParams()` — metadata method 29757, token 0x6000046
- `void OnMolotovEnded(string mollyName)` — metadata method 29758, token 0x6000047
- `void ForceQuitMolotov()` — metadata method 29759, token 0x6000048
- `void OnTriggerEnter(UnityEngine.Collider other)` — metadata method 29760, token 0x6000049
- `void OnTriggerExit(UnityEngine.Collider other)` — metadata method 29761, token 0x600004a
- `void JumpOnPad()` — metadata method 29762, token 0x600004b
- `float CalculateVerticalVelocity(float targetHeight)` — metadata method 29763, token 0x600004c
- `System.Collections.IEnumerator JumpTimer()` — metadata method 29764, token 0x600004d
- `UnityEngine.Transform GetClosestPlayer(UnityEngine.Transform[] players, out float distanceToPlayer)` — metadata method 29765, token 0x600004e
- `UnityEngine.Transform[] GetVisiblePlayers(float aimAssistAngle)` — metadata method 29766, token 0x600004f
- `void ImpactForce(UnityEngine.Vector3 vector3)` — metadata method 29767, token 0x6000050
- `void RegisterShooter(Shooter shooter)` — metadata method 29768, token 0x6000051
- `void UnregisterShooter(Shooter shooter)` — metadata method 29769, token 0x6000052
- `void SetMyVehicle(ATV aTV)` — metadata method 29770, token 0x6000053
- `void .ctor()` — metadata method 29771, token 0x6000054
- `void .cctor()` — metadata method 29772, token 0x6000055

### PlayerInputHandler

Parent: `Photon.Pun.MonoBehaviourPun`. Type definition 4384.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| ammoPanel | UnityEngine.RectTransform |  |
| alts | UnityEngine.GameObject[] |  |
| weaponKeyTxts | TMPro.TMP_Text[] |  |
| crosshairParentParent | UnityEngine.Transform |  |
| shooter | Shooter |  |
| healthRectTransform | UnityEngine.RectTransform |  |
| playerController | PlayerController |  |
| disableForMobile | UnityEngine.GameObject[] |  |
| isPaused | bool |  |
| isDancing | bool |  |
| canvasRectTransform | UnityEngine.RectTransform |  |
| mobileControlsPrefab | MobileControls |  |
| PC_SENS_MUTLI | float | 1.1619999408721924 |
| MOBILE_WEB_SENS_MUTLI | float | 0.44999998807907104 |
| MOBILE_SENS_MUTLI | float | 0.3499999940395355 |
| threshold | float | 9 |

Declared methods:

- `void Update()` — metadata method 32404, token 0x6000a9d
- `void KillMobileControls()` — metadata method 32405, token 0x6000a9e
- `void OnEnable()` — metadata method 32406, token 0x6000a9f
- `void OnDisable()` — metadata method 32407, token 0x6000aa0
- `void OnGameEnded()` — metadata method 32408, token 0x6000aa1
- `void OnDanceStatus(bool isFinished)` — metadata method 32409, token 0x6000aa2
- `void Start()` — metadata method 32410, token 0x6000aa3
- `bool get_IsGamePaused()` — metadata method 32411, token 0x6000aa4
- `void Land()` — metadata method 32412, token 0x6000aa5
- `void EnableCrosshair()` — metadata method 32413, token 0x6000aa6
- `void OnPause()` — metadata method 32414, token 0x6000aa7
- `void OnResume()` — metadata method 32415, token 0x6000aa8
- `void RefreshWeaponKeyTxts()` — metadata method 32416, token 0x6000aa9
- `void OnMobileSetWeapon(bool canAimWithWeapon)` — metadata method 32417, token 0x6000aaa
- `void OnInventoryChanged()` — metadata method 32418, token 0x6000aab
- `void Awake()` — metadata method 32419, token 0x6000aac
- `void OnClassChangedExternally()` — metadata method 32420, token 0x6000aad
- `UnityEngine.Vector2 Movement(bool forceTruth)` — metadata method 32421, token 0x6000aae
- `string logMove()` — metadata method 32422, token 0x6000aaf
- `string logLook()` — metadata method 32423, token 0x6000ab0
- `UnityEngine.Vector2 Look()` — metadata method 32424, token 0x6000ab1
- `float AvoidFlicks(float currentDeltaX, float multiThreshold)` — metadata method 32425, token 0x6000ab2
- `void SetTargetFrameRate(int targetFrameRate)` — metadata method 32426, token 0x6000ab3
- `bool Shooting(out bool shootDown, out bool shootUp)` — metadata method 32427, token 0x6000ab4
- `bool Aiming()` — metadata method 32428, token 0x6000ab5
- `bool JumpDown()` — metadata method 32429, token 0x6000ab6
- `bool FirstWeaponDown()` — metadata method 32430, token 0x6000ab7
- `bool SecondWeaponDown()` — metadata method 32431, token 0x6000ab8
- `bool ThirdWeaponDown()` — metadata method 32432, token 0x6000ab9
- `bool ForthWeaponDown()` — metadata method 32433, token 0x6000aba
- `bool Reload()` — metadata method 32434, token 0x6000abb
- `bool Dance()` — metadata method 32435, token 0x6000abc
- `bool Inspect()` — metadata method 32436, token 0x6000abd
- `bool JumpUp()` — metadata method 32437, token 0x6000abe
- `bool Crouch()` — metadata method 32438, token 0x6000abf
- `bool MobilePausedDown()` — metadata method 32439, token 0x6000ac0
- `void ResetAim()` — metadata method 32440, token 0x6000ac1
- `void .ctor()` — metadata method 32441, token 0x6000ac2
- `void .cctor()` — metadata method 32442, token 0x6000ac3
- `void <Start>b__24_0()` — metadata method 32443, token 0x6000ac4
- `void <Start>b__24_1()` — metadata method 32444, token 0x6000ac5

### SmoothPlayerCamera

Parent: `UnityEngine.MonoBehaviour`. Type definition 3936.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| height | float |  |
| moveSpeed | float |  |
| distanceLimit | float |  |
| controller | PlayerController |  |

Declared methods:

- `void Start()` — metadata method 29789, token 0x6000066
- `void Update()` — metadata method 29790, token 0x6000067
- `void .ctor()` — metadata method 29791, token 0x6000068

### Weapon

Parent: `UnityEngine.MonoBehaviour`. Type definition 4585.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| arms | FPSArms |  |
| rarity | ItemRarity |  |
| defaultSkinName | string |  |
| customMaterialForSkins | UnityEngine.Material |  |
| shootOnRelease | bool |  |
| holdToAim | bool |  |
| crosshairStyle | CrosshairStyle |  |
| relativeWeaponSize | float |  |
| weaponRenderers | UnityEngine.Renderer[] |  |
| staticInstabilityAdd | float |  |
| minDistance | float |  |
| maxDistance | float |  |
| bulletAddReloadTimes | float[] |  |
| holdToShoot | bool |  |
| icon | UnityEngine.Sprite |  |
| realisticIconPath | string |  |
| loadSequences | AudioSeq[] |  |
| aftersmokeParticleFx | UnityEngine.ParticleSystem |  |
| weaponType | WeaponType |  |
| reloadSequences | AudioSeq[] |  |
| reloadSource | UnityEngine.AudioSource |  |
| intialReloadSoundDelay | float |  |
| initialLoadSoundDelay | float |  |
| isLocal | bool |  |
| myShooter | Shooter |  |
| sniperMask | UnityEngine.GameObject |  |
| crosshair | CrosshairReticle |  |
| changeWeaponTimerAdd | float |  |
| groundSpeedMulti | float |  |
| airSpeedMulti | float |  |
| fireRate | float |  |
| reloadTime | float |  |
| recoilCrazinessCrosshair | float |  |
| recoilCrazinessPhysical | float |  |
| recoilReturnSpeed | float |  |
| damage | int |  |
| maxAmmo | int |  |
| instabilityMultiplier | float |  |
| weaponOffsetParent | UnityEngine.Transform |  |
| currentCameras | UnityEngine.Camera[] |  |
| bulletSpawnPoint | UnityEngine.Transform |  |
| bulletPrefab | Bullet |  |
| audioSource | UnityEngine.AudioSource |  |
| muzzleFlash | MuzzleFlash |  |
| handsModel | UnityEngine.GameObject |  |
| isAiming | bool |  |
| isReloading | bool |  |
| lobbyAnimatorPlayAnimationName | string |  |

Declared methods:

- `UnityEngine.Renderer[] GetWeaponRenderers()` — metadata method 33756, token 0x6000fe5
- `UnityEngine.GameObject GetFirstWeaponRendererObject()` — metadata method 33757, token 0x6000fe6
- `void SetSkin(bool force, bool useStandardShader, string skinName)` — metadata method 33758, token 0x6000fe7
- `void ApplySkinTexture(bool useStandardShader, UnityEngine.Texture2D texture)` — metadata method 33759, token 0x6000fe8
- `void OnUserMouseUp()` — metadata method 33760, token 0x6000fe9
- `void SetImageWithMyRealisticIcon(UnityEngine.UI.Image image, int customSize, bool animate)` — metadata method 33761, token 0x6000fea
- `void Start()` — metadata method 33762, token 0x6000feb
- `void OnStart()` — metadata method 33763, token 0x6000fec
- `UnityEngine.Animator get_animator()` — metadata method 33764, token 0x6000fed
- `void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine)` — metadata method 33765, token 0x6000fee
- `System.Collections.IEnumerator AftersmokeCoroutine()` — metadata method 33766, token 0x6000fef
- `void Reload(int ammoLeft)` — metadata method 33767, token 0x6000ff0
- `System.Collections.IEnumerator IenuReloadSequences(bool is2DSound)` — metadata method 33768, token 0x6000ff1
- `System.Collections.IEnumerator IenuLoadSequences(bool is2DSound)` — metadata method 33769, token 0x6000ff2
- `void Die()` — metadata method 33770, token 0x6000ff3
- `void Aim()` — metadata method 33771, token 0x6000ff4
- `void StopAim()` — metadata method 33772, token 0x6000ff5
- `void EndReload()` — metadata method 33773, token 0x6000ff6
- `void Inspect()` — metadata method 33774, token 0x6000ff7
- `void .ctor()` — metadata method 33775, token 0x6000ff8

### AimableWeapon

Parent: `Weapon`. Type definition 3992.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| aimDuration | float |  |
| fovMultiOnAim | float |  |
| defaultWeaponParentPosition | UnityEngine.Vector3 |  |
| defaultWeaponParentRotation | UnityEngine.Vector3 |  |
| targetAimWeaponParentPosition | UnityEngine.Vector3 |  |
| targetAimWeaponParentRotation | UnityEngine.Vector3 |  |
| aftershotSource | UnityEngine.AudioSource |  |
| intialAftershotDelay | float |  |
| aftershots | AfterShot[] |  |
| instabilityWhileAiming | float |  |

Declared methods:

- `void OnEnable()` — metadata method 30081, token 0x600018a
- `void Aim()` — metadata method 30082, token 0x600018b
- `void StopAim()` — metadata method 30083, token 0x600018c
- `void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine)` — metadata method 30084, token 0x600018d
- `System.Collections.IEnumerator IenuAftershots(bool is2DSound)` — metadata method 30085, token 0x600018e
- `void .ctor()` — metadata method 30086, token 0x600018f
- `void <OnEnable>b__11_0()` — metadata method 30087, token 0x6000190
- `bool <Aim>g__AnimatorHasState|12_0(UnityEngine.Animator animator, string stateName)` — metadata method 30088, token 0x6000191
- `void <Aim>b__12_1()` — metadata method 30089, token 0x6000192
- `void <StopAim>b__13_0()` — metadata method 30090, token 0x6000193

### BurstWeapon

Parent: `Weapon`. Type definition 4046.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| bulletRowAmount | int |  |
| bulletBurstFireRate | float |  |

Declared methods:

- `void .ctor()` — metadata method 30401, token 0x60002ca

### Shotgun

Parent: `Weapon`. Type definition 4524.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| bulletsPerShot | int |  |
| intialAftershotDelay | float |  |
| aftershots | AfterShot[] |  |
| aftershotSource | UnityEngine.AudioSource |  |
| playOnEndOfReload | AudioSeq[] |  |
| reloadIncreament | int |  |

Declared methods:

- `void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine)` — metadata method 33348, token 0x6000e4d
- `System.Collections.IEnumerator IenuAftershots(bool is2DSound)` — metadata method 33349, token 0x6000e4e
- `void Reload(int ammoLeft)` — metadata method 33350, token 0x6000e4f
- `int GetTotalReloads(int currentlyHave)` — metadata method 33351, token 0x6000e50
- `System.Collections.IEnumerator IenuReloadSequences(bool is2DSound, int ammoLeft)` — metadata method 33352, token 0x6000e51
- `void .ctor()` — metadata method 33353, token 0x6000e52

### Sniper

Parent: `Weapon`. Type definition 4528.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| aimDuration | float |  |
| fovMultiOnAim | float |  |
| defaultWeaponParentPosition | UnityEngine.Vector3 |  |
| defaultWeaponParentRotation | UnityEngine.Vector3 |  |
| targetAimWeaponParentPosition | UnityEngine.Vector3 |  |
| targetAimWeaponParentRotation | UnityEngine.Vector3 |  |
| aftershotSource | UnityEngine.AudioSource |  |
| intialAftershotDelay | float |  |
| aftershots | AfterShot[] |  |
| sniperVisuals | UnityEngine.GameObject[] |  |
| instabilityWhileAiming | float |  |
| showSniperMask | bool |  |
| allowAimBetweenShots | bool |  |

Declared methods:

- `void Aim()` — metadata method 33373, token 0x6000e66
- `void StopAim()` — metadata method 33374, token 0x6000e67
- `void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine)` — metadata method 33375, token 0x6000e68
- `System.Collections.IEnumerator IenuAftershots(bool is2DSound)` — metadata method 33376, token 0x6000e69
- `void .ctor()` — metadata method 33377, token 0x6000e6a
- `void <Aim>b__13_0()` — metadata method 33378, token 0x6000e6b
- `void <StopAim>b__14_0()` — metadata method 33379, token 0x6000e6c

### Minigun

Parent: `Weapon`. Type definition 4325.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| reloadSmoke | UnityEngine.ParticleSystem |  |

Declared methods:

- `void OnStart()` — metadata method 32052, token 0x600093d
- `void Reload(int ammoLeft)` — metadata method 32053, token 0x600093e
- `void DisableReloadSmoke()` — metadata method 32054, token 0x600093f
- `void .ctor()` — metadata method 32055, token 0x6000940

### RocketLauncher

Parent: `Weapon`. Type definition 4428.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| tempRocket | UnityEngine.GameObject |  |
| aimDuration | float |  |
| fovMultiOnAim | float |  |
| defaultWeaponParentPosition | UnityEngine.Vector3 |  |
| defaultWeaponParentRotation | UnityEngine.Vector3 |  |
| targetAimWeaponParentPosition | UnityEngine.Vector3 |  |
| targetAimWeaponParentRotation | UnityEngine.Vector3 |  |
| aftershotSource | UnityEngine.AudioSource |  |
| intialAftershotDelay | float |  |
| aftershots | AfterShot[] |  |
| sniperVisuals | UnityEngine.GameObject[] |  |
| instabilityWhileAiming | float |  |

Declared methods:

- `void EndReload()` — metadata method 32654, token 0x6000b97
- `void OnStart()` — metadata method 32655, token 0x6000b98
- `void Aim()` — metadata method 32656, token 0x6000b99
- `void StopAim()` — metadata method 32657, token 0x6000b9a
- `void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine)` — metadata method 32658, token 0x6000b9b
- `System.Collections.IEnumerator IenuAftershots(bool is2DSound)` — metadata method 32659, token 0x6000b9c
- `void .ctor()` — metadata method 32660, token 0x6000b9d
- `void <Aim>b__15_0()` — metadata method 32661, token 0x6000b9e
- `void <StopAim>b__16_0()` — metadata method 32662, token 0x6000b9f

### WeaponCarrier

Parent: `UnityEngine.MonoBehaviour`. Type definition 4587.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| data | WeaponCarrierData |  |

Declared methods:

- `int SafeHatIndex(int given)` — metadata method 33797, token 0x600100e
- `int SafeEmoteIndex(int given)` — metadata method 33798, token 0x600100f
- `void Awake()` — metadata method 33799, token 0x6001010
- `int RealIndexOfWeapon(Weapon skin)` — metadata method 33800, token 0x6001011
- `int RealIndexOfItem(Item skin)` — metadata method 33801, token 0x6001012
- `int InstanceRealIndexOfWeaponByName(Weapon weapon)` — metadata method 33802, token 0x6001013
- `int InstanceRealIndexOfItem(Item item)` — metadata method 33803, token 0x6001014
- `int FindIndexByName(Item[] items, string itemName)` — metadata method 33804, token 0x6001015
- `void Start()` — metadata method 33805, token 0x6001016
- `WeaponClass GetRandomClass(out int index)` — metadata method 33806, token 0x6001017
- `bool IsCustomSkin(int skinIndex)` — metadata method 33807, token 0x6001018
- `void SetClass(int classIndex)` — metadata method 33808, token 0x6001019
- `int[] InitialClasses()` — metadata method 33809, token 0x600101a
- `WeaponClass GetCurrentClass(out int classIndex)` — metadata method 33810, token 0x600101b
- `void set_currentSkinIndex(int value)` — metadata method 33811, token 0x600101c
- `int get_currentSkinIndex()` — metadata method 33812, token 0x600101d
- `void RefreshSkinWith(int with)` — metadata method 33813, token 0x600101e
- `void .ctor()` — metadata method 33814, token 0x600101f

### WeaponClass

Parent: `UnityEngine.ScriptableObject`. Type definition 4590.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| canGetChosenRandomly | bool |  |
| overrideCharacterSkinIndex | int |  |
| description | string |  |
| iconName | string |  |
| weaponIndexes | int[] |  |
| overrideWeaponIndexesNew | int[] |  |
| health | int |  |
| classLevels | ClassLevel[] |  |
| firstLevelIsUnlock | bool |  |

Declared methods:

- `string get_iconPath()` — metadata method 33818, token 0x6001023
- `int[] get_finalWeaponIndexes()` — metadata method 33819, token 0x6001024
- `void .ctor()` — metadata method 33820, token 0x6001025

### Shooter

Parent: `Photon.Pun.MonoBehaviourPun`. Type definition 4481.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| kpTxt | TMPro.TMP_Text |  |
| overrideSpine3 | UnityEngine.Animations.Rigging.OverrideTransform |  |
| offsetKourstrike | UnityEngine.Transform |  |
| generalReaycastMask | UnityEngine.LayerMask |  |
| localCanvas | UnityEngine.RectTransform |  |
| gunGameProgressUI | GunGameProgress |  |
| reloadTipTxt | TMPro.TMP_Text |  |
| generalTipTxt | TMPro.TMP_Text |  |
| gameRunning | bool |  |
| characterSkinManager | CharacterSkinManager |  |
| teamMember | TeamMember |  |
| characterAnimatorManager | CharacterAnimatorManager |  |
| grantXpOnAssist | int | 25 |
| myClassIndex | int |  |
| mySkinIndex | int |  |
| myHatIndex | int |  |
| weaponIcons | WeaponGameplayIcon[] |  |
| onShotPanel | UnityEngine.GameObject |  |
| health | Health |  |
| weaponOffsetParent | UnityEngine.Transform |  |
| playerController | PlayerController |  |
| crouchLocalTransformParent | UnityEngine.Transform |  |
| crouchLocalWeaponTransformParent | UnityEngine.Transform |  |
| crouchPosition | UnityEngine.Vector3 |  |
| crouchRotation | UnityEngine.Vector3 |  |
| weaponCrouchRotation | UnityEngine.Vector3 |  |
| reloadingImage | UnityEngine.RectTransform |  |
| hitmarks | Hitmark[] |  |
| onKilledUI | OnKilledUI |  |
| shootLayerMask | UnityEngine.LayerMask |  |
| cam | UnityEngine.Camera |  |
| weaponCamera | UnityEngine.Camera |  |
| recoil | Recoil |  |
| ammoTxt | TMPro.TMP_Text |  |
| playerInputHandler | PlayerInputHandler |  |
| localWeaponParent | UnityEngine.Transform |  |
| globalWeaponParent | UnityEngine.Transform |  |
| head | UnityEngine.Collider |  |
| legs | UnityEngine.CapsuleCollider |  |
| myCapsuleCollider | UnityEngine.CapsuleCollider |  |
| currentLocalWeapon | Weapon |  |
| currentGlobalWeapon | Weapon |  |
| isCrouching | bool |  |
| isReloading | bool |  |
| KILL_ROW_DELTA_TIME | float | 10 |
| sniperMask | UnityEngine.GameObject |  |
| crosshair | CrosshairReticle |  |
| crosshairParent | UnityEngine.Transform |  |
| currentATV | ATV |  |
| neckNetworkXRotation | int |  |

Declared methods:

- `void RequestToOpenBuyMenu()` — metadata method 32982, token 0x6000cdf
- `void TeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)` — metadata method 32983, token 0x6000ce0
- `void RPCTeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)` — metadata method 32984, token 0x6000ce1
- `void TeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation, float wait)` — metadata method 32985, token 0x6000ce2
- `void SetBomb(bool giveBomb, bool isPlanting)` — metadata method 32986, token 0x6000ce3
- `void GiveWeapon(int onLocalSlotIndex, int weaponIndex, int ammo)` — metadata method 32987, token 0x6000ce4
- `void RemoveWeapon(int onLocalSlotIndex)` — metadata method 32988, token 0x6000ce5
- `void NewKourStrikeRoundStarted(int[] useWeapons, int planterId, Photon.Pun.UtilityScripts.PhotonTeam myTeam)` — metadata method 32989, token 0x6000ce6
- `void OnSpawnedBattleRoyale()` — metadata method 32990, token 0x6000ce7
- `void OnEnable()` — metadata method 32991, token 0x6000ce8
- `void OnDisable()` — metadata method 32992, token 0x6000ce9
- `void OnMove(bool isFirstTime)` — metadata method 32993, token 0x6000cea
- `void SetGlobalWeapon(bool active)` — metadata method 32994, token 0x6000ceb
- `void SetCustomBottomTip(string txt)` — metadata method 32995, token 0x6000cec
- `void HideCustomBottomTip()` — metadata method 32996, token 0x6000ced
- `void SetAirState(bool isGrounded)` — metadata method 32997, token 0x6000cee
- `void RPCInitiateDance(string danceName)` — metadata method 32998, token 0x6000cef
- `void RPCEndOfDance()` — metadata method 32999, token 0x6000cf0
- `void RPCSetAirState(bool isGrounded)` — metadata method 33000, token 0x6000cf1
- `void RPCSetAnimatorBoolForEveryone(string boolName, bool value)` — metadata method 33001, token 0x6000cf2
- `void RPCSetAnimatorLayerWeightForEveryone(int layerIndex, float weight)` — metadata method 33002, token 0x6000cf3
- `void OnOtherPlayerEliminated(Shooter killer, int whoID)` — metadata method 33003, token 0x6000cf4
- `void SetCrouch(bool crouch, bool aiming, bool pushToOthers)` — metadata method 33004, token 0x6000cf5
- `void RPCSetCrouch(bool crouch)` — metadata method 33005, token 0x6000cf6
- `UnityEngine.Color GetColorFromFloat(float value)` — metadata method 33006, token 0x6000cf7
- `void Awake()` — metadata method 33007, token 0x6000cf8
- `System.Collections.IEnumerator IenuWaitForMapSettings()` — metadata method 33008, token 0x6000cf9
- `void UpdateWeaponUIAndSetIndex(int ind)` — metadata method 33009, token 0x6000cfa
- `void UpdateCanSwitchTeam()` — metadata method 33010, token 0x6000cfb
- `void Start()` — metadata method 33011, token 0x6000cfc
- `void Update()` — metadata method 33012, token 0x6000cfd
- `void ParkourModeRespawn()` — metadata method 33013, token 0x6000cfe
- `void RPCDefuseBomb()` — metadata method 33014, token 0x6000cff
- `void RpcOnMouseUp()` — metadata method 33015, token 0x6000d00
- `void Shoot(int recursiveBurst)` — metadata method 33016, token 0x6000d01
- `void OnKilledChick(int scoreToGive)` — metadata method 33017, token 0x6000d02
- `void RPCExplodeBarrel(string barrelId, double atTime)` — metadata method 33018, token 0x6000d03
- `System.Collections.IEnumerator IenuShootAgain(float afterTime, int burstRecursive)` — metadata method 33019, token 0x6000d04
- `float CalculateDamageByDistance(float currentDistance, float minDistance, float maxDistance, float maxDamage)` — metadata method 33020, token 0x6000d05
- `float GetMultiFromRaycastHit(UnityEngine.RaycastHit hit, out Photon.Pun.PhotonView otherView)` — metadata method 33021, token 0x6000d06
- `System.Collections.IEnumerator IenuOnShotPanel()` — metadata method 33022, token 0x6000d07
- `Hitmark GetAvailableHitmark()` — metadata method 33023, token 0x6000d08
- `WorldHitmark GetAvailableWorldHitmark()` — metadata method 33024, token 0x6000d09
- `System.Collections.IEnumerator IenuReload(float reloadTime)` — metadata method 33025, token 0x6000d0a
- `void OnHitted(int damageDealt, Health who, string hitTag)` — metadata method 33026, token 0x6000d0b
- `void OnHitted(int damageDealt, KourBot who, string hitTag)` — metadata method 33027, token 0x6000d0c
- `void OnKilled(int damageDealt, Health who, string hitTag)` — metadata method 33028, token 0x6000d0d
- `void RPCForceGameEndedForAll()` — metadata method 33029, token 0x6000d0e
- `System.Collections.IEnumerator IenuDisableHitmarks(Hitmark hitmark, WorldHitmark worldHitmark)` — metadata method 33030, token 0x6000d0f
- `void RPCShoot(UnityEngine.Vector3[] ats, UnityEngine.Vector3[] hitNormals, int targetId, int damage, int hitTagNameIndex)` — metadata method 33031, token 0x6000d10
- `void OnClassChangedExternally(int newClass, int localWeaponIndexToSet)` — metadata method 33032, token 0x6000d11
- `void RPCOnClassChanged(int newClass, int skinIndex, int hatIndex)` — metadata method 33033, token 0x6000d12
- `void SetWeapon(int localweaponIndex, bool force)` — metadata method 33034, token 0x6000d13
- `int GetCurrentAmmo()` — metadata method 33035, token 0x6000d14
- `void PlayJumpPad(int jumpPadId)` — metadata method 33036, token 0x6000d15
- `void RPCJumpPad(int jumpPadId)` — metadata method 33037, token 0x6000d16
- `void RPCSetWeapon(int weaponIndex, int skinIndex)` — metadata method 33038, token 0x6000d17
- `void EnsureKill(int viewID)` — metadata method 33039, token 0x6000d18
- `void RPCEnsureKill(int whoId)` — metadata method 33040, token 0x6000d19
- `void ExplosiveDamage(int damage, bool showFeedback, int[] targetViewIDs)` — metadata method 33041, token 0x6000d1a
- `void BarrelExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs)` — metadata method 33042, token 0x6000d1b
- `void RPCExplosiveDamage(int damage, bool showFeedback, int[] targetViewIDs)` — metadata method 33043, token 0x6000d1c
- `void RPCBarrelExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs)` — metadata method 33044, token 0x6000d1d
- `void TryStopDefuse()` — metadata method 33045, token 0x6000d1e
- `void RPCStopDefuseBomb()` — metadata method 33046, token 0x6000d1f
- `void OnFlash(float flashStrength)` — metadata method 33047, token 0x6000d20
- `float EaseOutExpo(float x)` — metadata method 33048, token 0x6000d21
- `void HandleInventorySwap(int indexA, int indexB)` — metadata method 33049, token 0x6000d22
- `void SetMyVehicle(ATV aTV)` — metadata method 33050, token 0x6000d23
- `void OnPhotonSerializeView(Photon.Pun.PhotonStream stream, Photon.Pun.PhotonMessageInfo info)` — metadata method 33051, token 0x6000d24
- `void .ctor()` — metadata method 33052, token 0x6000d25
- `void .cctor()` — metadata method 33053, token 0x6000d26
- `void <OnKilled>g__ForceGameEndForAll|128_0()` — metadata method 33054, token 0x6000d27
- `void <OnKilled>g__ShowKillRowMessage|128_1()` — metadata method 33055, token 0x6000d28

### Health

Parent: `Photon.Pun.MonoBehaviourPun`. Type definition 4230.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| MINE_SPAWN_PROTECTION | float | 3.4000000953674316 |
| OTHER_SPAWN_PROTECTION | float | 3.299999952316284 |
| shieldPanel | UnityEngine.GameObject |  |
| spawnProtectedVignette | UnityEngine.GameObject |  |
| spawnProtectedTxt | TMPro.TMP_Text |  |
| spawnProtectedGO | UnityEngine.GameObject |  |
| globalHealthFill | UnityEngine.Transform |  |
| globalHealthLerpFill | UnityEngine.Transform |  |
| hitVignette | UnityEngine.UI.Image |  |
| healthFill | UnityEngine.UI.Image |  |
| healthTxt | TMPro.TMP_Text |  |
| head | UnityEngine.GameObject |  |
| legs | UnityEngine.GameObject |  |
| backInCanvas | BackInCanvas |  |
| kourstrikeBackInCanvas | KourstrikeBackInCanvas |  |
| battleRoyaleBackInCanvas | BattleRoyaleBackInCanvas |  |
| cam | UnityEngine.Camera |  |
| globalGfx | UnityEngine.GameObject[] |  |
| currentHealth | CodeStage.AntiCheat.ObscuredTypes.ObscuredInt |  |
| localDied | bool |  |
| damageCircles | DamageCircle[] |  |
| lastHitOrShotTime | float |  |
| globalDied | bool |  |

Declared methods:

- `bool IsSpawnProtected()` — metadata method 31398, token 0x60006af
- `int GetMaxHealth()` — metadata method 31399, token 0x60006b0
- `void OnShoot()` — metadata method 31400, token 0x60006b1
- `void Start()` — metadata method 31401, token 0x60006b2
- `System.Collections.IEnumerator IenuOnSpawn()` — metadata method 31402, token 0x60006b3
- `void TryStartHealthRegen()` — metadata method 31403, token 0x60006b4
- `void OnTeleport()` — metadata method 31404, token 0x60006b5
- `void TakeHealth(bool showIndicator, int amount, string hitTagName, Photon.Realtime.Player by, Shooter byShooter, UnityEngine.Vector3 hitPos)` — metadata method 31405, token 0x60006b6
- `DamageCircle GetAvailableDamageCircle()` — metadata method 31406, token 0x60006b7
- `void EndUseOfDamangeCircle(DamageCircle hitmark)` — metadata method 31407, token 0x60006b8
- `void ShowMarker(bool showUIIndicator, UnityEngine.Transform byy)` — metadata method 31408, token 0x60006b9
- `System.Collections.IEnumerator IenuHideDamageCircle(DamageCircle dc)` — metadata method 31409, token 0x60006ba
- `void AddHealth(int amount)` — metadata method 31410, token 0x60006bb
- `void InitiateTakeHealth(int amount)` — metadata method 31411, token 0x60006bc
- `void RPCTakeHealth(int amount)` — metadata method 31412, token 0x60006bd
- `System.Collections.IEnumerator IenuRegenHealth()` — metadata method 31413, token 0x60006be
- `void Update()` — metadata method 31414, token 0x60006bf
- `void LocalDie(Photon.Realtime.Player by, Shooter byShooter, string hitTagName, bool willRespawn)` — metadata method 31415, token 0x60006c0
- `void OnDestroy()` — metadata method 31416, token 0x60006c1
- `void GlobalDie(Shooter killer)` — metadata method 31417, token 0x60006c2
- `void OnMaxHpChanged(int newMaxHp)` — metadata method 31418, token 0x60006c3
- `void RpcOnMaxHealthChanged(int newMaxHp)` — metadata method 31419, token 0x60006c4
- `void OnBombExploaded(UnityEngine.Vector3 bombPos)` — metadata method 31420, token 0x60006c5
- `void .ctor()` — metadata method 31421, token 0x60006c6
- `void <IenuOnSpawn>b__27_0()` — metadata method 31422, token 0x60006c7

### NetworkManager

Parent: `Photon.Pun.MonoBehaviourPunCallbacks`. Type definition 4357.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| GUEST_NAME | string | "Guest" |
| KOUR_MOBILE_MAP | int | 3 |
| KOURSTRIKE_MOBILE_MAP | int | 8 |
| KOURZONE_MOBILE_MAP | int | 10 |
| currentGameMode | GameMode |  |
| gameModes | GameMode[] |  |
| joinRoomNameOnConnect | string |  |
| GAME_MODE_KEY | string | "C0" |
| MAP_KEY | string | "C1" |
| MATCH_TIME_KEY | string | "C2" |
| CUSTOM_MAP_ID_KEY | string | "C3" |
| CUSTOM_MAP_ID_KEY_FOR_INROOM | string | "C4" |
| isLookingForMatch | bool |  |
| propertiesOnFailedJoinRandom | ExitGames.Client.Photon.Hashtable |  |
| SpawnReuseCooldown | double | 3.5 |

Declared methods:

- `string getRegion()` — metadata method 32159, token 0x60009a8
- `int GetMaxTimer()` — metadata method 32160, token 0x60009a9
- `GameMode GetRandomGameMode()` — metadata method 32161, token 0x60009aa
- `int get_MOBILE_MAP()` — metadata method 32162, token 0x60009ab
- `int[] get_AUTOPLAY_MAPS()` — metadata method 32163, token 0x60009ac
- `void add_OnConnectedToMasterServer(System.Action<string> value)` — metadata method 32164, token 0x60009ad
- `void remove_OnConnectedToMasterServer(System.Action<string> value)` — metadata method 32165, token 0x60009ae
- `GameMode GetGameModeFromIndex(int i)` — metadata method 32166, token 0x60009af
- `GameMode GetRoomGameMode()` — metadata method 32167, token 0x60009b0
- `int GetRoomMapBuildIndex()` — metadata method 32168, token 0x60009b1
- `GameMode GetGameMode(int id)` — metadata method 32169, token 0x60009b2
- `void SetCurrentGameMode(int id, out GameMode gameMode)` — metadata method 32170, token 0x60009b3
- `void SetCurrentGameMode(string gameModeName, out GameMode gameMode)` — metadata method 32171, token 0x60009b4
- `void SetCurrentGameMode(GameMode gameMode)` — metadata method 32172, token 0x60009b5
- `void SetURLRoomNameRequest(string to)` — metadata method 32173, token 0x60009b6
- `string GetURLRoomNameRequest(string debugFrom)` — metadata method 32174, token 0x60009b7
- `void OnOtherPlayerDied(Shooter killer, int whoID)` — metadata method 32175, token 0x60009b8
- `Health GetMyPlayerHealth(out int viewId)` — metadata method 32176, token 0x60009b9
- `bool TryGetMyPlayer(out UnityEngine.GameObject _myPlayer)` — metadata method 32177, token 0x60009ba
- `void OnGameplayWeaponClassChanged(int newClass)` — metadata method 32178, token 0x60009bb
- `void OnLeftRoom()` — metadata method 32179, token 0x60009bc
- `void Awake()` — metadata method 32180, token 0x60009bd
- `void OnGameEnded(bool willKillPlayer, out int teamIndex)` — metadata method 32181, token 0x60009be
- `void OneTimeAwake()` — metadata method 32182, token 0x60009bf
- `bool NewConnectUsingSettings()` — metadata method 32183, token 0x60009c0
- `void Start()` — metadata method 32184, token 0x60009c1
- `void SetMyPlayerPropertiesForParty()` — metadata method 32185, token 0x60009c2
- `void PlayCustomJoin(string roomName, out bool canPlay)` — metadata method 32186, token 0x60009c3
- `bool CreateCustom(string rName, int maxPlayers, bool isPrivate, ExitGames.Client.Photon.Hashtable hash)` — metadata method 32187, token 0x60009c4
- `void OnCreateRoomFailed(short returnCode, string message)` — metadata method 32188, token 0x60009c5
- `string GetSqlLobbyFilter(ExitGames.Client.Photon.Hashtable expectedProperties)` — metadata method 32189, token 0x60009c6
- `void PlayPressed(out bool canPlay)` — metadata method 32190, token 0x60009c7
- `void ResetIsJoinRandomRoom()` — metadata method 32191, token 0x60009c8
- `void OnRoomListUpdate(System.Collections.Generic.List<Photon.Realtime.RoomInfo> roomList)` — metadata method 32192, token 0x60009c9
- `float GetRoomScore(Photon.Realtime.RoomInfo room)` — metadata method 32193, token 0x60009ca
- `void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)` — metadata method 32194, token 0x60009cb
- `ExitGames.Client.Photon.Hashtable GetMatchmakingFilter()` — metadata method 32195, token 0x60009cc
- `Photon.Realtime.RoomOptions GetRoomOptions(bool isPrivate, ExitGames.Client.Photon.Hashtable hashtable, int overrideMaxPlayers)` — metadata method 32196, token 0x60009cd
- `void SetURL(string add)` — metadata method 32197, token 0x60009ce
- `string GetParameter(string key)` — metadata method 32198, token 0x60009cf
- `void OnJoinRandomFailed(short returnCode, string message)` — metadata method 32199, token 0x60009d0
- `void OnJoinRoomFailed(short returnCode, string message)` — metadata method 32200, token 0x60009d1
- `bool get_CurrentRoomIsParty()` — metadata method 32201, token 0x60009d2
- `string get_CurrentPartyLeaderId()` — metadata method 32202, token 0x60009d3
- `string OpenParty(string inviteUid)` — metadata method 32203, token 0x60009d4
- `void JoinParty(string lobbyId)` — metadata method 32204, token 0x60009d5
- `void LeaveParty()` — metadata method 32205, token 0x60009d6
- `void OnJoinedRoom()` — metadata method 32206, token 0x60009d7
- `void OnConnectedToMaster()` — metadata method 32207, token 0x60009d8
- `void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)` — metadata method 32208, token 0x60009d9
- `string GetUrlParam(string paramName)` — metadata method 32209, token 0x60009da
- `void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)` — metadata method 32210, token 0x60009db
- `void OnGameSceneLoad(bool canSpawnPlayer)` — metadata method 32211, token 0x60009dc
- `void SpawnSpectateCamera()` — metadata method 32212, token 0x60009dd
- `void SpawnPlayer(UnityEngine.Vector3 atSpawnPoint, UnityEngine.Quaternion rot, bool justSwitchedTeams)` — metadata method 32213, token 0x60009de
- `void SpawnPlayer()` — metadata method 32214, token 0x60009df
- `UnityEngine.Vector3 GetSpawnPositionFarFromPlayers(out UnityEngine.Quaternion rot, bool justSwitchedTeams, Photon.Pun.UtilityScripts.PhotonTeam team)` — metadata method 32215, token 0x60009e0
- `void OnDisconnectedSimulate(bool forceShowReconnectDialog, Photon.Realtime.ServerConnection expectedServerConnection)` — metadata method 32216, token 0x60009e1
- `void OnDisconnected(Photon.Realtime.DisconnectCause cause)` — metadata method 32217, token 0x60009e2
- `bool IsInternetAvailable()` — metadata method 32218, token 0x60009e3
- `void Reconnect()` — metadata method 32219, token 0x60009e4
- `void ConnectAgain()` — metadata method 32220, token 0x60009e5
- `void Respawn()` — metadata method 32221, token 0x60009e6
- `string GenerateRoomName(int length, bool numbersOnly)` — metadata method 32222, token 0x60009e7
- `void .ctor()` — metadata method 32223, token 0x60009e8
- `void .cctor()` — metadata method 32224, token 0x60009e9
- `<>f__AnonymousType0<Photon.Realtime.RoomInfo, float> <OnRoomListUpdate>b__55_0(Photon.Realtime.RoomInfo room)` — metadata method 32225, token 0x60009ea
- `void <OnJoinRoomFailed>b__71_0()` — metadata method 32226, token 0x60009eb
- `void <OnJoinRoomFailed>b__71_1()` — metadata method 32227, token 0x60009ec
- `void <OnDisconnectedSimulate>b__95_0()` — metadata method 32228, token 0x60009ed
- `void <OnDisconnectedSimulate>b__95_1()` — metadata method 32229, token 0x60009ee

### GameMode

Parent: `UnityEngine.ScriptableObject`. Type definition 4204.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| chanceWeight | float |  |
| mobileChanceWeight | float |  |
| kourstrikeChanceWeight | float |  |
| kourzoneChanceWeight | float |  |
| id | int |  |
| canChangeTimerOnPrivateMatches | bool |  |
| canChangeMaxPlayersOnPrivateMatches | bool |  |
| forcesMap | int[] |  |
| _maxPlayers | int |  |
| _teamSize | int |  |
| matchTimeInSeconds | int |  |
| sprite | UnityEngine.Sprite |  |
| weaponList | Weapon[] |  |
| forcePrivate | bool |  |
| excludeFromPubs | bool |  |
| excludeFromPubsKourstrike | bool |  |
| excludeFromPubsKourZone | bool |  |

Declared methods:

- `float get_ChanceWeight()` — metadata method 31272, token 0x6000631
- `void .ctor()` — metadata method 31273, token 0x6000632

### MapInfo

Parent: `UnityEngine.MonoBehaviour`. Type definition 4319.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| GOsecrets | UnityEngine.GameObject[] |  |
| disableForParkour | UnityEngine.GameObject[] |  |
| customSpawnIndex | int |  |
| midgameRewards | MidgameReward[] |  |
| pressYToGetSkinPanel | PressYToGetSkinPanel |  |
| canvasScalers | UnityEngine.UI.CanvasScaler[] |  |
| friendCountTxt | TMPro.TMP_Text |  |
| yourPlaceTxtGo | UnityEngine.GameObject |  |
| missionNotification | MissionNotification |  |
| newMatchButton | UnityEngine.GameObject |  |
| roomNameStaticIF | TMPro.TMP_InputField |  |
| roomLinkStaticIF | TMPro.TMP_InputField |  |
| invitePopup | Popup |  |
| teamAddTxts | TMPro.TMP_Text[] |  |
| youImgs | UnityEngine.GameObject[] |  |
| teamBackgrounds | UnityEngine.UI.Image[] |  |
| teamImages | UnityEngine.UI.Image[] |  |
| hardpointObjectiveGOs | HardpointArea[] |  |
| sscc | ScreenSpaceCavityCurvature.SSCC |  |
| gunGameTopPanel | GunGameTopPanel |  |
| chickenExplosionYellow | bool |  |
| classSelectButtonLock | UnityEngine.GameObject |  |
| defaultChickMat | UnityEngine.Material |  |
| worldHitmarks | WorldHitmark[] |  |
| missionSlots | MissionSlot[] |  |
| hideForPoki | UnityEngine.GameObject[] |  |
| hideForCrazyGames | UnityEngine.GameObject[] |  |
| hideForAndroidAndIOS | UnityEngine.GameObject[] |  |
| hideForMobileWeb | UnityEngine.GameObject[] |  |
| chatPanel | UnityEngine.Transform |  |
| loginBtn | UnityEngine.GameObject |  |
| spectateToggle | UnityEngine.UI.Toggle |  |
| showIfLoggedIn | UnityEngine.GameObject[] |  |
| profileImage | UnityEngine.UI.Image |  |
| profileBackgroundImage | UnityEngine.UI.Image |  |
| mainMenuUsernameTxt | TMPro.TMP_Text |  |
| playerRT | UnityEngine.RenderTexture |  |
| lobbyRenderCamera | UnityEngine.Camera |  |
| leavePanel | Popup |  |
| leavePanelTopText | TMPro.TMP_Text |  |
| enableForTeams | UnityEngine.GameObject[] |  |
| teamTxts | TMPro.TMP_Text[] |  |
| lobbyPlayer | LobbyPlayer |  |
| inviteTxt | TMPro.TMP_Text |  |
| coinTxts | TMPro.TMP_Text[] |  |
| usernameTxt | TMPro.TMP_Text |  |
| lvlTxt | TMPro.TMP_Text |  |
| botPrefab | KourBot |  |
| chickenPrefab | ChickenController |  |
| chickenLines | ChickenLine[] |  |
| botLines | ChickenLine[] |  |
| victoryPanel | UnityEngine.GameObject |  |
| defeatPanel | UnityEngine.GameObject |  |
| fpsTxt | TMPro.TMP_Text |  |
| currentClassTxt | TMPro.TMP_Text |  |
| currentClassImg | UnityEngine.UI.Image |  |
| spawnPoints | UnityEngine.Transform[] |  |
| defaultCamera | UnityEngine.Camera |  |
| gameEndedPanelPrefab | GameEndedPanel |  |
| priorityCanvas | UnityEngine.RectTransform |  |
| teamSelectPanelPrefab | TeamSelectPanel |  |
| gamePausedPanel | UnityEngine.GameObject |  |
| resumeGameTxt | TMPro.TMP_Text |  |
| timerTxt | TMPro.TMP_Text |  |
| START_TIME_KEY | string | "C5" |
| gamePhotonStartTime | double |  |
| TIMER_TIMEOUT | float | 100 |
| matchEnded | bool |  |
| lastKnownTimerInSeconds | double |  |
| canvas | UnityEngine.RectTransform |  |
| leaveButtonWasPressed | bool |  |
| TEAM_1_TOTAL_SCORE_KEY | string | "T1S" |
| TEAM_2_TOTAL_SCORE_KEY | string | "T2S" |
| TEAM_3_TOTAL_SCORE_KEY | string | "T3S" |
| TEAM_4_TOTAL_SCORE_KEY | string | "T4S" |

Declared methods:

- `void OnFoundSecret(UnityEngine.GameObject secret)` — metadata method 31860, token 0x600087d
- `int GetTotalSecretsFound(out int total)` — metadata method 31861, token 0x600087e
- `void ShareRoomDiscord()` — metadata method 31862, token 0x600087f
- `string whoami()` — metadata method 31863, token 0x6000880
- `string checkRoomProp(string key)` — metadata method 31864, token 0x6000881
- `void SetCustomSpawnIndex(int index)` — metadata method 31865, token 0x6000882
- `void SetHUD(float given)` — metadata method 31866, token 0x6000883
- `void ShowMyFriendList()` — metadata method 31867, token 0x6000884
- `void KourLogoPressed()` — metadata method 31868, token 0x6000885
- `void OnLeftNavButtonPressed(string takeTo)` — metadata method 31869, token 0x6000886
- `void CloseLeavePanel()` — metadata method 31870, token 0x6000887
- `bool TryGetInstance(out MapInfo _instance)` — metadata method 31871, token 0x6000888
- `void ShowMissionPanel()` — metadata method 31872, token 0x6000889
- `void ShowProfilePanel()` — metadata method 31873, token 0x600088a
- `void ShowLoginPanel()` — metadata method 31874, token 0x600088b
- `void InviteFriend()` — metadata method 31875, token 0x600088c
- `void ResetInviteLink()` — metadata method 31876, token 0x600088d
- `void Update()` — metadata method 31877, token 0x600088e
- `void Awake()` — metadata method 31878, token 0x600088f
- `void add_OnGameSceneLoad(System.Action<bool> value)` — metadata method 31879, token 0x6000890
- `void remove_OnGameSceneLoad(System.Action<bool> value)` — metadata method 31880, token 0x6000891
- `void Start()` — metadata method 31881, token 0x6000892
- `void CheckForMidgameReward()` — metadata method 31882, token 0x6000893
- `void OnMidgameRewardClaimedOrClosed()` — metadata method 31883, token 0x6000894
- `int GetDesignIndex()` — metadata method 31884, token 0x6000895
- `TeamSelectDesign GetDesign()` — metadata method 31885, token 0x6000896
- `System.Collections.IEnumerator CheckAverageFPS()` — metadata method 31886, token 0x6000897
- `bool get_IsGunGame()` — metadata method 31887, token 0x6000898
- `bool get_IsParkour()` — metadata method 31888, token 0x6000899
- `void SpawnChicken(int i)` — metadata method 31889, token 0x600089a
- `void SpawnBot(int i)` — metadata method 31890, token 0x600089b
- `void SpawnChickenOnLine(ChickenLine line, int notOn, float afterTime)` — metadata method 31891, token 0x600089c
- `System.Collections.IEnumerator IenuSpawnChickenOnLine(ChickenLine line, int notOn, float afterTime)` — metadata method 31892, token 0x600089d
- `void SpawnBotOnLine(ChickenLine line, int notOn, float afterTime)` — metadata method 31893, token 0x600089e
- `System.Collections.IEnumerator IenuSpawnBotOnLine(ChickenLine line, int notOn, float afterTime)` — metadata method 31894, token 0x600089f
- `int[] GetUniqueRandomInts(int[] inputArray, int count)` — metadata method 31895, token 0x60008a0
- `void VerySlowUpdate()` — metadata method 31896, token 0x60008a1
- `void OnGameEnded(int timerInSeconds)` — metadata method 31897, token 0x60008a2
- `void KourstrikeEndGame()` — metadata method 31898, token 0x60008a3
- `void OnUIGameEndedAnimationFinished()` — metadata method 31899, token 0x60008a4
- `void ShowSelectTeamPanel()` — metadata method 31900, token 0x60008a5
- `void OnUserChanged(User user, bool b)` — metadata method 31901, token 0x60008a6
- `void SetNickname(string nick)` — metadata method 31902, token 0x60008a7
- `void OnChosenTeam(string teamName, TeamSelectPanel from, System.Action onApprove)` — metadata method 31903, token 0x60008a8
- `void OnPlayerJoinTeam(Photon.Realtime.Player targetPlayer, Photon.Pun.UtilityScripts.PhotonTeam team)` — metadata method 31904, token 0x60008a9
- `bool CanJoinTeam(Photon.Pun.UtilityScripts.PhotonTeam newTeam, out string result, out bool wasNullBefore)` — metadata method 31905, token 0x60008aa
- `string ToTimer(double time, bool showMillisecondsToo)` — metadata method 31906, token 0x60008ab
- `void OnEnable()` — metadata method 31907, token 0x60008ac
- `void OnDisable()` — metadata method 31908, token 0x60008ad
- `void AnalyticsReport(string n)` — metadata method 31909, token 0x60008ae
- `void FreeKP()` — metadata method 31910, token 0x60008af
- `void ShowSettingsPanel()` — metadata method 31911, token 0x60008b0
- `void OnEscape()` — metadata method 31912, token 0x60008b1
- `void ShowGamePausedUI()` — metadata method 31913, token 0x60008b2
- `void RedrawMissions()` — metadata method 31914, token 0x60008b3
- `void OnMissionPressed(MissionSlot missionSlot)` — metadata method 31915, token 0x60008b4
- `System.Collections.IEnumerator IenuShowResumeTxt()` — metadata method 31916, token 0x60008b5
- `void ResumeGamePressed()` — metadata method 31917, token 0x60008b6
- `System.Collections.IEnumerator IenuSpectateCamera()` — metadata method 31918, token 0x60008b7
- `System.Collections.IEnumerator IenuSpawnWithDelay()` — metadata method 31919, token 0x60008b8
- `void ResumeGame(bool setDefaultCamera, bool force)` — metadata method 31920, token 0x60008b9
- `void LeaveGameBtnPressed()` — metadata method 31921, token 0x60008ba
- `void ChangeClass()` — metadata method 31922, token 0x60008bb
- `void ChangeClassTo(int newClassIndex)` — metadata method 31923, token 0x60008bc
- `void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)` — metadata method 31924, token 0x60008bd
- `void FindANewMatch()` — metadata method 31925, token 0x60008be
- `M_1022[] ShuffleArray(M_1022[] array)` — metadata method 31926, token 0x60008bf
- `void ShowOtherUserProfile(string otherUserUID)` — metadata method 31927, token 0x60008c0
- `void SetupProfilePanelWith(string otherUserUID)` — metadata method 31928, token 0x60008c1
- `string ToShortString(double number)` — metadata method 31929, token 0x60008c2
- `void StartRemovingTextures()` — metadata method 31930, token 0x60008c3
- `System.Collections.IEnumerator RemoveAllTexturesAndApplyColorCoroutine()` — metadata method 31931, token 0x60008c4
- `UnityEngine.Color GetAverageColorFromMaterial(UnityEngine.Material material)` — metadata method 31932, token 0x60008c5
- `UnityEngine.Color GetAverageColor(UnityEngine.Texture2D texture)` — metadata method 31933, token 0x60008c6
- `UnityEngine.Texture2D MakeTextureReadable(UnityEngine.Texture2D original)` — metadata method 31934, token 0x60008c7
- `UnityEngine.Color AdjustBrightness(UnityEngine.Color color)` — metadata method 31935, token 0x60008c8
- `void TryHideSettingsPanel()` — metadata method 31936, token 0x60008c9
- `void .ctor()` — metadata method 31937, token 0x60008ca
- `void .cctor()` — metadata method 31938, token 0x60008cb
- `void <ShowMissionPanel>b__59_0(UnityEngine.GameObject prefab)` — metadata method 31939, token 0x60008cc
- `void <ShowProfilePanel>b__62_0(UnityEngine.GameObject prefab)` — metadata method 31940, token 0x60008cd
- `void <ShowLoginPanel>b__63_0(UnityEngine.GameObject prefab)` — metadata method 31941, token 0x60008ce
- `void <Start>b__102_0(UnityEngine.Texture2D x)` — metadata method 31942, token 0x60008cf
- `void <OnGameEnded>b__123_0()` — metadata method 31943, token 0x60008d0
- `void <ShowSettingsPanel>b__142_0(UnityEngine.GameObject prefab)` — metadata method 31944, token 0x60008d1
- `void <ChangeClass>b__154_0(int newClassIndex, WeaponClass newClass)` — metadata method 31945, token 0x60008d2
- `void <ChangeClass>b__154_1(UnityEngine.Texture2D x)` — metadata method 31946, token 0x60008d3
- `void <ChangeClassTo>b__155_0(UnityEngine.Texture2D x)` — metadata method 31947, token 0x60008d4

### MapSettings

Parent: `object`. Type definition 4302.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| gameName | string |  |
| creatorUid | string |  |
| gameMode | int |  |
| groundLimit | float |  |
| airLimit | float |  |
| forceWeapons | int[] |  |
| gravity | float |  |
| allowDash | bool |  |
| forceSkin | int |  |
| spawnPoints | UnityEngine.Vector3[] |  |

Declared methods:

- `string SerializeSettings()` — metadata method 31856, token 0x6000879
- `MapSettings DeserializeSettings(string json)` — metadata method 31857, token 0x600087a
- `void .ctor()` — metadata method 31858, token 0x600087b

### KourBot

Parent: `UnityEngine.MonoBehaviour`. Type definition 4269.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| characterSkinManager | CharacterSkinManager |  |
| health | int |  |
| animator | UnityEngine.Animator |  |
| globalWeaponParent | UnityEngine.Transform |  |
| ragdollPlayer | RagdollPlayer |  |
| globalHealthFill | UnityEngine.RectTransform |  |
| globalHealthFillLerp | UnityEngine.RectTransform |  |
| nameTxt | TMPro.TMP_Text |  |
| globalCanvas | UnityEngine.GameObject |  |
| lvlTxt | TMPro.TMP_Text |  |

Declared methods:

- `void OnDrawGizmos()` — metadata method 31624, token 0x6000791
- `void Init(ChickenLine line, int fromIndex)` — metadata method 31625, token 0x6000792
- `void Shuffle(M_1019[] array)` — metadata method 31626, token 0x6000793
- `void ChangeToRandomState()` — metadata method 31627, token 0x6000794
- `BotState GetRandomState()` — metadata method 31628, token 0x6000795
- `void Update()` — metadata method 31629, token 0x6000796
- `void MoveToNextPoint()` — metadata method 31630, token 0x6000797
- `void SetState(BotState newState)` — metadata method 31631, token 0x6000798
- `void Die()` — metadata method 31632, token 0x6000799
- `void SetWeapon(int weaponIndex, int skinIndex)` — metadata method 31633, token 0x600079a
- `void SetHoldAnimation(WeaponType type)` — metadata method 31634, token 0x600079b
- `void TakeHealth(UnityEngine.Vector3 point, int finalDamage)` — metadata method 31635, token 0x600079c
- `void DieNigga(UnityEngine.Vector3 point)` — metadata method 31636, token 0x600079d
- `void .ctor()` — metadata method 31637, token 0x600079e

### SearchAndDestroyManager

Parent: `Photon.Pun.MonoBehaviourPunCallbacks`. Type definition 4448.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| ALLOW_SWITCH_TEAM | bool | false |
| TEAM_WIN_AT_SCORE | int | 15 |
| ROUND_DURATION | float | 180 |
| BUY_PHASE_TIME | float | 10 |
| cameraFallbackOrierntation | UnityEngine.Transform |  |
| WIN_MONEY | int | 3250 |
| LOSE_MONEY | int | 1400 |
| flashImg | UnityEngine.UI.Image |  |
| teammateMinimapSpriteRenderer | UnityEngine.SpriteRenderer[] |  |
| BuyPhaseWindow | BuyPhaseMenu |  |
| aliveTerrorImages | UnityEngine.UI.Image[] |  |
| aliveCounterTerrorImages | UnityEngine.UI.Image[] |  |
| roundEndNotification | RoundEndNotification |  |
| teamMapMarkers | TeamMapMarker[] |  |
| notificationRectTransform | UnityEngine.RectTransform |  |
| notificationTxt | TMPro.TMP_Text |  |
| audioSource | UnityEngine.AudioSource |  |
| START_MONEY | int | 800 |
| moneyTxt | TMPro.TMP_Text |  |
| minimapCamera | UnityEngine.Transform |  |
| STILL_ALLOW_BUY_TIME | float | 50 |
| buyMenuCanvas | BuyMenuCanvas |  |
| currentWorldBomb | WorldBomb |  |
| currentRoundTxt | TMPro.TMP_Text |  |
| timerTxt | TMPro.TMP_Text |  |
| defusingImage | UnityEngine.UI.Image |  |
| defusingTxt | TMPro.TMP_Text |  |
| setBombEventCode | byte | 2 |
| MIN_PLAYERS_FOR_START | int | 2 |
| currentGameState | GameState |  |
| currentBombHolder | int |  |
| currentTimerText | string |  |
| AimDurationMulti | float | 0.4000000059604645 |
| DEFUSE_TIME | float | 6.5 |
| lastWinningTeam | string |  |

Declared methods:

- `void UpdateTeammateMinimapSpriteRendererColors()` — metadata method 32727, token 0x6000be0
- `void UpdateAlivePlayerImages(int kownTCount, int kownCTCount, int excludeActorNumber)` — metadata method 32728, token 0x6000be1
- `void AttachMapTracker(UnityEngine.Transform newTransform)` — metadata method 32729, token 0x6000be2
- `bool TryDetachMapTracker(UnityEngine.Transform newTransform)` — metadata method 32730, token 0x6000be3
- `void ShowNotification(string text, UnityEngine.Color c)` — metadata method 32731, token 0x6000be4
- `void PlaySound(int soundIndex, float delay)` — metadata method 32732, token 0x6000be5
- `void InstancePlaySound(int soundIndex)` — metadata method 32733, token 0x6000be6
- `void UpdateMapCameraTransform(UnityEngine.Transform with)` — metadata method 32734, token 0x6000be7
- `CodeStage.AntiCheat.ObscuredTypes.ObscuredInt get_money()` — metadata method 32735, token 0x6000be8
- `void set_money(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt value)` — metadata method 32736, token 0x6000be9
- `bool get_IsBuyMenuOpen()` — metadata method 32737, token 0x6000bea
- `void TryCloseBuyMenu()` — metadata method 32738, token 0x6000beb
- `void OnJoinedRoom()` — metadata method 32739, token 0x6000bec
- `void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)` — metadata method 32740, token 0x6000bed
- `void OnRoomPropsUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)` — metadata method 32741, token 0x6000bee
- `float get_START_AFTER_TIME()` — metadata method 32742, token 0x6000bef
- `void set_START_AFTER_TIME(float value)` — metadata method 32743, token 0x6000bf0
- `double get_currentRoundTime()` — metadata method 32744, token 0x6000bf1
- `void Awake()` — metadata method 32745, token 0x6000bf2
- `void SuperSlowUpdate()` — metadata method 32746, token 0x6000bf3
- `void Start()` — metadata method 32747, token 0x6000bf4
- `void Update()` — metadata method 32748, token 0x6000bf5
- `void RequestToOpenBuyMenu()` — metadata method 32749, token 0x6000bf6
- `void UpdateCheckBuy()` — metadata method 32750, token 0x6000bf7
- `System.Collections.IEnumerator SendAliveMessageRoutine()` — metadata method 32751, token 0x6000bf8
- `void HandleTimer()` — metadata method 32752, token 0x6000bf9
- `void StartRoundReasonRoundEnded()` — metadata method 32753, token 0x6000bfa
- `void StartRound(string reasonText, int giveExtraMoneyToAll)` — metadata method 32754, token 0x6000bfb
- `void StartActionPhase(string reason)` — metadata method 32755, token 0x6000bfc
- `void EndRoundByTimer(string timerReason)` — metadata method 32756, token 0x6000bfd
- `void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)` — metadata method 32757, token 0x6000bfe
- `void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)` — metadata method 32758, token 0x6000bff
- `void OnEvent(ExitGames.Client.Photon.EventData photonEvent)` — metadata method 32759, token 0x6000c00
- `int get_CurrentRound()` — metadata method 32760, token 0x6000c01
- `void SetGameState(string reasonForSet, GameState newState, object[] extraParams)` — metadata method 32761, token 0x6000c02
- `void OnStateChanged(int state, string reason, object[] extraParams)` — metadata method 32762, token 0x6000c03
- `void SetLastSelectedWeapons(int[] a)` — metadata method 32763, token 0x6000c04
- `UnityEngine.Transform GetSpawnPoint(Photon.Pun.UtilityScripts.PhotonTeam myTeam, bool justSwitchedTeam)` — metadata method 32764, token 0x6000c05
- `void TeleportMyPlayerToSpawnPoint(int planterId, Photon.Pun.UtilityScripts.PhotonTeam myKnownTeam, bool justSwitchedTeams)` — metadata method 32765, token 0x6000c06
- `void OnBombExploaded()` — metadata method 32766, token 0x6000c07
- `void OnPlayerDied(Photon.Pun.PhotonView pv)` — metadata method 32767, token 0x6000c08
- `int CountPlayerPhotonViews(Photon.Realtime.Player player)` — metadata method 32768, token 0x6000c09
- `TeamMember[] SlowFunctionGetTeamMembers(Photon.Pun.UtilityScripts.PhotonTeam team)` — metadata method 32769, token 0x6000c0a
- `void OnBombDefuseUpdate(bool isMine, float valueSoFar, float defuseTime)` — metadata method 32770, token 0x6000c0b
- `void OnBombDefused()` — metadata method 32771, token 0x6000c0c
- `void SetSaturation(bool isBuy, float inSeconds)` — metadata method 32772, token 0x6000c0d
- `void OnStopDefuse()` — metadata method 32773, token 0x6000c0e
- `void .ctor()` — metadata method 32774, token 0x6000c0f
- `void <ShowNotification>b__19_0()` — metadata method 32775, token 0x6000c10
- `void <Start>b__60_0()` — metadata method 32776, token 0x6000c11
- `void <Start>b__60_1()` — metadata method 32777, token 0x6000c12
- `void <OnPlayerEnteredRoom>b__75_0()` — metadata method 32778, token 0x6000c13
- `void <OnPlayerEnteredRoom>b__75_1()` — metadata method 32779, token 0x6000c14
- `void <OnPlayerLeftRoom>b__76_0()` — metadata method 32780, token 0x6000c15
- `void <OnPlayerLeftRoom>b__76_1()` — metadata method 32781, token 0x6000c16
- `void <OnStateChanged>b__88_0()` — metadata method 32782, token 0x6000c17
- `void <OnStateChanged>b__88_1()` — metadata method 32783, token 0x6000c18
- `void <OnStateChanged>b__88_2()` — metadata method 32784, token 0x6000c19

### HardpointManager

Parent: `UnityEngine.MonoBehaviour`. Type definition 4224.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| secondsPerObjective | int | 60 |
| captureGivesPoints | int | 5 |
| nextObjectiveTxt | TMPro.TMP_Text |  |

Declared methods:

- `void Init(HardpointArea[] hardpoints, int _matchTimeInSeconds, double _startTime)` — metadata method 31389, token 0x60006a6
- `void SlowUpdate()` — metadata method 31390, token 0x60006a7
- `void AddPointsToTeam(Photon.Pun.UtilityScripts.PhotonTeam team, int customAmount, bool isKourstrikeWinReport)` — metadata method 31391, token 0x60006a8
- `int GetCurrentActiveObjectiveIndex(int timerInSeconds)` — metadata method 31392, token 0x60006a9
- `void UpdateObjectiveTimerText(int timerInSeconds)` — metadata method 31393, token 0x60006aa
- `void .ctor()` — metadata method 31394, token 0x60006ab

### MapBuilder

Parent: `Photon.Pun.MonoBehaviourPunCallbacks`. Type definition 4299.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| spawnPoints | EditorSpawnPoint[] |  |
| KOUR_EDITOR_VERSION | string | "1.3" |
| kourEditorVersionTxt | TMPro.TMP_Text |  |
| gravityIF | UnityEngine.UI.InputField |  |
| groundLimitIF | UnityEngine.UI.InputField |  |
| airLimitIF | UnityEngine.UI.InputField |  |
| dashToggle | UnityEngine.UI.Toggle |  |
| loadingFullPanel | UnityEngine.GameObject |  |
| forceCharacterSkinTxt | TMPro.TMP_Text |  |
| settingsGameModeTxt | TMPro.TMP_Text |  |
| settingsGameNameTxt | UnityEngine.UI.InputField |  |
| overrideAllowedWeaponsTxt | TMPro.TMP_Text |  |
| notificationTxt | TMPro.TMP_Text |  |
| notificationRectTransform | UnityEngine.RectTransform |  |
| canvas | UnityEngine.RectTransform |  |
| splashScreen | UnityEngine.CanvasGroup |  |
| newObjectPanelTitle | TMPro.TMP_Text |  |
| previewCamera | UnityEngine.Camera |  |
| previewMeshFilter | UnityEngine.MeshFilter |  |
| renderTexture | UnityEngine.RenderTexture |  |
| inspectObjectPanel | InspectObjectPanel |  |
| hierarchyButtonPrefab | HierarchyButton |  |
| newObjectPanel | UnityEngine.GameObject |  |
| newMapObjectButtonPrefab | NewMapObjectButton |  |
| newMapObjectButtonsParent | UnityEngine.Transform |  |
| hierarchyButtonsParent | UnityEngine.Transform |  |
| availableMapObjectPrefabs | MapObjectPrefab[] |  |
| data | MapBuilderData |  |
| subSceneParent | UnityEngine.Transform |  |
| defaultIcons | UnityEngine.Sprite[] |  |

Declared methods:

- `void OnHierarchySearch(string searchString)` — metadata method 31784, token 0x6000831
- `System.Collections.IEnumerator IenuHierarchySearch(string searchString)` — metadata method 31785, token 0x6000832
- `void OpenURL(string url)` — metadata method 31786, token 0x6000833
- `void OnMapSettingsChanged()` — metadata method 31787, token 0x6000834
- `void UpdateDefaultCharacterSkinText()` — metadata method 31788, token 0x6000835
- `void UpdateGameModeText()` — metadata method 31789, token 0x6000836
- `void UpdateOverrideAllowedWeaponsText()` — metadata method 31790, token 0x6000837
- `void ChangeDefaultCharacterSkinButtonPressed()` — metadata method 31791, token 0x6000838
- `void ChangeGroundLimit(string input)` — metadata method 31792, token 0x6000839
- `void ChangAirLimit(string input)` — metadata method 31793, token 0x600083a
- `void SetAllowDashing(bool input)` — metadata method 31794, token 0x600083b
- `void ChangeGravity(string input)` — metadata method 31795, token 0x600083c
- `void ChangeGameModeButtonPressed()` — metadata method 31796, token 0x600083d
- `void OnSettingsInputFieldGameNameUpdate(string newGameName)` — metadata method 31797, token 0x600083e
- `void ChangeOverrideAllowedWeaponsButtonPressed()` — metadata method 31798, token 0x600083f
- `void Save()` — metadata method 31799, token 0x6000840
- `void Update()` — metadata method 31800, token 0x6000841
- `void Notify(string text)` — metadata method 31801, token 0x6000842
- `void OnConnectedToMaster()` — metadata method 31802, token 0x6000843
- `void PlaytestNowButtonPressed(bool offline)` — metadata method 31803, token 0x6000844
- `void PlaytestNow()` — metadata method 31804, token 0x6000845
- `void PublishButtonPressed()` — metadata method 31805, token 0x6000846
- `void ShowPublishPanel()` — metadata method 31806, token 0x6000847
- `UnityEngine.Sprite GetIconOf(MapObjectPrefab d)` — metadata method 31807, token 0x6000848
- `UnityEngine.Sprite Texture2DToSprite(UnityEngine.Texture2D texture)` — metadata method 31808, token 0x6000849
- `HierarchyButton GetValidHierarchyButton(int index)` — metadata method 31809, token 0x600084a
- `HierarchyButton GetHierarchyButtonOnIndex(int index)` — metadata method 31810, token 0x600084b
- `void InspectObject(UnityEngine.GameObject gameO, bool setActiveGameObject)` — metadata method 31811, token 0x600084c
- `void UpdateHierarchy(int autoInspectIndex)` — metadata method 31812, token 0x600084d
- `void InspectItem(int onIndex)` — metadata method 31813, token 0x600084e
- `void NewMapObjectTowardsMenuButtonPressed()` — metadata method 31814, token 0x600084f
- `void SelectObject(string title, M_1020[] from, System.Action<M_1020> then, bool allowNone)` — metadata method 31815, token 0x6000850
- `void NewMapObjectButtonPressed(MapObjectPrefab mapObjectPrefab)` — metadata method 31816, token 0x6000851
- `string SaveCurrentSubScene()` — metadata method 31817, token 0x6000852
- `void NewProject()` — metadata method 31818, token 0x6000853
- `void SaveMap()` — metadata method 31819, token 0x6000854
- `void OpenMap()` — metadata method 31820, token 0x6000855
- `void OnMapLoaded(string mapDataString)` — metadata method 31821, token 0x6000856
- `void Awake()` — metadata method 31822, token 0x6000857
- `void LoadMap(string mapDataString, MapBuilderData data, bool isKourEditor)` — metadata method 31823, token 0x6000858
- `void Start()` — metadata method 31824, token 0x6000859
- `UnityEngine.Vector3 StringToVector3(string s)` — metadata method 31825, token 0x600085a
- `void Exit()` — metadata method 31826, token 0x600085b
- `void .ctor()` — metadata method 31827, token 0x600085c
- `void <ChangeDefaultCharacterSkinButtonPressed>b__20_1(Item x)` — metadata method 31828, token 0x600085d
- `void <ChangeGameModeButtonPressed>b__25_0(GameMode selected)` — metadata method 31829, token 0x600085e
- `void <Notify>b__35_0()` — metadata method 31830, token 0x600085f
- `void <ShowPublishPanel>b__42_0(UnityEngine.GameObject prefab)` — metadata method 31831, token 0x6000860
- `void <Start>b__78_0()` — metadata method 31832, token 0x6000861
- `void <Start>b__78_1()` — metadata method 31833, token 0x6000862

### SettingsPanel

Parent: `Popup`. Type definition 4467.

Serialized field candidates and literal constants:

| Field | Type | Metadata constant |
|---|---|---|
| hideForCg | UnityEngine.GameObject[] |  |
| keybindSlotPrefab | UnityEngine.GameObject |  |
| keybindSlotContainer | UnityEngine.Transform |  |
| DEFAULT_MOUSE_ACCELERATION | int | 0 |
| DEFAULT_RENDER_SCALE_WEB | float | 0.8999999761581421 |
| DEFAULT_VIGNETTE | float | 0.6000000238418579 |
| DEFAULT_RENDER_DISTANCE | float | 270 |
| renderDistanceTxt | TMPro.TMP_Text |  |
| hudScaleSliderTxt | TMPro.TMP_Text |  |
| hudScaleSlider | UnityEngine.UI.Slider |  |
| vignetteSlider | UnityEngine.UI.Slider |  |
| vignetteTxt | TMPro.TMP_Text |  |
| renderDistanceSlider | UnityEngine.UI.Slider |  |
| disableTexturesToggle | UnityEngine.UI.Toggle |  |
| hideForMobile | UnityEngine.GameObject[] |  |
| crosshairLinkIF | UnityEngine.UI.InputField |  |
| sniperScopeLinkIF | UnityEngine.UI.InputField |  |
| sniperScopeSizeTxt | TMPro.TMP_Text |  |
| uidTxt | TMPro.TMP_Text |  |
| appTxt | TMPro.TMP_Text |  |
| devTxt | TMPro.TMP_Text |  |
| versionTxt | TMPro.TMP_Text |  |
| sdkTxt | TMPro.TMP_Text |  |
| photonVersionTxt | TMPro.TMP_Text |  |
| mouseSenseTxt | TMPro.TMP_Text |  |
| resolutionMustRefreshAlerts | UnityEngine.GameObject[] |  |
| resolutionSliderLayoutGroups | UnityEngine.UI.LayoutGroup[] |  |
| resolutionValueTxt | TMPro.TMP_Text |  |
| fovValueTxt | TMPro.TMP_Text |  |
| crosshairValueTxt | TMPro.TMP_Text |  |
| resolutionSlider | UnityEngine.UI.Slider |  |
| fovSlider | UnityEngine.UI.Slider |  |
| crosshairSlider | UnityEngine.UI.Slider |  |
| waitingForKeyPanel | UnityEngine.GameObject |  |
| qualityButtonBorders | UnityEngine.GameObject[] |  |
| keyTexts | TMPro.TMP_Text[] |  |
| volSlider | UnityEngine.UI.Slider |  |
| volSliderTxt | TMPro.TMP_Text |  |
| musicVolSlider | UnityEngine.UI.Slider |  |
| mouseFlickSlider | UnityEngine.UI.Slider |  |
| mouseFlickTxt | TMPro.TMP_Text |  |
| musicVolSliderTxt | TMPro.TMP_Text |  |
| regionDropdown | TMPro.TMP_Dropdown |  |
| senseSlider | UnityEngine.UI.Slider |  |
| devOptionsToggle | UnityEngine.UI.Toggle |  |
| mouseAccelerationToggle | UnityEngine.UI.Toggle |  |
| muzzleFlashToggle | UnityEngine.UI.Toggle |  |
| bulletHolesToggle | UnityEngine.UI.Toggle |  |
| motionBlurToggle | UnityEngine.UI.Toggle |  |
| renderWeaponToggle | UnityEngine.UI.Toggle |  |
| ragdollsToggle | UnityEngine.UI.Toggle |  |
| uiAnimationsToggle | UnityEngine.UI.Toggle |  |
| showRankPanelSoonToggle | UnityEngine.UI.Toggle |  |
| shadowsToggle | UnityEngine.UI.Toggle |  |
| ssccToggle | UnityEngine.UI.Toggle |  |
| inGameLeaderboardToggle | UnityEngine.UI.Toggle |  |
| sniperScaleSlider | UnityEngine.UI.Slider |  |

Declared methods:

- `void CreateKeybindSlots()` — metadata method 32853, token 0x6000c5e
- `float get_DEFAULT_MOUSE_FLICK_FIX()` — metadata method 32854, token 0x6000c5f
- `float get_DefaultVolume()` — metadata method 32855, token 0x6000c60
- `void Show()` — metadata method 32856, token 0x6000c61
- `void Close(System.Action onfinish)` — metadata method 32857, token 0x6000c62
- `void ResetAll()` — metadata method 32858, token 0x6000c63
- `void OnResolutionSliderChanged(float newRes)` — metadata method 32859, token 0x6000c64
- `void OnFOVChanged(float _newFov)` — metadata method 32860, token 0x6000c65
- `void OnEnable()` — metadata method 32861, token 0x6000c66
- `void OnCrosshairScaleChanged(float newCrosshairScale)` — metadata method 32862, token 0x6000c67
- `System.Collections.IEnumerator IenuSetResolutionScale(float x)` — metadata method 32863, token 0x6000c68
- `void UpdateLayoutGroup(UnityEngine.UI.LayoutGroup which)` — metadata method 32864, token 0x6000c69
- `System.Collections.IEnumerator IenuUpdateLayoutGroup(UnityEngine.UI.LayoutGroup which)` — metadata method 32865, token 0x6000c6a
- `bool TryGetInstance(out SettingsPanel _instance)` — metadata method 32866, token 0x6000c6b
- `void OnConnected(string currentRegionToken)` — metadata method 32867, token 0x6000c6c
- `System.Collections.IEnumerator IenuSetRegionTextAgain(string txt)` — metadata method 32868, token 0x6000c6d
- `int RegionTokenToIndex(string token)` — metadata method 32869, token 0x6000c6e
- `string RegionIndexToToken(int i)` — metadata method 32870, token 0x6000c6f
- `string RegionTokenToReadable(string token)` — metadata method 32871, token 0x6000c70
- `string RegionReadableToToken(string readable)` — metadata method 32872, token 0x6000c71
- `void Start()` — metadata method 32873, token 0x6000c72
- `void UpdateSettingsUI()` — metadata method 32874, token 0x6000c73
- `void SetRegion(int v)` — metadata method 32875, token 0x6000c74
- `void ChangeKeyBinding(int actionIndex)` — metadata method 32876, token 0x6000c75
- `void ResetKeybinds()` — metadata method 32877, token 0x6000c76
- `void OnHUDChanged(float v)` — metadata method 32878, token 0x6000c77
- `void SetHUDScale(float v)` — metadata method 32879, token 0x6000c78
- `void SetVignette(float v)` — metadata method 32880, token 0x6000c79
- `void SetHUDScale(UnityEngine.UI.Slider s)` — metadata method 32881, token 0x6000c7a
- `void SetMasterVoume(float v)` — metadata method 32882, token 0x6000c7b
- `void SetRenderDistance(float v)` — metadata method 32883, token 0x6000c7c
- `void SetMusicVolume(float v)` — metadata method 32884, token 0x6000c7d
- `void SetMouseFlick(float v)` — metadata method 32885, token 0x6000c7e
- `void SetScopeScale(float v)` — metadata method 32886, token 0x6000c7f
- `void SetCustomCrosshairLink(string x)` — metadata method 32887, token 0x6000c80
- `void SetSniperScopeLink(string x)` — metadata method 32888, token 0x6000c81
- `void SetSense(float v)` — metadata method 32889, token 0x6000c82
- `void SetDeveloperOptions(bool v)` — metadata method 32890, token 0x6000c83
- `void SetMouseAcceleration(bool v)` — metadata method 32891, token 0x6000c84
- `void SetMuzzleFlash(bool v)` — metadata method 32892, token 0x6000c85
- `void SetShadows(bool v)` — metadata method 32893, token 0x6000c86
- `void SetBulletHoles(bool v)` — metadata method 32894, token 0x6000c87
- `void SetRagdolls(bool v)` — metadata method 32895, token 0x6000c88
- `void SetInGameLeaderboard(bool v)` — metadata method 32896, token 0x6000c89
- `void SetUIAnimations(bool v)` — metadata method 32897, token 0x6000c8a
- `void SetShowRankProgressSoon(bool v)` — metadata method 32898, token 0x6000c8b
- `void SetSSCC(bool v)` — metadata method 32899, token 0x6000c8c
- `void OnSettingsChanged()` — metadata method 32900, token 0x6000c8d
- `void SetMotionBlur(bool v)` — metadata method 32901, token 0x6000c8e
- `void StaticRenderWeapon(bool v, string p)` — metadata method 32902, token 0x6000c8f
- `void SetRenderWeapon(bool v)` — metadata method 32903, token 0x6000c90
- `void SetQuality(int q)` — metadata method 32904, token 0x6000c91
- `void ForceSetQuality(int q)` — metadata method 32905, token 0x6000c92
- `void SetDisableTextures(bool disableTextures)` — metadata method 32906, token 0x6000c93
- `void SetVeryLowGraphicsMode()` — metadata method 32907, token 0x6000c94
- `System.Collections.IEnumerator IenuRefreshIn(float t)` — metadata method 32908, token 0x6000c95
- `void EnterKourEditor()` — metadata method 32909, token 0x6000c96
- `void .ctor()` — metadata method 32910, token 0x6000c97
- `void .cctor()` — metadata method 32911, token 0x6000c98
- `void <ResetKeybinds>b__86_0()` — metadata method 32912, token 0x6000c99
- `void <SetDisableTextures>b__115_3()` — metadata method 32913, token 0x6000c9a
- `void <SetVeryLowGraphicsMode>b__116_0()` — metadata method 32914, token 0x6000c9b
- `void <SetVeryLowGraphicsMode>b__116_1()` — metadata method 32915, token 0x6000c9c

## Network structure

Static room-property constants in NetworkManager: C0 game mode, C1 map, C2 match time, C3 custom map ID, C4 in-room custom map ID. This is a metadata-level association through field names and constant values; packet encoding and live room behavior were not observed.

See protocol/photon-rpc-catalog.json for all [PunRPC] declarations and protocol/static-endpoints.json for URL candidates. No recorded URL was fetched.

## Remaining uncertainty

A recoverable field declaration or method name is not a recovered implementation. Serialized values can differ from constructor defaults. Obfuscated/compiler-generated names remain as shipped. Original editor folder names, comments, source filenames, timelines and server-side implementation are not restored.