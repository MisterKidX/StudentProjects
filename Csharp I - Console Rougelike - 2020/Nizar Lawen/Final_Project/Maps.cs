using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Maps
    {
        private static Maps _mapInstance = null;
        public static Maps GetMapInstance
        {
            get
            {
                if (_mapInstance == null)
                {
                    _mapInstance = new Maps();
                }
                return _mapInstance;
            }
        }

        public string[,] Map = new string[30, 60];
        int IslandHeight = 5;
        int IslandWidth = 15;
        public void MapCreation()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = " ";
                    Map[0, j] = "-";
                    Map[Map.GetLength(0)-1 , j] = "-";
                    Map[i, 0] = "|";
                    Map[i, Map.GetLength(1)-1] = "|";
                    MapsInsides(i, j);
                    MapsLettersPlacementSet();
                    Colors(i,j);
                    Console.Write(Map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
        }        
        public void Colors(int i , int j)
        {
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    //hearts
                    if (i == 3 && j == 12)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 3 && j == 3) || (i == 15 && j == 51))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 2:
                    //hearts
                    if ((i == 18 && j == 40) || (i == 22 && j == 9))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 13 && j == 58) || (i == 18 && j == 20))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 3:
                    //hearts
                    if ((i == 7 && j == 9) || (i == 21 && j == 13) || (i == 7 && j == 50) || (i == 21 && j == 46))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 1 && j == 30) || (i == 14 && j == 56) || (i == 14 && j == 3))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 4:
                    //hearts
                    if ((i == 17 && j == 13) || (i == 2 && j == 50))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 22 && j == 40) || (i == 8 && j == 43))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 5:
                    //hearts
                    if ((i == 28 && j == 50) || (i == 5 && j == 2) || (i == 24 && j == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 15 && j == 57) || (i == 2 && j == 30) || (i == 28 && j == 10))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 6:
                    //hearts
                    if ((i == 7 && j == 1) || (i == 22 && j == 1) || (i == 4 && j == 52))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 25 && j == 30) || (i == 5 && j == 30) || (i == 15 && j == 10))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 7:
                    //hearts
                    if ((i == 12 && j == 27) || (i == 4 && j == 55) || (i == 27 && j == 38))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 15 && j == 20) || (i == 15 && j == 44) || (i == 26 && j == 12))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 8:
                    //hearts
                    if ((i == 28 && j == 35) || (i == 11 && j == 22) || (i == 1 && j == 49))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 6 && j == 10) || (i == 11 && j == 42) || (i == 20 && j == 3) || (i == 22 && j == 38))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 9:
                    //hearts
                    if ((i == 27 && j == 24) || (i == 2 && j == 24) || (i == 14 && j == 38))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    //Coins
                    if ((i == 9 && j == 10) || (i == 19 && j == 10) || (i == 14 && j == 54))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    break;
                case 10:
                    //hearts
                    if ((i == 14 && j == 31) || (i == 7 && j == 56) || (i == 22 && j == 56))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    break;
                default:
                    break;
            }                       
        }
        public void MapsLettersPlacementSet()
        {
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    Map[28,2] = "E";
                    Map[1, 50] = "X";
                    Map[3, 3] = "$";
                    Map[15,51] = "$";
                    Map[3, 12] = "♥";
                    break;
                case 2:
                    Map[2, 3] = "E";
                    Map[28, 5] = "X";                    
                    Map[13,58] = "$";
                    Map[18, 20] = "$";
                    Map[18, 40] = "♥";
                    Map[22, 9] = "♥";
                    break;
                case 3:
                    Map[17, 29] = "E";
                    Map[28, 29] = "X";
                    Map[1, 30] = "$";
                    Map[14, 56] = "$";
                    Map[14, 3] = "$";
                    Map[7, 9] = "♥";
                    Map[21, 13] = "♥";
                    Map[7, 50] = "♥";
                    Map[21, 46] = "♥";
                    break;
                case 4:
                    Map[28, 57] = "E";
                    Map[2, 2] = "X";
                    Map[22, 40] = "$";
                    Map[8, 43] = "$";
                    Map[17, 13] = "♥";
                    Map[2, 50] = "♥";
                    break;
                case 5:
                    Map[2, 56] = "E";
                    Map[28, 2] = "X";
                    Map[15, 57] = "$";
                    Map[2, 30] = "$";
                    Map[28, 10] = "$";
                    Map[28, 50] = "♥";
                    Map[5, 2] = "♥";
                    Map[24, 2] = "♥";
                    break;
                case 6:
                    Map[16, 54] = "E";
                    Map[14, 54] = "X";
                    Map[25, 30] = "$";
                    Map[5, 30] = "$";
                    Map[15, 10] = "$";
                    Map[7, 1] = "♥";
                    Map[22, 1] = "♥";
                    Map[4, 52] = "♥";
                    break;
                case 7:
                    Map[1, 4] = "E";
                    Map[28, 55] = "X";
                    Map[15, 20] = "$";
                    Map[15, 44] = "$";
                    Map[26, 12] = "$";
                    Map[12, 27] = "♥";
                    Map[4, 55] = "♥";
                    Map[27, 38] = "♥";
                    break;
                case 8:
                    Map[1, 1] = "E";
                    Map[28, 57] = "X";
                    Map[6, 10] = "$";
                    Map[11, 42] = "$";
                    Map[20, 3] = "$";
                    Map[22, 38] = "$";
                    Map[28, 35] = "♥";
                    Map[11, 22] = "♥";
                    Map[1, 49] = "♥";
                    break;
                case 9:
                    Map[14, 27] = "E";
                    Map[14, 31] = "X";
                    Map[9, 10] = "$";
                    Map[19, 10] = "$";
                    Map[14, 54] = "$";
                    Map[27, 24] = "♥";
                    Map[2, 24] = "♥";
                    Map[14, 38] = "♥";
                    break;
                case 10:
                    Map[14, 1] = "E";
                    Map[14, 58] = "X";
                    Map[14, 31] = "♥";
                    Map[7, 56] = "♥";
                    Map[22, 56] = "♥";
                    break;
                default:
                    break;
            }
        }
        public void MapsInsides(int i, int j)
        {
            switch (Player.GetPlayerInstance.Level)
            {
                case 1:
                    MapOne(i,j);
                    break;
                case 2:
                    MapTwo(i,j);
                    break;
                case 3:
                    MapThree(i,j);
                    break;
                case 4:
                    MapFour(i, j);
                    break;
                case 5:
                    MapFive(i,j);
                    break;
                case 6:
                    MapSix(i,j);
                    break;
                case 7:
                    MapSeven(i,j);
                    break;
                case 8:
                    MapEight(i,j);
                    break;
                case 9:
                    MapNine(i, j);
                    break;
                case 10:
                    MapTen(i,j);
                    break;
                default:             
                    break;
            }
        }
        public void MapOne(int i, int j)
        {
            if ((i >= 0 && i <= (0 + IslandHeight)) && (j >= 16 && j <= (16 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 16 || j == 16 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == 0 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 5 && i <= (5 + IslandHeight)) && (j >= 16 && j <= (16 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 16 || j == 16 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 5 || i == 5 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 5 && i <= (5 + IslandHeight)) && (j >= 38 && j <= (38 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 38 || j == 38 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 5 || i == 5 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 28 && j <= (28 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 28 || j == 28 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 0 && j <= (0 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 0 || j == 0 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 24 && i <= (24 + IslandHeight)) && (j >= 10 && j <= (10 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 10 || j == 10 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 24 || i == 24 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapTwo(int i,int j)
        {
            if ((i >= 5 && i <= (5 + IslandHeight)) && (j >= 0 && j <= (0 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 0 || j == 0 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 5 || i == 5 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 5 && i <= (5 + IslandHeight)) && (j >= 15 && j <= (15 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 15 || j == 15 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 5 || i == 5 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 41 && j <= (41 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 41 || j == 41 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 22 && j <= (22 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 22 || j == 22 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 3 && j <= (3 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 3 || j == 3 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= (22 + IslandHeight)) && (j >= 20 && j <= (20 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 20 || j == 20 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapThree(int i,int j)
        {
            if ((i >= 18 && i <= (18 + IslandHeight)) && (j >= 22 && j <= (22 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 22 || j == 22 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 18 || i == 18 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 9 && j <= (9 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 9 || j == 9 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 9 && i <= (9 + IslandHeight)) && (j >= 9 && j <= (9 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 9 || j == 9 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 9 || i == 9 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 14 && i <= (14 + IslandHeight)) && (j >= 35 && j <= (35 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 35 || j == 35 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 14 || i == 14 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 9 && i <= (9 + IslandHeight)) && (j >= 35 && j <= (35 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 35 || j == 35 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 9 || i == 9 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 0 && i <= (0 + IslandHeight)) && (j >= 0 && j <= (0 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 0 || j == 0 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == 0 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 0 && i <= (0 + IslandHeight)) && (j >= 44 && j <= (44 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 44 || j == 44 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == 0 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= (22 + IslandHeight)) && (j >= 3 && j <= (3 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 3 || j == 3 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= (22 + IslandHeight)) && (j >= 41 && j <= (41 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 41 || j == 41 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapFour(int i,int j)
        {
            if ((i >= 4 && i <= (4 + IslandHeight)) && (j >= 1 && j <= (1 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 1 || j == 1 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 4 || i == 4 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 4 && i <= (4 + IslandHeight)) && (j >= 17 && j <= (17 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 17 || j == 17 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 4 || i == 4 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }            
            
            if ((i >= 13 && i <= (13 + IslandHeight)) && (j >= 27 && j <= (27 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 27 || j == 27 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 13 || i == 13 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 13 && i <= (13 + IslandHeight)) && (j >= 43 && j <= (43 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 43 || j == 43 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 13 || i == 13 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }

            if ((i >= 22 && i <= (22 + IslandHeight)) && (j >= 1 && j <= (1 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 1 || j == 1 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= (22 + IslandHeight)) && (j >= 17 && j <= (17 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 17 || j == 17 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }            
        }
        public void MapFive(int i,int j)
        {
            if ((i >= 8 && i <= (6 + IslandHeight*3)) && (j >= 13 && j <= (1 + IslandWidth * 3)))
            {
                //InsideWalls();
                if (j == 13 || j == (1 + IslandWidth * 3))
                {
                    Map[i, j] = "|";
                }
                else if (i == 8 || i == (6 + IslandHeight * 3))
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 0 && i <= (-1 + IslandHeight)) && (j >= 11 && j <= (9 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 11 || j == 9 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == -1 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 0 && i <= (-1 + IslandHeight)) && (j >= 35 && j <= (33 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 35 || j == 33 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == -1 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 25 && i <= (24 + IslandHeight)) && (j >= 11 && j <= (9 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 11 || j == 9 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 25 || i == 24 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 25 && i <= (24 + IslandHeight)) && (j >= 35 && j <= (33 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 35 || j == 33 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 25 || i == 24 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 6 && i <= (6 + IslandHeight)) && (j >= 52 && j <= (50 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 52 || j == 50 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 6 || i == 6 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 18 && i <= (18 + IslandHeight)) && (j >= 52 && j <= (50 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 52 || j == 50 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 18 || i == 18 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 6 && i <= (6 + IslandHeight)) && (j >= 0 && j <= (-8 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 0 || j == -8 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 6 || i == 6 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 18 && i <= (18 + IslandHeight)) && (j >= 0 && j <= (-8 + IslandWidth)))
            {
                //InsideWalls();
                if (j == 0 || j == -8 + IslandWidth)
                {
                    Map[i, j] = "|";
                }
                else if (i == 18 || i == 18 + IslandHeight)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapSix(int i, int j)
        {
            if ((i >= 15 && i <= 15) && (j >= 45 && j <= 59))
            {
                //InsideWalls();
                if (j == 45 || j == 59)
                {
                    Map[i, j] = "|";
                }
                else if (i == 15 || i == 15)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 4 && i <= 13) && (j >= 5 && j <= 16))
            {
                //InsideWalls();
                if (j == 5 || j == 16)
                {
                    Map[i, j] = "|";
                }
                else if (i == 4 || i == 13)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 17 && i <= 26) && (j >= 5 && j <= 16))
            {
                //InsideWalls();
                if (j == 5 || j == 16)
                {
                    Map[i, j] = "|";
                }
                else if (i == 17 || i == 26)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 9 && i <= 21) && (j >= 25 && j <= 45))
            {
                //InsideWalls();
                if (j == 25 || j == 45)
                {
                    Map[i, j] = "|";
                }
                else if (i == 9 || i == 21)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 3 && i <= 7) && (j >= 38 && j <= 50))
            {
                //InsideWalls();
                if (j == 38 || j == 50)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 7)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 23 && i <= 27) && (j >= 38 && j <= 50))
            {
                //InsideWalls();
                if (j == 38 || j == 50)
                {
                    Map[i, j] = "|";
                }
                else if (i == 23 || i == 27)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapSeven(int i,int j)
        {
            if ((i >= 4 && i <= 8) && (j >= 8 && j <= 24))
            {
                //InsideWalls();
                if (j == 8 || j == 24)
                {
                    Map[i, j] = "|";
                }
                else if (i == 4 || i == 8)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 9 && i <= 12) && (j >= 24 && j <=24))
            {
                //InsideWalls();
                if (j == 24 || j == 24)
                {
                    Map[i, j] = "|";
                }
                else if (i == 9 || i == 12)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 13 && i <= 17) && (j >= 23 && j <= 42))
            {
                //InsideWalls();
                if (j == 23 || j == 42)
                {
                    Map[i, j] = "|";
                }
                else if (i == 13 || i == 17)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 16 && i <= 16) && (j >= 42 && j <= 59))
            {
                //InsideWalls();
                if (j == 42 || j == 59)
                {
                    Map[i, j] = "|";
                }
                else if (i == 16 || i == 16)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 21 && i <= 25) && (j >= 3 && j <= 18))
            {
                //InsideWalls();
                if (j == 3 || j == 18)
                {
                    Map[i, j] = "|";
                }
                else if (i == 21 || i == 25)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= 25) && (j >= 38 && j <= 48))
            {
                //InsideWalls();
                if (j == 38 || j == 48)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 25)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 25 && i <= 29) && (j >= 43 && j <= 43))
            {
                //InsideWalls();
                if (j == 43 || j == 43)
                {
                    Map[i, j] = "|";
                }
                else if (i == 25 || i == 29)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 4 && i <= 9) && (j >= 35 && j <= 49))
            {
                //InsideWalls();
                if (j == 35 || j == 49)
                {
                    Map[i, j] = "|";
                }
                else if (i == 4 || i == 9)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapEight(int i, int j)
        {
            if ((i >= 7 && i <= 12) && (j >= 28 && j <= 39))
            {
                //InsideWalls();
                if (j == 28 || j == 39)
                {
                    Map[i, j] = "|";
                }
                else if (i == 7 || i == 12)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 10 && i <= 10) && (j >= 18 && j <= 28))
            {
                //InsideWalls();
                if (j == 18 || j == 28)
                {
                    Map[i, j] = "|";
                }
                else if (i == 10 || i == 10)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 10 && i <= 17) && (j >= 18 && j <= 18))
            {
                //InsideWalls();
                if (j == 18 || j == 18)
                {
                    Map[i, j] = "|";
                }
                else if (i == 10 || i == 17)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 13 && i <= 13) && (j >= 7 && j <= 18))
            {
                //InsideWalls();
                if (j == 7 || j == 18)
                {
                    Map[i, j] = "|";
                }
                else if (i == 13 || i == 13)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 18 && i <= 18) && (j >= 0 && j <= 10))
            {
                //InsideWalls();
                if (j == 0 || j == 10)
                {
                    Map[i, j] = "|";
                }
                else if (i == 18 || i == 18)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 0 && i <= 2) && (j >= 32 && j <= 32))
            {
                //InsideWalls();
                if (j == 32 || j == 32)
                {
                    Map[i, j] = "|";
                }
                else if (i == 0 || i == 2)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 17 && i <= 17) && (j >= 27 && j <= 59))
            {
                //InsideWalls();
                if (j == 27 || j == 59)
                {
                    Map[i, j] = "|";
                }
                else if (i == 17 || i == 17)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 3 && i <= 3) && (j >= 22 && j <= 42))
            {
                //InsideWalls();
                if (j == 22 || j == 42)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 3)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 22 && i <= 22) && (j >= 0 && j <= 30))
            {
                //InsideWalls();
                if (j == 0 || j == 30)
                {
                    Map[i, j] = "|";
                }
                else if (i == 22 || i == 22)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 21 && i <= 25) && (j >= 40 && j <= 50))
            {
                //InsideWalls();
                if (j == 40 || j == 50)
                {
                    Map[i, j] = "|";
                }
                else if (i == 21 || i == 25)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 24 && i <= 27) && (j >= 7 && j <= 14))
            {
                //InsideWalls();
                if (j == 7 || j == 14)
                {
                    Map[i, j] = "|";
                }
                else if (i == 24 || i == 27)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapNine(int i, int j)
        {
            if ((i >= 9 && i <= 19) && (j >= 29 && j <= 29))
            {
                //InsideWalls();
                if (j == 29 || j == 29)
                {
                    Map[i, j] = "|";
                }
                else if (i == 9 || i == 19)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 8 && i <= 8) && (j >= 19 && j <= 39))
            {
                //InsideWalls();
                if (j == 19 || j == 39)
                {
                    Map[i, j] = "|";
                }
                else if (i == 8 || i == 8)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 20 && i <= 20) && (j >= 19 && j <= 39))
            {
                //InsideWalls();
                if (j == 19 || j == 39)
                {
                    Map[i, j] = "|";
                }
                else if (i == 20 || i == 20)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 12 && i <= 16) && (j >= 21 && j <= 21))
            {
                //InsideWalls();
                if (j == 21 || j == 21)
                {
                    Map[i, j] = "|";
                }
                else if (i == 12 || i == 16)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 12 && i <= 16) && (j >= 37 && j <= 37))
            {
                //InsideWalls();
                if (j == 37 || j == 37)
                {
                    Map[i, j] = "|";
                }
                else if (i == 12 || i == 16)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 12 && i <= 16) && (j >= 5 && j <= 13))
            {
                //InsideWalls();
                if (j == 5 || j == 13)
                {
                    Map[i, j] = "|";
                }
                else if (i == 12 || i == 16)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 5 && i <= 9) && (j >= 45 && j <= 53))
            {
                //InsideWalls();
                if (j == 45 || j == 53)
                {
                    Map[i, j] = "|";
                }
                else if (i == 5 || i == 9)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 19 && i <= 23) && (j >= 45 && j <= 53))
            {
                //InsideWalls();
                if (j == 45 || j == 53)
                {
                    Map[i, j] = "|";
                }
                else if (i == 19 || i == 23)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 23 && i <= 26) && (j >= 12 && j <= 32))
            {
                //InsideWalls();
                if (j == 12 || j == 32)
                {
                    Map[i, j] = "|";
                }
                else if (i == 23 || i == 26)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 3 && i <= 5) && (j >= 12 && j <= 32))
            {
                //InsideWalls();
                if (j == 12 || j == 32)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 5)
                {
                    Map[i, j] = "-";
                }
            }
        }
        public void MapTen(int i, int j)
        {
            if ((i >= 3 && i <= 11) && (j >= 8 && j <= 18))
            {
                //InsideWalls();
                if (j == 8 || j == 18)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 11)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 17 && i <= 26) && (j >= 8 && j <= 18))
            {
                //InsideWalls();
                if (j == 8 || j == 18)
                {
                    Map[i, j] = "|";
                }
                else if (i == 17 || i == 26)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 17 && i <= 26) && (j >= 26 && j <= 36))
            {
                //InsideWalls();
                if (j == 26 || j == 36)
                {
                    Map[i, j] = "|";
                }
                else if (i == 17 || i == 26)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 3 && i <= 11) && (j >= 26 && j <= 36))
            {
                //InsideWalls();
                if (j == 26 || j == 36)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 11)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 3 && i <= 11) && (j >= 44 && j <= 54))
            {
                //InsideWalls();
                if (j == 44 || j == 54)
                {
                    Map[i, j] = "|";
                }
                else if (i == 3 || i == 11)
                {
                    Map[i, j] = "-";
                }
            }
            if ((i >= 17 && i <= 26) && (j >= 44 && j <= 54))
            {
                //InsideWalls();
                if (j == 44 || j == 54)
                {
                    Map[i, j] = "|";
                }
                else if (i == 17 || i == 26)
                {
                    Map[i, j] = "-";
                }
            }
        }        
    }
}