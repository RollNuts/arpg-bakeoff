#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(cd "$SCRIPT_DIR/../../.." && pwd)"

UE_ROOT="${UE_ROOT:-/Users/murakaminaoya/Epic Games/UE_5.8}"
UE_CMD="$UE_ROOT/Engine/Binaries/Mac/UnrealEditor-Cmd"
PROJECT="$PROJECT_ROOT/Unreal/NightwatchFortress/NightwatchFortress.uproject"
BUILDER="$SCRIPT_DIR/build_wolf_forest_visual_spike.py"
LOG="$PROJECT_ROOT/local-evidence/nightwatch_unreal_spike_abs.log"

if [[ ! -x "$UE_CMD" ]]; then
  echo "UnrealEditor-Cmd not found or not executable: $UE_CMD" >&2
  exit 1
fi

if [[ ! -f "$PROJECT" ]]; then
  echo "Nightwatch Unreal project not found: $PROJECT" >&2
  exit 1
fi

if [[ ! -f "$BUILDER" ]]; then
  echo "Wolf Forest builder script not found: $BUILDER" >&2
  exit 1
fi

mkdir -p "$(dirname "$LOG")"
cd "$UE_ROOT/Engine/Binaries/Mac"

echo "Running Unreal Wolf Forest visual spike..."
echo "Project: $PROJECT"
echo "Builder: $BUILDER"
echo "Log: $LOG"

"$UE_CMD" "$PROJECT" \
  -run=pythonscript \
  -script="$BUILDER" \
  -unattended \
  -nop4 \
  -nosplash \
  -nosound \
  -nullrhi \
  -stdout \
  -FullStdOutLogOutput \
  -abslog="$LOG" \
  "$@"
