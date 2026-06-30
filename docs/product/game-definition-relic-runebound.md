# Game Definition: Relic Runebound

Status: active product source of truth.
Date: 2026-06-30.
Japanese title: `聖櫃の巡礼隊`

This document supersedes both `Threadlight Pilgrimage` and the temporary solo
fantasy ARPG direction. Keep prior images and Meshy/Maya outputs as
part-library evidence only. Do not let those older concepts define the game.

## One-Line Pitch

Two to four pilgrims carry an ancient holy reliquary through a sealed temple,
swap tools from weapon stands, defend the sacred flame, repel monsters, and
complete a sealing ritual before the relic breaks or its magic runs wild.

## Product Target

Steam commercial-quality 3D top-down cooperative fantasy action game.

This is not:

- a traditional party RPG
- a large exploration RPG
- a hack-and-slash loot game
- an enemy-clear game
- an MMO
- an online-first production
- a graybox prototype

The first commercial proof is one polished 8-12 minute stage, `Sealing Temple`,
dense enough to sell by itself.

Player target:

- local same-screen 2-player first
- Steam Remote Play friendly
- solo testable and ideally solo clearable
- expandable to 3-4 players without redesigning the core loop
- no online-first architecture in the first milestone

## Core Fantasy

The players are a shrine expedition team under pressure:

- choose tools at the entrance
- move and protect the holy reliquary
- keep sacred fire alive
- solve route blockers with the right tool
- redirect or withstand monsters
- protect the ritual carrier during the final seal
- win through coordination, not damage output alone

The target table conversation:

- "Shield in front."
- "Where is the torch?"
- "The reliquary stopped."
- "Shoot the upper bell."
- "I will chant; cover me."
- "Break the gate with the axe."
- "Fire is going out."
- "Ring the bell."
- "The reliquary is cracking."

## Player Count Policy

The game should be best with 2 players, but solo should be a valid clear path,
not only a debug mode.

Solo mode:

- one player can complete every required stage function
- tool stands remain available for quick role changes
- solo interaction timings are shorter
- enemy count and pressure are reduced, not removed
- reliquary runaway grows slower when solo
- ritual chants can be performed in shorter stages
- blind guardian sound response is less punishing
- sacred fire drain is slower but still meaningful

Co-op mode:

- carrying, guarding, lighting, breaking, shooting, ringing, and chanting should
  overlap under pressure
- 2-player tuning is the main fun baseline
- 3-4 player scaling adds enemy pressure and split objectives, not extra map
  length

## Camera

3D top-down oblique camera, fixed-ish and strongly assisted.

Required:

- show reliquary, players, enemies, sacred fire, altar, doors, and blockers
- keep readability above atmosphere
- use light, fog, and shadow as gameplay signals
- never hide an objective behind darkness or VFX

Do not:

- use a freely rotating camera
- rely on horror darkness
- cover tool roles with effects
- make players fight the camera

## Controls

Keep controls simple:

- move
- attack
- dodge or step
- pick up tool
- drop tool
- interact
- special tool action

No combo tree, skill tree, level grinding, or loot optimization.

## Tools And Roles

Players are defined by the tool they carry, not a permanent class.

| Tool | Combat Role | Objective Role | Solo Notes |
| --- | --- | --- | --- |
| Sword | Fast small-enemy clear. | Cuts vines and magic membranes. | Reliable fallback weapon. |
| Great Shield | Stops charges and protects allies/reliquary. | Creates safe front during pushes and rituals. | Can stagger one guardian charge on a longer cooldown. |
| Axe | Slow heavy damage and stagger. | Breaks wood doors, pillars, roots, and sealed blockers. | Required blockers have enough time windows for solo swapping. |
| Bow | Hits distant enemies and weak points. | Shoots chains, bells, and magic-circle cores. | Distant shots must be optional or reachable after tool swap. |
| Torch | Repels spirits and lights braziers. | Maintains sacred fire and safe zones. | Torch decay is slower in solo. |
| Holy Bell | Stuns spirits and redirects sound-sensitive enemies. | Lures the blind guardian and triggers bell mechanisms. | Solo bell effect lasts longer to allow repositioning. |
| Ritual Implement | Low combat power. | Advances final sealing ritual. | Solo ritual chants are shorter and can be performed in stages. |

## Stage: Sealing Temple

### 1. Temple Entrance

Purpose: teach tool pickup and reliquary objective without text overload.

Required:

- weapon stand
- holy reliquary in center
- first small enemy group
- reliquary push or activation
- exit gate objective

### 2. Closed Gate

Purpose: show that fighting alone does not progress the stage.

Required:

- gate blocked by wood, stone, vines, or magic membrane
- axe or alternate route solution
- small enemy pressure
- reliquary runaway begins if ignored

### 3. Mist Corridor

Purpose: make sacred fire matter.

Required:

- torch lights braziers
- visible safe light circles
- spirits become dangerous outside sacred fire
- sacred flame should never make the screen unreadably dark

### 4. Bell Courtyard

Purpose: teach redirection and defense instead of killing everything.

Required:

- blind guardian large enemy
- sound response to bell, attack noise, or footstep lure
- shield can block one charge
- killing is possible but inefficient

