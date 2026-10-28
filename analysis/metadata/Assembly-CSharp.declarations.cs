// Recovered declarations, NOT original C# source. Method bodies are deliberately omitted.
// Names: REA ev_effaaa217c77804598ae99af2a44e70d65dbbc3f089e7b1f838f7d9c14711f3e; signatures: static WASM Il2CppType table.
// Runtime offsets refer to 32-bit IL2CPP memory, not serialized asset offsets.
// Generic parameter names are placeholders; constructors and compiler-generated names may not compile.

// TypeDefinition 3921, 0x2000001
class <Module> : TypeIndex_-1 {
}

// TypeDefinition 3922, 0x2000002
class <>f__AnonymousType0`2 : object {
    // field 15928, runtime offset 0, flags 0x21
    private T_1017 <Room>i__Field;
    // field 15929, runtime offset 0, flags 0x21
    private T_1018 <Score>i__Field;
    // method 29688, 0x6000001
    T_1017 get_Room();
    // method 29689, 0x6000002
    T_1018 get_Score();
    // method 29690, 0x6000003
    void .ctor(T_1017 Room, T_1018 Score);
    // method 29691, 0x6000004
    bool Equals(object value);
    // method 29692, 0x6000005
    int GetHashCode();
    // method 29693, 0x6000006
    string ToString();
}

// TypeDefinition 3923, 0x2000004
class groundCheck : System.Enum {
    // field 15962, runtime offset 8, flags 0x606
    public int value__;
    // field 15963, runtime offset 0, flags 0x8056
    public static const groundCheck rayCast = 0;
    // field 15964, runtime offset 0, flags 0x8056
    public static const groundCheck sphereCaste = 1;
}

// TypeDefinition 3924, 0x2000005
class MovementMode : System.Enum {
    // field 15965, runtime offset 8, flags 0x606
    public int value__;
    // field 15966, runtime offset 0, flags 0x8056
    public static const MovementMode Velocity = 0;
    // field 15967, runtime offset 0, flags 0x8056
    public static const MovementMode AngularVelocity = 1;
}

// TypeDefinition 3925, 0x2000003
class ArcadeVehicleController : UnityEngine.MonoBehaviour {
    // field 15930, runtime offset 16, flags 0x6
    public ATVInput atvInput;
    // field 15931, runtime offset 20, flags 0x6
    public MovementMode movementMode;
    // field 15932, runtime offset 24, flags 0x6
    public groundCheck GroundCheck;
    // field 15933, runtime offset 28, flags 0x6
    public UnityEngine.LayerMask drivableSurface;
    // field 15934, runtime offset 32, flags 0x6
    public float MaxSpeed;
    // field 15935, runtime offset 36, flags 0x6
    public float accelaration;
    // field 15936, runtime offset 40, flags 0x6
    public float turn;
    // field 15937, runtime offset 44, flags 0x6
    public float gravity;
    // field 15938, runtime offset 48, flags 0x6
    public float downforce;
    // field 15939, runtime offset 52, flags 0x6
    public bool AirControl;
    // field 15940, runtime offset 53, flags 0x6
    public bool kartLike;
    // field 15941, runtime offset 56, flags 0x6
    public float driftMultiplier;
    // field 15942, runtime offset 60, flags 0x6
    public UnityEngine.Rigidbody rb;
    // field 15943, runtime offset 64, flags 0x6
    public UnityEngine.Rigidbody carBody;
    // field 15944, runtime offset 68, flags 0x6
    public UnityEngine.RaycastHit hit;
    // field 15945, runtime offset 112, flags 0x6
    public UnityEngine.AnimationCurve frictionCurve;
    // field 15946, runtime offset 116, flags 0x6
    public UnityEngine.AnimationCurve turnCurve;
    // field 15947, runtime offset 120, flags 0x6
    public UnityEngine.PhysicsMaterial frictionMaterial;
    // field 15948, runtime offset 124, flags 0x6
    public UnityEngine.Transform BodyMesh;
    // field 15949, runtime offset 128, flags 0x6
    public UnityEngine.Transform[] FrontWheels;
    // field 15950, runtime offset 132, flags 0x6
    public UnityEngine.Transform[] RearWheels;
    // field 15951, runtime offset 136, flags 0x6
    public UnityEngine.Vector3 carVelocity;
    // field 15952, runtime offset 148, flags 0x6
    public float BodyTilt;
    // field 15953, runtime offset 152, flags 0x6
    public UnityEngine.AudioSource engineSound;
    // field 15954, runtime offset 156, flags 0x6
    public float minPitch;
    // field 15955, runtime offset 160, flags 0x6
    public float MaxPitch;
    // field 15956, runtime offset 164, flags 0x6
    public UnityEngine.AudioSource SkidSound;
    // field 15957, runtime offset 168, flags 0x6
    public float skidWidth;
    // field 15958, runtime offset 172, flags 0x1
    private float radius;
    // field 15959, runtime offset 176, flags 0x1
    private float horizontalInput;
    // field 15960, runtime offset 180, flags 0x1
    private float verticalInput;
    // field 15961, runtime offset 184, flags 0x1
    private UnityEngine.Vector3 origin;
    // method 29694, 0x6000007
    void Start();
    // method 29695, 0x6000008
    void Update();
    // method 29696, 0x6000009
    void AudioManager();
    // method 29697, 0x600000a
    void FixedUpdate();
    // method 29698, 0x600000b
    void Visuals();
    // method 29699, 0x600000c
    bool grounded();
    // method 29700, 0x600000d
    void OnDrawGizmos();
    // method 29701, 0x600000e
    void .ctor();
}

// TypeDefinition 3926, 0x2000006
class FreeCam : UnityEngine.MonoBehaviour {
    // field 15968, runtime offset 16, flags 0x6
    public float movementSpeed;
    // field 15969, runtime offset 20, flags 0x6
    public float fastMovementSpeed;
    // field 15970, runtime offset 24, flags 0x6
    public float freeLookSensitivity;
    // field 15971, runtime offset 28, flags 0x6
    public float zoomSensitivity;
    // field 15972, runtime offset 32, flags 0x6
    public float fastZoomSensitivity;
    // field 15973, runtime offset 36, flags 0x1
    private bool looking;
    // method 29702, 0x600000f
    void Update();
    // method 29703, 0x6000010
    void OnDisable();
    // method 29704, 0x6000011
    void StartLooking();
    // method 29705, 0x6000012
    void StopLooking();
    // method 29706, 0x6000013
    void .ctor();
}

// TypeDefinition 3927, 0x2000007
class FreeCamera : UnityEngine.MonoBehaviour {
    // field 15974, runtime offset 16, flags 0x6
    public bool enableInputCapture;
    // field 15975, runtime offset 17, flags 0x6
    public bool holdRightMouseCapture;
    // field 15976, runtime offset 20, flags 0x6
    public float lookSpeed;
    // field 15977, runtime offset 24, flags 0x6
    public float moveSpeed;
    // field 15978, runtime offset 28, flags 0x6
    public float sprintSpeed;
    // field 15979, runtime offset 32, flags 0x1
    private bool m_inputCaptured;
    // field 15980, runtime offset 36, flags 0x1
    private float m_yaw;
    // field 15981, runtime offset 40, flags 0x1
    private float m_pitch;
    // method 29707, 0x6000014
    void Awake();
    // method 29708, 0x6000015
    void OnValidate();
    // method 29709, 0x6000016
    void CaptureInput();
    // method 29710, 0x6000017
    void ReleaseInput();
    // method 29711, 0x6000018
    void OnApplicationFocus(bool focus);
    // method 29712, 0x6000019
    void Update();
    // method 29713, 0x600001a
    void .ctor();
}

// TypeDefinition 3928, 0x2000008
class SuperCamera : UnityEngine.MonoBehaviour {
    // field 15982, runtime offset 16, flags 0x6
    public UnityEngine.GameObject pivot;
    // field 15983, runtime offset 20, flags 0x6
    public UnityEngine.KeyCode resetShortcut;
    // field 15984, runtime offset 24, flags 0x6
    public float rotationSensibility;
    // field 15985, runtime offset 28, flags 0x6
    public bool invertRotationX;
    // field 15986, runtime offset 29, flags 0x6
    public bool invertRotationY;
    // field 15987, runtime offset 32, flags 0x6
    public float translationSensibility;
    // field 15988, runtime offset 36, flags 0x6
    public bool invertTranslationX;
    // field 15989, runtime offset 37, flags 0x6
    public bool invertTranslationY;
    // field 15990, runtime offset 40, flags 0x6
    public float zoomMax;
    // field 15991, runtime offset 44, flags 0x6
    public float zoomMin;
    // field 15992, runtime offset 48, flags 0x6
    public float wheelSensibility;
    // field 15993, runtime offset 52, flags 0x1
    private float delayDoubleClic;
    // field 15994, runtime offset 56, flags 0x1
    private UnityEngine.Vector3 oldCamPos;
    // field 15995, runtime offset 68, flags 0x1
    private UnityEngine.Quaternion oldCamRot;
    // field 15996, runtime offset 84, flags 0x1
    private UnityEngine.Vector3 oldMousePos;
    // field 15997, runtime offset 96, flags 0x1
    private float timeDoubleClic;
    // field 15998, runtime offset 100, flags 0x1
    private bool firstClic;
    // field 15999, runtime offset 104, flags 0x1
    private UnityEngine.Vector3 pivotPos;
    // method 29714, 0x600001b
    void Start();
    // method 29715, 0x600001c
    void Update();
    // method 29716, 0x600001d
    void .ctor();
}

// TypeDefinition 3929, 0x2000009
class UIButton_ShowNext : UnityEngine.MonoBehaviour {
    // field 16000, runtime offset 16, flags 0x6
    public UnityEngine.GameObject[] GameObjectsList;
    // field 16001, runtime offset 20, flags 0x1
    private int shownGameObjectIndex;
    // method 29717, 0x600001e
    void Start();
    // method 29718, 0x600001f
    void SelectNextGameObject();
    // method 29719, 0x6000020
    void SelectPreviousGameObject();
    // method 29720, 0x6000021
    void SelectGameObject(int index);
    // method 29721, 0x6000022
    void .ctor();
}

// TypeDefinition 3930, 0x200000a
class RestartSceneTrigger : UnityEngine.MonoBehaviour {
    // method 29722, 0x6000023
    void OnTriggerEnter(UnityEngine.Collider other);
    // method 29723, 0x6000024
    void .ctor();
}

// TypeDefinition 3931, 0x200000b
class Speedometer : UnityEngine.MonoBehaviour {
    // field 16002, runtime offset 16, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 16003, runtime offset 20, flags 0x1
    private TMPro.TMP_Text text;
    // field 16004, runtime offset 24, flags 0x1
    private bool devOptionsEnabled;
    // method 29724, 0x6000025
    void Start();
    // method 29725, 0x6000026
    void LateUpdate();
    // method 29726, 0x6000027
    void .ctor();
}

// TypeDefinition 3932, 0x200000d
class <>c : object {
    // field 16084, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16085, runtime offset 4, flags 0x16
    public static System.Func<bool> <>9__69_0;
    // field 16086, runtime offset 8, flags 0x16
    public static System.Func<Shooter, UnityEngine.Transform> <>9__119_0;
    // method 29773, 0x6000056
    void .cctor();
    // method 29774, 0x6000057
    void .ctor();
    // method 29775, 0x6000058
    bool <IenuWaitForMapSettings>b__69_0();
    // method 29776, 0x6000059
    UnityEngine.Transform <GetVisiblePlayers>b__119_0(Shooter obj);
}

// TypeDefinition 3933, 0x200000e
class <IenuWaitForMapSettings>d__69 : object {
    // field 16087, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16088, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16089, runtime offset 16, flags 0x6
    public PlayerController <>4__this;
    // method 29777, 0x600005a
    void .ctor(int <>1__state);
    // method 29778, 0x600005b
    void System.IDisposable.Dispose();
    // method 29779, 0x600005c
    bool MoveNext();
    // method 29780, 0x600005d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 29781, 0x600005e
    void System.Collections.IEnumerator.Reset();
    // method 29782, 0x600005f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 3934, 0x200000f
class <JumpTimer>d__117 : object {
    // field 16090, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16091, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16092, runtime offset 16, flags 0x6
    public PlayerController <>4__this;
    // method 29783, 0x6000060
    void .ctor(int <>1__state);
    // method 29784, 0x6000061
    void System.IDisposable.Dispose();
    // method 29785, 0x6000062
    bool MoveNext();
    // method 29786, 0x6000063
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 29787, 0x6000064
    void System.Collections.IEnumerator.Reset();
    // method 29788, 0x6000065
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 3935, 0x200000c
class PlayerController : Photon.Pun.MonoBehaviourPun {
    // field 16005, runtime offset 20, flags 0x1
    private UnityEngine.GameObject[] disableForParkour;
    // field 16006, runtime offset 24, flags 0x1
    private UnityEngine.RectTransform dashFill;
    // field 16007, runtime offset 28, flags 0x1
    private int currentGameModeId;
    // field 16008, runtime offset 32, flags 0x1
    private ParticleSystemExtension fastPS;
    // field 16009, runtime offset 36, flags 0x1
    private bool doubleJumped;
    // field 16010, runtime offset 40, flags 0x1
    private float ladderExitTime;
    // field 16011, runtime offset 0, flags 0x8051
    private static const float ladderClimbSpeed = 6.199999809265137;
    // field 16012, runtime offset 44, flags 0x1
    private bool lastFrameOnLadder;
    // field 16013, runtime offset 48, flags 0x1
    private UnityEngine.Transform currentLadder;
    // field 16014, runtime offset 52, flags 0x1
    private UnityEngine.GameObject umbrellaGfx;
    // field 16015, runtime offset 0, flags 0x8051
    private static const float maxYVelocityFalling = -18;
    // field 16016, runtime offset 56, flags 0x1
    private UnityEngine.Transform umbrellaRotator;
    // field 16017, runtime offset 60, flags 0x1
    private UnityEngine.CapsuleCollider myCollider;
    // field 16018, runtime offset 0, flags 0x8051
    private static const float aimAssistIntensityPhone = 0.4000000059604645;
    // field 16019, runtime offset 0, flags 0x8051
    private static const float minAngleForAutoShootPhone = 3.5;
    // field 16020, runtime offset 0, flags 0x8051
    private static const float minAngleForAimAssistPhone = 6.5;
    // field 16021, runtime offset 0, flags 0x8051
    private static const float aimAssistIntensityLaptop = 0.03999999910593033;
    // field 16022, runtime offset 0, flags 0x8051
    private static const float minAngleForAutoShootLaptop = 0.8999999761581421;
    // field 16023, runtime offset 0, flags 0x8051
    private static const float minAngleForAimAssistLaptop = 2;
    // field 16024, runtime offset 0, flags 0x8051
    private static const float PLAYER_HEIGHT = 2.049999952316284;
    // field 16025, runtime offset 64, flags 0x6
    public ScreenSpaceCavityCurvature.SSCC[] SSCCs;
    // field 16026, runtime offset 68, flags 0x1
    private TeamMember teamMember;
    // field 16027, runtime offset 72, flags 0x1
    private CharacterAnimatorManager characterAnimatorManager;
    // field 16028, runtime offset 76, flags 0x1
    private Shooter shooter;
    // field 16029, runtime offset 80, flags 0x1
    private UnityEngine.LayerMask obstacleMask;
    // field 16030, runtime offset 84, flags 0x1
    private Recoil recoil;
    // field 16031, runtime offset 88, flags 0x1
    private CrosshairReticle crosshair;
    // field 16032, runtime offset 92, flags 0x1
    private PlayerInputHandler playerInput;
    // field 16033, runtime offset 96, flags 0x1
    private UnityEngine.Transform playerCameraParent;
    // field 16034, runtime offset 100, flags 0x1
    private UnityEngine.Camera playerCamera;
    // field 16035, runtime offset 104, flags 0x1
    private float mouseSensitivity;
    // field 16036, runtime offset 108, flags 0x1
    private float groundAcceleration;
    // field 16037, runtime offset 112, flags 0x1
    private float airAcceleration;
    // field 16038, runtime offset 116, flags 0x1
    private float airFriction;
    // field 16039, runtime offset 120, flags 0x1
    private float groundLimit;
    // field 16040, runtime offset 124, flags 0x1
    private float crouchGroundLimit;
    // field 16041, runtime offset 128, flags 0x1
    private float initialGroundLimit;
    // field 16042, runtime offset 132, flags 0x1
    private float airLimit;
    // field 16043, runtime offset 136, flags 0x1
    private float initialAirLimit;
    // field 16044, runtime offset 140, flags 0x1
    private float initialAirAcceleration;
    // field 16045, runtime offset 144, flags 0x1
    private float senseMulti;
    // field 16046, runtime offset 148, flags 0x1
    private float gravity;
    // field 16047, runtime offset 152, flags 0x1
    private float friction;
    // field 16048, runtime offset 156, flags 0x1
    private float jumpHeight;
    // field 16049, runtime offset 160, flags 0x1
    private float rampSlideLimit;
    // field 16050, runtime offset 164, flags 0x1
    private float slopeLimit;
    // field 16051, runtime offset 168, flags 0x1
    private bool additiveJump;
    // field 16052, runtime offset 169, flags 0x1
    private bool autoJump;
    // field 16053, runtime offset 170, flags 0x1
    private bool clampGroundSpeed;
    // field 16054, runtime offset 171, flags 0x1
    private bool isKourStrike;
    // field 16055, runtime offset 172, flags 0x1
    private bool isParKour;
    // field 16056, runtime offset 173, flags 0x1
    private bool isBR;
    // field 16057, runtime offset 176, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 16058, runtime offset 180, flags 0x6
    public UnityEngine.Vector3 vel;
    // field 16059, runtime offset 192, flags 0x1
    private UnityEngine.Vector3 inputDir;
    // field 16060, runtime offset 204, flags 0x1
    private UnityEngine.Vector3 _inputRot;
    // field 16061, runtime offset 216, flags 0x1
    private UnityEngine.Vector3 groundNormal;
    // field 16062, runtime offset 228, flags 0x6
    public bool onGround;
    // field 16063, runtime offset 229, flags 0x1
    private bool jumpPending;
    // field 16064, runtime offset 230, flags 0x1
    private bool ableToJump;
    // field 16065, runtime offset 232, flags 0x6
    public float currentInstability;
    // field 16066, runtime offset 236, flags 0x1
    private bool devOptionsEnabled;
    // field 16067, runtime offset 237, flags 0x1
    private bool canDash;
    // field 16068, runtime offset 240, flags 0x1
    private float dashMana;
    // field 16069, runtime offset 244, flags 0x1
    private UnityEngine.Vector3 lerpedUmbrellaVel;
    // field 16070, runtime offset 256, flags 0x1
    private bool openedUmbrella;
    // field 16071, runtime offset 260, flags 0x6
    public float landedBrTime;
    // field 16072, runtime offset 264, flags 0x1
    private JumpPad lastJumpPad;
    // field 16073, runtime offset 268, flags 0x1
    private bool crouching_input;
    // field 16074, runtime offset 269, flags 0x1
    private bool last_crouching_input;
    // field 16075, runtime offset 270, flags 0x1
    private bool last_aiming_input;
    // field 16076, runtime offset 272, flags 0x1
    private UnityEngine.Vector2 movement;
    // field 16077, runtime offset 280, flags 0x1
    private float resolutionScaleWebLookMulti;
    // field 16078, runtime offset 0, flags 0x16
    public static bool aimAssistInAction;
    // field 16079, runtime offset 284, flags 0x1
    private bool bypassMouseLook;
    // field 16080, runtime offset 288, flags 0x1
    private float lastJumpTime;
    // field 16081, runtime offset 292, flags 0x1
    private int insideMolotovZone;
    // field 16082, runtime offset 296, flags 0x6
    public bool dealZoneDamage;
    // field 16083, runtime offset 4, flags 0x16
    public static System.Collections.Generic.HashSet<Shooter> shooters;
    // method 29727, 0x6000028
    void ResetMomentum(bool resetRotation);
    // method 29728, 0x6000029
    void ResetJumps();
    // method 29729, 0x600002a
    UnityEngine.Vector3 get_InputRot();
    // method 29730, 0x600002b
    void Awake();
    // method 29731, 0x600002c
    System.Collections.IEnumerator IenuWaitForMapSettings();
    // method 29732, 0x600002d
    void Start();
    // method 29733, 0x600002e
    void SetYVelNormal(float normal);
    // method 29734, 0x600002f
    void MolotovUpdate();
    // method 29735, 0x6000030
    void ZoneUpdate();
    // method 29736, 0x6000031
    void SlowUpdate();
    // method 29737, 0x6000032
    void OnSettingsChanged();
    // method 29738, 0x6000033
    void SetSpeedMultis(float ground, float air);
    // method 29739, 0x6000034
    bool get_landedBr();
    // method 29740, 0x6000035
    void Update();
    // method 29741, 0x6000036
    void Dash(UnityEngine.Vector3 direction);
    // method 29742, 0x6000037
    void UpdateCrosshair();
    // method 29743, 0x6000038
    void RPCBRLand();
    // method 29744, 0x6000039
    void FixedUpdate();
    // method 29745, 0x600003a
    void GetMovementInput();
    // method 29746, 0x600003b
    void MouseLook();
    // method 29747, 0x600003c
    void GatherAimAssist(float autoShootAngle, float aimAssistAngle, float aimAssistIntensity, out float aimAssistX, out float aimAssistY);
    // method 29748, 0x600003d
    void GroundAccelerate();
    // method 29749, 0x600003e
    float NormalizeAngle(float angle);
    // method 29750, 0x600003f
    void AirAccelerate();
    // method 29751, 0x6000040
    void ApplyFriction();
    // method 29752, 0x6000041
    void ApplyAirFriction();
    // method 29753, 0x6000042
    void Jump(bool force);
    // method 29754, 0x6000043
    void ApplyGravity();
    // method 29755, 0x6000044
    void OnCollisionEnter(UnityEngine.Collision collision);
    // method 29756, 0x6000045
    void OnCollisionStay(UnityEngine.Collision other);
    // method 29757, 0x6000046
    void ResetParams();
    // method 29758, 0x6000047
    void OnMolotovEnded(string mollyName);
    // method 29759, 0x6000048
    void ForceQuitMolotov();
    // method 29760, 0x6000049
    void OnTriggerEnter(UnityEngine.Collider other);
    // method 29761, 0x600004a
    void OnTriggerExit(UnityEngine.Collider other);
    // method 29762, 0x600004b
    void JumpOnPad();
    // method 29763, 0x600004c
    float CalculateVerticalVelocity(float targetHeight);
    // method 29764, 0x600004d
    System.Collections.IEnumerator JumpTimer();
    // method 29765, 0x600004e
    UnityEngine.Transform GetClosestPlayer(UnityEngine.Transform[] players, out float distanceToPlayer);
    // method 29766, 0x600004f
    UnityEngine.Transform[] GetVisiblePlayers(float aimAssistAngle);
    // method 29767, 0x6000050
    void ImpactForce(UnityEngine.Vector3 vector3);
    // method 29768, 0x6000051
    void RegisterShooter(Shooter shooter);
    // method 29769, 0x6000052
    void UnregisterShooter(Shooter shooter);
    // method 29770, 0x6000053
    void SetMyVehicle(ATV aTV);
    // method 29771, 0x6000054
    void .ctor();
    // method 29772, 0x6000055
    void .cctor();
}

// TypeDefinition 3936, 0x2000010
class SmoothPlayerCamera : UnityEngine.MonoBehaviour {
    // field 16093, runtime offset 16, flags 0x1
    private float height;
    // field 16094, runtime offset 20, flags 0x1
    private float moveSpeed;
    // field 16095, runtime offset 24, flags 0x1
    private float distanceLimit;
    // field 16096, runtime offset 28, flags 0x1
    private PlayerController controller;
    // method 29789, 0x6000066
    void Start();
    // method 29790, 0x6000067
    void Update();
    // method 29791, 0x6000068
    void .ctor();
}

// TypeDefinition 3937, 0x2000012
class CrosshairStyle : System.Enum {
    // field 16111, runtime offset 8, flags 0x606
    public int value__;
    // field 16112, runtime offset 0, flags 0x8056
    public static const CrosshairStyle Regular = 0;
    // field 16113, runtime offset 0, flags 0x8056
    public static const CrosshairStyle Shotgun = 1;
    // field 16114, runtime offset 0, flags 0x8056
    public static const CrosshairStyle Circular = 2;
    // field 16115, runtime offset 0, flags 0x8056
    public static const CrosshairStyle Hidden = 3;
    // field 16116, runtime offset 0, flags 0x8056
    public static const CrosshairStyle Rocket = 4;
}

// TypeDefinition 3938, 0x2000013
class <DownloadImage>d__21 : object {
    // field 16117, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16118, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16119, runtime offset 16, flags 0x6
    public string imageUrl;
    // field 16120, runtime offset 20, flags 0x6
    public CrosshairReticle <>4__this;
    // field 16121, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 29800, 0x6000071
    void .ctor(int <>1__state);
    // method 29801, 0x6000072
    void System.IDisposable.Dispose();
    // method 29802, 0x6000073
    bool MoveNext();
    // method 29803, 0x6000074
    void <>m__Finally1();
    // method 29804, 0x6000075
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 29805, 0x6000076
    void System.Collections.IEnumerator.Reset();
    // method 29806, 0x6000077
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 3939, 0x2000011
class CrosshairReticle : UnityEngine.MonoBehaviour {
    // field 16097, runtime offset 16, flags 0x1
    private UnityEngine.RectTransform reticle;
    // field 16098, runtime offset 20, flags 0x1
    private UnityEngine.GameObject regularCrosshair;
    // field 16099, runtime offset 24, flags 0x1
    private UnityEngine.UI.RawImage rawImage;
    // field 16100, runtime offset 28, flags 0x1
    private UnityEngine.GameObject[] regularImages;
    // field 16101, runtime offset 32, flags 0x1
    private UnityEngine.GameObject[] shotgunImages;
    // field 16102, runtime offset 36, flags 0x1
    private UnityEngine.GameObject circularImage;
    // field 16103, runtime offset 40, flags 0x1
    private UnityEngine.GameObject rocketImage;
    // field 16104, runtime offset 44, flags 0x1
    private UnityEngine.UI.Image[] sprites;
    // field 16105, runtime offset 48, flags 0x6
    public float size;
    // field 16106, runtime offset 52, flags 0x6
    public int width;
    // field 16107, runtime offset 56, flags 0x6
    public int height;
    // field 16108, runtime offset 60, flags 0x6
    public bool centerPoint;
    // field 16109, runtime offset 64, flags 0x6
    public int centerPointWidth;
    // field 16110, runtime offset 68, flags 0x6
    public UnityEngine.Color color;
    // method 29792, 0x6000069
    void SetCrosshairStyle(CrosshairStyle style);
    // method 29793, 0x600006a
    void Start();
    // method 29794, 0x600006b
    void OnEnable();
    // method 29795, 0x600006c
    void Update();
    // method 29796, 0x600006d
    void OnCrosshairLink(string link);
    // method 29797, 0x600006e
    void SetImageTexture(string imageUrl);
    // method 29798, 0x600006f
    System.Collections.IEnumerator DownloadImage(string imageUrl);
    // method 29799, 0x6000070
    void .ctor();
}

// TypeDefinition 3940, 0x2000014
class DestroyerBoundary : UnityEngine.MonoBehaviour {
    // method 29807, 0x6000078
    void OnTriggerEnter(UnityEngine.Collider other);
    // method 29808, 0x6000079
    void .ctor();
}

// TypeDefinition 3941, 0x2000015
class basic_object : UnityEngine.MonoBehaviour {
    // method 29809, 0x600007a
    void OnSpawned();
    // method 29810, 0x600007b
    void OnDespawned();
    // method 29811, 0x600007c
    void .ctor();
}

// TypeDefinition 3942, 0x2000016
class test_recycleInstances : UnityEngine.MonoBehaviour {
    // field 16122, runtime offset 16, flags 0x6
    public UnityEngine.Transform prefab;
    // method 29812, 0x600007d
    void OnGUI();
    // method 29813, 0x600007e
    void .ctor();
}

// TypeDefinition 3943, 0x2000018
class <Decay>d__1 : object {
    // field 16123, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16124, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16125, runtime offset 16, flags 0x6
    public ObjBehaviour <>4__this;
    // method 29817, 0x6000082
    void .ctor(int <>1__state);
    // method 29818, 0x6000083
    void System.IDisposable.Dispose();
    // method 29819, 0x6000084
    bool MoveNext();
    // method 29820, 0x6000085
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 29821, 0x6000086
    void System.Collections.IEnumerator.Reset();
    // method 29822, 0x6000087
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 3944, 0x2000017
class ObjBehaviour : UnityEngine.MonoBehaviour {
    // method 29814, 0x600007f
    void OnSpawned();
    // method 29815, 0x6000080
    System.Collections.IEnumerator Decay();
    // method 29816, 0x6000081
    void .ctor();
}

// TypeDefinition 3945, 0x2000019
class test_sandbox : UnityEngine.MonoBehaviour {
    // field 16126, runtime offset 16, flags 0x6
    public UnityEngine.Transform[] prefabs;
    // method 29823, 0x6000088
    void OnGUI();
    // method 29824, 0x6000089
    void .ctor();
}

// TypeDefinition 3946, 0x200001a
class test_smartDespawnCull : UnityEngine.MonoBehaviour {
    // field 16127, runtime offset 16, flags 0x6
    public UnityEngine.Transform prefab;
    // method 29825, 0x600008a
    void Start();
    // method 29826, 0x600008b
    void OnGUI();
    // method 29827, 0x600008c
    void Auto();
    // method 29828, 0x600008d
    void .ctor();
}

// TypeDefinition 3947, 0x200001b
class FCP_ExampleScript : UnityEngine.MonoBehaviour {
    // field 16128, runtime offset 16, flags 0x6
    public bool getStartingColorFromMaterial;
    // field 16129, runtime offset 20, flags 0x6
    public FlexibleColorPicker fcp;
    // field 16130, runtime offset 24, flags 0x6
    public UnityEngine.Material material;
    // method 29829, 0x600008e
    void Start();
    // method 29830, 0x600008f
    void OnChangeColor(UnityEngine.Color co);
    // method 29831, 0x6000090
    void .ctor();
}

// TypeDefinition 3948, 0x200001d
class SaveStrategy : System.Enum {
    // field 16138, runtime offset 8, flags 0x606
    public int value__;
    // field 16139, runtime offset 0, flags 0x8056
    public static const SaveStrategy SessionOnly = 0;
    // field 16140, runtime offset 0, flags 0x8056
    public static const SaveStrategy File = 1;
    // field 16141, runtime offset 0, flags 0x8056
    public static const SaveStrategy PlayerPrefs = 2;
}

// TypeDefinition 3949, 0x200001c
class FCP_Persistence : UnityEngine.MonoBehaviour {
    // field 16131, runtime offset 16, flags 0x6
    public string saveName;
    // field 16132, runtime offset 20, flags 0x6
    public SaveStrategy saveStrategy;
    // field 16133, runtime offset 24, flags 0x1
    private FlexibleColorPicker fcp;
    // field 16134, runtime offset 0, flags 0x11
    private static System.Collections.Generic.Dictionary<string, UnityEngine.Color> savedColors;
    // field 16135, runtime offset 4, flags 0x11
    private static string saveFilePath;
    // field 16136, runtime offset 8, flags 0x11
    private static bool saveFileLoaded;
    // field 16137, runtime offset 9, flags 0x11
    private static bool saveFileOutdated;
    // method 29832, 0x6000091
    void Awake();
    // method 29833, 0x6000092
    void InitStatic();
    // method 29834, 0x6000093
    void OnDestroy();
    // method 29835, 0x6000094
    void OnEnable();
    // method 29836, 0x6000095
    void OnDisable();
    // method 29837, 0x6000096
    void LoadDataFile();
    // method 29838, 0x6000097
    void SaveDataFile();
    // method 29839, 0x6000098
    void SaveColor(UnityEngine.Color c);
    // method 29840, 0x6000099
    bool LoadColor(out UnityEngine.Color c);
    // method 29841, 0x600009a
    string GenerateID();
    // method 29842, 0x600009b
    void .ctor();
}

// TypeDefinition 3950, 0x200001f
class MeshType : System.Enum {
    // field 16147, runtime offset 8, flags 0x606
    public int value__;
    // field 16148, runtime offset 0, flags 0x8056
    public static const MeshType CenterPoint = 0;
    // field 16149, runtime offset 0, flags 0x8056
    public static const MeshType forward = 1;
    // field 16150, runtime offset 0, flags 0x8056
    public static const MeshType backward = 2;
}

// TypeDefinition 3951, 0x200001e
class FCP_SpriteMeshEditor : UnityEngine.MonoBehaviour {
    // field 16142, runtime offset 16, flags 0x6
    public int x;
    // field 16143, runtime offset 20, flags 0x6
    public int y;
    // field 16144, runtime offset 24, flags 0x6
    public MeshType meshType;
    // field 16145, runtime offset 28, flags 0x6
    public UnityEngine.Sprite sprite;
    // field 16146, runtime offset 32, flags 0x1
    private int bufferedHash;
    // method 29843, 0x600009c
    void Update();
    // method 29844, 0x600009d
    int GetSettingHash();
    // method 29845, 0x600009e
    void MakeMesh(UnityEngine.Sprite sprite, int x, int y, MeshType meshtype);
    // method 29846, 0x600009f
    void .ctor();
}

// TypeDefinition 3952, 0x2000021
class Picker : System.ValueType {
    // field 16177, runtime offset 8, flags 0x6
    public UnityEngine.UI.Image image;
    // field 16178, runtime offset 12, flags 0x6
    public UnityEngine.Sprite dynamicSprite;
    // field 16179, runtime offset 16, flags 0x6
    public UnityEngine.Sprite staticSpriteHor;
    // field 16180, runtime offset 20, flags 0x6
    public UnityEngine.Sprite staticSpriteVer;
    // field 16181, runtime offset 24, flags 0x6
    public UnityEngine.Material dynamicMaterial;
}

// TypeDefinition 3953, 0x2000022
class PickerType : System.Enum {
    // field 16182, runtime offset 8, flags 0x606
    public int value__;
    // field 16183, runtime offset 0, flags 0x8056
    public static const PickerType Main = 0;
    // field 16184, runtime offset 0, flags 0x8056
    public static const PickerType R = 1;
    // field 16185, runtime offset 0, flags 0x8056
    public static const PickerType G = 2;
    // field 16186, runtime offset 0, flags 0x8056
    public static const PickerType B = 3;
    // field 16187, runtime offset 0, flags 0x8056
    public static const PickerType H = 4;
    // field 16188, runtime offset 0, flags 0x8056
    public static const PickerType S = 5;
    // field 16189, runtime offset 0, flags 0x8056
    public static const PickerType V = 6;
    // field 16190, runtime offset 0, flags 0x8056
    public static const PickerType A = 7;
    // field 16191, runtime offset 0, flags 0x8056
    public static const PickerType Preview = 8;
    // field 16192, runtime offset 0, flags 0x8056
    public static const PickerType PreviewAlpha = 9;
}

// TypeDefinition 3954, 0x2000023
class MainPickingMode : System.Enum {
    // field 16193, runtime offset 8, flags 0x606
    public int value__;
    // field 16194, runtime offset 0, flags 0x8056
    public static const MainPickingMode HS = 0;
    // field 16195, runtime offset 0, flags 0x8056
    public static const MainPickingMode HV = 1;
    // field 16196, runtime offset 0, flags 0x8056
    public static const MainPickingMode SH = 2;
    // field 16197, runtime offset 0, flags 0x8056
    public static const MainPickingMode SV = 3;
    // field 16198, runtime offset 0, flags 0x8056
    public static const MainPickingMode VH = 4;
    // field 16199, runtime offset 0, flags 0x8056
    public static const MainPickingMode VS = 5;
}

// TypeDefinition 3955, 0x2000024
class ColorUpdateEvent : UnityEngine.Events.UnityEvent<UnityEngine.Color> {
    // method 29904, 0x60000d9
    void .ctor();
}

// TypeDefinition 3956, 0x2000026
class PSettings : object {
    // field 16208, runtime offset 8, flags 0x6
    public UnityEngine.Vector2 range;
    // field 16209, runtime offset 16, flags 0x6
    public bool overrideStatic;
    // method 29907, 0x60000dc
    void .ctor();
}

// TypeDefinition 3957, 0x2000025
class AdvancedSettings : object {
    // field 16200, runtime offset 8, flags 0x6
    public bool mainStatic;
    // field 16201, runtime offset 12, flags 0x6
    public PSettings r;
    // field 16202, runtime offset 16, flags 0x6
    public PSettings g;
    // field 16203, runtime offset 20, flags 0x6
    public PSettings b;
    // field 16204, runtime offset 24, flags 0x6
    public PSettings h;
    // field 16205, runtime offset 28, flags 0x6
    public PSettings s;
    // field 16206, runtime offset 32, flags 0x6
    public PSettings v;
    // field 16207, runtime offset 36, flags 0x6
    public PSettings a;
    // method 29905, 0x60000da
    PSettings Get(int i);
    // method 29906, 0x60000db
    void .ctor();
}

// TypeDefinition 3958, 0x2000027
class BufferedColor : object {
    // field 16210, runtime offset 8, flags 0x6
    public UnityEngine.Color color;
    // field 16211, runtime offset 24, flags 0x1
    private float bufferedHue;
    // field 16212, runtime offset 28, flags 0x1
    private float bufferedSaturation;
    // method 29908, 0x60000dd
    float get_r();
    // method 29909, 0x60000de
    float get_g();
    // method 29910, 0x60000df
    float get_b();
    // method 29911, 0x60000e0
    float get_a();
    // method 29912, 0x60000e1
    float get_h();
    // method 29913, 0x60000e2
    float get_s();
    // method 29914, 0x60000e3
    float get_v();
    // method 29915, 0x60000e4
    void .ctor();
    // method 29916, 0x60000e5
    void .ctor(UnityEngine.Color color);
    // method 29917, 0x60000e6
    void .ctor(UnityEngine.Color color, float hue, float sat);
    // method 29918, 0x60000e7
    void .ctor(UnityEngine.Color color, BufferedColor source);
    // method 29919, 0x60000e8
    void Set(UnityEngine.Color color);
    // method 29920, 0x60000e9
    void Set(UnityEngine.Color color, float bufferedHue, float bufferedSaturation);
    // method 29921, 0x60000ea
    BufferedColor PickR(float value);
    // method 29922, 0x60000eb
    BufferedColor PickG(float value);
    // method 29923, 0x60000ec
    BufferedColor PickB(float value);
    // method 29924, 0x60000ed
    BufferedColor PickA(float value);
    // method 29925, 0x60000ee
    BufferedColor PickH(float value);
    // method 29926, 0x60000ef
    BufferedColor PickS(float value);
    // method 29927, 0x60000f0
    BufferedColor PickV(float value);
}

// TypeDefinition 3959, 0x2000020
class FlexibleColorPicker : UnityEngine.MonoBehaviour {
    // field 16151, runtime offset 16, flags 0x1
    private Picker[] pickers;
    // field 16152, runtime offset 20, flags 0x1
    private UnityEngine.UI.InputField hexInput;
    // field 16153, runtime offset 24, flags 0x1
    private UnityEngine.UI.Dropdown modeDropdown;
    // field 16154, runtime offset 28, flags 0x1
    private UnityEngine.Canvas canvas;
    // field 16155, runtime offset 32, flags 0x1
    private MainPickingMode mode;
    // field 16156, runtime offset 36, flags 0x1
    private UnityEngine.Sprite[] staticSpriteMain;
    // field 16157, runtime offset 40, flags 0x1
    private BufferedColor bufferedColor;
    // field 16158, runtime offset 44, flags 0x1
    private Picker focusedPicker;
    // field 16159, runtime offset 64, flags 0x1
    private PickerType focusedPickerType;
    // field 16160, runtime offset 68, flags 0x1
    private MainPickingMode lastUpdatedMode;
    // field 16161, runtime offset 72, flags 0x1
    private bool typeUpdate;
    // field 16162, runtime offset 73, flags 0x1
    private bool triggeredStaticMode;
    // field 16163, runtime offset 74, flags 0x1
    private bool materialsSeperated;
    // field 16164, runtime offset 76, flags 0x1
    private UnityEngine.Color startingColor;
    // field 16165, runtime offset 92, flags 0x6
    public bool staticMode;
    // field 16166, runtime offset 93, flags 0x6
    public bool multiInstance;
    // field 16167, runtime offset 96, flags 0x6
    public ColorUpdateEvent onColorChange;
    // field 16168, runtime offset 0, flags 0x8051
    private static const float HUE_LOOP = 5.999899864196777;
    // field 16169, runtime offset 0, flags 0x8051
    private static const string SHADER_MODE = "_Mode";
    // field 16170, runtime offset 0, flags 0x8051
    private static const string SHADER_C1 = "_Color1";
    // field 16171, runtime offset 0, flags 0x8051
    private static const string SHADER_C2 = "_Color2";
    // field 16172, runtime offset 0, flags 0x8051
    private static const string SHADER_DOUBLE_MODE = "_DoubleMode";
    // field 16173, runtime offset 0, flags 0x8051
    private static const string SHADER_HSV = "_HSV";
    // field 16174, runtime offset 0, flags 0x8051
    private static const string SHADER_HSV_MIN = "_HSV_MIN";
    // field 16175, runtime offset 0, flags 0x8051
    private static const string SHADER_HSV_MAX = "_HSV_MAX";
    // field 16176, runtime offset 100, flags 0x6
    public AdvancedSettings advancedSettings;
    // method 29847, 0x60000a0
    AdvancedSettings get_avs();
    // method 29848, 0x60000a1
    UnityEngine.Color get_color();
    // method 29849, 0x60000a2
    void set_color(UnityEngine.Color value);
    // method 29850, 0x60000a3
    UnityEngine.Color GetColor();
    // method 29851, 0x60000a4
    void SetColor(UnityEngine.Color color);
    // method 29852, 0x60000a5
    UnityEngine.Color GetColorFullAlpha();
    // method 29853, 0x60000a6
    void SetColorNoAlpha(UnityEngine.Color color);
    // method 29854, 0x60000a7
    void Awake();
    // method 29855, 0x60000a8
    void OnEnable();
    // method 29856, 0x60000a9
    void Update();
    // method 29857, 0x60000aa
    void SetPointerFocus(int i);
    // method 29858, 0x60000ab
    void PointerUpdate(UnityEngine.EventSystems.BaseEventData e);
    // method 29859, 0x60000ac
    void TypeHex(string input);
    // method 29860, 0x60000ad
    void FinishTypeHex(string input);
    // method 29861, 0x60000ae
    void ChangeMode(int newMode);
    // method 29862, 0x60000af
    void ChangeMode(MainPickingMode mode);
    // method 29863, 0x60000b0
    void SeperateMaterials();
    // method 29864, 0x60000b1
    void ShiftColor(int type, float delta);
    // method 29865, 0x60000b2
    void ShiftHue(float delta);
    // method 29866, 0x60000b3
    BufferedColor PickColor(BufferedColor color, PickerType type, UnityEngine.Vector2 v);
    // method 29867, 0x60000b4
    BufferedColor PickColorMain(BufferedColor color, UnityEngine.Vector2 v);
    // method 29868, 0x60000b5
    BufferedColor PickColor1D(BufferedColor color, PickerType type, UnityEngine.Vector2 v);
    // method 29869, 0x60000b6
    BufferedColor PickColorMain(BufferedColor color, MainPickingMode mode, UnityEngine.Vector2 v);
    // method 29870, 0x60000b7
    BufferedColor PickColor2D(BufferedColor color, PickerType type1, float value1, PickerType type2, float value2);
    // method 29871, 0x60000b8
    BufferedColor PickColor1D(BufferedColor color, PickerType type, float value);
    // method 29872, 0x60000b9
    void UpdateMarkers();
    // method 29873, 0x60000ba
    void UpdateMarker(Picker picker, PickerType type, UnityEngine.Vector2 v);
    // method 29874, 0x60000bb
    void SetMarker(UnityEngine.UI.Image picker, UnityEngine.Vector2 v, bool setX, bool setY);
    // method 29875, 0x60000bc
    UnityEngine.RectTransform GetMarker(UnityEngine.UI.Image picker, string search);
    // method 29876, 0x60000bd
    UnityEngine.Vector2 GetValue(PickerType type);
    // method 29877, 0x60000be
    float GetValue1D(PickerType type);
    // method 29878, 0x60000bf
    UnityEngine.Vector2 GetValue(MainPickingMode mode);
    // method 29879, 0x60000c0
    void UpdateTextures();
    // method 29880, 0x60000c1
    void UpdateStatic(PickerType type);
    // method 29881, 0x60000c2
    void UpdateDynamic(PickerType type);
    // method 29882, 0x60000c3
    int GetGradientMode(PickerType type);
    // method 29883, 0x60000c4
    bool IsPickerAvailable(PickerType type);
    // method 29884, 0x60000c5
    bool IsPickerAvailable(int index);
    // method 29885, 0x60000c6
    void UpdateHex();
    // method 29886, 0x60000c7
    void TypeHex(string input, bool finish);
    // method 29887, 0x60000c8
    void MakeModeOptions();
    // method 29888, 0x60000c9
    void UpdateMode(MainPickingMode mode);
    // method 29889, 0x60000ca
    bool IsPreviewType(PickerType type);
    // method 29890, 0x60000cb
    bool IsAlphaType(PickerType type);
    // method 29891, 0x60000cc
    bool IsHorizontal(Picker p);
    // method 29892, 0x60000cd
    string GetSanitizedHex(string input, bool full);
    // method 29893, 0x60000ce
    bool IsValidHexChar(char c);
    // method 29894, 0x60000cf
    UnityEngine.Color ParseHex(string input);
    // method 29895, 0x60000d0
    UnityEngine.Color ParseHex(string input, UnityEngine.Color defaultColor);
    // method 29896, 0x60000d1
    UnityEngine.Vector2 GetNormalizedPointerPosition(UnityEngine.Canvas canvas, UnityEngine.RectTransform rect, UnityEngine.EventSystems.BaseEventData e);
    // method 29897, 0x60000d2
    UnityEngine.Vector2 GetNormScreenSpace(UnityEngine.RectTransform rect, UnityEngine.EventSystems.BaseEventData e);
    // method 29898, 0x60000d3
    UnityEngine.Vector2 GetNormWorldSpace(UnityEngine.Canvas canvas, UnityEngine.RectTransform rect, UnityEngine.EventSystems.BaseEventData e);
    // method 29899, 0x60000d4
    UnityEngine.Color HSVToRGB(UnityEngine.Vector3 hsv);
    // method 29900, 0x60000d5
    UnityEngine.Color HSVToRGB(float h, float s, float v);
    // method 29901, 0x60000d6
    UnityEngine.Vector3 RGBToHSV(UnityEngine.Color color);
    // method 29902, 0x60000d7
    UnityEngine.Vector3 RGBToHSV(float r, float g, float b);
    // method 29903, 0x60000d8
    void .ctor();
}

// TypeDefinition 3960, 0x2000029
class FriendData : object {
    // field 16224, runtime offset 8, flags 0x6
    public string Name;
    // field 16225, runtime offset 12, flags 0x6
    public Photon.Realtime.FriendInfo Info;
    // field 16226, runtime offset 16, flags 0x6
    public bl_PhotonFriendUI UI;
    // method 29943, 0x6000100
    void .ctor();
}

// TypeDefinition 3961, 0x200002a
class FriendUIStatus : object {
    // field 16227, runtime offset 8, flags 0x6
    public string Status;
    // field 16228, runtime offset 12, flags 0x6
    public UnityEngine.Color Color;
    // method 29944, 0x6000101
    void .ctor();
}

// TypeDefinition 3962, 0x200002b
class <>c : object {
    // field 16229, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16230, runtime offset 4, flags 0x16
    public static System.Func<FriendData, string> <>9__12_0;
    // field 16231, runtime offset 8, flags 0x16
    public static System.Func<FriendData, string> <>9__17_0;
    // field 16232, runtime offset 12, flags 0x16
    public static System.Func<FriendData, string> <>9__18_0;
    // method 29945, 0x6000102
    void .cctor();
    // method 29946, 0x6000103
    void .ctor();
    // method 29947, 0x6000104
    string <LoadFriends>b__12_0(FriendData x);
    // method 29948, 0x6000105
    string <SaveFriends>b__17_0(FriendData x);
    // method 29949, 0x6000106
    string <FindFriends>b__18_0(FriendData x);
}

// TypeDefinition 3963, 0x200002c
class <>c__DisplayClass14_0 : object {
    // field 16233, runtime offset 8, flags 0x6
    public System.Collections.Generic.List<Photon.Realtime.FriendInfo> newList;
    // field 16234, runtime offset 12, flags 0x6
    public int i;
    // field 16235, runtime offset 16, flags 0x6
    public System.Predicate<FriendData> <>9__0;
    // field 16236, runtime offset 20, flags 0x6
    public System.Predicate<FriendData> <>9__1;
    // method 29950, 0x6000107
    void .ctor();
    // method 29951, 0x6000108
    bool <UpdateFriendArray>b__0(FriendData x);
    // method 29952, 0x6000109
    bool <UpdateFriendArray>b__1(FriendData x);
}

// TypeDefinition 3964, 0x200002d
class <>c__DisplayClass15_0 : object {
    // field 16237, runtime offset 8, flags 0x6
    public string text;
    // method 29953, 0x600010a
    void .ctor();
    // method 29954, 0x600010b
    bool <AddFriend>b__0(FriendData x);
}

// TypeDefinition 3965, 0x200002e
class <>c__DisplayClass16_0 : object {
    // field 16238, runtime offset 8, flags 0x6
    public string Name;
    // method 29955, 0x600010c
    void .ctor();
    // method 29956, 0x600010d
    bool <RemoveFriend>b__0(FriendData x);
}

// TypeDefinition 3966, 0x2000028
class bl_PhotonFriendList : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 16213, runtime offset 20, flags 0x6
    public int UpdateRate;
    // field 16214, runtime offset 24, flags 0x6
    public int MaxFriends;
    // field 16215, runtime offset 28, flags 0x6
    public FriendUIStatus[] StatusData;
    // field 16216, runtime offset 32, flags 0x6
    public UnityEngine.GameObject Content;
    // field 16217, runtime offset 36, flags 0x6
    public UnityEngine.GameObject FriendUIPrefab;
    // field 16218, runtime offset 40, flags 0x6
    public UnityEngine.RectTransform Separator;
    // field 16219, runtime offset 44, flags 0x6
    public UnityEngine.RectTransform NoFriendsOnline;
    // field 16220, runtime offset 48, flags 0x6
    public UnityEngine.RectTransform ListPanel;
    // field 16221, runtime offset 52, flags 0x6
    public UnityEngine.UI.Text FriendsCountText;
    // field 16222, runtime offset 56, flags 0x1
    private System.Collections.Generic.List<FriendData> friendsArray;
    // field 16223, runtime offset 60, flags 0x1
    private bool pendingRebuild;
    // method 29928, 0x60000f1
    void Awake();
    // method 29929, 0x60000f2
    void LoadFriends();
    // method 29930, 0x60000f3
    void UpdateUIList(bool rebuild);
    // method 29931, 0x60000f4
    void UpdateFriendArray(System.Collections.Generic.List<Photon.Realtime.FriendInfo> newList);
    // method 29932, 0x60000f5
    void AddFriend(string text);
    // method 29933, 0x60000f6
    void RemoveFriend(string Name);
    // method 29934, 0x60000f7
    void SaveFriends();
    // method 29935, 0x60000f8
    void FindFriends();
    // method 29936, 0x60000f9
    void AddFriend(UnityEngine.UI.InputField field);
    // method 29937, 0x60000fa
    void ClearUI();
    // method 29938, 0x60000fb
    string get_FRIENDS_KEY();
    // method 29939, 0x60000fc
    void OnJoinedLobby();
    // method 29940, 0x60000fd
    void OnFriendListUpdate(System.Collections.Generic.List<Photon.Realtime.FriendInfo> friendList);
    // method 29941, 0x60000fe
    void OnJoinedRoom();
    // method 29942, 0x60000ff
    void .ctor();
}

// TypeDefinition 3967, 0x200002f
class bl_PhotonFriendUI : UnityEngine.MonoBehaviour {
    // field 16239, runtime offset 16, flags 0x6
    public UnityEngine.UI.Text NameText;
    // field 16240, runtime offset 20, flags 0x6
    public UnityEngine.UI.Text StatusText;
    // field 16241, runtime offset 24, flags 0x6
    public UnityEngine.UI.Image StatusImage;
    // field 16242, runtime offset 28, flags 0x6
    public UnityEngine.GameObject JoinButton;
    // field 16243, runtime offset 32, flags 0x1
    private bl_PhotonFriendList Manager;
    // field 16244, runtime offset 36, flags 0x1
    private FriendData cacheData;
    // field 16245, runtime offset 40, flags 0x1
    private int lastStatus;
    // method 29957, 0x600010e
    bool Set(FriendData data, bl_PhotonFriendList from);
    // method 29958, 0x600010f
    void Remove();
    // method 29959, 0x6000110
    void Join();
    // method 29960, 0x6000111
    void .ctor();
}

// TypeDefinition 3968, 0x2000030
class bl_AutoJoin : Photon.Pun.MonoBehaviourPunCallbacks {
    // method 29961, 0x6000112
    void .ctor();
}

// TypeDefinition 3969, 0x2000031
class JoystickPlayerExample : UnityEngine.MonoBehaviour {
    // field 16246, runtime offset 16, flags 0x6
    public float speed;
    // field 16247, runtime offset 20, flags 0x6
    public VariableJoystick variableJoystick;
    // field 16248, runtime offset 24, flags 0x6
    public UnityEngine.Rigidbody rb;
    // method 29962, 0x6000113
    void FixedUpdate();
    // method 29963, 0x6000114
    void .ctor();
}

// TypeDefinition 3970, 0x2000032
class JoystickSetterExample : UnityEngine.MonoBehaviour {
    // field 16249, runtime offset 16, flags 0x6
    public VariableJoystick variableJoystick;
    // field 16250, runtime offset 20, flags 0x6
    public UnityEngine.UI.Text valueText;
    // field 16251, runtime offset 24, flags 0x6
    public UnityEngine.UI.Image background;
    // field 16252, runtime offset 28, flags 0x6
    public UnityEngine.Sprite[] axisSprites;
    // method 29964, 0x6000115
    void ModeChanged(int index);
    // method 29965, 0x6000116
    void AxisChanged(int index);
    // method 29966, 0x6000117
    void SnapX(bool value);
    // method 29967, 0x6000118
    void SnapY(bool value);
    // method 29968, 0x6000119
    void Update();
    // method 29969, 0x600011a
    void .ctor();
}

// TypeDefinition 3971, 0x2000033
class Joystick : UnityEngine.MonoBehaviour {
    // field 16253, runtime offset 16, flags 0x1
    private float handleRange;
    // field 16254, runtime offset 20, flags 0x1
    private float deadZone;
    // field 16255, runtime offset 24, flags 0x1
    private AxisOptions axisOptions;
    // field 16256, runtime offset 28, flags 0x1
    private bool snapX;
    // field 16257, runtime offset 29, flags 0x1
    private bool snapY;
    // field 16258, runtime offset 32, flags 0x4
    protected UnityEngine.RectTransform background;
    // field 16259, runtime offset 36, flags 0x1
    private UnityEngine.RectTransform handle;
    // field 16260, runtime offset 40, flags 0x1
    private UnityEngine.RectTransform baseRect;
    // field 16261, runtime offset 44, flags 0x1
    private UnityEngine.Canvas canvas;
    // field 16262, runtime offset 48, flags 0x1
    private UnityEngine.Camera cam;
    // field 16263, runtime offset 52, flags 0x1
    private UnityEngine.Vector2 input;
    // method 29970, 0x600011b
    bool IsNearly00(UnityEngine.Vector2 localPos);
    // method 29971, 0x600011c
    float get_Horizontal();
    // method 29972, 0x600011d
    float get_Vertical();
    // method 29973, 0x600011e
    UnityEngine.Vector2 get_Direction();
    // method 29974, 0x600011f
    float get_HandleRange();
    // method 29975, 0x6000120
    void set_HandleRange(float value);
    // method 29976, 0x6000121
    float get_DeadZone();
    // method 29977, 0x6000122
    void set_DeadZone(float value);
    // method 29978, 0x6000123
    AxisOptions get_AxisOptions();
    // method 29979, 0x6000124
    void set_AxisOptions(AxisOptions value);
    // method 29980, 0x6000125
    bool get_SnapX();
    // method 29981, 0x6000126
    void set_SnapX(bool value);
    // method 29982, 0x6000127
    bool get_SnapY();
    // method 29983, 0x6000128
    void set_SnapY(bool value);
    // method 29984, 0x6000129
    void Start();
    // method 29985, 0x600012a
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 29986, 0x600012b
    void OnDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 29987, 0x600012c
    void HandleInput(float magnitude, UnityEngine.Vector2 normalised, UnityEngine.Vector2 radius, UnityEngine.Camera cam);
    // method 29988, 0x600012d
    void FormatInput();
    // method 29989, 0x600012e
    float SnapFloat(float value, AxisOptions snapAxis);
    // method 29990, 0x600012f
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 29991, 0x6000130
    UnityEngine.Vector2 ScreenPointToAnchoredPosition(UnityEngine.Vector2 screenPosition);
    // method 29992, 0x6000131
    void .ctor();
}

// TypeDefinition 3972, 0x2000034
class AxisOptions : System.Enum {
    // field 16264, runtime offset 8, flags 0x606
    public int value__;
    // field 16265, runtime offset 0, flags 0x8056
    public static const AxisOptions Both = 0;
    // field 16266, runtime offset 0, flags 0x8056
    public static const AxisOptions Horizontal = 1;
    // field 16267, runtime offset 0, flags 0x8056
    public static const AxisOptions Vertical = 2;
}

// TypeDefinition 3973, 0x2000035
class DynamicJoystick : Joystick {
    // field 16268, runtime offset 60, flags 0x1
    private float moveThreshold;
    // method 29993, 0x6000132
    float get_MoveThreshold();
    // method 29994, 0x6000133
    void set_MoveThreshold(float value);
    // method 29995, 0x6000134
    void Start();
    // method 29996, 0x6000135
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 29997, 0x6000136
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 29998, 0x6000137
    void HandleInput(float magnitude, UnityEngine.Vector2 normalised, UnityEngine.Vector2 radius, UnityEngine.Camera cam);
    // method 29999, 0x6000138
    void .ctor();
}

// TypeDefinition 3974, 0x2000036
class FixedJoystick : Joystick {
    // method 30000, 0x6000139
    void .ctor();
}

// TypeDefinition 3975, 0x2000037
class FloatingJoystick : Joystick {
    // field 16269, runtime offset 60, flags 0x1
    private UnityEngine.Vector2 initialAnchoredPos;
    // method 30001, 0x600013a
    void Start();
    // method 30002, 0x600013b
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30003, 0x600013c
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30004, 0x600013d
    void .ctor();
}

// TypeDefinition 3976, 0x2000038
class VariableJoystick : Joystick {
    // field 16270, runtime offset 60, flags 0x1
    private float moveThreshold;
    // field 16271, runtime offset 64, flags 0x1
    private JoystickType joystickType;
    // field 16272, runtime offset 68, flags 0x1
    private UnityEngine.Vector2 fixedPosition;
    // method 30005, 0x600013e
    float get_MoveThreshold();
    // method 30006, 0x600013f
    void set_MoveThreshold(float value);
    // method 30007, 0x6000140
    void SetMode(JoystickType joystickType);
    // method 30008, 0x6000141
    void Start();
    // method 30009, 0x6000142
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30010, 0x6000143
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30011, 0x6000144
    void HandleInput(float magnitude, UnityEngine.Vector2 normalised, UnityEngine.Vector2 radius, UnityEngine.Camera cam);
    // method 30012, 0x6000145
    void .ctor();
}

// TypeDefinition 3977, 0x2000039
class JoystickType : System.Enum {
    // field 16273, runtime offset 8, flags 0x606
    public int value__;
    // field 16274, runtime offset 0, flags 0x8056
    public static const JoystickType Fixed = 0;
    // field 16275, runtime offset 0, flags 0x8056
    public static const JoystickType Floating = 1;
    // field 16276, runtime offset 0, flags 0x8056
    public static const JoystickType Dynamic = 2;
}

// TypeDefinition 3978, 0x200003a
class spawnPoint : UnityEngine.MonoBehaviour {
    // method 30013, 0x6000146
    void .ctor();
}

// TypeDefinition 3979, 0x200003b
class PolygonOrbit : UnityEngine.MonoBehaviour {
    // field 16277, runtime offset 16, flags 0x6
    public UnityEngine.Transform target;
    // field 16278, runtime offset 20, flags 0x6
    public float distance;
    // field 16279, runtime offset 24, flags 0x6
    public float xSpeed;
    // field 16280, runtime offset 28, flags 0x6
    public float ySpeed;
    // field 16281, runtime offset 32, flags 0x6
    public float yMinLimit;
    // field 16282, runtime offset 36, flags 0x6
    public float yMaxLimit;
    // field 16283, runtime offset 40, flags 0x6
    public float distanceMin;
    // field 16284, runtime offset 44, flags 0x6
    public float distanceMax;
    // field 16285, runtime offset 48, flags 0x6
    public float smoothTime;
    // field 16286, runtime offset 52, flags 0x1
    private float rotationYAxis;
    // field 16287, runtime offset 56, flags 0x1
    private float rotationXAxis;
    // field 16288, runtime offset 60, flags 0x1
    private float velocityX;
    // field 16289, runtime offset 64, flags 0x1
    private float velocityY;
    // method 30014, 0x6000147
    void Start();
    // method 30015, 0x6000148
    void LateUpdate();
    // method 30016, 0x6000149
    float ClampAngle(float angle, float min, float max);
    // method 30017, 0x600014a
    void .ctor();
}

// TypeDefinition 3980, 0x200003c
class PolygonLightFlicker : UnityEngine.MonoBehaviour {
    // field 16290, runtime offset 16, flags 0x6
    public string waveFunction;
    // field 16291, runtime offset 20, flags 0x6
    public float startValue;
    // field 16292, runtime offset 24, flags 0x6
    public float amplitude;
    // field 16293, runtime offset 28, flags 0x6
    public float phase;
    // field 16294, runtime offset 32, flags 0x6
    public float frequency;
    // field 16295, runtime offset 36, flags 0x1
    private UnityEngine.Color originalColor;
    // method 30018, 0x600014b
    void Start();
    // method 30019, 0x600014c
    void Update();
    // method 30020, 0x600014d
    float EvalWave();
    // method 30021, 0x600014e
    void .ctor();
}

// TypeDefinition 3981, 0x200003d
class EditorSpawnPoint : UnityEngine.MonoBehaviour {
    // field 16296, runtime offset 16, flags 0x6
    public int spawnPointIndex;
    // method 30022, 0x600014f
    void OnEnable();
    // method 30023, 0x6000150
    void OnMapSettingsChanged();
    // method 30024, 0x6000151
    void Start();
    // method 30025, 0x6000152
    void SlowUpdate();
    // method 30026, 0x6000153
    void .ctor();
}

// TypeDefinition 3982, 0x200003e
class KourpassPanel : Popup {
    // method 30027, 0x6000154
    void .ctor();
}

// TypeDefinition 3983, 0x200003f
class UserRecoveryPanel : Popup {
    // field 16297, runtime offset 68, flags 0x1
    private UnityEngine.GameObject revealPasswordButton;
    // field 16298, runtime offset 72, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 16299, runtime offset 76, flags 0x1
    private TMPro.TMP_Text passwordTxt;
    // field 16300, runtime offset 80, flags 0x1
    private TMPro.TMP_Text passwordNopacityTxt;
    // method 30028, 0x6000155
    void Start();
    // method 30029, 0x6000156
    void RevealPassword();
    // method 30030, 0x6000157
    void .ctor();
    // method 30031, 0x6000158
    void <RevealPassword>b__5_0();
}

// TypeDefinition 3984, 0x2000040
class ATV : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 16301, runtime offset 20, flags 0x6
    public UnityEngine.Transform myCameraFollowParentTargetPos;
    // field 16302, runtime offset 24, flags 0x6
    public UnityEngine.Transform myCameraFollowParent;
    // field 16303, runtime offset 28, flags 0x6
    public UnityEngine.GameObject myCameraFollow;
    // field 16304, runtime offset 32, flags 0x6
    public UnityEngine.Transform playerParentSit;
    // field 16305, runtime offset 0, flags 0x16
    public static ATV currentLookedAt;
    // field 16306, runtime offset 36, flags 0x1
    private UnityEngine.Behaviour[] componentsToControl;
    // field 16307, runtime offset 40, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 16308, runtime offset 44, flags 0x1
    private Shooter playerInside;
    // field 16309, runtime offset 4, flags 0x11
    private static float lastTryEnter;
    // method 30032, 0x6000159
    Shooter GetShooterFromPlayer(Photon.Realtime.Player player);
    // method 30033, 0x600015a
    void Update();
    // method 30034, 0x600015b
    void OnLookedAt(bool beingLookedAt);
    // method 30035, 0x600015c
    void Awake();
    // method 30036, 0x600015d
    void TryEnter();
    // method 30037, 0x600015e
    void OnOwnershipRequest(Photon.Pun.PhotonView targetView, Photon.Realtime.Player requestingPlayer);
    // method 30038, 0x600015f
    void OnOwnershipTransfered(Photon.Pun.PhotonView targetView, Photon.Realtime.Player previousOwner);
    // method 30039, 0x6000160
    void TryExit();
    // method 30040, 0x6000161
    void RPCExit();
    // method 30041, 0x6000162
    void ActivateVehicle(bool isActive);
    // method 30042, 0x6000163
    void OnOwnershipTransferFailed(Photon.Pun.PhotonView targetView, Photon.Realtime.Player senderOfFailedRequest);
    // method 30043, 0x6000164
    void OnCollisionEnter(UnityEngine.Collision collision);
    // method 30044, 0x6000165
    string GetATVInfos();
    // method 30045, 0x6000166
    void .ctor();
}

// TypeDefinition 3985, 0x2000041
class ATVInput : Photon.Pun.MonoBehaviourPun {
    // field 16310, runtime offset 20, flags 0x6
    public float Horizontal;
    // field 16311, runtime offset 24, flags 0x6
    public float Vertical;
    // field 16312, runtime offset 28, flags 0x6
    public float Brake;
    // method 30046, 0x6000167
    float GetAxis(string axis);
    // method 30047, 0x6000168
    void Update();
    // method 30048, 0x6000169
    void Photon.Pun.IPunObservable.OnPhotonSerializeView(Photon.Pun.PhotonStream stream, Photon.Pun.PhotonMessageInfo info);
    // method 30049, 0x600016a
    void .ctor();
}

// TypeDefinition 3986, 0x2000043
class <>c__DisplayClass15_0 : object {
    // field 16323, runtime offset 8, flags 0x6
    public string txt;
    // field 16324, runtime offset 12, flags 0x6
    public AdminManager <>4__this;
    // method 30070, 0x600017f
    void .ctor();
    // method 30071, 0x6000180
    void <PromoteUserToAdmin>b__0();
}

// TypeDefinition 3987, 0x2000044
class <>c__DisplayClass16_0 : object {
    // field 16325, runtime offset 8, flags 0x6
    public string txt;
    // field 16326, runtime offset 12, flags 0x6
    public AdminManager <>4__this;
    // field 16327, runtime offset 16, flags 0x6
    public System.Action<string> <>9__1;
    // method 30072, 0x6000181
    void .ctor();
    // method 30073, 0x6000182
    void <AddCC>b__0();
    // method 30074, 0x6000183
    void <AddCC>b__1(string x);
}

// TypeDefinition 3988, 0x2000045
class <>c__DisplayClass18_0 : object {
    // field 16328, runtime offset 8, flags 0x6
    public string txt;
    // field 16329, runtime offset 12, flags 0x6
    public AdminManager <>4__this;
    // method 30075, 0x6000184
    void .ctor();
    // method 30076, 0x6000185
    void <DeleteAccount>b__0();
}

// TypeDefinition 3989, 0x2000046
class <>c__DisplayClass25_0 : object {
    // field 16330, runtime offset 8, flags 0x6
    public string txt;
    // field 16331, runtime offset 12, flags 0x6
    public AdminManager <>4__this;
    // field 16332, runtime offset 16, flags 0x6
    public string txt1;
    // field 16333, runtime offset 20, flags 0x6
    public string txt2;
    // field 16334, runtime offset 24, flags 0x6
    public System.Action<string> <>9__2;
    // field 16335, runtime offset 28, flags 0x6
    public System.Action<string> <>9__1;
    // method 30077, 0x6000186
    void .ctor();
    // method 30078, 0x6000187
    void <SetKeyValuePair>b__0();
    // method 30079, 0x6000188
    void <SetKeyValuePair>b__1(string otherUID);
    // method 30080, 0x6000189
    void <SetKeyValuePair>b__2(string x);
}

// TypeDefinition 3990, 0x2000042
class AdminManager : UnityEngine.MonoBehaviour {
    // field 16313, runtime offset 16, flags 0x6
    public TMPro.TMP_InputField usernameIF;
    // field 16314, runtime offset 20, flags 0x6
    public TMPro.TMP_InputField keyIF;
    // field 16315, runtime offset 24, flags 0x6
    public TMPro.TMP_InputField valueIF;
    // field 16316, runtime offset 28, flags 0x6
    public TMPro.TMP_Text resultTxt;
    // field 16317, runtime offset 32, flags 0x6
    public UnityEngine.UI.Toggle isPublicToggle;
    // field 16318, runtime offset 36, flags 0x6
    public UnityEngine.UI.Toggle isEncryptedToggle;
    // field 16319, runtime offset 40, flags 0x6
    public UnityEngine.GameObject dfsgfdg;
    // field 16320, runtime offset 44, flags 0x6
    public TMPro.TMP_InputField valueToDec;
    // field 16321, runtime offset 48, flags 0x6
    public TMPro.TMP_Text decResultTxt;
    // field 16322, runtime offset 52, flags 0x6
    public TMPro.TMP_Text uidResultTxt;
    // method 30050, 0x600016b
    void Start();
    // method 30051, 0x600016c
    void Awake();
    // method 30052, 0x600016d
    void GetDecVal();
    // method 30053, 0x600016e
    void Update();
    // method 30054, 0x600016f
    void OnUsernameChanged(string txt);
    // method 30055, 0x6000170
    void PromoteUserToAdmin();
    // method 30056, 0x6000171
    void AddCC();
    // method 30057, 0x6000172
    void OnCCAdded(string uid);
    // method 30058, 0x6000173
    void DeleteAccount();
    // method 30059, 0x6000174
    void OnPromoted(string result);
    // method 30060, 0x6000175
    void DeleteAllAccounts();
    // method 30061, 0x6000176
    void OnDeleteAccounts(string result);
    // method 30062, 0x6000177
    void OnDeleteAccount(string result);
    // method 30063, 0x6000178
    void BanUser(bool banBool);
    // method 30064, 0x6000179
    void VerifyUser(bool verifyBool);
    // method 30065, 0x600017a
    void SetKeyValuePair();
    // method 30066, 0x600017b
    void .ctor();
    // method 30067, 0x600017c
    void <GetDecVal>b__12_0(string uid);
    // method 30068, 0x600017d
    void <OnUsernameChanged>b__14_0(string x);
    // method 30069, 0x600017e
    void <DeleteAllAccounts>b__20_0();
}

// TypeDefinition 3991, 0x2000048
class <IenuAftershots>d__15 : object {
    // field 16347, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16348, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16349, runtime offset 16, flags 0x6
    public AimableWeapon <>4__this;
    // field 16350, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 16351, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 30091, 0x6000194
    void .ctor(int <>1__state);
    // method 30092, 0x6000195
    void System.IDisposable.Dispose();
    // method 30093, 0x6000196
    bool MoveNext();
    // method 30094, 0x6000197
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30095, 0x6000198
    void System.Collections.IEnumerator.Reset();
    // method 30096, 0x6000199
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 3992, 0x2000047
class AimableWeapon : Weapon {
    // field 16336, runtime offset 252, flags 0x1
    private float aimDuration;
    // field 16337, runtime offset 256, flags 0x1
    private float fovMultiOnAim;
    // field 16338, runtime offset 260, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentPosition;
    // field 16339, runtime offset 272, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentRotation;
    // field 16340, runtime offset 284, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentPosition;
    // field 16341, runtime offset 296, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentRotation;
    // field 16342, runtime offset 308, flags 0x1
    private UnityEngine.AudioSource aftershotSource;
    // field 16343, runtime offset 312, flags 0x1
    private float intialAftershotDelay;
    // field 16344, runtime offset 316, flags 0x1
    private AfterShot[] aftershots;
    // field 16345, runtime offset 320, flags 0x1
    private float instabilityWhileAiming;
    // field 16346, runtime offset 324, flags 0x1
    private bool aimCanceled;
    // method 30081, 0x600018a
    void OnEnable();
    // method 30082, 0x600018b
    void Aim();
    // method 30083, 0x600018c
    void StopAim();
    // method 30084, 0x600018d
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 30085, 0x600018e
    System.Collections.IEnumerator IenuAftershots(bool is2DSound);
    // method 30086, 0x600018f
    void .ctor();
    // method 30087, 0x6000190
    void <OnEnable>b__11_0();
    // method 30088, 0x6000191
    bool <Aim>g__AnimatorHasState|12_0(UnityEngine.Animator animator, string stateName);
    // method 30089, 0x6000192
    void <Aim>b__12_1();
    // method 30090, 0x6000193
    void <StopAim>b__13_0();
}

// TypeDefinition 3993, 0x200004a
class DiscordWebhookType : System.Enum {
    // field 16379, runtime offset 8, flags 0x606
    public int value__;
    // field 16380, runtime offset 0, flags 0x8056
    public static const DiscordWebhookType ReportBug = 0;
    // field 16381, runtime offset 0, flags 0x8056
    public static const DiscordWebhookType Matchmaker = 1;
}

// TypeDefinition 3994, 0x200004b
class WebhookPayload : object {
    // field 16382, runtime offset 8, flags 0x6
    public string content;
    // method 30149, 0x60001ce
    void .ctor();
}

// TypeDefinition 3995, 0x200004c
class <>c : object {
    // field 16383, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16384, runtime offset 4, flags 0x16
    public static System.Action <>9__47_0;
    // field 16385, runtime offset 8, flags 0x16
    public static System.Action <>9__47_1;
    // field 16386, runtime offset 12, flags 0x16
    public static System.Action<string> <>9__48_0;
    // method 30150, 0x60001cf
    void .cctor();
    // method 30151, 0x60001d0
    void .ctor();
    // method 30152, 0x60001d1
    void <OnNewVersionDetected>b__47_0();
    // method 30153, 0x60001d2
    void <OnNewVersionDetected>b__47_1();
    // method 30154, 0x60001d3
    void <SuperSlowUpdate>b__48_0(string result);
}

// TypeDefinition 3996, 0x200004d
class <>c__DisplayClass24_0 : object {
    // field 16387, runtime offset 8, flags 0x6
    public System.Action<string> setCallback;
    // field 16388, runtime offset 12, flags 0x6
    public AlltimeUIManager <>4__this;
    // field 16389, runtime offset 16, flags 0x6
    public int amountTotal;
    // field 16390, runtime offset 20, flags 0x6
    public int rewardToGive;
    // field 16391, runtime offset 24, flags 0x6
    public int currentCoins;
    // field 16392, runtime offset 28, flags 0x6
    public System.Action <>9__1;
    // method 30155, 0x60001d4
    void .ctor();
    // method 30156, 0x60001d5
    void <GiveCoins>b__0(string x);
    // method 30157, 0x60001d6
    void <GiveCoins>b__1();
}

// TypeDefinition 3997, 0x200004e
class <>c__DisplayClass50_0 : object {
    // field 16393, runtime offset 8, flags 0x6
    public AlltimeUIManager <>4__this;
    // field 16394, runtime offset 12, flags 0x6
    public UnityEngine.RenderTexture withRT;
    // field 16395, runtime offset 16, flags 0x6
    public System.Action<int, WeaponClass> onClassChosen;
    // method 30158, 0x60001d7
    void .ctor();
    // method 30159, 0x60001d8
    void <ChangeClass>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 3998, 0x200004f
class <>c__DisplayClass52_0 : object {
    // field 16396, runtime offset 8, flags 0x6
    public AlltimeUIManager <>4__this;
    // field 16397, runtime offset 12, flags 0x6
    public System.Action<string> _onGameModeChosen;
    // method 30160, 0x60001d9
    void .ctor();
    // method 30161, 0x60001da
    void <ChangeGameMode>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 3999, 0x2000050
class <>c__DisplayClass63_0 : object {
    // field 16398, runtime offset 8, flags 0x6
    public System.Action then;
    // field 16399, runtime offset 12, flags 0x6
    public AlltimeUIManager <>4__this;
    // method 30162, 0x60001db
    void .ctor();
    // method 30163, 0x60001dc
    void <SetLoadingTransition>b__0();
    // method 30164, 0x60001dd
    void <SetLoadingTransition>b__1();
}

// TypeDefinition 4000, 0x2000051
class <>c__DisplayClass66_0 : object {
    // field 16400, runtime offset 8, flags 0x6
    public TMPro.TMP_InputField tmpF;
    // field 16401, runtime offset 12, flags 0x6
    public UnityEngine.UI.InputField IF;
    // method 30165, 0x60001de
    void .ctor();
    // method 30166, 0x60001df
    void <OnPaste>b__0(string x);
    // method 30167, 0x60001e0
    void <OnPaste>b__1(string x);
}

// TypeDefinition 4001, 0x2000052
class <IenuDownloadAndSetImage>d__29 : object {
    // field 16402, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16403, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16404, runtime offset 16, flags 0x6
    public string url;
    // field 16405, runtime offset 20, flags 0x6
    public UnityEngine.UI.RawImage[] rawImgs;
    // field 16406, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 30168, 0x60001e1
    void .ctor(int <>1__state);
    // method 30169, 0x60001e2
    void System.IDisposable.Dispose();
    // method 30170, 0x60001e3
    bool MoveNext();
    // method 30171, 0x60001e4
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30172, 0x60001e5
    void System.Collections.IEnumerator.Reset();
    // method 30173, 0x60001e6
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4002, 0x2000053
class <IenuHide>d__32 : object {
    // field 16407, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16408, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16409, runtime offset 16, flags 0x6
    public NotificationContainer who;
    // method 30174, 0x60001e7
    void .ctor(int <>1__state);
    // method 30175, 0x60001e8
    void System.IDisposable.Dispose();
    // method 30176, 0x60001e9
    bool MoveNext();
    // method 30177, 0x60001ea
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30178, 0x60001eb
    void System.Collections.IEnumerator.Reset();
    // method 30179, 0x60001ec
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4003, 0x2000054
class <IenuShowAttractedObjects>d__26 : object {
    // field 16410, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16411, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16412, runtime offset 16, flags 0x6
    public int howMany;
    // field 16413, runtime offset 20, flags 0x6
    public AttractedMovement prefab;
    // field 16414, runtime offset 24, flags 0x6
    public AlltimeUIManager <>4__this;
    // field 16415, runtime offset 28, flags 0x6
    public UnityEngine.RectTransform attractor;
    // field 16416, runtime offset 32, flags 0x6
    public System.Action itemCall;
    // field 16417, runtime offset 36, flags 0x1
    private int <startHowMany>5__2;
    // method 30180, 0x60001ed
    void .ctor(int <>1__state);
    // method 30181, 0x60001ee
    void System.IDisposable.Dispose();
    // method 30182, 0x60001ef
    bool MoveNext();
    // method 30183, 0x60001f0
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30184, 0x60001f1
    void System.Collections.IEnumerator.Reset();
    // method 30185, 0x60001f2
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4004, 0x2000055
class <IenuShowBreathingCircleCToCancel>d__65 : object {
    // field 16418, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16419, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16420, runtime offset 16, flags 0x6
    public AlltimeUIManager <>4__this;
    // method 30186, 0x60001f3
    void .ctor(int <>1__state);
    // method 30187, 0x60001f4
    void System.IDisposable.Dispose();
    // method 30188, 0x60001f5
    bool MoveNext();
    // method 30189, 0x60001f6
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30190, 0x60001f7
    void System.Collections.IEnumerator.Reset();
    // method 30191, 0x60001f8
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4005, 0x2000056
class <PostRequestDiscord>d__7 : object {
    // field 16421, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16422, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16423, runtime offset 16, flags 0x6
    public DiscordWebhookType type;
    // field 16424, runtime offset 20, flags 0x6
    public string message;
    // field 16425, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 30192, 0x60001f9
    void .ctor(int <>1__state);
    // method 30193, 0x60001fa
    void System.IDisposable.Dispose();
    // method 30194, 0x60001fb
    bool MoveNext();
    // method 30195, 0x60001fc
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30196, 0x60001fd
    void System.Collections.IEnumerator.Reset();
    // method 30197, 0x60001fe
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4006, 0x2000049
class AlltimeUIManager : UnityEngine.MonoBehaviour {
    // field 16352, runtime offset 0, flags 0x8051
    private static const string ReportBugApiUrl = "https://kour.io/api/reportbug";
    // field 16353, runtime offset 0, flags 0x8051
    private static const string InviteDiscordApiUrl = "https://kour.io/api/invitediscord";
    // field 16354, runtime offset 0, flags 0x11
    private static bool ppvEnabled;
    // field 16355, runtime offset 1, flags 0x16
    public static bool dialogsEnabled;
    // field 16356, runtime offset 16, flags 0x1
    private MyFriendList myFriendList;
    // field 16357, runtime offset 20, flags 0x6
    public FriendInvitePopup friendInvitePopup;
    // field 16358, runtime offset 24, flags 0x1
    private UnityEngine.GameObject breathingCircleCToCancel;
    // field 16359, runtime offset 28, flags 0x1
    private AttractedMovement attractedCoinPrefab;
    // field 16360, runtime offset 32, flags 0x1
    private TMPro.TMP_Text loadingTransitionTxt;
    // field 16361, runtime offset 36, flags 0x1
    private UnityEngine.RectTransform loadingTransitionBarFill;
    // field 16362, runtime offset 40, flags 0x1
    private NotificationContainer[] errorNotifications;
    // field 16363, runtime offset 44, flags 0x6
    public UnityEngine.Canvas alltimeCanvas;
    // field 16364, runtime offset 48, flags 0x6
    public TMPro.TMP_Text dialogTxt;
    // field 16365, runtime offset 52, flags 0x6
    public TMPro.TMP_Text dialogTitleTxt;
    // field 16366, runtime offset 56, flags 0x6
    public Popup dialogPopup;
    // field 16367, runtime offset 60, flags 0x1
    private System.Action[] currentDialogCalls;
    // field 16368, runtime offset 4, flags 0x16
    public static AlltimeUIManager instance;
    // field 16369, runtime offset 64, flags 0x1
    private ClassSelectPanel classSelectPanel;
    // field 16370, runtime offset 68, flags 0x1
    private GameModeSelectPanel gameModeSelectPanel;
    // field 16371, runtime offset 0, flags 0x8051
    private static const int SUPER_SLOW_UPDATE_RATE = 180;
    // field 16372, runtime offset 72, flags 0x1
    private System.Action<string> onGameModeChosen;
    // field 16373, runtime offset 76, flags 0x1
    private ItemInspectPanel itemInspectPanel;
    // field 16374, runtime offset 80, flags 0x1
    private CasePanel casePanel;
    // field 16375, runtime offset 84, flags 0x6
    public UnityEngine.CanvasGroup loadingPanel;
    // field 16376, runtime offset 88, flags 0x1
    private UnityEngine.Coroutine showBreathingCircleCToCancelCoroutine;
    // field 16377, runtime offset 92, flags 0x1
    private UnityEngine.Sprite[] mapSprites;
    // field 16378, runtime offset 96, flags 0x1
    private ProfilePictures profilePictures;
    // method 30097, 0x600019a
    string ReportBug(string messageWithQuotes);
    // method 30098, 0x600019b
    string GetLastDebugLogs();
    // method 30099, 0x600019c
    string GetCustomProperties();
    // method 30100, 0x600019d
    void DiscordWebhook(string message, DiscordWebhookType type);
    // method 30101, 0x600019e
    System.Collections.IEnumerator PostRequestDiscord(string message, DiscordWebhookType type);
    // method 30102, 0x600019f
    string GetAuthToken();
    // method 30103, 0x60001a0
    void postProcessing(bool enable);
    // method 30104, 0x60001a1
    void RefreshPPV();
    // method 30105, 0x60001a2
    void OnDetectedCheats(string reason);
    // method 30106, 0x60001a3
    void ShowMyFriendList();
    // method 30107, 0x60001a4
    void OnApplicationFocus(bool focus);
    // method 30108, 0x60001a5
    bool CToCancelTextActive();
    // method 30109, 0x60001a6
    void GiveCoins(int amountTotal, System.Action<string> setCallback);
    // method 30110, 0x60001a7
    void ShowAttractedCoins(int howMany, UnityEngine.RectTransform _coinAttractor, System.Action itemCall);
    // method 30111, 0x60001a8
    System.Collections.IEnumerator IenuShowAttractedObjects(int howMany, AttractedMovement prefab, UnityEngine.RectTransform attractor, System.Action itemCall);
    // method 30112, 0x60001a9
    void DownloadAndSetImage(string url, UnityEngine.UI.RawImage[] rawImgs);
    // method 30113, 0x60001aa
    void InstanceDownloadAndSetImage(string url, UnityEngine.UI.RawImage[] rawImgs);
    // method 30114, 0x60001ab
    System.Collections.IEnumerator IenuDownloadAndSetImage(UnityEngine.UI.RawImage[] rawImgs, string url);
    // method 30115, 0x60001ac
    void ShowErrorNotification(string message, bool isError);
    // method 30116, 0x60001ad
    System.Collections.IEnumerator IenuHide(NotificationContainer who);
    // method 30117, 0x60001ae
    void OnClanDataChanged();
    // method 30118, 0x60001af
    void OnGotClipboard(string clipboard);
    // method 30119, 0x60001b0
    void Awake();
    // method 30120, 0x60001b1
    void Start();
    // method 30121, 0x60001b2
    void ObscuredCheatingDetectorOnDetectedCheats();
    // method 30122, 0x60001b3
    void OnNewVersionDetected(string newVersion);
    // method 30123, 0x60001b4
    void SuperSlowUpdate();
    // method 30124, 0x60001b5
    void SlowUpdate();
    // method 30125, 0x60001b6
    void ChangeClass(UnityEngine.RenderTexture withRT, System.Action<int, WeaponClass> onClassChosen);
    // method 30126, 0x60001b7
    void ChangeGameMode(System.Action<string> _onGameModeChosen);
    // method 30127, 0x60001b8
    void SetGameMode(string gameModeName);
    // method 30128, 0x60001b9
    void OpenCase(CaseData data);
    // method 30129, 0x60001ba
    void InspectItem(Item item, string customTitle, System.Action onClose, System.Action onPurchased, CaseData fromCaseData);
    // method 30130, 0x60001bb
    void InspectItem(Weapon weapon, string customTitle, System.Action onClose, System.Action onPurchased, CaseData fromCaseData);
    // method 30131, 0x60001bc
    void Dialog(string title, string message, System.Action onPositive, System.Action onNegative);
    // method 30132, 0x60001bd
    void DialogButtonClicked(bool isPositive);
    // method 30133, 0x60001be
    void UpdateLoadingTransitionTxt(string newText, float progressNormalized100);
    // method 30134, 0x60001bf
    void SetLoadingTransition(string currentTask, bool isLoading, System.Action then, float duration);
    // method 30135, 0x60001c0
    System.Collections.IEnumerator IenuShowBreathingCircleCToCancel();
    // method 30136, 0x60001c1
    void OnPaste();
    // method 30137, 0x60001c2
    string LimitStringCharacters(string inputString, int characterLimit);
    // method 30138, 0x60001c3
    string SceneNameFromBuildIndex(object index);
    // method 30139, 0x60001c4
    int BuildIndexFromSceneName(string selectedMapName);
    // method 30140, 0x60001c5
    void ShowMessageCustom(string what);
    // method 30141, 0x60001c6
    UnityEngine.Sprite SceneSpriteFromBuildIndex(int index);
    // method 30142, 0x60001c7
    string GetProfilePictureOnIndex(int index, int backgroundIndex, out UnityEngine.Color c);
    // method 30143, 0x60001c8
    void .ctor();
    // method 30144, 0x60001c9
    void .cctor();
    // method 30145, 0x60001ca
    void <OnNewVersionDetected>g__RequestNewVersion|47_2();
    // method 30146, 0x60001cb
    void <SetGameMode>b__53_0();
    // method 30147, 0x60001cc
    void <Dialog>b__59_0();
    // method 30148, 0x60001cd
    void <DialogButtonClicked>b__60_0();
}

// TypeDefinition 4007, 0x2000057
class AlphaTestMinThreshholdModifier : UnityEngine.MonoBehaviour {
    // method 30198, 0x60001ff
    void Start();
    // method 30199, 0x6000200
    void .ctor();
}

// TypeDefinition 4008, 0x2000059
class <PostEvent>d__6 : object {
    // field 16429, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16430, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16431, runtime offset 16, flags 0x6
    public string eventName;
    // field 16432, runtime offset 20, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 30205, 0x6000206
    void .ctor(int <>1__state);
    // method 30206, 0x6000207
    void System.IDisposable.Dispose();
    // method 30207, 0x6000208
    bool MoveNext();
    // method 30208, 0x6000209
    void <>m__Finally1();
    // method 30209, 0x600020a
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30210, 0x600020b
    void System.Collections.IEnumerator.Reset();
    // method 30211, 0x600020c
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4009, 0x2000058
class AnalyticsManager : UnityEngine.MonoBehaviour {
    // field 16426, runtime offset 16, flags 0x1
    private System.Collections.Generic.List<string> reportedEvents;
    // field 16427, runtime offset 0, flags 0x16
    public static AnalyticsManager instance;
    // field 16428, runtime offset 0, flags 0x8051
    private static const string analyticsUrl = "https://kour.io/api/track";
    // method 30200, 0x6000201
    void Awake();
    // method 30201, 0x6000202
    void ReportEvent(string eventName, bool oncePerSession);
    // method 30202, 0x6000203
    void InstanceReportEvent(string eventName, bool oncePerSession);
    // method 30203, 0x6000204
    System.Collections.IEnumerator PostEvent(string eventName);
    // method 30204, 0x6000205
    void .ctor();
}

// TypeDefinition 4010, 0x200005b
class <>c__DisplayClass3_0 : object {
    // field 16436, runtime offset 8, flags 0x6
    public UnityEngine.RectTransform rectTransform;
    // field 16437, runtime offset 12, flags 0x6
    public UnityEngine.Vector2 from;
    // method 30214, 0x600020f
    void .ctor();
    // method 30215, 0x6000210
    UnityEngine.Vector2 <Start>b__0();
    // method 30216, 0x6000211
    void <Start>b__1(UnityEngine.Vector2 x);
    // method 30217, 0x6000212
    void <Start>b__2();
}

// TypeDefinition 4011, 0x200005a
class AnchorPosAnimationLoopBackground : UnityEngine.MonoBehaviour {
    // field 16433, runtime offset 16, flags 0x1
    private UnityEngine.Vector2 to;
    // field 16434, runtime offset 24, flags 0x1
    private DG.Tweening.Ease ease;
    // field 16435, runtime offset 28, flags 0x1
    private float duration;
    // method 30212, 0x600020d
    void Start();
    // method 30213, 0x600020e
    void .ctor();
}

// TypeDefinition 4012, 0x200005d
class <III>d__11 : object {
    // field 16444, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16445, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16446, runtime offset 16, flags 0x6
    public AnimatedButton <>4__this;
    // method 30226, 0x600021b
    void .ctor(int <>1__state);
    // method 30227, 0x600021c
    void System.IDisposable.Dispose();
    // method 30228, 0x600021d
    bool MoveNext();
    // method 30229, 0x600021e
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30230, 0x600021f
    void System.Collections.IEnumerator.Reset();
    // method 30231, 0x6000220
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4013, 0x200005c
class AnimatedButton : UnityEngine.MonoBehaviour {
    // field 16438, runtime offset 16, flags 0x1
    private bool ignoreAnimations;
    // field 16439, runtime offset 20, flags 0x1
    private UnityEngine.Color originalColor;
    // field 16440, runtime offset 36, flags 0x1
    private UnityEngine.Color originalColor2;
    // field 16441, runtime offset 52, flags 0x1
    private UnityEngine.UI.Image img;
    // field 16442, runtime offset 56, flags 0x1
    private UnityEngine.UI.Image img2;
    // field 16443, runtime offset 60, flags 0x1
    private bool pointerInside;
    // method 30218, 0x6000213
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30219, 0x6000214
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30220, 0x6000215
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30221, 0x6000216
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30222, 0x6000217
    void OnEnable();
    // method 30223, 0x6000218
    System.Collections.IEnumerator III();
    // method 30224, 0x6000219
    void OnDisable();
    // method 30225, 0x600021a
    void .ctor();
}

// TypeDefinition 4014, 0x200005e
class AttractedMovement : UnityEngine.MonoBehaviour {
    // field 16447, runtime offset 16, flags 0x6
    public string startSoundName;
    // field 16448, runtime offset 20, flags 0x6
    public string endSoundName;
    // field 16449, runtime offset 24, flags 0x6
    public System.Action callOnDone;
    // field 16450, runtime offset 28, flags 0x6
    public UnityEngine.Transform attractor;
    // field 16451, runtime offset 32, flags 0x6
    public float speed;
    // field 16452, runtime offset 36, flags 0x6
    public float curveHeight;
    // field 16453, runtime offset 40, flags 0x1
    private float journeyLength;
    // field 16454, runtime offset 44, flags 0x1
    private float startTime;
    // field 16455, runtime offset 48, flags 0x6
    public float pitch;
    // method 30232, 0x6000221
    void Start();
    // method 30233, 0x6000222
    void Update();
    // method 30234, 0x6000223
    UnityEngine.Vector3 CalculateBezierPoint(float t, UnityEngine.Vector3 p0, UnityEngine.Vector3 p1, UnityEngine.Vector3 p2);
    // method 30235, 0x6000224
    void .ctor();
}

// TypeDefinition 4015, 0x2000060
class Sound : object {
    // field 16459, runtime offset 8, flags 0x6
    public string name;
    // field 16460, runtime offset 12, flags 0x6
    public UnityEngine.AudioClip clip;
    // field 16461, runtime offset 16, flags 0x6
    public float volume;
    // field 16462, runtime offset 20, flags 0x6
    public float pitch;
    // field 16463, runtime offset 24, flags 0x6
    public bool loop;
    // field 16464, runtime offset 28, flags 0x6
    public UnityEngine.AudioSource source;
    // method 30247, 0x6000230
    void .ctor();
}

// TypeDefinition 4016, 0x2000061
class <>c__DisplayClass7_0 : object {
    // field 16465, runtime offset 8, flags 0x6
    public string name;
    // method 30248, 0x6000231
    void .ctor();
    // method 30249, 0x6000232
    bool <PlaySound>b__0(Sound s);
}

// TypeDefinition 4017, 0x2000062
class <>c__DisplayClass9_0 : object {
    // field 16466, runtime offset 8, flags 0x6
    public string name;
    // method 30250, 0x6000233
    void .ctor();
    // method 30251, 0x6000234
    bool <StopSound>b__0(Sound s);
}

// TypeDefinition 4018, 0x2000063
class <LoadSoundsCoroutine>d__5 : object {
    // field 16467, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16468, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16469, runtime offset 16, flags 0x6
    public AudioManager <>4__this;
    // field 16470, runtime offset 20, flags 0x1
    private int <i>5__2;
    // method 30252, 0x6000235
    void .ctor(int <>1__state);
    // method 30253, 0x6000236
    void System.IDisposable.Dispose();
    // method 30254, 0x6000237
    bool MoveNext();
    // method 30255, 0x6000238
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30256, 0x6000239
    void System.Collections.IEnumerator.Reset();
    // method 30257, 0x600023a
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4019, 0x2000064
class <PlayDelayedSound>d__11 : object {
    // field 16471, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16472, runtime offset 12, flags 0x1
    private UnityEngine.WaitForSeconds <>2__current;
    // field 16473, runtime offset 16, flags 0x6
    public float delay;
    // field 16474, runtime offset 20, flags 0x6
    public AudioManager <>4__this;
    // field 16475, runtime offset 24, flags 0x6
    public string name;
    // method 30258, 0x600023b
    void .ctor(int <>1__state);
    // method 30259, 0x600023c
    void System.IDisposable.Dispose();
    // method 30260, 0x600023d
    bool MoveNext();
    // method 30261, 0x600023e
    UnityEngine.WaitForSeconds System.Collections.Generic.IEnumerator<UnityEngine.WaitForSeconds>.get_Current();
    // method 30262, 0x600023f
    void System.Collections.IEnumerator.Reset();
    // method 30263, 0x6000240
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4020, 0x200005f
class AudioManager : UnityEngine.MonoBehaviour {
    // field 16456, runtime offset 0, flags 0x16
    public static AudioManager instance;
    // field 16457, runtime offset 16, flags 0x6
    public UnityEngine.Audio.AudioMixerGroup mixerGroup;
    // field 16458, runtime offset 20, flags 0x6
    public System.Collections.Generic.List<Sound> sounds;
    // method 30236, 0x6000225
    void Start();
    // method 30237, 0x6000226
    System.Collections.IEnumerator LoadSoundsCoroutine();
    // method 30238, 0x6000227
    void PlaySound(string name);
    // method 30239, 0x6000228
    void PlaySound(string name, float pitch);
    // method 30240, 0x6000229
    void PlayRandomSound(string[] names);
    // method 30241, 0x600022a
    void StopSound(string name);
    // method 30242, 0x600022b
    void PlaySoundWithDelay(string name, float delay);
    // method 30243, 0x600022c
    System.Collections.Generic.IEnumerator<UnityEngine.WaitForSeconds> PlayDelayedSound(string name, float delay);
    // method 30244, 0x600022d
    void PlayRandomSoundFromArray(UnityEngine.AudioClip[] clips, UnityEngine.Vector3 position, float volume, float pitch);
    // method 30245, 0x600022e
    void PlaySoundAtPosition(UnityEngine.AudioClip clip, UnityEngine.Vector3 position, float volume, float pitch);
    // method 30246, 0x600022f
    void .ctor();
}

// TypeDefinition 4021, 0x2000065
class AudioSourceRefferer : UnityEngine.MonoBehaviour {
    // field 16476, runtime offset 16, flags 0x1
    private string soundName;
    // field 16477, runtime offset 20, flags 0x1
    private bool playOnEnable;
    // method 30264, 0x6000241
    void OnEnable();
    // method 30265, 0x6000242
    void Play();
    // method 30266, 0x6000243
    void .ctor();
}

// TypeDefinition 4022, 0x2000066
class AudioToIncludeInBuildFixWorkaround : UnityEngine.MonoBehaviour {
    // field 16478, runtime offset 0, flags 0x16
    public static AudioToIncludeInBuildFixWorkaround instance;
    // field 16479, runtime offset 16, flags 0x6
    public UnityEngine.AudioClip[] preloads;
    // method 30267, 0x6000244
    void Awake();
    // method 30268, 0x6000245
    void Start();
    // method 30269, 0x6000246
    void Never();
    // method 30270, 0x6000247
    void .ctor();
}

// TypeDefinition 4023, 0x2000067
class BRCaseData : UnityEngine.ScriptableObject {
    // field 16480, runtime offset 12, flags 0x6
    public BRCaseItemData[] items;
    // method 30271, 0x6000248
    float TotalWeight();
    // method 30272, 0x6000249
    BRCaseItemData GenerateRandomItem(int withSeed);
    // method 30273, 0x600024a
    void .ctor();
}

// TypeDefinition 4024, 0x2000068
class BRCaseItemData : object {
    // field 16481, runtime offset 8, flags 0x6
    public float weight;
    // field 16482, runtime offset 12, flags 0x6
    public Weapon weapon;
    // field 16483, runtime offset 16, flags 0x6
    public int currentAmmo;
    // method 30274, 0x600024b
    void .ctor();
}

// TypeDefinition 4025, 0x200006a
class <>c__DisplayClass15_0 : object {
    // field 16493, runtime offset 8, flags 0x6
    public BRChest <>4__this;
    // field 16494, runtime offset 12, flags 0x6
    public PickableWeapon pickableWeapon;
    // field 16495, runtime offset 16, flags 0x6
    public float dropAnimationDuration;
    // method 30283, 0x6000254
    void .ctor();
    // method 30284, 0x6000255
    void <Open>b__0();
    // method 30285, 0x6000256
    void <Open>b__1();
}

// TypeDefinition 4026, 0x2000069
class BRChest : UnityEngine.MonoBehaviour {
    // field 16484, runtime offset 16, flags 0x1
    private UnityEngine.AudioSource staticSoundSource;
    // field 16485, runtime offset 20, flags 0x1
    private UnityEngine.AudioSource openSource;
    // field 16486, runtime offset 24, flags 0x1
    private UnityEngine.Transform pickableWeaponParent;
    // field 16487, runtime offset 28, flags 0x1
    private PickableWeapon pickableWeaponPrefab;
    // field 16488, runtime offset 32, flags 0x1
    private BRCaseData data;
    // field 16489, runtime offset 0, flags 0x8051
    private static const byte openChestEventCode = 6;
    // field 16490, runtime offset 0, flags 0x16
    public static BRChest current;
    // field 16491, runtime offset 36, flags 0x1
    private UnityEngine.Transform gfxTop;
    // field 16492, runtime offset 40, flags 0x1
    private bool opened;
    // method 30275, 0x600024c
    int get_id();
    // method 30276, 0x600024d
    void OnEnable();
    // method 30277, 0x600024e
    void OnDisable();
    // method 30278, 0x600024f
    void Update();
    // method 30279, 0x6000250
    void TryOpenCurrent();
    // method 30280, 0x6000251
    void Open(int withSeed);
    // method 30281, 0x6000252
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 30282, 0x6000253
    void .ctor();
}

// TypeDefinition 4027, 0x200006c
class <>c : object {
    // field 16516, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16517, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__23_2;
    // field 16518, runtime offset 8, flags 0x16
    public static DG.Tweening.TweenCallback <>9__23_1;
    // method 30292, 0x600025d
    void .cctor();
    // method 30293, 0x600025e
    void .ctor();
    // method 30294, 0x600025f
    void <Init>b__23_1();
    // method 30295, 0x6000260
    void <Init>b__23_2();
}

// TypeDefinition 4028, 0x200006b
class BackInCanvas : UnityEngine.MonoBehaviour {
    // field 16496, runtime offset 16, flags 0x1
    private UnityEngine.GameObject respawnButton;
    // field 16497, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image timerFill;
    // field 16498, runtime offset 24, flags 0x1
    private TMPro.TMP_Text timerTxt;
    // field 16499, runtime offset 28, flags 0x1
    private UnityEngine.GameObject respawnImg;
    // field 16500, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image rankImg;
    // field 16501, runtime offset 36, flags 0x6
    public TMPro.TMP_Text backInTxt;
    // field 16502, runtime offset 40, flags 0x6
    public TMPro.TMP_Text byUsernameTxt;
    // field 16503, runtime offset 44, flags 0x6
    public UnityEngine.UI.Image byUserClassImg;
    // field 16504, runtime offset 48, flags 0x1
    private UnityEngine.GameObject changeClassPanel;
    // field 16505, runtime offset 52, flags 0x1
    private TMPro.TMP_Text changeClassTxt;
    // field 16506, runtime offset 56, flags 0x1
    private TMPro.TMP_Text pressSpaceTxt;
    // field 16507, runtime offset 60, flags 0x1
    private UnityEngine.UI.Image changeClassImage;
    // field 16508, runtime offset 64, flags 0x1
    private UnityEngine.CanvasGroup changeClassTick;
    // field 16509, runtime offset 68, flags 0x1
    private WeaponClass currentChangeToClass;
    // field 16510, runtime offset 72, flags 0x1
    private int currentChangeToClassIndex;
    // field 16511, runtime offset 76, flags 0x1
    private int xpToGiveOnClassChange;
    // field 16512, runtime offset 80, flags 0x1
    private bool haveSetClass;
    // field 16513, runtime offset 84, flags 0x1
    private float initTime;
    // field 16514, runtime offset 88, flags 0x1
    private System.Action onRespawnButtonPressed;
    // field 16515, runtime offset 0, flags 0x16
    public static BackInCanvas instance;
    // method 30286, 0x6000257
    void Update();
    // method 30287, 0x6000258
    void RespawnButtonPressed();
    // method 30288, 0x6000259
    void SimulateY();
    // method 30289, 0x600025a
    void Init(Photon.Realtime.Player killer, string killerNickName, string scoreReceived, int classUsed, System.Action _onRespawnButtonPressed);
    // method 30290, 0x600025b
    void .ctor();
    // method 30291, 0x600025c
    void <Init>b__23_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4029, 0x200006d
class Ball : Photon.Pun.MonoBehaviourPun {
    // field 16519, runtime offset 20, flags 0x1
    private UnityEngine.Rigidbody rb;
    // method 30296, 0x6000261
    void OnGotShot(UnityEngine.Vector3 hitPos, UnityEngine.Vector3 shootDirection);
    // method 30297, 0x6000262
    void .ctor();
}

// TypeDefinition 4030, 0x200006e
class BattleRoyaleBackInCanvas : UnityEngine.MonoBehaviour {
    // field 16520, runtime offset 16, flags 0x1
    private UnityEngine.GameObject spectatingPanel;
    // field 16521, runtime offset 20, flags 0x6
    public TMPro.TMP_Text spectatingTxt;
    // field 16522, runtime offset 24, flags 0x6
    public TMPro.TMP_Text damageTxt;
    // field 16523, runtime offset 28, flags 0x6
    public TMPro.TMP_Text byUsernameTxt;
    // field 16524, runtime offset 32, flags 0x6
    public UnityEngine.UI.Image byUserClassImg;
    // field 16525, runtime offset 36, flags 0x1
    private System.Action<int> onChangeSpectator;
    // method 30298, 0x6000263
    void ChangeSpectator(int move);
    // method 30299, 0x6000264
    void Init(string killerNickName, string scoreReceived, int classUsed, System.Action<int> _onChangeSpectator);
    // method 30300, 0x6000265
    void UpdateSpectatingText(string killerNickName);
    // method 30301, 0x6000266
    void OnRoundEnded();
    // method 30302, 0x6000267
    void LeaveGame();
    // method 30303, 0x6000268
    void .ctor();
    // method 30304, 0x6000269
    void <Init>b__7_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4031, 0x200006f
class BattleRoyaleDeadCamera : UnityEngine.MonoBehaviour {
    // field 16526, runtime offset 16, flags 0x1
    private UnityEngine.Camera myCamera;
    // field 16527, runtime offset 20, flags 0x1
    private UnityEngine.Transform _spectate;
    // field 16528, runtime offset 24, flags 0x1
    private BattleRoyaleBackInCanvas backInCanvas;
    // field 16529, runtime offset 28, flags 0x1
    private float lastChangeSpectatorTime;
    // method 30305, 0x600026a
    UnityEngine.Transform get_spectate();
    // method 30306, 0x600026b
    void set_spectate(UnityEngine.Transform value);
    // method 30307, 0x600026c
    void Init(string hitTagName, BattleRoyaleBackInCanvas BattleRoyaleBackInCanvas, Photon.Realtime.Player killerPlayer, Shooter killer);
    // method 30308, 0x600026d
    void ChangeSpectator(int move);
    // method 30309, 0x600026e
    void SlowInvocation();
    // method 30310, 0x600026f
    void Update();
    // method 30311, 0x6000270
    void OnDestroy();
    // method 30312, 0x6000271
    void .ctor();
    // method 30313, 0x6000272
    void <Init>b__6_0();
}

// TypeDefinition 4032, 0x2000071
class GameState : System.Enum {
    // field 16555, runtime offset 8, flags 0x606
    public int value__;
    // field 16556, runtime offset 0, flags 0x8056
    public static const GameState WaitingForPlayers = 0;
    // field 16557, runtime offset 0, flags 0x8056
    public static const GameState GameRunning = 1;
    // field 16558, runtime offset 0, flags 0x8056
    public static const GameState GameOver = 2;
}

// TypeDefinition 4033, 0x2000072
class <>c__DisplayClass53_0 : object {
    // field 16559, runtime offset 8, flags 0x6
    public Photon.Pun.PhotonView pv;
    // method 30348, 0x6000295
    void .ctor();
    // method 30349, 0x6000296
    bool <OnPlayerDied>b__0(Shooter x);
}

// TypeDefinition 4034, 0x2000073
class <>c__DisplayClass54_0 : object {
    // field 16560, runtime offset 8, flags 0x6
    public UnityEngine.Rendering.PostProcessing.ColorGrading colorGrading;
    // method 30350, 0x6000297
    void .ctor();
    // method 30351, 0x6000298
    float <SetSaturation>b__0();
    // method 30352, 0x6000299
    void <SetSaturation>b__1(float x);
    // method 30353, 0x600029a
    float <SetSaturation>b__2();
    // method 30354, 0x600029b
    void <SetSaturation>b__3(float x);
    // method 30355, 0x600029c
    float <SetSaturation>b__4();
    // method 30356, 0x600029d
    void <SetSaturation>b__5(float x);
    // method 30357, 0x600029e
    float <SetSaturation>b__6();
    // method 30358, 0x600029f
    void <SetSaturation>b__7(float x);
}

// TypeDefinition 4035, 0x2000074
class <SendAliveMessageRoutine>d__44 : object {
    // field 16561, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16562, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16563, runtime offset 16, flags 0x1
    private ExitGames.Client.Photon.Hashtable <props>5__2;
    // method 30359, 0x60002a0
    void .ctor(int <>1__state);
    // method 30360, 0x60002a1
    void System.IDisposable.Dispose();
    // method 30361, 0x60002a2
    bool MoveNext();
    // method 30362, 0x60002a3
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30363, 0x60002a4
    void System.Collections.IEnumerator.Reset();
    // method 30364, 0x60002a5
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4036, 0x2000070
class BattleRoyaleManager : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 16530, runtime offset 20, flags 0x1
    private UnityEngine.GameObject clockIcon;
    // field 16531, runtime offset 24, flags 0x1
    private UnityEngine.GameObject inviteBtn;
    // field 16532, runtime offset 28, flags 0x1
    private TMPro.TMP_Text pplAliveTxt;
    // field 16533, runtime offset 32, flags 0x1
    private TMPro.TMP_Text killsTxt;
    // field 16534, runtime offset 36, flags 0x1
    private ZoneManager zoneManager;
    // field 16535, runtime offset 40, flags 0x1
    private UnityEngine.GameObject spawnTip;
    // field 16536, runtime offset 44, flags 0x1
    private TMPro.TMP_Text spawnTipTxt;
    // field 16537, runtime offset 48, flags 0x6
    public BusController busController;
    // field 16538, runtime offset 52, flags 0x6
    public UnityEngine.Transform cameraFallbackOrierntation;
    // field 16539, runtime offset 56, flags 0x1
    private DG.Tweening.Sequence notificationSequence;
    // field 16540, runtime offset 60, flags 0x1
    private UnityEngine.RectTransform notificationRectTransform;
    // field 16541, runtime offset 64, flags 0x1
    private TMPro.TMP_Text notificationTxt;
    // field 16542, runtime offset 68, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 16543, runtime offset 72, flags 0x1
    private UnityEngine.Transform minimapCamera;
    // field 16544, runtime offset 76, flags 0x1
    private TMPro.TMP_Text timerTxt;
    // field 16545, runtime offset 80, flags 0x6
    public bool gameStarted;
    // field 16546, runtime offset 0, flags 0x8051
    private static const int MIN_PLAYERS_FOR_START = 12;
    // field 16547, runtime offset 0, flags 0x16
    public static BattleRoyaleManager Instance;
    // field 16548, runtime offset 84, flags 0x6
    public GameState currentGameState;
    // field 16549, runtime offset 88, flags 0x1
    private double gameStartTime;
    // field 16550, runtime offset 96, flags 0x1
    private bool masterClientHasSentStartMesage;
    // field 16551, runtime offset 100, flags 0x6
    public string currentTimerText;
    // field 16552, runtime offset 104, flags 0x6
    public int totalKills;
    // field 16553, runtime offset 0, flags 0x8056
    public static const float DEFUSE_TIME = 6.5;
    // field 16554, runtime offset 108, flags 0x1
    private GameState previousState;
    // method 30314, 0x6000273
    string GetCurrentShownTip();
    // method 30315, 0x6000274
    void ShowTip(string x);
    // method 30316, 0x6000275
    void HideTip();
    // method 30317, 0x6000276
    void OnTipPressed();
    // method 30318, 0x6000277
    bool get_GameIsRunning();
    // method 30319, 0x6000278
    void UpdateAlivePlayerImages(int excludeActorNumber);
    // method 30320, 0x6000279
    void ShowNotification(string text);
    // method 30321, 0x600027a
    void UpdateMapCameraTransform(UnityEngine.Transform with);
    // method 30322, 0x600027b
    void OnJoinedRoom();
    // method 30323, 0x600027c
    void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 30324, 0x600027d
    void OnRoomPropsUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 30325, 0x600027e
    float get_START_AFTER_TIME();
    // method 30326, 0x600027f
    void set_START_AFTER_TIME(float value);
    // method 30327, 0x6000280
    double get_currentRoundTime();
    // method 30328, 0x6000281
    void Awake();
    // method 30329, 0x6000282
    void Start();
    // method 30330, 0x6000283
    void Update();
    // method 30331, 0x6000284
    System.Collections.IEnumerator SendAliveMessageRoutine();
    // method 30332, 0x6000285
    void StartGame(string reasonText);
    // method 30333, 0x6000286
    void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer);
    // method 30334, 0x6000287
    void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer);
    // method 30335, 0x6000288
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 30336, 0x6000289
    void SetGameState(string reasonForSet, GameState newState, object[] extraParams);
    // method 30337, 0x600028a
    void OnStateChanged(int state, string reason, object[] extraParams);
    // method 30338, 0x600028b
    void OnPlayerDied(Photon.Pun.PhotonView pv);
    // method 30339, 0x600028c
    void SetSaturation(bool isBuy, float inSeconds);
    // method 30340, 0x600028d
    void .ctor();
    // method 30341, 0x600028e
    void <ShowNotification>b__17_0();
    // method 30342, 0x600028f
    void <Start>b__39_0();
    // method 30343, 0x6000290
    void <Start>b__39_1();
    // method 30344, 0x6000291
    void <OnPlayerEnteredRoom>b__46_0();
    // method 30345, 0x6000292
    void <OnPlayerEnteredRoom>b__46_1();
    // method 30346, 0x6000293
    void <OnPlayerLeftRoom>b__47_0();
    // method 30347, 0x6000294
    void <OnPlayerLeftRoom>b__47_1();
}

// TypeDefinition 4037, 0x2000076
class <IenuPlant>d__8 : object {
    // field 16568, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16569, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16570, runtime offset 16, flags 0x6
    public Bomb <>4__this;
    // method 30372, 0x60002ad
    void .ctor(int <>1__state);
    // method 30373, 0x60002ae
    void System.IDisposable.Dispose();
    // method 30374, 0x60002af
    bool MoveNext();
    // method 30375, 0x60002b0
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30376, 0x60002b1
    void System.Collections.IEnumerator.Reset();
    // method 30377, 0x60002b2
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4038, 0x2000077
class <IenuPlantSounds>d__9 : object {
    // field 16571, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16572, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16573, runtime offset 16, flags 0x6
    public Bomb <>4__this;
    // field 16574, runtime offset 20, flags 0x1
    private int <totalPlayed>5__2;
    // method 30378, 0x60002b3
    void .ctor(int <>1__state);
    // method 30379, 0x60002b4
    void System.IDisposable.Dispose();
    // method 30380, 0x60002b5
    bool MoveNext();
    // method 30381, 0x60002b6
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30382, 0x60002b7
    void System.Collections.IEnumerator.Reset();
    // method 30383, 0x60002b8
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4039, 0x2000075
class Bomb : Weapon {
    // field 16564, runtime offset 252, flags 0x1
    private UnityEngine.Coroutine plantCoroutine;
    // field 16565, runtime offset 256, flags 0x1
    private UnityEngine.Coroutine plantCoroutine2;
    // field 16566, runtime offset 260, flags 0x6
    public bool isPlanting;
    // field 16567, runtime offset 264, flags 0x1
    private TMPro.TMP_Text c4text;
    // method 30365, 0x60002a6
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 30366, 0x60002a7
    void OnEnable();
    // method 30367, 0x60002a8
    void OnDisable();
    // method 30368, 0x60002a9
    void StopPlant();
    // method 30369, 0x60002aa
    System.Collections.IEnumerator IenuPlant();
    // method 30370, 0x60002ab
    System.Collections.IEnumerator IenuPlantSounds();
    // method 30371, 0x60002ac
    void .ctor();
}

// TypeDefinition 4040, 0x2000078
class BottomImageFxOpacityBasedOffColor : UnityEngine.MonoBehaviour {
    // field 16575, runtime offset 16, flags 0x1
    private TMPro.TMP_Text refText;
    // field 16576, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image sp;
    // method 30384, 0x60002b9
    void Update();
    // method 30385, 0x60002ba
    void .ctor();
}

// TypeDefinition 4041, 0x2000079
class Bullet : UnityEngine.MonoBehaviour {
    // field 16577, runtime offset 16, flags 0x6
    public bool allowDistanceDestroy;
    // field 16578, runtime offset 20, flags 0x6
    public UnityEngine.GameObject impactPrefab;
    // field 16579, runtime offset 24, flags 0x1
    private UnityEngine.Transform bulletGfx;
    // field 16580, runtime offset 28, flags 0x6
    public UnityEngine.TrailRenderer trailRenderer;
    // field 16581, runtime offset 32, flags 0x1
    private float initialSpeed;
    // field 16582, runtime offset 36, flags 0x1
    private float speed;
    // field 16583, runtime offset 40, flags 0x1
    private UnityEngine.AnimationCurve speedMultiCurve;
    // field 16584, runtime offset 44, flags 0x6
    public UnityEngine.Vector3 moveDir;
    // field 16585, runtime offset 56, flags 0x6
    public float lifeDistance;
    // field 16586, runtime offset 60, flags 0x1
    private float destroyDelay;
    // field 16587, runtime offset 64, flags 0x1
    private UnityEngine.GameObject[] visualsToHideInstant;
    // field 16588, runtime offset 68, flags 0x1
    private UnityEngine.Vector3 from;
    // field 16589, runtime offset 80, flags 0x1
    private bool stop;
    // field 16590, runtime offset 84, flags 0x1
    private float spawnTime;
    // field 16591, runtime offset 88, flags 0x1
    private UnityEngine.Vector3 initialGfxScale;
    // method 30386, 0x60002bb
    void OnEnable();
    // method 30387, 0x60002bc
    void Update();
    // method 30388, 0x60002bd
    void Des(float x);
    // method 30389, 0x60002be
    void Des_();
    // method 30390, 0x60002bf
    void .ctor();
}

// TypeDefinition 4042, 0x200007b
class <>c__DisplayClass7_0 : object {
    // field 16599, runtime offset 8, flags 0x6
    public GameBundle bundle;
    // method 30393, 0x60002c2
    void .ctor();
    // method 30394, 0x60002c3
    void <Init>b__0();
}

// TypeDefinition 4043, 0x200007a
class BundleFeatureWindow : UnityEngine.MonoBehaviour {
    // field 16592, runtime offset 16, flags 0x1
    private int overrideFeatureIndex;
    // field 16593, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image bundleImage;
    // field 16594, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image backgroundImage;
    // field 16595, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image leftGlowImage;
    // field 16596, runtime offset 32, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 16597, runtime offset 36, flags 0x1
    private TMPro.TMP_Text descriptionTxt;
    // field 16598, runtime offset 40, flags 0x1
    private UnityEngine.UI.Button button;
    // method 30391, 0x60002c0
    void Init(ShopPanel shopPanel);
    // method 30392, 0x60002c1
    void .ctor();
}

// TypeDefinition 4044, 0x200007d
class <>c : object {
    // field 16609, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16610, runtime offset 4, flags 0x16
    public static System.Action<Item, int> <>9__9_0;
    // method 30398, 0x60002c7
    void .cctor();
    // method 30399, 0x60002c8
    void .ctor();
    // method 30400, 0x60002c9
    void <Init>b__9_0(Item x, int y);
}

// TypeDefinition 4045, 0x200007c
class BundlePanel : Popup {
    // field 16600, runtime offset 68, flags 0x1
    private UnityEngine.UI.Image leftPanel;
    // field 16601, runtime offset 72, flags 0x1
    private UnityEngine.UI.Image backgroundImage;
    // field 16602, runtime offset 76, flags 0x1
    private UnityEngine.UI.Image vignetteImage;
    // field 16603, runtime offset 80, flags 0x1
    private UnityEngine.UI.Image bigRenderImage;
    // field 16604, runtime offset 84, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 16605, runtime offset 88, flags 0x1
    private TMPro.TMP_Text priceTxt;
    // field 16606, runtime offset 92, flags 0x1
    private TMPro.TMP_Text descriptionTxt;
    // field 16607, runtime offset 96, flags 0x1
    private ShopItemSlot[] itemSlots;
    // field 16608, runtime offset 100, flags 0x1
    private GameBundle myBundle;
    // method 30395, 0x60002c4
    void Init(GameBundle bundle);
    // method 30396, 0x60002c5
    void BuyPressed();
    // method 30397, 0x60002c6
    void .ctor();
}

// TypeDefinition 4046, 0x200007e
class BurstWeapon : Weapon {
    // field 16611, runtime offset 252, flags 0x6
    public int bulletRowAmount;
    // field 16612, runtime offset 256, flags 0x6
    public float bulletBurstFireRate;
    // method 30401, 0x60002ca
    void .ctor();
}

// TypeDefinition 4047, 0x200007f
class BusCameraController : UnityEngine.MonoBehaviour {
    // field 16613, runtime offset 16, flags 0x1
    private UnityEngine.Camera startAnimationCamera;
    // field 16614, runtime offset 20, flags 0x6
    public UnityEngine.Camera cam;
    // field 16615, runtime offset 24, flags 0x1
    private float xRotation;
    // field 16616, runtime offset 28, flags 0x1
    private float yRotation;
    // field 16617, runtime offset 32, flags 0x1
    private bool canRotate;
    // method 30402, 0x60002cb
    void OnEnable();
    // method 30403, 0x60002cc
    void Update();
    // method 30404, 0x60002cd
    void .ctor();
    // method 30405, 0x60002ce
    void <OnEnable>b__5_0();
}

// TypeDefinition 4048, 0x2000081
class <>c__DisplayClass12_0 : object {
    // field 16628, runtime offset 8, flags 0x6
    public UnityEngine.Rendering.PostProcessing.DepthOfField dof;
    // method 30412, 0x60002d5
    void .ctor();
    // method 30413, 0x60002d6
    void <SpawnPlayer>b__0(float x);
}

// TypeDefinition 4049, 0x2000080
class BusController : UnityEngine.MonoBehaviour {
    // field 16618, runtime offset 16, flags 0x1
    private UnityEngine.Rendering.PostProcessing.PostProcessVolume DOFPPV;
    // field 16619, runtime offset 0, flags 0x8051
    private static const float totalBusDriveTime = 40;
    // field 16620, runtime offset 0, flags 0x8051
    private static const float totalBusDriveDistance = 600;
    // field 16621, runtime offset 20, flags 0x1
    private UnityEngine.Transform bus;
    // field 16622, runtime offset 24, flags 0x1
    private UnityEngine.Transform playerSpawnPoint;
    // field 16623, runtime offset 28, flags 0x1
    private BusCameraController busCameraController;
    // field 16624, runtime offset 32, flags 0x1
    private double startedAtPhotonTime;
    // field 16625, runtime offset 40, flags 0x1
    private bool playerSpawned;
    // field 16626, runtime offset 41, flags 0x1
    private bool canSpawn;
    // field 16627, runtime offset 0, flags 0x16
    public static CameraConfig spawnCameraConfig;
    // method 30406, 0x60002cf
    void InitBus(double atPhotonTime, int randomSeed);
    // method 30407, 0x60002d0
    void Update();
    // method 30408, 0x60002d1
    void SpawnPlayer();
    // method 30409, 0x60002d2
    void SpawnButtonPressed();
    // method 30410, 0x60002d3
    void .ctor();
    // method 30411, 0x60002d4
    void <InitBus>b__10_0();
}

// TypeDefinition 4050, 0x2000082
class CameraConfig : System.ValueType {
    // field 16629, runtime offset 8, flags 0x6
    public UnityEngine.Vector3 position;
    // field 16630, runtime offset 20, flags 0x6
    public UnityEngine.Quaternion rotation;
    // field 16631, runtime offset 36, flags 0x6
    public float fov;
}

// TypeDefinition 4051, 0x2000083
class ButtonCallStaticFunction : UnityEngine.MonoBehaviour {
    // method 30414, 0x60002d7
    void Logout();
    // method 30415, 0x60002d8
    void .ctor();
}

// TypeDefinition 4052, 0x2000085
class <III>d__1 : object {
    // field 16632, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16633, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16634, runtime offset 16, flags 0x6
    public ButtonWithAnimator <>4__this;
    // method 30419, 0x60002dc
    void .ctor(int <>1__state);
    // method 30420, 0x60002dd
    void System.IDisposable.Dispose();
    // method 30421, 0x60002de
    bool MoveNext();
    // method 30422, 0x60002df
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30423, 0x60002e0
    void System.Collections.IEnumerator.Reset();
    // method 30424, 0x60002e1
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4053, 0x2000084
class ButtonWithAnimator : UnityEngine.MonoBehaviour {
    // method 30416, 0x60002d9
    void OnEnable();
    // method 30417, 0x60002da
    System.Collections.IEnumerator III();
    // method 30418, 0x60002db
    void .ctor();
}

// TypeDefinition 4054, 0x2000086
class BuyMenuItem : object {
    // field 16635, runtime offset 8, flags 0x6
    public int price;
    // field 16636, runtime offset 12, flags 0x6
    public Weapon weapon;
    // field 16637, runtime offset 16, flags 0x6
    public string overrideName;
    // field 16638, runtime offset 20, flags 0x6
    public UnityEngine.Sprite overrideSprite;
    // method 30425, 0x60002e2
    void .ctor();
}

// TypeDefinition 4055, 0x2000088
class BuyLayout : System.Enum {
    // field 16655, runtime offset 8, flags 0x606
    public int value__;
    // field 16656, runtime offset 0, flags 0x8056
    public static const BuyLayout Base = 0;
    // field 16657, runtime offset 0, flags 0x8056
    public static const BuyLayout Rifle = 1;
    // field 16658, runtime offset 0, flags 0x8056
    public static const BuyLayout SMG = 2;
    // field 16659, runtime offset 0, flags 0x8056
    public static const BuyLayout Heavy = 3;
    // field 16660, runtime offset 0, flags 0x8056
    public static const BuyLayout Pistol = 4;
    // field 16661, runtime offset 0, flags 0x8056
    public static const BuyLayout Grenade = 5;
    // field 16662, runtime offset 0, flags 0x8056
    public static const BuyLayout Extras = 6;
}

// TypeDefinition 4056, 0x2000089
class <>c__DisplayClass20_0 : object {
    // field 16663, runtime offset 8, flags 0x6
    public BuyMenuCanvas <>4__this;
    // field 16664, runtime offset 12, flags 0x6
    public bool disallowBuyingAll;
    // field 16665, runtime offset 16, flags 0x6
    public int useIndex;
    // field 16666, runtime offset 20, flags 0x6
    public BuyMenuItem[] useBuys;
    // method 30435, 0x60002ec
    void .ctor();
    // method 30436, 0x60002ed
    void <Init>b__0();
    // method 30437, 0x60002ee
    void <Init>b__1();
    // method 30438, 0x60002ef
    void <Init>b__2();
}

// TypeDefinition 4057, 0x200008a
class <>c__DisplayClass20_1 : object {
    // field 16667, runtime offset 8, flags 0x6
    public int i_;
    // field 16668, runtime offset 12, flags 0x6
    public <>c__DisplayClass20_0 CS$<>8__locals1;
    // method 30439, 0x60002f0
    void .ctor();
    // method 30440, 0x60002f1
    void <Init>b__3();
}

// TypeDefinition 4058, 0x200008b
class <>c__DisplayClass20_2 : object {
    // field 16669, runtime offset 8, flags 0x6
    public bool hasAlready;
    // field 16670, runtime offset 12, flags 0x6
    public int _i;
    // field 16671, runtime offset 16, flags 0x6
    public <>c__DisplayClass20_0 CS$<>8__locals2;
    // method 30441, 0x60002f2
    void .ctor();
    // method 30442, 0x60002f3
    void <Init>b__4();
}

// TypeDefinition 4059, 0x2000087
class BuyMenuCanvas : UnityEngine.MonoBehaviour {
    // field 16639, runtime offset 16, flags 0x1
    private UnityEngine.Sprite ctSprite;
    // field 16640, runtime offset 20, flags 0x1
    private UnityEngine.Sprite tSprite;
    // field 16641, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image teamColorImage;
    // field 16642, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image teamImage;
    // field 16643, runtime offset 32, flags 0x1
    private TMPro.TMP_Text moneyTxt;
    // field 16644, runtime offset 36, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 16645, runtime offset 40, flags 0x1
    private UnityEngine.GameObject goBackButton;
    // field 16646, runtime offset 44, flags 0x1
    private UnityEngine.UI.Button[] buttons;
    // field 16647, runtime offset 48, flags 0x1
    private BuyMenuItem[] baseBuys;
    // field 16648, runtime offset 52, flags 0x1
    private BuyMenuItem[] extraBuys;
    // field 16649, runtime offset 56, flags 0x1
    private BuyMenuItem[] rifleBuys;
    // field 16650, runtime offset 60, flags 0x1
    private BuyMenuItem[] pistolBuys;
    // field 16651, runtime offset 64, flags 0x1
    private BuyMenuItem[] heavyBuys;
    // field 16652, runtime offset 68, flags 0x1
    private BuyMenuItem[] smgBuys;
    // field 16653, runtime offset 72, flags 0x1
    private BuyMenuItem[] grenadeBuys;
    // field 16654, runtime offset 76, flags 0x1
    private BuyLayout currentLayout;
    // method 30426, 0x60002e3
    void OnEnable();
    // method 30427, 0x60002e4
    void Update();
    // method 30428, 0x60002e5
    void GoBack();
    // method 30429, 0x60002e6
    void Init(BuyLayout buyLayout);
    // method 30430, 0x60002e7
    void MoneyTextColorBlink();
    // method 30431, 0x60002e8
    void BuyArmor(int extraHealthToGive, int forPrice);
    // method 30432, 0x60002e9
    void BuyWeapon(int onSlotIndex, BuyMenuItem item);
    // method 30433, 0x60002ea
    void Close();
    // method 30434, 0x60002eb
    void .ctor();
}

// TypeDefinition 4060, 0x200008c
class BuyPhaseMenu : UnityEngine.MonoBehaviour {
    // field 16672, runtime offset 16, flags 0x1
    private TMPro.TMP_Text roundTxt;
    // field 16673, runtime offset 20, flags 0x1
    private TMPro.TMP_Text teamTxt;
    // method 30443, 0x60002f4
    void Init(int round, bool isTerror);
    // method 30444, 0x60002f5
    void .ctor();
}

// TypeDefinition 4061, 0x200008d
class CameraFacingBillboard : UnityEngine.MonoBehaviour {
    // field 16674, runtime offset 16, flags 0x6
    public bool isBeingSpectated;
    // field 16675, runtime offset 20, flags 0x6
    public UnityEngine.LayerMask obstacleLayerMask;
    // field 16676, runtime offset 24, flags 0x1
    private UnityEngine.Transform cam;
    // field 16677, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image healthFill;
    // field 16678, runtime offset 32, flags 0x1
    private UnityEngine.GameObject[] renderers;
    // field 16679, runtime offset 36, flags 0x1
    private int frameCounter;
    // field 16680, runtime offset 0, flags 0x8051
    private static const int raycastInterval = 5;
    // method 30445, 0x60002f6
    void RenewAll(UnityEngine.Transform knownCamera);
    // method 30446, 0x60002f7
    void ResetCam(UnityEngine.Transform knownCamera);
    // method 30447, 0x60002f8
    void LateUpdate();
    // method 30448, 0x60002f9
    void .ctor();
}

// TypeDefinition 4062, 0x200008e
class CameraWalk : UnityEngine.MonoBehaviour {
    // field 16681, runtime offset 16, flags 0x1
    private UnityEngine.Camera cam;
    // field 16682, runtime offset 20, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 16683, runtime offset 24, flags 0x1
    private float walkRange;
    // field 16684, runtime offset 28, flags 0x1
    private Shooter shooter;
    // field 16685, runtime offset 32, flags 0x1
    private PlayerController playerController;
    // field 16686, runtime offset 36, flags 0x1
    private float defaultWalkSpeed;
    // field 16687, runtime offset 40, flags 0x1
    private float jumpEffect;
    // field 16688, runtime offset 44, flags 0x1
    private float lerpedY;
    // field 16689, runtime offset 48, flags 0x1
    private bool lastFrameOnGround;
    // field 16690, runtime offset 52, flags 0x1
    private float lerpedVelocityY;
    // field 16691, runtime offset 56, flags 0x1
    private float initialFOV;
    // field 16692, runtime offset 60, flags 0x1
    private float lastLandTime;
    // field 16693, runtime offset 64, flags 0x1
    private int gameModeId;
    // method 30449, 0x60002fa
    void Start();
    // method 30450, 0x60002fb
    void Update();
    // method 30451, 0x60002fc
    void .ctor();
}

// TypeDefinition 4063, 0x200008f
class Carousel : UnityEngine.MonoBehaviour {
    // field 16694, runtime offset 16, flags 0x1
    private TMPro.TMP_Text carouselText;
    // field 16695, runtime offset 20, flags 0x1
    private UnityEngine.UI.Button rightArrowButton;
    // field 16696, runtime offset 24, flags 0x1
    private UnityEngine.UI.Button leftArrowButton;
    // field 16697, runtime offset 28, flags 0x1
    private string[] carouselItems;
    // field 16698, runtime offset 32, flags 0x1
    private UnityEngine.Events.UnityEvent<int, string> OnValueChanged;
    // field 16699, runtime offset 36, flags 0x6
    public int currentItemIndex;
    // field 16700, runtime offset 40, flags 0x6
    public string currentItemName;
    // method 30452, 0x60002fd
    void Awake();
    // method 30453, 0x60002fe
    void Start();
    // method 30454, 0x60002ff
    void OnRightArrowClick();
    // method 30455, 0x6000300
    void OnLeftArrowClick();
    // method 30456, 0x6000301
    void UpdateCarousel();
    // method 30457, 0x6000302
    void SetItem(int itemIndex);
    // method 30458, 0x6000303
    void .ctor();
}

// TypeDefinition 4064, 0x2000090
class CaseData : Item {
    // field 16701, runtime offset 68, flags 0x6
    public string prefabName;
    // field 16702, runtime offset 72, flags 0x6
    public string caseTexturePath;
    // field 16703, runtime offset 76, flags 0x6
    public float openAgainChance;
    // field 16704, runtime offset 80, flags 0x6
    public CaseItemData[] items;
    // method 30459, 0x6000304
    float TotalWeight();
    // method 30460, 0x6000305
    CaseItemData GenerateRandomItem();
    // method 30461, 0x6000306
    void .ctor();
}

// TypeDefinition 4065, 0x2000091
class CaseItemData : object {
    // field 16705, runtime offset 8, flags 0x6
    public float weight;
    // field 16706, runtime offset 12, flags 0x6
    public Item item;
    // field 16707, runtime offset 16, flags 0x6
    public int amountMin;
    // field 16708, runtime offset 20, flags 0x6
    public int amountMax;
    // field 16709, runtime offset 24, flags 0x6
    public int overrideRarity;
    // method 30462, 0x6000307
    void .ctor();
}

// TypeDefinition 4066, 0x2000092
class CaseGallery : UnityEngine.MonoBehaviour {
    // field 16710, runtime offset 16, flags 0x1
    private ShopPanel shopPanel;
    // field 16711, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image backgroundImg;
    // field 16712, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image caseImage1;
    // field 16713, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image caseImage2;
    // field 16714, runtime offset 32, flags 0x1
    private UnityEngine.UI.Button purhcaseButton;
    // field 16715, runtime offset 36, flags 0x1
    private TMPro.TMP_Text purhcaseTxt;
    // field 16716, runtime offset 40, flags 0x1
    private CaseData current;
    // method 30463, 0x6000308
    void Start();
    // method 30464, 0x6000309
    void OnEnable();
    // method 30465, 0x600030a
    void SetNext();
    // method 30466, 0x600030b
    void CasePanelPressed();
    // method 30467, 0x600030c
    void SetNext(bool setCurrentAsNext);
    // method 30468, 0x600030d
    void Swap();
    // method 30469, 0x600030e
    void .ctor();
    // method 30470, 0x600030f
    void <SetNext>b__11_0();
    // method 30471, 0x6000310
    void <SetNext>b__11_1(UnityEngine.Color c);
}

// TypeDefinition 4067, 0x2000093
class CaseItemImage : UnityEngine.MonoBehaviour {
    // field 16717, runtime offset 16, flags 0x1
    private UnityEngine.UI.Graphic[] renderers;
    // field 16718, runtime offset 20, flags 0x1
    private int frameCounter;
    // field 16719, runtime offset 0, flags 0x8051
    private static const int raycastInterval = 5;
    // method 30472, 0x6000311
    void LateUpdate();
    // method 30473, 0x6000312
    bool IsVisible();
    // method 30474, 0x6000313
    void .ctor();
}

// TypeDefinition 4068, 0x2000095
class <>c : object {
    // field 16748, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16749, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__35_8;
    // method 30489, 0x6000322
    void .cctor();
    // method 30490, 0x6000323
    void .ctor();
    // method 30491, 0x6000324
    void <ForceOpen>b__35_8();
}

// TypeDefinition 4069, 0x2000096
class <>c__DisplayClass25_0 : object {
    // field 16750, runtime offset 8, flags 0x6
    public UnityEngine.MeshRenderer mr;
    // field 16751, runtime offset 12, flags 0x6
    public UnityEngine.MeshRenderer mr2;
    // field 16752, runtime offset 16, flags 0x6
    public CasePanel <>4__this;
    // method 30492, 0x6000325
    void .ctor();
    // method 30493, 0x6000326
    void <Init>b__0(UnityEngine.Texture2D n);
}

// TypeDefinition 4070, 0x2000097
class <>c__DisplayClass25_1 : object {
    // field 16753, runtime offset 8, flags 0x6
    public UnityEngine.MeshRenderer _mr;
    // field 16754, runtime offset 12, flags 0x6
    public UnityEngine.MeshRenderer _mr2;
    // method 30494, 0x6000327
    void .ctor();
    // method 30495, 0x6000328
    void <Init>b__1(UnityEngine.Texture2D n);
}

// TypeDefinition 4071, 0x2000098
class <>c__DisplayClass25_2 : object {
    // field 16755, runtime offset 8, flags 0x6
    public CaseItemData currentItem;
    // field 16756, runtime offset 12, flags 0x6
    public <>c__DisplayClass25_0 CS$<>8__locals1;
    // method 30496, 0x6000329
    void .ctor();
    // method 30497, 0x600032a
    void <Init>b__2();
}

// TypeDefinition 4072, 0x2000099
class <>c__DisplayClass34_0 : object {
    // field 16757, runtime offset 8, flags 0x6
    public int currentCoins;
    // field 16758, runtime offset 12, flags 0x6
    public int price;
    // field 16759, runtime offset 16, flags 0x6
    public CasePanel <>4__this;
    // method 30498, 0x600032b
    void .ctor();
    // method 30499, 0x600032c
    void <Open>b__0();
}

// TypeDefinition 4073, 0x200009a
class <>c__DisplayClass35_0 : object {
    // field 16760, runtime offset 8, flags 0x6
    public UnityEngine.RectTransform rectTransform;
    // method 30500, 0x600032d
    void .ctor();
    // method 30501, 0x600032e
    UnityEngine.Vector2 <ForceOpen>b__0();
    // method 30502, 0x600032f
    void <ForceOpen>b__1(UnityEngine.Vector2 x);
    // method 30503, 0x6000330
    UnityEngine.Vector2 <ForceOpen>b__2();
    // method 30504, 0x6000331
    void <ForceOpen>b__3(UnityEngine.Vector2 x);
    // method 30505, 0x6000332
    UnityEngine.Vector2 <ForceOpen>b__4();
    // method 30506, 0x6000333
    void <ForceOpen>b__5(UnityEngine.Vector2 x);
    // method 30507, 0x6000334
    UnityEngine.Vector2 <ForceOpen>b__6();
    // method 30508, 0x6000335
    void <ForceOpen>b__7(UnityEngine.Vector2 x);
}

// TypeDefinition 4074, 0x2000094
class CasePanel : UnityEngine.MonoBehaviour {
    // field 16720, runtime offset 16, flags 0x1
    private TMPro.TMP_Text coinTxt;
    // field 16721, runtime offset 20, flags 0x1
    private UnityEngine.Sprite kourstrikeRenderImg;
    // field 16722, runtime offset 24, flags 0x1
    private UnityEngine.Sprite kourzoneRenderImg;
    // field 16723, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image renderImg;
    // field 16724, runtime offset 32, flags 0x1
    private UnityEngine.RectTransform movingInAnim;
    // field 16725, runtime offset 36, flags 0x1
    private UnityEngine.UI.RawImage caseRawImage;
    // field 16726, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image backgroundImage;
    // field 16727, runtime offset 44, flags 0x1
    private UnityEngine.UI.Button closeButton;
    // field 16728, runtime offset 48, flags 0x1
    private UnityEngine.Transform caseParent;
    // field 16729, runtime offset 52, flags 0x1
    private TMPro.TMP_Text purchaseButtonText;
    // field 16730, runtime offset 56, flags 0x1
    private TMPro.TMP_Text caseNameTxt;
    // field 16731, runtime offset 60, flags 0x1
    private UnityEngine.AudioSource tickAudioSource;
    // field 16732, runtime offset 64, flags 0x1
    private UnityEngine.AudioSource openInstantAudioSource;
    // field 16733, runtime offset 68, flags 0x1
    private UnityEngine.AudioSource openAudioSource;
    // field 16734, runtime offset 72, flags 0x1
    private UnityEngine.AudioSource landAudioSource;
    // field 16735, runtime offset 76, flags 0x1
    private UnityEngine.RectTransform slightMoveTransform;
    // field 16736, runtime offset 80, flags 0x1
    private UnityEngine.RectTransform[] itemPreviews;
    // field 16737, runtime offset 84, flags 0x1
    private UnityEngine.RectTransform[] lineItems;
    // field 16738, runtime offset 88, flags 0x1
    private UnityEngine.MeshRenderer[] caseMeshRenderers;
    // field 16739, runtime offset 92, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 16740, runtime offset 96, flags 0x1
    private UnityEngine.Animator animator;
    // field 16741, runtime offset 100, flags 0x1
    private CaseData caseData;
    // field 16742, runtime offset 104, flags 0x1
    private CaseItemData landedOnItem;
    // field 16743, runtime offset 108, flags 0x1
    private bool isPrePaid;
    // field 16744, runtime offset 109, flags 0x1
    private bool canFastLeave;
    // field 16745, runtime offset 112, flags 0x1
    private string customTitle;
    // field 16746, runtime offset 116, flags 0x1
    private float openTime;
    // field 16747, runtime offset 120, flags 0x1
    private float slightMove;
    // method 30475, 0x6000314
    void PurchaseKPNow();
    // method 30476, 0x6000315
    void Init(CaseData withCaseData, bool wasPurchasedAlready);
    // method 30477, 0x6000316
    void CaseRawImageFadeBack();
    // method 30478, 0x6000317
    void GiveItem(CaseItemData caseItemData);
    // method 30479, 0x6000318
    void Update();
    // method 30480, 0x6000319
    void OnStartDie();
    // method 30481, 0x600031a
    void Open();
    // method 30482, 0x600031b
    void ForceOpen();
    // method 30483, 0x600031c
    void OnPrizeTick();
    // method 30484, 0x600031d
    void Close();
    // method 30485, 0x600031e
    void OnEnable();
    // method 30486, 0x600031f
    void .ctor();
    // method 30487, 0x6000320
    void <Open>b__34_1(string callback);
    // method 30488, 0x6000321
    void <Close>b__37_0();
}

// TypeDefinition 4075, 0x200009c
class <IenuOnEndOfDance>d__14 : object {
    // field 16779, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16780, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16781, runtime offset 16, flags 0x6
    public float wait;
    // field 16782, runtime offset 20, flags 0x6
    public CharacterAnimatorManager <>4__this;
    // method 30530, 0x600034b
    void .ctor(int <>1__state);
    // method 30531, 0x600034c
    void System.IDisposable.Dispose();
    // method 30532, 0x600034d
    bool MoveNext();
    // method 30533, 0x600034e
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30534, 0x600034f
    void System.Collections.IEnumerator.Reset();
    // method 30535, 0x6000350
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4076, 0x200009b
class CharacterAnimatorManager : Photon.Pun.MonoBehaviourPun {
    // field 16761, runtime offset 20, flags 0x1
    private Shooter shooter;
    // field 16762, runtime offset 24, flags 0x1
    private UnityEngine.AudioSource danceSource;
    // field 16763, runtime offset 28, flags 0x1
    private UnityEngine.Camera fpsCamera;
    // field 16764, runtime offset 32, flags 0x1
    private UnityEngine.Camera tpsCamera;
    // field 16765, runtime offset 36, flags 0x1
    private UnityEngine.Camera fallingBrCamera;
    // field 16766, runtime offset 40, flags 0x1
    private PlayerInputHandler playerInput;
    // field 16767, runtime offset 44, flags 0x6
    public bool networkGrounded;
    // field 16768, runtime offset 45, flags 0x6
    public bool networkCrouching;
    // field 16769, runtime offset 46, flags 0x1
    private bool localIsListeningForDanceCancel;
    // field 16770, runtime offset 48, flags 0x1
    private UnityEngine.Coroutine danceCancelCoroutine;
    // field 16771, runtime offset 52, flags 0x1
    private float velMoveTreshold;
    // field 16772, runtime offset 56, flags 0x1
    private float updateRate;
    // field 16773, runtime offset 60, flags 0x1
    private UnityEngine.Transform parentPlayer;
    // field 16774, runtime offset 64, flags 0x1
    private UnityEngine.Animator animator;
    // field 16775, runtime offset 68, flags 0x1
    private UnityEngine.Vector3 lastPlayerPosition;
    // field 16776, runtime offset 80, flags 0x1
    private float estimatedMoveVertical;
    // field 16777, runtime offset 84, flags 0x1
    private float estimatedMoveHorizontal;
    // field 16778, runtime offset 88, flags 0x6
    public float lastDance;
    // method 30509, 0x6000336
    Emote FindEmote(string musicName);
    // method 30510, 0x6000337
    void InitiateDance(string danceName);
    // method 30511, 0x6000338
    void RPCInitiateDance(string danceName);
    // method 30512, 0x6000339
    void ForceStopDance();
    // method 30513, 0x600033a
    System.Collections.IEnumerator IenuOnEndOfDance(float wait);
    // method 30514, 0x600033b
    void RPCEndOfDance();
    // method 30515, 0x600033c
    void SetCrouch(bool crouch);
    // method 30516, 0x600033d
    void SetAirState(bool isGrounded);
    // method 30517, 0x600033e
    void Start();
    // method 30518, 0x600033f
    void SlowUpdate();
    // method 30519, 0x6000340
    void SetHoldAnimation(WeaponType type);
    // method 30520, 0x6000341
    void Update();
    // method 30521, 0x6000342
    void SetFallingNormal(float normal);
    // method 30522, 0x6000343
    void OpenUmbrella();
    // method 30523, 0x6000344
    void Land();
    // method 30524, 0x6000345
    void SetAnimatorBoolForEveryone(string boolName, bool value);
    // method 30525, 0x6000346
    void RPCSetAnimatorBoolForEveryone(string boolName, bool value);
    // method 30526, 0x6000347
    void SetAnimatorLayerWeightForEveryone(int layerIndex, float weight);
    // method 30527, 0x6000348
    void RPCSetAnimatorLayerWeightForEveryone(int layerIndex, float weight);
    // method 30528, 0x6000349
    void .ctor();
    // method 30529, 0x600034a
    void <RPCEndOfDance>b__15_0();
}

// TypeDefinition 4077, 0x200009d
class CharacterSkin : Item {
    // field 16783, runtime offset 68, flags 0x6
    public int skinIndex;
    // method 30536, 0x6000351
    string get_IsCurrentKey();
    // method 30537, 0x6000352
    void SetAsCurrent();
    // method 30538, 0x6000353
    string get_HasItKey();
    // method 30539, 0x6000354
    bool get_IsCurrent();
    // method 30540, 0x6000355
    void .ctor();
}

// TypeDefinition 4078, 0x200009f
class <>c__DisplayClass10_0 : object {
    // field 16793, runtime offset 8, flags 0x6
    public CharacterSkinManager <>4__this;
    // field 16794, runtime offset 12, flags 0x6
    public int characterSkinIndex;
    // method 30546, 0x600035b
    void .ctor();
    // method 30547, 0x600035c
    void <SetCharacterSkin>b__0(UnityEngine.Texture2D x);
    // method 30548, 0x600035d
    void <SetCharacterSkin>b__5(UnityEngine.Mesh headMesh);
    // method 30549, 0x600035e
    void <SetCharacterSkin>b__6(UnityEngine.Texture2D headTexture);
    // method 30550, 0x600035f
    void <SetCharacterSkin>b__1(UnityEngine.Mesh headMesh);
    // method 30551, 0x6000360
    void <SetCharacterSkin>b__2(UnityEngine.Texture2D headTexture);
    // method 30552, 0x6000361
    void <SetCharacterSkin>b__3(UnityEngine.Mesh bodyAttachmentMesh);
    // method 30553, 0x6000362
    void <SetCharacterSkin>b__4(UnityEngine.Texture2D headTexture);
}

// TypeDefinition 4079, 0x200009e
class CharacterSkinManager : Photon.Pun.MonoBehaviourPun {
    // field 16784, runtime offset 20, flags 0x6
    public UnityEngine.Texture2D defaultCharacterTexture;
    // field 16785, runtime offset 24, flags 0x1
    private UnityEngine.MeshFilter headMeshFilter;
    // field 16786, runtime offset 28, flags 0x1
    private UnityEngine.MeshRenderer headMeshRenderer;
    // field 16787, runtime offset 32, flags 0x1
    private UnityEngine.MeshFilter bodyAttachmentMeshFilter;
    // field 16788, runtime offset 36, flags 0x1
    private UnityEngine.MeshRenderer bodyAttachmentMeshRenderer;
    // field 16789, runtime offset 40, flags 0x1
    private UnityEngine.SkinnedMeshRenderer[] bodyMeshRenderers;
    // field 16790, runtime offset 44, flags 0x1
    private int lastCharacterSkinIndex;
    // field 16791, runtime offset 48, flags 0x1
    private int currentUpdatedInstantCharacterSkinIndex;
    // field 16792, runtime offset 52, flags 0x1
    private int lastHatSkinIndex;
    // method 30541, 0x6000356
    string GetCurrentTexture(out bool isTransparent, out int meshIndex);
    // method 30542, 0x6000357
    void SetCharacterSkin(int characterSkinIndex, int hatSkinIndex, bool isMainMenuCharacter);
    // method 30543, 0x6000358
    void SetMaterial(UnityEngine.SkinnedMeshRenderer renderer, bool isTransparent);
    // method 30544, 0x6000359
    void SetHeadMesh(UnityEngine.Mesh m);
    // method 30545, 0x600035a
    void .ctor();
}

// TypeDefinition 4080, 0x20000a0
class CharacterSkinData : object {
    // field 16795, runtime offset 8, flags 0x6
    public int meshIndex;
    // field 16796, runtime offset 12, flags 0x6
    public bool useTransparentMaterial;
    // field 16797, runtime offset 16, flags 0x6
    public int useHatIndex;
    // field 16798, runtime offset 20, flags 0x6
    public int useBodyAttachmentIndex;
    // field 16799, runtime offset 24, flags 0x6
    public int forceToUseHat;
    // method 30554, 0x6000363
    void .ctor();
}

// TypeDefinition 4081, 0x20000a2
class <>c__DisplayClass2_0 : object {
    // field 16813, runtime offset 8, flags 0x6
    public ChatManager <>4__this;
    // field 16814, runtime offset 12, flags 0x6
    public bool isSendingMessageNow;
    // method 30575, 0x6000378
    void .ctor();
    // method 30576, 0x6000379
    void <Update>b__0(string message);
}

// TypeDefinition 4082, 0x20000a3
class <UpdateLayoutGroup>d__27 : object {
    // field 16815, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16816, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16817, runtime offset 16, flags 0x6
    public ChatManager <>4__this;
    // field 16818, runtime offset 20, flags 0x6
    public UnityEngine.RectTransform recttransformOfTheLayoutgroup;
    // method 30577, 0x600037a
    void .ctor(int <>1__state);
    // method 30578, 0x600037b
    void System.IDisposable.Dispose();
    // method 30579, 0x600037c
    bool MoveNext();
    // method 30580, 0x600037d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30581, 0x600037e
    void System.Collections.IEnumerator.Reset();
    // method 30582, 0x600037f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4083, 0x20000a1
class ChatManager : UnityEngine.MonoBehaviour {
    // field 16800, runtime offset 16, flags 0x1
    private ProfanityList profanityList;
    // field 16801, runtime offset 20, flags 0x1
    private bool isChatFocused;
    // field 16802, runtime offset 24, flags 0x1
    private TMPro.TMP_InputField messageIF;
    // field 16803, runtime offset 28, flags 0x1
    private ChatSlot[] chatSlots;
    // field 16804, runtime offset 32, flags 0x1
    private KourStrikeChatSlot[] kourStrikeChatSlots;
    // field 16805, runtime offset 36, flags 0x1
    private System.Collections.Generic.Queue<string> messages;
    // field 16806, runtime offset 40, flags 0x1
    private System.Collections.Generic.Queue<System.ValueTuple<string, int, bool>> kourstrikeMessages;
    // field 16807, runtime offset 0, flags 0x11
    private static ChatManager <instance>k__BackingField;
    // field 16808, runtime offset 44, flags 0x1
    private UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup;
    // field 16809, runtime offset 48, flags 0x1
    private UnityEngine.UI.VerticalLayoutGroup kourstrikeVerticalLayoutGroup;
    // field 16810, runtime offset 4, flags 0x31
    private static byte ChatMessageEventCode;
    // field 16811, runtime offset 52, flags 0x1
    private int messagesPastTenSeconds;
    // field 16812, runtime offset 56, flags 0x1
    private float timeSinceLastMessage;
    // method 30555, 0x6000364
    void Update();
    // method 30556, 0x6000365
    string FilterProfanity(string[] arr, string message);
    // method 30557, 0x6000366
    void PrepareMessageWithBody(string body);
    // method 30558, 0x6000367
    void OnEnable();
    // method 30559, 0x6000368
    void OnDisable();
    // method 30560, 0x6000369
    bool IsChatInputFieldFocused();
    // method 30561, 0x600036a
    void ClearChatAndUnfocus();
    // method 30562, 0x600036b
    void OnInputFieldSelect(string x);
    // method 30563, 0x600036c
    void SetChatFocus(bool focus, System.Action<string> toSend);
    // method 30564, 0x600036d
    ChatManager get_instance();
    // method 30565, 0x600036e
    void set_instance(ChatManager value);
    // method 30566, 0x600036f
    void Awake();
    // method 30567, 0x6000370
    void Start();
    // method 30568, 0x6000371
    void AddMessage(string message, int weaponIndex, bool flipColors);
    // method 30569, 0x6000372
    void RefreshChatUI(int forceLimit);
    // method 30570, 0x6000373
    void RefreshKourstrikeChatUI();
    // method 30571, 0x6000374
    System.Collections.IEnumerator UpdateLayoutGroup(UnityEngine.RectTransform recttransformOfTheLayoutgroup);
    // method 30572, 0x6000375
    void ClientSendMessage(string fullMessage, int withWeaponIndex, bool flipTeams);
    // method 30573, 0x6000376
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 30574, 0x6000377
    void .ctor();
}

// TypeDefinition 4084, 0x20000a5
class <>c : object {
    // field 16820, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16821, runtime offset 4, flags 0x16
    public static System.Action<string> <>9__2_0;
    // method 30588, 0x6000385
    void .cctor();
    // method 30589, 0x6000386
    void .ctor();
    // method 30590, 0x6000387
    void <OnPointerDown>b__2_0(string uid);
}

// TypeDefinition 4085, 0x20000a6
class <IenuFixContentSizeFitter>d__4 : object {
    // field 16822, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16823, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16824, runtime offset 16, flags 0x6
    public ChatSlot <>4__this;
    // method 30591, 0x6000388
    void .ctor(int <>1__state);
    // method 30592, 0x6000389
    void System.IDisposable.Dispose();
    // method 30593, 0x600038a
    bool MoveNext();
    // method 30594, 0x600038b
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30595, 0x600038c
    void System.Collections.IEnumerator.Reset();
    // method 30596, 0x600038d
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4086, 0x20000a4
class ChatSlot : UnityEngine.MonoBehaviour {
    // field 16819, runtime offset 16, flags 0x1
    private TMPro.TMP_Text myText;
    // method 30583, 0x6000380
    void Init(bool active, string text);
    // method 30584, 0x6000381
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30585, 0x6000382
    string ExtractUsername(string longStr);
    // method 30586, 0x6000383
    System.Collections.IEnumerator IenuFixContentSizeFitter();
    // method 30587, 0x6000384
    void .ctor();
}

// TypeDefinition 4087, 0x20000a7
class Checkpoint : UnityEngine.MonoBehaviour {
    // field 16825, runtime offset 16, flags 0x1
    private bool claimed;
    // field 16826, runtime offset 0, flags 0x11
    private static Checkpoint lastCheckpoint;
    // method 30597, 0x600038e
    void UnClaim();
    // method 30598, 0x600038f
    void Claim();
    // method 30599, 0x6000390
    UnityEngine.Transform GetSP();
    // method 30600, 0x6000391
    void .ctor();
}

// TypeDefinition 4088, 0x20000a9
class State : System.Enum {
    // field 16857, runtime offset 8, flags 0x606
    public int value__;
    // field 16858, runtime offset 0, flags 0x8056
    public static const State Eating = 0;
    // field 16859, runtime offset 0, flags 0x8056
    public static const State Walking = 1;
    // field 16860, runtime offset 0, flags 0x8056
    public static const State Running = 2;
}

// TypeDefinition 4089, 0x20000a8
class ChickenController : UnityEngine.MonoBehaviour {
    // field 16827, runtime offset 16, flags 0x1
    private ChickenLine myLine;
    // field 16828, runtime offset 20, flags 0x1
    private UnityEngine.GameObject chickGfx;
    // field 16829, runtime offset 24, flags 0x1
    private UnityEngine.Material pinkMat;
    // field 16830, runtime offset 28, flags 0x1
    private UnityEngine.Material greenMat;
    // field 16831, runtime offset 32, flags 0x1
    private UnityEngine.Material redMat;
    // field 16832, runtime offset 36, flags 0x1
    private UnityEngine.SkinnedMeshRenderer chickenMeshRenderer;
    // field 16833, runtime offset 40, flags 0x1
    private UnityEngine.GameObject chickenGfx;
    // field 16834, runtime offset 44, flags 0x1
    private UnityEngine.Animator chickAnimator;
    // field 16835, runtime offset 48, flags 0x1
    private UnityEngine.Animator chickenAnimator;
    // field 16836, runtime offset 52, flags 0x1
    private UnityEngine.Animator animator;
    // field 16837, runtime offset 56, flags 0x1
    private UnityEngine.Transform chickExplosion;
    // field 16838, runtime offset 60, flags 0x1
    private UnityEngine.Transform chickenExplosion;
    // field 16839, runtime offset 64, flags 0x1
    private UnityEngine.Transform explosion;
    // field 16840, runtime offset 68, flags 0x1
    private State state;
    // field 16841, runtime offset 72, flags 0x1
    private UnityEngine.Transform[] movePoints;
    // field 16842, runtime offset 76, flags 0x1
    private float walkSpeed;
    // field 16843, runtime offset 80, flags 0x1
    private float runSpeed;
    // field 16844, runtime offset 84, flags 0x1
    private float stateWaitTime;
    // field 16845, runtime offset 88, flags 0x1
    private int currentMovePointIndex;
    // field 16846, runtime offset 92, flags 0x1
    private float currentSpeed;
    // field 16847, runtime offset 96, flags 0x1
    private bool isReversed;
    // field 16848, runtime offset 100, flags 0x1
    private float scaleMulti;
    // field 16849, runtime offset 104, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 16850, runtime offset 108, flags 0x6
    public bool isChick;
    // field 16851, runtime offset 109, flags 0x6
    public bool isPink;
    // field 16852, runtime offset 110, flags 0x6
    public bool isRed;
    // field 16853, runtime offset 111, flags 0x6
    public bool isGreen;
    // field 16854, runtime offset 112, flags 0x1
    private bool defaultExplosionIsYellow;
    // field 16855, runtime offset 116, flags 0x1
    private int prevMovePointIndex;
    // field 16856, runtime offset 120, flags 0x1
    private int lastMovePointIndex;
    // method 30601, 0x6000392
    void Start();
    // method 30602, 0x6000393
    void Init(ChickenLine line, int fromIndex, UnityEngine.Material defaultMat, bool defaultExplosionYellow);
    // method 30603, 0x6000394
    void ChangeToRandomState();
    // method 30604, 0x6000395
    void Update();
    // method 30605, 0x6000396
    void MoveToNextPoint();
    // method 30606, 0x6000397
    void SetState(State newState);
    // method 30607, 0x6000398
    void LayEgg();
    // method 30608, 0x6000399
    void Die(out int scoreToGive);
    // method 30609, 0x600039a
    void PlaySound();
    // method 30610, 0x600039b
    void .ctor();
}

// TypeDefinition 4090, 0x20000aa
class ChickenLine : UnityEngine.MonoBehaviour {
    // field 16861, runtime offset 16, flags 0x6
    public System.Collections.Generic.List<UnityEngine.Transform> movePoints;
    // method 30611, 0x600039c
    void .ctor();
}

// TypeDefinition 4091, 0x20000ab
class ClanMemberContainer : UnityEngine.MonoBehaviour {
    // field 16862, runtime offset 16, flags 0x1
    private UnityEngine.GameObject enableOnHover;
    // field 16863, runtime offset 20, flags 0x1
    private UnityEngine.GameObject enableIfLeader;
    // field 16864, runtime offset 24, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 16865, runtime offset 28, flags 0x1
    private string myHolderUID;
    // method 30612, 0x600039d
    void Init(bool exists, bool isLeader, string uid);
    // method 30613, 0x600039e
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30614, 0x600039f
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30615, 0x60003a0
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30616, 0x60003a1
    void .ctor();
    // method 30617, 0x60003a2
    void <Init>b__4_0(string u);
}

// TypeDefinition 4092, 0x20000ac
class ClanRequestObject : UnityEngine.MonoBehaviour {
    // field 16866, runtime offset 16, flags 0x1
    private UnityEngine.UI.Button approveBtn;
    // field 16867, runtime offset 20, flags 0x1
    private UnityEngine.UI.Button declineBtn;
    // field 16868, runtime offset 24, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // method 30618, 0x60003a3
    void Init(bool active, string nameText, UnityEngine.Events.UnityAction onApprove, UnityEngine.Events.UnityAction onDecline);
    // method 30619, 0x60003a4
    void .ctor();
}

// TypeDefinition 4093, 0x20000ad
class ClassButton : UnityEngine.MonoBehaviour {
    // field 16869, runtime offset 16, flags 0x6
    public WeaponClass myWeaponClass;
    // field 16870, runtime offset 20, flags 0x6
    public int myWeaponClassIndex;
    // field 16871, runtime offset 24, flags 0x1
    private UnityEngine.UI.Slider xpSlider;
    // field 16872, runtime offset 28, flags 0x1
    private TMPro.TMP_Text xpTxt;
    // field 16873, runtime offset 32, flags 0x1
    private TMPro.TMP_Text hpTxt;
    // field 16874, runtime offset 36, flags 0x1
    private TMPro.TMP_Text lvlTxt;
    // field 16875, runtime offset 40, flags 0x1
    private TMPro.TMP_Text xpToUnlockTxt;
    // field 16876, runtime offset 44, flags 0x1
    private UnityEngine.GameObject lockedPanel;
    // field 16877, runtime offset 48, flags 0x1
    private System.Action<ClassButton> onClick;
    // field 16878, runtime offset 52, flags 0x6
    public bool isLocked;
    // method 30620, 0x60003a5
    void Init(WeaponClass weaponClass, int classIndex, System.Action<ClassButton> onClicked);
    // method 30621, 0x60003a6
    int GetLevel(out string progressText, out float xLocalScale);
    // method 30622, 0x60003a7
    void ButtonPressed();
    // method 30623, 0x60003a8
    void .ctor();
}

// TypeDefinition 4094, 0x20000ae
class WeaponLevel : object {
    // field 16879, runtime offset 8, flags 0x6
    public int[] unlockWeaponPair;
    // method 30624, 0x60003a9
    void .ctor();
}

// TypeDefinition 4095, 0x20000b0
class <>c__DisplayClass34_0 : object {
    // field 16908, runtime offset 8, flags 0x6
    public int classIndex;
    // field 16909, runtime offset 12, flags 0x6
    public ClassSelectPanel <>4__this;
    // method 30655, 0x60003c8
    void .ctor();
    // method 30656, 0x60003c9
    void <UnlockClassForAd>b__0(bool s);
}

// TypeDefinition 4096, 0x20000b1
class <>c__DisplayClass41_0 : object {
    // field 16910, runtime offset 8, flags 0x6
    public int forWeaponIndex;
    // field 16911, runtime offset 12, flags 0x6
    public WeaponClass currentClass;
    // field 16912, runtime offset 16, flags 0x6
    public ClassSelectPanel <>4__this;
    // method 30657, 0x60003ca
    void .ctor();
    // method 30658, 0x60003cb
    void <OnChoseWeapon>b__0();
}

// TypeDefinition 4097, 0x20000b2
class <>c__DisplayClass43_0 : object {
    // field 16913, runtime offset 8, flags 0x6
    public System.Action onfinish;
    // method 30659, 0x60003cc
    void .ctor();
    // method 30660, 0x60003cd
    void <Close>b__0();
}

// TypeDefinition 4098, 0x20000b3
class <>c__DisplayClass45_0 : object {
    // field 16914, runtime offset 8, flags 0x6
    public int _i;
    // field 16915, runtime offset 12, flags 0x6
    public ClassSelectPanel <>4__this;
    // method 30661, 0x60003ce
    void .ctor();
    // method 30662, 0x60003cf
    void <LoadClassInfo>b__2(int _);
}

// TypeDefinition 4099, 0x20000af
class ClassSelectPanel : Popup {
    // field 16880, runtime offset 68, flags 0x1
    private UnityEngine.UI.Image panel2ClassImage;
    // field 16881, runtime offset 72, flags 0x1
    private TMPro.TMP_Text panel2ClassNameTxt;
    // field 16882, runtime offset 76, flags 0x1
    private TMPro.TMP_Text panel2ClassDescriptionTxt;
    // field 16883, runtime offset 80, flags 0x6
    public WeaponLevel[] levelUnlocks;
    // field 16884, runtime offset 84, flags 0x6
    public UnityEngine.RenderTexture customizeRenderTexture;
    // field 16885, runtime offset 88, flags 0x6
    public RotateCharacter rotateCharacter;
    // field 16886, runtime offset 92, flags 0x1
    private UnityEngine.RectTransform classSelectPanel;
    // field 16887, runtime offset 96, flags 0x1
    private UnityEngine.UI.RawImage customizeRawImage;
    // field 16888, runtime offset 100, flags 0x1
    private UnityEngine.UI.Button[] topButtons;
    // field 16889, runtime offset 104, flags 0x1
    private UnityEngine.UI.Image currentSelectedHatImg;
    // field 16890, runtime offset 108, flags 0x1
    private TMPro.TMP_Text currentSelectedHatTxt;
    // field 16891, runtime offset 112, flags 0x1
    private UnityEngine.UI.Image currentSelectedCharacterImg;
    // field 16892, runtime offset 116, flags 0x1
    private TMPro.TMP_Text currentSelectedCharacterTxt;
    // field 16893, runtime offset 120, flags 0x6
    public System.Action<int, WeaponClass> onChosenClass;
    // field 16894, runtime offset 124, flags 0x1
    private WeaponUpgradesPanel weaponUpgradesPanel;
    // field 16895, runtime offset 128, flags 0x1
    private ClassButton[] classButtons;
    // field 16896, runtime offset 132, flags 0x1
    private ClassWeaponButton[] classWeaponButtons;
    // field 16897, runtime offset 136, flags 0x1
    private UnityEngine.GameObject[] panels;
    // field 16898, runtime offset 140, flags 0x1
    private UnityEngine.RectTransform tipPanel;
    // field 16899, runtime offset 144, flags 0x1
    private UnityEngine.UI.Image[] tipUnlockWeaponImages;
    // field 16900, runtime offset 148, flags 0x1
    private TMPro.TMP_Text tipTitleTxt;
    // field 16901, runtime offset 152, flags 0x1
    private UnityEngine.UI.Image tipTitleImage;
    // field 16902, runtime offset 156, flags 0x1
    private TMPro.TMP_Text[] tipUnlockWeaponLevelTxts;
    // field 16903, runtime offset 160, flags 0x1
    private TMPro.TMP_Text[] tipUnlockWeaponNameTxts;
    // field 16904, runtime offset 164, flags 0x1
    private UnityEngine.GameObject[] tipLocks;
    // field 16905, runtime offset 168, flags 0x1
    private ItemSelectPanel itemSelectPanel;
    // field 16906, runtime offset 172, flags 0x1
    private ProfilePictures profilePictures;
    // field 16907, runtime offset 176, flags 0x1
    private UnityEngine.Vector2 tipPanelTargetPosition;
    // method 30625, 0x60003aa
    string ColorCodeFromLevel(int level);
    // method 30626, 0x60003ab
    void SetMainPanelWidth(float width);
    // method 30627, 0x60003ac
    void CuztomizeButtonPressed();
    // method 30628, 0x60003ad
    void SetTip(bool active, int classIndex);
    // method 30629, 0x60003ae
    int GetLevel(WeaponClass myWeaponClass, int myWeaponClassIndex);
    // method 30630, 0x60003af
    void Update();
    // method 30631, 0x60003b0
    void UnlockClassForAd(int classIndex);
    // method 30632, 0x60003b1
    void OnClassButtonHover(int buttonIndex);
    // method 30633, 0x60003b2
    void OnClassButtonExit();
    // method 30634, 0x60003b3
    void SetPanel(int index);
    // method 30635, 0x60003b4
    void Show();
    // method 30636, 0x60003b5
    void RefreshCustomizePanelUI();
    // method 30637, 0x60003b6
    bool IsCustomSkin(int skinIndex);
    // method 30638, 0x60003b7
    void OnChoseWeapon(int forWeaponIndex);
    // method 30639, 0x60003b8
    void OnClassButtonPressed(ClassButton classButton);
    // method 30640, 0x60003b9
    void Close(System.Action onfinish);
    // method 30641, 0x60003ba
    void SetClass(int classIndex);
    // method 30642, 0x60003bb
    void LoadClassInfo(int knownClassIndex);
    // method 30643, 0x60003bc
    void LoadAllSkins();
    // method 30644, 0x60003bd
    void LoadHats();
    // method 30645, 0x60003be
    void OnSelectedHat(int hatIndex);
    // method 30646, 0x60003bf
    void OnSelectedSkin(int skinIndex);
    // method 30647, 0x60003c0
    void .ctor();
    // method 30648, 0x60003c1
    void <SetTip>b__31_0(UnityEngine.Texture2D s);
    // method 30649, 0x60003c2
    void <RefreshCustomizePanelUI>b__39_0(UnityEngine.Texture2D s);
    // method 30650, 0x60003c3
    void <RefreshCustomizePanelUI>b__39_1(UnityEngine.Texture2D s);
    // method 30651, 0x60003c4
    void <RefreshCustomizePanelUI>b__39_2(UnityEngine.Texture2D s);
    // method 30652, 0x60003c5
    void <SetClass>b__44_0();
    // method 30653, 0x60003c6
    void <LoadClassInfo>b__45_0(UnityEngine.Texture2D s);
    // method 30654, 0x60003c7
    void <LoadClassInfo>b__45_1();
}

// TypeDefinition 4100, 0x20000b4
class Texture2DExtensions : object {
    // method 30663, 0x60003d0
    UnityEngine.Sprite ToSprite(UnityEngine.Texture2D texture);
}

// TypeDefinition 4101, 0x20000b6
class <>c__DisplayClass5_0 : object {
    // field 16921, runtime offset 8, flags 0x6
    public ClassWeaponButton <>4__this;
    // field 16922, runtime offset 12, flags 0x6
    public int weaponIndex;
    // field 16923, runtime offset 16, flags 0x6
    public System.Action<int> onPressed;
    // field 16924, runtime offset 20, flags 0x6
    public System.Action <>9__1;
    // method 30666, 0x60003d3
    void .ctor();
    // method 30667, 0x60003d4
    void <Init>b__0();
    // method 30668, 0x60003d5
    void <Init>b__1();
}

// TypeDefinition 4102, 0x20000b5
class ClassWeaponButton : UnityEngine.MonoBehaviour {
    // field 16916, runtime offset 16, flags 0x6
    public UnityEngine.GameObject currentIndicator;
    // field 16917, runtime offset 20, flags 0x1
    private TMPro.TMP_Text weaponNameTxt;
    // field 16918, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image weaponIconImg;
    // field 16919, runtime offset 28, flags 0x1
    private UnityEngine.Animator animator;
    // field 16920, runtime offset 32, flags 0x1
    private int myWeaponIndex;
    // method 30664, 0x60003d1
    void Init(int weaponIndex, System.Action<int> onPressed);
    // method 30665, 0x60003d2
    void .ctor();
}

// TypeDefinition 4103, 0x20000b7
class CopyPasteButton : UnityEngine.MonoBehaviour {
    // field 16925, runtime offset 0, flags 0x11
    private static System.Action<string> currentCallback;
    // field 16926, runtime offset 16, flags 0x1
    private TMPro.TMP_Text textRef;
    // field 16927, runtime offset 20, flags 0x1
    private TMPro.TMP_InputField inputFieldRef;
    // field 16928, runtime offset 24, flags 0x1
    private UnityEngine.UI.InputField inputField2Ref;
    // field 16929, runtime offset 28, flags 0x1
    private bool isPaste;
    // field 16930, runtime offset 32, flags 0x1
    private TMPro.TMP_Text showCopiedTxtOptional;
    // method 30669, 0x60003d6
    void ResetCopiedTxt();
    // method 30670, 0x60003d7
    void OnClicked();
    // method 30671, 0x60003d8
    void GetClipboard(System.Action<string> c);
    // method 30672, 0x60003d9
    void OnGotClipboard(string clipboard);
    // method 30673, 0x60003da
    void CopyString(string str, bool notify);
    // method 30674, 0x60003db
    void CopyTextMobile(string text);
    // method 30675, 0x60003dc
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 30676, 0x60003dd
    void .ctor();
    // method 30677, 0x60003de
    void <OnClicked>b__7_0(string clipboard);
}

// TypeDefinition 4104, 0x20000b9
class <IenuAllowLockTimer>d__17 : object {
    // field 16941, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16942, runtime offset 12, flags 0x1
    private object <>2__current;
    // method 30692, 0x60003ed
    void .ctor(int <>1__state);
    // method 30693, 0x60003ee
    void System.IDisposable.Dispose();
    // method 30694, 0x60003ef
    bool MoveNext();
    // method 30695, 0x60003f0
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30696, 0x60003f1
    void System.Collections.IEnumerator.Reset();
    // method 30697, 0x60003f2
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4105, 0x20000b8
class CursorController : UnityEngine.MonoBehaviour {
    // field 16931, runtime offset 0, flags 0x8051
    private static const bool lockCursorFromUnity = false;
    // field 16932, runtime offset 0, flags 0x8056
    public static const float lockTimer = 1.5;
    // field 16933, runtime offset 0, flags 0x8056
    public static const float mobileLockTimer = 0.5;
    // field 16934, runtime offset 0, flags 0x16
    public static bool surpressNextEvent;
    // field 16935, runtime offset 1, flags 0x16
    public static bool canLock;
    // field 16936, runtime offset 4, flags 0x11
    private static System.Action OnLostLock;
    // field 16937, runtime offset 8, flags 0x11
    private static System.Action OnLock;
    // field 16938, runtime offset 12, flags 0x11
    private static bool isLockedNow;
    // field 16939, runtime offset 16, flags 0x6
    public UnityEngine.Coroutine lockCoroutine;
    // field 16940, runtime offset 16, flags 0x16
    public static CursorController instance;
    // method 30678, 0x60003df
    bool isCursorLocked();
    // method 30679, 0x60003e0
    void add_OnLostLock(System.Action value);
    // method 30680, 0x60003e1
    void remove_OnLostLock(System.Action value);
    // method 30681, 0x60003e2
    void add_OnLock(System.Action value);
    // method 30682, 0x60003e3
    void remove_OnLock(System.Action value);
    // method 30683, 0x60003e4
    void Start();
    // method 30684, 0x60003e5
    void LockCursor(bool isLocked);
    // method 30685, 0x60003e6
    System.Collections.IEnumerator IenuAllowLockTimer();
    // method 30686, 0x60003e7
    void OnEscapeJS();
    // method 30687, 0x60003e8
    void ForceStaticOnEscape();
    // method 30688, 0x60003e9
    void StaticOnEscape();
    // method 30689, 0x60003ea
    void Update();
    // method 30690, 0x60003eb
    bool SoftShowCurosr(bool show);
    // method 30691, 0x60003ec
    void .ctor();
}

// TypeDefinition 4106, 0x20000bb
class <>c__DisplayClass12_0 : object {
    // field 16954, runtime offset 8, flags 0x6
    public CustomGameSlot <>4__this;
    // field 16955, runtime offset 12, flags 0x6
    public string approve;
    // field 16956, runtime offset 16, flags 0x6
    public string authToken;
    // field 16957, runtime offset 20, flags 0x6
    public System.Action <>9__2;
    // field 16958, runtime offset 24, flags 0x6
    public DG.Tweening.TweenCallback <>9__1;
    // method 30716, 0x6000405
    void .ctor();
    // method 30717, 0x6000406
    void <Approve>b__0();
    // method 30718, 0x6000407
    void <Approve>b__1();
    // method 30719, 0x6000408
    void <Approve>b__2();
}

// TypeDefinition 4107, 0x20000bc
class <ApproveMap>d__15 : object {
    // field 16959, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16960, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16961, runtime offset 16, flags 0x6
    public string mapId;
    // field 16962, runtime offset 20, flags 0x6
    public string approve;
    // field 16963, runtime offset 24, flags 0x6
    public string authToken;
    // field 16964, runtime offset 28, flags 0x6
    public CustomGameSlot <>4__this;
    // field 16965, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30720, 0x6000409
    void .ctor(int <>1__state);
    // method 30721, 0x600040a
    void System.IDisposable.Dispose();
    // method 30722, 0x600040b
    bool MoveNext();
    // method 30723, 0x600040c
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30724, 0x600040d
    void System.Collections.IEnumerator.Reset();
    // method 30725, 0x600040e
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4108, 0x20000bd
class <IenuDownloadMapConf>d__17 : object {
    // field 16966, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16967, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16968, runtime offset 16, flags 0x6
    public string url;
    // field 16969, runtime offset 20, flags 0x6
    public CustomGameSlot <>4__this;
    // field 16970, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30726, 0x600040f
    void .ctor(int <>1__state);
    // method 30727, 0x6000410
    void System.IDisposable.Dispose();
    // method 30728, 0x6000411
    bool MoveNext();
    // method 30729, 0x6000412
    void <>m__Finally1();
    // method 30730, 0x6000413
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30731, 0x6000414
    void System.Collections.IEnumerator.Reset();
    // method 30732, 0x6000415
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4109, 0x20000be
class <IenuSetMapScore>d__14 : object {
    // field 16971, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16972, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16973, runtime offset 16, flags 0x6
    public int score;
    // field 16974, runtime offset 20, flags 0x6
    public string mapId;
    // field 16975, runtime offset 24, flags 0x6
    public string authToken;
    // field 16976, runtime offset 28, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30733, 0x6000416
    void .ctor(int <>1__state);
    // method 30734, 0x6000417
    void System.IDisposable.Dispose();
    // method 30735, 0x6000418
    bool MoveNext();
    // method 30736, 0x6000419
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30737, 0x600041a
    void System.Collections.IEnumerator.Reset();
    // method 30738, 0x600041b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4110, 0x20000bf
class <SendPlayMap>d__23 : object {
    // field 16977, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16978, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16979, runtime offset 16, flags 0x6
    public string mapId;
    // field 16980, runtime offset 20, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30739, 0x600041c
    void .ctor(int <>1__state);
    // method 30740, 0x600041d
    void System.IDisposable.Dispose();
    // method 30741, 0x600041e
    bool MoveNext();
    // method 30742, 0x600041f
    void <>m__Finally1();
    // method 30743, 0x6000420
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30744, 0x6000421
    void System.Collections.IEnumerator.Reset();
    // method 30745, 0x6000422
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4111, 0x20000ba
class CustomGameSlot : UnityEngine.MonoBehaviour {
    // field 16943, runtime offset 0, flags 0x16
    public static int CUSTOM_GAME_MODE_VALUE;
    // field 16944, runtime offset 16, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 16945, runtime offset 20, flags 0x1
    private TMPro.TMP_Text descriptionTxt;
    // field 16946, runtime offset 24, flags 0x1
    private UnityEngine.UI.RawImage mainImage;
    // field 16947, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image[] stars;
    // field 16948, runtime offset 32, flags 0x1
    private TMPro.TMP_Text byUserTxt;
    // field 16949, runtime offset 36, flags 0x1
    private TMPro.TMP_Text gameplaysTxt;
    // field 16950, runtime offset 40, flags 0x1
    private UnityEngine.UI.Button playButton;
    // field 16951, runtime offset 44, flags 0x1
    private UnityEngine.GameObject adminFuncs;
    // field 16952, runtime offset 48, flags 0x1
    private MapPreview mapPreview;
    // field 16953, runtime offset 52, flags 0x1
    private System.Action onPlayPressed;
    // method 30698, 0x60003f3
    void Setup(float delay, MapPreview preview, System.Action _onPlayPressed);
    // method 30699, 0x60003f4
    void Approve(string approve);
    // method 30700, 0x60003f5
    string SetMapScore(int score);
    // method 30701, 0x60003f6
    System.Collections.IEnumerator IenuSetMapScore(string mapId, int score, string authToken);
    // method 30702, 0x60003f7
    System.Collections.IEnumerator ApproveMap(string mapId, string approve, string authToken);
    // method 30703, 0x60003f8
    void PlayGame();
    // method 30704, 0x60003f9
    System.Collections.IEnumerator IenuDownloadMapConf(string url);
    // method 30705, 0x60003fa
    void Pressed();
    // method 30706, 0x60003fb
    ExitGames.Client.Photon.Hashtable GetMatchmakingFilter(string mapId);
    // method 30707, 0x60003fc
    int HashStringToInt(string input);
    // method 30708, 0x60003fd
    Photon.Realtime.RoomOptions GetRoomOptions(string mapId);
    // method 30709, 0x60003fe
    void IncreasePlayMapCount(string mapId);
    // method 30710, 0x60003ff
    System.Collections.IEnumerator SendPlayMap(string mapId);
    // method 30711, 0x6000400
    void UsernameButtonPressed();
    // method 30712, 0x6000401
    void .ctor();
    // method 30713, 0x6000402
    void .cctor();
    // method 30714, 0x6000403
    void <Setup>b__11_0(string username);
    // method 30715, 0x6000404
    void <Setup>b__11_1();
}

// TypeDefinition 4112, 0x20000c1
class <>c : object {
    // field 16988, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 16989, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__8_0;
    // method 30757, 0x600042e
    void .cctor();
    // method 30758, 0x600042f
    void .ctor();
    // method 30759, 0x6000430
    void <Show>b__8_0();
}

// TypeDefinition 4113, 0x20000c2
class <>c__DisplayClass14_0 : object {
    // field 16990, runtime offset 8, flags 0x6
    public bool devKour;
    // field 16991, runtime offset 9, flags 0x6
    public bool devChose;
    // field 16992, runtime offset 12, flags 0x6
    public float startTime;
    // field 16993, runtime offset 16, flags 0x6
    public float timeout;
    // method 30760, 0x6000431
    void .ctor();
    // method 30761, 0x6000432
    void <GetPopularMaps>b__0();
    // method 30762, 0x6000433
    void <GetPopularMaps>b__1();
    // method 30763, 0x6000434
    bool <GetPopularMaps>b__2();
}

// TypeDefinition 4114, 0x20000c3
class <DebouncedSearch>d__13 : object {
    // field 16994, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16995, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16996, runtime offset 16, flags 0x6
    public CustomGamesPanel <>4__this;
    // method 30764, 0x6000435
    void .ctor(int <>1__state);
    // method 30765, 0x6000436
    void System.IDisposable.Dispose();
    // method 30766, 0x6000437
    bool MoveNext();
    // method 30767, 0x6000438
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30768, 0x6000439
    void System.Collections.IEnumerator.Reset();
    // method 30769, 0x600043a
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4115, 0x20000c4
class <GetPopularMaps>d__14 : object {
    // field 16997, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 16998, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 16999, runtime offset 16, flags 0x6
    public CustomGamesPanel <>4__this;
    // field 17000, runtime offset 20, flags 0x1
    private <>c__DisplayClass14_0 <>8__1;
    // field 17001, runtime offset 24, flags 0x1
    private int <startIndex>5__2;
    // field 17002, runtime offset 28, flags 0x1
    private int <endIndex>5__3;
    // field 17003, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__4;
    // method 30770, 0x600043b
    void .ctor(int <>1__state);
    // method 30771, 0x600043c
    void System.IDisposable.Dispose();
    // method 30772, 0x600043d
    bool MoveNext();
    // method 30773, 0x600043e
    void <>m__Finally1();
    // method 30774, 0x600043f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30775, 0x6000440
    void System.Collections.IEnumerator.Reset();
    // method 30776, 0x6000441
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4116, 0x20000c0
class CustomGamesPanel : Popup {
    // field 16981, runtime offset 68, flags 0x1
    private CustomGameSlot[] gameSlots;
    // field 16982, runtime offset 72, flags 0x1
    private UnityEngine.GameObject loadingPanel;
    // field 16983, runtime offset 76, flags 0x1
    private TMPro.TMP_Dropdown sortDropdown;
    // field 16984, runtime offset 80, flags 0x1
    private UnityEngine.GameObject findingMatchPanel;
    // field 16985, runtime offset 84, flags 0x1
    private string currentFilter;
    // field 16986, runtime offset 88, flags 0x1
    private int currentSortIndex;
    // field 16987, runtime offset 92, flags 0x1
    private UnityEngine.Coroutine searchCoroutine;
    // method 30746, 0x6000423
    void OpenURL(string x);
    // method 30747, 0x6000424
    void Show();
    // method 30748, 0x6000425
    void Close(System.Action onfinish);
    // method 30749, 0x6000426
    void OnMapFilter(string mapFilter);
    // method 30750, 0x6000427
    void OnSortChanged(int sortIndex);
    // method 30751, 0x6000428
    void DebounceSearch();
    // method 30752, 0x6000429
    System.Collections.IEnumerator DebouncedSearch();
    // method 30753, 0x600042a
    System.Collections.IEnumerator GetPopularMaps();
    // method 30754, 0x600042b
    void OnPlayNowButtonPressed();
    // method 30755, 0x600042c
    string GetSortParam(string _currentFilter, int sortIndex);
    // method 30756, 0x600042d
    void .ctor();
}

// TypeDefinition 4117, 0x20000c5
class MapPreview : object {
    // field 17004, runtime offset 8, flags 0x6
    public string id;
    // field 17005, runtime offset 12, flags 0x6
    public string title;
    // field 17006, runtime offset 16, flags 0x6
    public string description;
    // field 17007, runtime offset 20, flags 0x6
    public string createdBy;
    // field 17008, runtime offset 24, flags 0x6
    public int thumbsUp;
    // field 17009, runtime offset 28, flags 0x6
    public int thumbsDown;
    // field 17010, runtime offset 32, flags 0x6
    public int playCount;
    // field 17011, runtime offset 36, flags 0x6
    public bool isPublic;
    // method 30777, 0x6000442
    void .ctor();
}

// TypeDefinition 4118, 0x20000c6
class MapURLFinder : object {
    // method 30778, 0x6000443
    string MapUrl(string id);
    // method 30779, 0x6000444
    string ThumbnailUrl(string id);
}

// TypeDefinition 4119, 0x20000c7
class MapData : object {
    // field 17012, runtime offset 8, flags 0x6
    public string mapName;
    // field 17013, runtime offset 12, flags 0x6
    public string creatorId;
    // field 17014, runtime offset 16, flags 0x6
    public bool isPublic;
    // field 17015, runtime offset 20, flags 0x6
    public string mapJsonString;
    // method 30780, 0x6000445
    void .ctor(string name, string creator, bool publicStatus, string json);
}

// TypeDefinition 4120, 0x20000c9
class <GetMapConfiguration>d__16 : object {
    // field 17026, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17027, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17028, runtime offset 16, flags 0x6
    public CustomMapLoader <>4__this;
    // field 17029, runtime offset 20, flags 0x6
    public string token;
    // field 17030, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 30796, 0x6000455
    void .ctor(int <>1__state);
    // method 30797, 0x6000456
    void System.IDisposable.Dispose();
    // method 30798, 0x6000457
    bool MoveNext();
    // method 30799, 0x6000458
    void <>m__Finally1();
    // method 30800, 0x6000459
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30801, 0x600045a
    void System.Collections.IEnumerator.Reset();
    // method 30802, 0x600045b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4121, 0x20000ca
class <SendLikeMapRequest>d__21 : object {
    // field 17031, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17032, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17033, runtime offset 16, flags 0x6
    public int value;
    // field 17034, runtime offset 20, flags 0x6
    public string uid;
    // field 17035, runtime offset 24, flags 0x6
    public string mapId;
    // field 17036, runtime offset 28, flags 0x6
    public CustomMapLoader <>4__this;
    // field 17037, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30803, 0x600045c
    void .ctor(int <>1__state);
    // method 30804, 0x600045d
    void System.IDisposable.Dispose();
    // method 30805, 0x600045e
    bool MoveNext();
    // method 30806, 0x600045f
    void <>m__Finally1();
    // method 30807, 0x6000460
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30808, 0x6000461
    void System.Collections.IEnumerator.Reset();
    // method 30809, 0x6000462
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4122, 0x20000cb
class <SetMapConfiguration>d__18 : object {
    // field 17038, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17039, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17040, runtime offset 16, flags 0x6
    public MapConfig config;
    // field 17041, runtime offset 20, flags 0x6
    public CustomMapLoader <>4__this;
    // field 17042, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 30810, 0x6000463
    void .ctor(int <>1__state);
    // method 30811, 0x6000464
    void System.IDisposable.Dispose();
    // method 30812, 0x6000465
    bool MoveNext();
    // method 30813, 0x6000466
    void <>m__Finally1();
    // method 30814, 0x6000467
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30815, 0x6000468
    void System.Collections.IEnumerator.Reset();
    // method 30816, 0x6000469
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4123, 0x20000c8
class CustomMapLoader : UnityEngine.MonoBehaviour {
    // field 17016, runtime offset 0, flags 0x16
    public static CustomMapLoader instance;
    // field 17017, runtime offset 16, flags 0x1
    private MapBuilderData mapBuilderData;
    // field 17018, runtime offset 20, flags 0x1
    private UnityEngine.GameObject[] hideForPlaytestingKourEditor;
    // field 17019, runtime offset 24, flags 0x1
    private UnityEngine.GameObject[] showForPlaytestingKourEditor;
    // field 17020, runtime offset 28, flags 0x1
    private TMPro.TMP_Text customTitleTxt;
    // field 17021, runtime offset 4, flags 0x16
    public static string configJson;
    // field 17022, runtime offset 8, flags 0x16
    public static string currentMapFirestoreId;
    // field 17023, runtime offset 32, flags 0x1
    private string getConfigUrl;
    // field 17024, runtime offset 36, flags 0x1
    private string setConfigUrl;
    // field 17025, runtime offset 40, flags 0x1
    private string likeMapUrl;
    // method 30781, 0x6000446
    bool get_inCustomRoom();
    // method 30782, 0x6000447
    void Start();
    // method 30783, 0x6000448
    void Awake();
    // method 30784, 0x6000449
    void PublishMapToken();
    // method 30785, 0x600044a
    void LoadMapFromJson();
    // method 30786, 0x600044b
    void ApplySpawnPoints(MapInfo mapInfo);
    // method 30787, 0x600044c
    string CustomMapInfo();
    // method 30788, 0x600044d
    System.Collections.IEnumerator GetMapConfiguration(string token);
    // method 30789, 0x600044e
    System.Collections.IEnumerator SetMapConfiguration(MapConfig config);
    // method 30790, 0x600044f
    void LikeMap(int value);
    // method 30791, 0x6000450
    System.Collections.IEnumerator SendLikeMapRequest(int value, string uid, string mapId);
    // method 30792, 0x6000451
    string FormatAPIResult(string resultJson);
    // method 30793, 0x6000452
    void .ctor();
    // method 30794, 0x6000453
    void .cctor();
    // method 30795, 0x6000454
    void <LoadMapFromJson>b__12_0(string user);
}

// TypeDefinition 4124, 0x20000cc
class MapConfig : object {
    // field 17043, runtime offset 8, flags 0x6
    public string token;
    // field 17044, runtime offset 12, flags 0x6
    public string mapConfig;
    // method 30817, 0x600046a
    void .ctor();
}

// TypeDefinition 4125, 0x20000cd
class DailyItemSlot : UnityEngine.MonoBehaviour {
    // field 17045, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image shadow;
    // field 17046, runtime offset 20, flags 0x1
    private UnityEngine.GameObject dim;
    // field 17047, runtime offset 24, flags 0x1
    private TMPro.TMP_Text dayTxt;
    // field 17048, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image iconImage;
    // field 17049, runtime offset 32, flags 0x1
    private TMPro.TMP_Text itemNameTxt;
    // field 17050, runtime offset 36, flags 0x1
    private TMPro.TMP_Text amountTxt;
    // field 17051, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image backgroundImg;
    // field 17052, runtime offset 44, flags 0x1
    private UnityEngine.GameObject checkPanel;
    // method 30818, 0x600046b
    void Init(Item item, int amount, int i, int activeIndex);
    // method 30819, 0x600046c
    void .ctor();
}

// TypeDefinition 4126, 0x20000ce
class DailyRewards : UnityEngine.ScriptableObject {
    // field 17053, runtime offset 12, flags 0x6
    public DailyItem[] items;
    // method 30820, 0x600046d
    void .ctor();
}

// TypeDefinition 4127, 0x20000cf
class DailyItem : object {
    // field 17054, runtime offset 8, flags 0x6
    public Item item;
    // field 17055, runtime offset 12, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt amount;
    // method 30821, 0x600046e
    void .ctor();
}

// TypeDefinition 4128, 0x20000d1
class DateData : object {
    // field 17066, runtime offset 8, flags 0x6
    public string currentDate;
    // method 30842, 0x6000483
    void .ctor();
}

// TypeDefinition 4129, 0x20000d2
class <>c__DisplayClass13_0 : object {
    // field 17067, runtime offset 8, flags 0x6
    public DailyRewardsPanel <>4__this;
    // field 17068, runtime offset 12, flags 0x6
    public DailyItem currentDailyItem;
    // field 17069, runtime offset 16, flags 0x6
    public System.Action<string> <>9__1;
    // method 30843, 0x6000484
    void .ctor();
    // method 30844, 0x6000485
    void <ForceClaimCurrent>b__0(string success1);
    // method 30845, 0x6000486
    void <ForceClaimCurrent>b__1(string success2);
}

// TypeDefinition 4130, 0x20000d3
class <>c__DisplayClass20_0 : object {
    // field 17070, runtime offset 8, flags 0x6
    public DailyItem dailyItem;
    // method 30846, 0x6000487
    void .ctor();
    // method 30847, 0x6000488
    void <GiveItem>b__0();
}

// TypeDefinition 4131, 0x20000d4
class <>c__DisplayClass20_1 : object {
    // field 17071, runtime offset 8, flags 0x6
    public Item item;
    // field 17072, runtime offset 12, flags 0x6
    public string customTitle;
    // field 17073, runtime offset 16, flags 0x6
    public DG.Tweening.TweenCallback <>9__2;
    // method 30848, 0x6000489
    void .ctor();
    // method 30849, 0x600048a
    void <GiveItem>b__1();
    // method 30850, 0x600048b
    void <GiveItem>b__2();
}

// TypeDefinition 4132, 0x20000d5
class <IenuGetServerDate>d__22 : object {
    // field 17074, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17075, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17076, runtime offset 16, flags 0x6
    public DailyRewardsPanel <>4__this;
    // field 17077, runtime offset 20, flags 0x6
    public System.Action<string> on;
    // field 17078, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 30851, 0x600048c
    void .ctor(int <>1__state);
    // method 30852, 0x600048d
    void System.IDisposable.Dispose();
    // method 30853, 0x600048e
    bool MoveNext();
    // method 30854, 0x600048f
    void <>m__Finally1();
    // method 30855, 0x6000490
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30856, 0x6000491
    void System.Collections.IEnumerator.Reset();
    // method 30857, 0x6000492
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4133, 0x20000d0
class DailyRewardsPanel : Popup {
    // field 17056, runtime offset 68, flags 0x1
    private UnityEngine.GameObject adIcon;
    // field 17057, runtime offset 72, flags 0x1
    private UnityEngine.GameObject loadingDatePanel;
    // field 17058, runtime offset 76, flags 0x1
    private TMPro.TMP_Text claimRewardButtonTxt;
    // field 17059, runtime offset 80, flags 0x1
    private TMPro.TMP_Text todayTxt;
    // field 17060, runtime offset 84, flags 0x1
    private DailyRewards dailyRewards;
    // field 17061, runtime offset 88, flags 0x1
    private UnityEngine.RectTransform dailyRewardParent;
    // field 17062, runtime offset 92, flags 0x1
    private DailyItemSlot[] dailyItemSlots;
    // field 17063, runtime offset 0, flags 0x16
    public static DailyRewardsPanel instance;
    // field 17064, runtime offset 4, flags 0x11
    private static string _today;
    // field 17065, runtime offset 8, flags 0x11
    private static bool fetchedNextDayTest;
    // method 30822, 0x600046f
    string get_today();
    // method 30823, 0x6000470
    void set_today(string value);
    // method 30824, 0x6000471
    void ClaimButtonPressed();
    // method 30825, 0x6000472
    void ForceClaimCurrent();
    // method 30826, 0x6000473
    void SlowUpdate();
    // method 30827, 0x6000474
    void Show();
    // method 30828, 0x6000475
    string TimeToNextDayInUtcTime();
    // method 30829, 0x6000476
    bool IsEligibleForAnyReward(out bool needRefresh);
    // method 30830, 0x6000477
    int GetCurrentReward(out DailyItem currentReward);
    // method 30831, 0x6000478
    void GiveItem(DailyItem dailyItem);
    // method 30832, 0x6000479
    void GetServerDate(System.Action<string> on);
    // method 30833, 0x600047a
    System.Collections.IEnumerator IenuGetServerDate(System.Action<string> on);
    // method 30834, 0x600047b
    string SimulateServerDate();
    // method 30835, 0x600047c
    void ProcessDate(string json, System.Action<string> on);
    // method 30836, 0x600047d
    void .ctor();
    // method 30837, 0x600047e
    void .cctor();
    // method 30838, 0x600047f
    void <ClaimButtonPressed>b__12_0(bool x);
    // method 30839, 0x6000480
    void <SlowUpdate>b__14_0();
    // method 30840, 0x6000481
    void <SlowUpdate>b__14_1();
    // method 30841, 0x6000482
    void <Show>b__15_0(string x);
}

// TypeDefinition 4134, 0x20000d6
class DamageCircle : UnityEngine.MonoBehaviour {
    // field 17079, runtime offset 16, flags 0x6
    public UnityEngine.Transform me;
    // field 17080, runtime offset 20, flags 0x6
    public UnityEngine.Transform by;
    // field 17081, runtime offset 24, flags 0x1
    private float cachedByEuler;
    // field 17082, runtime offset 28, flags 0x1
    private UnityEngine.RectTransform rt;
    // field 17083, runtime offset 0, flags 0x8051
    private static const float add = 180;
    // method 30858, 0x6000493
    void Init();
    // method 30859, 0x6000494
    void Update();
    // method 30860, 0x6000495
    void .ctor();
}

// TypeDefinition 4135, 0x20000d8
class <IenuRespawn>d__15 : object {
    // field 17094, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17095, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17096, runtime offset 16, flags 0x6
    public DeadCamera <>4__this;
    // field 17097, runtime offset 20, flags 0x1
    private float <autoRespawnTime>5__2;
    // method 30872, 0x60004a1
    void .ctor(int <>1__state);
    // method 30873, 0x60004a2
    void System.IDisposable.Dispose();
    // method 30874, 0x60004a3
    bool MoveNext();
    // method 30875, 0x60004a4
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30876, 0x60004a5
    void System.Collections.IEnumerator.Reset();
    // method 30877, 0x60004a6
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4136, 0x20000d7
class DeadCamera : UnityEngine.MonoBehaviour {
    // field 17084, runtime offset 0, flags 0x8056
    public static const float RESPAWN_BUTTON_BLOCK_TIME = 4;
    // field 17085, runtime offset 16, flags 0x1
    private UnityEngine.Vector3 lastLookAtPosition;
    // field 17086, runtime offset 28, flags 0x1
    private bool hasSetSpectator;
    // field 17087, runtime offset 32, flags 0x1
    private UnityEngine.Camera myCamera;
    // field 17088, runtime offset 36, flags 0x1
    private UnityEngine.Transform spectate;
    // field 17089, runtime offset 40, flags 0x1
    private BackInCanvas currentBackInCanvas;
    // field 17090, runtime offset 44, flags 0x1
    private TMPro.TMP_Text backInTxt;
    // field 17091, runtime offset 48, flags 0x1
    private UnityEngine.Coroutine respawnCoroutine;
    // field 17092, runtime offset 52, flags 0x1
    private bool respawned;
    // field 17093, runtime offset 56, flags 0x1
    private float showTime;
    // method 30861, 0x6000496
    bool get_RESPAWN_BUTTON_ONLY();
    // method 30862, 0x6000497
    void Init(string hitTagName, BackInCanvas backInC, Photon.Realtime.Player killerView, Shooter killer);
    // method 30863, 0x6000498
    void FastRespawn();
    // method 30864, 0x6000499
    void Update();
    // method 30865, 0x600049a
    System.Collections.IEnumerator IenuRespawn();
    // method 30866, 0x600049b
    void OnDestroy();
    // method 30867, 0x600049c
    void .ctor();
    // method 30868, 0x600049d
    void <Init>b__12_0();
    // method 30869, 0x600049e
    void <Init>b__12_1();
    // method 30870, 0x600049f
    void <FastRespawn>b__13_0();
    // method 30871, 0x60004a0
    void <IenuRespawn>b__15_0();
}

// TypeDefinition 4137, 0x20000da
class <DelayCoroutine>d__3 : object {
    // field 17099, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17100, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17101, runtime offset 16, flags 0x6
    public float delayTime;
    // field 17102, runtime offset 20, flags 0x6
    public System.Action action;
    // field 17103, runtime offset 24, flags 0x6
    public UnityEngine.GameObject delayObject;
    // method 30882, 0x60004ab
    void .ctor(int <>1__state);
    // method 30883, 0x60004ac
    void System.IDisposable.Dispose();
    // method 30884, 0x60004ad
    bool MoveNext();
    // method 30885, 0x60004ae
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30886, 0x60004af
    void System.Collections.IEnumerator.Reset();
    // method 30887, 0x60004b0
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4138, 0x20000d9
class DelayUtility : object {
    // field 17098, runtime offset 0, flags 0x11
    private static System.Collections.Generic.Queue<UnityEngine.GameObject> delayObjectPool;
    // method 30878, 0x60004a7
    void Delay(float delayTime, System.Action action);
    // method 30879, 0x60004a8
    UnityEngine.GameObject GetDelayObject();
    // method 30880, 0x60004a9
    System.Collections.IEnumerator DelayCoroutine(float delayTime, System.Action action, UnityEngine.GameObject delayObject);
    // method 30881, 0x60004aa
    void .cctor();
}

// TypeDefinition 4139, 0x20000db
class DestoryAfterTime : UnityEngine.MonoBehaviour {
    // field 17104, runtime offset 16, flags 0x1
    private float afterTime;
    // field 17105, runtime offset 20, flags 0x1
    private bool isMolotov;
    // method 30888, 0x60004b1
    void Start();
    // method 30889, 0x60004b2
    void OnDestroy();
    // method 30890, 0x60004b3
    void .ctor();
}

// TypeDefinition 4140, 0x20000dc
class DestroyOnAnyKey : UnityEngine.MonoBehaviour {
    // field 17106, runtime offset 16, flags 0x1
    private bool requestedToDestroy;
    // method 30891, 0x60004b4
    void Start();
    // method 30892, 0x60004b5
    void Update();
    // method 30893, 0x60004b6
    void .ctor();
}

// TypeDefinition 4141, 0x20000de
class <SetCameraRotation>d__11 : object {
    // field 17121, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17122, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17123, runtime offset 16, flags 0x6
    public EditorCamera <>4__this;
    // field 17124, runtime offset 20, flags 0x6
    public UnityEngine.Vector3 targetForward;
    // field 17125, runtime offset 32, flags 0x1
    private UnityEngine.Quaternion <initialRotation>5__2;
    // field 17126, runtime offset 48, flags 0x1
    private UnityEngine.Quaternion <targetRotation>5__3;
    // field 17127, runtime offset 64, flags 0x1
    private float <t>5__4;
    // method 30906, 0x60004c3
    void .ctor(int <>1__state);
    // method 30907, 0x60004c4
    void System.IDisposable.Dispose();
    // method 30908, 0x60004c5
    bool MoveNext();
    // method 30909, 0x60004c6
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30910, 0x60004c7
    void System.Collections.IEnumerator.Reset();
    // method 30911, 0x60004c8
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4142, 0x20000df
class <SwitchProjection>d__10 : object {
    // field 17128, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17129, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17130, runtime offset 16, flags 0x6
    public EditorCamera <>4__this;
    // field 17131, runtime offset 20, flags 0x1
    private bool <isOrthographic>5__2;
    // field 17132, runtime offset 24, flags 0x1
    private UnityEngine.Matrix4x4 <dest>5__3;
    // field 17133, runtime offset 88, flags 0x1
    private UnityEngine.Matrix4x4 <src>5__4;
    // field 17134, runtime offset 152, flags 0x1
    private float <t>5__5;
    // method 30912, 0x60004c9
    void .ctor(int <>1__state);
    // method 30913, 0x60004ca
    void System.IDisposable.Dispose();
    // method 30914, 0x60004cb
    bool MoveNext();
    // method 30915, 0x60004cc
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 30916, 0x60004cd
    void System.Collections.IEnumerator.Reset();
    // method 30917, 0x60004ce
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4143, 0x20000dd
class EditorCamera : UnityEngine.MonoBehaviour {
    // field 17107, runtime offset 16, flags 0x1
    private float cameraAdjustmentSpeed;
    // field 17108, runtime offset 20, flags 0x1
    private float projectionTransitionSpeed;
    // field 17109, runtime offset 24, flags 0x1
    private UnityEngine.Camera mainCamera;
    // field 17110, runtime offset 28, flags 0x1
    private UnityEngine.Transform mainCamParent;
    // field 17111, runtime offset 32, flags 0x1
    private System.Collections.IEnumerator cameraRotateCoroutine;
    // field 17112, runtime offset 36, flags 0x1
    private System.Collections.IEnumerator projectionChangeCoroutine;
    // field 17113, runtime offset 40, flags 0x1
    private float senseMulti;
    // field 17114, runtime offset 44, flags 0x6
    public float xRotation;
    // field 17115, runtime offset 48, flags 0x6
    public float yRotation;
    // field 17116, runtime offset 52, flags 0x6
    public float speed;
    // field 17117, runtime offset 56, flags 0x1
    private float smoothness;
    // field 17118, runtime offset 60, flags 0x1
    private float current3rdAxis;
    // field 17119, runtime offset 64, flags 0x1
    private float currentVerticalAxis;
    // field 17120, runtime offset 68, flags 0x1
    private float currentHorizontalAxis;
    // method 30894, 0x60004b7
    void Awake();
    // method 30895, 0x60004b8
    void OnDisable();
    // method 30896, 0x60004b9
    void SwitchOrthographicMode();
    // method 30897, 0x60004ba
    void RotateCameraInDirection(UnityEngine.Vector3 direction);
    // method 30898, 0x60004bb
    System.Collections.IEnumerator SwitchProjection();
    // method 30899, 0x60004bc
    System.Collections.IEnumerator SetCameraRotation(UnityEngine.Vector3 targetForward);
    // method 30900, 0x60004bd
    void Start();
    // method 30901, 0x60004be
    void Update();
    // method 30902, 0x60004bf
    float Get3rdAxis();
    // method 30903, 0x60004c0
    float GetVerticalAxis();
    // method 30904, 0x60004c1
    float GetHorizontalAxis();
    // method 30905, 0x60004c2
    void .ctor();
}

// TypeDefinition 4144, 0x20000e0
class EditorNavigation : UnityEngine.MonoBehaviour {
    // field 17135, runtime offset 16, flags 0x1
    private UnityEngine.GameObject projectSettingsPanel;
    // field 17136, runtime offset 20, flags 0x1
    private UnityEngine.GameObject[] settingsSideHighlighters;
    // field 17137, runtime offset 24, flags 0x1
    private UnityEngine.GameObject[] settingsPanels;
    // method 30918, 0x60004cf
    void SetLabel(int x);
    // method 30919, 0x60004d0
    void ShowSettings();
    // method 30920, 0x60004d1
    void .ctor();
}

// TypeDefinition 4145, 0x20000e1
class Egg : UnityEngine.MonoBehaviour {
    // field 17138, runtime offset 16, flags 0x1
    private UnityEngine.Texture2D[] textures;
    // field 17139, runtime offset 20, flags 0x1
    private int myTextureIndex;
    // method 30921, 0x60004d2
    void Init();
    // method 30922, 0x60004d3
    void Die();
    // method 30923, 0x60004d4
    void .ctor();
}

// TypeDefinition 4146, 0x20000e2
class Emote : Item {
    // field 17140, runtime offset 68, flags 0x6
    public UnityEngine.AudioClip clip;
    // field 17141, runtime offset 72, flags 0x6
    public UnityEngine.AnimationClip animationClip;
    // field 17142, runtime offset 76, flags 0x6
    public float audioPitch;
    // field 17143, runtime offset 80, flags 0x6
    public float audioVolume;
    // field 17144, runtime offset 84, flags 0x6
    public float animationTimeAdd;
    // method 30924, 0x60004d5
    string get_IsCurrentKey();
    // method 30925, 0x60004d6
    string get_HasItKey();
    // method 30926, 0x60004d7
    int get_AmountHave();
    // method 30927, 0x60004d8
    void .ctor();
}

// TypeDefinition 4147, 0x20000e3
class Encryptor : object {
}

// TypeDefinition 4148, 0x20000e4
class ExpandedGameplayLeaderboard : UnityEngine.MonoBehaviour {
    // field 17145, runtime offset 16, flags 0x6
    public GameLeaderboardSlot[] slots;
    // field 17146, runtime offset 20, flags 0x1
    private GameLeaderboardSlot[] secondarySlots;
    // field 17147, runtime offset 24, flags 0x1
    private TMPro.TMP_Text[] teamTxts;
    // field 17148, runtime offset 28, flags 0x1
    private TMPro.TMP_Text[] teamNameTxts;
    // field 17149, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image[] teamImages;
    // field 17150, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image[] teamOutlineImages;
    // method 30928, 0x60004d9
    void Set(LeaderboardManager use, bool active, bool gameEnded);
    // method 30929, 0x60004da
    UnityEngine.Color Change(UnityEngine.Color originalColor);
    // method 30930, 0x60004db
    UnityEngine.Color CombineWhite(UnityEngine.Color originalColor);
    // method 30931, 0x60004dc
    void .ctor();
}

// TypeDefinition 4149, 0x20000e5
class ExplosionEffect : UnityEngine.MonoBehaviour {
    // field 17151, runtime offset 16, flags 0x1
    private float life;
    // method 30932, 0x60004dd
    void Start();
    // method 30933, 0x60004de
    void Des();
    // method 30934, 0x60004df
    void .ctor();
}

// TypeDefinition 4150, 0x20000e6
class ExplosiveBarrel : UnityEngine.MonoBehaviour {
    // field 17152, runtime offset 16, flags 0x1
    private UnityEngine.LayerMask explosionLayerMask;
    // field 17153, runtime offset 20, flags 0x1
    private Photon.Pun.UtilityScripts.PhotonTeam myTeam;
    // field 17154, runtime offset 24, flags 0x1
    private UnityEngine.ParticleSystem[] effects;
    // field 17155, runtime offset 28, flags 0x1
    private UnityEngine.Transform gfx;
    // field 17156, runtime offset 32, flags 0x1
    private UnityEngine.Collider myCollider;
    // field 17157, runtime offset 36, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 17158, runtime offset 40, flags 0x1
    private double lastExplosion;
    // field 17159, runtime offset 0, flags 0x8051
    private static const float REGEN = 90;
    // field 17160, runtime offset 0, flags 0x8051
    private static const float MAX_DAMAGE_RADIUS = 14;
    // field 17161, runtime offset 0, flags 0x8051
    private static const int damage = 150;
    // field 17162, runtime offset 48, flags 0x1
    private Shooter myShooter;
    // method 30935, 0x60004e0
    void Explodato(double atTime, bool isMine, Shooter _myShooter);
    // method 30936, 0x60004e1
    float CalculateDamageByDistance(float currentDistance, float minDistance, float maxDistance, float maxDamage);
    // method 30937, 0x60004e2
    void Update();
    // method 30938, 0x60004e3
    int[] GetTargetIDs(int givenAmount, UnityEngine.Collider[] cols, out UnityEngine.Transform[] transforms);
    // method 30939, 0x60004e4
    void .ctor();
}

// TypeDefinition 4151, 0x20000e7
class FPSArms : UnityEngine.MonoBehaviour {
    // field 17163, runtime offset 16, flags 0x6
    public UnityEngine.SkinnedMeshRenderer[] handsMeshRenderers;
    // method 30940, 0x60004e5
    void .ctor();
}

// TypeDefinition 4152, 0x20000e8
class FPSManager : UnityEngine.MonoBehaviour {
    // method 30941, 0x60004e6
    void Start();
    // method 30942, 0x60004e7
    void Update();
    // method 30943, 0x60004e8
    void .ctor();
}

// TypeDefinition 4153, 0x20000ea
class <>c__DisplayClass5_0 : object {
    // field 17169, runtime offset 8, flags 0x6
    public FallingCamera <>4__this;
    // field 17170, runtime offset 12, flags 0x6
    public UnityEngine.Vector3 startPosition;
    // field 17171, runtime offset 24, flags 0x6
    public UnityEngine.Camera transitionToCamera;
    // field 17172, runtime offset 28, flags 0x6
    public UnityEngine.Quaternion startRotation;
    // field 17173, runtime offset 44, flags 0x6
    public float startFOV;
    // method 30948, 0x60004ed
    void .ctor();
    // method 30949, 0x60004ee
    void <Land>b__0(float value);
    // method 30950, 0x60004ef
    void <Land>b__1();
}

// TypeDefinition 4154, 0x20000e9
class FallingCamera : UnityEngine.MonoBehaviour {
    // field 17164, runtime offset 16, flags 0x1
    private UnityEngine.Camera cam;
    // field 17165, runtime offset 20, flags 0x1
    private PlayerController playerController;
    // field 17166, runtime offset 24, flags 0x1
    private UnityEngine.Vector3 lerpPosition;
    // field 17167, runtime offset 36, flags 0x1
    private UnityEngine.Quaternion lerpRotation;
    // field 17168, runtime offset 52, flags 0x1
    private float lerpSpeed;
    // method 30944, 0x60004e9
    void Land(UnityEngine.Camera transitionToCamera);
    // method 30945, 0x60004ea
    void OnEnable();
    // method 30946, 0x60004eb
    void Update();
    // method 30947, 0x60004ec
    void .ctor();
}

// TypeDefinition 4155, 0x20000ec
class UploadImageCallback : System.MulticastDelegate {
    // method 31051, 0x6000554
    void .ctor(object object, nint method);
    // method 31052, 0x6000555
    void Invoke(string downloadURL);
    // method 31053, 0x6000556
    System.IAsyncResult BeginInvoke(string downloadURL, System.AsyncCallback callback, object object);
    // method 31054, 0x6000557
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4156, 0x20000ed
class GetLeaderboardCallback : System.MulticastDelegate {
    // method 31055, 0x6000558
    void .ctor(object object, nint method);
    // method 31056, 0x6000559
    void Invoke(string result);
    // method 31057, 0x600055a
    System.IAsyncResult BeginInvoke(string result, System.AsyncCallback callback, object object);
    // method 31058, 0x600055b
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4157, 0x20000ee
class UserSetCallback : System.MulticastDelegate {
    // method 31059, 0x600055c
    void .ctor(object object, nint method);
    // method 31060, 0x600055d
    void Invoke(bool isRegister);
    // method 31061, 0x600055e
    System.IAsyncResult BeginInvoke(bool isRegister, System.AsyncCallback callback, object object);
    // method 31062, 0x600055f
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4158, 0x20000ef
class DateCallback : System.MulticastDelegate {
    // method 31063, 0x6000560
    void .ctor(object object, nint method);
    // method 31064, 0x6000561
    void Invoke(string date);
    // method 31065, 0x6000562
    System.IAsyncResult BeginInvoke(string date, System.AsyncCallback callback, object object);
    // method 31066, 0x6000563
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4159, 0x20000f0
class StringCallback : System.MulticastDelegate {
    // method 31067, 0x6000564
    void .ctor(object object, nint method);
    // method 31068, 0x6000565
    void Invoke(string str);
    // method 31069, 0x6000566
    System.IAsyncResult BeginInvoke(string str, System.AsyncCallback callback, object object);
    // method 31070, 0x6000567
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4160, 0x20000f1
class ClanData : object {
    // field 17202, runtime offset 8, flags 0x6
    public string Name;
    // field 17203, runtime offset 12, flags 0x6
    public string Color;
    // field 17204, runtime offset 16, flags 0x6
    public int MemberCount;
    // method 31071, 0x6000568
    void .ctor();
}

// TypeDefinition 4161, 0x20000f2
class ClanInfo : object {
    // field 17205, runtime offset 8, flags 0x1
    private string <Name>k__BackingField;
    // field 17206, runtime offset 12, flags 0x1
    private string <Color>k__BackingField;
    // field 17207, runtime offset 16, flags 0x1
    private System.Collections.Generic.Dictionary<string, bool> <Members>k__BackingField;
    // method 31072, 0x6000569
    void .ctor();
    // method 31073, 0x600056a
    string get_Name();
    // method 31074, 0x600056b
    void set_Name(string value);
    // method 31075, 0x600056c
    string get_Color();
    // method 31076, 0x600056d
    void set_Color(string value);
    // method 31077, 0x600056e
    System.Collections.Generic.Dictionary<string, bool> get_Members();
    // method 31078, 0x600056f
    void set_Members(System.Collections.Generic.Dictionary<string, bool> value);
}

// TypeDefinition 4162, 0x20000f3
class IntBoolPair : object {
    // field 17208, runtime offset 8, flags 0x6
    public int intValue;
    // field 17209, runtime offset 12, flags 0x6
    public bool boolValue;
    // method 31079, 0x6000570
    void .ctor(int intValue, bool boolValue);
}

// TypeDefinition 4163, 0x20000f4
class <>c : object {
    // field 17210, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17211, runtime offset 4, flags 0x16
    public static System.Action <>9__119_0;
    // field 17212, runtime offset 8, flags 0x16
    public static System.Action <>9__119_1;
    // field 17213, runtime offset 12, flags 0x16
    public static System.Action <>9__127_0;
    // method 31080, 0x6000571
    void .cctor();
    // method 31081, 0x6000572
    void .ctor();
    // method 31082, 0x6000573
    void <OnSessionError>b__119_0();
    // method 31083, 0x6000574
    void <OnSessionError>b__119_1();
    // method 31084, 0x6000575
    void <OnFriendError>b__127_0();
}

// TypeDefinition 4164, 0x20000f5
class <>c__DisplayClass107_0 : object {
    // field 17214, runtime offset 8, flags 0x6
    public bool reverse;
    // method 31085, 0x6000576
    void .ctor();
    // method 31086, 0x6000577
    int <SortLB>b__0(LeaderboardSlot slot1, LeaderboardSlot slot2);
}

// TypeDefinition 4165, 0x20000f6
class <>c__DisplayClass109_0 : object {
    // field 17215, runtime offset 8, flags 0x6
    public string uid;
    // field 17216, runtime offset 12, flags 0x6
    public System.Action<string> callback;
    // method 31087, 0x6000578
    void .ctor();
    // method 31088, 0x6000579
    void <GetUsernameByUID>b__0(string usrName);
}

// TypeDefinition 4166, 0x20000f7
class <>c__DisplayClass113_0 : object {
    // field 17217, runtime offset 8, flags 0x6
    public System.Action<string> call;
    // field 17218, runtime offset 12, flags 0x6
    public bool isPublic;
    // field 17219, runtime offset 16, flags 0x6
    public string varname;
    // field 17220, runtime offset 20, flags 0x6
    public string value;
    // method 31089, 0x600057a
    void .ctor();
    // method 31090, 0x600057b
    void <SetData>b__0();
}

// TypeDefinition 4167, 0x20000f8
class <>c__DisplayClass133_0 : object {
    // field 17221, runtime offset 8, flags 0x6
    public System.Action<string> then;
    // method 31091, 0x600057c
    void .ctor();
    // method 31092, 0x600057d
    void <SendFriendRequestTo>b__0(string otherUid);
}

// TypeDefinition 4168, 0x20000f9
class <>c__DisplayClass32_0 : object {
    // field 17222, runtime offset 8, flags 0x6
    public System.Collections.Generic.HashSet<string> seenSprites;
    // method 31093, 0x600057e
    void .ctor();
    // method 31094, 0x600057f
    string <RemoveTagsKeepColorAndVerify>b__0(System.Text.RegularExpressions.Match match);
}

// TypeDefinition 4169, 0x20000fa
class <>c__DisplayClass63_0 : object {
    // field 17223, runtime offset 8, flags 0x6
    public UserSetCallback call;
    // field 17224, runtime offset 12, flags 0x6
    public System.Collections.Generic.Dictionary<string, string> defaultJson;
    // field 17225, runtime offset 16, flags 0x6
    public System.Collections.Generic.Dictionary<string, string> defaultPublicJson;
    // field 17226, runtime offset 20, flags 0x6
    public System.Action<string> <>9__2;
    // method 31095, 0x6000580
    void .ctor();
    // method 31096, 0x6000581
    void <SetUser>b__0();
    // method 31097, 0x6000582
    void <SetUser>b__1(string json);
    // method 31098, 0x6000583
    void <SetUser>b__2(string x);
}

// TypeDefinition 4170, 0x20000fb
class <>c__DisplayClass75_0 : object {
    // field 17227, runtime offset 8, flags 0x6
    public System.Action<string> setCallback;
    // field 17228, runtime offset 12, flags 0x6
    public System.Action<string> <>9__0;
    // method 31099, 0x6000584
    void .ctor();
    // method 31100, 0x6000585
    void <SetInts>b__0(string r);
}

// TypeDefinition 4171, 0x20000fc
class <>c__DisplayClass79_0 : object {
    // field 17229, runtime offset 8, flags 0x6
    public System.Action<int> getCallback;
    // method 31101, 0x6000586
    void .ctor();
    // method 31102, 0x6000587
    void <GetPublicInt>b__0(string result);
}

// TypeDefinition 4172, 0x20000fd
class <>c__DisplayClass80_0 : object {
    // field 17230, runtime offset 8, flags 0x6
    public System.Action<string> setCallback;
    // method 31103, 0x6000588
    void .ctor();
    // method 31104, 0x6000589
    void <SetPublicInt>b__0(string result);
}

// TypeDefinition 4173, 0x20000fe
class <>c__DisplayClass81_0 : object {
    // field 17231, runtime offset 8, flags 0x6
    public System.Action<int> getCallback;
    // field 17232, runtime offset 12, flags 0x6
    public int defaultValue;
    // method 31105, 0x600058a
    void .ctor();
    // method 31106, 0x600058b
    void <GetInt>b__0(string result);
}

// TypeDefinition 4174, 0x20000ff
class <>c__DisplayClass83_0 : object {
    // field 17233, runtime offset 8, flags 0x6
    public System.Action<string> getCallback;
    // method 31107, 0x600058c
    void .ctor();
    // method 31108, 0x600058d
    void <GetRealString>b__0(string result);
}

// TypeDefinition 4175, 0x2000100
class <IenuGetLeaderboard>d__91 : object {
    // field 17234, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17235, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17236, runtime offset 16, flags 0x6
    public string identifier;
    // field 17237, runtime offset 20, flags 0x6
    public FirebasePlayerPrefs2023 <>4__this;
    // field 17238, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 31109, 0x600058e
    void .ctor(int <>1__state);
    // method 31110, 0x600058f
    void System.IDisposable.Dispose();
    // method 31111, 0x6000590
    bool MoveNext();
    // method 31112, 0x6000591
    void <>m__Finally1();
    // method 31113, 0x6000592
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31114, 0x6000593
    void System.Collections.IEnumerator.Reset();
    // method 31115, 0x6000594
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4176, 0x20000eb
class FirebasePlayerPrefs2023 : UnityEngine.MonoBehaviour {
    // field 17174, runtime offset 16, flags 0x1
    private bool connectedFirstTime;
    // field 17175, runtime offset 0, flags 0x8051
    private static const string COINS_KEY = "tekg2";
    // field 17176, runtime offset 0, flags 0x11
    private static System.Action<string> usernameLoginThen;
    // field 17177, runtime offset 4, flags 0x11
    private static System.Action<string> usernameRegisterThen;
    // field 17178, runtime offset 8, flags 0x16
    public static User currentUser;
    // field 17179, runtime offset 24, flags 0x11
    private static System.Action<string> onLoginGoogle;
    // field 17180, runtime offset 28, flags 0x11
    private static System.Action<User, bool> OnUserChanged;
    // field 17181, runtime offset 20, flags 0x1
    private float googleLoginTimer;
    // field 17182, runtime offset 32, flags 0x16
    public static bool lockCoins;
    // field 17183, runtime offset 36, flags 0x16
    public static FirebasePlayerPrefs2023 Instance;
    // field 17184, runtime offset 0, flags 0x8056
    public static const string SUCCESS = "Success";
    // field 17185, runtime offset 0, flags 0x8056
    public static const string FAILED = "Failed";
    // field 17186, runtime offset 0, flags 0x8056
    public static const string RESULT_SPLITTER = "&";
    // field 17187, runtime offset 0, flags 0x8056
    public static const string USERS_ROOT = "users";
    // field 17188, runtime offset 40, flags 0x11
    private static System.Collections.Generic.Dictionary<string, System.Action<string>> setCallbackDictionary;
    // field 17189, runtime offset 44, flags 0x11
    private static System.Collections.Generic.Dictionary<string, System.Action<string>> setCallbackDictionaryNew;
    // field 17190, runtime offset 48, flags 0x11
    private static System.Collections.Generic.Dictionary<string, System.Action<string>> getCallbackDictionary;
    // field 17191, runtime offset 52, flags 0x11
    private static System.Collections.Generic.Dictionary<string, string> localUserData;
    // field 17192, runtime offset 56, flags 0x11
    private static string MYUID;
    // field 17193, runtime offset 60, flags 0x11
    private static bool isUnityEditor;
    // field 17194, runtime offset 64, flags 0x16
    public static string cgPasswordCache;
    // field 17195, runtime offset 68, flags 0x11
    private static System.Collections.Generic.Dictionary<string, DG.Tweening.Tween> debouncers;
    // field 17196, runtime offset 72, flags 0x11
    private static System.Action<string> currentGetPromoCallback;
    // field 17197, runtime offset 24, flags 0x1
    private System.Action<string> currentAddPointsCallback;
    // field 17198, runtime offset 76, flags 0x31
    private static System.Collections.Generic.Dictionary<string, string> usernameCache;
    // field 17199, runtime offset 28, flags 0x1
    private int lastFriendRequestSize;
    // field 17200, runtime offset 80, flags 0x11
    private static System.Action<string> currentGetUserIdOfUsernameCall;
    // field 17201, runtime offset 84, flags 0x11
    private static System.Action<string> friendReqThen;
    // method 30951, 0x60004f0
    string GetEmailExtension();
    // method 30952, 0x60004f1
    void ond();
    // method 30953, 0x60004f2
    void onc();
    // method 30954, 0x60004f3
    float DEBOUNCE_TIME(string ofKey);
    // method 30955, 0x60004f4
    void DeleteKey(string whatKey);
    // method 30956, 0x60004f5
    string GetStringFromJson(string key, string fullJson);
    // method 30957, 0x60004f6
    int CustomPublicJsonInt(string str, string rawCall, int _default);
    // method 30958, 0x60004f7
    bool IsValidString(string input);
    // method 30959, 0x60004f8
    void UsernameLogin(string username, string password, System.Action<string> then);
    // method 30960, 0x60004f9
    void UsernameLoginResultJS(string res);
    // method 30961, 0x60004fa
    void UsernameRegister(string username, string password, System.Action<string> then);
    // method 30962, 0x60004fb
    void UsernameRegisterResultJS(string res);
    // method 30963, 0x60004fc
    void SetUserFromLoginData(string loginData, bool setNamePrefs);
    // method 30964, 0x60004fd
    void Logout();
    // method 30965, 0x60004fe
    void GoogleLogin(System.Action<string> _onLoginGoogle);
    // method 30966, 0x60004ff
    void OnGoogleLogin(string r);
    // method 30967, 0x6000500
    void OnLoggedOutGoogle();
    // method 30968, 0x6000501
    void add_OnUserChanged(System.Action<User, bool> value);
    // method 30969, 0x6000502
    void remove_OnUserChanged(System.Action<User, bool> value);
    // method 30970, 0x6000503
    string GetCurrentDateInCustomFormat();
    // method 30971, 0x6000504
    string RemoveTagsNew(string input);
    // method 30972, 0x6000505
    string RemoveClanIfAny(string x);
    // method 30973, 0x6000506
    string RemoveMultiSpaces(string x);
    // method 30974, 0x6000507
    void RunVerifiedCheck(TMPro.TMP_Text originalTxt);
    // method 30975, 0x6000508
    string RemoveTagsKeepColorAndVerify(string input, int characterLimit);
    // method 30976, 0x6000509
    void OnLoggedInGoogle(string loginData);
    // method 30977, 0x600050a
    void OnLoginOrRegisterVoid(bool isRegister);
    // method 30978, 0x600050b
    void AddSession();
    // method 30979, 0x600050c
    System.Collections.Generic.Dictionary<string, string> GetLocalUserData();
    // method 30980, 0x600050d
    void Awake();
    // method 30981, 0x600050e
    void LogOut();
    // method 30982, 0x600050f
    void OnCgP(string crazyGamesPassword);
    // method 30983, 0x6000510
    void Start();
    // method 30984, 0x6000511
    bool get_IsLoggedIn();
    // method 30985, 0x6000512
    string get_CurrentUsername();
    // method 30986, 0x6000513
    void SetUser(string uid, System.Collections.Generic.Dictionary<string, string> defaultJson, System.Collections.Generic.Dictionary<string, string> defaultPublicJson, UserSetCallback call);
    // method 30987, 0x6000514
    System.Collections.Generic.Dictionary<string, string> CombineDictionaries(System.Collections.Generic.Dictionary<string, string> dict1, System.Collections.Generic.Dictionary<string, string> dict2);
    // method 30988, 0x6000515
    string GetUser();
    // method 30989, 0x6000516
    void SetInt(string intName, int val, System.Action<string> setCallback, bool isPublic);
    // method 30990, 0x6000517
    string MakeValidFirebaseKey(string input);
    // method 30991, 0x6000518
    void AddInt(string intName, int val, out int newInt, System.Action<string> setCallback, bool isPublic);
    // method 30992, 0x6000519
    void AddInt(string intName, int val, System.Action<string> setCallback, bool isPublic);
    // method 30993, 0x600051a
    string MakeOKForFirebaseOptimized(string input);
    // method 30994, 0x600051b
    void UsePromoCode(string promoName, System.Action<string> c);
    // method 30995, 0x600051c
    void OnGetPromoCode(string result);
    // method 30996, 0x600051d
    void SetInts(string[] intNames, int[] vals, System.Action<string> setCallback);
    // method 30997, 0x600051e
    int GetInt(string intName, int defaultValue);
    // method 30998, 0x600051f
    string GetString(string stringName, string defaultValue);
    // method 30999, 0x6000520
    void GetRealInt(string intName, System.Action<int> getCallback);
    // method 31000, 0x6000521
    void GetPublicInt(string ofUser, string intName, System.Action<int> getCallback);
    // method 31001, 0x6000522
    void SetPublicInt(string ofUser, string intName, System.Action<string> setCallback);
    // method 31002, 0x6000523
    void GetInt(string intName, int defaultValue, System.Action<int> getCallback, bool isPublic);
    // method 31003, 0x6000524
    void SetString(string stringName, string val, System.Action<string> setCallback, bool isPublic);
    // method 31004, 0x6000525
    void GetRealString(string stringName, System.Action<string> getCallback);
    // method 31005, 0x6000526
    void GetDataOn(string path, bool forceLatest, System.Action<string> rawCall);
    // method 31006, 0x6000527
    void GetData(string varname, System.Action<string> call, bool isPublic);
    // method 31007, 0x6000528
    string GetUniqueStringForCurrentDay();
    // method 31008, 0x6000529
    string GetUniqueStringForCurrentWeek();
    // method 31009, 0x600052a
    string GetUniqueStringForCurrentMonth();
    // method 31010, 0x600052b
    void GetLeaderboard(string leaderboardIdentifier);
    // method 31011, 0x600052c
    System.Collections.IEnumerator IenuGetLeaderboard(string identifier);
    // method 31012, 0x600052d
    ClanData[] ParseJsonToClanData(string jsonString);
    // method 31013, 0x600052e
    void OnGotLeaderboard(string leaderboardDataStr, string statKey);
    // method 31014, 0x600052f
    void SetPointsToLeaderboards(System.Collections.Generic.Dictionary<string, int> leaderboards, System.Action<string> onSet);
    // method 31015, 0x6000530
    void OnAddedPoints(string result);
    // method 31016, 0x6000531
    System.Collections.Generic.List<LeaderboardSlot> ConvertNewLeaderboardData(string apiResponse, string statKey);
    // method 31017, 0x6000532
    float FindMetricValueFromJSON(SimpleJSON.JSONNode item, string statKey);
    // method 31018, 0x6000533
    float FindMetricValue(System.Collections.Generic.Dictionary<string, object> item);
    // method 31019, 0x6000534
    System.DateTime ConvertToTimestamp(long timestamp);
    // method 31020, 0x6000535
    string GetMonthlyResetText();
    // method 31021, 0x6000536
    string GetWeeklyResetText();
    // method 31022, 0x6000537
    string GetDailyResetText();
    // method 31023, 0x6000538
    string FormatTimeSpan(System.TimeSpan timeSpan);
    // method 31024, 0x6000539
    System.Collections.Generic.List<LeaderboardSlot> SortLB(System.Collections.Generic.List<LeaderboardSlot> leaderboard, bool reverse);
    // method 31025, 0x600053a
    void GetUsernameByUID(string uid, System.Action<string> callback);
    // method 31026, 0x600053b
    void GetUserData(System.Action<string> call);
    // method 31027, 0x600053c
    void SetUserData(string jsonString, string publicJsonString, System.Action<string> call);
    // method 31028, 0x600053d
    void CallSetDataFunc(string funcName, System.Action<string> call, object[] parameters);
    // method 31029, 0x600053e
    void SetData(string varname, string value, System.Action<string> call, bool isPublic);
    // method 31030, 0x600053f
    void AdminSetData(string uid, string varname, string value, System.Action<string> call, bool isPublic);
    // method 31031, 0x6000540
    void CreateClan(string clanName, string clanColorHex, System.Action<string> setCallback);
    // method 31032, 0x6000541
    void OnGotData(string data);
    // method 31033, 0x6000542
    string[] GetDayWeekMonth();
    // method 31034, 0x6000543
    string[] GetLastDayWeekMonth();
    // method 31035, 0x6000544
    void OnSessionError(string err);
    // method 31036, 0x6000545
    void OnSetData(string result);
    // method 31037, 0x6000546
    void OnSetDataNew(string result);
    // method 31038, 0x6000547
    bool HasKey(string key);
    // method 31039, 0x6000548
    void GetFriendsAndRequests();
    // method 31040, 0x6000549
    void OnFriendsUpdate(string friendsList);
    // method 31041, 0x600054a
    void OnFriendRequestsUpdate(string requestsList);
    // method 31042, 0x600054b
    void OnFriendError(string whatWentWrong);
    // method 31043, 0x600054c
    void DecideFriendRequest(string otherUID, bool accept);
    // method 31044, 0x600054d
    void GetUserIdOfUsername(string username, System.Action<string> call);
    // method 31045, 0x600054e
    void OnGotUserUID(string userId);
    // method 31046, 0x600054f
    void SendFriendRequestTo(string whoUsername, System.Action<string> then);
    // method 31047, 0x6000550
    void OnSentFriendRequest(string result);
    // method 31048, 0x6000551
    void OnInvite(string pars);
    // method 31049, 0x6000552
    void .ctor();
    // method 31050, 0x6000553
    void .cctor();
}

// TypeDefinition 4177, 0x2000101
class JsonAndDictionary : object {
    // method 31116, 0x6000595
    System.Collections.Generic.Dictionary<string, string> ConvertToDictionary(string jsonString);
    // method 31117, 0x6000596
    void ExtractKeyValues(SimpleJSON.JSONNode jsonObject, System.Collections.Generic.Dictionary<string, string> dictionary);
    // method 31118, 0x6000597
    string GetValue(System.Collections.Generic.Dictionary<string, string> dictionary, string key);
    // method 31119, 0x6000598
    string ToJson(System.Collections.Generic.Dictionary<string, string> dictionary);
}

// TypeDefinition 4178, 0x2000103
class <>c : object {
    // field 17239, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17240, runtime offset 4, flags 0x16
    public static System.Func<string, char> <>9__0_0;
    // method 31122, 0x600059b
    void .cctor();
    // method 31123, 0x600059c
    void .ctor();
    // method 31124, 0x600059d
    char <Generate>b__0_0(string s);
}

// TypeDefinition 4179, 0x2000102
class RandomStringGenerator : object {
    // method 31120, 0x6000599
    string Generate(int length);
    // method 31121, 0x600059a
    void .ctor();
}

// TypeDefinition 4180, 0x2000104
class JsonError : object {
    // field 17241, runtime offset 8, flags 0x6
    public string err;
    // method 31125, 0x600059e
    void .ctor();
}

// TypeDefinition 4181, 0x2000105
class LeaderboardSlot : object {
    // field 17242, runtime offset 8, flags 0x1
    private string <Name>k__BackingField;
    // field 17243, runtime offset 12, flags 0x1
    private float <Value>k__BackingField;
    // field 17244, runtime offset 16, flags 0x1
    private bool <IsClan>k__BackingField;
    // method 31126, 0x600059f
    string get_Name();
    // method 31127, 0x60005a0
    void set_Name(string value);
    // method 31128, 0x60005a1
    float get_Value();
    // method 31129, 0x60005a2
    void set_Value(float value);
    // method 31130, 0x60005a3
    bool get_IsClan();
    // method 31131, 0x60005a4
    void set_IsClan(bool value);
    // method 31132, 0x60005a5
    void .ctor();
}

// TypeDefinition 4182, 0x2000106
class User : System.ValueType {
    // field 17245, runtime offset 8, flags 0x6
    public string displayName;
    // field 17246, runtime offset 12, flags 0x6
    public string email;
    // field 17247, runtime offset 16, flags 0x6
    public string photoURL;
    // field 17248, runtime offset 20, flags 0x6
    public string UID;
    // method 31133, 0x60005a6
    User get_Clean();
    // method 31134, 0x60005a7
    bool get_LoggedIn();
    // method 31135, 0x60005a8
    bool op_Equality(User a, User b);
    // method 31136, 0x60005a9
    bool op_Inequality(User a, User b);
    // method 31137, 0x60005aa
    string ToString();
    // method 31138, 0x60005ab
    bool Equals(object obj);
    // method 31139, 0x60005ac
    int GetHashCode();
}

// TypeDefinition 4183, 0x2000108
class <>c__DisplayClass1_0 : object {
    // field 17254, runtime offset 8, flags 0x6
    public ClanData <>4__this;
    // field 17255, runtime offset 12, flags 0x6
    public System.Action<System.Collections.Generic.List<string>> call;
    // method 31156, 0x60005bd
    void .ctor();
    // method 31157, 0x60005be
    void <GetRequests>b__0(string clanDataString);
}

// TypeDefinition 4184, 0x2000109
class <>c__DisplayClass2_0 : object {
    // field 17256, runtime offset 8, flags 0x6
    public System.Collections.Generic.List<string> currentNames;
    // field 17257, runtime offset 12, flags 0x6
    public int uidIndex;
    // field 17258, runtime offset 16, flags 0x6
    public string[] uidArr;
    // field 17259, runtime offset 20, flags 0x6
    public ClanData <>4__this;
    // field 17260, runtime offset 24, flags 0x6
    public System.Action<System.Collections.Generic.List<string>> call;
    // method 31158, 0x60005bf
    void .ctor();
    // method 31159, 0x60005c0
    void <GetNextMember>b__0(string memberUsername);
}

// TypeDefinition 4185, 0x2000107
class ClanData : object {
    // field 17249, runtime offset 8, flags 0x1
    private string <Name>k__BackingField;
    // field 17250, runtime offset 12, flags 0x1
    private string <LeaderId>k__BackingField;
    // field 17251, runtime offset 16, flags 0x1
    private string <ClanColor>k__BackingField;
    // field 17252, runtime offset 20, flags 0x1
    private string[] <MemberIDs>k__BackingField;
    // field 17253, runtime offset 24, flags 0x1
    private System.Collections.Generic.Dictionary<string, string> <Requests>k__BackingField;
    // method 31140, 0x60005ad
    void GetMemeberNames(System.Action<System.Collections.Generic.List<string>> names);
    // method 31141, 0x60005ae
    void GetRequests(System.Action<System.Collections.Generic.List<string>> call);
    // method 31142, 0x60005af
    void GetNextMember(string[] uidArr, int uidIndex, System.Collections.Generic.List<string> currentNames, System.Action<System.Collections.Generic.List<string>> call);
    // method 31143, 0x60005b0
    string ToString();
    // method 31144, 0x60005b1
    string get_Name();
    // method 31145, 0x60005b2
    void set_Name(string value);
    // method 31146, 0x60005b3
    string get_LeaderId();
    // method 31147, 0x60005b4
    void set_LeaderId(string value);
    // method 31148, 0x60005b5
    string get_ClanColor();
    // method 31149, 0x60005b6
    void set_ClanColor(string value);
    // method 31150, 0x60005b7
    string[] get_MemberIDs();
    // method 31151, 0x60005b8
    void set_MemberIDs(string[] value);
    // method 31152, 0x60005b9
    System.Collections.Generic.Dictionary<string, string> get_Requests();
    // method 31153, 0x60005ba
    void set_Requests(System.Collections.Generic.Dictionary<string, string> value);
    // method 31154, 0x60005bb
    void .ctor(string name, string color, string leaderId, string[] members, System.Collections.Generic.Dictionary<string, string> requests);
    // method 31155, 0x60005bc
    ClanData FromJson(string jsonString);
}

// TypeDefinition 4186, 0x200010a
class Flamethrower : Weapon {
    // field 17261, runtime offset 252, flags 0x1
    private ParticleSystemExtension flame;
    // method 31160, 0x60005c1
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 31161, 0x60005c2
    void OnDisable();
    // method 31162, 0x60005c3
    void OnUserMouseUp();
    // method 31163, 0x60005c4
    void .ctor();
}

// TypeDefinition 4187, 0x200010b
class FloatInputSlider : UnityEngine.MonoBehaviour {
    // field 17262, runtime offset 16, flags 0x6
    public TMPro.TMP_InputField inputField;
    // field 17263, runtime offset 20, flags 0x1
    private float deltaIncrement;
    // field 17264, runtime offset 24, flags 0x1
    private UnityEngine.Vector3 initialMousePosition;
    // field 17265, runtime offset 36, flags 0x1
    private bool isDragging;
    // method 31164, 0x60005c5
    void Update();
    // method 31165, 0x60005c6
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31166, 0x60005c7
    void .ctor();
}

// TypeDefinition 4188, 0x200010c
class FreeCrateMission : UnityEngine.MonoBehaviour {
    // field 17266, runtime offset 16, flags 0x1
    private UnityEngine.RectTransform fill;
    // field 17267, runtime offset 20, flags 0x1
    private TMPro.TMP_Text fillTxt;
    // field 17268, runtime offset 24, flags 0x1
    private UnityEngine.GameObject claimButton;
    // field 17269, runtime offset 0, flags 0x8051
    private static const int totalKillsToDo = 10;
    // field 17270, runtime offset 0, flags 0x16
    public static bool IWasClaimed;
    // method 31167, 0x60005c8
    void Init(bool claimed);
    // method 31168, 0x60005c9
    void Claim();
    // method 31169, 0x60005ca
    void .ctor();
    // method 31170, 0x60005cb
    void <Claim>b__6_0(bool success);
    // method 31171, 0x60005cc
    void <Claim>b__6_1(string x);
}

// TypeDefinition 4189, 0x200010d
class FriendInvitePopup : UnityEngine.MonoBehaviour {
    // field 17271, runtime offset 16, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 17272, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image imageFill;
    // field 17273, runtime offset 24, flags 0x1
    private TMPro.TMP_Text mainTxt;
    // field 17274, runtime offset 28, flags 0x1
    private DG.Tweening.Tween cTween;
    // field 17275, runtime offset 32, flags 0x1
    private DG.Tweening.Tween tTween;
    // field 17276, runtime offset 36, flags 0x1
    private DG.Tweening.Tween rtTween;
    // field 17277, runtime offset 40, flags 0x1
    private DG.Tweening.Tween rt2Tween;
    // field 17278, runtime offset 44, flags 0x1
    private string room;
    // field 17279, runtime offset 48, flags 0x1
    private float fill;
    // field 17280, runtime offset 52, flags 0x1
    private bool joining;
    // field 17281, runtime offset 53, flags 0x1
    private bool iAmPressed;
    // method 31172, 0x60005cd
    void OnInvite(string whoInvitedUID, string roomId);
    // method 31173, 0x60005ce
    void Update();
    // method 31174, 0x60005cf
    void OnEnable();
    // method 31175, 0x60005d0
    void OnDisable();
    // method 31176, 0x60005d1
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31177, 0x60005d2
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31178, 0x60005d3
    void .ctor();
    // method 31179, 0x60005d4
    void <OnInvite>b__8_0(string friendName);
    // method 31180, 0x60005d5
    void <OnInvite>b__8_1();
    // method 31181, 0x60005d6
    void <Update>b__11_0();
}

// TypeDefinition 4190, 0x200010f
class <>c__DisplayClass7_0 : object {
    // field 17291, runtime offset 8, flags 0x6
    public FriendUI <>4__this;
    // field 17292, runtime offset 12, flags 0x6
    public string uid;
    // field 17293, runtime offset 16, flags 0x6
    public System.Action<string> <>9__2;
    // field 17294, runtime offset 20, flags 0x6
    public System.Action<string> <>9__3;
    // field 17295, runtime offset 24, flags 0x6
    public System.Action<string> <>9__4;
    // field 17296, runtime offset 28, flags 0x6
    public System.Action<string> <>9__6;
    // field 17297, runtime offset 32, flags 0x6
    public System.Action<string> <>9__5;
    // method 31196, 0x60005e5
    void .ctor();
    // method 31197, 0x60005e6
    void <Init>b__0(string username);
    // method 31198, 0x60005e7
    void <Init>b__2(string verifiedString);
    // method 31199, 0x60005e8
    void <Init>b__3(string verifiedString);
    // method 31200, 0x60005e9
    void <Init>b__4(string verifiedString);
    // method 31201, 0x60005ea
    void <Init>b__5(string hisClan);
    // method 31202, 0x60005eb
    void <Init>b__6(string clanColorString);
    // method 31203, 0x60005ec
    void <Init>b__1(string publicJson);
}

// TypeDefinition 4191, 0x200010e
class FriendUI : UnityEngine.MonoBehaviour {
    // field 17282, runtime offset 16, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 17283, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image profileBackground;
    // field 17284, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image profileImage;
    // field 17285, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image statusImage;
    // field 17286, runtime offset 32, flags 0x6
    public string myUid;
    // field 17287, runtime offset 36, flags 0x1
    private bool iAmARequest;
    // field 17288, runtime offset 40, flags 0x1
    private System.Action<bool> currentOnDecide;
    // field 17289, runtime offset 44, flags 0x1
    private string lastStatus;
    // field 17290, runtime offset 48, flags 0x1
    private float lastInviteTime;
    // method 31182, 0x60005d7
    void OnDisable();
    // method 31183, 0x60005d8
    void Init(string uid);
    // method 31184, 0x60005d9
    void SlowUpdate();
    // method 31185, 0x60005da
    void InitRequest(string uid, System.Action<bool> onDecide);
    // method 31186, 0x60005db
    void DecideRequest(bool accept);
    // method 31187, 0x60005dc
    void FriendStatusUpdate(string status);
    // method 31188, 0x60005dd
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31189, 0x60005de
    void InvitePressed();
    // method 31190, 0x60005df
    void ForceInviteToRoom(string inviteUid, string roomName);
    // method 31191, 0x60005e0
    void RemoveFriend();
    // method 31192, 0x60005e1
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31193, 0x60005e2
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31194, 0x60005e3
    void .ctor();
    // method 31195, 0x60005e4
    void <RemoveFriend>b__18_0();
}

// TypeDefinition 4192, 0x2000110
class GameBundle : UnityEngine.ScriptableObject {
    // field 17298, runtime offset 12, flags 0x6
    public string priceInUS;
    // field 17299, runtime offset 16, flags 0x6
    public UnityEngine.Color backgroundColor;
    // field 17300, runtime offset 32, flags 0x6
    public UnityEngine.Color vignetteColor;
    // field 17301, runtime offset 48, flags 0x6
    public UnityEngine.Color leftPanelColor;
    // field 17302, runtime offset 64, flags 0x6
    public string description;
    // field 17303, runtime offset 68, flags 0x6
    public string renderPath;
    // field 17304, runtime offset 72, flags 0x6
    public string sku;
    // field 17305, runtime offset 76, flags 0x6
    public Item[] items;
    // method 31204, 0x60005ed
    void .ctor();
}

// TypeDefinition 4193, 0x2000112
class <>c : object {
    // field 17341, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17342, runtime offset 4, flags 0x16
    public static System.Action<bool> <>9__35_1;
    // field 17343, runtime offset 8, flags 0x16
    public static System.Action<string> <>9__35_0;
    // field 17344, runtime offset 12, flags 0x16
    public static System.Action<string> <>9__35_2;
    // field 17345, runtime offset 16, flags 0x16
    public static System.Func<int, int> <>9__46_0;
    // field 17346, runtime offset 20, flags 0x16
    public static System.Func<int, int> <>9__46_1;
    // field 17347, runtime offset 24, flags 0x16
    public static System.Func<int, int> <>9__46_2;
    // method 31229, 0x6000606
    void .cctor();
    // method 31230, 0x6000607
    void .ctor();
    // method 31231, 0x6000608
    void <Init>b__35_1(bool leveledUp);
    // method 31232, 0x6000609
    void <Init>b__35_0(string result);
    // method 31233, 0x600060a
    void <Init>b__35_2(string result);
    // method 31234, 0x600060b
    int <StartNewGame>b__46_0(int i);
    // method 31235, 0x600060c
    int <StartNewGame>b__46_1(int i);
    // method 31236, 0x600060d
    int <StartNewGame>b__46_2(int i);
}

// TypeDefinition 4194, 0x2000113
class <>c__DisplayClass52_0 : object {
    // field 17348, runtime offset 8, flags 0x6
    public int _i;
    // field 17349, runtime offset 12, flags 0x6
    public GameEndedPanel <>4__this;
    // method 31237, 0x600060e
    void .ctor();
    // method 31238, 0x600060f
    void <UpdateMapVotes>b__0();
}

// TypeDefinition 4195, 0x2000114
class <IenuStartNewGame>d__45 : object {
    // field 17350, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17351, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17352, runtime offset 16, flags 0x6
    public GameEndedPanel <>4__this;
    // field 17353, runtime offset 20, flags 0x1
    private float <timeLeft>5__2;
    // field 17354, runtime offset 24, flags 0x1
    private bool <setNewStartTime>5__3;
    // method 31239, 0x6000610
    void .ctor(int <>1__state);
    // method 31240, 0x6000611
    void System.IDisposable.Dispose();
    // method 31241, 0x6000612
    bool MoveNext();
    // method 31242, 0x6000613
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31243, 0x6000614
    void System.Collections.IEnumerator.Reset();
    // method 31244, 0x6000615
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4196, 0x2000115
class <IenuStartNewMatchByMyself>d__47 : object {
    // field 17355, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17356, runtime offset 12, flags 0x1
    private object <>2__current;
    // method 31245, 0x6000616
    void .ctor(int <>1__state);
    // method 31246, 0x6000617
    void System.IDisposable.Dispose();
    // method 31247, 0x6000618
    bool MoveNext();
    // method 31248, 0x6000619
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31249, 0x600061a
    void System.Collections.IEnumerator.Reset();
    // method 31250, 0x600061b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4197, 0x2000116
class <IenuUpdateFindingTxt>d__48 : object {
    // field 17357, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17358, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17359, runtime offset 16, flags 0x6
    public GameEndedPanel <>4__this;
    // field 17360, runtime offset 20, flags 0x1
    private float <maxTimeToWait>5__2;
    // field 17361, runtime offset 24, flags 0x1
    private float <timeWaited>5__3;
    // method 31251, 0x600061c
    void .ctor(int <>1__state);
    // method 31252, 0x600061d
    void System.IDisposable.Dispose();
    // method 31253, 0x600061e
    bool MoveNext();
    // method 31254, 0x600061f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31255, 0x6000620
    void System.Collections.IEnumerator.Reset();
    // method 31256, 0x6000621
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4198, 0x2000117
class <UpdateLayoutGroups>d__36 : object {
    // field 17362, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17363, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17364, runtime offset 16, flags 0x6
    public GameEndedPanel <>4__this;
    // field 17365, runtime offset 20, flags 0x6
    public UnityEngine.RectTransform recttransformOfTheLayoutgroup;
    // method 31257, 0x6000622
    void .ctor(int <>1__state);
    // method 31258, 0x6000623
    void System.IDisposable.Dispose();
    // method 31259, 0x6000624
    bool MoveNext();
    // method 31260, 0x6000625
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31261, 0x6000626
    void System.Collections.IEnumerator.Reset();
    // method 31262, 0x6000627
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4199, 0x2000111
class GameEndedPanel : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 17306, runtime offset 20, flags 0x1
    private TMPro.TMP_Text matchInfoTxt;
    // field 17307, runtime offset 24, flags 0x1
    private TMPro.TMP_Text[] rankTxts;
    // field 17308, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image[] rankImages;
    // field 17309, runtime offset 32, flags 0x1
    private UnityEngine.GameObject[] destroyIfNo2nd;
    // field 17310, runtime offset 36, flags 0x1
    private UnityEngine.GameObject[] destroyIfNo3rd;
    // field 17311, runtime offset 40, flags 0x1
    private TMPro.TMP_Text[] victoryTopTxts;
    // field 17312, runtime offset 44, flags 0x1
    private LobbyPlayerUI[] topPlayerUIs;
    // field 17313, runtime offset 48, flags 0x1
    private UnityEngine.GameObject[] mapVoteGOs;
    // field 17314, runtime offset 52, flags 0x1
    private TMPro.TMP_Text nextMapTxt;
    // field 17315, runtime offset 56, flags 0x1
    private TMPro.TMP_Text nextModeTxt;
    // field 17316, runtime offset 60, flags 0x1
    private UnityEngine.UI.Image nextMapImage;
    // field 17317, runtime offset 64, flags 0x1
    private UnityEngine.GameObject[] doubleKpButtons;
    // field 17318, runtime offset 68, flags 0x1
    private UnityEngine.GameObject[] newMatchButtons;
    // field 17319, runtime offset 72, flags 0x1
    private UnityEngine.GameObject findingNewPanel;
    // field 17320, runtime offset 76, flags 0x1
    private TMPro.TMP_Text findingNewTxt;
    // field 17321, runtime offset 80, flags 0x1
    private UnityEngine.UI.Image[] mapOutlines;
    // field 17322, runtime offset 84, flags 0x1
    private UnityEngine.GameObject[] mapVoteBtnImages;
    // field 17323, runtime offset 88, flags 0x1
    private UnityEngine.GameObject[] hideForMobileWeb;
    // field 17324, runtime offset 92, flags 0x1
    private bool voted;
    // field 17325, runtime offset 96, flags 0x1
    private RankProgressPanel rankProgressPanelPrefab;
    // field 17326, runtime offset 100, flags 0x1
    private TMPro.TMP_Text[] mapVoteTxts;
    // field 17327, runtime offset 104, flags 0x1
    private UnityEngine.UI.Image[] mapVoteImages;
    // field 17328, runtime offset 108, flags 0x1
    private UnityEngine.UI.Button[] mapVoteBtns;
    // field 17329, runtime offset 112, flags 0x1
    private TMPro.TMP_Text newGameStartsInTxt;
    // field 17330, runtime offset 116, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 17331, runtime offset 120, flags 0x1
    private ExpandedGameplayLeaderboard regularLeaderboard;
    // field 17332, runtime offset 124, flags 0x1
    private ExpandedGameplayLeaderboard teamsLeaderboard;
    // field 17333, runtime offset 128, flags 0x1
    private UnityEngine.UI.LayoutGroup regularLeaderboardVerticalGroup;
    // field 17334, runtime offset 132, flags 0x1
    private UnityEngine.UI.LayoutGroup teamsLeaderboardVerticalGroup;
    // field 17335, runtime offset 136, flags 0x1
    private UnityEngine.UI.LayoutGroup teams2LeaderboardVerticalGroup;
    // field 17336, runtime offset 0, flags 0x11
    private static GameEndedPanel instance;
    // field 17337, runtime offset 140, flags 0x1
    private int kpEarnedThisMatch;
    // field 17338, runtime offset 0, flags 0x8051
    private static const int KFactor = 32;
    // field 17339, runtime offset 144, flags 0x1
    private string animNameToPlay;
    // field 17340, runtime offset 148, flags 0x1
    private string lastNextGameTime;
    // method 31205, 0x60005ee
    void GetDoubleKP();
    // method 31206, 0x60005ef
    void FindNewMatchNow();
    // method 31207, 0x60005f0
    bool TryGetInstance(out GameEndedPanel _instance);
    // method 31208, 0x60005f1
    void Init(out int rank);
    // method 31209, 0x60005f2
    System.Collections.IEnumerator UpdateLayoutGroups(UnityEngine.RectTransform recttransformOfTheLayoutgroup);
    // method 31210, 0x60005f3
    int CalculateEloChange(int currentElo, float kdr, int rank, int totalPlayers);
    // method 31211, 0x60005f4
    float GetKillsMulti(int kills);
    // method 31212, 0x60005f5
    float GetTotalGamesPlayedMulti(int totalGamesPlayed);
    // method 31213, 0x60005f6
    int CalculateKDREloChange(float kdr);
    // method 31214, 0x60005f7
    void Show();
    // method 31215, 0x60005f8
    System.Collections.IEnumerator IenuStartNewGame();
    // method 31216, 0x60005f9
    void StartNewGame();
    // method 31217, 0x60005fa
    System.Collections.IEnumerator IenuStartNewMatchByMyself(ExitGames.Client.Photon.Hashtable newProps);
    // method 31218, 0x60005fb
    System.Collections.IEnumerator IenuUpdateFindingTxt();
    // method 31219, 0x60005fc
    void LogNextMaps(int[][] intArrays);
    // method 31220, 0x60005fd
    int FindIndexOfMax(int[] array);
    // method 31221, 0x60005fe
    void BackToLobby();
    // method 31222, 0x60005ff
    void UpdateMapVotes();
    // method 31223, 0x6000600
    void AddVoteTo(int mapIndex);
    // method 31224, 0x6000601
    Photon.Realtime.Player GetPlayerByActorNumber(int actorNumber);
    // method 31225, 0x6000602
    void OnWonLost(bool won);
    // method 31226, 0x6000603
    void .ctor();
    // method 31227, 0x6000604
    void <GetDoubleKP>b__15_0(bool success);
    // method 31228, 0x6000605
    void <GetDoubleKP>b__15_1(bool success);
}

// TypeDefinition 4200, 0x2000118
class GameLeaderboardSlot : UnityEngine.MonoBehaviour {
    // field 17366, runtime offset 16, flags 0x1
    private TMPro.TMP_Text primaryTxt;
    // field 17367, runtime offset 20, flags 0x1
    private TMPro.TMP_Text scoreTxt;
    // field 17368, runtime offset 24, flags 0x1
    private TMPro.TMP_Text killsTxt;
    // field 17369, runtime offset 28, flags 0x1
    private TMPro.TMP_Text deathsTxt;
    // field 17370, runtime offset 32, flags 0x1
    private TMPro.TMP_Text kdrTxt;
    // field 17371, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image rankImg;
    // field 17372, runtime offset 40, flags 0x1
    private TMPro.TMP_Text kpTxt;
    // method 31263, 0x6000628
    void Init(bool setUserColor, bool active, int index, string playerName, int score, int kills, int deaths, int kp, string rankName);
    // method 31264, 0x6000629
    void SetColor(UnityEngine.Color c);
    // method 31265, 0x600062a
    void .ctor();
}

// TypeDefinition 4201, 0x200011a
class MissionType : System.Enum {
    // field 17380, runtime offset 8, flags 0x606
    public int value__;
    // field 17381, runtime offset 0, flags 0x8056
    public static const MissionType GetKills = 0;
    // field 17382, runtime offset 0, flags 0x8056
    public static const MissionType GetHeadshots = 1;
    // field 17383, runtime offset 0, flags 0x8056
    public static const MissionType GetKillsWith = 2;
    // field 17384, runtime offset 0, flags 0x8056
    public static const MissionType GetHeadshotsWith = 3;
    // field 17385, runtime offset 0, flags 0x8056
    public static const MissionType WinGames = 4;
    // field 17386, runtime offset 0, flags 0x8056
    public static const MissionType PlayHours = 5;
    // field 17387, runtime offset 0, flags 0x8056
    public static const MissionType KillChickens = 6;
    // field 17388, runtime offset 0, flags 0x8056
    public static const MissionType KillChickoletta = 7;
    // field 17389, runtime offset 0, flags 0x8056
    public static const MissionType KillKyle = 8;
    // field 17390, runtime offset 0, flags 0x8056
    public static const MissionType ShootEasterEggs = 9;
}

// TypeDefinition 4202, 0x200011b
class <>c__DisplayClass6_0 : object {
    // field 17391, runtime offset 8, flags 0x6
    public UnityEngine.UI.Image img;
    // method 31270, 0x600062f
    void .ctor();
    // method 31271, 0x6000630
    void <SetImageAsIcon>b__0(UnityEngine.Texture2D tex);
}

// TypeDefinition 4203, 0x2000119
class GameMission : UnityEngine.ScriptableObject {
    // field 17373, runtime offset 12, flags 0x1
    private MissionType missionType;
    // field 17374, runtime offset 16, flags 0x6
    public int[] missionParameters;
    // field 17375, runtime offset 20, flags 0x1
    private UnityEngine.Sprite defaultIcon;
    // field 17376, runtime offset 24, flags 0x6
    public string overrideWithIconPath;
    // field 17377, runtime offset 28, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt grantXp;
    // field 17378, runtime offset 48, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt grantKp;
    // field 17379, runtime offset 68, flags 0x6
    public int earnCustomCharacterSkinIndex;
    // method 31266, 0x600062b
    MissionType get_publicMissionType();
    // method 31267, 0x600062c
    void SetImageAsIcon(UnityEngine.UI.Image img);
    // method 31268, 0x600062d
    bool get_IsLimitedTime();
    // method 31269, 0x600062e
    void .ctor();
}

// TypeDefinition 4204, 0x200011c
class GameMode : UnityEngine.ScriptableObject {
    // field 17392, runtime offset 12, flags 0x6
    public float chanceWeight;
    // field 17393, runtime offset 16, flags 0x6
    public float mobileChanceWeight;
    // field 17394, runtime offset 20, flags 0x1
    private float kourstrikeChanceWeight;
    // field 17395, runtime offset 24, flags 0x1
    private float kourzoneChanceWeight;
    // field 17396, runtime offset 28, flags 0x6
    public int id;
    // field 17397, runtime offset 32, flags 0x6
    public bool canChangeTimerOnPrivateMatches;
    // field 17398, runtime offset 33, flags 0x6
    public bool canChangeMaxPlayersOnPrivateMatches;
    // field 17399, runtime offset 36, flags 0x6
    public int[] forcesMap;
    // field 17400, runtime offset 40, flags 0x6
    public int _maxPlayers;
    // field 17401, runtime offset 44, flags 0x6
    public int _teamSize;
    // field 17402, runtime offset 48, flags 0x6
    public int matchTimeInSeconds;
    // field 17403, runtime offset 52, flags 0x6
    public UnityEngine.Sprite sprite;
    // field 17404, runtime offset 56, flags 0x6
    public Weapon[] weaponList;
    // field 17405, runtime offset 60, flags 0x6
    public bool forcePrivate;
    // field 17406, runtime offset 61, flags 0x6
    public bool excludeFromPubs;
    // field 17407, runtime offset 62, flags 0x6
    public bool excludeFromPubsKourstrike;
    // field 17408, runtime offset 63, flags 0x6
    public bool excludeFromPubsKourZone;
    // method 31272, 0x6000631
    float get_ChanceWeight();
    // method 31273, 0x6000632
    void .ctor();
}

// TypeDefinition 4205, 0x200011e
class <>c__DisplayClass15_0 : object {
    // field 17414, runtime offset 8, flags 0x6
    public string gameModeName;
    // method 31287, 0x6000640
    void .ctor();
    // method 31288, 0x6000641
    void <OnChoseGameMode>b__0();
}

// TypeDefinition 4206, 0x200011f
class <IenuCheckConnection>d__9 : object {
    // field 17415, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17416, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17417, runtime offset 16, flags 0x6
    public GameModeSelectPanel <>4__this;
    // method 31289, 0x6000642
    void .ctor(int <>1__state);
    // method 31290, 0x6000643
    void System.IDisposable.Dispose();
    // method 31291, 0x6000644
    bool MoveNext();
    // method 31292, 0x6000645
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31293, 0x6000646
    void System.Collections.IEnumerator.Reset();
    // method 31294, 0x6000647
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4207, 0x2000120
class <IenuDownloadMapConf>d__2 : object {
    // field 17418, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17419, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17420, runtime offset 16, flags 0x6
    public string url;
    // field 17421, runtime offset 20, flags 0x6
    public GameModeSelectPanel <>4__this;
    // field 17422, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 31295, 0x6000648
    void .ctor(int <>1__state);
    // method 31296, 0x6000649
    void System.IDisposable.Dispose();
    // method 31297, 0x600064a
    bool MoveNext();
    // method 31298, 0x600064b
    void <>m__Finally1();
    // method 31299, 0x600064c
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31300, 0x600064d
    void System.Collections.IEnumerator.Reset();
    // method 31301, 0x600064e
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4208, 0x2000121
class <SendPlayMap>d__17 : object {
    // field 17423, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17424, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17425, runtime offset 16, flags 0x6
    public string mapId;
    // field 17426, runtime offset 20, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 31302, 0x600064f
    void .ctor(int <>1__state);
    // method 31303, 0x6000650
    void System.IDisposable.Dispose();
    // method 31304, 0x6000651
    bool MoveNext();
    // method 31305, 0x6000652
    void <>m__Finally1();
    // method 31306, 0x6000653
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31307, 0x6000654
    void System.Collections.IEnumerator.Reset();
    // method 31308, 0x6000655
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4209, 0x200011d
class GameModeSelectPanel : Popup {
    // field 17409, runtime offset 68, flags 0x1
    private string currentMapIdReq;
    // field 17410, runtime offset 72, flags 0x1
    private UnityEngine.UI.Image connectingPanel;
    // field 17411, runtime offset 76, flags 0x1
    private UnityEngine.GameObject[] hideForLegionGames;
    // field 17412, runtime offset 80, flags 0x1
    private UnityEngine.GameObject[] showForLegionGames;
    // field 17413, runtime offset 84, flags 0x1
    private UnityEngine.GameObject[] hideForPokiAndCg;
    // method 31274, 0x6000633
    void PlayCustom(string mapId);
    // method 31275, 0x6000634
    System.Collections.IEnumerator IenuDownloadMapConf(string url);
    // method 31276, 0x6000635
    void Pressed();
    // method 31277, 0x6000636
    void CustomGamesButtonPressed();
    // method 31278, 0x6000637
    System.Collections.IEnumerator IenuCheckConnection();
    // method 31279, 0x6000638
    void OnEnable();
    // method 31280, 0x6000639
    void Show();
    // method 31281, 0x600063a
    void Close(System.Action onfinish);
    // method 31282, 0x600063b
    bool get_CanPlay();
    // method 31283, 0x600063c
    void OnChoseGameMode(string gameModeName);
    // method 31284, 0x600063d
    void IncreasePlayMapCount(string mapId);
    // method 31285, 0x600063e
    System.Collections.IEnumerator SendPlayMap(string mapId);
    // method 31286, 0x600063f
    void .ctor();
}

// TypeDefinition 4210, 0x2000122
class GamePausedPanel : UnityEngine.MonoBehaviour {
    // method 31309, 0x6000656
    void Deactivate();
    // method 31310, 0x6000657
    void .ctor();
}

// TypeDefinition 4211, 0x2000124
class MessageArray : object {
    // field 17441, runtime offset 8, flags 0x6
    public string[] messages;
    // method 31332, 0x600066d
    void .ctor();
}

// TypeDefinition 4212, 0x2000125
class <GetMessages>d__28 : object {
    // field 17442, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17443, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17444, runtime offset 16, flags 0x6
    public GlobalChatManager <>4__this;
    // field 17445, runtime offset 20, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 31333, 0x600066e
    void .ctor(int <>1__state);
    // method 31334, 0x600066f
    void System.IDisposable.Dispose();
    // method 31335, 0x6000670
    bool MoveNext();
    // method 31336, 0x6000671
    void <>m__Finally1();
    // method 31337, 0x6000672
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31338, 0x6000673
    void System.Collections.IEnumerator.Reset();
    // method 31339, 0x6000674
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4213, 0x2000126
class <PostMessage>d__34 : object {
    // field 17446, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17447, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17448, runtime offset 16, flags 0x6
    public string messageText;
    // field 17449, runtime offset 20, flags 0x6
    public GlobalChatManager <>4__this;
    // field 17450, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 31340, 0x6000675
    void .ctor(int <>1__state);
    // method 31341, 0x6000676
    void System.IDisposable.Dispose();
    // method 31342, 0x6000677
    bool MoveNext();
    // method 31343, 0x6000678
    void <>m__Finally1();
    // method 31344, 0x6000679
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31345, 0x600067a
    void System.Collections.IEnumerator.Reset();
    // method 31346, 0x600067b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4214, 0x2000127
class <UpdateLayoutGroup>d__25 : object {
    // field 17451, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17452, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17453, runtime offset 16, flags 0x6
    public GlobalChatManager <>4__this;
    // field 17454, runtime offset 20, flags 0x6
    public UnityEngine.RectTransform recttransformOfTheLayoutgroup;
    // method 31347, 0x600067c
    void .ctor(int <>1__state);
    // method 31348, 0x600067d
    void System.IDisposable.Dispose();
    // method 31349, 0x600067e
    bool MoveNext();
    // method 31350, 0x600067f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31351, 0x6000680
    void System.Collections.IEnumerator.Reset();
    // method 31352, 0x6000681
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4215, 0x2000123
class GlobalChatManager : UnityEngine.MonoBehaviour {
    // field 17427, runtime offset 16, flags 0x1
    private bool checkingChat;
    // field 17428, runtime offset 0, flags 0x8056
    public static const float COOLDOWN = 2;
    // field 17429, runtime offset 20, flags 0x1
    private float lastSendTime;
    // field 17430, runtime offset 0, flags 0x16
    public static GlobalChatManager instance;
    // field 17431, runtime offset 24, flags 0x6
    public ProfanityList profanityList;
    // field 17432, runtime offset 28, flags 0x1
    private UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup;
    // field 17433, runtime offset 32, flags 0x1
    private ChatSlot[] chatSlots;
    // field 17434, runtime offset 36, flags 0x1
    private UnityEngine.UI.InputField globalInputField;
    // field 17435, runtime offset 40, flags 0x1
    private UnityEngine.GameObject connectingPanel;
    // field 17436, runtime offset 44, flags 0x1
    private UnityEngine.GameObject disabledPanel;
    // field 17437, runtime offset 48, flags 0x1
    private TMPro.TMP_Text connectingPanelStatusTxt;
    // field 17438, runtime offset 52, flags 0x1
    private string myUserID;
    // field 17439, runtime offset 56, flags 0x1
    private string currentMessageBody;
    // field 17440, runtime offset 60, flags 0x1
    private System.Collections.Generic.List<string> messageQueue;
    // method 31311, 0x6000658
    void Init(GlobalChatUI globalChatUI);
    // method 31312, 0x6000659
    void Disconnect();
    // method 31313, 0x600065a
    string GenerateString();
    // method 31314, 0x600065b
    void Awake();
    // method 31315, 0x600065c
    void SlowUpdate();
    // method 31316, 0x600065d
    void ConnectToChatWith(string userID);
    // method 31317, 0x600065e
    void SetCurrentMessage(string messageBody);
    // method 31318, 0x600065f
    void SendChatMessage(string messageBody);
    // method 31319, 0x6000660
    bool SendChatMessage();
    // method 31320, 0x6000661
    string FilterMessage(string original);
    // method 31321, 0x6000662
    void ClearAllMessagesUI();
    // method 31322, 0x6000663
    void RefreshChatUI();
    // method 31323, 0x6000664
    System.Collections.IEnumerator UpdateLayoutGroup(UnityEngine.RectTransform recttransformOfTheLayoutgroup);
    // method 31324, 0x6000665
    void Start();
    // method 31325, 0x6000666
    void FetchMessagesFromServer();
    // method 31326, 0x6000667
    System.Collections.IEnumerator GetMessages();
    // method 31327, 0x6000668
    string[] ParseMessagesFromJson(string jsonString);
    // method 31328, 0x6000669
    void OnMessageUpdate(string[] newMessages);
    // method 31329, 0x600066a
    void SendMessageToServer(string message);
    // method 31330, 0x600066b
    System.Collections.IEnumerator PostMessage(string messageText);
    // method 31331, 0x600066c
    void .ctor();
}

// TypeDefinition 4216, 0x2000129
class <IenuOnSent>d__11 : object {
    // field 17462, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17463, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17464, runtime offset 16, flags 0x6
    public GlobalChatUI <>4__this;
    // field 17465, runtime offset 20, flags 0x1
    private float <totalTime>5__2;
    // field 17466, runtime offset 24, flags 0x1
    private float <currentTimeLeft>5__3;
    // method 31359, 0x6000688
    void .ctor(int <>1__state);
    // method 31360, 0x6000689
    void System.IDisposable.Dispose();
    // method 31361, 0x600068a
    bool MoveNext();
    // method 31362, 0x600068b
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31363, 0x600068c
    void System.Collections.IEnumerator.Reset();
    // method 31364, 0x600068d
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4217, 0x2000128
class GlobalChatUI : UnityEngine.MonoBehaviour {
    // field 17455, runtime offset 16, flags 0x6
    public UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup;
    // field 17456, runtime offset 20, flags 0x6
    public ChatSlot[] chatSlots;
    // field 17457, runtime offset 24, flags 0x6
    public UnityEngine.UI.InputField globalInputField;
    // field 17458, runtime offset 28, flags 0x6
    public UnityEngine.Transform chatCooldownFill;
    // field 17459, runtime offset 32, flags 0x6
    public UnityEngine.GameObject connectingPanel;
    // field 17460, runtime offset 36, flags 0x6
    public UnityEngine.GameObject disabledPanel;
    // field 17461, runtime offset 40, flags 0x6
    public TMPro.TMP_Text connectingPanelStatusTxt;
    // method 31353, 0x6000682
    void Init();
    // method 31354, 0x6000683
    void OnDisable();
    // method 31355, 0x6000684
    void OnInputFieldTextChanged(string x);
    // method 31356, 0x6000685
    void SendButtonPressed();
    // method 31357, 0x6000686
    System.Collections.IEnumerator IenuOnSent();
    // method 31358, 0x6000687
    void .ctor();
}

// TypeDefinition 4218, 0x200012b
class <>c__DisplayClass4_0 : object {
    // field 17471, runtime offset 8, flags 0x6
    public Grenade <>4__this;
    // field 17472, runtime offset 12, flags 0x6
    public Shooter shooter;
    // field 17473, runtime offset 16, flags 0x6
    public int i;
    // field 17474, runtime offset 20, flags 0x6
    public DG.Tweening.TweenCallback <>9__1;
    // method 31368, 0x6000691
    void .ctor();
    // method 31369, 0x6000692
    void <Shoot>b__0();
    // method 31370, 0x6000693
    void <Shoot>b__1();
}

// TypeDefinition 4219, 0x200012a
class Grenade : Weapon {
    // field 17467, runtime offset 252, flags 0x1
    private UnityEngine.Transform worldGrenadeSpawnPos;
    // field 17468, runtime offset 256, flags 0x1
    private float spawnAfterTime;
    // field 17469, runtime offset 260, flags 0x1
    private GrenadeType grenadeType;
    // field 17470, runtime offset 264, flags 0x6
    public UnityEngine.GameObject explosionFx;
    // method 31365, 0x600068e
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 31366, 0x600068f
    void CenterForInspect(UnityEngine.Transform obj);
    // method 31367, 0x6000690
    void .ctor();
}

// TypeDefinition 4220, 0x200012c
class GunGameProgress : UnityEngine.MonoBehaviour {
    // field 17475, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image[] blockProgressImages;
    // field 17476, runtime offset 20, flags 0x1
    private TMPro.TMP_Text[] wepIndexTxt;
    // field 17477, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image[] wepIcons;
    // method 31371, 0x6000694
    void Refresh();
    // method 31372, 0x6000695
    void .ctor();
}

// TypeDefinition 4221, 0x200012e
class <IenuUpdateLayoutGroup>d__12 : object {
    // field 17485, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17486, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17487, runtime offset 16, flags 0x6
    public UnityEngine.UI.LayoutGroup which;
    // field 17488, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform <recttransformOfTheLayoutgroup>5__2;
    // method 31380, 0x600069d
    void .ctor(int <>1__state);
    // method 31381, 0x600069e
    void System.IDisposable.Dispose();
    // method 31382, 0x600069f
    bool MoveNext();
    // method 31383, 0x60006a0
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31384, 0x60006a1
    void System.Collections.IEnumerator.Reset();
    // method 31385, 0x60006a2
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4222, 0x200012d
class GunGameTopPanel : UnityEngine.MonoBehaviour {
    // field 17478, runtime offset 16, flags 0x1
    private UnityEngine.UI.HorizontalLayoutGroup layoutGroup;
    // field 17479, runtime offset 20, flags 0x1
    private ProfilePictures profilePictures;
    // field 17480, runtime offset 24, flags 0x1
    private TMPro.TMP_Text[] currentIndexTxts;
    // field 17481, runtime offset 28, flags 0x1
    private TMPro.TMP_Text[] nameTxts;
    // field 17482, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image[] backgrounds;
    // field 17483, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image[] pfps;
    // field 17484, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image[] currentWeaponImgs;
    // method 31373, 0x6000696
    void Refresh();
    // method 31374, 0x6000697
    void OnGunChanged();
    // method 31375, 0x6000698
    int SafeIndex(int x);
    // method 31376, 0x6000699
    void UpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 31377, 0x600069a
    void OnDestroy();
    // method 31378, 0x600069b
    System.Collections.IEnumerator IenuUpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 31379, 0x600069c
    void .ctor();
}

// TypeDefinition 4223, 0x200012f
class HardpointArea : UnityEngine.MonoBehaviour {
    // field 17489, runtime offset 16, flags 0x6
    public UnityEngine.Vector3 detectionBoxSize;
    // field 17490, runtime offset 28, flags 0x6
    public UnityEngine.LayerMask teamMemberLayer;
    // field 17491, runtime offset 32, flags 0x6
    public UnityEngine.Vector3 boxRotation;
    // field 17492, runtime offset 44, flags 0x1
    private UnityEngine.Collider[] hitColliders;
    // method 31386, 0x60006a3
    System.Collections.Generic.List<TeamMember> GetTeamMembersInArea();
    // method 31387, 0x60006a4
    void OnDrawGizmos();
    // method 31388, 0x60006a5
    void .ctor();
}

// TypeDefinition 4224, 0x2000130
class HardpointManager : UnityEngine.MonoBehaviour {
    // field 17493, runtime offset 0, flags 0x8051
    private static const int secondsPerObjective = 60;
    // field 17494, runtime offset 0, flags 0x8051
    private static const int captureGivesPoints = 5;
    // field 17495, runtime offset 16, flags 0x1
    private HardpointArea[] objectives;
    // field 17496, runtime offset 20, flags 0x1
    private int matchTimeInSeconds;
    // field 17497, runtime offset 24, flags 0x1
    private double startTime;
    // field 17498, runtime offset 32, flags 0x1
    private TMPro.TMP_Text nextObjectiveTxt;
    // method 31389, 0x60006a6
    void Init(HardpointArea[] hardpoints, int _matchTimeInSeconds, double _startTime);
    // method 31390, 0x60006a7
    void SlowUpdate();
    // method 31391, 0x60006a8
    void AddPointsToTeam(Photon.Pun.UtilityScripts.PhotonTeam team, int customAmount, bool isKourstrikeWinReport);
    // method 31392, 0x60006a9
    int GetCurrentActiveObjectiveIndex(int timerInSeconds);
    // method 31393, 0x60006aa
    void UpdateObjectiveTimerText(int timerInSeconds);
    // method 31394, 0x60006ab
    void .ctor();
}

// TypeDefinition 4225, 0x2000131
class Hat : Item {
    // field 17499, runtime offset 68, flags 0x6
    public string meshPath;
    // field 17500, runtime offset 72, flags 0x6
    public string texturePath;
    // field 17501, runtime offset 76, flags 0x6
    public float showOffset;
    // method 31395, 0x60006ac
    string get_IsCurrentKey();
    // method 31396, 0x60006ad
    string get_HasItKey();
    // method 31397, 0x60006ae
    void .ctor();
}

// TypeDefinition 4226, 0x2000133
class <>c : object {
    // field 17533, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17534, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__44_0;
    // method 31423, 0x60006c8
    void .cctor();
    // method 31424, 0x60006c9
    void .ctor();
    // method 31425, 0x60006ca
    void <LocalDie>b__44_0();
}

// TypeDefinition 4227, 0x2000134
class <IenuHideDamageCircle>d__35 : object {
    // field 17535, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17536, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17537, runtime offset 16, flags 0x6
    public Health <>4__this;
    // field 17538, runtime offset 20, flags 0x6
    public DamageCircle dc;
    // method 31426, 0x60006cb
    void .ctor(int <>1__state);
    // method 31427, 0x60006cc
    void System.IDisposable.Dispose();
    // method 31428, 0x60006cd
    bool MoveNext();
    // method 31429, 0x60006ce
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31430, 0x60006cf
    void System.Collections.IEnumerator.Reset();
    // method 31431, 0x60006d0
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4228, 0x2000135
class <IenuOnSpawn>d__27 : object {
    // field 17539, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17540, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17541, runtime offset 16, flags 0x6
    public Health <>4__this;
    // method 31432, 0x60006d1
    void .ctor(int <>1__state);
    // method 31433, 0x60006d2
    void System.IDisposable.Dispose();
    // method 31434, 0x60006d3
    bool MoveNext();
    // method 31435, 0x60006d4
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31436, 0x60006d5
    void System.Collections.IEnumerator.Reset();
    // method 31437, 0x60006d6
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4229, 0x2000136
class <IenuRegenHealth>d__41 : object {
    // field 17542, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17543, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17544, runtime offset 16, flags 0x6
    public Health <>4__this;
    // field 17545, runtime offset 20, flags 0x1
    private float <d>5__2;
    // method 31438, 0x60006d7
    void .ctor(int <>1__state);
    // method 31439, 0x60006d8
    void System.IDisposable.Dispose();
    // method 31440, 0x60006d9
    bool MoveNext();
    // method 31441, 0x60006da
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31442, 0x60006db
    void System.Collections.IEnumerator.Reset();
    // method 31443, 0x60006dc
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4230, 0x2000132
class Health : Photon.Pun.MonoBehaviourPun {
    // field 17502, runtime offset 20, flags 0x1
    private Shooter shooter;
    // field 17503, runtime offset 0, flags 0x8051
    private static const float MINE_SPAWN_PROTECTION = 3.4000000953674316;
    // field 17504, runtime offset 0, flags 0x8051
    private static const float OTHER_SPAWN_PROTECTION = 3.299999952316284;
    // field 17505, runtime offset 24, flags 0x1
    private UnityEngine.GameObject shieldPanel;
    // field 17506, runtime offset 28, flags 0x1
    private UnityEngine.GameObject spawnProtectedVignette;
    // field 17507, runtime offset 32, flags 0x1
    private TMPro.TMP_Text spawnProtectedTxt;
    // field 17508, runtime offset 36, flags 0x1
    private UnityEngine.GameObject spawnProtectedGO;
    // field 17509, runtime offset 40, flags 0x1
    private UnityEngine.Transform globalHealthFill;
    // field 17510, runtime offset 44, flags 0x1
    private UnityEngine.Transform globalHealthLerpFill;
    // field 17511, runtime offset 48, flags 0x1
    private UnityEngine.UI.Image hitVignette;
    // field 17512, runtime offset 52, flags 0x1
    private UnityEngine.UI.Image healthFill;
    // field 17513, runtime offset 56, flags 0x1
    private TMPro.TMP_Text healthTxt;
    // field 17514, runtime offset 60, flags 0x1
    private UnityEngine.GameObject head;
    // field 17515, runtime offset 64, flags 0x1
    private UnityEngine.GameObject legs;
    // field 17516, runtime offset 68, flags 0x1
    private BackInCanvas backInCanvas;
    // field 17517, runtime offset 72, flags 0x6
    public KourstrikeBackInCanvas kourstrikeBackInCanvas;
    // field 17518, runtime offset 76, flags 0x6
    public BattleRoyaleBackInCanvas battleRoyaleBackInCanvas;
    // field 17519, runtime offset 80, flags 0x1
    private UnityEngine.Camera cam;
    // field 17520, runtime offset 84, flags 0x1
    private UnityEngine.GameObject[] globalGfx;
    // field 17521, runtime offset 88, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredInt maxHealth;
    // field 17522, runtime offset 108, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt currentHealth;
    // field 17523, runtime offset 128, flags 0x6
    public bool localDied;
    // field 17524, runtime offset 136, flags 0x1
    private double spawnTime;
    // field 17525, runtime offset 144, flags 0x1
    private DamageCircle[] damageCircles;
    // field 17526, runtime offset 148, flags 0x6
    public float lastHitOrShotTime;
    // field 17527, runtime offset 152, flags 0x1
    private UnityEngine.Coroutine currentHealthRegenCoroutine;
    // field 17528, runtime offset 156, flags 0x1
    private float hpFillLerpX;
    // field 17529, runtime offset 160, flags 0x1
    private string myKillerName;
    // field 17530, runtime offset 164, flags 0x1
    private RagdollPlayer myRagdoll;
    // field 17531, runtime offset 168, flags 0x6
    public bool globalDied;
    // field 17532, runtime offset 172, flags 0x1
    private UnityEngine.Vector3 lastHitPoint;
    // method 31398, 0x60006af
    bool IsSpawnProtected();
    // method 31399, 0x60006b0
    int GetMaxHealth();
    // method 31400, 0x60006b1
    void OnShoot();
    // method 31401, 0x60006b2
    void Start();
    // method 31402, 0x60006b3
    System.Collections.IEnumerator IenuOnSpawn();
    // method 31403, 0x60006b4
    void TryStartHealthRegen();
    // method 31404, 0x60006b5
    void OnTeleport();
    // method 31405, 0x60006b6
    void TakeHealth(bool showIndicator, int amount, string hitTagName, Photon.Realtime.Player by, Shooter byShooter, UnityEngine.Vector3 hitPos);
    // method 31406, 0x60006b7
    DamageCircle GetAvailableDamageCircle();
    // method 31407, 0x60006b8
    void EndUseOfDamangeCircle(DamageCircle hitmark);
    // method 31408, 0x60006b9
    void ShowMarker(bool showUIIndicator, UnityEngine.Transform byy);
    // method 31409, 0x60006ba
    System.Collections.IEnumerator IenuHideDamageCircle(DamageCircle dc);
    // method 31410, 0x60006bb
    void AddHealth(int amount);
    // method 31411, 0x60006bc
    void InitiateTakeHealth(int amount);
    // method 31412, 0x60006bd
    void RPCTakeHealth(int amount);
    // method 31413, 0x60006be
    System.Collections.IEnumerator IenuRegenHealth();
    // method 31414, 0x60006bf
    void Update();
    // method 31415, 0x60006c0
    void LocalDie(Photon.Realtime.Player by, Shooter byShooter, string hitTagName, bool willRespawn);
    // method 31416, 0x60006c1
    void OnDestroy();
    // method 31417, 0x60006c2
    void GlobalDie(Shooter killer);
    // method 31418, 0x60006c3
    void OnMaxHpChanged(int newMaxHp);
    // method 31419, 0x60006c4
    void RpcOnMaxHealthChanged(int newMaxHp);
    // method 31420, 0x60006c5
    void OnBombExploaded(UnityEngine.Vector3 bombPos);
    // method 31421, 0x60006c6
    void .ctor();
    // method 31422, 0x60006c7
    void <IenuOnSpawn>b__27_0();
}

// TypeDefinition 4231, 0x2000137
class HierarchyButton : UnityEngine.MonoBehaviour {
    // field 17546, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image image;
    // field 17547, runtime offset 20, flags 0x1
    private UnityEngine.Color selectedColor;
    // field 17548, runtime offset 0, flags 0x11
    private static UnityEngine.Color regularColor;
    // field 17549, runtime offset 16, flags 0x16
    public static HierarchyButton lastSelected;
    // field 17550, runtime offset 36, flags 0x1
    private TMPro.TMP_Text text;
    // field 17551, runtime offset 40, flags 0x1
    private int myIndex;
    // field 17552, runtime offset 44, flags 0x1
    private System.Action<int> onPressed;
    // method 31444, 0x60006dd
    void OnRename(string newName);
    // method 31445, 0x60006de
    void Init(int autoInspectIndex, string nameText, int index, System.Action<int> _onPressed);
    // method 31446, 0x60006df
    void OnPressed();
    // method 31447, 0x60006e0
    void OnSearch(string searchString);
    // method 31448, 0x60006e1
    void .ctor();
    // method 31449, 0x60006e2
    void .cctor();
}

// TypeDefinition 4232, 0x2000138
class Hitmark : UnityEngine.MonoBehaviour {
    // field 17553, runtime offset 16, flags 0x1
    private TMPro.TMP_Text damageTxt;
    // field 17554, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image[] images;
    // field 17555, runtime offset 24, flags 0x1
    private bool showText;
    // field 17556, runtime offset 28, flags 0x1
    private UnityEngine.Color _color;
    // method 31450, 0x60006e3
    UnityEngine.Vector3 get_textScale();
    // method 31451, 0x60006e4
    void set_textScale(UnityEngine.Vector3 value);
    // method 31452, 0x60006e5
    string get_text();
    // method 31453, 0x60006e6
    void set_text(string value);
    // method 31454, 0x60006e7
    UnityEngine.Color get_color();
    // method 31455, 0x60006e8
    void set_color(UnityEngine.Color value);
    // method 31456, 0x60006e9
    void .ctor();
}

// TypeDefinition 4233, 0x200013a
class <>c : object {
    // field 17570, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17571, runtime offset 4, flags 0x16
    public static System.Action <>9__18_0;
    // method 31470, 0x60006f7
    void .cctor();
    // method 31471, 0x60006f8
    void .ctor();
    // method 31472, 0x60006f9
    void <JoinCustomRoom>b__18_0();
}

// TypeDefinition 4234, 0x200013b
class <>c__DisplayClass13_0 : object {
    // field 17572, runtime offset 8, flags 0x6
    public HostPanel <>4__this;
    // field 17573, runtime offset 12, flags 0x6
    public GameMode g;
    // method 31473, 0x60006fa
    void .ctor();
    // method 31474, 0x60006fb
    void <OnGameModeDropdownChanged>b__0();
    // method 31475, 0x60006fc
    void <OnGameModeDropdownChanged>b__1();
}

// TypeDefinition 4235, 0x200013c
class <>c__DisplayClass17_0 : object {
    // field 17574, runtime offset 8, flags 0x6
    public string inputTextLower;
    // field 17575, runtime offset 12, flags 0x6
    public string text;
    // method 31476, 0x60006fd
    void .ctor();
    // method 31477, 0x60006fe
    void <JoinButtonPressed>b__0();
    // method 31478, 0x60006ff
    void <JoinButtonPressed>b__1();
}

// TypeDefinition 4236, 0x200013d
class <>c__DisplayClass21_0 : object {
    // field 17576, runtime offset 8, flags 0x6
    public HostPanel <>4__this;
    // field 17577, runtime offset 12, flags 0x6
    public bool isPartyLeader;
    // method 31479, 0x6000700
    void .ctor();
    // method 31480, 0x6000701
    void <HostButtonPressed>b__0();
}

// TypeDefinition 4237, 0x200013e
class <>c__DisplayClass21_1 : object {
    // field 17578, runtime offset 8, flags 0x6
    public int gameModeId;
    // field 17579, runtime offset 12, flags 0x6
    public int mapBuildIndex;
    // field 17580, runtime offset 16, flags 0x6
    public bool useCustomTimer;
    // field 17581, runtime offset 20, flags 0x6
    public int matchTimeInSeconds;
    // field 17582, runtime offset 24, flags 0x6
    public GameMode gamemode;
    // field 17583, runtime offset 28, flags 0x6
    public int maxPlayers;
    // field 17584, runtime offset 32, flags 0x6
    public bool isPrivate;
    // field 17585, runtime offset 36, flags 0x6
    public <>c__DisplayClass21_0 CS$<>8__locals1;
    // method 31481, 0x6000702
    void .ctor();
    // method 31482, 0x6000703
    void <HostButtonPressed>b__1(string mapNameReady);
}

// TypeDefinition 4238, 0x2000139
class HostPanel : Popup {
    // field 17557, runtime offset 68, flags 0x1
    private UnityEngine.GameObject joinPanel;
    // field 17558, runtime offset 72, flags 0x1
    private TMPro.TMP_InputField linkIfStatic;
    // field 17559, runtime offset 76, flags 0x1
    private TMPro.TMP_Text hostGameButtonTxt;
    // field 17560, runtime offset 80, flags 0x1
    private TMPro.TMP_InputField roomNameIfStatic;
    // field 17561, runtime offset 84, flags 0x1
    private Carousel timerCarousel;
    // field 17562, runtime offset 88, flags 0x1
    private Carousel maxPlayersCarousel;
    // field 17563, runtime offset 92, flags 0x1
    private UnityEngine.GameObject timerOptionDisabledPanel;
    // field 17564, runtime offset 96, flags 0x1
    private UnityEngine.GameObject privateDisabledPanel;
    // field 17565, runtime offset 100, flags 0x1
    private TMPro.TMP_Dropdown mapDropdown;
    // field 17566, runtime offset 104, flags 0x1
    private TMPro.TMP_Dropdown gameModeDropdown;
    // field 17567, runtime offset 108, flags 0x1
    private UnityEngine.UI.InputField roomNameIF;
    // field 17568, runtime offset 112, flags 0x1
    private UnityEngine.UI.Toggle isPrivateToggle;
    // field 17569, runtime offset 116, flags 0x1
    private System.Collections.Generic.List<OptionData> currentMapOptions;
    // method 31457, 0x60006ea
    void OnGameModeDropdownChanged(int newValue);
    // method 31458, 0x60006eb
    void Init(bool showJoinOptionOnly);
    // method 31459, 0x60006ec
    void KeepGameMode(int m);
    // method 31460, 0x60006ed
    void Close(System.Action onfinish);
    // method 31461, 0x60006ee
    void JoinButtonPressed(UnityEngine.UI.InputField input);
    // method 31462, 0x60006ef
    void JoinCustomRoom(string roomNameToJoin);
    // method 31463, 0x60006f0
    void OnConnectedToMasterServer(string regionToken);
    // method 31464, 0x60006f1
    GameMode[] GetAvailableGameModes();
    // method 31465, 0x60006f2
    void HostButtonPressed();
    // method 31466, 0x60006f3
    void OnHostFailed(string message);
    // method 31467, 0x60006f4
    int ConvertTimeStringToSeconds(string timeString);
    // method 31468, 0x60006f5
    void .ctor();
    // method 31469, 0x60006f6
    void <OnHostFailed>b__22_0();
}

// TypeDefinition 4239, 0x2000140
class <LoadTexture>d__7 : object {
    // field 17589, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17590, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17591, runtime offset 16, flags 0x6
    public string dataUrl;
    // field 17592, runtime offset 20, flags 0x6
    public ImageHandler <>4__this;
    // field 17593, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 31489, 0x600070a
    void .ctor(int <>1__state);
    // method 31490, 0x600070b
    void System.IDisposable.Dispose();
    // method 31491, 0x600070c
    bool MoveNext();
    // method 31492, 0x600070d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31493, 0x600070e
    void System.Collections.IEnumerator.Reset();
    // method 31494, 0x600070f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4240, 0x200013f
class ImageHandler : UnityEngine.MonoBehaviour {
    // field 17586, runtime offset 16, flags 0x1
    private UnityEngine.UI.RawImage displayImage;
    // field 17587, runtime offset 20, flags 0x1
    private UnityEngine.GameObject onHover;
    // field 17588, runtime offset 24, flags 0x6
    public string myDataUrl;
    // method 31483, 0x6000704
    void Start();
    // method 31484, 0x6000705
    void ReceiveImage(string dataUrl);
    // method 31485, 0x6000706
    bool get_loadedImage();
    // method 31486, 0x6000707
    System.Collections.IEnumerator LoadTexture(string dataUrl);
    // method 31487, 0x6000708
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31488, 0x6000709
    void .ctor();
}

// TypeDefinition 4241, 0x2000141
class ImpactEffect : UnityEngine.MonoBehaviour {
    // field 17594, runtime offset 16, flags 0x1
    private UnityEngine.LayerMask m_LayerMask;
    // field 17595, runtime offset 20, flags 0x1
    private UnityEngine.GameObject smoke;
    // method 31495, 0x6000710
    void OnSpawned();
    // method 31496, 0x6000711
    void Despawn();
    // method 31497, 0x6000712
    void .ctor();
}

// TypeDefinition 4242, 0x2000143
class RewardType : System.Enum {
    // field 17601, runtime offset 8, flags 0x606
    public int value__;
    // field 17602, runtime offset 0, flags 0x8056
    public static const RewardType None = 0;
    // field 17603, runtime offset 0, flags 0x8056
    public static const RewardType KP = 1;
    // field 17604, runtime offset 0, flags 0x8056
    public static const RewardType KPRewarded = 2;
}

// TypeDefinition 4243, 0x2000144
class <>c__DisplayClass11_0 : object {
    // field 17605, runtime offset 8, flags 0x6
    public int _i;
    // field 17606, runtime offset 16, flags 0x6
    public System.DateTime expiryDate;
    // field 17607, runtime offset 24, flags 0x6
    public InboxManager <>4__this;
    // method 31508, 0x600071d
    void .ctor();
    // method 31509, 0x600071e
    void <LoadAll>b__0();
}

// TypeDefinition 4244, 0x2000145
class <>c__DisplayClass11_1 : object {
    // field 17608, runtime offset 8, flags 0x6
    public int rewardAmount;
    // method 31510, 0x600071f
    void .ctor();
    // method 31511, 0x6000720
    void <LoadAll>b__1(bool success);
}

// TypeDefinition 4245, 0x2000142
class InboxManager : Popup {
    // field 17596, runtime offset 0, flags 0x8056
    public static const int x0012_035 = -3390463;
    // field 17597, runtime offset 68, flags 0x1
    private UnityEngine.Sprite[] messageIconSprites;
    // field 17598, runtime offset 72, flags 0x1
    private UnityEngine.Transform inboxContent;
    // field 17599, runtime offset 76, flags 0x1
    private InboxMessage inboxMessagePrefab;
    // field 17600, runtime offset 0, flags 0x11
    private static bool isLoggedIn;
    // method 31498, 0x6000713
    void Update();
    // method 31499, 0x6000714
    void Show();
    // method 31500, 0x6000715
    void Add(string body, RewardType rewardType, int rewardAmount, int daysAlive, int x);
    // method 31501, 0x6000716
    void OnLoggedIn(bool isRegister);
    // method 31502, 0x6000717
    void WorkaroundFixMessageBug();
    // method 31503, 0x6000718
    void LoadAll();
    // method 31504, 0x6000719
    bool HasNewMessages();
    // method 31505, 0x600071a
    string ConvertTimeSpanToReadableString(System.TimeSpan timeSpan);
    // method 31506, 0x600071b
    void ReverseChildrenOrder(UnityEngine.Transform transform);
    // method 31507, 0x600071c
    void .ctor();
}

// TypeDefinition 4246, 0x2000147
class <>c__DisplayClass8_0 : object {
    // field 17617, runtime offset 8, flags 0x6
    public System.Action onclick;
    // method 31514, 0x6000723
    void .ctor();
    // method 31515, 0x6000724
    void <Init>b__0();
}

// TypeDefinition 4247, 0x2000146
class InboxMessage : UnityEngine.MonoBehaviour {
    // field 17609, runtime offset 16, flags 0x1
    private UnityEngine.GameObject rewardedImageGO;
    // field 17610, runtime offset 20, flags 0x1
    private UnityEngine.CanvasGroup cg;
    // field 17611, runtime offset 24, flags 0x1
    private TMPro.TMP_Text bodyTxt;
    // field 17612, runtime offset 28, flags 0x1
    private TMPro.TMP_Text sentOnTxt;
    // field 17613, runtime offset 32, flags 0x1
    private TMPro.TMP_Text expiryTxt;
    // field 17614, runtime offset 36, flags 0x1
    private UnityEngine.UI.Button claimBtn;
    // field 17615, runtime offset 40, flags 0x1
    private TMPro.TMP_Text claimTxt;
    // field 17616, runtime offset 44, flags 0x1
    private UnityEngine.UI.Image itemImage;
    // method 31512, 0x6000721
    void Init(RewardType type, string messageBody, string sentOn, string expiry, bool claimedAlready, UnityEngine.Sprite sprite, System.Action onclick);
    // method 31513, 0x6000722
    void .ctor();
}

// TypeDefinition 4248, 0x2000148
class InfoPanel : Popup {
    // field 17618, runtime offset 68, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 17619, runtime offset 72, flags 0x1
    private TMPro.TMP_Text contentTxt;
    // method 31516, 0x6000725
    void Init(string title, string content);
    // method 31517, 0x6000726
    void .ctor();
}

// TypeDefinition 4249, 0x200014a
class <>c__DisplayClass18_0 : object {
    // field 17637, runtime offset 8, flags 0x6
    public MapObject withMapObject;
    // field 17638, runtime offset 12, flags 0x6
    public InspectObjectPanel <>4__this;
    // field 17639, runtime offset 16, flags 0x6
    public int objectIndex;
    // method 31528, 0x6000731
    void .ctor();
    // method 31529, 0x6000732
    void <Init>b__0(string strX);
    // method 31530, 0x6000733
    void <Init>b__1(string strX);
    // method 31531, 0x6000734
    void <Init>b__2(string strX);
    // method 31532, 0x6000735
    void <Init>b__3(string strX);
    // method 31533, 0x6000736
    void <Init>b__4(string strX);
    // method 31534, 0x6000737
    void <Init>b__5(string strX);
    // method 31535, 0x6000738
    void <Init>b__6(string strX);
    // method 31536, 0x6000739
    void <Init>b__7(string strX);
    // method 31537, 0x600073a
    void <Init>b__8(string strX);
    // method 31538, 0x600073b
    void <Init>b__9(string str);
}

// TypeDefinition 4250, 0x2000149
class InspectObjectPanel : UnityEngine.MonoBehaviour {
    // field 17620, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image meshImage;
    // field 17621, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image textureImage;
    // field 17622, runtime offset 24, flags 0x1
    private UnityEngine.UI.InputField objNameIF;
    // field 17623, runtime offset 28, flags 0x1
    private TMPro.TMP_Text textureNameTxt;
    // field 17624, runtime offset 32, flags 0x1
    private TMPro.TMP_Text idTxt;
    // field 17625, runtime offset 36, flags 0x1
    private TMPro.TMP_Text shaderNameTxt;
    // field 17626, runtime offset 40, flags 0x1
    private TMPro.TMP_Text meshNameTxt;
    // field 17627, runtime offset 44, flags 0x1
    private TMPro.TMP_InputField posXIF;
    // field 17628, runtime offset 48, flags 0x1
    private TMPro.TMP_InputField posYIF;
    // field 17629, runtime offset 52, flags 0x1
    private TMPro.TMP_InputField posZIF;
    // field 17630, runtime offset 56, flags 0x1
    private TMPro.TMP_InputField rotXIF;
    // field 17631, runtime offset 60, flags 0x1
    private TMPro.TMP_InputField rotYIF;
    // field 17632, runtime offset 64, flags 0x1
    private TMPro.TMP_InputField rotZIF;
    // field 17633, runtime offset 68, flags 0x1
    private TMPro.TMP_InputField scaleXIF;
    // field 17634, runtime offset 72, flags 0x1
    private TMPro.TMP_InputField scaleYIF;
    // field 17635, runtime offset 76, flags 0x1
    private TMPro.TMP_InputField scaleZIF;
    // field 17636, runtime offset 80, flags 0x1
    private MapObject myMapObject;
    // method 31518, 0x6000727
    void Update();
    // method 31519, 0x6000728
    void Init(int objectIndex, MapObject withMapObject);
    // method 31520, 0x6000729
    void ModifyMesh();
    // method 31521, 0x600072a
    void ModifyTexture();
    // method 31522, 0x600072b
    void ModifyShader();
    // method 31523, 0x600072c
    void DeleteObject();
    // method 31524, 0x600072d
    void .ctor();
    // method 31525, 0x600072e
    void <ModifyMesh>b__19_0(UnityEngine.Mesh selected);
    // method 31526, 0x600072f
    void <ModifyTexture>b__20_0(UnityEngine.Texture2D selected);
    // method 31527, 0x6000730
    void <ModifyShader>b__21_0(UnityEngine.Material selected);
}

// TypeDefinition 4251, 0x200014b
class InventorySwap : UnityEngine.MonoBehaviour {
    // field 17640, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image myChildImage;
    // field 17641, runtime offset 20, flags 0x1
    private int myIndex;
    // field 17642, runtime offset 24, flags 0x1
    private UnityEngine.Vector3 startPosition;
    // field 17643, runtime offset 36, flags 0x1
    private UnityEngine.Transform originalParent;
    // field 17644, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image selectedItem;
    // field 17645, runtime offset 0, flags 0x11
    private static UnityEngine.UI.Image currentlyDragging;
    // field 17646, runtime offset 4, flags 0x11
    private static InventorySwap currentlyDraggingParent;
    // field 17647, runtime offset 8, flags 0x11
    private static System.Action<int, int> OnInventorySwap;
    // field 17648, runtime offset 12, flags 0x11
    private static float lastDrop;
    // method 31539, 0x600073c
    void add_OnInventorySwap(System.Action<int, int> value);
    // method 31540, 0x600073d
    void remove_OnInventorySwap(System.Action<int, int> value);
    // method 31541, 0x600073e
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31542, 0x600073f
    void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31543, 0x6000740
    void OnDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31544, 0x6000741
    void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31545, 0x6000742
    void OnDrop(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31546, 0x6000743
    void SwapSprites(UnityEngine.UI.Image img1, UnityEngine.UI.Image img2);
    // method 31547, 0x6000744
    void SetImageAlpha(UnityEngine.UI.Image img, float alpha);
    // method 31548, 0x6000745
    void .ctor();
}

// TypeDefinition 4252, 0x200014d
class <>c : object {
    // field 17682, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17683, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__40_0;
    // field 17684, runtime offset 8, flags 0x16
    public static DG.Tweening.TweenCallback <>9__41_0;
    // field 17685, runtime offset 12, flags 0x16
    public static DG.Tweening.TweenCallback <>9__45_0;
    // method 31568, 0x6000759
    void .cctor();
    // method 31569, 0x600075a
    void .ctor();
    // method 31570, 0x600075b
    void <Init>b__40_0();
    // method 31571, 0x600075c
    void <Init>b__41_0();
    // method 31572, 0x600075d
    void <OnEnable>b__45_0();
}

// TypeDefinition 4253, 0x200014e
class <>c__DisplayClass29_0 : object {
    // field 17686, runtime offset 8, flags 0x6
    public int currentCoins;
    // field 17687, runtime offset 12, flags 0x6
    public int price;
    // field 17688, runtime offset 16, flags 0x6
    public ItemInspectPanel <>4__this;
    // field 17689, runtime offset 20, flags 0x6
    public System.Action<string> <>9__1;
    // method 31573, 0x600075e
    void .ctor();
    // method 31574, 0x600075f
    void <Purchase>b__0();
    // method 31575, 0x6000760
    void <Purchase>b__1(string callback);
}

// TypeDefinition 4254, 0x200014f
class <>c__DisplayClass41_0 : object {
    // field 17690, runtime offset 8, flags 0x6
    public UnityEngine.MeshFilter filter;
    // field 17691, runtime offset 12, flags 0x6
    public UnityEngine.MeshRenderer renderer;
    // method 31576, 0x6000761
    void .ctor();
    // method 31577, 0x6000762
    void <Init>b__1(UnityEngine.Mesh x);
    // method 31578, 0x6000763
    void <Init>b__2(UnityEngine.Texture2D x);
}

// TypeDefinition 4255, 0x2000150
class <>c__DisplayClass41_1 : object {
    // field 17692, runtime offset 8, flags 0x6
    public UnityEngine.MeshRenderer mr;
    // field 17693, runtime offset 12, flags 0x6
    public UnityEngine.MeshRenderer mr2;
    // method 31579, 0x6000764
    void .ctor();
    // method 31580, 0x6000765
    void <Init>b__3(UnityEngine.Texture2D n);
}

// TypeDefinition 4256, 0x2000151
class <>c__DisplayClass41_2 : object {
    // field 17694, runtime offset 8, flags 0x6
    public UnityEngine.MeshRenderer _mr;
    // field 17695, runtime offset 12, flags 0x6
    public UnityEngine.MeshRenderer _mr2;
    // method 31581, 0x6000766
    void .ctor();
    // method 31582, 0x6000767
    void <Init>b__4(UnityEngine.Texture2D n);
}

// TypeDefinition 4257, 0x200014c
class ItemInspectPanel : UnityEngine.MonoBehaviour {
    // field 17649, runtime offset 16, flags 0x1
    private TMPro.TMP_Text coinTxt;
    // field 17650, runtime offset 20, flags 0x1
    private TMPro.TMP_Text ownedTxt;
    // field 17651, runtime offset 24, flags 0x1
    private UnityEngine.Camera cam;
    // field 17652, runtime offset 28, flags 0x1
    private UnityEngine.GameObject hatTemplate;
    // field 17653, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image openCaseImage;
    // field 17654, runtime offset 36, flags 0x1
    private ScreenSpaceCavityCurvature.SSCC sscc;
    // field 17655, runtime offset 40, flags 0x1
    private UnityEngine.UI.Button purchaseButton;
    // field 17656, runtime offset 44, flags 0x1
    private TMPro.TMP_Text worthTxt;
    // field 17657, runtime offset 48, flags 0x1
    private TMPro.TMP_Text purchaseTxt;
    // field 17658, runtime offset 52, flags 0x1
    private UnityEngine.AudioSource playSourceOnClose;
    // field 17659, runtime offset 56, flags 0x1
    private UnityEngine.UI.Button equipButton;
    // field 17660, runtime offset 60, flags 0x1
    private TMPro.TMP_Text equipButtonTxt;
    // field 17661, runtime offset 64, flags 0x1
    private TMPro.TMP_Text descriptionTxt;
    // field 17662, runtime offset 68, flags 0x1
    private UnityEngine.UI.RawImage mainRawImage;
    // field 17663, runtime offset 72, flags 0x1
    private UnityEngine.UI.Image itemIconImg;
    // field 17664, runtime offset 76, flags 0x1
    private TMPro.TMP_Text rarityTxt;
    // field 17665, runtime offset 80, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 17666, runtime offset 84, flags 0x1
    private UnityEngine.UI.Image rarityImg;
    // field 17667, runtime offset 88, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 17668, runtime offset 92, flags 0x1
    private UnityEngine.Transform characterInspectParent;
    // field 17669, runtime offset 96, flags 0x1
    private CharacterSkinManager characterSkinManagerPremadePreview;
    // field 17670, runtime offset 100, flags 0x1
    private UnityEngine.Transform kpInspectParent;
    // field 17671, runtime offset 104, flags 0x1
    private UnityEngine.Transform xpInspectParent;
    // field 17672, runtime offset 108, flags 0x1
    private UnityEngine.Transform caseDataInpectParent;
    // field 17673, runtime offset 112, flags 0x1
    private UnityEngine.Transform weaponInspectParent;
    // field 17674, runtime offset 116, flags 0x1
    private UnityEngine.Transform hatInspectParent;
    // field 17675, runtime offset 120, flags 0x1
    private float targetCamSize;
    // field 17676, runtime offset 0, flags 0x8051
    private static const float wepParentScale = 0.2800000011920929;
    // field 17677, runtime offset 124, flags 0x1
    private Item myItem;
    // field 17678, runtime offset 128, flags 0x1
    private System.Action onClose;
    // field 17679, runtime offset 132, flags 0x1
    private System.Action onPurchased;
    // field 17680, runtime offset 136, flags 0x1
    private CaseData suggestToOpenCase;
    // field 17681, runtime offset 140, flags 0x1
    private int giveKpOnWatchAd;
    // method 31549, 0x6000746
    void PurchaseKPNow();
    // method 31550, 0x6000747
    void Update();
    // method 31551, 0x6000748
    void Purchase();
    // method 31552, 0x6000749
    void MeGiveItem();
    // method 31553, 0x600074a
    void GiveItem(Item whatItem, int amount);
    // method 31554, 0x600074b
    void Close();
    // method 31555, 0x600074c
    void OpenCaseAgainPressed();
    // method 31556, 0x600074d
    void Init(Weapon weapon);
    // method 31557, 0x600074e
    void Init(Item item, string customTitle, System.Action _onPurchased, System.Action _onClose, CaseData _suggestToOpenCase);
    // method 31558, 0x600074f
    void PlayIdle();
    // method 31559, 0x6000750
    void EquipButtonPressed();
    // method 31560, 0x6000751
    void ResetEq();
    // method 31561, 0x6000752
    void OnEnable();
    // method 31562, 0x6000753
    void .ctor();
    // method 31563, 0x6000754
    void <Close>b__32_0(float x);
    // method 31564, 0x6000755
    void <Close>b__32_1();
    // method 31565, 0x6000756
    void <OpenCaseAgainPressed>b__39_0(bool success);
    // method 31566, 0x6000757
    void <OpenCaseAgainPressed>b__39_1(bool success);
    // method 31567, 0x6000758
    void <OpenCaseAgainPressed>b__39_2();
}

// TypeDefinition 4258, 0x2000152
class ItemSelectPanel : Popup {
    // field 17696, runtime offset 68, flags 0x6
    public SelectItemButton[] selectItemButtons;
    // method 31583, 0x6000768
    void Load(ItemData[] itemDatas, System.Action<int> onSelected);
    // method 31584, 0x6000769
    void .ctor();
}

// TypeDefinition 4259, 0x2000153
class ItemData : object {
    // field 17697, runtime offset 8, flags 0x6
    public string itemName;
    // field 17698, runtime offset 12, flags 0x6
    public int itemId;
    // field 17699, runtime offset 16, flags 0x6
    public string itemSpritePath;
    // field 17700, runtime offset 20, flags 0x6
    public ItemRarity itemRarity;
    // method 31585, 0x600076a
    void .ctor(string itemName, int itemId, string itemSpritePath, ItemRarity rarity);
}

// TypeDefinition 4260, 0x2000154
class JumpPad : UnityEngine.MonoBehaviour {
    // field 17701, runtime offset 16, flags 0x6
    public int id;
    // field 17702, runtime offset 20, flags 0x6
    public bool stopMomentum;
    // field 17703, runtime offset 24, flags 0x6
    public float height;
    // field 17704, runtime offset 28, flags 0x6
    public bool directional;
    // field 17705, runtime offset 32, flags 0x1
    private UnityEngine.AudioSource jumpAudioSource;
    // method 31586, 0x600076b
    JumpPad Find(int with);
    // method 31587, 0x600076c
    void Play();
    // method 31588, 0x600076d
    void .ctor();
}

// TypeDefinition 4261, 0x2000155
class Item : UnityEngine.ScriptableObject {
    // field 17706, runtime offset 12, flags 0x6
    public ItemRarity rarity;
    // field 17707, runtime offset 16, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredBool secure;
    // field 17708, runtime offset 28, flags 0x6
    public string iconPath;
    // field 17709, runtime offset 32, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt price;
    // field 17710, runtime offset 52, flags 0x6
    public string description;
    // field 17711, runtime offset 56, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredBool watchAdToUnlock;
    // method 31589, 0x600076e
    void SetImageToMySprite(UnityEngine.UI.Image image, int customSize);
    // method 31590, 0x600076f
    string GetKVPairForXsolla();
    // method 31591, 0x6000770
    string get_HasItKey();
    // method 31592, 0x6000771
    string get_IsCurrentKey();
    // method 31593, 0x6000772
    string get_DBValueIfHasItOnce();
    // method 31594, 0x6000773
    void SetAsCurrent();
    // method 31595, 0x6000774
    void HaveOneMore();
    // method 31596, 0x6000775
    int get_AmountHave();
    // method 31597, 0x6000776
    bool get_IsCurrent();
    // method 31598, 0x6000777
    bool get_HasIt();
    // method 31599, 0x6000778
    void .ctor();
}

// TypeDefinition 4262, 0x2000156
class ItemExtension : object {
    // method 31600, 0x6000779
    int GetIndex(Item item);
}

// TypeDefinition 4263, 0x2000157
class KP : Item {
    // method 31601, 0x600077a
    void .ctor();
}

// TypeDefinition 4264, 0x2000158
class KeybindManager : UnityEngine.MonoBehaviour {
    // field 17712, runtime offset 16, flags 0x1
    private System.Collections.Generic.Dictionary<string, UnityEngine.InputSystem.InputAction> actionMap;
    // field 17713, runtime offset 0, flags 0x16
    public static KeybindManager instance;
    // method 31602, 0x600077b
    void Awake();
    // method 31603, 0x600077c
    void InitializeActionMap();
    // method 31604, 0x600077d
    void ChangeKeyBinding(string actionName, int bindingIndex, string newBinding);
    // method 31605, 0x600077e
    void ResetAllKeyBindings();
    // method 31606, 0x600077f
    void SaveKeyBindings();
    // method 31607, 0x6000780
    void LoadKeyBindings();
    // method 31608, 0x6000781
    string ConvertToShortString(UnityEngine.InputSystem.InputControl control);
    // method 31609, 0x6000782
    string GetMainKeyName(UnityEngine.InputSystem.InputAction action);
    // method 31610, 0x6000783
    void .ctor();
}

// TypeDefinition 4265, 0x200015a
class <>c__DisplayClass12_0 : object {
    // field 17724, runtime offset 8, flags 0x6
    public KeybindSlot <>4__this;
    // field 17725, runtime offset 12, flags 0x6
    public int bindingIndex;
    // method 31618, 0x600078b
    void .ctor();
    // method 31619, 0x600078c
    void <StartRebinding>b__0(RebindingOperation operation);
}

// TypeDefinition 4266, 0x2000159
class KeybindSlot : UnityEngine.MonoBehaviour {
    // field 17714, runtime offset 16, flags 0x1
    private TMPro.TMP_Text actionTxt;
    // field 17715, runtime offset 20, flags 0x1
    private TMPro.TMP_Text keyPrimaryButton;
    // field 17716, runtime offset 24, flags 0x1
    private TMPro.TMP_Text keySecondaryButton;
    // field 17717, runtime offset 28, flags 0x1
    private UnityEngine.UI.Button primaryButton;
    // field 17718, runtime offset 32, flags 0x1
    private UnityEngine.UI.Button secondaryButton;
    // field 17719, runtime offset 36, flags 0x1
    private string actionName;
    // field 17720, runtime offset 40, flags 0x1
    private UnityEngine.InputSystem.InputAction inputAction;
    // field 17721, runtime offset 44, flags 0x1
    private UnityEngine.GameObject waitingForKeyPanel;
    // field 17722, runtime offset 48, flags 0x1
    private bool waitingForPrimaryKey;
    // field 17723, runtime offset 49, flags 0x1
    private bool waitingForSecondaryKey;
    // method 31611, 0x6000784
    void Init(string displayName, UnityEngine.InputSystem.InputAction inputAction, UnityEngine.GameObject _waitingForKeyPanel);
    // method 31612, 0x6000785
    void SetKeyTexts();
    // method 31613, 0x6000786
    void StartRebinding(bool isPrimary);
    // method 31614, 0x6000787
    void RebindComplete(RebindingOperation operation, int bindingIndex);
    // method 31615, 0x6000788
    void .ctor();
    // method 31616, 0x6000789
    void <Init>b__10_0();
    // method 31617, 0x600078a
    void <Init>b__10_1();
}

// TypeDefinition 4267, 0x200015b
class Knife : Weapon {
    // field 17726, runtime offset 252, flags 0x6
    public UnityEngine.Vector3 inspectRotateExtra;
    // field 17727, runtime offset 264, flags 0x1
    private UnityEngine.Transform impactPrefab;
    // method 31620, 0x600078d
    void CenterForInspect(UnityEngine.Transform knifeObject);
    // method 31621, 0x600078e
    void Inspect();
    // method 31622, 0x600078f
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 31623, 0x6000790
    void .ctor();
}

// TypeDefinition 4268, 0x200015d
class BotState : System.Enum {
    // field 17754, runtime offset 8, flags 0x606
    public int value__;
    // field 17755, runtime offset 0, flags 0x8056
    public static const BotState Walking = 0;
    // field 17756, runtime offset 0, flags 0x8056
    public static const BotState AFK = 1;
}

// TypeDefinition 4269, 0x200015c
class KourBot : UnityEngine.MonoBehaviour {
    // field 17728, runtime offset 16, flags 0x1
    private CharacterSkinManager characterSkinManager;
    // field 17729, runtime offset 20, flags 0x6
    public int health;
    // field 17730, runtime offset 24, flags 0x1
    private ChickenLine myLine;
    // field 17731, runtime offset 28, flags 0x1
    private UnityEngine.Animator animator;
    // field 17732, runtime offset 32, flags 0x1
    private UnityEngine.Transform globalWeaponParent;
    // field 17733, runtime offset 36, flags 0x1
    private RagdollPlayer ragdollPlayer;
    // field 17734, runtime offset 40, flags 0x1
    private UnityEngine.RectTransform globalHealthFill;
    // field 17735, runtime offset 44, flags 0x1
    private UnityEngine.RectTransform globalHealthFillLerp;
    // field 17736, runtime offset 48, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 17737, runtime offset 52, flags 0x1
    private UnityEngine.GameObject globalCanvas;
    // field 17738, runtime offset 56, flags 0x1
    private TMPro.TMP_Text lvlTxt;
    // field 17739, runtime offset 60, flags 0x1
    private BotState state;
    // field 17740, runtime offset 64, flags 0x1
    private UnityEngine.Transform[] movePoints;
    // field 17741, runtime offset 68, flags 0x1
    private float walkSpeed;
    // field 17742, runtime offset 72, flags 0x1
    private float stateWaitTime;
    // field 17743, runtime offset 76, flags 0x1
    private int currentMovePointIndex;
    // field 17744, runtime offset 80, flags 0x1
    private float currentSpeed;
    // field 17745, runtime offset 84, flags 0x1
    private bool isReversed;
    // field 17746, runtime offset 88, flags 0x1
    private float hpFillLerpX;
    // field 17747, runtime offset 92, flags 0x1
    private UnityEngine.Vector3 targetPosition;
    // field 17748, runtime offset 104, flags 0x1
    private float currentVel;
    // field 17749, runtime offset 108, flags 0x1
    private Shooter currentTarget;
    // field 17750, runtime offset 112, flags 0x1
    private int prevMovePointIndex;
    // field 17751, runtime offset 116, flags 0x1
    private int lastMovePointIndex;
    // field 17752, runtime offset 120, flags 0x1
    private Weapon currentGlobalWeapon;
    // field 17753, runtime offset 124, flags 0x1
    private bool died;
    // method 31624, 0x6000791
    void OnDrawGizmos();
    // method 31625, 0x6000792
    void Init(ChickenLine line, int fromIndex);
    // method 31626, 0x6000793
    void Shuffle(M_1019[] array);
    // method 31627, 0x6000794
    void ChangeToRandomState();
    // method 31628, 0x6000795
    BotState GetRandomState();
    // method 31629, 0x6000796
    void Update();
    // method 31630, 0x6000797
    void MoveToNextPoint();
    // method 31631, 0x6000798
    void SetState(BotState newState);
    // method 31632, 0x6000799
    void Die();
    // method 31633, 0x600079a
    void SetWeapon(int weaponIndex, int skinIndex);
    // method 31634, 0x600079b
    void SetHoldAnimation(WeaponType type);
    // method 31635, 0x600079c
    void TakeHealth(UnityEngine.Vector3 point, int finalDamage);
    // method 31636, 0x600079d
    void DieNigga(UnityEngine.Vector3 point);
    // method 31637, 0x600079e
    void .ctor();
}

// TypeDefinition 4270, 0x200015f
class <IenuFixContentSizeFitter>d__5 : object {
    // field 17761, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17762, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17763, runtime offset 16, flags 0x6
    public KourStrikeChatSlot <>4__this;
    // method 31641, 0x60007a2
    void .ctor(int <>1__state);
    // method 31642, 0x60007a3
    void System.IDisposable.Dispose();
    // method 31643, 0x60007a4
    bool MoveNext();
    // method 31644, 0x60007a5
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31645, 0x60007a6
    void System.Collections.IEnumerator.Reset();
    // method 31646, 0x60007a7
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4271, 0x200015e
class KourStrikeChatSlot : UnityEngine.MonoBehaviour {
    // field 17757, runtime offset 16, flags 0x1
    private TMPro.TMP_Text killerText;
    // field 17758, runtime offset 20, flags 0x1
    private TMPro.TMP_Text killedText;
    // field 17759, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image img;
    // field 17760, runtime offset 28, flags 0x1
    private UnityEngine.GameObject outline;
    // method 31638, 0x600079f
    void Init(bool active, string text, int withWeapon, bool flipColors);
    // method 31639, 0x60007a0
    System.Collections.IEnumerator IenuFixContentSizeFitter();
    // method 31640, 0x60007a1
    void .ctor();
}

// TypeDefinition 4272, 0x2000160
class KourstrikeBackInCanvas : UnityEngine.MonoBehaviour {
    // field 17764, runtime offset 16, flags 0x1
    private UnityEngine.GameObject killedByPanel;
    // field 17765, runtime offset 20, flags 0x1
    private UnityEngine.GameObject spectatingPanel;
    // field 17766, runtime offset 24, flags 0x6
    public TMPro.TMP_Text spectatingTxt;
    // field 17767, runtime offset 28, flags 0x6
    public UnityEngine.Sprite terrorIcon;
    // field 17768, runtime offset 32, flags 0x6
    public UnityEngine.Sprite counterTerrorIcon;
    // field 17769, runtime offset 36, flags 0x6
    public UnityEngine.UI.Image teamImg;
    // field 17770, runtime offset 40, flags 0x6
    public TMPro.TMP_Text damageTxt;
    // field 17771, runtime offset 44, flags 0x6
    public TMPro.TMP_Text byUsernameTxt;
    // field 17772, runtime offset 48, flags 0x1
    private System.Action<int> onChangeSpectator;
    // method 31647, 0x60007a8
    void ChangeSpectator(int move);
    // method 31648, 0x60007a9
    void Init(Photon.Realtime.Player killerView, string scoreReceived, int classUsed, System.Action<int> _onChangeSpectator);
    // method 31649, 0x60007aa
    void UpdateSpectatingText(string killerNickName, Photon.Pun.PhotonView pidar);
    // method 31650, 0x60007ab
    void OnRoundEnded();
    // method 31651, 0x60007ac
    void .ctor();
}

// TypeDefinition 4273, 0x2000161
class KourstrikeDeadCamera : UnityEngine.MonoBehaviour {
    // field 17773, runtime offset 16, flags 0x1
    private UnityEngine.Camera myCamera;
    // field 17774, runtime offset 20, flags 0x1
    private UnityEngine.Transform _spectate;
    // field 17775, runtime offset 24, flags 0x1
    private KourstrikeBackInCanvas backInCanvas;
    // field 17776, runtime offset 28, flags 0x1
    private float lastChangeSpectatorTime;
    // method 31652, 0x60007ad
    UnityEngine.Transform get_spectate();
    // method 31653, 0x60007ae
    void set_spectate(UnityEngine.Transform value);
    // method 31654, 0x60007af
    void Init(string hitTagName, KourstrikeBackInCanvas kourstrikeBackInCanvas, Photon.Realtime.Player killerView, Shooter killer);
    // method 31655, 0x60007b0
    void ChangeSpectator(int move);
    // method 31656, 0x60007b1
    void SlowInvocation();
    // method 31657, 0x60007b2
    void Update();
    // method 31658, 0x60007b3
    void OnDestroy();
    // method 31659, 0x60007b4
    void .ctor();
    // method 31660, 0x60007b5
    void <Init>b__6_0();
}

// TypeDefinition 4274, 0x2000163
class <>c : object {
    // field 17799, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17800, runtime offset 4, flags 0x16
    public static System.Func<PlayerLeaderboardData, int> <>9__32_2;
    // field 17801, runtime offset 8, flags 0x16
    public static System.Func<PlayerLeaderboardData, int> <>9__32_0;
    // field 17802, runtime offset 12, flags 0x16
    public static System.Predicate<PlayerLeaderboardData> <>9__32_1;
    // method 31679, 0x60007c8
    void .cctor();
    // method 31680, 0x60007c9
    void .ctor();
    // method 31681, 0x60007ca
    int <UpdateLeaderboard>b__32_2(PlayerLeaderboardData player);
    // method 31682, 0x60007cb
    int <UpdateLeaderboard>b__32_0(PlayerLeaderboardData player);
    // method 31683, 0x60007cc
    bool <UpdateLeaderboard>b__32_1(PlayerLeaderboardData player);
}

// TypeDefinition 4275, 0x2000162
class LeaderboardManager : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 17777, runtime offset 20, flags 0x1
    private TMPro.TMP_Text yourPlaceTxt;
    // field 17778, runtime offset 0, flags 0x8051
    private static const int MAX_KP_PER_MATCH = 150;
    // field 17779, runtime offset 24, flags 0x1
    private TemporaryUnlockPanel temporaryUnlockPanel;
    // field 17780, runtime offset 0, flags 0x16
    public static int currentScore;
    // field 17781, runtime offset 4, flags 0x16
    public static int currentKills;
    // field 17782, runtime offset 8, flags 0x16
    public static int currentDeaths;
    // field 17783, runtime offset 12, flags 0x16
    public static int kpThisMatch;
    // field 17784, runtime offset 16, flags 0x16
    public static LeaderboardManager instance;
    // field 17785, runtime offset 28, flags 0x1
    private GameLeaderboardSlot[] leaderboardSlots;
    // field 17786, runtime offset 32, flags 0x1
    private TMPro.TMP_Text killsTxt;
    // field 17787, runtime offset 36, flags 0x1
    private TMPro.TMP_Text deathsTxt;
    // field 17788, runtime offset 40, flags 0x1
    private UnityEngine.GameObject leaderboardParent;
    // field 17789, runtime offset 44, flags 0x1
    private ExpandedGameplayLeaderboard regularExpandedGameplayLeaderboardPrefab;
    // field 17790, runtime offset 48, flags 0x1
    private ExpandedGameplayLeaderboard teamsExpandedGameplayLeaderboardPrefab;
    // field 17791, runtime offset 52, flags 0x1
    private UnityEngine.Transform expandedGameplayLeaderboardParent;
    // field 17792, runtime offset 56, flags 0x1
    private UnityEngine.RectTransform killCounterParent;
    // field 17793, runtime offset 60, flags 0x1
    private UnityEngine.RectTransform deathCounterParent;
    // field 17794, runtime offset 64, flags 0x1
    private ExpandedGameplayLeaderboard expandedGameplayLeaderboard;
    // field 17795, runtime offset 68, flags 0x1
    private float lastTimeUpdatedKillsLeaderboard;
    // field 17796, runtime offset 72, flags 0x6
    public System.Collections.Generic.List<PlayerLeaderboardData> currentPlayerDatas;
    // field 17797, runtime offset 76, flags 0x6
    public UnityEngine.Transform crosshairParent;
    // field 17798, runtime offset 80, flags 0x6
    public int myBrRank;
    // method 31661, 0x60007b6
    void OnUnlockedItem(bool isWeapon, int itemIndex, int extraParam);
    // method 31662, 0x60007b7
    void OnMyPlayerDied();
    // method 31663, 0x60007b8
    void OnMyPlayerSpawned();
    // method 31664, 0x60007b9
    void ResetStats(bool send);
    // method 31665, 0x60007ba
    void Start();
    // method 31666, 0x60007bb
    void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps);
    // method 31667, 0x60007bc
    void AddScore(int score);
    // method 31668, 0x60007bd
    int CalculateCoins(int score);
    // method 31669, 0x60007be
    void CheckForUnlocks(int totalKills, int oldTotalKills, WeaponClass currentClass, int currentClassIndex, int totalCurrentClassKills);
    // method 31670, 0x60007bf
    int GetLevel(WeaponClass myWeaponClass, int myWeaponClassIndex, int totalKillsWithClass, int totalKillsGeneral);
    // method 31671, 0x60007c0
    void AddScoreAndKill(int score, bool isPublicMatch, out int earnedKp);
    // method 31672, 0x60007c1
    void AddDeath();
    // method 31673, 0x60007c2
    void UpdateLeaderboard();
    // method 31674, 0x60007c3
    void Update();
    // method 31675, 0x60007c4
    void SetLeaderboardFor(bool showKillsInsteadOfScore, GameLeaderboardSlot[] slots, System.Collections.Generic.List<PlayerLeaderboardData> datas);
    // method 31676, 0x60007c5
    void SetLeaderboardFor(GameLeaderboardSlot[] slots, int teamFilter, bool gameEnded);
    // method 31677, 0x60007c6
    void SetLeaderboardFor(GameLeaderboardSlot[] slots, string myUserId, out System.Collections.Generic.List<PlayerLeaderboardData> playerDatas, out int rank, out PlayerLeaderboardData myPlayerLeaderboardData);
    // method 31678, 0x60007c7
    void .ctor();
}

// TypeDefinition 4276, 0x2000164
class PlayerLeaderboardData : object {
    // field 17803, runtime offset 8, flags 0x6
    public string name;
    // field 17804, runtime offset 12, flags 0x6
    public string userID;
    // field 17805, runtime offset 16, flags 0x6
    public int kills;
    // field 17806, runtime offset 20, flags 0x6
    public int deaths;
    // field 17807, runtime offset 24, flags 0x6
    public int score;
    // field 17808, runtime offset 28, flags 0x6
    public int kp;
    // field 17809, runtime offset 32, flags 0x6
    public int teamId;
    // field 17810, runtime offset 36, flags 0x6
    public int actorNum;
    // field 17811, runtime offset 40, flags 0x6
    public string rankName;
    // method 31684, 0x60007cd
    void .ctor();
}

// TypeDefinition 4277, 0x2000166
class <>c : object {
    // field 17824, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17825, runtime offset 4, flags 0x16
    public static System.Func<LeaderboardSlot, bool> <>9__23_0;
    // method 31699, 0x60007dc
    void .cctor();
    // method 31700, 0x60007dd
    void .ctor();
    // method 31701, 0x60007de
    bool <IenuOnGotLeaderboard>b__23_0(LeaderboardSlot slot);
}

// TypeDefinition 4278, 0x2000167
class <IenuOnGotLeaderboard>d__23 : object {
    // field 17826, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17827, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17828, runtime offset 16, flags 0x6
    public LeaderboardsPanel <>4__this;
    // field 17829, runtime offset 20, flags 0x6
    public System.Collections.Generic.List<LeaderboardSlot> slots;
    // field 17830, runtime offset 24, flags 0x1
    private string <myUID>5__2;
    // field 17831, runtime offset 28, flags 0x1
    private int <totalToShow>5__3;
    // field 17832, runtime offset 32, flags 0x1
    private int <i>5__4;
    // field 17833, runtime offset 36, flags 0x1
    private int <loadedButtons>5__5;
    // field 17834, runtime offset 40, flags 0x1
    private bool <showBlacklist>5__6;
    // method 31702, 0x60007df
    void .ctor(int <>1__state);
    // method 31703, 0x60007e0
    void System.IDisposable.Dispose();
    // method 31704, 0x60007e1
    bool MoveNext();
    // method 31705, 0x60007e2
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31706, 0x60007e3
    void System.Collections.IEnumerator.Reset();
    // method 31707, 0x60007e4
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4279, 0x2000165
class LeaderboardsPanel : Popup {
    // field 17812, runtime offset 68, flags 0x1
    private UnityEngine.UI.Button[] allLeaderboardButtons;
    // field 17813, runtime offset 72, flags 0x1
    private MenuLeaderboardSlot[] slotsPool;
    // field 17814, runtime offset 76, flags 0x1
    private UnityEngine.GameObject loadingLeaderboardPanel;
    // field 17815, runtime offset 80, flags 0x1
    private UnityEngine.GameObject errorPanel;
    // field 17816, runtime offset 84, flags 0x1
    private TMPro.TMP_Text valueNameToLoadTxt;
    // field 17817, runtime offset 88, flags 0x1
    private TMPro.TMP_Text nameToLoadTxt;
    // field 17818, runtime offset 92, flags 0x1
    private UnityEngine.UI.LayoutGroup layoutGroup;
    // field 17819, runtime offset 0, flags 0x16
    public static LeaderboardsPanel instance;
    // field 17820, runtime offset 96, flags 0x1
    private string lastValueTitleNameToLoad;
    // field 17821, runtime offset 100, flags 0x1
    private float refreshTimer;
    // field 17822, runtime offset 104, flags 0x1
    private string lastGeneralType;
    // field 17823, runtime offset 108, flags 0x1
    private bool isLoadingLeaderboard;
    // method 31685, 0x60007ce
    void Close(System.Action onfinish);
    // method 31686, 0x60007cf
    bool TryGetInstance(out LeaderboardsPanel _instance);
    // method 31687, 0x60007d0
    void Init(string with);
    // method 31688, 0x60007d1
    string GetFixedType(string type);
    // method 31689, 0x60007d2
    string ConvertToSpacedString(string input);
    // method 31690, 0x60007d3
    void RefreshCurrentLeaderboard();
    // method 31691, 0x60007d4
    void GetLeaderboard(string generalType);
    // method 31692, 0x60007d5
    void GetLeaderboard(UnityEngine.UI.Button calledFrom);
    // method 31693, 0x60007d6
    void OnGotLeaderboard(System.Collections.Generic.List<LeaderboardSlot> slots, int sticky);
    // method 31694, 0x60007d7
    void LeaderboardTimeout();
    // method 31695, 0x60007d8
    void ErrorHandleTryAgain();
    // method 31696, 0x60007d9
    System.Collections.IEnumerator IenuOnGotLeaderboard(System.Collections.Generic.List<LeaderboardSlot> slots, int sticky);
    // method 31697, 0x60007da
    string RemoveCharactersFromUniqueIdentifier(string uniqueIdentifier);
    // method 31698, 0x60007db
    void .ctor();
}

// TypeDefinition 4280, 0x2000168
class LevelManager : UnityEngine.MonoBehaviour {
    // field 17835, runtime offset 16, flags 0x1
    private UnityEngine.AnimationCurve levelCurve;
    // field 17836, runtime offset 0, flags 0x16
    public static LevelManager instance;
    // method 31708, 0x60007e5
    void Awake();
    // method 31709, 0x60007e6
    void Start();
    // method 31710, 0x60007e7
    int GetLevel();
    // method 31711, 0x60007e8
    int GetLevelFromXP(int totalXP);
    // method 31712, 0x60007e9
    void GetLevelAndRemainingXP(int totalXP, out int level, out int deltaXpBetweenForCurrentLevelAndNextLevel, out int xpSoFar);
    // method 31713, 0x60007ea
    void .ctor();
}

// TypeDefinition 4281, 0x2000169
class LoadMyMaterialTexture : UnityEngine.MonoBehaviour {
    // field 17837, runtime offset 16, flags 0x1
    private string texturePath;
    // method 31714, 0x60007eb
    void Start();
    // method 31715, 0x60007ec
    void .ctor();
    // method 31716, 0x60007ed
    void <Start>b__1_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4282, 0x200016a
class LoadMyMesh : UnityEngine.MonoBehaviour {
    // field 17838, runtime offset 16, flags 0x1
    private string myMeshName;
    // method 31717, 0x60007ee
    void Start();
    // method 31718, 0x60007ef
    void .ctor();
    // method 31719, 0x60007f0
    void <Start>b__1_0(UnityEngine.Mesh x);
}

// TypeDefinition 4283, 0x200016b
class LoadingTransition : UnityEngine.MonoBehaviour {
    // method 31720, 0x60007f1
    void Start();
    // method 31721, 0x60007f2
    void .ctor();
}

// TypeDefinition 4284, 0x200016d
class <>c__DisplayClass12_0 : object {
    // field 17850, runtime offset 8, flags 0x6
    public string danceName;
    // method 31731, 0x60007fc
    void .ctor();
    // method 31732, 0x60007fd
    bool <Dance>b__0(Emote music);
}

// TypeDefinition 4285, 0x200016e
class <IenuOnEndOfDance>d__13 : object {
    // field 17851, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17852, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17853, runtime offset 16, flags 0x6
    public float wait;
    // field 17854, runtime offset 20, flags 0x6
    public UnityEngine.AudioSource danceSource;
    // field 17855, runtime offset 24, flags 0x6
    public LobbyPlayer <>4__this;
    // method 31733, 0x60007fe
    void .ctor(int <>1__state);
    // method 31734, 0x60007ff
    void System.IDisposable.Dispose();
    // method 31735, 0x6000800
    bool MoveNext();
    // method 31736, 0x6000801
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31737, 0x6000802
    void System.Collections.IEnumerator.Reset();
    // method 31738, 0x6000803
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4286, 0x200016f
class <IenuRebind>d__18 : object {
    // field 17856, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17857, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17858, runtime offset 16, flags 0x6
    public LobbyPlayer <>4__this;
    // field 17859, runtime offset 20, flags 0x6
    public string s;
    // method 31739, 0x6000804
    void .ctor(int <>1__state);
    // method 31740, 0x6000805
    void System.IDisposable.Dispose();
    // method 31741, 0x6000806
    bool MoveNext();
    // method 31742, 0x6000807
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31743, 0x6000808
    void System.Collections.IEnumerator.Reset();
    // method 31744, 0x6000809
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4287, 0x200016c
class LobbyPlayer : UnityEngine.MonoBehaviour {
    // field 17839, runtime offset 16, flags 0x1
    private bool isPartyPlayer;
    // field 17840, runtime offset 17, flags 0x1
    private bool isMainMenuCharacter;
    // field 17841, runtime offset 20, flags 0x1
    private int overrideLayer;
    // field 17842, runtime offset 24, flags 0x1
    private UnityEngine.Transform weaponParent;
    // field 17843, runtime offset 28, flags 0x1
    private CharacterSkinManager characterSkinManager;
    // field 17844, runtime offset 32, flags 0x1
    private UnityEngine.Animator lobbyAnimator;
    // field 17845, runtime offset 36, flags 0x1
    private UnityEngine.RuntimeAnimatorController defaultController;
    // field 17846, runtime offset 40, flags 0x1
    private UnityEngine.RuntimeAnimatorController danceController;
    // field 17847, runtime offset 44, flags 0x1
    private Weapon currentGlobalWeapon;
    // field 17848, runtime offset 48, flags 0x1
    private float lastDanceTime;
    // field 17849, runtime offset 52, flags 0x1
    private UnityEngine.Coroutine danceCancelCoroutine;
    // method 31722, 0x60007f3
    void Start();
    // method 31723, 0x60007f4
    void Update();
    // method 31724, 0x60007f5
    void Dance(string danceName);
    // method 31725, 0x60007f6
    System.Collections.IEnumerator IenuOnEndOfDance(UnityEngine.AudioSource danceSource, float wait);
    // method 31726, 0x60007f7
    void RefreshSkinAuto();
    // method 31727, 0x60007f8
    void RefreshSkin(int skinIndex, int hatIndex);
    // method 31728, 0x60007f9
    void SetWeapon(int weaponIndex, int currentSkinForWeapon);
    // method 31729, 0x60007fa
    System.Collections.IEnumerator IenuRebind(string s);
    // method 31730, 0x60007fb
    void .ctor();
}

// TypeDefinition 4288, 0x2000171
class <>c__DisplayClass10_0 : object {
    // field 17869, runtime offset 8, flags 0x6
    public LobbyPlayerUI <>4__this;
    // field 17870, runtime offset 12, flags 0x6
    public Photon.Realtime.Player player;
    // field 17871, runtime offset 16, flags 0x6
    public DG.Tweening.TweenCallback <>9__1;
    // method 31753, 0x6000812
    void .ctor();
    // method 31754, 0x6000813
    void <Init>b__0();
    // method 31755, 0x6000814
    void <Init>b__1();
}

// TypeDefinition 4289, 0x2000170
class LobbyPlayerUI : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 17860, runtime offset 0, flags 0x8056
    public static const byte danceEventCode = 3;
    // field 17861, runtime offset 20, flags 0x1
    private TMPro.TMP_Text playerNameTxt;
    // field 17862, runtime offset 24, flags 0x1
    private TMPro.TMP_Text levelTxt;
    // field 17863, runtime offset 28, flags 0x1
    private UnityEngine.GameObject crownLeaderIcon;
    // field 17864, runtime offset 32, flags 0x1
    private int myIndex;
    // field 17865, runtime offset 36, flags 0x1
    private LobbyPlayer myLobbyPlayer;
    // field 17866, runtime offset 40, flags 0x1
    private PartyPlayer partyPlayerPrefab;
    // field 17867, runtime offset 44, flags 0x1
    private PartyPlayer partyPlayer;
    // field 17868, runtime offset 48, flags 0x1
    private Photon.Realtime.Player trackPlayer;
    // method 31745, 0x600080a
    void OnViewMyProfileButtonPressed();
    // method 31746, 0x600080b
    void Init(Photon.Realtime.Player player, bool isEndGameUI, string knownLeaderId);
    // method 31747, 0x600080c
    void ForceEmoteIn(float n);
    // method 31748, 0x600080d
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 31749, 0x600080e
    void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps);
    // method 31750, 0x600080f
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 31751, 0x6000810
    void .ctor();
    // method 31752, 0x6000811
    void <ForceEmoteIn>b__11_0();
}

// TypeDefinition 4290, 0x2000173
class <>c : object {
    // field 17878, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17879, runtime offset 4, flags 0x16
    public static System.Action <>9__9_2;
    // field 17880, runtime offset 8, flags 0x16
    public static System.Action <>9__10_0;
    // field 17881, runtime offset 12, flags 0x16
    public static System.Action <>9__10_2;
    // method 31775, 0x6000828
    void .cctor();
    // method 31776, 0x6000829
    void .ctor();
    // method 31777, 0x600082a
    void <SignupBtn>b__9_2();
    // method 31778, 0x600082b
    void <LoginBtn>b__10_0();
    // method 31779, 0x600082c
    void <LoginBtn>b__10_2();
}

// TypeDefinition 4291, 0x2000174
class <>c__DisplayClass13_0 : object {
    // field 17882, runtime offset 8, flags 0x6
    public LoginPanel <>4__this;
    // field 17883, runtime offset 12, flags 0x6
    public UnityEngine.UI.Toggle consentToggle;
    // method 31780, 0x600082d
    void .ctor();
    // method 31781, 0x600082e
    void <SubmitEmail>b__0(string then);
}

// TypeDefinition 4292, 0x2000175
class <>c__DisplayClass8_0 : object {
    // field 17884, runtime offset 8, flags 0x6
    public string r;
    // field 17885, runtime offset 12, flags 0x6
    public LoginPanel <>4__this;
    // method 31782, 0x600082f
    void .ctor();
    // method 31783, 0x6000830
    void <GoogleLoginBtn>b__2();
}

// TypeDefinition 4293, 0x2000172
class LoginPanel : Popup {
    // field 17872, runtime offset 68, flags 0x1
    private UnityEngine.GameObject emailMissingParent;
    // field 17873, runtime offset 72, flags 0x1
    private ProfanityList profanityList;
    // field 17874, runtime offset 76, flags 0x1
    private TMPro.TMP_Text login_resultTxt;
    // field 17875, runtime offset 80, flags 0x1
    private UnityEngine.UI.InputField login_nameIF;
    // field 17876, runtime offset 84, flags 0x1
    private UnityEngine.UI.InputField login_passwordIF;
    // field 17877, runtime offset 88, flags 0x1
    private UnityEngine.UI.InputField login_emailIF;
    // method 31756, 0x6000815
    void OpenUrl(string x);
    // method 31757, 0x6000816
    void Show();
    // method 31758, 0x6000817
    void GoogleLoginBtn();
    // method 31759, 0x6000818
    void SignupBtn();
    // method 31760, 0x6000819
    void LoginBtn();
    // method 31761, 0x600081a
    void RefreshEmailMissingPanel(bool closeIfPossible);
    // method 31762, 0x600081b
    bool ShowEmailMissingPanel();
    // method 31763, 0x600081c
    void SubmitEmail(UnityEngine.UI.Toggle consentToggle);
    // method 31764, 0x600081d
    bool IsValidEmail(string email);
    // method 31765, 0x600081e
    void .ctor();
    // method 31766, 0x600081f
    void <GoogleLoginBtn>b__8_0();
    // method 31767, 0x6000820
    void <GoogleLoginBtn>b__8_1(string r);
    // method 31768, 0x6000821
    void <GoogleLoginBtn>b__8_3();
    // method 31769, 0x6000822
    void <SignupBtn>b__9_0();
    // method 31770, 0x6000823
    void <SignupBtn>b__9_1(string result);
    // method 31771, 0x6000824
    void <SignupBtn>b__9_3();
    // method 31772, 0x6000825
    void <LoginBtn>b__10_1(string result);
    // method 31773, 0x6000826
    void <LoginBtn>b__10_3();
    // method 31774, 0x6000827
    string <IsValidEmail>g__DomainMapper|14_0(System.Text.RegularExpressions.Match match);
}

// TypeDefinition 4294, 0x2000177
class <>c : object {
    // field 17924, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 17925, runtime offset 4, flags 0x16
    public static System.Func<CharacterSkin, Item> <>9__20_0;
    // field 17926, runtime offset 8, flags 0x16
    public static UnityEngine.Events.UnityAction<Battlehub.RTCommon.ExposeToEditor> <>9__70_0;
    // field 17927, runtime offset 12, flags 0x16
    public static System.Action <>9__77_0;
    // method 31834, 0x6000863
    void .cctor();
    // method 31835, 0x6000864
    void .ctor();
    // method 31836, 0x6000865
    Item <ChangeDefaultCharacterSkinButtonPressed>b__20_0(CharacterSkin x);
    // method 31837, 0x6000866
    void <NewMapObjectButtonPressed>b__70_0(Battlehub.RTCommon.ExposeToEditor x);
    // method 31838, 0x6000867
    void <LoadMap>b__77_0();
}

// TypeDefinition 4295, 0x2000178
class <>c__DisplayClass27_0 : object {
    // field 17928, runtime offset 8, flags 0x6
    public MapBuilder <>4__this;
    // field 17929, runtime offset 12, flags 0x6
    public int[] selected;
    // field 17930, runtime offset 16, flags 0x6
    public Weapon[] allWeapons;
    // field 17931, runtime offset 20, flags 0x6
    public System.Action<Weapon> <>9__2;
    // field 17932, runtime offset 24, flags 0x6
    public System.Action<Weapon> <>9__1;
    // method 31839, 0x6000868
    void .ctor();
    // method 31840, 0x6000869
    void <ChangeOverrideAllowedWeaponsButtonPressed>b__0(Weapon x);
    // method 31841, 0x600086a
    void <ChangeOverrideAllowedWeaponsButtonPressed>b__1(Weapon x);
    // method 31842, 0x600086b
    void <ChangeOverrideAllowedWeaponsButtonPressed>b__2(Weapon x);
}

// TypeDefinition 4296, 0x2000179
class <>c__DisplayClass38_0 : object {
    // field 17933, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomOptions ops;
    // method 31843, 0x600086c
    void .ctor();
    // method 31844, 0x600086d
    void <PlaytestNow>b__0(string mapNameReady);
}

// TypeDefinition 4297, 0x200017a
class <>c__DisplayClass69_0`1 : object {
    // field 17934, runtime offset 0, flags 0x6
    public MapBuilder <>4__this;
    // field 17935, runtime offset 0, flags 0x6
    public System.Action<T_1021> then;
    // field 17936, runtime offset 0, flags 0x6
    public System.Action<T_1021> <>9__1;
    // method 31845, 0x600086e
    void .ctor();
    // method 31846, 0x600086f
    void <SelectObject>b__0(T_1021 x);
    // method 31847, 0x6000870
    void <SelectObject>b__1(T_1021 x);
}

// TypeDefinition 4298, 0x200017b
class <IenuHierarchySearch>d__3 : object {
    // field 17937, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 17938, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 17939, runtime offset 16, flags 0x6
    public string searchString;
    // field 17940, runtime offset 20, flags 0x6
    public MapBuilder <>4__this;
    // method 31848, 0x6000871
    void .ctor(int <>1__state);
    // method 31849, 0x6000872
    void System.IDisposable.Dispose();
    // method 31850, 0x6000873
    bool MoveNext();
    // method 31851, 0x6000874
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31852, 0x6000875
    void System.Collections.IEnumerator.Reset();
    // method 31853, 0x6000876
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4299, 0x2000176
class MapBuilder : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 17886, runtime offset 20, flags 0x1
    private EditorSpawnPoint[] spawnPoints;
    // field 17887, runtime offset 24, flags 0x1
    private UnityEngine.Coroutine hierarchySearchCoroutine;
    // field 17888, runtime offset 0, flags 0x8051
    private static const string KOUR_EDITOR_VERSION = "1.3";
    // field 17889, runtime offset 28, flags 0x1
    private TMPro.TMP_Text kourEditorVersionTxt;
    // field 17890, runtime offset 32, flags 0x1
    private UnityEngine.UI.InputField gravityIF;
    // field 17891, runtime offset 36, flags 0x1
    private UnityEngine.UI.InputField groundLimitIF;
    // field 17892, runtime offset 40, flags 0x1
    private UnityEngine.UI.InputField airLimitIF;
    // field 17893, runtime offset 44, flags 0x1
    private UnityEngine.UI.Toggle dashToggle;
    // field 17894, runtime offset 48, flags 0x1
    private UnityEngine.GameObject loadingFullPanel;
    // field 17895, runtime offset 52, flags 0x1
    private TMPro.TMP_Text forceCharacterSkinTxt;
    // field 17896, runtime offset 56, flags 0x1
    private TMPro.TMP_Text settingsGameModeTxt;
    // field 17897, runtime offset 60, flags 0x1
    private UnityEngine.UI.InputField settingsGameNameTxt;
    // field 17898, runtime offset 64, flags 0x1
    private TMPro.TMP_Text overrideAllowedWeaponsTxt;
    // field 17899, runtime offset 68, flags 0x1
    private MapObject currentCopy;
    // field 17900, runtime offset 0, flags 0x16
    public static bool isPlaytestingRn;
    // field 17901, runtime offset 72, flags 0x1
    private DG.Tweening.Sequence notificationSequence;
    // field 17902, runtime offset 76, flags 0x1
    private TMPro.TMP_Text notificationTxt;
    // field 17903, runtime offset 80, flags 0x1
    private UnityEngine.RectTransform notificationRectTransform;
    // field 17904, runtime offset 84, flags 0x1
    private UnityEngine.RectTransform canvas;
    // field 17905, runtime offset 88, flags 0x1
    private PublishGamePanel publishGamePanel;
    // field 17906, runtime offset 4, flags 0x16
    public static MapSettings currentMapSettings;
    // field 17907, runtime offset 92, flags 0x1
    private UnityEngine.CanvasGroup splashScreen;
    // field 17908, runtime offset 96, flags 0x1
    private TMPro.TMP_Text newObjectPanelTitle;
    // field 17909, runtime offset 100, flags 0x6
    public UnityEngine.Camera previewCamera;
    // field 17910, runtime offset 104, flags 0x6
    public UnityEngine.MeshFilter previewMeshFilter;
    // field 17911, runtime offset 108, flags 0x6
    public UnityEngine.RenderTexture renderTexture;
    // field 17912, runtime offset 8, flags 0x16
    public static MapBuilder instance;
    // field 17913, runtime offset 112, flags 0x1
    private InspectObjectPanel inspectObjectPanel;
    // field 17914, runtime offset 116, flags 0x1
    private HierarchyButton hierarchyButtonPrefab;
    // field 17915, runtime offset 120, flags 0x1
    private UnityEngine.GameObject newObjectPanel;
    // field 17916, runtime offset 124, flags 0x1
    private NewMapObjectButton newMapObjectButtonPrefab;
    // field 17917, runtime offset 128, flags 0x1
    private UnityEngine.Transform newMapObjectButtonsParent;
    // field 17918, runtime offset 132, flags 0x1
    private UnityEngine.Transform hierarchyButtonsParent;
    // field 17919, runtime offset 136, flags 0x1
    private MapObjectPrefab[] availableMapObjectPrefabs;
    // field 17920, runtime offset 140, flags 0x6
    public MapBuilderData data;
    // field 17921, runtime offset 144, flags 0x6
    public UnityEngine.Transform subSceneParent;
    // field 17922, runtime offset 148, flags 0x6
    public UnityEngine.Sprite[] defaultIcons;
    // field 17923, runtime offset 152, flags 0x1
    private MapObject currentInspectedObject;
    // method 31784, 0x6000831
    void OnHierarchySearch(string searchString);
    // method 31785, 0x6000832
    System.Collections.IEnumerator IenuHierarchySearch(string searchString);
    // method 31786, 0x6000833
    void OpenURL(string url);
    // method 31787, 0x6000834
    void OnMapSettingsChanged();
    // method 31788, 0x6000835
    void UpdateDefaultCharacterSkinText();
    // method 31789, 0x6000836
    void UpdateGameModeText();
    // method 31790, 0x6000837
    void UpdateOverrideAllowedWeaponsText();
    // method 31791, 0x6000838
    void ChangeDefaultCharacterSkinButtonPressed();
    // method 31792, 0x6000839
    void ChangeGroundLimit(string input);
    // method 31793, 0x600083a
    void ChangAirLimit(string input);
    // method 31794, 0x600083b
    void SetAllowDashing(bool input);
    // method 31795, 0x600083c
    void ChangeGravity(string input);
    // method 31796, 0x600083d
    void ChangeGameModeButtonPressed();
    // method 31797, 0x600083e
    void OnSettingsInputFieldGameNameUpdate(string newGameName);
    // method 31798, 0x600083f
    void ChangeOverrideAllowedWeaponsButtonPressed();
    // method 31799, 0x6000840
    void Save();
    // method 31800, 0x6000841
    void Update();
    // method 31801, 0x6000842
    void Notify(string text);
    // method 31802, 0x6000843
    void OnConnectedToMaster();
    // method 31803, 0x6000844
    void PlaytestNowButtonPressed(bool offline);
    // method 31804, 0x6000845
    void PlaytestNow();
    // method 31805, 0x6000846
    void PublishButtonPressed();
    // method 31806, 0x6000847
    void ShowPublishPanel();
    // method 31807, 0x6000848
    UnityEngine.Sprite GetIconOf(MapObjectPrefab d);
    // method 31808, 0x6000849
    UnityEngine.Sprite Texture2DToSprite(UnityEngine.Texture2D texture);
    // method 31809, 0x600084a
    HierarchyButton GetValidHierarchyButton(int index);
    // method 31810, 0x600084b
    HierarchyButton GetHierarchyButtonOnIndex(int index);
    // method 31811, 0x600084c
    void InspectObject(UnityEngine.GameObject gameO, bool setActiveGameObject);
    // method 31812, 0x600084d
    void UpdateHierarchy(int autoInspectIndex);
    // method 31813, 0x600084e
    void InspectItem(int onIndex);
    // method 31814, 0x600084f
    void NewMapObjectTowardsMenuButtonPressed();
    // method 31815, 0x6000850
    void SelectObject(string title, M_1020[] from, System.Action<M_1020> then, bool allowNone);
    // method 31816, 0x6000851
    void NewMapObjectButtonPressed(MapObjectPrefab mapObjectPrefab);
    // method 31817, 0x6000852
    string SaveCurrentSubScene();
    // method 31818, 0x6000853
    void NewProject();
    // method 31819, 0x6000854
    void SaveMap();
    // method 31820, 0x6000855
    void OpenMap();
    // method 31821, 0x6000856
    void OnMapLoaded(string mapDataString);
    // method 31822, 0x6000857
    void Awake();
    // method 31823, 0x6000858
    void LoadMap(string mapDataString, MapBuilderData data, bool isKourEditor);
    // method 31824, 0x6000859
    void Start();
    // method 31825, 0x600085a
    UnityEngine.Vector3 StringToVector3(string s);
    // method 31826, 0x600085b
    void Exit();
    // method 31827, 0x600085c
    void .ctor();
    // method 31828, 0x600085d
    void <ChangeDefaultCharacterSkinButtonPressed>b__20_1(Item x);
    // method 31829, 0x600085e
    void <ChangeGameModeButtonPressed>b__25_0(GameMode selected);
    // method 31830, 0x600085f
    void <Notify>b__35_0();
    // method 31831, 0x6000860
    void <ShowPublishPanel>b__42_0(UnityEngine.GameObject prefab);
    // method 31832, 0x6000861
    void <Start>b__78_0();
    // method 31833, 0x6000862
    void <Start>b__78_1();
}

// TypeDefinition 4300, 0x200017c
class MapObjectPrefab : object {
    // field 17941, runtime offset 8, flags 0x6
    public string name;
    // field 17942, runtime offset 12, flags 0x6
    public int useMesh;
    // field 17943, runtime offset 16, flags 0x6
    public int useShader;
    // field 17944, runtime offset 20, flags 0x6
    public int useTexture;
    // method 31854, 0x6000877
    void .ctor();
}

// TypeDefinition 4301, 0x200017d
class MapObjectData : object {
    // field 17945, runtime offset 8, flags 0x6
    public string nick;
    // field 17946, runtime offset 12, flags 0x6
    public int mesh;
    // field 17947, runtime offset 16, flags 0x6
    public int shader;
    // field 17948, runtime offset 20, flags 0x6
    public int texture;
    // field 17949, runtime offset 24, flags 0x6
    public string pos;
    // field 17950, runtime offset 28, flags 0x6
    public string rot;
    // field 17951, runtime offset 32, flags 0x6
    public string scale;
    // method 31855, 0x6000878
    void .ctor();
}

// TypeDefinition 4302, 0x200017e
class MapSettings : object {
    // field 17952, runtime offset 8, flags 0x6
    public string gameName;
    // field 17953, runtime offset 12, flags 0x6
    public string creatorUid;
    // field 17954, runtime offset 16, flags 0x6
    public int gameMode;
    // field 17955, runtime offset 20, flags 0x6
    public float groundLimit;
    // field 17956, runtime offset 24, flags 0x6
    public float airLimit;
    // field 17957, runtime offset 28, flags 0x6
    public int[] forceWeapons;
    // field 17958, runtime offset 32, flags 0x6
    public float gravity;
    // field 17959, runtime offset 36, flags 0x6
    public bool allowDash;
    // field 17960, runtime offset 40, flags 0x6
    public int forceSkin;
    // field 17961, runtime offset 44, flags 0x6
    public UnityEngine.Vector3[] spawnPoints;
    // method 31856, 0x6000879
    string SerializeSettings();
    // method 31857, 0x600087a
    MapSettings DeserializeSettings(string json);
    // method 31858, 0x600087b
    void .ctor();
}

// TypeDefinition 4303, 0x200017f
class MapBuilderData : UnityEngine.ScriptableObject {
    // field 17962, runtime offset 12, flags 0x6
    public UnityEngine.Mesh[] meshList;
    // field 17963, runtime offset 16, flags 0x6
    public UnityEngine.Texture2D[] textureList;
    // field 17964, runtime offset 20, flags 0x6
    public UnityEngine.Material[] shaderList;
    // method 31859, 0x600087c
    void .ctor();
}

// TypeDefinition 4304, 0x2000181
class <>c : object {
    // field 18061, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18062, runtime offset 4, flags 0x16
    public static System.Func<UnityEngine.GameObject, bool> <>9__102_1;
    // field 18063, runtime offset 8, flags 0x16
    public static System.Func<int, int> <>9__102_2;
    // field 18064, runtime offset 12, flags 0x16
    public static System.Func<int, int> <>9__102_3;
    // field 18065, runtime offset 16, flags 0x16
    public static System.Action<bool> <>9__141_0;
    // field 18066, runtime offset 20, flags 0x16
    public static System.Action<string> <>9__146_3;
    // field 18067, runtime offset 24, flags 0x16
    public static System.Action<string> <>9__166_4;
    // method 31948, 0x60008d5
    void .cctor();
    // method 31949, 0x60008d6
    void .ctor();
    // method 31950, 0x60008d7
    bool <Start>b__102_1(UnityEngine.GameObject obj);
    // method 31951, 0x60008d8
    int <Start>b__102_2(int i);
    // method 31952, 0x60008d9
    int <Start>b__102_3(int i);
    // method 31953, 0x60008da
    void <FreeKP>b__141_0(bool success);
    // method 31954, 0x60008db
    void <OnMissionPressed>b__146_3(string successXp);
    // method 31955, 0x60008dc
    void <SetupProfilePanelWith>b__166_4(string result);
}

// TypeDefinition 4305, 0x2000182
class <>c__DisplayClass129_0 : object {
    // field 18068, runtime offset 8, flags 0x6
    public string verifiedAdd;
    // field 18069, runtime offset 12, flags 0x6
    public User user;
    // field 18070, runtime offset 28, flags 0x6
    public MapInfo <>4__this;
    // method 31956, 0x60008dd
    void .ctor();
    // method 31957, 0x60008de
    void <OnUserChanged>b__0(string clanDataString);
}

// TypeDefinition 4306, 0x2000183
class <>c__DisplayClass134_0 : object {
    // field 18071, runtime offset 8, flags 0x6
    public Photon.Pun.UtilityScripts.PhotonTeam currentTeam;
    // method 31958, 0x60008df
    void .ctor();
    // method 31959, 0x60008e0
    bool <CanJoinTeam>b__0(Photon.Pun.UtilityScripts.PhotonTeam team);
}

// TypeDefinition 4307, 0x2000184
class <>c__DisplayClass146_0 : object {
    // field 18072, runtime offset 8, flags 0x6
    public int missionIndex;
    // field 18073, runtime offset 12, flags 0x6
    public int kpReward;
    // field 18074, runtime offset 16, flags 0x6
    public int xpReward;
    // field 18075, runtime offset 20, flags 0x6
    public int customSkinReward;
    // field 18076, runtime offset 24, flags 0x6
    public System.Action<string> <>9__2;
    // field 18077, runtime offset 28, flags 0x6
    public System.Action<string> <>9__1;
    // method 31960, 0x60008e1
    void .ctor();
    // method 31961, 0x60008e2
    void <OnMissionPressed>b__0(string successMissionClaim);
    // method 31962, 0x60008e3
    void <OnMissionPressed>b__1(string claimDateCall);
    // method 31963, 0x60008e4
    void <OnMissionPressed>b__2(string successCoins);
}

// TypeDefinition 4308, 0x2000185
class <>c__DisplayClass165_0 : object {
    // field 18078, runtime offset 8, flags 0x6
    public MapInfo <>4__this;
    // field 18079, runtime offset 12, flags 0x6
    public string otherUserUID;
    // method 31964, 0x60008e5
    void .ctor();
    // method 31965, 0x60008e6
    void <ShowOtherUserProfile>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4309, 0x2000186
class <>c__DisplayClass166_0 : object {
    // field 18080, runtime offset 8, flags 0x6
    public MapInfo <>4__this;
    // field 18081, runtime offset 12, flags 0x6
    public string otherUserUID;
    // field 18082, runtime offset 16, flags 0x6
    public System.Action<string> <>9__2;
    // method 31966, 0x60008e7
    void .ctor();
    // method 31967, 0x60008e8
    void <SetupProfilePanelWith>b__0(string rawCall);
    // method 31968, 0x60008e9
    void <SetupProfilePanelWith>b__2(string clanDataString);
}

// TypeDefinition 4310, 0x2000187
class <>c__DisplayClass166_1 : object {
    // field 18083, runtime offset 8, flags 0x6
    public UnityEngine.GameObject addFriendButton;
    // field 18084, runtime offset 12, flags 0x6
    public <>c__DisplayClass166_0 CS$<>8__locals1;
    // method 31969, 0x60008ea
    void .ctor();
    // method 31970, 0x60008eb
    void <SetupProfilePanelWith>b__1(string otherIsFriend);
}

// TypeDefinition 4311, 0x2000188
class <>c__DisplayClass166_2 : object {
    // field 18085, runtime offset 8, flags 0x6
    public string myLocalClan;
    // field 18086, runtime offset 12, flags 0x6
    public string me;
    // field 18087, runtime offset 16, flags 0x6
    public <>c__DisplayClass166_0 CS$<>8__locals2;
    // method 31971, 0x60008ec
    void .ctor();
    // method 31972, 0x60008ed
    void <SetupProfilePanelWith>b__3();
}

// TypeDefinition 4312, 0x2000189
class <CheckAverageFPS>d__107 : object {
    // field 18088, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18089, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18090, runtime offset 16, flags 0x1
    private float <checkDuration>5__2;
    // field 18091, runtime offset 20, flags 0x1
    private float <startTime>5__3;
    // field 18092, runtime offset 24, flags 0x1
    private float <totalFrames>5__4;
    // field 18093, runtime offset 28, flags 0x1
    private float <totalTime>5__5;
    // method 31973, 0x60008ee
    void .ctor(int <>1__state);
    // method 31974, 0x60008ef
    void System.IDisposable.Dispose();
    // method 31975, 0x60008f0
    bool MoveNext();
    // method 31976, 0x60008f1
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31977, 0x60008f2
    void System.Collections.IEnumerator.Reset();
    // method 31978, 0x60008f3
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4313, 0x200018a
class <IenuShowResumeTxt>d__147 : object {
    // field 18094, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18095, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18096, runtime offset 16, flags 0x1
    private float <currentResumeTime>5__2;
    // method 31979, 0x60008f4
    void .ctor(int <>1__state);
    // method 31980, 0x60008f5
    void System.IDisposable.Dispose();
    // method 31981, 0x60008f6
    bool MoveNext();
    // method 31982, 0x60008f7
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31983, 0x60008f8
    void System.Collections.IEnumerator.Reset();
    // method 31984, 0x60008f9
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4314, 0x200018b
class <IenuSpawnBotOnLine>d__117 : object {
    // field 18097, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18098, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18099, runtime offset 16, flags 0x6
    public float afterTime;
    // field 18100, runtime offset 20, flags 0x6
    public ChickenLine line;
    // field 18101, runtime offset 24, flags 0x6
    public int notOn;
    // field 18102, runtime offset 28, flags 0x6
    public MapInfo <>4__this;
    // method 31985, 0x60008fa
    void .ctor(int <>1__state);
    // method 31986, 0x60008fb
    void System.IDisposable.Dispose();
    // method 31987, 0x60008fc
    bool MoveNext();
    // method 31988, 0x60008fd
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31989, 0x60008fe
    void System.Collections.IEnumerator.Reset();
    // method 31990, 0x60008ff
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4315, 0x200018c
class <IenuSpawnChickenOnLine>d__115 : object {
    // field 18103, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18104, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18105, runtime offset 16, flags 0x6
    public float afterTime;
    // field 18106, runtime offset 20, flags 0x6
    public ChickenLine line;
    // field 18107, runtime offset 24, flags 0x6
    public int notOn;
    // field 18108, runtime offset 28, flags 0x6
    public MapInfo <>4__this;
    // method 31991, 0x6000900
    void .ctor(int <>1__state);
    // method 31992, 0x6000901
    void System.IDisposable.Dispose();
    // method 31993, 0x6000902
    bool MoveNext();
    // method 31994, 0x6000903
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 31995, 0x6000904
    void System.Collections.IEnumerator.Reset();
    // method 31996, 0x6000905
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4316, 0x200018d
class <IenuSpawnWithDelay>d__150 : object {
    // field 18109, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18110, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18111, runtime offset 16, flags 0x6
    public MapInfo <>4__this;
    // method 31997, 0x6000906
    void .ctor(int <>1__state);
    // method 31998, 0x6000907
    void System.IDisposable.Dispose();
    // method 31999, 0x6000908
    bool MoveNext();
    // method 32000, 0x6000909
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32001, 0x600090a
    void System.Collections.IEnumerator.Reset();
    // method 32002, 0x600090b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4317, 0x200018e
class <IenuSpectateCamera>d__149 : object {
    // field 18112, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18113, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18114, runtime offset 16, flags 0x6
    public MapInfo <>4__this;
    // method 32003, 0x600090c
    void .ctor(int <>1__state);
    // method 32004, 0x600090d
    void System.IDisposable.Dispose();
    // method 32005, 0x600090e
    bool MoveNext();
    // method 32006, 0x600090f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32007, 0x6000910
    void System.Collections.IEnumerator.Reset();
    // method 32008, 0x6000911
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4318, 0x200018f
class <RemoveAllTexturesAndApplyColorCoroutine>d__169 : object {
    // field 18115, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18116, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18117, runtime offset 16, flags 0x1
    private UnityEngine.Renderer[] <allRenderers>5__2;
    // field 18118, runtime offset 20, flags 0x1
    private int <batchSize>5__3;
    // field 18119, runtime offset 24, flags 0x1
    private int <index>5__4;
    // method 32009, 0x6000912
    void .ctor(int <>1__state);
    // method 32010, 0x6000913
    void System.IDisposable.Dispose();
    // method 32011, 0x6000914
    bool MoveNext();
    // method 32012, 0x6000915
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32013, 0x6000916
    void System.Collections.IEnumerator.Reset();
    // method 32014, 0x6000917
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4319, 0x2000180
class MapInfo : UnityEngine.MonoBehaviour {
    // field 17965, runtime offset 16, flags 0x6
    public UnityEngine.GameObject[] GOsecrets;
    // field 17966, runtime offset 0, flags 0x11
    private static bool sharedRoomDiscord;
    // field 17967, runtime offset 4, flags 0x16
    public static float lastLeaveTime;
    // field 17968, runtime offset 20, flags 0x1
    private UnityEngine.GameObject[] disableForParkour;
    // field 17969, runtime offset 24, flags 0x6
    public int customSpawnIndex;
    // field 17970, runtime offset 28, flags 0x1
    private MidgameReward[] midgameRewards;
    // field 17971, runtime offset 32, flags 0x1
    private PressYToGetSkinPanel pressYToGetSkinPanel;
    // field 17972, runtime offset 36, flags 0x1
    private UnityEngine.UI.CanvasScaler[] canvasScalers;
    // field 17973, runtime offset 40, flags 0x1
    private TMPro.TMP_Text friendCountTxt;
    // field 17974, runtime offset 44, flags 0x1
    private UnityEngine.GameObject yourPlaceTxtGo;
    // field 17975, runtime offset 48, flags 0x6
    public MissionNotification missionNotification;
    // field 17976, runtime offset 52, flags 0x1
    private UnityEngine.GameObject newMatchButton;
    // field 17977, runtime offset 56, flags 0x1
    private TMPro.TMP_InputField roomNameStaticIF;
    // field 17978, runtime offset 60, flags 0x1
    private TMPro.TMP_InputField roomLinkStaticIF;
    // field 17979, runtime offset 64, flags 0x1
    private Popup invitePopup;
    // field 17980, runtime offset 68, flags 0x1
    private TMPro.TMP_Text[] teamAddTxts;
    // field 17981, runtime offset 72, flags 0x1
    private UnityEngine.GameObject[] youImgs;
    // field 17982, runtime offset 8, flags 0x16
    public static TeamSelectDesign currentTeamDesign;
    // field 17983, runtime offset 76, flags 0x1
    private UnityEngine.UI.Image[] teamBackgrounds;
    // field 17984, runtime offset 80, flags 0x1
    private UnityEngine.UI.Image[] teamImages;
    // field 17985, runtime offset 84, flags 0x1
    private HardpointArea[] hardpointObjectiveGOs;
    // field 17986, runtime offset 88, flags 0x1
    private ScreenSpaceCavityCurvature.SSCC sscc;
    // field 17987, runtime offset 92, flags 0x1
    private GunGameTopPanel gunGameTopPanel;
    // field 17988, runtime offset 96, flags 0x1
    private bool chickenExplosionYellow;
    // field 17989, runtime offset 100, flags 0x1
    private UnityEngine.GameObject classSelectButtonLock;
    // field 17990, runtime offset 104, flags 0x1
    private UnityEngine.Material defaultChickMat;
    // field 17991, runtime offset 108, flags 0x6
    public WorldHitmark[] worldHitmarks;
    // field 17992, runtime offset 112, flags 0x1
    private MissionSlot[] missionSlots;
    // field 17993, runtime offset 116, flags 0x1
    private UnityEngine.GameObject[] hideForPoki;
    // field 17994, runtime offset 120, flags 0x1
    private UnityEngine.GameObject[] hideForCrazyGames;
    // field 17995, runtime offset 124, flags 0x1
    private UnityEngine.GameObject[] hideForAndroidAndIOS;
    // field 17996, runtime offset 128, flags 0x1
    private UnityEngine.GameObject[] hideForMobileWeb;
    // field 17997, runtime offset 132, flags 0x1
    private UnityEngine.Transform chatPanel;
    // field 17998, runtime offset 136, flags 0x1
    private UnityEngine.GameObject loginBtn;
    // field 17999, runtime offset 140, flags 0x1
    private UnityEngine.UI.Toggle spectateToggle;
    // field 18000, runtime offset 144, flags 0x1
    private UnityEngine.GameObject[] showIfLoggedIn;
    // field 18001, runtime offset 148, flags 0x1
    private UnityEngine.UI.Image profileImage;
    // field 18002, runtime offset 152, flags 0x1
    private UnityEngine.UI.Image profileBackgroundImage;
    // field 18003, runtime offset 156, flags 0x1
    private TMPro.TMP_Text mainMenuUsernameTxt;
    // field 18004, runtime offset 160, flags 0x1
    private UnityEngine.RenderTexture playerRT;
    // field 18005, runtime offset 164, flags 0x1
    private UnityEngine.Camera lobbyRenderCamera;
    // field 18006, runtime offset 168, flags 0x1
    private Popup leavePanel;
    // field 18007, runtime offset 172, flags 0x1
    private TMPro.TMP_Text leavePanelTopText;
    // field 18008, runtime offset 12, flags 0x16
    public static string lobbyRequestWindow;
    // field 18009, runtime offset 176, flags 0x1
    private UnityEngine.GameObject[] enableForTeams;
    // field 18010, runtime offset 180, flags 0x1
    private TMPro.TMP_Text[] teamTxts;
    // field 18011, runtime offset 184, flags 0x1
    private MissionsPanel missionPanel;
    // field 18012, runtime offset 188, flags 0x1
    private LoginPanel loginPanel;
    // field 18013, runtime offset 192, flags 0x1
    private ProfilePanel profilePanel;
    // field 18014, runtime offset 196, flags 0x1
    private LobbyPlayer lobbyPlayer;
    // field 18015, runtime offset 200, flags 0x1
    private TMPro.TMP_Text inviteTxt;
    // field 18016, runtime offset 204, flags 0x1
    private TMPro.TMP_Text[] coinTxts;
    // field 18017, runtime offset 208, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 18018, runtime offset 212, flags 0x1
    private TMPro.TMP_Text lvlTxt;
    // field 18019, runtime offset 216, flags 0x1
    private KourBot botPrefab;
    // field 18020, runtime offset 220, flags 0x1
    private ChickenController chickenPrefab;
    // field 18021, runtime offset 224, flags 0x1
    private ChickenLine[] chickenLines;
    // field 18022, runtime offset 228, flags 0x1
    private ChickenLine[] botLines;
    // field 18023, runtime offset 232, flags 0x1
    private UnityEngine.GameObject victoryPanel;
    // field 18024, runtime offset 236, flags 0x1
    private UnityEngine.GameObject defeatPanel;
    // field 18025, runtime offset 240, flags 0x1
    private TMPro.TMP_Text fpsTxt;
    // field 18026, runtime offset 244, flags 0x1
    private TMPro.TMP_Text currentClassTxt;
    // field 18027, runtime offset 248, flags 0x1
    private UnityEngine.UI.Image currentClassImg;
    // field 18028, runtime offset 16, flags 0x16
    public static MapInfo instance;
    // field 18029, runtime offset 252, flags 0x6
    public UnityEngine.Transform[] spawnPoints;
    // field 18030, runtime offset 256, flags 0x6
    public UnityEngine.Camera defaultCamera;
    // field 18031, runtime offset 260, flags 0x1
    private GameEndedPanel gameEndedPanelPrefab;
    // field 18032, runtime offset 264, flags 0x1
    private UnityEngine.RectTransform priorityCanvas;
    // field 18033, runtime offset 268, flags 0x1
    private TeamSelectPanel teamSelectPanelPrefab;
    // field 18034, runtime offset 272, flags 0x6
    public UnityEngine.GameObject gamePausedPanel;
    // field 18035, runtime offset 276, flags 0x1
    private TMPro.TMP_Text resumeGameTxt;
    // field 18036, runtime offset 280, flags 0x1
    private TMPro.TMP_Text timerTxt;
    // field 18037, runtime offset 284, flags 0x1
    private float lastEscapeTime;
    // field 18038, runtime offset 0, flags 0x8056
    public static const string START_TIME_KEY = "C5";
    // field 18039, runtime offset 288, flags 0x6
    public double gamePhotonStartTime;
    // field 18040, runtime offset 296, flags 0x1
    private int matchTimeInSeconds;
    // field 18041, runtime offset 20, flags 0x16
    public static bool isKourStrike;
    // field 18042, runtime offset 21, flags 0x16
    public static bool parkourGameFinished;
    // field 18043, runtime offset 304, flags 0x1
    private double parkourTime;
    // field 18044, runtime offset 312, flags 0x1
    private bool lastGamePausedPanelActive;
    // field 18045, runtime offset 24, flags 0x11
    private static System.Action<bool> OnGameSceneLoad;
    // field 18046, runtime offset 0, flags 0x8051
    private static const float TIMER_TIMEOUT = 100;
    // field 18047, runtime offset 313, flags 0x6
    public bool matchEnded;
    // field 18048, runtime offset 320, flags 0x6
    public double lastKnownTimerInSeconds;
    // field 18049, runtime offset 328, flags 0x1
    private GameEndedPanel currentGameEndedPanel;
    // field 18050, runtime offset 332, flags 0x1
    private bool waitingForSpawn;
    // field 18051, runtime offset 333, flags 0x1
    private bool forceResumeOnJoinTeam;
    // field 18052, runtime offset 336, flags 0x6
    public UnityEngine.RectTransform canvas;
    // field 18053, runtime offset 340, flags 0x1
    private Popup settingsPanel;
    // field 18054, runtime offset 344, flags 0x6
    public bool leaveButtonWasPressed;
    // field 18055, runtime offset 0, flags 0x8056
    public static const string TEAM_1_TOTAL_SCORE_KEY = "T1S";
    // field 18056, runtime offset 0, flags 0x8056
    public static const string TEAM_2_TOTAL_SCORE_KEY = "T2S";
    // field 18057, runtime offset 0, flags 0x8056
    public static const string TEAM_3_TOTAL_SCORE_KEY = "T3S";
    // field 18058, runtime offset 0, flags 0x8056
    public static const string TEAM_4_TOTAL_SCORE_KEY = "T4S";
    // field 18059, runtime offset 348, flags 0x1
    private int previousTeam0Score;
    // field 18060, runtime offset 352, flags 0x1
    private int previousTeam1Score;
    // method 31860, 0x600087d
    void OnFoundSecret(UnityEngine.GameObject secret);
    // method 31861, 0x600087e
    int GetTotalSecretsFound(out int total);
    // method 31862, 0x600087f
    void ShareRoomDiscord();
    // method 31863, 0x6000880
    string whoami();
    // method 31864, 0x6000881
    string checkRoomProp(string key);
    // method 31865, 0x6000882
    void SetCustomSpawnIndex(int index);
    // method 31866, 0x6000883
    void SetHUD(float given);
    // method 31867, 0x6000884
    void ShowMyFriendList();
    // method 31868, 0x6000885
    void KourLogoPressed();
    // method 31869, 0x6000886
    void OnLeftNavButtonPressed(string takeTo);
    // method 31870, 0x6000887
    void CloseLeavePanel();
    // method 31871, 0x6000888
    bool TryGetInstance(out MapInfo _instance);
    // method 31872, 0x6000889
    void ShowMissionPanel();
    // method 31873, 0x600088a
    void ShowProfilePanel();
    // method 31874, 0x600088b
    void ShowLoginPanel();
    // method 31875, 0x600088c
    void InviteFriend();
    // method 31876, 0x600088d
    void ResetInviteLink();
    // method 31877, 0x600088e
    void Update();
    // method 31878, 0x600088f
    void Awake();
    // method 31879, 0x6000890
    void add_OnGameSceneLoad(System.Action<bool> value);
    // method 31880, 0x6000891
    void remove_OnGameSceneLoad(System.Action<bool> value);
    // method 31881, 0x6000892
    void Start();
    // method 31882, 0x6000893
    void CheckForMidgameReward();
    // method 31883, 0x6000894
    void OnMidgameRewardClaimedOrClosed();
    // method 31884, 0x6000895
    int GetDesignIndex();
    // method 31885, 0x6000896
    TeamSelectDesign GetDesign();
    // method 31886, 0x6000897
    System.Collections.IEnumerator CheckAverageFPS();
    // method 31887, 0x6000898
    bool get_IsGunGame();
    // method 31888, 0x6000899
    bool get_IsParkour();
    // method 31889, 0x600089a
    void SpawnChicken(int i);
    // method 31890, 0x600089b
    void SpawnBot(int i);
    // method 31891, 0x600089c
    void SpawnChickenOnLine(ChickenLine line, int notOn, float afterTime);
    // method 31892, 0x600089d
    System.Collections.IEnumerator IenuSpawnChickenOnLine(ChickenLine line, int notOn, float afterTime);
    // method 31893, 0x600089e
    void SpawnBotOnLine(ChickenLine line, int notOn, float afterTime);
    // method 31894, 0x600089f
    System.Collections.IEnumerator IenuSpawnBotOnLine(ChickenLine line, int notOn, float afterTime);
    // method 31895, 0x60008a0
    int[] GetUniqueRandomInts(int[] inputArray, int count);
    // method 31896, 0x60008a1
    void VerySlowUpdate();
    // method 31897, 0x60008a2
    void OnGameEnded(int timerInSeconds);
    // method 31898, 0x60008a3
    void KourstrikeEndGame();
    // method 31899, 0x60008a4
    void OnUIGameEndedAnimationFinished();
    // method 31900, 0x60008a5
    void ShowSelectTeamPanel();
    // method 31901, 0x60008a6
    void OnUserChanged(User user, bool b);
    // method 31902, 0x60008a7
    void SetNickname(string nick);
    // method 31903, 0x60008a8
    void OnChosenTeam(string teamName, TeamSelectPanel from, System.Action onApprove);
    // method 31904, 0x60008a9
    void OnPlayerJoinTeam(Photon.Realtime.Player targetPlayer, Photon.Pun.UtilityScripts.PhotonTeam team);
    // method 31905, 0x60008aa
    bool CanJoinTeam(Photon.Pun.UtilityScripts.PhotonTeam newTeam, out string result, out bool wasNullBefore);
    // method 31906, 0x60008ab
    string ToTimer(double time, bool showMillisecondsToo);
    // method 31907, 0x60008ac
    void OnEnable();
    // method 31908, 0x60008ad
    void OnDisable();
    // method 31909, 0x60008ae
    void AnalyticsReport(string n);
    // method 31910, 0x60008af
    void FreeKP();
    // method 31911, 0x60008b0
    void ShowSettingsPanel();
    // method 31912, 0x60008b1
    void OnEscape();
    // method 31913, 0x60008b2
    void ShowGamePausedUI();
    // method 31914, 0x60008b3
    void RedrawMissions();
    // method 31915, 0x60008b4
    void OnMissionPressed(MissionSlot missionSlot);
    // method 31916, 0x60008b5
    System.Collections.IEnumerator IenuShowResumeTxt();
    // method 31917, 0x60008b6
    void ResumeGamePressed();
    // method 31918, 0x60008b7
    System.Collections.IEnumerator IenuSpectateCamera();
    // method 31919, 0x60008b8
    System.Collections.IEnumerator IenuSpawnWithDelay();
    // method 31920, 0x60008b9
    void ResumeGame(bool setDefaultCamera, bool force);
    // method 31921, 0x60008ba
    void LeaveGameBtnPressed();
    // method 31922, 0x60008bb
    void ChangeClass();
    // method 31923, 0x60008bc
    void ChangeClassTo(int newClassIndex);
    // method 31924, 0x60008bd
    void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 31925, 0x60008be
    void FindANewMatch();
    // method 31926, 0x60008bf
    M_1022[] ShuffleArray(M_1022[] array);
    // method 31927, 0x60008c0
    void ShowOtherUserProfile(string otherUserUID);
    // method 31928, 0x60008c1
    void SetupProfilePanelWith(string otherUserUID);
    // method 31929, 0x60008c2
    string ToShortString(double number);
    // method 31930, 0x60008c3
    void StartRemovingTextures();
    // method 31931, 0x60008c4
    System.Collections.IEnumerator RemoveAllTexturesAndApplyColorCoroutine();
    // method 31932, 0x60008c5
    UnityEngine.Color GetAverageColorFromMaterial(UnityEngine.Material material);
    // method 31933, 0x60008c6
    UnityEngine.Color GetAverageColor(UnityEngine.Texture2D texture);
    // method 31934, 0x60008c7
    UnityEngine.Texture2D MakeTextureReadable(UnityEngine.Texture2D original);
    // method 31935, 0x60008c8
    UnityEngine.Color AdjustBrightness(UnityEngine.Color color);
    // method 31936, 0x60008c9
    void TryHideSettingsPanel();
    // method 31937, 0x60008ca
    void .ctor();
    // method 31938, 0x60008cb
    void .cctor();
    // method 31939, 0x60008cc
    void <ShowMissionPanel>b__59_0(UnityEngine.GameObject prefab);
    // method 31940, 0x60008cd
    void <ShowProfilePanel>b__62_0(UnityEngine.GameObject prefab);
    // method 31941, 0x60008ce
    void <ShowLoginPanel>b__63_0(UnityEngine.GameObject prefab);
    // method 31942, 0x60008cf
    void <Start>b__102_0(UnityEngine.Texture2D x);
    // method 31943, 0x60008d0
    void <OnGameEnded>b__123_0();
    // method 31944, 0x60008d1
    void <ShowSettingsPanel>b__142_0(UnityEngine.GameObject prefab);
    // method 31945, 0x60008d2
    void <ChangeClass>b__154_0(int newClassIndex, WeaponClass newClass);
    // method 31946, 0x60008d3
    void <ChangeClass>b__154_1(UnityEngine.Texture2D x);
    // method 31947, 0x60008d4
    void <ChangeClassTo>b__155_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4320, 0x2000191
class <>c : object {
    // field 18127, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18128, runtime offset 4, flags 0x16
    public static UnityEngine.Events.UnityAction<Battlehub.RTCommon.ExposeToEditor> <>9__0_0;
    // field 18129, runtime offset 8, flags 0x16
    public static UnityEngine.Events.UnityAction<Battlehub.RTCommon.ExposeToEditor> <>9__20_0;
    // method 32030, 0x6000927
    void .cctor();
    // method 32031, 0x6000928
    void .ctor();
    // method 32032, 0x6000929
    void <Init>b__0_0(Battlehub.RTCommon.ExposeToEditor x);
    // method 32033, 0x600092a
    void <Duplicate>b__20_0(Battlehub.RTCommon.ExposeToEditor x);
}

// TypeDefinition 4321, 0x2000190
class MapObject : UnityEngine.MonoBehaviour {
    // field 18120, runtime offset 16, flags 0x1
    private string _nick;
    // field 18121, runtime offset 20, flags 0x1
    private int _mesh;
    // field 18122, runtime offset 24, flags 0x1
    private int _texture;
    // field 18123, runtime offset 28, flags 0x1
    private int _shader;
    // field 18124, runtime offset 32, flags 0x6
    public string pos;
    // field 18125, runtime offset 36, flags 0x6
    public string rot;
    // field 18126, runtime offset 40, flags 0x6
    public string scale;
    // method 32015, 0x6000918
    void Init(bool isKourEditor, MapObjectData data, MapBuilderData mapBuilderData);
    // method 32016, 0x6000919
    string get_nick();
    // method 32017, 0x600091a
    void set_nick(string value);
    // method 32018, 0x600091b
    int GetMesh();
    // method 32019, 0x600091c
    void SetMesh(int value, MapBuilderData mapBuilderData);
    // method 32020, 0x600091d
    int GetTexture();
    // method 32021, 0x600091e
    void SetTexture(int value, MapBuilderData mapBuilderData);
    // method 32022, 0x600091f
    int GetShader();
    // method 32023, 0x6000920
    void SetShader(int value, MapBuilderData mapBuilderData);
    // method 32024, 0x6000921
    string Serialize();
    // method 32025, 0x6000922
    UnityEngine.Vector3 StringToVector3(string sVector);
    // method 32026, 0x6000923
    void Duplicate();
    // method 32027, 0x6000924
    void Duplicate(MapObject who);
    // method 32028, 0x6000925
    string GenerateUniqueKey();
    // method 32029, 0x6000926
    void .ctor();
}

// TypeDefinition 4322, 0x2000193
class <BlacklistUser>d__9 : object {
    // field 18138, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18139, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18140, runtime offset 16, flags 0x6
    public string uid;
    // field 18141, runtime offset 20, flags 0x6
    public string authToken;
    // field 18142, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 32044, 0x6000935
    void .ctor(int <>1__state);
    // method 32045, 0x6000936
    void System.IDisposable.Dispose();
    // method 32046, 0x6000937
    bool MoveNext();
    // method 32047, 0x6000938
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32048, 0x6000939
    void System.Collections.IEnumerator.Reset();
    // method 32049, 0x600093a
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4323, 0x2000192
class MenuLeaderboardSlot : UnityEngine.MonoBehaviour {
    // field 18130, runtime offset 16, flags 0x1
    private UnityEngine.GameObject blacklist;
    // field 18131, runtime offset 20, flags 0x1
    private UnityEngine.GameObject enableOnHover;
    // field 18132, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image img;
    // field 18133, runtime offset 28, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 18134, runtime offset 32, flags 0x1
    private TMPro.TMP_Text valueTxt;
    // field 18135, runtime offset 36, flags 0x1
    private TMPro.TMP_Text rankTxt;
    // field 18136, runtime offset 40, flags 0x1
    private string myHolderUID;
    // field 18137, runtime offset 44, flags 0x1
    private bool pressable;
    // method 32034, 0x600092b
    void BlacklistPressed();
    // method 32035, 0x600092c
    System.Collections.IEnumerator BlacklistUser(string uid, string authToken);
    // method 32036, 0x600092d
    void Init(bool showblacklist, bool isClan, int index, string uid, string username, object value, bool isMine);
    // method 32037, 0x600092e
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32038, 0x600092f
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32039, 0x6000930
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32040, 0x6000931
    void .ctor();
    // method 32041, 0x6000932
    void <Init>b__10_0(string usernameNew);
    // method 32042, 0x6000933
    void <Init>b__10_1(string hisClan);
    // method 32043, 0x6000934
    void <Init>b__10_2(string clanColorString);
}

// TypeDefinition 4324, 0x2000194
class MidgameReward : UnityEngine.ScriptableObject {
    // field 18143, runtime offset 12, flags 0x6
    public float imageScale;
    // field 18144, runtime offset 16, flags 0x6
    public int amountToGive;
    // field 18145, runtime offset 20, flags 0x6
    public bool flipView;
    // field 18146, runtime offset 24, flags 0x6
    public string rewardIconAdPath;
    // field 18147, runtime offset 28, flags 0x6
    public string topText;
    // field 18148, runtime offset 32, flags 0x6
    public Item itemToGive;
    // field 18149, runtime offset 36, flags 0x6
    public int forceSetClass;
    // field 18150, runtime offset 40, flags 0x6
    public int showtime;
    // field 18151, runtime offset 44, flags 0x6
    public int showIfPlaytimeIsMoreThan;
    // field 18152, runtime offset 48, flags 0x6
    public int showIfPlaytimeIsLessThan;
    // field 18153, runtime offset 52, flags 0x6
    public int showIfKPIsMoreThan;
    // field 18154, runtime offset 56, flags 0x6
    public int showIfKPIsLessThan;
    // field 18155, runtime offset 60, flags 0x6
    public string prefsValueMustBeZeroOn;
    // field 18156, runtime offset 64, flags 0x1
    private SdkType[] excludeSdkTypes;
    // method 32050, 0x600093b
    bool SDKTypeCheck(SdkType c);
    // method 32051, 0x600093c
    void .ctor();
}

// TypeDefinition 4325, 0x2000195
class Minigun : Weapon {
    // field 18157, runtime offset 252, flags 0x6
    public UnityEngine.ParticleSystem reloadSmoke;
    // method 32052, 0x600093d
    void OnStart();
    // method 32053, 0x600093e
    void Reload(int ammoLeft);
    // method 32054, 0x600093f
    void DisableReloadSmoke();
    // method 32055, 0x6000940
    void .ctor();
}

// TypeDefinition 4326, 0x2000196
class MinimapIndicator : UnityEngine.MonoBehaviour {
    // field 18158, runtime offset 16, flags 0x1
    private float mapSize;
    // field 18159, runtime offset 20, flags 0x1
    private float mapPhysicalSize;
    // field 18160, runtime offset 24, flags 0x1
    private UnityEngine.Transform indicator;
    // field 18161, runtime offset 28, flags 0x1
    private UnityEngine.Transform mapCamera;
    // field 18162, runtime offset 32, flags 0x1
    private TMPro.TMP_Text tmp;
    // method 32056, 0x6000941
    void Start();
    // method 32057, 0x6000942
    void Update();
    // method 32058, 0x6000943
    void .ctor();
}

// TypeDefinition 4327, 0x2000197
class MissionManager : UnityEngine.MonoBehaviour {
    // field 18163, runtime offset 16, flags 0x6
    public GameMission limitedTimeMission;
    // field 18164, runtime offset 20, flags 0x6
    public GameMission[] allMissions;
    // field 18165, runtime offset 0, flags 0x16
    public static MissionManager instance;
    // method 32059, 0x6000944
    void Awake();
    // method 32060, 0x6000945
    void Start();
    // method 32061, 0x6000946
    int[] GetActiveMissions(out bool[] finishedButNotClaimed);
    // method 32062, 0x6000947
    bool IsMissionFinished(GameMission mission, int missionGivenIndex);
    // method 32063, 0x6000948
    void OnPlaytimeUpdate(int playtimeAdded);
    // method 32064, 0x6000949
    void OnWonGame();
    // method 32065, 0x600094a
    void OnGotKill(int withClassIndex, int killsToAdd);
    // method 32066, 0x600094b
    void OnKilledChicken(int chickenType, bool isPublicMatch);
    // method 32067, 0x600094c
    void OnShotEgg(bool isPrivateMatch);
    // method 32068, 0x600094d
    void OnGotHeadshot(int withClassIndex, int headshotsToAdd);
    // method 32069, 0x600094e
    int[] GetCompletedMissions();
    // method 32070, 0x600094f
    void OnVerifiedMissionProgress(GameMission miss, int prev, int newAmount, int max);
    // method 32071, 0x6000950
    void .ctor();
}

// TypeDefinition 4328, 0x2000199
class <>c__DisplayClass13_0 : object {
    // field 18176, runtime offset 8, flags 0x6
    public MissionNotification <>4__this;
    // field 18177, runtime offset 12, flags 0x6
    public int prev;
    // field 18178, runtime offset 16, flags 0x6
    public int newAmount;
    // field 18179, runtime offset 20, flags 0x6
    public float dur2;
    // field 18180, runtime offset 24, flags 0x6
    public int max;
    // field 18181, runtime offset 28, flags 0x6
    public float delayInBetween;
    // field 18182, runtime offset 32, flags 0x6
    public float n2;
    // field 18183, runtime offset 36, flags 0x6
    public float dur1;
    // field 18184, runtime offset 40, flags 0x6
    public float displayFor;
    // field 18185, runtime offset 44, flags 0x6
    public DG.Tweening.TweenCallback<float> <>9__3;
    // field 18186, runtime offset 48, flags 0x6
    public DG.Tweening.TweenCallback <>9__5;
    // field 18187, runtime offset 52, flags 0x6
    public DG.Tweening.TweenCallback <>9__4;
    // method 32076, 0x6000955
    void .ctor();
    // method 32077, 0x6000956
    void <OnProgress>b__1(UnityEngine.Texture2D x);
    // method 32078, 0x6000957
    void <OnProgress>b__2(UnityEngine.Texture2D x);
    // method 32079, 0x6000958
    void <OnProgress>b__0();
    // method 32080, 0x6000959
    void <OnProgress>b__3(float update);
    // method 32081, 0x600095a
    void <OnProgress>b__4();
    // method 32082, 0x600095b
    void <OnProgress>b__5();
}

// TypeDefinition 4329, 0x2000198
class MissionNotification : UnityEngine.MonoBehaviour {
    // field 18166, runtime offset 16, flags 0x1
    private UnityEngine.GameObject pressYtoGetItemPanel;
    // field 18167, runtime offset 20, flags 0x1
    private UnityEngine.GameObject completedPanel;
    // field 18168, runtime offset 24, flags 0x1
    private UnityEngine.UI.Slider progressSlider;
    // field 18169, runtime offset 28, flags 0x1
    private TMPro.TMP_Text progressTxt;
    // field 18170, runtime offset 32, flags 0x1
    private TMPro.TMP_Text earnKpTxt;
    // field 18171, runtime offset 36, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 18172, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image icon;
    // field 18173, runtime offset 44, flags 0x1
    private DG.Tweening.Tween progressTextTween;
    // field 18174, runtime offset 48, flags 0x1
    private DG.Tweening.Tween progressSliderTween;
    // field 18175, runtime offset 52, flags 0x1
    private DG.Tweening.Tween anchorPosTween;
    // method 32072, 0x6000951
    float get_Y_POSITION();
    // method 32073, 0x6000952
    void Update();
    // method 32074, 0x6000953
    void OnProgress(GameMission mission, int prev, int newAmount, int max);
    // method 32075, 0x6000954
    void .ctor();
}

// TypeDefinition 4330, 0x200019b
class <>c__DisplayClass12_0 : object {
    // field 18200, runtime offset 8, flags 0x6
    public MissionSlot <>4__this;
    // field 18201, runtime offset 12, flags 0x6
    public System.Action<MissionSlot> onClaimPressed;
    // method 32086, 0x600095f
    void .ctor();
    // method 32087, 0x6000960
    void <Init>b__1(UnityEngine.Texture2D x);
    // method 32088, 0x6000961
    void <Init>b__2(UnityEngine.Texture2D x);
    // method 32089, 0x6000962
    void <Init>b__0();
}

// TypeDefinition 4331, 0x200019a
class MissionSlot : UnityEngine.MonoBehaviour {
    // field 18188, runtime offset 16, flags 0x1
    private UnityEngine.GameObject claimedPanel;
    // field 18189, runtime offset 20, flags 0x1
    private TMPro.TMP_Text claimedTxt;
    // field 18190, runtime offset 24, flags 0x1
    private UnityEngine.UI.Button claimButton;
    // field 18191, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image backgroundImg;
    // field 18192, runtime offset 32, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 18193, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image icon;
    // field 18194, runtime offset 40, flags 0x1
    private UnityEngine.UI.Slider progressSlider;
    // field 18195, runtime offset 44, flags 0x1
    private TMPro.TMP_Text progressTxt;
    // field 18196, runtime offset 48, flags 0x1
    private TMPro.TMP_Text xpRewardTxt;
    // field 18197, runtime offset 52, flags 0x1
    private TMPro.TMP_Text kpRewardTxt;
    // field 18198, runtime offset 56, flags 0x1
    private UnityEngine.GameObject kpIcon;
    // field 18199, runtime offset 60, flags 0x6
    public GameMission myMission;
    // method 32083, 0x600095c
    void Init(bool isDark, GameMission mission, System.Action<MissionSlot> onClaimPressed);
    // method 32084, 0x600095d
    void FixButton();
    // method 32085, 0x600095e
    void .ctor();
}

// TypeDefinition 4332, 0x200019d
class <>c : object {
    // field 18208, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18209, runtime offset 4, flags 0x16
    public static System.Action<string> <>9__10_3;
    // method 32096, 0x6000969
    void .cctor();
    // method 32097, 0x600096a
    void .ctor();
    // method 32098, 0x600096b
    void <OnMissionPressed>b__10_3(string successXp);
}

// TypeDefinition 4333, 0x200019e
class <>c__DisplayClass10_0 : object {
    // field 18210, runtime offset 8, flags 0x6
    public int missionIndex;
    // field 18211, runtime offset 12, flags 0x6
    public int kpReward;
    // field 18212, runtime offset 16, flags 0x6
    public int xpReward;
    // field 18213, runtime offset 20, flags 0x6
    public int customSkinReward;
    // field 18214, runtime offset 24, flags 0x6
    public MissionsPanel <>4__this;
    // field 18215, runtime offset 28, flags 0x6
    public System.Action<string> <>9__2;
    // field 18216, runtime offset 32, flags 0x6
    public System.Action<string> <>9__1;
    // method 32099, 0x600096c
    void .ctor();
    // method 32100, 0x600096d
    void <OnMissionPressed>b__0(string successMissionClaim);
    // method 32101, 0x600096e
    void <OnMissionPressed>b__1(string claimDateCall);
    // method 32102, 0x600096f
    void <OnMissionPressed>b__2(string successCoins);
}

// TypeDefinition 4334, 0x200019c
class MissionsPanel : Popup {
    // field 18202, runtime offset 68, flags 0x1
    private MissionSlot limitedTimeMissionSlot;
    // field 18203, runtime offset 72, flags 0x1
    private TMPro.TMP_Text missionsLockedTxt;
    // field 18204, runtime offset 76, flags 0x1
    private MissionSlot[] missionSlots;
    // field 18205, runtime offset 80, flags 0x1
    private MissionSlot missionSlotPrefab;
    // field 18206, runtime offset 84, flags 0x1
    private UnityEngine.RectTransform missionSlotsParent;
    // field 18207, runtime offset 88, flags 0x1
    private System.Collections.Generic.List<UnityEngine.GameObject> instantiatedObjects;
    // method 32090, 0x6000963
    void Update();
    // method 32091, 0x6000964
    void Close(System.Action onfinish);
    // method 32092, 0x6000965
    void Show();
    // method 32093, 0x6000966
    void Redraw();
    // method 32094, 0x6000967
    void OnMissionPressed(MissionSlot missionSlot);
    // method 32095, 0x6000968
    void .ctor();
}

// TypeDefinition 4335, 0x200019f
class MobileControls : UnityEngine.MonoBehaviour {
    // field 18217, runtime offset 0, flags 0x8056
    public static const int controlsVersion = 4;
    // field 18218, runtime offset 0, flags 0x16
    public static bool resetMobileButtonPositionsDueToNewVersion;
    // field 18219, runtime offset 16, flags 0x6
    public float Horizontal;
    // field 18220, runtime offset 20, flags 0x6
    public float Vertical;
    // field 18221, runtime offset 24, flags 0x6
    public UnityEngine.Vector2 deltaLook;
    // field 18222, runtime offset 32, flags 0x1
    private Joystick moveJoystick;
    // field 18223, runtime offset 36, flags 0x6
    public MobileGameButton crouchButton;
    // field 18224, runtime offset 40, flags 0x6
    public MobileGameButton shootButton;
    // field 18225, runtime offset 44, flags 0x6
    public MobileGameButton pauseButton;
    // field 18226, runtime offset 48, flags 0x6
    public MobileGameButton jumpButton;
    // field 18227, runtime offset 52, flags 0x6
    public MobileGameButton danceButton;
    // field 18228, runtime offset 56, flags 0x6
    public MobileGameButton reloadButton;
    // field 18229, runtime offset 60, flags 0x6
    public MobileGameButton weapon1Button;
    // field 18230, runtime offset 64, flags 0x6
    public MobileGameButton weapon2Button;
    // field 18231, runtime offset 68, flags 0x6
    public MobileGameButton weapon3Button;
    // field 18232, runtime offset 72, flags 0x6
    public MobileGameButton weapon4Button;
    // field 18233, runtime offset 76, flags 0x1
    private TMPro.TMP_Text[] weaponTxts;
    // field 18234, runtime offset 80, flags 0x1
    private UnityEngine.UI.Image[] weaponImages;
    // field 18235, runtime offset 84, flags 0x6
    public bool canLook;
    // field 18236, runtime offset 88, flags 0x1
    private int rightFingerId;
    // field 18237, runtime offset 92, flags 0x1
    private float halfScreenWidth;
    // field 18238, runtime offset 96, flags 0x1
    private UnityEngine.Vector2 lastDeltaTouch;
    // field 18239, runtime offset 104, flags 0x6
    public UnityEngine.Vector2 startTouchPos;
    // field 18240, runtime offset 112, flags 0x1
    private UnityEngine.Vector2 shootButtonRealDefaultPosition;
    // field 18241, runtime offset 120, flags 0x1
    private float shootButtonRealDefaultScale;
    // method 32103, 0x6000970
    void Awake();
    // method 32104, 0x6000971
    void Start();
    // method 32105, 0x6000972
    void UpdateWeaponUIs(bool hide);
    // method 32106, 0x6000973
    void SlowUpdate();
    // method 32107, 0x6000974
    void Update();
    // method 32108, 0x6000975
    void .ctor();
}

// TypeDefinition 4336, 0x20001a1
class <IenuReset>d__27 : object {
    // field 18257, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18258, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18259, runtime offset 16, flags 0x6
    public MobileGameButton <>4__this;
    // method 32124, 0x6000985
    void .ctor(int <>1__state);
    // method 32125, 0x6000986
    void System.IDisposable.Dispose();
    // method 32126, 0x6000987
    bool MoveNext();
    // method 32127, 0x6000988
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32128, 0x6000989
    void System.Collections.IEnumerator.Reset();
    // method 32129, 0x600098a
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4337, 0x20001a0
class MobileGameButton : UnityEngine.MonoBehaviour {
    // field 18242, runtime offset 0, flags 0x16
    public static bool isEditMode;
    // field 18243, runtime offset 16, flags 0x1
    private bool isFollowingTouch;
    // field 18244, runtime offset 17, flags 0x1
    private bool _toggleIsOn;
    // field 18245, runtime offset 18, flags 0x6
    public bool getKeyDown;
    // field 18246, runtime offset 19, flags 0x6
    public bool getKeyUp;
    // field 18247, runtime offset 20, flags 0x6
    public bool getKey;
    // field 18248, runtime offset 21, flags 0x1
    private bool isVisualJoystick;
    // field 18249, runtime offset 24, flags 0x1
    private UnityEngine.RectTransform joystickMoveable;
    // field 18250, runtime offset 28, flags 0x6
    public UnityEngine.Vector3 initialLocalScale;
    // field 18251, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image myImageIcon;
    // field 18252, runtime offset 44, flags 0x1
    private UnityEngine.Sprite toggleOnSprite;
    // field 18253, runtime offset 48, flags 0x1
    private UnityEngine.Sprite defaultSprite;
    // field 18254, runtime offset 52, flags 0x1
    private UnityEngine.Vector2 defaultPosition;
    // field 18255, runtime offset 60, flags 0x1
    private UnityEngine.Vector2 pointerDownPos;
    // field 18256, runtime offset 68, flags 0x1
    private UnityEngine.Vector2 pointerDragPosition;
    // method 32109, 0x6000976
    bool get_toggleIsOn();
    // method 32110, 0x6000977
    void set_toggleIsOn(bool value);
    // method 32111, 0x6000978
    void Awake();
    // method 32112, 0x6000979
    void Start();
    // method 32113, 0x600097a
    void RefreshPos();
    // method 32114, 0x600097b
    void ResetPrefs();
    // method 32115, 0x600097c
    void Update();
    // method 32116, 0x600097d
    UnityEngine.Vector2 MaxVector(UnityEngine.Vector2 inputVector);
    // method 32117, 0x600097e
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32118, 0x600097f
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32119, 0x6000980
    void IenuReset2();
    // method 32120, 0x6000981
    System.Collections.IEnumerator IenuReset();
    // method 32121, 0x6000982
    void OnDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32122, 0x6000983
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32123, 0x6000984
    void .ctor();
}

// TypeDefinition 4338, 0x20001a2
class MobileTutorialWindow : Popup {
    // method 32130, 0x600098b
    void Start();
    // method 32131, 0x600098c
    void Update();
    // method 32132, 0x600098d
    void .ctor();
}

// TypeDefinition 4339, 0x20001a3
class MobileUIElement : UnityEngine.MonoBehaviour {
    // field 18260, runtime offset 16, flags 0x1
    private UnityEngine.Vector3 initialScale;
    // field 18261, runtime offset 28, flags 0x6
    public float mobileScale;
    // field 18262, runtime offset 32, flags 0x6
    public float cgScale;
    // field 18263, runtime offset 36, flags 0x6
    public UnityEngine.Vector2 mobileSizeDelta;
    // field 18264, runtime offset 44, flags 0x6
    public bool hideForMobile;
    // method 32133, 0x600098e
    void Start();
    // method 32134, 0x600098f
    void .ctor();
}

// TypeDefinition 4340, 0x20001a4
class MuzzleFlash : UnityEngine.MonoBehaviour {
    // field 18265, runtime offset 16, flags 0x1
    private float lifeTime;
    // field 18266, runtime offset 20, flags 0x1
    private bool setRandomRotation;
    // method 32135, 0x6000990
    void Show();
    // method 32136, 0x6000991
    void Hide();
    // method 32137, 0x6000992
    void .ctor();
}

// TypeDefinition 4341, 0x20001a6
class <>c__DisplayClass17_0 : object {
    // field 18277, runtime offset 8, flags 0x6
    public MyFriendList <>4__this;
    // field 18278, runtime offset 12, flags 0x6
    public string[] requestUIDs;
    // method 32156, 0x60009a5
    void .ctor();
}

// TypeDefinition 4342, 0x20001a7
class <>c__DisplayClass17_1 : object {
    // field 18279, runtime offset 8, flags 0x6
    public int _i;
    // field 18280, runtime offset 12, flags 0x6
    public <>c__DisplayClass17_0 CS$<>8__locals1;
    // method 32157, 0x60009a6
    void .ctor();
    // method 32158, 0x60009a7
    void <OnFriendRequestsUpdate>b__0(bool accept);
}

// TypeDefinition 4343, 0x20001a5
class MyFriendList : Popup {
    // field 18267, runtime offset 0, flags 0x16
    public static bool currentPartyShared;
    // field 18268, runtime offset 68, flags 0x1
    private UnityEngine.GameObject addPanel;
    // field 18269, runtime offset 72, flags 0x1
    private UnityEngine.GameObject extraMenuFriendUI;
    // field 18270, runtime offset 76, flags 0x1
    private UnityEngine.GameObject friendAddLoadingPanel;
    // field 18271, runtime offset 80, flags 0x1
    private FriendUI[] friendRequestUIs;
    // field 18272, runtime offset 84, flags 0x1
    private UnityEngine.GameObject requestsEmptyGO;
    // field 18273, runtime offset 88, flags 0x1
    private FriendUI[] friendUIs;
    // field 18274, runtime offset 92, flags 0x1
    private UnityEngine.GameObject friendsEmptyGO;
    // field 18275, runtime offset 4, flags 0x16
    public static MyFriendList current;
    // field 18276, runtime offset 96, flags 0x1
    private FriendUI currentFriendUIAsked;
    // method 32138, 0x6000993
    void InviteDiscordCummunityToParty();
    // method 32139, 0x6000994
    void ShowAddPanel();
    // method 32140, 0x6000995
    bool IsExtraMenuActive();
    // method 32141, 0x6000996
    void SendFriendRequest(UnityEngine.UI.InputField field);
    // method 32142, 0x6000997
    bool TryGetCurrent(out MyFriendList l);
    // method 32143, 0x6000998
    void Show();
    // method 32144, 0x6000999
    void Close(System.Action onfinish);
    // method 32145, 0x600099a
    void OnFriendsUpdate(string[] friendUIDs);
    // method 32146, 0x600099b
    void OnFriendRequestsUpdate(string[] requestUIDs);
    // method 32147, 0x600099c
    void DecideRequest(string otherUID, bool accept);
    // method 32148, 0x600099d
    void ShowExtraFriendMenu(FriendUI whoAsked);
    // method 32149, 0x600099e
    void HideExtraFriendMenu();
    // method 32150, 0x600099f
    void ExtraOptions_Invite();
    // method 32151, 0x60009a0
    void ExtraOptions_Trade();
    // method 32152, 0x60009a1
    void ExtraOptions_Remove();
    // method 32153, 0x60009a2
    void ExtraOptions_ViewProfile();
    // method 32154, 0x60009a3
    void .ctor();
    // method 32155, 0x60009a4
    void <SendFriendRequest>b__7_0(string then);
}

// TypeDefinition 4344, 0x20001a9
class <>c : object {
    // field 18315, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18316, runtime offset 4, flags 0x16
    public static System.Func<<>f__AnonymousType0<Photon.Realtime.RoomInfo, float>, float> <>9__55_1;
    // field 18317, runtime offset 8, flags 0x16
    public static System.Func<<>f__AnonymousType0<Photon.Realtime.RoomInfo, float>, float> <>9__55_2;
    // field 18318, runtime offset 12, flags 0x16
    public static System.Func<<>f__AnonymousType0<Photon.Realtime.RoomInfo, float>, Photon.Realtime.RoomInfo> <>9__55_3;
    // field 18319, runtime offset 16, flags 0x16
    public static System.Func<Photon.Realtime.RoomInfo, int> <>9__55_5;
    // field 18320, runtime offset 20, flags 0x16
    public static System.Action<bool> <>9__59_0;
    // field 18321, runtime offset 24, flags 0x16
    public static System.Action <>9__82_0;
    // field 18322, runtime offset 28, flags 0x16
    public static System.Action <>9__86_0;
    // field 18323, runtime offset 32, flags 0x16
    public static System.Func<UnityEngine.Transform, float> <>9__92_0;
    // field 18324, runtime offset 36, flags 0x16
    public static System.Func<Shooter, UnityEngine.Transform> <>9__92_1;
    // field 18325, runtime offset 40, flags 0x16
    public static System.Action <>9__96_0;
    // field 18326, runtime offset 44, flags 0x16
    public static System.Action <>9__96_1;
    // method 32230, 0x60009ef
    void .cctor();
    // method 32231, 0x60009f0
    void .ctor();
    // method 32232, 0x60009f1
    float <OnRoomListUpdate>b__55_1(<>f__AnonymousType0<Photon.Realtime.RoomInfo, float> item);
    // method 32233, 0x60009f2
    float <OnRoomListUpdate>b__55_2(<>f__AnonymousType0<Photon.Realtime.RoomInfo, float> _);
    // method 32234, 0x60009f3
    Photon.Realtime.RoomInfo <OnRoomListUpdate>b__55_3(<>f__AnonymousType0<Photon.Realtime.RoomInfo, float> item);
    // method 32235, 0x60009f4
    int <OnRoomListUpdate>b__55_5(Photon.Realtime.RoomInfo room);
    // method 32236, 0x60009f5
    void <OnRoomPropertiesUpdate>b__59_0(bool result);
    // method 32237, 0x60009f6
    void <OnConnectedToMaster>b__82_0();
    // method 32238, 0x60009f7
    void <OnGameSceneLoad>b__86_0();
    // method 32239, 0x60009f8
    float <GetSpawnPositionFarFromPlayers>b__92_0(UnityEngine.Transform x);
    // method 32240, 0x60009f9
    UnityEngine.Transform <GetSpawnPositionFarFromPlayers>b__92_1(Shooter a);
    // method 32241, 0x60009fa
    void <OnDisconnected>b__96_0();
    // method 32242, 0x60009fb
    void <OnDisconnected>b__96_1();
}

// TypeDefinition 4345, 0x20001aa
class <>c__DisplayClass25_0 : object {
    // field 18327, runtime offset 8, flags 0x6
    public int id;
    // method 32243, 0x60009fc
    void .ctor();
    // method 32244, 0x60009fd
    bool <GetGameMode>b__0(GameMode mode);
}

// TypeDefinition 4346, 0x20001ab
class <>c__DisplayClass26_0 : object {
    // field 18328, runtime offset 8, flags 0x6
    public int id;
    // method 32245, 0x60009fe
    void .ctor();
    // method 32246, 0x60009ff
    bool <SetCurrentGameMode>b__0(GameMode mode);
}

// TypeDefinition 4347, 0x20001ac
class <>c__DisplayClass27_0 : object {
    // field 18329, runtime offset 8, flags 0x6
    public string gameModeName;
    // method 32247, 0x6000a00
    void .ctor();
    // method 32248, 0x6000a01
    bool <SetCurrentGameMode>b__0(GameMode mode);
}

// TypeDefinition 4348, 0x20001ad
class <>c__DisplayClass50_0 : object {
    // field 18330, runtime offset 8, flags 0x6
    public string message;
    // method 32249, 0x6000a02
    void .ctor();
    // method 32250, 0x6000a03
    void <OnCreateRoomFailed>b__0();
}

// TypeDefinition 4349, 0x20001ae
class <>c__DisplayClass55_0 : object {
    // field 18331, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomInfo bestRoom;
    // field 18332, runtime offset 12, flags 0x6
    public int mapIndex;
    // field 18333, runtime offset 16, flags 0x6
    public NetworkManager <>4__this;
    // method 32251, 0x6000a04
    void .ctor();
    // method 32252, 0x6000a05
    void <OnRoomListUpdate>b__4(string mapNameReady);
}

// TypeDefinition 4350, 0x20001af
class <>c__DisplayClass55_1 : object {
    // field 18334, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomInfo mostPopulatedRoom;
    // method 32253, 0x6000a06
    void .ctor();
    // method 32254, 0x6000a07
    void <OnRoomListUpdate>b__6(string mapNameReady);
}

// TypeDefinition 4351, 0x20001b0
class <>c__DisplayClass69_0 : object {
    // field 18335, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomOptions ops;
    // method 32255, 0x6000a08
    void .ctor();
    // method 32256, 0x6000a09
    void <OnJoinRandomFailed>b__0(string mapNameReady);
}

// TypeDefinition 4352, 0x20001b1
class <>c__DisplayClass69_1 : object {
    // field 18336, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomOptions ops;
    // method 32257, 0x6000a0a
    void .ctor();
    // method 32258, 0x6000a0b
    void <OnJoinRandomFailed>b__1(string mapNameReady);
}

// TypeDefinition 4353, 0x20001b2
class <>c__DisplayClass71_0 : object {
    // field 18337, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomOptions ops;
    // method 32259, 0x6000a0c
    void .ctor();
    // method 32260, 0x6000a0d
    void <OnJoinRoomFailed>b__2(string mapNameReady);
}

// TypeDefinition 4354, 0x20001b3
class <>c__DisplayClass78_0 : object {
    // field 18338, runtime offset 8, flags 0x6
    public string lobbyId;
    // field 18339, runtime offset 12, flags 0x6
    public NetworkManager <>4__this;
    // field 18340, runtime offset 16, flags 0x6
    public DG.Tweening.TweenCallback <>9__1;
    // method 32261, 0x6000a0e
    void .ctor();
    // method 32262, 0x6000a0f
    void <JoinParty>b__0();
    // method 32263, 0x6000a10
    void <JoinParty>b__1();
}

// TypeDefinition 4355, 0x20001b4
class <>c__DisplayClass92_0 : object {
    // field 18341, runtime offset 8, flags 0x6
    public UnityEngine.Transform spawnPoint;
    // method 32264, 0x6000a11
    void .ctor();
    // method 32265, 0x6000a12
    float <GetSpawnPositionFarFromPlayers>b__2(UnityEngine.Transform player);
}

// TypeDefinition 4356, 0x20001b5
class <>c__DisplayClass96_0 : object {
    // field 18342, runtime offset 8, flags 0x6
    public Photon.Realtime.DisconnectCause cause;
    // field 18343, runtime offset 12, flags 0x6
    public NetworkManager <>4__this;
    // method 32266, 0x6000a13
    void .ctor();
    // method 32267, 0x6000a14
    void <OnDisconnected>b__2();
    // method 32268, 0x6000a15
    void <OnDisconnected>b__3();
    // method 32269, 0x6000a16
    void <OnDisconnected>b__4();
    // method 32270, 0x6000a17
    void <OnDisconnected>b__5();
}

// TypeDefinition 4357, 0x20001a8
class NetworkManager : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 18281, runtime offset 0, flags 0x16
    public static UnityEngine.Vector3 overrideSpawnPoint;
    // field 18282, runtime offset 12, flags 0x16
    public static UnityEngine.Quaternion overrideSpawnRot;
    // field 18283, runtime offset 28, flags 0x16
    public static Photon.Realtime.TypedLobby staticSqlLobby;
    // field 18284, runtime offset 0, flags 0x8056
    public static const string GUEST_NAME = "Guest";
    // field 18285, runtime offset 32, flags 0x16
    public static string preloadedMap;
    // field 18286, runtime offset 36, flags 0x36
    public static int[] ALL_MAPS_FOR_PUBS;
    // field 18287, runtime offset 40, flags 0x36
    public static int[] ALL_MAPS;
    // field 18288, runtime offset 0, flags 0x8056
    public static const int KOUR_MOBILE_MAP = 3;
    // field 18289, runtime offset 0, flags 0x8056
    public static const int KOURSTRIKE_MOBILE_MAP = 8;
    // field 18290, runtime offset 0, flags 0x8056
    public static const int KOURZONE_MOBILE_MAP = 10;
    // field 18291, runtime offset 44, flags 0x11
    private static System.Action<string> OnConnectedToMasterServer;
    // field 18292, runtime offset 20, flags 0x6
    public GameMode currentGameMode;
    // field 18293, runtime offset 24, flags 0x6
    public GameMode[] gameModes;
    // field 18294, runtime offset 48, flags 0x11
    private static string urlRoomNameRequest;
    // field 18295, runtime offset 52, flags 0x16
    public static string urlRegionRequest;
    // field 18296, runtime offset 28, flags 0x1
    private int[] selectedWeaponIndexes;
    // field 18297, runtime offset 32, flags 0x1
    private UnityEngine.GameObject myPlayer;
    // field 18298, runtime offset 56, flags 0x16
    public static NetworkManager instance;
    // field 18299, runtime offset 36, flags 0x6
    public string joinRoomNameOnConnect;
    // field 18300, runtime offset 40, flags 0x1
    private bool isJoinRandomRoom;
    // field 18301, runtime offset 60, flags 0x16
    public static bool isJoinCustomGame;
    // field 18302, runtime offset 64, flags 0x16
    public static float lastMapChangeTime;
    // field 18303, runtime offset 0, flags 0x8056
    public static const string GAME_MODE_KEY = "C0";
    // field 18304, runtime offset 0, flags 0x8056
    public static const string MAP_KEY = "C1";
    // field 18305, runtime offset 0, flags 0x8056
    public static const string MATCH_TIME_KEY = "C2";
    // field 18306, runtime offset 0, flags 0x8056
    public static const string CUSTOM_MAP_ID_KEY = "C3";
    // field 18307, runtime offset 0, flags 0x8056
    public static const string CUSTOM_MAP_ID_KEY_FOR_INROOM = "C4";
    // field 18308, runtime offset 41, flags 0x6
    public bool isLookingForMatch;
    // field 18309, runtime offset 68, flags 0x16
    public static string inviteUidOnPartyJoined;
    // field 18310, runtime offset 44, flags 0x6
    public ExitGames.Client.Photon.Hashtable propertiesOnFailedJoinRandom;
    // field 18311, runtime offset 48, flags 0x1
    private System.Collections.Generic.Dictionary<int, double> spawnPointUsageTimes;
    // field 18312, runtime offset 0, flags 0x8051
    private static const double SpawnReuseCooldown = 3.5;
    // field 18313, runtime offset 72, flags 0x16
    public static bool isReconnecting;
    // field 18314, runtime offset 76, flags 0x16
    public static string tempRegion;
    // method 32159, 0x60009a8
    string getRegion();
    // method 32160, 0x60009a9
    int GetMaxTimer();
    // method 32161, 0x60009aa
    GameMode GetRandomGameMode();
    // method 32162, 0x60009ab
    int get_MOBILE_MAP();
    // method 32163, 0x60009ac
    int[] get_AUTOPLAY_MAPS();
    // method 32164, 0x60009ad
    void add_OnConnectedToMasterServer(System.Action<string> value);
    // method 32165, 0x60009ae
    void remove_OnConnectedToMasterServer(System.Action<string> value);
    // method 32166, 0x60009af
    GameMode GetGameModeFromIndex(int i);
    // method 32167, 0x60009b0
    GameMode GetRoomGameMode();
    // method 32168, 0x60009b1
    int GetRoomMapBuildIndex();
    // method 32169, 0x60009b2
    GameMode GetGameMode(int id);
    // method 32170, 0x60009b3
    void SetCurrentGameMode(int id, out GameMode gameMode);
    // method 32171, 0x60009b4
    void SetCurrentGameMode(string gameModeName, out GameMode gameMode);
    // method 32172, 0x60009b5
    void SetCurrentGameMode(GameMode gameMode);
    // method 32173, 0x60009b6
    void SetURLRoomNameRequest(string to);
    // method 32174, 0x60009b7
    string GetURLRoomNameRequest(string debugFrom);
    // method 32175, 0x60009b8
    void OnOtherPlayerDied(Shooter killer, int whoID);
    // method 32176, 0x60009b9
    Health GetMyPlayerHealth(out int viewId);
    // method 32177, 0x60009ba
    bool TryGetMyPlayer(out UnityEngine.GameObject _myPlayer);
    // method 32178, 0x60009bb
    void OnGameplayWeaponClassChanged(int newClass);
    // method 32179, 0x60009bc
    void OnLeftRoom();
    // method 32180, 0x60009bd
    void Awake();
    // method 32181, 0x60009be
    void OnGameEnded(bool willKillPlayer, out int teamIndex);
    // method 32182, 0x60009bf
    void OneTimeAwake();
    // method 32183, 0x60009c0
    bool NewConnectUsingSettings();
    // method 32184, 0x60009c1
    void Start();
    // method 32185, 0x60009c2
    void SetMyPlayerPropertiesForParty();
    // method 32186, 0x60009c3
    void PlayCustomJoin(string roomName, out bool canPlay);
    // method 32187, 0x60009c4
    bool CreateCustom(string rName, int maxPlayers, bool isPrivate, ExitGames.Client.Photon.Hashtable hash);
    // method 32188, 0x60009c5
    void OnCreateRoomFailed(short returnCode, string message);
    // method 32189, 0x60009c6
    string GetSqlLobbyFilter(ExitGames.Client.Photon.Hashtable expectedProperties);
    // method 32190, 0x60009c7
    void PlayPressed(out bool canPlay);
    // method 32191, 0x60009c8
    void ResetIsJoinRandomRoom();
    // method 32192, 0x60009c9
    void OnRoomListUpdate(System.Collections.Generic.List<Photon.Realtime.RoomInfo> roomList);
    // method 32193, 0x60009ca
    float GetRoomScore(Photon.Realtime.RoomInfo room);
    // method 32194, 0x60009cb
    void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 32195, 0x60009cc
    ExitGames.Client.Photon.Hashtable GetMatchmakingFilter();
    // method 32196, 0x60009cd
    Photon.Realtime.RoomOptions GetRoomOptions(bool isPrivate, ExitGames.Client.Photon.Hashtable hashtable, int overrideMaxPlayers);
    // method 32197, 0x60009ce
    void SetURL(string add);
    // method 32198, 0x60009cf
    string GetParameter(string key);
    // method 32199, 0x60009d0
    void OnJoinRandomFailed(short returnCode, string message);
    // method 32200, 0x60009d1
    void OnJoinRoomFailed(short returnCode, string message);
    // method 32201, 0x60009d2
    bool get_CurrentRoomIsParty();
    // method 32202, 0x60009d3
    string get_CurrentPartyLeaderId();
    // method 32203, 0x60009d4
    string OpenParty(string inviteUid);
    // method 32204, 0x60009d5
    void JoinParty(string lobbyId);
    // method 32205, 0x60009d6
    void LeaveParty();
    // method 32206, 0x60009d7
    void OnJoinedRoom();
    // method 32207, 0x60009d8
    void OnConnectedToMaster();
    // method 32208, 0x60009d9
    void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer);
    // method 32209, 0x60009da
    string GetUrlParam(string paramName);
    // method 32210, 0x60009db
    void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer);
    // method 32211, 0x60009dc
    void OnGameSceneLoad(bool canSpawnPlayer);
    // method 32212, 0x60009dd
    void SpawnSpectateCamera();
    // method 32213, 0x60009de
    void SpawnPlayer(UnityEngine.Vector3 atSpawnPoint, UnityEngine.Quaternion rot, bool justSwitchedTeams);
    // method 32214, 0x60009df
    void SpawnPlayer();
    // method 32215, 0x60009e0
    UnityEngine.Vector3 GetSpawnPositionFarFromPlayers(out UnityEngine.Quaternion rot, bool justSwitchedTeams, Photon.Pun.UtilityScripts.PhotonTeam team);
    // method 32216, 0x60009e1
    void OnDisconnectedSimulate(bool forceShowReconnectDialog, Photon.Realtime.ServerConnection expectedServerConnection);
    // method 32217, 0x60009e2
    void OnDisconnected(Photon.Realtime.DisconnectCause cause);
    // method 32218, 0x60009e3
    bool IsInternetAvailable();
    // method 32219, 0x60009e4
    void Reconnect();
    // method 32220, 0x60009e5
    void ConnectAgain();
    // method 32221, 0x60009e6
    void Respawn();
    // method 32222, 0x60009e7
    string GenerateRoomName(int length, bool numbersOnly);
    // method 32223, 0x60009e8
    void .ctor();
    // method 32224, 0x60009e9
    void .cctor();
    // method 32225, 0x60009ea
    <>f__AnonymousType0<Photon.Realtime.RoomInfo, float> <OnRoomListUpdate>b__55_0(Photon.Realtime.RoomInfo room);
    // method 32226, 0x60009eb
    void <OnJoinRoomFailed>b__71_0();
    // method 32227, 0x60009ec
    void <OnJoinRoomFailed>b__71_1();
    // method 32228, 0x60009ed
    void <OnDisconnectedSimulate>b__95_0();
    // method 32229, 0x60009ee
    void <OnDisconnectedSimulate>b__95_1();
}

// TypeDefinition 4358, 0x20001b6
class DebugNew : object {
    // field 18344, runtime offset 0, flags 0x16
    public static bool debugOverrideEnable;
    // method 32271, 0x6000a18
    void Log(string message);
    // method 32272, 0x6000a19
    void LogError(string message);
    // method 32273, 0x6000a1a
    void LogWarning(string message);
    // method 32274, 0x6000a1b
    void LogFormat(string v, object[] args);
}

// TypeDefinition 4359, 0x20001b7
class NewEncryptor : UnityEngine.MonoBehaviour {
    // field 18345, runtime offset 0, flags 0x31
    private static System.Text.Encoding encoding;
    // method 32275, 0x6000a1c
    string Encrypt(string text, string password);
    // method 32276, 0x6000a1d
    string Decrypt(string encryptedText, string password);
    // method 32277, 0x6000a1e
    System.Tuple<byte[], byte[]> GetAesKeyAndIV(string password, System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm);
    // method 32278, 0x6000a1f
    void .ctor();
    // method 32279, 0x6000a20
    void .cctor();
}

// TypeDefinition 4360, 0x20001b9
class ActionName : System.Enum {
    // field 18352, runtime offset 8, flags 0x606
    public int value__;
    // field 18353, runtime offset 0, flags 0x8056
    public static const ActionName Any = 0;
    // field 18354, runtime offset 0, flags 0x8056
    public static const ActionName Movement = 1;
    // field 18355, runtime offset 0, flags 0x8056
    public static const ActionName Interact = 2;
    // field 18356, runtime offset 0, flags 0x8056
    public static const ActionName MouseScroll = 3;
    // field 18357, runtime offset 0, flags 0x8056
    public static const ActionName SendMessage = 4;
    // field 18358, runtime offset 0, flags 0x8056
    public static const ActionName Look = 5;
    // field 18359, runtime offset 0, flags 0x8056
    public static const ActionName Jump = 6;
    // field 18360, runtime offset 0, flags 0x8056
    public static const ActionName Respawn = 7;
    // field 18361, runtime offset 0, flags 0x8056
    public static const ActionName Fire = 8;
    // field 18362, runtime offset 0, flags 0x8056
    public static const ActionName Aim = 9;
    // field 18363, runtime offset 0, flags 0x8056
    public static const ActionName Reload = 10;
    // field 18364, runtime offset 0, flags 0x8056
    public static const ActionName Run = 11;
    // field 18365, runtime offset 0, flags 0x8056
    public static const ActionName Inspect = 12;
    // field 18366, runtime offset 0, flags 0x8056
    public static const ActionName Crouch = 13;
    // field 18367, runtime offset 0, flags 0x8056
    public static const ActionName InventoryNext = 14;
    // field 18368, runtime offset 0, flags 0x8056
    public static const ActionName FirstWeapon = 15;
    // field 18369, runtime offset 0, flags 0x8056
    public static const ActionName SecondWeapon = 16;
    // field 18370, runtime offset 0, flags 0x8056
    public static const ActionName ThirdWeapon = 17;
    // field 18371, runtime offset 0, flags 0x8056
    public static const ActionName FourthWeapon = 18;
    // field 18372, runtime offset 0, flags 0x8056
    public static const ActionName ShowLeaderboard = 19;
    // field 18373, runtime offset 0, flags 0x8056
    public static const ActionName OpenKourzoneInventory = 20;
    // field 18374, runtime offset 0, flags 0x8056
    public static const ActionName Emote = 21;
    // field 18375, runtime offset 0, flags 0x8056
    public static const ActionName Escape = 22;
    // field 18376, runtime offset 0, flags 0x8056
    public static const ActionName Play = 23;
    // field 18377, runtime offset 0, flags 0x8056
    public static const ActionName CancelMatchmaking = 24;
    // field 18378, runtime offset 0, flags 0x8056
    public static const ActionName SwitchTeam = 25;
    // field 18379, runtime offset 0, flags 0x8056
    public static const ActionName OpenBuyMenu = 26;
    // field 18380, runtime offset 0, flags 0x8056
    public static const ActionName Dash = 27;
    // field 18381, runtime offset 0, flags 0x8056
    public static const ActionName ShowConsole = 28;
    // field 18382, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect1 = 29;
    // field 18383, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect2 = 30;
    // field 18384, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect3 = 31;
    // field 18385, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect4 = 32;
    // field 18386, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect5 = 33;
    // field 18387, runtime offset 0, flags 0x8056
    public static const ActionName BuyMenuSelect6 = 34;
    // field 18388, runtime offset 0, flags 0x8056
    public static const ActionName UpDownAxis = 35;
    // field 18389, runtime offset 0, flags 0x8056
    public static const ActionName SpectateToggleUI = 36;
}

// TypeDefinition 4361, 0x20001ba
class <>c : object {
    // field 18390, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18391, runtime offset 4, flags 0x16
    public static System.Action<CallbackContext> <>9__12_0;
    // method 32295, 0x6000a30
    void .cctor();
    // method 32296, 0x6000a31
    void .ctor();
    // method 32297, 0x6000a32
    void <InitializeActionMap>b__12_0(CallbackContext x);
}

// TypeDefinition 4362, 0x20001b8
class NewInputManager : UnityEngine.MonoBehaviour {
    // field 18346, runtime offset 0, flags 0x16
    public static NewInputManager instance;
    // field 18347, runtime offset 16, flags 0x1
    private UnityEngine.InputSystem.InputActionAsset playerInput;
    // field 18348, runtime offset 20, flags 0x1
    private System.Collections.Generic.Dictionary<string, string> actionNameOverrides;
    // field 18349, runtime offset 24, flags 0x1
    private string[] actionNameBlacklist;
    // field 18350, runtime offset 0, flags 0x8051
    private static const string actionMapName = "Player";
    // field 18351, runtime offset 28, flags 0x1
    private System.Collections.Generic.Dictionary<ActionName, UnityEngine.InputSystem.InputAction> actionMap;
    // method 32280, 0x6000a21
    UnityEngine.InputSystem.InputActionAsset GetPlayerInput();
    // method 32281, 0x6000a22
    bool CanEditBindingForAction(string actionName);
    // method 32282, 0x6000a23
    string GetActionDisplayName(string actionName);
    // method 32283, 0x6000a24
    void Awake();
    // method 32284, 0x6000a25
    void Update();
    // method 32285, 0x6000a26
    void InitializeActionMap();
    // method 32286, 0x6000a27
    UnityEngine.InputSystem.InputAction GetActionFor(ActionName name);
    // method 32287, 0x6000a28
    void OnEnable();
    // method 32288, 0x6000a29
    void OnDisable();
    // method 32289, 0x6000a2a
    bool GetKeyDown(ActionName actionName);
    // method 32290, 0x6000a2b
    bool GetKey(ActionName actionName);
    // method 32291, 0x6000a2c
    bool GetKeyUp(ActionName actionName);
    // method 32292, 0x6000a2d
    UnityEngine.Vector2 GetAxis(ActionName actionName);
    // method 32293, 0x6000a2e
    bool IsActionPressed(ActionName actionName, UnityEngine.InputSystem.InputActionPhase phase);
    // method 32294, 0x6000a2f
    void .ctor();
}

// TypeDefinition 4363, 0x20001bc
class <>c__DisplayClass4_0`1 : object {
    // field 18396, runtime offset 0, flags 0x6
    public System.Action<T_1024> onPressed;
    // method 32301, 0x6000a36
    void .ctor();
    // method 32302, 0x6000a37
    void <Init>b__0(object obj);
}

// TypeDefinition 4364, 0x20001bb
class NewMapObjectButton : UnityEngine.MonoBehaviour {
    // field 18392, runtime offset 16, flags 0x1
    private TMPro.TMP_Text objNameTxt;
    // field 18393, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image image;
    // field 18394, runtime offset 24, flags 0x1
    private object myMapObjectPrefab;
    // field 18395, runtime offset 28, flags 0x1
    private System.Action<object> myOnPressed;
    // method 32298, 0x6000a33
    void Init(int knownIndex, M_1023 with, System.Action<M_1023> onPressed);
    // method 32299, 0x6000a34
    void OnPressed();
    // method 32300, 0x6000a35
    void .ctor();
}

// TypeDefinition 4365, 0x20001be
class <DownloadThumbnail>d__10 : object {
    // field 18400, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18401, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18402, runtime offset 16, flags 0x6
    public string url;
    // field 18403, runtime offset 20, flags 0x6
    public NewsPanel <>4__this;
    // field 18404, runtime offset 24, flags 0x6
    public string description;
    // field 18405, runtime offset 28, flags 0x6
    public string title;
    // field 18406, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 32313, 0x6000a42
    void .ctor(int <>1__state);
    // method 32314, 0x6000a43
    void System.IDisposable.Dispose();
    // method 32315, 0x6000a44
    bool MoveNext();
    // method 32316, 0x6000a45
    void <>m__Finally1();
    // method 32317, 0x6000a46
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32318, 0x6000a47
    void System.Collections.IEnumerator.Reset();
    // method 32319, 0x6000a48
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4366, 0x20001bf
class <FetchInstagramMetadata>d__5 : object {
    // field 18407, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18408, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18409, runtime offset 16, flags 0x6
    public string url;
    // field 18410, runtime offset 20, flags 0x6
    public NewsPanel <>4__this;
    // field 18411, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 32320, 0x6000a49
    void .ctor(int <>1__state);
    // method 32321, 0x6000a4a
    void System.IDisposable.Dispose();
    // method 32322, 0x6000a4b
    bool MoveNext();
    // method 32323, 0x6000a4c
    void <>m__Finally1();
    // method 32324, 0x6000a4d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32325, 0x6000a4e
    void System.Collections.IEnumerator.Reset();
    // method 32326, 0x6000a4f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4367, 0x20001c0
class <FetchMetadata>d__4 : object {
    // field 18412, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18413, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18414, runtime offset 16, flags 0x6
    public NewsPanel <>4__this;
    // field 18415, runtime offset 20, flags 0x1
    private Enumerator<string> <>7__wrap1;
    // method 32327, 0x6000a50
    void .ctor(int <>1__state);
    // method 32328, 0x6000a51
    void System.IDisposable.Dispose();
    // method 32329, 0x6000a52
    bool MoveNext();
    // method 32330, 0x6000a53
    void <>m__Finally1();
    // method 32331, 0x6000a54
    void <>m__Finally2();
    // method 32332, 0x6000a55
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32333, 0x6000a56
    void System.Collections.IEnumerator.Reset();
    // method 32334, 0x6000a57
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4368, 0x20001c1
class <FetchTikTokMetadata>d__8 : object {
    // field 18416, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18417, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18418, runtime offset 16, flags 0x6
    public string url;
    // field 18419, runtime offset 20, flags 0x6
    public NewsPanel <>4__this;
    // field 18420, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 32335, 0x6000a58
    void .ctor(int <>1__state);
    // method 32336, 0x6000a59
    void System.IDisposable.Dispose();
    // method 32337, 0x6000a5a
    bool MoveNext();
    // method 32338, 0x6000a5b
    void <>m__Finally1();
    // method 32339, 0x6000a5c
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32340, 0x6000a5d
    void System.Collections.IEnumerator.Reset();
    // method 32341, 0x6000a5e
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4369, 0x20001bd
class NewsPanel : Popup {
    // field 18397, runtime offset 68, flags 0x1
    private System.Collections.Generic.List<string> instagramLinks;
    // field 18398, runtime offset 72, flags 0x1
    private System.Collections.Generic.List<string> tiktokLinks;
    // field 18399, runtime offset 76, flags 0x1
    private System.Collections.Generic.List<SocialPost> socialPosts;
    // method 32303, 0x6000a38
    void Show();
    // method 32304, 0x6000a39
    System.Collections.IEnumerator FetchMetadata();
    // method 32305, 0x6000a3a
    System.Collections.IEnumerator FetchInstagramMetadata(string url);
    // method 32306, 0x6000a3b
    string ExtractJsonFromHtml(string html);
    // method 32307, 0x6000a3c
    void ProcessInstagramResponse(string json);
    // method 32308, 0x6000a3d
    System.Collections.IEnumerator FetchTikTokMetadata(string url);
    // method 32309, 0x6000a3e
    void ProcessTikTokResponse(string html);
    // method 32310, 0x6000a3f
    System.Collections.IEnumerator DownloadThumbnail(string url, string description, string title);
    // method 32311, 0x6000a40
    void OpenURL(string x);
    // method 32312, 0x6000a41
    void .ctor();
}

// TypeDefinition 4370, 0x20001c2
class SocialPost : object {
    // field 18421, runtime offset 8, flags 0x1
    private UnityEngine.Texture2D <Thumbnail>k__BackingField;
    // field 18422, runtime offset 12, flags 0x1
    private string <Title>k__BackingField;
    // field 18423, runtime offset 16, flags 0x1
    private string <Description>k__BackingField;
    // method 32342, 0x6000a5f
    UnityEngine.Texture2D get_Thumbnail();
    // method 32343, 0x6000a60
    void set_Thumbnail(UnityEngine.Texture2D value);
    // method 32344, 0x6000a61
    string get_Title();
    // method 32345, 0x6000a62
    void set_Title(string value);
    // method 32346, 0x6000a63
    string get_Description();
    // method 32347, 0x6000a64
    void set_Description(string value);
    // method 32348, 0x6000a65
    void .ctor();
}

// TypeDefinition 4371, 0x20001c3
class NotificationContainer : UnityEngine.MonoBehaviour {
    // field 18424, runtime offset 16, flags 0x1
    private TMPro.TMP_Text messageTxt;
    // field 18425, runtime offset 20, flags 0x1
    private UnityEngine.GameObject errorImage;
    // field 18426, runtime offset 24, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 18427, runtime offset 28, flags 0x6
    public UnityEngine.Coroutine hideIenu;
    // method 32349, 0x6000a66
    void Show(bool isError, string message);
    // method 32350, 0x6000a67
    void Hide();
    // method 32351, 0x6000a68
    void .ctor();
    // method 32352, 0x6000a69
    void <Hide>b__5_0();
}

// TypeDefinition 4372, 0x20001c4
class OnKilledUI : UnityEngine.MonoBehaviour {
    // field 18428, runtime offset 16, flags 0x1
    private TMPro.TMP_Text scoreTxt;
    // field 18429, runtime offset 20, flags 0x1
    private TMPro.TMP_Text specialMessageTxt;
    // method 32353, 0x6000a6a
    void Show(int score, string specialMessage);
    // method 32354, 0x6000a6b
    void .ctor();
}

// TypeDefinition 4373, 0x20001c5
class OnOffToggle : UnityEngine.MonoBehaviour {
    // field 18430, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image handleImage;
    // field 18431, runtime offset 20, flags 0x1
    private UnityEngine.Sprite onBackgroundSprite;
    // field 18432, runtime offset 24, flags 0x1
    private UnityEngine.Sprite offBackgroundSprite;
    // field 18433, runtime offset 28, flags 0x1
    private UnityEngine.Sprite onHandleSprite;
    // field 18434, runtime offset 32, flags 0x1
    private UnityEngine.Sprite offHandleSprite;
    // field 18435, runtime offset 36, flags 0x1
    private UnityEngine.UI.Toggle toggle;
    // field 18436, runtime offset 40, flags 0x6
    public bool removeAllListeners;
    // method 32355, 0x6000a6c
    void Start();
    // method 32356, 0x6000a6d
    void OnClicked(bool isOn);
    // method 32357, 0x6000a6e
    void .ctor();
}

// TypeDefinition 4374, 0x20001c6
class OptionsMenu : UnityEngine.MonoBehaviour {
    // field 18437, runtime offset 16, flags 0x1
    private UnityEngine.GameObject filePanel;
    // field 18438, runtime offset 20, flags 0x1
    private UnityEngine.GameObject navigationPanel;
    // field 18439, runtime offset 24, flags 0x1
    private UnityEngine.GameObject helpPanel;
    // field 18440, runtime offset 28, flags 0x1
    private UnityEngine.GameObject publishPanel;
    // method 32358, 0x6000a6f
    void TogglePublish();
    // method 32359, 0x6000a70
    void ToggleFile();
    // method 32360, 0x6000a71
    void ToggleNavigation();
    // method 32361, 0x6000a72
    void ToggleHelp();
    // method 32362, 0x6000a73
    void Close();
    // method 32363, 0x6000a74
    void .ctor();
}

// TypeDefinition 4375, 0x20001c7
class ParticleSystemExtension : UnityEngine.MonoBehaviour {
    // field 18441, runtime offset 16, flags 0x1
    private UnityEngine.ParticleSystem myParticleSystem;
    // field 18442, runtime offset 20, flags 0x1
    private bool _isPlaying;
    // method 32364, 0x6000a75
    bool get_isPlaying();
    // method 32365, 0x6000a76
    void set_isPlaying(bool value);
    // method 32366, 0x6000a77
    void Awake();
    // method 32367, 0x6000a78
    void Start();
    // method 32368, 0x6000a79
    void .ctor();
}

// TypeDefinition 4376, 0x20001c8
class PartyPlayer : UnityEngine.MonoBehaviour {
    // field 18443, runtime offset 16, flags 0x1
    private UnityEngine.Camera lobbyRendererCamera;
    // method 32369, 0x6000a7a
    void Init(float cameraSize, UnityEngine.Vector3 localCameraPos);
    // method 32370, 0x6000a7b
    void .ctor();
}

// TypeDefinition 4377, 0x20001c9
class PasswordEye : UnityEngine.MonoBehaviour {
    // field 18444, runtime offset 16, flags 0x1
    private bool isHiding;
    // field 18445, runtime offset 20, flags 0x1
    private UnityEngine.GameObject eyeOn;
    // field 18446, runtime offset 24, flags 0x1
    private UnityEngine.GameObject eyeOff;
    // field 18447, runtime offset 28, flags 0x1
    private UnityEngine.UI.InputField relateToIf;
    // method 32371, 0x6000a7c
    void OnEnable();
    // method 32372, 0x6000a7d
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32373, 0x6000a7e
    void RefreshUI();
    // method 32374, 0x6000a7f
    void .ctor();
}

// TypeDefinition 4378, 0x20001ca
class PfpSelectPanel : Popup {
    // field 18448, runtime offset 68, flags 0x1
    private ProfilePictures profilePictures;
    // field 18449, runtime offset 72, flags 0x1
    private UnityEngine.GameObject[] locks;
    // field 18450, runtime offset 76, flags 0x1
    private UnityEngine.GameObject[] panels;
    // field 18451, runtime offset 80, flags 0x1
    private UnityEngine.UI.Button[] topButtons;
    // field 18452, runtime offset 84, flags 0x1
    private UnityEngine.UI.Image[] backgroundImages;
    // field 18453, runtime offset 88, flags 0x1
    private UnityEngine.UI.Image[] pfpImages;
    // field 18454, runtime offset 92, flags 0x1
    private UnityEngine.UI.Image[] backgroundSlots;
    // field 18455, runtime offset 96, flags 0x6
    public System.Action<int, int> onSelectedProfilePfp;
    // method 32375, 0x6000a80
    void Show();
    // method 32376, 0x6000a81
    void SelectBackground(int backgroundIndex);
    // method 32377, 0x6000a82
    void SelectProfilePicture(int profilePictureIndex);
    // method 32378, 0x6000a83
    int GetLevel(WeaponClass myWeaponClass, int myWeaponClassIndex);
    // method 32379, 0x6000a84
    void .ctor();
}

// TypeDefinition 4379, 0x20001cc
class <>c__DisplayClass19_0 : object {
    // field 18471, runtime offset 8, flags 0x6
    public PickableWeapon <>4__this;
    // field 18472, runtime offset 12, flags 0x6
    public Shooter shooter;
    // field 18473, runtime offset 16, flags 0x6
    public float duration;
    // method 32390, 0x6000a8f
    void .ctor();
    // method 32391, 0x6000a90
    void <TryPick>b__1();
}

// TypeDefinition 4380, 0x20001cd
class <>c__DisplayClass19_1 : object {
    // field 18474, runtime offset 8, flags 0x6
    public UnityEngine.Vector3 startPosition;
    // field 18475, runtime offset 20, flags 0x6
    public UnityEngine.Quaternion startRotation;
    // field 18476, runtime offset 36, flags 0x6
    public <>c__DisplayClass19_0 CS$<>8__locals1;
    // method 32392, 0x6000a91
    void .ctor();
    // method 32393, 0x6000a92
    void <TryPick>b__0(float value);
}

// TypeDefinition 4381, 0x20001ce
class <>c__DisplayClass19_2 : object {
    // field 18477, runtime offset 8, flags 0x6
    public UnityEngine.Vector3 startPosition;
    // field 18478, runtime offset 20, flags 0x6
    public UnityEngine.Quaternion startRotation;
    // field 18479, runtime offset 36, flags 0x6
    public <>c__DisplayClass19_0 CS$<>8__locals2;
    // field 18480, runtime offset 40, flags 0x6
    public DG.Tweening.TweenCallback<float> <>9__4;
    // method 32394, 0x6000a93
    void .ctor();
    // method 32395, 0x6000a94
    void <TryPick>b__2(float value);
    // method 32396, 0x6000a95
    void <TryPick>b__3();
    // method 32397, 0x6000a96
    void <TryPick>b__4(float value);
}

// TypeDefinition 4382, 0x20001cb
class PickableWeapon : UnityEngine.MonoBehaviour {
    // field 18456, runtime offset 0, flags 0x11
    private static float lastPickTime;
    // field 18457, runtime offset 16, flags 0x6
    public int id;
    // field 18458, runtime offset 0, flags 0x8051
    private static const byte pickEventCode = 7;
    // field 18459, runtime offset 4, flags 0x16
    public static PickableWeapon current;
    // field 18460, runtime offset 20, flags 0x1
    private UnityEngine.GameObject myCanvas;
    // field 18461, runtime offset 24, flags 0x1
    private UnityEngine.SpriteRenderer toColor;
    // field 18462, runtime offset 28, flags 0x1
    private UnityEngine.UI.Graphic[] toColorUI;
    // field 18463, runtime offset 32, flags 0x1
    private TMPro.TMP_Text weaponNameTxt;
    // field 18464, runtime offset 36, flags 0x1
    private TMPro.TMP_Text weaponAmmoTxt;
    // field 18465, runtime offset 40, flags 0x1
    private TMPro.TMP_Text weaponMiniTitleTxt;
    // field 18466, runtime offset 44, flags 0x1
    private UnityEngine.Transform weaponParent;
    // field 18467, runtime offset 48, flags 0x1
    private UnityEngine.Material hologramMaterial;
    // field 18468, runtime offset 52, flags 0x1
    private bool picked;
    // field 18469, runtime offset 8, flags 0x16
    public static bool isPickPending;
    // field 18470, runtime offset 56, flags 0x1
    private BRCaseItemData myData;
    // method 32380, 0x6000a85
    void OnEnable();
    // method 32381, 0x6000a86
    void OnDisable();
    // method 32382, 0x6000a87
    void Update();
    // method 32383, 0x6000a88
    void TryPickCurrent();
    // method 32384, 0x6000a89
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 32385, 0x6000a8a
    void TryPick(int viewId, int replaceWith, int ammo);
    // method 32386, 0x6000a8b
    void Init(BRCaseItemData data);
    // method 32387, 0x6000a8c
    void OnLookedAt(bool beingLookedAt);
    // method 32388, 0x6000a8d
    void .ctor();
    // method 32389, 0x6000a8e
    void .cctor();
}

// TypeDefinition 4383, 0x20001cf
class PlatformDetector : UnityEngine.MonoBehaviour {
    // field 18481, runtime offset 0, flags 0x8056
    public static const bool MOBILE_KICK_AFTER_MATCH = false;
    // field 18482, runtime offset 16, flags 0x6
    public bool editorIsMobile;
    // field 18483, runtime offset 17, flags 0x6
    public bool editorIsMobileWeb;
    // field 18484, runtime offset 0, flags 0x16
    public static bool isMobile;
    // field 18485, runtime offset 1, flags 0x16
    public static bool isMobileWeb;
    // field 18486, runtime offset 2, flags 0x16
    public static bool isPureMobile;
    // field 18487, runtime offset 3, flags 0x16
    public static bool possiblyLaptop;
    // method 32398, 0x6000a97
    void testFunctionggg();
    // method 32399, 0x6000a98
    bool isMobileDevice();
    // method 32400, 0x6000a99
    void Awake();
    // method 32401, 0x6000a9a
    void Start();
    // method 32402, 0x6000a9b
    void OnGotDevice(string device);
    // method 32403, 0x6000a9c
    void .ctor();
}

// TypeDefinition 4384, 0x20001d0
class PlayerInputHandler : Photon.Pun.MonoBehaviourPun {
    // field 18488, runtime offset 0, flags 0x16
    public static float mouseFlick;
    // field 18489, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform ammoPanel;
    // field 18490, runtime offset 24, flags 0x1
    private UnityEngine.GameObject[] alts;
    // field 18491, runtime offset 28, flags 0x1
    private float spawnTime;
    // field 18492, runtime offset 32, flags 0x1
    private bool lastAlt;
    // field 18493, runtime offset 36, flags 0x1
    private UnityEngine.Vector2 currentMovement;
    // field 18494, runtime offset 44, flags 0x1
    private UnityEngine.Vector2 currentLook;
    // field 18495, runtime offset 4, flags 0x16
    public static float lastActiveLookTime;
    // field 18496, runtime offset 52, flags 0x1
    private TMPro.TMP_Text[] weaponKeyTxts;
    // field 18497, runtime offset 56, flags 0x1
    private UnityEngine.Transform crosshairParentParent;
    // field 18498, runtime offset 60, flags 0x1
    private Shooter shooter;
    // field 18499, runtime offset 64, flags 0x1
    private UnityEngine.RectTransform healthRectTransform;
    // field 18500, runtime offset 68, flags 0x1
    private PlayerController playerController;
    // field 18501, runtime offset 72, flags 0x1
    private UnityEngine.GameObject[] disableForMobile;
    // field 18502, runtime offset 76, flags 0x1
    private float lastResumedTime;
    // field 18503, runtime offset 80, flags 0x6
    public bool isPaused;
    // field 18504, runtime offset 84, flags 0x1
    private float enabledTime;
    // field 18505, runtime offset 88, flags 0x6
    public bool isDancing;
    // field 18506, runtime offset 92, flags 0x1
    private UnityEngine.RectTransform canvasRectTransform;
    // field 18507, runtime offset 96, flags 0x1
    private MobileControls mobileControlsPrefab;
    // field 18508, runtime offset 100, flags 0x1
    private MobileControls currentMobileControls;
    // field 18509, runtime offset 104, flags 0x1
    private bool isMobile;
    // field 18510, runtime offset 8, flags 0x16
    public static bool isChatFocused;
    // field 18511, runtime offset 9, flags 0x16
    public static bool disableMovement;
    // field 18512, runtime offset 10, flags 0x16
    public static bool disableShooting;
    // field 18513, runtime offset 0, flags 0x8051
    private static const float PC_SENS_MUTLI = 1.1619999408721924;
    // field 18514, runtime offset 0, flags 0x8051
    private static const float MOBILE_WEB_SENS_MUTLI = 0.44999998807907104;
    // field 18515, runtime offset 0, flags 0x8051
    private static const float MOBILE_SENS_MUTLI = 0.3499999940395355;
    // field 18516, runtime offset 11, flags 0x16
    public static bool editingInventory;
    // field 18517, runtime offset 108, flags 0x1
    private float prevDeltaX;
    // field 18518, runtime offset 0, flags 0x8051
    private static const float threshold = 9;
    // field 18519, runtime offset 112, flags 0x1
    private bool aimToggleOn;
    // method 32404, 0x6000a9d
    void Update();
    // method 32405, 0x6000a9e
    void KillMobileControls();
    // method 32406, 0x6000a9f
    void OnEnable();
    // method 32407, 0x6000aa0
    void OnDisable();
    // method 32408, 0x6000aa1
    void OnGameEnded();
    // method 32409, 0x6000aa2
    void OnDanceStatus(bool isFinished);
    // method 32410, 0x6000aa3
    void Start();
    // method 32411, 0x6000aa4
    bool get_IsGamePaused();
    // method 32412, 0x6000aa5
    void Land();
    // method 32413, 0x6000aa6
    void EnableCrosshair();
    // method 32414, 0x6000aa7
    void OnPause();
    // method 32415, 0x6000aa8
    void OnResume();
    // method 32416, 0x6000aa9
    void RefreshWeaponKeyTxts();
    // method 32417, 0x6000aaa
    void OnMobileSetWeapon(bool canAimWithWeapon);
    // method 32418, 0x6000aab
    void OnInventoryChanged();
    // method 32419, 0x6000aac
    void Awake();
    // method 32420, 0x6000aad
    void OnClassChangedExternally();
    // method 32421, 0x6000aae
    UnityEngine.Vector2 Movement(bool forceTruth);
    // method 32422, 0x6000aaf
    string logMove();
    // method 32423, 0x6000ab0
    string logLook();
    // method 32424, 0x6000ab1
    UnityEngine.Vector2 Look();
    // method 32425, 0x6000ab2
    float AvoidFlicks(float currentDeltaX, float multiThreshold);
    // method 32426, 0x6000ab3
    void SetTargetFrameRate(int targetFrameRate);
    // method 32427, 0x6000ab4
    bool Shooting(out bool shootDown, out bool shootUp);
    // method 32428, 0x6000ab5
    bool Aiming();
    // method 32429, 0x6000ab6
    bool JumpDown();
    // method 32430, 0x6000ab7
    bool FirstWeaponDown();
    // method 32431, 0x6000ab8
    bool SecondWeaponDown();
    // method 32432, 0x6000ab9
    bool ThirdWeaponDown();
    // method 32433, 0x6000aba
    bool ForthWeaponDown();
    // method 32434, 0x6000abb
    bool Reload();
    // method 32435, 0x6000abc
    bool Dance();
    // method 32436, 0x6000abd
    bool Inspect();
    // method 32437, 0x6000abe
    bool JumpUp();
    // method 32438, 0x6000abf
    bool Crouch();
    // method 32439, 0x6000ac0
    bool MobilePausedDown();
    // method 32440, 0x6000ac1
    void ResetAim();
    // method 32441, 0x6000ac2
    void .ctor();
    // method 32442, 0x6000ac3
    void .cctor();
    // method 32443, 0x6000ac4
    void <Start>b__24_0();
    // method 32444, 0x6000ac5
    void <Start>b__24_1();
}

// TypeDefinition 4385, 0x20001d2
class <>c__DisplayClass3_0 : object {
    // field 18522, runtime offset 8, flags 0x6
    public UnityEngine.GameObject objectToSpawn;
    // method 32451, 0x6000acc
    void .ctor();
    // method 32452, 0x6000acd
    bool <SpawnObject>b__0(PooledObjectInfo p);
}

// TypeDefinition 4386, 0x20001d3
class <>c__DisplayClass5_0 : object {
    // field 18523, runtime offset 8, flags 0x6
    public string goName;
    // method 32453, 0x6000ace
    void .ctor();
    // method 32454, 0x6000acf
    bool <IenuReturnObjectToPool>b__0(PooledObjectInfo h);
}

// TypeDefinition 4387, 0x20001d4
class <IenuReturnObjectToPool>d__5 : object {
    // field 18524, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18525, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18526, runtime offset 16, flags 0x6
    public float t;
    // field 18527, runtime offset 20, flags 0x6
    public UnityEngine.GameObject who;
    // field 18528, runtime offset 24, flags 0x1
    private <>c__DisplayClass5_0 <>8__1;
    // field 18529, runtime offset 28, flags 0x1
    private float <elapsedTime>5__2;
    // method 32455, 0x6000ad0
    void .ctor(int <>1__state);
    // method 32456, 0x6000ad1
    void System.IDisposable.Dispose();
    // method 32457, 0x6000ad2
    bool MoveNext();
    // method 32458, 0x6000ad3
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32459, 0x6000ad4
    void System.Collections.IEnumerator.Reset();
    // method 32460, 0x6000ad5
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4388, 0x20001d1
class PoolManager : UnityEngine.MonoBehaviour {
    // field 18520, runtime offset 0, flags 0x16
    public static PoolManager instance;
    // field 18521, runtime offset 4, flags 0x16
    public static System.Collections.Generic.List<PooledObjectInfo> objectPools;
    // method 32445, 0x6000ac6
    void Awake();
    // method 32446, 0x6000ac7
    UnityEngine.GameObject SpawnObject(UnityEngine.GameObject objectToSpawn, UnityEngine.Vector3 spawnPosition, UnityEngine.Quaternion spawnRotation);
    // method 32447, 0x6000ac8
    void ReturnObjectToPool(UnityEngine.GameObject who, float afterSeconds);
    // method 32448, 0x6000ac9
    System.Collections.IEnumerator IenuReturnObjectToPool(UnityEngine.GameObject who, float t);
    // method 32449, 0x6000aca
    void .ctor();
    // method 32450, 0x6000acb
    void .cctor();
}

// TypeDefinition 4389, 0x20001d5
class PooledObjectInfo : object {
    // field 18530, runtime offset 8, flags 0x6
    public string lookupString;
    // field 18531, runtime offset 12, flags 0x6
    public System.Collections.Generic.List<UnityEngine.GameObject> inactiveGameObjects;
    // method 32461, 0x6000ad6
    void .ctor();
}

// TypeDefinition 4390, 0x20001d7
class <>c__DisplayClass14_0 : object {
    // field 18542, runtime offset 8, flags 0x6
    public Popup <>4__this;
    // field 18543, runtime offset 12, flags 0x6
    public System.Action onfinish;
    // method 32469, 0x6000ade
    void .ctor();
    // method 32470, 0x6000adf
    void <Close>b__0();
}

// TypeDefinition 4391, 0x20001d6
class Popup : UnityEngine.MonoBehaviour {
    // field 18532, runtime offset 16, flags 0x6
    public bool animateScale;
    // field 18533, runtime offset 20, flags 0x6
    public float durationStart;
    // field 18534, runtime offset 24, flags 0x6
    public float durationEnd;
    // field 18535, runtime offset 28, flags 0x6
    public UnityEngine.Vector2 startFrom;
    // field 18536, runtime offset 36, flags 0x6
    public UnityEngine.Vector2 startTo;
    // field 18537, runtime offset 44, flags 0x6
    public UnityEngine.Vector2 endTo;
    // field 18538, runtime offset 52, flags 0x4
    protected UnityEngine.CanvasGroup canvasGroup;
    // field 18539, runtime offset 56, flags 0x4
    protected UnityEngine.RectTransform rectTransform;
    // field 18540, runtime offset 60, flags 0x6
    public bool isClosing;
    // field 18541, runtime offset 64, flags 0x1
    private System.Action onShow;
    // method 32462, 0x6000ad7
    void Start();
    // method 32463, 0x6000ad8
    void Show(System.Action then);
    // method 32464, 0x6000ad9
    void Show();
    // method 32465, 0x6000ada
    void Close();
    // method 32466, 0x6000adb
    void Close(System.Action onfinish);
    // method 32467, 0x6000adc
    void .ctor();
    // method 32468, 0x6000add
    void <Show>b__12_0();
}

// TypeDefinition 4392, 0x20001d8
class PressYToGetSkinPanel : Popup {
    // field 18544, runtime offset 68, flags 0x1
    private UnityEngine.GameObject MOBILE;
    // field 18545, runtime offset 72, flags 0x1
    private UnityEngine.GameObject PC;
    // field 18546, runtime offset 76, flags 0x1
    private UnityEngine.UI.Image mainItemImage;
    // field 18547, runtime offset 80, flags 0x1
    private TMPro.TMP_Text rewardNameTxt;
    // field 18548, runtime offset 84, flags 0x1
    private TMPro.TMP_Text TopTxt;
    // field 18549, runtime offset 88, flags 0x1
    private TMPro.TMP_Text showtimeTxt;
    // field 18550, runtime offset 92, flags 0x1
    private MidgameReward midgameReward;
    // field 18551, runtime offset 96, flags 0x1
    private float initTime;
    // field 18552, runtime offset 100, flags 0x1
    private bool closed;
    // field 18553, runtime offset 104, flags 0x1
    private System.Action onClaimedOrClosed;
    // field 18554, runtime offset 108, flags 0x1
    private float showtime;
    // field 18555, runtime offset 112, flags 0x1
    private bool pressedY;
    // field 18556, runtime offset 113, flags 0x1
    private bool mobilePressed;
    // method 32471, 0x6000ae0
    void Init(float matchTimeInSeconds, MidgameReward newMidgameReward, System.Action _onClaimedOrClosed);
    // method 32472, 0x6000ae1
    void Update();
    // method 32473, 0x6000ae2
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32474, 0x6000ae3
    void .ctor();
    // method 32475, 0x6000ae4
    void <Update>b__13_0(bool success);
}

// TypeDefinition 4393, 0x20001d9
class ProfanityList : UnityEngine.ScriptableObject {
    // field 18557, runtime offset 12, flags 0x6
    public string[] words;
    // method 32476, 0x6000ae5
    void .ctor();
}

// TypeDefinition 4394, 0x20001db
class <>c : object {
    // field 18581, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18582, runtime offset 4, flags 0x16
    public static System.Action<string> <>9__24_0;
    // method 32488, 0x6000af1
    void .cctor();
    // method 32489, 0x6000af2
    void .ctor();
    // method 32490, 0x6000af3
    void <Add>b__24_0(string then);
}

// TypeDefinition 4395, 0x20001da
class ProfilePanel : Popup {
    // field 18558, runtime offset 68, flags 0x1
    private UnityEngine.GameObject[] showForCg;
    // field 18559, runtime offset 72, flags 0x1
    private UnityEngine.GameObject banBtn;
    // field 18560, runtime offset 76, flags 0x1
    private UnityEngine.GameObject addFriendButton;
    // field 18561, runtime offset 80, flags 0x1
    private UnityEngine.Sprite questionMark;
    // field 18562, runtime offset 84, flags 0x1
    private UnityEngine.GameObject bannedObj;
    // field 18563, runtime offset 88, flags 0x1
    private TMPro.TMP_Text rankTxt;
    // field 18564, runtime offset 92, flags 0x1
    private TMPro.TMP_Text uidTxt;
    // field 18565, runtime offset 96, flags 0x1
    private UnityEngine.UI.Image rankImage;
    // field 18566, runtime offset 100, flags 0x1
    private UnityEngine.UI.Image rankBackgroundImage;
    // field 18567, runtime offset 104, flags 0x6
    public UnityEngine.GameObject loadingPanel;
    // field 18568, runtime offset 108, flags 0x1
    private UnityEngine.GameObject[] showForMyProfile;
    // field 18569, runtime offset 112, flags 0x6
    public UnityEngine.UI.Button kickButton;
    // field 18570, runtime offset 116, flags 0x6
    public TMPro.TMP_Text topText;
    // field 18571, runtime offset 120, flags 0x6
    public TMPro.TMP_Text usernameTxt;
    // field 18572, runtime offset 124, flags 0x1
    private TMPro.TMP_Text accountCreatedTxt;
    // field 18573, runtime offset 128, flags 0x6
    public UnityEngine.UI.Image profileImage;
    // field 18574, runtime offset 132, flags 0x6
    public UnityEngine.UI.Image profileBackgroundImage;
    // field 18575, runtime offset 136, flags 0x1
    private UnityEngine.GameObject profileImageParent;
    // field 18576, runtime offset 140, flags 0x1
    private TMPro.TMP_Text levelInfo;
    // field 18577, runtime offset 144, flags 0x1
    private UnityEngine.RectTransform levelFill;
    // field 18578, runtime offset 148, flags 0x1
    private TMPro.TMP_Text[] statTxts;
    // field 18579, runtime offset 152, flags 0x1
    private bool isOther;
    // field 18580, runtime offset 156, flags 0x1
    private string initWithName;
    // method 32477, 0x6000ae6
    void ShowUserRecovery();
    // method 32478, 0x6000ae7
    void EditProfilePicture();
    // method 32479, 0x6000ae8
    void LogoutBtn();
    // method 32480, 0x6000ae9
    void Add();
    // method 32481, 0x6000aea
    void SelfInit();
    // method 32482, 0x6000aeb
    string ToShortString(double number);
    // method 32483, 0x6000aec
    bool IsValidDate(string dateString);
    // method 32484, 0x6000aed
    void BanCurrent();
    // method 32485, 0x6000aee
    void Init(string uid, string usernameRaw, out UnityEngine.GameObject _addFriendButton, bool banned, bool _isOther, int elo, int gamesPlayed, int profileBackgroundIndex, int profileImageIndex, float levelFill_, string levelInfoText, string usernameText, string accountCreatedText, string[] stats);
    // method 32486, 0x6000aef
    void .ctor();
    // method 32487, 0x6000af0
    void <Init>b__31_0(UnityEngine.Sprite sp);
}

// TypeDefinition 4396, 0x20001dc
class ProfilePictures : UnityEngine.ScriptableObject {
    // field 18583, runtime offset 12, flags 0x6
    public string[] picturePaths;
    // field 18584, runtime offset 16, flags 0x6
    public UnityEngine.Color[] backgroundColors;
    // method 32491, 0x6000af4
    void .ctor();
}

// TypeDefinition 4397, 0x20001de
class <>c : object {
    // field 18590, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18591, runtime offset 4, flags 0x16
    public static System.Action <>9__8_0;
    // method 32497, 0x6000afa
    void .cctor();
    // method 32498, 0x6000afb
    void .ctor();
    // method 32499, 0x6000afc
    void <UploadMapData>b__8_0();
}

// TypeDefinition 4398, 0x20001df
class <UploadMapData>d__8 : object {
    // field 18592, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18593, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18594, runtime offset 16, flags 0x6
    public PublishGamePanel <>4__this;
    // field 18595, runtime offset 20, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 32500, 0x6000afd
    void .ctor(int <>1__state);
    // method 32501, 0x6000afe
    void System.IDisposable.Dispose();
    // method 32502, 0x6000aff
    bool MoveNext();
    // method 32503, 0x6000b00
    void <>m__Finally1();
    // method 32504, 0x6000b01
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32505, 0x6000b02
    void System.Collections.IEnumerator.Reset();
    // method 32506, 0x6000b03
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4399, 0x20001dd
class PublishGamePanel : Popup {
    // field 18585, runtime offset 0, flags 0x8051
    private static const string uploadUrl = "https://kour.io/api/uploadMap";
    // field 18586, runtime offset 68, flags 0x1
    private UnityEngine.UI.InputField titleTxt;
    // field 18587, runtime offset 72, flags 0x1
    private UnityEngine.UI.InputField descriptionTxt;
    // field 18588, runtime offset 76, flags 0x1
    private TMPro.TMP_Text agreeTxt;
    // field 18589, runtime offset 80, flags 0x1
    private ImageHandler imageHandler;
    // method 32492, 0x6000af5
    void Show();
    // method 32493, 0x6000af6
    void PublishButtonPressed();
    // method 32494, 0x6000af7
    void OnNameChanged(string newName);
    // method 32495, 0x6000af8
    System.Collections.IEnumerator UploadMapData();
    // method 32496, 0x6000af9
    void .ctor();
}

// TypeDefinition 4400, 0x20001e0
class QualityManager : UnityEngine.MonoBehaviour {
    // field 18596, runtime offset 16, flags 0x6
    public ScreenSpaceCavityCurvature.SSCC[] SSCCs;
    // field 18597, runtime offset 0, flags 0x8056
    public static const int defaultQuality = 0;
    // field 18598, runtime offset 0, flags 0x16
    public static QualityManager instance;
    // field 18599, runtime offset 4, flags 0x16
    public static int CurrentQualityIndex;
    // field 18600, runtime offset 20, flags 0x1
    private bool isFocused;
    // method 32507, 0x6000b04
    void OnApplicationFocus(bool focus);
    // method 32508, 0x6000b05
    void Start();
    // method 32509, 0x6000b06
    void QualityButtonPressed(int index);
    // method 32510, 0x6000b07
    void RefreshUI(int customIndex);
    // method 32511, 0x6000b08
    void SetQuality(bool setOtherParams, int customIndex);
    // method 32512, 0x6000b09
    void .ctor();
}

// TypeDefinition 4401, 0x20001e1
class RagdollPlayer : UnityEngine.MonoBehaviour {
    // field 18601, runtime offset 16, flags 0x1
    private Shooter myShooter;
    // field 18602, runtime offset 20, flags 0x1
    private UnityEngine.Animations.Rigging.RigBuilder rigBuilder;
    // field 18603, runtime offset 24, flags 0x1
    private UnityEngine.Animator globalAnimator;
    // field 18604, runtime offset 28, flags 0x1
    private UnityEngine.Collider[] colliders_enableForRagdolls;
    // field 18605, runtime offset 32, flags 0x1
    private UnityEngine.Rigidbody[] rbs_enableForRagdolls;
    // field 18606, runtime offset 36, flags 0x1
    private UnityEngine.Collider[] colliders_disableForRagdolls;
    // field 18607, runtime offset 40, flags 0x1
    private UnityEngine.GameObject characterParent;
    // field 18608, runtime offset 44, flags 0x6
    public bool isRagdoll;
    // method 32513, 0x6000b0a
    void TurnIntoRagdoll(UnityEngine.Vector3 lastHitPos, float forceMulti);
    // method 32514, 0x6000b0b
    void .ctor();
}

// TypeDefinition 4402, 0x20001e3
class <DisplayRandomText>d__6 : object {
    // field 18613, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18614, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18615, runtime offset 16, flags 0x6
    public RandomTextDisplayer <>4__this;
    // field 18616, runtime offset 20, flags 0x1
    private int <index>5__2;
    // method 32520, 0x6000b11
    void .ctor(int <>1__state);
    // method 32521, 0x6000b12
    void System.IDisposable.Dispose();
    // method 32522, 0x6000b13
    bool MoveNext();
    // method 32523, 0x6000b14
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32524, 0x6000b15
    void System.Collections.IEnumerator.Reset();
    // method 32525, 0x6000b16
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4403, 0x20001e2
class RandomTextDisplayer : UnityEngine.MonoBehaviour {
    // field 18609, runtime offset 16, flags 0x1
    private string[] texts;
    // field 18610, runtime offset 20, flags 0x1
    private float textChangeSpeed;
    // field 18611, runtime offset 24, flags 0x1
    private TMPro.TMP_Text displayText;
    // field 18612, runtime offset 28, flags 0x1
    private UnityEngine.Coroutine displayCoroutine;
    // method 32515, 0x6000b0c
    void OnEnable();
    // method 32516, 0x6000b0d
    void OnDisable();
    // method 32517, 0x6000b0e
    System.Collections.IEnumerator DisplayRandomText();
    // method 32518, 0x6000b0f
    void Shuffle(string[] array);
    // method 32519, 0x6000b10
    void .ctor();
}

// TypeDefinition 4404, 0x20001e4
class RankManager : UnityEngine.MonoBehaviour {
    // field 18617, runtime offset 16, flags 0x6
    public UnityEngine.U2D.SpriteAtlas rankAtlas;
    // field 18618, runtime offset 20, flags 0x6
    public UnityEngine.Color[] rankBackgroundColors;
    // field 18619, runtime offset 0, flags 0x8056
    public static const int defaultElo = 3500;
    // field 18620, runtime offset 0, flags 0x8056
    public static const int maxElo = 20000;
    // field 18621, runtime offset 0, flags 0x8056
    public static const int minElo = 100;
    // field 18622, runtime offset 24, flags 0x1
    private UnityEngine.AnimationCurve eloToRankCurve;
    // field 18623, runtime offset 0, flags 0x16
    public static RankManager instance;
    // field 18624, runtime offset 4, flags 0x11
    private static int maxRank;
    // field 18625, runtime offset 0, flags 0x8056
    public static const int MIN_GAMES_FOR_RANK = 3;
    // method 32526, 0x6000b17
    void Awake();
    // method 32527, 0x6000b18
    void Start();
    // method 32528, 0x6000b19
    RankInfo GetRank(int fromElo);
    // method 32529, 0x6000b1a
    string RankIndexToName(int index);
    // method 32530, 0x6000b1b
    RankInfo GetRankInfo(int currentElo);
    // method 32531, 0x6000b1c
    void .ctor();
    // method 32532, 0x6000b1d
    void .cctor();
}

// TypeDefinition 4405, 0x20001e5
class RankInfo : object {
    // field 18626, runtime offset 8, flags 0x6
    public int currentRank;
    // field 18627, runtime offset 12, flags 0x6
    public int eloToNextRank;
    // field 18628, runtime offset 16, flags 0x6
    public int deltaElo;
    // method 32533, 0x6000b1e
    void .ctor();
}

// TypeDefinition 4406, 0x20001e7
class <>c : object {
    // field 18642, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18643, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__14_4;
    // field 18644, runtime offset 8, flags 0x16
    public static DG.Tweening.TweenCallback <>9__14_8;
    // method 32543, 0x6000b28
    void .cctor();
    // method 32544, 0x6000b29
    void .ctor();
    // method 32545, 0x6000b2a
    void <IenuInit>b__14_4();
    // method 32546, 0x6000b2b
    void <IenuInit>b__14_8();
}

// TypeDefinition 4407, 0x20001e8
class <>c__DisplayClass14_0 : object {
    // field 18645, runtime offset 8, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18646, runtime offset 12, flags 0x6
    public RankInfo currentRank;
    // field 18647, runtime offset 16, flags 0x6
    public UnityEngine.Color currentColor;
    // field 18648, runtime offset 32, flags 0x6
    public System.Action <>9__3;
    // field 18649, runtime offset 36, flags 0x6
    public DG.Tweening.TweenCallback <>9__2;
    // field 18650, runtime offset 40, flags 0x6
    public System.Action <>9__7;
    // field 18651, runtime offset 44, flags 0x6
    public DG.Tweening.TweenCallback <>9__6;
    // method 32547, 0x6000b2c
    void .ctor();
    // method 32548, 0x6000b2d
    void <IenuInit>b__0();
    // method 32549, 0x6000b2e
    void <IenuInit>b__1();
    // method 32550, 0x6000b2f
    void <IenuInit>b__2();
    // method 32551, 0x6000b30
    void <IenuInit>b__3();
    // method 32552, 0x6000b31
    void <IenuInit>b__5();
    // method 32553, 0x6000b32
    void <IenuInit>b__6();
    // method 32554, 0x6000b33
    void <IenuInit>b__7();
}

// TypeDefinition 4408, 0x20001e9
class <>c__DisplayClass16_0 : object {
    // field 18652, runtime offset 8, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18653, runtime offset 12, flags 0x6
    public bool leveledUp;
    // method 32555, 0x6000b34
    void .ctor();
    // method 32556, 0x6000b35
    void <IenuKill>b__0();
}

// TypeDefinition 4409, 0x20001ea
class <>c__DisplayClass17_0 : object {
    // field 18654, runtime offset 8, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18655, runtime offset 12, flags 0x6
    public System.Action onComplete;
    // method 32557, 0x6000b36
    void .ctor();
    // method 32558, 0x6000b37
    void <IenuUIFillAnimations>b__0();
    // method 32559, 0x6000b38
    void <IenuUIFillAnimations>b__1();
    // method 32560, 0x6000b39
    void <IenuUIFillAnimations>b__2();
}

// TypeDefinition 4410, 0x20001eb
class <IenuInit>d__14 : object {
    // field 18656, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18657, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18658, runtime offset 16, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18659, runtime offset 20, flags 0x6
    public float delay;
    // field 18660, runtime offset 24, flags 0x6
    public int eloBefore;
    // field 18661, runtime offset 28, flags 0x1
    private <>c__DisplayClass14_0 <>8__1;
    // field 18662, runtime offset 32, flags 0x6
    public int eloAfter;
    // method 32561, 0x6000b3a
    void .ctor(int <>1__state);
    // method 32562, 0x6000b3b
    void System.IDisposable.Dispose();
    // method 32563, 0x6000b3c
    bool MoveNext();
    // method 32564, 0x6000b3d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32565, 0x6000b3e
    void System.Collections.IEnumerator.Reset();
    // method 32566, 0x6000b3f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4411, 0x20001ec
class <IenuKill>d__16 : object {
    // field 18663, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18664, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18665, runtime offset 16, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18666, runtime offset 20, flags 0x6
    public bool leveledUp;
    // field 18667, runtime offset 24, flags 0x6
    public float delay;
    // field 18668, runtime offset 28, flags 0x6
    public float killDuration;
    // field 18669, runtime offset 32, flags 0x1
    private <>c__DisplayClass16_0 <>8__1;
    // method 32567, 0x6000b40
    void .ctor(int <>1__state);
    // method 32568, 0x6000b41
    void System.IDisposable.Dispose();
    // method 32569, 0x6000b42
    bool MoveNext();
    // method 32570, 0x6000b43
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32571, 0x6000b44
    void System.Collections.IEnumerator.Reset();
    // method 32572, 0x6000b45
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4412, 0x20001ed
class <IenuUIFillAnimations>d__17 : object {
    // field 18670, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18671, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18672, runtime offset 16, flags 0x6
    public RankProgressPanel <>4__this;
    // field 18673, runtime offset 20, flags 0x6
    public System.Action onComplete;
    // field 18674, runtime offset 24, flags 0x6
    public float baseStartWith;
    // field 18675, runtime offset 28, flags 0x6
    public float progStartWith;
    // field 18676, runtime offset 32, flags 0x6
    public float delay;
    // field 18677, runtime offset 36, flags 0x1
    private <>c__DisplayClass17_0 <>8__1;
    // field 18678, runtime offset 40, flags 0x1
    private float <timeToTravel>5__2;
    // method 32573, 0x6000b46
    void .ctor(int <>1__state);
    // method 32574, 0x6000b47
    void System.IDisposable.Dispose();
    // method 32575, 0x6000b48
    bool MoveNext();
    // method 32576, 0x6000b49
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32577, 0x6000b4a
    void System.Collections.IEnumerator.Reset();
    // method 32578, 0x6000b4b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4413, 0x20001e6
class RankProgressPanel : UnityEngine.MonoBehaviour {
    // field 18629, runtime offset 16, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 18630, runtime offset 20, flags 0x1
    private UnityEngine.AudioClip[] audioClips;
    // field 18631, runtime offset 24, flags 0x1
    private TMPro.TMP_Text rankTxt;
    // field 18632, runtime offset 28, flags 0x1
    private UnityEngine.CanvasGroup rankupEffectCanvasGroup;
    // field 18633, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image rankImg;
    // field 18634, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image backgroundImg;
    // field 18635, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image baseImageFill;
    // field 18636, runtime offset 44, flags 0x1
    private UnityEngine.UI.Image progImageFill;
    // field 18637, runtime offset 48, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 18638, runtime offset 52, flags 0x1
    private TMPro.TMP_Text percentageTxt;
    // field 18639, runtime offset 56, flags 0x1
    private float baseFillLerpTo;
    // field 18640, runtime offset 60, flags 0x1
    private float progFillLerpTo;
    // field 18641, runtime offset 64, flags 0x1
    private System.Action<bool> onDie;
    // method 32534, 0x6000b1f
    void Init(float delay, int eloBefore, int eloAfter, System.Action<bool> _onDie);
    // method 32535, 0x6000b20
    System.Collections.IEnumerator IenuInit(float delay, int eloBefore, int eloAfter);
    // method 32536, 0x6000b21
    void Kill(float delay, float killDuration, bool leveledUp);
    // method 32537, 0x6000b22
    System.Collections.IEnumerator IenuKill(float delay, float killDuration, bool leveledUp);
    // method 32538, 0x6000b23
    System.Collections.IEnumerator IenuUIFillAnimations(float baseStartWith, float progStartWith, float delay, System.Action onComplete);
    // method 32539, 0x6000b24
    void OnFillUpdate();
    // method 32540, 0x6000b25
    void SetRankSpriteAndText(RankInfo givenRank);
    // method 32541, 0x6000b26
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32542, 0x6000b27
    void .ctor();
}

// TypeDefinition 4414, 0x20001ef
class <>c__DisplayClass11_0 : object {
    // field 18689, runtime offset 8, flags 0x6
    public int lastRankSeen;
    // field 18690, runtime offset 12, flags 0x6
    public int rankIndex;
    // method 32585, 0x6000b52
    void .ctor();
    // method 32586, 0x6000b53
    void <RefreshRankImages>b__0(bool leveledUp);
}

// TypeDefinition 4415, 0x20001ee
class RankUIManager : UnityEngine.MonoBehaviour {
    // field 18679, runtime offset 16, flags 0x6
    public RankProgressPanel rankProgressPanelPrefab;
    // field 18680, runtime offset 0, flags 0x16
    public static int lastGamePreviousElo;
    // field 18681, runtime offset 4, flags 0x16
    public static int lastGameNewElo;
    // field 18682, runtime offset 20, flags 0x1
    private TMPro.TMP_Text rankLockedTxt;
    // field 18683, runtime offset 24, flags 0x1
    private UnityEngine.GameObject[] showIfRankUnlocked;
    // field 18684, runtime offset 28, flags 0x1
    private UnityEngine.GameObject[] showIfRankLocked;
    // field 18685, runtime offset 8, flags 0x11
    private static RankUIManager instance;
    // field 18686, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image[] rankImages;
    // field 18687, runtime offset 36, flags 0x1
    private TMPro.TMP_Text[] rankTxts;
    // field 18688, runtime offset 40, flags 0x1
    private TMPro.TMP_Text[] rankPercentTxts;
    // method 32579, 0x6000b4c
    RankUIManager get_Instance();
    // method 32580, 0x6000b4d
    void Start();
    // method 32581, 0x6000b4e
    void GetRankSprite(int givenElo, System.Action<UnityEngine.Sprite> onGot);
    // method 32582, 0x6000b4f
    void RefreshRankImages();
    // method 32583, 0x6000b50
    void .ctor();
    // method 32584, 0x6000b51
    void .cctor();
}

// TypeDefinition 4416, 0x20001f0
class RankedUpPanel : UnityEngine.MonoBehaviour {
    // field 18691, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image rankImage;
    // field 18692, runtime offset 20, flags 0x1
    private TMPro.TMP_Text rankTxt;
    // field 18693, runtime offset 24, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 18694, runtime offset 28, flags 0x1
    private UnityEngine.AudioSource musicAudioSource;
    // field 18695, runtime offset 32, flags 0x1
    private UnityEngine.AudioClip[] audioClips;
    // field 18696, runtime offset 36, flags 0x1
    private int withElo;
    // field 18697, runtime offset 40, flags 0x1
    private bool allowKill;
    // method 32587, 0x6000b54
    void Start();
    // method 32588, 0x6000b55
    void Update();
    // method 32589, 0x6000b56
    void DisableInputModules();
    // method 32590, 0x6000b57
    void EnableInputs();
    // method 32591, 0x6000b58
    void Init(float inTime, int _withElo);
    // method 32592, 0x6000b59
    void InitAfterDelay();
    // method 32593, 0x6000b5a
    void OnAnimationRankExplode();
    // method 32594, 0x6000b5b
    void OnAnimation2();
    // method 32595, 0x6000b5c
    void TryKill();
    // method 32596, 0x6000b5d
    void .ctor();
    // method 32597, 0x6000b5e
    void <InitAfterDelay>b__12_0(UnityEngine.Sprite sp);
    // method 32598, 0x6000b5f
    void <TryKill>b__15_0();
}

// TypeDefinition 4417, 0x20001f2
class <IenuOnLand>d__19 : object {
    // field 18713, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18714, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18715, runtime offset 16, flags 0x6
    public Recoil <>4__this;
    // field 18716, runtime offset 20, flags 0x6
    public float multi;
    // field 18717, runtime offset 24, flags 0x1
    private float <x>5__2;
    // method 32605, 0x6000b66
    void .ctor(int <>1__state);
    // method 32606, 0x6000b67
    void System.IDisposable.Dispose();
    // method 32607, 0x6000b68
    bool MoveNext();
    // method 32608, 0x6000b69
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32609, 0x6000b6a
    void System.Collections.IEnumerator.Reset();
    // method 32610, 0x6000b6b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4418, 0x20001f1
class Recoil : UnityEngine.MonoBehaviour {
    // field 18698, runtime offset 0, flags 0x8056
    public static const float MOBILE_RECOIL_MULTI = 0.4099999964237213;
    // field 18699, runtime offset 16, flags 0x1
    private PlayerController playerController;
    // field 18700, runtime offset 20, flags 0x1
    private UnityEngine.Vector3 currentRotation;
    // field 18701, runtime offset 32, flags 0x1
    private UnityEngine.Vector3 targetRotation;
    // field 18702, runtime offset 44, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat recoilX;
    // field 18703, runtime offset 68, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat recoilY;
    // field 18704, runtime offset 92, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat recoilZ;
    // field 18705, runtime offset 116, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat snappiness;
    // field 18706, runtime offset 140, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat returnSpeed;
    // field 18707, runtime offset 164, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat currentRecoil;
    // field 18708, runtime offset 188, flags 0x6
    public float initialReturnSpeed;
    // field 18709, runtime offset 192, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat currentRecoilCrazinessCrosshairMulti;
    // field 18710, runtime offset 216, flags 0x1
    private bool onGround;
    // field 18711, runtime offset 217, flags 0x1
    private bool onGroundLastFrame;
    // field 18712, runtime offset 218, flags 0x1
    private bool isLanding;
    // method 32599, 0x6000b60
    void Start();
    // method 32600, 0x6000b61
    void Update();
    // method 32601, 0x6000b62
    void RecoilFire(float recoilCrazinessCrosshair, float recoilCrazinessPhysical, float setReturnSpeedMulti);
    // method 32602, 0x6000b63
    void OnLand();
    // method 32603, 0x6000b64
    System.Collections.IEnumerator IenuOnLand(float multi);
    // method 32604, 0x6000b65
    void .ctor();
}

// TypeDefinition 4419, 0x20001f4
class <>c__DisplayClass15_0 : object {
    // field 18724, runtime offset 8, flags 0x6
    public Photon.Realtime.RoomInfo roomInfo;
    // field 18725, runtime offset 12, flags 0x6
    public System.Action<string> <>9__1;
    // method 32621, 0x6000b76
    void .ctor();
    // method 32622, 0x6000b77
    void <OnRoomButtonPressed>b__0();
    // method 32623, 0x6000b78
    void <OnRoomButtonPressed>b__1(string mapName);
}

// TypeDefinition 4420, 0x20001f5
class <>c__DisplayClass15_1 : object {
    // field 18726, runtime offset 8, flags 0x6
    public string rName;
    // field 18727, runtime offset 12, flags 0x6
    public Photon.Realtime.RoomOptions options;
    // method 32624, 0x6000b79
    void .ctor();
    // method 32625, 0x6000b7a
    void <OnRoomButtonPressed>b__2(string mapName);
}

// TypeDefinition 4421, 0x20001f6
class <IenuUpdateLayoutGroup>d__14 : object {
    // field 18728, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18729, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18730, runtime offset 16, flags 0x6
    public RegionRoomsHolder <>4__this;
    // field 18731, runtime offset 20, flags 0x6
    public UnityEngine.RectTransform recttransformOfTheLayoutgroup;
    // method 32626, 0x6000b7b
    void .ctor(int <>1__state);
    // method 32627, 0x6000b7c
    void System.IDisposable.Dispose();
    // method 32628, 0x6000b7d
    bool MoveNext();
    // method 32629, 0x6000b7e
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32630, 0x6000b7f
    void System.Collections.IEnumerator.Reset();
    // method 32631, 0x6000b80
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4422, 0x20001f3
class RegionRoomsHolder : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 18718, runtime offset 20, flags 0x1
    private TMPro.TMP_Text lobbiesFullTxt;
    // field 18719, runtime offset 24, flags 0x1
    private UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup;
    // field 18720, runtime offset 28, flags 0x6
    public UnityEngine.GameObject loadingPanel;
    // field 18721, runtime offset 32, flags 0x6
    public UnityEngine.GameObject noRooms;
    // field 18722, runtime offset 36, flags 0x6
    public ServerFinderRoomButton[] roomButtonsPool;
    // field 18723, runtime offset 40, flags 0x1
    private System.Collections.Generic.List<Photon.Realtime.RoomInfo> roomList;
    // method 32611, 0x6000b6c
    void OnDisable();
    // method 32612, 0x6000b6d
    void LoadRoomsOnRegion(string token);
    // method 32613, 0x6000b6e
    void OnConnectedToMasterServer(string regionToken);
    // method 32614, 0x6000b6f
    int get_fullLobbyCount();
    // method 32615, 0x6000b70
    void OnRoomListUpdate(System.Collections.Generic.List<Photon.Realtime.RoomInfo> updateRoomList);
    // method 32616, 0x6000b71
    void UpdateRoomList();
    // method 32617, 0x6000b72
    void UpdateLayoutGroup(UnityEngine.RectTransform with);
    // method 32618, 0x6000b73
    System.Collections.IEnumerator IenuUpdateLayoutGroup(UnityEngine.RectTransform recttransformOfTheLayoutgroup);
    // method 32619, 0x6000b74
    void OnRoomButtonPressed(Photon.Realtime.RoomInfo roomInfo);
    // method 32620, 0x6000b75
    void .ctor();
}

// TypeDefinition 4423, 0x20001f8
class <CheckCenterPixelAfterFrames>d__3 : object {
    // field 18734, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18735, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18736, runtime offset 16, flags 0x6
    public int frameDelay;
    // field 18737, runtime offset 20, flags 0x6
    public RenderTextureChecker <>4__this;
    // field 18738, runtime offset 24, flags 0x1
    private int <i>5__2;
    // method 32636, 0x6000b85
    void .ctor(int <>1__state);
    // method 32637, 0x6000b86
    void System.IDisposable.Dispose();
    // method 32638, 0x6000b87
    bool MoveNext();
    // method 32639, 0x6000b88
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32640, 0x6000b89
    void System.Collections.IEnumerator.Reset();
    // method 32641, 0x6000b8a
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4424, 0x20001f7
class RenderTextureChecker : UnityEngine.MonoBehaviour {
    // field 18732, runtime offset 16, flags 0x6
    public UnityEngine.RenderTexture renderTexture;
    // field 18733, runtime offset 20, flags 0x6
    public UnityEngine.Rendering.PostProcessing.PostProcessProfile[] postProcessProfiles;
    // method 32632, 0x6000b81
    void Start();
    // method 32633, 0x6000b82
    System.Collections.IEnumerator CheckCenterPixelAfterFrames(int frameDelay);
    // method 32634, 0x6000b83
    void DisableColorGrading();
    // method 32635, 0x6000b84
    void .ctor();
}

// TypeDefinition 4425, 0x20001fa
class <IenuDestroy>d__11 : object {
    // field 18747, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18748, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18749, runtime offset 16, flags 0x6
    public Rocket <>4__this;
    // method 32648, 0x6000b91
    void .ctor(int <>1__state);
    // method 32649, 0x6000b92
    void System.IDisposable.Dispose();
    // method 32650, 0x6000b93
    bool MoveNext();
    // method 32651, 0x6000b94
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32652, 0x6000b95
    void System.Collections.IEnumerator.Reset();
    // method 32653, 0x6000b96
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4426, 0x20001f9
class Rocket : Bullet {
    // field 18739, runtime offset 100, flags 0x6
    public Shooter myShooter;
    // field 18740, runtime offset 104, flags 0x6
    public Photon.Pun.UtilityScripts.PhotonTeam myTeam;
    // field 18741, runtime offset 108, flags 0x1
    private UnityEngine.LayerMask explosionLayerMask;
    // field 18742, runtime offset 112, flags 0x1
    private UnityEngine.Transform[] disableOnHit;
    // field 18743, runtime offset 116, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat explosionRadius;
    // field 18744, runtime offset 140, flags 0x1
    private float fullyDestoyTime;
    // field 18745, runtime offset 144, flags 0x6
    public CodeStage.AntiCheat.ObscuredTypes.ObscuredInt damage;
    // field 18746, runtime offset 164, flags 0x1
    private bool exploaded;
    // method 32642, 0x6000b8b
    void OnEnable();
    // method 32643, 0x6000b8c
    void OnTriggerEnter(UnityEngine.Collider other);
    // method 32644, 0x6000b8d
    int[] GetTargetIDs(int givenAmount, UnityEngine.Collider[] cols);
    // method 32645, 0x6000b8e
    System.Collections.IEnumerator IenuDestroy();
    // method 32646, 0x6000b8f
    void Des_();
    // method 32647, 0x6000b90
    void .ctor();
}

// TypeDefinition 4427, 0x20001fc
class <IenuAftershots>d__18 : object {
    // field 18763, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18764, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18765, runtime offset 16, flags 0x6
    public RocketLauncher <>4__this;
    // field 18766, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 18767, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 32663, 0x6000ba0
    void .ctor(int <>1__state);
    // method 32664, 0x6000ba1
    void System.IDisposable.Dispose();
    // method 32665, 0x6000ba2
    bool MoveNext();
    // method 32666, 0x6000ba3
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32667, 0x6000ba4
    void System.Collections.IEnumerator.Reset();
    // method 32668, 0x6000ba5
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4428, 0x20001fb
class RocketLauncher : Weapon {
    // field 18750, runtime offset 252, flags 0x1
    private UnityEngine.GameObject tempRocket;
    // field 18751, runtime offset 256, flags 0x1
    private float aimDuration;
    // field 18752, runtime offset 260, flags 0x1
    private float fovMultiOnAim;
    // field 18753, runtime offset 264, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentPosition;
    // field 18754, runtime offset 276, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentRotation;
    // field 18755, runtime offset 288, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentPosition;
    // field 18756, runtime offset 300, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentRotation;
    // field 18757, runtime offset 312, flags 0x1
    private UnityEngine.AudioSource aftershotSource;
    // field 18758, runtime offset 316, flags 0x1
    private float intialAftershotDelay;
    // field 18759, runtime offset 320, flags 0x1
    private AfterShot[] aftershots;
    // field 18760, runtime offset 324, flags 0x1
    private UnityEngine.GameObject[] sniperVisuals;
    // field 18761, runtime offset 328, flags 0x1
    private float instabilityWhileAiming;
    // field 18762, runtime offset 332, flags 0x1
    private bool aimCanceled;
    // method 32654, 0x6000b97
    void EndReload();
    // method 32655, 0x6000b98
    void OnStart();
    // method 32656, 0x6000b99
    void Aim();
    // method 32657, 0x6000b9a
    void StopAim();
    // method 32658, 0x6000b9b
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 32659, 0x6000b9c
    System.Collections.IEnumerator IenuAftershots(bool is2DSound);
    // method 32660, 0x6000b9d
    void .ctor();
    // method 32661, 0x6000b9e
    void <Aim>b__15_0();
    // method 32662, 0x6000b9f
    void <StopAim>b__16_0();
}

// TypeDefinition 4429, 0x20001fd
class RotateAllTime : UnityEngine.MonoBehaviour {
    // field 18768, runtime offset 16, flags 0x1
    private UnityEngine.Vector3 axis;
    // field 18769, runtime offset 28, flags 0x1
    private float speed;
    // method 32669, 0x6000ba6
    void Update();
    // method 32670, 0x6000ba7
    void .ctor();
}

// TypeDefinition 4430, 0x20001fe
class RotateCharacter : UnityEngine.MonoBehaviour {
    // field 18770, runtime offset 16, flags 0x6
    public bool isButton;
    // field 18771, runtime offset 20, flags 0x6
    public float rotationSpeed;
    // field 18772, runtime offset 24, flags 0x6
    public UnityEngine.Transform characterTransform;
    // field 18773, runtime offset 28, flags 0x1
    private bool isDragging;
    // field 18774, runtime offset 32, flags 0x1
    private UnityEngine.Vector2 initialTouchPosition;
    // field 18775, runtime offset 40, flags 0x1
    private bool onDragCalled;
    // field 18776, runtime offset 44, flags 0x1
    private UnityEngine.Quaternion initialRotation;
    // field 18777, runtime offset 60, flags 0x1
    private bool isSticky;
    // method 32671, 0x6000ba8
    void Start();
    // method 32672, 0x6000ba9
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32673, 0x6000baa
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32674, 0x6000bab
    void OnDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32675, 0x6000bac
    void Update();
    // method 32676, 0x6000bad
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32677, 0x6000bae
    void OnDisable();
    // method 32678, 0x6000baf
    void .ctor();
}

// TypeDefinition 4431, 0x20001ff
class RotateItemAllAxis : UnityEngine.MonoBehaviour {
    // field 18778, runtime offset 16, flags 0x6
    public float rotationSpeed;
    // field 18779, runtime offset 20, flags 0x6
    public UnityEngine.Transform itemTransform;
    // field 18780, runtime offset 24, flags 0x6
    public UnityEngine.Transform itemTransform2;
    // field 18781, runtime offset 28, flags 0x1
    private bool isDragging;
    // field 18782, runtime offset 32, flags 0x1
    private UnityEngine.Vector2 initialTouchPosition;
    // field 18783, runtime offset 40, flags 0x1
    private UnityEngine.Quaternion initialRotation;
    // field 18784, runtime offset 56, flags 0x1
    private UnityEngine.Quaternion initialRotation2;
    // method 32679, 0x6000bb0
    void Start();
    // method 32680, 0x6000bb1
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32681, 0x6000bb2
    void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32682, 0x6000bb3
    void OnDrag(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32683, 0x6000bb4
    void Update();
    // method 32684, 0x6000bb5
    void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
    // method 32685, 0x6000bb6
    void OnDisable();
    // method 32686, 0x6000bb7
    void .ctor();
}

// TypeDefinition 4432, 0x2000201
class MVPReason : System.Enum {
    // field 18792, runtime offset 8, flags 0x606
    public int value__;
    // field 18793, runtime offset 0, flags 0x8056
    public static const MVPReason MostKills = 0;
    // field 18794, runtime offset 0, flags 0x8056
    public static const MVPReason MostDamage = 1;
    // field 18795, runtime offset 0, flags 0x8056
    public static const MVPReason PlantingBomb = 2;
    // field 18796, runtime offset 0, flags 0x8056
    public static const MVPReason DefusingBomb = 3;
}

// TypeDefinition 4433, 0x2000200
class RoundEndNotification : UnityEngine.MonoBehaviour {
    // field 18785, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image winningTeamBackgroundImage;
    // field 18786, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image winningTeamImage;
    // field 18787, runtime offset 24, flags 0x1
    private UnityEngine.Sprite ctSprite;
    // field 18788, runtime offset 28, flags 0x1
    private UnityEngine.Sprite tSprite;
    // field 18789, runtime offset 32, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 18790, runtime offset 36, flags 0x1
    private TMPro.TMP_Text title2Txt;
    // field 18791, runtime offset 40, flags 0x1
    private TMPro.TMP_Text randomMatchFactTxt;
    // method 32687, 0x6000bb8
    void Init(string winningTeam);
    // method 32688, 0x6000bb9
    Photon.Realtime.Player GetMVPPlayer(System.Collections.Generic.Dictionary<Photon.Realtime.Player, int> playerStats);
    // method 32689, 0x6000bba
    string GetRandomMatchFact();
    // method 32690, 0x6000bbb
    void .ctor();
    // method 32691, 0x6000bbc
    void <Init>b__8_0();
}

// TypeDefinition 4434, 0x2000203
class <>c__DisplayClass9_0 : object {
    // field 18803, runtime offset 8, flags 0x6
    public System.Action then;
    // method 32699, 0x6000bc4
    void .ctor();
    // method 32700, 0x6000bc5
    void <SetThis>b__0();
    // method 32701, 0x6000bc6
    void <SetThis>b__1();
}

// TypeDefinition 4435, 0x2000202
class ScreenTransition : UnityEngine.MonoBehaviour {
    // field 18797, runtime offset 0, flags 0x11
    private static bool remindedThisSession;
    // field 18798, runtime offset 16, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 18799, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform trasitionPart1;
    // field 18800, runtime offset 24, flags 0x1
    private UnityEngine.RectTransform reminder;
    // field 18801, runtime offset 28, flags 0x1
    private UnityEngine.RectTransform trasitionPart2;
    // field 18802, runtime offset 4, flags 0x16
    public static ScreenTransition instance;
    // method 32692, 0x6000bbd
    void OnPlayerSpawned();
    // method 32693, 0x6000bbe
    void Start();
    // method 32694, 0x6000bbf
    void Set(bool active, System.Action then);
    // method 32695, 0x6000bc0
    void SetThis(bool active, System.Action then);
    // method 32696, 0x6000bc1
    void .ctor();
    // method 32697, 0x6000bc2
    void <OnPlayerSpawned>b__6_0();
    // method 32698, 0x6000bc3
    void <OnPlayerSpawned>b__6_1();
}

// TypeDefinition 4436, 0x2000205
class SdkType : System.Enum {
    // field 18827, runtime offset 8, flags 0x606
    public int value__;
    // field 18828, runtime offset 0, flags 0x8056
    public static const SdkType Vanilla = 0;
    // field 18829, runtime offset 0, flags 0x8056
    public static const SdkType Poki = 1;
    // field 18830, runtime offset 0, flags 0x8056
    public static const SdkType CrazyGames = 2;
    // field 18831, runtime offset 0, flags 0x8056
    public static const SdkType Android = 3;
    // field 18832, runtime offset 0, flags 0x8056
    public static const SdkType Standalone = 4;
    // field 18833, runtime offset 0, flags 0x8056
    public static const SdkType iOS = 5;
    // field 18834, runtime offset 0, flags 0x8056
    public static const SdkType Discord = 6;
    // field 18835, runtime offset 0, flags 0x8056
    public static const SdkType MSN = 7;
}

// TypeDefinition 4437, 0x2000206
class GameType : System.Enum {
    // field 18836, runtime offset 8, flags 0x606
    public int value__;
    // field 18837, runtime offset 0, flags 0x8056
    public static const GameType Kour = 0;
    // field 18838, runtime offset 0, flags 0x8056
    public static const GameType KourStrike = 1;
    // field 18839, runtime offset 0, flags 0x8056
    public static const GameType KourZone = 2;
}

// TypeDefinition 4438, 0x2000207
class AdType : System.Enum {
    // field 18840, runtime offset 8, flags 0x606
    public int value__;
    // field 18841, runtime offset 0, flags 0x8056
    public static const AdType Midroll = 0;
    // field 18842, runtime offset 0, flags 0x8056
    public static const AdType Rewarded = 1;
}

// TypeDefinition 4439, 0x2000208
class BannerState : System.Enum {
    // field 18843, runtime offset 8, flags 0x606
    public int value__;
    // field 18844, runtime offset 0, flags 0x8056
    public static const BannerState Hidden = 0;
    // field 18845, runtime offset 0, flags 0x8056
    public static const BannerState Left = 1;
    // field 18846, runtime offset 0, flags 0x8056
    public static const BannerState Right = 2;
    // field 18847, runtime offset 0, flags 0x8056
    public static const BannerState Bottom = 3;
    // field 18848, runtime offset 0, flags 0x8056
    public static const BannerState TopLeft = 4;
    // field 18849, runtime offset 0, flags 0x8056
    public static const BannerState BottomRight = 5;
    // field 18850, runtime offset 0, flags 0x8056
    public static const BannerState BottomLeft = 6;
}

// TypeDefinition 4440, 0x2000209
class <>c : object {
    // field 18851, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18852, runtime offset 4, flags 0x16
    public static DG.Tweening.TweenCallback <>9__28_0;
    // method 32724, 0x6000bdd
    void .cctor();
    // method 32725, 0x6000bde
    void .ctor();
    // method 32726, 0x6000bdf
    void <Awake>b__28_0();
}

// TypeDefinition 4441, 0x2000204
class SdkManager : UnityEngine.MonoBehaviour {
    // field 18804, runtime offset 0, flags 0x8051
    private static const float deltaBetweenMidrolls = 90;
    // field 18805, runtime offset 0, flags 0x11
    private static float lastMidroll;
    // field 18806, runtime offset 0, flags 0x8051
    private static const float REWARDED_DELTA_ALLOWED = 4;
    // field 18807, runtime offset 0, flags 0x8056
    public static const int DEFAULT_KP_VANILLA = 100;
    // field 18808, runtime offset 0, flags 0x8056
    public static const int DEFAULT_KP_STANDALONE = 0;
    // field 18809, runtime offset 0, flags 0x8056
    public static const int DEFAULT_KP_POKI = 50;
    // field 18810, runtime offset 0, flags 0x8056
    public static const bool USE_NICE_GUEST_NAMES = true;
    // field 18811, runtime offset 4, flags 0x11
    private static bool gotGameplayStartThisSession;
    // field 18812, runtime offset 16, flags 0x6
    public bool htmlFocused;
    // field 18813, runtime offset 20, flags 0x6
    public SdkType sdkType;
    // field 18814, runtime offset 24, flags 0x6
    public GameType gameType;
    // field 18815, runtime offset 8, flags 0x16
    public static SdkManager Instance;
    // field 18816, runtime offset 12, flags 0x11
    private static bool inGameplay;
    // field 18817, runtime offset 28, flags 0x1
    private System.Action<bool> onAdFinished;
    // field 18818, runtime offset 16, flags 0x11
    private static float lastRewardedAdStartTime;
    // field 18819, runtime offset 20, flags 0x11
    private static BannerState lastBannerState1;
    // field 18820, runtime offset 24, flags 0x11
    private static BannerState lastBannerState2;
    // field 18821, runtime offset 28, flags 0x11
    private static BannerState lastBannerState3;
    // field 18822, runtime offset 32, flags 0x11
    private static BannerState currentBannerState1;
    // field 18823, runtime offset 36, flags 0x11
    private static BannerState currentBannerState2;
    // field 18824, runtime offset 40, flags 0x11
    private static BannerState currentBannerState3;
    // field 18825, runtime offset 44, flags 0x11
    private static bool verifiedEverDetected;
    // field 18826, runtime offset 32, flags 0x1
    private string[] allowedHosts;
    // method 32702, 0x6000bc7
    void OnHtmlFocus(string focusStr);
    // method 32703, 0x6000bc8
    float get_PrerollShowChance();
    // method 32704, 0x6000bc9
    bool get_ShowAdWhenGameEnds();
    // method 32705, 0x6000bca
    bool get_CanSetURLForLink();
    // method 32706, 0x6000bcb
    bool get_WatchAdForDailyReward();
    // method 32707, 0x6000bcc
    bool AccountsEnabled();
    // method 32708, 0x6000bcd
    bool UseRealLeaderboards();
    // method 32709, 0x6000bce
    void GameplayStart(bool force);
    // method 32710, 0x6000bcf
    void GameplayEnd();
    // method 32711, 0x6000bd0
    void Awake();
    // method 32712, 0x6000bd1
    void Start();
    // method 32713, 0x6000bd2
    void ShowAd(string sourceName, AdType adType, System.Action<bool> then);
    // method 32714, 0x6000bd3
    void OnDaReveresedFinishedJS(string result);
    // method 32715, 0x6000bd4
    void SetBannersToPreviousState();
    // method 32716, 0x6000bd5
    void SetBanners(BannerState set728x90, BannerState set300x250, BannerState set300x600);
    // method 32717, 0x6000bd6
    string GetAllAdsStateString();
    // method 32718, 0x6000bd7
    void VerifiedDetected();
    // method 32719, 0x6000bd8
    bool MidgameAdsEnabled();
    // method 32720, 0x6000bd9
    int MaxEmailFillMessages();
    // method 32721, 0x6000bda
    void CheckHost();
    // method 32722, 0x6000bdb
    void .ctor();
    // method 32723, 0x6000bdc
    void .cctor();
}

// TypeDefinition 4442, 0x200020b
class GameState : System.Enum {
    // field 18901, runtime offset 8, flags 0x606
    public int value__;
    // field 18902, runtime offset 0, flags 0x8056
    public static const GameState WaitingForPlayers = 0;
    // field 18903, runtime offset 0, flags 0x8056
    public static const GameState BuyPhase = 1;
    // field 18904, runtime offset 0, flags 0x8056
    public static const GameState ActionPhase = 2;
    // field 18905, runtime offset 0, flags 0x8056
    public static const GameState BombPlanted = 3;
    // field 18906, runtime offset 0, flags 0x8056
    public static const GameState RoundEnd = 4;
    // field 18907, runtime offset 0, flags 0x8056
    public static const GameState GameOver = 5;
}

// TypeDefinition 4443, 0x200020c
class <>c__DisplayClass13_0 : object {
    // field 18908, runtime offset 8, flags 0x6
    public int excludeActorNumber;
    // method 32785, 0x6000c1a
    void .ctor();
    // method 32786, 0x6000c1b
    bool <UpdateAlivePlayerImages>b__0(TeamMember p);
    // method 32787, 0x6000c1c
    bool <UpdateAlivePlayerImages>b__1(TeamMember p);
}

// TypeDefinition 4444, 0x200020d
class <>c__DisplayClass23_0 : object {
    // field 18909, runtime offset 8, flags 0x6
    public int soundIndex;
    // method 32788, 0x6000c1d
    void .ctor();
    // method 32789, 0x6000c1e
    void <PlaySound>b__0();
}

// TypeDefinition 4445, 0x200020e
class <>c__DisplayClass94_0 : object {
    // field 18910, runtime offset 8, flags 0x6
    public Photon.Pun.PhotonView pv;
    // field 18911, runtime offset 12, flags 0x6
    public SearchAndDestroyManager <>4__this;
    // method 32790, 0x6000c1f
    void .ctor();
    // method 32791, 0x6000c20
    bool <OnPlayerDied>b__0(Photon.Realtime.Player p);
    // method 32792, 0x6000c21
    bool <OnPlayerDied>b__1(TeamMember p);
}

// TypeDefinition 4446, 0x200020f
class <>c__DisplayClass99_0 : object {
    // field 18912, runtime offset 8, flags 0x6
    public UnityEngine.Rendering.PostProcessing.ColorGrading colorGrading;
    // method 32793, 0x6000c22
    void .ctor();
    // method 32794, 0x6000c23
    float <SetSaturation>b__0();
    // method 32795, 0x6000c24
    void <SetSaturation>b__1(float x);
    // method 32796, 0x6000c25
    float <SetSaturation>b__2();
    // method 32797, 0x6000c26
    void <SetSaturation>b__3(float x);
    // method 32798, 0x6000c27
    float <SetSaturation>b__4();
    // method 32799, 0x6000c28
    void <SetSaturation>b__5(float x);
    // method 32800, 0x6000c29
    float <SetSaturation>b__6();
    // method 32801, 0x6000c2a
    void <SetSaturation>b__7(float x);
}

// TypeDefinition 4447, 0x2000210
class <SendAliveMessageRoutine>d__69 : object {
    // field 18913, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 18914, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 18915, runtime offset 16, flags 0x1
    private ExitGames.Client.Photon.Hashtable <props>5__2;
    // method 32802, 0x6000c2b
    void .ctor(int <>1__state);
    // method 32803, 0x6000c2c
    void System.IDisposable.Dispose();
    // method 32804, 0x6000c2d
    bool MoveNext();
    // method 32805, 0x6000c2e
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32806, 0x6000c2f
    void System.Collections.IEnumerator.Reset();
    // method 32807, 0x6000c30
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4448, 0x200020a
class SearchAndDestroyManager : Photon.Pun.MonoBehaviourPunCallbacks {
    // field 18853, runtime offset 0, flags 0x8051
    private static const bool ALLOW_SWITCH_TEAM = false;
    // field 18854, runtime offset 0, flags 0x8051
    private static const int TEAM_WIN_AT_SCORE = 15;
    // field 18855, runtime offset 0, flags 0x8051
    private static const float ROUND_DURATION = 180;
    // field 18856, runtime offset 0, flags 0x8056
    public static const float BUY_PHASE_TIME = 10;
    // field 18857, runtime offset 20, flags 0x6
    public UnityEngine.Transform cameraFallbackOrierntation;
    // field 18858, runtime offset 0, flags 0x8051
    private static const int WIN_MONEY = 3250;
    // field 18859, runtime offset 0, flags 0x8051
    private static const int LOSE_MONEY = 1400;
    // field 18860, runtime offset 24, flags 0x6
    public UnityEngine.UI.Image flashImg;
    // field 18861, runtime offset 28, flags 0x1
    private UnityEngine.SpriteRenderer[] teammateMinimapSpriteRenderer;
    // field 18862, runtime offset 32, flags 0x1
    private BuyPhaseMenu BuyPhaseWindow;
    // field 18863, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image[] aliveTerrorImages;
    // field 18864, runtime offset 40, flags 0x1
    private UnityEngine.UI.Image[] aliveCounterTerrorImages;
    // field 18865, runtime offset 44, flags 0x1
    private RoundEndNotification roundEndNotification;
    // field 18866, runtime offset 48, flags 0x1
    private TeamMapMarker[] teamMapMarkers;
    // field 18867, runtime offset 52, flags 0x1
    private DG.Tweening.Sequence notificationSequence;
    // field 18868, runtime offset 56, flags 0x1
    private UnityEngine.RectTransform notificationRectTransform;
    // field 18869, runtime offset 60, flags 0x1
    private TMPro.TMP_Text notificationTxt;
    // field 18870, runtime offset 64, flags 0x1
    private UnityEngine.AudioSource audioSource;
    // field 18871, runtime offset 0, flags 0x8056
    public static const int START_MONEY = 800;
    // field 18872, runtime offset 68, flags 0x1
    private TMPro.TMP_Text moneyTxt;
    // field 18873, runtime offset 72, flags 0x1
    private UnityEngine.Transform minimapCamera;
    // field 18874, runtime offset 0, flags 0x8056
    public static const float STILL_ALLOW_BUY_TIME = 50;
    // field 18875, runtime offset 0, flags 0x16
    public static CodeStage.AntiCheat.ObscuredTypes.ObscuredInt _money;
    // field 18876, runtime offset 76, flags 0x1
    private BuyMenuCanvas buyMenuCanvas;
    // field 18877, runtime offset 80, flags 0x6
    public WorldBomb currentWorldBomb;
    // field 18878, runtime offset 84, flags 0x1
    private TMPro.TMP_Text currentRoundTxt;
    // field 18879, runtime offset 88, flags 0x1
    private TMPro.TMP_Text timerTxt;
    // field 18880, runtime offset 92, flags 0x1
    private UnityEngine.UI.Image defusingImage;
    // field 18881, runtime offset 96, flags 0x1
    private TMPro.TMP_Text defusingTxt;
    // field 18882, runtime offset 0, flags 0x8051
    private static const byte setBombEventCode = 2;
    // field 18883, runtime offset 0, flags 0x8051
    private static const int MIN_PLAYERS_FOR_START = 2;
    // field 18884, runtime offset 20, flags 0x16
    public static SearchAndDestroyManager Instance;
    // field 18885, runtime offset 100, flags 0x6
    public GameState currentGameState;
    // field 18886, runtime offset 104, flags 0x6
    public int currentBombHolder;
    // field 18887, runtime offset 112, flags 0x1
    private double roundStartTime;
    // field 18888, runtime offset 120, flags 0x1
    private bool masterClientHasSentStartMesage;
    // field 18889, runtime offset 124, flags 0x6
    public string currentTimerText;
    // field 18890, runtime offset 128, flags 0x1
    private bool checkedBackupAtMyLocationAudio;
    // field 18891, runtime offset 132, flags 0x1
    private float lastRoundEndTime;
    // field 18892, runtime offset 136, flags 0x1
    private bool isRequestingToOpenBuyMenu;
    // field 18893, runtime offset 0, flags 0x8056
    public static const float AimDurationMulti = 0.4000000059604645;
    // field 18894, runtime offset 0, flags 0x8056
    public static const float DEFUSE_TIME = 6.5;
    // field 18895, runtime offset 140, flags 0x1
    private GameState previousState;
    // field 18896, runtime offset 144, flags 0x1
    private double lastBombPlantTime;
    // field 18897, runtime offset 152, flags 0x6
    public string lastWinningTeam;
    // field 18898, runtime offset 156, flags 0x1
    private int lastRoundMoney;
    // field 18899, runtime offset 160, flags 0x1
    private int lastLastRoundMoney;
    // field 18900, runtime offset 164, flags 0x1
    private int[] lastSelectedWeapons;
    // method 32727, 0x6000be0
    void UpdateTeammateMinimapSpriteRendererColors();
    // method 32728, 0x6000be1
    void UpdateAlivePlayerImages(int kownTCount, int kownCTCount, int excludeActorNumber);
    // method 32729, 0x6000be2
    void AttachMapTracker(UnityEngine.Transform newTransform);
    // method 32730, 0x6000be3
    bool TryDetachMapTracker(UnityEngine.Transform newTransform);
    // method 32731, 0x6000be4
    void ShowNotification(string text, UnityEngine.Color c);
    // method 32732, 0x6000be5
    void PlaySound(int soundIndex, float delay);
    // method 32733, 0x6000be6
    void InstancePlaySound(int soundIndex);
    // method 32734, 0x6000be7
    void UpdateMapCameraTransform(UnityEngine.Transform with);
    // method 32735, 0x6000be8
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt get_money();
    // method 32736, 0x6000be9
    void set_money(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt value);
    // method 32737, 0x6000bea
    bool get_IsBuyMenuOpen();
    // method 32738, 0x6000beb
    void TryCloseBuyMenu();
    // method 32739, 0x6000bec
    void OnJoinedRoom();
    // method 32740, 0x6000bed
    void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 32741, 0x6000bee
    void OnRoomPropsUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged);
    // method 32742, 0x6000bef
    float get_START_AFTER_TIME();
    // method 32743, 0x6000bf0
    void set_START_AFTER_TIME(float value);
    // method 32744, 0x6000bf1
    double get_currentRoundTime();
    // method 32745, 0x6000bf2
    void Awake();
    // method 32746, 0x6000bf3
    void SuperSlowUpdate();
    // method 32747, 0x6000bf4
    void Start();
    // method 32748, 0x6000bf5
    void Update();
    // method 32749, 0x6000bf6
    void RequestToOpenBuyMenu();
    // method 32750, 0x6000bf7
    void UpdateCheckBuy();
    // method 32751, 0x6000bf8
    System.Collections.IEnumerator SendAliveMessageRoutine();
    // method 32752, 0x6000bf9
    void HandleTimer();
    // method 32753, 0x6000bfa
    void StartRoundReasonRoundEnded();
    // method 32754, 0x6000bfb
    void StartRound(string reasonText, int giveExtraMoneyToAll);
    // method 32755, 0x6000bfc
    void StartActionPhase(string reason);
    // method 32756, 0x6000bfd
    void EndRoundByTimer(string timerReason);
    // method 32757, 0x6000bfe
    void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer);
    // method 32758, 0x6000bff
    void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer);
    // method 32759, 0x6000c00
    void OnEvent(ExitGames.Client.Photon.EventData photonEvent);
    // method 32760, 0x6000c01
    int get_CurrentRound();
    // method 32761, 0x6000c02
    void SetGameState(string reasonForSet, GameState newState, object[] extraParams);
    // method 32762, 0x6000c03
    void OnStateChanged(int state, string reason, object[] extraParams);
    // method 32763, 0x6000c04
    void SetLastSelectedWeapons(int[] a);
    // method 32764, 0x6000c05
    UnityEngine.Transform GetSpawnPoint(Photon.Pun.UtilityScripts.PhotonTeam myTeam, bool justSwitchedTeam);
    // method 32765, 0x6000c06
    void TeleportMyPlayerToSpawnPoint(int planterId, Photon.Pun.UtilityScripts.PhotonTeam myKnownTeam, bool justSwitchedTeams);
    // method 32766, 0x6000c07
    void OnBombExploaded();
    // method 32767, 0x6000c08
    void OnPlayerDied(Photon.Pun.PhotonView pv);
    // method 32768, 0x6000c09
    int CountPlayerPhotonViews(Photon.Realtime.Player player);
    // method 32769, 0x6000c0a
    TeamMember[] SlowFunctionGetTeamMembers(Photon.Pun.UtilityScripts.PhotonTeam team);
    // method 32770, 0x6000c0b
    void OnBombDefuseUpdate(bool isMine, float valueSoFar, float defuseTime);
    // method 32771, 0x6000c0c
    void OnBombDefused();
    // method 32772, 0x6000c0d
    void SetSaturation(bool isBuy, float inSeconds);
    // method 32773, 0x6000c0e
    void OnStopDefuse();
    // method 32774, 0x6000c0f
    void .ctor();
    // method 32775, 0x6000c10
    void <ShowNotification>b__19_0();
    // method 32776, 0x6000c11
    void <Start>b__60_0();
    // method 32777, 0x6000c12
    void <Start>b__60_1();
    // method 32778, 0x6000c13
    void <OnPlayerEnteredRoom>b__75_0();
    // method 32779, 0x6000c14
    void <OnPlayerEnteredRoom>b__75_1();
    // method 32780, 0x6000c15
    void <OnPlayerLeftRoom>b__76_0();
    // method 32781, 0x6000c16
    void <OnPlayerLeftRoom>b__76_1();
    // method 32782, 0x6000c17
    void <OnStateChanged>b__88_0();
    // method 32783, 0x6000c18
    void <OnStateChanged>b__88_1();
    // method 32784, 0x6000c19
    void <OnStateChanged>b__88_2();
}

// TypeDefinition 4449, 0x2000212
class <>c__DisplayClass7_0 : object {
    // field 18923, runtime offset 8, flags 0x6
    public SelectItemButton <>4__this;
    // field 18924, runtime offset 12, flags 0x6
    public int index;
    // field 18925, runtime offset 16, flags 0x6
    public ItemSelectPanel from;
    // field 18926, runtime offset 20, flags 0x6
    public System.Action<int> onSelected;
    // field 18927, runtime offset 24, flags 0x6
    public UnityEngine.Events.UnityAction <>9__1;
    // method 32811, 0x6000c34
    void .ctor();
    // method 32812, 0x6000c35
    void <Init>b__0(UnityEngine.Texture2D x);
    // method 32813, 0x6000c36
    void <Init>b__1();
}

// TypeDefinition 4450, 0x2000211
class SelectItemButton : UnityEngine.MonoBehaviour {
    // field 18916, runtime offset 16, flags 0x1
    private TMPro.TMP_Text itemNameTxt;
    // field 18917, runtime offset 20, flags 0x1
    private TMPro.TMP_Text itemRarityTxt;
    // field 18918, runtime offset 24, flags 0x1
    private UnityEngine.UI.Image itemImage;
    // field 18919, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image selectButtonBackgroundRegular;
    // field 18920, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image selectButtonBackgroundBright;
    // field 18921, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image itemBackgroundImage;
    // field 18922, runtime offset 40, flags 0x1
    private UnityEngine.UI.Button[] buttons;
    // method 32808, 0x6000c31
    void Init(bool exists, ItemSelectPanel from, string itemName, ItemRarity itemRarity, string itemPath, int index, System.Action<int> onSelected);
    // method 32809, 0x6000c32
    void OnButtonPressed(int index, ItemSelectPanel from, System.Action<int> onSelected);
    // method 32810, 0x6000c33
    void .ctor();
}

// TypeDefinition 4451, 0x2000214
class <>c : object {
    // field 18936, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 18937, runtime offset 4, flags 0x16
    public static System.Action <>9__10_0;
    // field 18938, runtime offset 8, flags 0x16
    public static System.Action <>9__17_0;
    // method 32831, 0x6000c48
    void .cctor();
    // method 32832, 0x6000c49
    void .ctor();
    // method 32833, 0x6000c4a
    void <Close>b__10_0();
    // method 32834, 0x6000c4b
    void <OnModeChanged>b__17_0();
}

// TypeDefinition 4452, 0x2000213
class ServerFinderPanel : Popup {
    // field 18928, runtime offset 0, flags 0x8056
    public static const float PLAYERCOUNT_ADD_STATIC = 1000;
    // field 18929, runtime offset 0, flags 0x8056
    public static const float PLAYERCOUNT_MULTI_STATIC = 2;
    // field 18930, runtime offset 68, flags 0x1
    private ServerFinderRegionButton[] regionButtons;
    // field 18931, runtime offset 72, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 18932, runtime offset 76, flags 0x1
    private RegionRoomsHolder roomsHolder;
    // field 18933, runtime offset 0, flags 0x16
    public static int currentMapFilter;
    // field 18934, runtime offset 4, flags 0x16
    public static int currentModeFilter;
    // field 18935, runtime offset 80, flags 0x1
    private TMPro.TMP_Dropdown modeDropdown;
    // method 32814, 0x6000c37
    void ShowHostPanel(bool joinOption);
    // method 32815, 0x6000c38
    void ShowCustomGamesPanel();
    // method 32816, 0x6000c39
    void Start();
    // method 32817, 0x6000c3a
    void SlowUpdate();
    // method 32818, 0x6000c3b
    void Show();
    // method 32819, 0x6000c3c
    void Close(System.Action onFinished);
    // method 32820, 0x6000c3d
    void OnEnable();
    // method 32821, 0x6000c3e
    string GetSQLFilter();
    // method 32822, 0x6000c3f
    void OnMapChanged(int selectedIndex);
    // method 32823, 0x6000c40
    void OnModeChanged(int selectedIndex);
    // method 32824, 0x6000c41
    void RefreshFilters();
    // method 32825, 0x6000c42
    void RefreshRegionButtons(string selectedReadable);
    // method 32826, 0x6000c43
    void QuickPlay(string onReadableRegion);
    // method 32827, 0x6000c44
    void OnRegionButtonClicked(ServerFinderRegionButton btn);
    // method 32828, 0x6000c45
    bool get_isLoadingSomething();
    // method 32829, 0x6000c46
    void .ctor();
    // method 32830, 0x6000c47
    void .cctor();
}

// TypeDefinition 4453, 0x2000216
class <>c__DisplayClass5_0 : object {
    // field 18944, runtime offset 8, flags 0x6
    public System.Action<ServerFinderRegionButton> onClickThis;
    // field 18945, runtime offset 12, flags 0x6
    public ServerFinderRegionButton <>4__this;
    // field 18946, runtime offset 16, flags 0x6
    public System.Action<string> onQuickPlay;
    // field 18947, runtime offset 20, flags 0x6
    public string currentSelectedRegion;
    // method 32838, 0x6000c4f
    void .ctor();
    // method 32839, 0x6000c50
    void <Init>b__0();
    // method 32840, 0x6000c51
    void <Init>b__1();
}

// TypeDefinition 4454, 0x2000215
class ServerFinderRegionButton : UnityEngine.UI.Button {
    // field 18939, runtime offset 184, flags 0x1
    private UnityEngine.UI.Button quickJoinButton;
    // field 18940, runtime offset 188, flags 0x1
    private TMPro.TMP_Text activePlayersTxt;
    // field 18941, runtime offset 192, flags 0x6
    public TMPro.TMP_Text regionNameTxt;
    // field 18942, runtime offset 196, flags 0x6
    public UnityEngine.UI.Image triangle;
    // field 18943, runtime offset 200, flags 0x6
    public bool isToggled;
    // method 32835, 0x6000c4c
    void Init(string currentSelectedRegion, System.Action<ServerFinderRegionButton> onClickThis, System.Action<string> onQuickPlay);
    // method 32836, 0x6000c4d
    void Toggle(out bool _isToggled, out string myRegionReadable);
    // method 32837, 0x6000c4e
    void .ctor();
}

// TypeDefinition 4455, 0x2000218
class <>c__DisplayClass5_0 : object {
    // field 18953, runtime offset 8, flags 0x6
    public System.Action<Photon.Realtime.RoomInfo> onPress;
    // field 18954, runtime offset 12, flags 0x6
    public Photon.Realtime.RoomInfo roomInfo;
    // method 32843, 0x6000c54
    void .ctor();
    // method 32844, 0x6000c55
    void <Init>b__0();
}

// TypeDefinition 4456, 0x2000217
class ServerFinderRoomButton : UnityEngine.UI.Button {
    // field 18948, runtime offset 184, flags 0x1
    private TMPro.TMP_Text joinBtnTxt;
    // field 18949, runtime offset 188, flags 0x1
    private TMPro.TMP_Text roomNameTxt;
    // field 18950, runtime offset 192, flags 0x1
    private TMPro.TMP_Text roomNicknameTxt;
    // field 18951, runtime offset 196, flags 0x1
    private TMPro.TMP_Text playerCountTxt;
    // field 18952, runtime offset 200, flags 0x1
    private UnityEngine.GameObject lineSeparator;
    // method 32841, 0x6000c52
    void Init(bool roomExists, bool enableSep, Photon.Realtime.RoomInfo roomInfo, System.Action<Photon.Realtime.RoomInfo> onPress);
    // method 32842, 0x6000c53
    void .ctor();
}

// TypeDefinition 4457, 0x200021a
class <>c__DisplayClass3_0 : object {
    // field 18957, runtime offset 8, flags 0x6
    public UnityEngine.UI.Image image;
    // field 18958, runtime offset 12, flags 0x6
    public string sequenceTag;
    // method 32849, 0x6000c5a
    void .ctor();
    // method 32850, 0x6000c5b
    void <SetImageLoad>b__0(UnityEngine.Texture2D x);
}

// TypeDefinition 4458, 0x200021b
class <>c__DisplayClass4_0 : object {
    // field 18959, runtime offset 8, flags 0x6
    public UnityEngine.UI.RawImage image;
    // field 18960, runtime offset 12, flags 0x6
    public string sequenceTag;
    // method 32851, 0x6000c5c
    void .ctor();
    // method 32852, 0x6000c5d
    void <SetImageLoad>b__0(UnityEngine.Texture2D x);
}

// TypeDefinition 4459, 0x2000219
class SetMyImage : UnityEngine.MonoBehaviour {
    // field 18955, runtime offset 16, flags 0x1
    private string iconPath;
    // field 18956, runtime offset 20, flags 0x1
    private bool force;
    // method 32845, 0x6000c56
    void Start();
    // method 32846, 0x6000c57
    void SetImageLoad(string fullURL, UnityEngine.UI.Image image, UnityEngine.FilterMode filterMode, int customSize, bool animate);
    // method 32847, 0x6000c58
    void SetImageLoad(string path, UnityEngine.UI.RawImage image, UnityEngine.FilterMode filterMode, int customSize, bool animate);
    // method 32848, 0x6000c59
    void .ctor();
}

// TypeDefinition 4460, 0x200021d
class <>c : object {
    // field 19021, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19022, runtime offset 4, flags 0x16
    public static System.Action <>9__66_0;
    // field 19023, runtime offset 8, flags 0x16
    public static System.Action <>9__84_0;
    // field 19024, runtime offset 12, flags 0x16
    public static System.Func<Setup, bool> <>9__88_0;
    // field 19025, runtime offset 16, flags 0x16
    public static System.Func<Setup, bool> <>9__90_0;
    // field 19026, runtime offset 20, flags 0x16
    public static System.Func<Shooter, bool> <>9__92_0;
    // field 19027, runtime offset 24, flags 0x16
    public static System.Func<Setup, bool> <>9__95_0;
    // field 19028, runtime offset 28, flags 0x16
    public static System.Func<Setup, bool> <>9__97_0;
    // field 19029, runtime offset 32, flags 0x16
    public static System.Action <>9__115_0;
    // field 19030, runtime offset 36, flags 0x16
    public static System.Action <>9__115_1;
    // field 19031, runtime offset 40, flags 0x16
    public static System.Action <>9__115_2;
    // method 32916, 0x6000c9d
    void .cctor();
    // method 32917, 0x6000c9e
    void .ctor();
    // method 32918, 0x6000c9f
    void <ResetAll>b__66_0();
    // method 32919, 0x6000ca0
    void <SetRegion>b__84_0();
    // method 32920, 0x6000ca1
    bool <SetHUDScale>b__88_0(Setup x);
    // method 32921, 0x6000ca2
    bool <SetHUDScale>b__90_0(Setup x);
    // method 32922, 0x6000ca3
    bool <SetRenderDistance>b__92_0(Shooter x);
    // method 32923, 0x6000ca4
    bool <SetScopeScale>b__95_0(Setup x);
    // method 32924, 0x6000ca5
    bool <SetSniperScopeLink>b__97_0(Setup x);
    // method 32925, 0x6000ca6
    void <SetDisableTextures>b__115_0();
    // method 32926, 0x6000ca7
    void <SetDisableTextures>b__115_1();
    // method 32927, 0x6000ca8
    void <SetDisableTextures>b__115_2();
}

// TypeDefinition 4461, 0x200021e
class <>c__DisplayClass102_0 : object {
    // field 19032, runtime offset 8, flags 0x6
    public bool v;
    // method 32928, 0x6000ca9
    void .ctor();
    // method 32929, 0x6000caa
    void <SetShadows>b__0();
    // method 32930, 0x6000cab
    void <SetShadows>b__1();
}

// TypeDefinition 4462, 0x200021f
class <>c__DisplayClass113_0 : object {
    // field 19033, runtime offset 8, flags 0x6
    public int q;
    // field 19034, runtime offset 12, flags 0x6
    public SettingsPanel <>4__this;
    // method 32931, 0x6000cac
    void .ctor();
    // method 32932, 0x6000cad
    void <SetQuality>b__0();
}

// TypeDefinition 4463, 0x2000220
class <IenuRefreshIn>d__117 : object {
    // field 19035, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19036, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19037, runtime offset 16, flags 0x6
    public float t;
    // method 32933, 0x6000cae
    void .ctor(int <>1__state);
    // method 32934, 0x6000caf
    void System.IDisposable.Dispose();
    // method 32935, 0x6000cb0
    bool MoveNext();
    // method 32936, 0x6000cb1
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32937, 0x6000cb2
    void System.Collections.IEnumerator.Reset();
    // method 32938, 0x6000cb3
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4464, 0x2000221
class <IenuSetRegionTextAgain>d__76 : object {
    // field 19038, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19039, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19040, runtime offset 16, flags 0x6
    public SettingsPanel <>4__this;
    // field 19041, runtime offset 20, flags 0x6
    public string txt;
    // method 32939, 0x6000cb4
    void .ctor(int <>1__state);
    // method 32940, 0x6000cb5
    void System.IDisposable.Dispose();
    // method 32941, 0x6000cb6
    bool MoveNext();
    // method 32942, 0x6000cb7
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32943, 0x6000cb8
    void System.Collections.IEnumerator.Reset();
    // method 32944, 0x6000cb9
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4465, 0x2000222
class <IenuSetResolutionScale>d__71 : object {
    // field 19042, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19043, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19044, runtime offset 16, flags 0x6
    public SettingsPanel <>4__this;
    // field 19045, runtime offset 20, flags 0x6
    public float x;
    // field 19046, runtime offset 24, flags 0x1
    private bool <wereActive>5__2;
    // method 32945, 0x6000cba
    void .ctor(int <>1__state);
    // method 32946, 0x6000cbb
    void System.IDisposable.Dispose();
    // method 32947, 0x6000cbc
    bool MoveNext();
    // method 32948, 0x6000cbd
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32949, 0x6000cbe
    void System.Collections.IEnumerator.Reset();
    // method 32950, 0x6000cbf
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4466, 0x2000223
class <IenuUpdateLayoutGroup>d__73 : object {
    // field 19047, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19048, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19049, runtime offset 16, flags 0x6
    public UnityEngine.UI.LayoutGroup which;
    // field 19050, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform <recttransformOfTheLayoutgroup>5__2;
    // method 32951, 0x6000cc0
    void .ctor(int <>1__state);
    // method 32952, 0x6000cc1
    void System.IDisposable.Dispose();
    // method 32953, 0x6000cc2
    bool MoveNext();
    // method 32954, 0x6000cc3
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32955, 0x6000cc4
    void System.Collections.IEnumerator.Reset();
    // method 32956, 0x6000cc5
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4467, 0x200021c
class SettingsPanel : Popup {
    // field 18961, runtime offset 68, flags 0x1
    private UnityEngine.GameObject[] hideForCg;
    // field 18962, runtime offset 72, flags 0x1
    private UnityEngine.GameObject keybindSlotPrefab;
    // field 18963, runtime offset 76, flags 0x1
    private UnityEngine.Transform keybindSlotContainer;
    // field 18964, runtime offset 80, flags 0x1
    private bool createdKeybindSlots;
    // field 18965, runtime offset 0, flags 0x8056
    public static const int DEFAULT_MOUSE_ACCELERATION = 0;
    // field 18966, runtime offset 0, flags 0x8056
    public static const float DEFAULT_RENDER_SCALE_WEB = 0.8999999761581421;
    // field 18967, runtime offset 0, flags 0x8056
    public static const float DEFAULT_VIGNETTE = 0.6000000238418579;
    // field 18968, runtime offset 0, flags 0x8056
    public static const float DEFAULT_RENDER_DISTANCE = 270;
    // field 18969, runtime offset 84, flags 0x1
    private TMPro.TMP_Text renderDistanceTxt;
    // field 18970, runtime offset 88, flags 0x1
    private TMPro.TMP_Text hudScaleSliderTxt;
    // field 18971, runtime offset 92, flags 0x1
    private UnityEngine.UI.Slider hudScaleSlider;
    // field 18972, runtime offset 96, flags 0x1
    private UnityEngine.UI.Slider vignetteSlider;
    // field 18973, runtime offset 100, flags 0x1
    private TMPro.TMP_Text vignetteTxt;
    // field 18974, runtime offset 104, flags 0x1
    private UnityEngine.UI.Slider renderDistanceSlider;
    // field 18975, runtime offset 108, flags 0x1
    private UnityEngine.UI.Toggle disableTexturesToggle;
    // field 18976, runtime offset 112, flags 0x1
    private UnityEngine.GameObject[] hideForMobile;
    // field 18977, runtime offset 116, flags 0x1
    private UnityEngine.UI.InputField crosshairLinkIF;
    // field 18978, runtime offset 120, flags 0x1
    private UnityEngine.UI.InputField sniperScopeLinkIF;
    // field 18979, runtime offset 124, flags 0x1
    private TMPro.TMP_Text sniperScopeSizeTxt;
    // field 18980, runtime offset 128, flags 0x1
    private TMPro.TMP_Text uidTxt;
    // field 18981, runtime offset 132, flags 0x1
    private TMPro.TMP_Text appTxt;
    // field 18982, runtime offset 136, flags 0x1
    private TMPro.TMP_Text devTxt;
    // field 18983, runtime offset 140, flags 0x1
    private TMPro.TMP_Text versionTxt;
    // field 18984, runtime offset 144, flags 0x1
    private TMPro.TMP_Text sdkTxt;
    // field 18985, runtime offset 148, flags 0x1
    private TMPro.TMP_Text photonVersionTxt;
    // field 18986, runtime offset 152, flags 0x1
    private TMPro.TMP_Text mouseSenseTxt;
    // field 18987, runtime offset 156, flags 0x1
    private UnityEngine.GameObject[] resolutionMustRefreshAlerts;
    // field 18988, runtime offset 160, flags 0x1
    private UnityEngine.UI.LayoutGroup[] resolutionSliderLayoutGroups;
    // field 18989, runtime offset 164, flags 0x1
    private TMPro.TMP_Text resolutionValueTxt;
    // field 18990, runtime offset 168, flags 0x1
    private TMPro.TMP_Text fovValueTxt;
    // field 18991, runtime offset 172, flags 0x1
    private TMPro.TMP_Text crosshairValueTxt;
    // field 18992, runtime offset 176, flags 0x1
    private UnityEngine.UI.Slider resolutionSlider;
    // field 18993, runtime offset 180, flags 0x1
    private UnityEngine.UI.Slider fovSlider;
    // field 18994, runtime offset 184, flags 0x1
    private UnityEngine.UI.Slider crosshairSlider;
    // field 18995, runtime offset 188, flags 0x1
    private UnityEngine.GameObject waitingForKeyPanel;
    // field 18996, runtime offset 192, flags 0x6
    public UnityEngine.GameObject[] qualityButtonBorders;
    // field 18997, runtime offset 196, flags 0x1
    private TMPro.TMP_Text[] keyTexts;
    // field 18998, runtime offset 200, flags 0x1
    private UnityEngine.UI.Slider volSlider;
    // field 18999, runtime offset 204, flags 0x1
    private TMPro.TMP_Text volSliderTxt;
    // field 19000, runtime offset 208, flags 0x1
    private UnityEngine.UI.Slider musicVolSlider;
    // field 19001, runtime offset 212, flags 0x1
    private UnityEngine.UI.Slider mouseFlickSlider;
    // field 19002, runtime offset 216, flags 0x1
    private TMPro.TMP_Text mouseFlickTxt;
    // field 19003, runtime offset 220, flags 0x1
    private TMPro.TMP_Text musicVolSliderTxt;
    // field 19004, runtime offset 224, flags 0x1
    private TMPro.TMP_Dropdown regionDropdown;
    // field 19005, runtime offset 228, flags 0x1
    private UnityEngine.UI.Slider senseSlider;
    // field 19006, runtime offset 232, flags 0x1
    private UnityEngine.UI.Toggle devOptionsToggle;
    // field 19007, runtime offset 236, flags 0x1
    private UnityEngine.UI.Toggle mouseAccelerationToggle;
    // field 19008, runtime offset 240, flags 0x1
    private UnityEngine.UI.Toggle muzzleFlashToggle;
    // field 19009, runtime offset 244, flags 0x1
    private UnityEngine.UI.Toggle bulletHolesToggle;
    // field 19010, runtime offset 248, flags 0x1
    private UnityEngine.UI.Toggle motionBlurToggle;
    // field 19011, runtime offset 252, flags 0x1
    private UnityEngine.UI.Toggle renderWeaponToggle;
    // field 19012, runtime offset 256, flags 0x1
    private UnityEngine.UI.Toggle ragdollsToggle;
    // field 19013, runtime offset 260, flags 0x1
    private UnityEngine.UI.Toggle uiAnimationsToggle;
    // field 19014, runtime offset 264, flags 0x1
    private UnityEngine.UI.Toggle showRankPanelSoonToggle;
    // field 19015, runtime offset 268, flags 0x1
    private UnityEngine.UI.Toggle shadowsToggle;
    // field 19016, runtime offset 272, flags 0x1
    private UnityEngine.UI.Toggle ssccToggle;
    // field 19017, runtime offset 276, flags 0x1
    private UnityEngine.UI.Toggle inGameLeaderboardToggle;
    // field 19018, runtime offset 0, flags 0x11
    private static SettingsPanel instance;
    // field 19019, runtime offset 280, flags 0x1
    private UnityEngine.UI.Slider sniperScaleSlider;
    // field 19020, runtime offset 4, flags 0x16
    public static float CurrentRenderScaleWeb;
    // method 32853, 0x6000c5e
    void CreateKeybindSlots();
    // method 32854, 0x6000c5f
    float get_DEFAULT_MOUSE_FLICK_FIX();
    // method 32855, 0x6000c60
    float get_DefaultVolume();
    // method 32856, 0x6000c61
    void Show();
    // method 32857, 0x6000c62
    void Close(System.Action onfinish);
    // method 32858, 0x6000c63
    void ResetAll();
    // method 32859, 0x6000c64
    void OnResolutionSliderChanged(float newRes);
    // method 32860, 0x6000c65
    void OnFOVChanged(float _newFov);
    // method 32861, 0x6000c66
    void OnEnable();
    // method 32862, 0x6000c67
    void OnCrosshairScaleChanged(float newCrosshairScale);
    // method 32863, 0x6000c68
    System.Collections.IEnumerator IenuSetResolutionScale(float x);
    // method 32864, 0x6000c69
    void UpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 32865, 0x6000c6a
    System.Collections.IEnumerator IenuUpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 32866, 0x6000c6b
    bool TryGetInstance(out SettingsPanel _instance);
    // method 32867, 0x6000c6c
    void OnConnected(string currentRegionToken);
    // method 32868, 0x6000c6d
    System.Collections.IEnumerator IenuSetRegionTextAgain(string txt);
    // method 32869, 0x6000c6e
    int RegionTokenToIndex(string token);
    // method 32870, 0x6000c6f
    string RegionIndexToToken(int i);
    // method 32871, 0x6000c70
    string RegionTokenToReadable(string token);
    // method 32872, 0x6000c71
    string RegionReadableToToken(string readable);
    // method 32873, 0x6000c72
    void Start();
    // method 32874, 0x6000c73
    void UpdateSettingsUI();
    // method 32875, 0x6000c74
    void SetRegion(int v);
    // method 32876, 0x6000c75
    void ChangeKeyBinding(int actionIndex);
    // method 32877, 0x6000c76
    void ResetKeybinds();
    // method 32878, 0x6000c77
    void OnHUDChanged(float v);
    // method 32879, 0x6000c78
    void SetHUDScale(float v);
    // method 32880, 0x6000c79
    void SetVignette(float v);
    // method 32881, 0x6000c7a
    void SetHUDScale(UnityEngine.UI.Slider s);
    // method 32882, 0x6000c7b
    void SetMasterVoume(float v);
    // method 32883, 0x6000c7c
    void SetRenderDistance(float v);
    // method 32884, 0x6000c7d
    void SetMusicVolume(float v);
    // method 32885, 0x6000c7e
    void SetMouseFlick(float v);
    // method 32886, 0x6000c7f
    void SetScopeScale(float v);
    // method 32887, 0x6000c80
    void SetCustomCrosshairLink(string x);
    // method 32888, 0x6000c81
    void SetSniperScopeLink(string x);
    // method 32889, 0x6000c82
    void SetSense(float v);
    // method 32890, 0x6000c83
    void SetDeveloperOptions(bool v);
    // method 32891, 0x6000c84
    void SetMouseAcceleration(bool v);
    // method 32892, 0x6000c85
    void SetMuzzleFlash(bool v);
    // method 32893, 0x6000c86
    void SetShadows(bool v);
    // method 32894, 0x6000c87
    void SetBulletHoles(bool v);
    // method 32895, 0x6000c88
    void SetRagdolls(bool v);
    // method 32896, 0x6000c89
    void SetInGameLeaderboard(bool v);
    // method 32897, 0x6000c8a
    void SetUIAnimations(bool v);
    // method 32898, 0x6000c8b
    void SetShowRankProgressSoon(bool v);
    // method 32899, 0x6000c8c
    void SetSSCC(bool v);
    // method 32900, 0x6000c8d
    void OnSettingsChanged();
    // method 32901, 0x6000c8e
    void SetMotionBlur(bool v);
    // method 32902, 0x6000c8f
    void StaticRenderWeapon(bool v, string p);
    // method 32903, 0x6000c90
    void SetRenderWeapon(bool v);
    // method 32904, 0x6000c91
    void SetQuality(int q);
    // method 32905, 0x6000c92
    void ForceSetQuality(int q);
    // method 32906, 0x6000c93
    void SetDisableTextures(bool disableTextures);
    // method 32907, 0x6000c94
    void SetVeryLowGraphicsMode();
    // method 32908, 0x6000c95
    System.Collections.IEnumerator IenuRefreshIn(float t);
    // method 32909, 0x6000c96
    void EnterKourEditor();
    // method 32910, 0x6000c97
    void .ctor();
    // method 32911, 0x6000c98
    void .cctor();
    // method 32912, 0x6000c99
    void <ResetKeybinds>b__86_0();
    // method 32913, 0x6000c9a
    void <SetDisableTextures>b__115_3();
    // method 32914, 0x6000c9b
    void <SetVeryLowGraphicsMode>b__116_0();
    // method 32915, 0x6000c9c
    void <SetVeryLowGraphicsMode>b__116_1();
}

// TypeDefinition 4468, 0x2000225
class <DownloadSniperScopeImage>d__28 : object {
    // field 19071, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19072, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19073, runtime offset 16, flags 0x6
    public string imageUrl;
    // field 19074, runtime offset 20, flags 0x6
    public Setup <>4__this;
    // field 19075, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <request>5__2;
    // method 32969, 0x6000cd2
    void .ctor(int <>1__state);
    // method 32970, 0x6000cd3
    void System.IDisposable.Dispose();
    // method 32971, 0x6000cd4
    bool MoveNext();
    // method 32972, 0x6000cd5
    void <>m__Finally1();
    // method 32973, 0x6000cd6
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32974, 0x6000cd7
    void System.Collections.IEnumerator.Reset();
    // method 32975, 0x6000cd8
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4469, 0x2000226
class <UpdateLayoutGroup>d__24 : object {
    // field 19076, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19077, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19078, runtime offset 16, flags 0x6
    public Setup <>4__this;
    // method 32976, 0x6000cd9
    void .ctor(int <>1__state);
    // method 32977, 0x6000cda
    void System.IDisposable.Dispose();
    // method 32978, 0x6000cdb
    bool MoveNext();
    // method 32979, 0x6000cdc
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 32980, 0x6000cdd
    void System.Collections.IEnumerator.Reset();
    // method 32981, 0x6000cde
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4470, 0x2000224
class Setup : Photon.Pun.MonoBehaviourPun {
    // field 19051, runtime offset 20, flags 0x1
    private UnityEngine.Behaviour[] destroyForOthersAwake;
    // field 19052, runtime offset 24, flags 0x1
    private UnityEngine.Behaviour[] enableForMeAwake;
    // field 19053, runtime offset 28, flags 0x1
    private UnityEngine.ParticleSystem[] smokeFists;
    // field 19054, runtime offset 32, flags 0x1
    private CMF.SmoothPosition gfxSmoothPosition;
    // field 19055, runtime offset 36, flags 0x1
    private UnityEngine.UI.CanvasScaler[] hudCanvases;
    // field 19056, runtime offset 40, flags 0x1
    private UnityEngine.Collider[] myColliders;
    // field 19057, runtime offset 44, flags 0x1
    private FallingCamera fallingCamera;
    // field 19058, runtime offset 48, flags 0x1
    private UnityEngine.Camera myCamera;
    // field 19059, runtime offset 52, flags 0x1
    private UnityEngine.GameObject globalTrail;
    // field 19060, runtime offset 56, flags 0x1
    private TMPro.TMP_Text nickNameTxt;
    // field 19061, runtime offset 60, flags 0x1
    private UnityEngine.UI.LayoutGroup levelLayoutGroup;
    // field 19062, runtime offset 64, flags 0x1
    private TMPro.TMP_Text levelTxt;
    // field 19063, runtime offset 68, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 19064, runtime offset 72, flags 0x1
    private UnityEngine.Behaviour[] disableForOthers;
    // field 19065, runtime offset 76, flags 0x1
    private UnityEngine.GameObject[] layerable;
    // field 19066, runtime offset 80, flags 0x1
    private UnityEngine.GameObject[] destroyForOthersGO;
    // field 19067, runtime offset 84, flags 0x1
    private UnityEngine.GameObject[] destroyForMeGO;
    // field 19068, runtime offset 88, flags 0x1
    private UnityEngine.GameObject[] hideForMeGO;
    // field 19069, runtime offset 92, flags 0x1
    private UnityEngine.GameObject sniperScopeParent;
    // field 19070, runtime offset 96, flags 0x1
    private UnityEngine.Coroutine sniperScopeCoroutine;
    // method 32957, 0x6000cc6
    void SetGfxSmoothPosition(bool enable);
    // method 32958, 0x6000cc7
    void StopSmokeFists();
    // method 32959, 0x6000cc8
    void KillSmokeFists();
    // method 32960, 0x6000cc9
    void SetHUDScale();
    // method 32961, 0x6000cca
    void Awake();
    // method 32962, 0x6000ccb
    System.Collections.IEnumerator UpdateLayoutGroup();
    // method 32963, 0x6000ccc
    void Start();
    // method 32964, 0x6000ccd
    void SniperScope(string imageUrl);
    // method 32965, 0x6000cce
    System.Collections.IEnumerator DownloadSniperScopeImage(string imageUrl);
    // method 32966, 0x6000ccf
    void OnSniperScale(float knownScale);
    // method 32967, 0x6000cd0
    void Land();
    // method 32968, 0x6000cd1
    void .ctor();
}

// TypeDefinition 4471, 0x2000228
class <>c : object {
    // field 19170, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19171, runtime offset 4, flags 0x16
    public static System.Func<bool> <>9__89_0;
    // field 19172, runtime offset 8, flags 0x16
    public static System.Action<string> <>9__128_2;
    // method 33056, 0x6000d29
    void .cctor();
    // method 33057, 0x6000d2a
    void .ctor();
    // method 33058, 0x6000d2b
    bool <IenuWaitForMapSettings>b__89_0();
    // method 33059, 0x6000d2c
    void <OnKilled>b__128_2(string res);
}

// TypeDefinition 4472, 0x2000229
class <>c__DisplayClass139_0 : object {
    // field 19173, runtime offset 8, flags 0x6
    public Shooter <>4__this;
    // field 19174, runtime offset 12, flags 0x6
    public int meshIndex;
    // field 19175, runtime offset 16, flags 0x6
    public bool isTransparent;
    // method 33060, 0x6000d2d
    void .ctor();
    // method 33061, 0x6000d2e
    void <SetWeapon>b__0(UnityEngine.Texture2D x);
}

// TypeDefinition 4473, 0x200022a
class <>c__DisplayClass154_0 : object {
    // field 19176, runtime offset 8, flags 0x6
    public float flashStrength;
    // method 33062, 0x6000d2f
    void .ctor();
    // method 33063, 0x6000d30
    void <OnFlash>b__0();
}

// TypeDefinition 4474, 0x200022b
class <>c__DisplayClass8_0 : object {
    // field 19177, runtime offset 8, flags 0x6
    public Shooter <>4__this;
    // field 19178, runtime offset 12, flags 0x6
    public UnityEngine.Vector3 position;
    // field 19179, runtime offset 24, flags 0x6
    public UnityEngine.Quaternion rotation;
    // field 19180, runtime offset 40, flags 0x6
    public float wait;
    // field 19181, runtime offset 44, flags 0x6
    public DG.Tweening.TweenCallback <>9__2;
    // field 19182, runtime offset 48, flags 0x6
    public DG.Tweening.TweenCallback <>9__1;
    // method 33064, 0x6000d31
    void .ctor();
    // method 33065, 0x6000d32
    void <TeleportTo>b__0();
    // method 33066, 0x6000d33
    void <TeleportTo>b__1();
    // method 33067, 0x6000d34
    void <TeleportTo>b__2();
}

// TypeDefinition 4475, 0x200022c
class <>c__DisplayClass93_0 : object {
    // field 19183, runtime offset 8, flags 0x6
    public Photon.Pun.UtilityScripts.PhotonTeam myTeam;
    // method 33068, 0x6000d35
    void .ctor();
    // method 33069, 0x6000d36
    bool <UpdateCanSwitchTeam>b__0(Photon.Pun.UtilityScripts.PhotonTeam team);
}

// TypeDefinition 4476, 0x200022d
class <IenuDisableHitmarks>d__130 : object {
    // field 19184, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19185, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19186, runtime offset 16, flags 0x6
    public Hitmark hitmark;
    // field 19187, runtime offset 20, flags 0x6
    public WorldHitmark worldHitmark;
    // method 33070, 0x6000d37
    void .ctor(int <>1__state);
    // method 33071, 0x6000d38
    void System.IDisposable.Dispose();
    // method 33072, 0x6000d39
    bool MoveNext();
    // method 33073, 0x6000d3a
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33074, 0x6000d3b
    void System.Collections.IEnumerator.Reset();
    // method 33075, 0x6000d3c
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4477, 0x200022e
class <IenuOnShotPanel>d__117 : object {
    // field 19188, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19189, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19190, runtime offset 16, flags 0x6
    public Shooter <>4__this;
    // method 33076, 0x6000d3d
    void .ctor(int <>1__state);
    // method 33077, 0x6000d3e
    void System.IDisposable.Dispose();
    // method 33078, 0x6000d3f
    bool MoveNext();
    // method 33079, 0x6000d40
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33080, 0x6000d41
    void System.Collections.IEnumerator.Reset();
    // method 33081, 0x6000d42
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4478, 0x200022f
class <IenuReload>d__121 : object {
    // field 19191, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19192, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19193, runtime offset 16, flags 0x6
    public Shooter <>4__this;
    // field 19194, runtime offset 20, flags 0x6
    public float reloadTime;
    // field 19195, runtime offset 24, flags 0x1
    private float <startReloadTime>5__2;
    // method 33082, 0x6000d43
    void .ctor(int <>1__state);
    // method 33083, 0x6000d44
    void System.IDisposable.Dispose();
    // method 33084, 0x6000d45
    bool MoveNext();
    // method 33085, 0x6000d46
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33086, 0x6000d47
    void System.Collections.IEnumerator.Reset();
    // method 33087, 0x6000d48
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4479, 0x2000230
class <IenuShootAgain>d__114 : object {
    // field 19196, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19197, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19198, runtime offset 16, flags 0x6
    public float afterTime;
    // field 19199, runtime offset 20, flags 0x6
    public Shooter <>4__this;
    // field 19200, runtime offset 24, flags 0x6
    public int burstRecursive;
    // method 33088, 0x6000d49
    void .ctor(int <>1__state);
    // method 33089, 0x6000d4a
    void System.IDisposable.Dispose();
    // method 33090, 0x6000d4b
    bool MoveNext();
    // method 33091, 0x6000d4c
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33092, 0x6000d4d
    void System.Collections.IEnumerator.Reset();
    // method 33093, 0x6000d4e
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4480, 0x2000231
class <IenuWaitForMapSettings>d__89 : object {
    // field 19201, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19202, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19203, runtime offset 16, flags 0x6
    public Shooter <>4__this;
    // method 33094, 0x6000d4f
    void .ctor(int <>1__state);
    // method 33095, 0x6000d50
    void System.IDisposable.Dispose();
    // method 33096, 0x6000d51
    bool MoveNext();
    // method 33097, 0x6000d52
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33098, 0x6000d53
    void System.Collections.IEnumerator.Reset();
    // method 33099, 0x6000d54
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4481, 0x2000227
class Shooter : Photon.Pun.MonoBehaviourPun {
    // field 19079, runtime offset 0, flags 0x16
    public static Shooter current;
    // field 19080, runtime offset 20, flags 0x1
    private TMPro.TMP_Text kpTxt;
    // field 19081, runtime offset 24, flags 0x1
    private UnityEngine.Animations.Rigging.OverrideTransform overrideSpine3;
    // field 19082, runtime offset 28, flags 0x1
    private UnityEngine.Transform offsetKourstrike;
    // field 19083, runtime offset 32, flags 0x1
    private UnityEngine.LayerMask generalReaycastMask;
    // field 19084, runtime offset 36, flags 0x1
    private UnityEngine.RectTransform localCanvas;
    // field 19085, runtime offset 40, flags 0x1
    private GunGameProgress gunGameProgressUI;
    // field 19086, runtime offset 4, flags 0x16
    public static int currentGunGameWeaponIndex;
    // field 19087, runtime offset 44, flags 0x1
    private float lastMoveTime;
    // field 19088, runtime offset 48, flags 0x1
    private TMPro.TMP_Text reloadTipTxt;
    // field 19089, runtime offset 52, flags 0x1
    private TMPro.TMP_Text generalTipTxt;
    // field 19090, runtime offset 56, flags 0x6
    public bool gameRunning;
    // field 19091, runtime offset 60, flags 0x6
    public CharacterSkinManager characterSkinManager;
    // field 19092, runtime offset 64, flags 0x6
    public TeamMember teamMember;
    // field 19093, runtime offset 68, flags 0x6
    public CharacterAnimatorManager characterAnimatorManager;
    // field 19094, runtime offset 72, flags 0x1
    private System.Collections.Generic.List<int> IDsHitted;
    // field 19095, runtime offset 0, flags 0x8051
    private static const int grantXpOnAssist = 25;
    // field 19096, runtime offset 76, flags 0x1
    private float lastKilledTime;
    // field 19097, runtime offset 80, flags 0x6
    public int myClassIndex;
    // field 19098, runtime offset 84, flags 0x6
    public int mySkinIndex;
    // field 19099, runtime offset 88, flags 0x6
    public int myHatIndex;
    // field 19100, runtime offset 8, flags 0x16
    public static int[] selectedWeaponIndexes;
    // field 19101, runtime offset 92, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredInt[] localWeaponAmmos;
    // field 19102, runtime offset 96, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredInt[] localMaxWeaponAmmos;
    // field 19103, runtime offset 12, flags 0x16
    public static int currentLocalWeaponIndex;
    // field 19104, runtime offset 100, flags 0x1
    private WeaponGameplayIcon[] weaponIcons;
    // field 19105, runtime offset 104, flags 0x1
    private UnityEngine.GameObject onShotPanel;
    // field 19106, runtime offset 108, flags 0x6
    public Health health;
    // field 19107, runtime offset 112, flags 0x1
    private UnityEngine.Transform weaponOffsetParent;
    // field 19108, runtime offset 116, flags 0x6
    public PlayerController playerController;
    // field 19109, runtime offset 120, flags 0x1
    private UnityEngine.Transform crouchLocalTransformParent;
    // field 19110, runtime offset 124, flags 0x1
    private UnityEngine.Transform crouchLocalWeaponTransformParent;
    // field 19111, runtime offset 128, flags 0x1
    private UnityEngine.Vector3 crouchPosition;
    // field 19112, runtime offset 140, flags 0x1
    private UnityEngine.Vector3 crouchRotation;
    // field 19113, runtime offset 152, flags 0x1
    private UnityEngine.Vector3 weaponCrouchRotation;
    // field 19114, runtime offset 164, flags 0x1
    private UnityEngine.RectTransform reloadingImage;
    // field 19115, runtime offset 168, flags 0x1
    private Hitmark[] hitmarks;
    // field 19116, runtime offset 172, flags 0x1
    private WorldHitmark[] worldHitmarks;
    // field 19117, runtime offset 176, flags 0x1
    private OnKilledUI onKilledUI;
    // field 19118, runtime offset 180, flags 0x1
    private UnityEngine.LayerMask shootLayerMask;
    // field 19119, runtime offset 184, flags 0x6
    public UnityEngine.Camera cam;
    // field 19120, runtime offset 188, flags 0x1
    private UnityEngine.Camera weaponCamera;
    // field 19121, runtime offset 192, flags 0x1
    private Recoil recoil;
    // field 19122, runtime offset 196, flags 0x1
    private TMPro.TMP_Text ammoTxt;
    // field 19123, runtime offset 200, flags 0x6
    public PlayerInputHandler playerInputHandler;
    // field 19124, runtime offset 204, flags 0x1
    private UnityEngine.Transform localWeaponParent;
    // field 19125, runtime offset 208, flags 0x1
    private UnityEngine.Transform globalWeaponParent;
    // field 19126, runtime offset 212, flags 0x1
    private UnityEngine.Collider head;
    // field 19127, runtime offset 216, flags 0x1
    private UnityEngine.CapsuleCollider legs;
    // field 19128, runtime offset 220, flags 0x1
    private UnityEngine.CapsuleCollider myCapsuleCollider;
    // field 19129, runtime offset 224, flags 0x6
    public Weapon currentLocalWeapon;
    // field 19130, runtime offset 228, flags 0x6
    public Weapon currentGlobalWeapon;
    // field 19131, runtime offset 232, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat shootingTimer;
    // field 19132, runtime offset 256, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat currentFireRate;
    // field 19133, runtime offset 280, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat currentRange;
    // field 19134, runtime offset 304, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat currentReloadTime;
    // field 19135, runtime offset 328, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredInt currentDamage;
    // field 19136, runtime offset 348, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat changeWeaponTimer;
    // field 19137, runtime offset 372, flags 0x1
    private UnityEngine.Vector3 target_crouchLocalTransformParentPosition;
    // field 19138, runtime offset 384, flags 0x1
    private UnityEngine.Quaternion target_crouchLocalTransformParentRotation;
    // field 19139, runtime offset 400, flags 0x1
    private UnityEngine.Quaternion target_crouchLocalWeaponTransformParentRotation;
    // field 19140, runtime offset 416, flags 0x6
    public bool isCrouching;
    // field 19141, runtime offset 16, flags 0x16
    public static bool isGunGame;
    // field 19142, runtime offset 17, flags 0x16
    public static bool everMoved;
    // field 19143, runtime offset 424, flags 0x1
    private double spawnTime;
    // field 19144, runtime offset 432, flags 0x1
    private float minTotalHeadshotsSoFarTimeInterval;
    // field 19145, runtime offset 20, flags 0x16
    public static float lastRequestedAimWhenImpossible;
    // field 19146, runtime offset 436, flags 0x1
    private bool isInspectTip;
    // field 19147, runtime offset 440, flags 0x1
    private float lastShootTime;
    // field 19148, runtime offset 24, flags 0x16
    public static float lastAnyKeyTime;
    // field 19149, runtime offset 444, flags 0x1
    private bool canSwitchTeam;
    // field 19150, runtime offset 448, flags 0x1
    private float lerpedNeckNetworkXRotation;
    // field 19151, runtime offset 452, flags 0x1
    private float lastParkourRespawnKeyPressed;
    // field 19152, runtime offset 456, flags 0x1
    private bool lastIsShooting;
    // field 19153, runtime offset 460, flags 0x1
    private int currentMouseWheelWeaponIndex;
    // field 19154, runtime offset 464, flags 0x1
    private int lastMouseWheelWeaponIndex;
    // field 19155, runtime offset 468, flags 0x1
    private UnityEngine.Coroutine currentReloadCoroutine;
    // field 19156, runtime offset 472, flags 0x6
    public bool isReloading;
    // field 19157, runtime offset 28, flags 0x11
    private static int totalHeadshotsSoFar;
    // field 19158, runtime offset 476, flags 0x1
    private WorldHitmark lastWorldHitmark;
    // field 19159, runtime offset 480, flags 0x1
    private int currentKillRow;
    // field 19160, runtime offset 0, flags 0x8051
    private static const float KILL_ROW_DELTA_TIME = 10;
    // field 19161, runtime offset 484, flags 0x1
    private string lastHitTag;
    // field 19162, runtime offset 488, flags 0x1
    private UnityEngine.GameObject sniperMask;
    // field 19163, runtime offset 492, flags 0x1
    private CrosshairReticle crosshair;
    // field 19164, runtime offset 496, flags 0x1
    private UnityEngine.Transform crosshairParent;
    // field 19165, runtime offset 500, flags 0x1
    private Weapon lastLocalWeapon;
    // field 19166, runtime offset 504, flags 0x1
    private float lastExplosiveDamageReceiveTime;
    // field 19167, runtime offset 508, flags 0x1
    private float lastExplosiveDamageSendTime;
    // field 19168, runtime offset 512, flags 0x6
    public ATV currentATV;
    // field 19169, runtime offset 516, flags 0x6
    public int neckNetworkXRotation;
    // method 32982, 0x6000cdf
    void RequestToOpenBuyMenu();
    // method 32983, 0x6000ce0
    void TeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation);
    // method 32984, 0x6000ce1
    void RPCTeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation);
    // method 32985, 0x6000ce2
    void TeleportTo(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation, float wait);
    // method 32986, 0x6000ce3
    void SetBomb(bool giveBomb, bool isPlanting);
    // method 32987, 0x6000ce4
    void GiveWeapon(int onLocalSlotIndex, int weaponIndex, int ammo);
    // method 32988, 0x6000ce5
    void RemoveWeapon(int onLocalSlotIndex);
    // method 32989, 0x6000ce6
    void NewKourStrikeRoundStarted(int[] useWeapons, int planterId, Photon.Pun.UtilityScripts.PhotonTeam myTeam);
    // method 32990, 0x6000ce7
    void OnSpawnedBattleRoyale();
    // method 32991, 0x6000ce8
    void OnEnable();
    // method 32992, 0x6000ce9
    void OnDisable();
    // method 32993, 0x6000cea
    void OnMove(bool isFirstTime);
    // method 32994, 0x6000ceb
    void SetGlobalWeapon(bool active);
    // method 32995, 0x6000cec
    void SetCustomBottomTip(string txt);
    // method 32996, 0x6000ced
    void HideCustomBottomTip();
    // method 32997, 0x6000cee
    void SetAirState(bool isGrounded);
    // method 32998, 0x6000cef
    void RPCInitiateDance(string danceName);
    // method 32999, 0x6000cf0
    void RPCEndOfDance();
    // method 33000, 0x6000cf1
    void RPCSetAirState(bool isGrounded);
    // method 33001, 0x6000cf2
    void RPCSetAnimatorBoolForEveryone(string boolName, bool value);
    // method 33002, 0x6000cf3
    void RPCSetAnimatorLayerWeightForEveryone(int layerIndex, float weight);
    // method 33003, 0x6000cf4
    void OnOtherPlayerEliminated(Shooter killer, int whoID);
    // method 33004, 0x6000cf5
    void SetCrouch(bool crouch, bool aiming, bool pushToOthers);
    // method 33005, 0x6000cf6
    void RPCSetCrouch(bool crouch);
    // method 33006, 0x6000cf7
    UnityEngine.Color GetColorFromFloat(float value);
    // method 33007, 0x6000cf8
    void Awake();
    // method 33008, 0x6000cf9
    System.Collections.IEnumerator IenuWaitForMapSettings();
    // method 33009, 0x6000cfa
    void UpdateWeaponUIAndSetIndex(int ind);
    // method 33010, 0x6000cfb
    void UpdateCanSwitchTeam();
    // method 33011, 0x6000cfc
    void Start();
    // method 33012, 0x6000cfd
    void Update();
    // method 33013, 0x6000cfe
    void ParkourModeRespawn();
    // method 33014, 0x6000cff
    void RPCDefuseBomb();
    // method 33015, 0x6000d00
    void RpcOnMouseUp();
    // method 33016, 0x6000d01
    void Shoot(int recursiveBurst);
    // method 33017, 0x6000d02
    void OnKilledChick(int scoreToGive);
    // method 33018, 0x6000d03
    void RPCExplodeBarrel(string barrelId, double atTime);
    // method 33019, 0x6000d04
    System.Collections.IEnumerator IenuShootAgain(float afterTime, int burstRecursive);
    // method 33020, 0x6000d05
    float CalculateDamageByDistance(float currentDistance, float minDistance, float maxDistance, float maxDamage);
    // method 33021, 0x6000d06
    float GetMultiFromRaycastHit(UnityEngine.RaycastHit hit, out Photon.Pun.PhotonView otherView);
    // method 33022, 0x6000d07
    System.Collections.IEnumerator IenuOnShotPanel();
    // method 33023, 0x6000d08
    Hitmark GetAvailableHitmark();
    // method 33024, 0x6000d09
    WorldHitmark GetAvailableWorldHitmark();
    // method 33025, 0x6000d0a
    System.Collections.IEnumerator IenuReload(float reloadTime);
    // method 33026, 0x6000d0b
    void OnHitted(int damageDealt, Health who, string hitTag);
    // method 33027, 0x6000d0c
    void OnHitted(int damageDealt, KourBot who, string hitTag);
    // method 33028, 0x6000d0d
    void OnKilled(int damageDealt, Health who, string hitTag);
    // method 33029, 0x6000d0e
    void RPCForceGameEndedForAll();
    // method 33030, 0x6000d0f
    System.Collections.IEnumerator IenuDisableHitmarks(Hitmark hitmark, WorldHitmark worldHitmark);
    // method 33031, 0x6000d10
    void RPCShoot(UnityEngine.Vector3[] ats, UnityEngine.Vector3[] hitNormals, int targetId, int damage, int hitTagNameIndex);
    // method 33032, 0x6000d11
    void OnClassChangedExternally(int newClass, int localWeaponIndexToSet);
    // method 33033, 0x6000d12
    void RPCOnClassChanged(int newClass, int skinIndex, int hatIndex);
    // method 33034, 0x6000d13
    void SetWeapon(int localweaponIndex, bool force);
    // method 33035, 0x6000d14
    int GetCurrentAmmo();
    // method 33036, 0x6000d15
    void PlayJumpPad(int jumpPadId);
    // method 33037, 0x6000d16
    void RPCJumpPad(int jumpPadId);
    // method 33038, 0x6000d17
    void RPCSetWeapon(int weaponIndex, int skinIndex);
    // method 33039, 0x6000d18
    void EnsureKill(int viewID);
    // method 33040, 0x6000d19
    void RPCEnsureKill(int whoId);
    // method 33041, 0x6000d1a
    void ExplosiveDamage(int damage, bool showFeedback, int[] targetViewIDs);
    // method 33042, 0x6000d1b
    void BarrelExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs);
    // method 33043, 0x6000d1c
    void RPCExplosiveDamage(int damage, bool showFeedback, int[] targetViewIDs);
    // method 33044, 0x6000d1d
    void RPCBarrelExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs);
    // method 33045, 0x6000d1e
    void TryStopDefuse();
    // method 33046, 0x6000d1f
    void RPCStopDefuseBomb();
    // method 33047, 0x6000d20
    void OnFlash(float flashStrength);
    // method 33048, 0x6000d21
    float EaseOutExpo(float x);
    // method 33049, 0x6000d22
    void HandleInventorySwap(int indexA, int indexB);
    // method 33050, 0x6000d23
    void SetMyVehicle(ATV aTV);
    // method 33051, 0x6000d24
    void OnPhotonSerializeView(Photon.Pun.PhotonStream stream, Photon.Pun.PhotonMessageInfo info);
    // method 33052, 0x6000d25
    void .ctor();
    // method 33053, 0x6000d26
    void .cctor();
    // method 33054, 0x6000d27
    void <OnKilled>g__ForceGameEndForAll|128_0();
    // method 33055, 0x6000d28
    void <OnKilled>g__ShowKillRowMessage|128_1();
}

// TypeDefinition 4482, 0x2000232
class ShopInnerWindow : Popup {
    // method 33100, 0x6000d55
    void .ctor();
}

// TypeDefinition 4483, 0x2000234
class <>c : object {
    // field 19224, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19225, runtime offset 4, flags 0x16
    public static System.Action <>9__32_0;
    // method 33118, 0x6000d67
    void .cctor();
    // method 33119, 0x6000d68
    void .ctor();
    // method 33120, 0x6000d69
    void <OnIconPressed>b__32_0();
}

// TypeDefinition 4484, 0x2000235
class <>c__DisplayClass27_0 : object {
    // field 19226, runtime offset 8, flags 0x6
    public System.Action<Item, int> onClicked;
    // field 19227, runtime offset 12, flags 0x6
    public CharacterSkin skin;
    // field 19228, runtime offset 16, flags 0x6
    public int realIndexOf;
    // method 33121, 0x6000d6a
    void .ctor();
    // method 33122, 0x6000d6b
    void <Init>b__0();
    // method 33123, 0x6000d6c
    void <Init>b__1();
    // method 33124, 0x6000d6d
    void <Init>b__2();
}

// TypeDefinition 4485, 0x2000236
class <>c__DisplayClass28_0 : object {
    // field 19229, runtime offset 8, flags 0x6
    public System.Action<Item, int> onClicked;
    // field 19230, runtime offset 12, flags 0x6
    public Emote emote;
    // field 19231, runtime offset 16, flags 0x6
    public int realIndexOf;
    // method 33125, 0x6000d6e
    void .ctor();
    // method 33126, 0x6000d6f
    void <Init>b__0();
}

// TypeDefinition 4486, 0x2000237
class <>c__DisplayClass29_0 : object {
    // field 19232, runtime offset 8, flags 0x6
    public System.Action<Item, int> onClicked;
    // field 19233, runtime offset 12, flags 0x6
    public Hat hat;
    // field 19234, runtime offset 16, flags 0x6
    public int realIndexOf;
    // method 33127, 0x6000d70
    void .ctor();
    // method 33128, 0x6000d71
    void <Init>b__0();
    // method 33129, 0x6000d72
    void <Init>b__1();
    // method 33130, 0x6000d73
    void <Init>b__2();
    // method 33131, 0x6000d74
    void <Init>b__3();
}

// TypeDefinition 4487, 0x2000238
class <>c__DisplayClass30_0 : object {
    // field 19235, runtime offset 8, flags 0x6
    public System.Action<Item, int> onClicked;
    // field 19236, runtime offset 12, flags 0x6
    public WeaponSkin weaponSkin;
    // field 19237, runtime offset 16, flags 0x6
    public int realIndexOf;
    // method 33132, 0x6000d75
    void .ctor();
    // method 33133, 0x6000d76
    void <Init>b__0();
}

// TypeDefinition 4488, 0x2000239
class <>c__DisplayClass31_0 : object {
    // field 19238, runtime offset 8, flags 0x6
    public System.Action<int> onClicked;
    // field 19239, runtime offset 12, flags 0x6
    public int crateIndex;
    // method 33134, 0x6000d77
    void .ctor();
    // method 33135, 0x6000d78
    void <Init>b__0();
}

// TypeDefinition 4489, 0x2000233
class ShopItemSlot : UnityEngine.MonoBehaviour {
    // field 19204, runtime offset 16, flags 0x1
    private bool cull;
    // field 19205, runtime offset 20, flags 0x1
    private UnityEngine.GameObject[] showWhenVisible;
    // field 19206, runtime offset 24, flags 0x1
    private UnityEngine.RectTransform targetUIElement;
    // field 19207, runtime offset 28, flags 0x1
    private bool becameVisible;
    // field 19208, runtime offset 32, flags 0x1
    private int frameCount;
    // field 19209, runtime offset 36, flags 0x1
    private bool requestedImage;
    // field 19210, runtime offset 0, flags 0x8051
    private static const string AD_TEXT = "FREE";
    // field 19211, runtime offset 0, flags 0x8051
    private static const float SELECTED_COLOR = 0.15000000596046448;
    // field 19212, runtime offset 40, flags 0x1
    private UnityEngine.GameObject glow;
    // field 19213, runtime offset 44, flags 0x1
    private UnityEngine.GameObject adIcon;
    // field 19214, runtime offset 48, flags 0x1
    private UnityEngine.UI.Button purchaseButton;
    // field 19215, runtime offset 52, flags 0x1
    private UnityEngine.UI.Image purchaseButtonImg;
    // field 19216, runtime offset 56, flags 0x1
    private TMPro.TMP_Text purchaseButtonTxt;
    // field 19217, runtime offset 60, flags 0x1
    private UnityEngine.UI.Image purchaseButtonFx;
    // field 19218, runtime offset 64, flags 0x1
    private UnityEngine.UI.Image skinImage;
    // field 19219, runtime offset 68, flags 0x1
    private UnityEngine.UI.Image skinBackgroundImage;
    // field 19220, runtime offset 72, flags 0x1
    private UnityEngine.UI.Image[] brighterImages;
    // field 19221, runtime offset 76, flags 0x1
    private TMPro.TMP_Text skinNameTxt;
    // field 19222, runtime offset 80, flags 0x1
    private TMPro.TMP_Text skinRarityTxt;
    // field 19223, runtime offset 84, flags 0x6
    public Item myItem;
    // method 33101, 0x6000d56
    bool AllowItemsForFollow();
    // method 33102, 0x6000d57
    void Start();
    // method 33103, 0x6000d58
    void OnEnable();
    // method 33104, 0x6000d59
    void Update();
    // method 33105, 0x6000d5a
    bool IsVisibleToCamera(UnityEngine.RectTransform rectTransform);
    // method 33106, 0x6000d5b
    void OnBecameVisibleNow(bool visibleRn);
    // method 33107, 0x6000d5c
    void InitGeneral(Item item, System.Action<Item, int> onClicked);
    // method 33108, 0x6000d5d
    void Init(CharacterSkin skin, System.Action<Item, int> onClicked);
    // method 33109, 0x6000d5e
    void Init(Emote emote, System.Action<Item, int> onClicked);
    // method 33110, 0x6000d5f
    void Init(Hat hat, System.Action<Item, int> onClicked);
    // method 33111, 0x6000d60
    void Init(WeaponSkin weaponSkin, System.Action<Item, int> onClicked);
    // method 33112, 0x6000d61
    void Init(CaseData crate, int crateIndex, System.Action<int> onClicked);
    // method 33113, 0x6000d62
    void OnIconPressed();
    // method 33114, 0x6000d63
    UnityEngine.Color GetAdjustedColor(UnityEngine.Color originalColor, float adjustmentFactor);
    // method 33115, 0x6000d64
    bool MatchSearch(string userSearchString);
    // method 33116, 0x6000d65
    void .ctor();
    // method 33117, 0x6000d66
    void <OnEnable>b__7_0();
}

// TypeDefinition 4490, 0x200023b
class SortMethod : System.Enum {
    // field 19299, runtime offset 8, flags 0x606
    public int value__;
    // field 19300, runtime offset 0, flags 0x8056
    public static const SortMethod Rarity = 0;
    // field 19301, runtime offset 0, flags 0x8056
    public static const SortMethod Price = 1;
}

// TypeDefinition 4491, 0x200023c
class ItemRarity : System.Enum {
    // field 19302, runtime offset 8, flags 0x606
    public int value__;
    // field 19303, runtime offset 0, flags 0x8056
    public static const ItemRarity Uncommon = 0;
    // field 19304, runtime offset 0, flags 0x8056
    public static const ItemRarity Rare = 1;
    // field 19305, runtime offset 0, flags 0x8056
    public static const ItemRarity Epic = 2;
    // field 19306, runtime offset 0, flags 0x8056
    public static const ItemRarity Legendary = 3;
    // field 19307, runtime offset 0, flags 0x8056
    public static const ItemRarity Immortal = 4;
}

// TypeDefinition 4492, 0x200023d
class <>c : object {
    // field 19308, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19309, runtime offset 4, flags 0x16
    public static System.Func<CharacterSkin, ItemRarity> <>9__50_2;
    // field 19310, runtime offset 8, flags 0x16
    public static System.Func<CharacterSkin, CodeStage.AntiCheat.ObscuredTypes.ObscuredInt> <>9__50_3;
    // field 19311, runtime offset 12, flags 0x16
    public static System.Func<Emote, ItemRarity> <>9__51_2;
    // field 19312, runtime offset 16, flags 0x16
    public static System.Func<Emote, CodeStage.AntiCheat.ObscuredTypes.ObscuredInt> <>9__51_3;
    // field 19313, runtime offset 20, flags 0x16
    public static System.Func<Item, ItemRarity> <>9__52_2;
    // field 19314, runtime offset 24, flags 0x16
    public static System.Func<Item, CodeStage.AntiCheat.ObscuredTypes.ObscuredInt> <>9__52_3;
    // field 19315, runtime offset 28, flags 0x16
    public static System.Func<Hat, ItemRarity> <>9__56_2;
    // field 19316, runtime offset 32, flags 0x16
    public static System.Func<Hat, CodeStage.AntiCheat.ObscuredTypes.ObscuredInt> <>9__56_3;
    // field 19317, runtime offset 36, flags 0x16
    public static System.Func<WeaponSkin, ItemRarity> <>9__110_2;
    // field 19318, runtime offset 40, flags 0x16
    public static System.Func<WeaponSkin, CodeStage.AntiCheat.ObscuredTypes.ObscuredInt> <>9__110_3;
    // field 19319, runtime offset 44, flags 0x16
    public static System.Action<string> <>9__129_0;
    // method 33210, 0x6000dc3
    void .cctor();
    // method 33211, 0x6000dc4
    void .ctor();
    // method 33212, 0x6000dc5
    ItemRarity <IenuLoadCharacters>b__50_2(CharacterSkin skin);
    // method 33213, 0x6000dc6
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt <IenuLoadCharacters>b__50_3(CharacterSkin skin);
    // method 33214, 0x6000dc7
    ItemRarity <IenuLoadEmotes>b__51_2(Emote skin);
    // method 33215, 0x6000dc8
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt <IenuLoadEmotes>b__51_3(Emote skin);
    // method 33216, 0x6000dc9
    ItemRarity <IenuLoadYourItems>b__52_2(Item skin);
    // method 33217, 0x6000dca
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt <IenuLoadYourItems>b__52_3(Item skin);
    // method 33218, 0x6000dcb
    ItemRarity <IenuLoadHats>b__56_2(Hat skin);
    // method 33219, 0x6000dcc
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt <IenuLoadHats>b__56_3(Hat skin);
    // method 33220, 0x6000dcd
    ItemRarity <IenuLoadWeapons>b__110_2(WeaponSkin skin);
    // method 33221, 0x6000dce
    CodeStage.AntiCheat.ObscuredTypes.ObscuredInt <IenuLoadWeapons>b__110_3(WeaponSkin skin);
    // method 33222, 0x6000dcf
    void <BuyItem>b__129_0(string x);
}

// TypeDefinition 4493, 0x200023e
class <>c__DisplayClass110_0 : object {
    // field 19320, runtime offset 8, flags 0x6
    public WeaponSkin[] weaponSkins;
    // method 33223, 0x6000dd0
    void .ctor();
    // method 33224, 0x6000dd1
    bool <IenuLoadWeapons>b__0(int i);
    // method 33225, 0x6000dd2
    bool <IenuLoadWeapons>b__1(int i);
}

// TypeDefinition 4494, 0x200023f
class <>c__DisplayClass115_0 : object {
    // field 19321, runtime offset 8, flags 0x6
    public CharacterSkin[] sortedSkins;
    // method 33226, 0x6000dd3
    void .ctor();
    // method 33227, 0x6000dd4
    bool <GetUnownedSkins>b__0(int i);
    // method 33228, 0x6000dd5
    bool <GetUnownedSkins>b__1(int i);
    // method 33229, 0x6000dd6
    CharacterSkin <GetUnownedSkins>b__2(int index);
}

// TypeDefinition 4495, 0x2000240
class <>c__DisplayClass119_0 : object {
    // field 19322, runtime offset 8, flags 0x6
    public Item item;
    // field 19323, runtime offset 12, flags 0x6
    public CharacterSkin currentSkin;
    // field 19324, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19325, runtime offset 20, flags 0x6
    public int currentCoins;
    // field 19326, runtime offset 24, flags 0x6
    public int price;
    // field 19327, runtime offset 28, flags 0x6
    public System.Action<string> <>9__2;
    // method 33230, 0x6000dd7
    void .ctor();
    // method 33231, 0x6000dd8
    void <OnSkinButtonPressed>b__0(bool success);
    // method 33232, 0x6000dd9
    void <OnSkinButtonPressed>b__1();
    // method 33233, 0x6000dda
    void <OnSkinButtonPressed>b__2(string callback);
}

// TypeDefinition 4496, 0x2000241
class <>c__DisplayClass120_0 : object {
    // field 19328, runtime offset 8, flags 0x6
    public int currentCoins;
    // field 19329, runtime offset 12, flags 0x6
    public int price;
    // field 19330, runtime offset 16, flags 0x6
    public Item item;
    // field 19331, runtime offset 20, flags 0x6
    public ShopPanel <>4__this;
    // field 19332, runtime offset 24, flags 0x6
    public System.Action<string> <>9__1;
    // method 33234, 0x6000ddb
    void .ctor();
    // method 33235, 0x6000ddc
    void <OnEmoteButtonPressed>b__0();
    // method 33236, 0x6000ddd
    void <OnEmoteButtonPressed>b__1(string callback);
}

// TypeDefinition 4497, 0x2000242
class <>c__DisplayClass122_0 : object {
    // field 19333, runtime offset 8, flags 0x6
    public Item item;
    // field 19334, runtime offset 12, flags 0x6
    public ShopPanel <>4__this;
    // field 19335, runtime offset 16, flags 0x6
    public int currentCoins;
    // field 19336, runtime offset 20, flags 0x6
    public int price;
    // field 19337, runtime offset 24, flags 0x6
    public System.Action<string> <>9__2;
    // method 33237, 0x6000dde
    void .ctor();
    // method 33238, 0x6000ddf
    void <OnHatButtonPressed>b__0(bool success);
    // method 33239, 0x6000de0
    void <OnHatButtonPressed>b__1();
    // method 33240, 0x6000de1
    void <OnHatButtonPressed>b__2(string callback);
}

// TypeDefinition 4498, 0x2000243
class <>c__DisplayClass124_0 : object {
    // field 19338, runtime offset 8, flags 0x6
    public int weaponSkinIndex;
    // field 19339, runtime offset 12, flags 0x6
    public Item item;
    // field 19340, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19341, runtime offset 20, flags 0x6
    public int currentCoins;
    // field 19342, runtime offset 24, flags 0x6
    public int price;
    // field 19343, runtime offset 28, flags 0x6
    public System.Action<string> <>9__2;
    // method 33241, 0x6000de2
    void .ctor();
    // method 33242, 0x6000de3
    void <OnWeaponSkinButtonPressed>b__0(bool success);
    // method 33243, 0x6000de4
    void <OnWeaponSkinButtonPressed>b__1();
    // method 33244, 0x6000de5
    void <OnWeaponSkinButtonPressed>b__2(string callback);
}

// TypeDefinition 4499, 0x2000244
class <>c__DisplayClass130_0 : object {
    // field 19344, runtime offset 8, flags 0x6
    public int kourPointsToGive;
    // field 19345, runtime offset 12, flags 0x6
    public int newCoinsAmount;
    // method 33245, 0x6000de6
    void .ctor();
    // method 33246, 0x6000de7
    void <GiveKourPoints>b__0(string x);
}

// TypeDefinition 4500, 0x2000245
class <>c__DisplayClass4_0 : object {
    // field 19346, runtime offset 8, flags 0x6
    public ShopPanel <>4__this;
    // field 19347, runtime offset 12, flags 0x6
    public GameBundle bundle;
    // method 33247, 0x6000de8
    void .ctor();
    // method 33248, 0x6000de9
    void <InpsectBundle>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4501, 0x2000246
class <>c__DisplayClass50_0 : object {
    // field 19348, runtime offset 8, flags 0x6
    public CharacterSkin[] sortedSkins;
    // method 33249, 0x6000dea
    void .ctor();
    // method 33250, 0x6000deb
    bool <IenuLoadCharacters>b__0(int i);
    // method 33251, 0x6000dec
    bool <IenuLoadCharacters>b__1(int i);
}

// TypeDefinition 4502, 0x2000247
class <>c__DisplayClass51_0 : object {
    // field 19349, runtime offset 8, flags 0x6
    public Emote[] sortedEmotes;
    // method 33252, 0x6000ded
    void .ctor();
    // method 33253, 0x6000dee
    bool <IenuLoadEmotes>b__0(int i);
    // method 33254, 0x6000def
    bool <IenuLoadEmotes>b__1(int i);
}

// TypeDefinition 4503, 0x2000248
class <>c__DisplayClass52_0 : object {
    // field 19350, runtime offset 8, flags 0x6
    public Item[] allItems;
    // method 33255, 0x6000df0
    void .ctor();
    // method 33256, 0x6000df1
    bool <IenuLoadYourItems>b__0(int i);
    // method 33257, 0x6000df2
    bool <IenuLoadYourItems>b__1(int i);
}

// TypeDefinition 4504, 0x2000249
class <>c__DisplayClass56_0 : object {
    // field 19351, runtime offset 8, flags 0x6
    public Hat[] hats;
    // method 33258, 0x6000df3
    void .ctor();
    // method 33259, 0x6000df4
    bool <IenuLoadHats>b__0(int i);
    // method 33260, 0x6000df5
    bool <IenuLoadHats>b__1(int i);
}

// TypeDefinition 4505, 0x200024a
class <>c__DisplayClass60_0 : object {
    // field 19352, runtime offset 8, flags 0x6
    public ShopPanel <>4__this;
    // field 19353, runtime offset 12, flags 0x6
    public int i;
    // field 19354, runtime offset 16, flags 0x6
    public int currentCoins;
    // field 19355, runtime offset 20, flags 0x6
    public CaseData caseData;
    // field 19356, runtime offset 24, flags 0x6
    public System.Action<string> <>9__2;
    // method 33261, 0x6000df6
    void .ctor();
    // method 33262, 0x6000df7
    void <OnCrateButtonPressed>b__0(bool success);
    // method 33263, 0x6000df8
    void <OnCrateButtonPressed>b__1();
    // method 33264, 0x6000df9
    void <OnCrateButtonPressed>b__2(string callback);
}

// TypeDefinition 4506, 0x200024b
class <IenuLoadCharacters>d__50 : object {
    // field 19357, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19358, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19359, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19360, runtime offset 20, flags 0x1
    private <>c__DisplayClass50_0 <>8__1;
    // field 19361, runtime offset 24, flags 0x1
    private int[] <ownedIndexes>5__2;
    // field 19362, runtime offset 28, flags 0x1
    private int[] <unOwnedIndexes>5__3;
    // field 19363, runtime offset 32, flags 0x1
    private int <totalAnimated>5__4;
    // field 19364, runtime offset 36, flags 0x1
    private int <i>5__5;
    // method 33265, 0x6000dfa
    void .ctor(int <>1__state);
    // method 33266, 0x6000dfb
    void System.IDisposable.Dispose();
    // method 33267, 0x6000dfc
    bool MoveNext();
    // method 33268, 0x6000dfd
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33269, 0x6000dfe
    void System.Collections.IEnumerator.Reset();
    // method 33270, 0x6000dff
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4507, 0x200024c
class <IenuLoadCrates>d__59 : object {
    // field 19365, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19366, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19367, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19368, runtime offset 20, flags 0x1
    private int <totalAnimated>5__2;
    // field 19369, runtime offset 24, flags 0x1
    private int <i>5__3;
    // method 33271, 0x6000e00
    void .ctor(int <>1__state);
    // method 33272, 0x6000e01
    void System.IDisposable.Dispose();
    // method 33273, 0x6000e02
    bool MoveNext();
    // method 33274, 0x6000e03
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33275, 0x6000e04
    void System.Collections.IEnumerator.Reset();
    // method 33276, 0x6000e05
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4508, 0x200024d
class <IenuLoadEmotes>d__51 : object {
    // field 19370, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19371, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19372, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19373, runtime offset 20, flags 0x1
    private <>c__DisplayClass51_0 <>8__1;
    // field 19374, runtime offset 24, flags 0x1
    private int[] <ownedIndexes>5__2;
    // field 19375, runtime offset 28, flags 0x1
    private int[] <unOwnedIndexes>5__3;
    // field 19376, runtime offset 32, flags 0x1
    private int <totalAnimated>5__4;
    // field 19377, runtime offset 36, flags 0x1
    private int <i>5__5;
    // method 33277, 0x6000e06
    void .ctor(int <>1__state);
    // method 33278, 0x6000e07
    void System.IDisposable.Dispose();
    // method 33279, 0x6000e08
    bool MoveNext();
    // method 33280, 0x6000e09
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33281, 0x6000e0a
    void System.Collections.IEnumerator.Reset();
    // method 33282, 0x6000e0b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4509, 0x200024e
class <IenuLoadHats>d__56 : object {
    // field 19378, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19379, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19380, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19381, runtime offset 20, flags 0x1
    private <>c__DisplayClass56_0 <>8__1;
    // field 19382, runtime offset 24, flags 0x1
    private int[] <ownedIndexes>5__2;
    // field 19383, runtime offset 28, flags 0x1
    private int[] <unOwnedIndexes>5__3;
    // field 19384, runtime offset 32, flags 0x1
    private int <totalAnimated>5__4;
    // field 19385, runtime offset 36, flags 0x1
    private int <i>5__5;
    // method 33283, 0x6000e0c
    void .ctor(int <>1__state);
    // method 33284, 0x6000e0d
    void System.IDisposable.Dispose();
    // method 33285, 0x6000e0e
    bool MoveNext();
    // method 33286, 0x6000e0f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33287, 0x6000e10
    void System.Collections.IEnumerator.Reset();
    // method 33288, 0x6000e11
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4510, 0x200024f
class <IenuLoadHome>d__118 : object {
    // field 19386, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19387, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19388, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19389, runtime offset 20, flags 0x1
    private int <totalAnimated>5__2;
    // field 19390, runtime offset 24, flags 0x1
    private CharacterSkin[] <skinsToLoad>5__3;
    // field 19391, runtime offset 28, flags 0x1
    private int <i>5__4;
    // method 33289, 0x6000e12
    void .ctor(int <>1__state);
    // method 33290, 0x6000e13
    void System.IDisposable.Dispose();
    // method 33291, 0x6000e14
    bool MoveNext();
    // method 33292, 0x6000e15
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33293, 0x6000e16
    void System.Collections.IEnumerator.Reset();
    // method 33294, 0x6000e17
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4511, 0x2000250
class <IenuLoadWeapons>d__110 : object {
    // field 19392, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19393, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19394, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19395, runtime offset 20, flags 0x1
    private <>c__DisplayClass110_0 <>8__1;
    // field 19396, runtime offset 24, flags 0x1
    private int[] <ownedIndexes>5__2;
    // field 19397, runtime offset 28, flags 0x1
    private int[] <unOwnedIndexes>5__3;
    // field 19398, runtime offset 32, flags 0x1
    private int <totalAnimated>5__4;
    // field 19399, runtime offset 36, flags 0x1
    private int <i>5__5;
    // method 33295, 0x6000e18
    void .ctor(int <>1__state);
    // method 33296, 0x6000e19
    void System.IDisposable.Dispose();
    // method 33297, 0x6000e1a
    bool MoveNext();
    // method 33298, 0x6000e1b
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33299, 0x6000e1c
    void System.Collections.IEnumerator.Reset();
    // method 33300, 0x6000e1d
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4512, 0x2000251
class <IenuLoadYourItems>d__52 : object {
    // field 19400, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19401, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19402, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19403, runtime offset 20, flags 0x1
    private <>c__DisplayClass52_0 <>8__1;
    // field 19404, runtime offset 24, flags 0x1
    private int[] <ownedIndexes>5__2;
    // field 19405, runtime offset 28, flags 0x1
    private int <totalAnimated>5__3;
    // field 19406, runtime offset 32, flags 0x1
    private int <i>5__4;
    // method 33301, 0x6000e1e
    void .ctor(int <>1__state);
    // method 33302, 0x6000e1f
    void System.IDisposable.Dispose();
    // method 33303, 0x6000e20
    bool MoveNext();
    // method 33304, 0x6000e21
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33305, 0x6000e22
    void System.Collections.IEnumerator.Reset();
    // method 33306, 0x6000e23
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4513, 0x2000252
class <IenuPerformSearch>d__107 : object {
    // field 19407, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19408, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19409, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // field 19410, runtime offset 20, flags 0x6
    public UnityEngine.Transform parent;
    // field 19411, runtime offset 24, flags 0x6
    public int expectedChildCount;
    // field 19412, runtime offset 28, flags 0x6
    public string seachString;
    // field 19413, runtime offset 32, flags 0x1
    private int <t>5__2;
    // field 19414, runtime offset 36, flags 0x1
    private int <totalAnimated>5__3;
    // field 19415, runtime offset 40, flags 0x1
    private int <i>5__4;
    // method 33307, 0x6000e24
    void .ctor(int <>1__state);
    // method 33308, 0x6000e25
    void System.IDisposable.Dispose();
    // method 33309, 0x6000e26
    bool MoveNext();
    // method 33310, 0x6000e27
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33311, 0x6000e28
    void System.Collections.IEnumerator.Reset();
    // method 33312, 0x6000e29
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4514, 0x2000253
class <IenuWaitForPerformCharacterSearch>d__98 : object {
    // field 19416, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19417, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19418, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // method 33313, 0x6000e2a
    void .ctor(int <>1__state);
    // method 33314, 0x6000e2b
    void System.IDisposable.Dispose();
    // method 33315, 0x6000e2c
    bool MoveNext();
    // method 33316, 0x6000e2d
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33317, 0x6000e2e
    void System.Collections.IEnumerator.Reset();
    // method 33318, 0x6000e2f
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4515, 0x2000254
class <IenuWaitForPerformEmoteSearch>d__99 : object {
    // field 19419, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19420, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19421, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // method 33319, 0x6000e30
    void .ctor(int <>1__state);
    // method 33320, 0x6000e31
    void System.IDisposable.Dispose();
    // method 33321, 0x6000e32
    bool MoveNext();
    // method 33322, 0x6000e33
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33323, 0x6000e34
    void System.Collections.IEnumerator.Reset();
    // method 33324, 0x6000e35
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4516, 0x2000255
class <IenuWaitForPerformHatSearch>d__96 : object {
    // field 19422, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19423, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19424, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // method 33325, 0x6000e36
    void .ctor(int <>1__state);
    // method 33326, 0x6000e37
    void System.IDisposable.Dispose();
    // method 33327, 0x6000e38
    bool MoveNext();
    // method 33328, 0x6000e39
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33329, 0x6000e3a
    void System.Collections.IEnumerator.Reset();
    // method 33330, 0x6000e3b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4517, 0x2000256
class <IenuWaitForPerformItemsSearch>d__100 : object {
    // field 19425, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19426, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19427, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // method 33331, 0x6000e3c
    void .ctor(int <>1__state);
    // method 33332, 0x6000e3d
    void System.IDisposable.Dispose();
    // method 33333, 0x6000e3e
    bool MoveNext();
    // method 33334, 0x6000e3f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33335, 0x6000e40
    void System.Collections.IEnumerator.Reset();
    // method 33336, 0x6000e41
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4518, 0x2000257
class <IenuWaitForPerformWeaponSearch>d__97 : object {
    // field 19428, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19429, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19430, runtime offset 16, flags 0x6
    public ShopPanel <>4__this;
    // method 33337, 0x6000e42
    void .ctor(int <>1__state);
    // method 33338, 0x6000e43
    void System.IDisposable.Dispose();
    // method 33339, 0x6000e44
    bool MoveNext();
    // method 33340, 0x6000e45
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33341, 0x6000e46
    void System.Collections.IEnumerator.Reset();
    // method 33342, 0x6000e47
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4519, 0x200023a
class ShopPanel : Popup {
    // field 19240, runtime offset 68, flags 0x1
    private TMPro.TMP_Text loadingTxt;
    // field 19241, runtime offset 72, flags 0x1
    private BundleFeatureWindow bundleFeatureWindow;
    // field 19242, runtime offset 76, flags 0x1
    private BundlePanel bundlePanel;
    // field 19243, runtime offset 80, flags 0x6
    public GameBundle[] gameBundles;
    // field 19244, runtime offset 84, flags 0x1
    private UnityEngine.GameObject tradingLocker;
    // field 19245, runtime offset 88, flags 0x1
    private UnityEngine.UI.Button buyKpButton;
    // field 19246, runtime offset 92, flags 0x1
    private TMPro.TMP_Text caseNotificationTxt;
    // field 19247, runtime offset 96, flags 0x1
    private TMPro.TMP_Text dailyNotificationTxt;
    // field 19248, runtime offset 100, flags 0x1
    private UnityEngine.GameObject dailyCasePanel;
    // field 19249, runtime offset 104, flags 0x1
    private UnityEngine.UI.InputField weaponSearchBar;
    // field 19250, runtime offset 108, flags 0x1
    private UnityEngine.UI.InputField hatSearchBar;
    // field 19251, runtime offset 112, flags 0x1
    private UnityEngine.UI.InputField characterSearchBar;
    // field 19252, runtime offset 116, flags 0x1
    private UnityEngine.UI.InputField emoteSearchBar;
    // field 19253, runtime offset 120, flags 0x1
    private UnityEngine.UI.InputField yourItemsSearchBar;
    // field 19254, runtime offset 124, flags 0x1
    private UnityEngine.UI.InputField crateSearchBar;
    // field 19255, runtime offset 128, flags 0x1
    private UnityEngine.GameObject[] disableForPoki;
    // field 19256, runtime offset 132, flags 0x1
    private ButtonClickedEvent showKpEvent;
    // field 19257, runtime offset 136, flags 0x6
    public ShopItemSlot shopItemSlotPrefab;
    // field 19258, runtime offset 140, flags 0x6
    public ShopItemSlot crateSlotPrefab;
    // field 19259, runtime offset 144, flags 0x1
    private UnityEngine.RectTransform characterSlotParent;
    // field 19260, runtime offset 148, flags 0x1
    private UnityEngine.RectTransform emoteSlotParent;
    // field 19261, runtime offset 152, flags 0x1
    private UnityEngine.RectTransform yourItemsSlotParent;
    // field 19262, runtime offset 156, flags 0x1
    private UnityEngine.RectTransform hatSlotParent;
    // field 19263, runtime offset 160, flags 0x1
    private UnityEngine.RectTransform caseSlotParent;
    // field 19264, runtime offset 164, flags 0x1
    private UnityEngine.RectTransform weaponsSlotParent;
    // field 19265, runtime offset 168, flags 0x6
    public TMPro.TMP_Text[] coinTxts;
    // field 19266, runtime offset 172, flags 0x1
    private UnityEngine.Coroutine loadCharactersCoroutine;
    // field 19267, runtime offset 176, flags 0x1
    private UnityEngine.Coroutine loadEmotesCoroutine;
    // field 19268, runtime offset 180, flags 0x1
    private UnityEngine.Coroutine loadYourItemsCoroutine;
    // field 19269, runtime offset 184, flags 0x1
    private UnityEngine.Coroutine loadHatsCoroutine;
    // field 19270, runtime offset 188, flags 0x1
    private UnityEngine.Coroutine loadCratesCoroutine;
    // field 19271, runtime offset 0, flags 0x8051
    private static const int minItemsToLoadForAnimation = 40;
    // field 19272, runtime offset 192, flags 0x1
    private UnityEngine.Coroutine loadWeaponsCoroutine;
    // field 19273, runtime offset 196, flags 0x1
    private UnityEngine.Coroutine waitForWeaponSearchCoroutine;
    // field 19274, runtime offset 200, flags 0x1
    private UnityEngine.Coroutine waitForHatSearchCoroutine;
    // field 19275, runtime offset 204, flags 0x1
    private UnityEngine.Coroutine waitForCharacterSearchCoroutine;
    // field 19276, runtime offset 208, flags 0x1
    private UnityEngine.Coroutine waitForEmoteSearchCoroutine;
    // field 19277, runtime offset 212, flags 0x1
    private UnityEngine.Coroutine waitForItemsSearchCoroutine;
    // field 19278, runtime offset 216, flags 0x1
    private UnityEngine.Coroutine waitForCrateSearchCoroutine;
    // field 19279, runtime offset 220, flags 0x1
    private UnityEngine.Coroutine weaponSearchCoroutine;
    // field 19280, runtime offset 224, flags 0x1
    private UnityEngine.Coroutine hatSearchCoroutine;
    // field 19281, runtime offset 228, flags 0x1
    private UnityEngine.Coroutine characterSearchCoroutine;
    // field 19282, runtime offset 232, flags 0x1
    private UnityEngine.Coroutine emoteSearchCoroutine;
    // field 19283, runtime offset 236, flags 0x1
    private UnityEngine.Coroutine itemsSearchCoroutine;
    // field 19284, runtime offset 240, flags 0x1
    private string currentWeaponSearch;
    // field 19285, runtime offset 244, flags 0x1
    private string currentHatSearch;
    // field 19286, runtime offset 248, flags 0x1
    private string currentCharacterSearch;
    // field 19287, runtime offset 252, flags 0x1
    private string currentEmoteSearch;
    // field 19288, runtime offset 256, flags 0x1
    private string currentYourItemsSearch;
    // field 19289, runtime offset 260, flags 0x1
    private SortMethod currentWeaponSort;
    // field 19290, runtime offset 264, flags 0x1
    private SortMethod currentHatSort;
    // field 19291, runtime offset 268, flags 0x1
    private SortMethod currentCharacterSort;
    // field 19292, runtime offset 272, flags 0x1
    private SortMethod currentCrateSort;
    // field 19293, runtime offset 276, flags 0x1
    private SortMethod currentEmoteSort;
    // field 19294, runtime offset 280, flags 0x1
    private SortMethod currentItemsSort;
    // field 19295, runtime offset 284, flags 0x1
    private ShopItemSlot[] skinSlots;
    // field 19296, runtime offset 288, flags 0x1
    private UnityEngine.Coroutine loadHomeCoroutine;
    // field 19297, runtime offset 0, flags 0x11
    private static ShopPanel instance;
    // field 19298, runtime offset 292, flags 0x1
    private UnityEngine.GameObject onlyAvailableOnWebsite;
    // method 33136, 0x6000d79
    bool TryFindBundle(Item item, out int bundleIndex);
    // method 33137, 0x6000d7a
    void InpsectBundle(GameBundle bundle);
    // method 33138, 0x6000d7b
    void InpsectBundle(int bundleIndex);
    // method 33139, 0x6000d7c
    float get_deltaLoadItems();
    // method 33140, 0x6000d7d
    void ShowMarketplace();
    // method 33141, 0x6000d7e
    void RefreshNotifications();
    // method 33142, 0x6000d7f
    void ShowDailyRewards();
    // method 33143, 0x6000d80
    bool IsEligibleForDailyCase();
    // method 33144, 0x6000d81
    void OpenCase(CaseData caseData);
    // method 33145, 0x6000d82
    void OpenCase(int caseIndex);
    // method 33146, 0x6000d83
    void ClaimDailyCase();
    // method 33147, 0x6000d84
    void Close(System.Action onfinish);
    // method 33148, 0x6000d85
    void Show();
    // method 33149, 0x6000d86
    void LoadCharacters();
    // method 33150, 0x6000d87
    void LoadEmotes();
    // method 33151, 0x6000d88
    void LoadYourItems();
    // method 33152, 0x6000d89
    void LoadCharacters(bool useSort);
    // method 33153, 0x6000d8a
    void LoadEmotes(bool useSort);
    // method 33154, 0x6000d8b
    void LoadYourItems(bool useSort);
    // method 33155, 0x6000d8c
    void StopLoadCoroutines();
    // method 33156, 0x6000d8d
    System.Collections.IEnumerator IenuLoadCharacters(bool useSort);
    // method 33157, 0x6000d8e
    System.Collections.IEnumerator IenuLoadEmotes(bool useSort);
    // method 33158, 0x6000d8f
    System.Collections.IEnumerator IenuLoadYourItems(bool useSort);
    // method 33159, 0x6000d90
    void LoadHats();
    // method 33160, 0x6000d91
    void LoadHats(bool useSort);
    // method 33161, 0x6000d92
    System.Collections.IEnumerator IenuLoadHats(bool useSort);
    // method 33162, 0x6000d93
    void LoadCrates();
    // method 33163, 0x6000d94
    System.Collections.IEnumerator IenuLoadCrates();
    // method 33164, 0x6000d95
    void OnCrateButtonPressed(int i);
    // method 33165, 0x6000d96
    void OnChangedWeaponSortMethod(int sortMethodIndex);
    // method 33166, 0x6000d97
    void OnChangedHatSortMethod(int sortMethodIndex);
    // method 33167, 0x6000d98
    void OnChangedCharacterSortMethod(int sortMethodIndex);
    // method 33168, 0x6000d99
    void OnChangedEmoteSortMethod(int sortMethodIndex);
    // method 33169, 0x6000d9a
    void OnChangedItemsSortMethod(int sortMethodIndex);
    // method 33170, 0x6000d9b
    void SetCurrentWeaponSearch(string search);
    // method 33171, 0x6000d9c
    void SetCurrentHatSearch(string search);
    // method 33172, 0x6000d9d
    void SetCurrentCharacterSearch(string search);
    // method 33173, 0x6000d9e
    void SetCurrentEmoteSearch(string search);
    // method 33174, 0x6000d9f
    void SetCurrentYourItemsSearch(string search);
    // method 33175, 0x6000da0
    System.Collections.IEnumerator IenuWaitForPerformHatSearch();
    // method 33176, 0x6000da1
    System.Collections.IEnumerator IenuWaitForPerformWeaponSearch();
    // method 33177, 0x6000da2
    System.Collections.IEnumerator IenuWaitForPerformCharacterSearch();
    // method 33178, 0x6000da3
    System.Collections.IEnumerator IenuWaitForPerformEmoteSearch();
    // method 33179, 0x6000da4
    System.Collections.IEnumerator IenuWaitForPerformItemsSearch();
    // method 33180, 0x6000da5
    void PerformWeaponSearch();
    // method 33181, 0x6000da6
    void PerformCharacterSearch();
    // method 33182, 0x6000da7
    void PerformEmoteSearch();
    // method 33183, 0x6000da8
    void PerformItemsSearch();
    // method 33184, 0x6000da9
    void PerformHatSearch();
    // method 33185, 0x6000daa
    void HideLoading();
    // method 33186, 0x6000dab
    System.Collections.IEnumerator IenuPerformSearch(string seachString, UnityEngine.Transform parent, int expectedChildCount);
    // method 33187, 0x6000dac
    void LoadWeapons();
    // method 33188, 0x6000dad
    void LoadWeapons(bool useSort);
    // method 33189, 0x6000dae
    System.Collections.IEnumerator IenuLoadWeapons(bool useSort);
    // method 33190, 0x6000daf
    UnityEngine.Color RarityColor(ItemRarity of);
    // method 33191, 0x6000db0
    void FreeKPButtonPressed();
    // method 33192, 0x6000db1
    CharacterSkin[] GetUnownedSkins(out System.Collections.Generic.List<int> finalIndexes);
    // method 33193, 0x6000db2
    void LoadHome();
    // method 33194, 0x6000db3
    System.Collections.IEnumerator IenuLoadHome();
    // method 33195, 0x6000db4
    void OnSkinButtonPressed(Item item, int skinIndex);
    // method 33196, 0x6000db5
    void OnEmoteButtonPressed(Item item, int emoteIndex);
    // method 33197, 0x6000db6
    void OnPurchased();
    // method 33198, 0x6000db7
    void OnHatButtonPressed(Item item, int hatIndex);
    // method 33199, 0x6000db8
    void OnItemButtonPressed(Item item, int realIndex);
    // method 33200, 0x6000db9
    void OnWeaponSkinButtonPressed(Item item, int weaponSkinIndex);
    // method 33201, 0x6000dba
    void Start();
    // method 33202, 0x6000dbb
    void SlowUpdate();
    // method 33203, 0x6000dbc
    bool TryGetInstance(out ShopPanel _instance);
    // method 33204, 0x6000dbd
    void BuyItem(string sku);
    // method 33205, 0x6000dbe
    void GiveKourPoints(int kourPointsToGive);
    // method 33206, 0x6000dbf
    void ShowKPPanel(bool forceShow);
    // method 33207, 0x6000dc0
    void .ctor();
    // method 33208, 0x6000dc1
    void <ClaimDailyCase>b__37_0(bool success);
    // method 33209, 0x6000dc2
    void <ClaimDailyCase>b__37_1(string x);
}

// TypeDefinition 4520, 0x2000259
class <>c : object {
    // field 19431, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19432, runtime offset 4, flags 0x16
    public static System.Comparison<CaseItemData> <>9__0_0;
    // method 33345, 0x6000e4a
    void .cctor();
    // method 33346, 0x6000e4b
    void .ctor();
    // method 33347, 0x6000e4c
    int <SortByRarity>b__0_0(CaseItemData a, CaseItemData b);
}

// TypeDefinition 4521, 0x2000258
class CaseItemSorter : object {
    // method 33343, 0x6000e48
    CaseItemData[] SortByRarity(CaseItemData[] items);
    // method 33344, 0x6000e49
    void .ctor();
}

// TypeDefinition 4522, 0x200025b
class <IenuAftershots>d__6 : object {
    // field 19439, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19440, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19441, runtime offset 16, flags 0x6
    public Shotgun <>4__this;
    // field 19442, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 19443, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 33354, 0x6000e53
    void .ctor(int <>1__state);
    // method 33355, 0x6000e54
    void System.IDisposable.Dispose();
    // method 33356, 0x6000e55
    bool MoveNext();
    // method 33357, 0x6000e56
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33358, 0x6000e57
    void System.Collections.IEnumerator.Reset();
    // method 33359, 0x6000e58
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4523, 0x200025c
class <IenuReloadSequences>d__10 : object {
    // field 19444, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19445, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19446, runtime offset 16, flags 0x6
    public Shotgun <>4__this;
    // field 19447, runtime offset 20, flags 0x6
    public int ammoLeft;
    // field 19448, runtime offset 24, flags 0x6
    public bool is2DSound;
    // field 19449, runtime offset 28, flags 0x1
    private int <totalSequensesToPlay>5__2;
    // field 19450, runtime offset 32, flags 0x1
    private int <_totalPlayed>5__3;
    // method 33360, 0x6000e59
    void .ctor(int <>1__state);
    // method 33361, 0x6000e5a
    void System.IDisposable.Dispose();
    // method 33362, 0x6000e5b
    bool MoveNext();
    // method 33363, 0x6000e5c
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33364, 0x6000e5d
    void System.Collections.IEnumerator.Reset();
    // method 33365, 0x6000e5e
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4524, 0x200025a
class Shotgun : Weapon {
    // field 19433, runtime offset 252, flags 0x6
    public int bulletsPerShot;
    // field 19434, runtime offset 256, flags 0x1
    private float intialAftershotDelay;
    // field 19435, runtime offset 260, flags 0x1
    private AfterShot[] aftershots;
    // field 19436, runtime offset 264, flags 0x1
    private UnityEngine.AudioSource aftershotSource;
    // field 19437, runtime offset 268, flags 0x4
    protected AudioSeq[] playOnEndOfReload;
    // field 19438, runtime offset 272, flags 0x1
    private int reloadIncreament;
    // method 33348, 0x6000e4d
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 33349, 0x6000e4e
    System.Collections.IEnumerator IenuAftershots(bool is2DSound);
    // method 33350, 0x6000e4f
    void Reload(int ammoLeft);
    // method 33351, 0x6000e50
    int GetTotalReloads(int currentlyHave);
    // method 33352, 0x6000e51
    System.Collections.IEnumerator IenuReloadSequences(bool is2DSound, int ammoLeft);
    // method 33353, 0x6000e52
    void .ctor();
}

// TypeDefinition 4525, 0x200025d
class ShowAfterTime : UnityEngine.MonoBehaviour {
    // field 19451, runtime offset 16, flags 0x1
    private UnityEngine.GameObject[] stuffToShow;
    // field 19452, runtime offset 20, flags 0x1
    private float afterTime;
    // method 33366, 0x6000e5f
    void OnEnable();
    // method 33367, 0x6000e60
    void OnDisable();
    // method 33368, 0x6000e61
    void ShowStuff();
    // method 33369, 0x6000e62
    void HideStuff();
    // method 33370, 0x6000e63
    void .ctor();
}

// TypeDefinition 4526, 0x200025e
class SimpleCameraFacingBillboard : UnityEngine.MonoBehaviour {
    // field 19453, runtime offset 16, flags 0x1
    private UnityEngine.Transform cam;
    // method 33371, 0x6000e64
    void LateUpdate();
    // method 33372, 0x6000e65
    void .ctor();
}

// TypeDefinition 4527, 0x2000260
class <IenuAftershots>d__17 : object {
    // field 19468, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19469, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19470, runtime offset 16, flags 0x6
    public Sniper <>4__this;
    // field 19471, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 19472, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 33380, 0x6000e6d
    void .ctor(int <>1__state);
    // method 33381, 0x6000e6e
    void System.IDisposable.Dispose();
    // method 33382, 0x6000e6f
    bool MoveNext();
    // method 33383, 0x6000e70
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33384, 0x6000e71
    void System.Collections.IEnumerator.Reset();
    // method 33385, 0x6000e72
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4528, 0x200025f
class Sniper : Weapon {
    // field 19454, runtime offset 252, flags 0x1
    private float aimDuration;
    // field 19455, runtime offset 256, flags 0x1
    private float fovMultiOnAim;
    // field 19456, runtime offset 260, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentPosition;
    // field 19457, runtime offset 272, flags 0x1
    private UnityEngine.Vector3 defaultWeaponParentRotation;
    // field 19458, runtime offset 284, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentPosition;
    // field 19459, runtime offset 296, flags 0x1
    private UnityEngine.Vector3 targetAimWeaponParentRotation;
    // field 19460, runtime offset 308, flags 0x1
    private UnityEngine.AudioSource aftershotSource;
    // field 19461, runtime offset 312, flags 0x1
    private float intialAftershotDelay;
    // field 19462, runtime offset 316, flags 0x1
    private AfterShot[] aftershots;
    // field 19463, runtime offset 320, flags 0x1
    private UnityEngine.GameObject[] sniperVisuals;
    // field 19464, runtime offset 324, flags 0x1
    private float instabilityWhileAiming;
    // field 19465, runtime offset 328, flags 0x1
    private bool showSniperMask;
    // field 19466, runtime offset 329, flags 0x1
    private bool aimCanceled;
    // field 19467, runtime offset 330, flags 0x1
    private bool allowAimBetweenShots;
    // method 33373, 0x6000e66
    void Aim();
    // method 33374, 0x6000e67
    void StopAim();
    // method 33375, 0x6000e68
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] hitNormals, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 33376, 0x6000e69
    System.Collections.IEnumerator IenuAftershots(bool is2DSound);
    // method 33377, 0x6000e6a
    void .ctor();
    // method 33378, 0x6000e6b
    void <Aim>b__13_0();
    // method 33379, 0x6000e6c
    void <StopAim>b__14_0();
}

// TypeDefinition 4529, 0x2000261
class AfterShot : object {
    // field 19473, runtime offset 8, flags 0x6
    public UnityEngine.AudioClip clip;
    // field 19474, runtime offset 12, flags 0x6
    public float volume;
    // field 19475, runtime offset 16, flags 0x6
    public float pitch;
    // field 19476, runtime offset 20, flags 0x6
    public float pitchRandom;
    // field 19477, runtime offset 24, flags 0x6
    public float duration;
    // field 19478, runtime offset 28, flags 0x6
    public bool playEvenIfDiePending;
    // method 33386, 0x6000e73
    void .ctor();
}

// TypeDefinition 4530, 0x2000263
class <>c : object {
    // field 19495, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19496, runtime offset 4, flags 0x16
    public static UnityEngine.Events.UnityAction <>9__21_1;
    // field 19497, runtime offset 8, flags 0x16
    public static UnityEngine.Events.UnityAction <>9__21_2;
    // method 33409, 0x6000e8a
    void .cctor();
    // method 33410, 0x6000e8b
    void .ctor();
    // method 33411, 0x6000e8c
    void <ShowRequests>b__21_1();
    // method 33412, 0x6000e8d
    void <ShowRequests>b__21_2();
}

// TypeDefinition 4531, 0x2000264
class <>c__DisplayClass17_0 : object {
    // field 19498, runtime offset 8, flags 0x6
    public string updatedClan;
    // field 19499, runtime offset 12, flags 0x6
    public SocialPanel <>4__this;
    // method 33413, 0x6000e8e
    void .ctor();
    // method 33414, 0x6000e8f
    void <OnExternalChange>b__2(string x);
}

// TypeDefinition 4532, 0x2000265
class <>c__DisplayClass18_0 : object {
    // field 19500, runtime offset 8, flags 0x6
    public SocialPanel <>4__this;
    // field 19501, runtime offset 12, flags 0x6
    public string clanName;
    // method 33415, 0x6000e90
    void .ctor();
    // method 33416, 0x6000e91
    void <CreateClan>b__0(string _result);
}

// TypeDefinition 4533, 0x2000266
class <>c__DisplayClass21_0 : object {
    // field 19502, runtime offset 8, flags 0x6
    public string currentUID;
    // field 19503, runtime offset 12, flags 0x6
    public SocialPanel <>4__this;
    // method 33417, 0x6000e92
    void .ctor();
    // method 33418, 0x6000e93
    void <ShowRequests>b__3();
    // method 33419, 0x6000e94
    void <ShowRequests>b__4();
}

// TypeDefinition 4534, 0x2000267
class <>c__DisplayClass24_0 : object {
    // field 19504, runtime offset 8, flags 0x6
    public SocialPanel <>4__this;
    // field 19505, runtime offset 12, flags 0x6
    public string memberID;
    // method 33420, 0x6000e95
    void .ctor();
    // method 33421, 0x6000e96
    void <AddMember>b__0(string result);
}

// TypeDefinition 4535, 0x2000268
class <>c__DisplayClass25_0 : object {
    // field 19506, runtime offset 8, flags 0x6
    public SocialPanel <>4__this;
    // field 19507, runtime offset 12, flags 0x6
    public string memberID;
    // method 33422, 0x6000e97
    void .ctor();
    // method 33423, 0x6000e98
    void <DeclineMember>b__0(string result);
}

// TypeDefinition 4536, 0x2000262
class SocialPanel : Popup {
    // field 19479, runtime offset 68, flags 0x1
    private ProfanityList profanityList;
    // field 19480, runtime offset 72, flags 0x1
    private ClanRequestObject[] clanRequestObjects;
    // field 19481, runtime offset 76, flags 0x1
    private FlexibleColorPicker fcp;
    // field 19482, runtime offset 80, flags 0x1
    private TMPro.TMP_Text errorMessageTxt;
    // field 19483, runtime offset 84, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 19484, runtime offset 88, flags 0x1
    private TMPro.TMP_Text leaveClanButtonTxt;
    // field 19485, runtime offset 92, flags 0x1
    private ClanMemberContainer[] clanMemberContainers;
    // field 19486, runtime offset 96, flags 0x1
    private UnityEngine.GameObject loadingPanel;
    // field 19487, runtime offset 100, flags 0x1
    private UnityEngine.GameObject requestsPanel;
    // field 19488, runtime offset 104, flags 0x1
    private UnityEngine.GameObject createClanPanel;
    // field 19489, runtime offset 108, flags 0x1
    private UnityEngine.GameObject joinClanPanel;
    // field 19490, runtime offset 112, flags 0x1
    private UnityEngine.GameObject createOrJoinClanPanel;
    // field 19491, runtime offset 116, flags 0x1
    private UnityEngine.GameObject myClanPanel;
    // field 19492, runtime offset 120, flags 0x1
    private float externalChangeCooldownTimer;
    // field 19493, runtime offset 124, flags 0x6
    public ClanData currentLoadedClan;
    // field 19494, runtime offset 128, flags 0x1
    private float lastLeave;
    // method 33387, 0x6000e74
    void ViewClanLeaderboard();
    // method 33388, 0x6000e75
    void ToggleFCP();
    // method 33389, 0x6000e76
    void Show();
    // method 33390, 0x6000e77
    void OnExternalChange();
    // method 33391, 0x6000e78
    void CreateClan(UnityEngine.UI.InputField clanIF);
    // method 33392, 0x6000e79
    void LoadMyClan();
    // method 33393, 0x6000e7a
    void ShowRequests(bool silent);
    // method 33394, 0x6000e7b
    void RemoveByValue(System.Collections.Generic.Dictionary<M_1025, M_1026> dictionary, M_1026 value);
    // method 33395, 0x6000e7c
    void CloseRequestsPanel();
    // method 33396, 0x6000e7d
    void AddMember(string clanName, string fromId, string memberID);
    // method 33397, 0x6000e7e
    void DeclineMember(string clanName, string fromId, string memberID);
    // method 33398, 0x6000e7f
    void RequestToJoinClan(UnityEngine.UI.InputField IF);
    // method 33399, 0x6000e80
    void LeaveClan();
    // method 33400, 0x6000e81
    void .ctor();
    // method 33401, 0x6000e82
    void <OnExternalChange>b__17_0(string updatedClan);
    // method 33402, 0x6000e83
    void <OnExternalChange>b__17_1(string raw);
    // method 33403, 0x6000e84
    void <LoadMyClan>b__20_0(string clanDataString);
    // method 33404, 0x6000e85
    void <LoadMyClan>b__20_1(string x);
    // method 33405, 0x6000e86
    void <ShowRequests>b__21_0(System.Collections.Generic.List<string> reqs);
    // method 33406, 0x6000e87
    void <RequestToJoinClan>b__26_0(string result);
    // method 33407, 0x6000e88
    void <LeaveClan>b__28_0();
    // method 33408, 0x6000e89
    void <LeaveClan>b__28_1(string result);
}

// TypeDefinition 4537, 0x2000269
class ColorExtensions : object {
    // method 33424, 0x6000e99
    string ToHexString(UnityEngine.Color color);
}

// TypeDefinition 4538, 0x200026a
class SpectateCamera : Photon.Pun.MonoBehaviourPun {
    // field 19508, runtime offset 20, flags 0x1
    private float xRotation;
    // field 19509, runtime offset 24, flags 0x1
    private float yRotation;
    // field 19510, runtime offset 28, flags 0x1
    private float speed;
    // field 19511, runtime offset 32, flags 0x1
    private bool isPaused;
    // field 19512, runtime offset 36, flags 0x1
    private float senseMulti;
    // field 19513, runtime offset 40, flags 0x1
    private TMPro.TMP_Text usernameTxt;
    // field 19514, runtime offset 44, flags 0x1
    private ScreenSpaceCavityCurvature.SSCC sscc;
    // field 19515, runtime offset 48, flags 0x1
    private UnityEngine.GameObject canvas;
    // field 19516, runtime offset 52, flags 0x1
    private UnityEngine.GameObject[] disableForMe;
    // field 19517, runtime offset 56, flags 0x1
    private UnityEngine.GameObject[] disableForOthers;
    // field 19518, runtime offset 60, flags 0x1
    private bool uiShowing;
    // field 19519, runtime offset 64, flags 0x1
    private float smoothness;
    // field 19520, runtime offset 68, flags 0x1
    private float current3rdAxis;
    // field 19521, runtime offset 72, flags 0x1
    private float currentVerticalAxis;
    // field 19522, runtime offset 76, flags 0x1
    private float currentHorizontalAxis;
    // method 33425, 0x6000e9a
    void ToggleUI();
    // method 33426, 0x6000e9b
    void Awake();
    // method 33427, 0x6000e9c
    void Start();
    // method 33428, 0x6000e9d
    void OnPause();
    // method 33429, 0x6000e9e
    void OnResume();
    // method 33430, 0x6000e9f
    void Update();
    // method 33431, 0x6000ea0
    float Get3rdAxis();
    // method 33432, 0x6000ea1
    float GetVerticalAxis();
    // method 33433, 0x6000ea2
    float GetHorizontalAxis();
    // method 33434, 0x6000ea3
    void .ctor();
}

// TypeDefinition 4539, 0x200026b
class StepsManager : Photon.Pun.MonoBehaviourPun {
    // field 19523, runtime offset 20, flags 0x1
    private UnityEngine.AudioClip stepClip;
    // field 19524, runtime offset 24, flags 0x1
    private UnityEngine.AudioClip jumpClip;
    // field 19525, runtime offset 28, flags 0x1
    private UnityEngine.AudioClip landClip;
    // field 19526, runtime offset 32, flags 0x1
    private CharacterAnimatorManager characterAnimatorManager;
    // field 19527, runtime offset 36, flags 0x1
    private PlayerController playerController;
    // field 19528, runtime offset 40, flags 0x1
    private UnityEngine.AudioSource mainStepsSource;
    // field 19529, runtime offset 44, flags 0x1
    private UnityEngine.AudioSource mainJumpSource;
    // field 19530, runtime offset 48, flags 0x1
    private float maxStepsSoundDistance;
    // field 19531, runtime offset 52, flags 0x1
    private float maxJumpSoundDistance;
    // field 19532, runtime offset 56, flags 0x1
    private float velMoveTreshold;
    // field 19533, runtime offset 60, flags 0x1
    private UnityEngine.Transform smoothLocalPlayerTransform;
    // field 19534, runtime offset 64, flags 0x1
    private float defaultStepsVolume;
    // field 19535, runtime offset 68, flags 0x1
    private bool lastFrameIsGrounded;
    // field 19536, runtime offset 72, flags 0x1
    private UnityEngine.Vector3 lastPlayerPosition;
    // field 19537, runtime offset 84, flags 0x1
    private float lastLandTime;
    // field 19538, runtime offset 88, flags 0x1
    private float lastJumpTime;
    // method 33435, 0x6000ea4
    void OnEnable();
    // method 33436, 0x6000ea5
    void Update();
    // method 33437, 0x6000ea6
    void OnLand();
    // method 33438, 0x6000ea7
    void OnJump();
    // method 33439, 0x6000ea8
    void .ctor();
}

// TypeDefinition 4540, 0x200026d
class <>c : object {
    // field 19543, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19544, runtime offset 4, flags 0x16
    public static System.Func<bool> <>9__11_0;
    // method 33463, 0x6000ec0
    void .cctor();
    // method 33464, 0x6000ec1
    void .ctor();
    // method 33465, 0x6000ec2
    bool <IenuUseServerFinder>b__11_0();
}

// TypeDefinition 4541, 0x200026e
class <DownloadAndLoadPrefab>d__22 : object {
    // field 19545, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19546, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19547, runtime offset 16, flags 0x6
    public string bundleUrl;
    // field 19548, runtime offset 20, flags 0x6
    public string prefabName;
    // field 19549, runtime offset 24, flags 0x6
    public StreamingAssetsLoader <>4__this;
    // field 19550, runtime offset 28, flags 0x6
    public System.Action<UnityEngine.GameObject> onDownloaded;
    // field 19551, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // field 19552, runtime offset 36, flags 0x1
    private UnityEngine.Networking.UnityWebRequestAsyncOperation <asyncOperation>5__3;
    // method 33466, 0x6000ec3
    void .ctor(int <>1__state);
    // method 33467, 0x6000ec4
    void System.IDisposable.Dispose();
    // method 33468, 0x6000ec5
    bool MoveNext();
    // method 33469, 0x6000ec6
    void <>m__Finally1();
    // method 33470, 0x6000ec7
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33471, 0x6000ec8
    void System.Collections.IEnumerator.Reset();
    // method 33472, 0x6000ec9
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4542, 0x200026f
class <IenuLoadMap>d__12 : object {
    // field 19553, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19554, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19555, runtime offset 16, flags 0x6
    public StreamingAssetsLoader <>4__this;
    // field 19556, runtime offset 20, flags 0x6
    public string mapName;
    // field 19557, runtime offset 24, flags 0x6
    public System.Action<string> onLoaded;
    // field 19558, runtime offset 28, flags 0x1
    private string <mapNickname>5__2;
    // field 19559, runtime offset 32, flags 0x1
    private UIManager <ui>5__3;
    // field 19560, runtime offset 36, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__4;
    // field 19561, runtime offset 40, flags 0x1
    private UnityEngine.Networking.UnityWebRequestAsyncOperation <asyncOperation>5__5;
    // method 33473, 0x6000eca
    void .ctor(int <>1__state);
    // method 33474, 0x6000ecb
    void System.IDisposable.Dispose();
    // method 33475, 0x6000ecc
    bool MoveNext();
    // method 33476, 0x6000ecd
    void <>m__Finally1();
    // method 33477, 0x6000ece
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33478, 0x6000ecf
    void System.Collections.IEnumerator.Reset();
    // method 33479, 0x6000ed0
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4543, 0x2000270
class <IenuLoadMapAndJoin>d__9 : object {
    // field 19562, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19563, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19564, runtime offset 16, flags 0x6
    public bool usePhoton;
    // field 19565, runtime offset 20, flags 0x6
    public StreamingAssetsLoader <>4__this;
    // field 19566, runtime offset 24, flags 0x6
    public string mapName;
    // field 19567, runtime offset 28, flags 0x1
    private string <mapNickname>5__2;
    // field 19568, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__3;
    // field 19569, runtime offset 36, flags 0x1
    private UnityEngine.Networking.UnityWebRequestAsyncOperation <asyncOperation>5__4;
    // method 33480, 0x6000ed1
    void .ctor(int <>1__state);
    // method 33481, 0x6000ed2
    void System.IDisposable.Dispose();
    // method 33482, 0x6000ed3
    bool MoveNext();
    // method 33483, 0x6000ed4
    void <>m__Finally1();
    // method 33484, 0x6000ed5
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33485, 0x6000ed6
    void System.Collections.IEnumerator.Reset();
    // method 33486, 0x6000ed7
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4544, 0x2000271
class <IenuLoadMapByName>d__24 : object {
    // field 19570, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19571, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19572, runtime offset 16, flags 0x6
    public StreamingAssetsLoader <>4__this;
    // field 19573, runtime offset 20, flags 0x6
    public string mapName;
    // field 19574, runtime offset 24, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // field 19575, runtime offset 28, flags 0x1
    private UnityEngine.Networking.UnityWebRequestAsyncOperation <asyncOperation>5__3;
    // method 33487, 0x6000ed8
    void .ctor(int <>1__state);
    // method 33488, 0x6000ed9
    void System.IDisposable.Dispose();
    // method 33489, 0x6000eda
    bool MoveNext();
    // method 33490, 0x6000edb
    void <>m__Finally1();
    // method 33491, 0x6000edc
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33492, 0x6000edd
    void System.Collections.IEnumerator.Reset();
    // method 33493, 0x6000ede
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4545, 0x2000272
class <IenuUseServerFinder>d__11 : object {
    // field 19576, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19577, runtime offset 12, flags 0x1
    private object <>2__current;
    // method 33494, 0x6000edf
    void .ctor(int <>1__state);
    // method 33495, 0x6000ee0
    void System.IDisposable.Dispose();
    // method 33496, 0x6000ee1
    bool MoveNext();
    // method 33497, 0x6000ee2
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33498, 0x6000ee3
    void System.Collections.IEnumerator.Reset();
    // method 33499, 0x6000ee4
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4546, 0x200026c
class StreamingAssetsLoader : UnityEngine.MonoBehaviour {
    // field 19539, runtime offset 0, flags 0x8056
    public static const string mobileWebPreloadMap = "map2mobile";
    // field 19540, runtime offset 0, flags 0x16
    public static StreamingAssetsLoader instance;
    // field 19541, runtime offset 4, flags 0x11
    private static bool isSubscribedOnGameSceneLoad;
    // field 19542, runtime offset 16, flags 0x1
    private UnityEngine.AssetBundle lastMapAssetBundle;
    // method 33440, 0x6000ea9
    string StreamingAssetsPath();
    // method 33441, 0x6000eaa
    void Awake();
    // method 33442, 0x6000eab
    void Start();
    // method 33443, 0x6000eac
    void PrepareMap(int mapExpectedBuildIndex, System.Action<string> onMapReady);
    // method 33444, 0x6000ead
    void PrepareMapString(string sceneName, System.Action<string> onMapReady);
    // method 33445, 0x6000eae
    void LoadLevel(int mapExpectedBuildIndex, bool usePhoton);
    // method 33446, 0x6000eaf
    System.Collections.IEnumerator IenuLoadMapAndJoin(string mapName, bool usePhoton);
    // method 33447, 0x6000eb0
    void UseServerFinder();
    // method 33448, 0x6000eb1
    System.Collections.IEnumerator IenuUseServerFinder();
    // method 33449, 0x6000eb2
    System.Collections.IEnumerator IenuLoadMap(string mapName, System.Action<string> onLoaded);
    // method 33450, 0x6000eb3
    void LoadMapAndJoin(string mapName, bool usePhoton);
    // method 33451, 0x6000eb4
    void NowLoadLevel(string mapName, bool usePhoton);
    // method 33452, 0x6000eb5
    void OnGameSceneLoad(bool _);
    // method 33453, 0x6000eb6
    string MapNameToURL(string x);
    // method 33454, 0x6000eb7
    string RemoveQueryParams(string url);
    // method 33455, 0x6000eb8
    float AdjustProgressEaseOutQuad(float actualProgress);
    // method 33456, 0x6000eb9
    void UnloadAll();
    // method 33457, 0x6000eba
    void DownloadPrefab(string assetName, System.Action<UnityEngine.GameObject> onDownloaded);
    // method 33458, 0x6000ebb
    System.Collections.IEnumerator DownloadAndLoadPrefab(string bundleUrl, string prefabName, System.Action<UnityEngine.GameObject> onDownloaded);
    // method 33459, 0x6000ebc
    void LoadMapByName(string mapName);
    // method 33460, 0x6000ebd
    System.Collections.IEnumerator IenuLoadMapByName(string mapName);
    // method 33461, 0x6000ebe
    bool MapHasMobileVersion(int map);
    // method 33462, 0x6000ebf
    void .ctor();
}

// TypeDefinition 4547, 0x2000273
class TeamMapMarker : UnityEngine.MonoBehaviour {
    // field 19578, runtime offset 16, flags 0x6
    public UnityEngine.Transform connectedTo;
    // method 33500, 0x6000ee5
    void Update();
    // method 33501, 0x6000ee6
    void .ctor();
}

// TypeDefinition 4548, 0x2000274
class TeamMember : Photon.Pun.MonoBehaviourPun {
    // field 19579, runtime offset 20, flags 0x6
    public CameraFacingBillboard globalCanvas;
    // field 19580, runtime offset 24, flags 0x1
    private UnityEngine.GameObject globalBombHolderIndicator;
    // field 19581, runtime offset 28, flags 0x1
    private UnityEngine.UI.Image teamsIcon;
    // field 19582, runtime offset 32, flags 0x1
    private UnityEngine.UI.Image[] hpImages;
    // field 19583, runtime offset 36, flags 0x1
    private TMPro.TMP_Text matchInfoTxt;
    // field 19584, runtime offset 40, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 19585, runtime offset 44, flags 0x1
    private UnityEngine.Color hpTeamMemeberColor;
    // field 19586, runtime offset 60, flags 0x1
    private UnityEngine.Color withme_color;
    // field 19587, runtime offset 76, flags 0x1
    private UnityEngine.Color againsthme_color;
    // field 19588, runtime offset 92, flags 0x1
    private UnityEngine.Color terroristWhiteColor;
    // field 19589, runtime offset 108, flags 0x1
    private UnityEngine.Color terroristColor;
    // field 19590, runtime offset 124, flags 0x1
    private UnityEngine.Color counterTerroristWhiteColor;
    // field 19591, runtime offset 140, flags 0x1
    private UnityEngine.Color counterTerroristColor;
    // field 19592, runtime offset 156, flags 0x1
    private Photon.Pun.UtilityScripts.PhotonTeam thisTeamCache;
    // method 33502, 0x6000ee7
    void SetIsBeingSpectated(bool x);
    // method 33503, 0x6000ee8
    Photon.Pun.UtilityScripts.PhotonTeam get_thisTeam();
    // method 33504, 0x6000ee9
    void OnEnable();
    // method 33505, 0x6000eea
    void TryAttachMapTracker();
    // method 33506, 0x6000eeb
    void OnDisable();
    // method 33507, 0x6000eec
    void Start();
    // method 33508, 0x6000eed
    void Update();
    // method 33509, 0x6000eee
    void OnKilledOther();
    // method 33510, 0x6000eef
    void UpdateState(bool updateOthers);
    // method 33511, 0x6000ef0
    void .ctor();
    // method 33512, 0x6000ef1
    bool <UpdateState>b__23_0(TeamMember x);
}

// TypeDefinition 4549, 0x2000275
class TeamSelectDesign : UnityEngine.ScriptableObject {
    // field 19593, runtime offset 12, flags 0x6
    public UnityEngine.Sprite team1sprite;
    // field 19594, runtime offset 16, flags 0x6
    public UnityEngine.Sprite overrideTeam1SelectImage;
    // field 19595, runtime offset 20, flags 0x6
    public UnityEngine.Sprite overrideTeam2SelectImage;
    // field 19596, runtime offset 24, flags 0x6
    public UnityEngine.Sprite team2sprite;
    // field 19597, runtime offset 28, flags 0x6
    public UnityEngine.Color team1color;
    // field 19598, runtime offset 44, flags 0x6
    public UnityEngine.Color team2color;
    // field 19599, runtime offset 60, flags 0x6
    public string team1name;
    // field 19600, runtime offset 64, flags 0x6
    public string team2name;
    // method 33513, 0x6000ef2
    void .ctor();
}

// TypeDefinition 4550, 0x2000277
class <>c : object {
    // field 19615, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19616, runtime offset 4, flags 0x16
    public static System.Func<Photon.Realtime.Player, string> <>9__17_0;
    // field 19617, runtime offset 8, flags 0x16
    public static System.Func<Photon.Realtime.Player, string> <>9__17_1;
    // method 33525, 0x6000efe
    void .cctor();
    // method 33526, 0x6000eff
    void .ctor();
    // method 33527, 0x6000f00
    string <RefreshList>b__17_0(Photon.Realtime.Player x);
    // method 33528, 0x6000f01
    string <RefreshList>b__17_1(Photon.Realtime.Player x);
}

// TypeDefinition 4551, 0x2000278
class <IenuRefreshLists>d__16 : object {
    // field 19618, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19619, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19620, runtime offset 16, flags 0x6
    public TeamSelectPanel <>4__this;
    // method 33529, 0x6000f02
    void .ctor(int <>1__state);
    // method 33530, 0x6000f03
    void System.IDisposable.Dispose();
    // method 33531, 0x6000f04
    bool MoveNext();
    // method 33532, 0x6000f05
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33533, 0x6000f06
    void System.Collections.IEnumerator.Reset();
    // method 33534, 0x6000f07
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4552, 0x2000276
class TeamSelectPanel : Popup {
    // field 19601, runtime offset 0, flags 0x11
    private static TeamSelectPanel instance;
    // field 19602, runtime offset 68, flags 0x1
    private System.Action<string, TeamSelectPanel, System.Action> onChosenTeam;
    // field 19603, runtime offset 72, flags 0x1
    private TMPro.TMP_Text errorTxt;
    // field 19604, runtime offset 76, flags 0x1
    private UnityEngine.GameObject loadingPanel;
    // field 19605, runtime offset 80, flags 0x1
    private TMPro.TMP_Text team1List;
    // field 19606, runtime offset 84, flags 0x1
    private UnityEngine.UI.Image[] teamSprites;
    // field 19607, runtime offset 88, flags 0x1
    private UnityEngine.UI.Image[] team1ToColorize;
    // field 19608, runtime offset 92, flags 0x1
    private UnityEngine.UI.Image[] team2ToColorize;
    // field 19609, runtime offset 96, flags 0x1
    private TMPro.TMP_Text team1CountTxt;
    // field 19610, runtime offset 100, flags 0x1
    private TMPro.TMP_Text team2List;
    // field 19611, runtime offset 104, flags 0x1
    private TMPro.TMP_Text team2CountTxt;
    // field 19612, runtime offset 108, flags 0x1
    private UnityEngine.GameObject simpleTutorial;
    // field 19613, runtime offset 112, flags 0x1
    private TMPro.TMP_Text titleTxt;
    // field 19614, runtime offset 116, flags 0x1
    private int autoSelectTime;
    // method 33514, 0x6000ef3
    void OnSecondPassed();
    // method 33515, 0x6000ef4
    void Init(System.Action<string, TeamSelectPanel, System.Action> onChosen, string errorMessage);
    // method 33516, 0x6000ef5
    System.Collections.IEnumerator IenuRefreshLists();
    // method 33517, 0x6000ef6
    void RefreshList();
    // method 33518, 0x6000ef7
    void Show();
    // method 33519, 0x6000ef8
    void ChooseTeam(string teamName);
    // method 33520, 0x6000ef9
    bool TryGet(out TeamSelectPanel t);
    // method 33521, 0x6000efa
    void .ctor();
    // method 33522, 0x6000efb
    void <Init>b__15_0();
    // method 33523, 0x6000efc
    void <Init>b__15_1();
    // method 33524, 0x6000efd
    void <ChooseTeam>b__19_0();
}

// TypeDefinition 4553, 0x2000279
class ColorExtensions2 : object {
    // method 33535, 0x6000f08
    string ToHex(UnityEngine.Color color);
}

// TypeDefinition 4554, 0x200027a
class TemporaryUnlockPanel : Popup {
    // field 19621, runtime offset 68, flags 0x1
    private float lifetime;
    // field 19622, runtime offset 72, flags 0x1
    private UnityEngine.GameObject classImageParent;
    // field 19623, runtime offset 76, flags 0x1
    private UnityEngine.GameObject weaponImageParent;
    // field 19624, runtime offset 80, flags 0x1
    private UnityEngine.UI.Image classImage;
    // field 19625, runtime offset 84, flags 0x1
    private UnityEngine.UI.Image weaponImage;
    // field 19626, runtime offset 88, flags 0x1
    private TMPro.TMP_Text mainTxt;
    // field 19627, runtime offset 92, flags 0x6
    public int myItemIndex;
    // field 19628, runtime offset 96, flags 0x1
    private int extraParam;
    // field 19629, runtime offset 100, flags 0x1
    private bool isAlive;
    // field 19630, runtime offset 101, flags 0x1
    private bool isWeapon;
    // field 19631, runtime offset 102, flags 0x1
    private bool isPointerDown;
    // method 33536, 0x6000f09
    void Init(bool _isWeapon, int withItemIndex, int _extraParam);
    // method 33537, 0x6000f0a
    void Hide();
    // method 33538, 0x6000f0b
    void Update();
    // method 33539, 0x6000f0c
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33540, 0x6000f0d
    void .ctor();
    // method 33541, 0x6000f0e
    void <Init>b__10_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4555, 0x200027c
class <DownloadAndLoadMesh>d__15 : object {
    // field 19638, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19639, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19640, runtime offset 16, flags 0x6
    public string assetBundleUrl;
    // field 19641, runtime offset 20, flags 0x1
    private int <attemptCount>5__2;
    // field 19642, runtime offset 24, flags 0x1
    private bool <loadSuccessful>5__3;
    // field 19643, runtime offset 28, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__4;
    // method 33555, 0x6000f1c
    void .ctor(int <>1__state);
    // method 33556, 0x6000f1d
    void System.IDisposable.Dispose();
    // method 33557, 0x6000f1e
    bool MoveNext();
    // method 33558, 0x6000f1f
    void <>m__Finally1();
    // method 33559, 0x6000f20
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33560, 0x6000f21
    void System.Collections.IEnumerator.Reset();
    // method 33561, 0x6000f22
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4556, 0x200027d
class <LoadTextureCoroutine>d__9 : object {
    // field 19644, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19645, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19646, runtime offset 16, flags 0x6
    public string url;
    // field 19647, runtime offset 20, flags 0x6
    public string skinName;
    // field 19648, runtime offset 24, flags 0x6
    public System.Action<UnityEngine.Texture2D> callback;
    // field 19649, runtime offset 28, flags 0x6
    public UnityEngine.FilterMode filterMode;
    // field 19650, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <webRequest>5__2;
    // method 33562, 0x6000f23
    void .ctor(int <>1__state);
    // method 33563, 0x6000f24
    void System.IDisposable.Dispose();
    // method 33564, 0x6000f25
    bool MoveNext();
    // method 33565, 0x6000f26
    void <>m__Finally1();
    // method 33566, 0x6000f27
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33567, 0x6000f28
    void System.Collections.IEnumerator.Reset();
    // method 33568, 0x6000f29
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4557, 0x200027b
class TextureLoader : UnityEngine.MonoBehaviour {
    // field 19632, runtime offset 0, flags 0x8051
    private static const string BASE_CONTENT_URL = "https://kour.io/content/stream";
    // field 19633, runtime offset 0, flags 0x16
    public static TextureLoader instance;
    // field 19634, runtime offset 4, flags 0x11
    private static System.Collections.Generic.Dictionary<string, UnityEngine.Texture2D> textureCache;
    // field 19635, runtime offset 8, flags 0x31
    private static object assetBundleLock;
    // field 19636, runtime offset 12, flags 0x11
    private static System.Collections.Generic.Dictionary<string, UnityEngine.Mesh> loadedAssetBundles;
    // field 19637, runtime offset 16, flags 0x11
    private static System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Action<UnityEngine.Mesh>>> loadRequests;
    // method 33542, 0x6000f0f
    void Awake();
    // method 33543, 0x6000f10
    void Start();
    // method 33544, 0x6000f11
    void GetTexture2DOf(bool force, string skinName, System.Action<UnityEngine.Texture2D> then, UnityEngine.FilterMode filterMode, int customSizePc, int customSizeMobile);
    // method 33545, 0x6000f12
    void GetTexture2DOfURL(bool force, string fullURL, System.Action<UnityEngine.Texture2D> then, UnityEngine.FilterMode filterMode, int customSizePc, int customSizeMobile);
    // method 33546, 0x6000f13
    void InstanceGetTexture2DOf(bool force, string skinName, System.Action<UnityEngine.Texture2D> then, UnityEngine.FilterMode filterMode, int MAX_SIZE, int MAX_SIZE_MOBILE);
    // method 33547, 0x6000f14
    void InstanceGetTexture2DOfURL(bool force, string fullURL, System.Action<UnityEngine.Texture2D> then, UnityEngine.FilterMode filterMode, int MAX_SIZE, int MAX_SIZE_MOBILE);
    // method 33548, 0x6000f15
    System.Collections.IEnumerator LoadTextureCoroutine(string skinName, string url, System.Action<UnityEngine.Texture2D> callback, UnityEngine.FilterMode filterMode);
    // method 33549, 0x6000f16
    void LoadAssetBundleMesh(string path, System.Action<UnityEngine.Mesh> callback);
    // method 33550, 0x6000f17
    void InstanceLoadAssetBundleMesh(string url, System.Action<UnityEngine.Mesh> callback);
    // method 33551, 0x6000f18
    System.Collections.IEnumerator DownloadAndLoadMesh(string assetBundleUrl);
    // method 33552, 0x6000f19
    void UseLoadedAssetBundle(UnityEngine.AssetBundle bundle, System.Action<UnityEngine.Mesh> callback);
    // method 33553, 0x6000f1a
    void .ctor();
    // method 33554, 0x6000f1b
    void .cctor();
}

// TypeDefinition 4558, 0x200027e
class ThirdPersonCamera : UnityEngine.MonoBehaviour {
    // field 19651, runtime offset 16, flags 0x1
    private UnityEngine.LayerMask layerMask;
    // field 19652, runtime offset 20, flags 0x1
    private UnityEngine.Transform from;
    // field 19653, runtime offset 24, flags 0x1
    private UnityEngine.Vector3 initialDirection;
    // field 19654, runtime offset 36, flags 0x1
    private UnityEngine.Vector3 initialLocalDirection;
    // field 19655, runtime offset 48, flags 0x1
    private UnityEngine.Vector3 lerpPosition;
    // field 19656, runtime offset 60, flags 0x1
    private UnityEngine.Vector3 lerpRotation;
    // field 19657, runtime offset 72, flags 0x1
    private float initialLength;
    // field 19658, runtime offset 76, flags 0x1
    private bool danceEnded;
    // method 33569, 0x6000f2a
    void Start();
    // method 33570, 0x6000f2b
    void OnEnable();
    // method 33571, 0x6000f2c
    void EndOfDance();
    // method 33572, 0x6000f2d
    void Update();
    // method 33573, 0x6000f2e
    void .ctor();
}

// TypeDefinition 4559, 0x2000280
class <>c : object {
    // field 19738, runtime offset 0, flags 0x36
    public static <>c <>9;
    // field 19739, runtime offset 4, flags 0x16
    public static System.Func<bool, bool> <>9__83_0;
    // field 19740, runtime offset 8, flags 0x16
    public static DG.Tweening.TweenCallback <>9__139_3;
    // field 19741, runtime offset 12, flags 0x16
    public static System.Action <>9__157_0;
    // field 19742, runtime offset 16, flags 0x16
    public static System.Action<bool> <>9__157_1;
    // field 19743, runtime offset 20, flags 0x16
    public static System.Func<Photon.Realtime.Player, int> <>9__170_0;
    // field 19744, runtime offset 24, flags 0x16
    public static System.Func<Photon.Realtime.Player, bool> <>9__170_1;
    // method 33688, 0x6000fa1
    void .cctor();
    // method 33689, 0x6000fa2
    void .ctor();
    // method 33690, 0x6000fa3
    bool <RefreshMissionNotification>b__83_0(bool a);
    // method 33691, 0x6000fa4
    void <Start>b__139_3();
    // method 33692, 0x6000fa5
    void <PlayPressed>b__157_0();
    // method 33693, 0x6000fa6
    void <PlayPressed>b__157_1(bool success);
    // method 33694, 0x6000fa7
    int <OnPartyUpdate>b__170_0(Photon.Realtime.Player x);
    // method 33695, 0x6000fa8
    bool <OnPartyUpdate>b__170_1(Photon.Realtime.Player x);
}

// TypeDefinition 4560, 0x2000281
class <>c__DisplayClass118_0 : object {
    // field 19745, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19746, runtime offset 12, flags 0x6
    public string text1;
    // field 19747, runtime offset 16, flags 0x6
    public string text2;
    // method 33696, 0x6000fa9
    void .ctor();
    // method 33697, 0x6000faa
    void <ShowInfoPanel>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4561, 0x2000282
class <>c__DisplayClass126_0 : object {
    // field 19748, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19749, runtime offset 12, flags 0x6
    public string requestCustom;
    // method 33698, 0x6000fab
    void .ctor();
    // method 33699, 0x6000fac
    void <ShowLeaderboardsPanel>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4562, 0x2000283
class <>c__DisplayClass127_0 : object {
    // field 19750, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19751, runtime offset 12, flags 0x6
    public string otherUserUID;
    // method 33700, 0x6000fad
    void .ctor();
    // method 33701, 0x6000fae
    void <ShowOtherUserProfile>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4563, 0x2000284
class <>c__DisplayClass129_0 : object {
    // field 19752, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19753, runtime offset 12, flags 0x6
    public string otherUserUID;
    // field 19754, runtime offset 16, flags 0x6
    public System.Action<string> <>9__4;
    // field 19755, runtime offset 20, flags 0x6
    public System.Action<string> <>9__2;
    // method 33702, 0x6000faf
    void .ctor();
    // method 33703, 0x6000fb0
    void <SetupProfilePanelWith>b__0(string rawCall);
    // method 33704, 0x6000fb1
    void <SetupProfilePanelWith>b__2(string clanDataString);
    // method 33705, 0x6000fb2
    void <SetupProfilePanelWith>b__4(string result);
}

// TypeDefinition 4564, 0x2000285
class <>c__DisplayClass129_1 : object {
    // field 19756, runtime offset 8, flags 0x6
    public UnityEngine.GameObject addFriendButton;
    // field 19757, runtime offset 12, flags 0x6
    public <>c__DisplayClass129_0 CS$<>8__locals1;
    // method 33706, 0x6000fb3
    void .ctor();
    // method 33707, 0x6000fb4
    void <SetupProfilePanelWith>b__1(string otherIsFriend);
}

// TypeDefinition 4565, 0x2000286
class <>c__DisplayClass129_2 : object {
    // field 19758, runtime offset 8, flags 0x6
    public string myLocalClan;
    // field 19759, runtime offset 12, flags 0x6
    public string me;
    // field 19760, runtime offset 16, flags 0x6
    public <>c__DisplayClass129_0 CS$<>8__locals2;
    // method 33708, 0x6000fb5
    void .ctor();
    // method 33709, 0x6000fb6
    void <SetupProfilePanelWith>b__3();
}

// TypeDefinition 4566, 0x2000287
class <>c__DisplayClass152_0 : object {
    // field 19761, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19762, runtime offset 12, flags 0x6
    public string roomName;
    // field 19763, runtime offset 16, flags 0x6
    public System.Action <>9__1;
    // method 33710, 0x6000fb7
    void .ctor();
    // method 33711, 0x6000fb8
    void <OnCustomRoomRequested>b__0();
    // method 33712, 0x6000fb9
    void <OnCustomRoomRequested>b__1();
}

// TypeDefinition 4567, 0x2000288
class <>c__DisplayClass161_0 : object {
    // field 19764, runtime offset 8, flags 0x6
    public UIManager <>4__this;
    // field 19765, runtime offset 12, flags 0x6
    public bool joinOption;
    // method 33713, 0x6000fba
    void .ctor();
    // method 33714, 0x6000fbb
    void <ShowHostPanel>b__0(UnityEngine.GameObject prefab);
}

// TypeDefinition 4568, 0x2000289
class <>c__DisplayClass74_0 : object {
    // field 19766, runtime offset 8, flags 0x6
    public string verifiedAdd;
    // field 19767, runtime offset 12, flags 0x6
    public User user;
    // field 19768, runtime offset 28, flags 0x6
    public UIManager <>4__this;
    // method 33715, 0x6000fbc
    void .ctor();
    // method 33716, 0x6000fbd
    void <OnUserChanged>b__0(string clanDataString);
}

// TypeDefinition 4569, 0x200028a
class <>c__DisplayClass9_0 : object {
    // field 19769, runtime offset 8, flags 0x6
    public UIManager i;
    // method 33717, 0x6000fbe
    void .ctor();
    // method 33718, 0x6000fbf
    void <LoadProfile>b__0(string uid);
}

// TypeDefinition 4570, 0x200028b
class <IenuUpdateLayoutGroup>d__91 : object {
    // field 19770, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19771, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19772, runtime offset 16, flags 0x6
    public UnityEngine.UI.LayoutGroup which;
    // field 19773, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform <recttransformOfTheLayoutgroup>5__2;
    // method 33719, 0x6000fc0
    void .ctor(int <>1__state);
    // method 33720, 0x6000fc1
    void System.IDisposable.Dispose();
    // method 33721, 0x6000fc2
    bool MoveNext();
    // method 33722, 0x6000fc3
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33723, 0x6000fc4
    void System.Collections.IEnumerator.Reset();
    // method 33724, 0x6000fc5
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4571, 0x200027f
class UIManager : UnityEngine.MonoBehaviour {
    // field 19659, runtime offset 16, flags 0x1
    private UnityEngine.GameObject loadoutTip;
    // field 19660, runtime offset 20, flags 0x6
    public float partyPlayerCameraSize;
    // field 19661, runtime offset 24, flags 0x6
    public UnityEngine.Vector3 partyPlayerCameraLocalPosition;
    // field 19662, runtime offset 36, flags 0x1
    private UnityEngine.GameObject downloadGooglePlayButton;
    // field 19663, runtime offset 40, flags 0x1
    private UnityEngine.GameObject leaderCrownImg;
    // field 19664, runtime offset 44, flags 0x1
    private UnityEngine.GameObject addToLobbyButton;
    // field 19665, runtime offset 48, flags 0x1
    private PfpSelectPanel pfpSelectPanel;
    // field 19666, runtime offset 52, flags 0x1
    private TMPro.TMP_Text friendsCountTxt;
    // field 19667, runtime offset 56, flags 0x1
    private UnityEngine.RectTransform fxRepeating;
    // field 19668, runtime offset 60, flags 0x1
    private UnityEngine.RectTransform playButtonRectTransform;
    // field 19669, runtime offset 64, flags 0x1
    private int[] freeCasesIndexes;
    // field 19670, runtime offset 68, flags 0x1
    private int currentIndex;
    // field 19671, runtime offset 72, flags 0x1
    private TMPro.TMP_Text versionTxt;
    // field 19672, runtime offset 76, flags 0x1
    private UnityEngine.UI.Image[] backgroundImages;
    // field 19673, runtime offset 80, flags 0x1
    private TMPro.TMP_Text regionTxt;
    // field 19674, runtime offset 84, flags 0x1
    private UnityEngine.UI.Image[] regionPositives;
    // field 19675, runtime offset 88, flags 0x6
    public LobbyPlayer lobbyPlayer;
    // field 19676, runtime offset 92, flags 0x1
    private UnityEngine.GameObject[] hideForPoki;
    // field 19677, runtime offset 96, flags 0x1
    private UnityEngine.GameObject[] hideForCrazyGames;
    // field 19678, runtime offset 100, flags 0x1
    private UnityEngine.GameObject[] destroyForMSN;
    // field 19679, runtime offset 104, flags 0x1
    private UnityEngine.GameObject[] showForCrazyGames;
    // field 19680, runtime offset 108, flags 0x1
    private UnityEngine.GameObject[] hideForAndroidAndIOS;
    // field 19681, runtime offset 112, flags 0x1
    private UnityEngine.GameObject[] hideForMobileWeb;
    // field 19682, runtime offset 116, flags 0x6
    public UnityEngine.UI.Image profileImage;
    // field 19683, runtime offset 120, flags 0x1
    private MissionsPanel missionPanel;
    // field 19684, runtime offset 124, flags 0x1
    private UnityEngine.UI.Image freeCrateImage;
    // field 19685, runtime offset 128, flags 0x1
    private UnityEngine.GameObject freeCrateUIParent;
    // field 19686, runtime offset 132, flags 0x1
    private FreeCrateMission freeCrateMissionUIParent;
    // field 19687, runtime offset 136, flags 0x1
    private CaseData currentFreeCrate;
    // field 19688, runtime offset 140, flags 0x1
    private UnityEngine.RenderTexture playerRT;
    // field 19689, runtime offset 144, flags 0x1
    private UnityEngine.GameObject[] adminObjects;
    // field 19690, runtime offset 148, flags 0x1
    private TMPro.TMP_Text infoTxt;
    // field 19691, runtime offset 152, flags 0x1
    private TMPro.TMP_Text levelTxt;
    // field 19692, runtime offset 156, flags 0x1
    private UnityEngine.UI.LayoutGroup levelTxtLayoutGroup;
    // field 19693, runtime offset 160, flags 0x1
    private TMPro.TMP_Text[] coinTxts;
    // field 19694, runtime offset 164, flags 0x6
    public UnityEngine.RectTransform canvas;
    // field 19695, runtime offset 168, flags 0x1
    private UnityEngine.Sprite randomGameModeSprite;
    // field 19696, runtime offset 172, flags 0x1
    private UnityEngine.UI.Image gameModeImg;
    // field 19697, runtime offset 176, flags 0x1
    private TMPro.TMP_Text gameModeTxt;
    // field 19698, runtime offset 180, flags 0x6
    public UnityEngine.CanvasGroup connectingLoadingPanel;
    // field 19699, runtime offset 184, flags 0x6
    public UnityEngine.RectTransform findingMatchPanel;
    // field 19700, runtime offset 188, flags 0x1
    private UnityEngine.RectTransform mainPanel;
    // field 19701, runtime offset 192, flags 0x1
    private UnityEngine.UI.InputField nicknameIF;
    // field 19702, runtime offset 196, flags 0x1
    private TMPro.TMP_Text currentClassTxt;
    // field 19703, runtime offset 200, flags 0x1
    private UnityEngine.UI.Image currentClassImg;
    // field 19704, runtime offset 0, flags 0x16
    public static UIManager instance;
    // field 19705, runtime offset 204, flags 0x1
    private UnityEngine.GameObject[] forLoggedInUsers;
    // field 19706, runtime offset 208, flags 0x1
    private UnityEngine.GameObject[] forLoggedOutUsers;
    // field 19707, runtime offset 212, flags 0x1
    private TMPro.TMP_Text[] usernameTxts;
    // field 19708, runtime offset 216, flags 0x1
    private TMPro.TMP_Text[] mainMenuUsernameTxts;
    // field 19709, runtime offset 220, flags 0x6
    public UnityEngine.UI.Image profileBackgroundImage;
    // field 19710, runtime offset 224, flags 0x1
    private TMPro.TMP_Text inboxNotificationTxt;
    // field 19711, runtime offset 228, flags 0x1
    private TMPro.TMP_Text missionNotificationTxt;
    // field 19712, runtime offset 232, flags 0x1
    private TMPro.TMP_Text shopNotificationTxt;
    // field 19713, runtime offset 236, flags 0x6
    public SocialPanel socialPanel;
    // field 19714, runtime offset 240, flags 0x1
    private LoginPanel loginPanel;
    // field 19715, runtime offset 244, flags 0x1
    private CustomGamesPanel customGamesPanel;
    // field 19716, runtime offset 248, flags 0x1
    private ProfilePanel profilePanel;
    // field 19717, runtime offset 252, flags 0x1
    private ServerFinderPanel serverFinderPanel;
    // field 19718, runtime offset 256, flags 0x1
    private Popup settingsPanel;
    // field 19719, runtime offset 260, flags 0x1
    private MobileTutorialWindow mobileTutorialPanel;
    // field 19720, runtime offset 264, flags 0x1
    private InboxManager inboxPanel;
    // field 19721, runtime offset 268, flags 0x1
    private DailyRewardsPanel dailyRewardsPanel;
    // field 19722, runtime offset 272, flags 0x1
    private ShopPanel shopPanel;
    // field 19723, runtime offset 276, flags 0x1
    private InfoPanel infoPanel;
    // field 19724, runtime offset 280, flags 0x1
    private UserRecoveryPanel userRecoveryPanel;
    // field 19725, runtime offset 284, flags 0x1
    private NewsPanel newsPanel;
    // field 19726, runtime offset 288, flags 0x1
    private LeaderboardsPanel leaderboardsPanel;
    // field 19727, runtime offset 4, flags 0x16
    public static bool playOnConnect;
    // field 19728, runtime offset 8, flags 0x31
    private static System.Collections.Generic.List<string> Names;
    // field 19729, runtime offset 292, flags 0x6
    public bool showGooglePlayButton;
    // field 19730, runtime offset 12, flags 0x16
    public static bool kourLogoRedirect;
    // field 19731, runtime offset 293, flags 0x1
    private bool isLandscape;
    // field 19732, runtime offset 294, flags 0x1
    private bool isFirstSlowUpdate;
    // field 19733, runtime offset 13, flags 0x16
    public static bool wantsToGoOffline;
    // field 19734, runtime offset 296, flags 0x1
    private HostPanel hostPanel;
    // field 19735, runtime offset 16, flags 0x16
    public static int lastFriendCount;
    // field 19736, runtime offset 300, flags 0x1
    private LobbyPlayerUI[] lobbyPlayerUIs;
    // field 19737, runtime offset 304, flags 0x1
    private TMPro.TMP_Text currentPartyIdTxt;
    // method 33574, 0x6000f2f
    void DestroyPanelsSaveMemory();
    // method 33575, 0x6000f30
    void EnterKourEngine(bool resetMap);
    // method 33576, 0x6000f31
    void LoadLobby(bool reconnect);
    // method 33577, 0x6000f32
    void LoadProfile(string username);
    // method 33578, 0x6000f33
    void EditProfilePicture();
    // method 33579, 0x6000f34
    void OnSetProfilePhoto(int index, int backgroundIndex);
    // method 33580, 0x6000f35
    void ShowMyFriendList();
    // method 33581, 0x6000f36
    string GetYourGuestName();
    // method 33582, 0x6000f37
    void AnalyticsReport(string eventName);
    // method 33583, 0x6000f38
    void AnalyticsReportEvent(string eventName);
    // method 33584, 0x6000f39
    bool LobbyPlayerCanDance();
    // method 33585, 0x6000f3a
    void KourLogoPressed();
    // method 33586, 0x6000f3b
    void SwitchImage();
    // method 33587, 0x6000f3c
    void OpenURL(string url);
    // method 33588, 0x6000f3d
    void FreeCrateButtonPressed();
    // method 33589, 0x6000f3e
    void OpenCase(CaseData caseData);
    // method 33590, 0x6000f3f
    void ShowMissionPanel();
    // method 33591, 0x6000f40
    void OnDisconnected();
    // method 33592, 0x6000f41
    void ShowDailyRewardsPanel(bool force);
    // method 33593, 0x6000f42
    void LoadScene(string sceneName);
    // method 33594, 0x6000f43
    void Awake();
    // method 33595, 0x6000f44
    bool TryGetInstance(out UIManager _instance);
    // method 33596, 0x6000f45
    void OnEnable();
    // method 33597, 0x6000f46
    void OnDisable();
    // method 33598, 0x6000f47
    void OnUserChanged(User user, bool isRegister);
    // method 33599, 0x6000f48
    void Update();
    // method 33600, 0x6000f49
    void LoadForceMap(int mapNumber);
    // method 33601, 0x6000f4a
    void CancelMatchmaking();
    // method 33602, 0x6000f4b
    void UpdateUsernameExtension(string clan, string clanColor, string u);
    // method 33603, 0x6000f4c
    void OnIsAdminApproved();
    // method 33604, 0x6000f4d
    bool IsCustomSkin(int skinIndex);
    // method 33605, 0x6000f4e
    void UpdateMainUI(string currentUserName);
    // method 33606, 0x6000f4f
    void RefreshMissionNotification();
    // method 33607, 0x6000f50
    void RefreshInboxNotification();
    // method 33608, 0x6000f51
    void RefreshShopNotification();
    // method 33609, 0x6000f52
    bool TryUpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 33610, 0x6000f53
    void UpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 33611, 0x6000f54
    System.Collections.IEnumerator IenuUpdateLayoutGroup(UnityEngine.UI.LayoutGroup which);
    // method 33612, 0x6000f55
    void UpdateCoins(int knownCoins);
    // method 33613, 0x6000f56
    void HideMobileTutorial();
    // method 33614, 0x6000f57
    void ShowLoginPanel();
    // method 33615, 0x6000f58
    void StaticShowCustomGamesPanel();
    // method 33616, 0x6000f59
    void ShowCustomGamesPanel();
    // method 33617, 0x6000f5a
    void ShowSocialPanel();
    // method 33618, 0x6000f5b
    void ShowSettingsPanel();
    // method 33619, 0x6000f5c
    void ShowInboxPanel();
    // method 33620, 0x6000f5d
    void PurchaseKPNow();
    // method 33621, 0x6000f5e
    void ShowNews();
    // method 33622, 0x6000f5f
    void ShowMarketplace();
    // method 33623, 0x6000f60
    void ShowUserRecoveryPanel();
    // method 33624, 0x6000f61
    void ShowInfoPanel(string text1, string text2);
    // method 33625, 0x6000f62
    void ShowKourTV();
    // method 33626, 0x6000f63
    void ShowTOS();
    // method 33627, 0x6000f64
    void ShowPrivacyPolicy();
    // method 33628, 0x6000f65
    void ShowAbout();
    // method 33629, 0x6000f66
    void ShowDailyRewards();
    // method 33630, 0x6000f67
    void ShowShopPanel();
    // method 33631, 0x6000f68
    void ShowServerFinderPanel();
    // method 33632, 0x6000f69
    void ShowLeaderboardsPanel(string requestCustom);
    // method 33633, 0x6000f6a
    void ShowOtherUserProfile(string otherUserUID);
    // method 33634, 0x6000f6b
    void ShowLeaderboardsPanel();
    // method 33635, 0x6000f6c
    void SetupProfilePanelWith(string otherUserUID);
    // method 33636, 0x6000f6d
    string ToShortString(double number);
    // method 33637, 0x6000f6e
    void ShowProfilePanel();
    // method 33638, 0x6000f6f
    void ShowWindowAccordingToMapInfo();
    // method 33639, 0x6000f70
    void ShuffleBackgroundImages();
    // method 33640, 0x6000f71
    void FixTotalScore();
    // method 33641, 0x6000f72
    bool IsMobileTutorialActive();
    // method 33642, 0x6000f73
    string GetNiceGuestName();
    // method 33643, 0x6000f74
    void Start();
    // method 33644, 0x6000f75
    void OnSgpb(bool x);
    // method 33645, 0x6000f76
    void OnKourLogoRedirect(bool x);
    // method 33646, 0x6000f77
    void SetLobbyAds();
    // method 33647, 0x6000f78
    void SlowUpdate();
    // method 33648, 0x6000f79
    void ChangeClassButtonPressed();
    // method 33649, 0x6000f7a
    void ForceSetGameMode(string x);
    // method 33650, 0x6000f7b
    void ChangeGameModeButtonPressed();
    // method 33651, 0x6000f7c
    void SetNickname(string nick);
    // method 33652, 0x6000f7d
    void OnCustomRoomRequested(string roomName);
    // method 33653, 0x6000f7e
    void Reconnect();
    // method 33654, 0x6000f7f
    void OnConnectedToMasterServer(string regionToken);
    // method 33655, 0x6000f80
    void GoOfflineEmergency(string password);
    // method 33656, 0x6000f81
    void PlayPressed(bool lockCursor);
    // method 33657, 0x6000f82
    bool CanPlay();
    // method 33658, 0x6000f83
    void PlayForce(bool lockCursor);
    // method 33659, 0x6000f84
    void ShowHostPanel(bool joinOption);
    // method 33660, 0x6000f85
    void PlayOnReconnected(string regionToken);
    // method 33661, 0x6000f86
    void PlayPressedWithCurrentRegion();
    // method 33662, 0x6000f87
    void LeaveParty();
    // method 33663, 0x6000f88
    void OnClassChanged(int classIndex, WeaponClass currentClass);
    // method 33664, 0x6000f89
    void OnFriendsUpdate(string[] final);
    // method 33665, 0x6000f8a
    void OnPartyUpdate();
    // method 33666, 0x6000f8b
    void .ctor();
    // method 33667, 0x6000f8c
    void .cctor();
    // method 33668, 0x6000f8d
    void <EditProfilePicture>b__11_0(UnityEngine.GameObject prefab);
    // method 33669, 0x6000f8e
    void <FreeCrateButtonPressed>b__43_0(bool success);
    // method 33670, 0x6000f8f
    void <ShowMissionPanel>b__45_0(UnityEngine.GameObject prefab);
    // method 33671, 0x6000f90
    void <ShowDailyRewardsPanel>b__64_0(UnityEngine.GameObject prefab);
    // method 33672, 0x6000f91
    void <ShowLoginPanel>b__108_0(UnityEngine.GameObject prefab);
    // method 33673, 0x6000f92
    void <ShowCustomGamesPanel>b__110_0(UnityEngine.GameObject prefab);
    // method 33674, 0x6000f93
    void <ShowSocialPanel>b__111_0(UnityEngine.GameObject prefab);
    // method 33675, 0x6000f94
    void <ShowSettingsPanel>b__112_0(UnityEngine.GameObject prefab);
    // method 33676, 0x6000f95
    void <ShowInboxPanel>b__113_0(UnityEngine.GameObject prefab);
    // method 33677, 0x6000f96
    void <PurchaseKPNow>b__114_0(UnityEngine.GameObject prefab);
    // method 33678, 0x6000f97
    void <ShowUserRecoveryPanel>b__117_0(UnityEngine.GameObject prefab);
    // method 33679, 0x6000f98
    void <ShowKourTV>b__119_0(UnityEngine.GameObject prefab);
    // method 33680, 0x6000f99
    void <ShowShopPanel>b__124_0(UnityEngine.GameObject prefab);
    // method 33681, 0x6000f9a
    void <ShowServerFinderPanel>b__125_0(UnityEngine.GameObject prefab);
    // method 33682, 0x6000f9b
    void <ShowProfilePanel>b__131_0(UnityEngine.GameObject prefab);
    // method 33683, 0x6000f9c
    void <Start>b__139_0();
    // method 33684, 0x6000f9d
    void <Start>b__139_1();
    // method 33685, 0x6000f9e
    void <Start>b__139_2(UnityEngine.Texture2D x);
    // method 33686, 0x6000f9f
    void <ChangeGameModeButtonPressed>b__150_0(string x);
    // method 33687, 0x6000fa0
    void <OnClassChanged>b__165_0(UnityEngine.Texture2D x);
}

// TypeDefinition 4572, 0x200028c
class UnbrokenEventTrigger : UnityEngine.MonoBehaviour {
    // field 19774, runtime offset 16, flags 0x6
    public UnityEngine.Events.UnityEvent<UnityEngine.EventSystems.BaseEventData> onEnter;
    // field 19775, runtime offset 20, flags 0x6
    public UnityEngine.Events.UnityEvent<UnityEngine.EventSystems.BaseEventData> onExit;
    // method 33725, 0x6000fc6
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33726, 0x6000fc7
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33727, 0x6000fc8
    void .ctor();
}

// TypeDefinition 4573, 0x200028d
class UnityAds : UnityEngine.MonoBehaviour {
    // method 33728, 0x6000fc9
    void ShowMidroll(System.Action<bool> then);
    // method 33729, 0x6000fca
    void ShowRewarded(System.Action<bool> then);
    // method 33730, 0x6000fcb
    void .ctor();
}

// TypeDefinition 4574, 0x200028e
class UnityFirebase : UnityEngine.MonoBehaviour {
    // field 19776, runtime offset 0, flags 0x16
    public static UnityFirebase Instance;
    // method 33731, 0x6000fcc
    void Logout();
    // method 33732, 0x6000fcd
    void Awake();
    // method 33733, 0x6000fce
    void Start();
    // method 33734, 0x6000fcf
    void InitializeFirebase();
    // method 33735, 0x6000fd0
    void CheckUserAuthentication();
    // method 33736, 0x6000fd1
    void .ctor();
}

// TypeDefinition 4575, 0x2000290
class <>c__DisplayClass7_0 : object {
    // field 19785, runtime offset 8, flags 0x6
    public UnlockWeaponButton <>4__this;
    // field 19786, runtime offset 12, flags 0x6
    public WeaponUpgradesPanel from;
    // field 19787, runtime offset 16, flags 0x6
    public int weaponIndex;
    // field 19788, runtime offset 20, flags 0x6
    public bool locked;
    // method 33744, 0x6000fd9
    void .ctor();
    // method 33745, 0x6000fda
    void <Init>b__0();
}

// TypeDefinition 4576, 0x2000291
class <>c__DisplayClass8_0 : object {
    // field 19789, runtime offset 8, flags 0x6
    public UnlockWeaponButton <>4__this;
    // field 19790, runtime offset 12, flags 0x6
    public WeaponSkin weaponSkin;
    // field 19791, runtime offset 16, flags 0x6
    public int weaponSkinIndex;
    // field 19792, runtime offset 20, flags 0x6
    public WeaponUpgradesPanel from;
    // field 19793, runtime offset 24, flags 0x6
    public int forWeaponIndex;
    // field 19794, runtime offset 28, flags 0x6
    public bool locked;
    // method 33746, 0x6000fdb
    void .ctor();
    // method 33747, 0x6000fdc
    void <InitSkin>b__0();
}

// TypeDefinition 4577, 0x200028f
class UnlockWeaponButton : UnityEngine.MonoBehaviour {
    // field 19777, runtime offset 16, flags 0x1
    private UnityEngine.GameObject lockedPanel;
    // field 19778, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image weaponIconImg;
    // field 19779, runtime offset 24, flags 0x1
    private UnityEngine.Sprite randomSprite;
    // field 19780, runtime offset 28, flags 0x1
    private TMPro.TMP_Text weaponNameTxt;
    // field 19781, runtime offset 32, flags 0x1
    private TMPro.TMP_Text lockLevelTxt;
    // field 19782, runtime offset 36, flags 0x1
    private UnityEngine.UI.Image lockLevelImg;
    // field 19783, runtime offset 40, flags 0x1
    private UnityEngine.UI.Button btn;
    // field 19784, runtime offset 44, flags 0x6
    public object toInspect;
    // method 33737, 0x6000fd2
    void Init(string className, WeaponUpgradesPanel from, bool isSkin, bool isRandom, bool exists, Weapon weapon, int weaponIndex, int currentLevel, int unlocksAtLevel);
    // method 33738, 0x6000fd3
    void InitSkin(WeaponUpgradesPanel from, WeaponSkin weaponSkin, int weaponSkinIndex, int forWeaponIndex, int availableCount);
    // method 33739, 0x6000fd4
    void OnClicked(WeaponUpgradesPanel from, bool isSkin, int indexChose, int forWeaponIndex, bool locked);
    // method 33740, 0x6000fd5
    void OnClickedSkin(WeaponSkin weaponSkin, int weaponSkinIndex, WeaponUpgradesPanel from, bool isSkin, int indexChose, int forWeaponIndex, bool locked);
    // method 33741, 0x6000fd6
    void InfoButtonPressed();
    // method 33742, 0x6000fd7
    UnityEngine.Color ToColorFromHex(string hex);
    // method 33743, 0x6000fd8
    void .ctor();
}

// TypeDefinition 4578, 0x2000292
class UserStatusManager : UnityEngine.MonoBehaviour {
    // field 19795, runtime offset 16, flags 0x6
    public UnityEngine.GameObject bannedCanvasPrefab;
    // field 19796, runtime offset 0, flags 0x16
    public static UserStatusManager Instance;
    // method 33748, 0x6000fdd
    void Start();
    // method 33749, 0x6000fde
    void OnEnable();
    // method 33750, 0x6000fdf
    void OnDisable();
    // method 33751, 0x6000fe0
    void OnUserChanged(User u, bool r);
    // method 33752, 0x6000fe1
    void OnHackerDetected(string reason);
    // method 33753, 0x6000fe2
    void .ctor();
}

// TypeDefinition 4579, 0x2000293
class UsernameContainer : UnityEngine.MonoBehaviour {
    // method 33754, 0x6000fe3
    void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33755, 0x6000fe4
    void .ctor();
}

// TypeDefinition 4580, 0x2000295
class WeaponType : System.Enum {
    // field 19853, runtime offset 8, flags 0x606
    public int value__;
    // field 19854, runtime offset 0, flags 0x8056
    public static const WeaponType Rifle = 0;
    // field 19855, runtime offset 0, flags 0x8056
    public static const WeaponType Pistol = 1;
    // field 19856, runtime offset 0, flags 0x8056
    public static const WeaponType Knife = 2;
    // field 19857, runtime offset 0, flags 0x8056
    public static const WeaponType Bomb = 3;
    // field 19858, runtime offset 0, flags 0x8056
    public static const WeaponType Grenade = 4;
}

// TypeDefinition 4581, 0x2000296
class <>c__DisplayClass11_0 : object {
    // field 19859, runtime offset 8, flags 0x6
    public Weapon <>4__this;
    // field 19860, runtime offset 12, flags 0x6
    public bool useStandardShader;
    // method 33776, 0x6000ff9
    void .ctor();
    // method 33777, 0x6000ffa
    void <SetSkin>b__0(UnityEngine.Texture2D x);
}

// TypeDefinition 4582, 0x2000297
class <AftersmokeCoroutine>d__66 : object {
    // field 19861, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19862, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19863, runtime offset 16, flags 0x6
    public Weapon <>4__this;
    // method 33778, 0x6000ffb
    void .ctor(int <>1__state);
    // method 33779, 0x6000ffc
    void System.IDisposable.Dispose();
    // method 33780, 0x6000ffd
    bool MoveNext();
    // method 33781, 0x6000ffe
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33782, 0x6000fff
    void System.Collections.IEnumerator.Reset();
    // method 33783, 0x6001000
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4583, 0x2000298
class <IenuLoadSequences>d__69 : object {
    // field 19864, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19865, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19866, runtime offset 16, flags 0x6
    public Weapon <>4__this;
    // field 19867, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 19868, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 33784, 0x6001001
    void .ctor(int <>1__state);
    // method 33785, 0x6001002
    void System.IDisposable.Dispose();
    // method 33786, 0x6001003
    bool MoveNext();
    // method 33787, 0x6001004
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33788, 0x6001005
    void System.Collections.IEnumerator.Reset();
    // method 33789, 0x6001006
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4584, 0x2000299
class <IenuReloadSequences>d__68 : object {
    // field 19869, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19870, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19871, runtime offset 16, flags 0x6
    public Weapon <>4__this;
    // field 19872, runtime offset 20, flags 0x6
    public bool is2DSound;
    // field 19873, runtime offset 24, flags 0x1
    private int <totalPlayed>5__2;
    // method 33790, 0x6001007
    void .ctor(int <>1__state);
    // method 33791, 0x6001008
    void System.IDisposable.Dispose();
    // method 33792, 0x6001009
    bool MoveNext();
    // method 33793, 0x600100a
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33794, 0x600100b
    void System.Collections.IEnumerator.Reset();
    // method 33795, 0x600100c
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4585, 0x2000294
class Weapon : UnityEngine.MonoBehaviour {
    // field 19797, runtime offset 16, flags 0x6
    public FPSArms arms;
    // field 19798, runtime offset 20, flags 0x6
    public ItemRarity rarity;
    // field 19799, runtime offset 24, flags 0x6
    public string defaultSkinName;
    // field 19800, runtime offset 28, flags 0x1
    private UnityEngine.Material customMaterialForSkins;
    // field 19801, runtime offset 32, flags 0x6
    public bool shootOnRelease;
    // field 19802, runtime offset 33, flags 0x6
    public bool holdToAim;
    // field 19803, runtime offset 36, flags 0x6
    public CrosshairStyle crosshairStyle;
    // field 19804, runtime offset 40, flags 0x6
    public float relativeWeaponSize;
    // field 19805, runtime offset 44, flags 0x1
    private UnityEngine.Renderer[] weaponRenderers;
    // field 19806, runtime offset 48, flags 0x6
    public float staticInstabilityAdd;
    // field 19807, runtime offset 52, flags 0x6
    public float minDistance;
    // field 19808, runtime offset 56, flags 0x6
    public float maxDistance;
    // field 19809, runtime offset 60, flags 0x6
    public float[] bulletAddReloadTimes;
    // field 19810, runtime offset 64, flags 0x6
    public bool holdToShoot;
    // field 19811, runtime offset 68, flags 0x6
    public UnityEngine.Sprite icon;
    // field 19812, runtime offset 72, flags 0x1
    private string realisticIconPath;
    // field 19813, runtime offset 76, flags 0x1
    private AudioSeq[] loadSequences;
    // field 19814, runtime offset 80, flags 0x1
    private UnityEngine.ParticleSystem aftersmokeParticleFx;
    // field 19815, runtime offset 84, flags 0x6
    public WeaponType weaponType;
    // field 19816, runtime offset 88, flags 0x1
    private UnityEngine.Coroutine aftersmokeCoroutine;
    // field 19817, runtime offset 92, flags 0x4
    protected AudioSeq[] reloadSequences;
    // field 19818, runtime offset 96, flags 0x4
    protected UnityEngine.AudioSource reloadSource;
    // field 19819, runtime offset 100, flags 0x4
    protected float intialReloadSoundDelay;
    // field 19820, runtime offset 104, flags 0x1
    private float initialLoadSoundDelay;
    // field 19821, runtime offset 108, flags 0x6
    public bool isLocal;
    // field 19822, runtime offset 112, flags 0x6
    public Shooter myShooter;
    // field 19823, runtime offset 116, flags 0x6
    public UnityEngine.GameObject sniperMask;
    // field 19824, runtime offset 120, flags 0x6
    public CrosshairReticle crosshair;
    // field 19825, runtime offset 124, flags 0x6
    public float changeWeaponTimerAdd;
    // field 19826, runtime offset 128, flags 0x6
    public float groundSpeedMulti;
    // field 19827, runtime offset 132, flags 0x6
    public float airSpeedMulti;
    // field 19828, runtime offset 136, flags 0x6
    public float fireRate;
    // field 19829, runtime offset 140, flags 0x6
    public float reloadTime;
    // field 19830, runtime offset 144, flags 0x6
    public float recoilCrazinessCrosshair;
    // field 19831, runtime offset 148, flags 0x6
    public float recoilCrazinessPhysical;
    // field 19832, runtime offset 152, flags 0x6
    public float recoilReturnSpeed;
    // field 19833, runtime offset 156, flags 0x6
    public int damage;
    // field 19834, runtime offset 160, flags 0x6
    public int maxAmmo;
    // field 19835, runtime offset 164, flags 0x6
    public float instabilityMultiplier;
    // field 19836, runtime offset 168, flags 0x4
    protected float initialInstabilityMultiplier;
    // field 19837, runtime offset 172, flags 0x1
    private UnityEngine.Animator cacheAnimator;
    // field 19838, runtime offset 176, flags 0x6
    public UnityEngine.Transform weaponOffsetParent;
    // field 19839, runtime offset 180, flags 0x6
    public UnityEngine.Camera[] currentCameras;
    // field 19840, runtime offset 184, flags 0x1
    private UnityEngine.Transform bulletSpawnPoint;
    // field 19841, runtime offset 188, flags 0x1
    private Bullet bulletPrefab;
    // field 19842, runtime offset 192, flags 0x4
    protected UnityEngine.AudioSource audioSource;
    // field 19843, runtime offset 196, flags 0x1
    private MuzzleFlash muzzleFlash;
    // field 19844, runtime offset 200, flags 0x6
    public UnityEngine.GameObject handsModel;
    // field 19845, runtime offset 204, flags 0x6
    public bool isAiming;
    // field 19846, runtime offset 205, flags 0x6
    public bool isReloading;
    // field 19847, runtime offset 208, flags 0x1
    private int bulletCountRow;
    // field 19848, runtime offset 212, flags 0x1
    private float lastShotTime;
    // field 19849, runtime offset 216, flags 0x4
    protected float cantAimTime;
    // field 19850, runtime offset 220, flags 0x1
    private CodeStage.AntiCheat.ObscuredTypes.ObscuredFloat lastShootTime;
    // field 19851, runtime offset 244, flags 0x4
    protected bool isDiePending;
    // field 19852, runtime offset 248, flags 0x6
    public string lobbyAnimatorPlayAnimationName;
    // method 33756, 0x6000fe5
    UnityEngine.Renderer[] GetWeaponRenderers();
    // method 33757, 0x6000fe6
    UnityEngine.GameObject GetFirstWeaponRendererObject();
    // method 33758, 0x6000fe7
    void SetSkin(bool force, bool useStandardShader, string skinName);
    // method 33759, 0x6000fe8
    void ApplySkinTexture(bool useStandardShader, UnityEngine.Texture2D texture);
    // method 33760, 0x6000fe9
    void OnUserMouseUp();
    // method 33761, 0x6000fea
    void SetImageWithMyRealisticIcon(UnityEngine.UI.Image image, int customSize, bool animate);
    // method 33762, 0x6000feb
    void Start();
    // method 33763, 0x6000fec
    void OnStart();
    // method 33764, 0x6000fed
    UnityEngine.Animator get_animator();
    // method 33765, 0x6000fee
    void Shoot(UnityEngine.Vector3[] targetPoses, UnityEngine.Vector3[] normalDirs, UnityEngine.Vector3 camForward, bool is2DSound, bool isMine);
    // method 33766, 0x6000fef
    System.Collections.IEnumerator AftersmokeCoroutine();
    // method 33767, 0x6000ff0
    void Reload(int ammoLeft);
    // method 33768, 0x6000ff1
    System.Collections.IEnumerator IenuReloadSequences(bool is2DSound);
    // method 33769, 0x6000ff2
    System.Collections.IEnumerator IenuLoadSequences(bool is2DSound);
    // method 33770, 0x6000ff3
    void Die();
    // method 33771, 0x6000ff4
    void Aim();
    // method 33772, 0x6000ff5
    void StopAim();
    // method 33773, 0x6000ff6
    void EndReload();
    // method 33774, 0x6000ff7
    void Inspect();
    // method 33775, 0x6000ff8
    void .ctor();
}

// TypeDefinition 4586, 0x200029a
class AudioSeq : object {
    // field 19874, runtime offset 8, flags 0x6
    public UnityEngine.AudioClip clip;
    // field 19875, runtime offset 12, flags 0x6
    public float volume;
    // field 19876, runtime offset 16, flags 0x6
    public float pitch;
    // field 19877, runtime offset 20, flags 0x6
    public float pitchRandom;
    // field 19878, runtime offset 24, flags 0x6
    public float duration;
    // field 19879, runtime offset 28, flags 0x6
    public bool playEvenIfDiePending;
    // method 33796, 0x600100d
    void .ctor();
}

// TypeDefinition 4587, 0x200029b
class WeaponCarrier : UnityEngine.MonoBehaviour {
    // field 19880, runtime offset 16, flags 0x6
    public WeaponCarrierData data;
    // field 19881, runtime offset 0, flags 0x16
    public static int currentClassIndex;
    // field 19882, runtime offset 4, flags 0x16
    public static WeaponCarrier instance;
    // field 19883, runtime offset 8, flags 0x16
    public static int _currentSkinIndex;
    // method 33797, 0x600100e
    int SafeHatIndex(int given);
    // method 33798, 0x600100f
    int SafeEmoteIndex(int given);
    // method 33799, 0x6001010
    void Awake();
    // method 33800, 0x6001011
    int RealIndexOfWeapon(Weapon skin);
    // method 33801, 0x6001012
    int RealIndexOfItem(Item skin);
    // method 33802, 0x6001013
    int InstanceRealIndexOfWeaponByName(Weapon weapon);
    // method 33803, 0x6001014
    int InstanceRealIndexOfItem(Item item);
    // method 33804, 0x6001015
    int FindIndexByName(Item[] items, string itemName);
    // method 33805, 0x6001016
    void Start();
    // method 33806, 0x6001017
    WeaponClass GetRandomClass(out int index);
    // method 33807, 0x6001018
    bool IsCustomSkin(int skinIndex);
    // method 33808, 0x6001019
    void SetClass(int classIndex);
    // method 33809, 0x600101a
    int[] InitialClasses();
    // method 33810, 0x600101b
    WeaponClass GetCurrentClass(out int classIndex);
    // method 33811, 0x600101c
    void set_currentSkinIndex(int value);
    // method 33812, 0x600101d
    int get_currentSkinIndex();
    // method 33813, 0x600101e
    void RefreshSkinWith(int with);
    // method 33814, 0x600101f
    void .ctor();
}

// TypeDefinition 4588, 0x200029c
class ClassLevel : object {
    // field 19884, runtime offset 8, flags 0x6
    public int KillsForLevel;
    // field 19885, runtime offset 12, flags 0x6
    public int[] unlocksWeaponPair;
    // method 33815, 0x6001020
    void .ctor(int killsForLevel);
    // method 33816, 0x6001021
    void .ctor(int killsForLevel, int wepLocalIndex, int unlocksWeapon);
}

// TypeDefinition 4589, 0x200029d
class WeaponCarrierData : UnityEngine.ScriptableObject {
    // field 19886, runtime offset 12, flags 0x6
    public UnityEngine.Material defaultCharacterMaterial;
    // field 19887, runtime offset 16, flags 0x6
    public UnityEngine.Material transparentCharacterMaterial;
    // field 19888, runtime offset 20, flags 0x6
    public Sound[] kourstrikeSounds;
    // field 19889, runtime offset 24, flags 0x6
    public CharacterSkinData[] characterSkinDatas;
    // field 19890, runtime offset 28, flags 0x6
    public TeamSelectDesign[] teamSelectDesigns;
    // field 19891, runtime offset 32, flags 0x6
    public Emote[] emotes;
    // field 19892, runtime offset 36, flags 0x6
    public CaseData dailyCaseData;
    // field 19893, runtime offset 40, flags 0x6
    public CaseData[] caseDatas;
    // field 19894, runtime offset 44, flags 0x6
    public WeaponSkin[] allWeaponSkins;
    // field 19895, runtime offset 48, flags 0x6
    public CharacterSkin[] characterCustomSkins;
    // field 19896, runtime offset 52, flags 0x6
    public Hat[] allHats;
    // field 19897, runtime offset 56, flags 0x6
    public Weapon[] allWeapons;
    // field 19898, runtime offset 60, flags 0x6
    public WeaponClass[] classes;
    // field 19899, runtime offset 64, flags 0x6
    public KP kp;
    // field 19900, runtime offset 68, flags 0x6
    public XP xp;
    // method 33817, 0x6001022
    void .ctor();
}

// TypeDefinition 4590, 0x200029e
class WeaponClass : UnityEngine.ScriptableObject {
    // field 19901, runtime offset 12, flags 0x6
    public bool canGetChosenRandomly;
    // field 19902, runtime offset 16, flags 0x6
    public int overrideCharacterSkinIndex;
    // field 19903, runtime offset 20, flags 0x6
    public string description;
    // field 19904, runtime offset 24, flags 0x6
    public string iconName;
    // field 19905, runtime offset 28, flags 0x6
    public int[] weaponIndexes;
    // field 19906, runtime offset 32, flags 0x6
    public int[] overrideWeaponIndexesNew;
    // field 19907, runtime offset 36, flags 0x6
    public int health;
    // field 19908, runtime offset 40, flags 0x6
    public ClassLevel[] classLevels;
    // field 19909, runtime offset 44, flags 0x6
    public bool firstLevelIsUnlock;
    // method 33818, 0x6001023
    string get_iconPath();
    // method 33819, 0x6001024
    int[] get_finalWeaponIndexes();
    // method 33820, 0x6001025
    void .ctor();
}

// TypeDefinition 4591, 0x200029f
class WeaponGameplayIcon : UnityEngine.MonoBehaviour {
    // field 19910, runtime offset 16, flags 0x1
    private UnityEngine.UI.Image[] enableForBr;
    // field 19911, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image image;
    // method 33821, 0x6001026
    void Init(Weapon withWeapon, int myIndex, bool isUsing);
    // method 33822, 0x6001027
    void UpdateVisual(bool isUsing);
    // method 33823, 0x6001028
    void .ctor();
}

// TypeDefinition 4592, 0x20002a1
class <>c__DisplayClass7_0 : object {
    // field 19917, runtime offset 8, flags 0x6
    public System.Action customizePressed;
    // method 33828, 0x600102d
    void .ctor();
    // method 33829, 0x600102e
    void <SetWeapon>b__0();
}

// TypeDefinition 4593, 0x20002a0
class WeaponPreviewer : UnityEngine.MonoBehaviour {
    // field 19912, runtime offset 16, flags 0x1
    private UnityEngine.Transform weaponInspectParent;
    // field 19913, runtime offset 20, flags 0x1
    private TMPro.TMP_Text nameTxt;
    // field 19914, runtime offset 24, flags 0x1
    private UnityEngine.UI.Button customizeButton;
    // field 19915, runtime offset 0, flags 0x16
    public static WeaponPreviewer instance;
    // field 19916, runtime offset 28, flags 0x1
    private bool initiated;
    // method 33824, 0x6001029
    void OnEnable();
    // method 33825, 0x600102a
    void InitialSet(int weaponIndex, System.Action customizePressed);
    // method 33826, 0x600102b
    void SetWeapon(int weaponIndex, System.Action customizePressed);
    // method 33827, 0x600102c
    void .ctor();
}

// TypeDefinition 4594, 0x20002a2
class WeaponSkin : Item {
    // field 19918, runtime offset 68, flags 0x6
    public bool showForKourstrike;
    // field 19919, runtime offset 69, flags 0x6
    public bool isTextureRaw;
    // field 19920, runtime offset 72, flags 0x6
    public string skinName;
    // field 19921, runtime offset 76, flags 0x6
    public Weapon forWeapon;
    // method 33830, 0x600102f
    void SetImageToMySprite(UnityEngine.UI.Image image, int customSize);
    // method 33831, 0x6001030
    string get_HasItKey();
    // method 33832, 0x6001031
    void SetAsCurrent();
    // method 33833, 0x6001032
    string get_IsCurrentKey();
    // method 33834, 0x6001033
    void .ctor();
}

// TypeDefinition 4595, 0x20002a3
class WeaponSway : UnityEngine.MonoBehaviour {
    // field 19922, runtime offset 16, flags 0x1
    private UnityEngine.Quaternion initialRotation;
    // field 19923, runtime offset 32, flags 0x1
    private UnityEngine.Vector3 initialPosition;
    // field 19924, runtime offset 44, flags 0x1
    private UnityEngine.Camera cam;
    // field 19925, runtime offset 48, flags 0x1
    private UnityEngine.Camera weaponCam;
    // field 19926, runtime offset 52, flags 0x1
    private PlayerInputHandler playerInput;
    // field 19927, runtime offset 56, flags 0x1
    private Shooter shooter;
    // field 19928, runtime offset 60, flags 0x6
    public float swayAmount;
    // field 19929, runtime offset 64, flags 0x6
    public float moveSwayAmount;
    // field 19930, runtime offset 68, flags 0x6
    public float swaySpeed;
    // field 19931, runtime offset 72, flags 0x6
    public float maxLookAxisX;
    // field 19932, runtime offset 76, flags 0x6
    public float maxLookAxisY;
    // field 19933, runtime offset 80, flags 0x1
    private float initialFOV;
    // field 19934, runtime offset 0, flags 0x8056
    public static const float FIELD_OF_VIEW_MULTI = 0.6800000071525574;
    // field 19935, runtime offset 0, flags 0x8056
    public static const int DEFAULT_FOV = 95;
    // method 33835, 0x6001034
    void Start();
    // method 33836, 0x6001035
    void OnFOVChanged(int to);
    // method 33837, 0x6001036
    void Update();
    // method 33838, 0x6001037
    void .ctor();
}

// TypeDefinition 4596, 0x20002a4
class WeaponUpgradesPanel : UnityEngine.MonoBehaviour {
    // field 19936, runtime offset 16, flags 0x1
    private UnlockWeaponButton unlockWeaponButtonPrefab;
    // field 19937, runtime offset 20, flags 0x1
    private UnityEngine.RectTransform unlockWeaponButtonsParent;
    // field 19938, runtime offset 24, flags 0x1
    private int lastSelectedWeaponIndexFilter;
    // field 19939, runtime offset 28, flags 0x1
    private ClassSelectPanel classSelectPanel;
    // method 33839, 0x6001038
    void Show(ClassSelectPanel _classSelectPanel, int selectedWeaponIndexFilter);
    // method 33840, 0x6001039
    void OnChoseWeapon(bool isSkin, int indexChosen, int forWeaponIndex);
    // method 33841, 0x600103a
    int GetClassLevelByWeapon(WeaponClass weaponClass, int weaponIndexThatUnlocks);
    // method 33842, 0x600103b
    void .ctor();
}

// TypeDefinition 4597, 0x20002a6
class <Defuse>d__20 : object {
    // field 19953, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19954, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19955, runtime offset 16, flags 0x6
    public WorldBomb <>4__this;
    // field 19956, runtime offset 20, flags 0x6
    public bool isMine;
    // field 19957, runtime offset 24, flags 0x1
    private float <defuseTime>5__2;
    // field 19958, runtime offset 28, flags 0x1
    private float <startTime>5__3;
    // method 33855, 0x6001048
    void .ctor(int <>1__state);
    // method 33856, 0x6001049
    void System.IDisposable.Dispose();
    // method 33857, 0x600104a
    bool MoveNext();
    // method 33858, 0x600104b
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33859, 0x600104c
    void System.Collections.IEnumerator.Reset();
    // method 33860, 0x600104d
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4598, 0x20002a5
class WorldBomb : UnityEngine.MonoBehaviour {
    // field 19940, runtime offset 16, flags 0x6
    public UnityEngine.Transform spectateOn;
    // field 19941, runtime offset 0, flags 0x8056
    public static const double BOMB_ALIVE_TIME = 50;
    // field 19942, runtime offset 20, flags 0x6
    public int isBeingDefusedById;
    // field 19943, runtime offset 24, flags 0x6
    public bool isDefused;
    // field 19944, runtime offset 32, flags 0x1
    private double spawnTime;
    // field 19945, runtime offset 40, flags 0x1
    private float nextBeepTime;
    // field 19946, runtime offset 0, flags 0x8051
    private static const float initialBeepInterval = 1;
    // field 19947, runtime offset 44, flags 0x1
    private UnityEngine.AudioSource beep;
    // field 19948, runtime offset 48, flags 0x1
    private UnityEngine.GameObject exploadEffect;
    // field 19949, runtime offset 52, flags 0x1
    private UnityEngine.Transform lightPlane;
    // field 19950, runtime offset 56, flags 0x1
    private bool exploaded;
    // field 19951, runtime offset 57, flags 0x1
    private bool thisIsTheEndVoicelineCheck;
    // field 19952, runtime offset 0, flags 0x16
    public static UnityEngine.Vector3 lastKnownWorldBombPosition;
    // method 33843, 0x600103c
    void Init(double bombSpawnTime);
    // method 33844, 0x600103d
    void Update();
    // method 33845, 0x600103e
    void Expload();
    // method 33846, 0x600103f
    void PlayBeepSound(float p);
    // method 33847, 0x6001040
    float EaseInQuart(float t);
    // method 33848, 0x6001041
    float EaseInQuad(float t);
    // method 33849, 0x6001042
    void TryDefuse(bool isMine, int byId);
    // method 33850, 0x6001043
    System.Collections.IEnumerator Defuse(bool isMine);
    // method 33851, 0x6001044
    void .ctor();
    // method 33852, 0x6001045
    void .cctor();
    // method 33853, 0x6001046
    void <PlayBeepSound>b__16_0();
    // method 33854, 0x6001047
    void <PlayBeepSound>b__16_1();
}

// TypeDefinition 4599, 0x20002a8
class GrenadeType : System.Enum {
    // field 19972, runtime offset 8, flags 0x606
    public int value__;
    // field 19973, runtime offset 0, flags 0x8056
    public static const GrenadeType Normal = 0;
    // field 19974, runtime offset 0, flags 0x8056
    public static const GrenadeType Flash = 1;
    // field 19975, runtime offset 0, flags 0x8056
    public static const GrenadeType Smoke = 2;
    // field 19976, runtime offset 0, flags 0x8056
    public static const GrenadeType Molotov = 3;
    // field 19977, runtime offset 0, flags 0x8056
    public static const GrenadeType Decoy = 4;
}

// TypeDefinition 4600, 0x20002a7
class WorldGrenade : Photon.Pun.MonoBehaviourPun {
    // field 19959, runtime offset 20, flags 0x1
    private UnityEngine.LayerMask explosionLayerMask;
    // field 19960, runtime offset 24, flags 0x1
    private UnityEngine.GameObject fireTrail;
    // field 19961, runtime offset 28, flags 0x1
    private UnityEngine.MeshFilter meshFilter;
    // field 19962, runtime offset 32, flags 0x1
    private UnityEngine.MeshRenderer meshRenderer;
    // field 19963, runtime offset 36, flags 0x1
    private UnityEngine.LayerMask obstacleMask;
    // field 19964, runtime offset 40, flags 0x1
    private UnityEngine.Rigidbody rb;
    // field 19965, runtime offset 44, flags 0x1
    private UnityEngine.GameObject explosionFxGo;
    // field 19966, runtime offset 48, flags 0x1
    private GrenadeType myGrenadeType;
    // field 19967, runtime offset 52, flags 0x1
    private int myDamage;
    // field 19968, runtime offset 56, flags 0x1
    private bool exploaded;
    // field 19969, runtime offset 0, flags 0x8051
    private static const float flashRadius = 88;
    // field 19970, runtime offset 0, flags 0x8051
    private static const float maxFlashStrength = 1;
    // field 19971, runtime offset 0, flags 0x8051
    private static const float addToFlashHitCheck = 1.7699999809265137;
    // method 33861, 0x600104e
    void Start();
    // method 33862, 0x600104f
    void Init(UnityEngine.Vector3 forward, GrenadeType grenadeType, UnityEngine.GameObject explosionFx, string skinName);
    // method 33863, 0x6001050
    void Expload(UnityEngine.Vector3 normal);
    // method 33864, 0x6001051
    void RpcExploadAt(UnityEngine.Vector3 pos, UnityEngine.Vector3 normal);
    // method 33865, 0x6001052
    void ExplodeFlash();
    // method 33866, 0x6001053
    void OnCollisionEnter(UnityEngine.Collision collision);
    // method 33867, 0x6001054
    void Explodato();
    // method 33868, 0x6001055
    float CalculateDamageByDistance(float currentDistance, float minDistance, float maxDistance, float maxDamage);
    // method 33869, 0x6001056
    int[] GetTargetIDs(int givenAmount, UnityEngine.Collider[] cols, out UnityEngine.Transform[] transforms);
    // method 33870, 0x6001057
    void ExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs);
    // method 33871, 0x6001058
    void RPCExplosiveDamage(int[] damages, bool showFeedback, int[] targetViewIDs);
    // method 33872, 0x6001059
    void .ctor();
    // method 33873, 0x600105a
    void <Init>b__11_0(UnityEngine.Mesh mesh);
    // method 33874, 0x600105b
    void <Init>b__11_1(UnityEngine.Texture2D texture);
    // method 33875, 0x600105c
    void <Init>b__11_2();
}

// TypeDefinition 4601, 0x20002a9
class WorldHitmark : UnityEngine.MonoBehaviour {
    // field 19978, runtime offset 16, flags 0x6
    public UnityEngine.LayerMask obstacleLayerMask;
    // field 19979, runtime offset 20, flags 0x1
    private UnityEngine.GameObject damageTxt;
    // field 19980, runtime offset 24, flags 0x1
    private TMPro.TMP_Text[] damageTxts;
    // field 19981, runtime offset 28, flags 0x1
    private UnityEngine.GameObject[] damageTxtParents;
    // field 19982, runtime offset 0, flags 0x8051
    private static const float duration = 1.899999976158142;
    // field 19983, runtime offset 0, flags 0x8051
    private static const float animOutDuration = 0.20000000298023224;
    // method 33876, 0x600105d
    void Init(UnityEngine.Camera cam, string damageText, bool isHeadshot, bool targetIsDead, UnityEngine.Transform who, UnityEngine.Transform myPlayer);
    // method 33877, 0x600105e
    void FastTransitionEnd();
    // method 33878, 0x600105f
    float GetScaleMultiplier(float distance, float originalDistance, float originalScale);
    // method 33879, 0x6001060
    void .ctor();
}

// TypeDefinition 4602, 0x20002aa
class XP : Item {
    // method 33880, 0x6001061
    void .ctor();
}

// TypeDefinition 4603, 0x20002ac
class PaymentInfo : object {
    // field 19987, runtime offset 8, flags 0x6
    public string status;
    // method 33891, 0x600106c
    void .ctor();
}

// TypeDefinition 4604, 0x20002ad
class PaymentTokenResponse : object {
    // field 19988, runtime offset 8, flags 0x6
    public string paymentToken;
    // method 33892, 0x600106d
    void .ctor();
}

// TypeDefinition 4605, 0x20002ae
class <>c__DisplayClass11_0 : object {
    // field 19989, runtime offset 8, flags 0x6
    public string UID;
    // field 19990, runtime offset 12, flags 0x6
    public string itemSKU;
    // method 33893, 0x600106e
    void .ctor();
    // method 33894, 0x600106f
    void <PurchaseItem>b__0();
}

// TypeDefinition 4606, 0x20002af
class <PurchaseItem>d__11 : object {
    // field 19991, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 19992, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 19993, runtime offset 16, flags 0x6
    public string UID;
    // field 19994, runtime offset 20, flags 0x6
    public string itemSKU;
    // field 19995, runtime offset 24, flags 0x6
    public XsollaPayments <>4__this;
    // field 19996, runtime offset 28, flags 0x1
    private <>c__DisplayClass11_0 <>8__1;
    // field 19997, runtime offset 32, flags 0x1
    private UnityEngine.Networking.UnityWebRequest <www>5__2;
    // method 33895, 0x6001070
    void .ctor(int <>1__state);
    // method 33896, 0x6001071
    void System.IDisposable.Dispose();
    // method 33897, 0x6001072
    bool MoveNext();
    // method 33898, 0x6001073
    void <>m__Finally1();
    // method 33899, 0x6001074
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 33900, 0x6001075
    void System.Collections.IEnumerator.Reset();
    // method 33901, 0x6001076
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4607, 0x20002ab
class XsollaPayments : UnityEngine.MonoBehaviour {
    // field 19984, runtime offset 0, flags 0x16
    public static XsollaPayments instance;
    // field 19985, runtime offset 16, flags 0x1
    private UnityEngine.GameObject paymentProcessingPanel;
    // field 19986, runtime offset 20, flags 0x1
    private TMPro.TMP_Text paymentProcessingStatusTxt;
    // method 33881, 0x6001062
    void Start();
    // method 33882, 0x6001063
    string ToReadable(string input);
    // method 33883, 0x6001064
    void OnXsollaWindowUpdate(string dataJson);
    // method 33884, 0x6001065
    void OnPurchaseEnded();
    // method 33885, 0x6001066
    void BuyVirtualItem(string sku, string uid, System.Action<string> result);
    // method 33886, 0x6001067
    void InstanceBuyVirtualItem(string sku, string uid, System.Action<string> result);
    // method 33887, 0x6001068
    string EncJes(string input, int seed);
    // method 33888, 0x6001069
    System.Collections.IEnumerator PurchaseItem(string UID, string itemSKU);
    // method 33889, 0x600106a
    void OpenPaymentStation(string paymentToken);
    // method 33890, 0x600106b
    void .ctor();
}

// TypeDefinition 4608, 0x20002b1
class ZonePhase : System.Enum {
    // field 20012, runtime offset 8, flags 0x606
    public int value__;
    // field 20013, runtime offset 0, flags 0x8056
    public static const ZonePhase Unexistant = 0;
    // field 20014, runtime offset 0, flags 0x8056
    public static const ZonePhase MovingToBigCircle = 1;
    // field 20015, runtime offset 0, flags 0x8056
    public static const ZonePhase BigCircleStatic = 2;
    // field 20016, runtime offset 0, flags 0x8056
    public static const ZonePhase MovingToMediumCircle = 3;
    // field 20017, runtime offset 0, flags 0x8056
    public static const ZonePhase MediumCircleStatic = 4;
    // field 20018, runtime offset 0, flags 0x8056
    public static const ZonePhase MovingToSmallCircle = 5;
    // field 20019, runtime offset 0, flags 0x8056
    public static const ZonePhase SmallCircleStatic = 6;
    // field 20020, runtime offset 0, flags 0x8056
    public static const ZonePhase MovingToTinyCircle = 7;
    // field 20021, runtime offset 0, flags 0x8056
    public static const ZonePhase TinyCircleStatic = 8;
    // field 20022, runtime offset 0, flags 0x8056
    public static const ZonePhase MovingToClose = 9;
}

// TypeDefinition 4609, 0x20002b0
class ZoneManager : UnityEngine.MonoBehaviour {
    // field 19998, runtime offset 0, flags 0x16
    public static ZoneManager Instance;
    // field 19999, runtime offset 16, flags 0x1
    private double gameStartTime;
    // field 20000, runtime offset 24, flags 0x1
    private TMPro.TMP_Text zoneTxt;
    // field 20001, runtime offset 28, flags 0x1
    private UnityEngine.Vector3[] circlePositions;
    // field 20002, runtime offset 32, flags 0x1
    private TMPro.TMP_Text zoneTimeTxt;
    // field 20003, runtime offset 36, flags 0x1
    private UnityEngine.AudioClip[] sounds;
    // field 20004, runtime offset 40, flags 0x1
    private UnityEngine.Transform zoneParent;
    // field 20005, runtime offset 44, flags 0x1
    private UnityEngine.CapsuleCollider zoneCollider;
    // field 20006, runtime offset 48, flags 0x1
    private UnityEngine.Rendering.PostProcessing.PostProcessVolume[] playerPPVs;
    // field 20007, runtime offset 52, flags 0x1
    private UnityEngine.Rendering.PostProcessing.PostProcessProfile defaultPostProcessProfile;
    // field 20008, runtime offset 56, flags 0x1
    private UnityEngine.Rendering.PostProcessing.PostProcessProfile zonePostProcessProfile;
    // field 20009, runtime offset 60, flags 0x1
    private UnityEngine.AudioSource mySource;
    // field 20010, runtime offset 64, flags 0x1
    private int seed;
    // field 20011, runtime offset 68, flags 0x1
    private ZonePhase lastPhase;
    // method 33902, 0x6001077
    void OnPlayerZoneUpdate(bool inSafeZone);
    // method 33903, 0x6001078
    void Start();
    // method 33904, 0x6001079
    void PlaySound(int x);
    // method 33905, 0x600107a
    void Init(TMPro.TMP_Text _zoneTxt, int _seed);
    // method 33906, 0x600107b
    void Update();
    // method 33907, 0x600107c
    ZonePhase GetZonePhaseFromTime(double timePassed, out float circleSize, out UnityEngine.Vector3 circlePosition, out float timeRemainingTillNextState);
    // method 33908, 0x600107d
    void .ctor();
}

// TypeDefinition 4610, 0x20002b3
class TextAlign : System.Enum {
    // field 20031, runtime offset 8, flags 0x606
    public int value__;
    // field 20032, runtime offset 0, flags 0x8056
    public static const TextAlign Left = 0;
    // field 20033, runtime offset 0, flags 0x8056
    public static const TextAlign Right = 1;
}

// TypeDefinition 4611, 0x20002b2
class STController : UnityEngine.MonoBehaviour {
    // field 20023, runtime offset 16, flags 0x6
    public UnityEngine.RectTransform canvasRect;
    // field 20024, runtime offset 20, flags 0x1
    private UnityEngine.UI.Image panel;
    // field 20025, runtime offset 24, flags 0x1
    private TMPro.TextMeshProUGUI toolTipTextLeft;
    // field 20026, runtime offset 28, flags 0x1
    private TMPro.TextMeshProUGUI toolTipTextRight;
    // field 20027, runtime offset 32, flags 0x1
    private UnityEngine.RectTransform rect;
    // field 20028, runtime offset 36, flags 0x1
    private int showInFrames;
    // field 20029, runtime offset 40, flags 0x1
    private bool showNow;
    // field 20030, runtime offset 44, flags 0x1
    private UnityEngine.Vector2 offset;
    // method 33909, 0x600107e
    void Awake();
    // method 33910, 0x600107f
    void Update();
    // method 33911, 0x6001080
    void ResizeToMatchText();
    // method 33912, 0x6001081
    void UpdateShow();
    // method 33913, 0x6001082
    void SetRawText(string text, TextAlign align);
    // method 33914, 0x6001083
    void SetCustomStyledText(string text, SimpleTooltipStyle style, TextAlign align);
    // method 33915, 0x6001084
    string ColorToHex(UnityEngine.Color color);
    // method 33916, 0x6001085
    void ShowTooltip();
    // method 33917, 0x6001086
    void HideTooltip();
    // method 33918, 0x6001087
    void .ctor();
}

// TypeDefinition 4612, 0x20002b4
class STDynamicExample : UnityEngine.MonoBehaviour {
    // field 20034, runtime offset 16, flags 0x6
    public SimpleTooltipStyle dynamicTooltipStyle;
    // field 20035, runtime offset 20, flags 0x6
    public string tooltipText;
    // method 33919, 0x6001088
    void AddTooltip();
    // method 33920, 0x6001089
    void .ctor();
}

// TypeDefinition 4613, 0x20002b5
class SimpleTooltip : UnityEngine.MonoBehaviour {
    // field 20036, runtime offset 16, flags 0x6
    public SimpleTooltipStyle simpleTooltipStyle;
    // field 20037, runtime offset 20, flags 0x6
    public string infoLeft;
    // field 20038, runtime offset 24, flags 0x6
    public string infoRight;
    // field 20039, runtime offset 28, flags 0x1
    private STController tooltipController;
    // field 20040, runtime offset 32, flags 0x1
    private UnityEngine.EventSystems.EventSystem eventSystem;
    // field 20041, runtime offset 36, flags 0x1
    private bool cursorInside;
    // field 20042, runtime offset 37, flags 0x1
    private bool isUIObject;
    // field 20043, runtime offset 38, flags 0x1
    private bool showing;
    // method 33921, 0x600108a
    void Awake();
    // method 33922, 0x600108b
    void Update();
    // method 33923, 0x600108c
    STController AddTooltipPrefabToScene();
    // method 33924, 0x600108d
    void OnMouseOver();
    // method 33925, 0x600108e
    void OnMouseExit();
    // method 33926, 0x600108f
    void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33927, 0x6001090
    void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
    // method 33928, 0x6001091
    void ShowTooltip();
    // method 33929, 0x6001092
    void HideTooltip();
    // method 33930, 0x6001093
    void Reset();
    // method 33931, 0x6001094
    void .ctor();
}

// TypeDefinition 4614, 0x20002b7
class Style : System.ValueType {
    // field 20049, runtime offset 8, flags 0x6
    public string tag;
    // field 20050, runtime offset 12, flags 0x6
    public UnityEngine.Color color;
    // field 20051, runtime offset 28, flags 0x6
    public bool bold;
    // field 20052, runtime offset 29, flags 0x6
    public bool italic;
    // field 20053, runtime offset 30, flags 0x6
    public bool underline;
    // field 20054, runtime offset 31, flags 0x6
    public bool strikethrough;
}

// TypeDefinition 4615, 0x20002b6
class SimpleTooltipStyle : UnityEngine.ScriptableObject {
    // field 20044, runtime offset 12, flags 0x6
    public UnityEngine.Sprite slicedSprite;
    // field 20045, runtime offset 16, flags 0x6
    public UnityEngine.Color color;
    // field 20046, runtime offset 32, flags 0x6
    public TMPro.TMP_FontAsset fontAsset;
    // field 20047, runtime offset 36, flags 0x6
    public UnityEngine.Color defaultColor;
    // field 20048, runtime offset 52, flags 0x6
    public Style[] fontStyles;
    // method 33932, 0x6001095
    void .ctor();
}

// TypeDefinition 4616, 0x20002b8
class UniClipboard : object {
    // field 20055, runtime offset 0, flags 0x11
    private static IBoard _board;
    // method 33933, 0x6001096
    IBoard get_board();
    // method 33934, 0x6001097
    void SetText(string str);
    // method 33935, 0x6001098
    string GetText();
    // method 33936, 0x6001099
    void .ctor();
}

// TypeDefinition 4617, 0x20002b9
class IBoard : TypeIndex_-1 {
    // method 33937, 0x600109a
    void SetText(string str);
    // method 33938, 0x600109b
    string GetText();
}

// TypeDefinition 4618, 0x20002ba
class StandardBoard : object {
    // field 20056, runtime offset 0, flags 0x11
    private static System.Reflection.PropertyInfo m_systemCopyBufferProperty;
    // method 33939, 0x600109c
    System.Reflection.PropertyInfo GetSystemCopyBufferProperty();
    // method 33940, 0x600109d
    void SetText(string str);
    // method 33941, 0x600109e
    string GetText();
    // method 33942, 0x600109f
    void .ctor();
}

// TypeDefinition 4619, 0x20002bc
class MonoScriptData : System.ValueType {
    // field 20057, runtime offset 8, flags 0x6
    public byte[] FilePathsData;
    // field 20058, runtime offset 12, flags 0x6
    public byte[] TypesData;
    // field 20059, runtime offset 16, flags 0x6
    public int TotalTypes;
    // field 20060, runtime offset 20, flags 0x6
    public int TotalFiles;
    // field 20061, runtime offset 24, flags 0x6
    public bool IsEditorOnly;
}

// TypeDefinition 4620, 0x20002bb
class UnitySourceGeneratedAssemblyMonoScriptTypes_v1 : object {
    // method 33943, 0x60010a0
    MonoScriptData Get();
    // method 33944, 0x60010a1
    void .ctor();
}

// TypeDefinition 4621, 0x20002bd
// Namespace SimpleJSON
class JSONNodeType : System.Enum {
    // field 20062, runtime offset 8, flags 0x606
    public int value__;
    // field 20063, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType Array = 1;
    // field 20064, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType Object = 2;
    // field 20065, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType String = 3;
    // field 20066, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType Number = 4;
    // field 20067, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType NullValue = 5;
    // field 20068, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType Boolean = 6;
    // field 20069, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType None = 7;
    // field 20070, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONNodeType Custom = 255;
}

// TypeDefinition 4622, 0x20002be
// Namespace SimpleJSON
class JSONTextMode : System.Enum {
    // field 20071, runtime offset 8, flags 0x606
    public int value__;
    // field 20072, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONTextMode Compact = 0;
    // field 20073, runtime offset 0, flags 0x8056
    public static const SimpleJSON.JSONTextMode Indent = 1;
}

// TypeDefinition 4623, 0x20002c1
class Type : System.Enum {
    // field 20081, runtime offset 8, flags 0x606
    public int value__;
    // field 20082, runtime offset 0, flags 0x8056
    public static const Type None = 0;
    // field 20083, runtime offset 0, flags 0x8056
    public static const Type Array = 1;
    // field 20084, runtime offset 0, flags 0x8056
    public static const Type Object = 2;
}

// TypeDefinition 4624, 0x20002c0
class Enumerator : System.ValueType {
    // field 20078, runtime offset 8, flags 0x1
    private Type type;
    // field 20079, runtime offset 12, flags 0x1
    private Enumerator<string, SimpleJSON.JSONNode> m_Object;
    // field 20080, runtime offset 36, flags 0x1
    private Enumerator<SimpleJSON.JSONNode> m_Array;
    // method 34018, 0x60010eb
    bool get_IsValid();
    // method 34019, 0x60010ec
    void .ctor(Enumerator<SimpleJSON.JSONNode> aArrayEnum);
    // method 34020, 0x60010ed
    void .ctor(Enumerator<string, SimpleJSON.JSONNode> aDictEnum);
    // method 34021, 0x60010ee
    System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode> get_Current();
    // method 34022, 0x60010ef
    bool MoveNext();
}

// TypeDefinition 4625, 0x20002c2
class ValueEnumerator : System.ValueType {
    // field 20085, runtime offset 8, flags 0x1
    private Enumerator m_Enumerator;
    // method 34023, 0x60010f0
    void .ctor(Enumerator<SimpleJSON.JSONNode> aArrayEnum);
    // method 34024, 0x60010f1
    void .ctor(Enumerator<string, SimpleJSON.JSONNode> aDictEnum);
    // method 34025, 0x60010f2
    void .ctor(Enumerator aEnumerator);
    // method 34026, 0x60010f3
    SimpleJSON.JSONNode get_Current();
    // method 34027, 0x60010f4
    bool MoveNext();
    // method 34028, 0x60010f5
    ValueEnumerator GetEnumerator();
}

// TypeDefinition 4626, 0x20002c3
class KeyEnumerator : System.ValueType {
    // field 20086, runtime offset 8, flags 0x1
    private Enumerator m_Enumerator;
    // method 34029, 0x60010f6
    void .ctor(Enumerator<SimpleJSON.JSONNode> aArrayEnum);
    // method 34030, 0x60010f7
    void .ctor(Enumerator<string, SimpleJSON.JSONNode> aDictEnum);
    // method 34031, 0x60010f8
    void .ctor(Enumerator aEnumerator);
    // method 34032, 0x60010f9
    string get_Current();
    // method 34033, 0x60010fa
    bool MoveNext();
    // method 34034, 0x60010fb
    KeyEnumerator GetEnumerator();
}

// TypeDefinition 4627, 0x20002c4
class LinqEnumerator : object {
    // field 20087, runtime offset 8, flags 0x1
    private SimpleJSON.JSONNode m_Node;
    // field 20088, runtime offset 12, flags 0x1
    private Enumerator m_Enumerator;
    // method 34035, 0x60010fc
    void .ctor(SimpleJSON.JSONNode aNode);
    // method 34036, 0x60010fd
    System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode> get_Current();
    // method 34037, 0x60010fe
    object System.Collections.IEnumerator.get_Current();
    // method 34038, 0x60010ff
    bool MoveNext();
    // method 34039, 0x6001100
    void Dispose();
    // method 34040, 0x6001101
    System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode>> GetEnumerator();
    // method 34041, 0x6001102
    void Reset();
    // method 34042, 0x6001103
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();
}

// TypeDefinition 4628, 0x20002c5
class <get_Children>d__43 : object {
    // field 20089, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20090, runtime offset 12, flags 0x1
    private SimpleJSON.JSONNode <>2__current;
    // field 20091, runtime offset 16, flags 0x1
    private int <>l__initialThreadId;
    // method 34043, 0x6001104
    void .ctor(int <>1__state);
    // method 34044, 0x6001105
    void System.IDisposable.Dispose();
    // method 34045, 0x6001106
    bool MoveNext();
    // method 34046, 0x6001107
    SimpleJSON.JSONNode System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode>.get_Current();
    // method 34047, 0x6001108
    void System.Collections.IEnumerator.Reset();
    // method 34048, 0x6001109
    object System.Collections.IEnumerator.get_Current();
    // method 34049, 0x600110a
    System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode>.GetEnumerator();
    // method 34050, 0x600110b
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();
}

// TypeDefinition 4629, 0x20002c6
class <get_DeepChildren>d__45 : object {
    // field 20092, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20093, runtime offset 12, flags 0x1
    private SimpleJSON.JSONNode <>2__current;
    // field 20094, runtime offset 16, flags 0x1
    private int <>l__initialThreadId;
    // field 20095, runtime offset 20, flags 0x6
    public SimpleJSON.JSONNode <>4__this;
    // field 20096, runtime offset 24, flags 0x1
    private System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> <>7__wrap1;
    // field 20097, runtime offset 28, flags 0x1
    private System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> <>7__wrap2;
    // method 34051, 0x600110c
    void .ctor(int <>1__state);
    // method 34052, 0x600110d
    void System.IDisposable.Dispose();
    // method 34053, 0x600110e
    bool MoveNext();
    // method 34054, 0x600110f
    void <>m__Finally1();
    // method 34055, 0x6001110
    void <>m__Finally2();
    // method 34056, 0x6001111
    SimpleJSON.JSONNode System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode>.get_Current();
    // method 34057, 0x6001112
    void System.Collections.IEnumerator.Reset();
    // method 34058, 0x6001113
    object System.Collections.IEnumerator.get_Current();
    // method 34059, 0x6001114
    System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode>.GetEnumerator();
    // method 34060, 0x6001115
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();
}

// TypeDefinition 4630, 0x20002bf
// Namespace SimpleJSON
class JSONNode : object {
    // field 20074, runtime offset 0, flags 0x16
    public static bool forceASCII;
    // field 20075, runtime offset 1, flags 0x16
    public static bool longAsString;
    // field 20076, runtime offset 2, flags 0x16
    public static bool allowLineComments;
    // field 20077, runtime offset -2147483648, flags 0x11
    private static System.Text.StringBuilder m_EscapeBuilder;
    // method 33945, 0x60010a2
    SimpleJSON.JSONNodeType get_Tag();
    // method 33946, 0x60010a3
    SimpleJSON.JSONNode get_Item(int aIndex);
    // method 33947, 0x60010a4
    void set_Item(int aIndex, SimpleJSON.JSONNode value);
    // method 33948, 0x60010a5
    SimpleJSON.JSONNode get_Item(string aKey);
    // method 33949, 0x60010a6
    void set_Item(string aKey, SimpleJSON.JSONNode value);
    // method 33950, 0x60010a7
    string get_Value();
    // method 33951, 0x60010a8
    void set_Value(string value);
    // method 33952, 0x60010a9
    int get_Count();
    // method 33953, 0x60010aa
    bool get_IsNumber();
    // method 33954, 0x60010ab
    bool get_IsString();
    // method 33955, 0x60010ac
    bool get_IsBoolean();
    // method 33956, 0x60010ad
    bool get_IsNull();
    // method 33957, 0x60010ae
    bool get_IsArray();
    // method 33958, 0x60010af
    bool get_IsObject();
    // method 33959, 0x60010b0
    bool get_Inline();
    // method 33960, 0x60010b1
    void set_Inline(bool value);
    // method 33961, 0x60010b2
    void Add(string aKey, SimpleJSON.JSONNode aItem);
    // method 33962, 0x60010b3
    void Add(SimpleJSON.JSONNode aItem);
    // method 33963, 0x60010b4
    SimpleJSON.JSONNode Remove(string aKey);
    // method 33964, 0x60010b5
    SimpleJSON.JSONNode Remove(int aIndex);
    // method 33965, 0x60010b6
    SimpleJSON.JSONNode Remove(SimpleJSON.JSONNode aNode);
    // method 33966, 0x60010b7
    void Clear();
    // method 33967, 0x60010b8
    SimpleJSON.JSONNode Clone();
    // method 33968, 0x60010b9
    System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> get_Children();
    // method 33969, 0x60010ba
    System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> get_DeepChildren();
    // method 33970, 0x60010bb
    bool HasKey(string aKey);
    // method 33971, 0x60010bc
    SimpleJSON.JSONNode GetValueOrDefault(string aKey, SimpleJSON.JSONNode aDefault);
    // method 33972, 0x60010bd
    string ToString();
    // method 33973, 0x60010be
    string ToString(int aIndent);
    // method 33974, 0x60010bf
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 33975, 0x60010c0
    Enumerator GetEnumerator();
    // method 33976, 0x60010c1
    System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode>> get_Linq();
    // method 33977, 0x60010c2
    KeyEnumerator get_Keys();
    // method 33978, 0x60010c3
    ValueEnumerator get_Values();
    // method 33979, 0x60010c4
    double get_AsDouble();
    // method 33980, 0x60010c5
    void set_AsDouble(double value);
    // method 33981, 0x60010c6
    int get_AsInt();
    // method 33982, 0x60010c7
    void set_AsInt(int value);
    // method 33983, 0x60010c8
    float get_AsFloat();
    // method 33984, 0x60010c9
    void set_AsFloat(float value);
    // method 33985, 0x60010ca
    bool get_AsBool();
    // method 33986, 0x60010cb
    void set_AsBool(bool value);
    // method 33987, 0x60010cc
    long get_AsLong();
    // method 33988, 0x60010cd
    void set_AsLong(long value);
    // method 33989, 0x60010ce
    ulong get_AsULong();
    // method 33990, 0x60010cf
    void set_AsULong(ulong value);
    // method 33991, 0x60010d0
    SimpleJSON.JSONArray get_AsArray();
    // method 33992, 0x60010d1
    SimpleJSON.JSONObject get_AsObject();
    // method 33993, 0x60010d2
    SimpleJSON.JSONNode op_Implicit(string s);
    // method 33994, 0x60010d3
    string op_Implicit(SimpleJSON.JSONNode d);
    // method 33995, 0x60010d4
    SimpleJSON.JSONNode op_Implicit(double n);
    // method 33996, 0x60010d5
    double op_Implicit(SimpleJSON.JSONNode d);
    // method 33997, 0x60010d6
    SimpleJSON.JSONNode op_Implicit(float n);
    // method 33998, 0x60010d7
    float op_Implicit(SimpleJSON.JSONNode d);
    // method 33999, 0x60010d8
    SimpleJSON.JSONNode op_Implicit(int n);
    // method 34000, 0x60010d9
    int op_Implicit(SimpleJSON.JSONNode d);
    // method 34001, 0x60010da
    SimpleJSON.JSONNode op_Implicit(long n);
    // method 34002, 0x60010db
    long op_Implicit(SimpleJSON.JSONNode d);
    // method 34003, 0x60010dc
    SimpleJSON.JSONNode op_Implicit(ulong n);
    // method 34004, 0x60010dd
    ulong op_Implicit(SimpleJSON.JSONNode d);
    // method 34005, 0x60010de
    SimpleJSON.JSONNode op_Implicit(bool b);
    // method 34006, 0x60010df
    bool op_Implicit(SimpleJSON.JSONNode d);
    // method 34007, 0x60010e0
    SimpleJSON.JSONNode op_Implicit(System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode> aKeyValue);
    // method 34008, 0x60010e1
    bool op_Equality(SimpleJSON.JSONNode a, object b);
    // method 34009, 0x60010e2
    bool op_Inequality(SimpleJSON.JSONNode a, object b);
    // method 34010, 0x60010e3
    bool Equals(object obj);
    // method 34011, 0x60010e4
    int GetHashCode();
    // method 34012, 0x60010e5
    System.Text.StringBuilder get_EscapeBuilder();
    // method 34013, 0x60010e6
    string Escape(string aText);
    // method 34014, 0x60010e7
    SimpleJSON.JSONNode ParseElement(string token, bool quoted);
    // method 34015, 0x60010e8
    SimpleJSON.JSONNode Parse(string aJSON);
    // method 34016, 0x60010e9
    void .ctor();
    // method 34017, 0x60010ea
    void .cctor();
}

// TypeDefinition 4631, 0x20002c8
class <get_Children>d__24 : object {
    // field 20100, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20101, runtime offset 12, flags 0x1
    private SimpleJSON.JSONNode <>2__current;
    // field 20102, runtime offset 16, flags 0x1
    private int <>l__initialThreadId;
    // field 20103, runtime offset 20, flags 0x6
    public SimpleJSON.JSONArray <>4__this;
    // field 20104, runtime offset 24, flags 0x1
    private Enumerator<SimpleJSON.JSONNode> <>7__wrap1;
    // method 34079, 0x6001128
    void .ctor(int <>1__state);
    // method 34080, 0x6001129
    void System.IDisposable.Dispose();
    // method 34081, 0x600112a
    bool MoveNext();
    // method 34082, 0x600112b
    void <>m__Finally1();
    // method 34083, 0x600112c
    SimpleJSON.JSONNode System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode>.get_Current();
    // method 34084, 0x600112d
    void System.Collections.IEnumerator.Reset();
    // method 34085, 0x600112e
    object System.Collections.IEnumerator.get_Current();
    // method 34086, 0x600112f
    System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode>.GetEnumerator();
    // method 34087, 0x6001130
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();
}

// TypeDefinition 4632, 0x20002c7
// Namespace SimpleJSON
class JSONArray : SimpleJSON.JSONNode {
    // field 20098, runtime offset 8, flags 0x1
    private System.Collections.Generic.List<SimpleJSON.JSONNode> m_List;
    // field 20099, runtime offset 12, flags 0x1
    private bool inline;
    // method 34061, 0x6001116
    bool get_Inline();
    // method 34062, 0x6001117
    void set_Inline(bool value);
    // method 34063, 0x6001118
    SimpleJSON.JSONNodeType get_Tag();
    // method 34064, 0x6001119
    bool get_IsArray();
    // method 34065, 0x600111a
    Enumerator GetEnumerator();
    // method 34066, 0x600111b
    SimpleJSON.JSONNode get_Item(int aIndex);
    // method 34067, 0x600111c
    void set_Item(int aIndex, SimpleJSON.JSONNode value);
    // method 34068, 0x600111d
    SimpleJSON.JSONNode get_Item(string aKey);
    // method 34069, 0x600111e
    void set_Item(string aKey, SimpleJSON.JSONNode value);
    // method 34070, 0x600111f
    int get_Count();
    // method 34071, 0x6001120
    void Add(string aKey, SimpleJSON.JSONNode aItem);
    // method 34072, 0x6001121
    SimpleJSON.JSONNode Remove(int aIndex);
    // method 34073, 0x6001122
    SimpleJSON.JSONNode Remove(SimpleJSON.JSONNode aNode);
    // method 34074, 0x6001123
    void Clear();
    // method 34075, 0x6001124
    SimpleJSON.JSONNode Clone();
    // method 34076, 0x6001125
    System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> get_Children();
    // method 34077, 0x6001126
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34078, 0x6001127
    void .ctor();
}

// TypeDefinition 4633, 0x20002ca
class <>c__DisplayClass21_0 : object {
    // field 20107, runtime offset 8, flags 0x6
    public SimpleJSON.JSONNode aNode;
    // method 34109, 0x6001146
    void .ctor();
    // method 34110, 0x6001147
    bool <Remove>b__0(System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode> k);
}

// TypeDefinition 4634, 0x20002cb
class <get_Children>d__27 : object {
    // field 20108, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20109, runtime offset 12, flags 0x1
    private SimpleJSON.JSONNode <>2__current;
    // field 20110, runtime offset 16, flags 0x1
    private int <>l__initialThreadId;
    // field 20111, runtime offset 20, flags 0x6
    public SimpleJSON.JSONObject <>4__this;
    // field 20112, runtime offset 24, flags 0x1
    private Enumerator<string, SimpleJSON.JSONNode> <>7__wrap1;
    // method 34111, 0x6001148
    void .ctor(int <>1__state);
    // method 34112, 0x6001149
    void System.IDisposable.Dispose();
    // method 34113, 0x600114a
    bool MoveNext();
    // method 34114, 0x600114b
    void <>m__Finally1();
    // method 34115, 0x600114c
    SimpleJSON.JSONNode System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode>.get_Current();
    // method 34116, 0x600114d
    void System.Collections.IEnumerator.Reset();
    // method 34117, 0x600114e
    object System.Collections.IEnumerator.get_Current();
    // method 34118, 0x600114f
    System.Collections.Generic.IEnumerator<SimpleJSON.JSONNode> System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode>.GetEnumerator();
    // method 34119, 0x6001150
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();
}

// TypeDefinition 4635, 0x20002c9
// Namespace SimpleJSON
class JSONObject : SimpleJSON.JSONNode {
    // field 20105, runtime offset 8, flags 0x1
    private System.Collections.Generic.Dictionary<string, SimpleJSON.JSONNode> m_Dict;
    // field 20106, runtime offset 12, flags 0x1
    private bool inline;
    // method 34088, 0x6001131
    bool get_Inline();
    // method 34089, 0x6001132
    void set_Inline(bool value);
    // method 34090, 0x6001133
    SimpleJSON.JSONNodeType get_Tag();
    // method 34091, 0x6001134
    bool get_IsObject();
    // method 34092, 0x6001135
    Enumerator GetEnumerator();
    // method 34093, 0x6001136
    SimpleJSON.JSONNode get_Item(string aKey);
    // method 34094, 0x6001137
    void set_Item(string aKey, SimpleJSON.JSONNode value);
    // method 34095, 0x6001138
    SimpleJSON.JSONNode get_Item(int aIndex);
    // method 34096, 0x6001139
    void set_Item(int aIndex, SimpleJSON.JSONNode value);
    // method 34097, 0x600113a
    int get_Count();
    // method 34098, 0x600113b
    void Add(string aKey, SimpleJSON.JSONNode aItem);
    // method 34099, 0x600113c
    SimpleJSON.JSONNode Remove(string aKey);
    // method 34100, 0x600113d
    SimpleJSON.JSONNode Remove(int aIndex);
    // method 34101, 0x600113e
    SimpleJSON.JSONNode Remove(SimpleJSON.JSONNode aNode);
    // method 34102, 0x600113f
    void Clear();
    // method 34103, 0x6001140
    SimpleJSON.JSONNode Clone();
    // method 34104, 0x6001141
    bool HasKey(string aKey);
    // method 34105, 0x6001142
    SimpleJSON.JSONNode GetValueOrDefault(string aKey, SimpleJSON.JSONNode aDefault);
    // method 34106, 0x6001143
    System.Collections.Generic.IEnumerable<SimpleJSON.JSONNode> get_Children();
    // method 34107, 0x6001144
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34108, 0x6001145
    void .ctor();
}

// TypeDefinition 4636, 0x20002cc
// Namespace SimpleJSON
class JSONString : SimpleJSON.JSONNode {
    // field 20113, runtime offset 8, flags 0x1
    private string m_Data;
    // method 34120, 0x6001151
    SimpleJSON.JSONNodeType get_Tag();
    // method 34121, 0x6001152
    bool get_IsString();
    // method 34122, 0x6001153
    Enumerator GetEnumerator();
    // method 34123, 0x6001154
    string get_Value();
    // method 34124, 0x6001155
    void set_Value(string value);
    // method 34125, 0x6001156
    void .ctor(string aData);
    // method 34126, 0x6001157
    SimpleJSON.JSONNode Clone();
    // method 34127, 0x6001158
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34128, 0x6001159
    bool Equals(object obj);
    // method 34129, 0x600115a
    int GetHashCode();
    // method 34130, 0x600115b
    void Clear();
}

// TypeDefinition 4637, 0x20002cd
// Namespace SimpleJSON
class JSONNumber : SimpleJSON.JSONNode {
    // field 20114, runtime offset 8, flags 0x1
    private double m_Data;
    // method 34131, 0x600115c
    SimpleJSON.JSONNodeType get_Tag();
    // method 34132, 0x600115d
    bool get_IsNumber();
    // method 34133, 0x600115e
    Enumerator GetEnumerator();
    // method 34134, 0x600115f
    string get_Value();
    // method 34135, 0x6001160
    void set_Value(string value);
    // method 34136, 0x6001161
    double get_AsDouble();
    // method 34137, 0x6001162
    void set_AsDouble(double value);
    // method 34138, 0x6001163
    long get_AsLong();
    // method 34139, 0x6001164
    void set_AsLong(long value);
    // method 34140, 0x6001165
    ulong get_AsULong();
    // method 34141, 0x6001166
    void set_AsULong(ulong value);
    // method 34142, 0x6001167
    void .ctor(double aData);
    // method 34143, 0x6001168
    void .ctor(string aData);
    // method 34144, 0x6001169
    SimpleJSON.JSONNode Clone();
    // method 34145, 0x600116a
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34146, 0x600116b
    bool IsNumeric(object value);
    // method 34147, 0x600116c
    bool Equals(object obj);
    // method 34148, 0x600116d
    int GetHashCode();
    // method 34149, 0x600116e
    void Clear();
}

// TypeDefinition 4638, 0x20002ce
// Namespace SimpleJSON
class JSONBool : SimpleJSON.JSONNode {
    // field 20115, runtime offset 8, flags 0x1
    private bool m_Data;
    // method 34150, 0x600116f
    SimpleJSON.JSONNodeType get_Tag();
    // method 34151, 0x6001170
    bool get_IsBoolean();
    // method 34152, 0x6001171
    Enumerator GetEnumerator();
    // method 34153, 0x6001172
    string get_Value();
    // method 34154, 0x6001173
    void set_Value(string value);
    // method 34155, 0x6001174
    bool get_AsBool();
    // method 34156, 0x6001175
    void set_AsBool(bool value);
    // method 34157, 0x6001176
    void .ctor(bool aData);
    // method 34158, 0x6001177
    void .ctor(string aData);
    // method 34159, 0x6001178
    SimpleJSON.JSONNode Clone();
    // method 34160, 0x6001179
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34161, 0x600117a
    bool Equals(object obj);
    // method 34162, 0x600117b
    int GetHashCode();
    // method 34163, 0x600117c
    void Clear();
}

// TypeDefinition 4639, 0x20002cf
// Namespace SimpleJSON
class JSONNull : SimpleJSON.JSONNode {
    // field 20116, runtime offset 0, flags 0x11
    private static SimpleJSON.JSONNull m_StaticInstance;
    // field 20117, runtime offset 4, flags 0x16
    public static bool reuseSameInstance;
    // method 34164, 0x600117d
    SimpleJSON.JSONNull CreateOrGet();
    // method 34165, 0x600117e
    void .ctor();
    // method 34166, 0x600117f
    SimpleJSON.JSONNodeType get_Tag();
    // method 34167, 0x6001180
    bool get_IsNull();
    // method 34168, 0x6001181
    Enumerator GetEnumerator();
    // method 34169, 0x6001182
    string get_Value();
    // method 34170, 0x6001183
    void set_Value(string value);
    // method 34171, 0x6001184
    bool get_AsBool();
    // method 34172, 0x6001185
    void set_AsBool(bool value);
    // method 34173, 0x6001186
    SimpleJSON.JSONNode Clone();
    // method 34174, 0x6001187
    bool Equals(object obj);
    // method 34175, 0x6001188
    int GetHashCode();
    // method 34176, 0x6001189
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
    // method 34177, 0x600118a
    void .cctor();
}

// TypeDefinition 4640, 0x20002d0
// Namespace SimpleJSON
class JSONLazyCreator : SimpleJSON.JSONNode {
    // field 20118, runtime offset 8, flags 0x1
    private SimpleJSON.JSONNode m_Node;
    // field 20119, runtime offset 12, flags 0x1
    private string m_Key;
    // method 34178, 0x600118b
    SimpleJSON.JSONNodeType get_Tag();
    // method 34179, 0x600118c
    Enumerator GetEnumerator();
    // method 34180, 0x600118d
    void .ctor(SimpleJSON.JSONNode aNode);
    // method 34181, 0x600118e
    void .ctor(SimpleJSON.JSONNode aNode, string aKey);
    // method 34182, 0x600118f
    M_1027 Set(M_1027 aVal);
    // method 34183, 0x6001190
    SimpleJSON.JSONNode get_Item(int aIndex);
    // method 34184, 0x6001191
    void set_Item(int aIndex, SimpleJSON.JSONNode value);
    // method 34185, 0x6001192
    SimpleJSON.JSONNode get_Item(string aKey);
    // method 34186, 0x6001193
    void set_Item(string aKey, SimpleJSON.JSONNode value);
    // method 34187, 0x6001194
    void Add(SimpleJSON.JSONNode aItem);
    // method 34188, 0x6001195
    void Add(string aKey, SimpleJSON.JSONNode aItem);
    // method 34189, 0x6001196
    bool op_Equality(SimpleJSON.JSONLazyCreator a, object b);
    // method 34190, 0x6001197
    bool op_Inequality(SimpleJSON.JSONLazyCreator a, object b);
    // method 34191, 0x6001198
    bool Equals(object obj);
    // method 34192, 0x6001199
    int GetHashCode();
    // method 34193, 0x600119a
    int get_AsInt();
    // method 34194, 0x600119b
    void set_AsInt(int value);
    // method 34195, 0x600119c
    float get_AsFloat();
    // method 34196, 0x600119d
    void set_AsFloat(float value);
    // method 34197, 0x600119e
    double get_AsDouble();
    // method 34198, 0x600119f
    void set_AsDouble(double value);
    // method 34199, 0x60011a0
    long get_AsLong();
    // method 34200, 0x60011a1
    void set_AsLong(long value);
    // method 34201, 0x60011a2
    ulong get_AsULong();
    // method 34202, 0x60011a3
    void set_AsULong(ulong value);
    // method 34203, 0x60011a4
    bool get_AsBool();
    // method 34204, 0x60011a5
    void set_AsBool(bool value);
    // method 34205, 0x60011a6
    SimpleJSON.JSONArray get_AsArray();
    // method 34206, 0x60011a7
    SimpleJSON.JSONObject get_AsObject();
    // method 34207, 0x60011a8
    void WriteToStringBuilder(System.Text.StringBuilder aSB, int aIndent, int aIndentInc, SimpleJSON.JSONTextMode aMode);
}

// TypeDefinition 4641, 0x20002d1
// Namespace SimpleJSON
class JSON : object {
    // method 34208, 0x60011a9
    SimpleJSON.JSONNode Parse(string aJSON);
}

// TypeDefinition 4642, 0x20002d2
// Namespace FLGCoreEditor.Utilities
class FindMissingScriptsRecursivelyAndRemove : object {
    // method 34209, 0x60011aa
    void .ctor();
}

// TypeDefinition 4643, 0x20002d3
// Namespace PolygonArsenal
class PolygonBeamScript : UnityEngine.MonoBehaviour {
    // field 20120, runtime offset 16, flags 0x6
    public UnityEngine.GameObject[] beamLineRendererPrefab;
    // field 20121, runtime offset 20, flags 0x6
    public UnityEngine.GameObject[] beamStartPrefab;
    // field 20122, runtime offset 24, flags 0x6
    public UnityEngine.GameObject[] beamEndPrefab;
    // field 20123, runtime offset 28, flags 0x1
    private int currentBeam;
    // field 20124, runtime offset 32, flags 0x1
    private UnityEngine.GameObject beamStart;
    // field 20125, runtime offset 36, flags 0x1
    private UnityEngine.GameObject beamEnd;
    // field 20126, runtime offset 40, flags 0x1
    private UnityEngine.GameObject beam;
    // field 20127, runtime offset 44, flags 0x1
    private UnityEngine.LineRenderer line;
    // field 20128, runtime offset 48, flags 0x6
    public float beamEndOffset;
    // field 20129, runtime offset 52, flags 0x6
    public float textureScrollSpeed;
    // field 20130, runtime offset 56, flags 0x6
    public float textureLengthScale;
    // field 20131, runtime offset 60, flags 0x6
    public UnityEngine.UI.Slider endOffSetSlider;
    // field 20132, runtime offset 64, flags 0x6
    public UnityEngine.UI.Slider scrollSpeedSlider;
    // field 20133, runtime offset 68, flags 0x6
    public UnityEngine.UI.Text textBeamName;
    // method 34210, 0x60011ab
    void Start();
    // method 34211, 0x60011ac
    void Update();
    // method 34212, 0x60011ad
    void nextBeam();
    // method 34213, 0x60011ae
    void previousBeam();
    // method 34214, 0x60011af
    void UpdateEndOffset();
    // method 34215, 0x60011b0
    void UpdateScrollSpeed();
    // method 34216, 0x60011b1
    void ShootBeamInDir(UnityEngine.Vector3 start, UnityEngine.Vector3 dir);
    // method 34217, 0x60011b2
    void .ctor();
}

// TypeDefinition 4644, 0x20002d4
// Namespace PolygonArsenal
class PolygonButtonScript : UnityEngine.MonoBehaviour {
    // field 20134, runtime offset 16, flags 0x6
    public UnityEngine.GameObject Button;
    // field 20135, runtime offset 20, flags 0x1
    private UnityEngine.UI.Text MyButtonText;
    // field 20136, runtime offset 24, flags 0x1
    private string projectileParticleName;
    // field 20137, runtime offset 28, flags 0x1
    private PolygonArsenal.PolygonFireProjectile effectScript;
    // field 20138, runtime offset 32, flags 0x1
    private PolygonArsenal.PolygonProjectileScript projectileScript;
    // field 20139, runtime offset 36, flags 0x6
    public float buttonsX;
    // field 20140, runtime offset 40, flags 0x6
    public float buttonsY;
    // field 20141, runtime offset 44, flags 0x6
    public float buttonsSizeX;
    // field 20142, runtime offset 48, flags 0x6
    public float buttonsSizeY;
    // field 20143, runtime offset 52, flags 0x6
    public float buttonsDistance;
    // method 34218, 0x60011b3
    void Start();
    // method 34219, 0x60011b4
    void Update();
    // method 34220, 0x60011b5
    void getProjectileNames();
    // method 34221, 0x60011b6
    bool overButton();
    // method 34222, 0x60011b7
    void .ctor();
}

// TypeDefinition 4645, 0x20002d5
// Namespace PolygonArsenal
class PolygonEffectCycler : UnityEngine.MonoBehaviour {
    // field 20144, runtime offset 16, flags 0x1
    private System.Collections.Generic.List<UnityEngine.GameObject> listOfEffects;
    // field 20145, runtime offset 20, flags 0x1
    private float loopTimeLength;
    // field 20146, runtime offset 24, flags 0x1
    private float timeOfLastInstantiate;
    // field 20147, runtime offset 28, flags 0x1
    private UnityEngine.GameObject instantiatedEffect;
    // field 20148, runtime offset 32, flags 0x1
    private int effectIndex;
    // method 34223, 0x60011b8
    void Start();
    // method 34224, 0x60011b9
    void Update();
    // method 34225, 0x60011ba
    void .ctor();
}

// TypeDefinition 4646, 0x20002d6
// Namespace PolygonArsenal
class PolygonFireProjectile : UnityEngine.MonoBehaviour {
    // field 20149, runtime offset 16, flags 0x1
    private UnityEngine.RaycastHit hit;
    // field 20150, runtime offset 60, flags 0x6
    public UnityEngine.GameObject[] projectiles;
    // field 20151, runtime offset 64, flags 0x6
    public UnityEngine.Transform spawnPosition;
    // field 20152, runtime offset 68, flags 0x6
    public int currentProjectile;
    // field 20153, runtime offset 72, flags 0x6
    public float speed;
    // field 20154, runtime offset 76, flags 0x1
    private PolygonArsenal.PolygonButtonScript selectedProjectileButton;
    // method 34226, 0x60011bb
    void Start();
    // method 34227, 0x60011bc
    void Update();
    // method 34228, 0x60011bd
    void nextEffect();
    // method 34229, 0x60011be
    void previousEffect();
    // method 34230, 0x60011bf
    void AdjustSpeed(float newSpeed);
    // method 34231, 0x60011c0
    void .ctor();
}

// TypeDefinition 4647, 0x20002d8
class <EffectLoop>d__4 : object {
    // field 20157, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20158, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 20159, runtime offset 16, flags 0x6
    public PolygonArsenal.PolygonLoopScript <>4__this;
    // field 20160, runtime offset 20, flags 0x1
    private UnityEngine.GameObject <effectPlayer>5__2;
    // method 34236, 0x60011c5
    void .ctor(int <>1__state);
    // method 34237, 0x60011c6
    void System.IDisposable.Dispose();
    // method 34238, 0x60011c7
    bool MoveNext();
    // method 34239, 0x60011c8
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 34240, 0x60011c9
    void System.Collections.IEnumerator.Reset();
    // method 34241, 0x60011ca
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4648, 0x20002d7
// Namespace PolygonArsenal
class PolygonLoopScript : UnityEngine.MonoBehaviour {
    // field 20155, runtime offset 16, flags 0x6
    public UnityEngine.GameObject chosenEffect;
    // field 20156, runtime offset 20, flags 0x6
    public float loopTimeLimit;
    // method 34232, 0x60011c1
    void Start();
    // method 34233, 0x60011c2
    void PlayEffect();
    // method 34234, 0x60011c3
    System.Collections.IEnumerator EffectLoop();
    // method 34235, 0x60011c4
    void .ctor();
}

// TypeDefinition 4649, 0x20002d9
// Namespace PolygonArsenal
class PolygonProjectileScript : UnityEngine.MonoBehaviour {
    // field 20161, runtime offset 16, flags 0x6
    public UnityEngine.GameObject impactParticle;
    // field 20162, runtime offset 20, flags 0x6
    public UnityEngine.GameObject projectileParticle;
    // field 20163, runtime offset 24, flags 0x6
    public UnityEngine.GameObject muzzleParticle;
    // field 20164, runtime offset 28, flags 0x6
    public UnityEngine.GameObject[] trailParticles;
    // field 20165, runtime offset 32, flags 0x6
    public float colliderRadius;
    // field 20166, runtime offset 36, flags 0x6
    public float collideOffset;
    // method 34242, 0x60011cb
    void Start();
    // method 34243, 0x60011cc
    void FixedUpdate();
    // method 34244, 0x60011cd
    void .ctor();
}

// TypeDefinition 4650, 0x20002da
// Namespace PolygonArsenal
class PolygonSceneSelect : UnityEngine.MonoBehaviour {
    // field 20167, runtime offset 16, flags 0x6
    public bool GUIHide;
    // field 20168, runtime offset 17, flags 0x6
    public bool GUIHide2;
    // field 20169, runtime offset 18, flags 0x6
    public bool GUIHide3;
    // field 20170, runtime offset 19, flags 0x6
    public bool GUIHide4;
    // field 20171, runtime offset 20, flags 0x6
    public bool GUIHide5;
    // method 34245, 0x60011ce
    void CBLoadSceneMissiles();
    // method 34246, 0x60011cf
    void CBLoadSceneBeams();
    // method 34247, 0x60011d0
    void CBLoadSceneBeams2();
    // method 34248, 0x60011d1
    void CBLoadSceneAura();
    // method 34249, 0x60011d2
    void CBLoadSceneAura2();
    // method 34250, 0x60011d3
    void CBLoadSceneAura3();
    // method 34251, 0x60011d4
    void CBLoadSceneAura4();
    // method 34252, 0x60011d5
    void CBLoadSceneBarrage();
    // method 34253, 0x60011d6
    void CBLoadSceneBarrage2();
    // method 34254, 0x60011d7
    void CBLoadSceneChains();
    // method 34255, 0x60011d8
    void CBLoadSceneChains2();
    // method 34256, 0x60011d9
    void CBLoadSceneCleave();
    // method 34257, 0x60011da
    void CBLoadSceneCombat01();
    // method 34258, 0x60011db
    void CBLoadSceneCombat02();
    // method 34259, 0x60011dc
    void CBLoadSceneCurses();
    // method 34260, 0x60011dd
    void CBLoadSceneDeath();
    // method 34261, 0x60011de
    void CBLoadSceneEnchant();
    // method 34262, 0x60011df
    void CBLoadSceneExploMini();
    // method 34263, 0x60011e0
    void CBLoadSceneGore();
    // method 34264, 0x60011e1
    void CBLoadSceneHitscan();
    // method 34265, 0x60011e2
    void CBLoadSceneNecromancy();
    // method 34266, 0x60011e3
    void CBLoadSceneNova();
    // method 34267, 0x60011e4
    void CBLoadSceneOrbitalBeam();
    // method 34268, 0x60011e5
    void CBLoadSceneSpikes();
    // method 34269, 0x60011e6
    void CBLoadSceneSpikes2();
    // method 34270, 0x60011e7
    void CBLoadSceneSpikes3();
    // method 34271, 0x60011e8
    void CBLoadSceneSpikes4();
    // method 34272, 0x60011e9
    void CBLoadSceneSurfaceDmg();
    // method 34273, 0x60011ea
    void CBLoadSceneSword();
    // method 34274, 0x60011eb
    void CBLoadSceneSwordTrail();
    // method 34275, 0x60011ec
    void ENVLoadSceneConfetti();
    // method 34276, 0x60011ed
    void ENVLoadSceneEnvironment();
    // method 34277, 0x60011ee
    void ENVLoadSceneFire();
    // method 34278, 0x60011ef
    void ENVLoadSceneFire2();
    // method 34279, 0x60011f0
    void ENVLoadSceneFireflies();
    // method 34280, 0x60011f1
    void ENVLoadSceneFireworks();
    // method 34281, 0x60011f2
    void ENVLoadSceneLiquid();
    // method 34282, 0x60011f3
    void ENVLoadSceneLiquid2();
    // method 34283, 0x60011f4
    void ENVLoadSceneRocks();
    // method 34284, 0x60011f5
    void ENVLoadSceneSparks();
    // method 34285, 0x60011f6
    void ENVLoadSceneTornado();
    // method 34286, 0x60011f7
    void ENVLoadSceneWeather();
    // method 34287, 0x60011f8
    void INTLoadSceneBeamUp();
    // method 34288, 0x60011f9
    void INTLoadSceneBlackHole();
    // method 34289, 0x60011fa
    void INTLoadSceneHeal();
    // method 34290, 0x60011fb
    void INTLoadSceneJets();
    // method 34291, 0x60011fc
    void INTLoadSceneLoot();
    // method 34292, 0x60011fd
    void INTLoadScenePortal();
    // method 34293, 0x60011fe
    void INTLoadScenePortal2();
    // method 34294, 0x60011ff
    void INTLoadScenePowerupIcon();
    // method 34295, 0x6001200
    void INTLoadSceneSpawn();
    // method 34296, 0x6001201
    void INTLoadSceneTrails();
    // method 34297, 0x6001202
    void INTLoadSceneTreasure();
    // method 34298, 0x6001203
    void INTLoadSceneTreasure2();
    // method 34299, 0x6001204
    void INTLoadSceneZones();
    // method 34300, 0x6001205
    void Update();
    // method 34301, 0x6001206
    void .ctor();
}

// TypeDefinition 4651, 0x20002db
// Namespace PolygonArsenal
class PolygonBeamStatic : UnityEngine.MonoBehaviour {
    // field 20172, runtime offset 16, flags 0x6
    public UnityEngine.GameObject beamLineRendererPrefab;
    // field 20173, runtime offset 20, flags 0x6
    public UnityEngine.GameObject beamStartPrefab;
    // field 20174, runtime offset 24, flags 0x6
    public UnityEngine.GameObject beamEndPrefab;
    // field 20175, runtime offset 28, flags 0x1
    private UnityEngine.GameObject beamStart;
    // field 20176, runtime offset 32, flags 0x1
    private UnityEngine.GameObject beamEnd;
    // field 20177, runtime offset 36, flags 0x1
    private UnityEngine.GameObject beam;
    // field 20178, runtime offset 40, flags 0x1
    private UnityEngine.LineRenderer line;
    // field 20179, runtime offset 44, flags 0x6
    public bool alwaysOn;
    // field 20180, runtime offset 45, flags 0x6
    public bool beamCollides;
    // field 20181, runtime offset 48, flags 0x6
    public float beamLength;
    // field 20182, runtime offset 52, flags 0x6
    public float beamEndOffset;
    // field 20183, runtime offset 56, flags 0x6
    public float textureScrollSpeed;
    // field 20184, runtime offset 60, flags 0x6
    public float textureLengthScale;
    // method 34302, 0x6001207
    void Start();
    // method 34303, 0x6001208
    void OnEnable();
    // method 34304, 0x6001209
    void OnDisable();
    // method 34305, 0x600120a
    void FixedUpdate();
    // method 34306, 0x600120b
    void SpawnBeam();
    // method 34307, 0x600120c
    void RemoveBeam();
    // method 34308, 0x600120d
    void .ctor();
}

// TypeDefinition 4652, 0x20002dc
// Namespace PolygonArsenal
class PolygonLightFade : UnityEngine.MonoBehaviour {
    // field 20185, runtime offset 16, flags 0x6
    public float life;
    // field 20186, runtime offset 20, flags 0x6
    public bool killAfterLife;
    // field 20187, runtime offset 24, flags 0x1
    private UnityEngine.Light li;
    // field 20188, runtime offset 28, flags 0x1
    private float initIntensity;
    // method 34309, 0x600120e
    void Start();
    // method 34310, 0x600120f
    void Update();
    // method 34311, 0x6001210
    void .ctor();
}

// TypeDefinition 4653, 0x20002de
class spaceEnum : System.Enum {
    // field 20191, runtime offset 8, flags 0x606
    public int value__;
    // field 20192, runtime offset 0, flags 0x8056
    public static const spaceEnum Local = 0;
    // field 20193, runtime offset 0, flags 0x8056
    public static const spaceEnum World = 1;
}

// TypeDefinition 4654, 0x20002dd
// Namespace PolygonArsenal
class PolygonRotation : UnityEngine.MonoBehaviour {
    // field 20189, runtime offset 16, flags 0x6
    public UnityEngine.Vector3 rotateVector;
    // field 20190, runtime offset 28, flags 0x6
    public spaceEnum rotateSpace;
    // method 34312, 0x6001211
    void Start();
    // method 34313, 0x6001212
    void Update();
    // method 34314, 0x6001213
    void .ctor();
}

// TypeDefinition 4655, 0x20002df
// Namespace PolygonArsenal
class PolygonSoundSpawn : UnityEngine.MonoBehaviour {
    // field 20194, runtime offset 16, flags 0x6
    public UnityEngine.GameObject prefabSound;
    // field 20195, runtime offset 20, flags 0x6
    public bool destroyWhenDone;
    // field 20196, runtime offset 21, flags 0x6
    public bool soundPrefabIsChild;
    // field 20197, runtime offset 24, flags 0x6
    public float pitchRandomMultiplier;
    // method 34315, 0x6001214
    void Start();
    // method 34316, 0x6001215
    void .ctor();
}

// TypeDefinition 4656, 0x20002e0
// Namespace ExitGames.Client.Photon
class WaitForRealSeconds : UnityEngine.CustomYieldInstruction {
    // field 20198, runtime offset 8, flags 0x21
    private float _endTime;
    // method 34317, 0x6001216
    bool get_keepWaiting();
    // method 34318, 0x6001217
    void .ctor(float seconds);
}

// TypeDefinition 4657, 0x20002e2
class MonoBehaviourExt : UnityEngine.MonoBehaviour {
    // method 34328, 0x6001221
    void .ctor();
}

// TypeDefinition 4658, 0x20002e3
class <ReceiveLoop>d__13 : object {
    // field 20205, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20206, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 20207, runtime offset 16, flags 0x6
    public ExitGames.Client.Photon.SocketWebTcp <>4__this;
    // method 34329, 0x6001222
    void .ctor(int <>1__state);
    // method 34330, 0x6001223
    void System.IDisposable.Dispose();
    // method 34331, 0x6001224
    bool MoveNext();
    // method 34332, 0x6001225
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 34333, 0x6001226
    void System.Collections.IEnumerator.Reset();
    // method 34334, 0x6001227
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4659, 0x20002e1
// Namespace ExitGames.Client.Photon
class SocketWebTcp : ExitGames.Client.Photon.IPhotonSocket {
    // field 20199, runtime offset 52, flags 0x1
    private ExitGames.Client.Photon.WebSocket sock;
    // field 20200, runtime offset 56, flags 0x21
    private object syncer;
    // field 20201, runtime offset 60, flags 0x1
    private UnityEngine.GameObject websocketConnectionObject;
    // field 20202, runtime offset 0, flags 0x8053
    internal static const int ALL_HEADER_BYTES = 9;
    // field 20203, runtime offset 0, flags 0x8053
    internal static const int TCP_HEADER_BYTES = 7;
    // field 20204, runtime offset 0, flags 0x8053
    internal static const int MSG_HEADER_BYTES = 2;
    // method 34319, 0x6001218
    void .ctor(ExitGames.Client.Photon.PeerBase npeer);
    // method 34320, 0x6001219
    void Dispose();
    // method 34321, 0x600121a
    bool Connect();
    // method 34322, 0x600121b
    bool ReadProxyConfigScheme(string proxyAddress, string url, out string proxyUrl);
    // method 34323, 0x600121c
    bool Disconnect();
    // method 34324, 0x600121d
    ExitGames.Client.Photon.PhotonSocketError Send(byte[] data, int length);
    // method 34325, 0x600121e
    ExitGames.Client.Photon.PhotonSocketError Receive(out byte[] data);
    // method 34326, 0x600121f
    System.Collections.IEnumerator ReceiveLoop();
    // method 34327, 0x6001220
    void <Connect>b__5_0(ExitGames.Client.Photon.DebugLevel l, string s);
}

// TypeDefinition 4660, 0x20002e4
// Namespace ExitGames.Client.Photon
class WebSocket : object {
    // field 20208, runtime offset 8, flags 0x1
    private System.Uri mUrl;
    // field 20209, runtime offset 12, flags 0x1
    private string mProxyAddress;
    // field 20210, runtime offset 16, flags 0x1
    private string protocols;
    // field 20211, runtime offset 20, flags 0x1
    private System.Action<ExitGames.Client.Photon.DebugLevel, string> <DebugReturn>k__BackingField;
    // field 20212, runtime offset 24, flags 0x1
    private int m_NativeRef;
    // method 34335, 0x6001228
    System.Action<ExitGames.Client.Photon.DebugLevel, string> get_DebugReturn();
    // method 34336, 0x6001229
    void set_DebugReturn(System.Action<ExitGames.Client.Photon.DebugLevel, string> value);
    // method 34337, 0x600122a
    void .ctor(System.Uri url, string proxyAddress, string protocols);
    // method 34338, 0x600122b
    string get_ProxyAddress();
    // method 34339, 0x600122c
    void SendString(string str);
    // method 34340, 0x600122d
    string RecvString();
    // method 34341, 0x600122e
    int SocketCreate(string url, string protocols);
    // method 34342, 0x600122f
    int SocketState(int socketInstance);
    // method 34343, 0x6001230
    void SocketSend(int socketInstance, byte[] ptr, int length);
    // method 34344, 0x6001231
    void SocketRecv(int socketInstance, byte[] ptr, int length);
    // method 34345, 0x6001232
    int SocketRecvLength(int socketInstance);
    // method 34346, 0x6001233
    void SocketClose(int socketInstance);
    // method 34347, 0x6001234
    int SocketError(int socketInstance, byte[] ptr, int length);
    // method 34348, 0x6001235
    void Send(byte[] buffer);
    // method 34349, 0x6001236
    byte[] Recv();
    // method 34350, 0x6001237
    void Connect();
    // method 34351, 0x6001238
    void Close();
    // method 34352, 0x6001239
    bool get_Connected();
    // method 34353, 0x600123a
    string get_Error();
}

// TypeDefinition 4661, 0x20002e5
// Namespace Assets.Scripts.Water
class WaterArea : UnityEngine.MonoBehaviour {
    // field 20213, runtime offset 16, flags 0x1
    private Assets.Scripts.Water.WaterPropertyBlockSetter waterProperties;
    // method 34354, 0x600123b
    UnityEngine.MaterialPropertyBlock get_WaterPropertyBlock();
    // method 34355, 0x600123c
    void .ctor();
}

// TypeDefinition 4662, 0x20002e6
// Namespace Assets.Scripts.Water
class WaterMaterialSwitcher : UnityEngine.MonoBehaviour {
    // field 20214, runtime offset 16, flags 0x1
    private UnityEngine.Renderer renderer;
    // field 20215, runtime offset 20, flags 0x1
    private UnityEngine.Material waterMaterial;
    // field 20216, runtime offset 24, flags 0x1
    private UnityEngine.Material diffuseMaterial;
    // field 20217, runtime offset 28, flags 0x1
    private UnityEngine.MaterialPropertyBlock defaulPropertyBlock;
    // method 34356, 0x600123d
    void Awake();
    // method 34357, 0x600123e
    void OnTriggerEnter(UnityEngine.Collider collider);
    // method 34358, 0x600123f
    void OnTriggerExit(UnityEngine.Collider collider);
    // method 34359, 0x6001240
    void .ctor();
}

// TypeDefinition 4663, 0x20002e7
// Namespace Assets.Scripts.Water
class WaterPropertyBlockSetter : UnityEngine.MonoBehaviour {
    // field 20218, runtime offset 16, flags 0x1
    private UnityEngine.Renderer[] waterRenderers;
    // field 20219, runtime offset 20, flags 0x1
    private UnityEngine.Color waterColor;
    // field 20220, runtime offset 36, flags 0x1
    private UnityEngine.Texture waterTex;
    // field 20221, runtime offset 40, flags 0x1
    private UnityEngine.Vector2 waterTile;
    // field 20222, runtime offset 48, flags 0x1
    private float textureVisibility;
    // field 20223, runtime offset 52, flags 0x1
    private UnityEngine.Texture distortionTex;
    // field 20224, runtime offset 56, flags 0x1
    private UnityEngine.Vector2 distortionTile;
    // field 20225, runtime offset 64, flags 0x1
    private float waterHeight;
    // field 20226, runtime offset 68, flags 0x1
    private float waterDeep;
    // field 20227, runtime offset 72, flags 0x1
    private float waterDepthParam;
    // field 20228, runtime offset 76, flags 0x1
    private float waterMinAlpha;
    // field 20229, runtime offset 80, flags 0x1
    private UnityEngine.Color borderColor;
    // field 20230, runtime offset 96, flags 0x1
    private float borderWidth;
    // field 20231, runtime offset 100, flags 0x1
    private UnityEngine.Vector2 moveDirection;
    // field 20232, runtime offset 108, flags 0x1
    private UnityEngine.MaterialPropertyBlock materialPropertyBlock;
    // method 34360, 0x6001241
    UnityEngine.MaterialPropertyBlock get_MaterialPropertyBlock();
    // method 34361, 0x6001242
    void Awake();
    // method 34362, 0x6001243
    void SetUpPropertyBlock(UnityEngine.MaterialPropertyBlock propertyBlock);
    // method 34363, 0x6001244
    void .ctor();
}

// TypeDefinition 4664, 0x20002e8
// Namespace Assets.Scripts.Helpers
class FPSCounter : object {
    // field 20233, runtime offset 0, flags 0x8051
    private static const float Frequency = 0.10000000149011612;
    // field 20234, runtime offset 0, flags 0x8051
    private static const int DataSize = 100;
    // field 20235, runtime offset 8, flags 0x1
    private float[] fpsData;
    // field 20236, runtime offset 12, flags 0x1
    private float[] deltaTimeData;
    // field 20237, runtime offset 16, flags 0x1
    private float timer;
    // field 20238, runtime offset 20, flags 0x1
    private int index;
    // field 20239, runtime offset 24, flags 0x1
    private int lastFrameCount;
    // field 20240, runtime offset 28, flags 0x1
    private float lastTime;
    // method 34364, 0x6001245
    void .ctor();
    // method 34365, 0x6001246
    float get_Fps();
    // method 34366, 0x6001247
    void Update(float deltaTime);
    // method 34367, 0x6001248
    float GetAverageFps(float forLastSec);
}

// TypeDefinition 4665, 0x20002e9
// Namespace Assets.MobileOptimizedWater.Scripts
class AnimationStarter : UnityEngine.MonoBehaviour {
    // field 20241, runtime offset 16, flags 0x1
    private UnityEngine.Animator animator;
    // field 20242, runtime offset 20, flags 0x1
    private UnityEngine.Motion animation;
    // method 34368, 0x6001249
    void Awake();
    // method 34369, 0x600124a
    void .ctor();
}

// TypeDefinition 4666, 0x20002ea
// Namespace Assets.MobileOptimizedWater.Scripts
class CameraDepthSlider : UnityEngine.MonoBehaviour {
    // field 20243, runtime offset 16, flags 0x1
    private UnityEngine.UI.Slider slider;
    // field 20244, runtime offset 20, flags 0x1
    private UnityEngine.Transform cameraTransform;
    // field 20245, runtime offset 24, flags 0x1
    private float minDistance;
    // field 20246, runtime offset 28, flags 0x1
    private float maxDistance;
    // field 20247, runtime offset 32, flags 0x1
    private float scrollDelta;
    // field 20248, runtime offset 36, flags 0x1
    private float scrollSpeed;
    // field 20249, runtime offset 40, flags 0x1
    private UnityEngine.Vector3 cameraDirectionToRoot;
    // field 20250, runtime offset 52, flags 0x1
    private float currentScrollSpeed;
    // field 20251, runtime offset 56, flags 0x1
    private float currentValue;
    // method 34370, 0x600124b
    void Awake();
    // method 34371, 0x600124c
    void OnSliderValueChanged();
    // method 34372, 0x600124d
    void UpdateDepthPosition(float value);
    // method 34373, 0x600124e
    void .ctor();
}

// TypeDefinition 4667, 0x20002eb
// Namespace Assets.MobileOptimizedWater.Scripts
class CameraRotator : UnityEngine.MonoBehaviour {
    // field 20252, runtime offset 16, flags 0x1
    private float speed;
    // method 34374, 0x600124f
    void Update();
    // method 34375, 0x6001250
    void .ctor();
}

// TypeDefinition 4668, 0x20002ec
// Namespace Assets.MobileOptimizedWater.Scripts
class FPSUI : UnityEngine.MonoBehaviour {
    // field 20253, runtime offset 16, flags 0x1
    private UnityEngine.UI.Text fpsText;
    // field 20254, runtime offset 20, flags 0x1
    private Assets.Scripts.Helpers.FPSCounter fpsCounter;
    // method 34376, 0x6001251
    void Awake();
    // method 34377, 0x6001252
    void Update();
    // method 34378, 0x6001253
    void .ctor();
}

// TypeDefinition 4669, 0x20002ed
// Namespace Assets.MobileOptimizedWater.Scripts
class TouchRotator : UnityEngine.MonoBehaviour {
    // field 20255, runtime offset 16, flags 0x1
    private UnityEngine.Transform cameraRoot;
    // field 20256, runtime offset 20, flags 0x1
    private float speed;
    // field 20257, runtime offset 24, flags 0x1
    private float mouseSpeed;
    // field 20258, runtime offset 28, flags 0x1
    private UnityEngine.Vector3 prevMousePos;
    // method 34379, 0x6001254
    void Update();
    // method 34380, 0x6001255
    void .ctor();
}

// TypeDefinition 4670, 0x20002ee
// Namespace GogoGaga.UWI
class AnimationController : UnityEngine.MonoBehaviour {
    // field 20259, runtime offset 16, flags 0x1
    private UnityEngine.Animator animCont;
    // method 34381, 0x6001256
    void Awake();
    // method 34382, 0x6001257
    void Play(string name);
    // method 34383, 0x6001258
    void SetTrigger(string name);
    // method 34384, 0x6001259
    void StopAnimator();
    // method 34385, 0x600125a
    void .ctor();
}

// TypeDefinition 4671, 0x20002f0
class <Disable>d__19 : object {
    // field 20270, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20271, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 20272, runtime offset 16, flags 0x6
    public GogoGaga.UWI.CenterTrackMarkerUI <>4__this;
    // method 34397, 0x6001266
    void .ctor(int <>1__state);
    // method 34398, 0x6001267
    void System.IDisposable.Dispose();
    // method 34399, 0x6001268
    bool MoveNext();
    // method 34400, 0x6001269
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 34401, 0x600126a
    void System.Collections.IEnumerator.Reset();
    // method 34402, 0x600126b
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4672, 0x20002f1
class <FarWaypointDelay>d__15 : object {
    // field 20273, runtime offset 8, flags 0x1
    private int <>1__state;
    // field 20274, runtime offset 12, flags 0x1
    private object <>2__current;
    // field 20275, runtime offset 16, flags 0x6
    public GogoGaga.UWI.CenterTrackMarkerUI <>4__this;
    // method 34403, 0x600126c
    void .ctor(int <>1__state);
    // method 34404, 0x600126d
    void System.IDisposable.Dispose();
    // method 34405, 0x600126e
    bool MoveNext();
    // method 34406, 0x600126f
    object System.Collections.Generic.IEnumerator<System.Object>.get_Current();
    // method 34407, 0x6001270
    void System.Collections.IEnumerator.Reset();
    // method 34408, 0x6001271
    object System.Collections.IEnumerator.get_Current();
}

// TypeDefinition 4673, 0x20002ef
// Namespace GogoGaga.UWI
class CenterTrackMarkerUI : UnityEngine.MonoBehaviour {
    // field 20260, runtime offset 16, flags 0x6
    public UnityEngine.UI.Image IconImage;
    // field 20261, runtime offset 20, flags 0x1
    private GogoGaga.UWI.CenterTrackWorldMarker worldMarker;
    // field 20262, runtime offset 24, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 20263, runtime offset 28, flags 0x1
    private bool farAway;
    // field 20264, runtime offset 32, flags 0x1
    private UnityEngine.Camera mainCam;
    // field 20265, runtime offset 36, flags 0x1
    private UnityEngine.Vector3 targetPos;
    // field 20266, runtime offset 48, flags 0x1
    private float distance;
    // field 20267, runtime offset 52, flags 0x1
    private bool disabling;
    // field 20268, runtime offset 56, flags 0x1
    private float destroyTime;
    // field 20269, runtime offset 60, flags 0x1
    private UnityEngine.GameObject g;
    // method 34386, 0x600125b
    void OnDisable();
    // method 34387, 0x600125c
    void Start();
    // method 34388, 0x600125d
    void OnDestroy();
    // method 34389, 0x600125e
    void CameraChange(UnityEngine.Camera cam);
    // method 34390, 0x600125f
    void SetMarker(GogoGaga.UWI.CenterTrackWorldMarker marker);
    // method 34391, 0x6001260
    System.Collections.IEnumerator FarWaypointDelay();
    // method 34392, 0x6001261
    void FarUpdateUI();
    // method 34393, 0x6001262
    void Update();
    // method 34394, 0x6001263
    void UpdateUI();
    // method 34395, 0x6001264
    System.Collections.IEnumerator Disable();
    // method 34396, 0x6001265
    void .ctor();
}

// TypeDefinition 4674, 0x20002f2
// Namespace GogoGaga.UWI
class CenterTrackWorldMarker : UnityEngine.MonoBehaviour {
    // field 20276, runtime offset 16, flags 0x1
    private GogoGaga.UWI.WaypointPanelManager <waypointPanelManager>k__BackingField;
    // field 20277, runtime offset 20, flags 0x1
    private GogoGaga.UWI.CenterTrackMarkerUI markerUI;
    // field 20278, runtime offset 24, flags 0x6
    public GogoGaga.UWI.CenterTrackMarkerProperties centerTrackProperties;
    // method 34409, 0x6001272
    GogoGaga.UWI.WaypointPanelManager get_waypointPanelManager();
    // method 34410, 0x6001273
    void set_waypointPanelManager(GogoGaga.UWI.WaypointPanelManager value);
    // method 34411, 0x6001274
    void Start();
    // method 34412, 0x6001275
    void Setup();
    // method 34413, 0x6001276
    void Update();
    // method 34414, 0x6001277
    void OnDestroy();
    // method 34415, 0x6001278
    void .ctor();
}

// TypeDefinition 4675, 0x20002f4
class DisableType : System.Enum {
    // field 20293, runtime offset 8, flags 0x606
    public int value__;
    // field 20294, runtime offset 0, flags 0x8056
    public static const DisableType none = 0;
    // field 20295, runtime offset 0, flags 0x8056
    public static const DisableType Disable = 1;
    // field 20296, runtime offset 0, flags 0x8056
    public static const DisableType Destroy = 2;
}

// TypeDefinition 4676, 0x20002f3
// Namespace GogoGaga.UWI
class CenterTrackMarkerProperties : object {
    // field 20279, runtime offset 8, flags 0x6
    public GogoGaga.UWI.WAYPOINT_GRAPHICS_TYPE GraphicsType;
    // field 20280, runtime offset 12, flags 0x6
    public UnityEngine.RectTransform PrefabAsset;
    // field 20281, runtime offset 16, flags 0x6
    public UnityEngine.Sprite Icon;
    // field 20282, runtime offset 20, flags 0x6
    public UnityEngine.Color IconColor;
    // field 20283, runtime offset 36, flags 0x6
    public float IconSize;
    // field 20284, runtime offset 40, flags 0x6
    public float IconDistance;
    // field 20285, runtime offset 44, flags 0x6
    public float IconRotation;
    // field 20286, runtime offset 48, flags 0x6
    public float fadeDistance_UI;
    // field 20287, runtime offset 52, flags 0x6
    public float fadeSmoothing_UI;
    // field 20288, runtime offset 56, flags 0x6
    public bool UnlimitedDistance;
    // field 20289, runtime offset 60, flags 0x6
    public float MaxDistance;
    // field 20290, runtime offset 64, flags 0x6
    public float maxDisFadingTime;
    // field 20291, runtime offset 68, flags 0x6
    public DisableType _disableType;
    // field 20292, runtime offset 72, flags 0x6
    public float destroyTime;
    // method 34416, 0x6001279
    void .ctor();
}

// TypeDefinition 4677, 0x20002f5
// Namespace GogoGaga.UWI
class WaypointMarkerUI : UnityEngine.MonoBehaviour {
    // field 20297, runtime offset 16, flags 0x6
    public UnityEngine.UI.Image onScreenImage;
    // field 20298, runtime offset 20, flags 0x6
    public UnityEngine.UI.Image offScreenImage;
    // field 20299, runtime offset 24, flags 0x6
    public UnityEngine.Transform offScreenParent;
    // field 20300, runtime offset 28, flags 0x6
    public TMPro.TextMeshProUGUI titleText;
    // field 20301, runtime offset 32, flags 0x6
    public TMPro.TextMeshProUGUI distanceText;
    // field 20302, runtime offset 36, flags 0x1
    private GogoGaga.UWI.WaypointWorldMarker worldMarker;
    // field 20303, runtime offset 40, flags 0x1
    private UnityEngine.RectTransform rectT;
    // field 20304, runtime offset 44, flags 0x1
    private UnityEngine.CanvasGroup canvasGroup;
    // field 20305, runtime offset 48, flags 0x1
    private UnityEngine.Camera _mainCam;
    // field 20306, runtime offset 52, flags 0x1
    private GogoGaga.UWI.WaypointPrefabRotation[] OffScreenRotationPrefabs;
    // field 20307, runtime offset 56, flags 0x1
    private UnityEngine.Vector3 targetPos;
    // field 20308, runtime offset 68, flags 0x1
    private float distance;
    // field 20309, runtime offset 72, flags 0x1
    private float dotProduct;
    // field 20310, runtime offset 76, flags 0x1
    private bool outOfscreen;
    // method 34417, 0x600127a
    UnityEngine.Camera get_mainCam();
    // method 34418, 0x600127b
    void set_mainCam(UnityEngine.Camera value);
    // method 34419, 0x600127c
    void Start();
    // method 34420, 0x600127d
    void OnEnable();
    // method 34421, 0x600127e
    void OnDestroy();
    // method 34422, 0x600127f
    void CameraChange(UnityEngine.Camera cam);
    // method 34423, 0x6001280
    void CheckRotationPrefabs();
    // method 34424, 0x6001281
    void SetMarker(GogoGaga.UWI.WaypointWorldMarker marker);
    // method 34425, 0x6001282
    void UISetup();
    // method 34426, 0x6001283
    void LateUpdate();
    // method 34427, 0x6001284
    void UpdateUI();
    // method 34428, 0x6001285
    void HandleRotation();
    // method 34429, 0x6001286
    void .ctor();
}

// TypeDefinition 4678, 0x20002f6
// Namespace GogoGaga.UWI
class WaypointPanelManager : UnityEngine.MonoBehaviour {
    // field 20311, runtime offset 16, flags 0x6
    public GogoGaga.UWI.WaypointMarkerUI waypointUIPrefab;
    // field 20312, runtime offset 20, flags 0x6
    public GogoGaga.UWI.CenterTrackMarkerUI centerTrackUIPrefab;
    // field 20313, runtime offset 24, flags 0x6
    public UnityEngine.Transform uiParent;
    // field 20314, runtime offset 28, flags 0x1
    private System.Collections.Generic.List<GogoGaga.UWI.WaypointWorldMarker> allMarkers;
    // field 20315, runtime offset 32, flags 0x1
    private System.Collections.Generic.List<GogoGaga.UWI.CenterTrackWorldMarker> allCenterTrackMarker;
    // method 34430, 0x6001287
    GogoGaga.UWI.WaypointWorldMarker CreateWaypoint(GogoGaga.UWI.WaypointMarkerProperties properties, UnityEngine.Vector3 worldPos);
    // method 34431, 0x6001288
    void AddMarker(GogoGaga.UWI.WaypointWorldMarker marker);
    // method 34432, 0x6001289
    void removeMarker(GogoGaga.UWI.WaypointWorldMarker m);
    // method 34433, 0x600128a
    void AddCenterTrackMarker(GogoGaga.UWI.CenterTrackWorldMarker marker);
    // method 34434, 0x600128b
    void removeCenterTrackMarker(GogoGaga.UWI.CenterTrackWorldMarker m);
    // method 34435, 0x600128c
    GogoGaga.UWI.WaypointMarkerUI CreateWaypointUI(GogoGaga.UWI.WaypointWorldMarker marker);
    // method 34436, 0x600128d
    GogoGaga.UWI.CenterTrackMarkerUI CreateCenterTrackUI(GogoGaga.UWI.CenterTrackWorldMarker marker);
    // method 34437, 0x600128e
    void RemoveAll();
    // method 34438, 0x600128f
    void .ctor();
}

// TypeDefinition 4679, 0x20002f7
// Namespace GogoGaga.UWI
class WaypointPrefabRotation : UnityEngine.MonoBehaviour {
    // field 20316, runtime offset 16, flags 0x1
    private float RotationOffset;
    // method 34439, 0x6001290
    void ApplyRotation(float angle);
    // method 34440, 0x6001291
    void .ctor();
}

// TypeDefinition 4680, 0x20002f8
// Namespace GogoGaga.UWI
class WAYPOINT_GRAPHICS_TYPE : System.Enum {
    // field 20317, runtime offset 8, flags 0x606
    public int value__;
    // field 20318, runtime offset 0, flags 0x8056
    public static const GogoGaga.UWI.WAYPOINT_GRAPHICS_TYPE sprite = 0;
    // field 20319, runtime offset 0, flags 0x8056
    public static const GogoGaga.UWI.WAYPOINT_GRAPHICS_TYPE prefab = 1;
}

// TypeDefinition 4681, 0x20002f9
// Namespace GogoGaga.UWI
class WaypointWorldMarker : UnityEngine.MonoBehaviour {
    // field 20320, runtime offset 16, flags 0x6
    public GogoGaga.UWI.WaypointMarkerProperties WaypointProperties;
    // field 20321, runtime offset 20, flags 0x1
    private GogoGaga.UWI.WaypointPanelManager <waypointPanelManager>k__BackingField;
    // field 20322, runtime offset 24, flags 0x1
    private GogoGaga.UWI.WaypointMarkerUI markerUI;
    // field 20323, runtime offset 28, flags 0x1
    private bool _commonPropertiesMenu;
    // field 20324, runtime offset 29, flags 0x1
    private bool _showOnScreenMenu;
    // field 20325, runtime offset 30, flags 0x1
    private bool _showOffScreenMenu;
    // field 20326, runtime offset 31, flags 0x1
    private bool _showTextProperties;
    // field 20327, runtime offset 32, flags 0x1
    private bool _showOtherProperties;
    // method 34441, 0x6001292
    GogoGaga.UWI.WaypointPanelManager get_waypointPanelManager();
    // method 34442, 0x6001293
    void set_waypointPanelManager(GogoGaga.UWI.WaypointPanelManager value);
    // method 34443, 0x6001294
    void Start();
    // method 34444, 0x6001295
    void OnEnable();
    // method 34445, 0x6001296
    void OnDisable();
    // method 34446, 0x6001297
    void Setup();
    // method 34447, 0x6001298
    void Update();
    // method 34448, 0x6001299
    void OnDestroy();
    // method 34449, 0x600129a
    void .ctor();
}

// TypeDefinition 4682, 0x20002fa
// Namespace GogoGaga.UWI
class WaypointMarkerProperties : object {
    // field 20328, runtime offset 8, flags 0x6
    public string Title;
    // field 20329, runtime offset 12, flags 0x6
    public UnityEngine.Vector3 PostionOffset;
    // field 20330, runtime offset 24, flags 0x6
    public UnityEngine.Vector4 UIOffsetLeftRightTopBottom;
    // field 20331, runtime offset 40, flags 0x6
    public bool UnlimitedDistance;
    // field 20332, runtime offset 44, flags 0x6
    public float MaxDistance;
    // field 20333, runtime offset 48, flags 0x6
    public float maxDisFadingTime;
    // field 20334, runtime offset 52, flags 0x6
    public float HideWhenCloseDistance;
    // field 20335, runtime offset 56, flags 0x6
    public float HideFadingSmoothing;
    // field 20336, runtime offset 60, flags 0x6
    public bool showOnScreen;
    // field 20337, runtime offset 64, flags 0x6
    public GogoGaga.UWI.WAYPOINT_GRAPHICS_TYPE onScreenGraphicsType;
    // field 20338, runtime offset 68, flags 0x6
    public UnityEngine.RectTransform onScreenPrefab;
    // field 20339, runtime offset 72, flags 0x6
    public UnityEngine.Sprite onScreenImage;
    // field 20340, runtime offset 76, flags 0x6
    public UnityEngine.Color onScreenImageColor;
    // field 20341, runtime offset 92, flags 0x6
    public float onScreenSize;
    // field 20342, runtime offset 96, flags 0x6
    public float onScreenRotation;
    // field 20343, runtime offset 100, flags 0x6
    public UnityEngine.Vector2 onScreenPositionOffset;
    // field 20344, runtime offset 108, flags 0x6
    public bool showOffScreen;
    // field 20345, runtime offset 112, flags 0x6
    public GogoGaga.UWI.WAYPOINT_GRAPHICS_TYPE offScreenGraphicsType;
    // field 20346, runtime offset 116, flags 0x6
    public UnityEngine.RectTransform offScreenPrefab;
    // field 20347, runtime offset 120, flags 0x6
    public UnityEngine.Sprite offScreenImage;
    // field 20348, runtime offset 124, flags 0x6
    public UnityEngine.Color offScreenImageColor;
    // field 20349, runtime offset 140, flags 0x6
    public float offScreenSize;
    // field 20350, runtime offset 144, flags 0x6
    public float offScreenRotation;
    // field 20351, runtime offset 148, flags 0x6
    public bool rotateToTarget;
    // field 20352, runtime offset 152, flags 0x6
    public UnityEngine.Vector2 offScreenPositionOffset;
    // field 20353, runtime offset 160, flags 0x6
    public TMPro.TMP_FontAsset textMeshTextPreset;
    // field 20354, runtime offset 164, flags 0x6
    public bool showDistanceOnScreen;
    // field 20355, runtime offset 165, flags 0x6
    public bool showDistanceOffScreen;
    // field 20356, runtime offset 168, flags 0x6
    public float distanceTextFontSize;
    // field 20357, runtime offset 172, flags 0x6
    public UnityEngine.Color distanceTextColor;
    // field 20358, runtime offset 188, flags 0x6
    public UnityEngine.Vector2 distanceTextPositionOffset;
    // field 20359, runtime offset 196, flags 0x6
    public bool showTitleOnScreen;
    // field 20360, runtime offset 197, flags 0x6
    public bool showTitleOffScreen;
    // field 20361, runtime offset 200, flags 0x6
    public float titleTextFontSize;
    // field 20362, runtime offset 204, flags 0x6
    public UnityEngine.Color titleTextColor;
    // field 20363, runtime offset 220, flags 0x6
    public UnityEngine.Vector2 titleTextPositionOffset;
    // field 20364, runtime offset 228, flags 0x6
    public GogoGaga.UWI.WaypointMarkerUI CustomUI;
    // method 34450, 0x600129b
    void .ctor();
}

// TypeDefinition 4683, 0x20002fc
class CameraChangeEvent : System.MulticastDelegate {
    // method 34467, 0x60012ac
    void .ctor(object object, nint method);
    // method 34468, 0x60012ad
    void Invoke(UnityEngine.Camera cam);
    // method 34469, 0x60012ae
    System.IAsyncResult BeginInvoke(UnityEngine.Camera cam, System.AsyncCallback callback, object object);
    // method 34470, 0x60012af
    void EndInvoke(System.IAsyncResult result);
}

// TypeDefinition 4684, 0x20002fb
// Namespace GogoGaga.UWI
class UltimateWaypointIndicator : UnityEngine.MonoBehaviour {
    // field 20365, runtime offset 0, flags 0x11
    private static GogoGaga.UWI.UltimateWaypointIndicator <Instance>k__BackingField;
    // field 20366, runtime offset 16, flags 0x6
    public bool DoNotDestroyOnLoad;
    // field 20367, runtime offset 20, flags 0x6
    public GogoGaga.UWI.WaypointPanelManager waypointPanelManager;
    // field 20368, runtime offset 24, flags 0x1
    private UnityEngine.Camera <mainCam>k__BackingField;
    // field 20369, runtime offset 28, flags 0x1
    private CameraChangeEvent OnCameraChange;
    // method 34451, 0x600129c
    GogoGaga.UWI.UltimateWaypointIndicator get_Instance();
    // method 34452, 0x600129d
    void set_Instance(GogoGaga.UWI.UltimateWaypointIndicator value);
    // method 34453, 0x600129e
    UnityEngine.Camera get_mainCam();
    // method 34454, 0x600129f
    void set_mainCam(UnityEngine.Camera value);
    // method 34455, 0x60012a0
    void add_OnCameraChange(CameraChangeEvent value);
    // method 34456, 0x60012a1
    void remove_OnCameraChange(CameraChangeEvent value);
    // method 34457, 0x60012a2
    void Awake();
    // method 34458, 0x60012a3
    void Start();
    // method 34459, 0x60012a4
    GogoGaga.UWI.WaypointWorldMarker CreateWaypoint(UnityEngine.Vector3 position);
    // method 34460, 0x60012a5
    GogoGaga.UWI.WaypointWorldMarker CreateWaypoint(GogoGaga.UWI.WaypointWorldMarker marker, UnityEngine.Vector3 position);
    // method 34461, 0x60012a6
    GogoGaga.UWI.WaypointWorldMarker CreateWaypoint(GogoGaga.UWI.WaypointMarkerProperties properties, UnityEngine.Vector3 position);
    // method 34462, 0x60012a7
    void RemoveAllWaypoints();
    // method 34463, 0x60012a8
    float RemapValue(float from, float fromMin, float fromMax, float toMin, float toMax);
    // method 34464, 0x60012a9
    float GetAngle(UnityEngine.Vector3 a1, UnityEngine.Vector3 a2, UnityEngine.Vector3 n);
    // method 34465, 0x60012aa
    void SetMainCamera(UnityEngine.Camera cam);
    // method 34466, 0x60012ab
    void .ctor();
}

// TypeDefinition 4685, 0x20002fd
// Namespace LayerLab
class PanelSimpleCasual : UnityEngine.MonoBehaviour {
    // field 20370, runtime offset 16, flags 0x1
    private UnityEngine.GameObject[] otherPanels;
    // method 34471, 0x60012b0
    void OnEnable();
    // method 34472, 0x60012b1
    void OnDisable();
    // method 34473, 0x60012b2
    void .ctor();
}

// TypeDefinition 4686, 0x20002fe
// Namespace EZ_Pooling
class EZ_PoolManager : UnityEngine.MonoBehaviour {
    // field 20371, runtime offset 16, flags 0x6
    public System.Collections.Generic.List<EZ_Pooling.EZ_PrefabPoolOption> prefabPoolOptions;
    // field 20372, runtime offset 20, flags 0x6
    public bool showDebugLog;
    // field 20373, runtime offset 21, flags 0x6
    public bool isRootExpanded;
    // field 20374, runtime offset 22, flags 0x6
    public bool autoAddMissingPrefabPool;
    // field 20375, runtime offset 23, flags 0x6
    public bool usePoolManager;
    // field 20376, runtime offset 0, flags 0x11
    private static System.Collections.Generic.Dictionary<string, EZ_Pooling.EZ_PrefabPool> Pools;
    // field 20377, runtime offset 4, flags 0x11
    private static UnityEngine.Transform parentTransform;
    // field 20378, runtime offset 8, flags 0x11
    private static EZ_Pooling.EZ_PoolManager instance;
    // field 20379, runtime offset 24, flags 0x1
    private System.Collections.Generic.List<EZ_Pooling.EZ_PrefabPoolOption> itemsMarkedForDeletion;
    // method 34474, 0x60012b3
    EZ_Pooling.EZ_PoolManager get_Instance();
    // method 34475, 0x60012b4
    void Awake();
    // method 34476, 0x60012b5
    void Update();
    // method 34477, 0x60012b6
    void CreateMissingPrefabPool(UnityEngine.Transform missingTrans, string name);
    // method 34478, 0x60012b7
    UnityEngine.Transform Spawn(UnityEngine.Transform transToSpawn, UnityEngine.Vector3 position, UnityEngine.Quaternion rotation);
    // method 34479, 0x60012b8
    void Despawn(UnityEngine.Transform transToDespawn);
    // method 34480, 0x60012b9
    EZ_Pooling.EZ_PrefabPool GetPool(string name);
    // method 34481, 0x60012ba
    void .ctor();
    // method 34482, 0x60012bb
    void .cctor();
}

// TypeDefinition 4687, 0x20002ff
// Namespace EZ_Pooling
class EZ_PrefabPool : object {
    // field 20380, runtime offset 8, flags 0x6
    public bool showDebugLog;
    // field 20381, runtime offset 9, flags 0x6
    public bool poolCanGrow;
    // field 20382, runtime offset 10, flags 0x6
    public bool cullDespawned;
    // field 20383, runtime offset 12, flags 0x6
    public int cullAbove;
    // field 20384, runtime offset 16, flags 0x6
    public float cullDelay;
    // field 20385, runtime offset 20, flags 0x6
    public int cullAmount;
    // field 20386, runtime offset 24, flags 0x6
    public bool enableHardLimit;
    // field 20387, runtime offset 28, flags 0x6
    public int hardLimit;
    // field 20388, runtime offset 32, flags 0x6
    public bool recycle;
    // field 20389, runtime offset 36, flags 0x6
    public UnityEngine.Transform parentTransform;
    // field 20390, runtime offset 40, flags 0x6
    public System.Collections.Generic.List<UnityEngine.Transform> spawnedList;
    // field 20391, runtime offset 44, flags 0x6
    public System.Collections.Generic.List<UnityEngine.Transform> despawnedList;
    // field 20392, runtime offset 48, flags 0x1
    private float TimeOfLastCull;
    // method 34483, 0x60012bc
    void .ctor();
    // method 34484, 0x60012bd
    void .ctor(System.Collections.Generic.List<UnityEngine.Transform> list);
    // method 34485, 0x60012be
    UnityEngine.Transform Spawn(UnityEngine.Transform transToSpawn, UnityEngine.Vector3 position, UnityEngine.Quaternion rotation);
    // method 34486, 0x60012bf
    void Despawn(UnityEngine.Transform transToDespawn);
    // method 34487, 0x60012c0
    void Poll();
}

// TypeDefinition 4688, 0x2000300
// Namespace EZ_Pooling
class EZ_PrefabPoolOption : object {
    // field 20393, runtime offset 8, flags 0x6
    public UnityEngine.Transform prefabTransform;
    // field 20394, runtime offset 12, flags 0x6
    public int instancesToPreload;
    // field 20395, runtime offset 16, flags 0x6
    public bool isPoolExpanded;
    // field 20396, runtime offset 17, flags 0x6
    public bool showDebugLog;
    // field 20397, runtime offset 18, flags 0x6
    public bool poolCanGrow;
    // field 20398, runtime offset 19, flags 0x6
    public bool cullDespawned;
    // field 20399, runtime offset 20, flags 0x6
    public int cullAbove;
    // field 20400, runtime offset 24, flags 0x6
    public float cullDelay;
    // field 20401, runtime offset 28, flags 0x6
    public int cullAmount;
    // field 20402, runtime offset 32, flags 0x6
    public bool enableHardLimit;
    // field 20403, runtime offset 36, flags 0x6
    public int hardLimit;
    // field 20404, runtime offset 40, flags 0x6
    public bool recycle;
    // method 34488, 0x60012c1
    void .ctor();
}

// TypeDefinition 4689, 0x2000301
// Namespace Crystal
class SafeAreaDemo : UnityEngine.MonoBehaviour {
    // field 20405, runtime offset 16, flags 0x1
    private UnityEngine.KeyCode KeySafeArea;
    // field 20406, runtime offset 20, flags 0x1
    private SimDevice[] Sims;
    // field 20407, runtime offset 24, flags 0x1
    private int SimIdx;
    // method 34489, 0x60012c2
    void Awake();
    // method 34490, 0x60012c3
    void Update();
    // method 34491, 0x60012c4
    void ToggleSafeArea();
    // method 34492, 0x60012c5
    void .ctor();
}

// TypeDefinition 4690, 0x2000303
class SimDevice : System.Enum {
    // field 20420, runtime offset 8, flags 0x606
    public int value__;
    // field 20421, runtime offset 0, flags 0x8056
    public static const SimDevice None = 0;
    // field 20422, runtime offset 0, flags 0x8056
    public static const SimDevice iPhoneX = 1;
    // field 20423, runtime offset 0, flags 0x8056
    public static const SimDevice iPhoneXsMax = 2;
    // field 20424, runtime offset 0, flags 0x8056
    public static const SimDevice Pixel3XL_LSL = 3;
    // field 20425, runtime offset 0, flags 0x8056
    public static const SimDevice Pixel3XL_LSR = 4;
}

// TypeDefinition 4691, 0x2000302
// Namespace Crystal
class SafeArea : UnityEngine.MonoBehaviour {
    // field 20408, runtime offset 0, flags 0x16
    public static SimDevice Sim;
    // field 20409, runtime offset 16, flags 0x1
    private UnityEngine.Rect[] NSA_iPhoneX;
    // field 20410, runtime offset 20, flags 0x1
    private UnityEngine.Rect[] NSA_iPhoneXsMax;
    // field 20411, runtime offset 24, flags 0x1
    private UnityEngine.Rect[] NSA_Pixel3XL_LSL;
    // field 20412, runtime offset 28, flags 0x1
    private UnityEngine.Rect[] NSA_Pixel3XL_LSR;
    // field 20413, runtime offset 32, flags 0x1
    private UnityEngine.RectTransform Panel;
    // field 20414, runtime offset 36, flags 0x1
    private UnityEngine.Rect LastSafeArea;
    // field 20415, runtime offset 52, flags 0x1
    private UnityEngine.Vector2Int LastScreenSize;
    // field 20416, runtime offset 60, flags 0x1
    private UnityEngine.ScreenOrientation LastOrientation;
    // field 20417, runtime offset 64, flags 0x1
    private bool ConformX;
    // field 20418, runtime offset 65, flags 0x1
    private bool ConformY;
    // field 20419, runtime offset 66, flags 0x1
    private bool Logging;
    // method 34493, 0x60012c6
    void Awake();
    // method 34494, 0x60012c7
    void Update();
    // method 34495, 0x60012c8
    void Refresh();
    // method 34496, 0x60012c9
    UnityEngine.Rect GetSafeArea();
    // method 34497, 0x60012ca
    void ApplySafeArea(UnityEngine.Rect r);
    // method 34498, 0x60012cb
    void .ctor();
}

// TypeDefinition 4692, 0x2000305
class UpdateType : System.Enum {
    // field 20436, runtime offset 8, flags 0x606
    public int value__;
    // field 20437, runtime offset 0, flags 0x8056
    public static const UpdateType Update = 0;
    // field 20438, runtime offset 0, flags 0x8056
    public static const UpdateType LateUpdate = 1;
}

// TypeDefinition 4693, 0x2000306
class SmoothType : System.Enum {
    // field 20439, runtime offset 8, flags 0x606
    public int value__;
    // field 20440, runtime offset 0, flags 0x8056
    public static const SmoothType Lerp = 0;
    // field 20441, runtime offset 0, flags 0x8056
    public static const SmoothType SmoothDamp = 1;
}

// TypeDefinition 4694, 0x2000304
// Namespace CMF
class SmoothPosition : UnityEngine.MonoBehaviour {
    // field 20426, runtime offset 16, flags 0x6
    public UnityEngine.Transform target;
    // field 20427, runtime offset 20, flags 0x1
    private UnityEngine.Transform tr;
    // field 20428, runtime offset 24, flags 0x1
    private UnityEngine.Vector3 currentPosition;
    // field 20429, runtime offset 36, flags 0x6
    public float lerpSpeed;
    // field 20430, runtime offset 40, flags 0x6
    public float smoothDampTime;
    // field 20431, runtime offset 44, flags 0x6
    public bool extrapolatePosition;
    // field 20432, runtime offset 48, flags 0x6
    public UpdateType updateType;
    // field 20433, runtime offset 52, flags 0x6
    public SmoothType smoothType;
    // field 20434, runtime offset 56, flags 0x1
    private UnityEngine.Vector3 localPositionOffset;
    // field 20435, runtime offset 68, flags 0x1
    private UnityEngine.Vector3 refVelocity;
    // method 34499, 0x60012cc
    void Awake();
    // method 34500, 0x60012cd
    void OnEnable();
    // method 34501, 0x60012ce
    void Update();
    // method 34502, 0x60012cf
    void LateUpdate();
    // method 34503, 0x60012d0
    void SmoothUpdate();
    // method 34504, 0x60012d1
    UnityEngine.Vector3 Smooth(UnityEngine.Vector3 _start, UnityEngine.Vector3 _target, float _smoothTime);
    // method 34505, 0x60012d2
    void ResetCurrentPosition();
    // method 34506, 0x60012d3
    void .ctor();
}

// TypeDefinition 4695, 0x2000308
class UpdateType : System.Enum {
    // field 20448, runtime offset 8, flags 0x606
    public int value__;
    // field 20449, runtime offset 0, flags 0x8056
    public static const UpdateType Update = 0;
    // field 20450, runtime offset 0, flags 0x8056
    public static const UpdateType LateUpdate = 1;
}

// TypeDefinition 4696, 0x2000307
// Namespace CMF
class SmoothRotation : UnityEngine.MonoBehaviour {
    // field 20442, runtime offset 16, flags 0x6
    public UnityEngine.Transform target;
    // field 20443, runtime offset 20, flags 0x1
    private UnityEngine.Transform tr;
    // field 20444, runtime offset 24, flags 0x1
    private UnityEngine.Quaternion currentRotation;
    // field 20445, runtime offset 40, flags 0x6
    public float smoothSpeed;
    // field 20446, runtime offset 44, flags 0x6
    public bool extrapolateRotation;
    // field 20447, runtime offset 48, flags 0x6
    public UpdateType updateType;
    // method 34507, 0x60012d4
    void Awake();
    // method 34508, 0x60012d5
    void OnEnable();
    // method 34509, 0x60012d6
    void Update();
    // method 34510, 0x60012d7
    void LateUpdate();
    // method 34511, 0x60012d8
    void SmoothUpdate();
    // method 34512, 0x60012d9
    UnityEngine.Quaternion Smooth(UnityEngine.Quaternion _currentRotation, UnityEngine.Quaternion _targetRotation, float _smoothSpeed);
    // method 34513, 0x60012da
    void ResetCurrentRotation();
    // method 34514, 0x60012db
    void .ctor();
}

// TypeDefinition 4697, 0x2000309
// Namespace ArcadeVP
class SkidMarks : UnityEngine.MonoBehaviour {
    // field 20451, runtime offset 16, flags 0x1
    private UnityEngine.TrailRenderer skidMark;
    // field 20452, runtime offset 20, flags 0x1
    private UnityEngine.ParticleSystem smoke;
    // field 20453, runtime offset 24, flags 0x6
    public ArcadeVehicleController carController;
    // field 20454, runtime offset 28, flags 0x1
    private float fadeOutSpeed;
    // method 34515, 0x60012dc
    void Awake();
    // method 34516, 0x60012dd
    void OnEnable();
    // method 34517, 0x60012de
    void OnDisable();
    // method 34518, 0x60012df
    void FixedUpdate();
    // method 34519, 0x60012e0
    void .ctor();
}

// TypeDefinition 4698, 0x200030b
class __StaticArrayInitTypeSize=12 : System.ValueType {
}

// TypeDefinition 4699, 0x200030c
class __StaticArrayInitTypeSize=20 : System.ValueType {
}

// TypeDefinition 4700, 0x200030d
class __StaticArrayInitTypeSize=28 : System.ValueType {
}

// TypeDefinition 4701, 0x200030e
class __StaticArrayInitTypeSize=32 : System.ValueType {
}

// TypeDefinition 4702, 0x200030f
class __StaticArrayInitTypeSize=60 : System.ValueType {
}

// TypeDefinition 4703, 0x2000310
class __StaticArrayInitTypeSize=104 : System.ValueType {
}

// TypeDefinition 4704, 0x2000311
class __StaticArrayInitTypeSize=8938 : System.ValueType {
}

// TypeDefinition 4705, 0x2000312
class __StaticArrayInitTypeSize=14913 : System.ValueType {
}

// TypeDefinition 4706, 0x200030a
class <PrivateImplementationDetails> : object {
    // field 20455, runtime offset 0, flags 0x133
    internal static __StaticArrayInitTypeSize=60 178C7E859D6ECE229B53A199EA0371A5AB29A7F3A2B8F733B9B9F891A834C02B;
    // field 20456, runtime offset 60, flags 0x133
    internal static __StaticArrayInitTypeSize=20 22D210985B9BD717AB2FEC1D6E19288CE35515D772083864B6B3192B08FBA76C;
    // field 20457, runtime offset 80, flags 0x133
    internal static __StaticArrayInitTypeSize=12 3783FB69B6B736ADC42ED678E95315363C531091CF9C361E8E08BFBAB5C07A59;
    // field 20458, runtime offset 92, flags 0x133
    internal static __StaticArrayInitTypeSize=104 3B9B3340714D4F3119878245092C26737264D5CF1EF2E0EB3B910BEA058535A9;
    // field 20459, runtime offset 196, flags 0x133
    internal static __StaticArrayInitTypeSize=12 4636993D3E1DA4E9D6B8F87B79E8F7C6D018580D52661950EABC3845C5897A4D;
    // field 20460, runtime offset 208, flags 0x133
    internal static __StaticArrayInitTypeSize=14913 46BAB85021B178E61CE5D5ECF511ADA4BCF6B9FB0034F430BDE65756EDF0EA45;
    // field 20461, runtime offset 15121, flags 0x133
    internal static __StaticArrayInitTypeSize=12 46D972F37F023D7E2910E3CA9877A0FE493C8BA3DF8E7C97F4477BEDA168C429;
    // field 20462, runtime offset 15133, flags 0x133
    internal static __StaticArrayInitTypeSize=28 4839D56F366AA8A594C885BC3944C66317106BB912CDD8EBB2D1FF02F41651BA;
    // field 20463, runtime offset 15161, flags 0x133
    internal static __StaticArrayInitTypeSize=20 5C672853DB7FD2D7617852B1536D11539D8A16BD2E4132B5AD46CAC5EC2FEB64;
    // field 20464, runtime offset 15184, flags 0x133
    internal static long 66840DDA154E8A113C31DD0AD32F7F3A366A80E8136979D8F5A101D3D29D6F72 = "578437695752307201";
    // field 20465, runtime offset 15192, flags 0x133
    internal static __StaticArrayInitTypeSize=20 701C156015EE18DF338A5F9D4DD7C86EADCAEB1773B559CECB4112ACEDA4C3F9;
    // field 20466, runtime offset 15212, flags 0x133
    internal static __StaticArrayInitTypeSize=32 85FBB10F315EBA69D50E48E68EC9836EA4EB2167B7D35FCEE93847FE7AC1B491;
    // field 20467, runtime offset 15244, flags 0x133
    internal static __StaticArrayInitTypeSize=12 8688D249E9D047B4FC2FB89CE05AFE9EC89252FFCCDD969DE6EEF260DD7FFB21;
    // field 20468, runtime offset 15256, flags 0x133
    internal static __StaticArrayInitTypeSize=8938 8765270796AC0A6DDA78C94C94782D3FA1B33F346A9228A06934EFAD850AFD57;
    // field 20469, runtime offset 24194, flags 0x133
    internal static __StaticArrayInitTypeSize=20 8F0A4D3E6C46D5C9C13221C8D48E97537BF2DAF5F55E742C3AB4BA276E52C18E;
    // field 20470, runtime offset 24214, flags 0x133
    internal static __StaticArrayInitTypeSize=20 9A8DCD3F9FF7AA3114E141F03C12989D363EA81FD74C02EEA63C5F41489CB17A;
    // field 20471, runtime offset 24234, flags 0x133
    internal static __StaticArrayInitTypeSize=20 A447D00AC463BEF54D9648861566DC9DA21B6E74A29912133182221C6E612A2B;
    // field 20472, runtime offset 24254, flags 0x133
    internal static __StaticArrayInitTypeSize=20 A9EBBF0D36F820305C13E9400D38517FB5D90AACAEC67ECC7798DF4953A369A5;
    // field 20473, runtime offset 24274, flags 0x133
    internal static __StaticArrayInitTypeSize=20 D495CD984849F3F57B27DF2FE06C60917D69CDCA9A4AD1A75F20488AEA60A0E7;
    // field 20474, runtime offset 24294, flags 0x133
    internal static __StaticArrayInitTypeSize=28 E1A613AA4B331588D97B5FEEF1FAABE8E8138D8C488EE9122B8533BFDDA3C189;
    // field 20475, runtime offset 24322, flags 0x133
    internal static __StaticArrayInitTypeSize=20 F53DB9CE1973ADC3271E026C53B53D45E98204205C82ECB93455456527DA2034;
    // method 34520, 0x60012e1
    uint ComputeStringHash(string s);
}
