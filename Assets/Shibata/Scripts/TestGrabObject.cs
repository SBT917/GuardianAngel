using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrabObject : MonoBehaviour, IGrabbable
{
    Collider col;
    Rigidbody rb;
    void Awake()
    {
        TryGetComponent(out col);
        TryGetComponent(out rb);
    }

    public void Grabbed(Transform transform)
    {
        Debug.Log(gameObject.name + "‚ª’Í‚Ü‚ê‚½");
        this.transform.parent = transform;
        col.enabled = false;
    }

    public void Release(Transform transform)
    {
        Debug.Log(gameObject.name + "‚ª•ú‚³‚ê‚½");
        this.transform.parent = null;
        col.enabled = true;
        rb.useGravity = true;
        Vector3 vel = transform.forward * 25;
        rb.AddForce(vel, ForceMode.Impulse);
    }
}
