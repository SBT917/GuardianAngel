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
        // �ŏ��̒Ǐ]�Ώۂ�ݒ�
        FindNewTarget();
    }

    void Update()
    {
        if (targetCarHuman != null)
        {
            navMeshAgent.SetDestination(targetCarHuman.transform.position);


            // �Ǐ]�Ώۂ̈ʒu��ݒ�
            if (navMeshAgent.remainingDistance < 1.5f&&deathCheck==false)
            {
                //targetCarHuman.GetComponent<CarHuman>().Death();
                targetCarHuman.GetComponent<CarHuman>().ChangeZombie();
                targetCarHuman = null;
                // �^�[�Q�b�g�ɓ��B������V�����^�[�Q�b�g������
                FindNewTarget();
                Debug.Log("�L�����܂���");
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
        // CarHuman�I�u�W�F�N�g���������A�����_���Ɉ�I��
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
