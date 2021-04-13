using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class EnemyManager
    {
        public static int smallEnemyDeathCounter = 0;
        public static int bigEnemyDeathCounter = 0;
        public static List<SmallEnemy> smallEnemyList = new List<SmallEnemy>(100);
        public static List<BigEnemy> bigEnemyList = new List<BigEnemy>(100);
        public static List<Trap> trapList = new List<Trap>(100);
        static bool _canMove = true;
        #region Rewards
        public static void SmallEnemyRewards()
        {
            Random random = new Random();
            int goldAmount = 0;
            int leatherAmount = 0;
            if (smallEnemyDeathCounter >= 100)
            {
                goldAmount = random.Next(0, 6);
                leatherAmount = random.Next(2, 12);
            }
            else
            {
                goldAmount = random.Next(0, 3);
                leatherAmount = random.Next(1, 6);
            }
            Hud.InfoText2 = "Small Enemy Killed, You Recive "+ goldAmount +" Gold And " + leatherAmount+ " Leather";
            PlayerStats.gold += goldAmount;
            PlayerStats.leather += leatherAmount;
        }
        public static void BigEnemyRewards()
        {
            Random random = new Random();
            int goldAmount = 0;
            int leatherAmount = 0;
            if(bigEnemyDeathCounter >= 100)
            {
                goldAmount = random.Next(0, 6);
                leatherAmount = random.Next(5, 20);
            }
            else
            {
                goldAmount = random.Next(0, 3);
                leatherAmount = random.Next(2, 10);
            }
            Hud.InfoText2 = "Big Enemy Killed, You Recive " + goldAmount + " Gold And " + leatherAmount + " Leather";
            PlayerStats.gold += goldAmount;
            PlayerStats.leather += leatherAmount;
        }
        #endregion
        #region Movement
        #region SmallEnemyMovement
        public static void SmallEnemyMovement()
        {
            for (int i = 0; i < smallEnemyList.Count(); i++)
            {
                if (smallEnemyList[i] != null)
                {
                    int moveX;
                    int moveY;
                    Position pPos = GameManager.player.position;
                    Position smPos = smallEnemyList[i].position;
                    moveX = PositionFromPlayerX(pPos, smPos);
                    moveY = PositionFromPlayerY(pPos, smPos);
                    smallEnemyList[i].position = SmallEnemyMoveDirection(moveX, moveY, smPos);
                    if(Position.PositionCheck(GameManager.player.position, smallEnemyList[i].position))
                    {
                        StepOnSmallEnemy();
                        smallEnemyList.RemoveAt(i);
                        GameManager.map.mapArray[pPos.y, pPos.x].type = Type.Player;
                    }
                }
            }
        }
        static Position SmallEnemyMoveDirection(int moveX, int moveY, Position smPos)
        {
            bool canMoveX = false;
            bool canMoveY = false;
            if (GameManager.map.mapArray[smPos.y, smPos.x + moveX].type == Type.Empty || GameManager.map.mapArray[smPos.y, smPos.x + moveX].type == Type.Player
                || GameManager.map.mapArray[smPos.y, smPos.x + moveX].type == Type.Vendor|| GameManager.map.mapArray[smPos.y, smPos.x + moveX].type == Type.Entrance)
            {
                canMoveX = true;
            }
            if(GameManager.map.mapArray[smPos.y + moveY,smPos.x].type == Type.Empty || GameManager.map.mapArray[smPos.y + moveY, smPos.x].type == Type.Player
                || GameManager.map.mapArray[smPos.y + moveY, smPos.x].type == Type.Vendor || GameManager.map.mapArray[smPos.y + moveY, smPos.x].type == Type.Entrance)
            {
                canMoveY = true;
            }
            if (canMoveX == true && canMoveY == true)
            {
                Random random = new Random();
                int direction = random.Next(0, 2);
                if (direction == 0)
                {
                    GameManager.map.mapArray[smPos.y, smPos.x].type = Type.Empty;
                    GameManager.map.mapArray[smPos.y,smPos.x + moveX].type = Type.SmallEnemy;
                    return new Position(smPos.x + moveX, smPos.y);
                }
                else
                {
                    GameManager.map.mapArray[smPos.y, smPos.x].type = Type.Empty;
                    GameManager.map.mapArray[smPos.y + moveY, smPos.x].type = Type.SmallEnemy;
                    return new Position(smPos.x, smPos.y + moveY);
                }
            }
            else if(canMoveX == true)
            {
                GameManager.map.mapArray[smPos.y, smPos.x].type = Type.Empty;
                GameManager.map.mapArray[smPos.y, smPos.x + moveX].type = Type.SmallEnemy;
                return new Position(smPos.x + moveX, smPos.y);
            }
            else if(canMoveY == true)
            {
                GameManager.map.mapArray[smPos.y, smPos.x].type = Type.Empty;
                GameManager.map.mapArray[smPos.y + moveY, smPos.x].type = Type.SmallEnemy;
                return new Position(smPos.x, smPos.y + moveY);
            }
            else if(_canMove == true)
            {
                //if both are blocked
                //check for other sides
                _canMove = false;
                return SmallEnemyMoveDirection(-moveX,-moveY, smPos);
                //both are walls

            }
            else
            {
                _canMove = true;
                return smPos;
            }
            //check for both options

        }
        static int PositionFromPlayerX(Position playerPos, Position enemyPos)
        {
            int moveX;
            if (playerPos.x > enemyPos.x)
            {
                //can go down
                moveX = 1;
            }
            else if (playerPos.x == enemyPos.x)
            {
                //check where to move sideways
                moveX = 0;
            }
            else
            {
                moveX = -1;
                //can go up
            }
            return moveX;
        }
        static int PositionFromPlayerY(Position playerPos, Position enemyPos)
        {
            int moveY;
            if (playerPos.y > enemyPos.y)
            {
                //can go Right
                moveY = 1;
            }
            else if (playerPos.y == enemyPos.y)
            {
                //check where to move sideways
                moveY = 0;
            }
            else
            {
                moveY = -1;
                //can go left
            }
            return moveY;
        }
        #endregion
        #region BigEnemyMovement
        public static void BigEnemyMovement()
        {
            for (int i = 0; i < bigEnemyList.Count(); i++)// make every enemy to move
            {
                if (bigEnemyList[i] != null && bigEnemyList[i].isMoving == false)//make sure not empty and not moving
                {
                    bigEnemyList[i].isMoving = true;

                    int moveX = bigEnemyList[i].ComparePositionToPlayerX();
                    int moveY = bigEnemyList[i].ComparePositionToPlayerY();
                    bigEnemyList[i].BigEnemyFirstStep(moveX, moveY);
                    //make moveDirection Y
                    //make moveDirection X
                    //Use values to move big minion body
                    if (bigEnemyList[i] != null && bigEnemyList[i].CheckPositions(GameManager.player.position))
                    {
                        bigEnemyList[i].CollideWithPlayer(GameManager.player.position);
                    }
                }
                else if(bigEnemyList[i] != null && bigEnemyList[i].isMoving == true)//make second step
                {
                    bigEnemyList[i].isMoving = false;
                    bigEnemyList[i].BigEnemySecondStep();
                    if (bigEnemyList[i] != null && bigEnemyList[i].CheckPositions(GameManager.player.position))
                    {
                        bigEnemyList[i].CollideWithPlayer(GameManager.player.position);
                    }
                }
            }
        }
        #endregion
        #endregion
        #region BigEnemyChecks
        public static bool SpawnBigEnemyCheck(Position startPosition)
        {
            //if all 4 blocks are empty return true, else return false
            if (GameManager.map.CheckMyBlockEmpty(startPosition) && GameManager.map.CheckRightBlockEmpty(startPosition) && GameManager.map.CheckLowerBlockEmpty(startPosition)
                && GameManager.map.CheckLowerRightBlockEmpty(startPosition))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool TypeOfBigEnemy(int posY, int posX)
        {
            if (GameManager.map.mapArray[posY,posX].type == Type.BigEnemyUpperLeft || GameManager.map.mapArray[posY, posX].type == Type.BigEnemyUpperRight
                || GameManager.map.mapArray[posY, posX].type == Type.BigEnemyLowerLeft || GameManager.map.mapArray[posY, posX].type == Type.BigEnemyLowerRight)
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        public static bool CheckBigEnemyType(Position position, BigEnemy bigEnemy)
        {
            return bigEnemy.CheckPositionOfBodyParts(position);
        }
        public static Type GetBigEnemyType(Position position, BigEnemy bigEnemy)
        {
            return bigEnemy.GetBodyType(position);
        }
        #endregion
        #region Step On Enemy
        public static void StepOnSmallEnemy()
        {
            SoundManager.GetHitSound();
            Random random = new Random();
            if (PlayerStats.armor >= random.Next(0,100))
            {
                Hud.InfoText2 = "Damage Denied By Armor";
            }
            else
            {
                PlayerStats.health--;
                Hud.InfoText2 = "You Got Hit for 1 DMG";
            }
        }
        public static void StepOnBigEnemy()
        {
            SoundManager.GetHitSound();
            PlayerStats.health-=2;
            Hud.InfoText2 = "You Got Hit for 2 DMG";
        }
        public static void StepOnTrap()
        {
            Random random = new Random();
            int trapChance = random.Next(0, 100);
            if (trapChance >= 80)
            {
                SoundManager.PerchaseSound();
                Hud.InfoText2 = "Someone left a donut on the ground, Do you eat it? Y/N";
                ScreenManager.PrintScreen();
                bool wantDount = true;
                while (wantDount)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            if (PlayerStats.health == PlayerStats.maxHealth)
                            {
                                PlayerStats.maxHealth++;
                                Hud.InfoText = "Maple srrounds the Dount and it looks well preserved";
                                Hud.InfoText2 = "You eat it and Gain 1 Max HP";
                                wantDount = false;
                            }
                            else
                            {
                                PlayerStats.health++;
                                Hud.InfoText = "There is some chocolate sprinkles on it";
                                Hud.InfoText2 = "You eat it and restore 1 HP";
                                wantDount = false;

                            }
                            break;
                        case ConsoleKey.N:
                            Hud.InfoText2 = "You Smash the donut so nobody can eat it";
                            wantDount = false;
                            break;
                        default:
                            Hud.InfoText2 = "Wrong Input, Y for EAT DONUT, N for DESTROY DONUT";
                            break;
                    }
                }
            }
            else if (trapChance >= 60)
            {
                SoundManager.ChestSound();
                if (PlayerStats.gold < PlayerStats.leather)
                {
                    int gold = random.Next(1, 10);
                    PlayerStats.gold += gold;
                    Hud.InfoText2 = "You found " + gold + " Gold on the floor";
                }
                else
                {
                    int leather = random.Next(1, 10);
                    Hud.InfoText2 = "You found " + leather + " Leather on the floor";
                    PlayerStats.leather += leather;
                }
                Hud.InfoText = "You steped on a trap Press Y to Continue";
                ScreenManager.PrintScreen();
                bool trapActive = true;
                while (trapActive)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            trapActive = false;
                            break;
                        default:

                            break;
                    }
                }
            }
            else if (trapChance >= 40)
            {
                SoundManager.TrapSound();
                Hud.InfoText2 = "A trap triggers and a arrow comes, you dodge on the last second";
                Hud.InfoText = "You steped on a trap Press Y to Continue";
                ScreenManager.PrintScreen();
                bool trapActive = true;
                while (trapActive)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            trapActive = false;
                            break;
                        default:

                            break;
                    }
                }
            }
            else
            {
                SoundManager.GetHitSound();
                PlayerStats.health--;
                Hud.InfoText2 = "A trap triggers and a arrow comes, you were a bit late to respond and got grazed by the arrow for 1 DMG";
                Hud.InfoText = "You steped on a trap Press Y to Continue";
                ScreenManager.PrintScreen();
                bool trapActive = true;
                while (trapActive)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            trapActive = false;
                            break;
                        default:

                            break;
                    }
                }
            }
        }
        #endregion
    }
}
