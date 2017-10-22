using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tetris
{
    class Blocks
    {
        public static List<int[,]> Pieces = new List<int[,]>();

        //Add the blocks to the list
        public void AddBlocksToList()
        {
            //Iblock
            Pieces.Add(new int[4, 4]{
                { 0, 0, 0, 0},
                { 1, 1, 1, 1},
                { 0, 0, 0, 0},
                { 0, 0, 0, 0}
            });

            //Jblock
            Pieces.Add(new int[3, 3]{
                { 0, 0, 0},
                { 2, 2, 2},
                { 0, 0, 2}
            });

            //Lblock
            Pieces.Add(new int[3, 3]{
                { 0, 0, 3},
                { 3, 3, 3},
                { 0, 0, 0}
            });

            //Zblock
            Pieces.Add(new int[3, 3]{
                {4, 4, 0},
                {0, 4, 4},
                {0, 0, 0}
            });

            //Oblock
            Pieces.Add(new int[2, 2]{
                {5, 5},
                {5, 5},
            });

            //Sblock
            Pieces.Add(new int[3, 3]{
                {0, 6, 6},
                {6, 6, 0},
                {0, 0, 0}
            });

            //Tblock
            Pieces.Add(new int[3, 3]{
                {0, 7, 0},
                {7, 7, 7},
                {0, 0, 0}
            });
        }
        
        //Add the colors to an array
        public static Color[] PieceColor = {
        Color.LightGray,    /* 0 */ /* Background Block */
        Color.Orange,       /* 1 */ /* IBlock */
        Color.Blue,         /* 2 */ /* JBlock */
        Color.Red,          /* 3 */ /* LBlock */
        Color.LightSkyBlue, /* 4 */ /* ZBlock */
        Color.Yellow,       /* 5 */ /* OBlock */
        Color.Magenta,      /* 6 */ /* SBlock */
        Color.LimeGreen,    /* 7 */ /* TBlock */
        };

    }
}