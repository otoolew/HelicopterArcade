﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderParent : MonoBehaviour
{
    [SerializeField]
    GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject RecieveParent()
    {
        return parentObject;
    }
}
