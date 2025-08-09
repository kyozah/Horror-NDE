using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LightFlicker2D : MonoBehaviour
{
    public Light2D flickerLight;                 // Light2D trong phòng
    public int flickerCount = 5;                 // Số lần nhấp nháy
    public float flickerMinInterval = 0.05f;     // Thời gian nhấp nháy nhỏ nhất
    public float flickerMaxInterval = 0.2f;      // Thời gian nhấp nháy lớn nhất

    public AudioClip[] flickerSounds;            // Âm thanh flicker
    private AudioSource audioSource;

    private bool hasTriggered = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            PlayRandomFlickerSound();
            StartCoroutine(FlickerThenOn(other.gameObject));
        }
    }

    IEnumerator FlickerThenOn(GameObject player)
    {
        for (int i = 0; i < flickerCount; i++)
        {
            flickerLight.enabled = !flickerLight.enabled;
            yield return new WaitForSeconds(Random.Range(flickerMinInterval, flickerMaxInterval));
        }

        flickerLight.enabled = true;

        // 🔦 Bật Spot Light2D trong player (nếu có)
        Light2D playerSpotLight = player.GetComponentInChildren<Light2D>(true); // true = tìm cả object đang bị ẩn
        if (playerSpotLight != null)
        {
            playerSpotLight.enabled = true;
        }
        else
        {
            Debug.LogWarning("⚠️ Player không có Spot Light2D!");
        }
    }

    void PlayRandomFlickerSound()
    {
        if (flickerSounds.Length > 0)
        {
            AudioClip clip = flickerSounds[Random.Range(0, flickerSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
