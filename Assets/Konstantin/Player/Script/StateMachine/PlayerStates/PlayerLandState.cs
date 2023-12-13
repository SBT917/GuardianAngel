using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLandState : PlayerBaseState
{
    private readonly int LandHash = Animator.StringToHash("Land");
    private const float CrossFadeDuration = 0.1f;


    public PlayerLandState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        Debug.Log("land state enter");
    }
    public override async void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LandHash, CrossFadeDuration);
        await Task.Delay(200);
        stateMachine.SwitchState(new PlayerMoveState(stateMachine));
    }
    public override void Tick()
    {

    }
    public override void Exit()
    {
        
    }
    
}
