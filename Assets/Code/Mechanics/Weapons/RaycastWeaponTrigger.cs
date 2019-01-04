using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastWeaponTrigger : WeaponComponent
{
    LineRenderer lineRenderer;
    Ray ray;
    RaycastHit rayHit;
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
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, FirePoint.transform.position);
        ray.origin = FirePoint.transform.position;
        ray.direction = FirePoint.transform.forward;

        if (Physics.Raycast(ray, out rayHit, RayRange, LayerRayMask))
        {
            //Debug.Log("Debug RayHit: " + rayHit.collider.name);
            OnRayHit.Invoke();
            lineRenderer.SetPosition(1, rayHit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + ray.direction * RayRange);
            //Debug.Log("Debug RayHit: NOTHING");
        }
        yield return new WaitForSeconds(effectDuration);
        lineRenderer.enabled = false;
    }

    protected override void CooldownWeapon()
    {
        WeaponSchematic.CooldownWeapon(this);
    }
}
