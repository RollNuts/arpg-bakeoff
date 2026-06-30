# Task Split

Status: first task map for `色喰いの王冠` commercial vertical-slice production.

Active source of truth:
`docs/product/game-definition-color-eater-crown.md`.

## Milestone 0: Repository And Review Gate

- [ ] M0-T01: Confirm branch protection and required `docs-gate` check.
- [ ] M0-T02: Convert this plan into issue backlog.
- [ ] M0-T03: Define PR order for product bible, asset gate, Unity project,
  player, color system, red theatre, enemies, boss, capture, and polish.
- [ ] M0-T04: Maintain required asset ledger format.

## Milestone 1: Product And Visual Direction

- [x] M1-T00: Set `色喰いの王冠` as the active product direction.
- [x] M1-T01: Define the color-drain dark fantasy ARPG product bible.
- [ ] M1-T02: Create the first commercial final-frame brief: Lucien, red
  theatre, color core, color drain, UI, and Red Duchess silhouette.
- [ ] M1-T03: Build a commercially legal asset shortlist for player, red theatre
  kit, enemies, boss, VFX, UI, audio, and animation.
- [ ] M1-T04: Create a visual mood board with licensed sources and rejection
  notes for "dark but vivid".
- [ ] M1-T05: Define the 30-second color-drain capture checklist.
- [ ] M1-T06: Create player/color silhouette sheets.
- [ ] M1-T07: Create the Red Theatre vertical-slice layout brief.
- [ ] M1-T08: Create the Red Duchess boss brief.

## Milestone 2: Unity Project And Scene Setup

- [ ] M2-T01: Add Unity project settings and package manifest, documenting Unity
  version and package approvals.
- [ ] M2-T02: Add `Assets/Design` source docs for game, art, animation, audio,
  enemy, and boss design.
- [ ] M2-T03: Add scene folders for Title, AtelierHub, RedTheatre, and
  Boss_RedDuchess.
- [ ] M2-T04: Add initial Red Theatre blockout with dressed commercial art
  direction placeholders, not gray boxes.
- [ ] M2-T05: Add title-screen art target evidence.
- [ ] M2-T06: Capture first screenshot evidence and improve at least one
  mock-looking area before completion.

## Milestone 3: Player And Color System

- [ ] M3-T01: Implement `PlayerController`: movement, jump, dodge, camera,
  lock-on hooks.
- [ ] M3-T02: Implement `PlayerCombat`: normal combo, heavy attack, parry,
  hitboxes, hit stop hooks.
- [ ] M3-T03: Implement `ColorInventory`: three color slots, stacking, switching,
  color gauge.
- [ ] M3-T04: Implement `ColorDrainSystem`: color layer break, drain-ready state,
  execution trigger, HP restore, color gain.
- [ ] M3-T05: Implement first color skills: red, blue, purple.
- [ ] M3-T06: Capture playable combat/color-drain evidence.

## Milestone 4: Enemies And Exploration

- [ ] M4-T01: Implement masked actor enemy with HP, color layer, telegraph, hit,
  drain, and death.
- [ ] M4-T02: Implement red dancer enemy.
- [ ] M4-T03: Implement stage executioner enemy.
- [ ] M4-T04: Implement red seal thread, blue memory platform, and purple
  illusion wall.
- [ ] M4-T05: Add HUD: HP, color slots, color gauge, enemy HP, enemy color layer,
  drain marker.
- [ ] M4-T06: Capture a 10-second playable red-theatre proof.

## Milestone 5: Red Duchess Boss Proof

- [ ] M5-T01: Build Red Theatre path: stage entrance, backstage, shortcut,
  color-gated side room, save point, boss arena.
- [ ] M5-T02: Add `緋幕の公爵夫人`: entrance, phase 1, phase 2, boss HP, boss
  color layer, red drain window, defeat.
- [ ] M5-T03: Add boss music and phase transition.
- [ ] M5-T04: Add reward: `血華`, theatre key, memory fragment, atelier return.
- [ ] M5-T05: Capture 30-second Steam-facing gameplay and five store-screenshot
  candidates.

## Milestone 6: Commercial Completion Roadmap

- [ ] M6-T01: Build `青硝子の記憶図書館`.
- [ ] M6-T02: Build `緑毒の温室宮`.
- [ ] M6-T03: Build `金箔の裁判宮`.
- [ ] M6-T04: Build `紫月の夢宮`.
- [ ] M6-T05: Build final `色喰いの王冠` area and endings.
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
