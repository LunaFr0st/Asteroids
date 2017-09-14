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
            Enemy e = col.GetComponent<Enemy>(); // Refrences Enemy.cs into e
            if (e != null) // if Enemy exists
            {
                enemies.Add(e); // adds enemy to a list
            }

        }
        void OnTriggerExit(Collider col) // Allows the Detection to work
        {
            Enemy e = col.GetComponent<Enemy>(); // Refrences Enemy.cs into e
            if (e != null) // if Enemy exists
            {
                enemies.Remove(e); // remove enemy from list
            }
        }
        List<Enemy> RemoveAllNulls(List<Enemy> listWithNulls)
        {
            List<Enemy> listWithoutNulls = new List<Enemy>();
            foreach (Enemy enemies in listWithNulls)
            {
                if (enemies != null)
                {
                    listWithoutNulls.Add(enemies);
                }
            }
            return listWithoutNulls;
        }
        // DIDN'T UNDERSTAND HOW TO DO FOREACH STATEMENTS
        Enemy GetClosetEnemy() // Function to get the closest enemy
        {
            enemies = RemoveAllNulls(enemies);
            Enemy closest = null; // sets closest to be nothing as default
            float minDistance = float.MaxValue; // Sets the minDistance to be the MaxValue
            foreach (Enemy enemy in enemies) // For each Enemy in Enemies list
            {
                float distance = Vector3.Distance(c.transform.position, enemy.transform.position); // Sets the distance between the Cannon and the Enemy
                if (distance < minDistance) // if distance is less than minDistance
                {
                    minDistance = distance; // distance equals mindistance
                    closest = enemy; // closest enemy equals enemy
                }
            }
            return closest; // returns the value
        }
        void Attack() // Function for Attacking
        {
            Enemy closest = GetClosetEnemy(); // sets the closest refrence to start refrencing the GetClosestEnemy function
            if (closest != null) // if there is a enemy close
            {
                c.Fire(closest); // Attack
            }
        }
        void Update()
        {
            aT = aT + Time.deltaTime;
            if (aT >= aR)
            {
                Attack();
                aT = 0;
            }
        }
    }

}
