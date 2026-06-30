# Unreal Production Ownership

Status: proposed PR ownership plan.

## Scope

The project is Unreal-first. Split work by production proof, not by parallel
Unity/Unreal comparison.

## PR Ownership

- PR-Product: product bible, scope, done criteria, and anti-copy rules.
- PR-Asset-Gate: asset ledger format, legal source shortlist, Maya/Meshy gate.
- PR-Unreal-Setup: fresh Unreal project, input, camera scaffold, capture path.
- PR-Environment: dressed Sealing Temple test space, lighting, fog, materials,
  and screenshot proof.
- PR-Hero: swordfighter controller, animation states, camera/lock-on, VFX/SFX
  hooks.
- PR-Enemy: first two enemies with telegraphs, hit reactions, and death.
- PR-Boss: Sealing Guardian boss, entrance, HP UI, phase change, retry, defeat.
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
5. Hero
6. Enemy
7. Boss
8. Capture

If multiple PRs are open, merge order should preserve this dependency chain:
product direction before asset decisions, asset legality before screenshot use,
environment before combat capture, hero before enemy/boss tuning.
