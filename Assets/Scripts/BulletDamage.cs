using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 25;

    void Start()
    {
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
               
            }
        }
    }
}
