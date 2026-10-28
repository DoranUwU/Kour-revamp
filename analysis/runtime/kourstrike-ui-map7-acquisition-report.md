# Public static map7 acquisition

## Saved artifact

`original-preview/StreamingAssets/map7` was acquired through the native REA browser scenario's declared same-origin **GET request** and its explicitly selected retained HTTP response body. No browser download was enabled or resumed; REA's download cancellation behavior was not changed. No shell HTTP request was used to retrieve it.

| Property | Observed value |
|---|---|
| Public source | `https://kourstrike.io/StreamingAssets/map7?v=4.24` |
| HTTP status | 200 |
| Bytes | 5,611,470 |
| SHA-256 | `f86a722b8d0936beb3010ad0e9591c439b54c557d4289ab131368cfa3e945828` |
| Header | `UnityFS`, format8 |
| Unity version | `6000.0.10f1` |
| Header-declared bundle length | 5,611,470 |
| REA Evidence | `ev_eba811e12d3e015b4280236acf9424243cb4f31d128acbb3ca19d1de7a54d25b` |
| Native browser cleanup | `terminated-owned-process` |

The exact captured base64 bytes were decoded locally and verified against the retained byte count and SHA-256 before saving. The original supplied WASM/data/framework files were not replaced. Acquisition receipt: [kourstrike-ui-map7-receipt.json](kourstrike-ui-map7-receipt.json).

## URL discovery and bounded browser actions

The authorized initial native REA inspection opened the public launcher without clicking game controls, signing in or joining a match. It hit its ten-second provider deadline during page navigation but returned useful partial response bodies and confirmed termination of the owned browser. The preserved public HTML explicitly sets `streamingAssetsUrl: "StreamingAssets"`; the supplied compiled client's previously recovered `/map7` loader branch establishes the map path. The public launcher HTML and mapManager script are saved as `kourstrike-ui-public-launcher.html` and `kourstrike-ui-public-mapManager.js`.

That initial public page automatically requested its launcher scripts, Unity build resources and third-party analytics/advertising resources. It was separate from the isolated local game harness. Subsequent static-map verification/acquisition used only a lightweight same-origin `mapManager.js` text document, so no public Unity game startup was needed.

Native HEAD request evidence `ev_122bcb738698c568061c856bf7ccd9d72e14b8d39e8734af6a34c21ed74e7805` verified `/StreamingAssets/map7` status200, `application/octet-stream`, Content-Length5,611,470 and Last-Modified2024-10-04. Native GET used the supplied client's optional version query `v=4.24`; that query is not proof the remote bundle matches client4.24.

## Capture budget and export recovery

The first GET completed, but REA reported the selected32MiB response-body allocation budget was insufficient (observed conservative estimate59,855,682). A single corrected GET used the reported requirement with a96MiB body/event allocation budget. Its body was retained completely, but inline MCP delivery exceeded the server's10MiB response budget. The operation was not repeated: the official `export_evidence_bundle` tool saved retained Evidence to [kourstrike-ui-map7-acquisition-bundle.json](kourstrike-ui-map7-acquisition-bundle.json), and [kourstrike-ui-extract-map7.mjs](kourstrike-ui-extract-map7.mjs) extracted only the exact successful static-map response.

REA identifies the retained body representation as `playwright-response-body-bytes`. Its stated limitation applies: Playwright's Response.body API can perform a follow-up load when CDP lacks the original body; the record does not establish original wire-transaction byte provenance. Byte count/hash verification establishes the saved file matches the retained browser-exposed bytes.

## Compatibility remains to be tested

The public launcher reports productVersion4.15, whereas the supplied client is4.24. The acquired bundle's Unity header is6000.0.10f1, compared with the supplied client6000.2.7f2. These differences do not by themselves establish incompatibility or compatibility. Structural asset inspection and local runtime loading must determine whether it can supply the required KourStrike scene. This receipt alone makes no playable-match claim.
