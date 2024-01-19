using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : Singleton<HumanManager>
{
    public int HumanCount { get; set; }
    public static int HumanDeathCount { get; set; }
    [field: SerializeField] public Transform[] WanderingPoint { get; private set; }

    [SerializeField] private GameObject[] humansPrefabs;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float spawnSpan;
    [SerializeField] private int oneTimeSpawnCount;
    [SerializeField] private int humanLimit;

    private float timeCount;

    void Start()
    {
        int index = Random.Range(0, spawnPoint.Length);
        Instantiate(humansPrefabs[0], spawnPoint[index].position, Quaternion.identity);
        ++HumanCount;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount > spawnSpan)
        {
            timeCount = 0;

            for (int i = 0; i < oneTimeSpawnCount; ++i)
            {
                if (HumanCount + HumanDeathCount >= humanLimit) return;

                int index = Random.Range(0, spawnPoint.Length);
                Instantiate(humansPrefabs[0], spawnPoint[index].position, Quaternion.identity);
                ++HumanCount;
            }
            
        }
    }
}
