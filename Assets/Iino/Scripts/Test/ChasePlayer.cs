using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerTransform; // �v���C���[��Transform
    private NavMeshAgent agent; // NavMeshAgent�R���|�[�l���g

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // �v���C���[�̈ʒu��ڕW�Ƃ��Đݒ�
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}

