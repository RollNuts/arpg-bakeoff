using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public class Phase1CombatDummy : MonoBehaviour
    {
        [SerializeField] private int maxHp = 90;

        private int hp;
        private float hitPulse;
        private Vector3 basePosition;
        private Transform visualRoot;
        private Renderer[] renderers;

        private void Awake()
        {
            hp = maxHp;
            basePosition = transform.position;
            EnsureVisuals();
        }

        private void Update()
        {
            hitPulse = Mathf.Max(0f, hitPulse - Time.deltaTime * 4f);
            float shake = hitPulse * 0.045f;
            transform.position = basePosition + new Vector3(Mathf.Sin(Time.time * 62f) * shake, 0f, Mathf.Cos(Time.time * 49f) * shake);

            if (renderers == null)
            {
                return;
            }

            foreach (var renderer in renderers)
            {
                if (renderer == null || renderer.sharedMaterial == null)
                {
                    continue;
                }

                Color baseColor = hp <= 0 ? new Color(0.12f, 0.09f, 0.1f, 1f) : new Color(0.54f, 0.12f, 0.15f, 1f);
                Phase1VisualUtil.SetColor(renderer.sharedMaterial, Color.Lerp(baseColor, Color.white, hitPulse));
            }
        }

        public void ReceiveHit(int damage, Vector3 sourcePosition, Vector3 attackDirection)
        {
            if (hp <= 0)
            {
                return;
            }

            hp = Mathf.Max(0, hp - damage);
            hitPulse = 1f;
            Phase1VfxFactory.CreateHitBurst(transform.position + Vector3.up * 1.05f, attackDirection, new Color(1f, 0.38f, 0.16f, 1f));
            if (hp <= 0)
            {
                visualRoot.localRotation = Quaternion.Euler(0f, 0f, 74f);
                visualRoot.localPosition += attackDirection.normalized * 0.32f;
                Phase1VfxFactory.CreateDeathEmbers(transform.position + Vector3.up * 0.9f);
            }
        }

        private void EnsureVisuals()
        {
            if (visualRoot != null)
            {
                return;
            }

            visualRoot = new GameObject("breakable crimson training idol").transform;
            visualRoot.SetParent(transform, false);

            var stone = Phase1VisualUtil.CreateMaterial("Dummy dark stone", new Color(0.18f, 0.14f, 0.16f, 1f), 0f, 0.35f);
            var crimson = Phase1VisualUtil.CreateMaterial("Dummy crimson core", new Color(0.54f, 0.12f, 0.15f, 1f), 0f, 0.45f, new Color(0.45f, 0.04f, 0.02f, 1f));
            var gold = Phase1VisualUtil.CreateMaterial("Dummy tarnished brass", new Color(0.76f, 0.48f, 0.18f, 1f), 0.35f, 0.4f);

            Phase1VisualUtil.MeshObject("weighted stone base", Phase1VisualUtil.TaperedCylinder("Dummy base", 8, 0.24f, 0.48f, 0.36f), stone, visualRoot, new Vector3(0f, 0.13f, 0f), Quaternion.Euler(0f, 22.5f, 0f), Vector3.one);
            Phase1VisualUtil.MeshObject("crimson hit body", Phase1VisualUtil.TaperedCylinder("Dummy body", 7, 1.15f, 0.28f, 0.18f), crimson, visualRoot, new Vector3(0f, 0.82f, 0f), Quaternion.Euler(0f, 12f, 0f), Vector3.one);
            Phase1VisualUtil.MeshObject("gold hit rim", Phase1VisualUtil.TaperedCylinder("Dummy rim", 7, 0.09f, 0.34f, 0.31f), gold, visualRoot, new Vector3(0f, 1.38f, 0f), Quaternion.Euler(0f, 12f, 0f), Vector3.one);
            Phase1VisualUtil.MeshObject("readable horn left", Phase1VisualUtil.TaperedCylinder("Dummy horn", 5, 0.42f, 0.05f, 0.14f), gold, visualRoot, new Vector3(-0.27f, 1.55f, 0f), Quaternion.Euler(0f, 0f, 32f), Vector3.one);
            Phase1VisualUtil.MeshObject("readable horn right", Phase1VisualUtil.TaperedCylinder("Dummy horn", 5, 0.42f, 0.05f, 0.14f), gold, visualRoot, new Vector3(0.27f, 1.55f, 0f), Quaternion.Euler(0f, 0f, -32f), Vector3.one);

            var collider = gameObject.AddComponent<CapsuleCollider>();
            collider.radius = 0.42f;
            collider.height = 1.7f;
            collider.center = new Vector3(0f, 0.88f, 0f);
            renderers = visualRoot.GetComponentsInChildren<Renderer>();
        }
    }
}
