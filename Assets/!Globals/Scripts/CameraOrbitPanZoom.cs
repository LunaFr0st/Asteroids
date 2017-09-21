using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraOrbitPanZoom : MonoBehaviour
{
    public Transform target; // Target to orbit around
    public float panSpeed = 5f; // Speed of Panning
    public float sens = 1f; // Sensitivity of mouse
    public float distanceMin = 0.5f; // min zoom distance
    public float distanceMax = 50f; // max zoom distance
    private float distance = 0f; //current distance between target and camera
    private float x; // x rot in euler
    private float y; // y rot in euler

    public enum MouseButton
    {
        LEFTMOUSE = 0,
        RIGHTMOUSE = 1,
        MIDDLEMOUSE = 2,
    }
    void Start()
    {
        target.transform.SetParent(null);
        distance = Vector3.Distance(target.transform.position, transform.position);
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }
    void Orbit()
    {
        x = x + Input.GetAxis("Mouse X") * sens;
        y = y + Input.GetAxis("Mouse Y") * sens;
    }
    void Movement()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            float desDist = distance - Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(desDist, distanceMin, distanceMax);
            Vector3 invDistanceZ = new Vector3(0, 0, -distance);
            invDistanceZ = rotation * invDistanceZ;
            Vector3 pos = target.position + invDistanceZ;
            transform.rotation = rotation;
            transform.position = pos;
        }
    }
    void Pan()
    {
        float iX = Input.GetAxis("Mouse X");
        float iY = Input.GetAxis("Mouse Y");
        Vector3 inputDir = new Vector3(iX, iY);
        Vector3 movement = transform.TransformDirection(inputDir);
        target.transform.position += movement * panSpeed * Time.deltaTime;
    }
    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void LateUpdate()
    {
        if (Input.GetMouseButton((int)MouseButton.RIGHTMOUSE))
        {
            HideCursor(true);
            Orbit();
        }
        else if (Input.GetMouseButton((int)MouseButton.MIDDLEMOUSE))
        {
            HideCursor(true);
            Pan();
        }
        else
        {
            HideCursor(false);
        }
        Movement();
    }
}
