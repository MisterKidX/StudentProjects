using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Traps : GameObject
    {
        public Traps(int[,] SpawnZone) : base('×', ConsoleColor.DarkCyan, SpawnZone, 1)
        {

        }
    }
}
