using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Obstacles
    {
        string s1 =@"-------| 
                    |       |
                    |       |
                    |        
                    |-------|";
        string s2 = @"-------------| 
                    |              |       
                                   |
                    |        |-----|               
                    |--------|";

        string s3 = @"-------| 
                    |        |       
                |---         |
                             |               
                |------------|";

        string s4 = @"-------| 
                    |        |       
                             |               
                    |--------|";
        Random rnd = new Random();
        string selctedObs;
        public int x;
        public int y;

        public Obstacles()
        {
            int x = rnd.Next(15,35);
            int y = rnd.Next(6,17);
            switch (rnd.Next(1,5))
            {
                case 1:
                    selctedObs = s1;
                    break;
                case 2:
                    selctedObs = s2;
                    break;
                case 3:
                    selctedObs = s3;
                    break;
                case 4:
                    selctedObs = s4;
                    break;
                default:
                    break;
            }
        }
        public void PrintObs()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(selctedObs);
            Console.ResetColor();

        }
    }
}
