# 2D To 3D Character Workflow

Status: production workflow note for using 2D concept images as the starting
point for Meshy/Maya/engine character creation.

## Direct Answer

Maya should not be treated as a one-click "2D character image to commercial 3D
game character" converter.

What Maya can do well:

- place 2D concept art as image planes for modeling reference
- trace silhouettes or hard-surface motifs into curves
- extrude flat logos, shields, blades, reliefs, and symbols from curves
- use height/displacement/normal-style images for surface relief
- clean, retopo, UV, rig, skin, pose-test, and export the resulting model

What should use AI/Meshy first:

- rough 3D shape from one concept image
- better rough 3D shape from multiple concept views
- early comparison of several silhouettes before manual cleanup

What must still be done by hand or at least human-reviewed:

- top-down silhouette judgement
- production topology around shoulders, elbows, knees, hands, cloth, and weapon
- UV layout and material separation
- skin weights
- attack animation timing
- game-camera readability
- legal/IP similarity review

## Practical Route For This Project

Use 2D images as a gate before any paid 3D generation.

1. Create 2D concept sheets for 3 hero candidates:
   - `H07 White-Charcoal Judgement Axe`
   - `H02 Black-Iron Pincer Knight`
   - `H08 Navy-Lantern Threadbinder`
2. Each sheet must include:
   - black silhouette strip
   - front view
   - back view
   - side or 3/4 view
   - top-down gameplay readability crop
   - weapon close-up
   - material/value swatches
   - explicit reject notes
3. Run a 64-128 px thumbnail test before 3D generation.
4. Use Meshy Image-to-3D or Multi-Image-to-3D for preview only.
5. Bring the preview into Maya.
6. Clean the mesh, split parts, fix weapon thickness, and verify top-down shape.
7. Only then spend on refine, texture, rig, animation, or engine import.

## 2D Sheet Requirements

Every candidate sheet must answer these questions without text labels:

- Which direction is the character facing?
- What is the weapon?
- What is the class fantasy?
- Where is the head?
- Where are the shoulders?
- What one shape makes this character different from any other dark knight?
- Does the silhouette survive when reduced to 96 px tall?

If the answer is unclear, do not generate 3D.

## Candidate 2D Prompts

These prompts are for creating 2D concept sheets. They are intentionally not
final game art prompts.

### H07 White-Charcoal Judgement Axe

```text
dark fantasy top-down ARPG playable hero concept sheet, white-charcoal
execution axe warrior, one oversized arm, one huge one-sided axe head wider
than the shoulders, charcoal black body, white ash cracks, dark red cloth,
clear black silhouette strip, front view, back view, side view, top-down
gameplay readability crop, weapon close-up, material swatches, practical game
character design, readable at small size
```

Reject:

```text
no generic barbarian, no viking helmet, no tiny axe, no realistic bodybuilder,
no gore, no huge fur cloak, no unreadable black blob, no excessive ornamental
detail
```

### H02 Black-Iron Pincer Knight

```text
dark fantasy top-down ARPG playable hero concept sheet, asymmetric black-iron
pincer knight, one huge shoulder pincer silhouette, one-handed great shears
weapon, short shield blade, rust red cloth, pale scar edge lines, clear black
silhouette strip, front view, back view, side view, top-down gameplay
readability crop, weapon close-up, material swatches, practical game character
design, readable at small size
```

Reject:

```text
no literal crab body, no robot armor, no tiny scissors, no hidden weapon, no
long cape covering legs, no excessive spikes, no merged hands, no extra arms,
no gore
```

### H08 Navy-Lantern Threadbinder

```text
dark fantasy top-down ARPG playable hero concept sheet, navy-lantern
threadbinder, small pale lantern floating above the head, black lacquer armor,
dark navy cloth, visible thick magical thread loops around the hands, compact
body silhouette, fingertip blade shapes, clear black silhouette strip, front
view, back view, side view, top-down gameplay readability crop, material
swatches, practical game character design, readable at small size
```

Reject:

```text
no puppet master cliche, no thin invisible threads, no dolls, no anime school
outfit, no cyber wires, no wings, no face-detail focus, no huge robe blob
```

## Maya Use Cases By Asset Type

| Asset Type | Best 2D Input | Maya Method | Meshy Useful? |
| --- | --- | --- | --- |
| Player hero | concept sheet with multiple views | image planes, blockout, cleanup, retopo, rig, skin | yes, preview only |
| Enemy fodder | concept sheet or strong silhouette | model over reference, simplify forms | yes |
| Boss | front/top silhouette plus attack-shape sheet | blockout in simple masses first | limited; cleanup heavy |
| Weapon | side view and top view | curve/mesh modeling, thickness pass | sometimes |
| Shield/emblem | vector/black shape | curve/extrude/bevel | rarely needed |
| Floor relief | grayscale height/ornament map | displacement/normal/mesh relief | not needed |
| UI icon | flat concept/vector | keep 2D or vector; do not force 3D | no |

## Preview Pass/Fail

Pass:

- 96 px grayscale still reads as the same role.
- Weapon silhouette is obvious.
- Character has one dominant hook, not five small hooks.
- Head and shoulders are separable from cape/body.
- The design can be modeled without relying on hair-thin details.

Fail:

- It only works as a full-resolution illustration.
- The weapon disappears in top-down view.
- The pose is doing all the work.
- Materials are all the same dark value.
- It depends on floating particles or VFX to identify the character.
- It looks like a known commercial character, class skin, or franchise mascot.

## First Batch Decision

Run 2D concept exploration first, not 3D generation.

Batch size:

- 3 hero candidates
- 2 variations each
- 6 concept sheets total

Pick one for Meshy preview only after this review:

1. H07 if the goal is strongest melee impact.
2. H02 if the goal is strongest dark-fantasy identity.
3. H08 if the goal is novelty, accepting higher production risk.

No refine/rig/animation spend until a 2D sheet passes the tiny-camera test.

## Sources

- Autodesk Maya Help: https://help.autodesk.com/view/MAYAUL/2026/ENU/
- Meshy Image to 3D API: https://docs.meshy.ai/en/api/image-to-3d
- Meshy Multi-Image to 3D API: https://docs.meshy.ai/en/api/multi-image-to-3d
- Meshy for Maya plugin: https://docs.meshy.ai/en/maya-plugin/introduction
