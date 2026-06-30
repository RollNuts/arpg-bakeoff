# ProjectStructure: 夜番の砦

Status: intended Unity project layout.

Unity version is assumed to be `2021.3 LTS` until
`ProjectSettings/ProjectVersion.txt` is added.

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
