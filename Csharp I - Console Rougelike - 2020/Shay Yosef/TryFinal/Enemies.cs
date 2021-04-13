using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TryFinal
{
    class Enemies
    {
        char enemy;
        int col;
        int row;
        public int HP;
        public int dmg;
        int redo = 0;
        MapGenerator map = new MapGenerator(20, 50, 0);
        

        Random rand = new Random();

        public Enemies(char enemy, int col, int row , int hp , int damage)
        {
            
            this.enemy = enemy;
            this.row = row;
            this.col = col;
            HP = hp;
            dmg = damage;
            // generateEnemy();
        }
        public Enemies(int hp, int damage)
        {
            HP = hp;
            dmg = damage;

        }

        public void moveEnemy()
        {
            do
            {
                Random rand = new Random();

                int keyinfo;
                keyinfo = rand.Next(0, 4);


                switch (keyinfo)
                {
                    case 0:
                        if (map.getValue(row, col + 1) != '#' && map.getValue(row, col + 1) != '*')
                        {
                            Console.Write("");
                            col++;
                        }
                        break;

                    case 1:
                        if (map.getValue(row, col - 1) != '#' && map.getValue(row, col - 1) != '*')
                        {
                            col--;
                        }
                        break;

                    case 2:
                        if (map.getValue(row - 1, col) != '#' && map.getValue(row - 1, col) != '*')
                        {
                            row--;
                        }

                        break;

                    case 3:
                        if (map.getValue(row + 1, col) != '#' && map.getValue(row + 1, col) != '*')
                        {
                            row++;
                        }

                        break;
                }
                Thread.Sleep(500);
            } while (redo == 0);
        }
        public string enemyStats()
        {
           // Console.SetCursorPosition(50, 0 + level);
            Console.SetCursorPosition(0, 23);
            return "Enemy HP = " + HP + " " + "Dmg = " + dmg;
        }

        //public void enemiesStats(int level)
        //{
        //    if (level == 1)
        //    {
        //        Console.WriteLine(enemyStats(0)); 
        //    }
        //    else if (level == 2)
        //    {
        //        Console.WriteLine(enemyStats(level - 2));
        //        Console.WriteLine(enemyStats(level - 1));
        //    }
        //    else if (level == 3)
        //    {
        //        Console.WriteLine(enemyStats(level - 3));
        //        Console.WriteLine(enemyStats(level - 2));
        //        Console.WriteLine(enemyStats(level - 1));
        //    }
        //    else if (level == 4)
        //    {
        //        Console.WriteLine(enemyStats(level - 4));
        //        Console.WriteLine(enemyStats(level - 3));
        //        Console.WriteLine(enemyStats(level - 2));
        //        Console.WriteLine(enemyStats(level - 1));
        //        Console.WriteLine(enemyStats(level));
        //    }
        //    else if (level == 5)
        //    {
        //        Console.WriteLine(enemyStats(level - 5));
        //        Console.WriteLine(enemyStats(level - 4));
        //        Console.WriteLine(enemyStats(level - 3));
        //        Console.WriteLine(enemyStats(level - 2));
        //        Console.WriteLine(enemyStats(level - 1));
        //        Console.WriteLine(enemyStats(level));
        //        Console.WriteLine(enemyStats(level + 1));
        //        Console.WriteLine(enemyStats(level + 2));
        //    }
      //  }
    }
}
