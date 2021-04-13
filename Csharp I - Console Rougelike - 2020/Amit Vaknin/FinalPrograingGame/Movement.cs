using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalPrograingGame
{
    class Movement
    {
        private static Movement MovementInstance = null;
        public static Movement getMovementInstance
        {
            get
            {
                if (MovementInstance == null)
                {
                    MovementInstance = new Movement();
                }
                return MovementInstance;
            }
        }
       public static List<Enemy> enemies=new List<Enemy>();
        public void DrawPlayer()
        {
            int x = 1;
            int y = 10;
            Console.ForegroundColor = ConsoleColor.Blue;
            SetCursorPosition(x, y);
            Console.Write("¥");
            ConsoleKeyInfo input;
            placeEnemy();
            icons();
           
           
            while (player.getplayerInstance.baseHp != 0)
            {
                icons();
                Trapdmg();
                SetCursorPosition(x, y);
                Console.Write("¥");
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.W:
                        if (MapCreator.getMapInstance.map[y - 1, x] == "-" || MapCreator.getMapInstance.map[y - 1, x] == "|")
                        {
                            continue;
                        }
                        if (MapCreator.getMapInstance.map[y - 1, x] == "♥")
                        {
                            player.getplayerInstance.baseHp += 10;
                            MapCreator.getMapInstance.map[y - 1, x] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y - 1, x] == "Φ")
                        {
                            player.getplayerInstance.baseHp -= 10;
                            MapCreator.getMapInstance.map[y - 1, x] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y - 1, x] == "☺")
                        {
                            player.getplayerInstance.coins++;
                            MapCreator.getMapInstance.map[y - 1, x] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        SetCursorPosition(x, y);
                        Write(" ");
                        y--;
                        SetCursorPosition(x, y);
                        Write("¥");
                        break;
                    case ConsoleKey.A:
                        if (MapCreator.getMapInstance.map[y, x - 1] == "|" || MapCreator.getMapInstance.map[y, x - 1] == "-")
                        {
                            continue;
                        }

                        if (MapCreator.getMapInstance.map[y, x - 1] == "♥")
                        {
                            player.getplayerInstance.baseHp += 10;
                            MapCreator.getMapInstance.map[y, x - 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y, x - 1] == "Φ")
                        {
                            player.getplayerInstance.baseHp -= 10;
                            MapCreator.getMapInstance.map[y, x - 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y, x - 1] == "☺")
                        {
                            player.getplayerInstance.coins++;
                            MapCreator.getMapInstance.map[y, x - 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }

                        SetCursorPosition(x, y);
                        Write(" ");
                        x--;
                        SetCursorPosition(x, y);
                        Write("¥");
                        break;
                    case ConsoleKey.S:
                        if (MapCreator.getMapInstance.map[y + 1, x] == "-" || MapCreator.getMapInstance.map[y + 1, x] == "|")
                        {
                            continue;
                        }
                        if (MapCreator.getMapInstance.map[y + 1, x] == "♥")
                        {
                            player.getplayerInstance.baseHp += 10;
                            MapCreator.getMapInstance.map[y + 1, x] = "";
                            Console.SetCursorPosition(0,20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y + 1, x] == "Φ")
                        {
                            player.getplayerInstance.baseHp -= 10;
                            MapCreator.getMapInstance.map[y + 1, x] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();
                        }
                        if (MapCreator.getMapInstance.map[y + 1, x] == "☺")
                        {
                            player.getplayerInstance.coins++;
                            MapCreator.getMapInstance.map[y + 1, x] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        SetCursorPosition(x, y);
                        Write(" ");
                        y++;
                        SetCursorPosition(x, y);
                        Write("¥");
                        break;
                    case ConsoleKey.D:
                        if (MapCreator.getMapInstance.map[y, x + 1] == "|" || MapCreator.getMapInstance.map[y, x + 1] == "-")
                        {
                            continue;
                        }
                        if (MapCreator.getMapInstance.map[y, x + 1] == "♥")
                        {
                            player.getplayerInstance.baseHp += 10;
                            MapCreator.getMapInstance.map[y, x + 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y, x + 1] == "Φ")
                        {
                            player.getplayerInstance.baseHp -= 10;
                            MapCreator.getMapInstance.map[y, x + 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        if (MapCreator.getMapInstance.map[y, x + 1] == "☺")
                        {
                            player.getplayerInstance.coins++;
                            MapCreator.getMapInstance.map[y, x + 1] = "";
                            Console.SetCursorPosition(0, 20);
                            HUD.gethudInstance.Hudcreator();

                        }
                        SetCursorPosition(x, y);
                        Write(" ");
                        x++;
                        SetCursorPosition(x, y);
                        Write("¥");
                        break;
                }
                SetCursorPosition(0, 20);
                if (player.getplayerInstance.trapy ==y  && player.getplayerInstance.trapx== x)
                {
                    player.getplayerInstance.baseHp -= 5;
                    HUD.gethudInstance.Hudcreator();
                    player.getplayerInstance.traptrigger = true;
                }
               
                foreach (var item in enemies)
                {
                    if (item.isDead)
                    {
                       
                        continue;
                     
                    }
                    item.PrintEnemy();
                    item.Move(x,y);
                }
                if (x==exitx&&y==exity)
                {
                    MapCreator.getMapInstance.lvlcounter++;
                    player.getplayerInstance.traptrigger = false;
                    break;
                }
                
            }    
        }
        public void placeEnemy()
        {
            enemies = new List<Enemy>();
            switch (MapCreator.getMapInstance.lvlcounter)
            {
                case 1:
                    Enemy e = new Enemy(2,1);
                    enemies.Add(e);
                    break;
                case 2:
                    Enemy e1 = new Enemy(17, 1);
                    enemies.Add(e1);
                    break;
                case 3:                  
                    Enemy e2 = new Enemy(6,1);
                    enemies.Add(e2);
                    break;
                case 4:                  
                    Enemy e3 = new Enemy(18, 1);
                    enemies.Add(e3);
                    break;
                case 5:
                    Enemy e4 = new Enemy(15, 17);
                    enemies.Add(e4);
                    Enemy e5 = new Enemy(2, 1);
                    enemies.Add(e5);
                    break;
                case 6:
                    Enemy e6 = new Enemy(1, 1);
                    enemies.Add(e6);
                    Enemy e7 = new Enemy(9, 1);
                    enemies.Add(e7);
                    Enemy e8 = new Enemy(17, 1);
                    enemies.Add(e8);
                    break;
                case 7:
                    Enemy e9 = new Enemy(17, 1);
                    enemies.Add(e9);
                    Enemy e10 = new Enemy(18, 12);
                    enemies.Add(e10);
                    Enemy e11 = new Enemy(38, 8);
                    enemies.Add(e11);
                    break;
                case 8:
                    Enemy e12 = new Enemy(1, 1);
                    enemies.Add(e12);
                    Enemy e13 = new Enemy(6, 1);
                    enemies.Add(e13);
                    Enemy e14 = new Enemy(18, 1);
                    enemies.Add(e14);
                    break;
                case 9:
                    Enemy e15 = new Enemy(1, 1);
                    enemies.Add(e15);
                    Enemy e16 = new Enemy(6, 1);
                    enemies.Add(e16);
                    Enemy e17 = new Enemy(19, 1);
                    enemies.Add(e17);
                    break;
                case 10:
                    Enemy e18 = new Enemy(1, 1);
                    enemies.Add(e18);
                    Enemy e19 = new Enemy(15, 1);
                    enemies.Add(e19);
                    Enemy e20 = new Enemy(19, 1);
                    enemies.Add(e20);
                    Enemy e21 = new Enemy(21, 1);
                    enemies.Add(e21);
                    Enemy e22 = new Enemy(1, 18);
                    enemies.Add(e22);
                    Enemy e23 = new Enemy(25,3);
                    enemies.Add(e23);
                    break;
            }
        }
        public void Trapdmg()
        {
            if (!player.getplayerInstance.traptrigger)
            {
                SetCursorPosition(player.getplayerInstance.trapx, player.getplayerInstance.trapy);
            }
            else
            {
                SetCursorPosition(player.getplayerInstance.trapx, player.getplayerInstance.trapy);
                Console.Write("#");
            }
        }
        public int exitx=0;
        public int exity=0;
        public void icons()
        {

            switch (MapCreator.getMapInstance.lvlcounter)
            {
                case 1:
                    SetCursorPosition(exitx = 38, exity = 18);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 2:
                    SetCursorPosition(exitx = 38, exity = 1);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 3:
                    SetCursorPosition(exitx = 20, exity = 1);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 4:
                    SetCursorPosition(exitx = 36, exity = 5);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 5:
                    SetCursorPosition(exitx = 38, exity = 18);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 6:
                    SetCursorPosition(exitx =38, exity = 3);
                    Console.Write("≈");
                    break;
                case 7:
                    SetCursorPosition(exitx = 1, exity = 1);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 8:
                    SetCursorPosition(exitx = 38, exity = 1);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 9:
                    SetCursorPosition(exitx = 38, exity = 18);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                case 10:
                    SetCursorPosition(exitx =1, exity = 1);
                    Console.Write("≈");
                    SetCursorPosition(player.getplayerInstance.startx, player.getplayerInstance.starty);
                    Console.Write("E");
                    break;
                default:
                    break;
            }
        }
    }
}
