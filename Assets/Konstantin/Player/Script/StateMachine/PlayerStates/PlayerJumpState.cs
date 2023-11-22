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
    }
    public override void Tick()
    {
        if(stateMachine.Velocity.y<=0f)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        FaceMoveDirection();
        Move();
    }
    public override void Exit() { }
}
