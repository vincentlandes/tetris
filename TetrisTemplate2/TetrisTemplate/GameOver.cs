using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tetris
{
    class GameOver
    {
        Texture2D exitButton;
        Texture2D menuButton;

        Vector2 exitButtonPos;
        Vector2 menuButtonPos;

        public bool ExitGame = false;
        
        public GameOver(Texture2D ExitButton, Texture2D MenuButton)
        {
            exitButton = ExitButton;
            menuButton = MenuButton;

            exitButtonPos = new Vector2(150, 500);
            menuButtonPos = new Vector2(450, 500);


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
            s.Draw(menuButton, new Vector2(menuButtonPos.X, menuButtonPos.Y), Color.White);
            s.Draw(exitButton, new Vector2(exitButtonPos.X, exitButtonPos.Y), Color.White);
        }

    }
}
