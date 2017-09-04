using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        public Transform spawnPoint; // Sets the Spawnpoint of the Board.
        public GameObject tilePrefab; // Allows us to set the Tile Prefab
        public int width = 10; // Sets the HWidth for the Minesweeper Board
        public int height = 10; //  Sets the Height for the Minesweeper Board
        public float spacing = 0.155f; // Sets the spacing between each tile

        private Tile[,] tiles; // Creates a 2D array using the tiles set in the Arrays in Tile.cs

        void Start()
        {

            GenerateTile(); // Generate the tiles on startup.
        }

        void Update()
        {
            // I lost my Script where you showed me how to get this working.
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                    Destroy(hit.collider);
                }
            }
        }

        Tile SpawnTile(Vector3 pos)
        {
            GameObject clone = Instantiate(tilePrefab); // Instantiates a new clone of the Tile Prefab
            clone.transform.position = pos; // Sets the Position of clone to the position of pos.
            Tile currentTile = clone.GetComponent<Tile>(); // Sets the component for the clone to be Tile
            return currentTile; // Returns the tile.
        }
        void GenerateTile()
        {
            tiles = new Tile[width, height]; // sets tiles to be a new Array for Tile containing the Width and Height
            for (int x = 0; x < width; x++) // Loops through entire list of tiles on x axis
            {
                for (int y = 0; y < height; y++) // Loops through enture list of tiles on y axis
                {
                    Vector2 halfSize = new Vector2(width / 2, height / 2); // Stores half the board size for later.
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y); // Pivots the Tiles around the grid.
                    pos *= spacing; // apply the spacing for tiles.
                    Tile tile = SpawnTile(pos); // Spawns the tile
                    tile.transform.SetParent(transform); // Attach the tile to the transform
                    tile.x = x; // Sets coordinates on x axis for future refrence
                    tile.y = y; // Sets coordinates on y axis for future refrence
                    tiles[x, y] = tile; // Store the tile in an array at those coordinates
                }
            }
        }
        // Didn't undetstand how to do Within Range things.
        public int GetAdjactentMineCountAt(Tile t)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                int desiredX = t.x + x;
                /*if(desiredX = tiles[0, 9])
                {

                }*/
            }
            return count;
        }
    }
}

