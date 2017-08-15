using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxBullets = 30;
        public float fireInterval = 0.2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;

        private Transform target;
        private bool isFired = false;
        private int currentBullets = 0;
        private Bullet[] spawnedBullets;
        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
            
        }

        // Update is called once per frame
        void Update()
        {
            if(!isFired && currentBullets < maxBullets)
            {
                StartCoroutine(Fire());
            }
        }

        IEnumerator Fire()
        {
            isFired = true;
            SpawnBullet();
            yield return new WaitForSeconds(fireInterval);
            isFired = false;
        }
        void SpawnBullet()
        {
            /*  1. Instantiate Bullet clone
                2. Create direction varaible for bullet and rotating
                3. Rotate the weapon to direction
                4. Grab the bullet script from clone
                5. Send bullet to target (by setting direction)
                6. Store bullet in array using currentBullets as index
                7. Increment currentBullets
            */
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity); //Instantiate Bullet clone
            Vector2 direction = target.position - transform.position;//Create direction varaible for bullet and rotating
            direction.Normalize();//Create direction varaible for bullet and rotating
            transform.rotation = Quaternion.LookRotation(direction);//Rotate the weapon to direction
            Bullet bullet = clone.GetComponent<Bullet>();//Grab the bullet script from clone
            bullet.direction = direction;//Send bullet to target (by setting direction)
            spawnedBullets[currentBullets] = bullet;//Store bullet in array using currentBullets as index
            currentBullets++;//Increment currentBullets
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}

