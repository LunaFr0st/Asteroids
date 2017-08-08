using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RotateVelocity : MonoBehaviour
    {
        private Rigidbody2D Rigid;
        // Use this for initialization
        void Start()
        {
            Rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 vel = Rigid.velocity;
            float angle = Mathf.Atan2(vel.y, vel.x);
            Rigid.rotation = angle * Mathf.Rad2Deg;
        }
    }
}

