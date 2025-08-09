using UnityEngine;
using System.Diagnostics; // Add this for launching programs
using System.IO;

public class DeathHandler : MonoBehaviour
{
    public string undertalePath = @"D:\SteamLibary\steamapps\common\Undertale\UDERTALE.EXE";

    public void OnPlayerDeath()
    {
        // First check if Undertale executable exists
        if (File.Exists(undertalePath))
        {
            // Launch Undertale
            Process.Start(undertalePath);
        }
        else
        {
            UnityEngine.Debug.LogError("Undertale not found at: " + undertalePath);
        }

        // Quit the game
        Application.Quit();

        // For editor testing only (optional)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}