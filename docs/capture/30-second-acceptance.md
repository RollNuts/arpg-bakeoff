# 30-Second Acceptance: 夜番の砦

Status: acceptance checklist for first Steam-facing gameplay capture.

A valid capture must prove the game is about local weapons, not just sword
combat.

## Required Beats

1. Player begins near a weapon rack or visible ground weapons.
2. Player moves through readable Wolf Forest lighting.
3. Enemy attack telegraph is visible.
4. Player attacks with one weapon.
5. Weapon durability or damage state is visible.
6. Player picks up or swaps to another weapon during combat.
7. Player throws a weapon.
8. Thrown weapon sticks into enemy, boss, or terrain.
9. Player recovers or pulls a weapon.
10. Boss/large enemy part or posture reaction appears.

## Visual Requirements

- HP and stamina are visible.
- Current and sub weapon are visible.
- Durability state is visible.
- Pickup prompt is visible when near a weapon.
- Weapon silhouettes are readable.
- Warm torch light and cool moonlight both appear.
- No gray-box/default-floor look.

## Audio Requirements

Even with temporary audio, the direction must be clear:

- pickup
- drop
- throw
- embed
- pull out
- weapon hit
- weapon break or near-break warning
- monster reaction
- torch/fire or night ambience

## Fail Conditions

- 30 seconds of only sword attacks.
- No local weapon pickup or throw.
- Weapons too small to read.
- Forest too dark or monochrome.
- HUD looks like unstyled debug text.
- Boss/large enemy interaction does not show weapon-specific value.
