# Game Definition: 夜番の砦

Status: active product source of truth.

English working title: `Nightwatch Fortress`

This document supersedes the active `色喰いの王冠` direction. Historical concepts
remain in the repository only as reference history; the current game is a simpler,
more immediately readable solo 3D dark fantasy ARPG centered on changing weapons
found on the battlefield.

## One-Line Pitch

A solo night-hunter ARPG where the player survives monster-infested roads by
quickly picking up, throwing, breaking, swapping, and reusing weapons found in the
field.

## Product Target

Make a Steam-facing commercial game, not a prototype. The first target is a
complete vertical slice of `狼森` that can show the hook within 30 seconds:

- a lone nightwatch fighter enters a dangerous forest at night
- weapons lie on racks, bodies, carts, and the ground
- enemies drop usable weapons
- weapons wear down, chip, break, and become throwable
- thrown weapons stick into enemies or terrain
- a boss can be stopped, staggered, or weakened by using the right weapon type
- the scene reads as a dark but colorful night fantasy, not gray fog

## Genre Boundaries

This is:

- 3D solo dark fantasy action RPG
- third-person camera behind and above the player
- focused on local weapons and readable action
- short-to-medium commercial scope

This is not:

- online co-op
- open world
- loot-rarity hack-and-slash
- lore-heavy opaque fantasy
- pure survival craft
- a slow defensive Souls clone
- a gray-box weapon sandbox

## Core Hook: Local Weapons

The game is about `現地武器`.

The player brings two weapons from the fort, but cannot rely on them for the
whole stage. During battle, weapons chip, fall, break, get thrown, stick into
enemies, and are replaced by weapons found in the level.

Required weapon actions:

- pick up
- swap
- drop
- throw
- recover from the ground
- pull from an enemy or boss
- use while damaged
- break

Required weapon states:

- fresh
- normal
- chipped
- near-broken
- broken

Near-broken weapons should become attractive as throws. A broken weapon should
not remain a viable main weapon.

## World

The kingdom is ordinary by day. At night, monsters appear in forests, mines,
forts, old castles, swamps, and near the capital walls. Villagers close gates,
forts ring bells, soldiers light fires, and the nightwatch goes outside.

The protagonist is not royal or chosen. They are a night hunter who can fight
where ordinary people cannot. The story should stay clear:

1. a village or fort is threatened
2. the nightwatch goes out
3. enemies are killed on the road
4. weapons are picked up and replaced
5. a monster nest is reached
6. a large night beast is defeated
7. morning returns

## Player

Default role: `夜番の剣士`.

Visual direction:

- leather armor
- cloth cloak
- small shoulder lantern
- short blade at the waist
- initial weapon on the back
- gloves, boots, belts, and weapon holders
- practical and cool, not overdesigned
- dark enough for night fantasy, but not lifeless

The silhouette must clearly change with:

- one-handed weapon
- two-handed weapon
- spear
- large shield
- bow
- torch

## Controls

- move
- camera
- lock-on
- normal attack
- heavy attack
- dodge
- jump
- guard
- parry
- pick up weapon
- drop weapon
- throw weapon
- swap weapon
- use torch
- use item
- interact

## Weapon Types

### One-Handed Sword

Fast, stable, easy to guard and parry with. Baseline weapon.

### Greatsword

Wide and heavy. Strong for large parts, but has recovery.

### One-Handed Axe

High damage, good against shields, throwable.

### Great Hammer

Slow and heavy. Strong posture damage, armor breaking, ground shock.

### Spear

Long reach, thrusts, charge stopping, throwable. Can stick into boss legs,
wings, or mouth to interrupt movement.

### Dagger

Fast, good after dodge, easy to throw, strong from behind.

### Bow

Ranged weak-point tool. Uses limited arrows: fire, poison, heavy arrows.

### Large Shield

Best guard tool, can stop charges, push enemies, shield bash, and break under
pressure.

### Torch

Lights dark areas, frightens small night monsters, ignites oil, pairs with
one-handed weapons, and can hit weakly.

## Combat

Combat should be lighter and more responsive than a heavy Soulslike. The player
should feel that changing weapons is fast and useful, not a menu chore.

Required combat systems:

- weapon-specific light attacks
- weapon-specific heavy attacks
- dodge step
- guard
- parry
- posture damage
- weapon durability
- weapon throw
- weapon embed
- weapon pull
- enemy weapon drop
- readable enemy telegraph
- hit stop
- weapon-specific sound
- blood, sparks, wood chips, bone chips, shell chips
- small camera shake on heavy hits

