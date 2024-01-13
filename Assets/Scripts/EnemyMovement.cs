using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float health = 100;
    private float currentHealth;
    private Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    public float moveSpeed = 8f;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    bool isAlive;
    public GameObject healthPotion;


    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        currentHealth = health;
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

        TowardToPlayer();

    }

    void TrackingMovement(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        animator.SetFloat("Speed",Mathf.Abs(moveSpeed));
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            TrackingMovement(movement);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject);
        }
    }

    void Attack(GameObject x)
    {
        animator.SetTrigger("Attack");
        x.GetComponent<CharacterMovement>().TakeDamage(attackDamage);
    }


    void TowardToPlayer()
    {
        Vector2 direction = player.position - transform.position;

        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        float dropChance = 0.2f;

        if (currentHealth <= 0) 
        {
            animator.SetTrigger("isDead");
            gameObject.GetComponent<Collider2D>().enabled = false;
            isAlive = false;
            StartCoroutine(DestroyAfterAnimation(gameObject));
            if (Random.value <= dropChance)
            {
                Instantiate(healthPotion, transform.position, Quaternion.identity);
            }
        }
        else
        {
            animator.SetTrigger("isHit");
        }
    }
    private IEnumerator DestroyAfterAnimation(GameObject enemy)
    {
        yield return new WaitForSeconds(1);
        Destroy(enemy);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
