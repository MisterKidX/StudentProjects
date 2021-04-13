using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    class Spawner
    {
        public void SpawnAll(Map map, int level, Player player, Entrance entrance, Exit exit, Vendor vendor)
        {
            SpawnEnemy(map, level);
            SpawnChest(map, level);
            SpawnTrap(map, level);
            map.SpawnPlayer(player, entrance);
            map.SpawnExit(exit);
            map.SpawnVendor(vendor);
        }
        private void SpawnChest(Map map, float level)
        {
            level = level / 10;
            int chestsToSpawn = (int)level;
            if (chestsToSpawn == 0)
            {
                chestsToSpawn = 1;
            }
            for (int i = 0; i < chestsToSpawn; i++)
            {
                ChestManager.chestList[i] = new Chest();
                map.SpawnChest(ChestManager.chestList[i]);
            }
        }
        private void SpawnEnemy(Map map, int level)
        {
            Random random = new Random();
            int spawnChance;
            for (int i = 0; i < level; i++)
            {
                spawnChance = random.Next(0, 100);
                if (spawnChance > 80)
                {
                    EnemyManager.bigEnemyList[i]  = new BigEnemy(map.SpawnBigEnemy());
                }
                else
                {
                    EnemyManager.smallEnemyList[i] = new SmallEnemy();
                    map.SpawnSmallEnemy(EnemyManager.smallEnemyList[i]);
                }
            }
        }
        private void SpawnTrap(Map map, int level)
        {
            level = level / 5;
            int chestsToSpawn = (int)level;
            if (chestsToSpawn == 0)
            {
                chestsToSpawn = 1;
            }
            for (int i = 0; i < chestsToSpawn; i++)
            {
                EnemyManager.trapList[i] = new Trap();
                map.SpawnTrap(EnemyManager.trapList[i]);
            }
        }
    }
}
