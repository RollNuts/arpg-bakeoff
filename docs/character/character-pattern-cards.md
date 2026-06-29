# Character Pattern Cards

Status: divergent character concept set. Use this before spending Meshy/API
credits or polishing the current procedural hero.

## Why This Exists

The current Phase 1 character is not worth polishing as the final direction.
Before generating or modeling, compare several readable silhouettes at gameplay
camera distance. Reject weak patterns early.

Judgement order:

1. black silhouette at tiny size
2. grayscale value separation
3. weapon/readability from top-down
4. attack pose and telegraph
5. material identity
6. only then texture detail

## Hero Pattern Cards

| ID | Concept | Silhouette Hook | Weapon | Material/Value Bands | Animation Identity | VFX Role | Reject If |
| --- | --- | --- | --- | --- | --- | --- | --- |
| H01 | Lantern-Coffin Pilgrim | Tall coffin box on back, one-shoulder cloak | Hooked spear with candle head | Black cloth, dark wood, dull gold, bright face area | Heavy steps, flame jumps only on attack | Amber; cleanse/heal | Angel wings, cross overload, generic paladin |
| H02 | Black-Iron Pincer Knight | Asymmetric huge shoulder pincers | One-handed great shears plus short shield blade | Black iron, rust red, white scar lines | Side-stepping, opens wide before clamping | Red-black; bind/bleed | Literal crab/insect, robot read |
| H03 | Ash-Glass Scout | Slim body, broken glass blade-fan on back | Reverse-grip twin daggers | Gray leather, transparent glass, silver edges | Low sliding motion, afterimage shatters after attack | Pale blue; dodge/critical | Ninja costume, cyber glow |
| H04 | Mud-Crown Hexer | Huge clay crown, round body mass | Bone staff and hanging jar | Dry clay, bone white, black cords | Swaying chant, jar lags behind body | Green-brown; poison/summon | Real-world tribal mimicry, tiny symbols |
| H05 | Silver-Needle Execution Medic | Long beak mask, needle bundle on back | Telescoping injection spear | Black leather, dull silver, dirty white cloth | Small footwork, body becomes a straight thrust line | Sick yellow-green; weaken/drain | Direct plague doctor copy, medical clutter |
| H06 | Star-Eater Chain Monk | Circular back-chain halo, small head | Weighted chain ring | Black cloth, bronze, sparse white star dots | Constant visible circular orbit | Deep purple; pull/area control | Space wizard, zodiac ornament spam |
| H07 | White-Charcoal Judgement Axe | One giant arm, axe head wider than shoulders | One-sided execution axe | Charcoal body, white ash cracks, dark red cloth | Long charge, kneels after slam | White ash; stun/shatter | Barbarian cliche, muscle-only design |
| H08 | Navy-Lantern Threadbinder | Floating small lantern overhead, threads outward | Thread spool ring and fingertip blades | Navy cloth, black lacquer, pale lantern white | Body stays calm; threads move first | Blue-white; traps/remote cuts | Puppet-master cliche, invisible thin threads |

## Enemy Pattern Cards

