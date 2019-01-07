using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    public GameObject goPrefab;
    public FactionAlignment faction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SpawnObject();
    }
    void SpawnObject()
    {
        goPrefab.GetComponent<Faction>().FactionAlignment = faction;
        GameObject ship = Instantiate(goPrefab, transform);
        ship.transform.parent = null;
    }
}
