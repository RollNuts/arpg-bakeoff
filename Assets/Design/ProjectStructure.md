# ProjectStructure: 夜番の砦

Status: active Unity project layout.

Unity version is pinned by `ProjectSettings/ProjectVersion.txt`:
`6000.3.18f1`.

The first generated scene entry point is:

`Nightwatch Fortress > Build Wolf Forest Foundation Scene`

It writes `Assets/Scenes/WolfForestFoundation.unity`.

## Target Folder Layout

```text
Assets/
  Art/
    Characters/
      Player/
      Enemies/
      Bosses/
      NPC/
    Environment/
      NightwatchFort/
      WolfForest/
      IronMine/
      SwampFort/
      MoonCastle/
      CapitalWall/
    Props/
      WeaponRacks/
      Torches/
      Carts/
      OilJars/
    Weapons/
      Sword/
      Spear/
      Hammer/
      Bow/
      Shield/
      Torch/
    Materials/
    Textures/
    VFX/
  Audio/
    Music/
    SFX/
    Ambience/
  Animations/
    Player/
    Enemies/
    Bosses/
    Weapons/
  Scripts/
    Core/
    Player/
    Combat/
    Weapons/
    Durability/
    Enemies/
    Bosses/
    UI/
    Save/
    Audio/
    VFX/
  Scenes/
    Title/
    NightwatchFort/
    WolfForest/
    Boss_Garm/
  UI/
    HUD/
    Menus/
    Icons/
  Design/
    GameDesign.md
    ArtBible.md
    AnimationList.md
    AudioBible.md
    BossDesign.md
    EnemyDesign.md
```

## Creation Rule

Create concrete folders when the first real asset or script lands in that area.
Do not commit empty production folders just to satisfy the tree. This keeps GUID
and placeholder churn down.
