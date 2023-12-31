using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMoveState : HumanBaseState
{
    private readonly int MoveHash = Animator.StringToHash("Move");
    private const float CrossFadeDuration = 0.1f;

    // レイの長さ
    private float maxMoveDistance = 50f;
    // 歩く方向
    private Vector3 walkDirection;


    public HumanMoveState(HumanStateMachine stateMachine) : base(stateMachine)
    {
        Debug.Log(stateMachine.gameObject.name + ": move state enter");
    }

    public override void Enter()
    {
        stateMachine.Agent.isStopped = false;
        stateMachine.Agent.speed = stateMachine.MovementSpeed;
        stateMachine.Animator.CrossFadeInFixedTime(MoveHash, CrossFadeDuration);

        ResetWalkParameters();
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {
        UpdateAgentMovement();
    }

    void ResetWalkParameters()
    {
        // ランダムの方向を作成
        var x = (Random.value * 2f) - 1f;
        var z = (Random.value * 2f) - 1f;

        walkDirection = new Vector3(x, 0f, z).normalized;
    }


    void UpdateAgentMovement()
    {
        if (stateMachine.Agent.remainingDistance < 5)
        {
            MoveTowardsTarget();
            ResetWalkParameters();
        }
    }


    void MoveTowardsTarget()
    {
        Vector3 position = HumanManager.instance.WanderingPoint[Random.Range(0, HumanManager.instance.WanderingPoint.Length)].position;
        stateMachine.Agent.SetDestination(position);
        
    }
}
