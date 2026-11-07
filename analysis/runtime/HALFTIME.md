# Twelve-round halftime and temporary round controls

## Missing-score freeze correction

Native rooms can omit a side's score property until that side earns a point. The original local halftime implementation incorrectly required both boxed score values whenever either existed, throwing Incomplete team scores on a shutout. It now creates a native boxed zero for an absent score, prepares the exchanged score properties before switching memberships, and publishes both sides together. Missing scores are valid zero scores.

The browser regression mode `node tools/test-kourstrike-halftime.mjs --sparse-scores` passed with T1S missing, T2S missing, and both absent. It records actual missing-property presence before halftime, completes the native12→13 transition, checks both resulting stored scores, and verifies continued rounds14/15, repeat jumps, rewinds, spawns and C4. All three scenarios recorded zero page errors/external requests. Evidence is retained separately in halftime-sparse-browser.json.

The local KourStrike match swaps sides once after twelve completed rounds, before round13 selects a C4 holder or starts its buy phase. Terrorists become Counter-Terrorists and vice versa. Scores follow the same players: for example T7/CT5 becomes T5/CT7 after the rosters switch. Native spawning, team icons and C4 ownership use the new side. The original victory target remains15; this change introduces the requested halftime boundary rather than a new complete match format.

## Use the temporary controls

Restart the preview server, reload, load KourStrike, start the offline match and select a team. Open **Debug: rounds (temporary)** below the game on the right.

1. Enter12 and press **Start round**. This begins round12 with the normal buy phase, retaining the current scores.
2. Once the buy phase finishes, press **End current round**. This invokes the original timeout/end-round flow. When round13 begins, sides switch automatically.
3. Enter13 directly to test halftime immediately. Repeating13 or entering14 does not switch again. Entering12 restores the first-half side; returning to13 switches to the second-half side again.

The round input accepts1–99 and starts a new native round. End current round is available during the action phase. These controls are restricted to the local offline room. To remove the debug option, remove round-debug.js and its script tag and #round-debug panel from index.html; remove their static routes if desired. The loader installs it optionally. Normal halftime behavior remains in kourstrike-rules.js and the native round-start hook.

## Implementation

- tools/original-wasm.mjs retains the existing compatibility/cash patches, moves first-half warnings to rounds11/12 and disables the obsolete round15 CT bomb-holder exception.
- tools/wasm-round-hook.mjs adds a five-byte call at the entry of the existing StartRound function and rebuilds its body/code section lengths. Function/import/table indices, data and unrelated functions remain unchanged.
- The existing JS_Eval_EvalJS import recognizes the dedicated -1 marker before decoding a string. Ordinary eval calls preserve their existing behavior. Module.onKourStrikeRoundStart dispatches to the local rules synchronously.
- kourstrike-rules.js snapshots all team memberships before exchanging them through native SwitchTeam, rebuilds the native roster cache and refreshes the active buy-menu team icon, then replaces the local player through native Photon destruction and native round-start spawning. A cloned native room Hashtable exchanges T1S/T2S scores. Per-room half state prevents duplicate swaps, including repeated debug jumps. Failed membership transactions attempt native rollback.
- round-debug.js contains the removable UI and native round-counter boxing/state transitions. It sets CurrentRound to the requested round minus one before invoking StartRound, which performs the normal increment.

Native Hashtable.get_Item is used for string-key lookup and returnsnull for missing keys. The similarly named table26335 ContainsKey overload takes a **byte** key and is not suitable for managed string keys. Native TeleportTo applies position on the next player update, so runtime checks wait for that frame rather than reading immediately after the room property changes.

## Verification

tools/check-round-hook.mjs compares every function body and non-code section, validates unchanged imports, and exercises the actual framework marker dispatch and ordinary eval behavior. Core KourStrike, compatibility, asset and syntax checks pass.

The browser test tools/test-kourstrike-halftime.mjs passed these native scenarios:

- T stays T in round12; the ordinary end-round flow advances to13, changes the local player to CT, preserves roster scores, refreshes its team icon and places it at the CT spawn.
- A seeded7/4 score becomes7/5 after the CT round win, then5/7 after the side exchange; the same player retains7 points.
- Repeating13 and moving to14 cause no extra swap; rewinding12 and forwarding13 correctly restore/change parity and score ownership.
- A fresh CT start can jump directly to13 and become T, spawn at the T location and receive C4. Round15 preserves the same T role and C4 ownership.

The test recorded zero page errors and zero external requests. It uses the temporary round controls to avoid playing twelve full rounds; the actual12→13 transition then uses the original native end/start-round flow. Offline single-player testing does not establish networked multiplayer behavior. Evidence: halftime-browser.json and selected halftime screenshots. The owned browser and separate test server were closed after testing.


## Camera lifecycle correction

Halftime no longer calls TeamMember.OnDisable/OnEnable manually on a retained actor. It rebuilds the roster cache and removes the old local player using PhotonNetwork.Destroy, followed by Unity Object.DestroyImmediate to complete destruction before the synchronous StartRound continues. Native TryGetMyPlayer confirms the old actor is absent; original round-start code then creates fresh player, controller, input and camera components. No raw camera rotation or input memory is overwritten.

The sparse-score browser regression passes normal round 12 to 13, debug jumps and rewinds, both sides, missing score keys, team spawn locations and C4 ownership, with no page errors or external requests. Camera tests separately check fresh player/camera identities, stable idle yaw, deliberate mouse rotation and walking after the action phase starts. Their evidence is camera-halftime-browser.json and camera-halftime-debug-browser.json.

The continuous spinning reported by the user was not reproduced in the clean headless baseline. This change removes retained camera state as a possible cause; these tests do not prove the original hardware/browser symptom is resolved.
