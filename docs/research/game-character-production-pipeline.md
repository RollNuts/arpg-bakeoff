# Game Character Production Pipeline

Status: research note for deciding how to create the first commercial-looking
ARPG character without wasting Maya/Meshy/API spend.

## Blunt Finding

The current Phase 1 character fails as a commercial character because it is a
procedural gameplay marker, not a production character. A production character
needs readable identity, authored shape language, deformation-safe topology,
materials that survive the game camera, animation poses that sell intent, and
engine evidence. Meshy can help create starting geometry. Maya is where the
result must be judged, cleaned, rigged, skinned, and made usable.

Do not spend paid generation credits until the character has a one-page
direction sheet and a pass/fail test at gameplay camera distance.

## Pipeline

| Stage | Output | Pass Gate |
| --- | --- | --- |
| 1. Role and camera brief | One sentence role, weapon, scale, camera-distance crop, color/value target. | Readable as hero/enemy at 256 px tall screenshot. |
| 2. Silhouette sheet | 6-12 black silhouettes, front/side/back roughs, weapon profile. | Head, shoulders, weapon, facing direction readable in black. |
| 3. Color/material key | 2-3 material/value studies, no final render dependency. | Hero separates from blue-gray dungeon floor and warm torches. |
| 4. Generation or blockout | Meshy preview, Maya blockout, or kitbash blockout. | Shape works untextured from top-down. |
| 5. Cleanup/retopo | Animation-ready low/mid poly mesh, named parts, pivot/origin set. | No melted limbs, no ambiguous hands/weapon, no tangled intersections. |
| 6. UV/materials | Base color, normal, roughness/metal where useful. | Materials read under engine lighting, not only in DCC viewport. |
| 7. Rig/skin | Skeleton, skin weights, weapon sockets, optional cloth/cape bones. | Idle/run/attack/death poses deform without collapsing volume. |
| 8. Animation set | Idle, run, dodge, attack, hit, death, and one skill pose. | Each pose reads in a still frame before motion blur/VFX. |
| 9. Engine import | Unity or Unreal prefab/blueprint with scale, materials, animator. | Screenshot and contact sheet prove commercial direction. |
| 10. Ledger | Source, license, prompts, task IDs, edits, export formats. | Rebuildable, reviewable, legally traceable asset. |

## Maya's Correct Role

Maya is not where we should improvise a finished character from nothing. It is
the production control point:

- clean Meshy/kitbash geometry
- fix scale, forward axis, pivot, naming, hierarchy
- retopologize or simplify problem areas
- create/adjust skeleton joints
- bind mesh to skeleton and paint skin weights
- pose-test shoulders, cape, weapon, hands, knees, and death collapse
- export FBX/GLB for engine import

Unreal's FBX skeletal mesh pipeline describes the same basic production facts:
characters are exported from DCC software as FBX, contain mesh and skeleton, can
include animations/morph targets, and support materials, multiple UVs, vertex
colors, smoothing groups, and LODs. It also calls out Maya Joint Tool, Smooth
Bind, Paint Skin Weights, manual triangulation control, normal-map baking, and
Skeletal Mesh LOD setup as production concerns.

## Meshy/API Role

Meshy is useful only if treated as a draft asset generator plus cleanup input.
The official Text to 3D API uses a two-step preview/refine flow: preview creates
untextured geometry, refine textures it. It can request `glb`, `obj`, `fbx`,
`stl`, `usdz`, and `3mf` outputs, supports A/T pose requests, target polycount,
and PBR/HD texture options. The docs also show that tasks consume credits, so
preview spam is waste.

Meshy's Rigging API can add skeletons to humanoid models, but the official docs
state that programmatic rigging currently works well only for standard bipedal
humanoids with clear limbs/body. It is not suitable for untextured meshes,
non-humanoids, unclear humanoids, or models over 300,000 faces when using a
task ID. Model URL rigging requires textured GLB and forward-facing +Z.

Meshy's Animation API applies library animations to a previously rigged
character. That can accelerate tests, but it does not solve game-specific attack
timing, hit stop, dodge frames, weapon sockets, or top-down pose readability.

## Unity/Unreal Import Facts

Unity:

- Humanoid import needs a valid Avatar mapped to a human-like skeleton.
- Unity distinguishes Humanoid and Generic rigs; non-human enemies may need
  Generic.
- Unity recommends checking Avatar mapping even when automatic mapping succeeds.
- The Rig import tab defaults to 4 bone skin weights for performance, and higher
  bone influence has cost.
