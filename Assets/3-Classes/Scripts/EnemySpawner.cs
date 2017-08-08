using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Classes
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public float spawnRate = 1f;
        public float spawnRadius = 1f;
        public float force = 300f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            //InvokeRepeating(functionName, time, repeatingRate);
            //functionName = name of function you wish to be called in the class.
            //time = the delay for when you want the function to start.
            //repeatingRate = the rate at which it repeats itself after the previous call.
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void Spawn()
        {
            //Instaniate a new gameObject.
            GameObject enemy = Instantiate(enemyPrefab);
            //Position it to a random place with in the spawn radius.
            enemy.transform.position = Random.insideUnitCircle * spawnRadius;
            //Apply Force to a rigidbody2d randomly
            Rigidbody2D Rigid = enemy.GetComponent<Rigidbody2D>();
            Rigid.AddForce(Random.insideUnitCircle * force);
            
        }
    }
}

