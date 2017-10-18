using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using Tetris.Content;

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

    SpriteFont font;
    Texture2D block, playOriginal, exitbutton;
       
    
    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;

        gameState = GameState.Menu;

        font = Content.Load<SpriteFont>("SpelFont");
        block = Content.Load<Texture2D>("block_sprite");
        playOriginal = Content.Load<Texture2D>("playOriginal");
        exitbutton = Content.Load<Texture2D>("exitbutton");

        menu = new Menu(playOriginal, exitbutton);
        grid = new TetrisGrid(block, font, exitbutton);

    }

    public void Reset()
    {
        
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
    }

    public void Update(GameTime gameTime)
    {
        menu.Update(gameTime);
        grid.Update(gameTime);
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
            //
            spriteBatch.End();
        }

        spriteBatch.End();
    }

    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }
}
