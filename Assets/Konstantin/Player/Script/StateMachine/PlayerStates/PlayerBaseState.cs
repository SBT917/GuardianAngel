using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine stateMachine;
    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected virtual void CalculateMoveDirection()
    {
        Vector3 cameraForward = new(stateMachine.MainCamera.forward.x, 0, stateMachine.MainCamera.forward.z);
        Vector3 cameraRight = new(stateMachine.MainCamera.right.x, 0, stateMachine.MainCamera.right.z);

        Vector3 moveDirection = cameraForward.normalized * stateMachine.InputReader.MoveComposite.y 
            + cameraRight.normalized * stateMachine.InputReader.MoveComposite.x;

        stateMachine.Velocity.x = moveDirection.x * stateMachine.MovementSpeed;
        stateMachine.Velocity.z = moveDirection.z * stateMachine.MovementSpeed;
        stateMachine.MovementSpeedMultiplier = 1;

        if (stateMachine.GetState().GetType() == typeof(PlayerFlyState))
        {
            stateMachine.Velocity.y = stateMachine.InputReader.Altitude * 5;
            stateMachine.MovementSpeedMultiplier = 2;
        }
    }

    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = new(stateMachine.Velocity.x, 0f, stateMachine.Velocity.z);

        if (faceDirection == Vector3.zero)
            return;

        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), stateMachine.LookRotationDampFactor * Time.deltaTime);
    }

    protected void ApplyGravity()
    {
        if (stateMachine.Velocity.y > Physics.gravity.y)
        {
            stateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    protected void Move()
    {
        stateMachine.Controller.Move(stateMachine.Velocity * stateMachine.MovementSpeedMultiplier * Time.deltaTime);
    }
}
