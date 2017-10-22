using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tetris
{
    class GameOver
    {
        Texture2D exitButton, menuButton, gameoverbackground;

        Vector2 exitButtonPos;
        Vector2 menuButtonPos;

        public bool ExitGame = false;
        
        public GameOver(Texture2D ExitButton, Texture2D MenuButton, Texture2D gameoverBackground)
        {
            exitButton = ExitButton;
            menuButton = MenuButton;
            gameoverbackground = gameoverBackground;

            exitButtonPos = new Vector2(450, 500);
            menuButtonPos = new Vector2(150, 500);
        }

        public void Update(GameTime gameTime)
        {
            if (TetrisGame.inputHelper.MouseLeftButtonPressed())
            {
                if (TetrisGame.inputHelper.CheckButtonPressed((int)menuButtonPos.X, (int)menuButtonPos.Y))
                    GameWorld.gameState = GameState.Menu;

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
            s.Draw(gameoverbackground, new Rectangle(0, 0, 800, 600), Color.White);
            s.Draw(menuButton, new Vector2(menuButtonPos.X, menuButtonPos.Y), Color.White);
            s.Draw(exitButton, new Vector2(exitButtonPos.X, exitButtonPos.Y), Color.White);
        }

    }
}

///  Weghalen rij geluid
