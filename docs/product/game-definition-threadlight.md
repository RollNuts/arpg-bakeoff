# Game Definition: Threadlight Pilgrimage

Status: superseded historical direction.
Date: 2026-06-30.

This document is retained as visual and research history only. Do not use it as
the current product source of truth. The active product is `夜番の砦`,
defined in `docs/product/game-definition-nightwatch-fortress.md`.

## One-Line Pitch

Enter frayed provinces as a lantern-thread surveyor, read the traces of a
broken land, bind its monsters and routes with threadlight, and bring lost
memories back to a growing pilgrimage caravan.

## What The Player Buys

The player is not buying a sword, axe, or armor set.

The player is buying the fantasy of becoming a careful, brave field worker in a
beautifully damaged world:

- reading danger before it kills them
- restoring paths others can no longer cross
- rescuing memories, names, and people from places that have come apart
- returning to a caravan that becomes warmer and stranger after each expedition
- mastering action combat because they understand the land, not because they
  found a bigger weapon

## Genre

Top-down action roguelite / compact ARPG.

The first commercial prototype should prove:

- readable movement, dodge, and melee timing
- one exploration tool that changes combat and navigation
- short expeditions with retreat/deeper risk
- one hub that visibly grows
- one boss whose attacks are explained by the region's world rule

## Player Role

The player is a `Threadlight Surveyor`.

Surveyors belong to a travelling repair pilgrimage. They enter provinces where
roads, names, memories, and buildings have frayed into physical thread. Their
job is not conquest. Their job is to make a route safe enough that others can
return.

The hero should read as profession first, warrior second:

- lantern or thread tool
- field coat, mantle, sash, or work apron
- measuring pins, spools, charms, chalk, map cloth, and route tags
- one practical weapon that also supports the job
- clear top-down value mark: pale lantern, white thread, red route cloth, or
  blue-black coat

Avoid hero-first signals:

- chosen-one crown
- generic holy knight
- huge spiked armor
- skull overload
- weapon collector silhouette
- black-on-black body with no job identity

## World Premise

The world entered a `Long Night`. Some provinces did not simply fall into ruin;
they came unstitched.

Memory became thread. Grief became knots. Roads now loop back on themselves.
Old flags, wedding veils, work clothes, banners, curtains, and burial cloth
wake as hostile relics. Lamps and bells are the safest way to mark a true path.

People survive by travelling in pilgrimage caravans built around looms,
lantern racks, map cloth, kitchens, sleeping shelves, and memory archives.

## Hub

The hub is a mobile `Loom Caravan`.

It is not a menu room. It is the emotional anchor.

Hub upgrades should be visible:

- lantern shelf fills with recovered lights
- NPC bunks appear and become lived-in
- map cloth expands across the wall
- repaired tools hang from hooks
- cooking area becomes warmer
- memory fragments become small exhibits
- failed expeditions leave stains, torn cloth, or missing markers

This is how runs gain emotional weight beyond loot.

## Core Loop

1. Prepare at the Loom Caravan.
2. Choose a frayed province and one route objective.
3. Enter a compact top-down expedition.
4. Read traces: loose threads, lamp color, footprints, corpse direction, bell
   rhythm, cloth movement, floor seams.
5. Use the threadlight tool to reveal, bind, anchor, or cut a route.
6. Fight enemies whose attacks come from the same local rule.
7. Decide to retreat with rescued memory or push deeper for a route seal.
8. Return to the caravan and see the world, NPCs, or tools change.

## First Prototype Slice

The first 30-second slice should not try to show the whole game.

It should show:

- a surveyor entering a rain-dark cloth street
- the threadlight lantern revealing a hidden route seam
- one enemy that eats light
- one enemy that tangles the player's route line
- one elite with a clear bell or banner telegraph
- a short fight with hit stop, knockback, and readable danger colors
- one rescued memory returned to a visible caravan object
- one boss tease: a giant loom gate or bell tower begins moving

## Visual Pillars

Use these before character detail:

1. `Thread and cloth`: route lines, torn banners, veils, knots, sashes, ropes,
   stitching, repair tags.
2. `Lantern light`: warm safety, pale memory light, reflected wet stone,
   readable player mark.
