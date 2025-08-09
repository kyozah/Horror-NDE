using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager dialogManager;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            dialogManager.StartDialog();
        }
    }
}
