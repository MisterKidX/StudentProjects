using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    class Hud
    {
        private static Hud _hudInstance = null;
        public static Hud HudInstance
        {
            get
            {
                if (_hudInstance == null)
                {
                    _hudInstance = new Hud();
                }
                return _hudInstance;
            }
        }
        public string[,] HudAI = new string[5, 20];
     
        public void PrintHud()
        {
            for (int i = 0; i < HudAI.GetLength(0); i++)
            {
                for (int j = 0; j < HudAI.GetLength(1); j++)
                {
                    HudAI[i, j] = " ";
                    HudAI[0, j] = "-";
                    HudAI[HudAI.GetLength(0) - 1, j] = "-";
                    HudAI[0, 0] = "|";
                    HudAI[0, HudAI.GetLength(1) - 1] = "|";
                    ShowHud();
                    Console.Write(HudAI[i, j]);
                }
                Console.WriteLine("");
            }
        }
        
        public void ShowHud()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            HudAI[1, 1] = "Player HP " + Player.PlayerInstance.baseHP;
            HudAI[2, 1] = "Player DAMAGE " + Player.PlayerInstance.Damage;
            HudAI[3, 1] = "LEVEL " + Player.PlayerInstance.Level;
        }
    }
}
