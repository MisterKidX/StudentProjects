using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoughLite
{
    class Game
    {
        #region Fields/Variables
        private Maps _currentMap;
        private Player _currentPlayer;
        private List<Enemy> _currentEnemies;
        private List<Item> _currentMapItems;
        private int _currentLevel;
        private Random _random;
        private int _difficulty = 1;
        private int _width = 10;
        private int _heigth = 10;
        private int _enemyKills;
        #endregion

        public void Start()
        {

            Console.Title = " One Last Run - A Roughlike Game!";
            Console.CursorVisible = false;
            _random = new Random();
            _currentLevel = 1;
            _enemyKills = 0;
            RunMainMenu();
        }
        private void HandleGameLoop()
        {
            DisplayLevelInfo();
            while (true)
            {
                DrawObjects();
                HandleEnemyEncounters();
                HandleItemPickUp();
                HandlePlayerMovement();
                HandleEnemyMovement();


                string elementAtPlayerPos = _currentMap.GetElementAt(_currentPlayer.X, _currentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }

                System.Threading.Thread.Sleep(20);
            }
            DisplayLevelComplet();
            _currentLevel += 1;
            PlayGame();
        }

        #region MainMenuOptions
        private void PlayGame()
        {
            Console.Clear();

            _currentMap = Maps.InitMap(_width, _heigth, _currentLevel);
            _currentPlayer = _currentMap.PlayerPos(_currentPlayer);
            _currentEnemies = new List<Enemy>();
            _currentMapItems = new List<Item>();

            for (int i = 0; i < (_currentLevel / 2 + 1) * _difficulty; i++)
            {
                _currentEnemies.Add(_currentMap.EnemyPos());
            }
            for (int z = 0; z < _currentLevel / 2 + 1; z++)
            {
                _currentMapItems.Add(_currentMap.ItemsPos());
            }


            HandleGameLoop();
        }
        private void MapOptions()
        {
            Console.Clear();
            Console.WriteLine("Choose game difficulty (E)Easy (N)Normal (H)Hard (default 1)");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.E:
                    Console.WriteLine("You Choose easy difficulty!");
                    _difficulty = 1;
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("You Choose normal difficulty!");
                    _difficulty = 2;
                    break;
                case ConsoleKey.H:
                    Console.WriteLine("You Choose hard difficulty!");
                    _difficulty = 3;
                    break;
                default:
                    _difficulty = 1;
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Choose map size (S)Small (M)Medium (L)Large (default size is Small)");
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.S:
                    Console.WriteLine("You Choose a small size map!");
                    _width = 12;            
                    _heigth = 12;
                    break;
                case ConsoleKey.M:
                    Console.WriteLine("You Choose a medium size map!");
                    _width = 18;
                    _heigth = 18;
                    break;
                case ConsoleKey.L:
                    Console.WriteLine("You Choose a large size map!");
                    _width = 23;
                    _heigth = 23;
                    break;
                default:
                    _width = 12;
                    _heigth = 12;
                    break;
            }
            Console.ReadKey();
            RunMainMenu();
        }
        private void ExitGame()
        {
            Console.WriteLine("\n Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        #endregion

        #region UI
        private void DrawObjects()
        {
            Console.Clear();
            _currentMap.DrawMap();
            _currentPlayer.DrawPlayer();
            foreach (Enemy enemy in _currentEnemies)
            {

                enemy.DrawEnemy();
            }
            foreach (Item item in _currentMapItems)
            {
                item.DrawItems();
            }
            DrawPlayerHud();
        }
        private void RunMainMenu()
        {
            string prompt = @"
 _____              _               _    ______            
|  _  |            | |             | |   | ___ \           
| | | |_ __   ___  | |     __ _ ___| |_  | |_/ /   _ _ __  
| | | | '_ \ / _ \ | |    / _` / __| __| |    / | | | '_ \ 
\ \_/ / | | |  __/ | |___| (_| \__ \ |_  | |\ \ |_| | | | |
 \___/|_| |_|\___| \_____/\__,_|___/\__| \_| \_\__,_|_| |_|
Welcome to One Last Run. What would you like to do?
(Use the arrow keys to select an option and press Enter to choose it.)";
            string[] options = { "Play", "Map Options", "Exit" };

            MainMenu mainMenu = new MainMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    MapOptions();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        private void DisplayLevelInfo()
        {
            if (_currentLevel == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Welcome to the last run!");
                Console.ResetColor();
                Console.WriteLine("Use the keys \"WASD\" to move around the level.");
                Console.Write("Find your way around the room to reach the \"Exit\".\nThe exit is marked with a Yellow" + " ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\"E\".");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Avoid or fight enemies on the map.\nEnemies are marked on the map as a red sign");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\"¤\".");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Pick up treasure chests on map to increase your stats.\nTreasure chests are marked on the map as a cyan sign");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\"¥\".");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(25, 10);
                Console.WriteLine("Press any key start the first level.");
                Console.ResetColor();
                Console.ReadKey(true);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Level" + " " + _currentLevel);
                Console.ReadKey(true);
            }


        }
        private void DisplayLevelComplet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Congratulations!");
            Console.WriteLine("Level" + " " + _currentLevel + " " + "Completed!");
            Console.WriteLine($"You defeated:{_enemyKills} enemies so far!");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        private void DrawPlayerHud()
        {
            Console.SetCursorPosition(0, _currentMap._height + 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Your Stats:\nHP: {_currentPlayer.HP} \nArmor: {_currentPlayer.GetArmor()} \nAttack Power: {_currentPlayer.GetPower()}");

            int cursorLocation = 6;
            Console.SetCursorPosition(0, _currentMap._height + 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Inventory:");
            foreach (var item in _currentPlayer.Items.Values)
            {
                Console.SetCursorPosition(0, _currentMap._height + cursorLocation);
                cursorLocation++;
                Console.WriteLine($"{item.Type} Adds+{item.Stat}");
            }

        }

        #endregion

        #region Movements
        private void HandlePlayerMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.W:

                    if (_currentMap.IsWalkableSpace(_currentPlayer.X, _currentPlayer.Y - 1))
                    {
                        _currentPlayer.Y -= 1;

                    }
                    break;
                case ConsoleKey.A:
                    if (_currentMap.IsWalkableSpace(_currentPlayer.X - 1, _currentPlayer.Y))
                    {
                        _currentPlayer.X -= 1;

                    }
                    break;
                case ConsoleKey.S:
                    if (_currentMap.IsWalkableSpace(_currentPlayer.X, _currentPlayer.Y + 1))
                    {
                        _currentPlayer.Y += 1;

                    }
                    break;
                case ConsoleKey.D:
                    if (_currentMap.IsWalkableSpace(_currentPlayer.X + 1, _currentPlayer.Y))
                    {
                        _currentPlayer.X += 1;

                    }
                    break;
                default:
                    break;
            }
        }
        private void HandleEnemyMovement()
        {
            Random r = new Random();

            foreach (Enemy enemy in _currentEnemies)
            {
                switch (r.Next(5))
                {
                    case (0):
                        if (_currentMap.IsWalkableSpace(enemy.X, enemy.Y - 1))
                        {
                            enemy.Y -= 1;
                        }
                        break;
                    case (1):
                        if (_currentMap.IsWalkableSpace(enemy.X, enemy.Y + 1))
                        {
                            enemy.Y += 1;
                        }
                        break;
                    case (2):
                        if (_currentMap.IsWalkableSpace(enemy.X - 1, enemy.Y))
                        {
                            enemy.X -= 1;
                        }
                        break;
                    case (3):
                        if (_currentMap.IsWalkableSpace(enemy.X + 1, enemy.Y))
                        {
                            enemy.X += 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Map Entities
        private void HandleEnemyEncounters()
        {
            int currentEnemeyPower;
            int currentPlayerPower;
            int diceRoll;
            Enemy currentEnemy = _currentEnemies.FirstOrDefault(enemy => enemy.X == _currentPlayer.X && enemy.Y == _currentPlayer.Y);
            if (currentEnemy != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(_currentMap._width + 9, 1);
                Console.WriteLine("A wild enemy appeared:");
                Console.SetCursorPosition(_currentMap._width + 9, 2);
                Console.WriteLine($"HP:{currentEnemy.HP} Armor:{currentEnemy.Armor} Power:{currentEnemy.Power}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(_currentMap._width + 9, 3);
                Console.WriteLine("Will you fight? or run?");
                Console.SetCursorPosition(_currentMap._width + 5, 4);
                Console.WriteLine("Press S to start a fight or R to Run");
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.R)
                {
                    _currentPlayer.HP -= 1;
                }
                if (keyInfo.Key == ConsoleKey.S)
                {
                    Console.SetCursorPosition(_currentMap._width + 9, 5);
                    Console.WriteLine("The fight begin!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(_currentMap._width + 9, 6);
                    Console.WriteLine("Your Stats:");
                    Console.SetCursorPosition(_currentMap._width + 9, 7);
                    Console.WriteLine($"HP:{_currentPlayer.HP}");
                    Console.SetCursorPosition(_currentMap._width + 9, 8);
                    Console.WriteLine($"Armor:{_currentPlayer.GetArmor()}");
                    Console.SetCursorPosition(_currentMap._width + 9, 9);
                    Console.WriteLine($"Power:{_currentPlayer.GetPower()}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(_currentMap._width + 29, 6);
                    Console.WriteLine("Enemy Stats:");
                    Console.SetCursorPosition(_currentMap._width + 29, 7);
                    Console.WriteLine($"HP:{currentEnemy.HP}");
                    Console.SetCursorPosition(_currentMap._width + 29, 8);
                    Console.WriteLine($"Armor:{currentEnemy.Armor}");
                    Console.SetCursorPosition(_currentMap._width + 29, 9);
                    Console.WriteLine($"Power:{currentEnemy.Power}");
                    Console.ResetColor();

                    Console.SetCursorPosition(_currentMap._width + 9, 11);
                    Console.WriteLine("Press \"Enter\" to Roll the dice!");
                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:

                            diceRoll = _random.Next(1, 6);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(_currentMap._width + 9, 12);
                            Console.Write("Rolling a 1d6 dice");
                            Console.ResetColor();

                            for (int i = 0; i < 10; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Thread.Sleep(200);
                                Console.Write(".");
                                Console.ResetColor();
                            }
                            Console.SetCursorPosition(_currentMap._width + 9, 13);
                            Console.WriteLine($"You Rolled:{diceRoll}");
                            currentPlayerPower = _currentPlayer.Power + diceRoll;
                            if (currentPlayerPower > currentEnemy.Armor)
                            {
                                Console.SetCursorPosition(_currentMap._width + 9, 14);
                                Console.WriteLine("You Won");
                                currentEnemy.HP -= 1;
                                _enemyKills += 1;
                                _currentEnemies.Remove(currentEnemy);
                                Console.SetCursorPosition(_currentMap._width + 9, 15);
                                Console.WriteLine("Choose a reward:");
                                Console.SetCursorPosition(_currentMap._width + 9, 16);
                                Console.WriteLine("(1) +1 HP (2) +1 Armor (3) +1 Power");
                                keyInfo = Console.ReadKey(true);

                                switch (keyInfo.Key)
                                {
                                    case ConsoleKey.D1:
                                        _currentPlayer.HP += 1+(_currentLevel/ 2);
                                        break;
                                    case ConsoleKey.D2:
                                        _currentPlayer.Armor +=1+(_currentLevel / 2);
                                        break;
                                    case ConsoleKey.D3:
                                        _currentPlayer.Power +=1+(_currentLevel / 2);
                                        break;
                                    default:
                                        break;
                                }
                                DrawObjects();
                            }
                            else if (currentPlayerPower <= currentEnemy.Armor)
                            {
                                Console.SetCursorPosition(_currentMap._width + 9, 17);
                                Console.WriteLine("Your attack missed!");
                                Console.SetCursorPosition(_currentMap._width + 9, 18);
                                Console.WriteLine("Enemey Turn!");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(_currentMap._width + 9, 19);
                                Console.Write("Rolling a 1d6 dice");
                                Console.ResetColor();

                                for (int i = 0; i < 10; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Thread.Sleep(200);
                                    Console.Write(".");
                                    Console.ResetColor();
                                }
                                diceRoll = _random.Next(1, 6);
                                Console.SetCursorPosition(_currentMap._width + 9, 20);
                                Console.WriteLine($"Enemy Rolled:{diceRoll}");
                                currentEnemeyPower = currentEnemy.Power + diceRoll;
                                if (currentEnemeyPower > _currentPlayer.GetArmor())
                                {
                                    Console.SetCursorPosition(_currentMap._width + 9, 21);
                                    Console.WriteLine("Enemy hits you! you lost 1 HP.");
                                    _currentPlayer.HP -= 1;
                                }
                            }
                            break;

                        default:
                            break;
                    }

                }

            }
            if (_currentPlayer.HP < 1)
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine("Better luck next time!");
                Console.WriteLine($"You manage to survive {_currentLevel} levels!");
                Console.WriteLine($"You manage to defeat:{_enemyKills} enemies this run.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();

                _currentPlayer = null;
                RunMainMenu();
                return;
            }
        }

        private void HandleItemPickUp()
        {
            Item currentItem = _currentMapItems.FirstOrDefault(item => item.X == _currentPlayer.X && item.Y == _currentPlayer.Y);
            if (currentItem == null)
            {
                return;
            }
            if (_currentPlayer.Items.ContainsKey(currentItem.Type))
            {
                Item playerItem = _currentPlayer.Items[currentItem.Type];
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(_currentMap._width + 9, 5);
                Console.WriteLine("You found a treasure chest");
                Console.SetCursorPosition(_currentMap._width + 9, 6);
                Console.WriteLine("Press Enter to open the Chest");
                Console.ReadKey();
                Console.SetCursorPosition(_currentMap._width + 9, 7);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You found a {currentItem.Type} with +{currentItem.Stat}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(_currentMap._width + 9, 8);
                Console.WriteLine($"You already have a {currentItem.Type}");
                Console.SetCursorPosition(_currentMap._width + 9, 9);
                Console.WriteLine("Press \"R\" to replace or \"D\" to discard");
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.R)
                {
                    _currentPlayer.Items[currentItem.Type] = currentItem;
                }
                if (keyInfo.Key == ConsoleKey.D)
                {
                    _currentMapItems.Remove(currentItem);
                    DrawObjects();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(_currentMap._width + 9, 5);
                Console.WriteLine("You found a treasure chest");
                Console.SetCursorPosition(_currentMap._width + 9, 6);
                Console.WriteLine("Press Enter to open the Chest");
                Console.ReadKey();
                Console.SetCursorPosition(_currentMap._width + 9, 7);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You found a {currentItem.Type} with +{currentItem.Stat}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(_currentMap._width + 9, 8);
                Console.WriteLine("Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();
                _currentPlayer.Items.Add(currentItem.Type, currentItem);
            }
            _currentMapItems.Remove(currentItem);
            DrawObjects();
        }
        #endregion
    }

}
