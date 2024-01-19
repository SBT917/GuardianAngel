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

    // 経過時間
    private float time;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time > spawnSpan)
        {
            for (int i = 0; i < oneTimeSpawnCount; ++i)
            {
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(meteor, new Vector3(x, y, z), meteor.transform.rotation);

                // 経過時間リセット
                time = 0f;
            }
            
        }
    }
}
