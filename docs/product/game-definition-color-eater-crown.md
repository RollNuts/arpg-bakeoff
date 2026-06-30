# Game Definition: 色喰いの王冠

Status: historical, superseded.
Date: 2026-06-30.
English working title: `The Color-Eater Crown`.

Active product source of truth:
[`docs/product/game-definition-nightwatch-fortress.md`](game-definition-nightwatch-fortress.md).

This document is preserved as design history only. Do not use it as the current
implementation target.

## One-Line Pitch

A lone color mortician enters a poisonous royal dark fantasy kingdom, tears color
from enemies, stores up to three colors in a glass arm organ, reshapes the sword
with those colors, opens color-locked paths, strips bosses down to their true
weakness, and hunts the cursed crown that devoured the kingdom.

## Product Target

Steam commercial-quality 3D solo dark fantasy action RPG.

This is not:

- a cooperative game
- an online-first game
- a hack-and-slash loot game
- an open world
- a gray fantasy prototype
- a pure Soulslike defense-first game

The game should feel:

- dark but vivid
- beautiful but unpleasant
- courtly but monstrous
- sword-based, but mechanically centered on stealing color

## World

The setting is `彩冠王国オルフェリア`.

Orphelia was once the most beautiful kingdom in the world: black marble, gold
leaf, red carpets, stained glass, wet wood, old oil paintings, silk masks,
greenhouses, court music, judges, dancers, painters, magicians, and knights.

Color is not cosmetic in this world. Color is soul heat, memory, emotion, and
magic.

| Color | Meaning |
| --- | --- |
| Red | anger, life, blood, heat |
| Blue | memory, silence, water, mirror |
| Green | growth, poison, vines, decay |
| Gold | authority, contract, light, weight |
| Purple | dream, madness, illusion, shadow |
| Black | desire, hunger, abyss |
| White | loss, blankness, mourning |

The king gathered the kingdom's colors into the crown. When he wore it, he
became a color-eating monster. Nobles became masked beasts, citizens became
colorless husks, and paintings began to move like living things.

The kingdom is dark, but not gray: wet black marble reflects red, blue stained
glass paints corridors, gold decoration rots, green glasshouses pulse like meat,
and purple moonlight stains the palace.

## Protagonist

Default name: `リュシアン`.

Role: `彩葬師`, a mortician who calms violent color and mourns the colorless
dead.

Visual pillars:

- slim swordfighter
- black formal combat clothing
- one-sided long mantle
- brush-like short dagger at the waist
- narrow black-silver sword on the back
- glass color organ in the left arm, `彩槽`
- eyes, left arm, sword, and mantle lining change color in combat

Core equipment:

- `彩剣`: black-silver rapier that changes shape when color is equipped
- `彩槽`: stores up to three colors
- `葬筆`: short blade/magic brush used to paint seals, doors, floor marks, and
  paintings
- mantle: dodge, air control, fall reduction, color-change silhouette

## Core System: Color Drain

Every enemy has a color core and a color layer separate from HP.

Flow:

1. Damage an enemy to削る its color layer.
2. Break the color layer.
3. Enter color-drain-ready state.
4. Press the color drain input at close range.
5. A short execution animation pulls color as liquid/ribbon light into the left
   arm.
6. The enemy loses color and collapses.

Color drain success:

- restores a small amount of HP
- adds one color to the `彩槽`
- grants short invulnerability
- emits a color shockwave
- awards color material

Color storage:

- maximum three colors
- same-color stacking strengthens that color
- mixed colors unlock combo techniques later
- color skills consume color gauge
- gauge recovers through attacks, color drain, and color crystals

## Colors

### Red

Theme: life, anger, blood, heat.

- combat: close damage, HP steal, rapid attacks
- weapon: red curved blade
- VFX: blood-like slashes, sparks, red particles
- skills: `紅裂き`, `血華`, `命喰い`
- exploration: cut red seals and open vascular doors

### Blue

Theme: memory, silence, water, mirror.

- combat: counter, ranged slash, time slow
- weapon: thin transparent crystal blade
- VFX: mirror shards, ripples, cold light
- skills: `水鏡返し`, `記憶刃`, `静止線`
- exploration: reveal memory ghosts and restore vanished platforms

### Green

Theme: growth, poison, vines, decay.

- combat: poison, bind, setup, recovery support
- weapon: thorns and vines around the blade
- VFX: green liquid, spores, thorns, glowing pollen
- skills: `棘縫い`, `毒庭`, `再生芽`
- exploration: grow dead plants and open root-blocked paths

### Gold

Theme: authority, contract, light, weight.

- combat: heavy attacks, guard break, shield, stun
- weapon: gold greatsword or heavy ceremonial sword
- VFX: gold leaf, seals, hard light, contract marks
- skills: `王印砕き`, `契約盾`, `断罪落とし`
- exploration: open royal crest doors and restart mechanisms

### Purple

Theme: dream, madness, illusion, shadow.

- combat: short teleport, clone, confusion, back attack
- weapon: long thin shadow blade
- VFX: afterimages, butterflies, smoke, moonlight
- skills: `夢渡り`, `影替え`, `月裏刺し`
- exploration: pass illusion walls and enter dream rooms

### Black

Theme: desire, hunger, abyss.

- combat: high-risk high-power
- weapon: black spatial tear
- VFX: black liquid, distortion, pull
- skills: `色喰い`, `黒渦`, `飢刃`
- exploration: open black rifts and hidden shortcuts

