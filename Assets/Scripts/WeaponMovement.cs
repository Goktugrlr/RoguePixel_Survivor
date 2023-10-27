using UnityEngine;
public class WeaponMovement : MonoBehaviour
{
    private Transform weaponTransform;
    private Vector3 mousePosition;
    public float rotationSpeed = 100f;

    private void Start()
    {
        weaponTransform = this.transform;
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition-transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;

        if (mousePosition.x < weaponTransform.position.y)
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotz);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, rotz);
        }
    }
}