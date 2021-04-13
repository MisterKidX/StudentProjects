// ---- C# 101 (Dor Ben Dor) ----
//         Alla Makarov
//          01/03/2021
// ------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgame
{
    class Coordinate
    {
        public readonly int Colomn;
        public readonly int Row;

        public Coordinate(int colomn,int row)
        {
            Colomn = colomn;
            Row = row;
        }
    }
}
