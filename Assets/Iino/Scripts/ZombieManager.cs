using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] zombie;

    [SerializeField]
    float generateInterval;

    [SerializeField]
    Transform[] zombieSpawnPoint;

    [SerializeField]
    private int maxZombieCount;

    private float timeCount;

    private int zombieCount;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount > generateInterval)
        {
            if(zombieCount < maxZombieCount)
            {
                Instantiate(zombie[0], GetRandomSpawnPoint().position, Quaternion.identity);
            }
            timeCount = 0;
        }
    }

    Transform GetRandomSpawnPoint()
    {
        return zombieSpawnPoint[Random.Range(0, zombieSpawnPoint.Length - 1)];
    }
}
