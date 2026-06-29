using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public static class Phase1VfxFactory
    {
        public static GameObject CreateSlashArc(Vector3 position, Quaternion rotation)
        {
            var root = new GameObject("readable forward foldblade slash");
            root.transform.position = position + Vector3.up * 0.72f;
            root.transform.rotation = rotation;

            var core = Phase1VisualUtil.CreateMaterial("white sword slash core", new Color(0.92f, 0.98f, 1f, 0.92f), 0f, 0.85f, new Color(0.85f, 1.4f, 1.7f, 1f), true);
            var trail = Phase1VisualUtil.CreateMaterial("cyan sword slash trail", new Color(0.14f, 0.72f, 1f, 0.52f), 0f, 0.75f, new Color(0.05f, 0.9f, 1.8f, 1f), true);
            var ember = Phase1VisualUtil.CreateMaterial("small warm slash chips", new Color(1f, 0.42f, 0.12f, 0.75f), 0f, 0.45f, new Color(1.2f, 0.22f, 0.04f, 1f), true);

            Phase1VisualUtil.MeshObject("white blade core stroke", Phase1VisualUtil.BeveledBox("Slash core stroke", new Vector3(1.45f, 0.055f, 0.07f), 0.016f), core, root.transform, new Vector3(0.2f, 0f, 0.32f), Quaternion.Euler(0f, 34f, -7f), Vector3.one);
            Phase1VisualUtil.MeshObject("cyan trailing broad stroke", Phase1VisualUtil.BeveledBox("Slash broad stroke", new Vector3(1.75f, 0.035f, 0.12f), 0.014f), trail, root.transform, new Vector3(0.06f, -0.035f, 0.16f), Quaternion.Euler(0f, 34f, -7f), Vector3.one);
            Phase1VisualUtil.MeshObject("thin finishing sword streak", Phase1VisualUtil.BeveledBox("Slash finish streak", new Vector3(0.95f, 0.035f, 0.045f), 0.012f), core, root.transform, new Vector3(0.46f, 0.04f, 0.62f), Quaternion.Euler(0f, 18f, 10f), Vector3.one);

            for (int i = 0; i < 5; i++)
            {
                Phase1VisualUtil.MeshObject(
                    $"warm chip from sword impact {i}",
                    Phase1VisualUtil.BeveledBox("Slash chip", new Vector3(0.16f, 0.025f, 0.045f), 0.008f),
                    ember,
                    root.transform,
                    new Vector3(-0.35f + i * 0.18f, -0.04f, 0.72f + i * 0.04f),
                    Quaternion.Euler(0f, 80f + i * 19f, 0f),
                    Vector3.one);
            }

            var timed = root.AddComponent<Phase1TimedVfx>();
            timed.Configure(0.22f, 1.0f, 1.18f, true);
            return root;
        }

        public static void CreateHitBurst(Vector3 position, Vector3 direction, Color color)
        {
            direction = direction.sqrMagnitude < 0.01f ? Vector3.forward : direction.normalized;
            var material = Phase1VisualUtil.CreateMaterial("impact spark material", color, 0f, 0.7f, color * 2f, true);

            for (int i = 0; i < 13; i++)
            {
                float angle = (i / 13f) * Mathf.PI * 2f;
                Vector3 side = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.up) * direction;
                Vector3 offset = side * Random.Range(0.03f, 0.2f) + Vector3.up * Random.Range(-0.08f, 0.15f);
                var spark = Phase1VisualUtil.MeshObject(
                    "sharp directional hit spark",
                    Phase1VisualUtil.BeveledBox("Spark shard", new Vector3(0.035f, Random.Range(0.16f, 0.34f), 0.035f), 0.01f),
                    material,
                    null,
                    position + offset,
                    Quaternion.LookRotation(side + Vector3.up * 0.35f, Vector3.up) * Quaternion.Euler(70f, 0f, 0f),
                    Vector3.one);
                var timed = spark.AddComponent<Phase1TimedVfx>();
                timed.Configure(Random.Range(0.16f, 0.28f), 1.0f, Random.Range(1.2f, 1.9f), true);
            }
        }

        public static void CreateDeathEmbers(Vector3 position)
        {
            var ember = Phase1VisualUtil.CreateMaterial("death ember material", new Color(1f, 0.24f, 0.08f, 0.72f), 0f, 0.5f, new Color(1.8f, 0.3f, 0.04f, 1f), true);
            var smoke = Phase1VisualUtil.CreateMaterial("death smoke material", new Color(0.04f, 0.02f, 0.025f, 0.45f), 0f, 0f, null, true);

            for (int i = 0; i < 18; i++)
            {
                Vector2 circle = Random.insideUnitCircle.normalized * Random.Range(0.08f, 0.55f);
                var shard = Phase1VisualUtil.MeshObject(
                    "collapsing ember shard",
                    Phase1VisualUtil.TaperedCylinder("Ember shard", 5, Random.Range(0.1f, 0.24f), 0.018f, 0.04f),
                    i % 3 == 0 ? smoke : ember,
                    null,
                    position + new Vector3(circle.x, Random.Range(0f, 0.38f), circle.y),
                    Random.rotation,
                    Vector3.one);
                var timed = shard.AddComponent<Phase1TimedVfx>();
                timed.Configure(Random.Range(0.55f, 0.9f), 1.0f, Random.Range(1.6f, 2.8f), true);
            }
        }

        public static void CreateDodgeTrail(Vector3 position, Quaternion rotation)
        {
            var material = Phase1VisualUtil.CreateMaterial("blue dodge afterimage", new Color(0.2f, 0.7f, 1f, 0.28f), 0f, 0.2f, new Color(0.08f, 0.5f, 1.1f, 1f), true);
            for (int i = 0; i < 3; i++)
            {
                var trail = Phase1VisualUtil.MeshObject(
                    "quick dodge slash afterimage",
                    Phase1VisualUtil.Cape("Dodge speed smear", 0.52f, 1.4f, 0.28f),
                    material,
                    null,
                    position - (rotation * Vector3.forward) * (0.22f + i * 0.18f) + Vector3.up * 0.5f,
                    rotation * Quaternion.Euler(62f, 0f, 180f),
                    Vector3.one * (1f - i * 0.16f));
                var timed = trail.AddComponent<Phase1TimedVfx>();
                timed.Configure(0.18f + i * 0.04f, 1.0f, 1.18f, true);
            }
        }
    }
}
