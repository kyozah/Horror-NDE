using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public PuzzleGuessNumber puzzle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzle.ShowPanel();
        }
    }
}

