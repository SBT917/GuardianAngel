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
        points = CarManager.instance.patrolPoint;
        // NavMeshレイヤーマスクを設定
        SetLayerMaskForAgent();
        GotoNextPoint();
    }

    void SetLayerMaskForAgent()
    {
        int layerMask = 1 << NavMesh.GetAreaFromName("Roads");
        agent.areaMask = layerMask;
    }

    public void GotoNextPoint()
    {
        destPoint = Random.Range(0, points.Length -1);
        agent.destination = points[destPoint].position;
    }

    public void Invalid()
    {
        Debug.Log("Invalid");
        agent.enabled = false;
        this.enabled = false;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}
