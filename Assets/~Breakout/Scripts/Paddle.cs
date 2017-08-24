using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        public Button startButton;
        public float movementSpeed = 20f;
        public Ball currentBall;
        public Vector2[] directions = new Vector2[]
        {
            new Vector2(-0.5f, 0.5f),
            new Vector2(0.5f, 0.5f),
        };
        // Use this for initialization
        void Start()
        {
            //grabs currentBall from children of the Paddle
            currentBall = GetComponentInChildren<Ball>();
        }

        // Update is called once per frame
        void Update()
        {
            InputCheck();
            Movement();
        }
        void Fire()
        {
            //detach as child
            currentBall.transform.SetParent(null);
            // Generate random direction from list of directions
            Vector3 randomDirection = directions[Random.Range(0, directions.Length)];
            // Fire off the ball in randomDirection
            currentBall.Fire(randomDirection);
        }
        void InputCheck()
        {
            if (currentBall.transform.parent != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire(); // Fires the ball from the paddle to start game.
                }
            }
            
        }
        void Movement()
        {
            // Get input on the horizontal axis (A, D, leftArrow, rightArrow)
            float hori = Input.GetAxis("Horizontal");
            //Set force to direction (Hori to decide the direction)
            Vector3 force = transform.right * hori;
            // Apply movement speed
            force *= movementSpeed;
            // Apply Delta Time to Force
            force *= Time.deltaTime;
            // add force to position
            transform.position += force;
        }
    }
}


