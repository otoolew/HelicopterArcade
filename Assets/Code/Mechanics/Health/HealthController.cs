using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int maxHealthPoints;
    public int totalHealthPoints;
    public HitZone[] hitZones;
    public UnityEvent OnDeath;
    public void Start()
    {
        hitZones = GetComponentsInChildren<HitZone>();
        for (int i = 0; i < hitZones.Length; i++)
        {
            hitZones[i].OnHit.AddListener(ApplyDamage);
        }
        if (OnDeath == null)
            OnDeath = new UnityEvent();
    }
    // Start is called before the first frame update
    public void ApplyDamage(int amount)
    {
        totalHealthPoints -= amount;
        if (totalHealthPoints <= 0)
            OnDeath.Invoke();
    }

}
