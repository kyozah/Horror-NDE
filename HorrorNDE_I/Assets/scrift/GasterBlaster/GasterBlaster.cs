using UnityEngine;
using System.Collections;

public class GasterBlaster : MonoBehaviour
{
    public GameObject beamPreview;           // Vệt đỏ cảnh báo
    public GameObject beamReal;              // Beam thật

    public AudioSource audioSource;          // Nhạc beat đang phát
    public AudioClip chargeAndFireClip;      // Âm thanh charge & bắn

    public float warningTime = 0.5f;         // Thời gian cảnh báo
    public float fireDuration = 0.3f;        // Thời gian tồn tại beam

    [Header("Beat Config")]
    public int beatCount = 120;              // Tổng số beam
    public float startTime = 2f;             // Giây bắt đầu
    public float initialInterval = 2.5f;     // Khoảng cách ban đầu
    public float intervalDecrease = 0.02f;   // Mỗi beat sẽ nhanh dần
    public float minInterval = 0.5f;         // Tốc độ tối đa

    private float[] beatTimes;               // Danh sách mốc beat tự tạo
    private int beatIndex = 0;

    void Start()
    {
        GenerateBeatTimes();
        if (audioSource) audioSource.Play(); // Phát nhạc nếu có
    }

    void Update()
    {
        if (beatIndex < beatTimes.Length && audioSource.time >= beatTimes[beatIndex])
        {
            StartCoroutine(ShowBeamWithWarning());
            beatIndex++;
        }
    }

    void GenerateBeatTimes()
    {
        beatTimes = new float[beatCount];
        float currentTime = startTime;
        float interval = initialInterval;

        for (int i = 0; i < beatCount; i++)
        {
            beatTimes[i] = currentTime;
            currentTime += interval;
            interval = Mathf.Max(minInterval, interval - intervalDecrease); // Giảm dần, không thấp hơn min
        }
    }

    IEnumerator ShowBeamWithWarning()
    {
        // 1. Hiện cảnh báo beam
        if (beamPreview) beamPreview.SetActive(true);

        // 2. Phát âm thanh charge & bắn
        if (audioSource && chargeAndFireClip)
            audioSource.PlayOneShot(chargeAndFireClip);

        // 3. Đợi cảnh báo
        yield return new WaitForSeconds(warningTime);

        // 4. Bật beam thật
        if (beamPreview) beamPreview.SetActive(false);
        if (beamReal) beamReal.SetActive(true);

        // 5. Ký ức (nếu dùng)
        if (MemoryManager.Instance != null)
            MemoryManager.Instance.ShowMemoryFragment(beatIndex);

        // 6. Tắt beam sau khi bắn
        yield return new WaitForSeconds(fireDuration);
        if (beamReal) beamReal.SetActive(false);
    }
}
