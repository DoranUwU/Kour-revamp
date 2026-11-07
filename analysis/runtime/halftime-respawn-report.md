# Clean local-player lifecycle for halftime testing

NetworkManager.Respawn table19923/function74901 `(manager,0)->void` does not destroy the current player. It builds class/equipment information, checks the existing player/connection, calls SpawnPlayer and UnloadAllAssetBundles. It is unsuitable as a narrow retained-camera replacement.

Use PhotonNetwork.Destroy GameObject overload table27756/function25040 `(ownedGameObject,0)->void` for normal Photon teardown. RemoveInstantiatedGO25036 deactivates the object, unregisters/cleans network views and invokes its configured pool Destroy. DefaultPool.Destroy27966/function24790 calls UnityEngine.Object.Destroy, so native object destruction completes at end-of-frame. Extra GameObject.SetActive(false) is redundant.

NetworkManager.TryGetMyPlayer19879/function74902 `(manager,outGameObjectPointer,0)->bool` copies manager.myPlayer at+32 and evaluates Unity Object!=null; it does not check activeSelf. Therefore destruction plus immediate same-stack StartRound does not establish that the original absent-player spawn branch will run. Test by destroying during RoundEnd before the next round, await native destruction and TryGetMyPlayer=false, then allow original StartRound. Do not raw-clear manager.myPlayer or reuse Respawn's unrelated asset unload behavior.

Scores and side membership live in Photon room/player properties and are separate from the destroyed GameObject, so normal property-driven halftime reconciliation can remain. Rebuild PhotonTeamsManager caches before native holder selection. Reacquire all live shooter/controller/input pointers after spawn.

C4 needs explicit runtime verification: BuyPhase.OnStateChanged sets currentBombHolder, then attempts SetBomb on the existing local player, then teleports or spawns. With no existing player, that earlier SetBomb branch is skipped. Source calls to Shooter.SetBomb are in OnStateChanged, OnEvent and the planting coroutine; Shooter.NewKourStrikeRoundStarted does not call it. If fresh-spawn C4 is absent, after the new player exists invoke original SetBomb20676(shooter, nativeCurrentBombHolder==localActor, false, 0), with T/holder checks, instead of raw inventory edits. This is a conditional test recovery, not a proven necessary production change.

Native Respawn/TryGetMyPlayer/Photon Destroy bodies are saved in halftime-respawn-static.json. No production edits were made.
