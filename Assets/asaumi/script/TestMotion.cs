using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMotion : MonoBehaviour
{

    public float speed = -5.0f; // ‘¬“x‚Ìİ’è

    void Update()
    {
        // X²•ûŒü‚Éˆê’è‚Ì‘¬“x‚Å“®‚­
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
