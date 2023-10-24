using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesnenin referans�
    public Collider2D boundaryCollider; // Duvarlar� temsil eden Collider

    private Vector3 minBound, maxBound; // S�n�rlar�n de�erleri

    void Start()
    {
        if (boundaryCollider != null)
        {
            // Duvar collider'�n�n s�n�rlar�n� al
            minBound = boundaryCollider.bounds.min;
            maxBound = boundaryCollider.bounds.max;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Hedefin pozisyonunu s�n�rla
            float clampedX = Mathf.Clamp(target.position.x, minBound.x, maxBound.x);
            float clampedY = Mathf.Clamp(target.position.y, minBound.y, maxBound.y);

            // Kameran�n yeni pozisyonunu belirle
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
