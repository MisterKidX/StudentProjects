using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Treasure : GameObject
    {
        public Treasure(int[,] SpawnZone) : base('@', ConsoleColor.DarkMagenta, SpawnZone, 1)
        {

        }
    }
}
