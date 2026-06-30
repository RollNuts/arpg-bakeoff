# 30-Second Capture Acceptance

This document defines the acceptance gate for the first Steam-facing cooperative
gameplay capture.

## Pre-Capture Gate

- Playable build or PIE session.
- Same-screen co-op playable flow or deterministic two-player test input.
- Solo run remains testable, but the store-facing capture should sell
  cooperation.
- No debug cheats required to reproduce the shown sequence.
- No graybox, default floor, default sky, mannequin-only character, or debug UI.
- All visible assets are approved in the asset ledger.
- Capture is continuous gameplay footage. No cut editing inside the 30 seconds.
- Minimum 30 fps, 1920x1080.

## Timeline Requirements

- `0-3s` Objective And Team Read
  - Two pilgrims, tool stand, reliquary, and temple identity are visible.
  - The frame already looks like a game product, not a test map.
- `3-6s` Tool Choice And Movement
  - Players pick up different tools or demonstrate role contrast.
  - The camera frames both players and the reliquary.
- `6-10s` First Enemy Pressure
  - Imps or spirits threaten a player or the reliquary.
  - Sword/shield/torch response shows hit, block, or repel feedback.
- `10-15s` Objective Conflict
  - A gate, mist corridor, sacred fire, or reliquary runaway pressure appears.
  - Fighting alone is visibly insufficient.
- `15-20s` Role-Swap Or Tool Solution
  - Axe, bow, torch, bell, or ritual implement solves a visible problem.
  - Reliquary/fire UI changes in response.
- `20-26s` Cooperation Spike
  - Blind guardian, spirit surge, or altar ritual creates a protect/lure/guard
    moment.
- `26-30s` Peak Frame And CTA
  - End on the strongest readable cooperative save, ritual completion, or
    failure pressure frame.
  - Title or CTA is readable if shown.

## Audio Minimums

All must be present if the corresponding action appears:

- attack SFX
- hit or shield SFX
- dodge/step or movement SFX
- torch/fire SFX
- holy bell or ritual SFX
- enemy hit/death or guardian threat SFX
- reliquary magic warning
- UI/altar/reward SFX if shown
- ambience or BGM that is not a debug placeholder
- mix clarity: warnings and hit sounds are not buried by music

## Additional Checks

- Events occur in the central readable area, not only at screen edges.
- No major pop-in or frame drop hides the main action.
- UI and VFX do not overlap the objective read.
- Screenshot candidates can be extracted from the capture.
- A short note records one visually weak/mock-looking area that was improved.

## Rejection Conditions

- Placeholder visuals or unresolved asset legality appear on screen.
- Footage proves only animation playback, not playable gameplay.
- Cooperation is not readable.
- Reliquary, sacred fire, or ritual objective is missing.
- Enemy pressure is missing.
- Audio is absent or uses a single debug track only.
- The capture could not support a Steam store page.
