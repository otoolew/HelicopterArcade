using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSchematic : ScriptableObject
{
    public float WeaponDamage { get; set; }
    public float WeaponRange { get; set; }
    public float WeaponCooldown { get; set; }

    public abstract void InitComponent(WeaponComponent weaponComponent);
    public abstract void CooldownWeapon(WeaponComponent weaponComponent);
    public abstract void FireWeapon(WeaponComponent weaponComponent);
}
