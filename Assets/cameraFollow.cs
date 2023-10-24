using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesnenin referansý
    public Collider2D boundaryCollider; // Duvarlarý temsil eden Collider

    private Vector3 minBound, maxBound; // Sýnýrlarýn deðerleri

    void Start()
    {
        if (boundaryCollider != null)
        {
            // Duvar collider'ýnýn sýnýrlarýný al
            minBound = boundaryCollider.bounds.min;
            maxBound = boundaryCollider.bounds.max;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Hedefin pozisyonunu sýnýrla
            float clampedX = Mathf.Clamp(target.position.x, minBound.x, maxBound.x);
            float clampedY = Mathf.Clamp(target.position.y, minBound.y, maxBound.y);

            // Kameranýn yeni pozisyonunu belirle
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
