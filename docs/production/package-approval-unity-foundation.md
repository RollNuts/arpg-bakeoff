# Unity Foundation Package Approval

Status: approved for the first `夜番の砦` Unity foundation PR.

## Scope

This memo approves only the built-in Unity modules listed in
`Packages/manifest.json`.

Approved modules:

- `com.unity.modules.animation`
- `com.unity.modules.assetbundle`
- `com.unity.modules.audio`
- `com.unity.modules.imageconversion`
- `com.unity.modules.imgui`
- `com.unity.modules.physics`
- `com.unity.modules.screencapture`
- `com.unity.modules.ui`

No registry package, Asset Store package, third-party plugin, paid asset, or
generated Meshy/Maya asset is approved by this memo.

## Reason

The first playable foundation needs only Unity's built-in modules for character
movement, physics overlap checks, IMGUI smoke HUD, audio hooks, and screenshot
capture. Keeping the manifest to built-in modules protects the local-weapon loop
from package sprawl before it proves itself.

## Official References To Verify Before Changing

- Unity Manual: Project manifest files, `Packages/manifest.json`
  - https://docs.unity3d.com/Manual/upm-manifestPrj.html
- Unity Manual: Unity Package Manager concepts
  - https://docs.unity3d.com/Manual/upm-concepts.html
- Unity legal terms
  - https://unity.com/legal/terms-of-service

## Alternatives Considered

- Add Cinemachine, Input System, URP, Shader Graph, VFX Graph, or Test Framework
  now.
  - Rejected for this PR. Each can help later, but each needs a separate
    approval memo and a concrete implementation need.
- Keep `Packages/manifest.json` absent.
  - Rejected. AGENTS.md treats the manifest as the package source of truth.

## Removal Method

To remove this approval, delete this memo, remove the unneeded module entries
from `Packages/manifest.json`, then let Unity regenerate
`Packages/packages-lock.json` on the next project open. Do not delete modules
that active scripts or scenes compile against.
