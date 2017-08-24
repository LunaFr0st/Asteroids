using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {

        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            //Check if the velocity is going on Y axis
            if (vel.y > 0)
            {
                vel.y = 0;
            }
            if (vel.magnitude < stopSpeed)
            {
                vel = Vector3.zero;
            }
            rigid.velocity = vel;
        }
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }
        void OnTriggerEnter(Collision other)
        {
            if(other.gameObject.tag == "BallRemover")
            {
                Destroy(other.gameObject);
            }
            
        }
    }
}
