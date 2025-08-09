using UnityEngine;

public class PickupFlashlight : MonoBehaviour
{
    private bool playerInRange = false;
    private GameObject player;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TopDownPlayerMovement movement = player.GetComponent<TopDownPlayerMovement>();
            if (movement != null)
            {
                movement.EnableFlashlight();       // Kích hoạt flashlight
                Destroy(gameObject);              // Xoá flashlight trên bàn
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }
}
