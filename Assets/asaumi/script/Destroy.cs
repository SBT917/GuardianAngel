using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // �Փ˂������������ǂ����̃t���O
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
        // �Փ˂�����������5�b��ɃI�u�W�F�N�g��j��
        if (collisionOccurred)
        {
            // 5�b���Destroy���\�b�h���Ăяo���A���̃I�u�W�F�N�g��j������
            Destroy(gameObject, 5f);
        }
    }
}
