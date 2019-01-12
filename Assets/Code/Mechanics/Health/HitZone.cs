using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitZone : MonoBehaviour
{
    public int damageMultiplier;
    // Issues with this Event working
    public Events.HitZoneHit OnHit;

    public void TakeDamage(int amount)
    {
        int totalDamage = amount * damageMultiplier;
        OnHit.Invoke(totalDamage);
    }
}
