# Relic Runebound Production

Public planning and review repo for a Steam-facing 3D top-down cooperative
fantasy action game.

This repository exists to keep the next work clean:

- no inherited Unity mock implementation
- no reuse of the first-person Unreal hotel project
- no placeholder-only visual proof
- no new Maya/Meshy/API spend before written gates pass
- every meaningful step happens through a pull request
- review comments can coordinate task slicing and merge order

## Current Objective

Build the smallest commercial-quality vertical slice for `Relic Runebound`
(`聖櫃の巡礼隊`):

1. two readable same-screen pilgrims, with solo test/clear support
2. 3D top-down oblique camera
3. movement, attack, dodge/step, pickup/drop, interact, and special tool action
4. one dressed ancient-temple route, not a graybox
5. weapon/tool stands that create role changes
6. holy reliquary durability and magic-runaway pressure
7. sacred fire, spirits, imps, and one blind guardian pressure beat
8. final altar ritual with victory/defeat outcome
9. screenshots and 30-second capture that look like a real Steam product

The active product definition is
[`docs/product/game-definition-relic-runebound.md`](docs/product/game-definition-relic-runebound.md).

## Ground Rules

- Do not copy existing game characters, UI, logos, costumes, silhouettes, named
  systems, bosses, maps, or weapon designs.
- Use references only for quality bars, readability, pacing, cooperation
  pressure, combat feel, and store presentation patterns.
- Prefer commercially legal free or already-owned assets before paid or
  API-generated assets.
- Use Maya as an inspection, cleanup, conversion, rigging, or export tool, not
  as a reason to spend on throwaway assets.
- Keep generated assets isolated with provenance notes and approval evidence.
- Screenshots and video cannot be accepted if they show gray boxes, default
  floors, default skies, mannequin-only characters, debug UI, or unapproved
  asset-store pileups.
