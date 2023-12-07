using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputReader))]
[RequireComponent (typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{

    //速度
    public Vector3 Velocity;
    public float MovementSpeed { get; private set; } = 5f;
    public float MovementSpeedMultiplier { get; set; }
    //ジャンプ力
    public float JumpForce { get; private set; } = 5f;
    //カメラ回転ダンプ"
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }
    public PlayerGrab GrabComponent { get; private set; }

    [field: SerializeField] public float PlayerMaxStamina { get; set; } = 10f;
    [field: SerializeField] public float PlayerStamina { get; set; }
    public Action<float> onChangeStamina;

    private void Start()
    {
        MainCamera = Camera.main.transform;
        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        Controller  = GetComponent<CharacterController>();
        GrabComponent = GetComponent<PlayerGrab>();
        PlayerStamina = PlayerMaxStamina;

        SwitchState(new PlayerMoveState(this));
    }


}
