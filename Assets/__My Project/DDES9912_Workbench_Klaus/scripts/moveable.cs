using UnityEngine;

public class MouseGrab : MonoBehaviour
{
    public float grabDistance = 5f;     
    public float moveSpeed = 10f;      

    private GameObject grabbedObject;   
    private Rigidbody grabbedRigidbody;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            TryGrabObject();
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            ReleaseObject();
        }

        if (grabbedObject != null)
        {
            MoveObject();
        }
    }

    void TryGrabObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            if (hit.collider != null && hit.collider.attachedRigidbody != null)
            {
                grabbedObject = hit.collider.gameObject;
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
                grabbedRigidbody.useGravity = false;
                grabbedRigidbody.velocity = Vector3.zero;
            }
        }
    }

    void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPosition = ray.origin + ray.direction * grabDistance;

        grabbedRigidbody.position = Vector3.Lerp(grabbedRigidbody.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void ReleaseObject()
    {
        if (grabbedRigidbody != null)
        {
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody = null;
        }
        grabbedObject = null;
    }
}
