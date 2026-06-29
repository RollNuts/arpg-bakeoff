using ArpgBakeoff.Phase1;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArpgBakeoff.Phase1.Editor
{
    public static class Phase1SceneBuilder
    {
        private const string ScenePath = "Assets/Scenes/Phase1PlayerSlice.unity";

        [MenuItem("ARPG Bakeoff/Phase 1/Build Player Slice Scene")]
        public static void BuildScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "Phase1PlayerSlice";

            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
            RenderSettings.ambientSkyColor = new Color(0.13f, 0.15f, 0.18f, 1f);
            RenderSettings.ambientEquatorColor = new Color(0.08f, 0.055f, 0.045f, 1f);
            RenderSettings.ambientGroundColor = new Color(0.02f, 0.018f, 0.02f, 1f);
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.035f, 0.03f, 0.035f, 1f);
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogDensity = 0.014f;

            var root = new GameObject("Phase 1 cathedral combat slice");
            BuildFloor(root.transform);
            BuildWorldDressing(root.transform);

            var hero = new GameObject("PLAYER - Aurelian Foldblade");
            hero.transform.position = new Vector3(0f, 0.08f, -1.65f);
            var controller = hero.AddComponent<Phase1HeroController>();
            hero.GetComponent<Phase1HeroRig>().EnsureBuilt();

            var dummy = new GameObject("HIT TEST - crimson training idol");
            dummy.transform.position = new Vector3(0f, 0.05f, 1.45f);
            dummy.AddComponent<Phase1CombatDummy>();

            var cameraObject = new GameObject("Main Camera - top down combat read");
            var camera = cameraObject.AddComponent<Camera>();
            camera.tag = "MainCamera";
            camera.orthographic = true;
            camera.orthographicSize = 4.65f;
            camera.nearClipPlane = 0.1f;
            camera.farClipPlane = 80f;
            camera.transform.position = new Vector3(0f, 7.55f, -7.15f);
            camera.transform.rotation = Quaternion.Euler(51f, 0f, 0f);
            camera.backgroundColor = new Color(0.018f, 0.018f, 0.024f, 1f);
            camera.clearFlags = CameraClearFlags.SolidColor;
            var follow = cameraObject.AddComponent<Phase1CameraFollow>();
            follow.SetTarget(hero.transform);
            var hud = cameraObject.AddComponent<Phase1HudOverlay>();
            hud.SetHero(controller);

            var directional = new GameObject("cool moon key light").AddComponent<Light>();
            directional.type = LightType.Directional;
            directional.intensity = 1.8f;
            directional.color = new Color(0.68f, 0.78f, 1f, 1f);
            directional.transform.rotation = Quaternion.Euler(50f, -32f, 12f);
            directional.shadows = LightShadows.Soft;

            CreatePointLight("hero cyan rim light", new Vector3(-1.6f, 2.2f, -2.1f), new Color(0.18f, 0.85f, 1f, 1f), 2.8f, 5.5f);
            CreatePointLight("hero warm silhouette fill", new Vector3(1.4f, 1.45f, -1.0f), new Color(1f, 0.42f, 0.18f, 1f), 1.45f, 3.1f);
            CreatePointLight("warm candle cluster left", new Vector3(-3.7f, 1.3f, 1.9f), new Color(1f, 0.46f, 0.18f, 1f), 3.4f, 4.2f);
            CreatePointLight("warm candle cluster right", new Vector3(3.7f, 1.3f, 1.9f), new Color(1f, 0.46f, 0.18f, 1f), 3.4f, 4.2f);

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            Debug.Log($"Built Phase 1 player slice scene at {ScenePath}");
        }

        public static string GetScenePath()
        {
            return ScenePath;
        }

        private static void BuildFloor(Transform root)
        {
            var floorRoot = new GameObject("dense gothic stone floor, readable center").transform;
            floorRoot.SetParent(root, false);
            var baseStone = Phase1VisualUtil.CreateMaterial("continuous dark cathedral base stone", new Color(0.105f, 0.112f, 0.128f, 1f), 0f, 0.34f);
            var darkStone = Phase1VisualUtil.CreateMaterial("dark cracked stone", new Color(0.058f, 0.058f, 0.07f, 1f), 0f, 0.28f);
            var carpet = Phase1VisualUtil.CreateMaterial("worn oxblood runner carpet", new Color(0.32f, 0.018f, 0.035f, 1f), 0f, 0.72f);
            var gold = Phase1VisualUtil.CreateMaterial("thin muted gold inlay", new Color(0.62f, 0.39f, 0.13f, 1f), 0.35f, 0.5f);
            var sigil = Phase1VisualUtil.CreateMaterial("nearly hidden cyan floor etching", new Color(0.02f, 0.36f, 0.48f, 0.055f), 0f, 0.5f, new Color(0f, 0.08f, 0.12f, 1f), true);
            var blood = Phase1VisualUtil.CreateMaterial("old dry blood stains", new Color(0.18f, 0.015f, 0.018f, 0.68f), 0f, 0.25f, null, true);

            Phase1VisualUtil.MeshObject(
                "continuous underfloor stone field",
                Phase1VisualUtil.BeveledBox("Continuous floor field", new Vector3(11.7f, 0.04f, 11.7f), 0.035f),
                baseStone,
                floorRoot,
                new Vector3(0f, -0.025f, 0f),
                Quaternion.identity,
                Vector3.one);

            for (int x = -4; x <= 4; x++)
            {
                for (int z = -4; z <= 4; z++)
                {
                    float noise = Mathf.PerlinNoise((x + 13) * 0.41f, (z + 7) * 0.49f);
                    float tint = noise * 0.055f;
                    float width = 1.18f + Mathf.PerlinNoise(x * 0.77f + 4.2f, z * 0.31f + 1.1f) * 0.36f;
                    float depth = 1.1f + Mathf.PerlinNoise(x * 0.29f + 3.7f, z * 0.83f + 5.2f) * 0.42f;
                    float xOffset = (Mathf.PerlinNoise(x * 1.3f + 8.1f, z * 0.6f + 2.4f) - 0.5f) * 0.22f;
                    float zOffset = (Mathf.PerlinNoise(x * 0.4f + 9.7f, z * 1.1f + 7.1f) - 0.5f) * 0.22f;
                    var mat = Phase1VisualUtil.CreateMaterial($"irregular stone slab {x},{z}", new Color(0.105f + tint, 0.112f + tint, 0.13f + tint, 1f), 0f, 0.32f);
                    var tile = Phase1VisualUtil.MeshObject(
                        $"offset stone slab {x},{z}",
                        Phase1VisualUtil.BeveledBox("Stone slab", new Vector3(width, 0.045f, depth), 0.026f),
                        mat,
                        floorRoot,
                        new Vector3((x * 1.22f) + xOffset, 0.005f, (z * 1.22f) + zOffset),
                        Quaternion.Euler(0f, (((x * 17) + (z * 11)) % 7 - 3) * 1.7f, 0f),
                        Vector3.one);
                    tile.isStatic = true;
                }
            }

            Phase1VisualUtil.MeshObject("central worn red carpet one", Phase1VisualUtil.BeveledBox("Carpet slab", new Vector3(1.34f, 0.025f, 4.25f), 0.025f), carpet, floorRoot, new Vector3(0f, 0.055f, -0.35f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("central torn red carpet two", Phase1VisualUtil.BeveledBox("Carpet tear", new Vector3(1.05f, 0.026f, 1.75f), 0.025f), carpet, floorRoot, new Vector3(0.16f, 0.058f, 2.3f), Quaternion.Euler(0f, -4f, 0f), Vector3.one);
            Phase1VisualUtil.MeshObject("left gold carpet inlay", Phase1VisualUtil.BeveledBox("Gold rail", new Vector3(0.055f, 0.035f, 5.6f), 0.01f), gold, floorRoot, new Vector3(-0.78f, 0.075f, 0.2f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("right gold carpet inlay", Phase1VisualUtil.BeveledBox("Gold rail", new Vector3(0.055f, 0.035f, 5.6f), 0.01f), gold, floorRoot, new Vector3(0.78f, 0.075f, 0.2f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("small etched floor sigil", Phase1VisualUtil.RingSector("Small sigil ring", 0.42f, 0.48f, 315f, 28), sigil, floorRoot, new Vector3(0f, 0.092f, -0.9f), Quaternion.identity, Vector3.one);

            for (int i = 0; i < 18; i++)
            {
                float x = Mathf.Sin(i * 2.31f) * RandomRange(0.4f, 4.6f);
                float z = Mathf.Cos(i * 1.77f) * RandomRange(0.3f, 4.6f);
                var material = i % 5 == 0 ? blood : darkStone;
                Vector3 size = i % 5 == 0 ? new Vector3(RandomRange(0.35f, 0.9f), 0.014f, RandomRange(0.12f, 0.34f)) : new Vector3(RandomRange(0.5f, 1.6f), 0.016f, RandomRange(0.035f, 0.07f));
                Phase1VisualUtil.MeshObject($"floor grime crack or stain {i}", Phase1VisualUtil.BeveledBox("Floor scar", size, 0.01f), material, floorRoot, new Vector3(x, 0.105f, z), Quaternion.Euler(0f, i * 37f, 0f), Vector3.one);
            }

        }

        private static void BuildWorldDressing(Transform root)
        {
            var propRoot = new GameObject("outer gothic props that frame the combat").transform;
            propRoot.SetParent(root, false);
            var stone = Phase1VisualUtil.CreateMaterial("carved dark gothic stone", new Color(0.16f, 0.16f, 0.18f, 1f), 0f, 0.35f);
            var brass = Phase1VisualUtil.CreateMaterial("old brass prop trim", new Color(0.54f, 0.32f, 0.11f, 1f), 0.35f, 0.42f);
            var flame = Phase1VisualUtil.CreateMaterial("warm torch flame", new Color(1f, 0.38f, 0.08f, 0.82f), 0f, 0.4f, new Color(2f, 0.45f, 0.08f, 1f), true);

            for (int i = 0; i < 4; i++)
            {
                float x = i < 2 ? -4.4f : 4.4f;
                float z = i % 2 == 0 ? -3.7f : 3.7f;
                CreateColumn(propRoot, new Vector3(x, 0f, z), stone, brass);
            }

            for (int i = 0; i < 8; i++)
            {
                float x = i % 2 == 0 ? -3.2f : 3.2f;
                float z = -3.2f + (i / 2) * 1.95f;
                Phase1VisualUtil.MeshObject($"slender brass candle stand {i}", Phase1VisualUtil.TaperedCylinder("Candle stand", 8, 0.78f, 0.045f, 0.07f), brass, propRoot, new Vector3(x, 0.42f, z), Quaternion.identity, Vector3.one);
                Phase1VisualUtil.MeshObject($"small flame readable prop {i}", Phase1VisualUtil.TaperedCylinder("Flame diamond", 5, 0.28f, 0.02f, 0.11f), flame, propRoot, new Vector3(x, 0.94f, z), Quaternion.Euler(0f, i * 17f, 0f), Vector3.one);
                if (i % 2 == 0)
                {
                    CreatePointLight($"candle point {i}", new Vector3(x, 1.1f, z), new Color(1f, 0.4f, 0.13f, 1f), 1.2f, 2.5f);
                }
            }

            Phase1VisualUtil.MeshObject("background altar silhouette base", Phase1VisualUtil.BeveledBox("Altar base", new Vector3(2.2f, 0.7f, 0.78f), 0.08f), stone, propRoot, new Vector3(0f, 0.38f, 4.72f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("background altar golden lip", Phase1VisualUtil.BeveledBox("Altar lip", new Vector3(2.42f, 0.12f, 0.9f), 0.035f), brass, propRoot, new Vector3(0f, 0.79f, 4.72f), Quaternion.identity, Vector3.one);
        }

        private static void CreateColumn(Transform parent, Vector3 position, Material stone, Material brass)
        {
            Phase1VisualUtil.MeshObject("gothic column base", Phase1VisualUtil.TaperedCylinder("Column base", 10, 0.28f, 0.55f, 0.42f), stone, parent, position + Vector3.up * 0.14f, Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("gothic column shaft", Phase1VisualUtil.TaperedCylinder("Column shaft", 10, 1.9f, 0.28f, 0.24f), stone, parent, position + Vector3.up * 1.22f, Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("gothic column capital", Phase1VisualUtil.TaperedCylinder("Column capital", 10, 0.32f, 0.36f, 0.5f), brass, parent, position + Vector3.up * 2.32f, Quaternion.identity, Vector3.one);
        }

        private static void CreatePointLight(string name, Vector3 position, Color color, float intensity, float range)
        {
            var light = new GameObject(name).AddComponent<Light>();
            light.type = LightType.Point;
            light.transform.position = position;
            light.color = color;
            light.intensity = intensity;
            light.range = range;
            light.shadows = LightShadows.Soft;
        }

        private static float RandomRange(float min, float max)
        {
            return Mathf.Lerp(min, max, Mathf.Abs(Mathf.Sin((min * 19.13f) + (max * 7.37f))));
        }
    }
}
