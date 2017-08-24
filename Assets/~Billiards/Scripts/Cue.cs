using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Cue : MonoBehaviour
    {
        public Ball targetBall; // target ball selected, which should be the Cue Ball
        public float minPower = 0f; // the minimum power which is map to the distance
        public float maxPower = 20f; // the maximum power which is applied by mapping the distance
        public float maxDistance = 5f; //The maxium distance in units the cue can be dragged back

        private float hitPower; // the final calculated hit power when firing the ball
        private Vector3 aimDirection; // direction where the ball should fire
        private Vector3 prevMousePos; // the mouse position obtained when left-clicking
        private Ray mouseRay; // the ray of the mouse

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Check if left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                //Store the click position as the previousMousePos
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                //Perform drag mechanic
                Drag();
            }
            else
            {
                //Perform aim mechanic
                Aim();
            }
            if (Input.GetMouseButtonUp(0))
            {
                //Hit the ball
                Fire();
            }
        }
        // Creates Visualisation of the ray
        void OnDrawGizmos()
        {
            Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f); // Creates the line to visuales the ray
            Gizmos.color = Color.cyan; // Sets the Gizmo colour to Cyan
            Gizmos.DrawLine(targetBall.transform.position, targetBall.transform.position + aimDirection * hitPower); // Draws the line where the ball will end up with the hit power
        }
        // Rotates the vue to wherever the mouse is pointing using raycast
        void Aim()
        {
            // Calculate mouse ray before performing the raycast
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Raycast Hit Container for the hit information
            RaycastHit hit;
            // perform the raycast
            if (Physics.Raycast(mouseRay, out hit))
            {
                //Obtain direction from the cue's position to the raycast's hit point
                Vector3 dir = transform.position - hit.point;
                //Convert direction to angle in degrees
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                //rotate to the new angle
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                //Position cue to the ball's position
                transform.position = targetBall.transform.position;
            }
        }
        // Deactivate the cue
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        // Activate the cue
        public void Activate()
        {
            Aim();
            gameObject.SetActive(true);
        }
        void Drag()
        {
            //Store Target Ball's Position in smaller variable
            Vector3 targetPos = targetBall.transform.position;
            //Get mouse position in world units
            Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Calculate distance from previous mouse posiition to the current mouse position
            float distance = Vector3.Distance(prevMousePos, currentMousePos);
            //Clamp the distance between 0 minus maxDistance
            distance = Mathf.Clamp(distance, 0, maxDistance);
            //Calculate a percentage for the distance
            float distancePercentage = distance / maxDistance;
            //Use percentage of distance to map to the minPower minus maxPower values
            hitPower = Mathf.Lerp(minPower, maxPower, distancePercentage);
            //Position the cue back using distance
            transform.position = targetPos - transform.forward * distance;
            //Get direction ot target the ball
            aimDirection = (targetPos - transform.position).normalized;
        }
        //Fires off the ball
        void Fire()
        {
            //Hit the ball with direction and Power
            targetBall.Hit(aimDirection, hitPower);
            //Deactivate the cue when done
            Deactivate();
        }
    }
}

