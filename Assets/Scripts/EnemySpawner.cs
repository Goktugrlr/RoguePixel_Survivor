using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject knightPrefab, wizardPrefab;
    public float spawnTime = 1;
    public float timer = 0;
    public WaveManager waveManager;
    private bool isSpawning = false;
    

    void Update()
    {
        if (isSpawning && timer > spawnTime)
        {
            GameObject enemyToSpawn = GetRandomEnemyPrefab();
            GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            timer = 0;
            waveManager.EnemySpawned();
        }

        timer += Time.deltaTime;
    }

    private GameObject GetRandomEnemyPrefab()
    {
        int randomIndex = Random.Range(0, 2); 
        GameObject[] enemyPrefabs = { knightPrefab, wizardPrefab};
        return enemyPrefabs[randomIndex];
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
