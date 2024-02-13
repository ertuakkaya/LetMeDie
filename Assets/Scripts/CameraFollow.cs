using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;
    public float smoothSpeed = 0.125f; // Add this line

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        // Update the camera's position to follow the player, without changing rotation.
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}