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

        // �ŏ��̒Ǐ]�Ώۂ�ݒ�
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

        // �Ǐ]�Ώۂ̈ʒu��ݒ�
        if (navMeshAgent.remainingDistance < 0.1f)
        {

            // �^�[�Q�b�g�ɓ��B������V�����^�[�Q�b�g������
            FindNewTarget();
        }
    }

    void FindNewTarget()
    {
        // CarHuman�I�u�W�F�N�g���������A�����_���Ɉ�I��
        GameObject[] carHumans = GameObject.FindGameObjectsWithTag("CarHuman");
        if (carHumans.Length > 0)
        {
            targetCarHuman = carHumans[Random.Range(0, carHumans.Length)];
            navMeshAgent.SetDestination(targetCarHuman.transform.position);
        }
    }
}
