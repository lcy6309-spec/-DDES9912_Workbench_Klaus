using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialogue(string text)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = text;
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
