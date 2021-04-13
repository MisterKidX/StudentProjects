using System;

//////////////////////////////////   ------------
//////////////////////////////////   Dor Ben Dor
//////////////////////////////////   Due: 1/3/2020

namespace _4DayProject
{
    class Program//"■"
    {       
        public static bool PlayerAlive;
        public static int Level = 1;
        public static int Coins = 0;
        public static int X_vector = 20;//hight
        public static int Y_vector = 30;//lenght
        public static int SightRange = 4;        
        public static int Health = 10;
        public static int Maxdamage = 3;
        public static int Mindamage = 1;
        public static int Mmaxdamage = 2;
        public static int Mmindamage = 1;
        public static int[] Player = new int[4];
        public static int[,] Mesta = new int[Y_vector, X_vector];
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            if (!PlayerAlive)
            {
                Menu.UImenu();
            }
            Interactables();

            Console.SetWindowSize(Y_vector + 5, X_vector + 12);
            Console.SetBufferSize(Y_vector + 5, X_vector + 12);
            while (PlayerAlive)
            {
                MapUI();
                Menu.Stats();
                UserInput.Duserinput();
                MonsterEyeSight();
                if (!PlayerAlive)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(4, 5);
                    Console.Write("You have Diededededed\n ");
                }
            }
        }   
        static void MapUI()
        {           
            for (int y = 0; y < Y_vector; y++)
            {
                for (int x = 0; x < X_vector; x++)
                {
                    switch (Mesta[y, x])//12=-,11=|,9=H,8=^,7=#,6=#,5=X,4=E,3=M,2=,1=,0=" "
                    {
                        case 13:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("%");
                            break;
                        case 12:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("-");
                            break;
                        case 11:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("|");
                            break;
                        case 10:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(",");
                            break;
                        case 9:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            break;
                        case 8:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("H");
                            break;
                        case 7:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("#");
                            break;
                        case 6:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("#");
                            break;
                        case 5:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("X");
                            break;
                        case 4:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("E");
                            break;
                        case 3:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("m");
                            break;
                        case 2:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("M");
                            break;
                        case 1:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("$");
                            break;
                        case 0:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            break;
                        default:
                            Console.SetCursorPosition(y, x);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("!");
                            break;
                    }
                }
            }
            Console.SetCursorPosition(Player[0], Player[1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
        }
        static void Interactables()
        {
            Random rnd = new Random();
            int _trapnum = 0;
            int _monstercount = 0;
            int _coincount = 0;
            int _heals = 0;
            for (int y = 0; y < Y_vector; y++) 
            {
                for (int x = 0; x < X_vector; x++)
                {
                    Mesta[y, x] = 0;
                    if (x == 0 || x == X_vector-1)
                    {
                        Mesta[y, x] = 12;//Y Wall
                    }
                    if (y == 0 || y == Y_vector-1) 
                    {
                        Mesta[y, x] = 11;//X wall
                    }
                }               
            }
            while (true)//4x4
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector - 3);
                int p = rnd.Next(0, X_vector - 3);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 12;
                    Mesta[k + 1, p] = 12;
                    Mesta[k + 2, p] = 12;
                    Mesta[k + 3, p] = 12;
                    Mesta[k, p + 1] = 11;
                    Mesta[k, p + 2] = 11;
                    Mesta[k + 1, p + 1] = 13;
                    Mesta[k + 2, p + 1] = 13;
                    Mesta[k + 1, p + 2] = 13;
                    Mesta[k + 2, p + 2] = 13;
                    Mesta[k + 3, p + 1] = 11;
                    Mesta[k + 3, p + 2] = 11;
                    Mesta[k, p + 3] = 12;
                    Mesta[k + 1, p + 3] = 12;
                    Mesta[k + 2, p + 3] = 12;
                    Mesta[k + 3, p + 3] = 12;
                    break;
                }
            }
            while (true)//3x3 wall
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector-2);
                int p = rnd.Next(0, X_vector-2);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 12;
                    Mesta[k + 1, p] = 12;
                    Mesta[k + 2, p] = 12;
                    Mesta[k, p + 1] = 11;
                    Mesta[k + 1, p + 1] = 13;
                    Mesta[k + 2, p + 1] = 11;
                    Mesta[k, p + 2] = 12;
                    Mesta[k + 1, p + 2] = 12;
                    Mesta[k + 2, p + 2] = 12;
                    break;
                }
            }
            while (true)//3x4 wall
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector - 3);
                int p = rnd.Next(0, X_vector - 2);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 12;
                    Mesta[k + 1, p] = 12;
                    Mesta[k + 2, p] = 12;
                    Mesta[k + 3, p] = 12;
                    Mesta[k, p + 1] = 11;
                    Mesta[k + 1, p + 1] = 13;
                    Mesta[k + 2, p + 1] = 13;
                    Mesta[k + 3, p + 1] = 11;
                    Mesta[k, p + 2] = 12;
                    Mesta[k + 1, p + 2] = 12;
                    Mesta[k + 2, p + 2] = 12;
                    Mesta[k + 3, p + 2] = 12;
                    break;
                }
            }
            while (true)//4x3 wall
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector - 2);
                int p = rnd.Next(0, X_vector - 3);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 12;
                    Mesta[k + 1, p] = 12;
                    Mesta[k + 2, p] = 12;
                    Mesta[k, p + 1] = 11;
                    Mesta[k, p + 2] = 11;
                    Mesta[k + 1, p + 1] = 13;
                    Mesta[k + 1, p + 2] = 13;
                    Mesta[k, p + 3] = 12;
                    Mesta[k + 1, p + 3] = 12;
                    Mesta[k + 2, p + 3] = 12;
                    Mesta[k + 2, p + 1] = 11;
                    Mesta[k + 2, p + 2] = 11;
                    break;
                }
            }
            while (true)//,
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 9;
                    _trapnum++;
                    if (_trapnum == 2 + Level * 2)
                    {
                        break;
                    }
                }
            }
            while (true)//H
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 8;
                    _heals++;
                    if (_heals == Level)
                    {
                        break;
                    }
                }
            }
            while (true)
            {               
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0 )
                {
                    Mesta[k, p] = 6;//#
                    break;
                }
            }
            while (true)//X
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 5;
                    break;
                }
            }
            while (true)//E
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 4;
                    break;
                }
            }
            while (true)//M
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 2;
                    _monstercount++;
                    if (_monstercount == Level)
                    {
                        break;
                    }
                }
            }
            while (true)//$
            {
                System.Threading.Thread.Sleep(10);
                int k = rnd.Next(0, Y_vector);
                int p = rnd.Next(0, X_vector);
                if (Mesta[k, p] == 0)
                {
                    Mesta[k, p] = 1;
                    _coincount++;
                    if (_coincount == 3 + Level * 2) 
                    {
                        break;
                    }
                }
            }
            for (int y = 0; y < Y_vector; y++)//find player on E
            {
                for (int x = 0; x < X_vector; x++)
                {
                    if (Mesta[y, x] == 4)
                    {
                        Player[0] = y;
                        Player[1] = x;
                    }
                }
            }
        }
        
        static void MonsterEyeSight()
        {
            for (int y = 0; y < Y_vector; y++)
            {
                for (int x = 0; x < X_vector; x++)
                {
                    bool moved = false;
                    if (Mesta[y, x] == 2)//(y - Player[0]) * (y - Player[0]) + (x - Player[1]) * (x - Player[1]) <= 1
                    {
                        if ((y - Player[0]) * (y - Player[0]) + (x - Player[1]) * (x - Player[1]) <= SightRange * SightRange)
                        {
                            if (Player[0] - y > 0 && !moved)//Player[0] - y < SightRange && 
                            {
                                if (Mesta[y + 1, x] == 0)
                                {
                                    Mesta[y, x] = 0;
                                    y++;
                                    Mesta[y, x] = 2;
                                    moved = true;
                                }
                            }
                            if (Player[1] - x > 0 && !moved)//Player[1] - x < SightRange && 
                            {
                                if (Mesta[y, x + 1] == 0)
                                {
                                    Mesta[y, x] = 0;
                                    x++;
                                    Mesta[y, x] = 2;
                                    moved = true;
                                }
                            }
                            if (y - Player[0] > 0 && !moved)//y - Player[0] < SightRange && 
                            {
                                if (Mesta[y - 1, x] == 0)
                                {
                                    Mesta[y, x] = 0;
                                    Mesta[y - 1, x] = 2;
                                    moved = true;
                                }
                            }
                            if (x - Player[1] > 0 && !moved)//x - Player[1] < SightRange && 
                            {
                                if (Mesta[y, x - 1] == 0)
                                {
                                    Mesta[y, x] = 0;
                                    Mesta[y, x - 1] = 2;
                                    moved = true;
                                }
                            }
                            if (y - Player[0] == 0 && x - Player[1] == 0)
                            {
                                Fight();
                                moved = true;
                            }
                        }
                        if (!moved)
                        {
                            Random rnd = new Random();
                            System.Threading.Thread.Sleep(10);
                            int k = rnd.Next(0, 5);
                            switch (k)
                            {
                                case 0:
                                    if (Mesta[y + 1, x] == 0)
                                    {
                                        Mesta[y, x] = 0;
                                        y++;
                                        Mesta[y, x] = 2;
                                    }
                                    break;
                                case 1:
                                    if (Mesta[y - 1, x] == 0)
                                    {
                                        Mesta[y, x] = 0;
                                        Mesta[y - 1, x] = 2;
                                    }
                                    break;
                                case 2:
                                    if (Mesta[y, x + 1] == 0)
                                    {
                                        Mesta[y, x] = 0;
                                        x++;
                                        Mesta[y, x] = 2;
                                    }
                                    break;
                                case 3:
                                    if (Mesta[y, x - 1] == 0)
                                    {
                                        Mesta[y, x] = 0;
                                        Mesta[y, x - 1] = 2;
                                    }
                                    break;
                            }
                            moved = true;
                        }
                    }
                }
            }
        }
        public static void Fight()
        {
            Random rnd = new Random();
            int Mhealth = 4 + Level * 2;
            Menu.deletetext();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(0, Program.X_vector + 6);
            Console.Write("Press Enter or Spacebar to Attack");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.Write("You have encountered an Enemy");
            while (true)
            {
                var n = Console.ReadKey().Key;
                if (n == ConsoleKey.Enter || n == ConsoleKey.Spacebar)
                {
                    Menu.deletetext();
                    System.Threading.Thread.Sleep(10);
                    int k = rnd.Next(Mindamage, Maxdamage);
                    System.Threading.Thread.Sleep(10);
                    int l = rnd.Next(Mmindamage, Mmaxdamage);
                    if (n == ConsoleKey.Enter || n == ConsoleKey.Spacebar)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.SetCursorPosition(0, Program.X_vector + 6);
                        Console.Write("Press Enter or Spacebar to Attack"); Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(1, Program.X_vector + 7);
                        Console.Write("You've hitted the Enemy for\n " + k + " damage");
                        Mhealth -= k;
                        Console.SetCursorPosition(1, Program.X_vector + 9);
                        Console.Write("The monster has \n " + Mhealth + " HP left");
                        n = 0;
                        n = Console.ReadKey().Key;
                    }
                    if (Mhealth <= 0)
                    {
                        Menu.deletetext();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(1, Program.X_vector + 7);
                        Console.Write("You have killed the monster");
                        Mesta[Player[0], Player[1]] = 3;
                        break;
                    }
                    else if (n == ConsoleKey.Enter || n == ConsoleKey.Spacebar)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(1, Program.X_vector + 7);
                        Console.Write("The monster strikes back for\n " + l + " damage"); 
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(1, Program.X_vector + 9);
                        Console.Write("                             \n                         ");
                        Health -= l;
                    }
                    if (Health <= 0)
                    {
                        PlayerAlive = false;
                        break;
                    }
                    else
                    {
                        Menu.Stats();
                    }
                }
            }
        }

        public static void Nextlvl()
        {
            Level++;
            Maxdamage = 3 + 2 * Level;
            Mindamage = 1 + Level;
            Mmaxdamage = 2 + Level;
            Mmindamage = 1 + Level;
            Interactables();
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("You've reached " + Level + "level");
        }
    
    }
}
