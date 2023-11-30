using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyState : PlayerBaseState
{
    //private readonly int FlyMoveHash = Animator.StringToHash("FlySpeed");
    private readonly int FlyHash = Animator.StringToHash("Fly");
    private const float AnimationDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
   


    public PlayerFlyState(PlayerStateMachine stateMachine):base(stateMachine)
    {
        Debug.Log("fly state enter");
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FlyHash, CrossFadeDuration);
    }
    public override void Tick()
    {
        stateMachine.PlayerStamina -= 4f * Time.deltaTime;
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

    }
    public override void Exit() 
    {
        
    }

    
   
}
