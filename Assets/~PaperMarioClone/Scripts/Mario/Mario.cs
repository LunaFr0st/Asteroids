using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(PlayerController))]
    public class Mario : MonoBehaviour
    {
        public float rayDist;
        private PlayerController pc;
        private Ray stompRay;
        void Awake()
        {
            pc = GetComponent<PlayerController>();
        }
        void Update()
        {
            if (!pc.isGrounded)
                CheckStomp();
        }
        void RecalcuateRay()
        {
            stompRay = new Ray(transform.position, Vector3.down);
        }
        void CheckStomp()
        {
            RaycastHit hit;
            if (Physics.Raycast(stompRay, out hit, rayDist))
            {
                Enemy e = hit.collider.GetComponent<Enemy>();
                if(e != null)
                {
                    // e.Damage();
                    pc.Jump(true);
                }
            }
        }
        void OnDrawGizmos()
        {
            RecalcuateRay();
            Gizmos.DrawLine(stompRay.origin, stompRay.origin + stompRay.direction * rayDist);
        }
    }
}

