using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Map
    {
        Random random = new Random();
        public Cells[,] mapArray;
        static int _mapHight;
        static int _mapLength;
        static int _spawnWallChance = 0;
        public int hightStart;
        public int hightEnd;
        public int lengthStart;
        public int lengthEnd;
        public int maxHight;
        public int maxLength;
        public int maxRightEdge;
        private int _mapFirstBlock;
        private int _mapSpawnWallForLoop = 0;
        public Map(int mapHight, int mapLength, int spawnWallChance)
        {
            _mapHight = mapHight;
            _mapLength = mapLength;
            mapArray = new Cells[_mapHight, _mapLength];
            _spawnWallChance = spawnWallChance;
            float modularMapHight = _mapHight / 5;
            float modularMapLength = _mapLength / 5;
            hightStart = (int)modularMapHight;
            lengthStart = (int)modularMapLength;
            hightEnd = _mapHight - hightStart;
            lengthEnd = _mapLength - lengthStart;
            maxHight = _mapHight;
            maxHight--;
            maxLength = _mapLength;
            maxLength--;
            maxRightEdge = maxLength;
            maxRightEdge--;
            _mapFirstBlock = random.Next(1, (int)maxHight / 5);
        }
        public void GenerateMap()
        {
            //AssignMapFrame
            for (int i = 0; i < _mapHight; i++)
            {
                for (int j = 0; j < _mapLength; j++)
                {
                    if (i == 0)
                    {
                        mapArray[i, j] = new Cells() { type = Type.Wall };
                    }
                    else if (i == maxHight)
                    {
                        mapArray[i, j] = new Cells() { type = Type.Wall };
                    }
                    else if (j == 0)
                    {
                        mapArray[i, j] = new Cells() { type = Type.Wall };
                    }
                    else if (j == maxLength)
                    {
                        mapArray[i, j] = new Cells() { type = Type.Wall };
                    }
                }
            }
            //AssignMapCenter
            for (int i = hightStart; i < hightEnd; i++)
            {
                for (int j = lengthStart; j < lengthEnd; j++)
                {
                    mapArray[i, j] = new Cells() { type = Type.Empty };
                }
            }
            //AssignMapEdge
            for (int i = 1; i < maxHight; i++)
            {
                int lastI = i;
                lastI--;
                int nextI = i;
                nextI++;
                for (int j = 1; j < maxLength; j++)
                {
                    int lastJ = j;
                    lastJ--;
                    int nextJ = j;
                    nextJ++;
                    if (i <= hightStart)//if on first layer have a chance to spawn wall
                    {
                        _mapSpawnWallForLoop = random.Next(0, 100);
                        _mapSpawnWallForLoop += _spawnWallChance;
                        if (i == 1)
                        {
                            if (mapArray[i, lastJ].type == Type.Empty && _mapSpawnWallForLoop > 10)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                            else if (mapArray[i, lastJ].type == Type.Wall && _mapSpawnWallForLoop > 5)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        else if (mapArray[lastI, j].type == Type.Wall && mapArray[lastI, nextJ].type == Type.Wall)
                        {
                            if (mapArray[lastI, lastJ].type == Type.Empty || mapArray[lastI, nextJ].type == Type.Empty)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Empty };
                            }
                            else if (mapArray[i, lastJ].type == Type.Wall && _mapSpawnWallForLoop > 5)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                            else if (_mapSpawnWallForLoop > 5)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        if (mapArray[i, j] == null)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                    }//top part of the map
                    else if (i >= hightEnd && i < maxHight)//bottom part of the map
                    {
                        _mapSpawnWallForLoop = random.Next(0, 100);
                        _mapSpawnWallForLoop += _spawnWallChance;
                        if (mapArray[i, j] != null)
                        {
                            //continue
                        }
                        else if (j == 1 && mapArray[lastI, j].type == Type.Wall && mapArray[lastI, nextJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (j == maxRightEdge && mapArray[lastI, lastJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, lastJ].type == Type.Wall && mapArray[lastI, j].type == Type.Wall && mapArray[lastI, nextJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, j].type == Type.Wall && mapArray[lastI, nextJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (i == hightEnd && mapArray[lastI, lastJ].type != Type.Wall)//have a chance to add some * on the top part of the bottom
                        {
                            if (_mapSpawnWallForLoop >= 90)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        else if (i > hightEnd)
                        {
                            if (mapArray[lastI, nextJ].type == Type.Wall || mapArray[lastI, lastJ].type == Type.Wall || mapArray[lastI, j].type == Type.Wall)//check for next upper right block and if there is * in it will have a chance to spawn wall
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        if (mapArray[i, j] == null)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                    }//bottom part of the map
                    else if (j <= lengthStart)//left side of map
                    {
                        _mapSpawnWallForLoop = random.Next(0, 100);
                        _mapSpawnWallForLoop += _spawnWallChance;
                        if (mapArray[i, j] != null)
                        {
                            //continue
                        }
                        else if (mapArray[lastI, lastJ].type == Type.Wall && mapArray[i, lastJ].type == Type.Empty)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                        else if (lastI == hightStart)
                        {
                            if (mapArray[lastI, lastJ].type == Type.Empty && mapArray[lastI, j].type == Type.Empty && mapArray[lastI, nextJ].type == Type.Empty && _mapSpawnWallForLoop > 90)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                            else
                            {
                                mapArray[i, j] = new Cells() { type = Type.Empty };
                            }
                        }
                        else if (j == 1)
                        {
                            if (mapArray[lastI, nextJ].type == Type.Wall)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                            else if (mapArray[lastI, j].type == Type.Empty && _mapSpawnWallForLoop > 10)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                            else if (mapArray[lastI, j].type == Type.Wall && _mapSpawnWallForLoop > 10)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        else if (mapArray[lastI, nextJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, lastJ].type == Type.Wall && mapArray[i, lastJ].type == Type.Wall && _mapSpawnWallForLoop > 60)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, j].type == Type.Wall && _mapSpawnWallForLoop > 60)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, nextJ].type == Type.Empty)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                        if (mapArray[i, j] == null)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                    }//left side of map
                    else if (j >= lengthEnd && j < maxLength)
                    {
                        _mapSpawnWallForLoop = random.Next(0, 100);
                        _mapSpawnWallForLoop += _spawnWallChance;
                        if (mapArray[i, j] != null)
                        {
                            //continue
                        }
                        else if (lastI == hightStart)
                        {
                            if (mapArray[lastI, lastJ].type == Type.Wall || mapArray[lastI, j].type == Type.Wall || mapArray[lastI, nextJ].type == Type.Wall)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Empty };
                            }
                            else if (j == maxRightEdge && _mapSpawnWallForLoop >= 10)
                            {
                                mapArray[i, j] = new Cells() { type = Type.Wall };
                            }
                        }
                        else if (mapArray[i, lastJ].type == Type.Wall || mapArray[lastI, lastJ].type == Type.Wall)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (mapArray[lastI, nextJ].type == Type.Wall && _mapSpawnWallForLoop > 60)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        else if (j == maxRightEdge && _mapSpawnWallForLoop >= 60)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Wall };
                        }
                        if (mapArray[i, j] == null)
                        {
                            mapArray[i, j] = new Cells() { type = Type.Empty };
                        }
                    }//right side of the map
                }
            }
        }
        public void PrintMap()
        {
            for (int i = 0; i < _mapHight; i++)
            {
                for (int j = 0; j < _mapLength; j++)
                {
                    switch (mapArray[i, j].type)
                    {
                        case Type.Empty:
                            Console.Write("  ");
                            break;
                        case Type.Wall:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("* ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.IslandWall:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("# ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.IslandCenter:
                            Console.Write("  ");
                            break;
                        case Type.Player:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("@ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.SmallEnemy:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("M ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.BigEnemyUpperLeft:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("/ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.BigEnemyUpperRight:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\\ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.BigEnemyLowerLeft:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\\ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.BigEnemyLowerRight:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("/ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.BigEnemyNextStep:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("  ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.Entrance:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("E ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.Exit:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("X ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.Vendor:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("V ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.Chest:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("$ ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case Type.Trap:
                            Console.Write("  ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
        public int GetReducedWallSpawnChance()
        {
            if (_spawnWallChance > -10)
            {
                _spawnWallChance--;
            }
            else
            {
                Console.WriteLine("Spawn Wall Chance is Low Enough");

            }
            return _spawnWallChance;
        }
        public int GetSpawnWallChance()
        {
            return _spawnWallChance;
        }
        public int GetMapHight()
        {
            return _mapHight;
        }
        public int GetMapLength()
        {
            return _mapLength;
        }
        public void SpawnExit(Exit exit)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    mapArray[randomY, randomX].type = Type.Exit;
                    exit.position.y = randomY;
                    exit.position.x = randomX;
                    break;
                }
            }
        }
        public void SpawnVendor(Vendor vendor)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    mapArray[randomY, randomX].type = Type.Vendor;
                    vendor.position.y = randomY;
                    vendor.position.x = randomX;
                    break;
                }
            }
        }
        public void SpawnChest(Chest chest)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    mapArray[randomY, randomX].type = Type.Chest;
                    chest.position.y = randomY;
                    chest.position.x = randomX;
                    break;
                }
            }
        }
        public void SpawnTrap(Trap trap)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    mapArray[randomY, randomX].type = Type.Trap;
                    trap.position.y = randomY;
                    trap.position.x = randomX;
                    break;
                }
            }
        }
        public void SpawnSmallEnemy(SmallEnemy smallEnemy)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    //small enemy
                    mapArray[randomY, randomX].type = Type.SmallEnemy;
                    smallEnemy.position.y = randomY;
                    smallEnemy.position.x = randomX;
                    break;
                }
            }
        }
        public Position SpawnBigEnemy()
        {
            while (true)
            {
                Position bigEnemyPos = new Position();
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                bigEnemyPos.y = randomY;
                bigEnemyPos.x = randomX;
                if (EnemyManager.SpawnBigEnemyCheck(bigEnemyPos))
                {
                    mapArray[randomY, randomX].type = Type.BigEnemyUpperLeft;
                    mapArray[randomY, randomX + 1].type = Type.BigEnemyUpperRight;
                    mapArray[randomY + 1, randomX].type = Type.BigEnemyLowerLeft;
                    mapArray[randomY + 1, randomX + 1].type = Type.BigEnemyLowerRight;
                    return bigEnemyPos;
                }
            }
        }
        #region BlockChecks
        public bool CheckMyBlockEmpty(Position position)
        {
            if(mapArray[position.y, position.x].type == Type.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckRightBlockEmpty(Position position)
        {
            if (mapArray[position.y, position.x + 1].type == Type.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLowerBlockEmpty(Position position)
        {
            if (mapArray[position.y + 1, position.x].type == Type.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLowerRightBlockEmpty(Position position)
        {
            if (mapArray[position.y+1, position.x+1].type == Type.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        public void SpawnPlayer(Player player, Entrance entrance)
        {
            while (true)
            {
                int randomY = random.Next(0, maxHight);
                int randomX = random.Next(0, maxLength);
                if (mapArray[randomY, randomX].type == Type.Empty)
                {
                    //small enemy
                    mapArray[randomY, randomX].type = Type.Player;
                    entrance.position.y = randomY;
                    entrance.position.x = randomX;
                    player.position.y = randomY;
                    player.position.x = randomX;
                    break;
                }
            }
        }
    }
}
