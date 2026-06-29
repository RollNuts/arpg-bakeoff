# 無料・商用向け素材ソース（CC0ショートリスト）

対象日: 2026-06-29（調査時点）

## 対象ソース運用メモ

| Source | 商用可 | 改変可 | クレジット | 主な形式 | 注意点 |
|---|---|---|---|---|---|
| Quaternius | ○（CC0） | ○（CC0） | 通常不要。著作情報の明示は任意 | FBX / OBJ / GLTF / Blender / PNG / JPG | CC0前提で配布。作者名と同梱素材URLを取得ログに残す。 |
| Kenney | ○（基本CC0） | ○（CC0） | 通常不要。任意で明示可 | PNG / SVG / PNGシート / OBJ / FBX / Blender系 | 無料素材中心だが、ページごとに公開条件が同一か確認する。 |
| Poly Haven | ○（CC0） | ○（CC0） | 不要。原則は帰属不要 | EXR / PNG / JPG / HDR / BLEND / FBX / GLTF / USDZ | 写真/モデルの派生再配布時も、商用利用自体は可。 |
| Fab / Megascans | ○（Fab standard利用条件） | 通常可 | 多くは不要。個別要件あり | FBX / GLTF / USD / OBJ / PNG / EXR | 素材そのものの再配布や抽出利用に制限。AI学習向け投入制限の有無を毎回確認。 |
| Unity Asset Store | ○（EULA範囲） | ○（EULA範囲） | 指定がある場合のみ必須 | UnityPackage / FBX / OBJ / PNG / WAV | 「販売/再配布禁止」「Unityプロジェクト外での公開再配布」を厳密確認。 |
| Sketchfab | ○（CC0/CC-BY等を選別） | ライセンス条件次第 | CC-BY系は必須、CC0は不要 | GLB / GLTF / FBX / OBJ / STL | Creative Commons以外や NC・ND・SA混在、Editorial表記は除外。 |
| OpenGameArt | 条件付き（素材ごと） | 条件付き | ライセンス次第（CC-BY系は必要） | PNG / WAV / OGG / FLAC / SVG / OBJ / FBX | GPL/SAなどを混在掲載するため素材ごとに個別確認。 |
| Mixamo | ○（提供時の契約範囲） | ○（用途内） | 原則不要。必要時は権利情報を保持 | FBX / FBX/BVH（Rig/Anim） / PNG | 生キャラクター/モーションをそのまま配布しない。人物再利用の範囲を別途確認。 |

## ライセンス除外ルール

以下を含む素材は原則採用しない:

- NC / 非営利限定の条項
- ND / 改変禁止
- SA / 派生の再配布条件が厳格なもの
- GPL / CC-BY-SA（ARPG本体をクローズな販売物とする前提では原則不採用）
- Editorial / 参考用の限定利用
- Trial（体験版）/教育版（商用案件での再利用不可）

上記どれかがある場合は、商用実装前に`asset-ledger-template.csv`に「除外理由」を明記し、採用候補に入れない。

## 今回ARPGで最初に試す種類（優先順）

1. **環境基盤（最優先）**
   - Poly Haven: PBRテクスチャ/HDRI/岩肌
   - Quaternius: 低ポリ環境プロップ
   - Kenney: 基本UI/エフェクト資産
2. **キャラクター系（早期検証）**
   - Mixamo: 基本モーション、リギング参照
   - Quaternius: 敵/小型生物
3. **装備・小道具・UI（量産候補）**
   - Kenney: 武器UI・インターフェース
   - Sketchfab: 探索的に特定モチーフを追加（CC0/CC-BYのみ）
4. **最終補完（必要時）**
   - Fab/Megascans: 岩盤・地形素材の高品質拡張

## 判定メモ（採用時の最低記録）

- ソースURL、作成者、ライセンス条文該当箇所、取得日、形式、改変内容、再配布可否を`docs/assets/asset-ledger-template.csv`に記録
- ライセンスが1件でも曖昧なら、実装前レビューまで `pending-review` 状態で固定
- すべての判定基準は `NC/ND/SA/GPL/Editorial/Trial/教育版`除外規則と衝突しないこと
