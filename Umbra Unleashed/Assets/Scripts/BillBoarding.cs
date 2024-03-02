using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find and store a reference to the main camera
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // Make the object face the camera by matching the camera's rotation
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                         mainCamera.transform.rotation * Vector3.up);
    }
}
