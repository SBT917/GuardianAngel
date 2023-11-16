using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");
    private const float CrossFadeDuration = 0.1f;

    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.playerVelocity.y = 0f;

        _stateMachine.playerAnimator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);
    }

    public override void Tick()
    {
        ApplyGravity();
        Move();

        if (_stateMachine.characterController.isGrounded)
        {
            _stateMachine.SwitchState(new PlayerMoveState(_stateMachine));
        }
    }

    public override void Exit() { }
}
