using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;
        public float shootRate = 0.2f;

        private float shootTimer = 0f;

        void Shoot()                                                                                // Function that handles the creation and force of the bullet
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);   // Defines a new Gameobject to equal a new version of the bullet prefab and its position + rotation
            Rigidbody2D rigi = clone.GetComponent<Rigidbody2D>();                                   // Grabs the Component for the rigidbody
            rigi.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);                         // Applies a force instantly to the clone
        }
        void Update()                                                                               // Function to Update every frame
        {
            shootTimer += Time.deltaTime;                                                           // Timer using Delta time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (shootTimer > shootRate)                                                         // Checks if the timer equals the defined rate of fire
                {                                                                                   
                    Shoot();                                                                        // Calls Shooting function
                    shootTimer = 0;                                                                 // Sets the timer to 0
                }
            }
        }
    }
}
