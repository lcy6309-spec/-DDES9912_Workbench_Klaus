using UnityEngine;
using TMPro;

public class TypewriterInput : MonoBehaviour
{
    public TMP_Text paperText;

    public int maxCharsPerLine = 7;   
    public int maxLines = 7;          

    private string currentText = "";

    public void OnKeyPressed(string keyValue)
    {
        if (paperText == null) return;

        int lineCount = currentText.Split('\n').Length;

        if (lineCount >= maxLines)
        {
            int lastLineStart = currentText.LastIndexOf('\n') + 1;
            int charsInCurrentLine = currentText.Length - lastLineStart;

            if (charsInCurrentLine >= maxCharsPerLine)
                return;
        }

        currentText += keyValue;

        int newLastLineStart = currentText.LastIndexOf('\n') + 1;
        int newChars = currentText.Length - newLastLineStart;

        if (newChars >= maxCharsPerLine && lineCount < maxLines)
        {
            currentText += "\n";
        }

        paperText.text = currentText;
    }
}
