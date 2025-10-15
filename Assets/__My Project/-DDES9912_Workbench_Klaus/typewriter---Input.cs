using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypewriterInput : MonoBehaviour
{
    [Header("Text to display")]
    public TMP_Text paperText;

    [Header("Characters per line")]
    public int maxCharsPerLine = 7; 

    private string currentText = "";

    public void OnKeyPressed(string keyValue)
    {
        if (paperText == null)
        {
            Debug.LogWarning("Paper Text is not assigned!");
            return;
        }

        currentText += keyValue;

        int lastLineStart = currentText.LastIndexOf('\n') + 1;
        int charsInCurrentLine = currentText.Length - lastLineStart;

        if (charsInCurrentLine >= maxCharsPerLine)
        {
            currentText += "\n";
        }

        paperText.text = currentText;
    }
}