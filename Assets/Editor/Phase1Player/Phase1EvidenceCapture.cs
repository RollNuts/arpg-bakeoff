using ArpgBakeoff.Phase1;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ArpgBakeoff.Phase1.Editor
{
    public static class Phase1EvidenceCapture
    {
        private const string EvidenceDir = "Assets/Phase1/Evidence";

        [MenuItem("ARPG Bakeoff/Phase 1/Capture Evidence Screenshots")]
        public static void CaptureEvidenceScreenshots()
        {
            Phase1SceneBuilder.BuildScene();
            EditorSceneManager.OpenScene(Phase1SceneBuilder.GetScenePath());
            System.IO.Directory.CreateDirectory(EvidenceDir);

            CapturePose("phase1_idle_readability.png", Phase1HeroPose.Idle, 0.2f, false, false);
            CapturePose("phase1_run_silhouette.png", Phase1HeroPose.Run, 0.4f, false, false);
            CapturePose("phase1_attack_hit_vfx.png", Phase1HeroPose.Attack, 0.58f, true, false);
            CapturePose("phase1_hurt_response.png", Phase1HeroPose.Hit, 0.55f, true, false);
            CapturePose("phase1_death_collapse.png", Phase1HeroPose.Dead, 0.8f, false, true);
            AssetDatabase.Refresh();
            Debug.Log($"Captured Phase 1 evidence screenshots in {EvidenceDir}");
        }

        [MenuItem("ARPG Bakeoff/Phase 1/Capture Demo Contact Sheet")]
        public static void CaptureDemoContactSheet()
        {
            Phase1SceneBuilder.BuildScene();
            EditorSceneManager.OpenScene(Phase1SceneBuilder.GetScenePath());
            System.IO.Directory.CreateDirectory(EvidenceDir);

            var camera = Camera.main;
            var rig = Object.FindFirstObjectByType<Phase1HeroRig>();
            var dummy = Object.FindFirstObjectByType<Phase1CombatDummy>();
            if (camera == null || rig == null || dummy == null)
            {
                throw new System.InvalidOperationException("Phase 1 scene is missing camera, hero rig, or combat dummy.");
            }

            var hero = rig.transform;
            var follow = camera.GetComponent<Phase1CameraFollow>();
            bool followWasEnabled = follow != null && follow.enabled;
            var randomState = Random.state;
            Vector3 previousHeroPosition = hero.position;
            Quaternion previousHeroRotation = hero.rotation;
            Vector3 previousCameraPosition = camera.transform.position;
            Quaternion previousCameraRotation = camera.transform.rotation;
            float previousCameraSize = camera.orthographicSize;

            var frames = new[]
            {
                new DemoFrame(Phase1HeroPose.Idle, 0.15f, new Vector3(-0.6f, 0.08f, -1.85f), Vector3.forward, false, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Run, 0.22f, new Vector3(-0.35f, 0.08f, -1.45f), Vector3.forward, false, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Run, 0.48f, new Vector3(-0.1f, 0.08f, -1.0f), Vector3.forward, false, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Dodge, 0.48f, new Vector3(0.18f, 0.08f, -0.72f), Vector3.forward, false, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Attack, 0.18f, new Vector3(0.05f, 0.08f, -0.58f), Vector3.forward, true, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Attack, 0.56f, new Vector3(0.05f, 0.08f, -0.58f), Vector3.forward, true, true, false, 0.35f),
                new DemoFrame(Phase1HeroPose.Hit, 0.34f, new Vector3(-0.12f, 0.08f, -0.72f), Vector3.back, false, true, false, 0.45f),
                new DemoFrame(Phase1HeroPose.Run, 0.7f, new Vector3(0.28f, 0.08f, -0.42f), Vector3.forward, false, false, false, 0f),
                new DemoFrame(Phase1HeroPose.Attack, 0.62f, new Vector3(0.3f, 0.08f, -0.32f), Vector3.forward, true, true, false, 0.25f),
                new DemoFrame(Phase1HeroPose.Dead, 0.42f, new Vector3(0.06f, 0.08f, -0.62f), Vector3.forward, false, false, true, 0f),
                new DemoFrame(Phase1HeroPose.Dead, 0.82f, new Vector3(0.06f, 0.08f, -0.62f), Vector3.forward, false, false, true, 0f),
                new DemoFrame(Phase1HeroPose.Idle, 0.35f, new Vector3(-0.48f, 0.08f, -1.28f), Vector3.forward, false, false, false, 0f),
            };

            const int frameWidth = 480;
            const int frameHeight = 270;
            const int captureWidth = 620;
            const int captureHeight = 349;
            const int frameGutter = 8;
            const int frameBorder = 2;
            const int columns = 4;
            const int rows = 3;
            Texture2D sheet = null;
            try
            {
                Random.InitState(190627);
                if (follow != null)
                {
                    follow.enabled = false;
                }

                sheet = new Texture2D(frameWidth * columns, frameHeight * rows, TextureFormat.RGBA32, false);
                var fill = new Color[sheet.width * sheet.height];
                for (int i = 0; i < fill.Length; i++)
                {
                    fill[i] = new Color(0.01f, 0.01f, 0.014f, 1f);
                }

                sheet.SetPixels(fill);

                for (int i = 0; i < frames.Length; i++)
                {
                    var texture = CaptureDemoFrame(camera, rig, hero, dummy.transform, frames[i], captureWidth, captureHeight);
                    try
                    {
                        int column = i % columns;
                        int row = rows - 1 - (i / columns);
                        int cellX = column * frameWidth;
                        int cellY = row * frameHeight;
                        int innerX = cellX + frameGutter;
                        int innerY = cellY + frameGutter;
                        int innerWidth = frameWidth - (frameGutter * 2);
                        int innerHeight = frameHeight - (frameGutter * 2);
                        FillRect(sheet, innerX - frameBorder, innerY - frameBorder, innerWidth + (frameBorder * 2), innerHeight + (frameBorder * 2), new Color(0.07f, 0.08f, 0.095f, 1f));
                        CopyCroppedFrame(sheet, texture, innerX, innerY, innerWidth, innerHeight);
                    }
                    finally
                    {
                        Object.DestroyImmediate(texture);
                    }
                }

                sheet.Apply();
                System.IO.File.WriteAllBytes($"{EvidenceDir}/phase1_demo_contact_sheet.png", sheet.EncodeToPNG());
                AssetDatabase.Refresh();
                Debug.Log($"Captured Phase 1 demo contact sheet in {EvidenceDir}/phase1_demo_contact_sheet.png");
            }
            finally
            {
                if (sheet != null)
                {
                    Object.DestroyImmediate(sheet);
                }

                Random.state = randomState;
                ClearTransientVfx();
                hero.position = previousHeroPosition;
                hero.rotation = previousHeroRotation;
                rig.ApplyPose(Phase1HeroPose.Idle, 0.2f, Vector3.forward, 0f);
                camera.transform.position = previousCameraPosition;
                camera.transform.rotation = previousCameraRotation;
                camera.orthographicSize = previousCameraSize;
                if (follow != null)
                {
                    follow.enabled = followWasEnabled;
                }
            }
        }

        private static void CapturePose(string fileName, Phase1HeroPose pose, float poseTime, bool impact, bool death)
        {
            var camera = Camera.main;
            var rig = Object.FindFirstObjectByType<Phase1HeroRig>();
            var hero = rig.transform;
            var dummy = Object.FindFirstObjectByType<Phase1CombatDummy>();
            if (camera == null || rig == null || dummy == null)
            {
                throw new System.InvalidOperationException("Phase 1 scene is missing camera, hero rig, or combat dummy.");
            }

            ClearTransientVfx();
            hero.position = new Vector3(0f, 0.08f, -1.65f);
            hero.rotation = Quaternion.identity;
            rig.ApplyPose(pose, poseTime, Vector3.forward, impact ? 0.35f : 0f);
            if (pose == Phase1HeroPose.Attack)
            {
                Phase1VfxFactory.CreateSlashArc(hero.position + Vector3.forward * 0.82f + Vector3.up * 0.18f, Quaternion.identity);
            }

            if (impact)
            {
                Phase1VfxFactory.CreateHitBurst(dummy.transform.position + Vector3.up * 1.0f, Vector3.forward, new Color(0.8f, 1f, 1f, 1f));
            }

            if (death)
            {
                Phase1VfxFactory.CreateDeathEmbers(hero.position + Vector3.up * 0.75f);
            }

            var follow = camera.GetComponent<Phase1CameraFollow>();
            if (follow != null)
            {
                follow.enabled = false;
            }

            camera.transform.position = new Vector3(0f, 7.55f, -7.15f);
            camera.transform.rotation = Quaternion.Euler(51f, 0f, 0f);
            camera.orthographicSize = 4.65f;
            RenderCamera(camera, $"{EvidenceDir}/{fileName}", 1920, 1080);

            if (follow != null)
            {
                follow.enabled = true;
            }
        }

        private static Texture2D CaptureDemoFrame(Camera camera, Phase1HeroRig rig, Transform hero, Transform dummy, DemoFrame frame, int width, int height)
        {
            ClearTransientVfx();
            hero.position = frame.Position;
            hero.rotation = Quaternion.LookRotation(frame.Facing, Vector3.up);
            rig.ApplyPose(frame.Pose, frame.PoseTime, frame.Facing, frame.Flash);

            if (frame.Slash)
            {
                Phase1VfxFactory.CreateSlashArc(hero.position + (frame.Facing * 0.82f) + Vector3.up * 0.18f, Quaternion.LookRotation(frame.Facing, Vector3.up));
            }

            if (frame.Impact)
            {
                Phase1VfxFactory.CreateHitBurst(dummy.position + Vector3.up * 1.0f, frame.Facing, new Color(0.9f, 0.98f, 1f, 1f));
            }

            if (frame.Death)
            {
                Phase1VfxFactory.CreateDeathEmbers(hero.position + Vector3.up * 0.75f);
            }

            camera.transform.position = hero.position + new Vector3(0f, 7.55f, -7.15f);
            camera.transform.rotation = Quaternion.Euler(51f, 0f, 0f);
            camera.orthographicSize = 3.35f;
            return CaptureCameraTexture(camera, width, height);
        }

        private static void FillRect(Texture2D texture, int x, int y, int width, int height, Color color)
        {
            var pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            texture.SetPixels(x, y, width, height, pixels);
        }

        private static void CopyCroppedFrame(Texture2D sheet, Texture2D source, int x, int y, int width, int height)
        {
            var pixels = new Color[width * height];
            const float insetX = 0.13f;
            const float insetY = 0.08f;

            for (int targetY = 0; targetY < height; targetY++)
            {
                float v = Mathf.Lerp(insetY, 1f - insetY, (targetY + 0.5f) / height);
                for (int targetX = 0; targetX < width; targetX++)
                {
                    float u = Mathf.Lerp(insetX, 1f - insetX, (targetX + 0.5f) / width);
                    var color = source.GetPixelBilinear(u, v);
                    color.a = 1f;
                    pixels[(targetY * width) + targetX] = color;
                }
            }

            sheet.SetPixels(x, y, width, height, pixels);
        }

        private static void RenderCamera(Camera camera, string path, int width, int height)
        {
            var texture = CaptureCameraTexture(camera, width, height);
            System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());
            Object.DestroyImmediate(texture);
        }

        private static Texture2D CaptureCameraTexture(Camera camera, int width, int height)
        {
            var format = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;
            var target = new RenderTexture(width, height, 24, format);
            var previousTarget = camera.targetTexture;
            var previousActive = RenderTexture.active;
            try
            {
                camera.targetTexture = target;
                RenderTexture.active = target;
                camera.Render();

                var texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
                try
                {
                    texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
                    texture.Apply();
                    return texture;
                }
                catch
                {
                    Object.DestroyImmediate(texture);
                    throw;
                }
            }
            finally
            {
                camera.targetTexture = previousTarget;
                RenderTexture.active = previousActive;
                target.Release();
                Object.DestroyImmediate(target);
            }
        }

        private static void ClearTransientVfx()
        {
            foreach (var vfx in Object.FindObjectsByType<Phase1TimedVfx>(FindObjectsSortMode.None))
            {
                Object.DestroyImmediate(vfx.gameObject);
            }
        }

        private readonly struct DemoFrame
        {
            public readonly Phase1HeroPose Pose;
            public readonly float PoseTime;
            public readonly Vector3 Position;
            public readonly Vector3 Facing;
            public readonly bool Slash;
            public readonly bool Impact;
            public readonly bool Death;
            public readonly float Flash;

            public DemoFrame(Phase1HeroPose pose, float poseTime, Vector3 position, Vector3 facing, bool slash, bool impact, bool death, float flash)
            {
                Pose = pose;
                PoseTime = poseTime;
                Position = position;
                Facing = facing.normalized;
                Slash = slash;
                Impact = impact;
                Death = death;
                Flash = flash;
            }
        }
    }
}
