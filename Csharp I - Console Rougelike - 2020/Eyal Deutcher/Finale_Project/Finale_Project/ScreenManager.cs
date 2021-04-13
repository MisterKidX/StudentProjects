using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public static class ScreenManager
    {
        public static void PrintScreen()
        {
            Console.SetCursorPosition(0, 0);
            GameManager.map.PrintMap();
            int currentLineCursor = Console.CursorTop;
            clearHud();
            Console.SetCursorPosition(0, currentLineCursor);
            Hud.PrintHUD();
        }
        static void clearHud()
        {
            int line = Console.CursorTop;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.BufferWidth));
                line++;
            }
        }


    }
}
