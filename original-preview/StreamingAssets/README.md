# Local KourStrike asset bundles

The supplied startup files did not include gameplay maps. After explicit user authorization, `map7` was acquired once from the public KourStrike static asset endpoint and verified through REA's retained HTTP response body. The running game serves it locally and does not connect to the original services.

Known bundle names (no added extension):

- `map7`: Kour2, included and tested (room map index8).
- `map8`: OldStorm, not acquired (room map index9).
- `map10`: Kour3, not acquired (room map index11).

Included map7: 5,611,470 bytes, SHA-256 `f86a722b8d0936beb3010ad0e9591c439b54c557d4289ab131368cfa3e945828`, Unity6000.0.10f1. It has been loaded successfully with the supplied Unity6000.2.7f2 client; first-person movement, shooting and reload were tested in Search And Destroy. Receipt: analysis/runtime/kourstrike-ui-map7-receipt.json. Additional maps must be compatible with this client; they are not supplied by the local server unless placed here.

The 34 distinct mesh bundles referenced by the supplied LoadMyMesh components are also included, including usps, m4a4, awp, knife and grenades/mesh/*. The original prefabs contain empty mesh references for these models and load them on demand. Files were acquired once as static bytes; the game requests only the local copies. Exact names: tools/local-bundles.mjs. Sources, hashes and Mesh records: analysis/runtime/mesh-acquisition-manifest.json. Run node tools/check-mesh-assets.mjs to verify all 34 files.
