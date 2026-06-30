# Video Analysis Tooling

Status: local free-tool setup note.

## Installed Tool

Installed with Homebrew:

```bash
brew install ffmpeg
```

Verified tools:

- `ffmpeg 8.1.2`
- `ffprobe 8.1.2`

`ffmpeg` is the baseline free tool for trailer/gameplay evidence work:

- read video metadata
- extract exact frames
- generate contact sheets
- extract audio
- measure volume
- generate spectrogram/waveform evidence
- transcode Unity/Unreal captures to reviewable MP4

Do not commit downloaded commercial reference videos to the repository. Store
temporary analysis inputs under `/tmp` or another ignored local evidence
folder, and cite the source URL in research docs.

## Smoke Test Performed

Created a one-second synthetic video and audio test:

```bash
ffmpeg -y \
  -f lavfi -i testsrc2=duration=1:size=960x540:rate=24 \
  -f lavfi -i sine=frequency=440:duration=1 \
  -pix_fmt yuv420p \
  -shortest \
  /tmp/arpg-ffmpeg-smoke.mp4
```

Read metadata:

```bash
ffprobe -v error \
  -show_entries format=duration:stream=index,codec_type,width,height,r_frame_rate,sample_rate \
  -of default=noprint_wrappers=1 \
  /tmp/arpg-ffmpeg-smoke.mp4
```

Extracted one frame:

```bash
ffmpeg -y \
  -ss 0.5 \
  -i /tmp/arpg-ffmpeg-smoke.mp4 \
  -frames:v 1 \
  -update 1 \
  /tmp/arpg-ffmpeg-smoke-frame.png
```

Measured volume:

```bash
ffmpeg \
  -i /tmp/arpg-ffmpeg-smoke.mp4 \
  -af volumedetect \
  -f null -
```

Observed output included:

- video stream: 960x540, 24 fps
- audio stream: 44.1 kHz
- duration: 1.000000 seconds
- mean volume: about `-21.2 dB`
- max volume: about `-17.7 dB`

## Reference Trailer Analysis Commands

For local, permitted trailer/gameplay files:

Metadata:

```bash
ffprobe -v error \
  -show_entries format=duration,bit_rate:stream=index,codec_type,width,height,r_frame_rate,sample_rate \
  -of json \
  /path/to/reference.mp4
```

One frame every two seconds:

```bash
mkdir -p /tmp/arpg-reference-frames
ffmpeg -y \
  -i /path/to/reference.mp4 \
  -vf fps=1/2,scale=1280:-2 \
  /tmp/arpg-reference-frames/frame_%03d.png
```

Contact sheet from extracted frames:

```bash
ffmpeg -y \
  -pattern_type glob \
  -i "/tmp/arpg-reference-frames/*.png" \
  -vf "scale=320:-2,tile=4x3" \
  /tmp/arpg-reference-contact-sheet.png
```

Audio waveform image:

```bash
ffmpeg -y \
  -i /path/to/reference.mp4 \
  -filter_complex "aformat=channel_layouts=mono,showwavespic=s=1600x300:colors=cyan" \
  -frames:v 1 \
  /tmp/arpg-reference-waveform.png
```

Audio spectrogram image:

```bash
ffmpeg -y \
  -i /path/to/reference.mp4 \
  -lavfi showspectrumpic=s=1600x900:legend=disabled \
  /tmp/arpg-reference-spectrogram.png
```

Volume:

```bash
ffmpeg \
  -i /path/to/reference.mp4 \
  -af volumedetect \
  -f null -
```

## What To Measure For This Game

For each reference trailer/gameplay clip:

- first readable hero frame time
- first enemy-threat frame time
- first hit/impact frame time
- first boss/guardian frame time
- first altar/shortcut/exploration-loop frame time
- camera distance and character screen-height percentage
- third-person hero readability from rear and side angles
- boss/player scale contrast
- screen center occupancy by character/enemy/VFX vs empty floor
- audio presence in first 3 seconds
- mean/max loudness from `volumedetect`
- waveform density during attacks vs downtime

For our own capture:

- reject silent clips for store-facing evidence
- reject clips where the hero is not readable in extracted frames
- reject clips where the first 5 seconds show only floor/idle motion
- reject clips where the camera hides enemy windups or boss attacks
- reject clips whose best frame cannot support a Steam screenshot
- always produce a contact sheet and a waveform alongside any video PR

## Tooling Gaps

`ffmpeg` is enough for immediate free analysis. Optional later tools:

- `yt-dlp`: free downloader/metadata extractor for public video URLs, but use
  only where source terms and rights permit local analysis.
- Python OpenCV: useful for automated frame statistics, but not required before
  we have local video captures and reference files.
