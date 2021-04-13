using System;
using System.Collections.Generic;
using System.Threading;


namespace HomeWork1
{
    class Program
    {
        // ---- C# 101 (Dor Ben Dor) ----
        //          Ron Guetta 
        //          10/04/2021
        //-------------------------------

        public static void Main()
        {
            Game g = new Game();
            g.StartingMoney = 500;
            g.MaxCapacity = 100;
            g.LivingColor = ConsoleColor.Cyan;
            g.UndeadColor = ConsoleColor.Red;
            g.MainMenu();
        }
    }
}
