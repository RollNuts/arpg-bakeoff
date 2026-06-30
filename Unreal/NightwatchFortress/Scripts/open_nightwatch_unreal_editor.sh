#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(cd "$SCRIPT_DIR/../../.." && pwd)"

UE_ROOT="${UE_ROOT:-/Users/murakaminaoya/Epic Games/UE_5.8}"
UE_APP="$UE_ROOT/Engine/Binaries/Mac/UnrealEditor.app"
PROJECT="$PROJECT_ROOT/Unreal/NightwatchFortress/NightwatchFortress.uproject"
MAP_PATH="${NIGHTWATCH_MAP:-/Game/Maps/WolfForestVisualSpike}"

if [[ ! -d "$UE_APP" ]]; then
  echo "UnrealEditor.app not found: $UE_APP" >&2
  exit 1
fi

if [[ ! -f "$PROJECT" ]]; then
  echo "Nightwatch Unreal project not found: $PROJECT" >&2
  exit 1
fi

echo "Opening Nightwatch Fortress in Unreal Editor..."
echo "Project: $PROJECT"
echo "Map: $MAP_PATH"

open -n "$UE_APP" --args "$PROJECT" "$MAP_PATH" -nosplash "$@"
