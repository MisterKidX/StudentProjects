using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleGame
{
    class Player : GameObject
    {

        public Player(int[,] SpawnZone) : base('P', ConsoleColor.Red, SpawnZone, 1)
        {

        }
        //public void Draw()
        //{
        //    ForegroundColor = PlayerColor;
        //    SetCursorPosition(X, Y);
        //    Write(PlayerMarker);
        //    ResetColor();
        //}
    }
}
