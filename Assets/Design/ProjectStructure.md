# ProjectStructure: 色喰いの王冠

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
      RedTheatre/
      BlueLibrary/
      GreenGreenhouse/
      GoldCourt/
      PurplePalace/
      FinalCrown/
    Props/
    Weapons/
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
  Scripts/
    Core/
    Player/
    Combat/
    ColorSystem/
    Enemies/
    Bosses/
    UI/
    Save/
    Audio/
    VFX/
  Scenes/
    Title/
    AtelierHub/
    RedTheatre/
    Boss_RedDuchess/
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
