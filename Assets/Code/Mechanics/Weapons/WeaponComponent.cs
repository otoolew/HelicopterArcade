using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    [SerializeField]
    private WeaponSchematic weaponSchematic;
    public WeaponSchematic WeaponSchematic { get => weaponSchematic; set => weaponSchematic = value; }

    public abstract int WeaponDamage { get; set; }
    public abstract float WeaponRange { get; set; }
    public abstract float WeaponCooldown { get; set; }
    public abstract float WeaponTimer { get; set; }
    public abstract bool WeaponReady { get; set; }

    public abstract void CooldownWeapon();

    public abstract void FireWeapon();
}
