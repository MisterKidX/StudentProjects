using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    class Program
    {
// --------------- C# 101 (Dor Ben Dor) ---------------
//                     Dor Shem Tov
//                 Due Date: 1/3/2021
// ----------------------------------------------------
        static void Main(string[] args)
        {
            bool gameOver = false;
            while (!gameOver)
            {
                switch (Player.PlayerInstance.Level)
                {
                    case 1:
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 2:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 3:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 4:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 5:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 6:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 7:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 8:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 9:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        break;
                    case 10:
                        Shop.ShopInstance.PrintShop();
                        Shop.ShopInstance.BuyPhase();
                        Console.Clear();
                        Console.SetWindowSize(120, 50);
                        Map.MapInstance.PrintMap();
                        Hud.HudInstance.PrintHud();
                        Player.PlayerInstance.PlayerMovement();
                        Console.Clear();
                        gameOver = true;
                        break;
                    default:
                        break;
                }
                if (Player.PlayerInstance.baseHP <= 0)
                {
                    gameOver = true;
                }

            }
            if (Player.PlayerInstance.Level == 11)
            {
                Console.WriteLine("Congratulations, THANKS FOR PLAYING");
            }
            else if (gameOver)
            {
                Console.WriteLine("GAME OVER , PLEASE TRY AGAIN");
            }
        }
    }
}
