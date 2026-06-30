# GameDesign: 色喰いの王冠

Status: active Unity design source for the first vertical slice.

## Core Loop

1. Explore the red theatre.
2. Fight a color-bearing enemy.
3. Break the enemy color layer.
4. Drain color into one of three `彩槽` slots.
5. Use color to change weapon, skill, and traversal.
6. Open a color gate.
7. Reach and defeat `緋幕の公爵夫人`.
8. Return to `無色のアトリエ` with reward and memory fragment.

## Vertical Slice Scope

Scene targets:

- `Title`
- `AtelierHub`
- `RedTheatre`
- `Boss_RedDuchess`

Player abilities:

- movement
- camera
- lock-on
- jump
- dodge
- normal attack 1/2/3
- heavy attack
- parry
- color drain
- red skill
- blue skill
- purple skill
- interact

Systems:

- HP
- color gauge
- three color slots
- enemy HP
- enemy color layer
- color-drain-ready state
- color gate activation
- save point
- boss phase transition

## Color Types

| Color | Combat | Exploration |
| --- | --- | --- |
| Red | close damage, HP steal, blood-flower burst | cut red seal threads |
| Blue | counter, delayed blade, slow line | reveal memory platform |
| Purple | dodge warp, clone, back attack | pass illusion wall |

Green, gold, black, and white remain designed but not required for the first
vertical-slice gameplay pass.

## First Enemies

- `MaskedActor`: first readable red enemy, teaches color layer.
- `RedDancer`: fast pressure, teaches dodge/lock-on.
- `StageExecutioner`: heavy telegraph, teaches parry and color-layer break.

## First Boss

`緋幕の公爵夫人`

- phase 1: dance slashes, fan slash, dress spin, thrust, applause shockwave
- phase 2 at 50% HP: rotating stage, curtain blades, red clone dance
- red color drain strips dress defense

## Done For First Playable

- One playable route from theatre entrance to boss.
- Three enemies can be damaged, color-layer-broken, drained, and killed.
- Red, blue, and purple abilities each change either combat or traversal.
- Boss can be defeated.
- UI communicates HP, color slots, color gauge, enemy HP, and color layer.
- Capture can show color drain within 30 seconds.
