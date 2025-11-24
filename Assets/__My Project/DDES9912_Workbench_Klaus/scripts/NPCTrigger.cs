using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private NPCDialogue dialogue;

    private void Start()
    {
        dialogue = GetComponent<NPCDialogue>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.Talk();
        }
    }
}
