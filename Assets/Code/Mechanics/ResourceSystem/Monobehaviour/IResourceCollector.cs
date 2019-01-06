using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceCollector : ISerializableInterface
{
    MissionStatus.CollectorStatus CollectorStatus { get; set; }
    ResourceDepot ResourceDepot { get; set; }
    ResourceField ResourceField { get; set; }
    bool IsEmpty();
    bool IsFull();
    void LoadResource();
    void DeliverResource();
    void UnloadResource();
    void RequestFieldAssignment();
}
[Serializable]
public class SerializableIResourceCollector<T> : SerializableInterface<IResourceCollector>
{
}