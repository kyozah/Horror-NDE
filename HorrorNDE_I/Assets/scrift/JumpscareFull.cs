using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class JumpscareFull : MonoBehaviour
{
    [Header("Jumpscare Elements")]
    public GameObject jumpscareImage;
    public AudioClip jumpscareSound;
    public float scareDuration = 2f;

    [Header("Camera Shake")]
    public Camera mainCamera;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    [Header("Music Control")]
    public AudioSource backgroundMusic;

    [Header("Light Flicker")]
    public Light2D flickerLight;
    public int flickerCount = 8;
    public float flickerMinInterval = 0.05f;
    public float flickerMaxInterval = 0.15f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerJumpscare();
        }
    }

    void TriggerJumpscare()
    {
        // Hiện hình ảnh jumpscare
        if (jumpscareImage != null)
            jumpscareImage.SetActive(true);

        // Phát âm thanh jumpscare
        if (jumpscareSound != null)
        {
            audioSource.clip = jumpscareSound;
            audioSource.Play();
        }

        // Tắt nhạc nền
        if (backgroundMusic != null && backgroundMusic.isPlaying)
            backgroundMusic.Stop();

        // Lắc camera
        if (mainCamera != null)
            StartCoroutine(ShakeCamera());

        // Nhấp nháy đèn
        if (flickerLight != null)
            StartCoroutine(FlickerLight());

        // Kết thúc jumpscare
        Invoke("HideJumpscare", scareDuration);
    }

    void HideJumpscare()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);

        // Xóa trigger nếu chỉ sử dụng 1 lần
        Destroy(gameObject);
    }

    IEnumerator ShakeCamera()
    {
        Vector3 originalPos = mainCamera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            mainCamera.transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }

    IEnumerator FlickerLight()
    {
        for (int i = 0; i < flickerCount; i++)
        {
            flickerLight.enabled = !flickerLight.enabled;
            yield return new WaitForSeconds(Random.Range(flickerMinInterval, flickerMaxInterval));
        }

        flickerLight.enabled = true;
    }
}

