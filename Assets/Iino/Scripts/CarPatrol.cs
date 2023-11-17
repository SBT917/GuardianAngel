using UnityEngine;
using UnityEngine.AI;

public class CarPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        // NavMesh���C���[�}�X�N��ݒ�
        SetLayerMaskForAgent();

        GotoNextPoint();
    }

    void SetLayerMaskForAgent()
    {
        int layerMask = 1 << NavMesh.GetAreaFromName("Roads");
        agent.areaMask = layerMask;
    }

    void GotoNextPoint()
    {
        destPoint = Random.Range(0, points.Length -1);
        agent.destination = points[destPoint].position;

    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
