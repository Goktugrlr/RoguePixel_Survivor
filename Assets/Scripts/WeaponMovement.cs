using UnityEngine;
public class WeaponMovement : MonoBehaviour
{
    private Transform weaponTransform;
    private Vector3 mousePosition;
    public float rotationSpeed = 100f;
    public Sprite rightSprite;
    public Sprite leftSprite;
    
    private void Start()
    {
        weaponTransform = this.transform;
    }

    private void Update()
    {
        aiming();
    }

    private void aiming() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        GameObject player = GameObject.Find("Player");
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();

        if (mousePosition.x < weaponTransform.position.x)
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotz);
            spriteRenderer.sprite = leftSprite;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, rotz);
            spriteRenderer.sprite = rightSprite;
        }
    }

}