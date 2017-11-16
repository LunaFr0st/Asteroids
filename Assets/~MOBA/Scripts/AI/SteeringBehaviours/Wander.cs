using UnityEngine;
using System.Collections;

using GGL;

namespace MOBA
{
    public class Wander : SteeringBehaviour
    {
        public float offset = 1f;
        public float radius = 1f;
        public float jitter = 0.2f;
        private Vector3 targetDir;
        private Vector3 randDir;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
            float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
            #region Calculate RandomDirection
            randDir = new Vector3(randX, 0, randZ);
            randDir = randDir.normalized;
            randDir *= jitter;
            #endregion
            #region Calculate Target Direction
            targetDir += randDir;
            targetDir = targetDir.normalized;
            targetDir *= radius;
            #endregion
            Vector3 seekPos = transform.position + targetDir;
            seekPos += transform.forward * offset;
            #region GizmosGL
            Vector3 forwardPos = transform.position + transform.forward * offset;
            GizmosGL.color = Color.white;
            GizmosGL.AddCircle(forwardPos, radius, Quaternion.LookRotation(Vector3.down));
            GizmosGL.color = Color.red;
            GizmosGL.AddCircle(seekPos + (Vector3.up * 0.1f), radius * 0.6f, Quaternion.LookRotation(Vector3.down));
            #endregion
            #region Wander
            Vector3 dir = seekPos - transform.position;
            if(dir.magnitude > 0)
            {
                Vector3 desForce = dir.normalized * weighting;
                force = desForce - owner.velocity;
            }
            #endregion
            return force;
        }


    }
}