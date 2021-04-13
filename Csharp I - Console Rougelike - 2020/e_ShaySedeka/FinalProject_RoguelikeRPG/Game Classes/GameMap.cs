using System;

namespace FinalProject_RoguelikeRPG
{
    class GameMap
    {
        #region Class Members

        private int mapWidth, mapHeight;
        private char[,] mapLayout;

        int entrancePosRow, entrancePosColumn;

        #endregion

        #region Class Properties

        public int EntrancePosRow { get => entrancePosRow; set => entrancePosRow = value; }
        public int EntrancePosColumn { get => entrancePosColumn; set => entrancePosColumn = value; }

        private enum MapWall
        {
            TopWall, BottomWall, LeftWall, RightWall
        }

        #endregion

        public GameMap()
        {

            //generate random map scale
            Random r = new Random();
            mapWidth = r.Next(GameDefinitions.MapMinWidth, GameDefinitions.MapMaxWidth);
            mapHeight = r.Next(GameDefinitions.MapMinHeight, GameDefinitions.MapMaxHeight);

            //init base map array
            this.mapLayout = new char[GameDefinitions.MapMaxHeight, GameDefinitions.MapMaxWidth];
            initMapWithValue(' ');

            //place walls on map
            PlaceMapFrame();
            PlaceWallsOutsideOfFrame();

            placeEntranceAndExit();

            FillMapWithObstacles(GameDefinitions.MaxObstacleNum);

        }

        #region Initial Map Building

