using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Nút chơi lại (load lại scene hiện tại)
    public void PlayAgain()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian không bị pause
        SceneManager.LoadScene("Day4");
    }

    // Nút thoát game (đóng game nếu build, dừng PlayMode nếu trong editor)
    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Dừng trong Editor
#else
        Application.Quit(); // Thoát game thật khi build
#endif
    }
}

