using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Chest
    {
        Player player;
        Random rnd = new Random();
        int Contains;
        public int x;
        public int y;
        int level;
        char marker = '#';
        public bool taken = false;
        public Chest(Player player, int level)
        {
            this.player = player;
            this.level = level;
            Contains = rnd.Next(1,9);
            x = rnd.Next(10, 35);
            y = rnd.Next(2,15);
        }

        public void run()
        {
            int x;
            taken = true;
            marker = ' ';
            switch (Contains)
            {
                case 1:
                    x = level * rnd.Next(5, 6);
                    player.money += x;
                    Console.SetCursorPosition(52, 2);
                    Console.WriteLine("JACKPOT " + x + " moeny");
                    Console.ReadKey(true);
                    //player.keys -= 1;
                    break;
                case 2:
                    x = level * rnd.Next(1, 4);
                    player.XP += x;
                    Console.SetCursorPosition(52, 2);
                    Console.WriteLine("you earn " + x + " Xp");
                    Console.ReadKey(true);
                    break;
                
                default:
                    x = level * rnd.Next(1, 5);
                    player.money += x;
                    Console.SetCursorPosition(52, 2);
                    Console.WriteLine("You find " + x + " moeny");
                    Console.ReadKey(true);
                    //player.keys -= 1;
                    break;
                    
            }
        }

        public void PrintChest()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(marker);
            Console.ResetColor();
        }
    }
}
