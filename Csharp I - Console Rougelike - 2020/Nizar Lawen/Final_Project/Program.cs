using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Final_Project
{
    // ---- C# 101 (Dor Ben Dor) ----
    //        Nizar Lawen
    //         1/3/2021
    // ------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            bool gameOver = false;            
            SoundManager SoundManager = new SoundManager();
            while (!end)
            {
                Console.WriteLine("Welcome to Escape the Dungeon \n" +
                    "You have been taken hostage to be experamented on to see how well \n" +
                    "can you survive in this dungeon \n" +
                    "\n" +
                    "Buttons to use:\n" +
                    "Movement: WASD\n" +
                    "Shop: Numbers\n" +
                    "\n" +
                    "Press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                while (!gameOver)
                {
                    SoundManager.BackGroundMusic();
                    switch (Player.GetPlayerInstance.Level)
                    {
                        case 1:
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();
                            break;
                        case 2:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();
                            break;
                        case 3:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();
                            break;
                        case 4:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();

                            break;
                        case 5:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();

                            break;
                        case 6:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();

                            break;
                        case 7:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();

                            break;
                        case 8:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();

                            break;
                        case 9:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();
                            break;
                        case 10:
                            Shop.GetShopInstance.PrintShop();
                            Shop.GetShopInstance.BuyPhase();
                            Console.Clear();
                            SoundManager.Paused = false;
                            SoundManager.BackGroundMusic();
                            Console.SetWindowSize(120, 45);
                            Maps.GetMapInstance.MapCreation();
                            DataBoard.GetDataInstance.PrintData();
                            Movement.GetMoveInstance.GameMovement();
                            SoundManager.Paused = true;
                            SoundManager.LevelEndingSoundEffect();
                            Console.Clear();
                            break;
                        case 11:                            
                            if (Player.GetPlayerInstance.PlayerHP <= 0)
                            {
                                //SoundManager.paused = true;                                
                                Console.WriteLine("You Dead and Failed the Experament");
                                gameOver = true;
                            }
                            else
                            {
                                Console.WriteLine("Congratulations You Finished the game \n" +
                                    "You Finished With These Attributes: \n" +
                                    "HP: " + Player.GetPlayerInstance.PlayerHP + "\n" +
                                    "Coins: " + Player.GetPlayerInstance.Coins + "\n" +
                                    "");
                                gameOver = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (Player.GetPlayerInstance.PlayerHP <= 0)
                    {
                        SoundManager.Paused = true;                        
                        Player.GetPlayerInstance.Level = 11;
                    }
                    
                }
                Console.WriteLine("\n" +
                    "Would You Like To Restart? \n" +
                        "Press Y/N");
                bool answer = false;
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Y:
                            Player.GetPlayerInstance.Level = 1;
                            Player.GetPlayerInstance.PlayerHP = 100;
                            Player.GetPlayerInstance.PlayerMaxHP = 100;
                            Player.GetPlayerInstance.Coins = 0;
                            Player.GetPlayerInstance.EnemyDMG = 14;
                            Player.GetPlayerInstance.HealPickup = 5;
                            answer = true;
                            gameOver = false;
                            SoundManager.Paused = false;
                            Console.Clear();
                            break;
                        case ConsoleKey.N:
                            answer = true;
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Wrong Button");
                            break;
                    }
                } while (!answer);
            }
            if (gameOver)
            {
                Console.WriteLine("Game Over");
            }
            Console.ReadLine();

        }
    }
}
