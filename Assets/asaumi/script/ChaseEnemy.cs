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
        // �ŏ��̒Ǐ]�Ώۂ�ݒ�
        FindNewTarget();
    }

    void Update()
    {

        //Debug.Log(navMeshAgent.remainingDistance);
        if (targetCarHuman != null)
        {
            navMeshAgent.SetDestination(targetCarHuman.transform.position);


            // �Ǐ]�Ώۂ̈ʒu��ݒ�
            if (navMeshAgent.remainingDistance < 1.5f && !navMeshAgent.pathPending)
            {
                targetCarHuman.GetComponent<CarHuman>().Death();
                AudioManager.instance.PlaySE("Attack", transform.position);
                targetCarHuman = null;
                // �^�[�Q�b�g�ɓ��B������V�����^�[�Q�b�g������
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
        // CarHuman�I�u�W�F�N�g���������A�����_���Ɉ�I��
        GameObject[] carHumans = GameObject.FindGameObjectsWithTag("Human");
        if (carHumans.Length > 0)
        {
            targetCarHuman = carHumans[Random.Range(0, carHumans.Length)];
            navMeshAgent.SetDestination(targetCarHuman.transform.position);
        }
    }

}
