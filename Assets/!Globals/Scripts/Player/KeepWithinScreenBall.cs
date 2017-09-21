using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))] //Force Renderer component to be attached
public class KeepWithinScreenBall : MonoBehaviour
{
    private Renderer rend; // Renderer attached to the object
    private Camera cam; // Camera contatiner (variable)
    private Bounds camBounds; // Camera Bounds structure
    private float camWidth, camHeight;

    // Use this for initialization
    void Start()
    {
        // Set Camera variable to the main camera
        cam = Camera.main;
        // Get Renderer component to attach to the object
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the camera bounds
        UpdateCamBounds();
        // Set the position after checking the bounds
        transform.position = CheckBounds();
    }
    //Updates the camBounds variable with the camera values
    void UpdateCamBounds()
    {
        //Calculate camera bounds
        camHeight = 2f * cam.orthographicSize; // height = 2 x orthographic size
        camWidth = camHeight * cam.aspect; // width = height x aspect ratio
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }
    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;
        float halfCamWidth = camWidth * 0.5f;
        float halfCamHeight = camHeight * 0.5f;
        //Check Left side of screen
        if (pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }
        //Check Right side of screen
        if (pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }
        // Check top of screen
        if (pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.max.y - halfHeight;
        }
        return pos; // Returns adjusted position
    }
    }
