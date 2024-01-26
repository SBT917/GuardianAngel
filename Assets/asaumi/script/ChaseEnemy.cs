using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    GameObject targetCarHuman;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetCarHuman = null;
        // 最初の追従対象を設定
        FindNewTarget();
    }

    void Update()
    {

        //Debug.Log(navMeshAgent.remainingDistance);
        if (targetCarHuman != null)
        {
            navMeshAgent.SetDestination(targetCarHuman.transform.position);


            // 追従対象の位置を設定
            if (navMeshAgent.remainingDistance < 1.5f && !navMeshAgent.pathPending)
            {
                targetCarHuman.GetComponent<CarHuman>().Death();
                AudioManager.instance.PlaySE("Attack", transform.position);
                targetCarHuman = null;
                // ターゲットに到達したら新しいターゲットを検索
                FindNewTarget();
            }
        }

        if(targetCarHuman == null)
        {
            FindNewTarget();
        }
    }

    void FindNewTarget()
    {
        // CarHumanオブジェクトを検索し、ランダムに一つ選択
        GameObject[] carHumans = GameObject.FindGameObjectsWithTag("Human");
        if (carHumans.Length > 0)
        {
            targetCarHuman = carHumans[Random.Range(0, carHumans.Length)];
            navMeshAgent.SetDestination(targetCarHuman.transform.position);
        }
    }

}
