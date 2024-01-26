using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerStunState : PlayerBaseState
{
    private readonly int StunHash = Animator.StringToHash("Stun");
    private const float CrossFadeDuration = 0.1f;
    public PlayerStunState(PlayerStateMachine stateMachine):base(stateMachine)
    {
       
    }
    public override async void Enter()
    {
        stateMachine.playerStunned = true;
        if (stateMachine.GrabComponent!=null)
        {
            stateMachine.GrabComponent.Release(0);
        }
        stateMachine.Animator.CrossFadeInFixedTime(StunHash, CrossFadeDuration);
        await Task.Delay(5000);
        stateMachine.SwitchState(new PlayerMoveState(stateMachine));
    }
    public override void Tick()
    {
        this.Move();
        ApplyGravity();
        
    }
    public override async void Exit()
    {
        
    }
    protected override void Move() { }

}
