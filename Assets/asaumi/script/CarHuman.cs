using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CarHuman : MonoBehaviour
{
    private HumanStateMachine stateMachine;
    private Animator animator;
    private bool collisionOccurred = false;
    public GameObject DeathHuman;
    public GameObject Zombie;
    bool DeathCheck;

    void Start()
    {
        stateMachine = GetComponent<HumanStateMachine>();
        animator = GetComponent<Animator>();
        DeathCheck = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.1)
            {
                // 衝突が発生したらアニメーターを停止
                Death();
            }
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

    public void Death()
    {
        if (!DeathCheck)
        {
            animator.enabled = false;
            collisionOccurred = true;

            Debug.Log("判定あり");
            var cadaver = Instantiate(DeathHuman, transform.position, Quaternion.identity);
            --HumanManager.instance.HumanCount;
            ++HumanManager.HumanDeathCount;
            var effectPos = transform.position + new Vector3(0, 1, 0);
            EffectManager.instance.PlayEffect(5, effectPos);
            Destroy(gameObject);

            DeathCheck = true;
        }
    }
    public void ChangeZombie()
    {
        if (!DeathCheck)
        {
            animator.enabled = false;
            collisionOccurred = true;

            Debug.Log("判定あり");
            var cadaver = Instantiate(Zombie, transform.position, Quaternion.identity);
            --HumanManager.instance.HumanCount;
            ++HumanManager.HumanDeathCount;
            Destroy(gameObject);

            DeathCheck = true;
        }
    }
}
