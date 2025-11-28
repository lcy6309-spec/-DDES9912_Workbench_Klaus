using UnityEngine;

public class TypewriterTrigger : MonoBehaviour
{
    [Header("References")]
    public Transform player;                     
    public TypewriterEffect typewriter;          
    public Animator rollerAnimator;              
    public string spinBoolName = "IsSpinning";   

    [Header("Trigger Settings")]
    public bool oneTime = true;                 
    public float triggerRadius = 3f;            

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered && oneTime) return;
        if (other.transform == player)
        {
            DoStart();
            if (oneTime) triggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player && !oneTime)
        {
            DoStop();
        }
    }

    void Update()
    {
        if (player != null && !triggered && !HasTriggerCollider())
        {
            float d = Vector3.Distance(player.position, transform.position);
            if (d <= triggerRadius)
            {
                DoStart();
                if (oneTime) triggered = true;
            }
            else if (!oneTime)
            {
                DoStop();
            }
        }
    }

    private void DoStart()
    {
        if (rollerAnimator != null && !string.IsNullOrEmpty(spinBoolName))
            rollerAnimator.SetBool(spinBoolName, true);

        // Start typing
        if (typewriter != null)
            typewriter.StartTyping();
    }

    private void DoStop()
    {
        if (rollerAnimator != null && !string.IsNullOrEmpty(spinBoolName))
            rollerAnimator.SetBool(spinBoolName, false);
    }

    bool HasTriggerCollider()
    {
        Collider col = GetComponent<Collider>();
        return col != null && col.isTrigger;
    }
}
