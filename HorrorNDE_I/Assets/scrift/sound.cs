using UnityEngine;

public class PlayerFootstepAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public float stepInterval = 0.4f; // thời gian giữa các bước chân

    private float stepTimer = 0f;
    private bool isWalking = false;

    void Update()
    {
        HandleFootstepSound();
    }

    void HandleFootstepSound()
    {
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                        Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W);

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayRandomFootstep();
                stepTimer = stepInterval;
            }

            isWalking = true;
        }
        else
        {
            if (isWalking)
            {
                StopFootstepSound();
                isWalking = false;
            }
        }
    }

    void PlayRandomFootstep()
    {
        if (footstepClips.Length == 0 || footstepSource == null) return;

        int index = Random.Range(0, footstepClips.Length);
        footstepSource.clip = footstepClips[index];
        footstepSource.Play();
    }

    void StopFootstepSound()
    {
        if (footstepSource != null && footstepSource.isPlaying)
        {
            footstepSource.Stop();
        }
    }
}


