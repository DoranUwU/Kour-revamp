# KourStrike asset/bootstrap evidence

This is a bounded offline inspection of the supplied build. No external services were contacted and no game code was run.

## Confirmed bootstrap configuration

- `SdkManager`: `level0`, pathID 3235, complete object decode; `gameType=0`. Enum values: Kour=0, KourStrike=1, KourZone=2.
- The serialized `gameType` occupies object-relative bytes 40..44, absolute byte offset 458856 in the extracted `level0` file. This identifies the default only; host/bootstrap code may override it.
- `NetworkManager`: `level0`, pathID 2449, configured with 11 GameMode references.
- `Search And Destroy`: `sharedassets0.assets`, pathID 7893; id8, `kourstrikeChanceWeight=1`, `excludeFromPubsKourstrike=false`, forced maps [8,9,11], 8 players, team size4, 600-second match.

## Map availability boundary

- BuildSettings (`globalgamemanagers`, class141, pathID11) has exactly 1 registered built scene: `Assets/Lobby.unity`. This is direct serialized scene-table evidence, stronger than interpreting filenames.
- The UnityFS directory contains only globalgamemanagers, globalgamemanagers.assets, sharedassets0.assets, level0, resources.assets and Resources/unity_builtin_extra. No map8/map9/map11 node is present.
- ResourceManager (`globalgamemanagers`, class147, pathID13) exposes 75 resource names. Its complete resource-name table is in `kourstrike-resources.json`. There are no map/scene/bundle/catalogue resource entries.
- The four TextAssets are PerformanceTestRunInfo, PerformanceTestRunSettings and two line-breaking character tables. None is a map/configuration catalogue.
- The two `.resource` files are fully accounted for by original AudioClip payloads plus zero-filled alignment gaps: 9 clips +85 padding bytes in resources.resource; 105 clips +879 padding bytes in sharedassets0.resource. No non-audio remainder is available as a hidden map payload there.
- No MapInfo, MapBuilder, MapBuilderData or CustomMapLoader MonoBehaviour instances were found in the decoded gameplay object inventory. MapConfig/MapData/MapSettings are metadata types, not recovered map instances.
- KourStrike dead-camera/UI prefabs and sounds exist, but they do not supply a map scene.

## What is missing

The map AssetBundle selected for index8,9 or11, including any dependent bundles, is required to enter that original scene. A configuration/catalogue is needed only if the matching loading code references it. Exact filenames must come from the WASM loading branch; this asset pass does not invent map names or URLs. A loader that starts the Lobby successfully does not establish that a playable map is present.

Evidence files: `kourstrike-bootstrap.json`, `kourstrike-resources.json`, `kourstrike-map-evidence.json`, `kourstrike-required-files.json`. Reproduce with `python tools/inspect-kourstrike-assets.py`.
