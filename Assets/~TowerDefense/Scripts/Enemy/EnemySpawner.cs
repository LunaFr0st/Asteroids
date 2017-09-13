using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab; // Prefab for the Enemey AI
        public Transform target; // AI End Goal
        public float spawnRate = 1f; // rate of spawn
        public float spawnRadius = 1f; // Area of spawn

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue; // Sets Gizmo Colour to Blue
            Gizmos.DrawWireSphere(transform.position, spawnRadius); // Shows the Spawn radius
        }
        void Spawn()
        {
            GameObject clone = Instantiate(aiAgentPrefab); // Sets the Clone to be a Copy of the Prefab
            Vector3 rand = Random.insideUnitSphere; // Random position to spawn within Spawn Radius
            rand.y = 0; // sets the Y position to be 0 so no Flying Enemies
            clone.transform.position = transform.position + rand * spawnRadius; // Sets the position to be random within the Spawn Radius
            EnemyAI enemyAI = clone.GetComponent<EnemyAI>(); // Gets the Enemy AI Component
            enemyAI.target = target; // Sets the target to be whatever the EnemyAI's target is           
        }
        void Start()
        {
            InvokeRepeating("Spawn", 0, spawnRate); // Sets the function to Repeat constantly at a certain rate.
        }
    }
}

