# KourStrike local room exists, but map download has not started

This addendum uses original static method bodies. The parent separately reported live state: actual table names match the expected functions, OfflineMode/InRoom/IsConnected/IsReady/IsMasterClient all return1, CurrentRoom is nonzero, and IsMessageQueueRunning returns0. Those observations establish an offline room, not that the map scene loaded.

## Verified API signatures and table identities

| Table slot | Function | Signature |
|---:|---|---|
| 27673 | PhotonNetwork.set_OfflineMode /24949 | `(i32 bool,i32 MethodInfo*) -> void` |
| 21283 | UIManager.LoadForceMap /76698 | `(i32 mapNumber,i32 MethodInfo*) -> void` |
| 27683 | PhotonNetwork.set_IsMessageQueueRunning /24959 | `(i32 bool,i32 MethodInfo*) -> void` |
| 27672 | PhotonNetwork.get_OfflineMode /24948 | `(i32 MethodInfo*) -> i32` |
| 27689 | PhotonNetwork.get_InRoom /24964 | `(i32 MethodInfo*) -> i32` |
| 27666 | PhotonNetwork.get_CurrentRoom /24867 | `(i32 MethodInfo*) -> i32 Room*` |
| 27682 | PhotonNetwork.get_IsMessageQueueRunning /24958 | `(i32 MethodInfo*) -> i32` |
| 12356 | AsyncOperation.get_isDone /83905 | `(i32 AsyncOperation*,i32 MethodInfo*) -> i32` |
| 40485 | AsyncOperation.get_progress /83907 | `(i32 AsyncOperation*,i32 MethodInfo*) -> f32` |
| 19871 | NetworkManager.GetRoomMapBuildIndex /75032 | `(i32 NetworkManager*,i32 MethodInfo*) -> i32` |

All indices are from the module's actual active element segment. Slots27673/21283 are not off-by-one guesses. A read-only initialized-runtime snapshot helper is retained in `kourstrike-static-more-snapshot.mjs`. It only calls getters and reads known fields, never setters or scene entry APIs.

## Exact offline room creation sequence

`PhotonNetwork.set_OfflineMode` can reject entry if the client reports connected, and emits an error on that path. It returns early if the requested flag already equals the current flag. Successful enable stores `offlineMode=true`, changes local ID, and synchronously invokes `ConnectionCallbacksContainer.OnConnectedToMaster` at byte9,310,244.

`NetworkManager.CreateCustom` builds RoomOptions, then calls `PhotonNetwork.CreateRoom` at byte23,871,275. The offline branch of CreateRoom checks whether offlineModeRoom is already nonnull: if so, it logs an error and returnsfalse at9,329,046. Otherwise it calls `EnterOfflineRoom` at9,329,078 and returnstrue. `EnterOfflineRoom` constructs the room, assigns it to offlineModeRoom, changes local ID to1, assigns client.CurrentRoom, then invokes OnCreatedRoom and **MatchMakingCallbacksContainer.OnJoinedRoom** at9,327,629.

The latter first calls `LoadBalancingClient.UpdateCallbackTargets` at9,153,140, then invokes the registered matchmaking callback targets. Thus an existing offline room and no map request can occur if a callback failed, was absent, or chose a scene path that bypassed map preparation. Calling CreateRoom again while the room exists does not rerun OnJoinedRoom; it takes the already-in-room failure path.

## NetworkManager.OnJoinedRoom has a preloaded-map bypass

After early host callback/account/party handling, it reads the room mode and C1 map property. It then tests **NetworkManager.preloadedMap**:

```text
if String.IsNullOrWhiteSpace(preloadedMap):
    StreamingAssetsLoader.instance.LoadLevel(roomMapId, usePhoton=true)
else:
    StreamingAssetsLoader.instance.NowLoadLevel(preloadedMap, usePhoton=true)
```

The test occurs at23,883,014; LoadLevel at23,883,040; bypass NowLoadLevel at23,883,167. A stale or invalid preloadedMap can therefore request a scene without issuing an HTTP bundle download. This is a concrete branch to inspect, not an established cause before its live string value is read.

There is also an early `Application.ExternalCall("onJoinedRoom",...)` at23,882,111, before the map-loading code. The reconstructed host did not define that callback when inspected. Whether it throws or is ignored in this engine path is unverified here; a missing callback must not be declared the proven cause merely from its absence.

