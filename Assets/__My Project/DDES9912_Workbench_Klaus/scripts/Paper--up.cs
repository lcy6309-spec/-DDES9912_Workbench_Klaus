using UnityEngine;

public class PaperMove : MonoBehaviour
{
    public Transform paper;
    public float moveStep = 0.1f;
    public float maxY = 2f;

    private int count = 0; 

    public void OnKeyPressed()
    {
        count++;

        if (count >= 10)
        {
            count = 0;
            MoveUp();
        }
    }

    void MoveUp()
    {
        if (paper == null) return;

        Vector3 pos = paper.position;
        pos.y = Mathf.Min(pos.y + moveStep, maxY);
        paper.position = pos;
    }
}