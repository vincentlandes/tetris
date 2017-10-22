using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGame : Game
{
    SpriteBatch spriteBatch;
    public static InputHelper inputHelper;
    public static GameWorld gameWorld;
    

    [STAThread]
    static void Main(string[] args)
    {
        TetrisGame game = new TetrisGame();
        game.Run();
    }

    public TetrisGame()
    {
        // initialize the graphics device
        GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);

        // set the directory where game assets are located
        this.Content.RootDirectory = "Content";

        // set the desired window size
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;

        // create the input helper object
        inputHelper = new InputHelper();    
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // create and reset the game world
        gameWorld = new GameWorld(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content);
        IsMouseVisible = true;
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        gameWorld.Update(gameTime);
        if (gameWorld.menu.ExitGame)
            Exit();
        if (gameWorld.grid.ExitGame)
            Exit();
        if (gameWorld.gameover.ExitGame)
            Exit();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        gameWorld.Draw(gameTime, spriteBatch);
    }
}
