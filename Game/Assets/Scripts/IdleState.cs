using UnityEngine;

public class IdleState : BaseState
{
    private readonly float chaseRange = 8f;
    private float timer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            animator.SetBool("isPatrolling", true);
        }

       // if (GetDistanceFromPlayer(animator.transform) < chaseRange)
        //{
       //     animator.SetBool("isChasing", true);
       // }
    }
}