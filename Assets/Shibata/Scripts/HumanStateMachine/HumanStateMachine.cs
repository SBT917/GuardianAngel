using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class HumanStateMachine : StateMachine, IGrabbable
{
    public NavMeshAgent Agent { get; private set; }
    public Animator Animator { get; private set; }
    public Collider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float MovementSpeed {  get; private set; } = 1.0f;
    public float WanderRange { get; private set; }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();

        SwitchState(new HumanMoveState(this));
    }

    public GameObject Grabbed(out float offset)
    {
        Collider.enabled = false;
        Rigidbody.useGravity = false;
        Agent.enabled = false;
        offset = 3.0f;
        SwitchState(new HumanGrabbingState(this));
        return gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        Collider.enabled = true;
        Rigidbody.useGravity = true;
        Agent.enabled = true;
        SwitchState(new HumanIdleState(this));
        AudioManager.instance.PlaySE("HumanPut");
    }

}
