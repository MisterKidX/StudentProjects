using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoughLite
{
    class Maps
    {
        private string[,] _grid;
        
        public int _height;
        public int _width;
        private int _entranceCol;
        private int _level;

        private Random _random;

        public Maps(string[,] grid, int entreinsCol, int level)
        {
            _random = new Random();
            _level = level;
            _entranceCol = entreinsCol;
            _grid = grid;
            _height = _grid.GetLength(0);
            _width = _grid.GetLength(1);
        }

        public void DrawMap()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    string element = _grid[y, x];
                    Console.SetCursorPosition(x, y);

                    if (element == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (element == "E")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write(element);
                }
            }
        }
        public string GetElementAt(int gX, int gY)
        {
            return _grid[gY, gX];
        }
        public bool IsWalkableSpace(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height)
            {
                return false;
            }

            return _grid[y, x] == " " || _grid[y, x] == null || _grid[y, x] == "E" || _grid[y, x] == "X";
        }

        public static Maps InitMap(int width, int height, int level)
        {
            Random rMap = new Random();
            string[,] grid = new string[height, width];
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (r == 0 || c == 0 || r == height - 1 || c == width - 1)
                    {
                        grid[r, c] = "░";
                    }
                    else
                    {
                        grid[r, c] = r > 1 && r < height - 2 && rMap.Next(100) < level + 10 ? "▒" : null;
                    }
                }
            }

            int entreinsCol = rMap.Next(1, width - 1);
            grid[0, entreinsCol] = "E";
            grid[height - 1, rMap.Next(1, width - 1)] = "X";

            return new Maps(grid, entreinsCol, level);

        }
        public Player PlayerPos(Player currentPlayer)
        {
            if (currentPlayer == null)
            {
                return new Player(_entranceCol, 0);
            }
            currentPlayer.X = _entranceCol;
            currentPlayer.Y = 0;
            return currentPlayer;
        }
        public Enemy EnemyPos()
        {
            int x = _random.Next(2, _width - 1);
            int y = _random.Next(1, _height - 1);
            while (_grid[y, x] == "▒")
            {
                x = _random.Next(2, _width - 1);
                y = _random.Next(1, _height - 1);
            }



            return new Enemy(x, y, _level);
        }
        public Item ItemsPos()
        {
            int x = _random.Next(2, _width - 1);
            int y = _random.Next(1, _height - 1);
            while (_grid[y, x] == "▒")
            {
                x = _random.Next(2, _width - 1);
                y = _random.Next(1, _height - 1);
            }
            return new Item(x, y, _level, _random);
        }
    }


}
