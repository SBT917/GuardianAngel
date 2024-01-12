using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyC : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    GameObject targetCarHuman;
    bool deathCheck;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        deathCheck = false;
        // 最初の追従対象を設定
        FindNewTarget();
    }

    void Update()
    {
        if (targetCarHuman != null)
        {
            navMeshAgent.SetDestination(targetCarHuman.transform.position);


            // 追従対象の位置を設定
            if (navMeshAgent.remainingDistance < 1.5f&&deathCheck==false)
            {
                //targetCarHuman.GetComponent<CarHuman>().Death();
                targetCarHuman.GetComponent<CarHuman>().ChangeZombie();
                targetCarHuman = null;
                // ターゲットに到達したら新しいターゲットを検索
                FindNewTarget();
                Debug.Log("キルしました");
                deathCheck = true;
            }
        }
        else
        {
            FindNewTarget();
            return;
        }
        if (deathCheck)
        {
            SetFalseAfterDelay(deathCheck, 3);
        }
    }

    void FindNewTarget()
    {
        // CarHumanオブジェクトを検索し、ランダムに一つ選択
        GameObject[] carHumans = GameObject.FindGameObjectsWithTag("CarHuman");
        if (carHumans.Length > 0)
        {
            targetCarHuman = carHumans[Random.Range(0, carHumans.Length)];
            navMeshAgent.SetDestination(targetCarHuman.transform.position);
        }
    }
    static void SetFalseAfterDelay(bool varriableToSet, int seconds)
    {
        varriableToSet = false;
    }
}
