using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMoveState : HumanBaseState
{
    private readonly int MoveHash = Animator.StringToHash("Move");
    private const float CrossFadeDuration = 0.1f;


    public HumanMoveState(HumanStateMachine stateMachine) : base(stateMachine)
    {
        //Debug.Log(stateMachine.gameObject.name + ": move state enter");
    }

    public override void Enter()
    {
        stateMachine.Agent.isStopped = false;
        stateMachine.Agent.speed = stateMachine.MovementSpeed;
        stateMachine.Animator.CrossFadeInFixedTime(MoveHash, CrossFadeDuration);
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {
        UpdateAgentMovement();
    }

    void UpdateAgentMovement()
    {
        if (stateMachine.Agent.remainingDistance < 5)
        {
            MoveTowardsTarget();
        }
    }


    void MoveTowardsTarget()
    {
        Vector3 position = HumanManager.instance.WanderingPoint[Random.Range(0, HumanManager.instance.WanderingPoint.Length)].position;
        stateMachine.Agent.SetDestination(position);
        
    }
}
