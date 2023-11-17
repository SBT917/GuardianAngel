using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private readonly int MoveBlendTreeHash = Animator.StringToHash("MoveBlendTree");
    private const float AnimationDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.playerVelocity.y = Physics.gravity.y;

        //_stateMachine.playerAnimator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);

        _stateMachine.inputReader.onJumpPerformed += SwitchToJumpState;
    }

    public override void Tick()
    {
        if (!_stateMachine.characterController.isGrounded)
        {
            _stateMachine.SwitchState(new PlayerFallState(_stateMachine));
        }

        CalculateMoveDirection();
        FaceMoveDirection();
        Move();

        //_stateMachine.playerAnimator.SetFloat(MoveSpeedHash, _stateMachine.inputReader.moveComposite.sqrMagnitude > 0f ? 1f : 0f, 
        //    AnimationDampTime, Time.deltaTime);
    }

    public override void Exit()
    {
        _stateMachine.inputReader.onJumpPerformed -= SwitchToJumpState;
    }

    private void SwitchToJumpState()
    {
        _stateMachine.SwitchState(new PlayerJumpState(_stateMachine));
    }
}
