using UnityEngine;

public class NPCAudioAndAnimation : MonoBehaviour
{
    public AudioSource audioSource;    
    public Animator animator;           
    public string animationName = "Wave"; 

    private bool hasTriggered = false;   

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (animator == null)
            animator = GetComponent<Animator>();
    }

 
    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player")) 
        {
            hasTriggered = true;       
            StartCoroutine(PlayAudioThenAnimation());
        }
    }

    private System.Collections.IEnumerator PlayAudioThenAnimation()
    {
        if (audioSource != null)
        {
            audioSource.Play();         
            yield return new WaitForSeconds(audioSource.clip.length); 
        }

        if (animator != null)
        {
            animator.Play(animationName, 0, 0f); 
        }
    }
}
