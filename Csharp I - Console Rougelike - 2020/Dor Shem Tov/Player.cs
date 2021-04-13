using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    public class Player
    {
        private static Player _playerInstance = null;
        public static Player PlayerInstance
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
        public int baseHP = 100;
        public int Damage = 10;
        public int Coins = 0;
        public bool LevelOver = false;
        public int Level = 1;
        public char PlayerAvatar = '@';
        public int X = 1;
        public int Y = 1;
        public int EntrenceX = 1;
        public int EntrenceY = 1;
        public int EndX = 0;
        public int EndY = 0;
        public List<Enemy> enemies;
        public List<Trap> traps;


        public void PlayerMovement()
        {
            DrawEntranceAndExit();
            DrawEnemy();
            DrawTraps();
            X = EntrenceX;
            Y = EntrenceY;
            int movement = Level;
            ConsoleKeyInfo input;
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(PlayerAvatar);
            Console.ResetColor();
            do
            {
                DrawEntranceAndExit();
                foreach (var item in enemies)
                {
                    if (item.IsDead)
                    {
                        continue;
                    }
                    item.Move(X, Y);
                }
                foreach (var item in traps)
                {
                    item.ShowTrap();
                }
                Console.SetCursorPosition(X, Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(PlayerAvatar);
                Console.ResetColor();
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.W:
                        if (Map.MapInstance.Map2D[Y - 1, X] == '-' || Map.MapInstance.Map2D[Y - 1, X] == '|')
                        {
                            continue;
                        }
                        if (Map.MapInstance.Map2D[Y - 1, X] == '+')
                        {
                            Console.Beep(415, 250);
                            baseHP += 10;
                            Map.MapInstance.Map2D[Y - 1, X] = ' ';
                            Console.SetCursorPosition(0, 40);
                            Hud.HudInstance.PrintHud();
                        }
                        Console.SetCursorPosition(X, Y);
                        Console.Write(' ');
                        Y--;
                        break;
                    case ConsoleKey.A:
                        if (Map.MapInstance.Map2D[Y, X - 1] == '|')
                        {
                            continue;
                        }
                        if (Map.MapInstance.Map2D[Y, X - 1] == '+')
                        {
                            Console.Beep(415, 250);
                            baseHP += 10;
                            Map.MapInstance.Map2D[Y, X - 1] = ' ';
                            Console.SetCursorPosition(0, 40);
                            Hud.HudInstance.PrintHud();
                        }
                        Console.SetCursorPosition(X, Y);
                        Console.Write(' ');
                        X--;
                        break;
                    case ConsoleKey.S:
                        if (Map.MapInstance.Map2D[Y + 1, X] == '-' || Map.MapInstance.Map2D[Y + 1, X] == '|')
                        {
                            continue;
                        }
                        if (Map.MapInstance.Map2D[Y + 1, X] == '+')
                        {
                            Console.Beep(415, 250);
                            baseHP += 10;
                            Map.MapInstance.Map2D[Y + 1, X] = ' ';
                            Console.SetCursorPosition(0, 40);
                            Hud.HudInstance.PrintHud();
                        }
                        Console.SetCursorPosition(X, Y);
                        Console.Write(' ');
                        Y++;
                        break;
                    case ConsoleKey.D:
                        if (Map.MapInstance.Map2D[Y, X + 1] == '|')
                        {
                            continue;
                        }
                        if (Map.MapInstance.Map2D[Y, X + 1] == '+')
                        {
                            Console.Beep(415, 250);
                            baseHP += 10;
                            Map.MapInstance.Map2D[Y, X + 1] = ' ';
                            Console.SetCursorPosition(0, 40);
                            Hud.HudInstance.PrintHud();
                        }
                        Console.SetCursorPosition(X, Y);
                        Console.Write(' ');
                        X++;
                        break;
                    default:
                        break;
                }
                if (baseHP <= 0)
                {
                    break;
                }
                if (X == EndX && Y == EndY)
                {
                    Level++;
                    Coins += 2;
                    Console.Beep(493, 250);
                    break;
                }
            } while (movement == Level);
        }

        public void DrawEntranceAndExit()
        {


            switch (Level)
            {
                case 1:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 2:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 3:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 4:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 5:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 6:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 7:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 8:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 9:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                case 10:
                    Console.SetCursorPosition(EntrenceX = 1, EntrenceY = 1);
                    Console.Write('E');
                    Console.SetCursorPosition(EndX = 78, EndY = 38);
                    Console.Write('X');
                    break;
                default:
                    break;
            }
        }
        
        public void DrawEnemy()
        {
            enemies = new List<Enemy>();
            switch (Level)
            {
                case 1:
                    break;
                case 2:
                    Enemy e = new Enemy(38, 38);
                    enemies.Add(e);
                    break;
                case 3:
                    Enemy e2 = new Enemy(65, 35);
                    enemies.Add(e2);
                    break;
                case 4:
                    Enemy e3 = new Enemy(75, 30);
                    Enemy e4 = new Enemy(10, 35);
                    enemies.Add(e3);
                    enemies.Add(e4);
                    break;
                case 5:
                    Enemy e5 = new Enemy(70, 10);
                    Enemy e6 = new Enemy(65, 30);
                    Enemy e7 = new Enemy(40, 35);
                    enemies.Add(e5);
                    enemies.Add(e6);
                    enemies.Add(e7);
                    break;
                case 6:
                    Enemy e8 = new Enemy(70, 10);
                    Enemy e9 = new Enemy(65, 30);
                    Enemy e10 = new Enemy(40, 35);
                    enemies.Add(e8);
                    enemies.Add(e9);
                    enemies.Add(e10);
                    break;
                case 7:
                    Enemy e11 = new Enemy(55, 38);
                    Enemy e12 = new Enemy(75, 38);
                    Enemy e13 = new Enemy(38, 38);
                    enemies.Add(e11);
                    enemies.Add(e12);
                    enemies.Add(e13);
                    break;
                case 8:
                    Enemy e14 = new Enemy(10, 38);
                    Enemy e15 = new Enemy(30, 38);
                    Enemy e16 = new Enemy(75, 10);
                    enemies.Add(e14);
                    enemies.Add(e15);
                    enemies.Add(e16);
                    break;
                case 9:
                    Enemy e17 = new Enemy(75, 38);
                    Enemy e18 = new Enemy(38, 38);
                    Enemy e19 = new Enemy(55, 36);
                    enemies.Add(e17);
                    enemies.Add(e18);
                    enemies.Add(e19);
                    break;
                case 10:
                    Enemy e20 = new Enemy(10, 37);
                    Enemy e21 = new Enemy(25, 37);
                    Enemy e22 = new Enemy(75, 36);
                    enemies.Add(e20);
                    enemies.Add(e21);
                    enemies.Add(e22);
                    break;
                default:
                    break;
            }
        }
        
        public void DrawTraps()
        {
            traps = new List<Trap>();
            switch (Level)
            {
                case 1:
                    Trap t = new Trap(15, 15);
                    traps.Add(t);
                    break;
                case 2:
                    Trap t1 = new Trap(15, 15);
                    Trap t2 = new Trap(30, 20);
                    Trap t3 = new Trap(65, 7);
                    traps.Add(t1);
                    traps.Add(t2);
                    traps.Add(t3);
                    break;
                case 3:
                    Trap t4 = new Trap(65, 7);
                    Trap t5 = new Trap(20, 14);
                    Trap t6 = new Trap(10, 30);
                    Trap t7 = new Trap(55, 10);
                    traps.Add(t4);
                    traps.Add(t5);
                    traps.Add(t6);
                    traps.Add(t7);
                    break;
                case 4:
                    Trap t8 = new Trap(65, 7);
                    Trap t9 = new Trap(20, 14);
                    Trap t10 = new Trap(10, 30);
                    Trap t11 = new Trap(55, 10);
                    Trap t12 = new Trap(35, 23);
                    Trap t13 = new Trap(40, 35);
                    Trap t14 = new Trap(60, 5);
                    traps.Add(t8);
                    traps.Add(t9);
                    traps.Add(t10);
                    traps.Add(t11);
                    traps.Add(t12);
                    traps.Add(t13);
                    traps.Add(t14);
                    break;
                case 5:
                    Trap t15 = new Trap(65, 7);
                    Trap t16 = new Trap(20, 14);
                    Trap t17 = new Trap(55, 10);
                    Trap t18 = new Trap(35, 23);
                    Trap t19 = new Trap(40, 35);
                    Trap t20 = new Trap(60, 5);
                    Trap t21 = new Trap(20, 2);
                    Trap t22 = new Trap(25, 12);
                    Trap t23 = new Trap(35, 23);
                    Trap t24 = new Trap(28, 35);
                    traps.Add(t15);
                    traps.Add(t16);
                    traps.Add(t17);
                    traps.Add(t18);
                    traps.Add(t19);
                    traps.Add(t20);
                    traps.Add(t21);
                    traps.Add(t22);
                    traps.Add(t23);
                    traps.Add(t24);
                    break;
                case 6:
                    Trap t25 = new Trap(65, 7);
                    Trap t26 = new Trap(20, 14);
                    Trap t27 = new Trap(55, 10);
                    Trap t28 = new Trap(35, 23);
                    Trap t29 = new Trap(40, 35);
                    Trap t30 = new Trap(60, 5);
                    Trap t31 = new Trap(20, 2);
                    Trap t32 = new Trap(25, 12);
                    Trap t33 = new Trap(35, 23);
                    Trap t34 = new Trap(28, 35);
                    traps.Add(t25);
                    traps.Add(t26);
                    traps.Add(t27);
                    traps.Add(t28);
                    traps.Add(t29);
                    traps.Add(t30);
                    traps.Add(t31);
                    traps.Add(t32);
                    traps.Add(t33);
                    traps.Add(t34);
                    break;
                case 7:
                    Trap t35 = new Trap(65, 7);
                    Trap t36 = new Trap(20, 14);
                    Trap t37 = new Trap(55, 10);
                    Trap t38 = new Trap(35, 23);
                    Trap t39 = new Trap(40, 35);
                    Trap t40 = new Trap(60, 5);
                    Trap t41 = new Trap(20, 2);
                    Trap t42 = new Trap(25, 12);
                    Trap t43 = new Trap(35, 23);
                    Trap t44 = new Trap(28, 35);
                    traps.Add(t35);
                    traps.Add(t36);
                    traps.Add(t37);
                    traps.Add(t38);
                    traps.Add(t39);
                    traps.Add(t40);
                    traps.Add(t41);
                    traps.Add(t42);
                    traps.Add(t43);
                    traps.Add(t44);
                    break;
                case 8:
                    Trap t45 = new Trap(65, 7);
                    Trap t46 = new Trap(20, 14);
                    Trap t47 = new Trap(55, 10);
                    Trap t48 = new Trap(35, 23);
                    Trap t49 = new Trap(40, 35);
                    Trap t50 = new Trap(60, 5);
                    Trap t51 = new Trap(20, 2);
                    Trap t52 = new Trap(25, 12);
                    Trap t53 = new Trap(35, 23);
                    Trap t54 = new Trap(28, 35);
                    traps.Add(t45);
                    traps.Add(t46);
                    traps.Add(t47);
                    traps.Add(t48);
                    traps.Add(t49);
                    traps.Add(t50);
                    traps.Add(t51);
                    traps.Add(t52);
                    traps.Add(t53);
                    traps.Add(t54);
                    break;
                case 9:
                    Trap t55 = new Trap(65, 7);
                    Trap t56 = new Trap(20, 14);
                    Trap t57 = new Trap(55, 10);
                    Trap t58 = new Trap(35, 23);
                    Trap t59 = new Trap(40, 35);
                    Trap t60 = new Trap(60, 5);
                    Trap t61 = new Trap(20, 2);
                    Trap t62 = new Trap(25, 12);
                    Trap t63 = new Trap(35, 23);
                    Trap t64 = new Trap(28, 35);
                    traps.Add(t55);
                    traps.Add(t56);
                    traps.Add(t57);
                    traps.Add(t58);
                    traps.Add(t59);
                    traps.Add(t60);
                    traps.Add(t61);
                    traps.Add(t62);
                    traps.Add(t63);
                    traps.Add(t64);
                    break;
                case 10:
                    Trap t65 = new Trap(65, 7);
                    Trap t66 = new Trap(20, 14);
                    Trap t67 = new Trap(55, 10);
                    Trap t68 = new Trap(35, 23);
                    Trap t69 = new Trap(40, 35);
                    Trap t70 = new Trap(60, 5);
                    Trap t71 = new Trap(20, 2);
                    Trap t72 = new Trap(25, 12);
                    Trap t73 = new Trap(35, 23);
                    Trap t74 = new Trap(28, 35);
                    traps.Add(t65);
                    traps.Add(t66);
                    traps.Add(t67);
                    traps.Add(t68);
                    traps.Add(t69);
                    traps.Add(t70);
                    traps.Add(t71);
                    traps.Add(t72);
                    traps.Add(t73);
                    traps.Add(t74);
                    break;
                default:
                    break;
            }
        }


    }
}
