using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public Transform playerTransform; // プレイヤーのTransform
    private NavMeshAgent agent; // NavMeshAgentコンポーネント

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // プレイヤーの位置を目標として設定
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}

