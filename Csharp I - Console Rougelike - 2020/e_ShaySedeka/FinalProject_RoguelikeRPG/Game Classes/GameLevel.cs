using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_RoguelikeRPG.GameDefinitions;

namespace FinalProject_RoguelikeRPG
{
    class GameLevel
    {
 
        #region Class Members

        int levelIndex;
        GameMap levelMap;

        List<Enemy> enemyList;
        List<Shrine> treasureList;
        List<Trap> trapList;

        int playerPosRow, playerPosColumn;

        #endregion

        #region Properties

        public int PlayerPosRow { get => playerPosRow; set => playerPosRow = value; }
        public int PlayerPosColumn { get => playerPosColumn; set => playerPosColumn = value; }
        public int LevelIndex { get => levelIndex; set => levelIndex = value; }
        internal GameMap LevelMap { get => levelMap; set => levelMap = value; }
        internal List<Enemy> EnemyList { get => enemyList; set => enemyList = value; }
        internal List<Shrine> TreasureList { get => treasureList; set => treasureList = value; }
        internal List<Trap> TrapList { get => trapList; set => trapList = value; }

        #endregion

        public GameLevel(int levelIndex)
        {
            this.LevelIndex = levelIndex;
            this.LevelMap = new GameMap();

            PlacePlayerOnCreation();

            this.EnemyList = GenerateEnemyList();
            this.TreasureList = GenerateTreasureList();
            this.trapList = GenerateTrapList();

            PlaceShopOnMap();
        }

        #region Enemy Generation In The Level
        private int GetAmountOfEnemiesToPlace()
        {
            return LevelIndex;
        }

        private List<Enemy> GenerateEnemyList()
        {
            //create empty list of enemies
            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < GetAmountOfEnemiesToPlace(); i++)
            {
                //create a new enemy
                Enemy e = new Enemy(this.LevelIndex);
                //add it to the list
                enemies.Add(e);
                //add it to the map and update it's position
                PlaceEnemyOnMap(e);
            }

            return enemies;

        }

