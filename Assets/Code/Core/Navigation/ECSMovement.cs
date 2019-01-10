using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class ECSMovement : MonoBehaviour
{
    public float speed;

}
class ECSMovementSystem : ComponentSystem
{
    struct Components
    {
        //public ActorMovement actor;
        public Transform transform;
    }
    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Components>())
        {
            //entity.transform
        }

    }
}

