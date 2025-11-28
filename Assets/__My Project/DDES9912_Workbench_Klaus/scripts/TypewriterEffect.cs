using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textMesh;
    [TextArea] public string fullText;
    public float typingSpeed = 0.05f;
    public bool clearOnStart = true;

    [Header("Character & Line Limits")]
    public int maxCharsPerLine = 15;   
    public int maxLines = 7;           

    // Events
    public UnityEvent onTypingStart;
    public UnityEvent onTypingComplete;

    private Coroutine typingCoroutine;

    void Reset()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Awake()
    {
        if (textMesh == null)
            textMesh = GetComponent<TMP_Text>();
    }

    void Start()
    {
        if (string.IsNullOrEmpty(fullText))
            fullText = textMesh.text;

        if (clearOnStart)
            textMesh.text = "";
    }

    public void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypingCoroutine());
    }

    public void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }

    IEnumerator TypingCoroutine()
    {
        onTypingStart?.Invoke();

        textMesh.text = "";

        int charCountInLine = 0;
        int lineCount = 1;

        foreach (char c in fullText)
        {
            if (lineCount > maxLines)
            {
                break;
            }

            if (charCountInLine >= maxCharsPerLine)
            {
                textMesh.text += "\n";
                lineCount++;
                charCountInLine = 0;

                if (lineCount > maxLines)
                    break;
            }

            textMesh.text += c;
            charCountInLine++;

            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
        onTypingComplete?.Invoke();
    }
}
