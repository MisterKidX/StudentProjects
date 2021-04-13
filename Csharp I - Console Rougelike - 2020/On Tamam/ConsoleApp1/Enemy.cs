using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Enemy
    {
        public int HP;
        public int Dexterity;
        public int strength;
        public int intelligence;
        public int MagRes;
        public int Armor;
        public int  EnemyLevel;
        public string ClassType; // decide between magic enemies and physical enemies (dmg type)
        public int EnemyX ;
        public int EnemyY ;
        ConsoleColor EnemyColor;
        public char EnemyMarker = '@';
        public int XPValue;
        Random rnd = new Random();
        public bool hassaki;
        public Enemy(int type, int level)
        {
            EnemyX = rnd.Next(5, 20);
            EnemyY = rnd.Next(5, 35);
            EnemyLevel = level;
            switch (type)
            {
                case 1:
                    ClassType = "Magical_enemy";
                    //EnemyColor = ConsoleColor.Blue; change that in the class that spawns them
                    HP = rnd.Next(10, 30) * EnemyLevel;
                    Dexterity = EnemyLevel;
                    strength = EnemyLevel;
                    intelligence = rnd.Next(1, 4) * EnemyLevel;
                    MagRes = rnd.Next(1, 3) * EnemyLevel;
                    Armor = EnemyLevel;
                    XPValue = level * 3;
                    break;
                case 2:
                    ClassType = "Physical_enemy";
                    //EnemyColor = ConsoleColor.Red; change that in the class that spawns them
                    HP = rnd.Next(10, 30) * EnemyLevel;
                    Dexterity = EnemyLevel;
                    strength = rnd.Next(1,4) * EnemyLevel;
                    intelligence = EnemyLevel;
                    MagRes = EnemyLevel;
                    Armor = rnd.Next(1,3) * EnemyLevel;
                    XPValue = level * 3;
                    break;
                default:
                    break;
            }
            if (rnd.Next(1, 100) >= level * 10)
            {
                hassaki = true;
            }
            else
                hassaki = false;
        }
        public void printEnemy()
        {
            if (HP <= 0)
            {
                EnemyMarker = ' ';
            }
            switch (ClassType)
            {
                case "Magical_enemy":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Console.Write(EnemyMarker);
                    Console.ResetColor();
                    break;
                case "Physical_enemy":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(EnemyX, EnemyY);
                    Console.Write(EnemyMarker);
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }
    }
}
