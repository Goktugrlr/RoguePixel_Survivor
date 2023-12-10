using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private WaveManager waveManager;
    public int damage = 25;

    void Start()
    {
        waveManager = GameObject.FindAnyObjectByType<WaveManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();

            if(enemyMovement != null)
            {
                enemyMovement.TakeDamage(damage);
                Destroy(gameObject);
                if (enemyMovement.GetCurrentHealth() <= 0) 
                {
                    waveManager.EnemyDefeated();
                }
               
            }
        }
    }
}
