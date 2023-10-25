using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public Transform target; // The reference to the object to follow
    public float followSpeed = 5f; // How fast the camera follows the target
     public Vector2 minBoundaries, maxBoundaries; // Sınırların değerleri (minX, maxX, minY, maxY olarak da kullanılabilir)

    void Update()
    {
        if (target != null)
        {
            // Hedefin pozisyonunu sınırla
            float clampedX = Mathf.Clamp(target.position.x, minBoundaries.x, maxBoundaries.x);
            float clampedY = Mathf.Clamp(target.position.y, minBoundaries.y, maxBoundaries.y);

            // Kameranın yeni pozisyonunu belirle
            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

}
