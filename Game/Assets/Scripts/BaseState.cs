using UnityEngine;

public abstract class BaseState : StateMachineBehaviour
{
    protected Transform player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override abstract void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement any code to run when the state is exited
    }
}