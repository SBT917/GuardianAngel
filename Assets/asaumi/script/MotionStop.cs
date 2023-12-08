using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MotionStop : MonoBehaviour
{
    private Animator animator;
    private bool collisionOccurred = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "car" タグを持つかどうかを確認
        if (collision.gameObject.tag=="Car")
        {
            // 衝突が発生したらアニメーターを停止
            animator.enabled = false;
            collisionOccurred = true;
            Debug.Log("判定あり");
        }
        if (collision.gameObject.tag == "Ground")
        {
            // 衝突が発生したらアニメーターを停止
            animator.enabled = false;
            collisionOccurred = true;
            Debug.Log("判定あり");
        }
    }
    private void Update()
    {
        if (collisionOccurred)
        {
            // 5秒後にDestroyメソッドを呼び出し、このオブジェクトを破棄する
            Destroy(gameObject, 5f);
        }
    }
}
