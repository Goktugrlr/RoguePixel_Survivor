using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    private Collider2D boundaryCollider;

    void Start()
    {
        boundaryCollider = GetComponent<Collider2D>();
    }

    void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, boundaryCollider.bounds.min.y, boundaryCollider.bounds.max.y);
        transform.position = clampedPosition;
    }
}