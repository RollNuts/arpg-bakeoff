using System.Collections;
using NightwatchFortress.Combat;
using NightwatchFortress.Enemies;
using NightwatchFortress.Weapons;
using UnityEngine;

namespace NightwatchFortress.Player
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(PlayerVitals))]
    [RequireComponent(typeof(WeaponInventory))]
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private float attackRadius = 0.9f;
        [SerializeField] private float attackReach = 1.15f;
        [SerializeField] private float lightAttackCost = 10f;
        [SerializeField] private float heavyAttackCost = 24f;
        [SerializeField] private float lightCooldown = 0.32f;
        [SerializeField] private float heavyCooldown = 0.62f;
        [SerializeField] private float throwCooldown = 0.38f;
        [SerializeField] private LayerMask hittableLayers = ~0;

        private PlayerController controller;
        private PlayerVitals vitals;
        private WeaponInventory inventory;
        private float cooldownTimer;
        private Coroutine hitStopRoutine;

        public float Cooldown01 => Mathf.Clamp01(cooldownTimer / heavyCooldown);

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
            vitals = GetComponent<PlayerVitals>();
            inventory = GetComponent<WeaponInventory>();
        }

        private void Update()
        {
            cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory.SwapActiveSlot();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!inventory.TryPullEmbeddedNearby())
                {
                    inventory.TryPickupNearest();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                inventory.DropActive();
            }

            if (cooldownTimer > 0f || vitals.IsDead)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
            {
                Strike(false);
            }
            else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.U))
            {
                Strike(true);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                ThrowActive();
            }
        }

        public void Strike(bool heavy)
        {
            WeaponInstance weapon = inventory.ActiveWeapon;
            if (weapon == null || weapon.IsBroken)
            {
                return;
            }

            float staminaCost = heavy ? heavyAttackCost : lightAttackCost;
            if (!vitals.SpendStamina(staminaCost))
            {
                return;
            }

            Vector3 center = transform.position + Vector3.up * 0.88f + controller.Facing * attackReach;
            Collider[] hits = Physics.OverlapSphere(center, attackRadius, hittableLayers, QueryTriggerInteraction.Ignore);
            bool connected = false;
            foreach (Collider hit in hits)
            {
                EnemyBase enemy = hit.GetComponentInParent<EnemyBase>();
                if (enemy == null || enemy.IsDead)
                {
                    continue;
                }

                float damageMultiplier = heavy ? 1.48f : 1f;
                float postureMultiplier = heavy ? 1.7f : 1f;
                Vector3 direction = enemy.transform.position - transform.position;
                enemy.TakeHit(new CombatHit(
                    Mathf.RoundToInt(weapon.Damage * damageMultiplier),
                    weapon.PostureDamage * postureMultiplier,
                    weapon.WeaponType,
                    center,
                    direction,
                    heavy ? 0.28f : 0.13f,
                    false));
                connected = true;
            }

            weapon.ApplyUseWear(heavy ? 0.10f : 0.055f);
            cooldownTimer = heavy ? heavyCooldown : lightCooldown;
            if (connected)
            {
                StartHitStop(heavy ? 0.075f : 0.04f);
            }
        }

        public void ThrowActive()
        {
            WeaponInstance weapon = inventory.ActiveWeapon;
            if (weapon == null || !weapon.CanThrow)
            {
                return;
            }

            if (!vitals.SpendStamina(14f))
            {
                return;
            }

            if (inventory.ThrowActive(controller.Facing))
            {
                cooldownTimer = throwCooldown;
                StartHitStop(0.025f);
            }
        }

        private void StartHitStop(float duration)
        {
            if (hitStopRoutine != null)
            {
                StopCoroutine(hitStopRoutine);
            }

            hitStopRoutine = StartCoroutine(HitStop(duration));
        }

        private IEnumerator HitStop(float duration)
        {
            float previous = Time.timeScale;
            Time.timeScale = 0.1f;
            yield return new WaitForSecondsRealtime(duration);
            Time.timeScale = previous;
            hitStopRoutine = null;
        }
    }
}
