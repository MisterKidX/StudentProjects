using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class EndLevelQuestion
    {
        public static void EndLevel()
        {
            Console.Clear();
            Console.WriteLine("Are You Sure You Want to EXIT?");
            Console.WriteLine("Press Y to Exit");
            Console.WriteLine("Press X to Return to Game");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    MainMenu mm = new MainMenu();
                    mm.SaveGame();
                    Environment.Exit(0);
                    break;
                case ConsoleKey.X:
                    Console.Clear();
                    break;
            }
        }
    }
}
