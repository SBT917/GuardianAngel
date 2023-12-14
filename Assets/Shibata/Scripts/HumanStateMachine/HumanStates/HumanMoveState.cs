using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMoveState : HumanBaseState
{
    private readonly int MoveHash = Animator.StringToHash("Move");
    private const float CrossFadeDuration = 0.1f;

    // ���C�̒���
    private float maxMoveDistance = 50f;
    // ��������
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
        // �����_���̕������쐬
        var x = (Random.value * 2f) - 1f;
        var z = (Random.value * 2f) - 1f;

        walkDirection = new Vector3(x, 0f, z).normalized;
    }


    void UpdateAgentMovement()
    {
        // �����Ԃ��ƂɖړI�n��ݒ肵�Ēl��������
        if (stateMachine.Agent.remainingDistance <= 0)
        {
            MoveTowardsTarget();
            ResetWalkParameters();
        }
    }


    void MoveTowardsTarget()
    {
        // ���C�̎n�_
        var sourcePos = stateMachine.transform.position;

        // ���C�̏I�_
        var targetPos = sourcePos + walkDirection * maxMoveDistance;

        // ���C�𓊂���
        var blocked = NavMesh.Raycast(sourcePos, targetPos, out NavMeshHit hitInfo, NavMesh.AllAreas);

        if (blocked)
        {
            // �q�b�g�n�_��ړI�n�ɂ���
            stateMachine.Agent.SetDestination(hitInfo.position);
        }
        else
        {
            // �^�[�Q�b�g�ʒu��ړI�n�ɂ���B
            stateMachine.Agent.SetDestination(targetPos);
        }
    }
}
