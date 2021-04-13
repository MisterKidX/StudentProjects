using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleGame
{
    class World
    {
        private Game Game;
        // Map top left and bottom right positions.
        public char[,] MapGrid { get; private set; }
        // All of the obstacles in the map.

        private List<int[,]> Obstacles = new List<int[,]>();
        public List<GameObject> GameObjects = new List<GameObject>();
        // The symbols that are in use for the map grid and the obstacles.
        private char[] Symbols; // 0 - Horizontal | 1 - Vertical | 2 - Corner

        private int Rows;

        private int Cols;

        public World(int[] MapEndPoint, char[] Symbols) //char HorizontalBorder, char VerticalBorder, char Corner)
        {
            // Save symbols.
            this.Symbols = Symbols;

            // Save map grid points.
            MapGrid = new char[MapEndPoint[0], MapEndPoint[1]];

            // Draw Map Grid.
            DrawBox(new int[,] { { 0, 0 }, { MapEndPoint[0], MapEndPoint[1] } });
            Rows = MapGrid.GetLength(0);//Y
            Cols = MapGrid.GetLength(1);//X
        }

        public World(int[] MapEndPoint, char[] Symbols, int NumOfBoxes, int[] MaxSize, int[,] Range) : this(MapEndPoint, Symbols)
        {
            Random Rnd = new Random();
            for (int CurrentBox = 0; CurrentBox < NumOfBoxes; CurrentBox++)
            {
                int[] BoxSize = { Rnd.Next(3, MaxSize[0]), Rnd.Next(3, MaxSize[1]) };
                int[] StartPos = { Rnd.Next(Range[0, 0], Range[1, 0]), Rnd.Next(Range[0, 1], Range[1, 1]) };
                int[,] BoxPoints = new int[,] { { StartPos[0], StartPos[1] }, { Math.Min(StartPos[0] + BoxSize[0], MapEndPoint[0]), Math.Min(StartPos[1] + BoxSize[1], MapEndPoint[1]) } };

                Obstacles.Add(BoxPoints);

                DrawBox(BoxPoints);
            }

            ClearIntersection();
        }

        public void DrawWorld()
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    char element = MapGrid[x, y];
                    SetCursorPosition(x, y);

                    if (element == 'X')
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }

                    Write(element);
                }
            }
        }

        public void SpawnGameObject(GameObject gameObject)
        {
            Random rnd = new Random();
            do
            {
                gameObject.X = rnd.Next(gameObject.SpawnZone[0, 0], gameObject.SpawnZone[1, 0]);
                gameObject.Y = rnd.Next(gameObject.SpawnZone[0, 1], gameObject.SpawnZone[1, 1]);

            } while (!IsPostionWalkable(gameObject.X, gameObject.Y));
        }
        public void SpawnGameObjects()
        {
            Random rnd = new Random();

            foreach (GameObject gameObject in GameObjects)
            {
                do
                {
                    gameObject.X = rnd.Next(gameObject.SpawnZone[0, 0], gameObject.SpawnZone[1, 0]);
                    gameObject.Y = rnd.Next(gameObject.SpawnZone[0, 1], gameObject.SpawnZone[1, 1]);

                } while (!IsPostionWalkable(gameObject.X, gameObject.Y));
            }
            DrawGameObjects();
        }
        public void DrawGameObjects()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                SetCursorPosition(gameObject.X, gameObject.Y);
                ForegroundColor = gameObject.Color;
                Write(gameObject.Icon);
            }
        }

        public char GetElementAt(int x, int y)
        {
            return MapGrid[x, y];
        }

        public bool IsPostionWalkable(int x, int y)
        {
            //return (x == 0 || y == 0 || x == Cols || y == Rows) ? false : (Grid[y, x] == '\0' || Grid[y, x] == 'X');

            // Chack bounds first.
            if (x == 0 || y == 0 || x == Cols || y == Rows)
            {
                return false;
            }

            // Chack if the grid is a walable tile.
            return MapGrid[x, y] == '\0' || MapGrid[x, y] == Game.CurrentExit.Icon;
        }

        public void DrawBox(int[,] BoxPoints)
        {
            for (int BorderX = BoxPoints[0, 0] + 1; BorderX < BoxPoints[1, 0] - 1; BorderX++)
            {
                MapGrid[BorderX, BoxPoints[0, 1]] = Symbols[0];
                MapGrid[BorderX, BoxPoints[1, 1] - 1] = Symbols[0];
            }

            for (int BorderY = BoxPoints[0, 1] + 1; BorderY < BoxPoints[1, 1] - 1; BorderY++)
            {
                MapGrid[BoxPoints[0, 0], BorderY] = Symbols[1];
                MapGrid[BoxPoints[1, 0] - 1, BorderY] = Symbols[1];
            }

            MapGrid[BoxPoints[0, 0], BoxPoints[0, 1]] = Symbols[2];
            MapGrid[BoxPoints[0, 0], BoxPoints[1, 1] - 1] = Symbols[2];
            MapGrid[BoxPoints[1, 0] - 1, BoxPoints[0, 1]] = Symbols[2];
            MapGrid[BoxPoints[1, 0] - 1, BoxPoints[1, 1] - 1] = Symbols[2];
        }
        private void ClearIntersection()
        {
            foreach (int[,] Box in Obstacles)
            {
                for (int CurrentPosX = Box[0, 0] + 1; CurrentPosX < Box[1, 0] - 1; CurrentPosX++)
                {
                    for (int CurrentPosY = Box[0, 1] + 1; CurrentPosY < Box[1, 1] - 1; CurrentPosY++)
                    {
                        MapGrid[CurrentPosX, CurrentPosY] = '▓';
                    }
                }
            }
        }
        public void AddGameObject(GameObject newObject)
        {
            GameObjects.Add(newObject);
        }
        public void RemoveGameObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }
        public bool HasGameObject(GameObject gameObject)
        {
            return GameObjects.Contains(gameObject);
        }
        public bool MoveGameObject(GameObject gameObject, GameObject.direction direction)
        {
            int[] newPos = new int[2];
            newPos[0] = gameObject.X;
            newPos[1] = gameObject.Y;
            switch (direction)
            {
                case GameObject.direction.Down:
                    newPos[1]++;
                    break;
                case GameObject.direction.Up:
                    newPos[1]--;
                    break;
                case GameObject.direction.Left:
                    newPos[0]--;
                    break;
                case GameObject.direction.Right:
                    newPos[0]++;
                    break;
            }

            if (MapGrid[newPos[0], newPos[1]] != '\0')
            {
                return false;
            }

            SetCursorPosition(gameObject.X, gameObject.Y);
            Write('\0');

            gameObject.X = newPos[0];
            gameObject.Y = newPos[1];
            return true;
        }
    }
}
