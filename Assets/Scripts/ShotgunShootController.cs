using UnityEngine;

public class ShotgunShootController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;

    public int bulletDamage = 35;
    private float lastFireTime;
    public float fireRate = 1f;


    public AudioSource shotgunAudioSource;

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if(player.GetComponent<CharacterMovement>().GetIsDead()==false)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if (Input.GetMouseButton(0) && Time.time - lastFireTime >= 1f / fireRate)
        {
            Vector3[] directions = { bulletSpawn.right, (Quaternion.Euler(0, 0, -10f) * bulletSpawn.right), (Quaternion.Euler(0, 0, 10f) * bulletSpawn.right) };

            shotgunAudioSource.Play();

            for (int i = 0; i < directions.Length; i++)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<BulletDamage>().damage = bulletDamage; 
                bullet.GetComponent<Rigidbody2D>().velocity = directions[i].normalized * bulletSpeed;

                Destroy(bullet, 0.5f);
            }

            lastFireTime = Time.time - 0.5f;
        }
    }
}
