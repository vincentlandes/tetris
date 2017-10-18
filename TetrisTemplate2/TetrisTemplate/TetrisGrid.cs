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

    //Variable    
    //Block variable
    Blocks blocks;
    int blockSize = 30;
    Texture2D gridblock;

    //Main Block variable
    public int[,] SpawnedPiece;
    int blockLength;
    private Vector2 SpawnedPieceLocation;
    int Timer = 0;
    int TimerEnd = 400;

    //Second Block variable
    public int[,] secPiece;
    int secblockLenght;

    //Block Order variable
    public static List<int> blockOrder = new List<int>();
    Random rndBlock;

    //Main Grid variable
    int[,] mainGrid;
    Vector2 mainGridPosition = new Vector2(30, 0);

    //Second Grid variable
    int[,] secGrid;
    Vector2 secGridPosition = new Vector2(420, 60);

    //Score
    int Score = 0;
    Vector2 ScorePosition = new Vector2(420, 200);
    SpriteFont font;
    Texture2D exitButton;
    Vector2 exitButtonPos = new Vector2(420, 500);
    public bool ExitGame;

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
   

    //
    public TetrisGrid(Texture2D block, SpriteFont spriteFont, Texture2D ExitButton)
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

        //
        font = spriteFont;
        exitButton = ExitButton;

        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));
        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));

        SpawnPiece();
    }


    //Create a new block
    private void SpawnPiece()
    {
        SpawnedPiece = Blocks.Pieces[blockOrder[0]];
        blockLength = SpawnedPiece.GetLength(0);
        SpawnedPieceLocation = new Vector2(6, 0);

        secPiece = Blocks.Pieces[blockOrder[1]];
        secblockLenght = secPiece.GetLength(0);
        for (int x = 0; x < secGrid.GetLength(0); x++)
        {
            for (int y = 0; y < secGrid.GetLength(1); y++)
            {
                if (x < secblockLenght && y < secblockLenght)
                    secGrid[x, y] = secPiece[x, y];
                else
                    secGrid[x, y] = 0;
            }
        }
    }

    //Add a new block to the spawn list
    private void AddSpawnList()
    {
        blockOrder.RemoveAt(0);
        blockOrder.Add(rndBlock.Next(0, Blocks.Pieces.Count));
    }



    //
    public void Update(GameTime gameTime)
    {
        MoveBlock(gameTime);
        CheckRow();

        if (TetrisGame.inputHelper.MouseLeftButtonPressed())
        {
            if (TetrisGame.inputHelper.CheckButtonPressed((int)exitButtonPos.X, (int)exitButtonPos.Y))
                Exit();
        }
    }


    //Check for movement
    private void MoveBlock(GameTime gameTime)
    {
        //Rotate Piece
        if (TetrisGame.inputHelper.KeyPressed(Keys.A))
        {
            RotatePiece(SpawnedPiece, false);
        }

        if (TetrisGame.inputHelper.KeyPressed(Keys.D))
        {
            RotatePiece(SpawnedPiece, true);
        }

        //Move block to the right
        if (TetrisGame.inputHelper.KeyPressed(Keys.Right))
        {
            Vector2 NextSpawnPieceLocation = SpawnedPieceLocation + new Vector2(1, 0);

            if (PlaceFree((int)NextSpawnPieceLocation.X, (int)NextSpawnPieceLocation.Y))
                SpawnedPieceLocation = NextSpawnPieceLocation;
        }

    //Move Block to the left
        if (TetrisGame.inputHelper.KeyPressed(Keys.Left))
        {
            Vector2 NextSpawnPieceLocation = SpawnedPieceLocation + new Vector2(-1, 0);

            if (PlaceFree((int)NextSpawnPieceLocation.X, (int)NextSpawnPieceLocation.Y))
                SpawnedPieceLocation = NextSpawnPieceLocation;
        }

        //Move Block Down
        Timer += gameTime.ElapsedGameTime.Milliseconds;

        if (Timer >= TimerEnd)
        {
            Vector2 NextSpawnPieceLocation = SpawnedPieceLocation + new Vector2(0, 1);

            if (PlaceFree((int)NextSpawnPieceLocation.X, (int)NextSpawnPieceLocation.Y))
                SpawnedPieceLocation = NextSpawnPieceLocation;

            Timer = 0;
        }

        //Move Block down faster
        if (TetrisGame.inputHelper.KeyPressed(Keys.Down))
        {
            Timer = TimerEnd;
        }

        //Place block on the floor when pressing UP
        if (TetrisGame.inputHelper.KeyPressed(Keys.Up))
        {
            bool FloorLocation = true;
            while(FloorLocation)
            {
            Vector2 NextSpawnPieceLocation = SpawnedPieceLocation + new Vector2(0, 1);

            if (PlaceFree((int)NextSpawnPieceLocation.X, (int)NextSpawnPieceLocation.Y))
                SpawnedPieceLocation = NextSpawnPieceLocation;
            else
                FloorLocation = false;
            }
        }
    }

    //Check if the block can move to the next position
    private bool PlaceFree(int nextSpawnPieceLocationX, int nextSpawnPieceLocationY)
    {
        for (int y = 0; y < blockLength; y++)
        {
            for (int x = 0; x < blockLength; x++)
            {
                int nextX = nextSpawnPieceLocationX + x;
                int nextY = nextSpawnPieceLocationY + y;

                if (SpawnedPiece[x, y] != 0)
                {
                    if (nextX < 0 || nextX >= Width || mainGrid[nextX, (int)SpawnedPieceLocation.Y + y] != 0)
                    {
                        return false;
                    }
                    
                    if (nextY >= Height || mainGrid[(int)SpawnedPieceLocation.X + x, nextY] != 0)
                    {
                            PlaceBlockInGrid();
                        return false;
                    }
                }
            }
        }
        return true;
    }

    //Place block in grid
    private void PlaceBlockInGrid()
    {
        for (int x = 0; x < blockLength; x++)
        {
            for (int y = 0; y < blockLength; y++)
            {
                if (SpawnedPiece[x, y] != 0)
                {
                    mainGrid[(int)SpawnedPieceLocation.X + x, (int)SpawnedPieceLocation.Y + y] = SpawnedPiece[x, y];
                    for (int px = 0; px < Width; px++)
                    {
                        if (mainGrid[px, 0] != 0)
                            GameWorld.gameState = GameState.GameOver;
                    }
                }
            }
        }
        AddSpawnList();
        SpawnPiece();
    }

    //Rotate Piece
    private void RotatePiece(int[,] spawnedPiece, bool rotationDirection)
    {
        int[,] rotatedPiece = new int[blockLength, blockLength];
        for (int x = 0; x < blockLength; x++)
        {
            for (int y = 0; y < blockLength; y++)
            {
                if (rotationDirection)
                    rotatedPiece[y, x] = spawnedPiece[x, blockLength - 1 - y];
                else
                    rotatedPiece[y, x] = spawnedPiece[blockLength - 1 - x, y];
            }
        }

        SpawnedPiece = rotatedPiece;

        if (!PlaceFree((int)SpawnedPieceLocation.X, (int)SpawnedPieceLocation.Y))
            SpawnedPiece = spawnedPiece;
    }




    //Check if a row is full
    private void CheckRow()
    {
        //Check form the bottem to the top
        for (int y = Height - 1; y >= 0; y--)
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
                y++;
                Score += 100;
            }
        }
    }

    //Deletes a row
    private void DeleteRow(int row)
    {
        for (int y = row; y > 0; y--)
        {
            for (int x = 0; x < Width; x++)
            {
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
                Color pieceColor = Blocks.PieceColor[mainGrid[x, y]];

                s.Draw(gridblock, new Vector2(mainGridPosition.X + x * blockSize, mainGridPosition.Y + y * blockSize), pieceColor);

                if (x < secGrid.GetLength(0) && y < secGrid.GetLength(1))
                {
                    Color secpieceColor = Blocks.PieceColor[secGrid[x, y]];
                    s.Draw(gridblock, new Vector2(secGridPosition.X + x * blockSize, secGridPosition.Y + y * blockSize), secpieceColor);
                }
            }
        }

        for (int y = 0; y < blockLength; y++)
        {
            for (int x = 0; x < blockLength; x++)
            {
                if(SpawnedPiece[x,y] != 0)
                {
                    Color pieceColor = Blocks.PieceColor[SpawnedPiece[x, y]];

                    s.Draw(gridblock, new Vector2(mainGridPosition.X + (SpawnedPieceLocation.X + x) * blockSize, mainGridPosition.Y + (SpawnedPieceLocation.Y + y) * blockSize), pieceColor);
                }
            }
        }

        s.DrawString(font, "Score: " + Score, new Vector2(ScorePosition.X, ScorePosition.Y), Color.Black);

        s.Draw(exitButton, new Vector2(exitButtonPos.X, exitButtonPos.Y), Color.White);
    }

    private void Exit()
    {
        ExitGame = true;
    }
}

