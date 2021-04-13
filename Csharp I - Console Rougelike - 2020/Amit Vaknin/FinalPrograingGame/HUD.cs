using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalPrograingGame
{
    class HUD
    {
        private static HUD hudInstance = null;
        public static HUD gethudInstance
        {
            get
            {
                if (hudInstance == null)
                {
                    hudInstance = new HUD(6,20);
                }
                return hudInstance;
            }
        }
        public string[,] hud;
        public static int X;
        public static int Y;
        public HUD(int x, int y)
        {
            X = x;
            Y = y;
            hud = new string[x, y];
        }
        public void Hudcreator()
        {
            for (X = 0; X < hud.GetLength(0); X++)
            {
                for (Y = 0; Y < hud.GetLength(1); Y++)
                {
                   
                    hud[X, Y] = " ";
                    hud[0, Y] = "-";
                    hud[0, 0] = "|";
                    hud[0, hud.GetLength(1) - 1] = "|";
                    hud[hud.GetLength(0) - 1, Y] = "-";
                    hud[hud.GetLength(0) - 1, 0] = "|";
                    hud[hud.GetLength(0) - 1, hud.GetLength(1) - 1] = "|";
                    PrintHUDStats();
                    Console.Write(hud[X, Y]);

                }
                Console.WriteLine("");
            }
                
        }
        public void PrintHUDStats ()
        {
            ForegroundColor = ConsoleColor.Cyan;
            hud[1, 1] = "HP:"+player.getplayerInstance.baseHp;
            hud[2, 1] = "lvl:" + MapCreator.getMapInstance.lvlcounter;
            hud[3, 1] = "Coins" + player.getplayerInstance.coins;
        }
         
        
    }
}
