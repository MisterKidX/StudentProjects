using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class HUD
    {
        static int numberOfRows = 9;
        static int numberOfColumns = 44;
        static string[,] hud;
        public enum EntryColor
        {
            DarkRed,
            DarkBlue,
            Magenta,
            Green,
            Cyan
        }
        
        static Queue<string> queue = new Queue<string>();

        static HUD()
        {
            hud = new string[numberOfRows, numberOfColumns];            
        }

        public static void PrintHud()
        {
            InitializeHudFrame();
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < numberOfColumns; currentColumn++)
                {
                    Console.Write(hud[currentRow, currentColumn]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Player.Instance.PrintPlayerHPAndArmor();
            Player.Instance.PrintPlayerPotions();
            PrintToHUD();
            Player.Instance.PrintPlayerGold();
        }

        static void InitializeHudFrame()
        {
            int i = 1;            
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < numberOfColumns; currentColumn++)
                {
                    if ((currentColumn == 0) || (currentColumn == (numberOfColumns - 1)))
                    {
                        hud[currentRow, currentColumn] = GameIcons.verticalWall;
                    }
                    else if ((currentRow == 0) || (currentRow == (numberOfRows - 1)))
                    {
                        hud[currentRow, currentColumn] = GameIcons.horizontalWall;
                    }
                    else
                    {
                        hud[currentRow, currentColumn] = GameIcons.emptySpace;
                    }
                }
                Console.WriteLine();                                
            }   

        }

        static public void NewHUDEntry(string newInfo)
        {
            
            if(queue.Count >= 5)
            {
                queue.Dequeue();
            }
            queue.Enqueue(newInfo);
            PrintToHUD();
        }

        static void PrintToHUD()
        {
            int hudRowToWriteTo = 24;
            int i = 0;
            foreach (var item in queue)
            {
                Console.SetCursorPosition(1, hudRowToWriteTo + i);
                DeleteHUDEntry();
                Console.SetCursorPosition(1, hudRowToWriteTo + i);
                Console.Write((i + 1) + ". " + item);
                i++;
            }
        }

        static public void NewHUDEntry(string newInfo, EntryColor color)
        {

            if (queue.Count >= 5)
            {
                queue.Dequeue();
            }
            queue.Enqueue(newInfo);
            PrintToHUD(color);
        }

        static void PrintToHUD(EntryColor color)
        {
            int hudRowToWriteTo = 24;
            int i = 0;
            foreach (var item in queue)
            {
                Console.SetCursorPosition(1, hudRowToWriteTo + i);
                DeleteHUDEntry();
                Console.SetCursorPosition(1, hudRowToWriteTo + i);
                ChangeEntryHUDColor(color);
                Console.Write((i + 1) + ". " + item);
                ChangeEntryHUDColor(default);
                i++;
            }
        }

        static void ChangeEntryHUDColor(EntryColor color)
        {
            switch (color)
            {
                case EntryColor.DarkRed:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case EntryColor.DarkBlue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case EntryColor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case EntryColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case EntryColor.Cyan:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

            }
        }

        static void DeleteHUDEntry()
        {
            for (int i = 0; i < 42; i++)
            {
                Console.Write(GameIcons.emptySpace);
            }
        }
        
    }
}
