using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Finish
    {
        public static List<Finish> FinishList = new List<Finish>(1);
        public Position FinishLoc = new Position();

        public Finish(int x, int y)
        {
            FinishLoc = new Position(x, y);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write(MapGenerator.Instance.Entrance);
            Console.SetCursorPosition(x, y);
            Console.Write(MapGenerator.Instance.Exit);
            Console.ResetColor();
        }
    }
}
