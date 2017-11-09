using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class MoveWithinBounds : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public float zoomSens = 10f;
        public CameraBounds bound;
        void Update()
        {
            Vector3 pos = transform.position;
            float iH = Input.GetAxis("Horizontal");
            float iV = Input.GetAxis("Vertical");
            Vector3 inputDir = new Vector3(iH, 0, iV);
            pos += inputDir * movementSpeed * Time.deltaTime;

            float iScroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 scrollDir = transform.forward * zoomSens * iScroll;
            pos += scrollDir;
            pos = bound.GetAdjustedPos(pos);
            transform.position = pos;
        }
    }
}

