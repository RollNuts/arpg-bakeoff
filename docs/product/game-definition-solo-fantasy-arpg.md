# Game Definition: Solo Fantasy ARPG

Status: active product source of truth.
Date: 2026-06-30.
Working title: TBD.

This document supersedes both `Threadlight Pilgrimage` and the cooperative
`Relic Runebound` reliquary direction. Keep prior images and Meshy/Maya outputs
as part-library evidence only. Do not let those older concepts define the game.

## One-Line Pitch

A lone swordfighter explores the ruins of an ancient sealed kingdom, opens
shortcuts, strengthens simple gear, and defeats five readable guardians through
weighty melee combat, careful dodging, limited healing, and altar checkpoints.

## Product Target

Steam commercial-quality solo 3D fantasy action RPG.

This is not:

- online co-op
- local co-op
- MMO
- hack-and-slash loot game
- open world
- roguelike
- giant RPG

The finished game target is a dense 4-8 hour premium indie ARPG with enough
visual and combat quality to support a Steam page, screenshots, and a 30-second
trailer.

Commercial requirements from the beginning:

- controller support
- keyboard/mouse support
- save/load
- fast retry from death
- Japanese and English UI/text
- settings for resolution, volume, input, and graphics basics
- key/button remapping
- Steam achievements
- stable performance on modest PCs
- asset ledger for every visible commercial asset
- no copied IP, costume, UI, character, boss, logo, or named system

## Core Fantasy

The player is an unnamed swordfighter entering a beautiful but dangerous sealed
kingdom:

- draw a blade in a ruined temple
- read enemy windups
- dodge or guard with intent
- land heavy-feeling hits
- conserve limited healing
- unlock shortcuts back to altars
- defeat area guardians
- bring light back to dead sanctuaries

The game sells on readable combat, atmosphere, and screenshot strength, not on
system count.

## Camera

Third-person 3D camera, close enough to see the hero's back, weapon, and enemy
scale. It is not a full top-down camera.

Required:

- lock-on camera for combat
- assisted camera follow
- wall transparency or wall fade in tight areas
- zoom correction in narrow spaces
- boss framing that preserves attack readability
- no camera behavior that hides enemy windups

The camera must make screenshots stronger while staying playable.

## Hero

One fixed protagonist. No character creator for the first commercial target.

Required actions:

- walk
- run
- lock-on strafe
- light attack
- heavy attack
- charged attack
- dodge
- guard
- parry or perfect guard
- hit reaction
- knockdown
- heal
- item pickup
- open door
- rest at altar
- death
- short boss-victory animation

The hero's face is less important than silhouette, readable equipment, motion,
weapon grip, and contact response.

## Combat Feel

Combat is simple, heavy, and readable. One enemy can be dangerous if the player
ignores its telegraph.

Required feel stack:

- input response with deliberate recovery
- enemy windup before damage
- hit stop on meaningful contact
- enemy flinch and knockback
- low-frequency weapon impacts
- sparks, dust, light, smoke, or magic particles on contact
- stamina cost for attacks, guard, and dodge
- recovery windows after attacks and dodges
- clear player damage feedback
- fast death retry

Do not rely on HP bars and damage numbers to prove combat. The animation, sound,
VFX, camera, and timing must prove it.

## Weapons

Finished game maximum: four weapon families.

| Weapon | Role | Feel Requirement |
| --- | --- | --- |
| One-Handed Sword | First weapon and balance baseline. | Clean timing, readable arcs, reliable recovery. |
| Greatsword | Slow, heavy stagger. | Strong anticipation, longer hit stop, heavy impact SFX. |
| Spear | Range and spacing. | Clear thrust line, good lock-on footwork, weaker in tight spaces. |
| Sword And Shield | Guard and counter play. | Strong block audio, perfect-guard flash, lower raw damage. |

Do not add weapon families unless they create a distinct combat decision.

## Progression

Keep progression simple:

- max HP upgrades
- stamina upgrades
- weapon upgrade levels
- healing charge increase
- a small number of special move unlocks

No large skill tree. No randomized loot. No equipment affix grind.

## World

The world is an ancient kingdom that once flourished through sealing magic. It
is now broken but not visually hopeless.

Tone:

- mysterious
- dangerous
- beautiful
- ancient
- adventurous
- not pure horror
- not fully grimdark

Core motifs:

- ancient ruins
- stone temples
- forest altars
- ruined fortresses
- magic circles
- sacred fire
- bells
- giant gates
- seals
- monsters
- swords and shields
- fog and wind
- cloth, chains, rubble, columns
- light returning after victory

## Areas

Finished game target: five dense areas, not a sprawling open world.

### 1. Sealing Temple

First area. Teaches movement, combat, healing, altar checkpoints, and shortcut
opening. Ends with a small guardian boss.

### 2. Sunken Forest Ruins

Stone ruins swallowed by vegetation. Uses sightlines, elevation, hidden paths,
poison, and vines. Ends with the Forest Guardian.

### 3. Ruined Fort

Combat-heavy area with soldiers, shield enemies, archers, stairs, towers,
bridges, and gates. Ends with the Fortress Knight.

### 4. Underground Altar

Mystic and dangerous without becoming unreadably dark. Uses magic circles,
spirits, warps, and seal mechanisms. Ends with the Altar Magus.

