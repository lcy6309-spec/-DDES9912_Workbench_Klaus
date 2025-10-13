using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypewriterInput : MonoBehaviour
{
    [Header("ÏÔÊ¾ÎÄ×ÖµÄ TextMeshPro (UI)")]
    public TMP_Text paperText; 

    private string currentText = "";

    public void OnKeyPressed(string keyValue)
    {
        if (paperText == null)
        {
            Debug.LogWarning("Paper Text is not assigned!");
            return;
        }

        currentText += keyValue;
        paperText.text = currentText;
    }
}