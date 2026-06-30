using UnityEngine;

namespace NightwatchFortress.Weapons
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(WeaponInstance))]
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private float promptRadius = 1.55f;
        [SerializeField] private bool rackWeapon = false;

        private WeaponInstance weapon;

        public WeaponInstance Weapon => weapon;
        public float PromptRadius => promptRadius;
        public bool IsRackWeapon => rackWeapon;

        private void Awake()
        {
            weapon = GetComponent<WeaponInstance>();
        }

        public string GetPrompt()
        {
            if (weapon == null)
            {
                weapon = GetComponent<WeaponInstance>();
            }

            return $"{weapon.DisplayName} / {WeaponUtility.GetDurabilityName(weapon.DurabilityState)}";
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = rackWeapon ? new Color(1f, 0.65f, 0.16f, 1f) : new Color(0.45f, 0.75f, 1f, 1f);
            Gizmos.DrawWireSphere(transform.position, promptRadius);
        }
    }
}