### 5. White Sanctuary

Final area at the collapsed center of the seal. Fewer enemies, higher tension,
stronger lighting identity. Ends with the Seal King.

## Enemy Roster

Finished target:

- 12 normal enemies
- 4 mid-tier enemies
- 5 bosses

Enemy rules:

- a player should understand the enemy role from silhouette
- every damaging action needs a windup
- no unfair instant attacks
- every enemy needs a satisfying hit and death reaction
- mixed groups should create decisions, not visual noise

Initial normal enemy list:

1. small fiend
2. spear dead soldier
3. shield soldier
4. archer
5. heavy infantry
6. pouncing beast
7. unstable magic insect
8. spirit
9. magic priest
10. large axe soldier
11. stone sentinel
12. late-game sealed soldier

## Bosses

Finished target: five bosses.

| Boss | Purpose |
| --- | --- |
| Sealing Guardian | First mastery check for attack, dodge, guard, heal. |
| Forest Guardian | Teaches spacing, charge reads, and ground hazards. |
| Fortress Knight | Teaches shield/counter discipline and side/back openings. |
| Altar Magus | Teaches position management against magic circles and summons. |
| Seal King | Final sword/magic duel with phase change and light-return payoff. |

Boss requirements:

- entrance beat
- name display
- boss HP UI
- dedicated music layer
- readable attack pattern set
- phase change below a health threshold
- fast retry
- victory animation and reward

Boss HP must create intensity, not padding.

## Hub

One small hub, not a town simulation.

Functions:

- weapon upgrade
- healing restock
- area selection or progression gate
- minimal world explanation
- next objective prompt

NPC maximum for the first full target:

- blacksmith
- ritual keeper
- traveler or recorder

Dialog should be short and atmospheric.

## UI

Minimum commercial UI:

- HP
- stamina
- healing item count
- equipped weapon
- boss HP
- objective prompt
- item pickup toast
- altar menu
- upgrade screen
- settings screen

Visual language:

- stone
- metal
- parchment
- magic marks
- sacred flame
- cool blue-white magic
- restrained ornament

No plain debug text UI in accepted screenshots or video.

## Audio

Audio is part of commercial quality, not decoration.

Minimum categories:

- footsteps
- sword swing
- sword hit
- greatsword hit
- spear thrust
- shield guard
- perfect guard
- dodge
- player hit
- healing
- enemy voice
- boss voice
- magic
- door
- altar
- item pickup
- boss defeat
- death
- area music
- boss music
- hub music

Light audio makes the whole product look cheap. Sword, shield, boss, and death
sounds need weight.

## Visual Target

The screenshot must read as a commercial fantasy game.

Required visual ingredients:

- medieval fantasy
- ancient ruin identity
- sacred spaces
- magical light
- readable fog
- layered stone floors
- broken columns
- cloth moving in wind
- chains
- bells
- altars
- distant vista
- light-return victory moment

Forbidden in accepted evidence:

- gray boxes
- default floor
- default sky
- unadjusted default materials
- asset-store pileup with no art direction
- overly dark screens
- placeholder UI
- copied existing game costumes, bosses, or weapons
- screenshots where the genre is unclear

Assets may be used, but lighting, palette, layout density, VFX, UI, and audio
must make them feel like one game.

## Engine Direction

Unreal Engine is the recommended default for the first commercial-quality
vertical slice because it gives better early leverage on lighting, materials,
VFX, animation presentation, and camera.

Unity remains allowed only with an explicit exception memo that proves it reaches
the same screenshot and combat-feel bar faster. The project must not drift back
to the old Unity mock style.

## Development Order

1. commercial-looking hero controller in a small dressed temple
2. light attack, dodge, guard, lock-on, stamina
3. hit stop, enemy flinch, hit/death feedback, healing
4. two normal enemies: small fiend and shield soldier
5. first boss: Sealing Guardian
6. first area: Sealing Temple with shortcut, altar, small boss, victory
7. 30-second Steam-facing capture
8. remaining areas and bosses
9. save/settings/localization/achievements/performance pass

Do not add more systems while the sword swing, dodge, enemy read, camera, UI, or
audio still feels cheap.

## Done Criteria

The finished game is not complete until:

- it can be cleared from start to ending
- playtime is 4-8 hours
- five areas exist
- five bosses exist
- 12 normal enemies exist
- four weapon families exist
- one hub exists
- save/load works
- controller works
- Japanese and English UI/text exist
- settings screen exists
- achievements exist
- 30-second trailer footage looks commercial
- store screenshots look commercial
- attack and dodge feel good
- enemy attacks are readable
- boss fights are fair
- visible assets are commercially legal
- UI is not placeholder
- sound has weight
- FPS is stable
- no critical progression bugs remain

## Scope Discipline

Do not build before the core sells:

- online co-op
- local co-op
- open world
- random generation
- crafting
- large loot tables
- affix grind
- huge skill trees
- mass NPC dialog
- large side-quest web
- town life simulation
- fishing, cooking, farming
- multiple endings
- large cinematic set
- large voice acting set

The first commercial proof is simple: a lone swordfighter enters a ruined
temple, fights clearly, opens a path, survives a guardian, and brings light back.
