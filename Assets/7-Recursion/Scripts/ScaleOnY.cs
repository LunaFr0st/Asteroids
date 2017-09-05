using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Recursion
{
    public class ScaleOnY : MonoBehaviour
    {
        public float maxY = 500f;
        public float maxScale = 100f;
        private float percentY = 0;
        void Start()
        {

        }
        void OnCollisionEnter(Collision col)
        {

        }
        void Update()
        {
            Vector3 scale = transform.localScale;
            Vector3 pos = transform.position;

            float yPercent = pos.y / maxY;
            float invertYPercent = 1 - yPercent;
            float scaleFactor = maxScale * invertYPercent;
            scale = Vector3.one * scaleFactor;
            transform.localScale = scale;
        }
    }
}

