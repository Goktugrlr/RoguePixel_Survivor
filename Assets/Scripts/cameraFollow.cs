using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public Transform target; 
    public float followSpeed = 5f; 
     public Vector2 minBoundaries, maxBoundaries;

    void Update()
    {
        if (target != null)
        {
            
            float clampedX = Mathf.Clamp(target.position.x, minBoundaries.x, maxBoundaries.x);
            float clampedY = Mathf.Clamp(target.position.y, minBoundaries.y, maxBoundaries.y);

            
            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

}
