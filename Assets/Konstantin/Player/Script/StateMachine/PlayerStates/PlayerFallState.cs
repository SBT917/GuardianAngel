using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");
    private const float CrossFadeDuration = 0.1f;

    public PlayerFallState(PlayerStateMachine stateMachine): base(stateMachine) 
    {
        //Debug.Log("fall state enter");
    }

    public override void Enter()
    {
        stateMachine.currentState = this;
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);
    }
    
    public override void Tick()
    {
        ApplyGravity();
        CalculateMoveDirection();
        FaceMoveDirection();
        Move();
        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerLandState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
