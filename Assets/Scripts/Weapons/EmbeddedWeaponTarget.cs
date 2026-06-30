using NightwatchFortress.Combat;
using NightwatchFortress.Enemies;
using UnityEngine;

namespace NightwatchFortress.Weapons
{
    public class EmbeddedWeaponTarget : MonoBehaviour
    {
        [SerializeField] private string partName = "脚";
        [SerializeField] private float pullPostureDamage = 30f;
        [SerializeField] private Transform embedRoot;
        [SerializeField] private WeaponInstance embeddedWeapon;

        public string PartName => partName;
        public WeaponInstance EmbeddedWeapon => embeddedWeapon;
        public bool HasEmbeddedWeapon => embeddedWeapon != null;
        public float PullPostureDamage => pullPostureDamage;

        private void Awake()
        {
            if (embedRoot == null)
            {
                embedRoot = transform;
            }
        }

        public bool TryEmbed(WeaponInstance weapon, Vector3 hitPoint, Vector3 direction)
        {
            if (weapon == null || !weapon.CanEmbed || embeddedWeapon != null)
            {
                return false;
            }

            embeddedWeapon = weapon;
            weapon.Embed(embedRoot, hitPoint, direction);
            return true;
        }

        public WeaponInstance PullWeapon(Vector3 dropPosition)
        {
            WeaponInstance pulled = embeddedWeapon;
            if (pulled == null)
            {
                return null;
            }

            embeddedWeapon = null;
            EnemyBase enemy = GetComponentInParent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeHit(new CombatHit(0, pullPostureDamage, pulled.WeaponType, transform.position, transform.forward, 0f, false));
            }

            pulled.PullFree(dropPosition);
            return pulled;
        }
    }
}
