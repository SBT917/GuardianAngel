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
    private void Start()
    {
        carPatrol = GetComponent<CarPatrol>();
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    public GameObject Grabbed(out float offset)
    {
        offset = 5f;
        carPatrol.Invalid();
        col.enabled = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        return this.gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        col.enabled = true;
        rb.useGravity = true;
        rb.AddForce(direction * force * 10, ForceMode.Impulse);
    }

}
