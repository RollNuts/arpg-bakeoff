using UnityEngine;

namespace NightwatchFortress.Weapons
{
    public class WeaponInventory : MonoBehaviour
    {
        [SerializeField] private Transform mainHand;
        [SerializeField] private Transform offHand;
        [SerializeField] private WeaponInstance primary;
        [SerializeField] private WeaponInstance secondary;
        [SerializeField] private int activeSlot;
        [SerializeField] private float pickupRadius = 1.65f;
        [SerializeField] private float throwSpeed = 14f;
        [SerializeField] private LayerMask pickupMask = ~0;

        public WeaponInstance ActiveWeapon => activeSlot == 0 ? primary : secondary;
        public WeaponInstance Primary => primary;
        public WeaponInstance Secondary => secondary;
        public int ActiveSlot => activeSlot;
        public float PickupRadius => pickupRadius;

        private void Awake()
        {
            EnsureHolders();
            EquipExisting(primary, 0);
            EquipExisting(secondary, 1);
        }

        public void EnsureHolders()
        {
            if (mainHand == null)
            {
                mainHand = new GameObject("main weapon holder").transform;
                mainHand.SetParent(transform, false);
                mainHand.localPosition = new Vector3(0.42f, 1.05f, 0.45f);
            }

            if (offHand == null)
            {
                offHand = new GameObject("secondary weapon holder").transform;
                offHand.SetParent(transform, false);
                offHand.localPosition = new Vector3(-0.48f, 1.2f, -0.25f);
            }
        }

        public void SetInitialWeapons(WeaponInstance first, WeaponInstance second)
        {
            primary = first;
            secondary = second;
            activeSlot = 0;
            EnsureHolders();
            EquipExisting(primary, 0);
            EquipExisting(secondary, 1);
        }

        public void SwapActiveSlot()
        {
            activeSlot = activeSlot == 0 ? 1 : 0;
            EquipExisting(primary, 0);
            EquipExisting(secondary, 1);
        }

        public bool TryPickupNearest()
        {
            WeaponPickup pickup = FindNearestPickup();
            if (pickup == null || pickup.Weapon == null)
            {
                return false;
            }

            Pickup(pickup.Weapon);
            return true;
        }

        public WeaponPickup FindNearestPickup()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position + Vector3.up * 0.6f, pickupRadius, pickupMask, QueryTriggerInteraction.Collide);
            WeaponPickup best = null;
            float bestDistance = float.MaxValue;
            foreach (Collider hit in hits)
            {
                WeaponPickup pickup = hit.GetComponentInParent<WeaponPickup>();
                if (pickup == null || pickup.Weapon == null || pickup.Weapon.IsEquipped || pickup.Weapon.IsEmbedded)
                {
                    continue;
                }

                float distance = (pickup.transform.position - transform.position).sqrMagnitude;
                if (distance < bestDistance)
                {
                    best = pickup;
                    bestDistance = distance;
                }
            }

            return best;
        }

        public void Pickup(WeaponInstance weapon)
        {
            if (weapon == null)
            {
                return;
            }

            if (ActiveWeapon != null)
            {
                DropActive();
            }

            if (activeSlot == 0)
            {
                primary = weapon;
            }
            else
            {
                secondary = weapon;
            }

            EquipExisting(weapon, activeSlot);
        }

        public bool DropActive()
        {
            WeaponInstance weapon = ActiveWeapon;
            if (weapon == null)
            {
                return false;
            }

            Vector3 dropPosition = transform.position + transform.forward * 0.85f + Vector3.up * 0.55f;
            weapon.Drop(dropPosition, (transform.forward * 2f) + Vector3.up * 1.2f);
            ClearActive();
            return true;
        }

        public bool ThrowActive(Vector3 direction)
        {
            WeaponInstance weapon = ActiveWeapon;
            if (weapon == null || !weapon.CanThrow)
            {
                return false;
            }

            Vector3 origin = transform.position + Vector3.up * 1.2f + direction.normalized * 0.65f;
            weapon.Throw(origin, direction.normalized, throwSpeed);
            weapon.ApplyUseWear(weapon.DurabilityState == WeaponDurabilityState.NearBroken ? 0.28f : 0.16f);
            ClearActive();
            return true;
        }

        public bool TryPullEmbeddedNearby()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position + Vector3.up * 0.8f, pickupRadius, pickupMask, QueryTriggerInteraction.Collide);
            EmbeddedWeaponTarget best = null;
            float bestDistance = float.MaxValue;
            foreach (Collider hit in hits)
            {
                EmbeddedWeaponTarget target = hit.GetComponentInParent<EmbeddedWeaponTarget>();
                if (target == null || !target.HasEmbeddedWeapon)
                {
                    continue;
                }

                float distance = (target.transform.position - transform.position).sqrMagnitude;
                if (distance < bestDistance)
                {
                    best = target;
                    bestDistance = distance;
                }
            }

            if (best == null)
            {
                return false;
            }

            WeaponInstance pulled = best.PullWeapon(transform.position + transform.forward * 0.8f + Vector3.up * 0.4f);
            if (pulled != null)
            {
                Pickup(pulled);
                return true;
            }

            return false;
        }

        private void EquipExisting(WeaponInstance weapon, int slot)
        {
            if (weapon == null)
            {
                return;
            }

            Transform holder = slot == activeSlot ? mainHand : offHand;
            Vector3 localPosition = slot == activeSlot ? Vector3.zero : Vector3.zero;
            Quaternion localRotation = slot == activeSlot ? Quaternion.identity : Quaternion.Euler(0f, -25f, 55f);
            weapon.SetEquipped(holder, localPosition, localRotation);
            weapon.gameObject.SetActive(true);
        }

        private void ClearActive()
        {
            if (activeSlot == 0)
            {
                primary = null;
            }
            else
            {
                secondary = null;
            }
        }
    }
}
