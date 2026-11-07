# MP5, Beretta and AWP appearance verification

I inspected all three final first-person screenshots. **MP5 is charcoal/textured; AWP is olive and charcoal/textured; Beretta has a silver/gray multi-tone finish.** None appears as an undifferentiated missing-texture white model in this run.

| Original native purchase | Price | Observed cash after purchase | Screenshot |
|---|---:|---:|---|
| MP5 | $1,700 | $12,300 | [weapon-colors-mp5.png](weapon-colors-mp5.png) |
| Beretta92fs | $450 | $11,850 | [weapon-colors-beretta.png](weapon-colors-beretta.png) |
| Awp | $4,100 | $7,750 | [weapon-colors-awp.png](weapon-colors-awp.png) |

Starting cash was $14,000. Every observed debit equals the actual original buy-menu item price. Purchases used the metadata/signature-verified original `BuyMenuCanvas.BuyWeapon` handler and real menu-item references; the test did not assign weapons or cash directly. Live player-weapon names were `MP5(Clone)`, `Beretta92fs(Clone)` and `Awp(Clone)`, respectively.

The native MP5 and AWP texture requests were served locally with HTTP200:

- `/content/stream/weapon-skins/texture/mp5.png`
- `/content/stream/weapon-skins/texture/awp.png`

All three corresponding mesh-bundle requests also returned local HTTP200. There were zero captured page errors and zero external requests. Full requests, responses, native purchases, cash values and live material probes are in [weapon-colors-browser.json](weapon-colors-browser.json).

**Beretta does not require an invented PNG.** Its recovered source uses three embedded gray materials. The screenshot is consistent with that original gray/silver design. Its `Weapon.GetWeaponRenderers()` configured cache returned an empty array, so this probe did not independently enumerate its child-renderer material colors; that empty cache must not be interpreted as an absent renderer, since the weapon is visibly rendered. MP5/AWP live materials used the Standard shader and white tint with their loaded texture, which is also normal and does not indicate a missing texture.

The first attempt completed MP5 but stopped on the exact-name mismatch `Beretta` versus the actual prefab name `Beretta92fs`; that record is preserved in [weapon-colors-first-attempt.json](weapon-colors-first-attempt.json). The successful retry corrected the alias and completed all three.

To avoid a second two-minute wait, the successful retry called the original `SearchAndDestroyManager.StartRound` once while its state was Waiting0, using its actual managed name as the reason and zero bonus. This was a controlled test-only native phase advance. Production warmup and application source were unchanged, and no timer/money memory fields were edited by the test.

The owned browser closed successfully and the independent port8087 server was stopped. Driver: [test-kourstrike-weapon-colors.mjs](../../tools/test-kourstrike-weapon-colors.mjs).
