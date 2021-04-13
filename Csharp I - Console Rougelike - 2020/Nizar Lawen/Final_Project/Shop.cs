using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Shop
    {
        private static Shop _shopInstance = null;
        public static Shop GetShopInstance
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
        string[,] shop = new string[12, 60];
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
                    shop[shop.GetLength(0)-1, 0] = "|";
                    shop[shop.GetLength(0) - 1, shop.GetLength(1) - 1] = "|";
                    ShopCalling(i, j);
                    Console.Write(shop[i, j]);
                }
                Console.WriteLine("");
            }
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
                        if (Player.GetPlayerInstance.Coins>=6)
                        {
                            Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                            Player.GetPlayerInstance.Coins -= 6;
                            Console.SetCursorPosition(0,0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Buy A Refill");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        break;
                    case ConsoleKey.D2:
                        if (Player.GetPlayerInstance.Coins >= 4)
                        {
                            if (Player.GetPlayerInstance.PlayerHP < Player.GetPlayerInstance.PlayerMaxHP)
                            {
                                Player.GetPlayerInstance.PlayerHP += 15;
                                if (Player.GetPlayerInstance.PlayerHP > Player.GetPlayerInstance.PlayerMaxHP)
                                {
                                    Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                                }
                                Player.GetPlayerInstance.Coins -= 4;
                            }
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
                    case ConsoleKey.D3:
                        if (Player.GetPlayerInstance.Coins >= 4)
                        {
                            Player.GetPlayerInstance.EnemyDMG -= 2;
                            Player.GetPlayerInstance.Coins -= 4;
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Reduce Enemy Damage");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        break;
                    case ConsoleKey.D4:
                        if (Player.GetPlayerInstance.Coins >= 4)
                        {
                            Player.GetPlayerInstance.PlayerMaxHP += 20;
                            Player.GetPlayerInstance.Coins -= 4;
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Increase Max HP");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        break;
                    case ConsoleKey.D5:
                        if (Player.GetPlayerInstance.Coins >= 5)
                        {
                            Player.GetPlayerInstance.HealPickup += 2;
                            Player.GetPlayerInstance.Coins -= 5;
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have Enough Coins To Increase Heal Pickup");
                            Console.SetCursorPosition(0, 0);
                            PrintShop();
                        }
                        break;
                    default:
                        break;
                }

            } while (!buy);
        }
        private void ShopCalling(int i, int j)
        {
            shop[1, 1] = "HP " + Player.GetPlayerInstance.PlayerHP;
            shop[2, 1] = "Level: " + Player.GetPlayerInstance.Level;
            shop[3, 1] = "Coins: " + Player.GetPlayerInstance.Coins;
            shop[5, 1] = "Press 1. Refill HP: 6 Coins";
            shop[6, 1] = "Press 2. buy 15 HP: 4 Coins";
            shop[7, 1] = "Press 3. Reduce Enemy Damage by 2: 4 Coins";
            shop[8, 1] = "Press 4. Increase Max HP by 20: 4 Coins";
            shop[9, 1] = "Press 5. Increasse Heal Pickup Amount by 2: 5 Coins";
            shop[shop.GetLength(0) - 2, 1] = "Press X To Exit";
        }
    }
}
