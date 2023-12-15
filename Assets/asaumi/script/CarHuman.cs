using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MotionStop : MonoBehaviour
{
    private HumanStateMachine stateMachine;
    private Animator animator;
    private bool collisionOccurred = false;
    public GameObject DeathHuman;
    bool DeathCheck;

    void Start()
    {
        stateMachine = GetComponent<HumanStateMachine>();
        animator = GetComponent<Animator>();
        DeathCheck = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Car")
        {
            // 衝突が発生したらアニメーターを停止
            animator.enabled = false;
            collisionOccurred = true;
           
            Debug.Log("判定あり");
            if (DeathCheck == false)
            {
                Instantiate(DeathHuman, collision.contacts[0].point, Quaternion.identity);
                DeathCheck = true; 
            }
        Destroy(gameObject);}
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
