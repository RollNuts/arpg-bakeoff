# 2D To 3D Character Workflow

Status: production workflow note for using 2D concept images as starting points
for Meshy/Maya/Unity character creation.

## Direct Answer

Maya is not a one-click "2D character image to commercial 3D game character"
converter.

Maya can:

- place 2D concept art as image planes for modeling reference
- trace hard-surface motifs into curves
- extrude masks, blades, crown panels, theatre ornaments, and reliefs
- use grayscale maps for surface relief
- clean, retopo, UV, rig, skin, pose-test, and export models

Meshy or another generator can help with:

- rough 3D shape from one concept image
- better rough 3D shape from multiple concept views
- early silhouette comparison before manual cleanup

Human review is still required for:

- third-person gameplay readability
- left-arm `彩槽` readability
- shoulder, elbow, knee, hand, cloth, mantle, and sword topology
- UV and material separation
- weapon and color-organ sockets
- attack, dodge, parry, color drain, color skill, hit, and death timing
- legal/IP similarity review
- Steam screenshot readiness

## Practical Route For This Project

Use 2D images as a gate before any paid 3D generation.

First batch:

1. Lucien character sheet
2. seven color-form sheets:
   - red
   - blue
   - green
   - gold
   - purple
   - black
   - white
3. three enemy sheets:
   - masked actor
   - red dancer
   - stage executioner
4. Red Duchess boss sheet

Each sheet must include:

- black silhouette strip
- front view
- back view
- side or 3/4 view
- third-person gameplay crop
- weapon/color-organ/color-core close-up
- material/value swatches
- explicit reject notes

Run a 64-128 px thumbnail test and a gameplay-camera crop before 3D generation.
Do not refine, texture, rig, or animate until the preview survives the
game-camera test.

## Current Prompt Pattern

Use this only as a starting structure; each generation still needs asset-ledger
notes and review.

```text
3D dark fantasy action RPG protagonist concept sheet, Lucien the last color
mortician, slim androgynous swordfighter, black formal combat clothing,
one-sided long mantle, thin black-silver sword, brush dagger at waist, left arm
glass color organ filled with vivid liquid color, poisonous royal court fantasy,
wet black marble and gold detail material language, front view, back view, side
view, third-person gameplay crop, color-drain execution pose, red blue purple
color state thumbnails, commercial game character design, low/mid-poly 3D
production ready
```

Reject:

```text
no copied franchise costume, no recognizable famous weapon, no anime school
outfit, no generic horned dark knight, no plague doctor copy, no huge fur cloak,
no face-detail focus, no unreadable black blob, no merged hands, no hidden color
organ, no gore
```

## Maya Use Cases By Asset Type

| Asset Type | Best 2D Input | Maya Method | Meshy Useful? |
| --- | --- | --- | --- |
| Player Lucien | multi-view concept sheet with color states | image planes, blockout, cleanup, retopo, rig, skin | preview only |
| Sword/color forms | side/top views and grip poses | curve/mesh modeling, thickness, socket checks | sometimes |
| Color organ | close-up and material sheet | hard-surface/glass blockout, VFX anchor sockets | sometimes |
| Enemy | silhouette, color core, attack sheet | model over reference, simplify forms | yes |
| Boss | front/side mass plus attack/phase sheet | blockout in simple masses first | limited; cleanup heavy |
| Mask/crown/emblem | vector/black shape | curve/extrude/bevel | rarely needed |
| Floor relief | grayscale ornament map | displacement/normal/mesh relief | not needed |
| UI icon | flat concept/vector | keep 2D or vector | no |

## Preview Pass/Fail

Pass:

- 96 px grayscale still reads as the same role.
- Left arm/color organ is visible from gameplay angles.
- Weapon silhouette is obvious.
- Character has one dominant hook, not five small hooks.
- Head and shoulders are separable from mantle/body.
- It looks commercially usable after cleanup and material pass.

Fail:

- It only works as a full-resolution illustration.
- Color organ disappears in gameplay view.
- The pose is doing all the work.
- Materials are all the same dark value.
- It depends on particles alone to identify the color system.
- It looks like a known commercial character, class skin, or franchise mascot.

## Historical Concepts

The existing `docs/character/concepts/*.png` files are retained as historical
part-library and IP-safety evidence. Do not adopt any sheet wholesale as Lucien.
Reuse only isolated lessons:

- heavy impact mass for executioner or boss attacks
- hood/cloak/relic weight as silhouette reference
- pale veil or crest for readable value separation
- glass/moth afterimage ideas for blue/purple effects
- bell/root motifs for green enemies or props

## Sources

- Autodesk Maya Help: https://help.autodesk.com/view/MAYAUL/2026/ENU/
- Meshy Image to 3D API: https://docs.meshy.ai/en/api/image-to-3d
- Meshy Multi-Image to 3D API: https://docs.meshy.ai/en/api/multi-image-to-3d
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
