using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle; Bunlar sonra düþünülebilir

        direction.Normalize();  //vektörün length'ini 1 yapýyor ve böylece ýþýnlanmayý önlüyor (adým adým)
        movement = direction;
    }

    void TrackingMovement(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        TrackingMovement(movement);
    }
}
