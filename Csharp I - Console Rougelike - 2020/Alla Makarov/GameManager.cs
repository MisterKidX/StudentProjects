// ---- C# 101 (Dor Ben Dor) ----
//         Alla Makarov
//          01/03/2021
// ------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPGgame
{
    class GameManager
    {
        private int _level;
        private string[] _menuString;
        private string[] _optionsMenu;
        private Player _player;
        private Map _map;
        private Logger _logger;

        public GameManager()
        {
            Init();
        }
        private void RestartGame(string massage)
        {
            Init();
            Console.WriteLine(massage);
            Console.ReadLine();
            ShowMainMenu();
        }
        public void ShowMainMenu()
        {
            switch (MenuGui(_menuString))
            {
                case (int)MainMenu.Start:
                    LoadGame();
                    break;
                case (int)MainMenu.Options:
                    ShowOptionsMenu();
                    break;
                case (int)MainMenu.Exit:
                    Environment.Exit(-1);
                    break;
            }
        }
        private void ShowOptionsMenu()
        {
            
            switch (MenuGui(_optionsMenu))
            {
                case (int)OptionsMenu.LoggerLength:
                    _logger.ChangeLoggerLimit();
                    ShowOptionsMenu();
                    break;
                case (int)OptionsMenu.Level:
                    ChangeLevel();
                    break;
                case (int)OptionsMenu.Back:
                    ShowMainMenu();
                    break;
            }
        }

        private int MenuGui(string[] menu)
        {
            int index = 0;

            ConsoleKey keyPressed = ConsoleKey.Escape;
            while (keyPressed != ConsoleKey.Enter)
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(menu[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(menu[i]);
                    }
                }

                keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    if (index == 0)
                    {
                        index = 2;
                    }
                    else
                    {
                        index--;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    if (index == 2)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return index;
        }

        private void LoadGame()
        {
            Console.Clear();
            _map.PrintMap();
            _logger.PrintLog();
            _player.PrintPlayerStats();
            Movement(Console.ReadKey().Key);
        }
        private void Movement(ConsoleKey keyPressed)
        {
            char actionChar = '9';
            switch (keyPressed)
            {
                case ConsoleKey.Escape:
                    ShowMainMenu();
                    break;
                case ConsoleKey.LeftArrow:
                    actionChar = _map.PlayerMove(0, -1);
                    break;
                case ConsoleKey.UpArrow:
                    actionChar = _map.PlayerMove(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    actionChar = _map.PlayerMove(0, 1);
                    break;
                case ConsoleKey.DownArrow:
                    actionChar = _map.PlayerMove(1, 0);
                    break;
                    // Left turn
                case ConsoleKey.A:
                    actionChar = _map.PlayerMove(0, -1);
                    break;
                    // Right turn
                case ConsoleKey.D:
                    actionChar = _map.PlayerMove(0, 1);
                    break;
                    // Down
                case ConsoleKey.S:
                    actionChar = _map.PlayerMove(1, 0);
                    break;
                    // Up
                case ConsoleKey.W:
                    actionChar = _map.PlayerMove(-1, 0);
                    break;
            }

            if(actionChar!='9')
            {
                ActionTile(actionChar);
            }

            LoadGame();
        }

        private void ActionTile(char action)
        {
            switch(action)
            {
                case 'X':
                    _logger.AddToLog("Congratulations you comleted level " + _level + "!");
                    LevelUp();
                    break;
                case 'E':
                    {
                        if (_player.FightEnemy())
                        {
                            _logger.AddToLog("Horray, you killed your enemy!");
                        }
                        else
                        {
                            RestartGame("Too bad! The enemy killed you :(");
                        }

                        break;
                    }
                case 'T':
                    _logger.AddToLog(_player.TreasureBonus());
                    break;
                case 'R':
                    {
                        if(_player.LoseHealthInTrap())
                        {
                            RestartGame("Too bad! The trap killed you!");
                        }
                        else
                        {
                            _logger.AddToLog("Lucky you! You survived a trap!");
                        }

                        break;
                    }
            }
        }

        private void LevelUp()
        {
            _level++;
            _player.LevelUp();
            _player.UpdatePlayerPosition(new Coordinate(1, 1));
            _map = new Map(_level, _player);
        }
        private void ChangeLevel()
        {
            Console.Clear();
            Console.WriteLine("What level would you like to go to?");
            _level = int.Parse(Console.ReadLine());
            _player = new Player(_level);
            _map = new Map(_level, _player);
            _menuString = new string[]
                {
                     MainMenu.Start + "\n",
                     MainMenu.Options + "\n",
                     MainMenu.Exit + "\n" };
            ShowOptionsMenu();
        }

        private void Init()
        {
            _level = 0;
            _player = new Player(_level);
            _map = new Map(_level, _player);
            _logger = new Logger();
            _menuString = new string[]
                {
                     MainMenu.Start + "\n",
                     MainMenu.Options+"\n",
                     MainMenu.Exit + "\n" };
            _optionsMenu = new string[]
                {
                     OptionsMenu.LoggerLength + "\n",
                     OptionsMenu.Level+"\n",
                     OptionsMenu.Back + "\n" };
        }
        private enum MainMenu
        {
            Start,
            Options,
            Exit
        }
        private enum OptionsMenu
        {
            LoggerLength,
            Level,
            Back
        }
    }
}

