using UnityEngine;
using System.Diagnostics;
using System.IO;

public class BeamDamage : MonoBehaviour
{
    public string undertalePath = @"D:\SteamLibrary\steamapps\common\Undertale\UNDERTALE.exe";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KillPlayer(); // Run death logic
            Destroy(other.gameObject); // Then destroy the player
        }
    }

    void KillPlayer()
    {
        UnityEngine.Debug.Log("Player died by beam!");

        if (File.Exists(undertalePath))
        {
            Process.Start(undertalePath);
            UnityEngine.Debug.Log("Launched Undertale!");
        }
        else
        {
            UnityEngine.Debug.LogError("Undertale not found at: " + undertalePath);
        }

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
