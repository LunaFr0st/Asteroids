using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent nav;
        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            //If Target is not null
                   //Set nav destenation to target position
            if(target != null)
            {
                nav.SetDestination(target.position);
            }
        }
    }
}