## Boss And Part Break Rules

Large enemies and bosses have parts such as head, arms, legs, wings, tail, horn,
armor, and belly. Part breaks must change the fight.

Boss arenas must include local supplies:

- weapon rack
- broken weapons
- throwing spears
- oil jars
- torch
- large shield
- arrow bundle
- small healing item

Boss fights should require choosing, throwing, embedding, breaking, and pulling
weapons. They must not be just dodge-and-hit loops.

## Core Loop

1. Accept request at a village or fort.
2. Choose two carry-in weapons from a weapon rack.
3. Enter the night area.
4. Fight enemies.
5. Replace damaged weapons with local weapons.
6. Open shortcuts.
7. Defeat a medium enemy and resupply.
8. Prepare at a boss-room rack.
9. Fight a giant night beast.
10. Defeat the boss and see morning return.
11. Return to the fort.
12. Upgrade, choose the next request, and leave again.

## Areas

### 1. 狼森

First vertical-slice area.

Art:

- dark forest
- moonlight
- mist
- hunter shack
- fallen trees
- stream
- torch stands
- weapon rack

Enemies:

- small wolf
- horned beast
- goblin
- shield goblin

Gimmicks:

- torch lights the path
- oil jars can be ignited
- fallen trees open shortcuts
- spear stops charging beasts

Boss: `大狼ガルム`

- giant wolf
- fast charge, bite, roar, leap
- spear in leg slows movement
- great hammer to head creates large stagger
- tail cut weakens spin attack

### 2. 鉄鉱山

Mine, scaffold, minecart, furnace, workshop. Hammers and axes matter.

Boss: `炉喰いの巨人`

### 3. 沼の砦

Sunken fort, swamp, planks, poison, broken tower. Shields and torches matter.

Boss: `沼鎧の騎士`

### 4. 月見の古城

Blue moon castle, walls, chapel, armory, rooftops. Bows and agile weapons matter.

Boss: `月角の魔女獣`

### 5. 王都外壁

Burning walls, broken gate, refugees' traces, armory, siege tools.

Boss: `夜王獣`

The final boss must make the player use the whole weapon language: spear to stop
legs, greatsword on arms, bow to head, shield against charge, and a near-broken
weapon throw to open the final weak point.

## First Vertical Slice

The first complete slice is `狼森`.

Required player features:

- movement
- jump
- dodge
- lock-on
- one-handed sword
- spear
- great hammer
- bow
- torch
- weapon pickup
- weapon drop
- weapon throw
- weapon durability
- parry
- guard
- HP
- stamina
- death
- respawn

Required enemies:

- small wolf
- horned beast
- goblin
- shield goblin

Required boss:

- `大狼ガルム`
- intro
- phase 1
- phase 2
- spear sticks into leg
- head stagger
- tail part break
- defeat
- dedicated music target

Required area:

- Wolf Forest route
- hunter shack
- fallen tree shortcut
- stream
- weapon rack
- torch stand
- boss den

Required UI:

- HP
- stamina
- equipped weapon
- sub weapon
- weapon durability
- pickup prompt
- enemy HP
- enemy posture
- boss HP
- part break display
- lock-on
- pause/settings

## Art Direction

The image should immediately say:

- night kingdom
- lone monster hunter
- local weapons on the ground
- huge beast combat

Use:

- village lights
- torches
- moonlight
- blood red
- iron highlights
- forest green
- blue castle night air
- warm fort fires

Do not make the screen gray and unreadable. Darkness is the premise, not the
palette.

## Sound Direction

Music should carry night tension, adventure, and combat excitement. Use strings,
low drums, flute, horn, metal percussion, fire, and fort warning horns.

Sound must sell the weapon hook:

- pick up
- drop
- throw
- embed
- pull out
- chip
- near-break warning
- break
- weapon-specific hit sounds

## Completion Definition

The first vertical slice is not complete until:

- the game starts from a title or playable entry
- the player can enter Wolf Forest
- weapons can be picked up, swapped, dropped, thrown, damaged, and broken
- enemies can drop usable weapons
- at least one weapon can stick into a large enemy or boss
- embedded weapons can be pulled out
- part break changes boss behavior
- Garm can be defeated
- morning return is shown
- the player can return to the fort
- screenshots communicate the weapon-swapping night-hunter ARPG immediately
