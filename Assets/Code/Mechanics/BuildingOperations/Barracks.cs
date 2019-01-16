using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    public KeyCodeVariable debugSpawnKey;

    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction { get => faction; set => faction = value; }

    [SerializeField]
    private int riflemenPoolCount;
    public int RiflemenPoolCount { get => riflemenPoolCount; set => riflemenPoolCount = value; }

    [SerializeField]
    private UnitActor infantryPrefab;
    public UnitActor InfantryPrefab { get => infantryPrefab; set => infantryPrefab = value; }

    [SerializeField]
    private Transform infantrySpawnPoint;
    public Transform InfantrySpawnPoint { get => infantrySpawnPoint; set => infantrySpawnPoint = value; }

    [SerializeField]
    private Transform infantryReturnPoint;
    public Transform InfantryReturnPoint { get => infantryReturnPoint; set => infantryReturnPoint = value; }

    public List<UnitActor> infantryList = new List<UnitActor>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < riflemenPoolCount; i++)
        {
            UnitActor newUnit = Instantiate(infantryPrefab);
            newUnit.Pooled = true;
            newUnit.Faction = faction;
            newUnit.name = faction.name + " Infantry";
            newUnit.transform.parent = null;
            newUnit.gameObject.SetActive(false);
            infantryList.Add(newUnit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (debugSpawnKey.KeyDownValue())
            SpawnRifleman();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("UnitActor"))
        {
            InfantryActor unit = other.GetComponentInParent<InfantryActor>();
            if (unit == null)
                return;
            unit.GetComponent<UnitActor>().Pooled = true;
            unit.GetComponent<UnitActor>().Dead = false;
            unit.GetComponent<HealthController>().totalHealthPoints = 100;
            unit.gameObject.SetActive(false);       
        }


    }

    public void SpawnRifleman()
    {
        foreach (var infantry in infantryList)
        {
            if (!infantry.isActiveAndEnabled && infantry.Pooled)
            {
                infantry.Pooled = false;
                infantry.transform.position = infantrySpawnPoint.position;
                infantry.gameObject.SetActive(true);
                return;
            }
        }
    }

}
