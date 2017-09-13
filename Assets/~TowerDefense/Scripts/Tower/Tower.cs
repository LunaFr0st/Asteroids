using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon c; // Refrence the Cannon inside the Tower
        public float aR = 0.25f; // Attack Rate
        public float aRad = 5f; // Distance of attack in world Units
        private float aT = 0f; // Timer to count up to aR
        private List<Enemy> enemies = new List<Enemy>(); // list of enemies within rad
        void OnTriggerEnter(Collider col)
        {
            Enemy e = GetComponent<Enemy>();
            if(e != null)
            {
                enemies.Add(e);
            }

        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Remove(e);
            }
        }
// DIDN'T UNDERSTAND HOW TO DO FOREACH STATEMENTS
        //Enemy GetClosetEnemy()
        //{
        //    Enemy closest = null;
        //    float minDistance = float.MaxValue;
        //    foreach(Enemy in enemies)
        //    {
                
        //    }
        //    return closest;
        //}
    }

}
