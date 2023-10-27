using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    public Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player"); 
            player = playerObject.transform;
        }

        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
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
