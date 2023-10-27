using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1;
    public float timer = 0;
    

    void Update()
    {
        if (timer > spawnTime)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(newEnemy, 10);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
