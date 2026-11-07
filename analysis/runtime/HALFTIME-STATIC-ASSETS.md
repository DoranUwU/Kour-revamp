# Halftime: native sides, scores, spawns and round state

This pass reads the supplied native build and the acquired map7 scene. No production code or assets were modified. Instruction evidence is in `halftime-static-disassembly.json`; decoded scene evidence is in `halftime-map-assets.json`.

## Team identities are not all ordered alike

The supplied lobby's PhotonTeamsManager (`level0`, pathID3264) serializes:

| Native team Name | Photon Code | Score property | UI design |
|---|---:|---|---|
| ct | 1 | T2S | Counter-Terrorists, blue |
| t | 2 | T1S | Terrorists, gold |

The score mapping is verified in original `HardpointManager.AddPointsToTeam` func77461: offsets24665033..24665090 select T1S for Name `t`, T2S for Name `ct`. It does not derive the score key directly from the Photon byte Code. TeamSelectDesign's `team1name` is Terrorists, despite the Photon Code1 being CT.

A side swap therefore needs to change actual player team membership through the native team API, not just rename the UI labels. If the intended team identity/players retain their accumulated score when they change side, exchange T1S/T2S at the same boundary. Otherwise native side-keyed scoring will make the old score appear attached to the other player group. Keep Photon actor numbers/ownership stable.

## Round property and native state

`SearchAndDestroyManager.get_CurrentRound` func74519 reads **room CustomProperties["CurrentRound"]** as a boxed ordinary int. It returns0 if the key is absent, and−1 when there is no room. CurrentRound is independent of the two score properties; it is not computed as their sum.

The native state enum is WaitingForPlayers0, BuyPhase1, ActionPhase2, BombPlanted3, RoundEnd4, GameOver5. `SetGameState` func74513 publishes room properties `GameState`, `GameStateChangeReason`, `ExtraParams` and `RoundStartTime`. The original callbacks perform the subsequent native UI/spawn changes. Setting only the manager's local currentGameState field would bypass that contract.

OnStateChanged's score reads initialize absent/null/non-int T1S/T2S values to zero before using them (offsets23691546..23691659). The serialized scene's initial manager fields are state0, currentBombHolder−1 and empty lastWinningTeam. Those are scene defaults, not persisted match results.

## Native halftime remnants need attention

Metadata declares `ALLOW_SWITCH_TEAM=false` and win score15. There is no public halftime/swap method in SearchAndDestroyManager's recovered metadata. The original OnStateChanged body still emits half-related warnings:

- CurrentRound13: `Second Half starts in 2 Rounds.`
- CurrentRound14: `Last Round of First Half`.

The warning switch is visible at23691666..23691671 (`CurrentRound−13`, br_table). The literal `JUST SWITCHED TEAMS, FLIP SCORES` appears only in this method's literal-initialization preamble; it is not a later reachable literal load in the decoded body. No native JoinTeam/SwitchTeam call appears in OnStateChanged. **The strings do not establish a working native swap.** They are consistent with disabled/compiled-out swap code leaving warnings behind.

There is, however, a concrete surviving special case in `StartRound` func74516: at23703299..23703304 it compares CurrentRound with14 and selects **ct** rather than **t** for the team whose random member will receive the planter/bomb actor assignment. This branch must be reconciled with a new 12-round halftime. Leaving it untouched can select a CT actor for C4 at the old boundary even after the new swap feature has run.

The user's requested boundary is after completing round12, before playing round13. A temporary round setter should exercise that same native transition and avoid applying the swap/score exchange repeatedly for an unchanged half. The old round13/14 warning text should also be suppressed or updated to avoid contradicting the new boundary.

## Spawn and C4 ownership assumptions

MapInfo (`BuildPlayer-map7`, pathID4086) serializes exactly eight spawn transforms, in this order:

| Array indices | Names | Native side |
|---|---|---|
| 0–3 | t0, t1, t2, t3 | t |
| 4–7 | ct0, ct1, ct2, ct3 | ct |

Original `GetSpawnPoint` func74527 selects base index0 for Name `t`, otherwise4 (23707647..23707654), adds the actor's slot, and reads `MapInfo.spawnPoints` at runtime field offset252 (23707724..23707743). Representative serialized local positions are t0≈(29.28,6.63,−44.02), ct0≈(80.14,−2.10,116.20).

Changing native player membership before calling the ordinary round respawn lets that existing logic select the other side's spawn. There is no need to rewrite map spawn positions. `TeleportMyPlayerToSpawnPoint` also has a justSwitchedTeams path and calls native GetPhotonTeam/JoinTeam, player teleport/spawn and NewKourStrikeRoundStarted; its call/field sequence needs to be respected rather than merely moving the camera.

StartRound selects a random player from the relevant side to carry C4, then passes the actor id in the BuyPhase ExtraParams. Bomb explosion resolves the winning side as `t`; defuse resolves it as `ct`. Preserve these side-specific rules, clear/reassign the old bomb through the native new-round lifecycle, and do not treat a stale currentBombHolder actor as a new side owner after swapping teams.

## UI placeholders are not rule constants

The map's currentRoundTxt (pathID3542) serializes **"Round 30"** as an editor placeholder. Its timer text is00:00, money text$999, and notification placeholder says the bomb has been planted. They are replaced at runtime and do not prove a 30-round limit, round30 start, $999 start cash or active bomb.

The independent static recommendation is to keep all team/score/round values native and use one clearly defined boundary operation. A temporary test setter should be restricted to the local offline profile and report the actual CurrentRound, native team and side-score values after applying it. Runtime tests must verify both directions, once-only behavior, retained score ownership, fresh spawn/default weapon/C4 state, and continued native round progression.
