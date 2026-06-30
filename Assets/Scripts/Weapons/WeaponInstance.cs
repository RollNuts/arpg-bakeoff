using UnityEngine;

namespace NightwatchFortress.Weapons
{
    [DisallowMultipleComponent]
    public class WeaponInstance : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType = WeaponType.OneHandedSword;
        [SerializeField] private WeaponDurabilityState durabilityState = WeaponDurabilityState.Normal;
        [SerializeField] private float durability = 1f;
        [SerializeField] private int damage = 18;
        [SerializeField] private float postureDamage = 12f;
        [SerializeField] private float throwDamageMultiplier = 1.4f;
        [SerializeField] private bool embedded;
        [SerializeField] private bool equipped;
        [SerializeField] private Renderer visualRenderer;
        [SerializeField] private Rigidbody body;
        [SerializeField] private Collider pickupCollider;
        [SerializeField] private Collider[] weaponColliders;

        public WeaponType WeaponType => weaponType;
        public WeaponDurabilityState DurabilityState => durabilityState;
        public float Durability01 => durability;
        public int Damage => Mathf.RoundToInt(damage * GetDurabilityDamageFactor());
        public float PostureDamage => postureDamage * GetDurabilityPostureFactor();
        public bool IsEmbedded => embedded;
        public bool IsEquipped => equipped;
        public bool IsBroken => durabilityState == WeaponDurabilityState.Broken;
        public bool CanThrow => WeaponUtility.CanThrow(weaponType) && !IsBroken;
        public bool CanEmbed => WeaponUtility.CanEmbed(weaponType) && !IsBroken;
        public string DisplayName => WeaponUtility.GetDisplayName(weaponType);

        private void Awake()
        {
            CacheComponents();
            ApplyVisuals();
        }

        public void Configure(WeaponType type, WeaponDurabilityState state, int baseDamage, float basePostureDamage)
        {
            weaponType = type;
            durabilityState = state;
            durability = StateToDurability(state);
            damage = Mathf.Max(1, baseDamage);
            postureDamage = Mathf.Max(1f, basePostureDamage);
            CacheComponents();
            ApplyVisuals();
        }

        public void SetEquipped(Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            embedded = false;
            equipped = true;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;
            SetPhysics(false);
        }

        public void Drop(Vector3 position, Vector3 impulse)
        {
            embedded = false;
            equipped = false;
            transform.SetParent(null, true);
            transform.position = position;
            SetPhysics(true);
            if (body != null)
            {
                body.linearVelocity = impulse;
            }
        }

        public void Throw(Vector3 origin, Vector3 direction, float speed)
        {
            embedded = false;
            equipped = false;
            transform.SetParent(null, true);
            transform.position = origin;
            transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            SetPhysics(true);
            if (body != null)
            {
                body.linearVelocity = direction.normalized * speed;
                body.angularVelocity = Vector3.Cross(Vector3.up, direction.normalized) * 8f;
            }
        }

        public void Embed(Transform target, Vector3 worldPosition, Vector3 direction)
        {
            embedded = true;
            equipped = false;
            transform.SetParent(target, true);
            transform.position = worldPosition;
            transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            SetPhysics(false);
        }

        public void PullFree(Vector3 dropPosition)
        {
            embedded = false;
            transform.SetParent(null, true);
            Drop(dropPosition, Vector3.up * 1.6f);
        }

        public void ApplyUseWear(float amount)
        {
            if (IsBroken || amount <= 0f)
            {
                return;
            }

            durability = Mathf.Clamp01(durability - amount);
            durabilityState = DurabilityToState(durability);
            ApplyVisuals();
        }

        public int GetThrowDamage()
        {
            float nearBrokenBonus = durabilityState == WeaponDurabilityState.NearBroken ? 1.65f : 1f;
            return Mathf.RoundToInt(Damage * throwDamageMultiplier * nearBrokenBonus);
        }

        private void CacheComponents()
        {
            if (visualRenderer == null)
            {
                visualRenderer = GetComponentInChildren<Renderer>();
            }

            if (body == null)
            {
                body = GetComponent<Rigidbody>();
            }

            if (pickupCollider == null)
            {
                pickupCollider = GetComponent<Collider>();
            }

            if (weaponColliders == null || weaponColliders.Length == 0)
            {
                weaponColliders = GetComponentsInChildren<Collider>(true);
            }
        }

        private void SetPhysics(bool active)
        {
            CacheComponents();
            if (body != null)
            {
                body.isKinematic = !active;
                body.useGravity = active;
            }

            if (weaponColliders != null)
            {
                for (int i = 0; i < weaponColliders.Length; i++)
                {
                    if (weaponColliders[i] == null)
                    {
                        continue;
                    }

                    weaponColliders[i].enabled = active;
                    weaponColliders[i].isTrigger = false;
                }
            }
        }

        private void ApplyVisuals()
        {
            CacheComponents();
            if (visualRenderer == null)
            {
                return;
            }

            Color baseColor = WeaponUtility.GetWeaponColor(weaponType);
            Color wearColor = Color.Lerp(baseColor, new Color(0.12f, 0.10f, 0.09f, 1f), 1f - durability);
            visualRenderer.material.color = durabilityState == WeaponDurabilityState.Broken
                ? new Color(0.08f, 0.08f, 0.08f, 1f)
                : wearColor;
        }

        private float GetDurabilityDamageFactor()
        {
            switch (durabilityState)
            {
                case WeaponDurabilityState.Fresh:
                    return 1.12f;
                case WeaponDurabilityState.Chipped:
                    return 0.82f;
                case WeaponDurabilityState.NearBroken:
                    return 0.58f;
                case WeaponDurabilityState.Broken:
                    return 0.12f;
                default:
                    return 1f;
            }
        }

        private float GetDurabilityPostureFactor()
        {
            return durabilityState == WeaponDurabilityState.Broken ? 0.15f : 1f;
        }

        private static float StateToDurability(WeaponDurabilityState state)
        {
            switch (state)
            {
                case WeaponDurabilityState.Fresh:
                    return 1f;
                case WeaponDurabilityState.Normal:
                    return 0.78f;
                case WeaponDurabilityState.Chipped:
                    return 0.48f;
                case WeaponDurabilityState.NearBroken:
                    return 0.22f;
                case WeaponDurabilityState.Broken:
                    return 0f;
                default:
                    return 0.78f;
            }
        }

        private static WeaponDurabilityState DurabilityToState(float value)
        {
            if (value <= 0.02f)
            {
                return WeaponDurabilityState.Broken;
            }

            if (value <= 0.28f)
            {
                return WeaponDurabilityState.NearBroken;
            }

            if (value <= 0.58f)
            {
                return WeaponDurabilityState.Chipped;
            }

            if (value < 0.92f)
            {
                return WeaponDurabilityState.Normal;
            }

            return WeaponDurabilityState.Fresh;
        }
    }
}
