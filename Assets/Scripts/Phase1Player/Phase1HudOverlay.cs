using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public class Phase1HudOverlay : MonoBehaviour
    {
        [SerializeField] private Phase1HeroController hero;

        private Transform hudRoot;
        private Transform hpFill;
        private Renderer hpFillRenderer;
        private Transform damageGhost;
        private Renderer damageGhostRenderer;

        public void SetHero(Phase1HeroController newHero)
        {
            hero = newHero;
            EnsureBuilt();
        }

        private void Awake()
        {
            EnsureBuilt();
        }

        private void LateUpdate()
        {
            EnsureBuilt();
            if (hero == null)
            {
                return;
            }

            float hpPercent = Mathf.Clamp01(hero.Hp / (float)hero.MaxHp);
            hpFill.localScale = new Vector3(2.38f * hpPercent, 0.18f, 1f);
            hpFill.localPosition = new Vector3(-0.82f + (1.19f * hpPercent), 0.02f, 0.16f);
            damageGhost.localScale = new Vector3(2.38f, 0.18f, 1f);
            damageGhost.localPosition = new Vector3(0.37f, 0.02f, 0.13f);
            Phase1VisualUtil.SetColor(hpFillRenderer.material, Color.Lerp(new Color(0.86f, 0.08f, 0.08f, 0.98f), new Color(0.10f, 0.88f, 0.58f, 0.98f), hpPercent));
            Phase1VisualUtil.SetColor(damageGhostRenderer.material, new Color(0.32f, 0.035f, 0.055f, 0.52f));
        }

        private void EnsureBuilt()
        {
            if (hudRoot != null)
            {
                return;
            }

            hudRoot = new GameObject("camera anchored product HUD").transform;
            hudRoot.SetParent(transform, false);
            hudRoot.localPosition = new Vector3(-3.6f, -2.58f, 5.5f);
            hudRoot.localRotation = Quaternion.Euler(0f, 180f, 0f);

            var panel = Phase1VisualUtil.CreateMaterial("HUD smoked glass panel", new Color(0.012f, 0.014f, 0.02f, 0.96f), 0f, 0.2f, null, true);
            var frame = Phase1VisualUtil.CreateMaterial("HUD muted brass frame", new Color(0.78f, 0.52f, 0.18f, 1f), 0.25f, 0.45f, null, true);
            var hpBack = Phase1VisualUtil.CreateMaterial("HUD hp backplate", new Color(0.08f, 0.008f, 0.018f, 1f), 0f, 0.2f);
            var hpGhost = Phase1VisualUtil.CreateMaterial("HUD dark damage ghost", new Color(0.28f, 0.02f, 0.035f, 1f), 0f, 0.2f);
            var hp = Phase1VisualUtil.CreateMaterial("HUD hp fill", new Color(0.10f, 0.92f, 0.55f, 1f), 0f, 0.4f, new Color(0.0f, 0.45f, 0.22f, 1f));
            var icon = Phase1VisualUtil.CreateMaterial("HUD icon cyan", new Color(0.05f, 0.88f, 1f, 1f), 0f, 0.55f, new Color(0f, 0.9f, 1.4f, 1f));
            var redIcon = Phase1VisualUtil.CreateMaterial("HUD red action gem", new Color(1f, 0.13f, 0.07f, 1f), 0f, 0.55f, new Color(0.9f, 0.08f, 0.02f, 1f));
            var darkSlot = Phase1VisualUtil.CreateMaterial("HUD skill slot dark metal", new Color(0.045f, 0.05f, 0.062f, 1f), 0.12f, 0.35f);

            Phase1VisualUtil.MeshObject("HUD compact dark backing", Phase1VisualUtil.Quad("HUD backing quad", 3.35f, 0.58f), panel, hudRoot, Vector3.zero, Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("HUD brass top edge", Phase1VisualUtil.Quad("HUD top rail", 3.35f, 0.04f), frame, hudRoot, new Vector3(0f, 0.29f, -0.01f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("HUD brass bottom edge", Phase1VisualUtil.Quad("HUD bottom rail", 3.35f, 0.028f), frame, hudRoot, new Vector3(0f, -0.29f, -0.01f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("HUD hero crest medallion", Phase1VisualUtil.TaperedCylinder("HUD medallion", 8, 0.055f, 0.25f, 0.25f), frame, hudRoot, new Vector3(-1.38f, -0.02f, 0.12f), Quaternion.Euler(0f, 0f, 22.5f), Vector3.one);
            Phase1VisualUtil.MeshObject("HUD crest sword", Phase1VisualUtil.DiamondBlade("HUD sword icon", 0.48f, 0.045f, 0.01f), icon, hudRoot, new Vector3(-1.38f, -0.08f, 0.16f), Quaternion.Euler(0f, 0f, -36f), Vector3.one);
            Phase1VisualUtil.MeshObject("HUD hp back", Phase1VisualUtil.Quad("HUD hp back", 2.46f, 0.23f), hpBack, hudRoot, new Vector3(0.37f, 0.02f, 0.1f), Quaternion.identity, Vector3.one);
            damageGhost = Phase1VisualUtil.MeshObject("HUD full damage ghost", Phase1VisualUtil.Quad("HUD damage ghost", 1f, 1f), hpGhost, hudRoot, new Vector3(0.37f, 0.02f, 0.13f), Quaternion.identity, new Vector3(2.38f, 0.18f, 1f)).transform;
            damageGhostRenderer = damageGhost.GetComponent<Renderer>();
            hpFill = Phase1VisualUtil.MeshObject("HUD hp jeweled fill", Phase1VisualUtil.Quad("HUD hp fill", 1f, 1f), hp, hudRoot, new Vector3(0.37f, 0.02f, 0.16f), Quaternion.identity, new Vector3(2.38f, 0.18f, 1f)).transform;
            hpFillRenderer = hpFill.GetComponent<Renderer>();

            for (int i = 0; i < 3; i++)
            {
                float x = -0.48f + i * 0.34f;
                Phase1VisualUtil.MeshObject($"HUD skill slot {i}", Phase1VisualUtil.BeveledBox("HUD skill slot", new Vector3(0.25f, 0.20f, 0.025f), 0.025f), darkSlot, hudRoot, new Vector3(x, -0.19f, 0.12f), Quaternion.identity, Vector3.one);
            }

            Phase1VisualUtil.MeshObject("HUD attack skill slash", Phase1VisualUtil.DiamondBlade("HUD attack slash", 0.28f, 0.038f, 0.01f), redIcon, hudRoot, new Vector3(-0.48f, -0.23f, 0.18f), Quaternion.Euler(0f, 0f, -52f), Vector3.one);
            Phase1VisualUtil.MeshObject("HUD dodge skill diamond", Phase1VisualUtil.TaperedCylinder("HUD dodge diamond", 4, 0.08f, 0.075f, 0.075f), icon, hudRoot, new Vector3(-0.14f, -0.19f, 0.18f), Quaternion.Euler(0f, 0f, 45f), Vector3.one);
            Phase1VisualUtil.MeshObject("HUD hurt skill ember", Phase1VisualUtil.TaperedCylinder("HUD ember", 5, 0.12f, 0.02f, 0.06f), redIcon, hudRoot, new Vector3(0.2f, -0.18f, 0.18f), Quaternion.Euler(0f, 0f, -12f), Vector3.one);
        }
    }
}
