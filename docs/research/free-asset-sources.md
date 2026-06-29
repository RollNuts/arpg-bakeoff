# Free Asset Source Notes

Status: research input for PR review.

## Principle

Maya is a cleanup, inspection, conversion, and rigging tool. It is not the
primary free asset source. Autodesk education/trial terms are not a safe source
for commercial game assets.

Prefer CC0 or explicit commercial-use sources before paid packs or API
generation.

## First Safe Sources

| Source | License Posture | Useful For |
| --- | --- | --- |
| Quaternius | CC0, commercial use and modification allowed. | Low-poly enemies, props, weapons, environment blockouts. |
| Kenney | CC0, commercial use and modification allowed. | UI, simple props, prototype packs, environment kits. |
| Poly Haven | CC0, commercial use and modification allowed. | HDRIs, PBR textures, rocks, ground, wood, metal. |
| Fab / Megascans | Fab Standard terms; commercial use generally allowed, asset resale/extraction forbidden. | Rocks, rubble, terrain, ruins, high-quality materials. |
| Unity Asset Store free assets | Unity Asset Store EULA plus individual restrictions. | Fast Unity prototyping, VFX, controllers, dungeon kits. |
| Sketchfab | Only CC0 or CC-BY candidates. Avoid NC, ND, and Editorial. | Specific gaps: altar, statue, tomb, creature, weapon. |
| OpenGameArt | License varies. Prefer CC0/OGA-BY. Avoid GPL/SA for this repo. | Backup source for icons, textures, small props. |
| Mixamo | Useful for animation/rigging tests; verify current Adobe terms before production use. | Humanoid motion tests. |

## Reject Conditions

- CC-NC
- CC-ND
- Editorial only
- education/research/trial-only assets
- GPL/CC-BY-SA art in closed commercial game scope
- brands, logos, real IP, recognizable characters
- third-party assets uploaded into AI tools for regeneration unless the license
  explicitly permits that use

## First Practical Test

1. Build a CC0-only candidate list from Quaternius, Kenney, and Poly Haven.
2. Use Blender as the conversion hub.
3. Use Maya only for inspection, rig cleanup, scale/pivot fixes, or FBX review.
4. Record source URL, author, license, download date, format, and modification
   note for every asset.
5. Use Meshy only after the free/CC0 route fails a written acceptance gate.

