# Task Split

Status: first task map for `夜番の砦` commercial vertical-slice production.

Active source of truth:
`docs/product/game-definition-nightwatch-fortress.md`.

## Milestone 0: Repository And Review Gate

- [ ] M0-T01: Confirm branch protection and required `docs-gate` check.
- [ ] M0-T02: Convert this plan into issue backlog.
- [ ] M0-T03: Define PR order for product bible, asset gate, Unity project,
  player, weapon system, Wolf Forest, enemies, Garm, capture, and polish.
- [ ] M0-T04: Maintain required asset ledger format.
- [ ] M0-T05: Close or supersede PRs and branches targeting older product
  directions before merging new implementation.

## Milestone 1: Product And Visual Direction

- [x] M1-T00: Set `夜番の砦` as the active product direction.
- [x] M1-T01: Define the local-weapon night-hunter ARPG product bible.
- [ ] M1-T02: Create the first commercial final-frame brief: nightwatch player,
  Wolf Forest, weapon rack, thrown spear, torch, and Garm silhouette.
- [ ] M1-T03: Build a commercially legal asset shortlist for player, weapons,
  Wolf Forest kit, enemies, Garm, VFX, UI, audio, and animation.
- [ ] M1-T04: Create a visual mood board with licensed sources and rejection
  notes for "night fantasy but not gray".
- [ ] M1-T05: Define the 30-second local-weapon capture checklist.
- [ ] M1-T06: Create player weapon-silhouette sheets.
- [ ] M1-T07: Create Wolf Forest vertical-slice layout brief.
- [ ] M1-T08: Create Garm boss brief.

## Milestone 2: Engine Spike And Scene Setup

- [ ] M2-T01: Add Unity project settings and package manifest, documenting Unity
  version and package approvals.
- [ ] M2-T01B: Add Unreal visual-spike project, launch runners, and run the
  `狼森` first-screen builder against UE 5.8.
- [ ] M2-T02: Add `Assets/Design` source docs for game, art, animation, audio,
  enemy, boss, and weapon design.
- [ ] M2-T03: Add scene folders for Title, NightwatchFort, WolfForest, and
  Boss_Garm.
- [ ] M2-T04: Add initial Wolf Forest scene with dressed commercial art
  direction placeholders, not gray boxes.
- [ ] M2-T05: Add title-screen art target evidence.
- [ ] M2-T06: Capture first screenshot evidence and improve at least one
  mock-looking area before completion.

## Milestone 3: Player And Local Weapon System

- [ ] M3-T01: Implement `PlayerController`: movement, jump, dodge, camera,
  lock-on hooks.
- [ ] M3-T02: Implement `PlayerCombat`: normal attack, heavy attack, guard,
  parry, hitboxes, hit stop hooks.
- [ ] M3-T03: Implement `WeaponInstance`: type, durability state, damage,
  posture damage, throw rules, embed rules.
- [ ] M3-T04: Implement `WeaponInventory`: two equipped slots, pickup, swap,
  drop, throw, recover.
- [ ] M3-T05: Implement `WeaponPickup`: ground/rack prompt, comparison text,
  fast pickup flow.
- [ ] M3-T06: Implement durability: fresh, normal, chipped, near-broken, broken.
- [ ] M3-T07: Implement first weapon actions: sword, spear, great hammer, bow,
  torch, and shield hooks.
- [ ] M3-T08: Capture playable evidence showing pickup, swap, throw, break, and
  recover within 30 seconds.

## Milestone 4: Enemies And Wolf Forest

- [ ] M4-T01: Implement small wolf: quick lunge, pack pressure, hit/death.
- [ ] M4-T02: Implement horned beast: telegraphed charge stopped by spear.
- [ ] M4-T03: Implement goblin: carries and drops usable weapon.
- [ ] M4-T04: Implement shield goblin: frontal defense, posture/back counterplay.
- [ ] M4-T05: Implement Wolf Forest route: fort exit, hunter shack, stream,
  fallen tree shortcut, weapon rack, torch stand, boss den gate.
- [ ] M4-T06: Add HUD: HP, stamina, equipped weapon, sub weapon, durability,
  pickup prompt, enemy HP, posture, lock-on.
- [ ] M4-T07: Capture a 10-second playable Wolf Forest proof.

## Milestone 5: Garm Boss Proof

- [ ] M5-T01: Build Garm arena with weapon rack, throwing spears, hammer, shield,
  arrow bundle, torch, broken cart, and small heal.
- [ ] M5-T02: Add `大狼ガルム`: entrance, phase 1, phase 2, boss HP, part HP,
  posture, defeat.
- [ ] M5-T03: Add spear leg embed and pull-out reaction.
- [ ] M5-T04: Add hammer head stagger.
- [ ] M5-T05: Add tail break that weakens spin/tail attacks.
- [ ] M5-T06: Add near-broken weapon throw weak-point window.
- [ ] M5-T07: Add boss music and morning-return defeat beat.
- [ ] M5-T08: Capture 30-second Steam-facing gameplay and five store-screenshot
  candidates.

## Milestone 6: Commercial Completion Roadmap

- [ ] M6-T01: Build `鉄鉱山`.
- [ ] M6-T02: Build `沼の砦`.
- [ ] M6-T03: Build `月見の古城`.
- [ ] M6-T04: Build `王都外壁`.
- [ ] M6-T05: Build final `夜王獣` encounter.
- [ ] M6-T06: Save/settings/localization/achievements/performance checklist.
- [ ] M6-T07: Steam page asset checklist.

## Work Rules

- One PR should target one task or one tightly coupled task pair.
- Do not add a new engine project and a large asset pack in the same PR.
- Do not mix market research, engine setup, gameplay, and art import in one PR.
- Every visible asset PR needs source/license notes.
- Every visual PR needs screenshot evidence.
- Every gameplay PR needs a playtest note or capture.
- If the screen looks gray, generic, or prototype-like, fix presentation before
  adding scope.
- Never implement this as a generic sword game first and local weapons later;
  weapon pickup/swap/throw must appear in the first playable loop.
