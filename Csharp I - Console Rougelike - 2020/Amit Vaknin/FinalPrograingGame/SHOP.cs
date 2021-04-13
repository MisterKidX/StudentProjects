using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPrograingGame
{
    class SHOP
    {
        private static SHOP shopInstance = null;
        public static SHOP getshopInstance
        {
            get
            {
                if (shopInstance == null)
                {
                    shopInstance = new SHOP(11, 40);
                }
                return shopInstance;
            }
        }
        public string[,] shop;
        public static int X;
        public static int Y;
        public SHOP(int x, int y)
        {
            X = x;
            Y = y;
            shop = new string[x, y];
        }
        public void Shopcreator()
        {
            for (X = 0; X < shop.GetLength(0); X++)
            {
                for (Y = 0; Y < shop.GetLength(1); Y++)
                {

                    shop[X, Y] = " ";
                    shop[0, Y] = "-";
                    shop[0, 0] = "|";
                    shop[0, shop.GetLength(1) - 1] = "|";
                    shop[shop.GetLength(0) - 1, Y] = "-";
                    shop[shop.GetLength(0) - 1, 0] = "|";
                    shop[shop.GetLength(0)-1, shop.GetLength(1) - 1] = "|";
                    printinsideshop();
                    Console.Write(shop[X, Y]);

                }
                Console.WriteLine("");
            }

        }
            public void printinsideshop()
            {
            shop[1, 1] = "hp" + player.getplayerInstance.baseHp;
            shop[2, 1] = "lvl" + MapCreator.getMapInstance.lvlcounter;
            shop[3, 1] = "coins" + player.getplayerInstance.coins;
            shop[5, 1] = "Press 1 to buy 15 hp for 2 coins";
            shop[6, 1] = "Press 2 to buy 50 hp for 8 coins";
            shop[7, 1] = "Press 3 to buy 3 enemy dmg reduce for 7 coins";
            shop[8, 1] = "Press 4 to buy 10 enemy dmg reduce for 17 coins";
            shop[9, 1] = "Press x to quit";
            }
        public void buyphase()
        {
            bool Letmeout = false;
            ConsoleKeyInfo input;
            do
            {

                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        
                        if (player.getplayerInstance.coins>=2)
                        {
                            player.getplayerInstance.baseHp += 15;
                            player.getplayerInstance.coins -= 2;
                            Console.SetCursorPosition(0, 0);
                            Shopcreator();
                        }
                        else
                        {
                            Console.Write("You are poor my friend");
                        }
                        break;
                    case ConsoleKey.D2:
                        if (player.getplayerInstance.coins>=8)
                        {
                            player.getplayerInstance.baseHp += 50;
                            player.getplayerInstance.coins -= 8;
                            Console.SetCursorPosition(0, 0);
                            Shopcreator();
                        }
                        else
                        {
                            Console.Write("You are poor my friend");
                        }

                        break;
                    case ConsoleKey.D3:
                        if (player.getplayerInstance.coins >= 7)
                        {
                           player.getplayerInstance.enemydmg -= 3;
                            player.getplayerInstance.coins -= 7;
                            Console.SetCursorPosition(0, 0);
                            Shopcreator();
                        }
                        else
                        {
                            Console.Write("You are poor my friend");
                        }

                        break;
                    case ConsoleKey.D4:
                        if (player.getplayerInstance.coins >= 17)
                        {
                            player.getplayerInstance.enemydmg -= 10;
                            player.getplayerInstance.coins -= 17;
                            Console.SetCursorPosition(0,0);
                            Shopcreator();
                        }
                        else
                        {
                            Console.Write("You are poor my friend");
                        }

                        break;
                    case ConsoleKey.X:
                        Letmeout = true;
                        break;
                }
                
            } while (!Letmeout);
            
        }

    }
}
