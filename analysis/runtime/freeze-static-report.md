# Static investigation of the post-host-check freeze

## Verified: the local CheckHost patch preserves Wasm semantics

`tools/original-wasm.mjs` changes exactly four bytes at file offsets 23,683,617–23,683,620. The original instruction is `call func[72207]`, whose checked signature is `(i32) -> ()`. Its one argument, `i32.const 0`, is emitted at 23,683,615.

The replacement is `drop; nop; nop; nop`. It consumes the same one argument and produces no result, retaining the exact instruction/body size and branch structure. Full Node/V8 Wasm validation passes. The branch end remains at 23,683,621; the function epilogue restores the stack pointer at 23,683,627 and ends at 23,683,629. There is no back edge after the removed quit call. See `freeze-static-patch-check.json`; rerun its adjacent `.mjs` for these checks.

`SdkManager.Start`, func[74473], has no loops and calls `SdkManager.CheckHost` at instruction offset **23,683,070**, immediately before its normal end. `SdkManager.Awake`, func[74472], also has no loops. Thus an explanation that the byte replacement itself introduces an infinite loop is unsupported by the decoded instructions.

`CheckHost` has a loop at **23,683,419** over the configured host array. The index increments at 23,683,486 and is compared with the array length at 23,683,494. It is a bounded whitelist search, not a `while(true)` spin. Its failure branch still makes four `Application.OpenURL` calls at **23,683,569 / 23,683,583 / 23,683,597 / 23,683,611**, each resolving to `https://kour.io`, before the removed quit call. Those remain observable side effects; this static inspection does not establish that they cause the reported freeze.

## Concrete blocking-network candidate after a disconnect

`NetworkManager.OnDisconnected`, func[75076], invokes `IsInternetAvailable` at **23,891,135**. The latter is func[75077] and constructs a `System.Net.WebClient`, then calls its synchronous `OpenRead` API with **`https://google.com`**:

1. At 23,891,725, imported `env.invoke_vii` receives table slot 12234, which resolves to func[13226], `WebClient..ctor`.
2. At **23,891,804**, imported `env.invoke_iiii` receives table slot 12235, resolving to func[13233], `WebClient.OpenRead(string)`.
3. Metadata-usage address 7,049,432 holds encoded literal `0xa0006023`, which resolves to the exact URL above.
4. Func[13233] calls func[13234] `GetUri` at 5,549,606, then func[13235] `OpenRead(Uri)` at **5,549,611**. The URI overload is a 2,106-byte compiled body containing WebRequest/response virtual dispatch and exception handling.

This is a meaningful runtime-debugger candidate because it is a synchronous network operation called on a callback path. However, **no runtime execution of that call has been demonstrated by this static work**. Whether it throws immediately, blocks in a platform implementation, or is never reached must be decided from the parent's captured CPU/debugger stack and logs.

The two loops inside `IsInternetAvailable` at 23,891,887 and 23,892,239 iterate IL2CPP interface metadata with incremented indices and finite interface counts. They are not network-polling spin loops themselves. `NetworkManager.OneTimeAwake`, func[75043], has one bounded initialization array loop at 23,867,089; `NewConnectUsingSettings`, `Start`, `OnDisconnected`, `Reconnect`, and `ConnectAgain` have no direct loops.

## Remaining quit call sites

The saved direct-call inventory has other `Application.Quit` callers: `CullArea.CreateCellHierarchy` at 23,510,199, `OnEscapeQuit.Update` at 23,554,997, `ButtonCallStaticFunction.Logout` at 23,743,768, and `PolygonBeamScript.Update` at 24,580,577. Their reachability in the current scene is unknown here; the one-call local-preview change does not remove them.

## Coverage and artifacts

All work was offline static inspection. No browser was launched and no loader/server files were modified. `freeze-static-startup.json` retains decoded bodies for the focused SDK/network/startup methods. `freeze-static-webclient.json` and `freeze-static-webclient-uri.json` retain the synchronous read overloads. This report excludes unobserved explanations such as a shader compilation stall, an active fatal engine error, or a proven deadlock; those require the separately captured runtime evidence.
