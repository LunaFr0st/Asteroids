using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class CameraBounds : MonoBehaviour
    {
        public Vector3 size = new Vector3(50f, 18f, 80f);
        public Vector3 GetAdjustedPos(Vector3 incomingPos)
        {
            Vector3 pos = transform.position;
            Vector3 halfSize = size * 0.5f;
            
            if (incomingPos.x > pos.x + halfSize.x) // Is incomingPos.x outside positive x?
                incomingPos.x = pos.x + halfSize.x;
            if (incomingPos.x < pos.x - halfSize.x) // Is incomingPos.x outside negatve x?
                incomingPos.x = pos.x - halfSize.x;

            if (incomingPos.y > pos.y + halfSize.y) // Is incomingPos.y outside positive y?
                incomingPos.y = pos.y + halfSize.y;
            if (incomingPos.y < pos.y - halfSize.y) // Is incomingPos.y outside negatve y?
                incomingPos.y = pos.y - halfSize.y;

            if (incomingPos.z > pos.z + halfSize.z) // Is incomingPos.z outside positive z?
                incomingPos.z = pos.z + halfSize.z;
            if (incomingPos.z < pos.z - halfSize.z) // Is incomingPos.z outside negatve z?
                incomingPos.z = pos.z - halfSize.z;

            return incomingPos;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, size);
        }
    }
}