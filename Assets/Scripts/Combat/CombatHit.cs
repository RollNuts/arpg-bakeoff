using NightwatchFortress.Weapons;
using UnityEngine;

namespace NightwatchFortress.Combat
{
    public readonly struct CombatHit
    {
        public readonly int Damage;
        public readonly float PostureDamage;
        public readonly WeaponType WeaponType;
        public readonly Vector3 Point;
        public readonly Vector3 Direction;
        public readonly float Knockback;
        public readonly bool FromThrownWeapon;

        public CombatHit(int damage, float postureDamage, WeaponType weaponType, Vector3 point, Vector3 direction, float knockback, bool fromThrownWeapon)
        {
            Damage = damage;
            PostureDamage = postureDamage;
            WeaponType = weaponType;
            Point = point;
            Direction = direction.sqrMagnitude > 0.001f ? direction.normalized : Vector3.forward;
            Knockback = knockback;
            FromThrownWeapon = fromThrownWeapon;
        }
    }
}
