using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static string sceneToLoad;  // lưu tên scene cần chuyển đến

    public void LoadSceneWithLoading(string targetScene)
    {
        sceneToLoad = targetScene;
        SceneManager.LoadScene("LoadingScene"); // chuyển sang scene loading
    }
}
