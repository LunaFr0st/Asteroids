using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variables
{
    public class Movement : MonoBehaviour
    {
        #region - Variables
        public float movementSpeed = 20f;
        public float rotationSpeed = 100f;
        public Vector3 rotateRight = Vector3.forward;
        public Vector3 rotateLeft = Vector3.back;



        #endregion
        #region - Functions
        // Update is called once per frame
        void Update()
        {
            //Variables
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            bool PressedQ = Input.GetKey(KeyCode.Q);
            bool PressedE = Input.GetKey(KeyCode.E);
            Vector3 velocity = new Vector3(inputH, inputV) * movementSpeed;


            transform.Translate(velocity * Time.deltaTime);
            if (PressedQ)
            {
                transform.Rotate(rotateRight * rotationSpeed * Time.deltaTime);
            }
            if (PressedE)
            {
                transform.Rotate(rotateLeft * rotationSpeed * Time.deltaTime);
            }

        }
        // Update called once every few frames.
        void FixedUpdate()
        {

        }
        #endregion
    }
}
