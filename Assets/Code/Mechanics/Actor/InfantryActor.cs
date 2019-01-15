﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryActor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public Animator Animator { get => animator; set => animator = value; }

    [SerializeField]
    private NavigationAgent navigationAgent;
    public NavigationAgent NavigationAgent { get => navigationAgent; set => navigationAgent = value; }

    [SerializeField]
    private TargetController targetController;
    public TargetController TargetController { get => targetController; set => targetController = value; }

    [SerializeField]
    private InfantryWeapon weapon;
    public InfantryWeapon Weapon { get => weapon; set => weapon = value; }

    //public event Action<UnitActor> removed;
    // Start is called before the first frame update
    void Start()
    {     
        targetController.Faction = GetComponent<UnitActor>().Faction;
        targetController.OnAcquiredTarget.AddListener(HandleTargetAcquired);
        targetController.OnLostTarget.AddListener(HandleTargetLost);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveVelocity", navigationAgent.NavAgent.velocity.magnitude);
    }


    public void AimAtTarget()
    {
        if (targetController.CurrentTarget == null)
            return;
        // Create a vector from the npc to the target.
        Vector3 rotVector = targetController.CurrentTarget.transform.position - transform.position;

        // Ensure the vector is entirely along the floor plane.
        rotVector.y = 0f;

        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        Quaternion newRotation = Quaternion.LookRotation(rotVector);

        // Set the character's rotation to this new rotation.
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1f);

    }
    public void HandleTargetAcquired(UnitActor target)
    {
        animator.SetBool("HasTarget", true);
        //animator.SetTrigger("TargetInRange");
    }
    public void HandleTargetLost()
    {
        Debug.Log("Target Lost");
        animator.SetBool("HasTarget", false);
    }
}
