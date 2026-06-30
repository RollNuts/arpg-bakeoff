# 色喰いの王冠 Production

Public planning and review repo for a Steam-facing 3D solo dark fantasy action
RPG.

This repository exists to keep the next work clean:

- no inherited Unity mock implementation
- no reuse of the first-person Unreal hotel project
- no placeholder-only visual proof
- no new Maya/Meshy/API spend before written gates pass
- every meaningful step happens through a pull request
- review comments can coordinate task slicing and merge order

## Current Objective

Build the smallest commercial-quality vertical slice for `色喰いの王冠`:

1. one readable player character, `リュシアン`, the last `彩葬師`
2. third-person 3D camera with lock-on and readable enemy telegraphs
3. sword combat, dodge, jump, guard/parry, color skills, and color drain
4. a dressed `赤絨毯の劇場` stage, not a graybox
5. enemy color layers and color cores
6. color drain execution that fills three `彩槽` slots
7. red, blue, and purple color abilities in the first vertical slice
8. exploration gates using color: red seal threads, blue memory platforms, and
   purple illusion walls
9. boss fight against `緋幕の公爵夫人`
10. screenshots and 30-second capture that sell "dark but vivid color-eating
    fantasy"

The active product definition is
[`docs/product/game-definition-color-eater-crown.md`](docs/product/game-definition-color-eater-crown.md).

## Ground Rules

- Do not copy existing game characters, UI, logos, costumes, silhouettes, named
  systems, bosses, maps, or weapon designs.
- Use references only for quality bars, readability, pacing, combat feel, color
  language, and store presentation patterns.
- Prefer commercially legal free or already-owned assets before paid or
  API-generated assets.
- Use Maya as an inspection, cleanup, conversion, rigging, or export tool, not
  as a reason to spend on throwaway assets.
- Keep generated assets isolated with provenance notes and approval evidence.
- Screenshots and video cannot be accepted if they show gray boxes, default
  floors, default skies, mannequin-only characters, debug UI, or unapproved
  asset-store pileups.

## Unity Assumption

`ProjectSettings/ProjectVersion.txt` is not present in this planning branch, so
Unity version is assumed to be `2021.3 LTS` until a real Unity project is added.
`Packages/manifest.json` is also not present, so no new package dependency is
approved by this branch.
