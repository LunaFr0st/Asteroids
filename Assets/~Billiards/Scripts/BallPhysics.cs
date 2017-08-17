using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class BallPhysics : MonoBehaviour
    {

        public float gravity = -9.81f;
        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rigid.velocity = rigid.velocity.normalized + Vector3.back * gravity;
        }

        void OnCollisionEnter(Collision other)
        {
            BallPhysics ball = other.collider.GetComponent<BallPhysics>();
            if(ball != null)
            {
                ball.Activate();
            }
        }
        public void Activate()
        {
            rigid.constraints = RigidbodyConstraints.None;
        }
        public void Deactivate()
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }


    }
}

