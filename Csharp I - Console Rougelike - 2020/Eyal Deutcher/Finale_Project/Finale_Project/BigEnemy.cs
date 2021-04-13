using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class BigEnemy
    {
        public bool isMoving;
        bool _canMove = true;
        string _moveDirection;
        int _moveSide;
        public List<BigEnemyBodyPart> bigEnemyPartList;
        public BigEnemyBodyPart upperLeft;
        public BigEnemyBodyPart upperRight;
        public BigEnemyBodyPart lowerLeft;
        public BigEnemyBodyPart lowerRight;

        public BigEnemy(Position position)
        {
            bigEnemyPartList = new List<BigEnemyBodyPart>(4);

            upperLeft = new BigEnemyBodyPart();
            upperLeft.position.x = position.x;
            upperLeft.position.y = position.y;
            bigEnemyPartList.Add(upperLeft);

            upperRight = new BigEnemyBodyPart();
            upperRight.position.x = position.x + 1;
            upperRight.position.y = position.y;
            bigEnemyPartList.Add(upperRight);

            lowerLeft = new BigEnemyBodyPart();
            lowerLeft.position.x = position.x;
            lowerLeft.position.y = position.y + 1;
            bigEnemyPartList.Add(lowerLeft);

            lowerRight = new BigEnemyBodyPart();
            lowerRight.position.x = position.x + 1;
            lowerRight.position.y = position.y + 1;
            bigEnemyPartList.Add(lowerRight);
        }
        public void ReciveDamage(Position attackPos, int damageAmount)
        {
            for (int i = 0; i < bigEnemyPartList.Count; i++)
            {
                if(bigEnemyPartList != null && Position.PositionCheck(bigEnemyPartList[i].position, attackPos))
                {
                    bigEnemyPartList[i].reciveDamage(damageAmount, this);
                }
            }
            if(bigEnemyPartList.Count == 0)
            {
                //recieve reward
                EnemyManager.BigEnemyRewards();
                EnemyManager.bigEnemyDeathCounter++;
                EnemyManager.bigEnemyList.Remove(this);
            }
        }
        public bool CheckPositions(Position otherPos)
        {
            bool stepOnBigEnemyPart = false;
            for (int i = 0; i < bigEnemyPartList.Count; i++)
            {
                if (bigEnemyPartList[i] != null && Position.PositionCheck(otherPos, bigEnemyPartList[i].position))
                {
                    stepOnBigEnemyPart = true;
                }
            }
            return stepOnBigEnemyPart;
        }
        public void CollideWithPlayer(Position playerPos)
        {
            for (int i = 0; i < bigEnemyPartList.Count; i++)
            {
                if (bigEnemyPartList[i] != null && Position.PositionCheck(playerPos, bigEnemyPartList[i].position))
                {
                    EnemyManager.StepOnBigEnemy();
                    bigEnemyPartList[i].DestroyBodyPart(this);
                    GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
                }
            }
        }
        public int ComparePositionToPlayerX()
        {
            Position playerPos = GameManager.player.position;
            int moveX = 0;
            if (playerPos.x > upperRight.position.x && playerPos.x > lowerRight.position.x) //check if from the right of the enemy

            {
                moveX = 1;
            }
            else if(playerPos.x < upperLeft.position.x && playerPos.x < lowerLeft.position.x) //check if from the left of the enemy
            {
                moveX = -1;
            }
            else //should be on the same x of the big enemy
            {
                moveX = 0;
            }
            return moveX;
        }
        public int ComparePositionToPlayerY()
        {
            Position playerPos = GameManager.player.position;
            int moveY = 0;
            if (playerPos.y > lowerLeft.position.y && playerPos.y > lowerRight.position.y) //check if below of the enemy
            {
                moveY = 1;
            }
            else if (playerPos.y < upperLeft.position.y && playerPos.y < upperRight.position.y) //check if above of the enemy
            {
                moveY = -1;
            }
            else //should be on the same y of the big enemy
            {
                moveY = 0;
            }
            return moveY;
        }
        public void BigEnemyFirstStep(int moveX, int moveY)
        {
            Random random = new Random();
            _moveSide = random.Next(0, 2);
            _canMove = true;
            //need to understand combination of X and Y to understand Where to move
            CheckDirection(moveX,moveY);
            if(_moveDirection == "Stay")
            {
                //dont move
                isMoving = false;
            }
            else if(_moveDirection == "Up")
            {
                if(_moveSide == 1)
                {
                    MoveRightSideUp();
                    if (GameManager.map.mapArray[upperRight.position.y, upperRight.position.x - 1].type != Type.Player)
                    {
                        GameManager.map.mapArray[upperRight.position.y, upperRight.position.x - 1].type = Type.BigEnemyNextStep;
                    }
                }
                else
                {
                    MoveLeftSideUp();
                    if (GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x + 1].type != Type.Player)
                    {
                        GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x + 1].type = Type.BigEnemyNextStep;
                    }

                }
                //moveUp
            }
            else if(_moveDirection == "Down")
            {
                if(_moveSide == 1)
                {
                    MoveRightSideDown();
                    if (GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x - 1].type != Type.Player)
                    {
                        GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x - 1].type = Type.BigEnemyNextStep;
                    }
                }
                else
                {
                    MoveLeftSideDown();
                    if (GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x + 1].type != Type.Player)
                    {
                        GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x + 1].type = Type.BigEnemyNextStep;
                    }
                }
                //moveDown
            }
            else if(_moveDirection == "Right")
            {
                if(_moveSide == 1)
                {
                    MoveUpSideRight();
                    if (GameManager.map.mapArray[upperRight.position.y + 1, upperRight.position.x].type != Type.Player)
                    {
                        GameManager.map.mapArray[upperRight.position.y + 1, upperRight.position.x].type = Type.BigEnemyNextStep;
                    }
                }
                else
                {
                    MoveDownSideRight();
                    if (GameManager.map.mapArray[lowerRight.position.y - 1, lowerRight.position.x].type != Type.Player)
                    {
                        GameManager.map.mapArray[lowerRight.position.y - 1, lowerRight.position.x].type = Type.BigEnemyNextStep;
                    }
                }
                //moveRight
            }
            else if(_moveDirection == "Left")
            {
                if(_moveSide == 1)
                {
                    MoveUpSideLeft();
                    if(GameManager.map.mapArray[upperLeft.position.y + 1, upperLeft.position.x].type != Type.Player)
                    {
                        GameManager.map.mapArray[upperLeft.position.y + 1, upperLeft.position.x].type = Type.BigEnemyNextStep;
                    }
                }
                else
                {
                    MoveDownSideLeft();
                    if(GameManager.map.mapArray[lowerLeft.position.y - 1, lowerLeft.position.x].type != Type.Player)
                    {
                        GameManager.map.mapArray[lowerLeft.position.y - 1, lowerLeft.position.x].type = Type.BigEnemyNextStep;
                    }
                }
                //moveLeft
            }
            PrintTypes();
        }
        public void BigEnemySecondStep()
        {
            if (_moveDirection == "Up")
            {
                if (_moveSide == 1)
                {
                    MoveLeftSideUp();
                }
                else
                {
                    MoveRightSideUp();
                }
                //moveUp
            }
            else if (_moveDirection == "Down")
            {
                if (_moveSide == 1)
                {
                    MoveLeftSideDown();
                }
                else
                {
                    MoveRightSideDown();
                }
                //moveDown
            }
            else if (_moveDirection == "Right")
            {
                if (_moveSide == 1)
                {
                    MoveDownSideRight();
                }
                else
                {
                    MoveUpSideRight();
                }
                //moveRight
            }
            else if (_moveDirection == "Left")
            {
                if (_moveSide == 1)
                {
                    MoveDownSideLeft();
                }
                else
                {
                    MoveUpSideLeft();
                }
                //moveLeft
            }
            PrintTypes();
        }
        #region MoveBigEnemy
        void PrintTypes()
        {
            if (bigEnemyPartList.Contains(upperRight))
            {
                GameManager.map.mapArray[upperRight.position.y, upperRight.position.x].type = Type.BigEnemyUpperRight;
            }
            if (bigEnemyPartList.Contains(lowerRight))
            {
                GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x].type = Type.BigEnemyLowerRight;
            }
            if (bigEnemyPartList.Contains(upperLeft))
            {
                GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x].type = Type.BigEnemyUpperLeft;
            }
            if (bigEnemyPartList.Contains(lowerLeft))
            {
                GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x].type = Type.BigEnemyLowerLeft;
            }
        }
        void MoveRightSideUp()
        {
            GameManager.map.mapArray[upperRight.position.y, upperRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x].type = Type.Empty;
            upperRight.position.y -= 1;
            lowerRight.position.y -= 1;
            if(GameManager.map.mapArray[GameManager.player.position.y,GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveRightSideDown()
        {
            GameManager.map.mapArray[upperRight.position.y, upperRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x].type = Type.Empty;
            upperRight.position.y += 1;
            lowerRight.position.y += 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveLeftSideUp()
        {
            GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x].type = Type.Empty;
            upperLeft.position.y -= 1;
            lowerLeft.position.y -= 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveLeftSideDown()
        {
            GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x].type = Type.Empty;
            upperLeft.position.y += 1;
            lowerLeft.position.y += 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveUpSideRight()
        {
            GameManager.map.mapArray[upperRight.position.y, upperRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x].type = Type.Empty;
            upperRight.position.x += 1;
            upperLeft.position.x += 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }

        }
        void MoveUpSideLeft()
        {
            GameManager.map.mapArray[upperRight.position.y, upperRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[upperLeft.position.y, upperLeft.position.x].type = Type.Empty;
            upperRight.position.x -= 1;
            upperLeft.position.x -= 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveDownSideRight()
        {
            GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x].type = Type.Empty;
            lowerRight.position.x += 1;
            lowerLeft.position.x += 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        void MoveDownSideLeft()
        {
            GameManager.map.mapArray[lowerRight.position.y, lowerRight.position.x].type = Type.Empty;
            GameManager.map.mapArray[lowerLeft.position.y, lowerLeft.position.x].type = Type.Empty;
            lowerRight.position.x -= 1;
            lowerLeft.position.x -= 1;
            if (GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type != Type.Player)
            {
                GameManager.map.mapArray[GameManager.player.position.y, GameManager.player.position.x].type = Type.Player;
            }
        }
        #endregion
        #region PositionChecks
        void CheckDirection(int moveX, int moveY)
        {
            bool canMoveUp = CheckMoveUp();
            bool canMoveDown = CheckMoveDown();
            bool canMoveLeft = CheckMoveLeft();
            bool canMoveRight = CheckMoveRight();
            if (moveX == -1 && moveY == -1)//move left or up
            {
                if (canMoveLeft && canMoveUp)
                {
                    Random random = new Random();
                    int direction = random.Next(0, 2);
                    if (direction == 1)
                    {
                        _moveDirection = "Up";
                    }
                    else
                    {
                        _moveDirection = "Left";
                    }
                }
                else if (canMoveUp)
                {
                    _moveDirection = "Up";
                }
                else if (canMoveLeft)
                {
                    _moveDirection = "Left";
                }
                else if (_canMove)
                {
                    _canMove = false;
                    CheckDirection(-moveX, -moveY);
                }
                else
                {
                    _moveDirection = "Stay";
                }
            }//move left or up
            else if(moveX == 0 && moveY == -1)//move up
            {
                if(canMoveUp)
                {
                    _moveDirection = "Up";
                }
                else
                {
                    _moveDirection = "Stay";
                }
            }//move up
            else if(moveX == 1 && moveY == -1)//move up or Right
            {
                if(canMoveRight && canMoveUp)
                {
                    Random random = new Random();
                    int direction = random.Next(0, 2);
                    if (direction == 1)
                    {
                        _moveDirection = "Up";
                    }
                    else
                    {
                        _moveDirection = "Right";
                    }
                }
                else if(canMoveUp)
                {
                    _moveDirection = "Up";
                }
                else if(canMoveRight)
                {
                    _moveDirection = "Right";
                }
                else if(_canMove)
                {
                    _canMove = false;
                    CheckDirection(-moveX, -moveY);
                }
                else
                {
                    _canMove = true;
                    _moveDirection = "Stay";
                }
            }//move up or Right
            else if(moveX == -1 && moveY == 0)//move left
            {
                if(canMoveLeft)
                {
                    _moveDirection = "Left";
                }
                else
                {
                    _moveDirection = "Stay";
                }
            }//move left
            else if(moveX == 1 && moveY == 0)//move Right
            {
                if(canMoveRight)
                {
                    _moveDirection = "Right";
                }
                else
                {
                    _moveDirection = "Stay";
                }
            }//move Right
            else if(moveX == -1 && moveY == 1)//move Left or Down
            {
                if(canMoveLeft && canMoveDown)
                {
                    Random random = new Random();
                    int direction = random.Next(0, 2);
                    if (direction == 1)
                    {
                        _moveDirection = "Down";
                    }
                    else
                    {
                        _moveDirection = "Left";
                    }
                }
                else if(canMoveDown)
                {
                    _moveDirection = "Down";
                }
                else if(canMoveLeft)
                {
                    _moveDirection = "Left";
                }
                else if(_canMove)
                {
                    _canMove = false;
                    CheckDirection(-moveX, -moveY);
                }
                else
                {
                    _canMove = true;
                    _moveDirection = "Stay";
                }
            }//move Left or Down
            else if(moveX == 0 && moveY == 1)//move down
            {
                if(canMoveDown)
                {
                    _moveDirection = "Down";
                }
                else
                {
                    _moveDirection = "Stay";
                }
            }//move down
            else if(moveX == 1 && moveY == 1)//move Down or Right
            {
                if(canMoveDown && canMoveRight)
                {
                    Random random = new Random();
                    int direction = random.Next(0, 2);
                    if (direction == 1)
                    {
                        _moveDirection = "Down";
                    }
                    else
                    {
                        _moveDirection = "Right";
                    }
                }
                else if(canMoveDown)
                {
                    _moveDirection = "Down";
                }
                else if(canMoveRight)
                {
                    _moveDirection = "Right";
                }
                else if(_canMove)
                {
                    _canMove = false;
                    CheckDirection(-moveX, -moveY);
                }
                else
                {
                    _canMove = true;
                    _moveDirection = "Stay";
                }
            }//move Down or Right
            else//Stay
            {
                //check on what body part the player is on
                //have two option of movement for each cenerio
                Type bodyType;
                if (Position.PositionCheck(GameManager.player.position, upperLeft.position))
                {
                    bodyType = Type.BigEnemyUpperLeft;
                }
                else if (Position.PositionCheck(GameManager.player.position, upperRight.position))
                {
                    bodyType = Type.BigEnemyUpperRight;
                }
                else if (Position.PositionCheck(GameManager.player.position, lowerLeft.position))
                {
                    bodyType = Type.BigEnemyLowerLeft;
                }
                else if (Position.PositionCheck(GameManager.player.position, lowerRight.position))
                {
                    bodyType = Type.BigEnemyLowerRight;
                }
                else
                {
                    bodyType = Type.Empty;
                    _moveDirection = "Stay";
                }
                switch (bodyType)
                {
                    case Type.BigEnemyUpperLeft://move left or up
                        if (canMoveLeft && canMoveUp)
                        {
                            Random random = new Random();
                            int direction = random.Next(0, 2);
                            if (direction == 1)
                            {
                                _moveDirection = "Up";
                            }
                            else
                            {
                                _moveDirection = "Left";
                            }
                        }
                        else if (canMoveUp)
                        {
                            _moveDirection = "Up";
                        }
                        else if (canMoveLeft)
                        {
                            _moveDirection = "Left";
                        }
                        else if (_canMove)
                        {
                            _canMove = false;
                            CheckDirection(-moveX, -moveY);
                        }
                        else
                        {
                            _moveDirection = "Stay";
                        }
                        break;
                    case Type.BigEnemyUpperRight://move up or right
                        if (canMoveRight && canMoveUp)
                        {
                            Random random = new Random();
                            int direction = random.Next(0, 2);
                            if (direction == 1)
                            {
                                _moveDirection = "Up";
                            }
                            else
                            {
                                _moveDirection = "Right";
                            }
                        }
                        else if (canMoveUp)
                        {
                            _moveDirection = "Up";
                        }
                        else if (canMoveRight)
                        {
                            _moveDirection = "Right";
                        }
                        else if (_canMove)
                        {
                            _canMove = false;
                            CheckDirection(-moveX, -moveY);
                        }
                        else
                        {
                            _canMove = true;
                            _moveDirection = "Stay";
                        }
                        break;
                    case Type.BigEnemyLowerLeft://move down or left
                        if (canMoveLeft && canMoveDown)
                        {
                            Random random = new Random();
                            int direction = random.Next(0, 2);
                            if (direction == 1)
                            {
                                _moveDirection = "Down";
                            }
                            else
                            {
                                _moveDirection = "Left";
                            }
                        }
                        else if (canMoveDown)
                        {
                            _moveDirection = "Down";
                        }
                        else if (canMoveLeft)
                        {
                            _moveDirection = "Left";
                        }
                        else if (_canMove)
                        {
                            _canMove = false;
                            CheckDirection(-moveX, -moveY);
                        }
                        else
                        {
                            _canMove = true;
                            _moveDirection = "Stay";
                        }
                        break;
                    case Type.BigEnemyLowerRight://move down or right
                        if (canMoveDown && canMoveRight)
                        {
                            Random random = new Random();
                            int direction = random.Next(0, 2);
                            if (direction == 1)
                            {
                                _moveDirection = "Down";
                            }
                            else
                            {
                                _moveDirection = "Right";
                            }
                        }
                        else if (canMoveDown)
                        {
                            _moveDirection = "Down";
                        }
                        else if (canMoveRight)
                        {
                            _moveDirection = "Right";
                        }
                        else if (_canMove)
                        {
                            _canMove = false;
                            CheckDirection(-moveX, -moveY);
                        }
                        else
                        {
                            _canMove = true;
                            _moveDirection = "Stay";
                        }
                        break;
                }
            }//Move On Player
        }
        bool CheckMoveDown()
        {
            if (CheckOtherPos(lowerLeft, 0, 1) && CheckOtherPos(lowerRight, 0, 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CheckMoveUp()
        {
            if (CheckOtherPos(upperLeft, 0, -1) && CheckOtherPos(upperRight, 0, -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CheckMoveRight()
        {
            if (CheckOtherPos(upperRight, 1, 0) && CheckOtherPos(lowerRight, 1, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CheckMoveLeft()
        {
            if (CheckOtherPos(upperLeft, -1, 0) && CheckOtherPos(lowerLeft, -1, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CheckOtherPos(BigEnemyBodyPart bodyPart,int additionX, int additionY)
        {
            if(GameManager.map.mapArray[bodyPart.position.y + additionY, bodyPart.position.x + additionX].type == Type.Empty || GameManager.map.mapArray[bodyPart.position.y + additionY, bodyPart.position.x + additionX].type == Type.Player
               || GameManager.map.mapArray[bodyPart.position.y + additionY, bodyPart.position.x + additionX].type == Type.Vendor || GameManager.map.mapArray[bodyPart.position.y + additionY, bodyPart.position.x + additionX].type == Type.Entrance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Type GetBodyType(Position position)
        {
            if (Position.PositionCheck(position, upperLeft.position) && bigEnemyPartList.Contains(upperLeft))
            {
                return Type.BigEnemyUpperLeft;
            }
            else if(Position.PositionCheck(position, upperRight.position) && bigEnemyPartList.Contains(upperRight))
            {
                return Type.BigEnemyUpperRight;
            }
            else if(Position.PositionCheck(position, lowerLeft.position) && bigEnemyPartList.Contains(lowerLeft))
            {
                return Type.BigEnemyLowerLeft;
            }
            else if(Position.PositionCheck(position, lowerRight.position) && bigEnemyPartList.Contains(lowerRight))
            {
                return Type.BigEnemyLowerRight;
            }
            else
            {
                return Type.Empty;
            }
        }
        public bool CheckPositionOfBodyParts(Position position)
        {
            for (int i = 0; i < bigEnemyPartList.Count; i++)
            {
                if(Position.PositionCheck(position, bigEnemyPartList[i].position))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
