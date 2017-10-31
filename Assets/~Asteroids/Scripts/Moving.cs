using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Moving : MonoBehaviour
    {
        public float accelerate = 25f;
        public float rotationSpeed = 360f;
        private Rigidbody2D rigi;
        private float iH;
        private float iV;

        void Awake()
        {
            rigi = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            Accelerate();
            Rotate();
        }

        void Accelerate()
        {
            iV = Input.GetAxis("Vertical");
            rigi.AddForce(transform.up * iV * accelerate);
        }

        void Rotate()
        {
            iH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back, rotationSpeed * iH * Time.deltaTime);
        }
    }
}

