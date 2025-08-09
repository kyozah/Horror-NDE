using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    private bool isChasing = false;

    void Update()
    {
        if (isChasing && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }

    public void StartChasing()
    {
        isChasing = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (JumpscareManager.Instance != null)
            {
                JumpscareManager.Instance.ShowJumpscare();
            }
        }
    }
}



