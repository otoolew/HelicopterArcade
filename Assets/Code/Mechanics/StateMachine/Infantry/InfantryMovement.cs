﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryMovement : StateMachineBehaviour
{
    InfantryActor actor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        actor = animator.GetComponent<InfantryActor>();
        actor.NavigationAgent.NavAgent.isStopped = false;
        Debug.Log("Unit State: Moving!");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       

        //NPCMovement.NavAgent.SetDestination(NPCMovement.Destination);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
