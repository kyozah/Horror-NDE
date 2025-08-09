using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip attackClip;
    public AudioClip hurtClip;
    public AudioClip walkClip;

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackClip);
    }

    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip);
    }

    public void PlayWalk()
    {
        audioSource.PlayOneShot(walkClip);
    }
}

