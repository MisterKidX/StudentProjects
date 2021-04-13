using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalPrograingGame
{
    class MapCreator
    {
        public int lvlcounter = 1;
        private static MapCreator mapInstance = null;
        public static MapCreator getMapInstance
        {
            get
            {
                if (mapInstance == null)
                {
                    mapInstance = new MapCreator(20, 40);
                }
                return mapInstance;
            }
        }
        public string[,] map;
        public static int X;
        public static int Y;
        public MapCreator(int x, int y)
        {
            X = x;
            Y = y;
            map = new string[x, y];
        }


        public void lvl1()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Green;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl1();
                    heartlvl1();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl1()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
        }

        public void heartlvl1()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
            }
        }

        public void lvl2()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl2();
                    heartlvl2();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl2()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[7, 35] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
        }

        public void heartlvl2()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Yellow;
            }
        }
        public void lvl3()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl3();
                    heartlvl3();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl3()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[7, 35] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
        }

        public void heartlvl3()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Magenta;
            }
        }
        public void lvl4()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl4();
                    heartlvl4();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl4()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[7, 35] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[18, 38] = "≈";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
        }

        public void heartlvl4()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
            }
        }
        public void lvl5()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl5();
                    heartlvl5();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl5()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[7, 35] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";

        }

        public void heartlvl5()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Yellow;
            }
        }
        public void lvl6()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.DarkYellow;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl6();
                    heartlvl6();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl6()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[11, 25] = "♥";
            map[18, 35] = "♥";
            map[3, 25] = "♥";
            map[2, 5] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 6] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
            map[17, 31] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";


        }

        public void heartlvl6()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkYellow;
            }
        }
        public void lvl7()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.Blue;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl7();
                    heartlvl7();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl7()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[1, 25] = "Φ";
            map[18, 19] = "Φ";
            map[7, 35] = "♥";
            map[9, 25] = "♥";
            map[11, 25] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
            map[1, 1] = "☺";
            map[1, 21] = "☺";
        }

        public void heartlvl7()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.Blue;
            }
        }
        public void lvl8()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl8();
                    heartlvl8();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl8()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[1, 25] = "Φ";
            map[18, 19] = "Φ";
            map[7, 35] = "♥";
            map[9, 25] = "♥";
            map[11, 25] = "♥";
            map[18, 35] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
            map[1, 1] = "☺";
            map[1, 21] = "☺";

        }

        public void heartlvl8()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
            }
        }
        public void lvl9()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.DarkGreen;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl9();
                    heartlvl9();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl9()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[1, 25] = "Φ";
            map[18, 19] = "Φ";
            map[7, 35] = "♥";
            map[9, 25] = "♥";
            map[3, 25] = "♥";
            map[2, 5] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
            map[1, 19] = "☺";
            map[17, 3] = "☺";
        }

        public void heartlvl9()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
        public void lvl10()
        {
            for (X = 0; X < map.GetLength(0); X++)
            {
                for (Y = 0; Y < map.GetLength(1); Y++)
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    map[X, Y] = " ";
                    map[0, Y] = "-";
                    map[map.GetLength(0) - 1, Y] = "-";
                    map[X, 0] = "|";
                    map[X, map.GetLength(1) - 1] = "|";
                    WALLSOFlvl10();
                    heartlvl10();
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine("");
                ResetColor();
            }
        }
        public void WALLSOFlvl10()
        {
            map[12, 19] = "|";
            map[13, 19] = "|";
            map[14, 19] = "|";
            map[14, 20] = "-";
            map[14, 21] = "-";
            map[14, 22] = "-";
            map[14, 23] = "|";
            map[13, 23] = "|";
            map[12, 23] = "|";
            map[12, 22] = "-";
            map[12, 21] = "-";
            map[12, 20] = "-";
            map[7, 8] = "|";
            map[8, 8] = "|";
            map[9, 8] = "|";
            map[9, 9] = "-";
            map[9, 10] = "-";
            map[9, 11] = "-";
            map[9, 12] = "|";
            map[8, 12] = "|";
            map[7, 12] = "|";
            map[7, 11] = "-";
            map[7, 10] = "-";
            map[7, 9] = "-";
            map[18, 35] = "Φ";
            map[14, 25] = "Φ";
            map[11, 19] = "Φ";
            map[1, 25] = "Φ";
            map[18, 19] = "Φ";
            map[7, 35] = "♥";
            map[9, 25] = "♥";
            map[11, 25] = "♥";
            map[18, 35] = "♥";
            map[3, 25] = "♥";
            map[2, 5] = "♥";
            map[16, 19] = "|";
            map[17, 19] = "|";
            map[18, 19] = "|";
            map[18, 20] = "-";
            map[18, 21] = "-";
            map[18, 22] = "-";
            map[18, 23] = "|";
            map[17, 23] = "|";
            map[16, 23] = "|";
            map[16, 22] = "-";
            map[16, 21] = "-";
            map[16, 20] = "-";
            map[16, 28] = "|";
            map[17, 28] = "|";
            map[18, 28] = "|";
            map[18, 29] = "-";
            map[18, 29] = "-";
            map[18, 30] = "-";
            map[18, 31] = "|";
            map[17, 31] = "|";
            map[16, 31] = "|";
            map[16, 30] = "-";
            map[16, 29] = "-";
            map[16, 28] = "|";
            map[4, 3] = "|";
            map[5, 3] = "|";
            map[6, 3] = "|";
            map[6, 4] = "-";
            map[6, 5] = "-";
            map[6, 6] = "-";
            map[6, 7] = "|";
            map[5, 7] = "|";
            map[4, 7] = "|";
            map[4, 6] = "-";
            map[4, 5] = "-";
            map[4, 4] = "-";
        }

        public void heartlvl10()
        {

            if (X == 7 && Y == 35 || X == 9 && Y == 25)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkCyan;
            }
        }
        public void mapchanger()
        {
            switch (lvlcounter)
            {
               case 1:
                    lvl1();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 2:
                    lvl2();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 3:
                    lvl3();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 4:
                    lvl4();
                    HUD.gethudInstance.Hudcreator();
                    break;
                default:
                    break;
                case 5:
                    lvl5();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 6:
                    lvl6();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 7:
                    lvl7();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 8:
                    lvl8();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 9:
                    lvl9();
                    HUD.gethudInstance.Hudcreator();
                    break;
                case 10:
                    lvl10();
                    HUD.gethudInstance.Hudcreator();
                    break;
            }
        }
	}
}



