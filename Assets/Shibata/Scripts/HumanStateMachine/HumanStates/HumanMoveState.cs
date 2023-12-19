using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMoveState : HumanBaseState
{
    private readonly int MoveHash = Animator.StringToHash("Move");
    private const float CrossFadeDuration = 0.1f;

    // ƒŒƒC‚Ì’·‚³
    private float maxMoveDistance = 50f;
    // •à‚­•ûŒü
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
        // ƒ‰ƒ“ƒ_ƒ€‚Ì•ûŒü‚ğì¬
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
