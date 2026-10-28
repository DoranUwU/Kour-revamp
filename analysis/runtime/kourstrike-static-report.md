# Original KourStrike bootstrap: static findings

## Correct mode and map identities

The original `NetworkManager` on **MainManager** has a serialized `gameModes` array. Its index **6** points to **Search And Destroy**, whose actual mode ID is **8**. These numbers are different and must not be interchanged. The mode asset permits room map IDs **8, 9, 11**, eight players, four per team, and a 600-second match duration.

The compiled `AlltimeUIManager.SceneNameFromBuildIndex` lookup table at initialized-memory address **4,491,308** gives these exact names. The loader subtracts one from the room map ID before constructing its bundle name:

| Room C1 map ID | Display name | Bundle filename | LoadForceMap argument |
|---:|---|---|---:|
| 8 | Kour2 | `map7` | 7 |
| 9 | OldStorm | `map8` | 8 |
| 11 | Kour3 | `map10` | 10 |

These map names, mode IDs, and loader arithmetic are observed static content. No match was executed in this task.

## Why the existing emergency offline route does not select KourStrike

`UIManager.GoOfflineEmergency(string password)` is **static**. It checks an embedded local diagnostic string, sets `UIManager.wantsToGoOffline=true`, disconnects if still connected, otherwise sets `PhotonNetwork.OfflineMode=true`, then calls **LoadForceMap(2)**. The disconnect callback independently contains the same emergency route and another hardcoded **LoadForceMap(2)** at 23,889,930. Both entry paths must agree on the requested map. The embedded string does not authenticate to any server; no account/service is contacted by this static work.

`UIManager.LoadForceMap(int mapNumber)` is also static. It always obtains **gameModes[0]**, which is FFA, and builds a room-property hashtable:

```text
C1 = mapNumber + 1
C0 = gameModes[0].id
C2 = 600
NetworkManager.instance.CreateCustom("TEMPUNITY", 0, true, properties)
```

`CreateCustom` builds RoomOptions and calls `PhotonNetwork.CreateRoom`. In Photon offline mode, this is the original local-room path rather than an external room request. `NetworkManager.OnJoinedRoom` then reads C0/C1 into the actual mode/map state and calls `StreamingAssetsLoader.LoadLevel`.

Simply setting the lobby mode label to Search And Destroy is insufficient: LoadForceMap overwrites the requested mode with index0 while constructing the room.

## Minimal candidate served-WASM changes

The parent preview can combine these changes with its existing compatibility changes. All retain instruction lengths and argument types:

| Method / function | File instruction offset | Expected bytes | Candidate bytes | Effect |
|---|---:|---|---|---|
| NetworkManager.OnDisconnected / func[75076] | 23,889,930 | `41 02` | `41 07` | Emergency offline callback chooses the same Kour2 map after an initially connected client disconnects |
| UIManager.GoOfflineEmergency / func[76743] | 24,448,525 | `41 02` | `41 07` | Emergency offline entry chooses mapNumber7, giving C1=8 / Kour2 / map7 |
| UIManager.LoadForceMap / func[76698] | 24,435,819 | `41 00` | `41 06` | Room mode is gameModes[6], Search And Destroy / id8 |

Source SHA-256 is `dc4848ad11ac723b2a58f22118055ac9a91c1abbf3e851e415a08e7685f397c2`. The adjacent `kourstrike-static-patch-manifest.json` includes exact function signatures and body boundaries. `node tools/trace-kourstrike-verify.mjs` verifies source identity, expected instructions, exactly three changed immediate bytes, unchanged file length, and complete Node/V8 module validation. **It does not modify the original file, write a patched Wasm file, alter the server, or start the game.**

## Original callable entry points

| GameObject / component | Method | Signature | Boundary |
|---|---|---|---|
| Canvas / UIManager | ForceSetGameMode | instance `void(string)` | Public string method compatible with Unity SendMessage; exact argument is `Search And Destroy`. Updates selected mode and lobby UI but does not create a room or load a map. |
| MainManager / StreamingAssetsLoader | LoadMapByName | instance `void(string)` | Public SendMessage-compatible map downloader; `map7` is a valid filename candidate. It does not establish required Photon room/mode state, so direct use is not a complete playable bootstrap. |
| UIManager | GoOfflineEmergency | static `void(string)` | Existing offline route, but static Unity SendMessage dispatch is not established; use the original UI callback or explicit function-table invocation. |
| UIManager | LoadForceMap | static `void(int)` | Original local-room construction, requiring offline Photon state first. |

The original Wasm exports `__indirect_function_table`. After the engine has initialized these types, exact table slots provide a second possible harness path: **table[27673](1,0)** is static `PhotonNetwork.set_OfflineMode(bool,MethodInfo*)`, and **table[21283](7,0)** is static `UIManager.LoadForceMap(int,MethodInfo*)`. The latter still requires its mode-index candidate change above. Function-table invocation is a direct native harness action, not Unity SendMessage, and has not been runtime-tested in this task. Methods needing an object receiver cannot be called with zero.

## Exact local asset URL construction

`StreamingAssetsLoader.StreamingAssetsPath` calls `Application.streamingAssetsPath` and replaces a `/mobile/` segment with `/`. The supplied framework's `JS_SystemInfo_GetStreamingAssetsURL` reads **Module.streamingAssetsUrl**. Therefore the current reconstructed host's `/StreamingAssets` value is the relevant base; no hardcoded original CDN URL was recovered for these map files.

`MapNameToURL` removes query/fragment from an absolute base by `Uri.GetLeftPart(UriPartial.Path)` where parsing succeeds, then returns:

```text
basePath + "/" + mapName.ToLower() + "?v=" + Application.version
```

With the current local base the required URLs are:

```text
/StreamingAssets/map7?v=<Application.version>
/StreamingAssets/map8?v=<Application.version>
/StreamingAssets/map10?v=<Application.version>
```

No `.bundle` extension is added. These maps are beyond the loader's first-six-map mobile suffix branch, so it does not append `mobile`. The raw PlayerSettings object contains a plausible version string `4.24` at `globalgamemanagers` byte offset1836; this was not fully schema-decoded here. For an exact live cache suffix, the getter is static table[38427](0), returning an Il2CppString pointer (length at+8, UTF-16 data at+12), or capture the loader's requested URL. The native game version is separate from the reconstructed host's productVersion cache metadata.

## Missing dependency boundary

Only the lobby scene **level0** exists in the supplied UnityFS bundle. No local files named map7, map8 or map10 were supplied. The decoded gameplay objects also contain **no MapInfo instance, no SearchAndDestroyManager instance, and no KourBot instance**. Their class definitions and supporting weapon assets exist, but the playable scene and its manager/spawn/site/collision configuration must come from the missing scene bundles.

The downloaded scene must contain the expected MapInfo and team/bomb/spawn configuration. `SearchAndDestroyManager.Start` assumes a Photon room, uses its GameState/ExtraParams/RoundStartTime properties, and calls master-client round-state logic. Force-loading a lobby background or a bare scene without this state cannot honestly count as original KourStrike gameplay.

This task did not contact an original service, fetch map assets, modify the loader/server, or launch a browser. The parent can now prepare a local mode/map resolver and explicit missing-file UI, then test actual bundles if the necessary files become available. Focused decoded bodies and literal annotations are retained in `kourstrike-static-disassembly.json` and its Markdown companion; regenerate with `python tools/trace-kourstrike.py`.
