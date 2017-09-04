using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        public int x = 0; // X Coordinate for Array
        public int y = 0; // Y Coordinate for Array
        public float minePercentage = 0.05f;
        public bool isMine = false; // Is the current tile a mine
        public bool isRevealed = false; // Has the tile been clicked and need revealed?
        [Header("Refrences")]
        public Sprite[] emptySprites; // List of empty sprites
        public Sprite[] mineSprites; // The Mine sprites

        private SpriteRenderer rend;

        void Awake()
        {
            rend = GetComponent<SpriteRenderer>(); // Gets the Component for Sprite Renderer and sets it to "rend"
        }

        void Start()
        {
            isMine = Random.value < minePercentage; // Sets the Mine to have a custom % chance of spawning 
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            isRevealed = true; // Flags the Tile as revealed
            if (isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}

