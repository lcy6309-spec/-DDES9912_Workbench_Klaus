using UnityEngine;

public class TypewriterWheel : MonoBehaviour
{
    public Transform wheel;

    public float speed = 100f;

    public float rotationAngle = 90f;


    public void OnKeyPressed()
    {

        wheel.Rotate(rotationAngle, 0f, 0f);
    }
}