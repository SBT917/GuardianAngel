using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanChange : MonoBehaviour
{
    public GameObject boyPrefab; // �{�[�CPrefab��Inspector����A�^�b�`����
    bool check = false;

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����������Ƃ��̏���
        // �Փ˂����I�u�W�F�N�g�����ł�����
        Destroy(gameObject);

        // �V����Prefab�𓯂����W�ɐ�������
        if (check == false)
        {
            Instantiate(boyPrefab, collision.contacts[0].point, Quaternion.identity);
            check = true;
        }

    }
}
