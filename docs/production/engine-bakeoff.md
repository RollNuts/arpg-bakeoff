# Engine Direction

Status: Unity-first planning note.

## Decision

This repository is treated as a Unity project by AGENTS.md. Until
`ProjectSettings/ProjectVersion.txt` exists, Unity version is assumed to be
`2021.3 LTS`.

The first `色喰いの王冠` vertical slice should therefore be planned as a Unity
project unless a later approved exception memo replaces the engine.

## Current Engine Facts

- `ProjectSettings/ProjectVersion.txt` is missing.
- `Packages/manifest.json` is missing.
- No `Assets/**/*.asmdef` files exist.
- `Assets/Resources` exists, but no production assets are present in this
  planning branch.

## Non-Reuse Rule

- Do not copy the existing old Unity mock scene, prefabs, scripts, or asset
  placement into the new vertical slice.
- Do not reuse the existing first-person Unreal hotel project as the ARPG base.
- Prior work may be used only as research history or failure evidence.

## Unity Acceptance Evidence

The first Unity production PR stack must produce:

- project version and package manifest
- gameplay-distance screenshot showing Lucien, red theatre, enemy, and color
  state
- close action/readability screenshot for color drain
- 10-second playable movement/combat/color-drain capture
- asset ledger for visible assets
- note identifying at least one mock-looking area that was improved before
  completion

## Package Rule

No package may be added without an approval memo covering:

- official documentation
- license
- alternative options
- removal method
- why the package is required for the vertical slice
