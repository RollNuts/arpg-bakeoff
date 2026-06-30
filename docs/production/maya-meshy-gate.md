# Maya / Meshy Gate

Status: active production gate.

## Product Gate Precondition

New 3D generation is paused until the active product direction in
`docs/product/game-definition-solo-fantasy-arpg.md` is accepted by PR review.

Maya and Meshy should not be used to rescue a vague fantasy character or a weak
mock. They are useful only after an asset proves a specific game promise on
screen.

## Allowed Use

Maya:

- inspect FBX/OBJ/GLB files
- fix scale, pivot, orientation, and material slots
- clean rigs or sockets
- split weapons and readable parts
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
- hit sparks
- filler props
- background clutter
- making a weak mock look slightly better

## First Candidate If Needed

The first generated asset should prove the current solo ARPG promise, not an
old Threadlight or cooperative reliquary concept.

Preferred order:

1. swordfighter protagonist body/gear preview
2. first small fiend enemy
3. Sealing Guardian boss blockout
4. signature ancient-temple weapon or altar prop

The first playable body candidate must be:

- solo third-person fantasy swordfighter
- readable from rear three-quarter gameplay camera
- original sealed-kingdom costume language
- readable head, shoulders, cloak/torso, weapon, and facing cues
- broad value blocking, not tiny detail dependence
- game-ready low/mid-poly target
- no known franchise resemblance
- usable in a Steam screenshot after cleanup, lighting, and material pass

Failure means:

- generic armor NPC
- unreadable at gameplay camera scale
- weapon too thin or hidden
- facing unclear
- job identity unclear
- famous-character resemblance
- requires changing the game direction to justify it