3. `Soft dark fantasy`: dangerous and melancholy, not rugged armor brutality.
4. `Profession silhouettes`: surveyor, weaver, bell keeper, route guard,
   lantern carrier, map stitcher.
5. `Repair over conquest`: visual payoff is opening, mending, lighting, and
   returning, not only killing.

Primary palette:

- ink blue
- black cloth
- wet stone gray
- warm lantern gold
- pale memory white
- oxblood route cloth
- moss green

Avoid:

- one-note slate/dark-blue UI
- generic brown dungeon
- all-black hero on all-black floor
- purple-blue magic as the main palette
- sand/beige fantasy ruins

## Character Direction

Existing generated sheets are not final protagonist direction. Preserve them as
parts:

- H09: hooded field-worker mood, relic weight, top-down cloak mass.
- F01: pale veil/crest and long polearm readability, but convert armor into
  ritual field uniform.
- F03: bell-root motif and occult ecology, useful for NPC, elite, or region
  boss language.
- H08: lantern/thread action language, but make it a physical survey tool
  instead of thin VFX loops.
- H02/H07: reserve for enemy, guard, or boss silhouettes, not first hero.
- F02: hold for redesign; current ninja/fairy signal is off-direction.

New character prompts should lead with job and world:

- rain surveyor with lantern-thread spool
- route mender with map cloth and short blade
- bell keeper with cracked bronze mantle
- caravan stitcher with field apron and measuring pins
- ash veil route guard with practical polearm

Do not lead with:

- dark fantasy warrior
- magic swordsman
- execution axe hero
- armored valkyrie
- rogue assassin

## Enemy Ecology

Enemies are not demons for their own sake. They are frayed memories and hostile
relic behavior.

First enemy set:

- `Light-Moth`: small fast creature that dims safe lantern zones.
- `Knot Hound`: low runner that pulls thread routes into hazards.
- `Banner Husk`: cloth soldier that hides attack direction until lit.
- `Bell Root`: stationary pulse enemy that changes floor rhythm.
- `Loom Gate Keeper`: first boss; a doorway/loom/bell machine that controls the
  route network.

Each enemy must teach the world rule:

- light reveals
- thread binds
- knots trap
- bells warn
- repaired routes create safety

## Store Page Promise

The first store-facing image should show:

- a small readable surveyor with a warm lantern
- a visible thread route crossing a dark floor
- a hostile relic or cloth creature pulling the route apart
- a large landmark: loom gate, bell tower, sunken wedding hall, or stitched
  street
- a hint of the caravan or rescued memory, so the game is not only combat

First trailer structure:

1. `0-3s`: lantern lights a thread route in a dark street.
2. `3-7s`: the route reveals danger before an enemy strikes.
3. `7-12s`: combat with a white hit core, warm thread trail, and knockback.
4. `12-16s`: retreat/deeper choice at a fraying doorway.
5. `16-21s`: caravan return, recovered memory changes a visible object.
6. `21-26s`: boss landmark wakes.
7. `26-30s`: high-readability combat beat, title card.

## Audio Direction

The sound should be dark but not generic.

Signature materials:

- taut thread plucks
- loom wood knocks
- lantern glass clicks
- soft bells
- rain on cloth
- low strings
- dry hand percussion
- breath-like choir fragments

Combat mix:

- player attacks: short cloth/metal motion plus clear contact
- enemy tells: bells, thread tension, breath, low scrape
- route tool: satisfying pluck, glow, and latch
- reward: small memory chime, not long fanfare

## Production Gate

Before any new Meshy/API spend:

1. Create a world contact sheet for Threadlight Pilgrimage.
2. Create a 1280x800 gameplay mock with surveyor, thread route, enemy, hub
   payoff, and boss tease.
3. Create one environment style tile.
4. Create a 30-second trailer beatboard.
5. Only then choose up to two assets for 3D preview.

Preferred first 3D targets:

1. threadlight route tool
2. light-moth enemy
3. surveyor body blockout

Do not start with a fully polished hero model.

## Rejection Rules

Reject any direction that:

- can only be explained as "dark fantasy ARPG"
- looks like weapon concept art without a world rule
- makes every character rugged, armored, and grim
- has no hub or non-combat desire
- cannot show the game promise in one screenshot
- requires paid generation to look convincing
- would still work if the thread, lantern, caravan, and repair ideas were
  removed
