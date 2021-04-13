using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Position
    {
        public int X, Y;
        public Position()
        {

        }

        public Position(int a, int b)
        {
            X = a;
            Y = b;
        }

        public static bool ComparePos(Position a, Position b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }
    }
}
