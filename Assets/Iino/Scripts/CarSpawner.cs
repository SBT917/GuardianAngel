using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "CarData",menuName ="ScriptableObjects/CarData",order =1)]
public class CarData : ScriptableObject
{
    public GameObject CarPrefab;
    public float weight;
}



public class CarSpawner : Singleton<CarSpawner>
{
    [SerializeField]
    private List<CarData> cars;

    [SerializeField]
    private Vector3 carSpawnPoint;

    public Transform[] patrolPoint;

    [SerializeField]
    private int CarMaxNum;

    private int carGenQueue;

    public int carCount { get; private set; }

    private bool canSpawn = true; // �����\���ǂ����̃t���O

    private bool generatingCar;

    // Start is called before the first frame update
    void Start()
    {
        InitSpawnCar();
    }

    private void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            SpawnCar();
        }
    }

    private void InitSpawnCar()
    {
        carGenQueue = CarMaxNum;
        StartCoroutine(GenerateCarWithDelay());
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
            if (canSpawn) // 3�b�o�߂��Ă��邩�ǂ����̃`�F�b�N
            {
                canSpawn = false; // ���������J�n���Ƀt���O���I�t�ɂ���
                yield return new WaitForSeconds(3f); // 3�b�҂�
                carCount++;


                var newCar = Instantiate(SelectCar(), carSpawnPoint, Quaternion.identity);
                var carPatrol = newCar.GetComponent<CarPatrol>();
                canSpawn = true; // ����������������t���O���I���ɂ���
                carGenQueue--;
            }
        }
        generatingCar= false;
    }


    private GameObject SelectCar()
    {
        float totalWeight = 0;
        foreach (CarData carData in cars)
        {
            totalWeight += carData.weight;
        }

        float randomNum = Random.Range(0f, totalWeight);
        foreach (CarData carData in cars)
        {
            if (randomNum < carData.weight)
            {
                return carData.CarPrefab;
            }
            else
            {
                randomNum -= carData.weight;
            }
        }
        
        return cars[0].CarPrefab;
    }
}
