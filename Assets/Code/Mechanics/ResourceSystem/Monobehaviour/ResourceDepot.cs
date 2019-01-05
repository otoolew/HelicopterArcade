using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDepot : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private MissionCommand missionCommand;
    public MissionCommand MissionCommand { get => missionCommand; set => missionCommand = value; }

    [SerializeField]
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment { get => factionAlignment; set => factionAlignment = value; }

    public ResourceField[] AllResourceFields;
    public List<ResourceField> AvailableResourceFields;

    [SerializeField]
    private int resourceAmount;
    public int ResourceAmount
    {
        get { return resourceAmount; }
        set { resourceAmount = value; }
    }

    [SerializeField]
    private Transform dropPoint;
    public Transform DropPoint
    {
        get { return dropPoint; }
        set { dropPoint = value; }
    }

    #endregion
    #region Events

    #endregion

    #region Debug
    public Text textLabel;
    public Text resourceLabel;
    public Text factionLabel;
    #endregion


    #region Monobehaviour
    // Use this for initialization
    void Start()
    {
        missionCommand.GetComponentInParent<MissionCommand>();
        AllResourceFields = FindObjectsOfType<ResourceField>();
        AvailableResourceFields = new List<ResourceField>();

        for (int i = 0; i < AllResourceFields.Length; i++)
        {
            AllResourceFields[i].OnCapture.AddListener(OnFieldCapture);

            if (AllResourceFields[i].FactionAlignment == FactionAlignment)
                AddToAvailable(AllResourceFields[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        resourceLabel.text = resourceAmount.ToString();
    }
    public ResourceField RequestFieldAssignment()
    {
        if (AvailableResourceFields.Count > 0)
        {
            ResourceField lessWorkedField = AvailableResourceFields[0];
            for (int i = 1; i < AvailableResourceFields.Count; i++)
            {
                if (AvailableResourceFields[i].assignmentCount < lessWorkedField.assignmentCount)
                    lessWorkedField = AvailableResourceFields[i];
            }
            return lessWorkedField;         
        }
        return null;

    }
    public Vector3 ResourceLocation(ResourceField resourceField)
    {
        if (resourceField.AvailablePacks.Count > 0)
            return resourceField.AvailablePacks[0].transform.position;
        return DropPoint.position;
    }
    public void OnFieldCapture(ResourceField resource)
    {
        if (resource.FactionAlignment == FactionAlignment)
            AddToAvailable(resource);
        else
            RemoveFromAvailable(resource);
    }
    public void AddToAvailable(ResourceField field)
    {
        if (!AvailableResourceFields.Contains(field))
            AvailableResourceFields.Add(field);
    }
    public void RemoveFromAvailable(ResourceField field)
    {
        if (AvailableResourceFields.Contains(field))
            AvailableResourceFields.Remove(field);
    }
    public bool RecieveFieldRequest(IResourceCollector resourceCollector)
    {
        //TODO: IMPLEMENT
        Debug.Log("NOT IMPLEMENTED");
        return false;
    } 
    #endregion

}
