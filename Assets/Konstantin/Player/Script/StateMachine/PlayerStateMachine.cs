using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputReader))]
[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{

    //���x
    public Vector3 Velocity;
    public float MovementSpeed { get; private set; } = 10f;
    public float MovementSpeedMultiplier { get; set; }
    //�W�����v��
    public float JumpForce { get; private set; } = 5f;
    //�J������]�_���v"
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    public PlayerGrab GrabComponent { get; private set; }

    [field: SerializeField] public float PlayerMaxStamina { get; set; } = 50f;
    [field: SerializeField] public float PlayerStamina { get; set; }
    public Action<float> onChangeStamina;
    [field: SerializeField] public bool playerStunned { get; set; }
    [field: SerializeField] public PlayerBaseState currentState { get; set; }

    private void Awake()
    {
        MainCamera = Camera.main.transform;
        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        Controller  = GetComponent<CharacterController>();
        GrabComponent = GetComponentInChildren<PlayerGrab>();
        PlayerStamina = PlayerMaxStamina;
        playerStunned = false;
        currentState = new PlayerMoveState(this);
        SwitchState(new PlayerMoveState(this));
    }


}
