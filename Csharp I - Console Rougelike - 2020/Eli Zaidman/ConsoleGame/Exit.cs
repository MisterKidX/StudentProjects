using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Exit : GameObject
    {
        public Exit(int[,] SpawnZone) : base('X', ConsoleColor.Yellow, SpawnZone, 1)
        {

        }
    }
}
