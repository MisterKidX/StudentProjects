using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class Map
    {
        enum SignColor
        {
            Red,
            Blue,
            Green,
            Cyan,

        }
        static public int numberOfNonMerchantInstances = 0;
        static public int level = 0;
        static int numberOfRows = 22;
        static int numberOfColumns = 44;
        static int exitCordsY;
        static int exitCordsX;
        static public string[,] mapLayout = new string[numberOfRows, numberOfColumns];
        static public Random rand = new Random();
        
        static Map()
        {            
        }

        // IMPORTANT: Console.SetCursor works opposite to the way im creating the array, thus:
        // Console.SetCursorPosition(currentColumn, currentRow) = map[currentRow, currentColumn]


        static void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < numberOfColumns; currentColumn++)
                {
                    if (mapLayout[currentRow, currentColumn] == GameIcons.apple)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (mapLayout[currentRow, currentColumn] == GameIcons.treasureChest)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (mapLayout[currentRow, currentColumn] == GameIcons.entry)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (mapLayout[currentRow, currentColumn] == GameIcons.enemy)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(GameIcons.enemy);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    else if(CheckForBossParts(currentRow, currentColumn))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (mapLayout[currentRow, currentColumn] == GameIcons.invisibleMine)
                    {
                        Console.Write(GameIcons.emptySpace);
                        continue;
                    }
                    Console.Write(mapLayout[currentRow, currentColumn]);
                    Console.ForegroundColor = ConsoleColor.Gray;                   
                }
                Console.WriteLine();
            }            
        }

        static public void BuildVerticalWall(int xCords, int yCords, int wallLength)
        {
            for (int i = 0; i < wallLength; i++)
            {
                if ( (yCords + i > 0) && (yCords + i < numberOfRows) )
                {
                    mapLayout[yCords + i, xCords] = GameIcons.verticalWall;
                }
            }
        }

        static public void BuildHorizontalWall(int xCords, int yCords, int wallLength)
        {
            for (int i = 0; i < wallLength; i++)
            {
                if ((xCords + i > 0) && (xCords + i < numberOfColumns))
                {
                    mapLayout[yCords, xCords+i] = GameIcons.horizontalWall;
                }
            }
        }

        static void InitializeMapFrame()
        {
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < numberOfColumns; currentColumn++)
                {
                    if ((currentColumn == 0) || (currentColumn == (numberOfColumns-1)))
                    {
                        mapLayout[currentRow, currentColumn] = GameIcons.verticalWall; 
                    }
                    else if ((currentRow == 0) || (currentRow == (numberOfRows-1)))
                    {
                        mapLayout[currentRow, currentColumn] = GameIcons.horizontalWall;
                    }                    
                    else
                    {
                        mapLayout[currentRow, currentColumn] = GameIcons.emptySpace;
                    }
                }
                Console.WriteLine();
            }           
        }

        static public void GenerateRandomMap()
        {
            Player.Instance.PlayerResetTempStats();
            level++;
            Console.Clear();
            HUD.PrintHud();
            PrintLevelToHud();
            int mapNumber;
            if (level % 5 == 0)
            {
                mapNumber = 1;
            }
            else
            {
                int upperBound = 9 + (numberOfNonMerchantInstances);
                mapNumber = rand.Next(2, upperBound + 1);
            }
            //mapNumber = 11;       //  for testing a specific map
            switch (mapNumber)
            {
                case 0:
                    GenreateMapTest();
                    break;

                case 1:
                    numberOfNonMerchantInstances++;
                    GenreateBossMap();
                    
                    break;

                case 2:
                    numberOfNonMerchantInstances++;
                    GenreateMap2();
                    break;

                case 3:
                    numberOfNonMerchantInstances++;
                    GenreateMap3();
                    break;

                case 4:
                    numberOfNonMerchantInstances++;
                    GenreateMap4();
                    break;

                case 5:
                    numberOfNonMerchantInstances++;
                    GenreateMap5();
                    break;

                case 6:
                    numberOfNonMerchantInstances++;
                    GenreateMap6();
                    break;

                case 7:
                    numberOfNonMerchantInstances++;
                    GenreateMap7();
                    break;

                case 8:
                    numberOfNonMerchantInstances++;
                    GenreateMap8();
                    break;

                case 9:
                    numberOfNonMerchantInstances++;
                    GenreateMap9();

                    break;

                default:
                    numberOfNonMerchantInstances = 0;
                    GenreateMerchantMap();
                    break;
            }
            InstructionsForLevel();
        }

        static void GenreateMapTest()
        {
            InitializeMapFrame();
            mapLayout[6, 9] = GameIcons.entry;
            Player.Instance.currentColumn = 9;
            Player.Instance.currentRow = 6;
            exitCordsX = 5;
            exitCordsY = 6;
            mapLayout[6, 10] = GameIcons.apple;
            mapLayout[6, 11] = GameIcons.apple;
            mapLayout[6, 12] = GameIcons.apple;
            mapLayout[6, 13] = GameIcons.apple;
            mapLayout[6, 14] = GameIcons.apple;
            mapLayout[6, 15] = GameIcons.treasureChest;
            mapLayout[6, 16] = GameIcons.treasureChest;
            mapLayout[6, 17] = GameIcons.treasureChest;
            mapLayout[5, 5] = GameIcons.horizontalWall;
            mapLayout[5, 6] = GameIcons.horizontalWall;
            mapLayout[5, 7] = GameIcons.horizontalWall;
            SpawnEnemiesForLevel();
            PrintMap();
        }

        static void GenreateBossMap()
        {
            InitializeMapFrame();
            exitCordsY = 1;
            exitCordsX = 20;
            mapLayout[20, 21] = GameIcons.entry;
            Player.Instance.currentColumn = 21;
            Player.Instance.currentRow = 20;
            Enemy boss = new Enemy(10, 21, rand.Next(), true);

            mapLayout[6, 38] = GameIcons.treasureChest;

            mapLayout[6, 9] = GameIcons.apple;
            mapLayout[14, 3] = GameIcons.apple;
            mapLayout[19, 39] = GameIcons.apple;

            ConstructWalls.Instance.MapBossWalls();

            mapLayout[20, 23] = GameIcons.invisibleMine;

            SpawnEntitiesForNormalLevel(4);


            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap2()
        {
            InitializeMapFrame();
            mapLayout[20, 25] = GameIcons.entry;
            Player.Instance.currentColumn = 25;
            Player.Instance.currentRow = 20;
            exitCordsX = 3;
            exitCordsY = 15;

            mapLayout[6, 10] = GameIcons.treasureChest;
            mapLayout[10, 36] = GameIcons.treasureChest;

            mapLayout[6, 17] = GameIcons.apple;
            mapLayout[7, 32] = GameIcons.apple;
            mapLayout[2, 9] = GameIcons.apple;

            ConstructWalls.Instance.Map2Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap3()
        {
            InitializeMapFrame();
            mapLayout[19, 18] = GameIcons.entry;
            Player.Instance.currentRow = 19;
            Player.Instance.currentColumn = 18;            
            exitCordsY = 2;
            exitCordsX = 40;

            mapLayout[9, 8] = GameIcons.treasureChest;
            mapLayout[19, 11] = GameIcons.treasureChest;
            mapLayout[13, 35] = GameIcons.treasureChest;

            mapLayout[6, 41] = GameIcons.apple;
            mapLayout[11, 6] = GameIcons.apple;
            
            ConstructWalls.Instance.Map3Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();

        }

        static void GenreateMap4()
        {
            InitializeMapFrame();
            mapLayout[6, 21] = GameIcons.entry;
            Player.Instance.currentRow = 6;
            Player.Instance.currentColumn = 21;
            exitCordsY = 11;
            exitCordsX = 21;

            mapLayout[2, 3] = GameIcons.treasureChest;
            mapLayout[19, 40] = GameIcons.treasureChest;

            mapLayout[2, 40] = GameIcons.apple;
            mapLayout[19, 3] = GameIcons.apple;

            Enemy enemy1 = new Enemy(5, 32, rand.Next(), false);
            Enemy enemy2 = new Enemy(5, 32, rand.Next(), false);

            ConstructWalls.Instance.Map4Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap5()
        {
            InitializeMapFrame();
            mapLayout[10, 19] = GameIcons.entry;
            Player.Instance.currentRow = 10;
            Player.Instance.currentColumn = 19;
            exitCordsY = 10;
            exitCordsX = 5;

            mapLayout[5, 36] = GameIcons.treasureChest;
            mapLayout[17, 35] = GameIcons.treasureChest;

            mapLayout[15, 1] = GameIcons.apple;
            mapLayout[15, 3] = GameIcons.apple;
            mapLayout[15, 4] = GameIcons.apple;

            Enemy enemy1 = new Enemy(3, 5, rand.Next(), false);


            ConstructWalls.Instance.Map5Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap6()
        {
            InitializeMapFrame();
            mapLayout[10, 41] = GameIcons.entry;
            Player.Instance.currentRow = 10;
            Player.Instance.currentColumn = 41;
            exitCordsY = 10;
            exitCordsX = 2;

            mapLayout[10, 16] = GameIcons.treasureChest;
            mapLayout[10, 6] = GameIcons.treasureChest;

            mapLayout[3, 39] = GameIcons.apple;
            mapLayout[18, 17] = GameIcons.apple;

            Enemy enemy1 = new Enemy(6, 30, rand.Next(), false);
            Enemy enemy2 = new Enemy(15, 30, rand.Next(), false);


            ConstructWalls.Instance.Map6Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap7()
        {
            InitializeMapFrame();
            mapLayout[2, 40] = GameIcons.entry;
            Player.Instance.currentRow = 2;
            Player.Instance.currentColumn = 40;
            exitCordsY = 12;
            exitCordsX = 22;

            mapLayout[14, 22] = GameIcons.treasureChest;
            mapLayout[20, 3] = GameIcons.treasureChest;

            mapLayout[4, 23] = GameIcons.apple;

            ConstructWalls.Instance.Map7Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap8()
        {
            InitializeMapFrame();
            mapLayout[11, 21] = GameIcons.entry;
            Player.Instance.currentRow = 11;
            Player.Instance.currentColumn = 21;
            exitCordsY = 10;
            exitCordsX = 21;

            mapLayout[2, 21] = GameIcons.treasureChest;
            mapLayout[19, 21] = GameIcons.treasureChest;
            mapLayout[12, 21] = GameIcons.treasureChest;

            mapLayout[10, 5] = GameIcons.apple;
            mapLayout[10, 38] = GameIcons.apple;

            Enemy enemy1 = new Enemy(5, 21, rand.Next(), false);
            Enemy enemy2 = new Enemy(16, 21, rand.Next(), false);

            ConstructWalls.Instance.Map8Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMap9()
        {
            InitializeMapFrame();
            mapLayout[4, 41] = GameIcons.entry;
            Player.Instance.currentRow = 4;
            Player.Instance.currentColumn = 41;
            exitCordsY = 17;
            exitCordsX = 41;

            mapLayout[1, 18] = GameIcons.treasureChest;
            mapLayout[19, 3] = GameIcons.treasureChest;

            mapLayout[2, 36] = GameIcons.apple;
            mapLayout[19, 29] = GameIcons.apple;
            mapLayout[20, 10] = GameIcons.apple;

            Enemy enemy1 = new Enemy(7, 30, rand.Next(), false);
            Enemy enemy2 = new Enemy(14, 4, rand.Next(), false);

            ConstructWalls.Instance.Map9Walls();

            SpawnEntitiesForNormalLevel(4);

            Console.SetCursorPosition(0, 0);
            PrintMap();
        }

        static void GenreateMerchantMap()
        {
            InitializeMapFrame();
            exitCordsY = 11;
            exitCordsX = 1;
            mapLayout[11, 42] = GameIcons.entry;
            Player.Instance.currentColumn = 42;
            Player.Instance.currentRow = 11;
            SpawnCodexPage();
            Console.SetCursorPosition(0, 0);
            PrintMap();
            
            Merchant.Instance.SetUpShop();
        }

        static public bool CheckForWalls(int targetRow, int targetColumn)
        {
            if ((mapLayout[targetRow, targetColumn] == GameIcons.verticalWall) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.horizontalWall))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool CheckForBossParts(int targetRow, int targetColumn)
        {
            if ((mapLayout[targetRow, targetColumn] == GameIcons.bossPartEar) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartEye) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartMouth) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartFaceSide) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartFlat) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartLeftShoulder) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartRightShoulder) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartLimb1) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartLimb2) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartWaist) ||
                (mapLayout[targetRow, targetColumn] == GameIcons.bossPartWaist) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void SpawnExit()
        {
            mapLayout[exitCordsY, exitCordsX] = GameIcons.exit;
            Console.SetCursorPosition(exitCordsX, exitCordsY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(GameIcons.exit);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static public int FindEmptySpace()
        {
            int infiniteWatchDog = 0;
            int emptyCordsY = rand.Next(1, numberOfRows);
            int emptyCordsX = rand.Next(1, numberOfColumns);

            while (mapLayout[emptyCordsY, emptyCordsX] != GameIcons.emptySpace)
            {
                emptyCordsY = rand.Next(1, numberOfRows);
                emptyCordsX = rand.Next(1, numberOfColumns);
                infiniteWatchDog++;
                if (infiniteWatchDog >= 1000)
                {
                    return 0;
                }
            }
            return ((100 * emptyCordsY) + emptyCordsX);
        }

        static void SpawnEntitiesForNormalLevel(int numberOfMinesToSpawn)
        {
            SpawnInvisibleMines(numberOfMinesToSpawn);
            SpawnEnemiesForLevel();
            SpawnCodexPage();
        }

        static void SpawnEnemiesForLevel()
        {
            int emptyCordsKey;
            int emptyCordsX;
            int emptyCordsY;
            int desiredNumberOfEnemies = 2 + level;
            if (desiredNumberOfEnemies > 100)
            {
                desiredNumberOfEnemies = 100;
            }
            for (int i = 0; i < desiredNumberOfEnemies; i++)
            {
                emptyCordsKey = FindEmptySpace();
                emptyCordsX = emptyCordsKey%100;
                emptyCordsY = emptyCordsKey/100;
                if (emptyCordsX != 0 && emptyCordsY != 0)
                {
                    Enemy enemy = new Enemy(emptyCordsY, emptyCordsX, rand.Next(), false);
                }
                
            }
        }

        static void SpawnInvisibleMines(int numberOfInvisibleMine)
        {
            int emptyCordsKey;
            int emptyCordsX;
            int emptyCordsY;
            for (int i = 0; i < numberOfInvisibleMine; i++)
            {
                emptyCordsKey = FindEmptySpace();
                emptyCordsX = emptyCordsKey % 100;
                emptyCordsY = emptyCordsKey / 100;
                if (emptyCordsX != 0 && emptyCordsY != 0)
                {
                    mapLayout[emptyCordsY, emptyCordsX] = GameIcons.invisibleMine;
                }
                
            }
        }

        static void SpawnCodexPage()
        {
            int emptyCordsKey;
            int emptyCordsX;
            int emptyCordsY;
            emptyCordsKey = FindEmptySpace();
            emptyCordsX = emptyCordsKey % 100;
            emptyCordsY = emptyCordsKey / 100;
            if (emptyCordsX != 0 && emptyCordsY != 0)
            {
                mapLayout[emptyCordsY, emptyCordsX] = GameIcons.codexPage;
            }
            
        }

        static void PrintLevelToHud()
        {
            int startingLevelStringPosition = 30;
            string levelString = level.ToString();
            int levelStringLength = levelString.Length;
            if (levelStringLength > 2)
            {
                levelString = "99+";
            }
            
            levelString = ("Lvl"+ levelString);
            int numberOfEmptySpacesDesired = 3 - levelStringLength;
            

            //  delete old
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(startingLevelStringPosition + i, 23);
                Console.Write(" ");
            }

            //for (int i = 0; i < numberOfEmptySpacesDesired; i++)
            //{
            //    startingLevelStringPosition++;
            //}
            Console.SetCursorPosition(startingLevelStringPosition, 23);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(levelString);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void InstructionsForLevel()
        {
            if (level == 1)
            {
                HUD.NewHUDEntry("Use the WASD keys to move");
                HUD.NewHUDEntry("Use the Arrow keys to shoot");
                HUD.NewHUDEntry("Kill all enemies, and head");
                HUD.NewHUDEntry("for the exit! (marked with X)");
            }
            if (level == 2)
            {
                Treasure.Instance.AddSeededPotionToPouch(1);
                HUD.NewHUDEntry("To drink a Potion, press a number key");
                HUD.NewHUDEntry("Potions tell their type by color");
                HUD.NewHUDEntry("(Green = Healing)");

            }
        }

        static void BuildSign(string signContent, int signCordX, int signCordY, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(signCordX, signCordY);
            Console.Write(signContent);
            BuildHorizontalWall(signCordX, signCordY, signContent.Length);
        }
    }
}