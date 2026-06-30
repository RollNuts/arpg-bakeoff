# Video Analysis Tooling: 夜番の砦

Status: capture-analysis checklist for weapon-swap gameplay.

## Measurements

For every candidate gameplay clip, record:

- first readable weapon rack frame
- first pickup/swap frame
- first durability-state frame
- first weapon throw frame
- first embed frame
- first pull/recover frame
- first boss part reaction frame
- first frame where the hook is understandable without narration

## Reject Clip If

- the weapon on the ground is not visible
- pickup prompt is unreadable
- weapon swap takes too long
- thrown weapon does not read as physical
- embed/pull does not have a clear reaction
- boss part break is hidden by camera or particles
- lighting hides weapons or enemies

## Useful Free Tooling

- OBS for capture
- ffmpeg for frame extraction
- ImageMagick or Python/Pillow for contact sheets
- Unity `ScreenCapture` for deterministic screenshots

## Contact Sheet Requirement

Every visual PR should include a contact sheet with at least:

1. player idle/readability
2. weapon rack
3. pickup prompt
4. weapon throw
5. embed/recover
6. enemy posture/part reaction
7. boss or large target
8. improved frame after removing the most mock-looking area
