using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    protected readonly PlayerStateMachine _stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    { this._stateMachine = stateMachine; }

    protected void CalculateMoveDirection()
    {
        Vector3 cameraForward = new(_stateMachine.mainCamera.forward.x, 0, _stateMachine.mainCamera.forward.z);
        Vector3 cameraRight = new(_stateMachine.mainCamera.right.x, 0, _stateMachine.mainCamera.right.z);

        Vector3 moveDirection = cameraForward.normalized * _stateMachine.inputReader.moveComposite.y 
                                + cameraRight.normalized * _stateMachine.inputReader.moveComposite.x;

        _stateMachine.playerVelocity.x = moveDirection.x * _stateMachine.movementSpeed;
        _stateMachine.playerVelocity.z = moveDirection.z * _stateMachine.movementSpeed;
    }

    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = new(_stateMachine.playerVelocity.x, 0f, _stateMachine.playerVelocity.z);

        if (faceDirection == Vector3.zero)
            return;

        _stateMachine.transform.rotation = Quaternion.Slerp(_stateMachine.transform.rotation, Quaternion.LookRotation(faceDirection),
                                            _stateMachine.lookRotationDampFactor * Time.deltaTime);
    }

    protected void ApplyGravity()
    {
        if (_stateMachine.playerVelocity.y > Physics.gravity.y)
        {
            _stateMachine.playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    protected void Move()
    {
        _stateMachine.characterController.Move(_stateMachine.playerVelocity * Time.deltaTime);
    }
    #region empty implementation of abstact methods
    public override void Enter() { }
    public override void Tick() { }
    public override void Exit() { }
    #endregion
}
