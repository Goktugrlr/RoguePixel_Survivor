using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public float waveDuration = 30.0f;
    private float waveTimer;
    private int waveNumber = 0;
    private bool waveInProgress = false;
    private int killCount = 0;
    public List<EnemySpawner> enemySpawners;
    private List<EnemySpawner> activeSpawners = new List<EnemySpawner>(); 
    private int activeEnemies = 0;
    public TMP_Text waveOverText;   
    public TMP_Text waveDurationText;
    public TMP_Text waveNumberText;
    public TMP_Text totalKillCountText;
    public Button restartButton;
    public Button menuButton;
    public Button continueButton;
    public AugmentManager augmentManager;
    private bool waveEndStarted = false;

    void Start()
    {
        continueButton.onClick.AddListener(OnNextWaveButtonClicked);
        StartWave();
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<CharacterMovement>().GetHealth() <= 0)
        {
            
            HandlePlayerDeath();
        }


        if (!waveInProgress && player.GetComponent<CharacterMovement>().GetIsDead()==false && !waveEndStarted)
        {            
            waveEndStarted = true;
            augmentManager.EndWave();
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
                DestroyAllHealthPotions();
                waveInProgress = false;
            }

        }
        
        totalKillCountText.text = "Total Kills: " + killCount;
    }

    public void StartWave()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterMovement>().SetHealth(player.GetComponent<CharacterMovement>().maxHealth);

        waveEndStarted = false;
        waveInProgress = true;
        waveTimer = waveDuration;
        waveNumber++;
        waveDuration +=10;
        waveNumberText.text = "Wave: " + waveNumber;
        continueButton.gameObject.SetActive(false);
        waveOverText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartSpawningEnemies();
    }

    private void RandomizeSpawners()
    {
        for (int i = 0; i < enemySpawners.Count; i++)
        {
            EnemySpawner temp = enemySpawners[i];
            int randomIndex = Random.Range(i, enemySpawners.Count);
            enemySpawners[i] = enemySpawners[randomIndex];
            enemySpawners[randomIndex] = temp;
        }
    }

    public void StartSpawningEnemies()
    {
        activeSpawners.Clear();
        RandomizeSpawners();

        int spawnerCountToActivate = 3;
        for (int i = 0; i < spawnerCountToActivate; i++)
        {
            enemySpawners[i].StartSpawning();
            activeSpawners.Add(enemySpawners[i]);
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

    private void DestroyAllHealthPotions()
    {
        GameObject[] healthPotions = GameObject.FindGameObjectsWithTag("HealthPotion");
        foreach(GameObject healthPotion in healthPotions)
        {
            Destroy(healthPotion);
        }
    }

    private void showWaveOverMenu()
    {
        
        waveOverText.text = "Wave " + waveNumber + " Completed!";
        continueButton.gameObject.SetActive(true);
        waveOverText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    public void HandlePlayerDeath()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterMovement>().SetIsDead(true);
        DestroyAllEnemies();
        waveOverText.text = "You Died!";
        waveOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        waveInProgress = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
