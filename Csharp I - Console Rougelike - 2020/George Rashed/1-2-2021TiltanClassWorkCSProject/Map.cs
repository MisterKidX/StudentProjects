using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class Map
    {
        public int RowSize;
        public int ColomnSize;

        public int RandomWallRow;
        public int RandomWallCol;

        public int RandomEntRow;
        public int RandomEntCol;

        public int RandomExtRow;
        public int RandomExtCol;

        public int RandomChestRow;
        public int RandomChestCol;

        public int RandomEnemyRow;
        public int RandomEnemyCol;
        public int[,] EnemyCordinates;

        public int RandomTrapRow;
        public int RandomTrapCol;
        public int[,] TrapCordinates;

        public string[,] MapGenerationMatrix;

        public int Level = 0;

        // Map Constructor
        public Map(int levelNum, string gameModeSetting)
        {
            Level = levelNum;
            DefiningRandomMapSize();
            MapGenerationMatrix = new string[RowSize, ColomnSize];
            GeneratingMap(RowSize, ColomnSize, gameModeSetting);
            //ShowMapDetails();
        }


        // Section Responsible For Generating Random Numbers
        Random randNum = new Random();
        public void DefiningRandomMapSize()
        {
            //row_size = randNum.Next(10, 21);
            //colomn_size = randNum.Next(20, 41);
            RowSize = randNum.Next(10, 20);
            ColomnSize = randNum.Next(20 + Level * 3, 41 + Level * 3);
        }

        public void RandomWallNumbers()
        {
            RandomWallRow = randNum.Next(1, RowSize-5);
            RandomWallCol = randNum.Next(1, ColomnSize-5);
        }

        public void RandomEntranceNumber()
        {
            RandomEntRow = randNum.Next(1, RowSize / 4);
            RandomEntCol = randNum.Next(1, ColomnSize / 4);
        }
        public void RandomExitNumber()
        {
            RandomExtRow = randNum.Next(RowSize / 2, RowSize - 2);
            RandomExtCol = randNum.Next(ColomnSize / 2, ColomnSize - 2);
        }

        public void RandomEnemyNumber()
        {
            RandomEnemyRow = randNum.Next(1, RowSize - 2);
            RandomEnemyCol = randNum.Next(1, ColomnSize - 2);
        }

        public void RandomTrapNumber()
        {
            RandomTrapRow = randNum.Next(1, RowSize - 2);
            RandomTrapCol = randNum.Next(1, ColomnSize - 2);
        }

        public void RandomChestNumber()
        {
            RandomChestRow = randNum.Next(1, RowSize - 2);
            RandomChestCol = randNum.Next(1, ColomnSize - 2);
        }

        // The Map's Generation Functions
        public void GeneratingMap(int x, int y, string gameModeSetting)
        {
            if (gameModeSetting == "Story")
            {
                if (Level < 10)
                {
                    RandomEntranceNumber();
                    RandomExitNumber();
                    for (int rowPlaceHolder = 0; rowPlaceHolder < MapGenerationMatrix.GetLength(0); rowPlaceHolder++)
                    {
                        for (int colomnPlaceHolder = 0; colomnPlaceHolder < MapGenerationMatrix.GetLength(1); colomnPlaceHolder++)
                        {
                            if (colomnPlaceHolder == 0)
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "|";
                            }
                            else if (colomnPlaceHolder == MapGenerationMatrix.GetLength(1) - 1)
                            {
                                MapGenerationMatrix[rowPlaceHolder, MapGenerationMatrix.GetLength(1) - 1] = "|";
                            }
                            else if (rowPlaceHolder == 0 || rowPlaceHolder == MapGenerationMatrix.GetLength(0) - 1)
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "-";
                            }
                            else if (rowPlaceHolder == RandomEntRow && colomnPlaceHolder == RandomEntCol)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "E";
                            }
                            else if (rowPlaceHolder == RandomExtRow && colomnPlaceHolder == RandomExtCol)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "X";
                            }
                            else
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = " ";
                            }
                            Console.Write(MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder]);
                            Console.ResetColor();
                        }
                        Console.WriteLine("");
                    }
                    EnemySpawnGeneration(gameModeSetting);
                    TrapSpawnGeneration();
                    ChestSpawnGenerator();
                    InnerWallsGeneration();
                }
                else if (Level == 10)
                {
                    RandomEntRow = RowSize / 2;
                    RandomEntCol = 1;
                    for (int rowPlaceHolder = 0; rowPlaceHolder < MapGenerationMatrix.GetLength(0); rowPlaceHolder++)
                    {
                        for (int colomnPlaceHolder = 0; colomnPlaceHolder < MapGenerationMatrix.GetLength(1); colomnPlaceHolder++)
                        {
                            if (colomnPlaceHolder == 0)
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "|";
                            }
                            else if (colomnPlaceHolder == MapGenerationMatrix.GetLength(1) - 1)
                            {
                                MapGenerationMatrix[rowPlaceHolder, MapGenerationMatrix.GetLength(1) - 1] = "|";
                            }
                            else if (rowPlaceHolder == 0 || rowPlaceHolder == MapGenerationMatrix.GetLength(0) - 1)
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "-";
                            }
                            else if (rowPlaceHolder == RandomEntRow && colomnPlaceHolder == RandomEntCol)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "E";
                            }
                            else if (rowPlaceHolder == RowSize / 2 && colomnPlaceHolder == ColomnSize - 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "X";
                            }
                            else
                            {
                                MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = " ";
                            }
                            Console.Write(MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder]);
                            Console.ResetColor();
                        }
                        Console.WriteLine("");
                    }
                    EnemySpawnGeneration(gameModeSetting);
                    AudioManager.getAudioManagerInstance.RunBossFightMusic();
                }
            }
            else if (gameModeSetting == "Survival")
            {
                RandomEntranceNumber();
                RandomExitNumber();
                for (int rowPlaceHolder = 0; rowPlaceHolder < MapGenerationMatrix.GetLength(0); rowPlaceHolder++)
                {
                    for (int colomnPlaceHolder = 0; colomnPlaceHolder < MapGenerationMatrix.GetLength(1); colomnPlaceHolder++)
                    {
                        if (colomnPlaceHolder == 0)
                        {
                            MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "|";
                        }
                        else if (colomnPlaceHolder == MapGenerationMatrix.GetLength(1) - 1)
                        {
                            MapGenerationMatrix[rowPlaceHolder, MapGenerationMatrix.GetLength(1) - 1] = "|";
                        }
                        else if (rowPlaceHolder == 0 || rowPlaceHolder == MapGenerationMatrix.GetLength(0)-1)
                        {
                            MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "-";
                        }
                        else if (rowPlaceHolder == RandomEntRow && colomnPlaceHolder == RandomEntCol)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "E";
                        }
                        else if (rowPlaceHolder == RandomExtRow && colomnPlaceHolder == RandomExtCol)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = "X";
                        }
                        else
                        {
                            MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder] = " ";
                        }
                        Console.Write(MapGenerationMatrix[rowPlaceHolder, colomnPlaceHolder]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                }
                EnemySpawnGeneration(gameModeSetting);
                TrapSpawnGeneration();
                ChestSpawnGenerator();
                InnerWallsGeneration();
            }
        }

        public void EnemySpawnGeneration(string gameModeSetting)
        {
            if (gameModeSetting == "Survival" || (gameModeSetting == "Story" && Level != 10))
            {
                EnemyCordinates = new int[Level, 3];
                for (int enemyAmount = 0; enemyAmount < Level; enemyAmount++)
                {
                    RandomEnemyNumber();
                    while (MapGenerationMatrix[RandomEnemyRow, RandomEnemyCol] != " ")
                    {
                        RandomEnemyNumber();
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    MapGenerationMatrix[RandomEnemyRow, RandomEnemyCol] = "M";
                    Console.SetCursorPosition(RandomEnemyCol, RandomEnemyRow);
                    Console.Write(MapGenerationMatrix[RandomEnemyRow, RandomEnemyCol]);
                    Console.ResetColor();

                    EnemyCordinates[enemyAmount, 0] = RandomEnemyRow;
                    EnemyCordinates[enemyAmount, 1] = RandomEnemyCol;
                    EnemyCordinates[enemyAmount, 2] = Enemy.EnemyHP;
                }
            }
            else if (gameModeSetting == "Story" && Level == 10)
            {
                int enemyRowPos = 1;
                EnemyCordinates = new int[RowSize - 2, 2];
                for (int enemyAmount = 0; enemyAmount < RowSize - 2; enemyAmount++)
                {
                    RandomEnemyRow = enemyRowPos++;
                    RandomEnemyCol = ColomnSize / 2;

                    Console.ForegroundColor = ConsoleColor.Red;
                    MapGenerationMatrix[RandomEnemyRow, RandomEnemyCol] = "M";
                    Console.SetCursorPosition(RandomEnemyCol, RandomEnemyRow);
                    Console.Write(MapGenerationMatrix[RandomEnemyRow, RandomEnemyCol]);
                    Console.ResetColor();

                    EnemyCordinates[enemyAmount, 0] = RandomEnemyRow;
                    EnemyCordinates[enemyAmount, 1] = RandomEnemyCol;
                }
            }
        }

        public void TrapSpawnGeneration()
        {
            TrapCordinates = new int[3, 2];
            for (int trapAmount = 0; trapAmount < TrapCordinates.GetLength(0); trapAmount++)
            {
                RandomTrapNumber();
                while (MapGenerationMatrix[RandomTrapRow,RandomTrapCol] != " ")
                {
                    RandomTrapNumber();
                }

                Console.ForegroundColor = ConsoleColor.Black;
                MapGenerationMatrix[RandomTrapRow, RandomTrapCol] = "*";
                Console.SetCursorPosition(RandomTrapCol, RandomTrapRow);
                Console.Write(MapGenerationMatrix[RandomTrapRow, RandomTrapCol]);
                Console.ResetColor();

                TrapCordinates[trapAmount, 0] = RandomTrapRow;
                TrapCordinates[trapAmount, 1] = RandomTrapCol;
            }
        }

        public void ChestSpawnGenerator()
        {
            RandomChestNumber();
            while (MapGenerationMatrix[RandomChestRow,RandomChestCol] != " ")
            {
                RandomChestNumber();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            MapGenerationMatrix[RandomChestRow, RandomChestCol] = "#";
            Console.SetCursorPosition(RandomChestCol, RandomChestRow);
            Console.Write(MapGenerationMatrix[RandomChestRow, RandomChestCol]);
            Console.ResetColor();
        }


        public void InnerWallsGeneration()
        {
            for (int wallAmnout = 0; wallAmnout < Level * 10; wallAmnout++)
            {
                RandomWallNumbers();
                for (int vertWalls = RandomWallRow; vertWalls < RandomWallRow + 5; vertWalls++)
                {
                    for (int horiWalls = RandomWallCol; horiWalls < RandomWallCol + 5; horiWalls++)
                    {
                        if (MapGenerationMatrix[vertWalls, horiWalls] == "E")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            MapGenerationMatrix[vertWalls, horiWalls] = "E";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            Console.ResetColor();
                        }
                        else if (horiWalls == RandomEntCol || vertWalls == RandomEntRow)
                        {
                            if (MapGenerationMatrix[vertWalls, horiWalls] == "*" || MapGenerationMatrix[vertWalls, horiWalls] == "M" || MapGenerationMatrix[vertWalls, horiWalls] == "#")
                            {
                                break;
                            }
                            else
                            {
                                MapGenerationMatrix[vertWalls, horiWalls] = " ";
                                Console.SetCursorPosition(horiWalls, vertWalls);
                                Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            }
                        }
                        else if (MapGenerationMatrix[vertWalls, horiWalls] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            MapGenerationMatrix[vertWalls, horiWalls] = "X";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            Console.ResetColor();
                        }
                        else if (horiWalls == RandomExtCol || vertWalls == RandomExtRow)
                        {
                            if (MapGenerationMatrix[vertWalls, horiWalls] == "*" || MapGenerationMatrix[vertWalls, horiWalls] == "M" || MapGenerationMatrix[vertWalls, horiWalls] == "#")
                            {
                                break;
                            }
                            else
                            {
                                MapGenerationMatrix[vertWalls, horiWalls] = " ";
                                Console.SetCursorPosition(horiWalls, vertWalls);
                                Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            }
                        }
                        else if (MapGenerationMatrix[vertWalls, horiWalls] == "#")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            MapGenerationMatrix[vertWalls, horiWalls] = "#";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            Console.ResetColor();
                        }
                        else if (horiWalls == RandomChestCol || vertWalls == RandomChestRow)
                        {
                            if (MapGenerationMatrix[vertWalls, horiWalls] == "*" || MapGenerationMatrix[vertWalls, horiWalls] == "M" || MapGenerationMatrix[vertWalls, horiWalls] == "E" || MapGenerationMatrix[vertWalls, horiWalls] == "X")
                            {
                                break;
                            }
                            else
                            {
                                MapGenerationMatrix[vertWalls, horiWalls] = " ";
                                Console.SetCursorPosition(horiWalls, vertWalls);
                                Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            }
                        }
                        else if (MapGenerationMatrix[vertWalls, horiWalls] == "*")
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            MapGenerationMatrix[vertWalls, horiWalls] = "*";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            Console.ResetColor();
                        }
                        else if (MapGenerationMatrix[vertWalls, horiWalls] == "M")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            MapGenerationMatrix[vertWalls, horiWalls] = "M";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                            Console.ResetColor();
                        }
                        else
                        {
                            MapGenerationMatrix[vertWalls, horiWalls] = "|";
                            Console.SetCursorPosition(horiWalls, vertWalls);
                            Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);

                            for (int enemyAmount = 0; enemyAmount < EnemyCordinates.GetLength(0); enemyAmount++)
                            {
                                if (horiWalls == EnemyCordinates[enemyAmount, 1] || vertWalls == EnemyCordinates[enemyAmount, 0])
                                {
                                    if (MapGenerationMatrix[vertWalls, horiWalls] == "*" || MapGenerationMatrix[vertWalls, horiWalls] == "M" || MapGenerationMatrix[vertWalls, horiWalls] == "E" || MapGenerationMatrix[vertWalls, horiWalls] == "X" || MapGenerationMatrix[vertWalls, horiWalls] == "#")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        MapGenerationMatrix[vertWalls, horiWalls] = " ";
                                        Console.SetCursorPosition(horiWalls, vertWalls);
                                        Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                                    }
                                }
                            }

                            for (int trapAmount = 0; trapAmount < TrapCordinates.GetLength(0); trapAmount++)
                            {
                                if (horiWalls == TrapCordinates[trapAmount, 1] || vertWalls == TrapCordinates[trapAmount, 0])
                                {
                                    if (MapGenerationMatrix[vertWalls, horiWalls] == "*" || MapGenerationMatrix[vertWalls, horiWalls] == "M" || MapGenerationMatrix[vertWalls, horiWalls] == "E" || MapGenerationMatrix[vertWalls, horiWalls] == "X" || MapGenerationMatrix[vertWalls, horiWalls] == "#")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        MapGenerationMatrix[vertWalls, horiWalls] = " ";
                                        Console.SetCursorPosition(horiWalls, vertWalls);
                                        Console.Write(MapGenerationMatrix[vertWalls, horiWalls]);
                                    }
                                }
                            }
                        }
                    }
                }
            }   
        }


        // Functions To Show Map Details 
        public void ShowEnemyCordinates()
        {
            for (int i = 0; i < EnemyCordinates.GetLength(0); i++)
            {
                Console.Write("Enemy" + (i+1) + "{");
                for (int j = 0; j < EnemyCordinates.GetLength(1); j++)
                {
                    Console.Write(EnemyCordinates[i, j]);
                    if (j < EnemyCordinates.GetLength(1) - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        public void ShowTrapCordinates()
        {
            for (int i = 0; i < TrapCordinates.GetLength(0); i++)
            {
                Console.Write("Trap:" + (i + 1) + "{");
                for (int j = 0; j < TrapCordinates.GetLength(1); j++)
                {
                    Console.Write(TrapCordinates[i, j]);
                    if (j < TrapCordinates.GetLength(1) - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        public void ShowMapDetails()
        {
            Console.SetCursorPosition(0, RowSize);
            Console.WriteLine("Level:" + Level);
            Console.WriteLine("Map Size:(" + RowSize + " , " + ColomnSize + ")");
            Console.WriteLine("Entrance:(" + RandomEntRow + " , " + RandomEntCol + ")");
            Console.WriteLine("Exit:(" + RandomExtRow + " , " + RandomExtCol + ")");
            Console.WriteLine("Chest:(" + RandomChestRow + " , " + RandomChestCol + ")");
            ShowEnemyCordinates();
            ShowTrapCordinates();
        }


        public static void ClearNoteBoard(int rowSize)
        {
            Console.SetCursorPosition(0, rowSize + 8);
            for (int clrLength = 0; clrLength < 17; clrLength++)
            {
                Console.WriteLine("                                                                                                                        ");
            }
            Console.SetCursorPosition(0, rowSize + 8);
        }
    }
}
