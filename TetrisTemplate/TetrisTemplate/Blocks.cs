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
    enum BlockTypes { Iblock, Jblock, Zblock, Oblock, Sblock, Tblock, Testblock }

    public static Color[] BlockColor = {
        Color.LightGray,    /* 0 */
        Color.Orange,       /* 1 */
        Color.Blue,         /* 2 */
        Color.Red,          /* 3 */
        Color.LightSkyBlue, /* 4 */
        Color.Yellow,       /* 5 */
        Color.Magenta,      /* 6 */
        Color.LimeGreen     /* 7 */
        };

    }

    class Testblock : Blocks
    {
        int[,] block = new int[1,1]
        {
            {1}
        };
    }

    class Iblock : Blocks
    {
        int[,] block = new int[4, 4] {
            {0, 0, 0, 0},
            {1, 1, 1, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };
    }

    class Jblock : Blocks
    {
        int[,] block = new int[3, 3] {
            {0, 0, 1},
            {1, 1, 1},
            {0, 0, 0}
        };
    }

    class Zblock : Blocks
    {
        int[,] block = new int[3, 3] {
            {1, 1, 0},
            {0, 1, 1},
            {0, 0, 0}
        };
    }

    class Oblock : Blocks
    {
        int[,] block = new int[2, 2] {
            {1, 1},
            {1, 1},
        };
    }

    class Sblock : Blocks
    {
        int[,] block = new int[3, 3] {
            {0, 1, 1},
            {1, 1, 0},
            {0, 0, 0}
        };
    }

    class Tblock : Blocks
    {
        int[,] block = new int[3, 3] {
            {0, 1, 0},
            {1, 1, 1},
            {0, 0, 0}
        };
    }
}
