using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SupplyTruckDriver : MonoBehaviour, IResourceCollector
{
    #region Fields and Properties
    
    [SerializeField]
    private NavMeshAgent navMesh;
    public NavMeshAgent NavAgent { get => navMesh; set => navMesh = value; }

    [SerializeField]
    private MissionCommand missionCommand;
    public MissionCommand MissionCommand { get => missionCommand; set => missionCommand = value; }

    [SerializeField]
    private MissionStatus.CollectorStatus collectorStatus;
    public MissionStatus.CollectorStatus CollectorStatus { get => collectorStatus; set => collectorStatus = value; }

    [SerializeField]
    private ResourceDepot resourceDepot;
    public ResourceDepot ResourceDepot { get => resourceDepot; set => resourceDepot = value; }

    [SerializeField]
    private ResourceField resourceField;
    public ResourceField ResourceField { get => resourceField; set => resourceField = value; }

    [SerializeField]
    private int maxResourceCapacity;
    public int MaxResourceCapacity { get => maxResourceCapacity; set => maxResourceCapacity = value; }

    [SerializeField]
    private int currentResourceAmount;
    public int CurrentResourceAmount { get => currentResourceAmount; set => currentResourceAmount = value; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        collectorStatus = MissionStatus.CollectorStatus.DEPLOYING;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEmpty())
            collectorStatus = MissionStatus.CollectorStatus.IDLE;
        if(IsFull())
            collectorStatus = MissionStatus.CollectorStatus.DELIVERING;
        switch (CollectorStatus)
        {
            case MissionStatus.CollectorStatus.DEPLOYING:
                // TODO: IMPLEMENT               
                break;
            case MissionStatus.CollectorStatus.IDLE:
                RequestFieldAssignment();
                break;
            case MissionStatus.CollectorStatus.FETCHING:
                // TODO: Check Path Validity
                break;
            case MissionStatus.CollectorStatus.LOADING:
                // TODO: Stop in Field
                break;
            case MissionStatus.CollectorStatus.DELIVERING:
                // TODO: Check Path Validity
                break;
            case MissionStatus.CollectorStatus.UNLOADING:
                // TODO: Stop in Depot
                break;
            default:
                break;
        }
    }
    #region IResourceCollector
    public void RequestFieldAssignment()
    {
        if (resourceDepot.RecieveFieldRequest(this))
        {
            collectorStatus = MissionStatus.CollectorStatus.FETCHING;
        }
        else
        {
           collectorStatus = MissionStatus.CollectorStatus.IDLE;
        }           
    }
    public void LoadResource()
    {
        Debug.Log("Loading Resources");
    }

    public void DeliverResource()
    {
        collectorStatus = MissionStatus.CollectorStatus.DELIVERING;
    }

    public void UnloadResource()
    {
        collectorStatus = MissionStatus.CollectorStatus.UNLOADING;
    }

    public bool IsEmpty()
    {
        if (currentResourceAmount <= 0)
            return true;
        return false;
    }

    public bool IsFull()
    {
        if (currentResourceAmount >= maxResourceCapacity)
        {
            collectorStatus = MissionStatus.CollectorStatus.DELIVERING;
            return true;
        }
        return false;
    }
    #endregion


}
