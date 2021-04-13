using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Position
    {
        public int x;
        public int y;
        public Position()
        {

        }
        public Position(int a, int b)
        {
            x = a;
            y = b;
        }
        public static bool PositionCheck(Position posA, Position posB)
        {
            return (posA.x == posB.x) && (posA.y == posB.y);
        }
    }
}
