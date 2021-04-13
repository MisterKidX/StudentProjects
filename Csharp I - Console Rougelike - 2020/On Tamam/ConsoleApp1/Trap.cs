using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Trap
    {
        int damage;
        string type;
        public int x;
        public int y;
        int level;
        char Marker = ' ';
        public bool Triggered = false;
        Random rnd = new Random();
        public Trap(int level, int type)
        {
            this.level = level;
            x = rnd.Next(10, 35);
            y = rnd.Next(5, 20);
            damage = rnd.Next(1, 5) * level;
            switch (type)
            {
                case 1:
                    this.type = "Physical_Bomb";
                    break;
                case 2:
                    this.type = "Magical_Bomb";
                    break;
                default:
                    break;
            }
        }

        public void Trigger(Player player)
        {
            Triggered = true;
            Marker = '!';
            switch (type)
            {
                case "Physical_Bomb":
                    player.currenthp -= (damage - player.Armor);
                    Console.SetCursorPosition(52, 2);
                    Console.Write("Trap Triggered, you take " + (damage - player.Armor)+ " damage");
                    if (player.currenthp >= player.HP)
                    {
                        player.currenthp = player.HP;
                    }
                    Console.ReadKey(true);
                    break;
                case "Magical_Bomb":
                    player.currenthp -= (damage - player.MagRes);
                    Console.SetCursorPosition(52, 2);
                    Console.Write("Trap Triggered, you take " + (damage - player.MagRes) + " damage");
                    if (player.currenthp >= player.HP)
                    {
                        player.currenthp = player.HP;
                    }
                    Console.ReadKey(true);
                    break;
                default:
                    break;
            }
        }

        public void PrintTrap()
        {
            switch (type)
            {
                case "Physical_Bomb":
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Marker);
                    Console.ResetColor();
                    break;

                case "Magical_Bomb":
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Marker);
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
            
        }
    }
}
