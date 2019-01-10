using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent)]
public class NavigationAgent : MonoBehaviour
{
    #region Fields and Properties

    [SerializeField]
    private NavMeshAgent navAgent;
    public NavMeshAgent NavAgent { get => navAgent; set => navAgent = value; }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
