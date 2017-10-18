using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tetris.Content
{
    class Menu
    {
        Texture2D playOriginal;
        Texture2D exitButton;

        Vector2 playOriginalPos;
        Vector2 exitButtonPos;

        public bool ExitGame = false;

        public Menu(Texture2D PlayOriginal, Texture2D Exitbutton)
        {
            playOriginal = PlayOriginal;
            exitButton = Exitbutton;

            playOriginalPos = new Vector2(100, 60);
            exitButtonPos = new Vector2(100, 160);
        }

        public void Update(GameTime gameTime)
        {
            if (TetrisGame.inputHelper.MouseLeftButtonPressed())
            {
                if (TetrisGame.inputHelper.CheckButtonPressed((int)playOriginalPos.X, (int)playOriginalPos.Y))      
                    GameWorld.gameState = GameState.PlayOriginal;

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
            s.Draw(playOriginal, new Vector2(playOriginalPos.X, playOriginalPos.Y),Color.White);
            s.Draw(exitButton, new Vector2(exitButtonPos.X, exitButtonPos.Y), Color.White);
        }
    }
}
