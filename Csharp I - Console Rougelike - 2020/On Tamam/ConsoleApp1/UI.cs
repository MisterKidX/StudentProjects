using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    class UI
    {
        char[] HpBar = new char[25];
        char[] XpBar = new char[25];
        int Money;
          public UI()
        {
            for (int i = 0; i < HpBar.Length; i++)
            {
                HpBar[i] = ' ';
            }
            for (int i = 0; i < XpBar.Length; i++)
            {
                XpBar[i] = ' ';
            }
        }

        public void PrintUi(Player player)
        {
            float maxvalue = player.HP;
            float curvalue = player.currenthp;
            float mod = curvalue/maxvalue;
            //print a red space for every 10% hp the player has
            Console.SetCursorPosition(1, 26);
            for (int i = 0; i < HpBar.Length; i++)
            {
                curvalue = player.currenthp;
                mod = curvalue / maxvalue;
                int place = (int)(HpBar.Length * mod);
                if (i <= place)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(HpBar[i]);
                    Console.ResetColor();
                }

            }
            float maxvaluexp = player.xptonext;
            float curvaluexp = player.XP;
            float modxp = curvaluexp / maxvaluexp;
            Console.SetCursorPosition(1, 27);
            for (int i = 0; i < XpBar.Length; i++)
            {
                curvalue = player.XP;
                modxp = curvaluexp / maxvaluexp;
                int place = (int)(XpBar.Length * modxp);
                if (i <= place)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(XpBar[i]);
                    Console.ResetColor();
                }

            }
            Console.SetCursorPosition(1, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(player.money + " $");
            Console.ResetColor();
            Console.SetCursorPosition(1, 29);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(player.keys + " 0-^");
            Console.ResetColor();
            Console.SetCursorPosition(8, 28);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(player.kills + " @");
            Console.ResetColor();


        }
        
    }
}
