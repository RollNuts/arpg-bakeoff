using NightwatchFortress.Cameras;
using NightwatchFortress.Enemies;
using NightwatchFortress.Player;
using NightwatchFortress.UI;
using NightwatchFortress.Weapons;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NightwatchFortress.EditorTools
{
    public static class WolfForestFoundationSceneBuilder
    {
        public const string ScenePath = "Assets/Scenes/WolfForestFoundation.unity";

        [MenuItem("Nightwatch Fortress/Build Wolf Forest Foundation Scene")]
        public static void BuildScene()
        {
            EnsureFolder("Assets/Scenes");
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "WolfForestFoundation";

            ConfigureLighting();
            Transform root = new GameObject("夜番の砦 - 狼森 foundation").transform;
            BuildWolfForest(root);

            GameObject player = CreatePlayer(new Vector3(0f, 0.08f, -5.8f));
            PlayerVitals playerVitals = player.GetComponent<PlayerVitals>();
            EnemyBase wolf = CreateEnemy("小型狼 - fast pressure", new Vector3(-1.35f, 0.05f, -1.6f), 58, 48f, new Color(0.16f, 0.18f, 0.15f, 1f), null);
            AddPursuitAI(wolf, playerVitals, 3.8f, 1.15f, 1.32f, 7, 0.92f);
            WeaponInstance goblinDrop = CreateWeapon(WeaponType.Spear, WeaponDurabilityState.Chipped, new Vector3(4f, 0.4f, -1.2f), Quaternion.Euler(90f, 0f, 0f), false);
            goblinDrop.gameObject.SetActive(false);
            EnemyBase goblin = CreateEnemy("武器持ち小鬼 - drops spear", new Vector3(1.45f, 0.05f, -0.5f), 72, 62f, new Color(0.23f, 0.18f, 0.12f, 1f), goblinDrop);
            AddPursuitAI(goblin, playerVitals, 2.25f, 1.45f, 1.65f, 10, 1.18f);
            AddCarriedWeapon(goblin.transform, WeaponType.Spear, new Vector3(0.36f, 1.0f, -0.12f), Quaternion.Euler(62f, 0f, -20f));
            EnemyBase garm = CreateGarmTarget(new Vector3(0f, 0.2f, 2.8f));

            Camera camera = CreateCamera(player.transform);
            var hud = camera.gameObject.AddComponent<HUDController>();
            hud.Bind(player.GetComponent<PlayerVitals>(), player.GetComponent<WeaponInventory>());
            hud.ObserveEnemy(garm != null ? garm : wolf);

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            Debug.Log($"Built Nightwatch Fortress Wolf Forest foundation scene at {ScenePath}");
        }

        private static void ConfigureLighting()
        {
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
            RenderSettings.ambientSkyColor = new Color(0.06f, 0.09f, 0.14f, 1f);
            RenderSettings.ambientEquatorColor = new Color(0.035f, 0.045f, 0.04f, 1f);
            RenderSettings.ambientGroundColor = new Color(0.012f, 0.014f, 0.012f, 1f);
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0.035f, 0.045f, 0.052f, 1f);
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogDensity = 0.014f;
        }

        private static void BuildWolfForest(Transform root)
        {
            Material ground = CreateMaterial("wet forest ground", new Color(0.035f, 0.050f, 0.032f, 1f), 0f, 0.72f);
            Material grass = CreateMaterial("dark green moss", new Color(0.055f, 0.16f, 0.07f, 1f), 0f, 0.8f);
            Material bark = CreateMaterial("moonlit bark", new Color(0.12f, 0.08f, 0.052f, 1f), 0f, 0.62f);
            Material leaves = CreateMaterial("deep forest leaves", new Color(0.025f, 0.20f, 0.09f, 1f), 0f, 0.8f);
            Material wood = CreateMaterial("broken hunter wood", new Color(0.22f, 0.13f, 0.07f, 1f), 0f, 0.66f);
            Material moonStone = CreateMaterial("cold stream stone", new Color(0.16f, 0.20f, 0.22f, 1f), 0.05f, 0.32f);
            Material torchFlame = CreateMaterial("torch flame", new Color(1f, 0.34f, 0.08f, 1f), 0f, 0.2f, new Color(2f, 0.48f, 0.08f, 1f));
            Material mist = CreateMaterial("low blue night mist", new Color(0.08f, 0.13f, 0.16f, 1f), 0f, 0.92f);

            Primitive(root, "uneven moonlit forest floor", PrimitiveType.Cube, new Vector3(0f, -0.05f, 0f), new Vector3(16f, 0.1f, 15f), ground);
            Primitive(root, "shallow blue stream", PrimitiveType.Cube, new Vector3(-3.2f, 0.005f, 0.8f), new Vector3(1.2f, 0.035f, 9.5f), CreateMaterial("cold stream water", new Color(0.04f, 0.18f, 0.28f, 0.68f), 0f, 0.12f, new Color(0.0f, 0.08f, 0.12f, 1f)));
            Primitive(root, "fallen tree shortcut blocker", PrimitiveType.Cylinder, new Vector3(2.9f, 0.45f, 0.8f), new Vector3(0.36f, 2.8f, 0.36f), wood).transform.rotation = Quaternion.Euler(0f, 0f, 82f);
            Primitive(root, "hunter shack silhouette", PrimitiveType.Cube, new Vector3(5.2f, 0.95f, 3.8f), new Vector3(2.4f, 1.9f, 2.1f), wood);
            Primitive(root, "hunter shack dark roof", PrimitiveType.Cube, new Vector3(5.2f, 2.1f, 3.8f), new Vector3(2.75f, 0.28f, 2.45f), CreateMaterial("black wet roof", new Color(0.035f, 0.028f, 0.024f, 1f), 0f, 0.52f));
            DecorativePrimitive(root, "foreground trunk left framing player", PrimitiveType.Cylinder, new Vector3(-6.7f, 1.7f, -4.7f), new Vector3(0.54f, 1.7f, 0.54f), bark);
            DecorativePrimitive(root, "foreground trunk right framing weapons", PrimitiveType.Cylinder, new Vector3(6.35f, 1.55f, -4.15f), new Vector3(0.46f, 1.55f, 0.46f), bark);
            DecorativePrimitive(root, "low ground mist band near player", PrimitiveType.Cube, new Vector3(0f, 0.12f, -3.15f), new Vector3(8.8f, 0.035f, 0.42f), mist);
            DecorativePrimitive(root, "low ground mist band near stream", PrimitiveType.Cube, new Vector3(-1.3f, 0.13f, -0.55f), new Vector3(6.4f, 0.035f, 0.38f), mist);
            DecorativePrimitive(root, "low ground mist band behind boss", PrimitiveType.Cube, new Vector3(1.0f, 0.13f, 2.0f), new Vector3(7.8f, 0.035f, 0.44f), mist);

            for (int i = 0; i < 22; i++)
            {
                float x = Mathf.Sin(i * 1.73f) * 7f;
                float z = Mathf.Cos(i * 2.19f) * 6.2f;
                if (Mathf.Abs(x) < 1.4f && z < -2.2f)
                {
                    x += 2.4f;
                }

                Primitive(root, $"readable tree trunk {i}", PrimitiveType.Cylinder, new Vector3(x, 1.1f, z), new Vector3(0.28f, 1.1f + (i % 3) * 0.24f, 0.28f), bark);
                Primitive(root, $"moonlit leaf mass {i}", PrimitiveType.Sphere, new Vector3(x, 2.45f + (i % 2) * 0.25f, z), new Vector3(1.0f, 0.72f, 1.0f), leaves);
            }

            for (int i = 0; i < 14; i++)
            {
                float x = -6.8f + i * 1.05f;
                float z = -4.3f + Mathf.Sin(i * 1.9f) * 0.6f;
                Primitive(root, $"moss and grass clump {i}", PrimitiveType.Cube, new Vector3(x, 0.045f, z), new Vector3(0.65f, 0.06f, 0.22f), grass);
            }

            CreateTorch(root, new Vector3(-1.9f, 0f, -5.2f), torchFlame, wood);
            CreateTorch(root, new Vector3(2.0f, 0f, -3.6f), torchFlame, wood);
            CreateWeaponRack(root, new Vector3(-3.8f, 0f, -4.9f), wood);

            DecorativePrimitive(root, "pickup weapon amber marker", PrimitiveType.Cylinder, new Vector3(-0.85f, 0.035f, -5.05f), new Vector3(0.48f, 0.012f, 0.48f), CreateMaterial("pickup amber marker", new Color(1f, 0.48f, 0.08f, 1f), 0f, 0.4f, new Color(1.2f, 0.35f, 0.06f, 1f)));
            CreateGroundWeapon(WeaponType.Spear, WeaponDurabilityState.Normal, new Vector3(-0.85f, 0.42f, -5.05f), Quaternion.Euler(90f, 0f, -8f));
            CreateGroundWeapon(WeaponType.Spear, WeaponDurabilityState.Normal, new Vector3(-3.95f, 0.42f, -4.78f), Quaternion.Euler(90f, 0f, 8f));
            CreateGroundWeapon(WeaponType.GreatHammer, WeaponDurabilityState.Chipped, new Vector3(-3.25f, 0.42f, -4.88f), Quaternion.Euler(90f, 0f, -15f));
            CreateGroundWeapon(WeaponType.Torch, WeaponDurabilityState.Normal, new Vector3(-4.55f, 0.42f, -4.7f), Quaternion.Euler(85f, 0f, 22f));
            CreateGroundWeapon(WeaponType.LargeShield, WeaponDurabilityState.Normal, new Vector3(2.3f, 0.28f, -1.2f), Quaternion.Euler(90f, 15f, 0f));

            Light moon = new GameObject("cool blue moon key light").AddComponent<Light>();
            moon.type = LightType.Directional;
            moon.color = new Color(0.42f, 0.56f, 1f, 1f);
            moon.intensity = 1.15f;
            moon.shadows = LightShadows.Soft;
            moon.transform.rotation = Quaternion.Euler(48f, -24f, 10f);

            CreatePointLight("warm fort light behind start", new Vector3(0f, 2.1f, -7.2f), new Color(1f, 0.45f, 0.12f, 1f), 3.8f, 8f);
            CreatePointLight("cold stream rim", new Vector3(-3.2f, 0.6f, 0.2f), new Color(0.1f, 0.36f, 0.85f, 1f), 1.2f, 6f);

            _ = moonStone;
        }

        private static GameObject CreatePlayer(Vector3 position)
        {
            Material leather = CreateMaterial("nightwatch leather armor", new Color(0.12f, 0.075f, 0.045f, 1f), 0.05f, 0.48f);
            Material cloak = CreateMaterial("dark cloth cloak", new Color(0.025f, 0.033f, 0.04f, 1f), 0f, 0.7f);
            Material lantern = CreateMaterial("shoulder lantern amber", new Color(1f, 0.54f, 0.12f, 1f), 0.15f, 0.22f, new Color(1.8f, 0.55f, 0.12f, 1f));
            Material metal = CreateMaterial("worn iron", new Color(0.44f, 0.45f, 0.42f, 1f), 0.65f, 0.28f);

            GameObject root = new GameObject("PLAYER - Nightwatch hunter");
            root.transform.position = position;
            root.AddComponent<CharacterController>();
            var vitals = root.AddComponent<PlayerVitals>();
            var inventory = root.AddComponent<WeaponInventory>();
            root.AddComponent<PlayerController>();
            root.AddComponent<PlayerCombat>();

            Transform visual = new GameObject("visual silhouette - leather cloak lantern").transform;
            visual.SetParent(root.transform, false);
            Primitive(visual, "leather torso", PrimitiveType.Capsule, new Vector3(0f, 0.95f, 0f), new Vector3(0.58f, 0.86f, 0.42f), leather);
            Primitive(visual, "cloak back panel", PrimitiveType.Cube, new Vector3(0f, 0.86f, -0.27f), new Vector3(0.72f, 1.2f, 0.1f), cloak);
            Primitive(visual, "head", PrimitiveType.Sphere, new Vector3(0f, 1.68f, 0f), new Vector3(0.32f, 0.36f, 0.3f), CreateMaterial("cool skin shadow", new Color(0.62f, 0.52f, 0.44f, 1f), 0f, 0.48f));
            Primitive(visual, "right weapon arm", PrimitiveType.Capsule, new Vector3(0.43f, 1.08f, 0.18f), new Vector3(0.15f, 0.5f, 0.15f), leather).transform.rotation = Quaternion.Euler(48f, 0f, 24f);
            Primitive(visual, "left balance arm", PrimitiveType.Capsule, new Vector3(-0.38f, 1.05f, -0.02f), new Vector3(0.13f, 0.42f, 0.13f), leather).transform.rotation = Quaternion.Euler(55f, 0f, -32f);
            Primitive(visual, "left boot leg", PrimitiveType.Capsule, new Vector3(-0.18f, 0.32f, 0.02f), new Vector3(0.17f, 0.38f, 0.17f), leather);
            Primitive(visual, "right boot leg", PrimitiveType.Capsule, new Vector3(0.18f, 0.32f, 0.02f), new Vector3(0.17f, 0.38f, 0.17f), leather);
            Primitive(visual, "shoulder lantern", PrimitiveType.Cube, new Vector3(-0.44f, 1.36f, 0.12f), new Vector3(0.18f, 0.24f, 0.16f), lantern);
            Primitive(visual, "lantern metal cage", PrimitiveType.Cube, new Vector3(-0.44f, 1.36f, 0.12f), new Vector3(0.24f, 0.04f, 0.22f), metal);
            Primitive(visual, "waist dagger", PrimitiveType.Cube, new Vector3(0.36f, 0.88f, -0.08f), new Vector3(0.08f, 0.42f, 0.05f), metal).transform.rotation = Quaternion.Euler(0f, 0f, -28f);
            CreatePointLight("player lantern light", position + new Vector3(-0.42f, 1.45f, 0.12f), new Color(1f, 0.5f, 0.12f, 1f), 2.0f, 3.8f);
            Primitive(visual, "weapon holder belt", PrimitiveType.Cube, new Vector3(0f, 0.95f, -0.32f), new Vector3(0.82f, 0.08f, 0.08f), metal);

            WeaponInstance sword = CreateWeapon(WeaponType.OneHandedSword, WeaponDurabilityState.Normal, position, Quaternion.identity, false);
            WeaponInstance spear = CreateWeapon(WeaponType.Spear, WeaponDurabilityState.Chipped, position, Quaternion.identity, false);
            inventory.SetInitialWeapons(sword, spear);
            _ = vitals;
            return root;
        }

        private static EnemyBase CreateEnemy(string name, Vector3 position, int hp, float posture, Color color, WeaponInstance dropPrefab)
        {
            GameObject root = new GameObject(name);
            root.transform.position = position;
            Renderer renderer = Primitive(root.transform, "enemy body", PrimitiveType.Capsule, new Vector3(0f, 0.72f, 0f), new Vector3(0.62f, 0.74f, 0.62f), CreateMaterial($"{name} material", color, 0f, 0.62f)).GetComponent<Renderer>();
            ParticleSystem particles = root.AddComponent<ParticleSystem>();
            var main = particles.main;
            main.playOnAwake = false;
            main.loop = false;
            main.startLifetime = 0.18f;
            main.startSpeed = 3.2f;
            main.startSize = 0.08f;
            main.startColor = new Color(0.7f, 0.03f, 0.02f, 1f);

            EnemyBase enemy = root.AddComponent<EnemyBase>();
            enemy.Configure(name, hp, posture, renderer, particles, dropPrefab);
            return enemy;
        }

        private static void AddPursuitAI(EnemyBase enemy, PlayerVitals target, float speed, float stopDistance, float attackRange, int damage, float cooldown)
        {
            EnemyPursuitAI ai = enemy.gameObject.AddComponent<EnemyPursuitAI>();
            ai.Configure(target, speed, stopDistance, attackRange, damage, cooldown);
        }

        private static EnemyBase CreateGarmTarget(Vector3 position)
        {
            Material hide = CreateMaterial("Garm prototype dark hide", new Color(0.055f, 0.06f, 0.065f, 1f), 0f, 0.62f);
            Material eye = CreateMaterial("Garm eye amber", new Color(1f, 0.42f, 0.05f, 1f), 0f, 0.2f, new Color(2f, 0.65f, 0.1f, 1f));
            Material scar = CreateMaterial("Garm fresh red scar", new Color(0.72f, 0.045f, 0.03f, 1f), 0f, 0.44f, new Color(0.55f, 0.02f, 0.01f, 1f));
            GameObject root = new GameObject("GARM PROTOTYPE - large embed target");
            root.transform.position = position;
            Renderer renderer = Primitive(root.transform, "large wolf body", PrimitiveType.Capsule, new Vector3(0f, 0.95f, 0f), new Vector3(1.35f, 1.0f, 2.05f), hide).GetComponent<Renderer>();
            Primitive(root.transform, "large wolf head", PrimitiveType.Sphere, new Vector3(0f, 1.25f, -1.25f), new Vector3(0.75f, 0.55f, 0.6f), hide);
            Primitive(root.transform, "long wolf muzzle", PrimitiveType.Cube, new Vector3(0f, 1.12f, -1.84f), new Vector3(0.42f, 0.22f, 0.42f), hide);
            Primitive(root.transform, "front left leg silhouette", PrimitiveType.Capsule, new Vector3(-0.48f, 0.45f, -0.62f), new Vector3(0.24f, 0.55f, 0.24f), hide);
            Primitive(root.transform, "front right leg silhouette", PrimitiveType.Capsule, new Vector3(0.48f, 0.45f, -0.62f), new Vector3(0.24f, 0.55f, 0.24f), hide);
            Primitive(root.transform, "rear left leg silhouette", PrimitiveType.Capsule, new Vector3(-0.5f, 0.45f, 0.72f), new Vector3(0.25f, 0.55f, 0.25f), hide);
            Primitive(root.transform, "rear right leg silhouette", PrimitiveType.Capsule, new Vector3(0.5f, 0.45f, 0.72f), new Vector3(0.25f, 0.55f, 0.25f), hide);
            Primitive(root.transform, "glowing eye left", PrimitiveType.Sphere, new Vector3(-0.22f, 1.34f, -1.78f), new Vector3(0.08f, 0.08f, 0.08f), eye);
            Primitive(root.transform, "glowing eye right", PrimitiveType.Sphere, new Vector3(0.22f, 1.34f, -1.78f), new Vector3(0.08f, 0.08f, 0.08f), eye);
            DecorativePrimitive(root.transform, "red slash scar across muzzle", PrimitiveType.Cube, new Vector3(0f, 1.34f, -1.91f), new Vector3(0.62f, 0.035f, 0.035f), scar).transform.rotation = Quaternion.Euler(0f, 0f, -16f);
            DecorativePrimitive(root.transform, "red body scar left", PrimitiveType.Cube, new Vector3(-0.52f, 1.1f, -0.15f), new Vector3(0.055f, 0.46f, 0.04f), scar).transform.rotation = Quaternion.Euler(18f, 0f, 28f);
            DecorativePrimitive(root.transform, "red body scar right", PrimitiveType.Cube, new Vector3(0.54f, 1.02f, 0.4f), new Vector3(0.055f, 0.5f, 0.04f), scar).transform.rotation = Quaternion.Euler(-12f, 0f, -24f);
            Primitive(root.transform, "breakable tail read", PrimitiveType.Cylinder, new Vector3(0f, 1.05f, 1.42f), new Vector3(0.16f, 1.25f, 0.16f), hide).transform.rotation = Quaternion.Euler(72f, 0f, 0f);
            GameObject legTarget = Primitive(root.transform, "leg embed target - spear stops charge", PrimitiveType.Sphere, new Vector3(-0.55f, 0.62f, -0.35f), new Vector3(0.28f, 0.28f, 0.28f), scar);
            legTarget.AddComponent<EmbeddedWeaponTarget>();
            CreatePointLight("Garm moon rim light", position + new Vector3(0f, 2.2f, 2.0f), new Color(0.28f, 0.48f, 1f, 1f), 2.8f, 5.5f);

            ParticleSystem particles = root.AddComponent<ParticleSystem>();
            var main = particles.main;
            main.playOnAwake = false;
            main.loop = false;
            main.startLifetime = 0.22f;
            main.startSpeed = 3.4f;
            main.startSize = 0.1f;
            main.startColor = new Color(0.8f, 0.04f, 0.02f, 1f);

            EnemyBase enemy = root.AddComponent<EnemyBase>();
            enemy.Configure("大狼ガルム - 槍を脚へ刺せ", 260, 180f, renderer, particles, null);
            return enemy;
        }

        private static void CreateWeaponRack(Transform parent, Vector3 position, Material wood)
        {
            Primitive(parent, "weapon rack cross beam", PrimitiveType.Cube, position + new Vector3(0f, 0.82f, 0f), new Vector3(1.8f, 0.12f, 0.12f), wood);
            Primitive(parent, "weapon rack left leg", PrimitiveType.Cube, position + new Vector3(-0.82f, 0.42f, 0f), new Vector3(0.12f, 0.84f, 0.12f), wood);
            Primitive(parent, "weapon rack right leg", PrimitiveType.Cube, position + new Vector3(0.82f, 0.42f, 0f), new Vector3(0.12f, 0.84f, 0.12f), wood);
        }

        private static void CreateTorch(Transform parent, Vector3 position, Material flame, Material wood)
        {
            Primitive(parent, "torch stand", PrimitiveType.Cylinder, position + new Vector3(0f, 0.62f, 0f), new Vector3(0.08f, 0.62f, 0.08f), wood);
            Primitive(parent, "torch flame", PrimitiveType.Sphere, position + new Vector3(0f, 1.3f, 0f), new Vector3(0.17f, 0.26f, 0.17f), flame);
            CreatePointLight("torch warm pool", position + new Vector3(0f, 1.5f, 0f), new Color(1f, 0.38f, 0.09f, 1f), 2.2f, 4.8f);
        }

        private static WeaponInstance CreateGroundWeapon(WeaponType type, WeaponDurabilityState state, Vector3 position, Quaternion rotation)
        {
            return CreateWeapon(type, state, position, rotation, true);
        }

        private static WeaponInstance CreateWeapon(WeaponType type, WeaponDurabilityState state, Vector3 position, Quaternion rotation, bool onGround)
        {
            GameObject root = new GameObject($"{WeaponUtility.GetDisplayName(type)} - {WeaponUtility.GetDurabilityName(state)}");
            root.transform.position = position;
            root.transform.rotation = rotation;

            Material material = CreateMaterial($"{type} material", WeaponUtility.GetWeaponColor(type), type == WeaponType.Torch ? 0f : 0.55f, 0.35f, type == WeaponType.Torch ? new Color(1.4f, 0.35f, 0.08f, 1f) : (Color?)null);
            CreateWeaponVisual(root.transform, type, material);
            var rigidbody = root.AddComponent<Rigidbody>();
            rigidbody.useGravity = onGround;
            rigidbody.isKinematic = !onGround;
            BoxCollider collider = root.AddComponent<BoxCollider>();
            collider.size = GetWeaponColliderSize(type);
            var weapon = root.AddComponent<WeaponInstance>();
            weapon.Configure(type, state, GetWeaponDamage(type), GetWeaponPosture(type));
            root.AddComponent<WeaponPickup>();
            root.AddComponent<ThrownWeaponImpact>();
            return weapon;
        }

        private static void AddCarriedWeapon(Transform parent, WeaponType type, Vector3 localPosition, Quaternion localRotation)
        {
            Transform visual = new GameObject($"visible carried {WeaponUtility.GetDisplayName(type)}").transform;
            visual.SetParent(parent, false);
            visual.localPosition = localPosition;
            visual.localRotation = localRotation;
            Material material = CreateMaterial($"carried {type} material", WeaponUtility.GetWeaponColor(type), 0.45f, 0.36f);
            CreateWeaponVisual(visual, type, material);
        }

        private static void CreateWeaponVisual(Transform parent, WeaponType type, Material mainMaterial)
        {
            Material darkGrip = CreateMaterial($"{type} dark grip", new Color(0.11f, 0.075f, 0.045f, 1f), 0f, 0.58f);
            Material iron = CreateMaterial($"{type} bright edge", new Color(0.72f, 0.72f, 0.66f, 1f), 0.72f, 0.22f);
            Material flame = CreateMaterial($"{type} live flame", new Color(1f, 0.42f, 0.08f, 1f), 0f, 0.25f, new Color(1.6f, 0.38f, 0.08f, 1f));

            switch (type)
            {
                case WeaponType.Spear:
                    DecorativePrimitive(parent, "spear long shaft", PrimitiveType.Cylinder, Vector3.zero, new Vector3(0.045f, 0.92f, 0.045f), darkGrip);
                    DecorativePrimitive(parent, "spear bright head", PrimitiveType.Cube, new Vector3(0f, 0.58f, 0f), new Vector3(0.16f, 0.24f, 0.16f), iron);
                    DecorativePrimitive(parent, "spear red wrap", PrimitiveType.Cube, new Vector3(0f, -0.18f, 0f), new Vector3(0.12f, 0.08f, 0.12f), mainMaterial);
                    return;
                case WeaponType.GreatHammer:
                    DecorativePrimitive(parent, "hammer long handle", PrimitiveType.Cylinder, new Vector3(0f, -0.12f, 0f), new Vector3(0.06f, 0.82f, 0.06f), darkGrip);
                    DecorativePrimitive(parent, "hammer heavy head", PrimitiveType.Cube, new Vector3(0f, 0.48f, 0f), new Vector3(0.62f, 0.25f, 0.34f), mainMaterial);
                    DecorativePrimitive(parent, "hammer iron cap", PrimitiveType.Cube, new Vector3(0f, 0.48f, 0f), new Vector3(0.68f, 0.06f, 0.39f), iron);
                    return;
                case WeaponType.Bow:
                    DecorativePrimitive(parent, "bow curved body", PrimitiveType.Cylinder, Vector3.zero, new Vector3(0.045f, 0.78f, 0.045f), mainMaterial);
                    DecorativePrimitive(parent, "bow string", PrimitiveType.Cube, new Vector3(0.18f, 0f, 0f), new Vector3(0.018f, 1.35f, 0.018f), iron);
                    DecorativePrimitive(parent, "bow grip", PrimitiveType.Cube, Vector3.zero, new Vector3(0.16f, 0.16f, 0.12f), darkGrip);
                    return;
                case WeaponType.Torch:
                    DecorativePrimitive(parent, "torch wood shaft", PrimitiveType.Cylinder, new Vector3(0f, -0.08f, 0f), new Vector3(0.055f, 0.62f, 0.055f), darkGrip);
                    DecorativePrimitive(parent, "torch flame head", PrimitiveType.Sphere, new Vector3(0f, 0.45f, 0f), new Vector3(0.17f, 0.24f, 0.17f), flame);
                    return;
                case WeaponType.LargeShield:
                    DecorativePrimitive(parent, "shield broad face", PrimitiveType.Cube, Vector3.zero, new Vector3(0.66f, 0.12f, 0.86f), mainMaterial);
                    DecorativePrimitive(parent, "shield center boss", PrimitiveType.Sphere, new Vector3(0f, 0.08f, 0f), new Vector3(0.18f, 0.1f, 0.18f), iron);
                    DecorativePrimitive(parent, "shield iron rim", PrimitiveType.Cube, new Vector3(0f, 0.09f, 0f), new Vector3(0.75f, 0.04f, 0.95f), iron);
                    return;
                case WeaponType.OneHandedSword:
                    DecorativePrimitive(parent, "sword bright blade", PrimitiveType.Cube, new Vector3(0f, 0.26f, 0f), new Vector3(0.08f, 0.84f, 0.04f), iron);
                    DecorativePrimitive(parent, "sword crossguard", PrimitiveType.Cube, new Vector3(0f, -0.2f, 0f), new Vector3(0.42f, 0.055f, 0.09f), mainMaterial);
                    DecorativePrimitive(parent, "sword grip", PrimitiveType.Cylinder, new Vector3(0f, -0.42f, 0f), new Vector3(0.055f, 0.22f, 0.055f), darkGrip);
                    return;
                case WeaponType.Dagger:
                    DecorativePrimitive(parent, "dagger bright blade", PrimitiveType.Cube, new Vector3(0f, 0.14f, 0f), new Vector3(0.075f, 0.42f, 0.035f), iron);
                    DecorativePrimitive(parent, "dagger dark grip", PrimitiveType.Cylinder, new Vector3(0f, -0.2f, 0f), new Vector3(0.05f, 0.18f, 0.05f), darkGrip);
                    return;
                default:
                    DecorativePrimitive(parent, "axe handle", PrimitiveType.Cylinder, Vector3.zero, new Vector3(0.055f, 0.68f, 0.055f), darkGrip);
                    DecorativePrimitive(parent, "axe blade wedge", PrimitiveType.Cube, new Vector3(0.18f, 0.25f, 0f), new Vector3(0.34f, 0.24f, 0.08f), iron);
                    DecorativePrimitive(parent, "axe red wrap", PrimitiveType.Cube, new Vector3(0f, -0.1f, 0f), new Vector3(0.11f, 0.08f, 0.11f), mainMaterial);
                    return;
            }
        }

        private static Vector3 GetWeaponColliderSize(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Spear:
                    return new Vector3(0.28f, 1.55f, 0.28f);
                case WeaponType.GreatHammer:
                    return new Vector3(0.84f, 1.25f, 0.56f);
                case WeaponType.LargeShield:
                    return new Vector3(0.9f, 0.28f, 1.08f);
                case WeaponType.Bow:
                    return new Vector3(0.42f, 1.38f, 0.24f);
                default:
                    return new Vector3(0.42f, 1.05f, 0.32f);
            }
        }

        private static int GetWeaponDamage(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.GreatHammer:
                    return 30;
                case WeaponType.Spear:
                    return 20;
                case WeaponType.Bow:
                    return 16;
                case WeaponType.LargeShield:
                    return 12;
                case WeaponType.Torch:
                    return 10;
                default:
                    return 18;
            }
        }

        private static float GetWeaponPosture(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.GreatHammer:
                    return 34f;
                case WeaponType.LargeShield:
                    return 24f;
                case WeaponType.Spear:
                    return 18f;
                default:
                    return 14f;
            }
        }

        private static Camera CreateCamera(Transform target)
        {
            GameObject cameraObject = new GameObject("Main Camera - readable night forest");
            Camera camera = cameraObject.AddComponent<Camera>();
            camera.tag = "MainCamera";
            camera.fieldOfView = 42f;
            camera.nearClipPlane = 0.1f;
            camera.farClipPlane = 90f;
            camera.backgroundColor = new Color(0.012f, 0.016f, 0.024f, 1f);
            camera.clearFlags = CameraClearFlags.SolidColor;
            var follow = cameraObject.AddComponent<ThirdPersonFollowCamera>();
            follow.SetTarget(target);
            target.GetComponent<PlayerController>().SetCamera(camera.transform);
            return camera;
        }

        private static GameObject Primitive(Transform parent, string name, PrimitiveType type, Vector3 localPosition, Vector3 localScale, Material material)
        {
            GameObject item = GameObject.CreatePrimitive(type);
            item.name = name;
            item.transform.SetParent(parent, false);
            item.transform.localPosition = localPosition;
            item.transform.localScale = localScale;
            item.GetComponent<Renderer>().material = material;
            return item;
        }

        private static GameObject DecorativePrimitive(Transform parent, string name, PrimitiveType type, Vector3 localPosition, Vector3 localScale, Material material)
        {
            GameObject item = Primitive(parent, name, type, localPosition, localScale, material);
            Collider collider = item.GetComponent<Collider>();
            if (collider != null)
            {
                Object.DestroyImmediate(collider);
            }

            return item;
        }

        private static Material CreateMaterial(string name, Color color, float metallic, float smoothness)
        {
            return CreateMaterial(name, color, metallic, smoothness, null);
        }

        private static Material CreateMaterial(string name, Color color, float metallic, float smoothness, Color? emission)
        {
            var material = new Material(Shader.Find("Standard"))
            {
                name = name,
                color = color
            };
            material.SetFloat("_Metallic", metallic);
            material.SetFloat("_Glossiness", 1f - smoothness);
            if (emission.HasValue)
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", emission.Value);
            }

            return material;
        }

        private static void CreatePointLight(string name, Vector3 position, Color color, float intensity, float range)
        {
            Light light = new GameObject(name).AddComponent<Light>();
            light.type = LightType.Point;
            light.transform.position = position;
            light.color = color;
            light.intensity = intensity;
            light.range = range;
            light.shadows = LightShadows.Soft;
        }

        private static void EnsureFolder(string path)
        {
            if (AssetDatabase.IsValidFolder(path))
            {
                return;
            }

            string[] parts = path.Split('/');
            string current = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                string next = $"{current}/{parts[i]}";
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                }

                current = next;
            }
        }
    }
}
