using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PaperMarioClone
{
    public class Enemy : MonoBehaviour
    {
        public float movementSpeed = 10f;
        public bool isMovingLeft = true;
        public float rayDist = 1f;
        private Ray leftRay;
        private Ray rightRay;
        private Ray forwardRay;
        private Ray backRay;
        private BoxCollider box;
        [Range(0, 1)]
        [SerializeField]
        private float hue, saturation, value;

        public virtual void Update()
        {
            Move();
        }
        public void Move()
        {
            RecalculateRays();
            Vector3 pos = transform.position;
            bool isLeftHitting = Physics.Raycast(leftRay, rayDist);
            bool isRightHitting = Physics.Raycast(rightRay, rayDist);
            bool isForwardHitting = Physics.Raycast(forwardRay, rayDist);
            bool isBackHitting = Physics.Raycast(backRay, rayDist);

            if (isLeftHitting && !isRightHitting)
                isMovingLeft = false;
            else if (isRightHitting && !isLeftHitting)
                isMovingLeft = true;
            Vector3 dir = Vector3.zero;
            if (isMovingLeft)
                dir += Vector3.left;
            else
                dir += Vector3.right;
            pos += dir * movementSpeed * Time.deltaTime;


            transform.position = pos;
        }
        public virtual void Damage(int combo = 0)
        {

        }

        private void Awake()
        {
            box = GetComponent<BoxCollider>();
        }
        private void OnDrawGizmos()
        {
            box = GetComponent<BoxCollider>();
            RecalculateRays();
            Gizmos.color = Color.HSVToRGB(hue, saturation, value);
            Gizmos.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * rayDist);
            Gizmos.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * rayDist);
            Gizmos.DrawLine(forwardRay.origin, forwardRay.origin + forwardRay.direction * rayDist);
            Gizmos.DrawLine(backRay.origin, backRay.origin + backRay.direction * rayDist);
        }
        private void RecalculateRays()
        {
            Vector3 halfSize = box.bounds.size * 0.5f;
            Vector3 leftPos = transform.position - Vector3.left * halfSize.x + Vector3.down * halfSize.y;
            Vector3 rightPos = transform.position - Vector3.right * halfSize.x + Vector3.down * halfSize.y;

            Vector3 forwardPos = transform.position - Vector3.forward * halfSize.z + Vector3.down * halfSize.y;
            Vector3 backPos = transform.position - Vector3.back * halfSize.z + Vector3.down * halfSize.y;

            leftRay = new Ray(leftPos, Vector3.down);
            rightRay = new Ray(rightPos, Vector3.down);
            forwardRay = new Ray(forwardPos, Vector3.down);
            backRay = new Ray(backPos, Vector3.down);
        }
        
    }
}
