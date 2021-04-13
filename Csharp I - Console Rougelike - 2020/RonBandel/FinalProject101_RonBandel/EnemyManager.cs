using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class EnemyManager
    {
        enum EnemyType
        {
            boss,
            normal
        }
        private static EnemyManager instance;
        public static List<Enemy> enemyList = new List<Enemy>();
        private EnemyManager()
        {

        }

        public static EnemyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyManager();
                }
                return instance;
            }
        }

        public void Update()
        {
            List<Enemy> localEnemyList = enemyList.GetRange(0, enemyList.Count);
            int numberOfDeadEnemies = 0;
            foreach (var enemy in localEnemyList)
            {
                if (enemy != null)
                {
                    enemy.Update();
                }
                else
                {
                    numberOfDeadEnemies++;
                }
            }
            if(enemyList.Count == numberOfDeadEnemies++)
            {
                Map.SpawnExit();
            }
        }

        // returns the location of the enemy in the List of enemies based on the cordinates of the enemy given
        public int FindEnemyInListBasedOnCords(int xCords, int yCords)   
        {
            int i = 0;
            foreach (Enemy enemy in enemyList)
            {
                if (enemy != null && (enemy.currentColumn == xCords) && (enemy.currentRow == yCords))
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return 1000;
        }

        public int FindBossInList()
        {
            int i = 0;
            foreach (Enemy enemy in enemyList)
            {
                if (enemy != null && enemy.boss == true)
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }
            return 1000;
        }

        public void KillEnemy(int xCords, int yCords)
        {
            int location = FindEnemyInListBasedOnCords(xCords, yCords);
            GainGoldOnKill(EnemyType.normal);
            enemyList[location] = null;
            SoundManager.Instance.PlayEnemyDeathSound();
        }

        public void DealDamageToEnemy(int xCords, int yCords, int damage)
        {
            int location = FindEnemyInListBasedOnCords(xCords, yCords);
            enemyList[location].hp -= damage;
            enemyList[location].Flicker();
            if (enemyList[location].hp <= 0)    
            {
                enemyList[location] = null;
                GainGoldOnKill(EnemyType.normal);
                Map.mapLayout[yCords, xCords] = GameIcons.emptySpace;
                Console.SetCursorPosition(xCords, yCords);
                Console.Write(GameIcons.emptySpace);
                SoundManager.Instance.PlayEnemyDeathSound();
            }
        }

        public void DealDamageToBoss(int damage)
        {
            int location = FindBossInList();
            enemyList[location].hp -= damage;
            enemyList[location].Flicker();
            if (enemyList[location].hp <= 0)
            {
                enemyList[location].DestroyBossPartsOnMap();
                enemyList[location] = null;
                GainGoldOnKill(EnemyType.boss);
                SoundManager.Instance.PlayBossDeathSound();
            }
        }

        void GainGoldOnKill(EnemyType option)
        {
            Random rand = new Random();
            int goldReceived = 0;
            if (option == EnemyType.boss)
            {
                goldReceived += Map.level;
                HUD.NewHUDEntry("You got " + goldReceived + "$ for slaying the boss");
            }
            else
            {
                goldReceived += rand.Next(1, 4);
            }
            Player.Instance.GainGold(goldReceived);
        }

    }
}