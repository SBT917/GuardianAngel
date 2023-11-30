using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rd;


    // Update is called once per frame
    void Update()
    {
        rd = this.GetComponent<Rigidbody>();
        rd.useGravity = true;
    }
}
