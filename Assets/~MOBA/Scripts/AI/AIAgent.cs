using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace MOBA
{
    public class AIAgent : MonoBehaviour
    {
        public float maxSpeed = 10f;
        public float maxDist = 5f;
        public bool updatePos = true;
        public bool updateRot = true;

        [HideInInspector]
        public Vector3 velocity;

        private Vector3 force;
        private List<SteeringBehaviour> behaviours;
        private NavMeshAgent nav;
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }
        void ComputeForces() // Calculates the forces attached to SteeringBehaviours
        {
            force = Vector3.zero;
            for (int i = 0; i < behaviours.Count; i++)
            {
                SteeringBehaviour b = behaviours[i];
                if (!b.isActiveAndEnabled)
                {
                    continue;
                }
                force += b.GetForce() * b.weighting;
                if (force.magnitude > maxSpeed)
                {
                    force = force.normalized * maxSpeed;
                    break;
                }
            }
        }
        void ApplyVelocity() // Applies the Velocity to the agent
        {
            velocity += force * Time.deltaTime;
            nav.speed = velocity.magnitude;
            if (velocity.magnitude > 0 && nav.updatePosition)
            {
                if (velocity.magnitude > maxSpeed)
                {
                    velocity = velocity.normalized * maxSpeed;
                }
                Vector3 nextPos = transform.position + velocity;
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(nextPos, out navHit, maxDist,-1))
                {
                    nav.SetDestination(navHit.position);
                }
            }
        }
        void Update() // Updates every Frame
        {
                nav.updatePosition = updatePos;
                nav.updateRotation = updateRot;
                ComputeForces();
                ApplyVelocity();
            }
        }
    }