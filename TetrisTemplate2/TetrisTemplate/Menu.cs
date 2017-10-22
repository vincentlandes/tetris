using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Tetris.Content
{
    class Menu
    {
        Texture2D playOriginal, exitButton, menubackground;

        Vector2 playOriginalPos;
        Vector2 exitButtonPos;

        public bool ExitGame = false;

        public Menu(Texture2D PlayOriginal, Texture2D Exitbutton, Texture2D menuBackground)
        {
            playOriginal = PlayOriginal;
            exitButton = Exitbutton;
            menubackground = menuBackground;

            playOriginalPos = new Vector2(150, 500);
            exitButtonPos = new Vector2(450, 500);
        }

        public void Update(GameTime gameTime)
        {
            if (TetrisGame.inputHelper.MouseLeftButtonPressed())
            {
                if (TetrisGame.inputHelper.CheckButtonPressed((int)playOriginalPos.X, (int)playOriginalPos.Y))
                {
                    TetrisGame.gameWorld.grid.Clear();
                    GameWorld.gameState = GameState.PlayOriginal;
                }      
                    

                if (TetrisGame.inputHelper.CheckButtonPressed((int)exitButtonPos.X, (int)exitButtonPos.Y))
                     Exit();
            }
        }

        private void Exit()
        {
            ExitGame = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch s)
        {
            s.Draw(menubackground, new Rectangle(0, 0, 800, 600), Color.White);
            s.Draw(playOriginal, new Vector2(playOriginalPos.X, playOriginalPos.Y),Color.White);
            s.Draw(exitButton, new Vector2(exitButtonPos.X, exitButtonPos.Y), Color.White);
        }
    }
}
