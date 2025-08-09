using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light2D;           // Assign in Inspector
    public float minIntensity = 0.1f; // Lowest brightness
    public float maxIntensity = 0.5f; // Highest brightness
    public float flickerSpeed = 0.05f; // Time between flickers

    private void Start()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        InvokeRepeating(nameof(Flicker), 0f, flickerSpeed);
    }

    void Flicker()
    {
        light2D.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
