using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    //This script depends on SpriteRenderer component attached to this object
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenWrap : MonoBehaviour
    {
        //Sprite
        private SpriteRenderer spriteRenderer;
        //Camera
        private Bounds camBounds;
        private float camWidth;
        private float camHeight;


        // Use this for initialization
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

        }

        void UpdateCameraBounds()
        {
            //Calculate camera bounds
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camWidth,camHeight));

        }

        // LateUpdate is called at the end of a frame
        void LateUpdate()
        {
            UpdateCameraBounds();
            //Store Position and size in shorter variable names
            Vector3 pos = transform.position;
            Vector3 size = spriteRenderer.bounds.size;

            //calculate the sprites half width and half height
            float halfWidth = size.x / 2;
            float halfHeight = size.y / 2;
            float halfCamWidth = camWidth / 2;
            float halfCamHeight = camHeight / 2;
            //check Left
            if (pos.x + halfWidth < camBounds.min.x)
            {
                pos.x = camBounds.max.x + halfWidth;
            }

            //check right
            if (pos.x - halfWidth > camBounds.max.x)
            {
                pos.x = camBounds.min.x - halfWidth;
            }
            //check top
            if (pos.y - halfHeight > camBounds.max.y)
            {
                pos.y = camBounds.min.y - halfHeight;
            }
            //check bottom
            if (pos.y + halfHeight < camBounds.min.y)
            {
                pos.y = camBounds.max.y + halfHeight;
            }
            //move the enemy back around
            transform.position = pos;
        }
    }
}

