using UnityEngine;

public class ShotgunShootController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;


    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    private void Shooting() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3[] directions = { bulletSpawn.right, (Quaternion.Euler(0, 0, -10f) * bulletSpawn.right), (Quaternion.Euler(0, 0, 10f) * bulletSpawn.right) };

            for (int i = 0;i < directions.Length; i++) 
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = directions[i].normalized*bulletSpeed;

                Destroy(bullet, 0.5f);
            }
        }
    }
}
