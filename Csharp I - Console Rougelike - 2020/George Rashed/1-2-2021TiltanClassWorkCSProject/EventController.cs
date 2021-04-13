using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class EventController
    {
        public void RunningTheGame()
        {

            // Creating Player
            Console.WriteLine("Hello & Welcome To 'Potatoes In A Dungeon' !!!VISUALIIIIISED!!!");
            Console.WriteLine("Better In FULLSCREEN!");
            Console.WriteLine("Create A NEW Character");
            Console.Write("What Is Your Name?: ");
            string name = Console.ReadLine();
            Player you = new Player(name);
            Console.Clear();

            string gameModeSetting = Player.Intro();

            if (gameModeSetting == "Story")
            {
                Console.WriteLine("Story Mode initialising...");
                Console.ReadLine();
                Console.Clear();
            }
            else if (gameModeSetting == "Survival")
            {
                Console.WriteLine("Survival Mode initialising...");
                Console.ReadLine();
                Console.Clear();
            }

            // Play BG Music
            AudioManager.getAudioManagerInstance.RunBackGroundMusic();

            bool levelGeneration = true;
            while (levelGeneration)
            {
                you.Level++;

                // Creating Enemy
                Enemy enemy = new Enemy(you.Level, gameModeSetting);

                // Initializing Map Class
                Map firstMap = new Map(you.Level, gameModeSetting);

                // Code Responsable For Movement
                bool moving = true;
                int xCor = firstMap.RandomEntCol;
                int yCor = firstMap.RandomEntRow;
                Console.SetCursorPosition(xCor, yCor);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("@");
                Console.ResetColor();

                ConsoleKeyInfo keyInfo;
                while (moving)
                {
                    keyInfo = Console.ReadKey(true);
                    Map.ClearNoteBoard(firstMap.RowSize);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (firstMap.MapGenerationMatrix[yCor - 1, xCor] == "X")
                            {
                                Console.WriteLine("EXIT TOUCHED");
                                moving = false;
                            }
                            else if (firstMap.MapGenerationMatrix[yCor - 1, xCor] == "#")
                            {
                                Console.SetCursorPosition(xCor, yCor);
                                Console.Write(" ");
                                yCor--;
                                Console.SetCursorPosition(xCor, yCor);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.ResetColor();
                                you.CollectTreasureChest(firstMap.RowSize);
                                firstMap.MapGenerationMatrix[yCor, xCor] = " ";
                            }
                            else if (!(firstMap.MapGenerationMatrix[yCor - 1, xCor] == "-" || firstMap.MapGenerationMatrix[yCor - 1, xCor] == "|" || firstMap.MapGenerationMatrix[yCor - 1, xCor] == "M"))
                            {
                                if (firstMap.MapGenerationMatrix[yCor, xCor] == "E")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("E");
                                    yCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                                else if (firstMap.MapGenerationMatrix[yCor, xCor] == "*")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("*");
                                    yCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                    you.TrapDamage(firstMap.RowSize, firstMap.Level);
                                }
                                else
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.Write(" ");
                                    yCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (firstMap.MapGenerationMatrix[yCor + 1, xCor] == "X")
                            {
                                Console.WriteLine("EXIT TOUCHED");
                                moving = false;
                            }
                            else if (firstMap.MapGenerationMatrix[yCor + 1, xCor] == "#")
                            {
                                Console.SetCursorPosition(xCor, yCor);
                                Console.Write(" ");
                                yCor++;
                                Console.SetCursorPosition(xCor, yCor);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.ResetColor();
                                you.CollectTreasureChest(firstMap.RowSize);
                                firstMap.MapGenerationMatrix[yCor, xCor] = " ";
                            }
                            else if (!(firstMap.MapGenerationMatrix[yCor + 1, xCor] == "-" || firstMap.MapGenerationMatrix[yCor + 1, xCor] == "|" || firstMap.MapGenerationMatrix[yCor + 1, xCor] == "M"))
                            {
                                if (firstMap.MapGenerationMatrix[yCor, xCor] == "E")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("E");
                                    yCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                                else if (firstMap.MapGenerationMatrix[yCor, xCor] == "*")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("*");
                                    yCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                    you.TrapDamage(firstMap.RowSize, firstMap.Level);
                                }
                                else
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.Write(" ");
                                    yCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (firstMap.MapGenerationMatrix[yCor, xCor - 1] == "X")
                            {
                                Console.WriteLine("EXIT TOUCHED");
                                moving = false;
                            }
                            else if (firstMap.MapGenerationMatrix[yCor, xCor - 1] == "#")
                            {
                                Console.SetCursorPosition(xCor, yCor);
                                Console.Write(" ");
                                xCor--;
                                Console.SetCursorPosition(xCor, yCor);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.ResetColor();
                                you.CollectTreasureChest(firstMap.RowSize);
                                firstMap.MapGenerationMatrix[yCor, xCor] = " ";
                            }
                            else if (!(firstMap.MapGenerationMatrix[yCor, xCor - 1] == "-" || firstMap.MapGenerationMatrix[yCor, xCor - 1] == "|" || firstMap.MapGenerationMatrix[yCor, xCor - 1] == "M"))
                            {
                                if (firstMap.MapGenerationMatrix[yCor, xCor] == "E")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("E");
                                    xCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                                else if (firstMap.MapGenerationMatrix[yCor, xCor] == "*")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("*");
                                    xCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                    you.TrapDamage(firstMap.RowSize, firstMap.Level);
                                }
                                else
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.Write(" ");
                                    xCor--;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (firstMap.MapGenerationMatrix[yCor, xCor + 1] == "X")
                            {
                                Console.WriteLine("EXIT TOUCHED");
                                moving = false;
                            }
                            else if (firstMap.MapGenerationMatrix[yCor, xCor + 1] == "#")
                            {
                                Console.SetCursorPosition(xCor, yCor);
                                Console.Write(" ");
                                xCor++;
                                Console.SetCursorPosition(xCor, yCor);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("@");
                                Console.ResetColor();
                                you.CollectTreasureChest(firstMap.RowSize);
                                firstMap.MapGenerationMatrix[yCor, xCor] = " ";
                            }
                            else if (!(firstMap.MapGenerationMatrix[yCor, xCor + 1] == "-" || firstMap.MapGenerationMatrix[yCor, xCor + 1] == "|" || firstMap.MapGenerationMatrix[yCor, xCor + 1] == "M"))
                            {
                                if (firstMap.MapGenerationMatrix[yCor, xCor] == "E")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write("E");
                                    xCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                                else if (firstMap.MapGenerationMatrix[yCor, xCor] == "*")
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("*");
                                    xCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                    you.TrapDamage(firstMap.RowSize, firstMap.Level);
                                }
                                else
                                {
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.Write(" ");
                                    xCor++;
                                    Console.SetCursorPosition(xCor, yCor);
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("@");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("Thank You For Playing!");
                            Console.WriteLine("Press 'ENTER' To Exit");
                            Console.ReadLine();
                            System.Environment.Exit(-1);
                            break;
                        default:
                            //moving = false;
                            break;
                    }



                    // Run Enemy AI
                    if (you.Level == 10 && gameModeSetting == "Story")
                    {
                        enemy.EnemyAIController(xCor, yCor, firstMap.MapGenerationMatrix, firstMap.EnemyCordinates, you.Level, gameModeSetting);

                    }
                    else
                    {
                        enemy.EnemyAIController(xCor, yCor, firstMap.MapGenerationMatrix, firstMap.EnemyCordinates, you.Level, gameModeSetting);
                    }

                    // Display Player Stats
                    Player.DisplayStats(firstMap.RowSize, firstMap.Level);

                    // Check If Player Is Dead
                    if (Player.IsDead == true)
                    {
                        moving = false;
                        levelGeneration = false;
                    }

                } // Moving While Loop Closer
                  // Check If Player Is Dead
                if (Player.IsDead == false)
                {
                    you.MarketGear(firstMap.RowSize, firstMap.Level);
                }
                Player.IsDead = false;
                Console.Clear();

            } // Level Generation While Loop Closer
        }
    }
}
