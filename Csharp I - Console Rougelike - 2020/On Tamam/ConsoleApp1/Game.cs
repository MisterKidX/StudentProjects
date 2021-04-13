using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Game
    {
        private World GameWorld;
        private Player ProGamer;
        Random rnd = new Random();
        string classtype;
        int Elevel = 1;
        List<Enemy> enemies = new List<Enemy>();
        List<Chest> Chests = new List<Chest>();
        List<Trap> traps = new List<Trap>();
        UI GameUi = new UI();
        Shop shop;
        public void Start()
        {
            Console.Title = "On's game";
            RunMainMenu(); 
        }
        void RunMainMenu()
        {
            string title = @"
   _____     _  _      _____                            
  / ____|  _| || |_   / ____|                           
 | |      |_  __  _| | |  __    __ _   _ __ ___     ___ 
 | |       _| || |_  | | |_ |  / _` | | '_ ` _ \   / _ \
 | |____  |_  __  _| | |__| | | (_| | | | | | | | |  __/
  \_____|   |_||_|    \_____|  \__,_| |_| |_| |_|  \___|
                                                        
                                                        
use W and S to navigate menues press enter to select";
            string[] options = { "start", "who did dis", "exit" };
            Menu MainMenu = new Menu(title, options);
            int SelectedIndex = MainMenu.Run();
            switch (SelectedIndex)
            {
                case 0:
                    ClassMenu();
                    break;
                case 1:
                    DisplayInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        void ExitGame()
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("press any key to close game...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        void DisplayInfo()
        {
            Console.Clear();
            Console.WriteLine("made by On");
            Console.WriteLine("press something to go back to the main menu");
            Console.ReadKey(true);
            RunMainMenu();
        }
        void StartGame() //level
        {
            HandleEnemies();
            HandleChests();
            HandleTraps();
            ProGamer.kills = 0;
            shop = new Shop(Elevel, ProGamer);
            GameWorld = new World(enemies, shop, Chests, traps);
            GameLoop(1);
        }
        public void PrintFrame()// frame
        {
            Console.Clear();
            GameWorld.PrinWorld();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (GameWorld.CheckPositionValidation(enemies[i].EnemyX,enemies[i].EnemyY))
                {
                    enemies[i].printEnemy();
                }
                else
                {
                    enemies[i].EnemyX = rnd.Next(5, 20);
                    enemies[i].EnemyY = rnd.Next(5, 35);
                    i--;
                }
                
            }
            for (int i = 0; i < Chests.Count; i++)
            {
                Chests[i].PrintChest();
            }
            for (int i = 0; i < traps.Count; i++)
            {
                traps[i].PrintTrap();
            }
            shop.PrintShop();
            ProGamer.PrintPlayer();
            GameUi.PrintUi(ProGamer);
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.W:
                    if (GameWorld.CheckPositionValidation(ProGamer.PlayerX, ProGamer.PlayerY -1) == true)
                    {
                        ProGamer.PlayerY -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (GameWorld.CheckPositionValidation(ProGamer.PlayerX, ProGamer.PlayerY + 1) == true)
                    {
                        ProGamer.PlayerY += 1;
                    }
                    break; 
                case ConsoleKey.D:
                    if (GameWorld.CheckPositionValidation(ProGamer.PlayerX + 1, ProGamer.PlayerY) == true)
                    {
                        ProGamer.PlayerX += 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (GameWorld.CheckPositionValidation(ProGamer.PlayerX - 1, ProGamer.PlayerY) == true)
                    {
                        ProGamer.PlayerX -= 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    PauseMenu();
                    break;
                case ConsoleKey.E:
                    CharacterPage();
                    break;
                default:
                    break;
            }
        }

        void GameLoop(int gur)//print enemies, print player, print treasure chests, print shops
        {
            if (gur == 1)
            {
                PrintFrame();
                HandleEnemies();
                HandleChests();
                HandleTraps();
            }
            
            bool Victory = false;
            while (Victory == false || ProGamer.HP == 0)
            {
                // draw the world
                PrintFrame();
                //execute player input if possbile 
                HandlePlayerInput();
                //checking if player beat the level
                GameWorld.SeekPlayer(ProGamer);
                if (GameWorld.CheckCombatPosition(ProGamer.PlayerX, ProGamer.PlayerY) == true)
                {
                   // Console.WriteLine("first if worked");
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].EnemyX == ProGamer.PlayerX && enemies[i].EnemyY == ProGamer.PlayerY &&enemies[i].HP >0)
                        {
                            Enemy Combatant = enemies[i];
                            Console.SetCursorPosition(51, 2);
                            Console.WriteLine("combat started");
                            Console.ReadKey();
                            Combat battle = new Combat(ProGamer, Combatant);
                            battle.StartCombat();
                        }
                    }
                }
                if (GameWorld.CheckShopPositon(ProGamer.PlayerX, ProGamer.PlayerY) == true)
                {
                    shop.RunShop();
                }
                if (GameWorld.CheckChestPosition(ProGamer.PlayerX, ProGamer.PlayerY) == true)
                {
                    for (int i = 0; i < Chests.Count; i++)
                    {
                        if (Chests[i].x == ProGamer.PlayerX && Chests[i].y == ProGamer.PlayerY && Chests[i].taken==false)
                        {
                            if (ProGamer.keys >= 1)
                            {
                                Chests[i].run();
                                ProGamer.keys--;
                            }
                            else
                            {
                                Console.SetCursorPosition(52, 2);
                                Console.Write("key is required");
                                Console.ReadKey(true);
                            }
                               
                        }
                    }
                }
                if (GameWorld.CheckTrapPosition(ProGamer.PlayerX, ProGamer.PlayerY))
                {
                    for (int i = 0; i < traps.Count; i++)
                    {
                        if (traps[i].x == ProGamer.PlayerX && traps[i].y == ProGamer.PlayerY && traps[i].Triggered == false)
                        {
                            traps[i].Trigger(ProGamer);
                        }
                    }
                }

                if (GameWorld.CheckVictoryPosition(ProGamer.PlayerX, ProGamer.PlayerY) == true && ProGamer.kills >= enemies.Count)
                {
                    Victory = true;
                }
                //giving the colsone a chance to render
                System.Threading.Thread.Sleep(20);
            }
            Elevel++;
            StartGame();
        }

        void PauseMenu()
        {
            string Pausetitle = @"
   _____     _  _      _____                            
  / ____|  _| || |_   / ____|                           
 | |      |_  __  _| | |  __    __ _   _ __ ___     ___ 
 | |       _| || |_  | | |_ |  / _` | | '_ ` _ \   / _ \
 | |____  |_  __  _| | |__| | | (_| | | | | | | | |  __/
  \_____|   |_||_|    \_____|  \__,_| |_| |_| |_|  \___|
                                                        
                                                        
use W and S to navigate menues press enter to select"; 
            string[] PauseOptions = { "Resume", "Main Menu", "Exit","How to Play" };
            Menu PauseMenuM = new Menu(Pausetitle, PauseOptions);
            int SelectIndexPause = PauseMenuM.Run();
            switch (SelectIndexPause)
            {
                case 0:
                    GameLoop(0);
                    break;
                case 1:
                    RunMainMenu();
                    break;
                case 2:
                    ExitGame();
                    break;
                case 3:
                    Console.WriteLine("Controls -");
                    Console.WriteLine("use W A S D to move");
                    Console.WriteLine("press E to open character page");
                    Console.WriteLine("Press Any Key To Go Back");
                    Console.ReadKey();
                    PauseMenu();
                    break;
                default:
                    GameLoop(0);
                    break;
            }
        }

        void ClassMenu()
        {
            Elevel = 1;
            string Prompt = "Which class would you like to play?";
            string[] Options = { "Rogue", "Mage", "Warrior", "return to main menu" };
            Menu ClassChoice = new Menu(Prompt, Options);
            int SelectedIndexClass = ClassChoice.Run();
            switch (SelectedIndexClass)
            {
                case 0:
                    classtype = "Rogue";
                    ProGamer = new Player(rnd.Next(1, 10), rnd.Next(1, 10), classtype);
                    Console.Clear();
                    Console.WriteLine("Rogue class selected");
                    Console.ReadKey(true);
                    StartGame();
                    break;
                case 1:
                    classtype = "Mage";
                    ProGamer = new Player(rnd.Next(1, 10), rnd.Next(1, 10), classtype);
                    Console.Clear();
                    Console.WriteLine("Mage class selected");
                    Console.ReadKey(true);
                    StartGame();
                    break;
                case 2:
                    classtype = "Warrior";
                    ProGamer = new Player(rnd.Next(1, 10), rnd.Next(1, 10), classtype);
                    Console.Clear();
                    Console.WriteLine("Warrior class selected");
                    Console.ReadKey(true);
                    StartGame();
                    break;
                case 3:
                    Console.Clear();
                    RunMainMenu();
                    break;
            }
        }

        void CharacterPage()
        {
            string Prompt = ProGamer.ClassType + " " + ProGamer.level;
            string[] Options = { "View Stats", "Open Inventory","Resume"};
            Menu CharacterPageMenu = new Menu(Prompt, Options);
            int SelectIndexChar = CharacterPageMenu.Run();
            switch (SelectIndexChar)
            {
                case 0:
                    Console.WriteLine(" HP - " + ProGamer.currenthp + " /" + ProGamer.HP); 
                    Console.WriteLine(" DEX - " + ProGamer.Dexterity); 
                    Console.WriteLine(" STR - " + ProGamer.strength); 
                    Console.WriteLine(" INT - " + ProGamer.intelligence); 
                    Console.WriteLine(" MAG DEF - " + ProGamer.MagRes); 
                    Console.WriteLine(" DEF - " + ProGamer.Armor);
                    Console.WriteLine(" XP - " + ProGamer.XP + " /" + ProGamer.xptonext);
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key To Go Back");
                    Console.ReadKey();
                    CharacterPage();
                    break;
                case 1:
                    ProGamer.OpenInventory();
                    break;
                case 2:
                    GameLoop(0);
                    break;
            }
        }

        void HandleEnemies()
        {
            enemies.Clear();
            EnemySpawner MonsterMaker = new EnemySpawner();
            int enemyamount = rnd.Next(1, Elevel);
            for (int i = 0; i < enemyamount; i++)
            {
                enemies.Add(MonsterMaker.createEnemy(rnd.Next(1, 3), Elevel));
                
            }
            
            //decide how many enemies will there be
            // decide their types
        }
        void HandleChests()
        {
            Chests.Clear();
            EnemySpawner ChestMaker = new EnemySpawner(); 
            int ChestAmount = rnd.Next(1, Elevel/2+1);
            for (int i = 0; i < ChestAmount; i++)
            {
                Chests.Add(ChestMaker.CreateChest(ProGamer, Elevel));
            }
            
        }

        void HandleTraps()
        {
            traps.Clear();
            EnemySpawner trapMaker = new EnemySpawner();
            int TrapAmount = rnd.Next(1, Elevel / 4 + 1);
            for (int i = 0; i < TrapAmount; i++)
            {
                traps.Add(trapMaker.CreateTrap(Elevel, rnd.Next(1,3)));
            }

        }

       
    }
}
