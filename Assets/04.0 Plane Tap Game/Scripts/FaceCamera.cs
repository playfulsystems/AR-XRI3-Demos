using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        directionToCamera.y = 0f; // Ignore vertical difference
        
        if (directionToCamera.sqrMagnitude > 0.001f) // Avoid zero-length vectors
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = targetRotation * Quaternion.Euler(0, 180, 0); // rotate 180
        }
    }
}
