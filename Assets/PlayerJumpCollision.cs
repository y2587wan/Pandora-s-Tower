using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCollision : StateMachineBehaviour {

    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = animator.gameObject;
        boxCollider = player.GetComponent<BoxCollider2D>();
        circleCollider = player.GetComponent<CircleCollider2D>();
        boxCollider.enabled = false;
        circleCollider.enabled = true;
    }

    
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boxCollider.enabled = true;
        circleCollider.enabled = false;
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
