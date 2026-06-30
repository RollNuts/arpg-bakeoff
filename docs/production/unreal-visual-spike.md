# Unreal Visual Spike

Status: proposed and scaffolded after the engine reassessment on 2026-06-30.

## Decision

For `夜番の砦`, Unreal Engine deserves a direct visual spike before more Unity
implementation work.

Reason: the current product goal is a Steam-facing 3D dark fantasy ARPG where a
single screenshot must sell night lighting, wet materials, fog, a heroic hunter
silhouette, readable weapon pickups, and a huge wolf boss. Unreal's default
renderer, lighting workflow, material response, camera tools, and editor
environment are better aligned with that visual target than continuing to push a
code-generated Unity primitive scene.

This is not approval to throw away the Unity work. The Unity branch remains a
useful gameplay-system scaffold. The next decision should be based on rendered
evidence from the same `狼森` beat in Unreal.

## Local Engine

Detected engine:

`/Users/murakaminaoya/Epic Games/UE_5.8`

Editor executable:

`/Users/murakaminaoya/Epic Games/UE_5.8/Engine/Binaries/Mac/UnrealEditor`

Command executable:

`/Users/murakaminaoya/Epic Games/UE_5.8/Engine/Binaries/Mac/UnrealEditor-Cmd`

## Spike Art Target

Use:

`docs/art/nightwatch/wolf-forest-visual-target-v1.png`

The Unreal spike must prove the same first-read:

- lone leather-clad night hunter
- visible pickup spear near the player
- weapon rack with alternate weapons
- moonlit wet forest clearing with warm torches, stream, shack, fog, and trees
- large readable original night wolf with leg target and embedded spear cue
- small enemy pressure without clutter

## Project

Project file:

`Unreal/NightwatchFortress/NightwatchFortress.uproject`

Scene builder:

`Unreal/NightwatchFortress/Scripts/build_wolf_forest_visual_spike.py`

CLI runner:

```bash
bash Unreal/NightwatchFortress/Scripts/run_wolf_forest_visual_spike.sh
```

Manual editor runner:

```bash
bash Unreal/NightwatchFortress/Scripts/open_nightwatch_unreal_editor.sh
```

The CLI runner uses `UnrealEditor-Cmd`, writes its absolute log to
`local-evidence/nightwatch_unreal_spike_abs.log`, and passes extra arguments
through to Unreal. The manual editor runner opens `/Game/Maps/WolfForestVisualSpike`
by default so the first visual pass can be inspected immediately.

## Pass Gate

Unreal becomes the primary production engine only if the spike produces a
captured image that beats the current Unity generated scene on:

- lighting depth
- wet ground/material response
- night forest atmosphere
- player and weapon readability
- Garm silhouette
- time-to-polished-screenshot

If the spike cannot be generated or captured locally, the decision remains open
and no Unity work should be deleted.

## Current Verification Status

The project scaffold, launch runners, Python scene builder, generated materials,
and `/Game/Maps/WolfForestVisualSpike` map asset are present.

Observed from this Codex shell:

- `UnrealEditor-Cmd -help -stdout -FullStdOutLogOutput` did not return within
  60 seconds and was interrupted.
- Running the project with `-run=pythonscript` also did not create a log or
  generated map before interruption.
- Re-running from the engine binary directory with `-abslog`, `-nosound`, and
  `-nullrhi` still did not produce a project log before interruption.
- Older local UE logs under the same UE 5.8 install show that the Python
  commandlet can reach script execution on this machine. That makes the current
  blocker a launch/project-startup issue, not a reason to reject Unreal.
- The launch runner now reaches Python, builds `/Game/Maps/WolfForestVisualSpike`,
  and exits with `Success - 0 error(s), 0 warning(s)`.
- A macOS `screencapture` attempt after opening the editor produced a black
  3840x2160 image, so it is not accepted as visual evidence.

This means the Unreal setup is no longer blocked at commandlet execution.
The engine decision is still not complete. The next required step is to open the
generated map in the local Unreal Editor UI and capture the resulting viewport
from an actual visible editor/game window.

## Next Visual Proof

Do not count this spike as passed until one of these exists:

- a viewport screenshot of `/Game/Maps/WolfForestVisualSpike`
- a render/capture generated from the map
- a failure log that explains why UE 5.8 cannot load this project locally

The screenshot must be judged against `docs/art/nightwatch/wolf-forest-visual-target-v1.png`.
If it still reads as primitive placeholder art, fix at least one visible issue
before asking for the engine decision.
