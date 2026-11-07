# Revolver, grenade and C4 appearance verification

Six previously missing original PNGs are now served locally through the exact native texture allowlist. Source files and PNG provenance are documented in EQUIPMENT-COLOR-ASSETS.md and default-weapon-texture-manifest.json. Original game.data/source.wasm inputs were preserved.

A fresh owned Edge browser selected the Terrorist team and entered a native offline round on Kour2. The test invoked the original StartRound handler once after the room/map/team were ready, avoiding another warmup wait in this diagnostic only. Production warmup remains unchanged. The native round assigned the local T actor as C4 holder; the test then equipped the already-owned C4 through original SetWeapon(slot2). No ownership or cash memory writes were used.

All six screenshots were inspected visually:

| Equipped item | Observed appearance | Screenshot |
|---|---|---|
| C4 / Bomb | Olive electronics board, keypad, wiring and screen | equipment-colors-c4.png |
| Revolver | Textured steel cylinder/barrel and darker parts | equipment-colors-revolver.png |
| Smoke | Labeled canister with olive cap | equipment-colors-smoke.png |
| Molotov | Green bottle, label and cloth | equipment-colors-molotov.png |
| HE grenade | Olive body and metal lever/ring | equipment-colors-grenade.png |
| Flashbang | Metal canister with red/dark markings | equipment-colors-flashbang.png |

Original BuyWeapon handlers purchased/equipped the revolver and all four buyable grenade types. Actual current weapon names were checked after each operation. Cash decreased normally:14000 ->12800(Revolver1200) ->12600(Smoke200) ->12150(Molotov450) ->12000(Grenade150) ->11900(Flashbang100). Native C4 assignment/equip had no purchase charge.

All six PNGs and corresponding mesh requests returned local HTTP200. The run recorded zero page errors and zero external requests, and the host response check passed. Full retained actions/material probes are in equipment-colors-browser.json. The owned browser closed; the separate port8088 server was stopped.

This verifies equipped models/textures and native purchases/ownership. Throwing, explosions, planting and defusing were not exercised in this run. Static WorldGrenade/WorldBomb loader traces show that the same local PNG paths cover their world-object texture dependencies; see grenade-bomb-report.md.
