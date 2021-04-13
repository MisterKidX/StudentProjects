using System;

namespace _4DayProject
{
    class Menu
    {       
        public static void UImenu()
        {
            int line = 0;
            while (!Program.PlayerAlive)
            {                
                switch (line)
                {
                    case 0:
                        Console.SetCursorPosition(8, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Start\n");
                        Console.SetCursorPosition(8, 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Help\n");
                        Console.SetCursorPosition(8, 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Options\n");
                        Console.SetCursorPosition(8, 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Exit\n");
                        break;
                    case 1:
                        Console.SetCursorPosition(8, 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Start\n");
                        Console.SetCursorPosition(8, 3);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Help\n");
                        Console.SetCursorPosition(8, 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Options\n");
                        Console.SetCursorPosition(8, 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Exit\n");
                        break;
                    case 2:
                        Console.SetCursorPosition(8, 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Start\n");
                        Console.SetCursorPosition(8, 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Help\n");
                        Console.SetCursorPosition(8, 5);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Options\n");
                        Console.SetCursorPosition(8, 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Exit\n");
                        break;
                    case 3:
                        Console.SetCursorPosition(8, 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Start\n");
                        Console.SetCursorPosition(8, 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Help\n");
                        Console.SetCursorPosition(8, 5);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Options\n");
                        Console.SetCursorPosition(8, 7);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Exit\n");
                        break;
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (line > 0)
                        {
                            line--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (line < 3)
                        {
                            line++;
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        switch (line)
                        {
                            case 0:
                                Program.PlayerAlive = true;
                                break;
                            case 1:
                                Help();
                                break;
                            case 2:
                                Options();
                                break;
                            case 3:
                                Exit();
                                break;
                        }
                        break;
                }
            }          
        }        
        static void Help()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, 1);
                Console.Write("For movement use the WASD \n or Arrow keys\n For conformations press either Enter \n or spacebar keys\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" Would you like to return?");
                var shit = Console.ReadKey(true).Key;
                if (shit == ConsoleKey.Enter || shit == ConsoleKey.Spacebar) 
                {
                    Console.Clear();
                    break;
                }
            }
        }
        static void Options()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, 1);
                Console.Write("The Entire game is randomized,\n so if you want you can change in the settings\n change vector y or x to increase map size\n or monstersight to increase/decrease \n thier sight range");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" Would you like to return?");
                var shit = Console.ReadKey(true).Key;
                if (shit == ConsoleKey.Enter || shit == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        static void Exit()
        {
            Environment.Exit(0);//if you read this, i lost my third bet D:
        }
        public static void Stats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, Program.X_vector + 1);
            Console.Write("HP "+ Program.Health+ " /10");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(1, Program.X_vector + 3);
            Console.Write("Max dmg "+Program.Maxdamage);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(13, Program.X_vector + 3);
            Console.Write("Min dmg " + Program.Mindamage);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, Program.X_vector + 5);
            Console.Write("Coins: " + Program.Coins);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(13, Program.X_vector + 1);
            Console.Write("Last Button Used- ");
        }
        public static void EncounterWall()
        {
            deletetext(); 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.Write("There's a wall in your way");
        }
        public static void Healing()
        {
            deletetext();
            if (Program.Health<10)
            {
                Program.Health += 4;
                Program.Mesta[Program.Player[0], Program.Player[1]] = 0;
                if (Program.Health > 10)
                {
                    Program.Health = 10;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(1, Program.X_vector + 7);
                Console.Write("You have used healing potion");
            }
        }
        public static void Treasure()
        {
            Program.Mesta[Program.Player[0], Program.Player[1]] = 7;
            Random rnd = new Random();
            System.Threading.Thread.Sleep(1);
            int k = rnd.Next(3, 10 + Program.Level);
            Program.Coins += k;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.Write("You have unlocked a treasure\n chest you picked "+k+" coins.");
        }
        public static void Traped()
        {
            deletetext(); 
            Program.Mesta[Program.Player[0], Program.Player[1]] = 10;
            Program.Health -= 2;
            if (Program.Health <=0)
            {
                Program.PlayerAlive = false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.Write("You have stepped on a trap\n and lost 2 HP");
        }
        public static void CoinsPickUp()
        {
            deletetext(); 
            Program.Mesta[Program.Player[0], Program.Player[1]] = 0;
            Program.Coins++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, Program.X_vector + 7);
            Console.Write("You've picked a coin");
        }
        public static void deletetext()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Program.X_vector + 6);
            Console.Write("                                  ");
            Console.SetCursorPosition(0, Program.X_vector + 7);
            Console.Write("                                  ");
            Console.SetCursorPosition(0, Program.X_vector + 8);
            Console.Write("                                  ");
            Console.SetCursorPosition(0, Program.X_vector + 9);
            Console.Write("                                  ");
            Console.SetCursorPosition(0, Program.X_vector + 10);
            Console.Write("                                  ");
        }
    }
}
