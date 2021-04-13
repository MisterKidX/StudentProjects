using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
    class Trap
    {
        Sounds SoundMngr = new Sounds();
        public int TrapX;
        public int TrapY;
       public bool TrapIsTriggered = false;
        public Trap(int x , int y) 
        {
            TrapX = x;
            TrapY = y;
/*            Console.SetCursorPosition(TrapX, TrapY);
            Console.Write("T");
*/
        }



        public void GetTrap(/*int playerX , int playerY, bool trapIsTriggered*/)
        {

            /*   if (*//*!trapIsTriggered*//*)
               {
                   Console.SetCursorPosition(TrapX, TrapY);

               }
               else
               {

                   Console.SetCursorPosition(TrapX, TrapY);
                   Console.ForegroundColor = ConsoleColor.White;
                   Console.Write("T");
               }*/
            if (Player.GetPlayerInstance.PlayerX == TrapX && Player.GetPlayerInstance.PlayerY == TrapY)
            {
                SoundMngr.TrapHit();
                TrapIsTriggered = true;
                Player.GetPlayerInstance.CurrentHP -= 5;
                Console.SetCursorPosition(0, 25);
                HUD.GetHUDInstance.ShowHUD();
                Console.WriteLine("You hit a trap , you lost 5 hp!                                                        ");

            }
            else if (TrapIsTriggered)
            {
                Console.SetCursorPosition(TrapX, TrapY);
                Console.Write(Map.GetMapInstance.Trap);
            }
        }

    }
}
