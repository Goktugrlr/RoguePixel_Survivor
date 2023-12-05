using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1;
    public float timer = 0;
    public WaveManager waveManager;
    private bool isSpawning = false;
    

    void Update()
    {
        if (isSpawning && timer > spawnTime)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(newEnemy, 10);
            timer = 0;
            waveManager.EnemySpawned();
        }

        timer += Time.deltaTime;
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
