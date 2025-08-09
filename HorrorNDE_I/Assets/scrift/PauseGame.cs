using UnityEngine;
using UnityEngine.SceneManagement; // <- Thêm dòng này

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;

    void Update()
    {
        // Nhấn ESC để tắt/bật pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;  // Dừng thời gian
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;  // Chạy lại thời gian
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Trả lại tốc độ thời gian nếu đang pause game
        SceneManager.LoadScene("Menu"); // Thay bằng tên scene menu chính xác của bạn
    }
}



