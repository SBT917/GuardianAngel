using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GrabbableObject : MonoBehaviour
{
    Collider col;
    Rigidbody rb;
    
    private void Awake()
    {
        TryGetComponent(out col);
        TryGetComponent(out rb);

    }
    public virtual GameObject Grabbed()
    {
        Debug.Log(gameObject.name + "‚ª’Í‚Ü‚ê‚½");
        col.enabled = false;
        return gameObject;
    }

    public virtual void  Release(Vector3 direction, float force)
    {
        Debug.Log(gameObject.name + "‚ª•ú‚³‚ê‚½");
        col.enabled = true;
        rb.useGravity = true;
        Vector3 vel = direction * force;
        rb.AddForce(vel, ForceMode.Impulse);
    }
}
