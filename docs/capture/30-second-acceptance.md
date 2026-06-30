# 30-Second Capture Acceptance

This document defines the acceptance gate for the first Steam-facing gameplay
capture.

## Pre-Capture Gate

- Unreal playable build or PIE session unless a Unity exception memo has been
  accepted.
- Solo playable combat, not cinematic-only playback.
- No debug cheats required to reproduce the shown sequence.
- No graybox, default floor, default sky, mannequin-only character, or debug UI.
- All visible assets are approved in the asset ledger.
- Capture is continuous gameplay footage. No cut editing inside the 30 seconds.
- Minimum 30 fps, 1920x1080.

## Timeline Requirements

- `0-3s` Hero And World Read
  - The hero is clearly visible: body, weapon, facing, and value contrast.
  - The Sealing Temple or ancient kingdom identity is readable.
  - The frame already looks like a game product, not a test map.
- `3-6s` Movement And Camera
  - The hero runs or strafes with camera support.
  - Lock-on or assisted framing does not hide the enemy.
- `6-10s` First Telegraph And Response
  - One enemy windup is readable.
  - The player dodges, guards, or attacks in response.
  - At least one hit or clear near-miss is visible.
- `10-15s` Impact Feel
  - Hit stop, flinch, knockback, impact VFX, and SFX intent are visible/audible.
  - HP/stamina/heal UI reads without looking like debug text.
- `15-20s` Second Decision
  - A second enemy behavior, shield read, altar, shortcut, or sealed gate changes
    the moment.
  - This must prove ARPG space, not only a combat animation test.
- `20-26s` Guardian Or Boss Promise
  - A guardian, boss gate, or boss entrance appears.
  - Scale, name/HP UI, or windup makes the larger threat clear.
- `26-30s` Peak Frame And CTA
  - End on the strongest readable combat frame.
  - Title or CTA is readable if shown.

## Audio Minimums

All must be present:

- attack SFX
- hit or guard SFX
- dodge or movement SFX
- enemy hit/death or boss threat SFX
- UI/altar/reward SFX if shown
- ambience or BGM that is not a debug placeholder
- mix clarity: hit sounds are not buried by music

## Additional Checks

- Events occur in the central readable area, not only at screen edges.
- No major pop-in or frame drop hides the main action.
- UI and VFX do not overlap the combat read.
- Screenshot candidates can be extracted from the capture.
- A short note records one visually weak/mock-looking area that was improved.

## Rejection Conditions

- Placeholder visuals or unresolved asset legality appear on screen.
- Multiplayer/co-op dependency is required to explain the footage.
- Footage proves only animation playback, not playable combat.
- Hero action is too limited to sell the game.
- Enemy windup, hit, or boss promise is missing.
- Audio is absent or uses a single debug track only.
- The capture could not support a Steam store page.
