using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform
    public Vector3 offset = new Vector3(0f, 10f, -10f); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of camera movement

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.position);
    }
}