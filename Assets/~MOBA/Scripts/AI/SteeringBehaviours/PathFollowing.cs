using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using GGL;

namespace MOBA
{
    public class PathFollowing : SteeringBehaviour
    {
        public Transform target; // Target to locate
        public float nodeRad = .1f; // How big each node is
        public float targetRad = 3f; // How big each target node is
        public bool isAtTarget = false; // Has the target been reached?
        public int currentNode = 0; // Keeps track of current node agent is targeting

        private NavMeshAgent nav; // Nav mesh agent refrence defined as nav
        private NavMeshPath path; // Stores the calculated path in the variable


        Vector3 Seek(Vector3 target)
        {
            Vector3 force = Vector3.zero;
            float distTarget = Vector3.Distance(target, transform.position);
            float dist = isAtTarget ? targetRad : nodeRad;
            if (distTarget > dist)
            {
                Vector3 dir = (target - transform.position).normalized * weighting;
                force = dir - owner.velocity;
            }
            return force;
        }

        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
        }

        void Update() // Draw out path calculated by agent
        {
            if (path != null)
            {
                Vector3[] corners = path.corners;
                if (corners.Length > 0)
                {
                    Vector3 targetPos = corners[corners.Length - 1];
                    GizmosGL.color = new Color(1, 0, 0, 0.3f);
                    GizmosGL.AddSphere(targetPos, targetRad * 2);
                    float dist = Vector3.Distance(transform.position, targetPos);
                    if (dist >= targetRad)
                    {
                        GizmosGL.color = Color.cyan;
                        for (int i = 0; i < corners.Length - 1; i++)
                        {
                            Vector3 nodeA = corners[i];
                            Vector3 nodeB = corners[i + 1];
                            GizmosGL.AddLine(nodeA, nodeB, 0.1f, 0.1f);
                            GizmosGL.AddSphere(nodeB, 1f);
                            GizmosGL.color = Color.red;
                        }
                    }
                }

            }
        }

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero; // No Force ("NO CAPES" )

            if (!target)
                return force;

            if (nav.CalculatePath(target.position, path)) // checks if the target position is within the path
            {
                if (path.status == NavMeshPathStatus.PathComplete) // Is the path finished calculating?
                {
                    Vector3[] corners = path.corners;
                    if (corners.Length > 0)
                    {
                        int lastIndex = corners.Length - 1;
                        if (currentNode >= corners.Length)
                        {
                            // Cap currentNode to lastIndex
                            currentNode = lastIndex;
                        }
                        // Get Current corner position
                        Vector3 curPos = corners[currentNode];
                        float dist = Vector3.Distance(transform.position, curPos);
                        if (dist <= nodeRad)
                        {
                            currentNode++;
                        }
                        float distanceToTarget = Vector3.Distance(transform.position, target.position);
                        isAtTarget = distanceToTarget <= targetRad;
                        force = Seek(curPos);
                    }

                }
            }
            return force;
        }
    }
}