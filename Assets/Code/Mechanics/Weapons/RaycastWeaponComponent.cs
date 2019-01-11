using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeaponComponent : WeaponComponent
{
    #region Properties and Variables

    [SerializeField]
    private LineRenderer lineRenderer;
    public LineRenderer LineRenderer { get => lineRenderer; set => lineRenderer = value; }

    [SerializeField]
    private float weaponDamage;
    public override float WeaponDamage { get => weaponDamage; set => weaponDamage = value; }

    [SerializeField]
    private float weaponCooldown;
    public override float WeaponCooldown { get => weaponCooldown; set => weaponCooldown = value; }

    [SerializeField]
    private float weaponRange;
    public override float WeaponRange { get => weaponRange; set => weaponRange = value; }

    [SerializeField]
    private float weaponTimer;
    public override float WeaponTimer { get => weaponTimer; set => weaponTimer = value; }

    [SerializeField]
    private bool weaponReady;
    public override bool WeaponReady { get => weaponReady; set => weaponReady = value; }

    [SerializeField]
    private Transform firePoint;
    public Transform FirePoint { get => firePoint; set => firePoint = value; }

    [SerializeField]
    private float fxDuration;
    public float FxDuration { get => fxDuration; set => fxDuration = value; }

    [SerializeField]
    private LayerMask layerMask;
    public LayerMask LayerMask { get => layerMask; set => layerMask = value; }

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        WeaponSchematic.InitComponent(this);
    }

    // Update is called once per frame
    void Update()
    {
        CooldownWeapon();
    }

    public override void FireWeapon()
    {
        StopCoroutine(FireFX());
        StartCoroutine(FireFX());
    }

    IEnumerator FireFX()
    {
        Vector3 startPos = FirePoint.transform.position;
        Vector3 endPos = -FirePoint.transform.right * weaponRange;
        Debug.DrawRay(startPos, endPos);
        if (Physics.Raycast(startPos, endPos, out RaycastHit rayHit, weaponRange, layerMask))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, rayHit.point);
            Debug.Log(rayHit.collider.gameObject.name + " TODO: Implement Damage");
        }
        else
        {
            lineRenderer.SetPosition(1, endPos);
        }
        yield return new WaitForSeconds(fxDuration);
        lineRenderer.enabled = false;
    }

    public override void CooldownWeapon()
    {
        WeaponSchematic.CooldownWeapon(this);
    }

}
