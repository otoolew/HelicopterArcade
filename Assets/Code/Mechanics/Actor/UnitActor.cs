using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitActor : MonoBehaviour
{
    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction { get => faction; set => faction = value; }

    [SerializeField]
    private bool dead;
    public bool Dead { get => dead; set => dead = value; }

    #region Events and Handlers
    public event Action<UnitActor> removed;
    public UnityEvent OnUnitActorDeath;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UnitActorDeath()
    {
        dead = true;
        if (removed != null)
        {
            removed(this);
        }
        StartCoroutine("DeathSequence");
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
