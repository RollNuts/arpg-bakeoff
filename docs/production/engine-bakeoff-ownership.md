# Engine Bakeoff Ownership

Status: PR ownership map for `夜番の砦`.

## PR Order

1. Product Direction: active Nightwatch Fortress bible and docs.
2. Asset Gate: legal source list and asset ledger updates.
3. Unity Setup: ProjectSettings, package manifest, first scene folders.
4. Player Core: movement, camera, dodge, jump, lock-on hook.
5. Weapon Core: weapon data, durability, pickup/drop/swap.
6. Throw/Embed: thrown weapons, sticking, pull-out interaction.
7. Combat Core: attacks, heavy attacks, guard, parry, posture, hit stop.
8. Wolf Forest: dressed first route and weapon racks.
9. Enemies: wolf, horned beast, goblin, shield goblin.
10. Garm: boss arena, part breaks, spear stop, hammer stagger.
11. Capture: 30-second proof and contact sheet.
12. Polish: lighting, HUD, SFX, VFX, input feel.

## Merge Rule

Merge product and system foundation PRs before visual polish PRs. Do not merge a
visual scene that proves the wrong game hook. The first implementation must
show local weapons, not just sword combat.

## Review Focus

- Does this PR make `現地武器` more true?
- Can the player see and use weapons on the ground?
- Does the screen read as night fantasy but not gray?
- Are asset/license notes present for any imported media?
- Is there screenshot or playtest evidence when visuals/gameplay change?
