using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RollABall
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 50f;
        private Rigidbody rigi;
        void Awake()
        {
            rigi = GetComponent<Rigidbody>();
        }
        void Update()
        {
            float iH = Input.GetAxis("Horizontal");
            float iV = Input.GetAxis("Vertical");
            float camY = Camera.main.transform.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0, camY, 0);
            Vector3 iDir = rot * new Vector3(iH, 0f, iV);
            rigi.AddForce(iDir * movementSpeed);
        }
    }
}

