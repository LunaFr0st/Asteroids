﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        public float damage = 50f; // How much damage dealt
        public float speed = 50f; // Speed of Projectile
        public Vector3 direction; // direction of projectile travelling

        void Update()
        {
            Vector3 velocity = direction.normalized * speed;
            direction += velocity * Time.deltaTime;
        }
        void OnTriggerEnter(Collider col)
        {
            Enemy e = GetComponent<Enemy>();
            if (e != null)
            {
                e.DealDamage(damage);
                Destroy(gameObject);
            }
            if(col.name == "Ground")
            {
                Destroy(gameObject);
            }
        }
    }
}


