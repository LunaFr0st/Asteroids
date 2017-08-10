using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public string msg = "You got Mail";
        public float frequency = 6f;
        public float amplitude = 12f;



        private float timer = 0;
        public float printTime = 2f;

        public GameObject spawnPrefab;
        public float spawnRadius = 5f;
        public int enemyCount = 10;

        public GameObject[] spawnPrefabs;


        // Use this for initialization
        void Start()
        {
            SpawnObjectsWithSine();
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer <= printTime)
            {
                print(msg);
            }
        }
        void SpawnObjectsWithSine()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int randomIndex = Random.Range(0, spawnPrefabs.Length);

                float x = Mathf.Sin(i * frequency) * amplitude;               //float x = Mathf.Sin(Mathf.Cos(Mathf.Tan(i * Time.deltaTime))) * enemyCount;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);

                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);

                rend.material.color = new Color(r, g, b);

                Vector3 randomPos = transform.position + new Vector3(x, y, z); //Random.insideUnitSphere * spawnRadius;
                clone.transform.position = randomPos;

            }
        }
    }
}

