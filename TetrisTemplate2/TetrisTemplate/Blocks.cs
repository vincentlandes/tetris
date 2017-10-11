using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                { 1, 1, 1},
                { 0, 0, 1}
            });

            //Lblock
            Pieces.Add(new int[3, 3]{
                { 0, 0, 1},
                { 1, 1, 1},
                { 0, 0, 0}
            });

            //Zblock
            Pieces.Add(new int[3, 3]{
                {1, 1, 0},
                {0, 1, 1},
                {0, 0, 0}
            });

            //Oblock
            Pieces.Add(new int[2, 2]{
                {1, 1},
                {1, 1},
            });

            //Sblock
            Pieces.Add(new int[3, 3]{
                {0, 1, 1},
                {1, 1, 0},
                {0, 0, 0}
            });

            //Tblock
            Pieces.Add(new int[3, 3]{
                {0, 1, 0},
                {1, 1, 1},
                {0, 0, 0}
            });
        }
        //Add the colors to an array
        public static Color[] BlockColor = {
        Color.LightGray,    /* 0 */ /* Background Block */
        Color.Orange,       /* 1 */ /* IBlock */
        Color.Blue,         /* 2 */ /* JBlock */
        Color.Red,          /* 3 */ /* LBlock */
        Color.LightSkyBlue, /* 4 */ /* ZBlock */
        Color.Yellow,       /* 5 */ /* OBlock */
        Color.Magenta,      /* 6 */ /* SBlock */
        Color.LimeGreen     /* 7 */ /* TBlock */
        };

    }
}