using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class World
    {
        char[,] map = new char[25, 50];
        int rows; 
        int cols;
        int VictoryPositionX;
        int VictoryPositionY;
        Random rnd = new Random();
        List<Enemy> enemies = new List<Enemy>();
        List<Chest> chests = new List<Chest>();
        List<Trap> traps = new List<Trap>();
        Shop shop;

        public World(List<Enemy>enemies, Shop shop,List<Chest> chests, List<Trap> traps)
        {
            this.shop = shop;
            this.enemies = enemies;
            this.chests = chests;
            this.traps = traps;
            VictoryPositionX = rnd.Next(12, 20);
            VictoryPositionY = rnd.Next(30, 45);
             rows = map.GetLength(0);
             cols = map.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows - 1)
                    {
                        map[i, j] = '-';
                    }
                    else if (j == 0 || j == cols - 1)
                    {
                        map[i, j] = '|';
                    }
                    else
                    {
                        map[i, j] = ' ';
                    }
                }
            }
            for (int i = 1; i < rows-1; i++)
            {
                for (int j = 1; j < cols-1; j++)
                {
                    if (rnd.Next(1,51) >= 49 )
                    {
                        if (i != VictoryPositionX && i != shop.x && j!= VictoryPositionY && j!= shop.y)
                        {
                            map[i, j] = '/';
                        }
                      
                    }
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                int x = rnd.Next(1, 24);
                int y = rnd.Next(1, 49);
                if (CheckPositionValidation(x,y) == true)
                {
                    enemies[i].EnemyX = x;
                    enemies[i].EnemyY = y;
                }
                else
                {
                    x = rnd.Next(1, 24);
                    y = rnd.Next(1, 49);
                    i--;
                }
            }

        }

        public void PrinWorld()
        {
            map[VictoryPositionX, VictoryPositionY] = 'X';
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public bool CheckPositionValidation(int x, int y)
        {
            if (x < 0 || y < 0 || x>= cols || y>= rows)
            {
                return false;
            }
            if (map[y, x] == ' ' || map[y, x] == 'X')
            {
                return true;
            }
            else return false;
        }

        public bool CheckVictoryPosition(int x, int y)
        {

            if (map[y,x] == map[VictoryPositionX, VictoryPositionY])
            {
                return true;
            }
            else return false;
        }

        public bool CheckCombatPosition(int x, int y)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].EnemyX == x && enemies[i].EnemyY == y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckShopPositon(int x, int y)
        {
            if (y== shop.y && x == shop.x)
            {
                return true;
            }
            else return false;
        }

        public bool CheckChestPosition(int x, int y)
        {
            for (int i = 0; i < chests.Count; i++)
            {
                if (chests[i].x == x && chests[i].y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckTrapPosition(int x, int y)
        {
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i].x == x && traps[i].y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void SeekPlayer(Player player)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (player.PlayerX != enemies[i].EnemyX || player.PlayerY != enemies[i].EnemyY && enemies[i].HP > 0)
                {
                    if (enemies[i].EnemyX > player.PlayerX && enemies[i].HP > 0 && CheckPositionValidation(enemies[i].EnemyX-1, enemies[i].EnemyY) == true)
                    {
                        enemies[i].EnemyX--;
                    }
                    else if (enemies[i].EnemyX < player.PlayerX && enemies[i].HP > 0 && CheckPositionValidation(enemies[i].EnemyX + 1, enemies[i].EnemyY) == true)
                    {
                        enemies[i].EnemyX++;
                    }
                     if (enemies[i].EnemyY > player.PlayerY && enemies[i].HP > 0 && CheckPositionValidation(enemies[i].EnemyX , enemies[i].EnemyY -1) == true)
                    {
                        enemies[i].EnemyY--;
                    }
                    else if (enemies[i].EnemyY < player.PlayerY && enemies[i].HP > 0 && CheckPositionValidation(enemies[i].EnemyX, enemies[i].EnemyY + 1) == true)
                    {
                        enemies[i].EnemyY++;
                    }
                }
                else
                {
                    if (enemies[i].HP >0)
                    {
                        Combat Battle = new Combat(player, enemies[i]);
                        Console.SetCursorPosition(51, 2);
                        Console.WriteLine("you got caught fight");
                        Console.ReadKey(true);
                        Battle.StartCombat();
                    }
                   

                }
            }
        }
    }
}
