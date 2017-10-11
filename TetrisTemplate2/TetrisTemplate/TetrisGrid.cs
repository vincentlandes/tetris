using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Tetris;

//a class for representing the Tetris playing grid
class TetrisGrid
{

    //Block variable
    Blocks blocks;
    int blockSize = 30;    
    Texture2D gridblock;
    public int[,] SpawnedPiece;
    public int blockLength;
    private Vector2 SpawnedPieceLocation;
    public static List<int> blockOrder = new List<int>();

    //Grid variable
    int[,] mainGrid;
    Vector2 mainGridPosition = new Vector2(30,0);
    int[,] secGrid;
    Vector2 secGridPosition = new Vector2(420, 60);

    //
    Random rndBlock;

    public TetrisGrid(Texture2D block)
    {
        //Make a new grid and clear it
        mainGrid = new int[Width, Height];
        secGrid = new int[4, 4];
        this.Clear();
        //Add the blocks to the list
        blocks = new Blocks();
        blocks.AddBlocksToList();
        //
        gridblock = block;
        rndBlock = new Random();

        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));
        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));

        SpawnBlock();
    }

    //Width in terms of grid elements
    public int Width
    {
        get { return 12; }
    }

    //Height in terms of grid elements
    public int Height
    {
        get { return 20; }
    }

    public void SpawnBlock()
    {
        CreateBlock();
        int offset = rndBlock.Next(8);
        for (int x = 0; x < blockLength; x++)
        {
            for (int y = 0; y < blockLength; y++)
            {
                mainGrid[x + offset , y] = SpawnedPiece[x, y];
            }
        }
    }

    public void CreateBlock()
    {
        int color = blockOrder[0];

        SpawnedPiece = (int[,])Blocks.Pieces[color].Clone();
        blockLength = SpawnedPiece.GetLength(0);

        for (int x = 0; x < blockLength; x++)
        {
            for (int y = 0; y < blockLength; y++)
            {
                SpawnedPiece[x, y] *= (color + 1);
                SpawnedPieceLocation = Vector2.Zero;
            }
        }
        AddSpawnList();
    }

    private void AddSpawnList()
    {
        blockOrder.RemoveAt(0);
        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));
    }

    private void MoveBlock()
    {
        // check of die geplaatst kan worden en of die binnen het grid is
        //if left arrow is pressed
        // ga naar links
        //if right arrow is pressed
        // ga naar rechts

        //standaard naar beneden gaan



    }

    //Clears the grid
    public void Clear()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                mainGrid[x, y] = 0;
                if (secGrid.GetLength(0) > x && secGrid.GetLength(1) > y)
                {
                    secGrid[x, y] = 0;
                }
            }
        }
    }

    //Draws the grid on the screen
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        //draw the grid
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Color blockColor = Blocks.BlockColor[mainGrid[x, y]];

                s.Draw(gridblock, new Vector2(mainGridPosition.X + x * blockSize, mainGridPosition.Y + y * blockSize), blockColor);
                if (secGrid.GetLength(0) > x && secGrid.GetLength(1) > y)
                {
                    //s.Draw(gridblock, new Vector2(secGridPosition.X + x * blockSize, secGridPosition.Y + y * blockSize), blockColor);
                }
            }
        }
    }
}

