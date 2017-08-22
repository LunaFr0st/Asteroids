using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 10f; // Speed of the ball
        private Vector3 velocity; // Speed X of Direction.
        public Text scoreCounter;
        public int currentScore;
        // Use this for initialization
        void Start()
        {
            currentScore = 0;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += velocity * Time.deltaTime;
            scoreCounter.text = "Score: " + currentScore;
        }
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            //Grab the contact point of collision
            ContactPoint2D contact = other.contacts[0];
            // Calculate the reflection point o fthe ball using velocity and the contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Calculate a new velocity from reflection multipled by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
            if(other.gameObject.tag == "GreenBlock")
            {
                Debug.Log("Block Destroyed, + 1 Point");
                Destroy(other.gameObject);
                currentScore++;
            }
            if (other.gameObject.tag == "RedBlock")
            {
                Debug.Log("Block Destroyed, + 2 Points");
                Destroy(other.gameObject);
                currentScore += 2;
            }
            if (other.gameObject.tag == "BlueBlock")
            {
                Debug.Log("Block Destroyed, + 3 Points");
                Destroy(other.gameObject);
                currentScore += 3;
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Block")
            {
                
                Debug.Log("Dead Ball, Restart Game");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }
}

