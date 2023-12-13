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
        // �Փ˂����I�u�W�F�N�g�� "car" �^�O�������ǂ������m�F
        if (collision.gameObject.tag=="Car")
        {
            // �Փ˂�����������A�j���[�^�[���~
            animator.enabled = false;
            collisionOccurred = true;
            Debug.Log("���肠��");
        }
        if (collision.gameObject.tag == "Ground")
        {
            // �Փ˂�����������A�j���[�^�[���~
            animator.enabled = false;
            collisionOccurred = true;
            Debug.Log("���肠��");
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
}
