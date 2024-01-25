using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private readonly int MoveBlendTreeHash = Animator.StringToHash("MoveBlendTree");
    private const float AnimationDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public PlayerMoveState(PlayerStateMachine stateMachine):base(stateMachine)
    {
        //Debug.Log("move state enter");
    }
    public override void Enter()
    {
        stateMachine.currentState = this;
        stateMachine.Velocity.y = Physics.gravity.y;
        stateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);
        stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
    }
    public override void Exit()
    { 
        stateMachine.InputReader.OnJumpPerformed -=SwitchToJumpState;
    }
    public override void Tick()
    {
        if(!stateMachine.Controller.isGrounded) 
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }


        // Does the ray intersect any objects excluding the player layer
        CalculateMoveDirection();
        FaceMoveDirection();
        RestoreStamina();
        Move();

        stateMachine.Animator.SetFloat(MoveSpeedHash, stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ? 
                                        1f : 0f, AnimationDampTime, Time.deltaTime);
    }
    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }

    private void RestoreStamina()
    {
        if(stateMachine.PlayerStamina < stateMachine.PlayerMaxStamina)
        {
            stateMachine.PlayerStamina += 5f * Time.deltaTime;
            if(stateMachine.PlayerStamina > stateMachine.PlayerMaxStamina) stateMachine.PlayerStamina = stateMachine.PlayerMaxStamina;
            stateMachine.onChangeStamina?.Invoke(stateMachine.PlayerStamina);
        }
    }
}
