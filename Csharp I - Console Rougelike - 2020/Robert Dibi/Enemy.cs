using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndOfSemester_Project
{
class Enemy
{
    public int EnemyDmg = 15;
    public int PosX;
    public int PosY;
    Sounds SoundMngr = new Sounds();
    public Enemy(int x , int y)
    {
        PosX = _prevX = x;
        PosY = _prevY = y;
        Console.SetCursorPosition(PosX, PosY);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(Map.GetMapInstance.Enemy);

    }

    private int _prevX;
    private int _prevY;
    public void Update()
    {
        if (PosX == _prevX && PosY == _prevY)
        {
            return;
        }

        Console.SetCursorPosition(_prevX, _prevY);
        Console.Write(" ");
        Console.SetCursorPosition(PosX, PosY);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(Map.GetMapInstance.Enemy);
        Console.ResetColor();
        _prevX = PosX;
        _prevY = PosY;
    }
    public bool PosXMovement = false;
    public bool PosYMovement = false;
    public bool EnemyIsDead = false;
    public void EnemyMovement(int PlayerX, int PlayerY)
    {
        Random RNG = new Random();
        int enemyRNG = RNG.Next(0, 2);
        //Enemy X axis
        if (enemyRNG == 0)
        {
            
        if (PosYMovement == false && !EnemyIsDead)
        {
            //Enemy X axis
            if (PosX == PlayerX)
            {
                if (PosY < PlayerY)
                {
                    if (Map.GetMapInstance.box[PosY + 1, PosX] != " ")
                    {

                        /*posY--;*/
                    }
                    else
                    {
                        
                            PosY++;
                            Update();
                        }

                }

                if (PosY > PlayerY)
                {
                    if (Map.GetMapInstance.box[PosY - 1, PosX] != " " )
                    {
                        /*posY++;*/
                    }
                    else
                    {

                        PosY--;
                        Update();
                        }
                       
                }
                PosXMovement = true;
            }
            if (PosX < PlayerX)
            {
                if (Map.GetMapInstance.box[PosY, PosX + 1] != " ")
                {
                    PosX--;
                }
                else
                {

                    PosX++;
                        Update();
                        PosXMovement = true;
                }

            }
            if (PosX > PlayerX)
            {
                if (Map.GetMapInstance.box[PosY, PosX - 1] != " ")
                {
                    PosX++;
                }
                else
                {

                    PosX--;
                        Update();
                        PosXMovement = true;
                }
                  
            }
        }

        }
        //Enemy Y axis
        if (enemyRNG==1)
        {
        if (PosXMovement == false && !EnemyIsDead)
        {
            if (PosY == PlayerY)
                {

                    if (PosX < PlayerX)
                {
                        if (Map.GetMapInstance.box[PosY, PosX + 1 ] != " ")
                        {
                            PosX--;
                        }
                        else
                        {

                        PosX++;
                            Update();
                        }

                }
                 
                if (PosX > PlayerX)
                {
                        if (Map.GetMapInstance.box[PosY, PosX + 1] != " " )
                        {
                            PosX++;
                        }
                        else
                        {
                        PosX--;
                            Update();
                        }
                }
              
                PosYMovement = true;
            }
            if (PosY < PlayerY)
            {
                    if (Map.GetMapInstance.box[PosY + 1, PosX] != " ")
                    {
                        /*posY--;*/
                    }
                    else
                    {

                        PosY++;
                        Update();
                    }
                PosYMovement = true;
            }

            if (PosY > PlayerY)
            {


                    if (Map.GetMapInstance.box[PosY - 1, PosX] != " ")
                    {
                        PosY++;
                    }
                    else
                    {
                        PosY--;
                        Update();
                        PosYMovement = true;
                    }
            }

        }

        }
               
        //If player touches enemy
            
        if (PlayerX == PosX && PlayerY == PosY && !EnemyIsDead)
        {
            SoundMngr.EnemyHit();
            Player.GetPlayerInstance.EnemiesKilled++;
            Player.GetPlayerInstance.CurrentHP -= Player.GetPlayerInstance.EnemyDmg;
                
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
            Console.SetCursorPosition(0, 25);
            HUD.GetHUDInstance.ShowHUD();
            Console.WriteLine("You have slain the enemy however it took "+EnemyDmg+"HP!                     ");

            EnemyIsDead = true;
        }
        PosXMovement = false;
        PosYMovement = false;
            
    }
}
}