        private void ChangeConsoleColorToMatch(char c)
        {
            if (c == GameDefinitions.WallSymbol) { 
                Console.ForegroundColor = GameDefinitions.WallColor;
                Console.BackgroundColor = GameDefinitions.WallColor;
            }
            else if (c == GameDefinitions.MapFillerSymbol) Console.ForegroundColor = GameDefinitions.FillerColor;
            else if (c == GameDefinitions.EnemySymbol) Console.ForegroundColor = GameDefinitions.EnemyColor;
            else if (c == GameDefinitions.CritShrineSymbol) Console.ForegroundColor = GameDefinitions.CritShrineColor;
            else if (c == GameDefinitions.EvasionShrineSymbol) Console.ForegroundColor = GameDefinitions.EvasionShrineColor;
            else if (c == GameDefinitions.CurrentHPShrineSymbol) Console.ForegroundColor = GameDefinitions.CurrentHPShrineColor;
            else if (c == GameDefinitions.MaxHPShrineSymbol) Console.ForegroundColor = GameDefinitions.MaxHPShrineColor;
            else if (c == GameDefinitions.ExitSymbol) Console.ForegroundColor = GameDefinitions.ExitColor;
            else if (c == GameDefinitions.EntranceSymbol) Console.ForegroundColor = GameDefinitions.EntranceColor;
            else if (c == GameDefinitions.PlayerSymbol) Console.ForegroundColor = GameDefinitions.PlayerColor;
            else if (c == GameDefinitions.ShopSymbol) Console.ForegroundColor = GameDefinitions.ShopColor;
            else if (c == GameDefinitions.TrapSymbol) Console.ForegroundColor = GameDefinitions.TrapColor;

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void initMapWithValue(char value)
        {
            for(int i = 0; i < this.mapLayout.GetLength(0); i++)
            {
                for (int j = 0; j < this.mapLayout.GetLength(1); j++)
                {
                    this.mapLayout[i, j] = value;
                }
            }
        }

        private void PrintMapLine(int lineIndex)
        {
            for(int i = 0; i < this.mapLayout.GetLength(1); i++)
            {
                ChangeConsoleColorToMatch(this.mapLayout[lineIndex, i]);
                System.Console.Write(this.mapLayout[lineIndex, i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            System.Console.WriteLine();
        }

        private void PlaceMapFrame()
        {
            //top wall
            for(int i = 0; i < this.mapWidth; i++)
            {
                this.mapLayout[0, i] = GameDefinitions.WallSymbol;
            }

            //bottom wall
            for (int i = 0; i < this.mapWidth; i++)
            {
                this.mapLayout[mapHeight-1, i] = GameDefinitions.WallSymbol;
            }

            //left wall
            for (int i = 0; i < this.mapHeight; i++)
            {
                this.mapLayout[i, 0] = GameDefinitions.WallSymbol;
            }

            //right wall
            for (int i = 0; i < this.mapHeight; i++)
            {
                this.mapLayout[i, mapWidth-1] = GameDefinitions.WallSymbol;
            }
        }

        private void PlaceWallsOutsideOfFrame()
        {
            for (int i = 0; i < this.mapLayout.GetLength(0); i++)
            {
                for (int j = 0; j < this.mapLayout.GetLength(1); j++)
                {
                    if(j >= mapWidth || i>= mapHeight)
                    {
                        this.mapLayout[i, j] = GameDefinitions.MapFillerSymbol;
                    }
                    
                }
            }
        }

        #endregion

        #region Entrance and Exit Placement 

        private MapWall getOppsiteWall(MapWall wall)
        {
            MapWall oppositeWall = wall;

            switch (wall)
            {
                case MapWall.TopWall:
                    oppositeWall = MapWall.BottomWall;
                    break;
                case MapWall.BottomWall:
                    oppositeWall = MapWall.TopWall;
                    break;
                case MapWall.LeftWall:
                    oppositeWall = MapWall.RightWall;
                    break;
                case MapWall.RightWall:
                    oppositeWall = MapWall.LeftWall;
                    break;
            }

            return oppositeWall;
        }

        private void placeEntranceAndExit()
        {

            //define entrance wall in random, exit will be opposite always.
            Random r = new Random();
            MapWall entranceWall = (MapWall)r.Next(0, 4);
            MapWall exitWall = getOppsiteWall(entranceWall);

            //define the index on the walls in which the entrance\exit is placed.
            int entranceIndex, exitIndex;
            if(entranceWall == MapWall.BottomWall || entranceWall == MapWall.TopWall)
            {
                entranceIndex = r.Next(1, mapWidth - 1);
                System.Threading.Thread.Sleep(20);
                exitIndex = r.Next(1, mapWidth - 1);

            }

            else
            {
                entranceIndex = r.Next(1, mapHeight - 1);
                System.Threading.Thread.Sleep(20);
                exitIndex = r.Next(1, mapHeight - 1);
            }


            //placing the actual symbols on the map layout.

            if(entranceWall == MapWall.TopWall)
            {
                mapLayout[1, entranceIndex] = GameDefinitions.EntranceSymbol;
                mapLayout[mapHeight - 2, exitIndex] = GameDefinitions.ExitSymbol;

                this.EntrancePosRow = 1;
                this.EntrancePosColumn = entranceIndex;
            }
            else if(entranceWall == MapWall.BottomWall)
            {
                mapLayout[mapHeight - 2, entranceIndex] = GameDefinitions.EntranceSymbol;
                mapLayout[1, exitIndex] = GameDefinitions.ExitSymbol;

                this.EntrancePosRow = mapHeight - 2;
                this.EntrancePosColumn = entranceIndex;
            }
            else if(entranceWall == MapWall.LeftWall)
            {
                mapLayout[entranceIndex, 1] = GameDefinitions.EntranceSymbol;
                mapLayout[exitIndex, mapWidth-2] = GameDefinitions.ExitSymbol;

                this.EntrancePosRow = entranceIndex;
                this.EntrancePosColumn = 1;
            }
            else
            {
                mapLayout[entranceIndex, mapWidth - 2] = GameDefinitions.EntranceSymbol;
                mapLayout[exitIndex, 1] = GameDefinitions.ExitSymbol;

                this.EntrancePosRow = entranceIndex;
                this.EntrancePosColumn = mapWidth - 2;
            }

        }

        #endregion

        #region Obstacle Generation

        private bool CheckObstacleLegality(int originRow, int originColumn, int height, int width)
        {
            //check boundaries
            if (originRow + height > this.mapHeight) return false;

            if (originColumn + width > this.mapWidth) return false;

            // check if there is anything imporant in that space
            for (int i = originRow; i < originRow + height; i++)
            {
                for (int j = originColumn; j < originColumn + width; j++)
                {
                    if(mapLayout[i, j] != GameDefinitions.FreeSymbol)
                    {
                        return false;
                    }
                }
            }


                return true;
        }

        private Obstacle GetRandomObstacle()
        {
            Random r = new Random();
            int maxObstacleHeight = mapHeight / GameDefinitions.ObstacleMapFactor;
            int maxObstacleWidth = mapWidth / GameDefinitions.ObstacleMapFactor;

            //get random origin point
            int originRow = r.Next(0, mapHeight);
            int originColumn = r.Next(0, mapWidth);

            //get random size
            int obstacleHeight = r.Next(GameDefinitions.ObstableMinHeight, maxObstacleHeight);
            int obstacleWidth = r.Next(GameDefinitions.ObstableMinWidth, maxObstacleWidth);

            // check legality
            bool isObstacleLegal = CheckObstacleLegality(originRow, originColumn, obstacleHeight, obstacleWidth);

            //sleep to affect random seed.
            System.Threading.Thread.Sleep(20);

            if (!isObstacleLegal)
            {
                return GetRandomObstacle();
            }

            else return new Obstacle(originRow, originColumn, obstacleWidth, obstacleHeight);

        }

        private void DrawMapObstacle(Obstacle obstacle)
        {
            for(int i = obstacle.originRow; i < obstacle.originRow + obstacle.height; i++)
            {
                for(int j = obstacle.originColumn; j < obstacle.originColumn + obstacle.width; j++)
                {
                    mapLayout[i, j] = GameDefinitions.WallSymbol;
                }
            }
        }

        public void FillMapWithObstacles(int numberOfObstacles)
        {
            for (int i = 0; i < numberOfObstacles; i++)
            {
                Obstacle ob = GetRandomObstacle();
                DrawMapObstacle(ob);

            }
        }

        #endregion

        #region Public Methods


        public int GetMapHeight()
        {
            return mapHeight;
        }

        public int GetMapWidth()
        {
            return mapWidth;
        }

        public char[,] GetMapLayout()
        {
            return this.mapLayout;
        }

        public void PlaceOnMapLayout(char value, int row, int column)
        {
            this.mapLayout[row, column] = value;
        }

        public void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < this.mapLayout.GetLength(0); i++)
            {
                PrintMapLine(i);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}
