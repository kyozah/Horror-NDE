using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Set this to the name or index of the scene you want to load
    public string sceneToLoad = "GameScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
