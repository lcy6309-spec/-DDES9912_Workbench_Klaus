using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCSequenceFlow : MonoBehaviour
{
    [Header("Movement Targets")]
    public Transform pointA;   
    public Transform pointB;   

    [Header("Audio Clips (Only Sounds)")]
    public AudioClip audioAtA; 
    public AudioClip audioAtB; 

    private NavMeshAgent agent;
    private AudioSource audioSource;

    private bool started = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void StartSequence()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Points are not assigned!");
            return;
        }

        if (audioAtA == null || audioAtB == null)
        {
            Debug.LogWarning("Audio clips are missing!");
        }

        if (!started)
        {
            started = true;
            StartCoroutine(SequenceCoroutine());
        }
    }

    private IEnumerator SequenceCoroutine()
    {
        agent.SetDestination(pointA.position);
        while (!HasArrived(pointA))
            yield return null;

        agent.isStopped = true;

        if (audioAtA != null && audioAtA.length > 0f)
        {
            audioSource.clip = audioAtA;
            audioSource.Play();
            yield return new WaitForSeconds(audioAtA.length);
        }

        agent.isStopped = false;
        agent.SetDestination(pointB.position);
        while (!HasArrived(pointB))
            yield return null;

        agent.isStopped = true;

        if (audioAtB != null && audioAtB.length > 0f)
        {
            audioSource.clip = audioAtB;
            audioSource.Play();
            yield return new WaitForSeconds(audioAtB.length);
        }

        Debug.Log("NPC sequence complete.");
    }
    private bool HasArrived(Transform target)
    {
        if (agent.pathPending) return false;
        if (agent.remainingDistance > agent.stoppingDistance) return false;
        if (agent.velocity.sqrMagnitude > 0.01f) return false;
        return true;
    }
}
