# Game Character Production Pipeline

Status: research note for creating the first commercial-looking `色喰いの王冠`
characters and bosses without wasting Maya/Meshy/API spend.

## Blunt Finding

A production character is not a procedural gameplay marker. It needs readable
identity, authored shape language, deformation-safe topology, materials that
survive the gameplay camera, animation poses that sell intent, and engine
evidence.

Meshy can help create starting geometry. Maya is where the result must be
judged, cleaned, rigged, skinned, and made usable. Do not spend paid generation
credits until the character/prop has a one-page direction sheet and a pass/fail
test from the actual third-person gameplay camera.

## Pipeline

| Stage | Output | Pass Gate |
| --- | --- | --- |
| 1. Role and camera brief | One sentence role, color hook, scale, gameplay crop, color/value target. | Readable as player/enemy/boss/objective in a 256 px crop. |
| 2. Silhouette sheet | 6-12 black silhouettes, front/side/back roughs, weapon/color organ profile. | Head, mantle, sword, `彩槽`, color core, and facing direction readable in black. |
| 3. Color/material key | 2-3 material/value studies. | Player separates from red theatre floor, black seats, gold ornament, and color VFX. |
| 4. Generation or blockout | Meshy preview, Maya blockout, or kitbash blockout. | Shape works untextured from third-person gameplay view. |
| 5. Cleanup/retopo | Animation-ready low/mid poly mesh, named parts, pivot/origin set. | No melted limbs, ambiguous hands, hidden color organ, or tangled mantle. |
| 6. UV/materials | Base color, normal, roughness/metal where useful. | Materials read under Unity lighting, not only in a DCC viewport. |
| 7. Rig/skin | Skeleton, skin weights, sword/color sockets, optional mantle bones. | Run/attack/dodge/parry/drain/skill/hit/death poses keep volume. |
| 8. Animation set | Idle, run, jump, dodge, combo, heavy, parry, drain, red/blue/purple skill, hit, death. | Each pose reads in a still frame before motion blur/VFX. |
| 9. Engine import | Unity prefab, animator, materials, VFX hooks. | Screenshot and contact sheet prove commercial direction. |
| 10. Ledger | Source, license, prompts, task IDs, edits, export formats. | Rebuildable, reviewable, legally traceable asset. |

## Maya's Correct Role

Maya is the production control point:

- clean Meshy/kitbash geometry
- fix scale, forward axis, pivot, naming, hierarchy
- retopologize or simplify problem areas
- split sword, mantle, glass organ, masks, dress blades, and hard-surface parts
- create/adjust skeleton joints
- bind mesh to skeleton and paint skin weights
- pose-test shoulders, mantle, sword, hands, knees, drain, and death collapse
- export FBX/GLB for Unity import

## Meshy/API Role

Meshy is useful only if treated as a draft asset generator plus cleanup input.
Preview spam is waste. Generated assets require prompt/task records, legal
review, IP similarity review, and Maya cleanup before accepted screenshots.

## Readability Rules

For this project, character quality is judged from the gameplay camera first,
not from a beauty render.

Required:

- Lucien's `彩槽` visible from gameplay angles
- current color state visible on arm, eye, sword, and mantle lining
- enemy color core visible before and during drain
- head/shoulder silhouette separated from mantle/body mass
- wet black/gold/red material contrast that survives theatre lighting
- enemy profession readable: actor, dancer, executioner, Duchess
- color drain pose readable in a still frame

Rejected:

- generic dark knight
- details only visible close-up
- hair/mantle/cloth fused into a single soft mass
- Meshy output used directly in-engine without cleanup
- animation that reads only when moving, not in still frames
- design that resembles a known franchise character or weapon

## First Character/Boss Target

Start with a readable set that can pass gameplay distance:

- player role: Lucien, last `彩葬師`
- camera: third-person gameplay distance
- silhouette: clear head/shoulders, one-sided mantle, thin sword, visible left
  arm glass organ
- prop role: color core and color-drain ribbon as the central system read
- materials: black formal cloth, wet dark metal, glass, gold detail, vivid color
  liquid
- animations: idle, run, jump, dodge, attack, heavy, parry, color drain, red
  skill, blue skill, purple skill, hit, death

If this fails, adding more enemies or areas will not fix the game.

## Spend Gate For Meshy

Before any paid/API generation:

- [ ] final role sentence approved
- [ ] 6+ silhouettes reviewed at gameplay crop
- [ ] front/side/back rough or reference sheet exists
- [ ] prompt includes pose, gameplay-readability, color organ, material bands,
      and forbidden details
- [ ] one preview limit per candidate; no refine until preview passes silhouette
- [ ] task IDs and prompts will be logged in asset ledger
- [ ] exported model will be cleaned in Maya before engine import

First allowed API experiment:

```text
Create one Meshy preview only, A-pose, GLB output, low-to-mid poly target,
for Lucien, the last color mortician in a 3D dark fantasy action RPG: slim
androgynous swordfighter, black formal combat clothing, one-sided long mantle,
thin black-silver sword, visible left-arm glass color organ filled with vivid
liquid color, poisonous royal court fantasy, wet black marble and gold detail
material language. Avoid copied franchise costume, famous weapon shape, generic
horned dark knight, plague doctor copy, huge fur cloak, tiny ornaments, hidden
color organ, merged hands, realistic face focus, and gore.
```

Do not refine/texture until the preview silhouette passes against the current
game camera.

## Immediate Next PR

The next implementation PR should create a character/system evidence lane:

1. Add or update the asset ledger with character/prop source/provenance.
2. Add Lucien/color-core/Red-Duchess production brief with silhouette, material,
   animation, and Meshy spend gate.
3. Add a Unity screenshot checklist for imported character, enemy, and
   color-drain evidence.

Only after that should a Meshy/Maya/engine import PR be opened.

## Sources

- Meshy API introduction and endpoint list: https://docs.meshy.ai/en
- Meshy Text to 3D API: https://docs.meshy.ai/en/api/text-to-3d
- Meshy Rigging API: https://docs.meshy.ai/en/api/rigging
- Meshy Animation API: https://docs.meshy.ai/en/api/animation
- Meshy Remesh API: https://docs.meshy.ai/en/api/remesh
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
