using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyState : PlayerBaseState
{
    //private readonly int FlyMoveHash = Animator.StringToHash("FlySpeed");
    private readonly int FlyHash = Animator.StringToHash("Fly");
    private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private const float AnimationDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
   


    public PlayerFlyState(PlayerStateMachine stateMachine):base(stateMachine)
    {
        //Debug.Log("fly state enter");
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FlyHash, CrossFadeDuration);
        stateMachine.InputReader.OnJumpPerformed += SwitchToFallState;
        stateMachine.GrabComponent.Release(0);
    }
    public override void Tick()
    {
        stateMachine.PlayerStamina -= 5f * Time.deltaTime;
        stateMachine.onChangeStamina?.Invoke(stateMachine.PlayerStamina);
        if (stateMachine.PlayerStamina <= 0)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerLandState(stateMachine));
        }



        CalculateMoveDirection();
        FaceMoveDirection();
        Move();

        stateMachine.Animator.SetFloat(MoveSpeedHash, stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ?
                                        1f : 0f, AnimationDampTime, Time.deltaTime);

    }
    public override void Exit() 
    {
        stateMachine.InputReader.OnJumpPerformed -= SwitchToFallState;
    }

    private void SwitchToFallState()
    {
        stateMachine.SwitchState(new PlayerFallState(stateMachine));
    }

    
   
}
