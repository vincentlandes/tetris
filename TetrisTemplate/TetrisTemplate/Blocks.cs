using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Blocks
    {
    enum BlockTypes { Iblock, Jblock, Zblock, Oblock, Sblock, Tblock }

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
