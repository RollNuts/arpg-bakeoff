# Engine Direction

Status: Unreal-first decision note.

## Decision

Unreal Engine is the default production path for the first commercial-quality
3D top-down cooperative fantasy action vertical slice.

Reason:

- stronger early leverage on lighting, materials, post process, VFX, cameras,
  animation presentation, and screenshot quality
- good fit for same-screen 3D top-down camera, readable props, and VFX-heavy
  sacred fire/reliquary presentation
- lower risk of returning to the old Unity mock visual language

## Non-Reuse Rule

- Do not copy the existing Unity mock scene, prefabs, scripts, or asset
  placement into the new vertical slice.
- Do not reuse the existing first-person Unreal hotel project as the ARPG base.
  It is the wrong camera, genre, input model, content style, and mood.
- Prior work may be used only as research history or failure evidence.

## Unreal Acceptance Evidence

The first Unreal production PR stack must produce:

- gameplay-distance screenshot showing players, reliquary, enemies, and fire
- close action/readability screenshot for attack, block, tool, or ritual
- top-down camera screenshot proving same-screen framing
- 10-second playable tool/objective capture
- asset ledger for visible assets
- note identifying at least one mock-looking area that was improved before
  completion

## Unity Exception Gate

Unity is allowed only with a written exception memo showing that it can reach
the same commercial screenshot, camera, and cooperation-readability bar faster.

The memo must include:

- screenshot evidence
- capture evidence
- asset ledger
- explanation of how it avoids the old mock style
- rollback plan if the visual bar is not met
