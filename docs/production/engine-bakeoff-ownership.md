# Unreal Production Ownership

Status: proposed PR ownership plan.

## Scope

The project is Unreal-first. Split work by production proof, not by parallel
Unity/Unreal comparison.

## PR Ownership

- PR-Product: product bible, scope, done criteria, and anti-copy rules.
- PR-Asset-Gate: asset ledger format, legal source shortlist, Maya/Meshy gate.
- PR-Unreal-Setup: fresh Unreal project, input, camera scaffold, capture path.
- PR-Environment: dressed Sealing Temple entrance, reliquary, sacred fire,
  weapon stand, lighting, fog, materials, and screenshot proof.
- PR-Players: two local players, solo test controls, movement, dodge/step,
  pickup/drop, and same-screen camera.
- PR-Tools: sword, shield, axe, torch, and ritual implement basics.
- PR-Reliquary: durability, runaway, movement/activation, warning UI/VFX.
- PR-Enemies: imp, spirit, and blind guardian pressure.
- PR-Ritual: altar phases, protect-the-chanter moment, success/failure.
- PR-Capture: 10-second and 30-second capture evidence plus screenshot set.

## Evidence Requirements Per Gameplay PR

Every gameplay PR must include:

- gameplay screenshot
- close readability screenshot where relevant
- short capture or playtest note
- asset ledger changes for visible assets
- known placeholder/mock-looking areas and what was improved

## Merge Order Request

The preferred order is:

1. Product
2. Asset-Gate
3. Unreal-Setup
4. Environment
5. Players
6. Tools
7. Reliquary
8. Enemies
9. Ritual
10. Capture

If multiple PRs are open, merge order should preserve this dependency chain:
product direction before asset decisions, asset legality before screenshot use,
environment before capture, players before tools, reliquary before enemy/ritual
tuning.
