# Character Pattern Cards

Status: active character direction for the solo fantasy ARPG.

The current product direction is
`docs/product/game-definition-solo-fantasy-arpg.md`.

Previous Threadlight and rugged weapon-first concepts are retained as
part-library evidence only. Do not adopt any old generated sheet wholesale as
the protagonist.

## Judgement Order

Before generation, modeling, rigging, or animation spend, judge in this order:

1. black silhouette at tiny size
2. rear three-quarter gameplay readability
3. grayscale value separation
4. weapon direction and facing
5. attack, dodge, guard, hit, and death pose readability
6. material identity
7. only then texture detail

## Protagonist Identity

One fixed unnamed swordfighter.

| Area | Requirement |
| --- | --- |
| Role | Lone swordfighter entering an ancient sealed kingdom. |
| Camera Read | Rear three-quarter third-person, not pure top-down. |
| Core Shape | Readable head/shoulders, cloak or torso value mark, obvious weapon line. |
| Material | Weathered metal, dark cloth/leather, pale sacred-light accent, restrained brass/stone details. |
| Animation | Deliberate footwork, readable windup, grounded dodge, heavy contact recovery. |
| Reject If | Generic horned dark knight, copied franchise costume, face-detail-first design, unreadable black blob, oversized clutter. |

## Weapon Family Cards

| Weapon | Silhouette Hook | Animation Identity | VFX/SFX Role | Reject If |
| --- | --- | --- | --- | --- |
| One-Handed Sword | Clean side blade line and compact stance. | Baseline attack timing, reliable recovery. | Bright steel core, small dust/spark contact. | Generic toy sword, hidden in body, too thin. |
| Greatsword | Blade mass wider/longer than torso. | Slow anticipation, committed sweep, strong recovery. | Larger hit stop, low thump, debris burst. | Anime slab copy, impossible grip, unreadable in camera. |
| Spear | Long forward line and clear point. | Spacing, thrust, retreat step. | Linear trail and sharp impact tick. | Vanishes in perspective, looks like a staff only. |
| Sword And Shield | Shield front plane plus short blade. | Guard, perfect guard, counter. | Heavy block ring, guard flash, short counter spark. | Shield hides facing, copied crest, invincible-looking silhouette. |

## First Enemy Cards

| Role | Concept | Silhouette Hook | Telegraph | Color/Value Role | Audio Cue | Reject If |
| --- | --- | --- | --- | --- | --- | --- |
| Small Fiend | Basic melee enemy. | Small hunched body, one bright claw or horn side. | Shoulder/claw pulls back, foot plants. | Dark body, pale attack edge. | Dry scrape into wet/cloth hit. | Generic zombie, unclear facing, instant lunge. |
| Shield Soldier | Teaches facing and side/back attacks. | Half-moon shield front, smaller rear body. | Shield raises, weapon arm draws. | Shield rim bright, body lower value. | Metal scrape, shield thud. | Omnidirectional block, player cannot read weak side. |
| Spear Dead Soldier | Spacing enemy. | Long spear point creates line. | Spear tip lowers then thrusts. | Pale spear tip, muted body. | Short inhale, point whistle. | Invisible tip, unfair instant poke. |
| Archer | Forces movement. | Bow arc and side stance. | Bow draw visible, ground mark at target. | Projectile brightest. | Bow creak, string snap. | Projectile same value as floor. |
| Spirit | Magic/altar enemy. | Floating torn-cloth mass, bright core. | Core pulses before dash/cast. | Cool light core, dark edges. | Breath/choir reverse. | Reads as fog only. |

## Boss Cards

| Boss | Product Role | Silhouette Hook | Telegraph Rule | Screenshot Requirement |
| --- | --- | --- | --- | --- |
| Sealing Guardian | First mastery check. | Tall stone/armor guardian with sealed chest light. | Weapon and chest light pulse before attack. | Small hero, large readable attack arc, altar/gate behind. |
| Forest Guardian | Area 2 spacing boss. | Root/stone beast with clear limb masses. | Roots glow before slam or vine line. | Green ruin identity, readable floor hazard. |
| Fortress Knight | Area 3 discipline boss. | Heavy shield/weapon knight with broad front plane. | Counter stance and shield angle are clear. | Strong metal silhouette, bridge or gate scale. |
| Altar Magus | Area 4 position boss. | Robed caster with orbiting seal shards. | Magic circles form before damage. | Cool magic circles visible without dark mush. |
| Seal King | Final boss. | Crowned sword/magic figure, not copied royalty trope. | Sword, magic, and phase-change tells are distinct. | Light/dark seal collapse sells finale. |

## Historical Concept Reuse

| Historical Asset | Keep As | Do Not Use As |
| --- | --- | --- |
| `h07-white-charcoal-judgement-axe-sheet.png` | Greatsword/boss impact mass reference. | Final hero direction. |
| `h02-black-iron-pincer-knight-sheet.png` | Elite or fortress enemy mass. | Main protagonist. |
| `h08-navy-lantern-threadbinder-sheet.png` | VFX/prop or spirit motif reference. | Current hero or Threadlight revival. |
| `h09-veiled-oath-relic-duelist-sheet.png` | Hood/cloak/relic weight part library. | Direct copied outfit or weapon. |
| `f01-ash-veil-halberd-matron-sheet.png` | Veil/crest value separation and polearm read. | Required heroine direction. |
| `f02-glass-moth-duelist-sheet.png` | Dodge/rogue silhouette study. | Ninja/fairy/cyber read. |
| `f03-bell-root-hex-huntress-sheet.png` | Bell/root enemy, prop, or area motif. | Main product identity. |

## Meshy/Maya Prompt Gate

New prompts must start from:

- solo third-person swordfighter protagonist
- four weapon family readability
- small fiend / shield soldier / Sealing Guardian
- ancient sealed kingdom material language
- Unreal gameplay-camera evidence

Do not start new prompts from Threadlight Surveyor, route tool, light-moth,
loom-gate, cooperative reliquary, or weapon-only fantasy.
