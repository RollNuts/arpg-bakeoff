# Game Character Production Pipeline

Status: research note for creating the first commercial-looking cooperative
fantasy action characters and props without wasting Maya/Meshy/API spend.

## Blunt Finding

A production character is not a procedural gameplay marker. It needs readable
identity, authored shape language, deformation-safe topology, materials that
survive the gameplay camera, animation poses that sell intent, and engine
evidence.

Meshy can help create starting geometry. Maya is where the result must be
judged, cleaned, rigged, skinned, and made usable. Do not spend paid generation
credits until the character/prop has a one-page direction sheet and a pass/fail
test from the actual top-down oblique gameplay camera.

## Pipeline

| Stage | Output | Pass Gate |
| --- | --- | --- |
| 1. Role and camera brief | One sentence role, tool, scale, gameplay crop, color/value target. | Readable as pilgrim/tool/enemy/objective in a 256 px crop. |
| 2. Silhouette sheet | 6-12 black silhouettes, front/side/back roughs, tool profile. | Head, shoulders, tool, reliquary, and facing direction readable in black. |
| 3. Color/material key | 2-3 material/value studies. | Players separate from stone floors, fog, fire, and magic light. |
| 4. Generation or blockout | Meshy preview, Maya blockout, or kitbash blockout. | Shape works untextured from top-down oblique gameplay view. |
| 5. Cleanup/retopo | Animation-ready low/mid poly mesh, named parts, pivot/origin set. | No melted limbs, ambiguous hands, hidden tool, or tangled cloth. |
| 6. UV/materials | Base color, normal, roughness/metal where useful. | Materials read under Unreal lighting, not only in a DCC viewport. |
| 7. Rig/skin | Skeleton, skin weights, tool sockets, optional cloth/cape bones. | Run/attack/block/carry/light/chant/hit/death poses keep volume. |
| 8. Animation set | Idle, run, dodge/step, attack, block, carry, light, chant, hit, death. | Each pose reads in a still frame before motion blur/VFX. |
| 9. Engine import | Unreal Skeletal Mesh/Static Mesh, Blueprint, materials. | Screenshot and contact sheet prove commercial direction. |
| 10. Ledger | Source, license, prompts, task IDs, edits, export formats. | Rebuildable, reviewable, legally traceable asset. |

## Maya's Correct Role

Maya is not where we should improvise a finished character from nothing. It is
the production control point:

- clean Meshy/kitbash geometry
- fix scale, forward axis, pivot, naming, hierarchy
- retopologize or simplify problem areas
- split tools, cloak, belt, reliquary panels, and hard-surface parts
- create/adjust skeleton joints
- bind mesh to skeleton and paint skin weights
- pose-test shoulders, cloak, tools, hands, knees, chant, and death collapse
- export FBX/GLB for engine import

## Meshy/API Role

Meshy is useful only if treated as a draft asset generator plus cleanup input.
Preview spam is waste. Generated assets require prompt/task records, legal
review, IP similarity review, and Maya cleanup before accepted screenshots.

## Top-Down Cooperative Readability Rules

For this project, character quality is judged from the gameplay camera first,
not from a beauty render.

Required:

- held tool visible from gameplay angles
- head/shoulder silhouette separated from cloak/body mass
- one bright player value band and one dark anchor band
- warm/cool material contrast that survives temple lighting
- role asymmetry through shield, torch, bell, axe head, bow line, or ritual prop
- pose with clear anticipation, contact/interact, and recovery
- enemy silhouette that differs in size, color, posture, and facing language
- reliquary silhouette that is more important than any player weapon

Rejected:

- white blob player
- generic armored human with no tool identity
- details only visible close-up
- hair/cape/cloth fused into a single soft mass
- Meshy output used directly in-engine without cleanup
- animation that reads only when moving, not in still frames
- design that resembles a known franchise character or weapon

## First Character/Prop Target

Start with a readable cooperative set that can pass gameplay distance:

- player role: shrine pilgrim/explorer with swappable tools
- camera: 3D top-down oblique gameplay distance
- silhouette: clear head/shoulders, practical cloak or torso value mark,
  visible carried tool, readable facing
- prop role: holy reliquary as central objective with durability/runaway state
- materials: weathered metal, dark cloth/leather, pale sacred-light accent,
  restrained brass/stone details
- animations: idle, run, dodge/step, attack, block, carry, light, chant, hit,
  death

This is intentionally narrow. If this fails, adding more enemies or tools will
not fix the game.

## Spend Gate For Meshy

Before any paid/API generation:

- [ ] final role sentence approved
- [ ] 6+ silhouettes reviewed at gameplay crop
- [ ] front/side/back rough or reference sheet exists
- [ ] prompt includes pose, gameplay-readability, tool, material bands, and
      forbidden details
- [ ] one preview limit per candidate; no refine until preview passes silhouette
- [ ] task IDs and prompts will be logged in asset ledger
- [ ] exported model will be cleaned in Maya before engine import

First allowed API experiment:

```text
Create one Meshy preview only, A-pose, GLB output, low-to-mid poly target,
for a cooperative top-down fantasy action game pilgrim: shrine expedition worker
escorting a holy reliquary, readable top-down oblique silhouette, practical
weathered cloth and light armor, visible carried tool socket for sword shield
axe torch bell ritual implement, clear head and shoulder line, dark cloth,
weathered metal, pale sacred-light accent, restrained brass details. Avoid
copied franchise costume, famous weapon shape, generic horned dark knight, huge
fur cloak, tiny ornaments, hidden tool, merged hands, realistic face focus, and
gore.
```

Do not refine/texture until the preview silhouette passes against the current
game camera.

## Immediate Next PR

The next implementation PR should create a character/objective evidence lane:

1. Add or update the asset ledger with character/prop source/provenance.
2. Add a pilgrim/tool/reliquary production brief with silhouette, material,
   animation, and Meshy spend gate.
3. Add an Unreal screenshot checklist for imported character and reliquary
   evidence.

Only after that should a Meshy/Maya/engine import PR be opened.

## Sources

- Meshy API introduction and endpoint list: https://docs.meshy.ai/en
- Meshy Text to 3D API: https://docs.meshy.ai/en/api/text-to-3d
- Meshy Rigging API: https://docs.meshy.ai/en/api/rigging
- Meshy Animation API: https://docs.meshy.ai/en/api/animation
- Meshy Remesh API: https://docs.meshy.ai/en/api/remesh
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
- Unreal Skeletal Mesh assets:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/skeletal-mesh-assets-in-unreal-engine
- Unreal FBX Skeletal Mesh Pipeline:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/fbx-skeletal-mesh-pipeline-in-unreal-engine
- Unreal Animation Retargeting:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/animation-retargeting-in-unreal-engine