        private void PlaceEnemyOnMap(Enemy enemy)
        {
            //choose a random index within the map
            Random r = new Random();

            //get random origin point
            int originRow = r.Next(0, LevelMap.GetMapHeight());
            int originColumn = r.Next(0, LevelMap.GetMapWidth());

            //check availablity
            bool isAvailable = LevelMap.GetMapLayout()[originRow, originColumn] == GameDefinitions.FreeSymbol;

            // refresh random seed anyways
            System.Threading.Thread.Sleep(20);

            //place if available
            if (isAvailable)
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.EnemySymbol, originRow, originColumn);
                enemy.AssignPositionOnMap(originRow, originColumn);
            }
            //redo if unavailable
            else
            {
                PlaceEnemyOnMap(enemy);
            }
        }

        public bool HurtEnemyOnPosition(int row, int col, int damage, bool isCrit, EventLog events, Player player)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i].PosRow == row && enemyList[i].PosColumn == col)
                {
                    enemyList[i].Health -= damage;

                    if (enemyList[i].Health <= 0)
                    {
                        GameManager.music.PlayDyingSound();

                        events.AddEvent("You slay " + enemyList[i].Name + " by dealing " + damage + " DMG.");
                        if (enemyList[i].GoldReward > 0)
                        {
                            events.AddEvent(enemyList[i].Name + " has dropped " + enemyList[i].GoldReward + " GOLD.");
                            player.Gold += enemyList[i].GoldReward;
                        }
                        enemyList.RemoveAt(i);
                        this.levelMap.PlaceOnMapLayout(FreeSymbol, row, col);
                    }
                    else
                    {
                        if (isCrit)
                        {
                            events.AddEvent("You land a Critical Hit! and strike " + enemyList[i].Name + " for " + damage + " DMG.");
                        }
                        else
                        {
                            events.AddEvent("You hit " + enemyList[i].Name + " for " + damage + " DMG.");
                        }

                    }
                    return true;
                }
            }

            return false;
        }

        public void DoEnemyPatrols()
        {
            foreach (Enemy e in EnemyList)
            {
                e.DoEnemyPatrol(LevelMap);
            }

        }





        #endregion

        #region Treasure Generation In The Level

        private int GetAmountOfTreasuresToPlace()
        {
            return LevelIndex / GameDefinitions.TreasureAmoutModifier;
        }



        private List<Shrine> GenerateTreasureList()
        {
            //create empty list of treasures
            List<Shrine> treasures = new List<Shrine>();

            for(int i = 0; i < GetAmountOfTreasuresToPlace(); i++)
            {
                //create a new treasure
                Shrine t = new Shrine();
                //add it to the list
                treasures.Add(t);
                //add it to the map and update it's position
                PlaceTreasureOnMap(t);
            }

            return treasures;
        }


        private void PlaceTreasureOnMap(Shrine treasure)
        {
            //choose a random index within the map
            Random r = new Random();

            //get random origin point
            int originRow = r.Next(0, LevelMap.GetMapHeight());
            int originColumn = r.Next(0, LevelMap.GetMapWidth());

            //check availablity
            bool isAvailable = LevelMap.GetMapLayout()[originRow, originColumn] == GameDefinitions.FreeSymbol;

            // refresh random seed anyways
            System.Threading.Thread.Sleep(20);

            //place if available
            if (isAvailable)
            {
                char symbolToPlace = '?';
                if (treasure.RewardType == RewardType.MaxHP) symbolToPlace = MaxHPShrineSymbol;
                else if (treasure.RewardType == RewardType.CritChance) symbolToPlace = GameDefinitions.CritShrineSymbol;
                else if (treasure.RewardType == RewardType.CurrentHP) symbolToPlace = GameDefinitions.CurrentHPShrineSymbol;
                else
                {
                    symbolToPlace = GameDefinitions.EvasionShrineSymbol;
                }

                LevelMap.PlaceOnMapLayout(symbolToPlace, originRow, originColumn);
                treasure.AssignPosition(originRow, originColumn);
            }
            //redo if unavailable
            else
            {
                PlaceTreasureOnMap(treasure);
            }
        }

        public bool RemoveTreasureOnPosition(int row, int col)
        {
            for (int i = 0; i < treasureList.Count; i++)
            {
                if(treasureList[i].PosRow == row && treasureList[i].PosColumn == col)
                {
                    treasureList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }


        #endregion

        #region Trap Generation In The Level

        private int GetAmountOfTrapsToPlace()
        {
            return LevelIndex / GameDefinitions.TrapAmountModifier;
        }

        private List<Trap> GenerateTrapList()
        {
            //create empty list of traps
            List<Trap> traps = new List<Trap>();

            for (int i = 0; i < GetAmountOfTrapsToPlace(); i++)
            {
                //create a new trap
                Trap t = new Trap(levelIndex);

                //assign a position to it
                AssignTrapPosition(t);

                //add it to the list
                traps.Add(t);


            }

            return traps;
        }

        private void AssignTrapPosition(Trap trap)
        {
            //choose a random index within the map
            Random r = new Random();

            //get random origin point
            int originRow = r.Next(0, LevelMap.GetMapHeight());
            int originColumn = r.Next(0, LevelMap.GetMapWidth());

            //check availablity
            bool isAvailable = LevelMap.GetMapLayout()[originRow, originColumn] == GameDefinitions.FreeSymbol;

            // refresh random seed anyways
            System.Threading.Thread.Sleep(20);

            //assign if available
            if (isAvailable)
            {
                trap.PosRow = originRow;
                trap.PosCol = originColumn;
            }
            //redo if unavailable
            else
            {
                AssignTrapPosition(trap);
            }
        }

        public void PlaceUncoveredTraps()
        {
            foreach(Trap t in TrapList)
            {
                if (t.WasSteppedOn == false) continue;

                char symbolInPosition = this.LevelMap.GetMapLayout()[t.PosRow, t.PosCol];
                
                if(symbolInPosition == FreeSymbol)
                {
                    this.LevelMap.PlaceOnMapLayout(TrapSymbol, t.PosRow, t.PosCol);
                }
            }
        }

        #endregion

        #region Player Placement On Creation

        public void PlacePlayerOnCreation()
        {
            int entranceRow = LevelMap.EntrancePosRow;
            int entranceColumn = LevelMap.EntrancePosColumn;
            char[,] map = LevelMap.GetMapLayout();


            if(map[entranceRow,entranceColumn-1] == GameDefinitions.FreeSymbol)
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.PlayerSymbol, entranceRow, entranceColumn - 1);
                this.PlayerPosRow = entranceRow;
                this.PlayerPosColumn = entranceColumn - 1;
            }

            else if (map[entranceRow, entranceColumn + 1] == GameDefinitions.FreeSymbol)
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.PlayerSymbol, entranceRow, entranceColumn + 1);
                this.PlayerPosRow = entranceRow;
                this.PlayerPosColumn = entranceColumn + 1;
            }

            else if (map[entranceRow -1, entranceColumn] == GameDefinitions.FreeSymbol)
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.PlayerSymbol, entranceRow -1, entranceColumn);
                this.PlayerPosRow = entranceRow -1;
                this.PlayerPosColumn = entranceColumn;
            }

            else
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.PlayerSymbol, entranceRow + 1, entranceColumn);
                this.PlayerPosRow = entranceRow + 1;
                this.PlayerPosColumn = entranceColumn;
            }
        }

        #endregion

        #region Shop Placement In The Level

        private void PlaceShopOnMap()
        {
            //shops only appear on every other level
            if ((LevelIndex % 2) != 0) return;

            //choose a random index within the map
            Random r = new Random();

            //get random origin point
            int originRow = r.Next(0, LevelMap.GetMapHeight());
            int originColumn = r.Next(0, LevelMap.GetMapWidth());

            //check availablity
            bool isAvailable = LevelMap.GetMapLayout()[originRow, originColumn] == GameDefinitions.FreeSymbol;

            // refresh random seed anyways
            System.Threading.Thread.Sleep(20);

            //place if available
            if (isAvailable)
            {
                LevelMap.PlaceOnMapLayout(GameDefinitions.ShopSymbol, originRow, originColumn);
                
            }
            //redo if unavailable
            else
            {
                PlaceShopOnMap();
            }
        }

        #endregion
    
    }
}

