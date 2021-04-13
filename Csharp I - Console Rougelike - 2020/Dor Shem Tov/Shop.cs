using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    class Shop
    {
        private static Shop _shopInstance = null;
        public static Shop ShopInstance
        {
            get
            {
                if (_shopInstance == null)
                {
                    _shopInstance = new Shop();
                }
                return _shopInstance;
            }
        }
        string[,] shop = new string[9, 60];
       
        public void PrintShop()
        {
            for (int i = 0; i < shop.GetLength(0); i++)
            {
                for (int j = 0; j < shop.GetLength(1); j++)
                {
                    shop[i, j] = " ";
                    shop[0, j] = "-";
                    shop[4, j] = "-";
                    shop[shop.GetLength(0) - 1, j] = "-";
                    shop[0, 0] = "|";
                    shop[0, shop.GetLength(1) - 1] = "|";
                    shop[shop.GetLength(0) - 1, 0] = "|";
                    shop[shop.GetLength(0) - 1, shop.GetLength(1) - 1] = "|";
                    ShopCalling(i, j);
                    Console.Write(shop[i, j]);
                }
                Console.WriteLine("");
            }
        }
        
        private void ShopCalling(int i, int j)
        {
            shop[1, 1] = "HP " + Player.PlayerInstance.baseHP;
            shop[2, 1] = "Level: " + Player.PlayerInstance.Level;
            shop[3, 1] = "Coins: " + Player.PlayerInstance.Coins;
            shop[5, 1] = "Press 1. buy 5 HP: 2 Coins";
            shop[6, 1] = "Press 2. buy 10 HP: 4 Coins";
            shop[shop.GetLength(0) - 2, 1] = "Press X To Exit";
        }
        
        public void BuyPhase()
        {
            bool buy = false;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.X:
                        buy = true;
                        break;
                    case ConsoleKey.D1:
                        if (Player.PlayerInstance.Coins >= 2)
                        {
                            Player.PlayerInstance.baseHP += 5;
                            Player.PlayerInstance.Coins -= 2;
                            Console.WriteLine("You bought 5 HP should have saved for 15");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Buy 5 HP ");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        break;
                    case ConsoleKey.D2:
                        if (Player.PlayerInstance.Coins >= 4)
                        {
                            Player.PlayerInstance.baseHP += 15;
                            Player.PlayerInstance.Coins -= 4;
                            Console.WriteLine("You bought 15 HP");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Buy 15 HP");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }                       
                        break;
                    default:
                        break;
                }

            } while (!buy);
        }
    }
}
