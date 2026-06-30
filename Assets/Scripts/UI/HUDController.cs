using NightwatchFortress.Enemies;
using NightwatchFortress.Player;
using NightwatchFortress.Weapons;
using UnityEngine;

namespace NightwatchFortress.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private PlayerVitals playerVitals;
        [SerializeField] private WeaponInventory weaponInventory;
        [SerializeField] private EnemyBase observedEnemy;
        [SerializeField] private string currentObjective = "狼森を進み、現地武器で夜獣を討つ";

        private GUIStyle labelStyle;
        private GUIStyle smallStyle;

        public void Bind(PlayerVitals vitals, WeaponInventory inventory)
        {
            playerVitals = vitals;
            weaponInventory = inventory;
        }

        public void ObserveEnemy(EnemyBase enemy)
        {
            observedEnemy = enemy;
        }

        private void OnGUI()
        {
            EnsureStyles();
            DrawVitals();
            DrawWeapons();
            DrawPickupPrompt();
            DrawEnemy();
            DrawObjective();
        }

        private void EnsureStyles()
        {
            if (labelStyle != null)
            {
                return;
            }

            labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 18,
                fontStyle = FontStyle.Bold,
                normal = { textColor = new Color(0.95f, 0.9f, 0.78f, 1f) }
            };

            smallStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 13,
                normal = { textColor = new Color(0.82f, 0.78f, 0.68f, 1f) }
            };
        }

        private void DrawVitals()
        {
            Rect frame = new Rect(22f, 18f, 330f, 86f);
            DrawPanel(frame, new Color(0.045f, 0.035f, 0.026f, 0.9f), new Color(0.85f, 0.45f, 0.16f, 0.9f));
            GUI.Label(new Rect(frame.x + 16f, frame.y + 8f, 250f, 22f), "夜番", labelStyle);
            float hp01 = playerVitals != null ? Mathf.Clamp01((float)playerVitals.Hp / playerVitals.MaxHp) : 1f;
            float stamina01 = playerVitals != null ? Mathf.Clamp01(playerVitals.Stamina / playerVitals.MaxStamina) : 1f;
            DrawBar(new Rect(frame.x + 16f, frame.y + 40f, 292f, 12f), hp01, new Color(0.68f, 0.03f, 0.025f, 1f), Color.black);
            DrawBar(new Rect(frame.x + 16f, frame.y + 60f, 292f, 10f), stamina01, new Color(0.55f, 0.78f, 0.32f, 1f), Color.black);
        }

        private void DrawWeapons()
        {
            Rect frame = new Rect(22f, Screen.height - 126f, 392f, 96f);
            DrawPanel(frame, new Color(0.034f, 0.034f, 0.04f, 0.92f), new Color(0.38f, 0.43f, 0.45f, 0.95f));
            GUI.Label(new Rect(frame.x + 16f, frame.y + 8f, 180f, 22f), "現地武器", labelStyle);

            DrawWeaponSlot(new Rect(frame.x + 16f, frame.y + 42f, 172f, 36f), weaponInventory != null ? weaponInventory.Primary : null, weaponInventory != null && weaponInventory.ActiveSlot == 0);
            DrawWeaponSlot(new Rect(frame.x + 204f, frame.y + 42f, 172f, 36f), weaponInventory != null ? weaponInventory.Secondary : null, weaponInventory != null && weaponInventory.ActiveSlot == 1);
        }

        private void DrawWeaponSlot(Rect rect, WeaponInstance weapon, bool active)
        {
            Color border = active ? new Color(1f, 0.68f, 0.18f, 1f) : new Color(0.32f, 0.31f, 0.28f, 1f);
            DrawPanel(rect, new Color(0.10f, 0.09f, 0.08f, 0.94f), border);
            string text = weapon == null ? "空き" : $"{weapon.DisplayName} / {WeaponUtility.GetDurabilityName(weapon.DurabilityState)}";
            GUI.Label(new Rect(rect.x + 9f, rect.y + 8f, rect.width - 16f, 20f), text, smallStyle);
        }

        private void DrawPickupPrompt()
        {
            if (weaponInventory == null)
            {
                return;
            }

            WeaponPickup pickup = weaponInventory.FindNearestPickup();
            if (pickup == null)
            {
                return;
            }

            Rect frame = new Rect((Screen.width - 320f) * 0.5f, Screen.height - 184f, 320f, 42f);
            DrawPanel(frame, new Color(0.05f, 0.035f, 0.02f, 0.88f), new Color(1f, 0.62f, 0.18f, 0.95f));
            GUI.Label(new Rect(frame.x + 14f, frame.y + 10f, 292f, 20f), $"E: 拾う  {pickup.GetPrompt()}", labelStyle);
        }

        private void DrawEnemy()
        {
            if (observedEnemy == null || observedEnemy.IsDead)
            {
                return;
            }

            Rect frame = new Rect((Screen.width - 430f) * 0.5f, 22f, 430f, 58f);
            DrawPanel(frame, new Color(0.035f, 0.025f, 0.022f, 0.86f), new Color(0.62f, 0.14f, 0.12f, 0.9f));
            GUI.Label(new Rect(frame.x + 16f, frame.y + 7f, 280f, 20f), observedEnemy.EnemyName, labelStyle);
            DrawBar(new Rect(frame.x + 16f, frame.y + 34f, 190f, 10f), Mathf.Clamp01((float)observedEnemy.Hp / observedEnemy.MaxHp), new Color(0.7f, 0.04f, 0.035f, 1f), Color.black);
            DrawBar(new Rect(frame.x + 224f, frame.y + 34f, 190f, 10f), Mathf.Clamp01(observedEnemy.Posture / observedEnemy.MaxPosture), new Color(0.86f, 0.69f, 0.28f, 1f), Color.black);
        }

        private void DrawObjective()
        {
            Rect frame = new Rect(Screen.width - 394f, 18f, 366f, 54f);
            DrawPanel(frame, new Color(0.025f, 0.028f, 0.035f, 0.76f), new Color(0.15f, 0.32f, 0.54f, 0.8f));
            GUI.Label(new Rect(frame.x + 14f, frame.y + 8f, 338f, 20f), "目的", smallStyle);
            GUI.Label(new Rect(frame.x + 14f, frame.y + 26f, 338f, 20f), currentObjective, smallStyle);
        }

        private void DrawBar(Rect rect, float value, Color fill, Color back)
        {
            GUI.color = back;
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            GUI.color = fill;
            GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width * Mathf.Clamp01(value), rect.height), Texture2D.whiteTexture);
            GUI.color = Color.white;
        }

        private void DrawPanel(Rect rect, Color fill, Color border)
        {
            GUI.color = fill;
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            GUI.color = border;
            GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, 2f), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(rect.x, rect.yMax - 2f, rect.width, 2f), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(rect.x, rect.y, 2f, rect.height), Texture2D.whiteTexture);
            GUI.DrawTexture(new Rect(rect.xMax - 2f, rect.y, 2f, rect.height), Texture2D.whiteTexture);
            GUI.color = Color.white;
        }
    }
}
