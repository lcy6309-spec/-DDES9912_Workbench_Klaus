using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PatrolPingPong_StopEnds : MonoBehaviour
{
    public Transform[] points;        
    public float stopTimeAtEnds = 2f; 

    private int index = 0;
    private int direction = 1;
    private NavMeshAgent agent;
    private bool isWaiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = points[index].position; 
    }

    void Update()
    {
        if (isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            StartCoroutine(OnReachPoint());
        }
    }

    IEnumerator OnReachPoint()
    {
        isWaiting = true;

        if (index == points.Length - 1)
        {
            yield return new WaitForSeconds(stopTimeAtEnds);
            direction = -1;
        }
        else if (index == 0)
        {
            yield return new WaitForSeconds(stopTimeAtEnds);
            direction = 1;
        }

        index += direction;
        agent.destination = points[index].position;

        isWaiting = false;
    }
}
