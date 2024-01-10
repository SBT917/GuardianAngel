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
        if (collision.gameObject.tag == "Car")
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.1)
            {
                // �Փ˂�����������A�j���[�^�[���~
                Death();
            }
        }
    }
    private void Update()
    {
        if (collisionOccurred)
        {
            // 5�b���Destroy���\�b�h���Ăяo���A���̃I�u�W�F�N�g��j������
            Destroy(gameObject, 5f);
        }
    }

    public void Death()
    {
        if (!DeathCheck)
        {
            animator.enabled = false;
            collisionOccurred = true;

            Debug.Log("���肠��");
            var cadaver = Instantiate(DeathHuman, transform.position, Quaternion.identity);
            --HumanManager.instance.HumanCount;
            ++HumanManager.HumanDeathCount;
            Destroy(gameObject);

            DeathCheck = true;
        }
    }
}
