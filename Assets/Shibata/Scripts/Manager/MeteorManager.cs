using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
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
                Vector3 pos = transform.GetChild(Random.Range(0, transform.childCount)).position;
                pos.y += Random.Range(300, 500);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(meteor, pos, meteor.transform.rotation);

                // �o�ߎ��ԃ��Z�b�g
                time = 0f;
            }
            
        }
    }
}
