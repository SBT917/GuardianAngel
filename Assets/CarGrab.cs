using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CarGrab : MonoBehaviour,IGrabbable
{
    CarPatrol carPatrol;
    Collider col;
    Rigidbody rb;
    float preMass;
    private void Start()
    {
        carPatrol = GetComponent<CarPatrol>();
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    public GameObject Grabbed()
    {
        carPatrol.Invalid();
        col.enabled = false;
        rb.useGravity = false;
        preMass = rb.mass;
        rb.mass = 1;
        return this.gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        col.enabled = true;
        rb.useGravity = true;
        rb.mass = preMass;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
