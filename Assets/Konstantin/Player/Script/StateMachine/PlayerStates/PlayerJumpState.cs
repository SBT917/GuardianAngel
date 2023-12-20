using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;

    public PlayerJumpState(PlayerStateMachine stateMachine):base(stateMachine)
    {
        Debug.Log("jump state enter");
    }

    public override void Enter()
    {
        stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.JumpForce, stateMachine.Velocity.z);
        stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
        stateMachine.InputReader.OnJumpPerformed += SwitchToFlyState;
    }
    public override void Tick()
    {
        ApplyGravity();
        if(stateMachine.Velocity.y<=0f)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        CalculateMoveDirection();
        FaceMoveDirection();
        Move();
    }
    public override void Exit() 
    {
        stateMachine.InputReader.OnJumpPerformed -= SwitchToFlyState;
    }

    private void SwitchToFlyState()
    {
        stateMachine.SwitchState(new PlayerFlyState(stateMachine));
    }
}
