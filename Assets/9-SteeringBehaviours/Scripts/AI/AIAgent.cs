using System.Collections;
using System.Collections.Generic;
using UnityEngine;                                                                          // Unity Engine
using UnityEngine.AI;                                                                       // Import for AI

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;                                                               // The Force
        public Vector3 velocity;                                                            // The Velocity
        public float maxSpeed = 100f;                                                       // Maximum Velocity
        public float maxDistance = 10f;                                                     // Maximum Distance
        public bool freezeRotation = false;                                                 // If it can turn

        private NavMeshAgent nav;                                                           // The Navmesh AI
        private List<SteeringBehaviour> behaviours;                                         // The List for the behaviours

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();                                             // Gets the Component and sets it to variable nav
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());   // Gets the Steering behaviour list, and its components and sets it to variable behaviour
        }
        void ComputeForces() // Function for Computing the forces
        {
            force = Vector3.zero;                                                           // sets variable force to 0,0,0
            for (int i = 0; i < behaviours.Count; i++)                                      // for loop for every behaviour in the list
            {
                SteeringBehaviour behaviour = behaviours[i];                                // defines behaviour as behaviours list count
                if (behaviour.isActiveAndEnabled == false)                                  // checks if the variable is false
                {
                    continue;                                                               // continues onward
                }
                force += behaviour.GetForce();                                              // sets force to add onto what it currently is, plus the force of behaviour
                if (force.magnitude > maxSpeed)                                             // if the force magnitude is greater than the max speed
                {
                    force = force.normalized * maxSpeed;                                    // sets the force to be normal times the max speed
                    break;                                                                  // break it
                }
            }
        }

        void ApplyVelocity()                                                                // function to apply velocity
        {
            velocity += force * Time.deltaTime;                                             // sets velocity to equal itself + force times it by deltatime
            if(velocity.magnitude > maxSpeed)                                               //
            {
                velocity = velocity.normalized * maxSpeed;                                  //
            }
            if (velocity.magnitude > 0)                                                     //
            {
                transform.position = transform.position + velocity * Time.deltaTime;        //
                transform.rotation = Quaternion.LookRotation(velocity);                     //
            }
        }

        void Update()                                                                       //
        {
            ComputeForces();                                                                //
            ApplyVelocity();                                                                //
        }
    }
}

