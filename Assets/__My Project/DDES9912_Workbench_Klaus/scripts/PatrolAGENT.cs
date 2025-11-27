using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAgent : MonoBehaviour
{
    public Transform[] patrolPoints; 
    private int currentIndex = 0;   
    private int direction = 1;       
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestinationToCurrent();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(WaitAndGoNext());
        }
    }

    IEnumerator WaitAndGoNext()
    {
        yield return new WaitForSeconds(1f);


        if (currentIndex == 0)
            direction = 1;
        else if (currentIndex == patrolPoints.Length - 1)
            direction = -1;

        currentIndex += direction;

        SetDestinationToCurrent();
    }

    void SetDestinationToCurrent()
    {
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentIndex].position);
        }
    }
}
