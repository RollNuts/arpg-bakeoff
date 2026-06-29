# Engine Bakeoff

Status: proposed plan.

## Goal

Pick the engine that produces a commercial-looking top-down ARPG prototype
fastest without carrying over the old Unity mock or the existing first-person
Unreal hotel project.

## Candidates

| Candidate | Use | Risk |
| --- | --- | --- |
| Unity fresh slice | Existing code knowledge and fast C# iteration. | Old mock inertia; visual ceiling may stay low. |
| Unreal 5.8 fresh slice | Stronger out-of-box lighting, materials, camera, post process. | Gameplay setup may delay proof. |
| Existing Unreal hotel project | Reference only. | Wrong genre, camera, input, content, and mood. Do not reuse as ARPG base. |

## Bakeoff Rules

- No new Maya/Meshy/API spend.
- No existing Unity scene copy.
- No existing hotel project copy.
- Start from the same design brief and same free/owned asset candidates.
- Produce comparable evidence:
  - gameplay-distance screenshot
  - close attack/readability screenshot
  - 10-second movement/attack capture if possible
  - asset/source ledger

## Decision Gate

Choose Unreal only if it makes the same hero/combat target materially more
commercial within one day of work.

Choose Unity only if it reaches playable feel and screenshot quality faster
without returning to the old mock style.

