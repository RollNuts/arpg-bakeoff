using UnityEngine;

namespace NightwatchFortress.Player
{
    public class PlayerVitals : MonoBehaviour
    {
        [SerializeField] private int maxHp = 120;
        [SerializeField] private int hp = 120;
        [SerializeField] private float maxStamina = 100f;
        [SerializeField] private float stamina = 100f;
        [SerializeField] private float staminaRegenPerSecond = 22f;

        public int Hp => hp;
        public int MaxHp => maxHp;
        public float Stamina => stamina;
        public float MaxStamina => maxStamina;
        public bool IsDead => hp <= 0;

        private void Awake()
        {
            hp = Mathf.Clamp(hp, 1, maxHp);
            stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        }

        private void Update()
        {
            if (!IsDead)
            {
                stamina = Mathf.Min(maxStamina, stamina + staminaRegenPerSecond * Time.deltaTime);
            }
        }

        public bool SpendStamina(float amount)
        {
            if (amount <= 0f)
            {
                return true;
            }

            if (stamina < amount)
            {
                return false;
            }

            stamina -= amount;
            return true;
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || IsDead)
            {
                return;
            }

            hp = Mathf.Min(maxHp, hp + amount);
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0 || IsDead)
            {
                return;
            }

            hp = Mathf.Max(0, hp - amount);
        }
    }
}
