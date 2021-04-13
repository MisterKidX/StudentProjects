using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    public class Map
    {
        private static Map _mapInstance = null;
        public static Map MapInstance
        {
            get
            {
                if (_mapInstance == null)
                {
                    _mapInstance = new Map();
                }
                return _mapInstance;
            }
        }
        public char[,] Rooms2D = new char[5, 10];
        public char[,] Map2D = new char[40, 80];
        
        public void PrintMap()
        {
            for (int i = 0; i < Map2D.GetLength(0); i++)
            {
                for (int j = 0; j < Map2D.GetLength(1); j++)
                {
                    Map2D[0, j] = '-';
                    Map2D[Map2D.GetLength(0) - 1, j] = '-';
                    Map2D[i, 0] = '|';
                    Map2D[i, Map2D.GetLength(1) - 1] = '|';
                    GenerateMapInside(i, j);
                    DrawLifePoints();
                    //Coloring(i, j);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Map2D[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
        }
        
        public void DrawLifePoints()
        {

            switch (Player.PlayerInstance.Level)
            {
                case 1:
                    Map2D[25, 25] = '+';
                    break;
                case 2:
                    Map2D[25, 25] = ' ';
                    Map2D[17, 17] = '+';
                    break;
                case 3:
                    Map2D[17, 17] = ' ';
                    Map2D[33, 36] = '+';
                    break;
                case 4:
                    Map2D[33, 36] = ' ';
                    Map2D[10, 40] = '+';
                    break;
                case 5:
                    Map2D[10, 40] = ' ';
                    break;
                case 6:
                    Map2D[10, 25] = '+';

                    break;
                case 7:
                    Map2D[10, 25] = ' ';
                    Map2D[10, 25] = '+';
                    Map2D[10, 29] = '+';
                    break;
                case 8:
                    Map2D[10, 25] = ' ';
                    Map2D[10, 29] = ' ';
                    Map2D[20, 10] = '+';
                    Map2D[20, 60] = '+';
                    break;
                case 9:
                    Map2D[20, 10] = ' ';
                    Map2D[20, 60] = ' ';
                    Map2D[10, 25] = '+';
                    break;
                case 10:
                    Map2D[10, 25] = ' ';
                    Map2D[10, 29] = '+';
                    break;
                default:
                    break;
            }
        }
        
        public void GenerateMapInside(int i, int j)
        {
            switch (Player.PlayerInstance.Level)
            {
                case 1:
                    Map1(i, j);
                    break;
                case 2:
                    Map2(i, j);
                    break;
                case 3:
                    Map3(i, j);
                    break;
                case 4:
                    Map4(i, j);
                    break;
                case 5:
                    Map5(i, j);
                    break;
                case 6:
                    Map6(i, j);
                    break;
                case 7:
                    Map7(i, j);
                    break;
                case 8:
                    Map8(i, j);
                    break;
                case 9:
                    Map9(i, j);
                    break;
                case 10:
                    Map10(i, j);
                    break;
                default:
                    break;
            }
        }
        
        public void Map1(int i, int j)
        {
            if ((i >= 0 && i <= 0) && (j >= 0 && j <= 0))
            {
                if (j == 0 || j == 0)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 0 || i == 0)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map2(int i, int j)
        {
            if ((i >= 5 && i <= 10) && (j >= 10 && j <= 20))
            {
                if (j == 10 || j == 20)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 5 || i == 10)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map3(int i, int j)
        {
            if ((i >= 15 && i <= 20) && (j >= 25 && j <= 40))
            {
                if (j == 25 || j == 40)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 15 || i == 20)
                {
                    Map2D[i, j] = '-';
                }
            }

        }
        
        public void Map4(int i, int j)
        {
            if ((i >= 25 && i <= 30) && (j >= 30 && j <= 45))
            {
                if (j == 30 || j == 45)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 25 || i == 30)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map5(int i, int j)
        {
            if ((i >= 30 && i <= 35) && (j >= 10 && j <= 20))
            {
                if (j == 10 || j == 20)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 30 || i == 35)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map6(int i, int j)
        {
            if ((i >= 5 && i <= 10) && (j >= 33 && j <= 38))
            {
                if (j == 33 || j == 38)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 5 || i == 10)
                {
                    Map2D[i, j] = '-';
                }
            }

        }
        
        public void Map7(int i, int j)
        {
            if ((i >= 5 && i <= 10) && (j >= 40 && j <= 50))
            {
                if (j == 40 || j == 50)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 5 || i == 10)
                {
                    Map2D[i, j] = '-';
                }
            }

        }
        
        public void Map8(int i, int j)
        {
            if ((i >= 37 && i <= 39) && (j >= 50 && j <= 60))
            {
                if (j == 50 || j == 60)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 37 || i == 39)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map9(int i, int j)
        {
            if ((i >= 7 && i <= 12) && (j >= 75 && j <= 79))
            {
                if (j == 75 || j == 79)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 7 || i == 12)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
        
        public void Map10(int i, int j)
        {
            if ((i >= 14 && i <= 20) && (j >= 0 && j <= 5))
            {
                if (j == 0 || j == 5)
                {
                    Map2D[i, j] = '|';
                }
                else if (i == 14 || i == 20)
                {
                    Map2D[i, j] = '-';
                }
            }
        }
    }

}
