using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
   public class Trap
    {
        public int trapX;
        public int trapY;
        bool trapIsTriggered = false;
        public Trap(int x, int y)
        {
            trapX = x;
            trapY = y;
        }
        
        public void ShowTrap()
        {
            if (Player.PlayerInstance.X == trapX && Player.PlayerInstance.Y == trapY)
            {
                trapIsTriggered = true;
                Console.Beep(196, 250);
                Player.PlayerInstance.baseHP -= 5;
                Console.SetCursorPosition(0, 40);
                Hud.HudInstance.PrintHud();
            }
            else if (trapIsTriggered)
            {
                Console.SetCursorPosition(trapX, trapY);
                Console.Write('#');
            }
        } 
    }
}
