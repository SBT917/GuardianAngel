using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrabObject :MonoBehaviour, IGrabbable
{
    Collider col;
    Rigidbody rb;
    void Awake()
    {
        TryGetComponent(out col);
        TryGetComponent(out rb);
    }

    public GameObject Grabbed()
    {
        Debug.Log(gameObject.name + "‚ª’Í‚Ü‚ê‚½");
        col.enabled = false;
        return gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        Debug.Log(gameObject.name + "‚ª•ú‚³‚ê‚½");
        col.enabled = true;
        rb.useGravity = true;
        Vector3 vel = direction * force;
        rb.AddForce(vel, ForceMode.Impulse);
    }
}
