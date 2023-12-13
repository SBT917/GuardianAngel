using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrabObject : GrabbableObject
{
    Collider col;
    Rigidbody rb;
    void Awake()
    {
        TryGetComponent(out col);
        TryGetComponent(out rb);
    }

    public override GameObject Grabbed()
    {
        Debug.Log(gameObject.name + "���͂܂ꂽ");
        col.enabled = false;
        return gameObject;
    }

    public override void Release(Vector3 direction, float force)
    {
        Debug.Log(gameObject.name + "�������ꂽ");
        col.enabled = true;
        rb.useGravity = true;
        Vector3 vel = direction * force;
        rb.AddForce(vel, ForceMode.Impulse);
    }
}
