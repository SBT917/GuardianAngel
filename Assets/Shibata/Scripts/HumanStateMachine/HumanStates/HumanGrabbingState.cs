using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGrabbingState : HumanBaseState
{
    private readonly string GrabbingHash = "Struggle";
    private const float CrossFadeDuration = 0.1f;

    public HumanGrabbingState(HumanStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(GrabbingHash, CrossFadeDuration);
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {

    }
}