- Animation clips can be masked, clipped, loop-optimized, and event-marked at
  import.

Unreal:

- The foundational character asset is Skeletal Mesh: geometry plus skeleton.
- FBX import can bring mesh, skeleton, animations, morph targets, materials,
  multiple UVs, smoothing groups, vertex colors, and LODs.
- Character behavior is assembled in a Character Blueprint and Animation
  Blueprint.
- Skeleton compatibility and retargeting matter if we want to reuse animations.
- LODs should align to the same skeleton/pivot and can reduce material/detail
  complexity at distance.

## Top-Down ARPG Character Readability Rules

For this project, character quality is judged from gameplay camera first, not
from a beauty render.

Required:

- oversized weapon or signature prop visible from top-down
- head/shoulder silhouette separated from cape/body mass
- one bright hero value band and one dark anchor band
- warm/cool material contrast that survives dungeon lighting
- asymmetry: shoulder plate, cape tear, lantern, relic, horn, or weapon shape
- attack pose with clear anticipation, contact, follow-through
- enemy silhouette that differs in size, color, and facing language

Rejected:

- white blob hero
- generic armored human with no weapon identity
- details only visible close-up
- hair/cape/cloth fused into a single soft mass
- Meshy output used directly in-engine without cleanup
- animation that reads only when moving, not in still frames

## First Character Target

Do not start with a complex full hero. Start with a "hero-readable prototype
character" that can pass gameplay distance:

- role: cursed foldblade knight / relic duelist
- camera: top-down/isometric gameplay distance, character occupies 12-16% of
  screen height in hero evidence shot
- silhouette: broad left shoulder, long diagonal folding blade, short torn cape,
  bright mask/crest, dark lower body
- materials: pale mask/crest, blackened armor, oxblood cloth, cyan relic glow,
  warm edge highlights from torches
- animations: idle, run, dodge, light attack, heavy attack, hit, death

This is intentionally narrow. If this fails, adding more enemies or skills will
not fix the game.

## Spend Gate For Meshy

Before any paid/API generation:

- [ ] final role sentence approved
- [ ] 6+ silhouettes reviewed at gameplay crop
- [ ] front/side/back rough or reference sheet exists
- [ ] prompt includes pose, camera-readability, weapon, material bands, and
      forbidden details
- [ ] one preview limit per candidate; no refine until preview passes silhouette
- [ ] task IDs and prompts will be logged in asset ledger
- [ ] exported model will be cleaned in Maya before engine import

First allowed API experiment:

```text
Create one Meshy preview only, A-pose, GLB output, low-to-mid poly target,
for a dark fantasy top-down ARPG hero with exaggerated readable silhouette:
bright mask/crest, asymmetrical shoulder armor, torn short cape, long diagonal
foldblade weapon, blackened armor, oxblood cloth, cyan relic accent. Avoid tiny
ornaments, fused hands, hidden weapon, symmetrical generic knight, realistic
face detail, and long trailing cloth that would break top-down readability.
```

Do not refine/texture until the preview silhouette passes against the current
game camera.

## Immediate Next PR

The next implementation PR should not be another procedural body polish pass.
It should create a character-evidence lane:

1. Add `docs/asset-ledger/character-ledger.md`.
2. Add a `docs/character/hero-readable-prototype-brief.md` with silhouette,
   material, animation, and Meshy spend gate.
3. Add a Unity/Unreal neutral screenshot checklist for imported character
   evidence.

Only after that should a Meshy/Maya/engine import PR be opened.

## Sources

- Meshy API introduction and endpoint list: https://docs.meshy.ai/en
- Meshy Text to 3D API: https://docs.meshy.ai/en/api/text-to-3d
- Meshy Rigging API: https://docs.meshy.ai/en/api/rigging
- Meshy Animation API: https://docs.meshy.ai/en/api/animation
- Meshy Remesh API: https://docs.meshy.ai/en/api/remesh
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
- Unity Humanoid import and Avatar configuration:
  https://docs.unity3d.com/Manual/ConfiguringtheAvatar.html
- Unity Rig import settings:
  https://docs.unity3d.com/Manual/FBXImporter-Rig.html
- Unreal Skeletal Mesh assets:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/skeletal-mesh-assets-in-unreal-engine
- Unreal FBX Skeletal Mesh Pipeline:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/fbx-skeletal-mesh-pipeline-in-unreal-engine
- Unreal Animation Retargeting:
  https://dev.epicgames.com/documentation/en-us/unreal-engine/animation-retargeting-in-unreal-engine
