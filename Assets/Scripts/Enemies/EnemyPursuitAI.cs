using NightwatchFortress.Player;
using UnityEngine;

namespace NightwatchFortress.Enemies
{
    [RequireComponent(typeof(EnemyBase))]
    public class EnemyPursuitAI : MonoBehaviour
    {
        [SerializeField] private PlayerVitals target;
        [SerializeField] private float moveSpeed = 2.6f;
        [SerializeField] private float stoppingDistance = 1.25f;
        [SerializeField] private float attackRange = 1.35f;
        [SerializeField] private float attackCooldown = 1.05f;
        [SerializeField] private int attackDamage = 8;
        [SerializeField] private float rotationSpeed = 12f;

        private EnemyBase enemy;
        private float cooldownTimer;

        public bool HasTarget => target != null && !target.IsDead;

        private void Awake()
        {
            enemy = GetComponent<EnemyBase>();
        }

        private void Update()
        {
            if (enemy == null || enemy.IsDead || !HasTarget)
            {
                return;
            }

            cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);
            Vector3 offset = target.transform.position - transform.position;
            offset.y = 0f;
            float distance = offset.magnitude;
            if (distance <= 0.001f)
            {
                return;
            }

            Vector3 direction = offset / distance;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), rotationSpeed * Time.deltaTime);

            if (distance > stoppingDistance)
            {
                transform.position += direction * (moveSpeed * Time.deltaTime);
            }

            if (distance <= attackRange && cooldownTimer <= 0f)
            {
                target.TakeDamage(attackDamage);
                cooldownTimer = attackCooldown;
            }
        }

        public void Configure(PlayerVitals targetVitals, float speed, float stopDistance, float range, int damage, float cooldown)
        {
            target = targetVitals;
            moveSpeed = Mathf.Max(0f, speed);
            stoppingDistance = Mathf.Max(0.1f, stopDistance);
            attackRange = Mathf.Max(stoppingDistance, range);
            attackDamage = Mathf.Max(1, damage);
            attackCooldown = Mathf.Max(0.1f, cooldown);
        }
    }
}
