using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller2D : MonoBehaviour
    {
        public float accelerate = 20f; // Acceleration of player
        public float airSpeed = 5f;
        public float jH = 10f; // Jump height of Player
        public float rayDist = 1f;
        public LayerMask hitLayer;
        public bool isGrounded = false;

        private Rigidbody2D rigid2D;

        void Awake()
        {
            rigid2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, rayDist, hitLayer); // Performs a raycast down at ground
            if (hit.collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        public void Move(float iH) // Makes player move horizontally
        {
            rigid2D.AddForce(transform.right * iH * accelerate);
        }

        public void Jump() // Makes player jump when functiion is called
        {
            rigid2D.AddForce(transform.up * jH, ForceMode2D.Impulse);
        }
        void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + -transform.up * rayDist);
        }
    }
}