| Role | Concept | Top-Down Silhouette Hook | Telegraph | Color/Value Role | Audio Cue | Reject If |
| --- | --- | --- | --- | --- | --- | --- |
| Fodder | Soot-Split Crawler | Small black teardrop, one long claw side | Claw side glows pale and half-steps | Low value body, claw marks facing | Dry claw scrape | Generic zombie, detail noise |
| Charger | Spineback Rammer | Thick triangle head and straight back-spine | Drops head, red line shadow appears | Dark red mid-value, high-contrast head | Low inhale into burst | Literal bull/boar, unreadable curved charge |
| Ranged | Lamp-Eye Shellgun | Round body plus one long arm cannon | Cannon tip point-light, impact circle appears | Cold blue-white, projectile brightest | Short glass pluck | Human archer, bullet same value as body |
| Summoner | Womb-Bell Conductor | Bell robe with small satellite shards | Shards stop spinning, summon sigil appears | Purple mid-value, pale gold sigil | Distant bell, reversed whisper | Wizard hat, unclear summon point |
| Tank | Black-Shield Gravekeeper | Huge half-moon front shield, tiny rear legs | Shield rim lights, front cone hardens | Black shield, bright metal rim | Dull metal scrape | Omnidirectional invincible read, unclear shield facing |
| Elite | Twin-Blade Shadow Priest | Thin cross shape, long blade sleeves left/right | Sleeves open, cross slash range appears | Black plus green poison light, bright blade tips | Cloth snap into metal hit | Ninja/reaper copy, instant attack |
| Miniboss | Furnace-Back Execution Bug | Large oval body, glowing back furnace, axe legs | Furnace brightens in three stages, axe legs lift | Black body, orange furnace danger meter | Furnace hum, steam vent | Just a bigger fodder, hidden weak point |
| Boss | Abyssal Crown Tree | Central crown trunk, radial root arms | Each root pulses white, then tears floor | Low-value trunk, white crown, red-black attack roots | Heartbeat plus heavy wood split | Generic tentacle boss, full-screen unreadable telegraphs |

## First Three Hero Candidates

These three are best for an early Meshy/Maya preview round because their
silhouettes should survive top-down camera distance.

### H02 Black-Iron Pincer Knight

Use if the game wants brutal melee identity.

Pass condition:

- pincer shoulder and shears read in a 96 px thumbnail
- attack telegraph can open/close clearly
- body does not become a crab/robot

### H07 White-Charcoal Judgement Axe

Use if the game wants heavy hit-stop and clear impact.

Pass condition:

- giant arm and axe head read as one bold silhouette
- white ash cracks separate hero from floor
- attack anticipation is readable in a still frame

### H08 Navy-Lantern Threadbinder

Use if the game wants a more unique hook than a knight.

Pass condition:

- floating lantern and thread field remain visible without becoming noise
- thread attacks are thick enough to read
- body stays distinguishable from trap/VFX layer

## First Enemy Pack

Use these for the first 30-second slice because they create readable combat
roles without needing many assets.

1. `Soot-Split Crawler`: fodder; teaches basic hit/death.
2. `Spineback Rammer`: charger; creates dodge pressure.
3. `Black-Shield Gravekeeper`: tank; teaches facing/positioning.
4. `Womb-Bell Conductor`: summoner; creates priority target.
5. `Furnace-Back Execution Bug`: miniboss; creates trailer frame.

Do not add all eight enemy patterns at once. Five is already enough for the
first enemy readability test.

## Meshy Preview Prompt Patterns

These prompts are for preview only. Do not run refine, HD texture, rig, or
animation until a preview passes the top-down thumbnail test.

### Hero Preview: Black-Iron Pincer Knight

```text
dark fantasy top-down ARPG hero character, full body, centered, neutral A-pose,
asymmetric black iron pincer knight, one huge shoulder pincer silhouette,
one-handed great shears weapon, short shield blade, oversized gauntlets and
boots, rust red cloth accents, pale scar edge lines, stylized realistic game
character, clean separate armor shapes, strong readable silhouette for
isometric camera, Maya-ready 3D asset
```

Reject:

```text
no literal crab body, no robot armor, no tiny scissors, no hidden weapon, no
long cape hiding legs, no excessive spikes, no merged hands, no extra arms, no
realistic face focus, no gore
```

Maya cleanup expected:

- separate shears, shield blade, shoulders, body, and cloth
- thicken the shears so they read from top-down
- reduce tiny armor shards
- add clear top-facing value bands

### Hero Preview: White-Charcoal Judgement Axe

```text
dark fantasy top-down ARPG hero character, full body, centered, neutral A-pose,
white-charcoal execution axe warrior, one oversized arm, huge one-sided axe
head wider than shoulders, charcoal black body, white ash cracks, dark red
cloth, heavy readable silhouette, stylized realistic proportions, broad upper
body, game-ready 3D character, Maya-ready asset
```

Reject:

```text
no generic barbarian, no bodybuilder focus, no tiny axe, no symmetrical normal
arms, no horned viking look, no long fur cape, no fused weapon hand, no gore
```

