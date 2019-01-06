using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newRaycastWeaponSchematic", menuName = "Weapons/Raycast Weapon Schematic")]
public class RaycastWeaponSchematic : WeaponSchematic
{

    public override void InitComponent(WeaponComponent weaponComponent)
    {
        weaponComponent.WeaponDamage = WeaponDamage;
        weaponComponent.WeaponRange = WeaponRange;
        weaponComponent.WeaponCooldown = WeaponCooldown;
    }

    public override void CooldownWeapon(WeaponComponent weaponComponent)
    {
        if (weaponComponent.WeaponTimer <= 0)
        {
            weaponComponent.WeaponTimer = 0;
            weaponComponent.WeaponReady = true;
        }
        else
        {
            weaponComponent.WeaponTimer -= Time.deltaTime;
            weaponComponent.WeaponReady = false;
        }

    }
    public override void FireWeapon(WeaponComponent weaponComponent)
    {
        weaponComponent.Fire();
    }
}
