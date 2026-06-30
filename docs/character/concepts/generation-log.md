# Character Concept Generation Log

Status: record of generated 2D concept sheets before any Meshy/Maya spend.

Tool path:

- Built-in `image_gen` tool.
- Outputs copied from `$CODEX_HOME/generated_images/...` into
  `docs/character/concepts/`.

## IP Safety Notes

The user provided a hooded reference image for mood. It was not used as a direct
edit target. The derived H09 direction keeps only broad, generic ideas:

- hooded anonymity
- ritual weapon weight
- occult pilgrim mood
- heavy beads/charms as silhouette support

Explicitly rejected from H09:

- key-shaped weapon
- star charm
- black zipper coat
- school-uniform silhouette
- childlike proportions
- recognizable franchise character design

## Generated Sheets

| File | Prompt Direction | Current Verdict |
| --- | --- | --- |
| `h07-white-charcoal-judgement-axe-sheet.png` | Oversized-arm execution axe hero. | Strong backup: best impact/readability, less novel. |
| `h02-black-iron-pincer-knight-sheet.png` | Asymmetric pincer knight with shears. | Keep: useful for elite/alternate class. |
| `h08-navy-lantern-threadbinder-sheet.png` | Lantern and thick thread-loop trap hero. | Keep: novel but production-risky. |
| `h09-veiled-oath-relic-duelist-sheet.png` | Hooded relic duelist with broad reliquary greatblade. | Primary hero candidate. |
| `f01-ash-veil-halberd-matron-sheet.png` | Female halberd warrior with ash veil crest. | Primary heroine candidate. |
| `f02-glass-moth-duelist-sheet.png` | Female glass-moth rogue with crescent daggers. | Keep with caution: strong art, risky ninja/fairy read. |
| `f03-bell-root-hex-huntress-sheet.png` | Female bell-root occult hunter/summoner. | Strong alternate; could become heroine or elite enemy. |
| `concept-comparison-contact-sheet.png` | Combined overview of all generated sheets. | Used for visual triage. |
| `concept-silhouette-strip.png` | Cropped top silhouette strips in grayscale. | Used for tiny-readability triage. |

## Next Gate

Before Meshy preview:

1. Compare H09, F01, H07, and F03 at 64-128 px height.
2. Pick no more than two candidates for first Meshy preview.
3. For each selected candidate, create or request a cleaner 2D multi-view sheet
   with front/back/side/top-down views.
4. Run only Meshy preview/draft first.
5. Do not refine, HD texture, rig, or animate until the preview survives the
   game-camera test.
