using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float health = 100;
    private Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    public float moveSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
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
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
    }

    private void FixedUpdate()
    {
        TrackingMovement(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0;
            animator.SetBool("IsAttacking", true);
        }
    }

    public void AttackAnimationComplete()
    {
        animator.SetBool("IsAttacking", false);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 8;
        }

    } 
}
