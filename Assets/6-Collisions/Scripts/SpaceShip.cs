using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    public class SpaceShip : MonoBehaviour
    {
        public float force = 30f;
        private Rigidbody2D rigid;

        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        void Update()
        {

        }
        void OnCollisionEnter2D(Collision2D other)
        {
            ContactPoint2D contact = other.contacts[0];
            Vector3 direction = contact.normal;
            //rigid.AddForce(direction * force, ForceMode2D.Impulse);
            rigid.velocity = direction * rigid.velocity.magnitude;
        }
    }
}

