using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] asteroidPrefab;
        public float spawnRate = 1f;
        public float spawnRadius = 5f;
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        void Spawn()
        {
            Vector3 rand = Random.insideUnitSphere * spawnRadius;
            rand.z = 0;
            Vector3 pos = transform.position + rand;
            int randIndex = Random.Range(0, asteroidPrefab.Length);
            GameObject clone = Instantiate(asteroidPrefab[randIndex]);
            clone.transform.position = pos;
        }
        void Start()
        {
            InvokeRepeating("Spawn", 0f, spawnRate);
        }

    }
}

