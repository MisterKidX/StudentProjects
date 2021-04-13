using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
class Map
{
    private static Map _mapInstance = null;
    public static Map GetMapInstance
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
    public string VerticalWall = "|";
    public string HorizontalWall = "-";
    public string SoulIcon = "¢";
    public string Entrance = "E";
    public string Exit = "X";
    public string Enemy = "M";
    public string Chest = "O";
    public string Trap = "T";
    public string[,] box = new string[25, 50];
        public int LevelCounter =1;
    public int UpcomingLvl = 2;


    public void MapCreation()
    {


        for (int i = 0; i < box.GetLength(0); i++)
        {
            for (int j = 0; j < box.GetLength(1); j++)
            {
                box[i, j] = " ";
                box[0, j] = HorizontalWall;
                box[box.GetLength(0) - 1, j] = HorizontalWall;
                box[i, 0] = VerticalWall;
                box[i, box.GetLength(1) - 1] = VerticalWall;
                MapInsides(i, j);
                Icons();
                ColorIcons(i,j);
                Console.Write(box[i, j]);
                    Console.ResetColor();

            }


            Console.WriteLine("");

        }


    }
    public void Icons()
    {

        switch (LevelCounter)
        {
            case 1:
                box[23, 23] = SoulIcon;
                box[2, 1] = Chest;
                box[23,1 ] = Entrance;
                
                break;
            case 2:
                box[23, 23] = SoulIcon;
                box[21, 3] = Chest;
                break;
            case 3:
                box[1, 15] = SoulIcon;
                box[23, 23] = SoulIcon;
                box[21, 2] = Chest;
                break;
            case 4:
                box[23, 24] = SoulIcon;
                box[1, 24] = SoulIcon;
                box[21, 3] = Chest;
                break;
            case 5:
                box[22, 46] = SoulIcon;
                box[1, 24] = SoulIcon;
                box[3, 43] = Chest;
                    break;
            case 6:
                box[2, 4] = SoulIcon;
                box[3, 44] = SoulIcon;
                box[23, 46] = Chest;
                box[23 , 3] = Chest;
                break;
            case 7:
                box[3, 5] = SoulIcon;
                box[3, 44] = SoulIcon;
                box[23, 3] = Chest;
                box[23, 46] = Chest;

                break;
            case 8:
                box[3, 5] = SoulIcon;
                box[3, 44] = SoulIcon;
                box[23, 3] = Chest;
                box[23, 46] = Chest;
                break;
            case 9:
                box[3, 28] = SoulIcon;
                box[3, 16] = SoulIcon;
                box[23, 16] = Chest;
                box[23, 28] = Chest;
                break;
            case 10:
                break;
            default:
                break;
        }


    }
    public void MapInsides(int i, int j)
    {


        switch (LevelCounter)
        {
            case 1:
                getMap0(i, j);
                    
                break;
            case 2:
                getMap1(i, j);
                break;
            case 3:
                getMap2(i, j);
                    break;
            case 4:
                getMap3(i, j);
                break;
            case 5:
                getMap4(i, j);
                break;
            case 6:
                getMap5(i, j);
                break;
            case 7:
                getMap6(i, j);
                break;
            case 8:
                getMap7(i, j);
                break;
            case 9:
                getMap8(i, j);
                break;
            case 10:
                getMap9(i, j);
                break;
            default:
                break;
        }

    }
    public void getMap0(int i, int j)
    {
         
    }
    public void getMap1(int i, int j)
    {

        if ((i >= 5 && i <= 17) && (j >= 10 && j <= 30))
        {
            if (j == 10 || j == 30)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 5 || i == 17)
            {
                box[i, j] = HorizontalWall;
            }


        }
    }
    public void getMap2(int i, int j)
    {

        if ((i >= 2 && i <= 30) && (j >= 10 && j <= 20))
        {
            if (j == 10 || j == 20)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 2 || i == 30)
            {
                box[i, j] = HorizontalWall;
            }


        }
    }
    public void getMap3(int i, int j)
    {

        if ((i >= 2 && i <= 22) && (j >= 19 && j <= 27))
        {
            if (j == 19 || j == 27)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 2 || i == 22)
            {
                box[i, j] = HorizontalWall;
            }


        }
    }
    public void getMap4(int i ,int j)
    {
        //I is Y and J is X
        if ((i >= 6 && i <= 8) && (j >= 30 && j <= 45))
        {
            if (j == 30 || j == 45)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 6 || i ==8)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 1 && i <= 10) && (j >= 25 && j <= 30))
        {
            if (j == 25 || j == 30)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 1 || i == 10)
            {
                box[i, j] = HorizontalWall;
            }


        }

        if ((i >= 2 && i <= 30) && (j >= 10 && j <= 20))
        {
            if (j == 10 || j == 20)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 2 || i == 30)
            {
                box[i, j] = HorizontalWall;
            }


        }

    }
    public void getMap5(int i, int j)
    {
        //I is Y and J is X
/*            if ((i >= 20 && i <= 22) && (j >= 4 && j <= 45))
        {
            if (j == 4 || j == 45)
            {
                box[i, j] = verticalWall;
            }

            else if (i == 20 || i == 22)
            {
                box[i, j] = horizontalWall;
            }


        }*/
        if ((i >= 1 && i <= 20) && (j >= 17 && j <= 30))
        {
            if (j == 17 || j == 30)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 1 || i == 20)
            {
                box[i, j] = HorizontalWall;
            }


        }

        if ((i >= 5 && i <= 7) && (j >=3 && j <= 17))
        {
            if (j == 3 || j ==17)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 5 || i == 7)
            {
                box[i, j] = HorizontalWall;
            }


        }

        if ((i >= 5 && i <= 7) && (j >= 30 && j <= 47))
        {
            if (j ==30 || j == 47)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 5 || i == 7)
            {
                box[i, j] = HorizontalWall;
            }


        }

    }
    public void getMap6(int i , int j)
    {
        //I is Y and J is X
        if ((i >= 20 && i <= 22) && (j >= 4 && j <= 45))
        {
            if (j == 4 || j == 45)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 20 || i == 22)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 12 && i <= 14) && (j >= 4 && j <= 45))
        {
            if (j == 4 || j == 45)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 12 || i == 14)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 4 && i <= 6) && (j >= 4 && j <= 45))
        {
            if (j == 4 || j == 45)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 4 || i == 6)
            {
                box[i, j] = HorizontalWall;
            }


        }
    }
    public void getMap7(int i , int j)
    {

        if ((i >= 2 && i <= 22) && (j >= 20 && j <= 28))
        {
            if (j == 20 || j == 28)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 2 || i == 22)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 10 && i <= 12) && (j >= 4 && j <= 45))
        {
            if (j == 4 || j == 45)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 10 || i == 12)
            {
                box[i, j] = HorizontalWall;
            }


        }


    }
    public void getMap8(int i , int j)
    {
        //I is Y and J is X

        if ((i >= 0 && i <= 8) && (j >= 10 && j <= 12))
        {
            if (j == 10 || j == 12)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 0 || i == 8)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 0 && i <= 8) && (j >= 21 && j <= 23))
        {
            if (j == 21 || j == 23)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 0 || i == 8)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 0 && i <= 8) && (j >= 33 && j <= 35))
        {
            if (j == 33 || j == 35)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 0 || i == 8)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 17 && i <= 25) && (j >= 10 && j <= 12))
        {
            if (j == 10 || j == 12)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 17 || i == 25)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 17 && i <= 25) && (j >= 21 && j <= 23))
        {
            if (j == 21 || j == 23)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 17 || i == 25)
            {
                box[i, j] = HorizontalWall;
            }


        }
        if ((i >= 17 && i <= 25) && (j >= 33 && j <= 35))
        {
            if (j == 33 || j == 35)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 17 || i == 25)
            {
                box[i, j] = HorizontalWall;
            }


        }
    }
    public void getMap9(int i, int j)
    {


        if ((i >= 8 && i <= 13) && (j >= 18 && j <= 26))
        {
            if (j == 18 || j == 26)
            {
                box[i, j] = VerticalWall;
            }

            else if (i == 8 || i == 13)
            {
                box[i, j] = HorizontalWall;
            }


        }


    }

    public void ColorIcons(int i , int j)
    {
            switch (LevelCounter)
            {
                case 1:
                    //Chest (X = I , J = Y
                    if (i ==  2  && j == 1 )
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 23 && j == 23)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 2:
                    //Chest (X = I , J = Y
                    if (i == 21 && j == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 23 && j == 23)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 3:
                    //Chest (X = I , J = Y
                    if (i == 21 && j == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 23 && j == 23 || i == 1 && j == 15)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 4:
                    //Chest (X = I , J = Y
                    if (i == 21 && j == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 23 && j == 24 || i == 1 && j == 24)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 5:
                    //Chest (X = I , J = Y
                    if (i == 3 && j == 43)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 22 && j == 46 || i == 1 && j == 24)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 6:
                    //Chest (X = I , J = Y
                    if (i == 23 && j == 46 || i == 23 && j == 3 )
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 3 && j == 44 || i == 2 && j == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 7:
                    //Chest (X = I , J = Y
                    if (i == 23 && j == 3 || i == 23 && j == 46)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 3 && j == 5 || i == 3 && j ==44)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 8:
                    //Chest (X = I , J = Y
                    if (i == 23 && j == 3 || i == 23 && j == 46)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 3 && j == 5 || i == 3 && j == 44)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                case 9:
                    //Chest (X = I , J = Y
                    if (i == 23 && j == 16 || i == 23 && j == 28)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    //Soul
                    if (i == 3 && j == 16 || i == 3 && j == 28)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    break;
                default:
                    break;
            }


        }
    }
   
}
