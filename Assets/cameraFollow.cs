using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesnenin referansý
    public float followSpeed = 5f; // Kameranýn ne kadar hýzlý takip edeceði
    public Vector2 minBoundaries, maxBoundaries; // Sýnýrlarýn deðerleri (minX, maxX, minY, maxY olarak da kullanýlabilir)

    void Update()
    {
        if (target != null)
        {
            // Hedefin pozisyonunu sýnýrla
            float clampedX = Mathf.Clamp(target.position.x, minBoundaries.x, maxBoundaries.x);
            float clampedY = Mathf.Clamp(target.position.y, minBoundaries.y, maxBoundaries.y);

            // Kameranýn yeni pozisyonunu belirle
            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
