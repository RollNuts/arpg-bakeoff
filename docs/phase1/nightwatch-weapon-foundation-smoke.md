# Nightwatch Weapon Foundation Smoke

Scope: first Unity foundation for `夜番の砦`.

## Build Scene

1. Open the project with Unity `6000.3.18f1`.
2. Run `Nightwatch Fortress > Build Wolf Forest Foundation Scene`.
3. Open `Assets/Scenes/WolfForestFoundation.unity`.
4. Press Play.

## Expected First-Screen Read

- The scene reads as a moonlit forest, not a gray test floor.
- The player silhouette has leather armor, cloak, lantern, and weapon holder
  cues.
- Warm torch pools, cold moonlight, stream color, hunter shack, fallen tree,
  moss clumps, and dense tree shapes are visible.
- A weapon rack and loose weapons are visible near the start.
- A large wolf-shaped embed target is visible deeper in the arena, with a red
  leg target that communicates spear-stopping intent.

## Controls

- `WASD`: move
- Mouse: camera
- `Space`: jump
- `Left Shift`: dodge
- `Tab`: swap weapon slots
- `E`: pull embedded weapon if near one, otherwise pick up nearest weapon
- `R`: drop active weapon
- `F`: throw active weapon
- `J` or left mouse: light attack
- `U` or right mouse: heavy attack

## Pass Criteria

- Player moves, jumps, dodges, and faces camera-relative directions.
- HUD shows HP, stamina, active weapon, sub weapon, durability, and nearest
  pickup.
- Weapon pickup, slot swap, drop, and throw happen without exceptions.
- Thrown spear or sword can damage the small enemy and can embed into the large
  wolf leg target.
- Embedded weapon can be pulled free with `E`.
- Enemy death can spawn a dropped spear.
- Screenshot communicates the hook: a lone hunter surviving in a night forest
  by changing weapons found on the ground.

## Not Yet Complete

- This is not the finished `狼森` vertical slice.
- Enemy AI, boss phases, animation clips, authored models, audio, save data, and
  final UI art are still production tasks.
- Do not merge future feature work that regresses the current visual read into
  gray boxes, default floor, default sky, or debug-only UI.
