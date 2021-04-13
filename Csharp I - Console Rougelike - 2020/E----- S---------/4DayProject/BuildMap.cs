using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4DayProject
{
    class BuildMap
    {
        public void Buildmap()
        {
            Console.Clear();
            NightVision = 0;
            Res = 3;
            int diff = lvl;
            if (diff > 20) diff = 20;
            BuildWalls();
            PlaceBarrier(wall1, '-', ConsoleColor.Blue);
            PlaceBarrier(wall2, '|', ConsoleColor.Blue);
            PlaceBarrier(wall3, EmptyBarrier, ConsoleColor.Blue);
            Build(Exit, 1);
            System.Threading.Thread.Sleep(10);
            Build(VisionPotion, 1);
            System.Threading.Thread.Sleep(10);
            Build(coins, 5 * diff);
            System.Threading.Thread.Sleep(10);
            Build(Treasure, 1 * diff);
            System.Threading.Thread.Sleep(10);
            Spawn(Monster, 1 * diff);
            System.Threading.Thread.Sleep(10);
            Build(Trap, 1 * diff);
            System.Threading.Thread.Sleep(10);
            Build(HealthPotion, 1 * diff);
            System.Threading.Thread.Sleep(10);
            Build(Entrance, 1);
            Shop[0, 0] = 0; Shop[0, 1] = 0;
            Random rnd = new Random();
            int n = rnd.Next(0, 3);
            if (n == 0) Build(Shop, 1);
            Player[0] = Entrance[0, 0];
            Player[1] = Entrance[0, 1];
        }
    }
}
