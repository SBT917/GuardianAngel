using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // 衝突が発生したかどうかのフラグ
    private bool collisionOccurred = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            collisionOccurred = true;
        }
    }

    void Update()
    {
        // 衝突が発生したら5秒後にオブジェクトを破棄
        if (collisionOccurred)
        {
            // 5秒後にDestroyメソッドを呼び出し、このオブジェクトを破棄する
            Destroy(gameObject, 5f);
        }
    }
}
