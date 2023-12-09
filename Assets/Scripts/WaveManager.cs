using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public float waveDuration = 10.0f;
    private float waveTimer;
    private int waveNumber = 1;
    private bool waveInProgress = false;
    private int killCount = 0;
    public List<EnemySpawner> enemySpawners;
    private int activeEnemies = 0;
    public TMP_Text waveOverText;   
    public Button nextWaveButton;
    public TMP_Text waveDurationText;
    public TMP_Text waveNumberText;
    public TMP_Text totalKillCountText;

    // Start is called before the first frame update
    void Start()
    {
        nextWaveButton.onClick.AddListener(OnNextWaveButtonClicked);
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(!waveInProgress)
        {
            
            showWaveOverMenu();
        }
        if(waveInProgress)
        {
            waveTimer -= Time.deltaTime;
            waveDurationText.text = "Remaining Time: " + waveTimer.ToString("F1");
            if(waveTimer <= 0)
            {
                Debug.Log("Wave Over");
                StopSpawningEnemies();
                DestroyAllEnemies();
                waveInProgress = false;
            }

        }
        
        totalKillCountText.text = "Total Kills: " + killCount;
    }

    public void StartWave()
    {
        waveInProgress = true;
        waveTimer = waveDuration;
        waveNumberText.text = "Wave: " + waveNumber;
        nextWaveButton.gameObject.SetActive(false);
        waveOverText.gameObject.SetActive(false);
        StartSpawningEnemies();
    }

    public void StartSpawningEnemies()
    {
        foreach(var spawner in enemySpawners)
        {
            spawner.StartSpawning();
            
        }
    }

    private void StopSpawningEnemies()
    {
        foreach(var spawner in enemySpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void OnNextWaveButtonClicked()
    {
        if(!waveInProgress)
        {
            waveNumber++;
            StartWave();
        }
    }

    public void EnemyDefeated()
    {
        killCount++;
        activeEnemies--;
        
    }

    public void EnemySpawned()
    {
        activeEnemies++;
        
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private void showWaveOverMenu()
    {
        waveOverText.text = "Wave " + waveNumber + " Complete!";
        nextWaveButton.gameObject.SetActive(true);
        waveOverText.gameObject.SetActive(true);
    }

}
