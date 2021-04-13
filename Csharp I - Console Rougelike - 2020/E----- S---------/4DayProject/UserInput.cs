using System;

namespace _4DayProject
{
    class UserInput
    {
        public static void Duserinput()//might disable num 3
        {
            switch (Console.ReadKey().Key) // 13=% 12 =- 11 =| 10 =,* 9 =, 8 = H 7 =#* 6 =# 5 = X 4 = E 3 = M * 2 = M 1 =$ 0 = " "
            {                
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    switch (Program.Mesta[Program.Player[0], Program.Player[1] - 1])
                    {
                        case 13:
                        case 12:
                        case 11:
                            Menu.EncounterWall();
                            break;
                        case 10:
                        case 9:
                            Up();
                            Menu.Traped();
                            break;
                        case 8:
                            Up();
                            Menu.Healing();
                            break;
                        case 6:
                            Up();
                            Menu.Treasure();
                            break;
                        case 5:
                            Up();
                            Program.Nextlvl();
                            break;
                        case 2:
                            break;
                        case 1:
                            Up();
                            Menu.CoinsPickUp();
                            break;
                        case 7:
                        case 4:
                        case 3:
                        case 0:
                            Up();
                            break;
                    }
                    break;               
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    switch (Program.Mesta[Program.Player[0], Program.Player[1]+1])
                    {
                        case 13:
                        case 12:
                        case 11:
                            Menu.EncounterWall();
                            break;
                        case 10:
                        case 9:
                            Down();
                            Menu.Traped();
                            break;
                        case 8:
                            Down();
                            Menu.Healing();
                            break;
                        case 6:
                            Down();
                            Menu.Treasure();
                            break;
                        case 5:
                            Down();
                            Program.Nextlvl();
                            break;
                        case 2:
                            break;
                        case 1:
                            Down();
                            Menu.CoinsPickUp();
                            break;
                        case 7:
                        case 4:
                        case 3:
                        case 0:
                            Down();
                            break;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    switch (Program.Mesta[Program.Player[0]-1, Program.Player[1]])
                    {
                        case 13:
                        case 12:
                        case 11:
                            Menu.EncounterWall();
                            break;
                        case 10:
                        case 9:
                            Left();
                            Menu.Traped();
                            break;
                        case 8:
                            Left();
                            Menu.Healing();
                            break;
                        case 6:
                            Left();
                            Menu.Treasure();
                            break;
                        case 5:
                            Left();
                            Program.Nextlvl();
                            break;
                        case 2:
                            break;
                        case 1:
                            Left();
                            Menu.CoinsPickUp();
                            break;
                        case 7:
                        case 4:
                        case 3:
                        case 0:
                            Left();
                            break;
                    }
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    switch (Program.Mesta[Program.Player[0]+1, Program.Player[1]])
                    {
                        case 13:
                        case 12:
                        case 11:
                            Menu.EncounterWall();
                            break;
                        case 10:
                        case 9:
                            Right();
                            Menu.Traped();
                            break;
                        case 8:
                            Right();
                            Menu.Healing();
                            break;
                        case 6:
                            Right();
                            Menu.Treasure();
                            break;
                        case 5:
                            Right();
                            Program.Nextlvl();
                            break;
                        case 2:
                            break;
                        case 1:
                            Right();
                            Menu.CoinsPickUp();
                            break;
                        case 7:
                        case 4:
                        case 3:
                        case 0:
                            Right();
                            break;
                    }
                    break;
            }
        }
        public static void Up()
        {
            Program.Player[3] = Program.Player[1];
            Program.Player[1]--;
        }
        public static void Down()
        {
            Program.Player[3] = Program.Player[1];
            Program.Player[1]++;//if you read this, i lost my second bet. D:
        }
        public static void Left()
        {
            Program.Player[2] = Program.Player[0];
            Program.Player[0]--;
        }
        public static void Right()
        {
            Program.Player[2] = Program.Player[0];
            Program.Player[0]++;
        }
    }
}
