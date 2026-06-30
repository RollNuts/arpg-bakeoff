# 30-Second Capture Acceptance

This document defines the acceptance gate for the first Steam-facing
`色喰いの王冠` gameplay capture.

## Pre-Capture Gate

- Playable build or editor play session.
- Solo playable combat and exploration flow.
- No debug cheats required to reproduce the shown sequence.
- No graybox, default floor, default sky, mannequin-only character, or debug UI.
- All visible assets are approved in the asset ledger.
- Capture is continuous gameplay footage. No cut editing inside the 30 seconds.
- Minimum 30 fps, 1920x1080.

## Timeline Requirements

- `0-3s` Player And World Read
  - Lucien, left-arm color organ, red theatre, and color identity are visible.
  - The frame already looks like a game product, not a test map.
- `3-6s` Movement And Lock-On
  - Player moves through the red theatre and locks onto an enemy.
  - Camera keeps enemy telegraph and player color state readable.
- `6-10s` First Combat And Color Layer
  - Normal/heavy attack hits.
  - Enemy HP and color layer response are visible.
- `10-14s` Color Drain
  - Color layer breaks.
  - Color drain execution pulls color into `彩槽`.
  - HP restore, shockwave, or slot fill reads clearly.
- `14-18s` Color Changes Action
  - Red, blue, or purple skill changes weapon/VFX/behavior.
  - The screen shows this is not only a sword game.
- `18-22s` Exploration Gate
  - Red seal, blue memory platform, or purple illusion wall reacts to color.
- `22-27s` Boss Or Elite Promise
  - Red Duchess entrance, silhouette, or major attack appears.
  - Boss HP/color layer or stage hazard makes the larger threat clear.
- `27-30s` Peak Frame And CTA
  - End on the strongest readable color-drain, color-skill, or boss-impact
    frame.
  - Title or CTA is readable if shown.

## Audio Minimums

All must be present if the corresponding action appears:

- sword attack SFX
- hit SFX
- dodge or movement SFX
- color layer break SFX
- color drain SFX
- color slot fill SFX
- red/blue/purple skill SFX
- enemy hit/death SFX
- UI/menu SFX if shown
- ambience or BGM that is not a debug placeholder
- mix clarity: color drain and hits are not buried by music

## Additional Checks

- Events occur in the central readable area, not only at screen edges.
- No major pop-in or frame drop hides the main action.
- UI and VFX do not overlap the color-core read.
- Screenshot candidates can be extracted from the capture.
- A short note records one visually weak/mock-looking area that was improved.

## Rejection Conditions

- Placeholder visuals or unresolved asset legality appear on screen.
- Footage proves only animation playback, not playable gameplay.
- Color drain is missing.
- The game reads as generic sword combat.
- Enemy color layer or color core is not readable.
- Audio is absent or uses a single debug track only.
- The capture could not support a Steam store page.
