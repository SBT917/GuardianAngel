using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMotion : MonoBehaviour
{

    public float speed = -5.0f; // ���x�̐ݒ�

    void Update()
    {
        // X�������Ɉ��̑��x�œ���
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
