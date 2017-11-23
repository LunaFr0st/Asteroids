using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GGL;
namespace MOBA
{
    [RequireComponent(typeof(Camera))]
    public class AIAgentPatrolSelector : MonoBehaviour
    {
        public LayerMask hitLayers;
        public float rayDistance = 1000f;
        public AIAgent[] agentsToDirect;
        public List<Transform> patrolPoints;
        private Camera cam;

        void Awake()
        {
            cam = GetComponent<Camera>();
            foreach (var agent in agentsToDirect)
            {
                Patrol p = agent.GetComponent<Patrol>();
                if(p != null)
                {
                    p.patrolSelector = this;
                }
            }
        }
        void HandleSelector()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                if(Physics.Raycast(camRay, out rayHit, rayDistance, hitLayers))
                {
                    NavMeshHit navHit;
                    if(NavMesh.SamplePosition(rayHit.point, out navHit, rayDistance, -1))
                    {
                        AddPatrolPoint(rayHit.point);
                    }
                }
            }
        }
        void AddPatrolPoint(Vector3 point)
        {
            GameObject g = new GameObject("Point" + patrolPoints.Count);
            g.transform.position = point;
            patrolPoints.Add(g.transform);
        }
        void Update()
        {
            HandleSelector();
            foreach (var p in patrolPoints)
            {
                GizmosGL.AddSphere(p.position, 1f);
            }
        }
    }
}

