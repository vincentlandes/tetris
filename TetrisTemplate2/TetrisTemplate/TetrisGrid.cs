using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Tetris;
using Microsoft.Xna.Framework.Input;

//a class for representing the Tetris playing grid
class TetrisGrid
{

    //Block variable
    Blocks blocks;
    int blockSize = 30;    
    Texture2D gridblock;
    public int[,] SpawnedPiece;
    public int[,] secPiece;
    int blockLength;
    int secblockLength;
    private Vector2 SpawnedPieceLocation;
    private Vector2 secPieceLocation;
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

        CreateBlock();
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

    public void CreateBlock()
    {
        int offset = rndBlock.Next(8);
        SpawnedPiece = (int[,])Blocks.Pieces[blockOrder[0]];
        blockLength = SpawnedPiece.GetLength(0);


        for (int y = 0; y < blockLength; y++)
        {
            for (int x = 0; x < blockLength; x++)
            {
                mainGrid[x + offset, y] = SpawnedPiece[x, y];
               
            }
        }
        SpawnedPieceLocation.X = offset;
        AddSpawnList();
    }

    private void AddSpawnList()
    {
        blockOrder.RemoveAt(0);
        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));
    }

    public void MoveBlock()
    {
        //check eerst of het nog binnen de grid is
        if (TetrisGame.inputHelper.KeyPressed(Keys.Right))
        {
            for (int y = blockLength; y >= 0; y--)
            {
                for (int x = blockLength; x >= 0 ; x--)
                {
                    if ((int)SpawnedPieceLocation.X + 1 + x < Width){
                        if (mainGrid[x + (int)SpawnedPieceLocation.X + 1, y] == 0)
                        {
                            mainGrid[x + (int)SpawnedPieceLocation.X + 1, y] = mainGrid[x + (int)SpawnedPieceLocation.X, y];
                            mainGrid[x + (int)SpawnedPieceLocation.X, y] = 0;
                        } }

                }
            }
            SpawnedPieceLocation.X++;
        }

        // ga naar links
    
        //if right arrow is pressed
        // ga naar rechts

        //standaard naar beneden gaan
    }

    //Check if a row is full
    private void CheckRow()
    {
        //Check form the bottem to the top
        for (int y = Height; y >= 0 ; y--)
        {
            bool completeRow = true;
            for (int x = 0; x < Width; x++)
            {
                //When there is a empty spot in a row
                if (mainGrid[x, y] == 0)
                    completeRow = false;
            }
            //When a row is completely full
            if (completeRow)
            {
                DeleteRow(y);
                y++; //<-- rij terug zetten omdat het kan gebeuren dat er twee rijen tegelijk vol zijn en dan zou de onderste rij verwijderd worden, de rij daar boven op die rij worden gezet, en dan de CheckRow functie een omhoog zou gaan, en daardoor word die rij ook niet meer gecontroleerd.
                //Score + 100
            }
        }
    }

    //Deletes a row
    private void DeleteRow(int row)
    {
        for (int y = row; y >= 0 ; y--)
        {
            for (int x = 0; x < Width; x++)
            {
                //zet de waardes van de rij er boven in de huidige rij
                mainGrid[x, y] = mainGrid[x, y - 1];
            }
        }
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
                    Color secblockColor = Blocks.BlockColor[secGrid[x, y]];
                    s.Draw(gridblock, new Vector2(secGridPosition.X + x * blockSize, secGridPosition.Y + y * blockSize), secblockColor);
                }
            }
        }

        
    }
}

