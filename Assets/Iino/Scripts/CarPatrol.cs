using UnityEngine;
using UnityEngine.AI;

public class CarPatrol : MonoBehaviour
{
    public Transform[] points;
    public Vector3 initPoint;
    private int destPoint = 0;
    private NavMeshAgent agent;

    private int currentRoundsNum;
    private bool returnInitPoint;

    [SerializeField]
    private int maxRoundsNum;
    void Start()
    {
        if(initPoint == null)
        {
            initPoint = transform.position;
        }

        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        points = CarSpawner.instance.patrolPoint;
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
        agent.velocity = Vector3.zero;
        if (returnInitPoint) 
        { 
            Destroy(gameObject);
            return;
        }


        if(currentRoundsNum >= maxRoundsNum)
        {
            agent.destination = initPoint;
            returnInitPoint = true;
            return;
        }

        destPoint = Random.Range(0, points.Length -1);
        agent.destination = points[destPoint].position;
        currentRoundsNum++;
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
