using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerFlashlight : MonoBehaviour
{
    public Light2D flashlight; // Gán Spot Light2D của Player
    private bool canUseFlashlight = false;
    private bool flashlightOn = false;

    void Update()
    {
        if (canUseFlashlight && Input.GetKeyDown(KeyCode.F))
        {
            flashlightOn = !flashlightOn;
            flashlight.enabled = flashlightOn;
        }
    }

    public void EnableFlashlightControl()
    {
        canUseFlashlight = true;
        flashlight.enabled = false; // Bắt đầu chưa bật
    }
}