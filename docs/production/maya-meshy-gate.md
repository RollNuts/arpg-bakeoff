# Maya / Meshy Gate

Status: active production gate.

## Product Gate Precondition

New 3D generation is paused until the active product direction in
`docs/product/game-definition-relic-runebound.md` is accepted by PR review.

Maya and Meshy should not be used to rescue vague fantasy props or a weak mock.
They are useful only after an asset proves a specific cooperative screen promise.

## Allowed Use

Maya:

- inspect FBX/OBJ/GLB files
- fix scale, pivot, orientation, and material slots
- clean rigs or sockets
- split tools and readable parts
- retopo or simplify if needed
- export engine-ready FBX

Meshy/API generation:

- only for main-screen assets
- only after legal free/owned/approved commercial sources fail or cannot meet
  the art target
- only after written success/failure criteria
- only after the asset will appear in the first screenshot or 30-second capture
- only with provenance, prompt, generated output, license/terms notes, and
  review status recorded in the asset ledger

## Forbidden Use

Do not spend API credits on:

- floor dirt
- decals
- small debris
- UI frames
- slash sprites
- generic hit sparks
- filler props
- background clutter
- making a weak mock look slightly better

## First Candidate If Needed

The first generated asset should prove the cooperative Relic Runebound promise.

Preferred order:

1. holy reliquary hero prop
2. readable tool stand with sword/shield/axe/torch/bell/ritual implement
3. pilgrim body with swappable carried tools
4. imp enemy
5. blind guardian blockout

The first body candidate must be:

- cooperative top-down fantasy pilgrim
- readable from oblique gameplay camera
- original sealed-temple expedition costume language
- readable head, shoulders, carried tool, and facing cues
- broad value blocking, not tiny detail dependence
- game-ready low/mid-poly target
- no known franchise resemblance
- usable in a Steam screenshot after cleanup, lighting, and material pass

Failure means:

- generic armor NPC
- unreadable at gameplay camera scale
- tool too thin or hidden
- facing unclear
- job identity unclear
- famous-character resemblance
- requires changing the game direction to justify it
