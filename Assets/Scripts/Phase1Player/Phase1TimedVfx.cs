using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public class Phase1TimedVfx : MonoBehaviour
    {
        private float lifetime = 0.2f;
        private float age;
        private float startScale = 1f;
        private float endScale = 1f;
        private bool fadeAlpha;
        private Renderer[] renderers;
        private Material[] materials;
        private Color[] startColors;

        public void Configure(float duration, float scaleFrom, float scaleTo, bool fade)
        {
            lifetime = Mathf.Max(0.03f, duration);
            startScale = scaleFrom;
            endScale = scaleTo;
            fadeAlpha = fade;
            transform.localScale *= startScale;
            CacheRenderers();
        }

        private void Awake()
        {
            CacheRenderers();
        }

        private void Update()
        {
            age += Time.deltaTime;
            float t = Mathf.Clamp01(age / lifetime);
            transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, t);
            if (fadeAlpha && materials != null)
            {
                for (int i = 0; i < materials.Length; i++)
                {
                    Color color = startColors[i];
                    color.a *= 1f - t;
                    Phase1VisualUtil.SetColor(materials[i], color);
                }
            }

            if (age >= lifetime)
            {
                Destroy(gameObject);
            }
        }

        private void CacheRenderers()
        {
            renderers = GetComponentsInChildren<Renderer>();
            materials = new Material[renderers.Length];
            startColors = new Color[renderers.Length];
            for (int i = 0; i < renderers.Length; i++)
            {
                materials[i] = renderers[i].material;
                startColors[i] = materials[i].HasProperty("_BaseColor") ? materials[i].GetColor("_BaseColor") : materials[i].color;
            }
        }
    }
}
