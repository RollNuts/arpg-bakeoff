# Phase 1 Player Slice Specification (Unity 3D Top-Down)

**Goal:** ship a short, verifiable playable slice for one hero that demonstrates readable top-down combat and state transitions (idle/run/dodge/attack/hit/death) with hit feedback and minimal HUD.

## Scope
- Build only one playable loop: input -> movement -> dash -> attack -> damage -> death.
- No content bloat: one stylized training idol is enough for hit/death verification.
- Unity implementation in isolation; no cross-engine reuse.

## Scene: Required Objects
Create `Assets/Scenes/Phase1PlayerSlice.unity` with:

- **Root: `GameRoot`**
  - `Main Camera` (`TopDownCamera`)
  - `DirectionalLight` + optional ambient fill
  - `Terrain`/`Plane` (simple collision plane + visual material)
  - `Nav/GameplayBounds` (non-blocking trigger box for diagnostics)
- **Root: `Player`**
  - `PlayerCharacter` (original 3D hero silhouette; no simplified stand-in)
    - `Animator` (state controller target)
    - `CharacterController` (or `Rigidbody+CapsuleCollider`, one consistent option)
    - `PlayerController` (movement + state machine entry)
    - `PlayerHealth` (max HP, current HP, damage/kill hooks)
    - `WeaponAnchor`
  - `HitVFXRoot` (spawn point for flash/spark effects)
- **Root: `EnemyDummy`** (for hit/death verification)
  - stylized crimson idol, collider, HP component, hit response event to confirm player attack feedback
- **Root: `UiRoot`**
  - `PlayerUI/HpBar` (slider or three-segment blocks)
  - diegetic HP bar and skill icons only; no visible diagnostic text in capture

## Script Set (minimum)
- `TopDownPlayerInput`  
  - Reads movement and action input, emits normalized move vector, dodge, attack.
- `PlayerStateMachine`  
  - States: `Idle`, `Run`, `Dodge`, `Attack`, `Hit`, `Death`; handles transitions.
- `PlayerMovement`  
  - Applies speed, facing rotation, and dodge burst with lockout window.
- `PlayerAnimatorBridge`  
  - Sets animator parameters for state + blend parameters.
- `PlayerHealth`  
  - `maxHealth`, `currentHealth`, `TakeDamage`, `ApplyHitStop`, `Die`.
- `PlayerAttack`  
  - Melee arc/box check, cooldown, hit registration, and hit-stop event.
- `PlayerVFX`  
  - `SpawnHitFx`, `SpawnAttackSlashFx`, `SpawnDodgeTrailFx`, `SpawnDeathBurst`.
- `CameraFollowController`  
  - Smooth damped follow, fixed top-down angle, optional shoulder offset + clamp.
- `GameplayOrchestrator`  
  - Initializes player/enemy, tracks test sequence, optional auto-log.
- `PlayerHudPresenter`  
  - Binds HP to UI, flash damage, death overlay state.

## Controller State Specification

### Idle
- Condition: no input magnitude and not in recovery.
- Looping base animation.
- Transitions:  
  - to **Run** on `moveInput.magnitude > 0.2`  
  - to **Attack** on attack input  
  - to **Dodge** on dodge input (if dodge available)

### Run
- Condition: move input sustained.
- Animation: directional movement loop; facing aligns to movement vector.
- Transitions:  
  - to **Idle** when input decays below threshold  
  - to **Attack/Dodge** on action input

### Dodge
- One burst duration (0.2–0.35s), invulnerable window (first half), then recovery.
- Uses root-speed multiplier 2.2x–2.8x over run speed.
- Transitions: to **Run/Idle** after duration.

### Attack
- One action window (0.25–0.45s), startup + active + recovery.
- Active window enables damage hitbox.
- Transitions:  
  - to **Run/Idle** after recovery if no immediate hit trigger  
  - to **Attack** for chain input (optional in v1, disabled if too complex)

### Hit
- Triggered by `TakeDamage` when health > 0.
- Short hit pause (0.05–0.10s), hurt VFX, then return to Run/Idle.

### Death
- Triggered by `TakeDamage` when health <= 0.
- Stop movement/attack input immediately.
- Death anim + death VFX + disable collider/input.
- Transition: remain locked until scene reset.

## HP & Combat Rules
- Player HP default: **100**.
- Attack damage default: **28** per hit.
- Enemy dummy HP default: **30**.
- Dodge cooldown: **0.8s**.
- Attack cooldown: **0.35s**.
- Contact check on enemy: `Physics.OverlapSphere` / overlap box on attack socket at active window.

## Art and Assets (free/procedural only)
- **Player model**  
  - Original low-poly 3D hero assembled from authored procedural meshes: readable head, shoulder armor, cloak, scarf, sword, boots.
  - No simplified stand-in as the final Phase 1 evidence.
- **Environment**  
- Dark stone slabs, red carpet, brass inlays, columns, candles, altar, rubble, stains, and contact shadows.
- **Materials/Textures**  
  - Generated in-editor (`ProcMat_`) using solid colors + emission strips + noise.
- **VFX**  
- Forward sword streak, cyan trail, warm impact chips, hit sparks, dodge smear, and death embers.
- **Animations**  
- Procedural transform poses for idle, run, dodge, attack, hit, and death until a stronger authored rig replaces them.
- **Audio**  
- Audio is out of this first PR unless a clearly licensed free source is committed with license evidence.

## Camera Spec
- Top-down angle: ~55–60° elevation.
- Distance: tuned to keep player + 2m radius readable at 16:9.
- Behavior:
  - follow target with smoothing (position + rotation)
  - fixed yaw (e.g., 45°) for consistent direction
  - optional dead-zone for sharp movement turns
  - collision-safe: keep camera in front of terrain during quick dodge/attack
- Capture-friendly framing: center player + enough runway forward for run/attack readability.

## Verification Artifacts (required screenshots)
Capture and commit under `Assets/Phase1/Evidence/`:
1. `phase1_idle_readability.png`
2. `phase1_run_silhouette.png`
3. `phase1_attack_hit_vfx.png`
4. `phase1_hurt_response.png`
5. `phase1_death_collapse.png`

The next PR should add live gameplay capture/video evidence after another visual pass.

## Exit Criteria
- Player can reproduce all 6 states in a single live run.
- HP reduces on enemy-triggered damage and displays on HUD.
- Dodge grants a clear invulnerability/readability window.
- Hit and death VFX trigger in correct timing windows.
- All nine screenshots captured at native project resolution and attached to review.
