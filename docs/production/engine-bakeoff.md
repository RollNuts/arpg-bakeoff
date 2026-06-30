# Engine Bakeoff

Status: reopened for Unreal visual spike after `夜番の砦` visual target review.

## Current Decision

Do not commit to Unity as the production engine until Unreal has been tested
against the same `狼森` first-screen target.

Reason:

- Unity already has a useful local-weapon gameplay scaffold in this repo.
- The product's selling constraint is visual credibility: night lighting, wet
  material response, fog, a heroic hunter silhouette, readable weapons, and a
  giant wolf boss must sell the game in one screenshot.
- Unreal 5.8 is installed locally and is likely stronger for this visual target.
- The next decision must be based on rendered evidence, not engine habit.

See:

`docs/production/unreal-visual-spike.md`

## Required First Proof

Do not count the engine setup as meaningful until a playable scene proves:

- player movement
- weapon pickup
- weapon swap
- weapon throw
- weapon durability state
- thrown weapon embedding in a large target
- weapon pull/recover
- enemy posture or part reaction
- HUD for HP, stamina, weapon slots, durability, pickup prompt

## Visual Gate

The first scene must be dressed enough to read as `狼森`:

- moonlight
- torch light
- trees
- hunter debris
- weapon rack
- ground weapons
- no default floor/sky/graybox acceptance

## Unity Version Rule

For the Unity scaffold, `ProjectSettings/ProjectVersion.txt` is the source of
truth and currently pins Unity `6000.3.18f1`.

## Unreal Version Rule

For the Unreal spike, the local engine is:

`/Users/murakaminaoya/Epic Games/UE_5.8`

Run the current Unreal proof with:

```bash
bash Unreal/NightwatchFortress/Scripts/run_wolf_forest_visual_spike.sh
```

If the commandlet stalls before producing a log, open the project manually:

```bash
bash Unreal/NightwatchFortress/Scripts/open_nightwatch_unreal_editor.sh
```

## Package Rule

`Packages/manifest.json` is the package source of truth. No package beyond the
manifest may be added without an approval memo covering official docs, license,
alternatives, and removal method.
