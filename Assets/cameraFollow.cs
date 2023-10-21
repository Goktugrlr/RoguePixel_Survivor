using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesnenin referans�
    public float followSpeed = 5f; // Kameran�n ne kadar h�zl� takip edece�i
    public Vector2 minBoundaries, maxBoundaries; // S�n�rlar�n de�erleri (minX, maxX, minY, maxY olarak da kullan�labilir)

    void Update()
    {
        if (target != null)
        {
            // Hedefin pozisyonunu s�n�rla
            float clampedX = Mathf.Clamp(target.position.x, minBoundaries.x, maxBoundaries.x);
            float clampedY = Mathf.Clamp(target.position.y, minBoundaries.y, maxBoundaries.y);

            // Kameran�n yeni pozisyonunu belirle
            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
