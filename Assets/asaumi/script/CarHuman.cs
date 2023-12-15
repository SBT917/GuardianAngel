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
            // �Փ˂�����������A�j���[�^�[���~
            animator.enabled = false;
            collisionOccurred = true;
           
            Debug.Log("���肠��");
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
            // 5�b���Destroy���\�b�h���Ăяo���A���̃I�u�W�F�N�g��j������
            Destroy(gameObject, 5f);
        }
    }
}
