using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyC : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    GameObject targetCarHuman;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 最初の追従対象を設定
        FindNewTarget();
    }

    void Update()
    {
        if(targetCarHuman != null)
        {
            navMeshAgent.SetDestination(targetCarHuman.transform.position);
        }
        else
        {
            FindNewTarget();
        }

        // 追従対象の位置を設定
        if (navMeshAgent.remainingDistance < 0.1f)
        {

            // ターゲットに到達したら新しいターゲットを検索
            FindNewTarget();
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
}
