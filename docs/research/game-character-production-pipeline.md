# Game Character Production Pipeline

Status: research note for creating the first commercial-looking solo ARPG
character without wasting Maya/Meshy/API spend.

## Blunt Finding

A production character is not a procedural gameplay marker. It needs readable
identity, authored shape language, deformation-safe topology, materials that
survive the gameplay camera, animation poses that sell intent, and engine
evidence.

Meshy can help create starting geometry. Maya is where the result must be
judged, cleaned, rigged, skinned, and made usable. Do not spend paid generation
credits until the character has a one-page direction sheet and a pass/fail test
from the actual third-person gameplay camera.

## Pipeline

| Stage | Output | Pass Gate |
| --- | --- | --- |
| 1. Role and camera brief | One sentence role, weapon, scale, rear-camera crop, color/value target. | Readable as hero/enemy in a 256 px tall gameplay crop. |
| 2. Silhouette sheet | 6-12 black silhouettes, front/side/back roughs, weapon profile. | Head, shoulders, weapon, and facing direction readable in black. |
| 3. Color/material key | 2-3 material/value studies. | Hero separates from stone floors, fog, and torch/magic light. |
| 4. Generation or blockout | Meshy preview, Maya blockout, or kitbash blockout. | Shape works untextured from rear three-quarter gameplay view. |
| 5. Cleanup/retopo | Animation-ready low/mid poly mesh, named parts, pivot/origin set. | No melted limbs, ambiguous hands, hidden weapon, or tangled cloth. |
| 6. UV/materials | Base color, normal, roughness/metal where useful. | Materials read under Unreal lighting, not only in a DCC viewport. |
| 7. Rig/skin | Skeleton, skin weights, weapon sockets, optional cloth/cape bones. | Idle/run/attack/dodge/guard/hit/death poses keep volume. |
| 8. Animation set | Idle, run, dodge, light attack, heavy attack, guard, hit, heal, death. | Each pose reads in a still frame before motion blur/VFX. |
| 9. Engine import | Unreal Skeletal Mesh, Blueprint, Animation Blueprint, materials. | Screenshot and contact sheet prove commercial direction. |
| 10. Ledger | Source, license, prompts, task IDs, edits, export formats. | Rebuildable, reviewable, legally traceable asset. |

## Maya's Correct Role

Maya is not where we should improvise a finished character from nothing. It is
the production control point:

- clean Meshy/kitbash geometry
- fix scale, forward axis, pivot, naming, hierarchy
- retopologize or simplify problem areas
- split weapon, cloak, belt, and hard-surface parts
- create/adjust skeleton joints
- bind mesh to skeleton and paint skin weights
- pose-test shoulders, cloak, weapon, hands, knees, dodge, and death collapse
- export FBX/GLB for engine import

Unreal's FBX skeletal mesh pipeline describes the same basic production facts:
characters are exported from DCC software as FBX, contain mesh and skeleton, can
include animations/morph targets, and support materials, multiple UVs, vertex
colors, smoothing groups, and LODs.

## Meshy/API Role

Meshy is useful only if treated as a draft asset generator plus cleanup input.
The official Text to 3D API uses a two-step preview/refine flow: preview creates
untextured geometry, refine textures it. It can request `glb`, `obj`, `fbx`,
`stl`, `usdz`, and `3mf` outputs, supports A/T pose requests, target polycount,
and PBR/HD texture options. The docs also show that tasks consume credits, so
preview spam is waste.

Meshy's Rigging API can add skeletons to humanoid models, but programmatic
rigging is safest for standard bipedal humanoids with clear limbs/body. It is
not a substitute for game-specific attack timing, dodge frames, guard poses,
weapon sockets, cloth control, or camera-readability checks.

## Import Facts

Unreal:

- The foundational character asset is Skeletal Mesh: geometry plus skeleton.
- FBX import can bring mesh, skeleton, animations, morph targets, materials,
  multiple UVs, smoothing groups, vertex colors, and LODs.
- Character behavior is assembled in a Character Blueprint and Animation
  Blueprint.
- Skeleton compatibility and retargeting matter if we want to reuse animations.
- LODs should align to the same skeleton/pivot and can reduce material/detail
  complexity at distance.

Unity remains useful as background knowledge only unless an exception memo
selects Unity. If Unity is used, Humanoid/Generic rig import, Avatar mapping,
bone influences, and animation clip import still need review.

## Third-Person ARPG Character Readability Rules

For this project, character quality is judged from the gameplay camera first,
not from a beauty render.

Required:

- weapon profile visible from rear and side camera angles
- head/shoulder silhouette separated from cloak/body mass
- one bright hero value band and one dark anchor band
- warm/cool material contrast that survives temple lighting
- asymmetry: cloak tear, shoulder plate, belt shape, scabbard, shield, or weapon
- attack pose with clear anticipation, contact, and follow-through
- enemy silhouette that differs in size, color, posture, and facing language

Rejected:

- white blob hero
- generic armored human with no weapon identity
- details only visible close-up
- hair/cape/cloth fused into a single soft mass
- Meshy output used directly in-engine without cleanup
- animation that reads only when moving, not in still frames
- design that resembles a known franchise character or weapon

## First Character Target

Start with a hero-readable prototype character that can pass gameplay distance:

- role: lone swordfighter of an ancient sealed kingdom
- camera: rear three-quarter third-person gameplay distance
- silhouette: clear head/shoulders, practical cloak or torso value mark, visible
  one-handed sword, readable belt/scabbard line
- materials: weathered metal, dark cloth/leather, pale sacred-light accent,
  restrained brass/stone details
- animations: idle, run, lock-on strafe, dodge, light attack, heavy attack,
  guard, hit, heal, death

This is intentionally narrow. If this fails, adding more enemies or skills will
not fix the game.

## Spend Gate For Meshy

Before any paid/API generation:

- [ ] final role sentence approved
- [ ] 6+ silhouettes reviewed at gameplay crop
- [ ] front/side/back rough or reference sheet exists
- [ ] prompt includes pose, gameplay-readability, weapon, material bands, and
      forbidden details
- [ ] one preview limit per candidate; no refine until preview passes silhouette
- [ ] task IDs and prompts will be logged in asset ledger
- [ ] exported model will be cleaned in Maya before engine import

First allowed API experiment:

```text
Create one Meshy preview only, A-pose, GLB output, low-to-mid poly target,
for a solo third-person fantasy action RPG protagonist: unnamed swordfighter
from an ancient sealed kingdom, readable rear three-quarter silhouette, practical
weathered armor and cloth, visible one-handed sword and scabbard, clear head and
shoulder line, dark cloth/leather, weathered metal, pale sacred-light accent,
restrained brass details. Avoid copied franchise costume, famous weapon shape,
generic horned dark knight, huge fur cloak, tiny ornaments, hidden weapon,
merged hands, realistic face focus, and gore.
```

Do not refine/texture until the preview silhouette passes against the current
game camera.

## Immediate Next PR

The next implementation PR should create a character-evidence lane:

1. Add or update the asset ledger with character source/provenance.
2. Add a protagonist production brief with silhouette, material, animation, and
   Meshy spend gate.
3. Add an Unreal screenshot checklist for imported character evidence.

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
