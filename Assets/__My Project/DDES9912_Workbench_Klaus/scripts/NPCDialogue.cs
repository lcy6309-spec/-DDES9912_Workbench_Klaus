using UnityEngine;
using UnityEngine.Events;

public class NPCDialogue : MonoBehaviour
{
    [TextArea]
    public string dialogueText;

    public UnityEvent OnTalk;

    public void Talk()
    {
        UIManager.Instance.ShowDialogue(dialogueText);
        OnTalk.Invoke();
    }
}
