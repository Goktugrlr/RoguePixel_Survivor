using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public WaveManager waveManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {   
            Destroy(other.gameObject);
            Destroy(gameObject);
            waveManager.EnemyDefeated();
        }
    }
}
