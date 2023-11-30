using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMotion : MonoBehaviour
{

    public float speed = -5.0f; // 速度の設定

    void Update()
    {
        // X軸方向に一定の速度で動く
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
