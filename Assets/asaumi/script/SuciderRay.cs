using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class suciderFall : MonoBehaviour
{
    private Rigidbody rb;
    private float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        distance = 1.5f;
    }

    private void Update()
    {
        Vector3 rayposition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayposition, Vector3.down);
        bool isGround=Physics.Raycast(ray,distance);
        Debug.DrawRay(rayposition,Vector3.down*distance, Color.yellow);
        Debug.Log(isGround);
    }
}
