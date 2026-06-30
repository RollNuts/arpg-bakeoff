# 夜番の砦 Production

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

Build the smallest commercial-quality vertical slice for `夜番の砦`:

1. one readable player character, a practical `夜番` with leather armor, cloak,
   lantern, weapon holders, gloves, boots, and a clear adventurer silhouette
2. third-person camera behind and above the player, readable for enemies,
   weapons, footing, dodge direction, and pickups
3. fast, satisfying solo ARPG combat with attack, heavy attack, dodge, jump,
   guard, parry, lock-on, item use, and interaction
4. the core hook: picking up, dropping, throwing, breaking, and swapping local
   weapons during combat
5. weapon states: fresh, normal, chipped, near-broken, broken
6. weapon racks, dropped enemy weapons, embedded weapons, and boss-room weapon
   supplies
7. first vertical-slice weapons: one-handed sword, spear, great hammer, bow,
   torch, and large shield hooks
8. first area: `狼森`, with moonlit forest, hunter shack, fallen trees, stream,
   weapon racks, torch stands, shortcut, and boss den
9. first enemies: small wolf, horned beast, goblin, shield goblin
10. first boss: `大狼ガルム`, with spear-into-leg stop, head stagger, tail
    break, phase change, and defeat sequence
11. screenshots and 30-second capture that sell "one person hunting monsters at
    night while surviving by changing weapons on the ground"

The active product definition is
[`docs/product/game-definition-nightwatch-fortress.md`](docs/product/game-definition-nightwatch-fortress.md).

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

## Unity Project

`ProjectSettings/ProjectVersion.txt` is present and pins the project to Unity
`6000.3.18f1`.

`Packages/manifest.json` currently contains built-in Unity modules only. The
approval memo is
[`docs/production/package-approval-unity-foundation.md`](docs/production/package-approval-unity-foundation.md).

The current playable foundation is generated inside Unity from:

`Nightwatch Fortress > Build Wolf Forest Foundation Scene`

This creates `Assets/Scenes/WolfForestFoundation.unity`, a code-generated
moonlit `狼森` slice with player movement, local weapons, pickup/drop/throw,
basic enemy health/posture, weapon drops, an embedded-weapon boss target, HUD,
camera, lighting, torches, weapon rack, stream, hunter shack, and forest set
dressing.
