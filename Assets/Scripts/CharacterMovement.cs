using TMPro;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public Rigidbody2D rb;
    Vector2 movement;
    public TMP_Text healthText;
    public int maxHealth = 100;
    int currentHealth;
    public WaveManager waveManager;


    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        healthText.text = "Health: " + currentHealth;

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    public int GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            waveManager.HandlePlayerDeath();
        }


    }



}
