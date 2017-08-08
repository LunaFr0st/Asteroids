using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Functions
{
    public class Shoot : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public float projectileSpeed = 10f;
        public float fireRate = 0.1f;
        private float shootTimer = 0f;
        public float recoil = 10f;
        private Rigidbody2D Rigid;
        void Start()
        {
            Rigid = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            shootTimer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && shootTimer >= fireRate)
            {
                Shooting();
                shootTimer = 0f;
            }
         
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "enemy")
            {
                Destroy(col.gameObject);
            }
        }

        void Shooting()
        {
            GameObject projectile = Instantiate(projectilePrefab);
            // Projectile's position = Transform position
            projectile.transform.position = transform.position;
            Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
            rigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
            Rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}

