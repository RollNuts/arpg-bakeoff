# Task Split

Status: first task map for solo commercial ARPG production review.

Active source of truth:
`docs/product/game-definition-solo-fantasy-arpg.md`.

## Milestone 0: Repository And Review Gate

- [ ] M0-T01: Confirm branch protection and required `docs-gate` check.
- [ ] M0-T02: Convert this plan into issue backlog.
- [ ] M0-T03: Define PR order for product bible, asset gate, engine setup, hero,
  combat, boss, capture, and Steam-facing polish.
- [ ] M0-T04: Add required asset ledger format.

## Milestone 1: Product And Visual Direction

- [x] M1-T00: Supersede Threadlight and cooperative Relic Runebound as active
  product directions.
- [x] M1-T01: Define the solo Steam 3D fantasy aRPG product bible.
- [ ] M1-T02: Create the first commercial final-frame brief: solo swordfighter,
  ancient temple, enemy telegraph, lock-on framing, boss landmark, UI, and VFX.
- [ ] M1-T03: Build a commercially legal asset shortlist for hero, enemy,
  temple kit, VFX, UI, and audio.
- [ ] M1-T04: Create a visual mood board with licensed sources and rejection
  notes.
- [ ] M1-T05: Define the 30-second Steam-facing capture checklist.
- [ ] M1-T06: Create protagonist and first enemy production sheets.
- [ ] M1-T07: Create the Sealing Temple area-one layout brief.
- [ ] M1-T08: Create the Sealing Guardian boss brief.

## Milestone 2: Unreal-First Vertical Slice Setup

- [ ] M2-T01: Create fresh Unreal project without copying the hotel project.
- [ ] M2-T02: Add legal asset ledger and initial approved asset import.
- [ ] M2-T03: Build a small dressed temple room with lighting, fog, stone
  material layers, and no graybox/default-sky accepted frame.
- [ ] M2-T04: Add third-person camera, lock-on, controller input, and camera
  collision/fade handling.
- [ ] M2-T05: Capture first screenshot evidence and reject mock-looking areas.
- [ ] M2-T06: Unity fallback requires an explicit exception memo proving faster
  commercial screenshot and combat-feel progress.

## Milestone 3: First Playable Hero

- [ ] M3-T01: Choose hero source: legal free/owned kitbash, approved paid asset,
  owned Meshy result, or one gated new generation.
- [ ] M3-T02: Implement idle, run, lock-on strafe, dodge, light attack, heavy
  attack, guard, hit, heal, death, and interact.
- [ ] M3-T03: Add hit stop, weapon trail, contact sparks/dust, impact camera
  impulse, and heavy SFX pass.
- [ ] M3-T04: Capture gameplay-distance, close-attack, lock-on, and dodge
  evidence.

## Milestone 4: First Combat Slice

- [ ] M4-T01: Add small fiend enemy with telegraph, attack, hit reaction, death,
  and audio.
- [ ] M4-T02: Add shield soldier enemy with guard/facing read and counterplay.
- [ ] M4-T03: Add HP, stamina, heal count, equipped weapon, objective, and item
  pickup UI in the final visual direction.
- [ ] M4-T04: Add altar checkpoint, death, and fast retry loop.
- [ ] M4-T05: Capture a 10-second playable combat proof.

## Milestone 5: First Boss And Area-One Proof

- [ ] M5-T01: Build Sealing Temple path: entrance, locked path, shortcut, altar,
  enemy placement, and boss arena.
- [ ] M5-T02: Add Sealing Guardian boss: entrance, name plate, HP bar,
  telegraphs, phase change, BGM, defeat reward, and retry.
- [ ] M5-T03: Add victory light-return beat for the first area.
- [ ] M5-T04: Capture 30-second Steam-facing gameplay and five store-screenshot
  candidates.

## Milestone 6: Full Game Roadmap

- [ ] M6-T01: Area 2: Sunken Forest Ruins.
- [ ] M6-T02: Area 3: Ruined Fort.
- [ ] M6-T03: Area 4: Underground Altar.
- [ ] M6-T04: Area 5: White Sanctuary.
- [ ] M6-T05: Save, settings, localization, achievements, performance, and
  build/release checklist.

## Work Rules

- One PR should target one task or one tightly coupled task pair.
- Do not add a new engine project and a large asset pack in the same PR.
- Do not mix market research, engine setup, gameplay, and art import in one PR.
- Every visible asset PR needs source/license notes.
- Every visual PR needs screenshot evidence.
- Every gameplay PR needs a playtest note or capture.
- If the screen looks like a prototype, fix presentation before adding scope.
