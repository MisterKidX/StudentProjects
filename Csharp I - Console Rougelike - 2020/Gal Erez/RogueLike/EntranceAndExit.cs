using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class EntranceAndExit
    {
        public static List<EntranceAndExit> ExitList = new List<EntranceAndExit>(10);
        public Position ExitLoc = new Position();

        public EntranceAndExit(int entanceX, int entranceY, int exitX, int exitY) //, int lvl)
        {
            ExitLoc = new Position(exitX, exitY);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(entanceX, entranceY);
            Console.Write(MapGenerator.Instance.Entrance);
            Console.SetCursorPosition(exitX, exitY);
            Console.Write(MapGenerator.Instance.Exit);
            Console.ResetColor();

            ExitList.Add(this);
        }
    }
}
