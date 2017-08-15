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
        public Vector2 spacing = new Vector2(25f, 10f);
        public Vector2 offset = new Vector2(-25f, 10f);

        [Header("Debug")]
        public bool isDebugging = false;
        private GameObject[,] spawnedBlocks;

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
            spawnedBlocks = new GameObject[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GameObject block = GetRandomBlock();
                    Vector2 pos = new Vector3(x * spacing.x, y * spacing.y);
                    block.transform.position = pos;
                    spawnedBlocks[x, y] = block;
                }
            }
        }

        void UpdateBlocks()
        {
            //loop through entire 2d array
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //update Positions
                    GameObject currentBlock = spawnedBlocks[x, y];
                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    pos += offset;
                    currentBlock.transform.position = pos;
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (isDebugging)
            {
                UpdateBlocks();
            }
        }
    }
}

