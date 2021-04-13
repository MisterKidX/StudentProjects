using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject101_RonBandel
{
    class Enemy
    {
        public int hp;
        public int currentColumn;
        public int currentRow;
        public float attackCD;
        public float timeSinceLastAttack;
        public float mineCD;
        public float timeSinceLastMine;
        public float moveCD;
        public float timeSinceLastMove;
        public float summonCD;
        public float timeSinceLastSummon;
        public bool isThereSpace = true;
        public bool boss;
        string thisEnemyIcon;

        
        private Random rand;

        public Enemy(int initialRowCordinates, int initialColumnCordinates, int seed, bool isBoss)
        {
            rand = new Random(seed);
            boss = isBoss;
            currentRow = initialRowCordinates;
            currentColumn = initialColumnCordinates;
            attackCD = 200;
            timeSinceLastAttack = 0;
            mineCD = 75;
            timeSinceLastMine = 0;
            moveCD = 50;
            timeSinceLastMove = 0;
            summonCD = 150;
            timeSinceLastSummon = 0;
            SpawnEnemyInCordinates( currentRow, currentColumn);            
        }

        public void SpawnEnemyInCordinates(int spawnRow, int spawnColumn)
        {
            if (!boss)
            {
                hp = 2 + Map.level / 5;
                thisEnemyIcon = GameIcons.enemy;
                Map.mapLayout[spawnRow, spawnColumn] = thisEnemyIcon;
            }
            else
            {
                hp = 5 * Map.level;
                thisEnemyIcon = GameIcons.heart;
                GenerateBossPartsOnMap();
            }

            EnemyManager.enemyList.Add(this);
        }

        public void Update()
        {
            EnemyBehavior();
        }

        // ---- Enemy Behavior -----
        void EnemyBehavior()
        {
            if (!boss)
            {
                MoveTowardsAndAttackPlayer();
                if(timeSinceLastAttack < attackCD)
                {
                    timeSinceLastAttack++;
                }
                SpawnMine();
            }   
            else
            {
                SpawnMinion();
            }
        }

        void MoveTowardsAndAttackPlayer()
        {
            int horizontalDirection = Player.Instance.currentColumn - currentColumn;
            int verticalDirection = Player.Instance.currentRow - currentRow;
            if (verticalDirection < 0)  // Enemy is on lower Row than the player
            {
                if (Map.mapLayout[currentRow - 1, currentColumn] == GameIcons.emptySpace || 
                    Map.mapLayout[currentRow - 1, currentColumn] == GameIcons.mine)
                {
                    MoveTo(currentRow - 1, currentColumn);
                }
                else if (Map.mapLayout[currentRow - 1, currentColumn] == GameIcons.player)
                {
                    AttackPlayer();
                }
                    
            }
            else if (verticalDirection > 0) // Enemy is on higher Row than the player
            {
                if (Map.mapLayout[currentRow + 1, currentColumn] == GameIcons.emptySpace ||
                    Map.mapLayout[currentRow + 1, currentColumn] == GameIcons.mine)
                {
                    MoveTo(currentRow + 1, currentColumn);
                }
                else if (Map.mapLayout[currentRow + 1, currentColumn] == GameIcons.player)
                {
                    AttackPlayer();
                }
            }
            if (horizontalDirection < 0)    // Enemy is to the right of the player
            {
                if (Map.mapLayout[currentRow, currentColumn - 1] == GameIcons.emptySpace ||
                    Map.mapLayout[currentRow, currentColumn - 1] == GameIcons.mine)
                {
                    MoveTo(currentRow, currentColumn - 1);
                }
                else if (Map.mapLayout[currentRow, currentColumn - 1] == GameIcons.player)
                {
                    AttackPlayer();
                }
            }
            else if (horizontalDirection > 0)   // Enemy is to the left of the player
            {
                if (Map.mapLayout[currentRow, currentColumn + 1] == GameIcons.emptySpace ||
                    Map.mapLayout[currentRow, currentColumn + 1] == GameIcons.mine)
                {
                    MoveTo(currentRow, currentColumn + 1);
                }
                else if (Map.mapLayout[currentRow, currentColumn + 1] == GameIcons.player)
                {
                    AttackPlayer();
                }
            }
        }

        void MoveTo(int targetRow, int targetColumn)
        {
            if (timeSinceLastMove >= moveCD)
            {
                timeSinceLastMove = 0;
                // delete old enemy avatar from console
                Console.SetCursorPosition(currentColumn, currentRow);
                Console.Write(GameIcons.emptySpace);
                // delete old enemy avatar from the map[]
                Map.mapLayout[currentRow, currentColumn] = GameIcons.emptySpace;
                currentColumn = targetColumn;
                currentRow = targetRow;
                // place new ennmy avatar on the map[]
                Map.mapLayout[currentRow, currentColumn] = GameIcons.enemy;
                // place new enemy avatar on console
                Console.SetCursorPosition(currentColumn, currentRow);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(GameIcons.enemy);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                timeSinceLastMove++;
            }
        }

        void AttackPlayer()
        {
            if (timeSinceLastAttack == attackCD)
            {
                timeSinceLastAttack = 0;
                int damageAmount = hp;
                if (damageAmount > 9)   // cap damage at 9
                {
                    damageAmount = 9;
                }
                Player.Instance.TakeDamage(damageAmount);
                HUD.NewHUDEntry("The enemy attacked you, dealing " + damageAmount + " dmg!");
            }
        }

        void SpawnMine()
        {
            int infiniteWatchDog = 0;

            int mineCordsY = rand.Next(currentRow - 1, currentRow + 2);
            int mineCordsX = rand.Next(currentColumn - 1, currentColumn + 2);
            if (timeSinceLastMine >= mineCD)
            {
                while (Map.mapLayout[mineCordsY, mineCordsX] != GameIcons.emptySpace)
                {
                    mineCordsY = rand.Next(currentRow - 1, currentRow + 2);
                    mineCordsX = rand.Next(currentColumn - 1, currentColumn + 2);
                    infiniteWatchDog++;
                    if (infiniteWatchDog >= 100)
                    {
                        return;
                    }
                }
                timeSinceLastMine = 0;
                Map.mapLayout[mineCordsY, mineCordsX] = GameIcons.mine;
                Console.SetCursorPosition(mineCordsX, mineCordsY);
                Console.Write(GameIcons.mine);
            }
            else
            {
                timeSinceLastMine++;
            }
        }

        void SpawnMinion()
        {
            int infiniteWatchDog = 0;

            int summonCordsY = rand.Next(currentRow - 10, currentRow + 11);
            int summonCordsX = rand.Next(currentColumn - 10, currentColumn + 11);
            if (timeSinceLastSummon >= summonCD)
            {
                while (Map.mapLayout[summonCordsY, summonCordsX] != GameIcons.emptySpace)
                {
                    summonCordsY = rand.Next(currentRow - 10, currentRow + 11);
                    summonCordsX = rand.Next(currentColumn - 10, currentColumn + 11);
                    infiniteWatchDog++;
                    if (infiniteWatchDog >= 1000)
                    {
                        return;
                    }
                }
                timeSinceLastSummon = 0;
                Enemy minion = new Enemy(summonCordsY, summonCordsX, summonCordsY * 100 + summonCordsX, false);
                HUD.NewHUDEntry("The boss summoned a minion!");
            }
            timeSinceLastSummon++;

        }

        public void Flicker()
        {
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(thisEnemyIcon);
            Thread.Sleep(50);
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(thisEnemyIcon);
        }

        // ----- Boss -----
        void GenerateBossPartsOnMap()
        {
            //  "  ▲___▲  \n"
            Map.mapLayout[currentRow - 3, currentColumn - 2] = GameIcons.bossPartEar;
            Map.mapLayout[currentRow - 3, currentColumn - 1] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow - 3, currentColumn] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow - 3, currentColumn + 1] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow - 3, currentColumn + 2] = GameIcons.bossPartEar;

            //  " /° O °\ \n"
            Map.mapLayout[currentRow - 2, currentColumn -3] = GameIcons.bossPartWaist;
            Map.mapLayout[currentRow - 2, currentColumn - 2] = GameIcons.bossPartEye;
            Map.mapLayout[currentRow - 2, currentColumn] = GameIcons.bossPartMouth;
            Map.mapLayout[currentRow - 2, currentColumn + 2] = GameIcons.bossPartEye;
            Map.mapLayout[currentRow - 2, currentColumn + 3] = GameIcons.bossPartFaceSide;

            //  " \     / \n"
            Map.mapLayout[currentRow - 1 , currentColumn - 3] = GameIcons.bossPartFaceSide;
            Map.mapLayout[currentRow - 1 , currentColumn + 3] = GameIcons.bossPartWaist;

            //  "╚╣  ♥  ╠╝\n"
            Map.mapLayout[currentRow, currentColumn - 4] = GameIcons.bossPartLimb2;
            Map.mapLayout[currentRow, currentColumn - 3] = GameIcons.bossPartLeftShoulder;
            Map.mapLayout[currentRow, currentColumn] = GameIcons.heart;
            Map.mapLayout[currentRow, currentColumn + 3] = GameIcons.bossPartRightShoulder;
            Map.mapLayout[currentRow, currentColumn + 4] = GameIcons.bossPartLimb1;

            //  "  \___/  \n"                 
            Map.mapLayout[currentRow + 1, currentColumn - 2] = GameIcons.bossPartFaceSide;
            Map.mapLayout[currentRow + 1, currentColumn - 1] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow + 1, currentColumn] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow + 1, currentColumn + 1] = GameIcons.bossPartFlat;
            Map.mapLayout[currentRow + 1, currentColumn + 2] = GameIcons.bossPartWaist;

            //  "   ╝ ╚   "
            Map.mapLayout[currentRow + 2, currentColumn - 1] = GameIcons.bossPartLimb1;
            Map.mapLayout[currentRow + 2, currentColumn + 1] = GameIcons.bossPartLimb2;
        }

        public void DestroyBossPartsOnMap()
        {
            //  "  ▲___▲  \n"
            Map.mapLayout[currentRow - 3, currentColumn - 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 2, currentRow - 3);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 3, currentColumn - 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 1, currentRow - 3);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 3, currentColumn] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn, currentRow - 3);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 3, currentColumn + 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 1, currentRow - 3);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 3, currentColumn + 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 2, currentRow - 3);
            Console.Write(GameIcons.emptySpace);

            //  " /° O °\ \n"
            Map.mapLayout[currentRow - 2, currentColumn - 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn -3, currentRow - 2);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 2, currentColumn - 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 2, currentRow - 2);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 2, currentColumn] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn, currentRow - 2);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 2, currentColumn + 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 2, currentRow - 2);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 2, currentColumn + 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 3, currentRow - 2);
            Console.Write(GameIcons.emptySpace);

            //  " \     / \n"
            Map.mapLayout[currentRow - 1, currentColumn - 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 3, currentRow - 1);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow - 1, currentColumn + 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 3, currentRow - 1);
            Console.Write(GameIcons.emptySpace);

            //  "╚╣  ♥  ╠╝\n"
            Map.mapLayout[currentRow, currentColumn - 4] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 4, currentRow);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow, currentColumn - 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 3, currentRow);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow, currentColumn] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow, currentColumn + 3] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 3, currentRow);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow, currentColumn + 4] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 4, currentRow);
            Console.Write(GameIcons.emptySpace);

            //  "  \___/  \n"                 
            Map.mapLayout[currentRow + 1, currentColumn - 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 2, currentRow + 1);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow + 1, currentColumn - 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 1, currentRow + 1);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow + 1, currentColumn] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn, currentRow + 1);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow + 1, currentColumn + 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 1, currentRow + 1);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow + 1, currentColumn + 2] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 2, currentRow + 1);
            Console.Write(GameIcons.emptySpace);

            //  "   ╝ ╚   "
            Map.mapLayout[currentRow + 2, currentColumn - 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn - 1, currentRow + 2);
            Console.Write(GameIcons.emptySpace);
            Map.mapLayout[currentRow + 2, currentColumn + 1] = GameIcons.emptySpace;
            Console.SetCursorPosition(currentColumn + 1, currentRow + 2);
            Console.Write(GameIcons.emptySpace);

            // Spawn 3 Treasure Chests
            for (int i = 0; i < 3; i++)
            {
                Map.mapLayout[currentRow, currentColumn - 1 + i] = GameIcons.treasureChest;
                Console.SetCursorPosition(currentColumn - 1 + i, currentRow);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(GameIcons.treasureChest);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}