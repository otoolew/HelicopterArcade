using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastWeaponTrigger : WeaponComponent
{
    LineRenderer lineRenderer;
    public float RayRange;
    public LayerMask LayerRayMask;
    public float effectDuration = 0.1f;
    public UnityEvent OnRayHit;

    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }
    private void Update()
    {
        CooldownWeapon();
    }
    public override void Fire()
    {
        StopCoroutine(FireFX());
        StartCoroutine(FireFX());       
    }
    IEnumerator FireFX()
    {
        Vector3 startPos = FirePoint.transform.position;
        Vector3 endPos = FirePoint.transform.forward * RayRange;
        Debug.DrawRay(startPos, endPos);
        if (Physics.Raycast(startPos, endPos, out RaycastHit rayHit, RayRange, LayerRayMask))
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
        yield return new WaitForSeconds(effectDuration);
        lineRenderer.enabled = false;
    }

    protected override void CooldownWeapon()
    {
        WeaponSchematic.CooldownWeapon(this);
    }
}
