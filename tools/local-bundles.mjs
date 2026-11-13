import fs from 'node:fs';
// Exact relative bundle names recovered from LoadMyMesh components in game.data.
export const meshBundles=Object.freeze(JSON.parse(fs.readFileSync(new URL('./local-asset-names.json',import.meta.url),'utf8')).names);
export const localBundles=Object.freeze(['map7','map8','map10','settingspanel','classselectpanel','characters/meshes/head/40','characters/meshes/body-attachments/34',...meshBundles]);