## Why the Photon queue can be0

`PhotonNetwork.LoadLevel`, func24901, sets **loadingLevelAndPausedNetwork=true** at9,294,523 and **isMessageQueueRunning=false** at9,294,531, before calling `SceneManager.LoadSceneAsync` at9,294,563. It stores the returned AsyncOperation at static-field offset160. Queue0 is therefore consistent with a scene-loading attempt, but another setter/call path could also clear it.

Read the PhotonNetwork static fields after initialization: class pointer from memory slot6,908,632; static-field pointer atclass+92; `loadingLevelAndPausedNetwork` atstatic+137; AsyncOperation pointer atstatic+160; progress float atstatic+164. If an operation exists, the getters in the table above distinguish progress from a failed/nonstarted scene load.

The native setter **table[27683](1,0)** only sets `isMessageQueueRunning=true`; it does not download missing scene data or repair an invalid scene name. It should be used as part of a deliberate corrected load sequence after map initialization, not as evidence that a match loaded.

## Exact map downloader input and scene dispatch

**`SendMessage("MainManager","LoadMapByName","map7")`** is the original public single-string entry. Its argument is the asset-bundle basename **map7**, not display nameKour2, and not the room C1 ID8.

The generated `<IenuLoadMapByName>d__24.MoveNext`:

1. Calls UnloadAll through table12376 at24,389,730.
2. Calls MapNameToURL through table12365 at24,389,789 and downloads via UnityWebRequestAssetBundle.GetAssetBundle.
3. Reads the downloaded AssetBundle's **GetAllScenePaths** through table12368 at24,391,458.
4. Selects the first scene path and calls **Path.GetFileNameWithoutExtension** through table12369 at24,391,575.
5. Calls **NowLoadLevel(actualSceneName,usePhoton=false)** through table12377 at24,391,628. The two final zero arguments are usePhoton and MethodInfo, so this path selects the ordinary SceneManager.LoadSceneAsync branch, not PhotonNetwork.LoadLevel.

This is a targeted way for the parent to exercise the original scene-bundle loader once an offline room with mode8/C1:8 exists. It does not itself create room state and it does not register the MapInfo.OnGameSceneLoad callback that is registered by LoadLevel/PrepareMapString; the correct final spawning/setup sequence must be checked after the map activates. If that subscription is missing, using the instance **LoadLevel(8,true)** after preparing the bundle, or explicitly following the original MapInfo callback flow, may be necessary. This last choice requires runtime evidence rather than another unverified blanket patch.

## Coverage

### Concrete missing request helper discovered after the room-state checks

The inspected reconstructed host loader does not define `Module.fetchWithProgress` or `Module.cachedFetch`. The actual supplied framework's `_JS_WebRequest_Send` sets `fetchImpl=Module.fetchWithProgress`, optionally replaces it with `Module.cachedFetch` only when that helper exists, and invokes it. Thus a map request reaches an undefined function before any browser fetch. The framework catches this synchronous error and reports a native UnityWebRequest error, so a missing HTTP request and absence of page errors are both consistent with the actual code path.

`kourstrike-static-more-webrequest-check.mjs` extracts and executes this exact unchanged function with synthetic request/native-callback memory, without browser or network activity. It verifies that a missing helper produces native HTTP status500, web error code2, and error **`fetchImpl is not a function`**, with no fetch. The same actual framework function accepts a helper that returns a Response carrying `parsedBody:Uint8Array`; when `init.enableStreamingDownload` is true, actual bundle bytes must also reach `init.onProgress` as a chunk with lengthComputable=true. A nonstreaming-only response body is insufficient for its streaming completion branch, which sends only the final length and no byte buffer.

The parent can supply this missing genuine local fetch integration while preserving its offline-policy wrapper; no service emulation or new gameplay patch is needed for this defect. The synthetic check verifies the framework contract, not a rendered map or live match.

`kourstrike-static-more-photon.json` retains exact decoded Photon getters/setter/CreateRoom/EnterOfflineRoom plus the original room callback and loader entry. `kourstrike-static-more-loader.json` retains the scene-load and callback-dispatch bodies. This subtask did not modify browser state, loader, server or original input files.
