# AnimationList: 夜番の砦

Status: active animation checklist for the first vertical slice.

## Player Core

- Idle
- Walk
- Run
- Dash
- Jump
- Land
- DodgeStep
- Guard
- Parry
- ParrySuccess
- HitSmall
- HitLarge
- Knockdown
- GetUp
- Death
- Respawn

## Weapon Handling

- PickupWeapon
- DropWeapon
- SwapWeapon
- ThrowWeapon
- PullEmbeddedWeapon
- WeaponBreakReaction
- UseItem
- RaiseTorch

## Weapon Attacks

- SwordLight1
- SwordLight2
- SwordLight3
- SwordHeavy
- SpearThrust
- SpearHeavyPierce
- SpearThrow
- HammerLight
- HammerHeavySlam
- BowAim
- BowShoot
- TorchSwing
- ShieldGuard
- ShieldBash

## Enemies

Each first enemy requires:

- Idle
- Patrol
- Notice
- Approach
- Attack
- HeavyAttack or SpecialAttack
- HitSmall
- HitLarge
- PostureBreak
- WeaponDrop
- Death

## Garm

- EntranceHowl
- PhaseOneIdle
- Walk
- Bite
- Leap
- Charge
- TailSweep
- Roar
- LegSpearEmbedded
- HeadStagger
- TailBreak
- PhaseTransition
- PhaseTwoChainAttack
- WeakPointOpenedByThrow
- Defeat

## Quality Notes

- Weapon pickup/swap must be short and readable.
- Heavy weapon motion must show weight.
- Dagger/sword/spear/hammer cannot share the same body timing.
- Embedded weapon pull needs a satisfying tug and enemy reaction.
- Feet must not slide during attacks or dodges.
