﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Tetris;

//a class for representing the Tetris playing grid
class TetrisGrid
{
    int blockSize = 30;
    Vector2 gridPosition = Vector2.Zero;
    int[,] grid;

    List<Blocks> pieces;

    //sprite for representing a single grid block
    Texture2D gridblock;

    //the position of the tetris grid
    Vector2 position;

    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        grid = new int[Width, Height];
        this.Clear();
 
        pieces = new List<Blocks>();

        grid[1, 1] = 1;
        grid[4, 7] = 5;

    }
    
    //width in terms of grid elements
    public int Width
    {
        get { return 12; }
    }

    //height in terms of grid elements
    public int Height
    {
        get { return 20; }
    }

    //clears the grid
    public void Clear()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                grid[x, y] = 0;
            }
        }
    }

    private void SwitchCase()
    {
        Random rndBlock = new Random();
        
        switch ( 6 /*rndBlock.Next(5)*/)
        {
            case 0:
                pieces.Add(new Iblock());
                break;
            case 1:
                pieces.Add(new Jblock());
                break;
                
            case 2:
                pieces.Add(new Zblock());
                break;
            case 3:
                pieces.Add(new Oblock());
                break;
            case 4:
                pieces.Add(new Sblock());
                break;
            case 5:
                pieces.Add(new Tblock());
                break;
            case 6:
                pieces.Add(new Testblock());
                break;
        }
    }

    //draws the grid on the screen
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        //draw the grid
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Color blockColor = Blocks.BlockColor[grid[x, y]];

                s.Draw(gridblock, new Vector2(x * blockSize, y * blockSize), blockColor);

            }
        }
    }
}

