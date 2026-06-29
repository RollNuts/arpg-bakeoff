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

        private static void RenderCamera(Camera camera, string path, int width, int height)
        {
            var target = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
            var previousTarget = camera.targetTexture;
            var previousActive = RenderTexture.active;
            camera.targetTexture = target;
            RenderTexture.active = target;
            camera.Render();

            var texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
            texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            texture.Apply();
            System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());

            camera.targetTexture = previousTarget;
            RenderTexture.active = previousActive;
            target.Release();
            Object.DestroyImmediate(texture);
            Object.DestroyImmediate(target);
        }

        private static void ClearTransientVfx()
        {
            foreach (var vfx in Object.FindObjectsByType<Phase1TimedVfx>(FindObjectsSortMode.None))
            {
                Object.DestroyImmediate(vfx.gameObject);
            }
        }
    }
}
