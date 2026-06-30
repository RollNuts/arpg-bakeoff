# Unity Production Ownership

Status: proposed PR ownership plan.

## Scope

The project is Unity-first under the current repository rules. Split work by
production proof, not by engine bakeoff.

## PR Ownership

- PR-Product: product bible, scope, done criteria, and anti-copy rules.
- PR-Asset-Gate: asset ledger format, legal source shortlist, Maya/Meshy gate.
- PR-Unity-Setup: Unity version, package manifest, project settings, folders,
  scene stubs.
- PR-Design-Assets: `Assets/Design` docs for game, art, animation, audio, enemy,
  and boss design.
- PR-Player-Core: movement, jump, dodge, camera, lock-on scaffold.
- PR-Combat-Core: normal combo, heavy attack, parry, hit stop, hit reactions.
- PR-Color-System: color inventory, color layer, color drain, red/blue/purple
  skills.
- PR-Red-Theatre: dressed stage, color gates, save point, shortcut.
- PR-Enemies: masked actor, red dancer, stage executioner.
- PR-Boss: Red Duchess entrance, phases, color layer, defeat.
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
3. Unity-Setup
4. Design-Assets
5. Player-Core
6. Combat-Core
7. Color-System
8. Red-Theatre
9. Enemies
10. Boss
11. Capture

If multiple PRs are open, merge order should preserve this dependency chain:
product direction before asset decisions, package/project setup before scripts,
player/combat before enemy tuning, color system before exploration gates and
boss color-layer design.
