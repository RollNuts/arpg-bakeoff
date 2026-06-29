# Visual And Audio Benchmark

Status: research input for PR review.

## Video Patterns

- Show a large readable shape in the first 1-3 seconds: magic circle,
  explosion, giant enemy, gate, boss, or enemy swarm.
- Use diagonal screen motion. Fixed top-down cameras still need diagonal player
  movement, enemy flow, and VFX direction.
- Keep the player visually separated with rim light, color, space, or a
  readable attack/safety ring.
- Show movement, attack, density ramp, and reward/build choice within 30
  seconds.
- VFX must have shape, not just glow: circles, cones, beams, trails, waves,
  impact bursts, and lingering aftereffects.

## Screenshot Patterns

- A strong screenshot has one clear subject: combat, environment, or build UI.
- Combat screenshots separate hero, enemies, attack direction, and danger.
- The floor has at least three layers: base material, detail/noise, and lighting
  or decal information.
- Corners and edges carry world detail: light sources, rubble, corpses, doors,
  pillars, chests, cliffs, or UI.
- Enemy placement is not evenly spaced. Use groups, columns, waves, encirclement,
  and boss-centered density.

## First 30 Seconds Storyboard

1. `0-2s`: hero alone on dark readable floor, weapon/identity visible.
2. `2-6s`: diagonal movement, first hit, dodge, enemy death, drop feedback.
3. `6-10s`: first signature skill with a clear shape.
4. `10-15s`: enemies enter from edges; keep a readable player pocket.
5. `15-20s`: medium enemy or mini-boss with size, color, and telegraph.
6. `20-24s`: reward/build choice, three options maximum.
7. `24-28s`: chosen upgrade immediately changes the combat shape.
8. `28-30s`: highest-density frame, then title/CTA.

## Audio Direction

Music:

- low drone
- metal or skin percussion
- short string/guitar/synth motif
- optional low choir for boss pressure
- SFX-forward mix with space in the 2-5 kHz range

Combat SFX:

- attack = whoosh + contact crack/slash + body/armor layer + low thump
- dodge = short cloth/leather/air burst, 0.2-0.4 seconds
- enemy death = short collapse plus soul/ember tail
- player death = low drop, breath/heartbeat stop, momentary BGM duck
- reward = rarity-coded stings, not long fanfares

Minimum audio set:

- 3 loopable music beds: exploration, combat, boss/high-density
- one 30-second trailer arrangement
- 30-50 combat SFX
- 15-20 UI/reward SFX
- 4-6 ambience loops

## Mock Smell To Reject

- flat floor with evenly spaced prefabs
- hero, enemies, projectiles, and floor at the same value
- round glow sprites with no attack shape
- inconsistent UI fonts, frames, or icon resolution
- no knockback, hit stop, death reaction, or reward feedback
- 30 seconds of the same enemy, same attack, same floor

