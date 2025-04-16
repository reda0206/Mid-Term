using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 5f;

    private Vector3 cameraVelocity = Vector3.zero;

    private void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothSpeed);

    }
}