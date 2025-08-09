using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JumpscareManager : MonoBehaviour
{
    public static JumpscareManager Instance;

    public GameObject jumpscarePanel;
    public AudioSource screamAudio;
    public Animator cameraAnimator;
    public float delayBeforeGameOver = 2f;

    void Awake()
    {
        Instance = this;
    }

    public void ShowJumpscare()
    {
        jumpscarePanel.SetActive(true);             // Hiện UI ảnh ma
        screamAudio.Play();                         // Phát tiếng hét
        cameraAnimator.SetTrigger("ShakeZoom");     // Camera zoom + shake
        Invoke(nameof(ShowGameOver), delayBeforeGameOver);
    }

    void ShowGameOver()
    {
        // Ẩn jumpscare, hiện màn hình Game Over
        // Có thể load lại scene hoặc hiện panel retry/quit
        SceneManager.LoadScene("GameOver");  // hoặc bật GameOverPanel
    }
}
