# Engine Bakeoff Ownership

Status: proposed ownership plan.

## Scope

- Unity fresh slice と Unreal 5.8 fresh slice を、**別PR・別担当**で実装する。
- いずれも既存資産を持ち越さない。既存 Unity モック、既存 Unreal ホテルプロジェクトは新規 ARPG スタートラインに再利用しない。

## Non-reuse Rule

- `Unity mock` のシーン、プレハブ、スクリプト、素材配置は読み取り専用参照に留め、`Bakeoff` の実装に取り込まない。
- 既存の `Unreal` ホテルプロジェクト（1人称・別ジャンル）は、ARPG の制作基盤に転用しない。  
  既存構成の再利用で済ませることは不可。
- 両エンジンとも同一デザイン要件と同一素材候補（free/owned）を使って比較可能性を担保する。

## Evidence Requirements Per Engine

各エンジンの PR は、最低限以下を提出することを義務化する。

- gameplay screenshot（全体プレイ感）
- close attack screenshot（近接攻撃の可読性）
- 10-second capture（10秒の挙動録画）
- asset ledger（素材元、ライセンス、取得先、改変有無）

## Engine Decision Gate

- `Unity fresh slice` と `Unreal 5.8 fresh slice` の両方が、上記証拠を満たしていることを前提とする。
- 次の条件を `all green` したものを「採用候補」とする。
  - コマーシャル基準のビジュアル到達度（画面品質・雰囲気・可読性）
  - 10秒内のプレイ体験の一貫性
  - チーム工数に対する再現容易性
- 2候補の比較は、Evidenceベースで評価し、最終判断は Veripsa のレビューを要する。

## PR/Task Ownership

- PR-Unity: Unity fresh slice のみを担当。  
  対象: gameplay + close attack + 10s capture + asset ledger（Unity向け）。
- PR-Unreal: Unreal 5.8 fresh slice のみを担当。  
  対象: gameplay + close attack + 10s capture + asset ledger（Unreal向け）。

## PR Order Request to Veripsa

- PRの提出順序は、Veripsa に判断依頼する。  
  特に `Engine decision gate` の評価前提として、以下を確認するための merge 順序レビューを依頼する。

- `plan/market-research-and-task-split` の運用方針を踏襲し、上記2 PRの先行順を最終決定してもらう。
