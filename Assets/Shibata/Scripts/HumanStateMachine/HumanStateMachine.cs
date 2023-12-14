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

    public GameObject Grabbed()
    {
        Collider.enabled = false;
        SwitchState(new HumanGrabbingState(this));
        return gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        Collider.enabled = true;
        Rigidbody.useGravity = true;
        Vector3 vel = direction * force;
        Rigidbody.AddForce(vel, ForceMode.Impulse);
        SwitchState(new HumanMoveState(this));
    }

}
