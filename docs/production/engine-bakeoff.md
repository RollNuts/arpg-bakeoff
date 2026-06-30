# Engine Bakeoff

Status: Unity-first production note for `夜番の砦`.

## Current Decision

Use Unity for the first vertical slice unless a specific blocker appears.

Reason:

- third-person character control can be built quickly
- physics overlaps and rigid-body style weapon interaction are straightforward
- editor tooling can generate weapon-rack and Wolf Forest test scenes
- local weapon pickup/drop/throw/embed can be iterated without a full content
  pipeline first

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

`ProjectSettings/ProjectVersion.txt` is the source of truth once created. Until
then, AGENTS.md requires assuming `2021.3 LTS` and marking that as an assumption.

## Package Rule

`Packages/manifest.json` is the package source of truth. No package beyond the
manifest may be added without an approval memo covering official docs, license,
alternatives, and removal method.
