using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovementRigid2D
{
    public class Movement2DRigid : MonoBehaviour
    {
        #region - Variables
        public float movementSpeed = 40f;
        public float sprintSpeed = 20f;
        public float rotationSpeed = 180f;
        public float deceleration = 10f;

        private Rigidbody2D rigid2D;
        #endregion

        #region - Functions
        // Use this for initialization
        void Start()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Sprint();
            decelerate();
            Rotation();
        }

        void decelerate()
        {
            rigid2D.velocity += -rigid2D.velocity * deceleration * Time.deltaTime;
        }

        void Movement()
        {
            float inputV = Input.GetAxis("Vertical");
            //Move by a force "forward" (which is right)
            rigid2D.AddForce(transform.right * inputV * movementSpeed);
        }

        void Sprint()
        {
            float inputV = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space))
            {
                rigid2D.AddForce(transform.right * inputV * (movementSpeed + sprintSpeed));
            }
        } 

        void Rotation()
        {
            float inputH = Input.GetAxis("Horizontal");
            //Rotate Player around an axis
            transform.rotation *= Quaternion.AngleAxis(inputH * rotationSpeed * Time.deltaTime, Vector3.back);
        }
        #endregion
    }
}
