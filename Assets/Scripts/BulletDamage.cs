using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
