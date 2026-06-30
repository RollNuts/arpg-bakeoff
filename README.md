# Solo Fantasy ARPG Production

Public planning and review repo for a Steam-facing solo 3D fantasy action RPG.

This repository exists to keep the next work clean:

- no inherited Unity mock implementation
- no reuse of the first-person Unreal hotel project
- no placeholder-only visual proof
- no new Maya/Meshy/API spend before written gates pass
- every meaningful step happens through a pull request
- review comments can coordinate task slicing and merge order

## Current Objective

Build the smallest commercial-quality vertical slice for a solo 3D fantasy
aRPG:

1. one readable swordfighter hero
2. third-person camera with lock-on support
3. walk, run, dodge, attack, guard, and healing
4. one dressed ancient-temple combat space
5. two normal enemies with readable telegraphs
6. one first boss with entrance, HP UI, music, and defeat beat
7. screenshots and 30-second capture that look like a real Steam product

The active product definition is
[`docs/product/game-definition-solo-fantasy-arpg.md`](docs/product/game-definition-solo-fantasy-arpg.md).

## Ground Rules

- Do not copy existing game characters, UI, logos, costumes, silhouettes, named
  systems, bosses, or weapon designs.
- Use references only for quality bars, readability, pacing, combat feel, and
  store presentation patterns.
- Prefer commercially legal free or already-owned assets before paid or
  API-generated assets.
- Use Maya as an inspection, cleanup, conversion, rigging, or export tool, not
  as a reason to spend on throwaway assets.
- Keep generated assets isolated with provenance notes and approval evidence.
- Screenshots and video cannot be accepted if they show gray boxes, default
  floors, default skies, mannequin-only characters, debug UI, or unapproved
  asset-store pileups.