Maya cleanup expected:

- separate axe mesh and hand socket
- exaggerate axe top plane and white cracks
- simplify muscles into readable armor/body masses
- pose-test charge, impact, and recovery silhouette

### Hero Preview: Navy-Lantern Threadbinder

```text
dark fantasy top-down ARPG hero character, full body, centered, neutral A-pose,
navy lantern threadbinder, small pale lantern floating above head, dark navy
cloth, black lacquer armor pieces, visible thick magical thread loops around
hands, compact body silhouette, finger blade shapes, stylized game character,
readable from isometric camera, Maya-ready 3D asset
```

Reject:

```text
no puppet master cliche, no tiny invisible threads, no huge robe blob, no
multiple dolls, no anime school outfit, no cyber wires, no wings, no face detail
focus
```

Maya cleanup expected:

- make thread loops separate, thick, and optional
- lantern must stay above head without hiding body
- split cloth layers so legs and facing remain clear
- keep VFX/trap geometry separate from body mesh

### Enemy Preview: Soot-Split Crawler

```text
dark top-down ARPG fodder enemy, small soot-black crawling creature, teardrop
body silhouette, one side has one long pale claw, hunched low stance, simple
large forms, readable facing direction from top-down, dark fantasy game enemy,
Maya-ready 3D model
```

Reject:

```text
no generic zombie, no exposed gore, no many tiny fingers, no realistic human
face, no fully black silhouette, no thin unreadable claw
```

### Enemy Preview: Spineback Rammer

```text
dark top-down ARPG charger enemy, thick triangular head, straight spine ridge
on back, compact heavy body, dark red hide, high contrast head plate, low
aggressive stance, readable charging silhouette, stylized dark fantasy creature,
Maya-ready 3D asset
```

Reject:

```text
no literal bull, no boar copy, no realistic animal, no curved unreadable horns,
no thin legs, no cluttered spikes
```

### Enemy Preview: Black-Shield Gravekeeper

```text
dark top-down ARPG shield tank enemy, huge half-moon black shield on front,
small legs visible behind shield, gravekeeper armor, bright worn metal rim,
clear front-facing silhouette, dark fantasy dungeon enemy, stylized game-ready
3D character, Maya-ready asset
```

Reject:

```text
no full round turtle shell, no hero knight read, no shield covering entire body
from all angles, no tiny shield, no ornate unreadable engraving
```

## Preview Spend Rules

- One preview per pattern per review round.
- No refine unless the preview passes 64-128 px readability.
- No rig/animation until Maya cleanup scope is written.
- Store task id, prompt, negative prompt, export format, credit cost, and
  preview verdict in the asset ledger.
- Kill patterns quickly. Weak silhouette is not fixed by texture quality.

## Selection Matrix

| Candidate | Differentiation | Gameplay Readability | Meshy Risk | Maya Cleanup Risk | First Slice Fit |
| --- | --- | --- | --- | --- | --- |
| H02 Pincer Knight | High | High | Medium | Medium | Strong melee identity |
| H07 Judgement Axe | Medium | Very high | Low-medium | Low-medium | Strong hit-stop demo |
| H08 Threadbinder | High | Medium | High | High | Unique but risky |
| H01 Lantern Pilgrim | Medium-high | Medium | Medium | Medium | Strong world identity |
| H03 Glass Scout | Medium | Medium-low | High | Medium | Risks thin unreadable blades |
| H04 Mud-Crown Hexer | Medium | Medium | Medium | Medium | Better as NPC/enemy first |
| H05 Execution Medic | Medium | Medium | Medium | Medium | IP/cliche risk if too plague-doctor |
| H06 Chain Monk | High | Medium | High | High | VFX-dependent, risky first hero |

Recommendation for first generation round:

1. H07 `White-Charcoal Judgement Axe`
2. H02 `Black-Iron Pincer Knight`
3. H08 `Navy-Lantern Threadbinder`

Generate these as low-cost previews only, compare them as 64-128 px grayscale
thumbnails, then pick one. Do not spend on texture/refine before that.
