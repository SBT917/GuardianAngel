using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private const float CrossFadeDuration = 0.1f;

    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.playerVelocity = new Vector3(_stateMachine.playerVelocity.x, 
                           _stateMachine.jumpForce, _stateMachine.playerVelocity.z);

        _stateMachine.playerAnimator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
    }

    public override void Tick()
    {
        ApplyGravity();

        if (_stateMachine.playerVelocity.y <= 0f)
        {
            _stateMachine.SwitchState(new PlayerFallState(_stateMachine));
        }

        FaceMoveDirection();
        Move();
    }

    public override void Exit() { }
}
