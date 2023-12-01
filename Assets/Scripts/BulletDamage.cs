using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {   
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
