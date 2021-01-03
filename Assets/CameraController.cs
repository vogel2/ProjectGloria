using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // PUBLIC
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float yawSpeed = 100f;

    // PRIVATE
    private float currentYaw = 0f;
    private float currentZoom = 10f;
    private float pitch = 2f;

    void Update()
    {
        currentZoom = currentZoom - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        currentYaw = currentYaw - Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.RotateAround(target.position, Vector3.up, currentYaw);
        transform.LookAt(target.position + Vector3.up * pitch);
    }

    void LookAt(Vector3 targetPosition)
    {

    }
}
