using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryAim : StateMachineBehaviour
{
    InfantryActor actor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        actor = animator.GetComponent<InfantryActor>();
        actor.NavigationAgent.NavAgent.isStopped = true;
        Debug.Log("Unit State: Aiming!");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        actor.NavigationAgent.NavAgent.isStopped = true;
        actor.AimAtTarget();
        if (actor.Weapon.WeaponReady)
            animator.SetBool("WeaponReady", true);
        else
        {
            animator.SetBool("WeaponReady", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