### 5. Broken Bridge

Purpose: teach ranged utility and alternate route decisions.

Required:

- bow shoots hanging chain to lower platform
- axe opens alternate route
- enemies pressure the reliquary during the solution

### 6. Sealing Altar

Purpose: final cooperation climax.

Required:

- reliquary moved to altar center
- ritual implement holder chants while vulnerable
- other players guard, light, block, lure, and kill
- three ritual phases:
  1. light braziers
  2. chant with ritual implement
  3. suppress reliquary surge and complete final seal
- success: magic calms, light enters temple, bell rings
- failure: reliquary breaks, runaway light consumes screen

## Enemies

Only three high-quality enemy types at first.

### Imp

Small basic enemy:

- attacks players or reliquary
- dies quickly to sword
- creates number pressure

### Spirit

Sacred-fire enemy:

- stronger in mist/darkness
- hard to kill with normal attacks
- repelled by torch
- staggered by holy bell

### Blind Guardian

Large pressure enemy:

- high damage
- reacts to sound
- can be redirected by holy bell or temple bell
- shield can block one charge
- killable but usually better avoided or lured

## Reliquary System

The holy reliquary is the central objective.

It has:

- durability
- magic runaway gauge
- movement/activation state

Rules:

- enemy attacks reduce durability
- durability at 0 causes defeat
- runaway rises while the reliquary is ignored
- sacred fire loss increases runaway speed
- runaway at 100% causes defeat
- players can push, activate, or escort it forward
- focusing only on the reliquary leaves enemies and blockers unmanaged

## Sacred Fire System

Sacred fire creates safety.

Elements:

- torch
- braziers
- reliquary flame
- fuel pickups

Rules:

- spirits weaken inside sacred fire range
- darkness/mist strengthens spirits
- fire range must be visible on the floor
- the game must remain readable even when fire is low

## Action Feel

Combat is simple, but contact must feel good.

Required:

- short anticipation before attacks
- hit stop on contact
- enemy flinch
- knockback
- low-frequency impact SFX
- sparks, sacred light, smoke, or magic particles
- recovery after attack
- dodge/step commitment
- shield block weight
- axe impact weight

Do not use damage numbers as the only proof of combat.

## Visual Target

Commercial screenshot quality is mandatory.

Direction:

- low-to-mid poly fantasy with authored lighting and materials
- strong silhouettes
- bright sacred fire against readable stone
- blue-white magic circles
- warm golden fire
- fog that reveals space, not hides it
- stone temple, broken columns, iron gates, vines, cloth, candles, chains,
  bells, altar, and reliquary
- magical particles and victory light return

Forbidden in accepted evidence:

- gray boxes
- default floors
- default sky
- unadjusted default materials
- asset-store pileup with no art direction
- overly dark screens
- placeholder UI
- copied existing game costumes, bosses, maps, UI, or weapons
- screenshots where the genre or objective is unclear

## UI

Minimum commercial UI:

- reliquary durability
- magic runaway gauge
- sacred fire remaining
- current objective
- each player held tool
- ritual progress
- danger warning

Visual language:

- stone
- metal
- parchment
- wax seal
- magic marks
- sacred flame
- cool blue-white magic
- restrained ornament

No plain debug text UI in accepted screenshots or video.

## Audio

Minimum audio categories:

- sword attack and hit
- axe heavy impact
- shield block
- bow shot
- torch fire
- holy bell
- imp voice
- spirit voice
- blind guardian threat
- reliquary magic hum
- ritual chant
- seal success
- reliquary break/failure
- exploration music
- ritual pressure music
- final success bell

## Development Order

1. 3D top-down camera in a dressed temple room
2. two-player local same-screen control plus solo test control
3. pickup/drop/hold tool system
4. sword, shield, axe, torch, and ritual implement basics
5. reliquary durability and runaway
6. imp AI
7. sacred fire and spirit enemy
8. gates and blockers
9. bell courtyard and blind guardian
10. sealing altar ritual
11. victory, defeat, and result screen
12. UI, SE, VFX, lighting, and stage dressing
13. playtest and commercial screenshot polish

## Done Criteria

The first stage is not complete until:

- solo can clear the stage
- 2 players can clear the stage and feel busier than solo
- the stage runs from start to victory or defeat
- weapon/tool stands work
- held tools visibly change player roles
- reliquary durability matters
- magic runaway matters
- sacred fire changes enemy pressure
- enemies can be attacked with satisfying feedback
- fighting alone does not win
- carrying alone does not win
- final ritual creates a protect-the-chanter moment
- victory and defeat have clear audiovisual payoff
- screenshots look commercial
- 30-second capture communicates the game without explanation
- all visible assets are commercially legal

## Scope Discipline

Do not add before the first stage sells:

- online matchmaking
- large campaign
- open world
- randomized dungeons
- loot rarity
- skill trees
- many enemy types
- many maps
- lots of NPC dialog
- crafting, farming, cooking, fishing
- cinematic story scenes

The first proof is simple: pick tools, move the reliquary, keep the flame alive,
solve blockers, survive monsters, protect the ritual, and seal the temple.
