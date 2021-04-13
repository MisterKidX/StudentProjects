using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Traps
    {
        int posX;
        int posY;
        SoundManager SoundManager = new SoundManager();
        public Traps(int x, int y)
        {
            posX = x;
            posY = y;           
        }
        bool trapTriggered = false;
        public void TrapPlacement()
        {
            if (posX == Movement.GetMoveInstance.PlayerX && posY == Movement.GetMoveInstance.PlayerY )
            {
                trapTriggered = true;
                SoundManager.GetHitSoundEffect();
                Player.GetPlayerInstance.PlayerHP -= 5;
                Console.SetCursorPosition(1, 30);
                DataBoard.GetDataInstance.PrintData();
            }
            else if (trapTriggered)
            {
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("#");
                Console.ResetColor();
            }

        }
    }
}
