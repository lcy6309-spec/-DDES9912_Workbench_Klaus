using UnityEngine;

public class PaperMove : MonoBehaviour
{
    public Transform paper;     
    public float moveStep = 0.1f; 
    public float maxY = 2f;       

    void Update()
    {
        for (KeyCode key = KeyCode.A; key <= KeyCode.Z; key++)
        {
            if (Input.GetKeyDown(key))
            {
                MoveUp();
            }
        }
    }

    public void MoveUp()
    {
        if (paper == null) return;

        if (paper.position.y < maxY)
        {
            paper.position += new Vector3(0, moveStep, 0);

            if (paper.position.y > maxY)
            {
                Vector3 p = paper.position;
                p.y = maxY;
                paper.position = p;
            }
        }

    }
}