using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarManager : Singleton<CarManager>
{
    [SerializeField]
    private List<GameObject> cars;

    [SerializeField]
    private Vector3 carSpawnPoint;

    public Transform[] patrolPoint;

    [SerializeField]
    private int CarMaxNum;

    private int carGenQueue;

    public int carCount { get; private set; }

    private bool canSpawn = true; // 生成可能かどうかのフラグ

    private bool generatingCar;

    // Start is called before the first frame update
    void Start()
    {
        var initialCarNum = GameObject.FindGameObjectsWithTag("Car");
        carCount = initialCarNum.Length;
    }

    private void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            SpawnCar();
        }
    }

    public void SpawnCar()
    {
        Debug.Log("Start Spawn Car");
        carGenQueue++;
        if(!generatingCar)
        {
            StartCoroutine(GenerateCarWithDelay());
        }
    }

    public void DecreasedCar()
    {
        carCount--;
        if (carCount <= CarMaxNum)
        {
            SpawnCar();
        }
    }

    public IEnumerator GenerateCarWithDelay()
    {
        generatingCar = true;
        while(carGenQueue != 0)
        {
            if (canSpawn) // 3秒経過しているかどうかのチェック
            {
                canSpawn = false; // 生成処理開始時にフラグをオフにする
                yield return new WaitForSeconds(3f); // 3秒待つ
                carCount++;
                var newCar = Instantiate(cars[Random.Range(0, cars.Count)], carSpawnPoint, Quaternion.identity);
                var carPatrol = newCar.GetComponent<CarPatrol>();
                canSpawn = true; // 生成が完了したらフラグをオンにする
                carGenQueue--;
            }
        }
        generatingCar= false;
    }
}
