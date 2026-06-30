using UnityEngine;

namespace NightwatchFortress.Weapons
{
    public static class WeaponUtility
    {
        public static string GetDisplayName(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.OneHandedSword:
                    return "片手剣";
                case WeaponType.Spear:
                    return "槍";
                case WeaponType.GreatHammer:
                    return "大槌";
                case WeaponType.Bow:
                    return "弓";
                case WeaponType.Torch:
                    return "松明";
                case WeaponType.LargeShield:
                    return "大盾";
                case WeaponType.Dagger:
                    return "短剣";
                case WeaponType.OneHandedAxe:
                    return "片手斧";
                case WeaponType.Greatsword:
                    return "大剣";
                default:
                    return "素手";
            }
        }

        public static string GetDurabilityName(WeaponDurabilityState state)
        {
            switch (state)
            {
                case WeaponDurabilityState.Fresh:
                    return "新品";
                case WeaponDurabilityState.Normal:
                    return "通常";
                case WeaponDurabilityState.Chipped:
                    return "欠け";
                case WeaponDurabilityState.NearBroken:
                    return "壊れかけ";
                case WeaponDurabilityState.Broken:
                    return "破損";
                default:
                    return "-";
            }
        }

        public static Color GetWeaponColor(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Spear:
                    return new Color(0.68f, 0.72f, 0.58f, 1f);
                case WeaponType.GreatHammer:
                    return new Color(0.44f, 0.42f, 0.38f, 1f);
                case WeaponType.Bow:
                    return new Color(0.48f, 0.28f, 0.12f, 1f);
                case WeaponType.Torch:
                    return new Color(1f, 0.32f, 0.08f, 1f);
                case WeaponType.LargeShield:
                    return new Color(0.22f, 0.26f, 0.30f, 1f);
                default:
                    return new Color(0.72f, 0.74f, 0.72f, 1f);
            }
        }

        public static bool CanThrow(WeaponType type)
        {
            return type == WeaponType.OneHandedSword ||
                   type == WeaponType.Spear ||
                   type == WeaponType.Dagger ||
                   type == WeaponType.OneHandedAxe ||
                   type == WeaponType.Torch;
        }

        public static bool CanEmbed(WeaponType type)
        {
            return type == WeaponType.Spear ||
                   type == WeaponType.Dagger ||
                   type == WeaponType.OneHandedAxe ||
                   type == WeaponType.OneHandedSword;
        }

        public static bool CanGuard(WeaponType type)
        {
            return type == WeaponType.OneHandedSword ||
                   type == WeaponType.LargeShield ||
                   type == WeaponType.Greatsword;
        }

        public static bool CanParry(WeaponType type)
        {
            return type == WeaponType.OneHandedSword ||
                   type == WeaponType.Dagger ||
                   type == WeaponType.LargeShield;
        }
    }
}
