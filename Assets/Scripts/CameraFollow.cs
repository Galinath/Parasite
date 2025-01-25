using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object the camera follows

    public float smoothSpeed = 5f; // Speed of camera movement

    public Vector3 offset; // Offset to adjust camera position



    void LateUpdate()

    {

        if (target == null) return;



        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

    }



    public void SetTarget(Transform newTarget)

    {

        target = newTarget;

    }
}
