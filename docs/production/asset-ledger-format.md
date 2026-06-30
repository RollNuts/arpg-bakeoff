# Asset Ledger Format

Status: required schema for all visible assets.

Every asset used in a screenshot, capture, build, PR, or public artifact needs a
ledger row before acceptance.

## Required Columns

| Column | Required Meaning |
| --- | --- |
| asset_path | Engine/repo path or planned import path. |
| asset_name | Human-readable asset name. |
| asset_type | Character, enemy, environment, VFX, UI, audio, animation, texture, etc. |
| source | URL, marketplace page, local source, generated task, or owned library. |
| creator_vendor | Creator, vendor, or generator/service. |
| license | Exact license or store EULA. |
| commercial_use | Yes/no/unknown plus proof note. |
| modification_rights | Whether editing, retopo, recolor, remix, or rigging is allowed. |
| redistribution_limits | Any restrictions on shipping, source sharing, or resale. |
| proof_path | Receipt, screenshot, license snapshot, prompt record, or terms note path. |
| generated_provenance | Prompt/model/service/date if AI-generated; otherwise `n/a`. |
| ip_similarity_review | Reviewer note confirming no known IP resemblance risk. |
| reviewer | Person/agent approving use. |
| approval_date | Date approved. |
| capture_evidence | Screenshot/video path where the asset appears, if accepted visually. |
| status | proposed, approved, rejected, removed, needs-review. |

## Acceptance Rule

No asset can appear in accepted Steam-facing screenshots or captures while its
status is `proposed`, `needs-review`, or `unknown commercial_use`.

## Generated Asset Rule

Generated assets require:

- prompt record
- source service/API name
- generation date
- output file path
- manual cleanup notes
- IP similarity review
- proof that the asset appears in the planned first-screen or trailer evidence

Do not spend generated credits on filler assets that can be solved with legal
free/owned sources or simple manual modeling.
