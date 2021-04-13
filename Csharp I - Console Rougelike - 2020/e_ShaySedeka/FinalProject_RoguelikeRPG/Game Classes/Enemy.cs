using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalProject_RoguelikeRPG.GameDefinitions;

namespace FinalProject_RoguelikeRPG
{
    class Enemy
    {

        #region Class Members

        string name;
        int level;
        int health, damage;
        int posRow, posColumn;
        int goldReward;

        bool isChasing;

        #endregion

        #region Class Properties

        // Properties
        public int Health { get => health; set => health = value; }
        public int Damage { get => damage; set => damage = value; }
        public int PosRow { get => posRow; set => posRow = value; }
        public int PosColumn { get => posColumn; set => posColumn = value; }
        public string Name { get => name; set => name = value; }
        public int GoldReward { get => goldReward; set => goldReward = value; }
        public int Level { get => level; set => level = value; }
        public bool IsChasing { get => isChasing; set => isChasing = value; }

        #endregion

        #region Methods

        public Enemy(int level)
        {
            name = GetRandomEnemyName();
            Level = level;
            Health = level;
            Damage = level / GameDefinitions.EnemyDamageModifier + 1;
            GoldReward = DetermineGoldReward();
            PosRow = -1;
            PosColumn = -1;
            isChasing = false;
        }
        public string GetRandomEnemyName()
        {
            // A array of possibel enemy names
            string[] enemyNames = { "Goblin Slave", "Cannibal", "Reckless Mage", "Imp",
                "Dusty Rat", "Demon", "Shady Bat", "Petty Thief","Evil Spirit", "Baby Werewolf" };

            Random rand = new Random();
            int index = rand.Next(enemyNames.Length);

            return enemyNames[index];
        }

        private int DetermineGoldReward()
        {
            Random r = new Random();
            int reward = r.Next(Level - 1, Level + 2);

            return reward;
        }

        public bool CheckIfPlayerInMeleeRange(GameMap map)
        {
            char[,] layout = map.GetMapLayout();

            if (layout[PosRow - 1, PosColumn] == PlayerSymbol) return true;
            else if(layout[PosRow + 1, PosColumn] == PlayerSymbol) return true;
            else if(layout[PosRow, PosColumn-1] == PlayerSymbol) return true;
            else if (layout[PosRow, PosColumn + 1] == PlayerSymbol) return true;
            else
            {
                return false;
            }

        }

        public bool CheckIfPlayerInChaseRadius(int playerRow, int playerColumn)
        {
            if (Math.Abs(PosRow - playerRow) < GameDefinitions.EnemyChaseRadius) return true;
            else if (Math.Abs(PosColumn - playerColumn) < GameDefinitions.EnemyChaseRadius) return true;
            else
            {
                return false;
            }

        }

        public void MoveTowardsPlayer(int playerRow, int playerColumn, GameMap map)
        {
            int normalizedRowDiff = Math.Sign(playerRow - PosRow) ;
            int normalizedColDiff = Math.Sign(playerColumn - PosColumn);
            

            //coin flip for horizontal/vertical movement checks order
            Random r = new Random();
            int coinFlip = r.Next(0, 2);

            if(coinFlip == 0)
            {
                //move vertically if free
                if (map.GetMapLayout()[PosRow + normalizedRowDiff, PosColumn] == FreeSymbol)
                {
                    //put a blank where the monster was
                    map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                    //move the monster to a new position
                    map.PlaceOnMapLayout(EnemySymbol, PosRow + normalizedRowDiff, PosColumn);

                    //change enemy object parameters
                    PosRow = PosRow + normalizedRowDiff;

                    return;
                }

                //move horizontally if free
                else if (map.GetMapLayout()[PosRow, PosColumn + normalizedColDiff] == FreeSymbol)
                {
                    //put a blank where the monster was
                    map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                    //move the monster to a new position
                    map.PlaceOnMapLayout(EnemySymbol, PosRow, PosColumn + normalizedColDiff);

                    //change enemy object parameters
                    PosColumn = PosColumn + normalizedColDiff;

                    return;
                }

            }

            else
            {
                //move horizontally if free
                if (map.GetMapLayout()[PosRow, PosColumn + normalizedColDiff] == FreeSymbol)
                {
                    //put a blank where the monster was
                    map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                    //move the monster to a new position
                    map.PlaceOnMapLayout(EnemySymbol, PosRow, PosColumn + normalizedColDiff);

                    //change enemy object parameters
                    PosColumn = PosColumn + normalizedColDiff;

                    return;
                }
                //move vertically if free
                else if (map.GetMapLayout()[PosRow + normalizedRowDiff, PosColumn] == FreeSymbol)
                {
                    //put a blank where the monster was
                    map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                    //move the monster to a new position
                    map.PlaceOnMapLayout(EnemySymbol, PosRow + normalizedRowDiff, PosColumn);

                    //change enemy object parameters
                    PosRow = PosRow + normalizedRowDiff;

                    return;
                }
            }

            //if the program hasn't returned by this line, movement is not possible towards the player, and the enemy will attempt to go another direction
            //move horizontally if free
            if (map.GetMapLayout()[PosRow, PosColumn - normalizedColDiff] == FreeSymbol)
            {
                //put a blank where the monster was
                map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                //move the monster to a new position
                map.PlaceOnMapLayout(EnemySymbol, PosRow, PosColumn - normalizedColDiff);

                //change enemy object parameters
                PosColumn = PosColumn - normalizedColDiff;

                return;
            }
            //move vertically if free
            else if (map.GetMapLayout()[PosRow - normalizedRowDiff, PosColumn] == FreeSymbol)
            {
                //put a blank where the monster was
                map.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                //move the monster to a new position
                map.PlaceOnMapLayout(EnemySymbol, PosRow - normalizedRowDiff, PosColumn);

                //change enemy object parameters
                PosRow = PosRow - normalizedRowDiff;

                return;
            }
        }

        public GameDirection GetRandomDirection()
        {
            Random r = new Random();
            int directionToReturn = r.Next(0, 4);
            return (GameDirection)directionToReturn;
        }

        public void DoEnemyPatrol(GameMap levelMap)
        {
            //choose random direction
            GameDirection direction = GetRandomDirection();

            //check if it's available
            int newPosRow = PosRow;
            int newPosCol = PosColumn;

            switch (direction)
            {
                case GameDirection.Up:
                    newPosRow -= 1;
                    break;
                case GameDirection.Down:
                    newPosRow += 1;
                    break;
                case GameDirection.Left:
                    newPosCol -= 1;
                    break;
                case GameDirection.Right:
                    newPosCol += 1;
                    break;
            }

            //move there if free
            if (levelMap.GetMapLayout()[newPosRow, newPosCol] == FreeSymbol)
            {
                //put a blank where the monster was
                levelMap.PlaceOnMapLayout(FreeSymbol, PosRow, PosColumn);

                //move the monster to a new position
                levelMap.PlaceOnMapLayout(EnemySymbol, newPosRow, newPosCol);

                //change enemy object parameters
                PosRow = newPosRow;
                PosColumn = newPosCol;
            }

            //change the random seed
            System.Threading.Thread.Sleep(15);
        }

        public void AssignPositionOnMap(int row, int column)
        {
            this.PosRow = row;
            this.PosColumn = column;
        }

        #endregion
    }
}
