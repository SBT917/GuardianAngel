using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private Transform rangeA;
    [SerializeField] private Transform rangeB;

    // �o�ߎ���
    private float time;

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        if (time > 10.0f)
        {
            for (int i = 0; i < 5; ++i)
            {
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(meteor, new Vector3(x, y, z), meteor.transform.rotation);

                // �o�ߎ��ԃ��Z�b�g
                time = 0f;
            }
            
        }
    }
}
