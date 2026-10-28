# Reproduce the investigation

Run from the workspace root with Node.js24 and Python3. Static extraction uses the Python standard library; UnityPy, Pillow, WABT and a Unity editor are not required.

## Existing results

```powershell
npm.cmd run verify:recovery
npm.cmd run inspect
```

Open http://localhost:8081/explorer/. The earlier original prototype uses a separate npm.cmd start command and is not the recovered client.

## Extraction dependency order

1. `node tools/extract-data.mjs`: decompress game.data.br and extract eight archive members; inputs preserved.
2. `python tools/inspect-wasm.py`: section/interface/function/element/data inventories and initialized memory; no execution.
3. `python tools/inspect-wasm-methods.py`: join metadata tokens to compiled locations and decode selected methods.
   Then run `python tools/inspect-wasm-defaults.py` to discover matching metadata registration, type/field layouts and constructor constants.
4. `node tools/recover-metadata.mjs`: join retained REA metadata with matching type/field-offset tables; emit signatures, attributes and declarations.
5. `python tools/inspect-assets.py`: UnityFS/LZ4 extraction, object inventory and supported texture/audio/geometry export.
6. `python tools/inspect-assets-behaviours.py`: decode behaviors from matching schemas, retaining exact byte ranges and incomplete coverage.
7. `python tools/inspect-assets-summary.py`: indexed weapon/class/mode tables and compact configuration.
8. `node tools/summarize-build.mjs`: source identities, gameplay structure, RPC declarations, URL candidates and embedded-script candidates.
9. `node tools/build-explorer.mjs`: refresh searchable catalog.
10. `npm.cmd run verify:recovery`: export-byte and structural validation, plus WASM/metadata agreement.

The matching initial REA evidence is retained in analysis/rea-evidence-initial.json. To recreate that record, call REA inspect_il2cpp_metadata on analysis/global-metadata.dat, then export_evidence_bundle. Shell parser output is labeled separately from REA Evidence.

## JavaScript formatting

`node tools/inspect-framework.mjs <absolute-path-to-existing-@babel/parser>` parses target text inertly and writes indexed functions/calls/literals. Readable printing uses the existing TypeScript installation at C:/Users/Admin/AppData/Roaming/npm/node_modules/typescript. These paths are environment-specific; generated output is already retained. This pass does not evaluate the target.

## Original runtime diagnostic

`npm.cmd run preview:original` starts the separate diagnostic loader at http://localhost:8082/. It intentionally executes the original client with external resources blocked and three compatibility changes in served framework bytes. See [runtime/REPORT.md](runtime/REPORT.md) for the actual startup outcome, exact changes, screenshots and limitations. It is not a recovered server or verified full match.
