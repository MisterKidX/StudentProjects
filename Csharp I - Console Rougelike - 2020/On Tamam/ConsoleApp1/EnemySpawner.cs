using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EnemySpawner
    {
        

        public Enemy createEnemy(int type, int level)
        {
            switch (type)
            {
                case 1:
                    Enemy PHenemy = new Enemy(type, level);
                    return PHenemy;
                case 2:
                    Enemy MAenemy = new Enemy(type, level);
                    return MAenemy;
                default:
                    Enemy enemy = new Enemy(1, 1);
                    return enemy;
            }
        }
        public Chest CreateChest(Player player,int level)
        {
            Chest chest = new Chest(player, level);
            return chest;
        }

        public Trap CreateTrap(int level, int type)
        {
            Trap trap = new Trap(level, type);
            return trap;
        }

        public Obstacles CreateObstacle()
        {
            Obstacles obs = new Obstacles();
            return obs;
        }
    }
}
