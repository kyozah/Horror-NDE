using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySFXOnTrigger : MonoBehaviour
{
    public AudioClip soundEffect; // Drag your SFX clip here in Inspector

    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
                hasPlayed = true;
            }
        }
    }
}
