using UnityEngine;

public class RifleShootController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosititon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosititon.z = 0f;

            Vector3 directon = (mousePosititon - bulletSpawn.position).normalized;
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = directon * bulletSpeed;

            Destroy(bullet, 1f);
        }
    }

}
