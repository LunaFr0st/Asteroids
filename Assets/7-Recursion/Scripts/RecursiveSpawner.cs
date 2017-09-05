using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{
    public class RecursiveSpawner : MonoBehaviour
    {
        public GameObject spawnPrefab;
        public int amount = 100;
        public float positionOffset = 10f;
        [Range(0, 1)]
        public float percentageReduction = 0.2f;
        void Start()
        {
            Vector3 pos = transform.position;
            Vector3 scale = spawnPrefab.transform.localScale;
            RecursiveSpawn(amount, pos, scale);
        }

        void RecursiveSpawn(int currentAmount, Vector3 position, Vector3 scale)
        {
            Vector3 adjustedScale = scale * (1 - percentageReduction);
            Vector3 adjustedPosition = position + Vector3.up * (adjustedScale.magnitude * positionOffset);
            GameObject clone = Instantiate(spawnPrefab); // Instantiates the Prefab
            clone.transform.position = adjustedPosition; // Sets the Position to the Adjusted Position
            clone.transform.localScale = adjustedScale; // Sets the local scale to the adjusted scale

            amount--; // Decrement
            if(amount <= 0)
            {
                return;
            }
            RecursiveSpawn(currentAmount, adjustedPosition, adjustedScale);
        }

    }
}

