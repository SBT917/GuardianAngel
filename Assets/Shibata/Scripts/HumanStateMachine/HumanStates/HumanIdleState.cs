using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdleState : HumanBaseState
{
    private readonly string IdleHash = "Idle";
    private const float CrossFadeDuration = 0.1f;
    private float idleTime;
    private float currentTime;

    public HumanIdleState(HumanStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Agent.isStopped = true;
        stateMachine.Animator.CrossFadeInFixedTime(IdleHash, CrossFadeDuration);
        idleTime = Random.Range(10f, 30f);
        currentTime = 0;
    }

    public override void Exit()
    {

    }

    public override void Tick()
    {
        currentTime += Time.deltaTime;
        if(currentTime > idleTime)
        {
            stateMachine.SwitchState(new HumanMoveState(stateMachine));
        }
    }
}
