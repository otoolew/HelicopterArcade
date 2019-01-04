using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    #region Variable Declarations
    [SerializeField]
    private WeaponSchematic weaponSchematic;
    public WeaponSchematic WeaponSchematic
    {
        get { return weaponSchematic; }
        set { weaponSchematic = value; }
    }
    public float WeaponDamage { get; set; }
    public float WeaponCooldown { get; set; }
    public float WeaponRange { get; set; }
    public float WeaponTimer { get; set; }
    public bool WeaponReady { get; set; }

    [SerializeField]
    private Transform firePoint;
    public Transform FirePoint
    {
        get { return firePoint; }
        set { firePoint = value; }
    }

    #endregion
    #region Events

    #endregion

    #region Monobehaviour

    #endregion

    protected abstract void CooldownWeapon();
    public abstract void Fire();

}
