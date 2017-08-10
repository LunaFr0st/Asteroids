using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public GameObject[] blockPrefabs;


        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }

        // Function with Arguments
      /*  GameObject GetBlockByIndex(int index)
        {
            if (index > blockPrefabs.Length || index < 0)
            {
                return null;
            }
            GameObject clone = Instantiate(blockPrefabs[index]);
            return clone;
        }*/

        GameObject GetRandomBlock()
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            return clone;
            
        }
        void GenerateBlocks()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GameObject block = GetRandomBlock();
                    Vector3 pos = new Vector3(x, y, 0);
                    block.transform.position = pos;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

