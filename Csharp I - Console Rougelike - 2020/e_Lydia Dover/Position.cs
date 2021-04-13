using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayRogLike
{
    public class Position
    {
        public int x;
        public int y;

        public Position() { }
        public Position(int a, int b)
        {
            x = a;
            y = b;
        }
        public static bool operator ==(Position posA, Position posB)
        {
            return ((posA.x == posB.x) && (posA.y == posB.y));
        }
        public static bool operator !=(Position posA, Position posB)
        {
            return ((posA.x == posB.x) && (posA.y == posB.y));
        }
    }
}
