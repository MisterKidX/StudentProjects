using System;
using System.Timers;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1
{
    class mapGenerator
    {
        public char[,] map;
        IslandGenerator island;
        public mapGenerator(int width, int hieght)
        {
            map = new char[width, hieght];
            island = new IslandGenerator();
        }
        public void DrawEntrance(char entrance)
        {
            map[1, 1] = entrance;
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(map[1, 1]);
            Console.ResetColor();
        }
        public void DrawExit(char exit)
        {
            map[19, 49] = exit;
            Console.SetCursorPosition(48, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(map[19, 49]);
            Console.ResetColor();
        }
        public void insertomap(char c, int row, int col)
        {
            map[col, row] = c;
        }
        public void insertIslandToMap() // get random pos from island
        {
            for (int i = island.rowStartIndex1; i < island.rowStartIndex1 + island.rowMaxSize1; i++)
            {
                for (int j = island.colStartIndex1; j < island.colStartIndex1 + island.colMaxSize1; j++)
                {
                    if (island.island1[i, j] != ' ')
                    {
                        map[i, j] = island.island1[i, j];
                    }
                }
            }
        }
        public void insertIsland2ToMap() // get random pos from island
        {
            for (int i = island.rowStartIndex2; i < island.rowStartIndex2 + island.rowMaxSize2; i++)
            {
                for (int j = island.colStartIndex2; j < island.colStartIndex2 + island.colMaxSize2; j++)
                {
                    if (island.island2[i, j] != ' ')
                    {
                        map[i, j] = island.island2[i, j];
                    }
                }
            }
        }
        public void insertIsland3ToMap() // get random pos from island
        {
            for (int i = island.rowStartIndex3; i < island.rowStartIndex3 + island.rowMaxSize1; i++)
            {
                for (int j = island.colStartIndex3; j < island.colStartIndex3 + island.colMaxSize1; j++)
                {
                    if (island.island3[i, j] != ' ')
                    {
                        map[i, j] = island.island3[i, j];
                    }
                }
            }
        }
        public char[,] getMap()
        {
            return map;
        }
        public void generateMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[0, j] = '-';
                    map[19, j] = '-';
                    map[i, 0] = '|';
                    map[i, 49] = '|';
                    Console.Write(map[i, j]);
                }
                Console.WriteLine("");
            }
            DrawEntrance('E');
            DrawExit('X');
        }
        public Tuple<int,int> PlayerPosition()
        {
            for(int i = 0; i < map.GetLength(0);i++)
            {
                for(int j = 0; j < map.GetLength(1);j++)
                {
                    if(map[i,j] == '♥')
                    {
                        return Tuple.Create(i,j);
                        break;
                    }
                }
            }
            return Tuple.Create(0, 0);
        }
    }
}
