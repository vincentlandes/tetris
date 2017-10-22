using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
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
    Texture2D block, playOriginal, exitbutton, menubutton, menubackground, gamebackground, gameoverbackground;
    SoundEffect placeBlock, deleteRow;
       
    
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

        menubackground = Content.Load<Texture2D>("MenuBackground");
        gamebackground = Content.Load<Texture2D>("GameBackground");
        gameoverbackground = Content.Load<Texture2D>("GameOverBackground");

        placeBlock = Content.Load<SoundEffect>("placeBlock");
        deleteRow = Content.Load<SoundEffect>("deleteRow");

        menu = new Menu(playOriginal, exitbutton, menubackground);
        grid = new TetrisGrid(block, font, exitbutton, placeBlock, gamebackground, deleteRow);
        gameover = new GameOver(exitbutton, menubutton, gameoverbackground);

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
}
