using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public class Phase1HudOverlay : MonoBehaviour
    {
        [SerializeField] private Phase1HeroController hero;

        private Transform hudRoot;
        private Transform hpFill;
        private Renderer hpFillRenderer;

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
            hpFill.localScale = new Vector3(2.8f * hpPercent, 0.16f, 1f);
            hpFill.localPosition = new Vector3(-1.4f + (1.4f * hpPercent), 0f, -0.01f);
            Phase1VisualUtil.SetColor(hpFillRenderer.material, Color.Lerp(new Color(0.9f, 0.08f, 0.08f, 0.95f), new Color(0.16f, 0.95f, 0.68f, 0.95f), hpPercent));
        }

        private void EnsureBuilt()
        {
            if (hudRoot != null)
            {
                return;
            }

            hudRoot = new GameObject("camera anchored product HUD").transform;
            hudRoot.SetParent(transform, false);
            hudRoot.localPosition = new Vector3(-3.95f, -2.72f, 5.5f);
            hudRoot.localRotation = Quaternion.Euler(0f, 180f, 0f);

            var panel = Phase1VisualUtil.CreateMaterial("HUD smoked glass panel", new Color(0.02f, 0.025f, 0.035f, 0.78f), 0f, 0.2f, null, true);
            var frame = Phase1VisualUtil.CreateMaterial("HUD brass frame", new Color(0.86f, 0.62f, 0.26f, 0.94f), 0.25f, 0.45f, null, true);
            var hpBack = Phase1VisualUtil.CreateMaterial("HUD hp backplate", new Color(0.16f, 0.02f, 0.035f, 0.85f), 0f, 0.2f, null, true);
            var hp = Phase1VisualUtil.CreateMaterial("HUD hp fill", new Color(0.16f, 0.95f, 0.68f, 0.95f), 0f, 0.4f, new Color(0.0f, 0.25f, 0.15f, 1f), true);
            var icon = Phase1VisualUtil.CreateMaterial("HUD icon cyan", new Color(0.1f, 0.76f, 1f, 0.92f), 0f, 0.55f, new Color(0f, 0.55f, 0.9f, 1f), true);

            Phase1VisualUtil.MeshObject("HUD dark backing", Phase1VisualUtil.Quad("HUD backing quad", 3.9f, 0.72f), panel, hudRoot, Vector3.zero, Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("HUD gold top rail", Phase1VisualUtil.Quad("HUD top rail", 3.9f, 0.045f), frame, hudRoot, new Vector3(0f, 0.36f, -0.01f), Quaternion.identity, Vector3.one);
            Phase1VisualUtil.MeshObject("HUD hp back", Phase1VisualUtil.Quad("HUD hp back", 2.9f, 0.19f), hpBack, hudRoot, new Vector3(0.25f, 0f, -0.02f), Quaternion.identity, Vector3.one);
            hpFill = Phase1VisualUtil.MeshObject("HUD hp jeweled fill", Phase1VisualUtil.Quad("HUD hp fill", 1f, 1f), hp, hudRoot, new Vector3(0.25f, 0f, -0.03f), Quaternion.identity, new Vector3(2.8f, 0.16f, 1f)).transform;
            hpFillRenderer = hpFill.GetComponent<Renderer>();

            Phase1VisualUtil.MeshObject("HUD foldblade icon", Phase1VisualUtil.DiamondBlade("HUD sword icon", 0.42f, 0.055f, 0.01f), icon, hudRoot, new Vector3(-1.63f, -0.05f, -0.04f), Quaternion.Euler(0f, 0f, -42f), Vector3.one);
            Phase1VisualUtil.MeshObject("HUD dodge diamond icon", Phase1VisualUtil.TaperedCylinder("HUD diamond", 4, 0.12f, 0.13f, 0.13f), icon, hudRoot, new Vector3(-1.25f, -0.04f, -0.04f), Quaternion.Euler(0f, 0f, 45f), Vector3.one);
        }
    }
}
