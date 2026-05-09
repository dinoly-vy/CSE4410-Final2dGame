using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour{
    
    public Transform target;

    public float smoothTime = 0.2f;
    public float orthographicSize = 7f;
    public float minX, maxX, minY, maxY;
    private Vector3 velocity = Vector3.zero;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = orthographicSize;
    }
    private void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = cam.orthographicSize * cam.aspect;

        float clampedX = Mathf.Clamp(transform.position.x, minX + camHalfWidth, maxX - camHalfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minY + camHalfHeight, maxY - camHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}

