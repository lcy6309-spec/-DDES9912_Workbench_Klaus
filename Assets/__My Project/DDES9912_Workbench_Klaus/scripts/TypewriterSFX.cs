using UnityEngine;

public class TypewriterSFX : MonoBehaviour
{
    public AudioSource sfxAudio;  
    public AudioClip typeClip;    


    public void PlayTypeSound()
    {
        sfxAudio.PlayOneShot(typeClip); 
    }
}
