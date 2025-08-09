using UnityEngine;
using System.Collections;

public class BeamBeatManager : MonoBehaviour
{
    public GameObject beamPrefab;
    public Transform[] spawnPoints;
    public AudioSource musicSource;

    public AudioClip beamSFX;
    public float warningTime = 0.5f;
    public float fireDuration = 0.3f;

    private int beatIndex = 0;
    private double songStartDSPTime;

    private float[] beatTimes = new float[] {
        12.85f, 13.95f, 14.60f, 15.20f, 15.85f, 16.45f, 16.95f, 17.85f, 18.65f, 20.30f,
        20.85f, 21.15f, 21.95f, 22.90f, 23.15f, 24.20f, 24.55f, 26.15f, 26.45f, 27.00f,
        28.60f, 29.25f, 30.40f, 30.85f, 31.15f, 31.50f, 32.00f, 32.60f, 35.10f, 35.50f,
        35.80f, 36.15f, 36.85f, 37.85f, 38.10f, 39.50f, 42.00f, 42.50f, 42.85f, 43.40f,
        43.70f, 44.25f, 44.60f, 45.95f, 46.25f, 46.75f, 47.20f, 47.55f, 47.90f, 48.30f,
        49.20f, 49.55f, 50.30f, 50.80f, 51.25f, 52.25f, 52.55f, 52.90f, 54.85f, 57.75f,
        58.75f, 59.15f, 60.15f, 60.45f, 61.20f, 62.00f, 65.25f, 65.60f, 65.85f, 66.25f,
        67.00f, 67.40f, 67.85f, 68.45f, 69.60f, 72.65f, 72.95f, 73.65f, 74.65f, 75.80f,
        76.35f, 76.85f, 77.15f, 77.60f, 77.95f, 79.00f, 79.30f, 79.60f, 80.05f, 81.30f,
        83.00f, 83.80f, 84.60f, 85.35f, 85.95f, 86.30f, 86.75f, 88.05f, 88.70f, 89.65f
    };

    void Start()
    {
        songStartDSPTime = AudioSettings.dspTime + 0.2f; // Cho chuẩn hóa khởi động
        musicSource.PlayScheduled(songStartDSPTime);
    }

    void Update()
    {
        double elapsedTime = AudioSettings.dspTime - songStartDSPTime;

        if (beatIndex < beatTimes.Length && elapsedTime >= beatTimes[beatIndex])
        {
            StartCoroutine(SpawnBeam());
            beatIndex++;
        }
    }

    IEnumerator SpawnBeam()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject beam = Instantiate(beamPrefab, spawnPoint.position, spawnPoint.rotation);

        GameObject warning = beam.transform.Find("BeamPreview")?.gameObject;
        GameObject realBeam = beam.transform.Find("BeamReal")?.gameObject;

        if (warning) warning.SetActive(true);
        if (beamSFX) musicSource.PlayOneShot(beamSFX);

        yield return new WaitForSeconds(warningTime);

        if (warning) warning.SetActive(false);
        if (realBeam) realBeam.SetActive(true);

        yield return new WaitForSeconds(fireDuration);

        Destroy(beam);
    }
}
