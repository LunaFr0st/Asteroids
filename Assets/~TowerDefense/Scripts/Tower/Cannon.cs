using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public Transform b; // Refrences the Barrel
        public GameObject pF; // Prefab of the Projectile
        public void Fire(Enemy tE) // Custom Fire Funtion with Variable to refrence the Enemy Script
        {
            Vector3 tP = tE.transform.position; // Sets the Targets position
            Vector3 bP = b.position; // sets the Position to be the barrels position
            Quaternion bR = b.rotation; // sets the rotation to be the Barrels rotation
            Vector3 fD = tP - bP; // Follows Target Position
            Quaternion cR = Quaternion.LookRotation(fD, Vector3.up);
            GameObject clone = Instantiate(pF, bP, bR);
            Projectile p = GetComponent<Projectile>();
            p.direction = fD;
        }
    }
}