### White

Theme: loss, blankness, mourning.

- combat: cleanse, remove buffs, special boss mechanics
- weapon: white bone-porcelain blade
- VFX: white powder, paper, silent light
- skills: `弔い`, `白断ち`, `空白化`
- exploration: restore lost text, portraits, and NPC memories

## Combat

Required actions:

- movement
- camera control
- lock-on
- normal attack
- heavy attack
- dodge
- jump
- guard or parry
- color skill
- color switch
- color drain
- interact

Combat feel:

- normal attack chains up to three hits
- heavy attacks damage color layers strongly
- dodge changes with held colors, especially purple and blue
- parry strips color layers and blue strengthens the counter
- enemies need HP and color-layer reactions
- hit stop, color-specific SFX, color splash, camera impulse, and screen color
  flash support impact

## Exploration

Every major path includes color gates.

| Color | Exploration Gate |
| --- | --- |
| Red | vascular doors, red seal threads, pulsing walls |
| Blue | memory platforms, vanished bridges, past NPC ghosts |
| Green | vine elevators, dead trees, poison marshes |
| Gold | royal doors, contract devices, scales |
| Purple | illusion walls, dream rooms, moonlight stairs |
| Black | rifts, hidden passages, hungry paintings |
| White | unreadable inscriptions, lost portraits, cursed NPCs |

Color is a resource, so players decide whether to spend it on combat or
exploration.

## Structure

Overall structure: semi-open royal city centered around `無色のアトリエ`.

Hub functions:

- save
- equipment changes
- color skill upgrades
- NPC conversations
- travel through paintings
- color return after boss defeats
- appearance state review
- music gallery
- bestiary/archive

Major areas:

1. `赤絨毯の劇場`: red, blood, stage, applause, execution, theatre
2. `青硝子の記憶図書館`: blue, memory, mirror, water, books, silence
3. `緑毒の温室宮`: green, growth, poison, noble garden, flesh plants
4. `金箔の裁判宮`: gold, authority, contract, trial, chains, scales
5. `紫月の夢宮`: purple, dream, madness, masquerade, moon, illusion
6. `色喰いの王冠`: all colors, black, white, king, hunger, beauty, end

## Vertical Slice

The first complete vertical slice is `赤絨毯の劇場`.

It must include:

- title screen
- player model and core movement
- jump, dodge, lock-on, normal combo, heavy attack, parry
- color drain
- red, blue, and purple abilities
- HP, color gauge, and three color slots
- death and revive
- three enemies: masked actor, red dancer, stage executioner
- boss: `緋幕の公爵夫人`
- red seal thread, blue memory platform, purple illusion wall
- shortcut
- save point
- return to `無色のアトリエ`
- title music, exploration music, combat layer, boss music
- core SFX, VFX, UI, animation, and post process

## Boss: 緋幕の公爵夫人

Visual:

- giant red dress
- white mask
- long thin arms
- countless applauding hands on her back
- dress hem becomes blades
- red trail on the stage floor

Start:

- player enters center stage
- masked audience applauds
- curtain rises
- Duchess bows
- waltz turns into battle music

Phase 1:

- triple dance slash
- red fan slash
- spinning dress attack
- thrust lunge
- applause shockwave
- color core flashes after attacks

Phase 2 at 50% HP:

- rotating stage
- falling curtain blades
- more hands on her back
- attack speed up
- red clone dance
- all-direction applause shockwave

Strategy:

- draining red strips dress defense
- blue helps read rotating-stage timing
- purple helps reach her back

Reward:

- red skill `血華`
- key deeper into the theatre
- Duchess memory fragment

## UI

HUD:

- HP top-left
- state icons top-left
- three `彩槽` slots bottom-left
- color gauge as circular or liquid fill
- current color skill bottom-right
- color drain marker center
- lock-on marker center
- enemy HP and color layer
- boss HP, boss color layer, and boss part lock-on

Menus:

- equipment
- status
- color skill trees
- items
- map
- bestiary/archive
- settings
- return to atelier

## Art Direction

Core phrase: `鮮やかな闇`.

The game must look dark, vivid, luxurious, wet, poisonous, and courtly.

Materials:

- black marble
- gold leaf
- red carpet
- blue stained glass
- green greenhouse glass
- purple velvet
- white porcelain
- wet wood
- old oil painting
- candle wax
- masks
- silk
- rusted ceremonial blades
- colored liquid

Accepted evidence must not look gray, generic, or placeholder.

## Audio Direction

Do not rely on generic orchestration. Use court music, distorted waltz,
harpsichord, string quartet, low choir, broken music box, glass sounds, metal
sounds, and deep percussion.

First vertical slice music:

- title theme
- red theatre exploration
- red theatre combat layer
- red duchess boss
- color drain success accent
- boss victory accent

## Done Criteria For Vertical Slice

- title screen appears
- new game starts
- player can fight enemies
- enemies have HP and color layer
- color drain works
- stored color changes weapon/skills
- red theatre can be explored
- color gates open paths
- three enemy types work
- Red Duchess boss works with phase transition
- boss defeat grants reward
- atelier return works
- skill upgrade exists
- HP, color slots, enemy HP, boss HP, and color layer UI are visible
- music and SFX play
- player, enemies, and boss have dedicated animations
- color VFX are visible
- screenshots communicate "color-draining dark fantasy ARPG"
