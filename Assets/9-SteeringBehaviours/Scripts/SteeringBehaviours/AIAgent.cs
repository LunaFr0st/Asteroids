using System.Collections;
using System.Collections.Generic;
using UnityEngine;                                 // Unity Engine
using UnityEngine.AI;                              // Import for AI

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;                       // The Force
        public Vector3 velocity;                    // The Velocity
        public float maxVelocity = 100f;            // Maximum Velocity
        public float maxDistance = 10f;             // Maximum Distance
        public bool freezeRotation = false;         // If it can turn

        private NavMeshAgent nav;                   // The Navmesh AI
        private List<SteeringBehaviour> behaviours; // The List for the behaviours

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            force = Vector3.zero;
            for (int i = 0; i < behaviours.Count; i++)
            {
                SteeringBehaviour behaviour = behaviours[i];
                if (behaviour.isActiveAndEnabled == false)
                {
                    continue;
                }
                force = force + behaviour.GetForce() * behaviour.weight;
                if (force.magnitude > maxVelocity)
                {
                    force = force.normalized * maxVelocity;
                    break;
                }
            }
        }

        void ApplyVelocity()
        {
            velocity = velocity + force * Time.deltaTime;
            if(velocity.magnitude > maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }
            if (velocity.magnitude > 0)
            {
                transform.position = transform.position + velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }

        void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}

