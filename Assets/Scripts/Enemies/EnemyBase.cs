using NightwatchFortress.Combat;
using NightwatchFortress.Weapons;
using UnityEngine;

namespace NightwatchFortress.Enemies
{
    [DisallowMultipleComponent]
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private string enemyName = "小型狼";
        [SerializeField] private int maxHp = 80;
        [SerializeField] private float maxPosture = 70f;
        [SerializeField] private WeaponInstance weaponDropPrefab;
        [SerializeField] private Renderer bodyRenderer;
        [SerializeField] private ParticleSystem hitParticles;

        private int hp;
        private float posture;
        private bool postureBroken;
        private bool dead;

        public string EnemyName => enemyName;
        public int Hp => hp;
        public int MaxHp => maxHp;
        public float Posture => posture;
        public float MaxPosture => maxPosture;
        public bool IsPostureBroken => postureBroken;
        public bool IsDead => dead;

        private void Awake()
        {
            hp = maxHp;
            posture = maxPosture;
            if (bodyRenderer == null)
            {
                bodyRenderer = GetComponentInChildren<Renderer>();
            }
        }

        public void Configure(string displayName, int hpValue, float postureValue, Renderer visibleRenderer, ParticleSystem particles, WeaponInstance dropPrefab)
        {
            enemyName = displayName;
            maxHp = Mathf.Max(1, hpValue);
            maxPosture = Mathf.Max(1f, postureValue);
            bodyRenderer = visibleRenderer;
            hitParticles = particles;
            weaponDropPrefab = dropPrefab;
            hp = maxHp;
            posture = maxPosture;
            postureBroken = false;
            dead = false;
        }

        public void TakeHit(CombatHit hit)
        {
            if (dead)
            {
                return;
            }

            hp = Mathf.Max(0, hp - Mathf.Max(0, hit.Damage));
            posture = Mathf.Max(0f, posture - Mathf.Max(0f, hit.PostureDamage));
            if (posture <= 0f)
            {
                postureBroken = true;
            }

            if (hit.Knockback > 0f)
            {
                Vector3 flatDirection = new Vector3(hit.Direction.x, 0f, hit.Direction.z);
                if (flatDirection.sqrMagnitude > 0.001f)
                {
                    transform.position += flatDirection.normalized * hit.Knockback;
                }
            }

            FlashHit(hit.WeaponType);
            if (hp <= 0)
            {
                Die(hit.Direction);
            }
        }

        private void FlashHit(WeaponType weaponType)
        {
            if (bodyRenderer != null)
            {
                bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, WeaponUtility.GetWeaponColor(weaponType), 0.45f);
            }

            if (hitParticles != null)
            {
                var main = hitParticles.main;
                main.startColor = WeaponUtility.GetWeaponColor(weaponType);
                hitParticles.Play(true);
            }
        }

        private void Die(Vector3 impulseDirection)
        {
            dead = true;
            DropWeapon(impulseDirection);
            gameObject.SetActive(false);
        }

        private void DropWeapon(Vector3 impulseDirection)
        {
            if (weaponDropPrefab == null)
            {
                return;
            }

            WeaponInstance drop = Instantiate(weaponDropPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            drop.gameObject.SetActive(true);
            drop.Drop(transform.position + Vector3.up * 0.5f, (impulseDirection.normalized * 1.5f) + Vector3.up * 1.2f);
        }
    }
}
