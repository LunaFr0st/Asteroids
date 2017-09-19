using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AHundredBalls
{
    public class Paddle : MonoBehaviour
    {
        public bool opened = false;
        private Animator anim;
        void Start()
        {
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                opened = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                opened = false;
            }
        }
        void UpdateAnimation()
        {
            anim.SetBool("IsOpen", opened);
        }
    }
}

