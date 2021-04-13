using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProgramming_DorShemTov
{
    public class Enemy
    {
        public int PosX;
        public int PreX;
        private int PosY;
        private int PreY;
        public bool IsDead = false;
        bool xMove = false;
        bool yMove = false;
       
        public Enemy(int x, int y)

        {
            PosX = PreX = x;
            PosY = PreY = y;
        }
       
        public void PrintEnemy()
        {
            if (PosX == PreX && PosY == PreY)
            {
                return;
            }
            Console.SetCursorPosition(PreX, PreY);
            Console.Write(' ');
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('M');
            Console.ResetColor();
            PreX = PosX;
            PreY = PosY;
        }
        
        public void Move(int playerX, int playerY)
        {
            Random rand = new Random();
            int enemyRand = rand.Next(0, 2);
            if (enemyRand == 0)
            {
                if (yMove == false && !IsDead)
                {
                    if (PosX == playerX)
                    {
                        if (PosY < playerY)
                        {
                            if (Map.MapInstance.Map2D[PosY + 1, PosX] == '|' || Map.MapInstance.Map2D[PosY + 1, PosX] == '-'
                                || Map.MapInstance.Map2D[PosY + 1, PosX] == '+')
                            {
                                PosY--;
                            }
                            else
                            {
                                PosY++;
                            }
                        }
                        if (PosY > playerY)
                        {
                            if (Map.MapInstance.Map2D[PosY - 1, PosX] == '|' || Map.MapInstance.Map2D[PosY - 1, PosX] == '-'
                                || Map.MapInstance.Map2D[PosY - 1, PosX] == '+')
                            {
                                PosY++;
                            }
                            else
                            {
                                PosY--;
                            }
                        }
                        xMove = true;
                    }
                    if (PosX < playerX)
                    {
                        if (Map.MapInstance.Map2D[PosY, PosX + 1] == '|' || Map.MapInstance.Map2D[PosY, PosX + 1] == '-'
                            || Map.MapInstance.Map2D[PosY, PosX + 1] == '+')
                        {
                            PosX--;
                        }
                        else
                        {
                            PosX++;
                            xMove = true;
                        }
                    }
                    if (PosX > playerX)
                    {
                        if (Map.MapInstance.Map2D[PosY, PosX - 1] == '|' || Map.MapInstance.Map2D[PosY, PosX - 1] == '-'
                            || Map.MapInstance.Map2D[PosY, PosX - 1] == '+')
                        {
                            PosX++;
                        }
                        else
                        {
                            PosX--;
                            xMove = true;
                        }
                    }
                }
            }
            if (enemyRand == 1)
            {
                if (xMove == false && !IsDead)
                {
                    if (PosY == playerY)
                    {
                        if (PosX < playerX)
                        {
                            if (Map.MapInstance.Map2D[PosY, PosX + 1] == '|' || Map.MapInstance.Map2D[PosY, PosX + 1] == '-'
                                || Map.MapInstance.Map2D[PosY, PosX + 1] == '+')
                            {
                                PosX--;
                            }
                            else
                            {
                                PosX++;
                            }
                        }
                        if (PosX > playerX)
                        {
                            if (Map.MapInstance.Map2D[PosY, PosX - 1] == '|' || Map.MapInstance.Map2D[PosY, PosX - 1] == '-'
                                || Map.MapInstance.Map2D[PosY, PosX - 1] == '+')
                            {
                                PosX++;
                            }
                            else
                            {
                                PosX--;
                            }
                        }
                        yMove = true;
                    }
                    if (PosY < playerY)
                    {
                        if (Map.MapInstance.Map2D[PosY + 1, PosX] == '|' || Map.MapInstance.Map2D[PosY + 1, PosX] == '-'
                            || Map.MapInstance.Map2D[PosY + 1, PosX] == '+')
                        {
                            PosY--;
                        }
                        else
                        {
                            PosY++;
                            yMove = true;
                        }
                    }
                    if (PosY > playerY)
                    {
                        if (Map.MapInstance.Map2D[PosY - 1, PosX] == '|' || Map.MapInstance.Map2D[PosY - 1, PosX] == '-'
                            || Map.MapInstance.Map2D[PosY - 1, PosX] == '+')
                        {
                            PosY++;
                        }
                        else
                        {
                            PosY--;
                            yMove = true;
                        }
                    }
                }
            }

            if (PosX == playerX && PosY == playerY && !IsDead)
            {

                Player.PlayerInstance.baseHP -= 10;
                Console.SetCursorPosition(PosX, PosY);
                Console.Write(" ");
                Console.SetCursorPosition(0, 40);
                Hud.HudInstance.PrintHud();
                IsDead = true;
                Console.Beep(196, 250);
            }
            xMove = false;
            yMove = false;
            PrintEnemy();
        }

    }
}
