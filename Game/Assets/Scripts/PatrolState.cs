using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public float _timer;
    public List<Transform> _wayPoints = new List<Transform>();
    public NavMeshAgent _agent;
    
    private float patrolSpeed = 1.5f;
    private float patrolTimerLimit = 10f;
    private float chaseRange = 8f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = patrolSpeed;
        _timer = 0;
        GameObject gameObject = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in gameObject.transform)
        {
            _wayPoints.Add(t);
        }
        
        _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);
        }
        
        _timer += Time.deltaTime;
        if (_timer > patrolTimerLimit)
        {
            animator.SetBool("isPatrolling", false);
        }
        if (GetDistanceFromPlayer(animator.transform) < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}