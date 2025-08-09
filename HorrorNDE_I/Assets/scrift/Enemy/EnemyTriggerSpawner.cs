using UnityEngine;

public class EnemyTriggerSpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetActive(true); // hiện quái vật
            enemy.GetComponent<EnemyChase>().StartChasing();
            enemy1.SetActive(true); // hiện quái vật
            enemy1.GetComponent<EnemyChase>().StartChasing();
            enemy2.SetActive(true); // hiện quái vật
            enemy2.GetComponent<EnemyChase>().StartChasing();
            enemy3.SetActive(true); // hiện quái vật
            enemy3.GetComponent<EnemyChase>().StartChasing();
            enemy4.SetActive(true); // hiện quái vật
            enemy4.GetComponent<EnemyChase>().StartChasing();
            enemy5.SetActive(true); // hiện quái vật
            enemy5.GetComponent<EnemyChase>().StartChasing();
        }
    }
}
