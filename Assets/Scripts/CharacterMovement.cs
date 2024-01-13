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
    private bool isDead = false;
    private bool isInvulnerable = false;
    private float invulnerableTime = -10.0f;
    public Color originalColor;
    public float transparency = 0.5f;
    
    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        healthText.text = "Health: " + currentHealth;
        if (isInvulnerable && Time.time > invulnerableTime +10)
        {
            isInvulnerable = false;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = originalColor;
        }
    }


    private void FixedUpdate()
    {
        if(isDead==false){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }


    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        if(!isInvulnerable)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
            } 
        }

    }

    public void SetIsDead(bool dead)
    {
        isDead = dead;
    }


    public bool GetIsDead()
    {
        return isDead;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "HealthPotion")
        {
                if (currentHealth +20 <= maxHealth){
                    currentHealth += 20;
                    Destroy(other.gameObject);
                }
                else if (currentHealth +20 > maxHealth){
                    currentHealth = maxHealth;
                    Destroy(other.gameObject);
                }
        }
    }

    public void MakeInvulnerable()
    {
        isInvulnerable = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        Color currentColor = spriteRenderer.color;
        currentColor.a = transparency;
        spriteRenderer.color = currentColor;
        
        invulnerableTime = Time.time;
    }
}
