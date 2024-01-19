using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private Transform rangeA;
    [SerializeField] private Transform rangeB;
    [SerializeField] private float spawnSpan;
    [SerializeField] private int oneTimeSpawnCount;

    // �o�ߎ���
    private float time;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time > spawnSpan)
        {
            for (int i = 0; i < oneTimeSpawnCount; ++i)
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
