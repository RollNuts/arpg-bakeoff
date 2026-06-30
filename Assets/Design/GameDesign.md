# GameDesign: 夜番の砦

Status: active Unity design source for the first vertical slice.

## Core Loop

1. Start at `夜番の砦`.
2. Choose two carry-in weapons from a rack.
3. Enter `狼森` at night.
4. Fight enemies while weapon durability falls.
5. Pick up, swap, drop, throw, and recover local weapons.
6. Open a shortcut with terrain or weapon interaction.
7. Resupply before the boss den.
8. Fight `大狼ガルム` using spear embed, hammer stagger, shield guard, bow shot,
   and broken-weapon throw.
9. Defeat the boss and show morning returning.
10. Return to the fort for upgrades and next request.

## Vertical Slice Scope

Scene targets:

- `Title`
- `NightwatchFort`
- `WolfForest`
- `Boss_Garm`

Player abilities:

- movement
- camera
- lock-on
- jump
- dodge
- normal attack
- heavy attack
- guard
- parry
- pickup weapon
- drop weapon
- throw weapon
- weapon swap
- torch use
- item use
- interact

Core systems:

- HP
- stamina
- two equipped weapon slots
- weapon pickup prompt
- weapon durability state
- weapon throw
- weapon embed
- weapon pull
- enemy HP
- enemy posture
- enemy weapon drop
- boss part break
- boss phase transition

## First Weapons

| Weapon | Role |
| --- | --- |
| One-handed sword | baseline fast weapon, guard/parry capable |
| Spear | reach, throw, charge stop, Garm leg embed |
| Great hammer | posture damage, armor/head stagger |
| Bow | weak-point poke, ranged pressure |
| Torch | light, frighten small night monsters, ignite oil |
| Large shield | charge stop, guard, shove, shield break |

## First Enemies

- `SmallWolf`: fast pack pressure, teaches dodge and quick weapon use.
- `HornedBeast`: charging enemy, teaches spear stop.
- `Goblin`: weapon carrier, drops usable weapons.
- `ShieldGoblin`: teaches axe/hammer/shield-breaking logic later; first slice
  can expose posture and back-angle counterplay.

## First Boss

`大狼ガルム`

- phase 1: bite, leap, charge, tail sweep
- phase 2: faster chain attacks and roar pressure
- spear in leg slows charge windows
- hammer to head creates large stagger
- tail break weakens spin attack
- near-broken weapon throw opens a short weak-point window

## Done For First Playable

- One playable route from fort gate into Wolf Forest and to Garm's den.
- At least four local weapons can be picked up, dropped, thrown, damaged, and
  recovered.
- At least one enemy drops a usable weapon.
- One large target supports embedded weapon and pull-out interaction.
- HUD communicates HP, stamina, equipped weapons, durability, enemy HP, posture,
  pickup prompt, and boss parts.
- Capture can show weapon pickup/swap/throw within 30 seconds.
