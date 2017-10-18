using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using Tetris.Content;
using Tetris;

enum GameState
{
    Menu, PlayOriginal, GameOver
}

class GameWorld
{


    int screenWidth, screenHeight;

    public static GameState gameState;

    public Menu menu;
    public TetrisGrid grid;
    public GameOver gameover;

    SpriteFont font;
    Texture2D block, playOriginal, exitbutton, menubutton;
       
    
    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;

        gameState = GameState.Menu;

        font = Content.Load<SpriteFont>("SpelFont");
        block = Content.Load<Texture2D>("block_sprite");
        playOriginal = Content.Load<Texture2D>("playOriginal");
        exitbutton = Content.Load<Texture2D>("exitbutton");
        menubutton = Content.Load<Texture2D>("menubutton");

        menu = new Menu(playOriginal, exitbutton);
        grid = new TetrisGrid(block, font, exitbutton);
        gameover = new GameOver(exitbutton, menubutton);

    }

    public void Reset()
    {
        
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
    }

    public void Update(GameTime gameTime)
    {
        if (gameState == GameState.Menu)
            menu.Update(gameTime);

        if (gameState == GameState.PlayOriginal)
            grid.Update(gameTime);

        if (gameState == GameState.GameOver)
            gameover.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        if (gameState == GameState.Menu)
        {
            menu.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }


        if (gameState == GameState.PlayOriginal)
        {
            grid.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
       

        if (gameState == GameState.GameOver)
        {
            gameover.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        spriteBatch.End();
    }

    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }
}
