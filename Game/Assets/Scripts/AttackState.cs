using UnityEngine;

public class AttackState : BaseState
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = GetDistanceFromPlayer(animator.transform);
        if (distance > 3.5f)
        {
            animator.SetBool("isAttacking", false);
        }
    }
}