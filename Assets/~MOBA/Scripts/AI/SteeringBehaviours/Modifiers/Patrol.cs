using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MOBA
{
    [RequireComponent(typeof(PathFollowing))]
    public class Patrol : MonoBehaviour
    {
        public AIAgentPatrolSelector patrolSelector;
        private int currentPoint = 0; // Current point the agent is pathfollwing to
        private PathFollowing pF; // Pathfollowing Refrence
        private List<Transform> pP; // Patrol Points

        void Start()
        {
            pF = GetComponent<PathFollowing>();

        }
        void Update()
        {
            if (patrolSelector != null)
            {
                pP = patrolSelector.patrolPoints;
                if (pP.Count > 0)
                {
                    if (pF.isAtTarget)
                    {
                        pF.currentNode = 0;
                        currentPoint++;
                    }
                    if(currentPoint >= pP.Count) // checks if the it is outside of the list
                    {
                        currentPoint = 0;
                    }
                    Transform point = pP[currentPoint];
                    pF.target = point;
                }
            }
        }
    }

}