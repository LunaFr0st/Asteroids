using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer2D
{
    [RequireComponent(typeof(Controller2D))]
    public class UserInput2D : MonoBehaviour
    {
        [SerializeField] KeyCode jumpKey = KeyCode.Space;
        private Controller2D c; // stores the Controller2D into a variable that can be called
        void Awake()
        {
            c = GetComponent<Controller2D>();
        }
        void Update()
        {
            float iH = Input.GetAxis("Horizontal");
            c.Move(iH);
            if (Input.GetKeyDown(jumpKey) && c.isGrounded)
            {
                c.Jump();
            }
        }
    }
}

