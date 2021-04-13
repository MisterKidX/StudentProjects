using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using System.IO;

namespace Final_Project
{
    class Movement
    {
        private static Movement _moveInstance = null;
        public static Movement GetMoveInstance
        {
            get
            {
                if (_moveInstance == null)
                {
                    _moveInstance = new Movement();
                }
                return _moveInstance;
            }
        }        
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Traps> Traps = new List<Traps>();                
        SoundManager SoundManager = new SoundManager();
        public int PlayerX = 1;
        public int PlayerY = 1;
        public void GameMovement()
        {            
            MapsLettersPlacementGet();
            EnemyPlacement();
            TrapsPlacement();
            int redo = Player.GetPlayerInstance.Level;
            PlayerX = entrenceXPosition;
            PlayerY = entrenceYPosition;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                MapsLettersPlacementGet();                
                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Gray;
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] == "-" || Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] == "|")
                        {
                            continue;
                        }
                        if (Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] == "$")
                        {
                            //coinSoundEffect.Play();
                            SoundManager.CoinSoundEffect();
                            Player.GetPlayerInstance.Coins++;                            
                            Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] = " ";
                            Console.SetCursorPosition(1, 30);
                            DataBoard.GetDataInstance.PrintData();
                        }
                        if (Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] == "♥")
                        {
                            if (Player.GetPlayerInstance.PlayerHP < Player.GetPlayerInstance.PlayerMaxHP)
                            {
                                Player.GetPlayerInstance.PlayerHP += Player.GetPlayerInstance.HealPickup;
                                SoundManager.HealingSoundEffect();
                                if (Player.GetPlayerInstance.PlayerHP > Player.GetPlayerInstance.PlayerMaxHP)
                                {
                                    Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                                }
                                Maps.GetMapInstance.Map[PlayerY - 1, PlayerX] = " ";
                                Console.SetCursorPosition(1, 30);
                                DataBoard.GetDataInstance.PrintData();
                            }
                        }
                        Console.SetCursorPosition(PlayerX, PlayerY);
                        Console.Write(" ");
                        PlayerY--;

                        break;
                    case ConsoleKey.A:
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX - 1] == "|")
                        {
                            continue;
                        }
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX - 1] == "$")
                        {
                            //coinSoundEffect.Play();
                            SoundManager.CoinSoundEffect();
                            Player.GetPlayerInstance.Coins++;                            
                            Maps.GetMapInstance.Map[PlayerY, PlayerX - 1] = " ";
                            Console.SetCursorPosition(1, 30);
                            DataBoard.GetDataInstance.PrintData();
                        }
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX - 1] == "♥")
                        {
                            if (Player.GetPlayerInstance.PlayerHP < Player.GetPlayerInstance.PlayerMaxHP)
                            {
                                Player.GetPlayerInstance.PlayerHP += Player.GetPlayerInstance.HealPickup;
                                SoundManager.HealingSoundEffect();
                                if (Player.GetPlayerInstance.PlayerHP > Player.GetPlayerInstance.PlayerMaxHP)
                                {
                                    Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                                }
                                Maps.GetMapInstance.Map[PlayerY, PlayerX - 1] = " ";
                                Console.SetCursorPosition(1, 30);
                                DataBoard.GetDataInstance.PrintData();
                            }
                        }
                        Console.SetCursorPosition(PlayerX, PlayerY);
                        Console.Write(" ");
                        PlayerX--;

                        break;
                    case ConsoleKey.S:
                        if (Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] == "-" || Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] == "|")
                        {
                            continue;
                        }
                        if (Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] == "$")
                        {
                            //coinSoundEffect.Play();
                            SoundManager.CoinSoundEffect();
                            Player.GetPlayerInstance.Coins++;                            
                            Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] = " ";
                            Console.SetCursorPosition(1, 30);
                            DataBoard.GetDataInstance.PrintData();
                        }
                        if (Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] == "♥")
                        {
                            if (Player.GetPlayerInstance.PlayerHP < Player.GetPlayerInstance.PlayerMaxHP)
                            {
                                Player.GetPlayerInstance.PlayerHP += Player.GetPlayerInstance.HealPickup;
                                SoundManager.HealingSoundEffect();
                                if (Player.GetPlayerInstance.PlayerHP > Player.GetPlayerInstance.PlayerMaxHP)
                                {
                                    Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                                }
                                Maps.GetMapInstance.Map[PlayerY + 1, PlayerX] = " ";
                                Console.SetCursorPosition(1, 30);
                                DataBoard.GetDataInstance.PrintData();
                            }
                        }
                        Console.SetCursorPosition(PlayerX, PlayerY);
                        Console.Write(" ");
                        PlayerY++;

                        break;
                    case ConsoleKey.D:
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX + 1] == "|")
                        {
                            continue;
                        }
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX + 1] == "$")
                        {
                            //coinSoundEffect.Play();
                            SoundManager.CoinSoundEffect();
                            Player.GetPlayerInstance.Coins++;                           
                            Maps.GetMapInstance.Map[PlayerY, PlayerX + 1] = " ";
                            Console.SetCursorPosition(1, 30);
                            DataBoard.GetDataInstance.PrintData();
                        }
                        if (Maps.GetMapInstance.Map[PlayerY, PlayerX + 1] == "♥")
                        {
                            if (Player.GetPlayerInstance.PlayerHP < Player.GetPlayerInstance.PlayerMaxHP)
                            {
                                Player.GetPlayerInstance.PlayerHP += Player.GetPlayerInstance.HealPickup;
                                SoundManager.HealingSoundEffect();
                                if (Player.GetPlayerInstance.PlayerHP > Player.GetPlayerInstance.PlayerMaxHP)
                                {
                                    Player.GetPlayerInstance.PlayerHP = Player.GetPlayerInstance.PlayerMaxHP;
                                }
                                Maps.GetMapInstance.Map[PlayerY, PlayerX + 1] = " ";
                                Console.SetCursorPosition(1, 30);
                                DataBoard.GetDataInstance.PrintData();
                            }
                        }
                        Console.SetCursorPosition(PlayerX, PlayerY);
                        Console.Write(" ");
                        PlayerX++;
                        break;
                    case ConsoleKey.VolumeMute:
                        break;
                    case ConsoleKey.VolumeDown:
                        break;
                    case ConsoleKey.VolumeUp:
                    default:
                        break;
                }
                //Check trap
                foreach (var item in Traps)
                {                    
                    item.TrapPlacement();
                }
                //EnemyMovement1(x_Axis, y_Axis);
                foreach (var item in enemies)
                {
                    if (item.EnemyIsDead)
                    {
                        continue;
                    }
                    item.EnemyMovement1(PlayerX,PlayerY);
                }
                //0 HP 
                if (Player.GetPlayerInstance.PlayerHP <= 0)
                {
                    break;
                }
                //Ends the level
                if (PlayerX == endXPosition && PlayerY == endYPosition)
                {
                    Player.GetPlayerInstance.Level++;                    
                    break;
                }
                
            } while (redo == Player.GetPlayerInstance.Level);
        }
        int entrenceXPosition = 2;
        int entrenceYPosition = 28;
        int endXPosition = 0;
        int endYPosition = 0;
        public void MapsLettersPlacementGet()
        {                        
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    Console.SetCursorPosition(entrenceXPosition = 2, entrenceYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 50, endYPosition = 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 2:                    
                    Console.SetCursorPosition(entrenceXPosition = 3, entrenceYPosition = 2);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 5, endYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 3:
                    Console.SetCursorPosition(entrenceXPosition = 29, entrenceYPosition = 17);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 29, endYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 4:
                    Console.SetCursorPosition(entrenceXPosition = 57, entrenceYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 2, endYPosition = 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 5:
                    Console.SetCursorPosition(entrenceXPosition = 56, entrenceYPosition = 2);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 2, endYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 6:
                    Console.SetCursorPosition(entrenceXPosition = 54, entrenceYPosition = 16);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 54, endYPosition = 14);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 7:
                    Console.SetCursorPosition(entrenceXPosition = 4, entrenceYPosition = 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 55, endYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 8:
                    Console.SetCursorPosition(entrenceXPosition = 1, entrenceYPosition = 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 57, endYPosition = 28);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                   
                    break;
                case 9:
                    Console.SetCursorPosition(entrenceXPosition = 27, entrenceYPosition = 14);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 31, endYPosition = 14);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();                    
                    break;
                case 10:
                    Console.SetCursorPosition(entrenceXPosition = 1, entrenceYPosition = 14);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("E");
                    Console.SetCursorPosition(endXPosition = 58, endYPosition = 14);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("X");
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }                
        public void EnemyPlacement()
        {
            enemies = new List<Enemy>();
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    Enemy e = new Enemy(55, 27);
                    enemies.Add(e);
                    break;
                case 2:
                    Enemy e1 = new Enemy(50, 26);
                    enemies.Add(e1);
                    Enemy e2 = new Enemy(2, 12);
                    enemies.Add(e2);
                    break;
                case 3:
                    Enemy e3 = new Enemy(42, 1);
                    enemies.Add(e3);
                    Enemy e4 = new Enemy(1, 26);
                    enemies.Add(e4);
                    Enemy e5 = new Enemy(58, 26);
                    enemies.Add(e5);
                    break;
                case 4:
                    Enemy e6 = new Enemy(22, 2);
                    enemies.Add(e6);
                    Enemy e7 = new Enemy(2, 20);
                    enemies.Add(e7);
                    Enemy e8 = new Enemy(2, 11);
                    enemies.Add(e8);
                    Enemy e9 = new Enemy(33, 28);
                    enemies.Add(e9);
                    break;
                case 5:
                    Enemy e10 = new Enemy(2, 2);
                    enemies.Add(e10);
                    Enemy e11 = new Enemy(56, 28);
                    enemies.Add(e11);
                    Enemy e12 = new Enemy(30, 28);
                    enemies.Add(e12);
                    Enemy e13 = new Enemy(2, 15);
                    enemies.Add(e13);
                    Enemy e14 = new Enemy(8, 25);
                    enemies.Add(e14);
                    break;
                case 6:
                    Enemy e15 = new Enemy(1, 1);
                    enemies.Add(e15);
                    Enemy e16 = new Enemy(1, 28);
                    enemies.Add(e16);
                    Enemy e17 = new Enemy(58, 1);
                    enemies.Add(e17);
                    Enemy e18 = new Enemy(58, 28);
                    enemies.Add(e18);
                    Enemy e19 = new Enemy(17, 12);
                    enemies.Add(e19);
                    Enemy e20 = new Enemy(17, 18);
                    enemies.Add(e20);
                    break;
                case 7:
                    Enemy e21 = new Enemy(8, 19);
                    enemies.Add(e21);
                    Enemy e22 = new Enemy(58, 15);
                    enemies.Add(e22);                    
                    Enemy e23 = new Enemy(57, 1);
                    enemies.Add(e23);
                    Enemy e24 = new Enemy(8, 28);
                    enemies.Add(e24);
                    Enemy e25 = new Enemy(58, 17);
                    enemies.Add(e25);
                    Enemy e26 = new Enemy(22, 9);
                    enemies.Add(e26);
                    break;
                case 8:
                    Enemy e27 = new Enemy(57, 16);
                    enemies.Add(e27);
                    Enemy e28 = new Enemy(55, 5);
                    enemies.Add(e28);
                    Enemy e29 = new Enemy(22, 26);
                    enemies.Add(e29);
                    Enemy e30 = new Enemy(57, 19);
                    enemies.Add(e30);
                    Enemy e31 = new Enemy(15, 14);
                    enemies.Add(e31);
                    Enemy e32 = new Enemy(24, 9);
                    enemies.Add(e32);
                    break;
                case 9:
                    Enemy e33 = new Enemy(1, 1);
                    enemies.Add(e33);
                    Enemy e34 = new Enemy(1, 28);
                    enemies.Add(e34);
                    Enemy e35 = new Enemy(58, 28);
                    enemies.Add(e35);
                    Enemy e36 = new Enemy(58, 1);
                    enemies.Add(e36);
                    Enemy e37 = new Enemy(32, 7);
                    enemies.Add(e37);
                    Enemy e38 = new Enemy(32, 21);
                    enemies.Add(e38);
                    break;
                case 10:
                    Enemy e39 = new Enemy(22, 2);
                    enemies.Add(e39);
                    Enemy e40 = new Enemy(22, 27);
                    enemies.Add(e40);
                    Enemy e41 = new Enemy(40, 2);
                    enemies.Add(e41);
                    Enemy e42 = new Enemy(40, 27);
                    enemies.Add(e42);
                    break;
                default:
                    break;
            }
        }                      
        public void TrapsPlacement()
        {
            Traps = new List<Traps>();
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    Traps t = new Traps(7, 10);
                    Traps.Add(t);
                    Traps t1 = new Traps(50, 20);
                    Traps.Add(t1);
                    break;
                case 2:
                    Traps t2 = new Traps(9, 26);
                    Traps.Add(t2);
                    Traps t3 = new Traps(48, 9);
                    Traps.Add(t3);
                    break;
                case 3:
                    Traps t4 = new Traps(25, 25);
                    Traps.Add(t4);
                    Traps t5 = new Traps(36, 26);
                    Traps.Add(t5);
                    break;
                case 4:
                    Traps t6 = new Traps(25, 15);
                    Traps.Add(t6);
                    Traps t7 = new Traps(35, 5);
                    Traps.Add(t7);
                    Traps t8 = new Traps(35, 25);
                    Traps.Add(t8);
                    break;
                case 5:
                    Traps t9 = new Traps(26, 24);
                    Traps.Add(t9);
                    Traps t10 = new Traps(26, 7);
                    Traps.Add(t10);
                    Traps t11 = new Traps(5, 17);
                    Traps.Add(t11);
                    Traps t12 = new Traps(54, 12);
                    Traps.Add(t12);
                    break;
                case 6:
                    Traps t13 = new Traps(20, 27);
                    Traps.Add(t13);
                    Traps t14 = new Traps(20, 3);
                    Traps.Add(t14);
                    break;
                case 7:
                    Traps t15 = new Traps(25, 5);
                    Traps.Add(t15);
                    Traps t16 = new Traps(25, 20);
                    Traps.Add(t16);
                    Traps t17 = new Traps(51, 18);
                    Traps.Add(t17);
                    break;
                case 8:
                    Traps t18 = new Traps(38, 15);
                    Traps.Add(t18);
                    Traps t19 = new Traps(21, 21);
                    Traps.Add(t19);
                    break;
                case 9:
                    Traps t20 = new Traps(40, 25);
                    Traps.Add(t20);
                    Traps t21 = new Traps(40, 4);
                    Traps.Add(t21);
                    break;
                case 10:
                    Traps t22 = new Traps(22, 14);
                    Traps.Add(t22);
                    Traps t23 = new Traps(40, 14);
                    Traps.Add(t23);
                    break;
                default:
                    break;
            }
        }
    }
}
