using UnityEngine;
public class WeaponMovement : MonoBehaviour
{
    private Transform weaponTransform;
    private Vector3 mousePosition;
    public float rotationSpeed = 100f;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private void Start()
    {
        weaponTransform = this.transform;
    }

    private void Update()
    {
        aiming();
        shooting();
    }

    private void aiming() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (mousePosition.x < weaponTransform.position.y)
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotz);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, rotz);
        }
    }

    private void shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 direction = (mousePosition - bulletSpawn.position).normalized;

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            Destroy(bullet, 1f);
        }
    }

}