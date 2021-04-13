using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2_2021TiltanClassWorkCSProject
{
    class Enemy
    {
        // General Enemy Data:
        public string EnemyName;
        public static int EnemyHP;
        public int EnemyDamage;

        // Assigning Values To Enemy Instance And Game Mode
        public Enemy(int level, string gameModeSetting)
        {
            if (gameModeSetting == "Story")
            {
                if (level < 10)
                {
                    for (int a = 0; a != level; a++)
                    {
                        EnemyName = "Potato" + (a + 1);
                    }

                    EnemyHP = level * 5;
                    EnemyDamage = level + 1;
                }
                else if (level == 10)
                {
                    EnemyName = "KING POTATO THE FOURTH";
                    EnemyHP = 9000;
                    EnemyDamage = 9000;
                }
                else
                {
                    Console.WriteLine("CONGRATULATIONS YOU HAVE ESCAPED THE DUNGEON!!!");
                    Console.WriteLine("You Escaped With The Following Stats");
                    Console.WriteLine("================================================");
                    Player.DisplayStats(3, level);
                    Console.WriteLine("================================================");
                    Console.WriteLine("Thank You So Much For Playing!");
                    Console.WriteLine("Click 'Enter' To Finish " + Player.CharacterName + "'s Journey");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }
            else if (gameModeSetting == "Survival")
            {
                for (int a = 0; a != level; a++)
                {
                    EnemyName = "Potato" + (a + 1);
                }

                EnemyHP = level * 5;
                EnemyDamage = level + 1;
            }

        }


        //--------------------
        // Functions/Methods:


        //  Present Enemy
        public void CombatInitiate(string[,] mapMatrix, int[,] enemyCords, int enemyAmount, int level, bool bossFight)
        {
            bool condition = bossFight;
            if (bossFight == true)
            {
                condition = EnemyHP > 0;
            }
            else if (bossFight == false)
            {
                condition = enemyCords[enemyAmount, 2] > 0;
            }
            while (condition)
            {
                //--------------------
                // Player's Turn
                Player.DisplayStats(mapMatrix.GetLength(0), level);
                ConsoleKeyInfo keyInfo;
                if (bossFight == true)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("You Face " + EnemyName);
                    Console.WriteLine("Its Health Is At " + EnemyHP + " HP");
                    Console.WriteLine("It Can Do " + EnemyDamage + " Damage");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("How Do You Act?");
                    Console.WriteLine("1. Attack, 2.Dodge, 3.Heal, 4.Special");
                }
                else if(bossFight == false)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("You Face " + EnemyName);
                    Console.WriteLine("Its Health Is At " + enemyCords[enemyAmount, 2] + " HP");
                    Console.WriteLine("It Can Do " + EnemyDamage + " Damage");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("How Do You Act?");
                    Console.WriteLine("1. Attack, 2.Dodge, 3.Heal, 4.Special");
                }   

                bool specialSkip = false;
                bool isDodging = false;
                Random rand = new Random();

                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    // Attack
                    case ConsoleKey.D1:
                        int damage = Player.DamageCalc();
                        if (damage > 0)
                        {
                            if (bossFight == true)
                            {
                                EnemyHP -= damage;
                                Console.WriteLine("You Have 'Attacked' The Enemey For " + damage + " Damage");
                            }
                            else if (bossFight == false)
                            {
                                enemyCords[enemyAmount, 2] -= damage;
                                Console.WriteLine("You Have 'Attacked' The Enemey For " + damage + " Damage");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You Tried To 'Attack' The Enemey And MISSED!");
                        }
                        Console.WriteLine("Press 'ENTER' To Continue");
                        Console.ReadLine();
                        Map.ClearNoteBoard(mapMatrix.GetLength(0));
                        break;
                    // Dodge
                    case ConsoleKey.D2:
                        if (rand.NextDouble() <= Player.DodgeChance)
                        {
                            isDodging = true;
                        }
                        break;
                    // Heal
                    case ConsoleKey.D3:
                        if (Player.CurrentHP == Player.BaseHP)
                        {
                            Console.WriteLine("Your Health Is Already Full");
                            Console.WriteLine("Trying To Heal Costed You '1' Turn!");
                        }
                        else if (Player.CurrentHP != Player.BaseHP && Player.HealthPacks == 0)
                        {
                            Console.WriteLine("You Are Carrying NO HealthPacks");
                            Console.WriteLine("You Wasted '1' Turn Searching Your Empty Pockets");
                        }
                        else
                        {
                            Player.CurrentHP = Player.BaseHP;
                            Player.HealthPacks = --Player.HealthPacks;
                            Console.WriteLine("You Use A HealthPack & Fully Recover Your HP!");
                        }
                        Console.WriteLine("Press 'ENTER' To Continue");
                        Console.ReadLine();
                        Map.ClearNoteBoard(mapMatrix.GetLength(0));
                        break;
                    // Special
                    case ConsoleKey.D4:
                        if (Player.SpecialA > 0)
                        {
                            if (bossFight == true)
                            {
                                Console.WriteLine("You Search Deep In Your Pockets To Find A...");
                                Console.WriteLine("GRENADE!?");
                                Console.WriteLine("You Attack " + EnemyName + " With It And Cause 9000 Damage!");
                                EnemyHP = EnemyHP - 9000;
                                Player.SpecialA = Player.SpecialA - 1;
                                specialSkip = true;
                            }
                            else if (bossFight == false)
                            {
                                Console.WriteLine("You Search Deep In Your Pockets To Find A...");
                                Console.WriteLine("GRENADE!?");
                                Console.WriteLine("You Attack " + EnemyName + " With It And Cause 9000 Damage!");
                                enemyCords[enemyAmount, 2] = enemyCords[enemyAmount, 2] - 9000;
                                Player.SpecialA = Player.SpecialA - 1;
                                specialSkip = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You Have Used Your GRENADE Already");
                            Console.WriteLine("Maybe You Should Have Saved It For Later...");
                        }
                        Console.WriteLine("Press 'ENTER' To Continue");
                        Console.ReadLine();
                        Map.ClearNoteBoard(mapMatrix.GetLength(0));
                        break;
                    default:
                        break;
                }

                //--------------------
                // Enemy's Turn
                if (bossFight == true)
                {
                    if (specialSkip == false && EnemyHP <= 0)
                    {
                        break;
                    }
                    else if (specialSkip == true)
                    {
                        specialSkip = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(EnemyName + " Strikes Back!");
                        if (isDodging)
                        {
                            Console.WriteLine("You Have Dodged " + EnemyName + "'s Attack. You Are Safe!");
                            EnemyHP -= Player.MaxDamage;
                            Console.WriteLine("You Counter The Attack! Causing " + Player.MaxDamage + " Damage To " + EnemyName);
                        }
                        else
                        {
                            Player.CurrentHP -= EnemyDamage;
                            Console.WriteLine(EnemyName + " Hits You For " + EnemyDamage + " Damage.");
                        }
                        Console.WriteLine("Press 'ENTER' To Continue");
                        Console.ReadLine();
                        Map.ClearNoteBoard(mapMatrix.GetLength(0));
                    }
                    Player.DisplayStats(mapMatrix.GetLength(0), level);
                }
                else if (bossFight == false)
                {
                    if (specialSkip == false && enemyCords[enemyAmount, 2] <= 0)
                    {
                        break;
                    }
                    else if (specialSkip == true)
                    {
                        specialSkip = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(EnemyName + " Strikes Back!");
                        if (isDodging)
                        {
                            Console.WriteLine("You Have Dodged " + EnemyName + "'s Attack. You Are Safe!");
                            enemyCords[enemyAmount, 2] -= Player.MaxDamage;
                            Console.WriteLine("You Counter The Attack! Causing " + Player.MaxDamage + " Damage To " + EnemyName);
                        }
                        else
                        {
                            Player.CurrentHP -= EnemyDamage;
                            Console.WriteLine(EnemyName + " Hits You For " + EnemyDamage + " Damage.");
                        }
                        Console.WriteLine("Press 'ENTER' To Continue");
                        Console.ReadLine();
                        Map.ClearNoteBoard(mapMatrix.GetLength(0));
                    }
                    Player.DisplayStats(mapMatrix.GetLength(0), level);
                }

                // Check If Player Is Dead
                if (bossFight == true)
                {
                    if (Player.CheckDeath() == true)
                    {
                        EnemyHP = 0;
                    }
                }
                else if(bossFight == false)
                {
                    if (Player.CheckDeath() == true)
                    {
                        enemyCords[enemyAmount, 2] = 0;
                    }
                }
            }
            if (Player.IsDead == false)
            {
                // When Enemy Dies
                if (bossFight == true)
                {
                    AudioManager.getAudioManagerInstance.RunEndingMusic();
                    Console.WriteLine("=====================================");
                    Console.WriteLine("You Beat " + EnemyName + "!");
                    Player.BaseHP = Player.BaseHP + level;
                    Console.WriteLine("Plus! Your BaseHP Went Up By '" + level + "' HP");
                    Console.WriteLine("Your BaseHP Is Now At '" + Player.BaseHP + "' HP");
                    Console.WriteLine("Press 'ENTER' To Continue");
                    Console.ReadLine();
                    Map.ClearNoteBoard(mapMatrix.GetLength(0));
                }
                else
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("You Beat " + EnemyName + "!");
                    Player.BaseHP = Player.BaseHP + level;
                    Console.WriteLine("Plus! Your BaseHP Went Up By '" + level + "' HP");
                    Console.WriteLine("Your BaseHP Is Now At '" + Player.BaseHP + "' HP");
                    Console.WriteLine("Press 'ENTER' To Continue");
                    Console.ReadLine();
                    Map.ClearNoteBoard(mapMatrix.GetLength(0));                        
                }
            }

            if (bossFight == true)
            {
                for (int enemyRowPos = 0; enemyRowPos < enemyCords.GetLength(0); enemyRowPos++)
                {
                    Console.SetCursorPosition(enemyCords[enemyRowPos, 1], enemyCords[enemyRowPos, 0]);
                    mapMatrix[(enemyCords[enemyRowPos, 0]), (enemyCords[enemyRowPos, 1])] = " ";
                    Console.Write(mapMatrix[(enemyCords[enemyRowPos, 0]), (enemyCords[enemyRowPos, 1])]);
                }
            }
            else if (bossFight == false)
            {
                Console.SetCursorPosition(enemyCords[enemyAmount, 1], enemyCords[enemyAmount, 0]);
                mapMatrix[(enemyCords[enemyAmount, 0]), (enemyCords[enemyAmount, 1])] = " ";
                Console.Write(mapMatrix[(enemyCords[enemyAmount, 0]), (enemyCords[enemyAmount, 1])]);
            }
        }


        // Enemy AI
        public void EnemyAIController(int playerX, int playerY, string[,] mapMatrix, int[,] enemyCords, int level, string gameModeSetting)
        {
            if (gameModeSetting == "Survival" || (gameModeSetting == "Story" && level != 10))
            {
                for (int enemyAmount = 0; enemyAmount < level; enemyAmount++)
                {
                    int enemyY = enemyCords[enemyAmount, 0];
                    int enemyX = enemyCords[enemyAmount, 1];

                    if (mapMatrix[enemyY, enemyX] == " ")
                    {

                    }
                    else if ((enemyY + 1 == playerY && enemyX == playerX) || (enemyY - 1 == playerY && enemyX == playerX) || (enemyY == playerY && enemyX + 1 == playerX) || (enemyY == playerY && enemyX - 1 == playerX))
                    {
                        Console.SetCursorPosition(0, mapMatrix.GetLength(0) + 7);
                        CombatInitiate(mapMatrix, enemyCords, enemyAmount, level, false);
                    }
                    else if (enemyY < playerY && mapMatrix[enemyY + 1,enemyX] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY,enemyX]);
                        enemyY++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                    else if (enemyY > playerY && mapMatrix[enemyY - 1, enemyX] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        enemyY--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                    else if (enemyX < playerX && mapMatrix[enemyY, enemyX + 1] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        enemyX++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                    else if (enemyX > playerX && mapMatrix[enemyY, enemyX - 1] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        enemyX--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                }
            }
            else if (gameModeSetting == "Story" && level == 10)
            {
                for (int enemyAmount = 0; enemyAmount < enemyCords.GetLength(0); enemyAmount++)
                {
                    int enemyY = enemyCords[enemyAmount, 0];
                    int enemyX = enemyCords[enemyAmount, 1];

                    if (mapMatrix[enemyY, enemyX] == " ")
                    {

                    }
                    else if ((enemyY + 1 == playerY && enemyX == playerX) || (enemyY - 1 == playerY && enemyX == playerX) || (enemyY == playerY && enemyX + 1 == playerX) || (enemyY == playerY && enemyX - 1 == playerX))
                    {
                        Console.SetCursorPosition(0, mapMatrix.GetLength(0) + 7);
                        CombatInitiate(mapMatrix, enemyCords, enemyAmount, level, true);
                    }
                    else if (enemyX < playerX && mapMatrix[enemyY, enemyX + 1] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        enemyX++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                    else if (enemyX > playerX && mapMatrix[enemyY, enemyX - 1] == " ")
                    {
                        Console.SetCursorPosition(enemyX, enemyY);
                        mapMatrix[enemyY, enemyX] = " ";
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        enemyX--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        mapMatrix[enemyY, enemyX] = "M";
                        Console.SetCursorPosition(enemyX, enemyY);
                        Console.Write(mapMatrix[enemyY, enemyX]);
                        Console.ResetColor();

                        enemyCords[enemyAmount, 0] = enemyY;
                        enemyCords[enemyAmount, 1] = enemyX;
                    }
                }
            }
        }
    }
}
