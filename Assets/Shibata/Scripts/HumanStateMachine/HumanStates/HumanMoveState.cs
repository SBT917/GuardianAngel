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
        stateMachine.Agent.enabled = true;
        stateMachine.Agent.speed = stateMachine.MovementSpeed;
        stateMachine.Animator.CrossFadeInFixedTime(MoveHash, CrossFadeDuration);

        ResetWalkParameters();
    }

    public override void Exit()
    {
        stateMachine.Agent.enabled = false;
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
        // 一定期間ごとに目的地を設定して値を初期化
        if (stateMachine.Agent.remainingDistance <= 0)
        {
            MoveTowardsTarget();
            ResetWalkParameters();
        }
    }


    void MoveTowardsTarget()
    {
        // レイの始点
        var sourcePos = stateMachine.transform.position;

        // レイの終点
        var targetPos = sourcePos + walkDirection * maxMoveDistance;

        // レイを投げる
        var blocked = NavMesh.Raycast(sourcePos, targetPos, out NavMeshHit hitInfo, NavMesh.AllAreas);

        if (blocked)
        {
            // ヒット地点を目的地にする
            stateMachine.Agent.SetDestination(hitInfo.position);
        }
        else
        {
            // ターゲット位置を目的地にする。
            stateMachine.Agent.SetDestination(targetPos);
        }
    }
}
