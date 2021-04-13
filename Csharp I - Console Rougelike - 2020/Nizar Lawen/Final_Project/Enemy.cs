using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Enemy
    {        
        int posX;
        int posY;
        public Enemy(int x, int y)
        {
            posX = _PrevX = x;
            posY = _PrevY = y;
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("M");
            Console.ResetColor();
        }
        private int _PrevX;
        private int _PrevY;
        public void UpdatePrint()
        {
            //happends after movement calculations
            //posX and posY are the new positions
            if (posX == _PrevX && posY==_PrevY )
            {
                return;
            }
            Console.SetCursorPosition(_PrevX, _PrevY);
            Console.Write(" ");
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("M");
            Console.ResetColor();
            _PrevX = posX;
            _PrevY = posY;
        }
       
        bool xMove = false;
        bool yMove = false;
        public bool EnemyIsDead = false;        
        SoundManager SoundManager = new SoundManager();
        public void EnemyMovement1( int playerX, int playerY)
        {
            Random rand = new Random();            
            int enemyRand = rand.Next(0, 2);
            
            //X Axis, Column
            if (enemyRand == 0)
            {
                if (yMove == false && !EnemyIsDead)
                {
                    if (posX == playerX)
                    {
                        //minionYPosition++ or --
                        if (posY < playerY)
                        {
                            //minionYPosition++
                            if (Maps.GetMapInstance.Map[posY + 1, posX] == "|" || Maps.GetMapInstance.Map[posY + 1, posX] == "-"
                                || Maps.GetMapInstance.Map[posY + 1, posX] == "$" || Maps.GetMapInstance.Map[posY + 1, posX] == "♥")
                            {
                                /*Console.SetCursorPosition(posX, posY);
                                Console.Write(" ");*/
                                posY--;
                            }
                            else
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posY++;
                                //xMove = true;
                            }
                        }
                        if (posY > playerY)
                        {
                            //posYPosition--
                            if (Maps.GetMapInstance.Map[posY - 1, posX] == "|" || Maps.GetMapInstance.Map[posY - 1, posX] == "-" 
                                || Maps.GetMapInstance.Map[posY - 1, posX] == "$" || Maps.GetMapInstance.Map[posY - 1, posX] == "♥")
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posY++;
                            }
                            else
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posY--;
                                //xMove = true;
                            }
                        }
                        xMove = true;
                    }
                    if (posX < playerX)
                    {
                        //minionXPosition++
                        if (Maps.GetMapInstance.Map[posY, posX + 1] == "|" || Maps.GetMapInstance.Map[posY, posX + 1] == "-" 
                            || Maps.GetMapInstance.Map[posY , posX + 1] == "$" || Maps.GetMapInstance.Map[posY , posX + 1] == "♥")
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posX--;
                        }
                        else
                        {
                            //make the same if like the WASD when u reach $ u delete the $ when u r going to step on it
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posX++;
                            xMove = true;
                        }
                    }
                    if (posX > playerX)
                    {
                        //minionXPosition--
                        if (Maps.GetMapInstance.Map[posY, posX - 1] == "|" || Maps.GetMapInstance.Map[posY, posX - 1] == "-" 
                            || Maps.GetMapInstance.Map[posY , posX - 1] == "$" || Maps.GetMapInstance.Map[posY , posX - 1] == "♥")
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posX++;
                        }
                        else
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posX--;
                            xMove = true;
                        }
                    }
                }
            }

            //Y Axis, Row
            if (enemyRand == 1)
            {
                if (xMove == false && !EnemyIsDead)
                {
                    if (posY == playerY)
                    {
                        //minionXPosition++ or --
                        if (posX < playerX)
                        {
                            //minionXPosition--
                            if (Maps.GetMapInstance.Map[posY, posX + 1] == "|" || Maps.GetMapInstance.Map[posY, posX + 1] == "-" 
                                || Maps.GetMapInstance.Map[posY , posX + 1] == "$" || Maps.GetMapInstance.Map[posY , posX + 1] == "♥")
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posX--;
                            }
                            else
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posX++;
                                //yMove = true;
                            }
                        }
                        if (posX > playerX)
                        {
                            //minionXPosition++
                            if (Maps.GetMapInstance.Map[posY, posX - 1] == "|" || Maps.GetMapInstance.Map[posY, posX - 1] == "-" 
                                || Maps.GetMapInstance.Map[posY , posX - 1] == "$" || Maps.GetMapInstance.Map[posY , posX - 1] == "♥")
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posX++;
                            }
                            else
                            {
                                //Console.SetCursorPosition(posX, posY);
                                //Console.Write(" ");
                                posX--;
                                //yMove = true;
                            }
                        }
                        yMove = true;
                    }
                    if (posY < playerY)
                    {
                        //posYPosition++
                        if (Maps.GetMapInstance.Map[posY + 1, posX] == "|" || Maps.GetMapInstance.Map[posY + 1, posX] == "-" 
                            || Maps.GetMapInstance.Map[posY + 1, posX] == "$" || Maps.GetMapInstance.Map[posY + 1, posX] == "♥")
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posY--;
                        }
                        else
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posY++;
                            yMove = true;
                        }
                    }
                    if (posY > playerY)
                    {
                        //minionYPosition--
                        if (Maps.GetMapInstance.Map[posY - 1, posX] == "|" || Maps.GetMapInstance.Map[posY - 1, posX] == "-" 
                            || Maps.GetMapInstance.Map[posY - 1, posX ] == "$" || Maps.GetMapInstance.Map[posY - 1, posX ] == "♥")
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posY++;
                        }
                        else
                        {
                            //Console.SetCursorPosition(posX, posY);
                            //Console.Write(" ");
                            posY--;
                            yMove = true;
                        }
                    }
                }
            }
            
            if (posX == playerX && posY == playerY && !EnemyIsDead)
            {
                Player.GetPlayerInstance.PlayerHP -= Player.GetPlayerInstance.EnemyDMG;
                SoundManager.GetHitSoundEffect();
                Console.SetCursorPosition(posX, posY);
                Console.Write(" ");
                Console.SetCursorPosition(1, 30);
                DataBoard.GetDataInstance.PrintData();
                EnemyIsDead = true;
            }
            xMove = false;
            yMove = false;
            UpdatePrint();
        }

    }
}
