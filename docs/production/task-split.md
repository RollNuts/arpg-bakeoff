# Task Split

Status: first task map for cooperative commercial fantasy action production.

Active source of truth:
`docs/product/game-definition-relic-runebound.md`.

## Milestone 0: Repository And Review Gate

- [ ] M0-T01: Confirm branch protection and required `docs-gate` check.
- [ ] M0-T02: Convert this plan into issue backlog.
- [ ] M0-T03: Define PR order for product bible, asset gate, engine setup,
  camera/control, reliquary, tools, enemies, ritual, capture, and polish.
- [ ] M0-T04: Maintain required asset ledger format.

## Milestone 1: Product And Visual Direction

- [x] M1-T00: Restore `Relic Runebound` / `聖櫃の巡礼隊` as the active product
  direction.
- [x] M1-T01: Define the cooperative top-down fantasy action product bible.
- [ ] M1-T02: Create the first commercial final-frame brief: two pilgrims,
  reliquary, sacred fire, weapon stand, incoming imps/spirits, readable temple.
- [ ] M1-T03: Build a commercially legal asset shortlist for pilgrims, tools,
  reliquary, temple kit, enemies, VFX, UI, and audio.
- [ ] M1-T04: Create a visual mood board with licensed sources and rejection
  notes.
- [ ] M1-T05: Define the 30-second cooperative capture checklist.
- [ ] M1-T06: Create pilgrim/tool silhouette sheets.
- [ ] M1-T07: Create the Sealing Temple one-stage layout brief.
- [ ] M1-T08: Create the Blind Guardian and final ritual briefs.

## Milestone 2: Unreal-First Vertical Slice Setup

- [ ] M2-T01: Create fresh Unreal project without copying the hotel project.
- [ ] M2-T02: Add legal asset ledger and initial approved asset import.
- [ ] M2-T03: Build a small dressed temple entrance with lighting, fog, stone
  material layers, weapon stand, reliquary, and no graybox/default-sky accepted
  frame.
- [ ] M2-T04: Add 3D top-down oblique camera with same-screen player framing.
- [ ] M2-T05: Add two local players plus solo test control.
- [ ] M2-T06: Capture first screenshot evidence and improve at least one
  mock-looking area before completion.

## Milestone 3: Core Cooperation Slice

- [ ] M3-T01: Implement pickup/drop/hold tool system.
- [ ] M3-T02: Implement sword, shield, axe, torch, and ritual implement basics.
- [ ] M3-T03: Add holy reliquary durability, movement/activation, and runaway
  gauge.
- [ ] M3-T04: Add sacred fire range, torch lighting, and visible safety zones.
- [ ] M3-T05: Capture gameplay-distance and close-action evidence.

## Milestone 4: Enemy And Pressure Slice

- [ ] M4-T01: Add imp enemy with reliquary/player targeting, hit reaction, death,
  and audio.
- [ ] M4-T02: Add spirit enemy that reacts to sacred fire, torch, and holy bell.
- [ ] M4-T03: Add closed gate/blocker solved by axe or alternate route.
- [ ] M4-T04: Add HP/durability/runaway/fire/tool UI in the final visual
  direction.
- [ ] M4-T05: Capture a 10-second playable cooperation proof.

## Milestone 5: First Stage Proof

- [ ] M5-T01: Build Sealing Temple path: entrance, closed gate, mist corridor,
  bell courtyard, broken bridge, altar.
- [ ] M5-T02: Add blind guardian: sound response, charge, shield block, bell
  lure, and inefficient kill option.
- [ ] M5-T03: Add final ritual: light braziers, chant, suppress surge, success
  and failure.
- [ ] M5-T04: Add result screen and fast retry.
- [ ] M5-T05: Capture 30-second Steam-facing gameplay and five store-screenshot
  candidates.

## Milestone 6: Commercial Completion Roadmap

- [ ] M6-T01: Tune solo clear path without making co-op trivial.
- [ ] M6-T02: Tune 2-player main balance.
- [ ] M6-T03: Add 3-4 player scaling hooks.
- [ ] M6-T04: Save/settings/localization/achievements/performance checklist.
- [ ] M6-T05: Steam page asset checklist.

## Work Rules

- One PR should target one task or one tightly coupled task pair.
- Do not add a new engine project and a large asset pack in the same PR.
- Do not mix market research, engine setup, gameplay, and art import in one PR.
- Every visible asset PR needs source/license notes.
- Every visual PR needs screenshot evidence.
- Every gameplay PR needs a playtest note or capture.
- If the screen looks like a prototype, fix presentation before adding scope.
