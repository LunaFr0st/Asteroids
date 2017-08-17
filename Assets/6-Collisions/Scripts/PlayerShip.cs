using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    public class PlayerShip : MonoBehaviour
    {

        public float acceleration = 20f;
        public float rotationSpeed = 360f;
        public float hyperSpeed = 150f;

        private Rigidbody2D rigid;


        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            Rigidbody2D[] rigids = FindObjectsOfType<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotate();
        }

        void Accelerate()
        {
            float InputV = Input.GetAxis("Vertical");
            rigid.AddForce(transform.up * InputV * acceleration);
            float currentSpeed = acceleration;
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = hyperSpeed;
            }

        }

        void Rotate()
        {
            float InputH = Input.GetAxis("Horizontal");
            //Vector3.back (... from outer space!), angle
            transform.Rotate(Vector3.back, rotationSpeed * InputH * Time.deltaTime);
        }
    }
}

