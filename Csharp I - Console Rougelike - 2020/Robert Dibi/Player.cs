using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
    class Player
    {

        public string Name;
        public bool InvalidName = true;
        public float MaxHP = 100f;
        public float CurrentHP = 100f;
        public float PotionHP = 15;
        public float CurrentDamage = 20f;
        public float LostSouls = 0;
        public int PotionCounter = 0;
        public int EnemyDmg = 15;
        public float EnemiesKilled;
        public string SoulIcon = "¢";
        public char PlayerToken = '@';
        public int LevelCounter = Map.GetMapInstance.LevelCounter;
        public int UpcomingLevel = 2;
        public bool PlayerIsAlive = false;
        Sounds SoundMngr = new Sounds();
        private static Player _playerInstance = null;
        public static Player GetPlayerInstance
        {
            get
            {
                if (_playerInstance == null)
                {
                    _playerInstance = new Player();
                }
                return _playerInstance;
            }
        }
        public bool TrapIsTriggered = false;
        public void CheckName()
        {

            do
            {
                if (Name == "")
                {
                    Console.WriteLine("We didn't quite understand that....");
                    Console.WriteLine("What is your name ? __");
                    Name = Console.ReadLine();
                }
                else
                {
                    InvalidName = false;
                }

            } while (InvalidName);
        }
        public int PlayerX = 1;
        public int PlayerY = 1;
        public void CheckMove()
        {
            GetIcons();
            GetEnemy();
            GetTrap();

            int redo = LevelCounter;
            PlayerY = EntranceY;
            PlayerX = EntranceX;
            ConsoleKeyInfo Key;
            /*  Console.SetCursorPosition(playerX, playerY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerToken);*/
            Console.ResetColor();
            if (!PlayerIsAlive)
            {
                do
                {
                    /*enemyMovement(playerX, playerY);*/
                    GetIcons();
                    Console.SetCursorPosition(PlayerX, PlayerY);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(PlayerToken);
                    Console.ResetColor();
                    Key = Console.ReadKey(true);

                    switch (Key.Key)
                    {
                        case ConsoleKey.W:
                            if (Map.GetMapInstance.box[PlayerY - 1, PlayerX] == Map.GetMapInstance.Chest)
                            {
                                SoundMngr.PotionPickUp();
                                Map.GetMapInstance.box[PlayerY - 1, PlayerX] = " ";
                                PotionCounter++;
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You Picked Up A Potion!                                                                 ");
                            }
                            if (Map.GetMapInstance.box[PlayerY - 1, PlayerX] == "-" || Map.GetMapInstance.box[PlayerY - 1, PlayerX] == "|")
                            {
                                continue;
                            }
                            if (Map.GetMapInstance.box[PlayerY - 1, PlayerX] == "¢")
                            {
                                SoundMngr.SoulPickUp();
                                LostSouls++;
                                Map.GetMapInstance.box[PlayerY - 1, PlayerX] = " ";
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You collected a lost soul!                                                   ");

                            }

                            Console.SetCursorPosition(PlayerX, PlayerY);
                            Console.Write(" ");
                            PlayerY--;


                            break;
                        case ConsoleKey.A:
                            if (Map.GetMapInstance.box[PlayerY, PlayerX - 1] == Map.GetMapInstance.Chest)
                            {
                                SoundMngr.PotionPickUp();
                                Map.GetMapInstance.box[PlayerY, PlayerX - 1] = " ";
                                PotionCounter++;
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You Picked Up A Potion!                                                                 ");
                            }
                            if (Map.GetMapInstance.box[PlayerY, PlayerX - 1] == "|")
                            {
                                continue;
                            }
                            if (Map.GetMapInstance.box[PlayerY, PlayerX - 1] == "¢")
                            {
                                SoundMngr.SoulPickUp();
                                LostSouls++;
                                Map.GetMapInstance.box[PlayerY, PlayerX - 1] = " ";
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You collected a lost soul!                                                      ");
                            }


                            Console.SetCursorPosition(PlayerX, PlayerY);
                            Console.Write(" ");
                            PlayerX--;

                            break;
                        case ConsoleKey.S:
                            if (Map.GetMapInstance.box[PlayerY + 1, PlayerX] == Map.GetMapInstance.Chest)
                            {
                                SoundMngr.PotionPickUp();
                                Map.GetMapInstance.box[PlayerY + 1, PlayerX] = " ";
                                PotionCounter++;
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You Picked Up A Potion!                                                                 ");
                            }
                            if (Map.GetMapInstance.box[PlayerY + 1, PlayerX] == "-" || Map.GetMapInstance.box[PlayerY + 1, PlayerX] == "|")
                            {
                                continue;
                            }
                            if (Map.GetMapInstance.box[PlayerY + 1, PlayerX] == "¢")
                            {
                                SoundMngr.SoulPickUp();
                                LostSouls++;
                                Map.GetMapInstance.box[PlayerY + 1, PlayerX] = " ";
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You collected a lost soul!                                                            ");
                            }


                            Console.SetCursorPosition(PlayerX, PlayerY);
                            Console.Write(" ");
                            PlayerY++;

                            break;
                        case ConsoleKey.D:
                            if (Map.GetMapInstance.box[PlayerY, PlayerX + 1] == Map.GetMapInstance.Chest)
                            {
                                SoundMngr.PotionPickUp();
                                Map.GetMapInstance.box[PlayerY, PlayerX + 1] = " ";
                                PotionCounter++;
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You Picked Up A Potion!                                                                 ");
                            }
                            if (Map.GetMapInstance.box[PlayerY, PlayerX + 1] == "|")
                            {
                                continue;
                            }

                            if (Map.GetMapInstance.box[PlayerY, PlayerX + 1] == "¢")
                            {
                                SoundMngr.SoulPickUp();
                                LostSouls++;
                                Map.GetMapInstance.box[PlayerY, PlayerX + 1] = " ";
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You collected a lost soul!                                                                ");
                            }


                            Console.SetCursorPosition(PlayerX, PlayerY);
                            Console.Write(" ");
                            PlayerX++;

                            break;
                        case ConsoleKey.H:
                            if (CurrentHP != MaxHP && PotionCounter > 0)
                            {
                                if (CurrentHP > MaxHP && PotionCounter > 0)
                                {

                                    Console.SetCursorPosition(0, 25);
                                    HUD.GetHUDInstance.ShowHUD();
                                    Console.WriteLine("You are overhealed!                                                                      ");
                                    break;
                                }
                                SoundMngr.PotionPickUp();
                                PotionCounter -= 1;
                                CurrentHP += PotionHP;
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("Potion Healed " + PotionHP + "!                                                             ");
                                break;
                            }
                            else if (PotionCounter > 0)
                            {

                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You are on full health , so it doesn't help you              ");
                                break;
                            }

                            else
                            {
                                Console.SetCursorPosition(0, 25);
                                HUD.GetHUDInstance.ShowHUD();
                                Console.WriteLine("You dont have any potions                                   ");
                                break;
                            }





                    }
                    if (CurrentHP <= 0)
                    {
                        Map.GetMapInstance.LevelCounter = 12;

                    }
                    foreach (var item in traps)
                    {

                      /*  if (item.trapistriggred)
                        {
                            continue;
                        }*/
                       /* if (playerX == item.TrapX && playerY == item.TrapY)
                        {
                            SOUNDMNGR.TrapHit();
                            trapIsTriggered = true;
                            Player.getPlayerInstance.currentHP -= 5;
                            Console.SetCursorPosition(0, 25);
                            HUD.getHUDInstance.showHUD();
                            Console.WriteLine("You hit a trap , you lost 5 hp!                                                    ");

                        }*/
                        item.GetTrap(/*playerX,playerY,trapIsTriggered*/);
                    }


                    foreach (var item in enemies)
                    {
                        if (item.EnemyIsDead)
                        {
                            continue;
                        }
                        item.EnemyMovement(PlayerX, PlayerY);
                    }
                    if (PlayerX == ExitX && PlayerY == exitY)
                    {
                        SoundMngr.LvlUp();
                        LevelCounter++;
                        Map.GetMapInstance.LevelCounter++;
                        break;
                    }


                } while (redo == Map.GetMapInstance.LevelCounter);

            }

        }
        public static List<Enemy> enemies = new List<Enemy>();


        public int EntranceX = 1;
        public int EntranceY = 23;

        public int ExitX = 0;
        public int exitY = 0;
        public int ChestX = 0;
        public int ChestY = 0;
        public int SoulX = 0;
        public int SoulY = 0;
        public int TrapX = 3;
        public int TrapY = 20;
        public void GetIcons()
        {
            

            switch (LevelCounter)
            {
                case 1:
                    Console.SetCursorPosition(EntranceX = 1, EntranceY = 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 48, exitY = 1);
                    Console.Write(Map.GetMapInstance.Exit);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.SetCursorPosition(EntranceX = 48, EntranceY = 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 1, exitY = 23);
                    Console.Write(Map.GetMapInstance.Exit);


                    Console.ResetColor();
                    break;
                case 3:

                    Console.SetCursorPosition(EntranceX = 48, EntranceY = 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 1, exitY = 23);
                    Console.Write(Map.GetMapInstance.Exit);
                    Console.ResetColor();
                    break;
                case 4:
                    Console.SetCursorPosition(EntranceX = 48, EntranceY = 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 1, exitY = 10);
                    Console.Write(Map.GetMapInstance.Exit);

                    break;
                case 5:
                    Console.SetCursorPosition(EntranceX = 48, EntranceY = 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 1, exitY = 23);
                    Console.Write(Map.GetMapInstance.Exit);

                    break;
                case 6:
                    Console.SetCursorPosition(EntranceX = 24, EntranceY = 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 48, exitY = 1);
                    Console.Write(Map.GetMapInstance.Exit);

                    break;
                case 7:
                    Console.SetCursorPosition(EntranceX = 24, EntranceY = 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 25, exitY = 1);
                    Console.Write(Map.GetMapInstance.Exit);
 
                    break;
                case 8:
                    Console.SetCursorPosition(EntranceX = 24, EntranceY = 23);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 24, exitY = 1);
                    Console.Write(Map.GetMapInstance.Exit);

                    break;
                case 9:
                    Console.SetCursorPosition(EntranceX = 2, EntranceY = 12);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 48, exitY = 12);
                    Console.Write(Map.GetMapInstance.Exit);

                    break;
                case 10:
                    Console.SetCursorPosition(EntranceX = 2, EntranceY = 11);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Map.GetMapInstance.Entrance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(ExitX = 48, exitY = 11);
                    Console.Write(Map.GetMapInstance.Exit);
                    break;
                default:
                    break;
            }

        }
        void GetEnemy()
        {
            enemies = new List<Enemy>();
            switch (LevelCounter)
            {
                case 1:
                    Enemy e = new Enemy(42, 1);
                    enemies.Add(e);
                    break;
                case 2:
                    Enemy e1 = new Enemy(32, 1);
                    enemies.Add(e1);
                    Enemy e2 = new Enemy(42, 23);
                    enemies.Add(e2);
                    break;
                case 3:
                    Enemy e3 = new Enemy(30, 1);
                    enemies.Add(e3);
                    Enemy e4 = new Enemy(38, 20);
                    enemies.Add(e4);
                    Enemy e5 = new Enemy(5, 21);
                    enemies.Add(e5);
                    break;
                case 4:
                    Enemy e6 = new Enemy(30, 1);
                    enemies.Add(e6);
                    Enemy e7 = new Enemy(10, 4);
                    enemies.Add(e7);
                    Enemy e8 = new Enemy(27, 23);
                    enemies.Add(e8);
                    Enemy e9 = new Enemy(7, 21);
                    enemies.Add(e9);
                    break;
                case 5:
                    Enemy e10 = new Enemy(35, 9);
                    enemies.Add(e10);
                    Enemy e11 = new Enemy(22, 11);
                    enemies.Add(e11);
                    Enemy e12 = new Enemy(27, 23);
                    enemies.Add(e12);
                    Enemy e13 = new Enemy(7, 21);
                    enemies.Add(e13);
                    break;
                case 6:
                    Enemy e14 = new Enemy(37, 9);
                    enemies.Add(e14);
                    Enemy e15 = new Enemy(37, 23);
                    enemies.Add(e15);
                    Enemy e16 = new Enemy(10, 23);
                    enemies.Add(e16);
                    Enemy e17 = new Enemy(6, 15);
                    enemies.Add(e17);
                    break;
                case 7:
                    Enemy e18 = new Enemy(1, 3);
                    enemies.Add(e18);
                    Enemy e19 = new Enemy(47, 3);
                    enemies.Add(e19);
                    Enemy e20 = new Enemy(3, 15);
                    enemies.Add(e20);
                    Enemy e21 = new Enemy(46, 15);
                    enemies.Add(e21);
                    break;
                case 8:
                    Enemy e22 = new Enemy(1, 3);
                    enemies.Add(e22);
                    Enemy e23 = new Enemy(47, 3);
                    enemies.Add(e23);
                    Enemy e24 = new Enemy(3, 15);
                    enemies.Add(e24);
                    Enemy e25 = new Enemy(46, 15);
                    enemies.Add(e25);
                    break;
                case 9:
                    break;
                case 10:
                    Enemy e26 = new Enemy(21, 1);
                    enemies.Add(e26);
                    Enemy e27 = new Enemy(20, 4);
                    enemies.Add(e27);
                    Enemy e28 = new Enemy(19, 7);
                    enemies.Add(e28);
                    Enemy e29 = new Enemy(19, 14);
                    enemies.Add(e29);
                    Enemy e30 = new Enemy(20, 17);
                    enemies.Add(e30);
                    Enemy e31 = new Enemy(21, 20);
                    enemies.Add(e31);
                    Enemy e32 = new Enemy(10, 14);
                    enemies.Add(e32);
                    Enemy e33 = new Enemy(10, 17);
                    enemies.Add(e33);
                    Enemy e34 = new Enemy(10, 20);
                    enemies.Add(e34);
                    Enemy e35 = new Enemy(10, 1);
                    enemies.Add(e35);
                    Enemy e36 = new Enemy(10, 4);
                    enemies.Add(e36);
                    Enemy e37 = new Enemy(10, 7);
                    enemies.Add(e37);
                    break;
                default:
                    break;
            }


        }

        public static List<Trap> traps = new List<Trap>();

        void GetTrap()
        {
            
            traps = new List<Trap>();
            switch (LevelCounter)
            {
                case 1:
                    Trap t = new Trap(2, 23);
                    traps.Add(t);
                    Trap t1 = new Trap(46, 2);
                    traps.Add(t1);
                        break;
                case 2:
                    Trap t2 = new Trap(7, 23);
                    traps.Add(t2);
                    Trap t3 = new Trap(48, 5);
                    traps.Add(t3);
                    break;
                case 3:
                    Trap t5 = new Trap(48, 5);
                    traps.Add(t5);
                    Trap t6 = new Trap(20, 1);
                    traps.Add(t6);
                    Trap t7 = new Trap(45, 1);
                    traps.Add(t7);
                    Trap t8 = new Trap(3, 22);
                    traps.Add(t8);
                    break;
                case 4:
                    Trap t9 = new Trap(20, 23);
                    traps.Add(t9);
                    Trap t10 = new Trap(20, 1);
                    traps.Add(t10);
                    Trap t11 = new Trap(48, 20);
                    traps.Add(t11);
                    Trap t12 = new Trap(3, 22);
                    traps.Add(t12);
                    break;
                case 5:
                    Trap t13 = new Trap(20, 1);
                    traps.Add(t13);
                    Trap t14 = new Trap(46, 6);
                    traps.Add(t14);
                    Trap t15 = new Trap(48, 6);
                    traps.Add(t15);
                    Trap t16 = new Trap(47, 6);
                    traps.Add(t16);
                    break;
                case 6:
                    Trap t17 = new Trap(4, 23);
                    traps.Add(t17);
                    Trap t18 = new Trap(45, 23);
                    traps.Add(t18);
                    Trap t19 = new Trap(48, 6);
                    traps.Add(t19);
                    Trap t20 = new Trap(2, 6);
                    traps.Add(t20);
                    break;
                case 7:
                    Trap t21 = new Trap(4, 23);
                    traps.Add(t21);
                    Trap t22 = new Trap(45, 23);
                    traps.Add(t22);
                    Trap t23 = new Trap(47, 6);
                    traps.Add(t23);
                    Trap t24 = new Trap(2, 6);
                    traps.Add(t24);
                    break;
                case 8:
                    Trap t25 = new Trap(4, 23);
                    traps.Add(t25);
                    Trap t26 = new Trap(45, 23);
                    traps.Add(t26);
                    Trap t27 = new Trap(47, 10);
                    traps.Add(t27);
                    Trap t28 = new Trap(2, 10);
                    traps.Add(t28);
                    break;
                case 9:
                    break;
                case 10:
                    Trap t29 = new Trap(30, 2);
                    traps.Add(t29);
                    Trap t30 = new Trap(30, 3);
                    traps.Add(t30);
                    Trap t31 = new Trap(30, 4);
                    traps.Add(t31);
                    Trap t32 = new Trap(30, 5);
                    traps.Add(t32);
                    Trap t33 = new Trap(30, 6);
                    traps.Add(t33);
                    Trap t34 = new Trap(30, 7);
                    traps.Add(t34);
                    Trap t35 = new Trap(30, 8);
                    traps.Add(t35);
                    Trap t36 = new Trap(30, 9);
                    traps.Add(t36);
                    Trap t37 = new Trap(30, 10);
                    traps.Add(t37);
                    Trap t38 = new Trap(30, 11);
                    traps.Add(t38);
                    Trap t39 = new Trap(30, 12);
                    traps.Add(t39);
                    Trap t40 = new Trap(30, 13);
                    traps.Add(t40);
                    Trap t41 = new Trap(30, 14);
                    traps.Add(t41);
                    Trap t42 = new Trap(30, 15);
                    traps.Add(t42);
                    Trap t43 = new Trap(30, 16);
                    traps.Add(t43);
                    Trap t44 = new Trap(30, 17);
                    traps.Add(t44);
                    Trap t45 = new Trap(30, 18);
                    traps.Add(t45);
                    Trap t46 = new Trap(30, 19);
                    traps.Add(t46);
                    Trap t47 = new Trap(30, 20);
                    traps.Add(t47);
                    Trap t48 = new Trap(30, 21);
                    traps.Add(t48);


                  
                    break;
                default:
                    break;
            }


        }
    }


}


    



