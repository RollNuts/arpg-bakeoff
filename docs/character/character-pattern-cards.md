# Character Pattern Cards

Status: active character direction for the cooperative top-down fantasy action
game.

The current product direction is
`docs/product/game-definition-relic-runebound.md`.

Previous Threadlight and solo-swordfighter concepts are retained as part-library
evidence only. Do not adopt any old generated sheet wholesale as the player
character.

## Judgement Order

Before generation, modeling, rigging, or animation spend, judge in this order:

1. black silhouette at tiny size
2. oblique top-down gameplay readability
3. grayscale value separation
4. held tool direction and facing
5. attack, carry, block, light, chant, hit, and death pose readability
6. material identity
7. only then texture detail

## Pilgrim Identity

Players are a small shrine expedition team, not permanent classes.

| Area | Requirement |
| --- | --- |
| Role | Pilgrim/explorer carrying tools to escort and seal the reliquary. |
| Camera Read | 3D top-down oblique camera, small but role-readable. |
| Core Shape | Readable head/shoulders, compact body, obvious carried tool line. |
| Material | Weathered cloth/leather, simple metal, sacred-light accent, restrained brass/stone details. |
| Animation | Quick footwork, readable pickup/drop, tool-ready stance, hit/death clarity. |
| Reject If | Generic armored hero, copied franchise costume, face-detail-first design, unreadable dark blob, oversized clutter. |

## Tool Role Cards

| Tool | Silhouette Hook | Animation Identity | VFX/SFX Role | Reject If |
| --- | --- | --- | --- | --- |
| Sword | Clean side blade line. | Quick clear and vine/membrane cuts. | Bright small slash, short hit stop. | Hidden in body, too thin, too heroic/class-based. |
| Great Shield | Large front plane. | Hold line, block charge, protect reliquary. | Heavy block ring and sparks. | Hides facing or looks invincible from all sides. |
| Axe | Head mass wider than hand/torso. | Slow breaker and heavy stagger. | Wood/stone debris, deep hit. | Generic barbarian read, tiny axe. |
| Bow | Long horizontal/diagonal read. | Aim at chains, bells, cores, distant enemies. | Thin but bright shot line. | Projectile disappears in environment. |
| Torch | Flame point and warm light radius. | Light braziers, repel spirits, carry risk. | Fire loop, flare, warm floor circle. | Reads as only a weapon or UI glow. |
| Holy Bell | Hand bell or shoulder bell shape. | Lure/stun sound-sensitive enemies. | Expanding sound ring, clear tone. | Looks like generic magic orb. |
| Ritual Implement | Staff/censer/tablet silhouette. | Vulnerable chanting and seal progress. | Chant pulse, blue-white seal marks. | Looks like combat weapon first. |

## First Enemy Cards

| Role | Concept | Silhouette Hook | Telegraph | Color/Value Role | Audio Cue | Reject If |
| --- | --- | --- | --- | --- | --- | --- |
| Imp | Basic small pressure enemy. | Small hunched body, one bright claw/horn side. | Shoulder/claw pulls back, foot plants. | Dark body, pale attack edge. | Dry scrape into body hit. | Generic zombie, unclear facing, instant lunge. |
| Spirit | Sacred-fire pressure enemy. | Floating torn-cloth mass, bright core. | Core pulses before dash/cast. | Cool light core, dark edges. | Breath/choir reverse. | Reads as fog only. |
| Blind Guardian | Large sound-reactive pressure. | Heavy broad body, blind head, forward charge mass. | Head lowers, sound ring or foot brace appears. | Dark mass, warm/cool weak cue. | Low inhale, stone/metal charge. | Just a bigger imp, unclear lure response. |

## Historical Concept Reuse

| Historical Asset | Keep As | Do Not Use As |
| --- | --- | --- |
| `h07-white-charcoal-judgement-axe-sheet.png` | Axe impact or guardian mass reference. | Main pilgrim direction. |
| `h02-black-iron-pincer-knight-sheet.png` | Guardian/elite mass reference. | Player silhouette. |
| `h08-navy-lantern-threadbinder-sheet.png` | Bell/ritual/VFX motif reference. | Threadlight revival. |
| `h09-veiled-oath-relic-duelist-sheet.png` | Hood/cloak/relic weight part library. | Direct outfit or weapon. |
| `f01-ash-veil-halberd-matron-sheet.png` | Veil/crest value separation and polearm read. | Required heroine direction. |
| `f02-glass-moth-duelist-sheet.png` | Dodge silhouette study. | Ninja/fairy/cyber read. |
| `f03-bell-root-hex-huntress-sheet.png` | Bell/root enemy, prop, or area motif. | Main product identity. |

## Meshy/Maya Prompt Gate

New prompts must start from:

- cooperative top-down pilgrim team
- visible carried tools
- holy reliquary and tool stand
- imp / spirit / blind guardian
- ancient sealed temple material language
- gameplay-camera evidence

Do not start new prompts from Threadlight Surveyor, solo-only swordfighter,
five-boss ARPG, or weapon-only fantasy.
