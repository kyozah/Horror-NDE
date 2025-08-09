using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager Instance;

    public Text memoryTextUI;                // UI để hiển thị ký ức (Text)
    public string[] memoryFragments;         // Danh sách các đoạn ký ức (string)

    public float displayDuration = 3f;       // Thời gian hiển thị mỗi ký ức

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowMemoryFragment(int index)
    {
        if (index < memoryFragments.Length && memoryTextUI != null)
        {
            memoryTextUI.text = memoryFragments[index];
            memoryTextUI.enabled = true;
            CancelInvoke(nameof(HideMemory));
            Invoke(nameof(HideMemory), displayDuration);
        }
    }

    private void HideMemory()
    {
        if (memoryTextUI != null)
            memoryTextUI.enabled = false;
    }
}
