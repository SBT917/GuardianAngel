using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : Singleton<HumanManager>
{
    public int HumanCount { get; set; }
    public int HumanDeathCount { get; set; }
    [field: SerializeField] public Transform[] WanderingPoint { get; private set; }

    [SerializeField] private GameObject[] humansPrefabs;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private float spawnSpan;
    [SerializeField] private int humanLimit;

    private float timeCount;

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount > spawnSpan)
        {
            if (HumanCount > humanLimit) return;

            timeCount = 0;

            int index = Random.Range(0, spawnPoint.Length);
            Instantiate(humansPrefabs[0], spawnPoint[index].position, Quaternion.identity);
            ++HumanCount;
        }
    }
}
