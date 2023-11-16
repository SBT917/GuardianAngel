using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class PlayerStateMachine : StateMachine
{
    public Vector3 playerVelocity;
    public float movementSpeed { get; private set; } = 5f;
    public float jumpForce { get; private set; } = 5f;
    public float lookRotationDampFactor { get; private set; } = 10f;
    public Transform mainCamera {  get; private set; }
    public InputReader inputReader { get; private set; }
    public Animator playerAnimator { get; private set; }
    public CharacterController characterController { get; private set; }

    private void Start()
    {
        mainCamera = Camera.main.transform;
        inputReader = GetComponent<InputReader>();
        Animator playerAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        SwitchState(new PlayerMoveState(this));
    }
}
