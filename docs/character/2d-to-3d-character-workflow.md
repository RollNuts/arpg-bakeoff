# 2D To 3D Character Workflow

Status: production workflow note for using 2D concept images as starting points
for Meshy/Maya/Unreal character creation.

## Direct Answer

Maya is not a one-click "2D character image to commercial 3D game character"
converter.

Maya can:

- place 2D concept art as image planes for modeling reference
- trace hard-surface motifs into curves
- extrude shields, blades, bells, reliquary panels, reliefs, and symbols
- use grayscale maps for surface relief
- clean, retopo, UV, rig, skin, pose-test, and export models

Meshy or another generator can help with:

- rough 3D shape from one concept image
- better rough 3D shape from multiple concept views
- early silhouette comparison before manual cleanup

Human review is still required for:

- top-down oblique gameplay readability
- held-tool silhouette
- shoulder, elbow, knee, hand, cloth, and tool topology
- UV and material separation
- tool socketing
- attack, block, carry, light, chant, hit, and death timing
- legal/IP similarity review
- Steam screenshot readiness

## Practical Route For This Project

Use 2D images as a gate before any paid 3D generation.

First batch:

1. one pilgrim body sheet with held-tool variants
2. seven tool sheets:
   - sword
   - great shield
   - axe
   - bow
   - torch
   - holy bell
   - ritual implement
3. holy reliquary sheet
4. two enemy sheets:
   - imp
   - spirit
5. one guardian blockout sheet:
   - blind guardian

Each sheet must include:

- black silhouette strip
- front view
- back view
- side or 3/4 view
- top-down oblique gameplay crop
- tool/attack/interact close-up
- material/value swatches
- explicit reject notes

Run a 64-128 px thumbnail test and a gameplay-camera crop before 3D generation.
Do not refine, texture, rig, or animate until the preview survives the
game-camera test.

## 2D Sheet Requirements

Every candidate sheet must answer these questions without text labels:

- Which direction is the character facing?
- What tool is being carried?
- Where is the head and shoulder line?
- Can another player tell the role at a glance?
- Can the design animate attack, block, carry, light, chant, hit, and death?
- Does the silhouette survive as a Steam trailer thumbnail crop?
- Does it avoid known franchise resemblance?

If the answer is unclear, do not generate 3D.

## Current Prompt Pattern

Use this only as a starting structure; each generation still needs asset-ledger
notes and review.

```text
cooperative top-down fantasy action pilgrim concept sheet, shrine expedition
worker escorting a holy reliquary, practical weathered cloth and light armor,
readable top-down oblique silhouette, held-tool variants for sword shield axe
torch bell ritual implement, clear head and shoulder shape, strong cloak or
torso value separation, front view, back view, side view, gameplay camera crop,
tool close-ups, material swatches, animation pose thumbnails for run attack
block carry light chant hit death, commercial game character design,
low/mid-poly 3D production ready
```

Reject:

```text
no copied franchise costume, no recognizable famous weapon, no anime school
outfit, no generic horned dark knight, no excessive spikes, no giant fur cloak,
no face-detail focus, no unreadable black blob, no merged hands, no hidden
tool, no gore
```

## Maya Use Cases By Asset Type

| Asset Type | Best 2D Input | Maya Method | Meshy Useful? |
| --- | --- | --- | --- |
| Player pilgrim | multi-view concept sheet with tools | image planes, blockout, cleanup, retopo, rig, skin | preview only |
| Tool set | side/top views and grip poses | curve/mesh modeling, thickness, socket checks | sometimes |
| Reliquary | front/side/top and material panels | hard-surface blockout, bevels, sockets, VFX anchors | sometimes |
| Enemy fodder | silhouette and attack sheet | model over reference, simplify forms | yes |
| Guardian | front/top mass plus charge/lure shapes | blockout in simple masses first | limited; cleanup heavy |
| Shield/emblem | vector/black shape | curve/extrude/bevel | rarely needed |
| Floor relief | grayscale ornament map | displacement/normal/mesh relief | not needed |
| UI icon | flat concept/vector | keep 2D or vector | no |

## Preview Pass/Fail

Pass:

- 96 px grayscale still reads as the same role.
- Held tool silhouette is obvious from gameplay angles.
- Character has one dominant hook, not five small hooks.
- Head and shoulders are separable from cloak/body.
- The design can be modeled without relying on hair-thin details.
- It looks commercially usable after cleanup and material pass.

Fail:

- It only works as a full-resolution illustration.
- The tool disappears in gameplay view.
- The pose is doing all the work.
- Materials are all the same dark value.
- It depends on floating particles or VFX to identify the role.
- It looks like a known commercial character, class skin, or franchise mascot.

## Historical Concepts

The existing `docs/character/concepts/*.png` files are retained as historical
part-library and IP-safety evidence. Do not adopt any sheet wholesale as the
player character. Reuse only isolated lessons:

- heavy impact mass for axe/guardian timing
- hooded field-worker/relic weight as silhouette reference
- pale veil or crest for readable value separation
- bell/root motifs for enemies or area props
- pincer/axe forms for guardian mass

## Sources

- Autodesk Maya Help: https://help.autodesk.com/view/MAYAUL/2026/ENU/
- Meshy Image to 3D API: https://docs.meshy.ai/en/api/image-to-3d
- Meshy Multi-Image to 3D API: https://docs.meshy.ai/en/api/multi-image-to-3d
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
