using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            if(target == null)
            {
                return force;
            }
            Vector3 desiredForce = target.position - transform.position;
            if (desiredForce.magnitude > stoppingDistance)
            {
                desiredForce = desiredForce.normalized * weight;
                force = desiredForce - owner.velocity;
            }
            return force;
        }
    }
}

