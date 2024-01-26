using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour, IGrabbable
{
    public delegate void ThrowEventHandler();
    public event ThrowEventHandler OnItemThrown;

    Collider col;
    Rigidbody rb;

    [SerializeField]
    float throwingForce = 15;

    [SerializeField]
    float grabbingOffset = 5;

    private void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    public GameObject Grabbed(out float offset)
    {
        offset = grabbingOffset;
        col.enabled = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        return this.gameObject;
    }

    public void Release(Vector3 direction, float force)
    {
        col.enabled = true;
        rb.useGravity = true;
        rb.AddForce(direction * force * throwingForce, ForceMode.Impulse);
        AudioManager.instance.PlaySE("Release");
        if (OnItemThrown != null) { OnItemThrown(); }

    }
}
