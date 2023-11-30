using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suciderFall : MonoBehaviour
{
    public float raycastDistance = 1f;  // Raycast�̒���
    public LayerMask groundLayer;       // �n�ʂƂ��Ĕ��肷�郌�C���[
    private Animator animator;

    void Start()
    {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Ray���L�����N�^�[�̉������ɔ�΂�
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Raycast�Œn�ʂƂ̐ڐG������s��
        if (Physics.Raycast(ray, out hit, raycastDistance, groundLayer))
        {
            // �n�ʂɐڐG���Ă���ꍇ
            animator.Play("run");  // "run"�A�j���[�V�������Đ�
        }
        else
        {
            // �n�ʂɐڐG���Ă��Ȃ��ꍇ
            animator.Play("fall");  // "fall"�A�j���[�V�������Đ�
        }
    }
}
