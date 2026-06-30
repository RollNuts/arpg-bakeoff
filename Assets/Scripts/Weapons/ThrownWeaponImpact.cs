using NightwatchFortress.Combat;
using NightwatchFortress.Enemies;
using UnityEngine;

namespace NightwatchFortress.Weapons
{
    [RequireComponent(typeof(WeaponInstance))]
    public class ThrownWeaponImpact : MonoBehaviour
    {
        [SerializeField] private float minimumImpactSpeed = 2.6f;
        [SerializeField] private float embedSpeedThreshold = 5.0f;
        [SerializeField] private float knockback = 0.24f;

        private WeaponInstance weapon;
        private Rigidbody body;

        private void Awake()
        {
            weapon = GetComponent<WeaponInstance>();
            body = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (weapon == null || weapon.IsEquipped || weapon.IsEmbedded || body == null)
            {
                return;
            }

            Vector3 linearVelocity = body.linearVelocity;
            float speed = linearVelocity.magnitude;
            if (speed < minimumImpactSpeed)
            {
                return;
            }

            Vector3 point = collision.contactCount > 0 ? collision.GetContact(0).point : transform.position;
            Vector3 direction = linearVelocity.sqrMagnitude > 0.001f ? linearVelocity.normalized : transform.forward;

            EnemyBase enemy = collision.collider.GetComponentInParent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeHit(new CombatHit(weapon.GetThrowDamage(), weapon.PostureDamage * 1.4f, weapon.WeaponType, point, direction, knockback, true));
            }

            EmbeddedWeaponTarget target = collision.collider.GetComponentInParent<EmbeddedWeaponTarget>();
            if (target != null && speed >= embedSpeedThreshold && target.TryEmbed(weapon, point, direction))
            {
                return;
            }

            weapon.ApplyUseWear(0.18f);
        }
    }
}
