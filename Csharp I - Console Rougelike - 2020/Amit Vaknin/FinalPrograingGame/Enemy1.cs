using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FinalPrograingGame
{
    class Enemy
    {

        public int posX;
        public int preX;
        private int posY;
        private int preY;
        public bool isDead = false;
        public Enemy(int x, int y)

        {
            posX = preX = x;
            posY = preY = y;
            SetCursorPosition(posX, posY);
            Console.Write("M");
        }
        public void PrintEnemy()
        {
            if (posX == preX && posY == preY)
            {
                return;
            }
            Console.SetCursorPosition(preX, preY);
            Console.Write(" ");
            Console.SetCursorPosition(posX, posY);
            Console.Write("M");
            preX = posX;
            preY = posY;
        }

        public void Move(int targetX, int targetY)
        {
            int deltaX = targetX - posX;
            int deltaY = targetY - posY;
            Random RND = new Random();
            int enemyrandom = RND.Next(0, 2);
            if (enemyrandom==0)
            {


                if (!isDead)
                {
                    if (posX < targetX)
                    {
                        if (MapCreator.getMapInstance.map[posY, posX + 1] == "-" || MapCreator.getMapInstance.map[posY, posX + 1] == "|")
                        {
                            posX--;
                        }
                        else
                        {
                            posX++;
                        }
                    }
                    if (posX > targetX)
                    {

                        if (MapCreator.getMapInstance.map[posY, posX - 1] == "-" || MapCreator.getMapInstance.map[posY, posX - 1] == "|")
                        {
                            posX++;
                        }
                        else
                        {
                            posX--;
                        }
                    }
                    if (posX == targetX)
                    {
                        if (posY < targetY)
                        {
                            if (MapCreator.getMapInstance.map[posY + 1, posX] == "-" || MapCreator.getMapInstance.map[posY + 1, posX] == "|")
                            {
                                posY--;
                            }
                            else
                            {
                                posY++;
                            }
                        }
                        if (posY > targetY)
                        {
                            if (MapCreator.getMapInstance.map[posY - 1, posX] == "-" || MapCreator.getMapInstance.map[posY - 1, posX] == "|")
                            {
                                posY++;
                            }
                            else
                            {
                                posY--;
                            }
                        }
                    }
                }
            }
            if (enemyrandom == 1)
            {


                if (!isDead)
                {
                    if (posY < targetY)
                    {
                        if (MapCreator.getMapInstance.map[posY + 1, posX] == "-" || MapCreator.getMapInstance.map[posY + 1, posX] == "|")
                        {
                            posY--;
                        }
                        else
                        {
                            posY++;
                        }
                    }
                    if (posY > targetY)
                    {
                        if (MapCreator.getMapInstance.map[posY - 1, posX] == "-" || MapCreator.getMapInstance.map[posY - 1, posX] == "|")
                        {
                            posY++;
                        }
                        else
                        {
                            posY--;
                        }
                    }
                    if (posY == targetY)
                    {
                        if (posX < targetX)
                        {
                            if (MapCreator.getMapInstance.map[posY, posX + 1] == "-" || MapCreator.getMapInstance.map[posY, posX + 1] == "|")
                            {
                                posX--;
                            }
                            else
                            {
                                posX++;
                            }
                        }
                        if (posX > targetX)
                        {

                            if (MapCreator.getMapInstance.map[posY, posX - 1] == "-" || MapCreator.getMapInstance.map[posY, posX - 1] == "|")
                            {
                                posX++;
                            }
                            else
                            {
                                posX--;
                            }
                        }
                    }
                }
            }
            if (posX == targetX && posY == targetY &&!isDead)
            {
                isDead = true;
                EnemyHit();
                Console.SetCursorPosition(0, 20);
                HUD.gethudInstance.Hudcreator();
               
            }

        }
        public void EnemyHit()
        {
            if (isDead == true)
            {
                player.getplayerInstance.baseHp -= player.getplayerInstance.enemydmg;
               

            }
        }

    }
}




