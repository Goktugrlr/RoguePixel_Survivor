using TMPro;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public Rigidbody2D rb;
    Vector2 movement;
    public TMP_Text healthText;
    public float health = 100f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        healthText.text = "Health: " + health;

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
