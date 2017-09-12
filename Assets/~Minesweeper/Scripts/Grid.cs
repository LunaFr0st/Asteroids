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
        public Camera cam;

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
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);//Camera.current.ScreenPointToRay(new Vector3(1, 1));
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    Debug.Log("Clicked " + hit.transform.name);
                    Tile hitTile = hit.collider.GetComponent<Tile>();
                    if (hitTile != null)
                    {
                        
                    }
                    Debug.Log("Destroyed");
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
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = t.x + x;
                    int desiredY = t.y + y;
                    if (desiredX >= 0 && desiredY >=0 && desiredX < width && desiredY < height)
                    {
                        Tile tile = GetComponent<Tile>();
                        tile = tiles[desiredX, desiredY];
                        if (tile.isMine)
                        {
                            count = count + 1;
                        }
                    }
                }
            }
            return count;
        }
        public void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (visited[x, y])
                {
                    return;
                }
            }
            Tile tile = GetComponent<Tile>();
            tile = tiles[x, y];
            int adjacentMines = GetAdjacentMineCountAt(tile);
            tile.Reveal(adjacentMines);
            if (adjacentMines > 0)
            {
                return;
            }
            visited[x, y] = true;

            FFuncover(x - 1, y, visited);
            FFuncover(x + 1, y, visited);
            FFuncover(x, y - 1, visited);
            FFuncover(x, y + 1, visited);
        }

        public void UncoverMines(int mineState)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile currentTile = tiles[x, y];
                    if (currentTile.isMine)
                    {
                        int adjacentMines = GetAdjacentMineCountAt(currentTile);
                        currentTile.Reveal(adjacentMines, mineState);
                    }
                }
            }
        }

        bool NoMoreEmptyTiles()
        {
            int emptyTileCount = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile currentTile = tiles[x, y];
                    if(!currentTile.isRevealed && !currentTile.isMine)
                    {
                        emptyTileCount = emptyTileCount + 1;
                    }
                }
            }
            return emptyTileCount == 0;
        }

        public void SelectTile(Tile selectedTile)
        {
            int adjacentMines = GetAdjacentMineCountAt(selectedTile);
            selectedTile.Reveal(adjacentMines);
            if (selectedTile.isMine)
            {
                UncoverMines(0);

            }
            else if (adjacentMines == 0)
            {
                int x = selectedTile.x;
                int y = selectedTile.y;
                FFuncover(x, y, new bool[width, height]);
            }
            if (NoMoreEmptyTiles())
            {
                UncoverMines(1);

            }
        }
    }
}

