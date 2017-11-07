using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{
    [RequireComponent(typeof(PlayerController))]
    public class UserInput : MonoBehaviour
    {
        private PlayerController pController;
        void Awake()
        {
            pController = GetComponent<PlayerController>();
        }
        void Update()
        {
            float iH = Input.GetAxis("Horizontal");
            float iV = Input.GetAxis("Vertical");
            pController.Move(iH, iV);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pController.Jump();
            }
        }
    }
}
