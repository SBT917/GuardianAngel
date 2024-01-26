using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieGrab : MonoBehaviour, IGrabbable
{
    Collider col;
    Rigidbody rb;
    Animator animator;
    NavMeshAgent agent;
    ChaseEnemy chaseCore;
    ChangeObjectThrowing zombieThrow;

    [SerializeField]
    float grabbingOffset;

    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        chaseCore = GetComponent<ChaseEnemy>();
        zombieThrow = GetComponent<ChangeObjectThrowing>();
    }


    public GameObject Grabbed(out float offset)
    {
        offset = grabbingOffset;
        chaseCore.enabled = false;
        animator.enabled = false;
        agent.enabled = false;
        col.enabled = false;
        rb.useGravity = false;


        return this.gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        col.enabled = true;
        rb.useGravity = true;
        zombieThrow.IsThrowing = true;
        rb.AddForce(direction * force / 3, ForceMode.Impulse);
        AudioManager.instance.PlaySE("Release");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
