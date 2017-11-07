using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 20f;
        public float runSpeed = 30f;
        public float jumpHeight = 10f;
        public bool MoveInJump = false;
        public bool isRunning = false;
        public bool isGrounded
        {
            get { return controller.isGrounded; }
        }

        private CharacterController controller;
        private Vector3 gravity;
        private Vector3 movement;
        private Vector3 inputDirection;
        private bool jump = false;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (isRunning)
                movement *= runSpeed;
            else
                movement *= walkSpeed;

            if (isGrounded)
            {
                gravity = Vector3.zero;
                if (jump)
                {
                    gravity.y = jumpHeight;
                    jump = false;
                }

            }
            else
            {
                gravity += Physics.gravity * Time.deltaTime;
            }
            movement += gravity;
            controller.Move(movement * Time.deltaTime);
        }
        public void Jump()
        {
            jump = true;
        }
        public void Move(float iH, float iV)
        {
            if (MoveInJump || (!MoveInJump && isGrounded))
            {
                inputDirection = new Vector3(iH, 0, iV);
            }
            movement = transform.TransformDirection(inputDirection);

        }
    }
}

