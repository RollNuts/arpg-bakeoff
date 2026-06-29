using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public class Phase1HeroRig : MonoBehaviour
    {
        [SerializeField] private Transform visualRoot;
        [SerializeField] private Transform bodyRoot;
        [SerializeField] private Transform torso;
        [SerializeField] private Transform head;
        [SerializeField] private Transform cloak;
        [SerializeField] private Transform scarf;
        [SerializeField] private Transform leftArm;
        [SerializeField] private Transform rightArm;
        [SerializeField] private Transform leftForearm;
        [SerializeField] private Transform rightForearm;
        [SerializeField] private Transform swordPivot;
        [SerializeField] private Transform sword;
        [SerializeField] private Transform leftLeg;
        [SerializeField] private Transform rightLeg;
        [SerializeField] private Renderer[] renderers;

        private Material armorMaterial;
        private Material clothMaterial;
        private Material glowMaterial;
        private Material metalMaterial;
        private Material skinMaterial;
        private Material shadowMaterial;
        private Color armorBase;
        private Color clothBase;
        private Color glowBase;
        private float lastFlash;

        public Transform SwordPivot => swordPivot;

        public Transform VisualRoot => visualRoot;

        public void EnsureBuilt()
        {
            if (visualRoot != null)
            {
                return;
            }

            armorBase = new Color(0.78f, 0.86f, 0.92f, 1f);
            clothBase = new Color(0.15f, 0.006f, 0.018f, 1f);
            glowBase = new Color(0.18f, 0.93f, 1f, 1f);

            armorMaterial = Phase1VisualUtil.CreateMaterial("Hero moonsteel armor", armorBase, 0.2f, 0.55f);
            clothMaterial = Phase1VisualUtil.CreateMaterial("Hero dark blood-red cloak", clothBase, 0f, 0.62f);
            glowMaterial = Phase1VisualUtil.CreateMaterial("Hero cyan spell glow", new Color(0.1f, 0.76f, 1f, 1f), 0f, 0.8f, new Color(0.0f, 1.7f, 2.5f, 1f));
            metalMaterial = Phase1VisualUtil.CreateMaterial("Hero dark steel and gold", new Color(0.20f, 0.23f, 0.28f, 1f), 0.45f, 0.55f);
            skinMaterial = Phase1VisualUtil.CreateMaterial("Hero warm face", new Color(0.78f, 0.55f, 0.42f, 1f), 0f, 0.5f);
            shadowMaterial = Phase1VisualUtil.CreateMaterial("Hero soft contact shadow", new Color(0f, 0f, 0f, 0.38f), 0f, 0f, null, true);

            visualRoot = new GameObject("Aurelian Foldblade visual").transform;
            visualRoot.SetParent(transform, false);

            Phase1VisualUtil.MeshObject(
                "painted oval contact shadow",
                Phase1VisualUtil.Ellipse("Hero oval shadow", 0.72f, 0.48f, 28),
                shadowMaterial,
                visualRoot,
                new Vector3(0f, 0.025f, 0.02f),
                Quaternion.identity,
                Vector3.one);

            bodyRoot = new GameObject("animated armor body").transform;
            bodyRoot.SetParent(visualRoot, false);
            bodyRoot.localPosition = Vector3.zero;

            torso = Part("moonsteel tapered cuirass", Phase1VisualUtil.TaperedCylinder("Tapered cuirass", 9, 0.95f, 0.38f, 0.28f), armorMaterial, bodyRoot, new Vector3(0f, 1.05f, 0f), Quaternion.Euler(0f, 22.5f, 0f), Vector3.one);
            Part("dark waist belt", Phase1VisualUtil.TaperedCylinder("Belt ring", 8, 0.16f, 0.44f, 0.36f), metalMaterial, bodyRoot, new Vector3(0f, 0.57f, 0f), Quaternion.Euler(0f, 22.5f, 0f), Vector3.one);
            Part("cyan chest spell core", Phase1VisualUtil.BeveledBox("Chest gem", new Vector3(0.16f, 0.22f, 0.07f), 0.025f), glowMaterial, torso, new Vector3(0f, 0.08f, 0.31f), Quaternion.identity, Vector3.one);
            Part("gold shoulder mantle pin", Phase1VisualUtil.BeveledBox("Gold mantle pin", new Vector3(0.5f, 0.08f, 0.11f), 0.025f), Phase1VisualUtil.CreateMaterial("Hero aged gold", new Color(0.95f, 0.67f, 0.24f, 1f), 0.5f, 0.5f), torso, new Vector3(0f, 0.42f, 0.26f), Quaternion.identity, Vector3.one);

            head = Part("readable head and face", Phase1VisualUtil.TaperedCylinder("Hero head", 8, 0.34f, 0.18f, 0.21f), skinMaterial, bodyRoot, new Vector3(0f, 1.72f, 0.03f), Quaternion.Euler(0f, 22.5f, 0f), Vector3.one);
            Part("dark asymmetrical hair crest", Phase1VisualUtil.BeveledBox("Hair crest", new Vector3(0.42f, 0.2f, 0.35f), 0.04f), Phase1VisualUtil.CreateMaterial("Hero ink black hair", new Color(0.06f, 0.07f, 0.11f, 1f), 0f, 0.55f), head, new Vector3(0.03f, 0.19f, 0.01f), Quaternion.Euler(-8f, -18f, 8f), Vector3.one);
            Part("small cyan eye read", Phase1VisualUtil.BeveledBox("Eye glint", new Vector3(0.22f, 0.04f, 0.025f), 0.01f), glowMaterial, head, new Vector3(0f, 0.03f, 0.2f), Quaternion.identity, Vector3.one);

            cloak = Part("tailored dark hero cloak", Phase1VisualUtil.Cape("Hero cape", 0.78f, 0.92f, 0.11f), clothMaterial, bodyRoot, new Vector3(0f, 1.33f, -0.15f), Quaternion.Euler(28f, 0f, 0f), Vector3.one);
            Part("subtle gold cloak hem", Phase1VisualUtil.BeveledBox("Cloak hem", new Vector3(0.48f, 0.03f, 0.045f), 0.01f), Phase1VisualUtil.CreateMaterial("Hero cloak aged gold trim", new Color(0.68f, 0.42f, 0.12f, 1f), 0.35f, 0.45f), cloak, new Vector3(0f, -0.78f, -0.04f), Quaternion.identity, Vector3.one);
            scarf = Part("white trailing scarf", Phase1VisualUtil.Cape("Hero scarf strip", 0.46f, 1.0f, 0.1f), Phase1VisualUtil.CreateMaterial("Hero white scarf", new Color(0.94f, 0.96f, 0.94f, 1f), 0f, 0.7f), bodyRoot, new Vector3(0.18f, 1.58f, 0.24f), Quaternion.Euler(60f, 0f, -24f), Vector3.one);

            leftArm = Arm("left");
            rightArm = Arm("right");
            leftForearm = Forearm("left", leftArm);
            rightForearm = Forearm("right", rightArm);
            Part("left wide shoulder plate", Phase1VisualUtil.TaperedCylinder("Shoulder plate", 7, 0.22f, 0.2f, 0.3f), armorMaterial, bodyRoot, new Vector3(-0.48f, 1.32f, 0f), Quaternion.Euler(0f, 22f, 86f), Vector3.one);
            Part("right wide shoulder plate", Phase1VisualUtil.TaperedCylinder("Shoulder plate", 7, 0.22f, 0.2f, 0.3f), armorMaterial, bodyRoot, new Vector3(0.48f, 1.32f, 0f), Quaternion.Euler(0f, 22f, -86f), Vector3.one);

            leftLeg = Leg("left");
            rightLeg = Leg("right");

            swordPivot = new GameObject("foldblade weapon pivot").transform;
            swordPivot.SetParent(rightForearm, false);
            swordPivot.localPosition = new Vector3(0.03f, -0.28f, 0.02f);
            swordPivot.localRotation = Quaternion.Euler(8f, 0f, -16f);
            sword = Part("crescent-edged magic sword", Phase1VisualUtil.DiamondBlade("Foldblade diamond blade", 1.38f, 0.13f, 0.025f), Phase1VisualUtil.CreateMaterial("Hero bright blade", new Color(0.88f, 0.96f, 1f, 1f), 0.65f, 0.78f, new Color(0.08f, 0.55f, 0.8f, 1f)), swordPivot, new Vector3(0f, 0.06f, 0f), Quaternion.Euler(0f, 0f, -28f), Vector3.one);
            Part("sword guard", Phase1VisualUtil.BeveledBox("Sword guard", new Vector3(0.42f, 0.08f, 0.08f), 0.02f), metalMaterial, swordPivot, new Vector3(0f, 0.03f, 0f), Quaternion.identity, Vector3.one);

            renderers = GetComponentsInChildren<Renderer>();
            ApplyPose(Phase1HeroPose.Idle, 0f, Vector3.forward, 0f);
        }

        public void ApplyPose(Phase1HeroPose pose, float time, Vector3 moveDirection, float flash)
        {
            EnsureBuilt();
            float breathe = Mathf.Sin(time * 4.2f) * 0.025f;
            float run = Mathf.Sin(time * 11f);
            float attackSwing = Mathf.Clamp01(time);
            float flashAmount = Mathf.Max(flash, lastFlash * 0.88f);
            lastFlash = flashAmount;

            bodyRoot.localPosition = new Vector3(0f, breathe, 0f);
            bodyRoot.localRotation = Quaternion.identity;
            torso.localRotation = Quaternion.Euler(0f, 22.5f, 0f);
            head.localRotation = Quaternion.Euler(0f, 22.5f, 0f);
            cloak.localRotation = Quaternion.Euler(18f + Mathf.Sin(time * 3f) * 3f, 0f, 0f);
            scarf.localRotation = Quaternion.Euler(60f + Mathf.Sin(time * 4f) * 5f, 0f, -24f);
            leftArm.localRotation = Quaternion.Euler(10f, 0f, -18f);
            rightArm.localRotation = Quaternion.Euler(8f, 0f, 18f);
            leftForearm.localRotation = Quaternion.Euler(0f, 0f, -10f);
            rightForearm.localRotation = Quaternion.Euler(0f, 0f, 8f);
            leftLeg.localRotation = Quaternion.Euler(0f, 0f, -4f);
            rightLeg.localRotation = Quaternion.Euler(0f, 0f, 4f);
            swordPivot.localRotation = Quaternion.Euler(8f, 0f, -16f);

            if (pose == Phase1HeroPose.Run)
            {
                bodyRoot.localRotation = Quaternion.Euler(5f, 0f, -run * 2f);
                cloak.localRotation = Quaternion.Euler(28f + Mathf.Abs(run) * 8f, -run * 4f, 0f);
                scarf.localRotation = Quaternion.Euler(75f, -run * 8f, -32f);
                leftArm.localRotation = Quaternion.Euler(run * 28f, 0f, -18f);
                rightArm.localRotation = Quaternion.Euler(-run * 28f, 0f, 18f);
                leftLeg.localRotation = Quaternion.Euler(-run * 24f, 0f, -5f);
                rightLeg.localRotation = Quaternion.Euler(run * 24f, 0f, 5f);
            }
            else if (pose == Phase1HeroPose.Dodge)
            {
                float s = Mathf.Sin(Mathf.Clamp01(time) * Mathf.PI);
                bodyRoot.localPosition = new Vector3(0f, 0.02f, s * 0.08f);
                bodyRoot.localRotation = Quaternion.Euler(18f * s, 0f, 0f);
                cloak.localRotation = Quaternion.Euler(40f + 20f * s, 0f, 0f);
                swordPivot.localRotation = Quaternion.Euler(-30f, 0f, -70f);
            }
            else if (pose == Phase1HeroPose.Attack)
            {
                float wind = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(attackSwing * 1.35f));
                bodyRoot.localRotation = Quaternion.Euler(0f, -22f + (40f * wind), -8f + (12f * wind));
                rightArm.localRotation = Quaternion.Euler(-45f + (95f * wind), 0f, 42f - (88f * wind));
                rightForearm.localRotation = Quaternion.Euler(0f, 0f, 26f - (50f * wind));
                leftArm.localRotation = Quaternion.Euler(10f, 0f, -42f);
                swordPivot.localRotation = Quaternion.Euler(-60f + (95f * wind), -18f + (36f * wind), -120f + (190f * wind));
                cloak.localRotation = Quaternion.Euler(24f + (16f * wind), 0f, -10f);
            }
            else if (pose == Phase1HeroPose.Hit)
            {
                float s = Mathf.Sin(Mathf.Clamp01(time) * Mathf.PI);
                bodyRoot.localPosition = new Vector3(0f, 0.02f, -0.08f * s);
                bodyRoot.localRotation = Quaternion.Euler(-12f * s, 0f, 10f * s);
                head.localRotation = Quaternion.Euler(-18f * s, 20f * s, 22.5f);
                rightArm.localRotation = Quaternion.Euler(-25f, 0f, 52f);
            }
            else if (pose == Phase1HeroPose.Dead)
            {
                bodyRoot.localPosition = new Vector3(0.18f, 0.05f, -0.08f);
                bodyRoot.localRotation = Quaternion.Euler(72f, -20f, 82f);
                cloak.localRotation = Quaternion.Euler(74f, 0f, 16f);
                scarf.localRotation = Quaternion.Euler(80f, -30f, -78f);
                swordPivot.localRotation = Quaternion.Euler(20f, 80f, -172f);
                head.localRotation = Quaternion.Euler(-38f, 0f, 22.5f);
            }

            ApplyFlash(flashAmount, pose == Phase1HeroPose.Dead);
        }

        private Transform Arm(string side)
        {
            float sign = side == "left" ? -1f : 1f;
            return Part($"{side} armored upper arm", Phase1VisualUtil.TaperedCylinder("Upper arm", 7, 0.56f, 0.11f, 0.14f), armorMaterial, bodyRoot, new Vector3(sign * 0.52f, 1.05f, 0.02f), Quaternion.Euler(0f, 0f, sign * 18f), Vector3.one);
        }

        private Transform Forearm(string side, Transform parent)
        {
            float sign = side == "left" ? -1f : 1f;
            return Part($"{side} dark bracer forearm", Phase1VisualUtil.TaperedCylinder("Forearm bracer", 7, 0.5f, 0.09f, 0.12f), metalMaterial, parent, new Vector3(sign * 0.04f, -0.49f, 0.02f), Quaternion.Euler(0f, 0f, sign * 8f), Vector3.one);
        }

        private Transform Leg(string side)
        {
            float sign = side == "left" ? -1f : 1f;
            var leg = Part($"{side} greave and boot", Phase1VisualUtil.TaperedCylinder("Leg greave", 7, 0.7f, 0.12f, 0.18f), metalMaterial, bodyRoot, new Vector3(sign * 0.18f, 0.15f, 0f), Quaternion.Euler(0f, 0f, sign * 4f), Vector3.one);
            Part($"{side} readable boot", Phase1VisualUtil.BeveledBox("Boot wedge", new Vector3(0.22f, 0.16f, 0.42f), 0.035f), metalMaterial, leg, new Vector3(0f, -0.43f, 0.08f), Quaternion.Euler(0f, 0f, 0f), Vector3.one);
            return leg;
        }

        private Transform Part(string name, Mesh mesh, Material material, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            return Phase1VisualUtil.MeshObject(name, mesh, material, parent, localPosition, localRotation, localScale).transform;
        }

        private void ApplyFlash(float amount, bool dead)
        {
            if (armorMaterial == null)
            {
                return;
            }

            float deathDim = dead ? 0.35f : 1f;
            Phase1VisualUtil.SetColor(armorMaterial, Color.Lerp(armorBase * deathDim, Color.white, amount));
            Phase1VisualUtil.SetColor(clothMaterial, Color.Lerp(clothBase * deathDim, new Color(1f, 0.18f, 0.16f, 1f), amount));
            Phase1VisualUtil.SetColor(glowMaterial, dead ? new Color(0.03f, 0.1f, 0.12f, 1f) : glowBase);
        }
    }
}
