using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public static class Hud
    {
        public static bool hasAnArmor = false;
        public static string InfoText = " ";
        public static string InfoText2 = " ";
        public static void PrintHUD()
        {
            InfoBar();
            InfoBar2();
            UpperHUD();
            HPBar();
            GoldBar();
            LeatherBar();
            LevelBar();
            ArmorBar();
            EnemyDeathBar();
            Items();
        }
        static void UpperHUD()
        {
            Console.WriteLine("-----PlayerStats-----");
        }
        static void HPBar()
        {   
            Console.Write("Health: ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < PlayerStats.health; i++)
            {
                Console.Write("<3 ");
                Console.Write("  ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        static void GoldBar()
        {
            Console.Write("Gold:  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(PlayerStats.gold);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void LevelBar()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(GameManager.level);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void ArmorBar()
        {
            PlayerStats.UpdateArmor();
            Console.Write("Armor: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(PlayerStats.armor);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void LeatherBar()
        {
            Console.Write("Leather: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(PlayerStats.leather);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void EnemyDeathBar()
        {
            SmallEnemyBar();
            BigEnemyBar();
        }
        static void SmallEnemyBar()
        {
            Console.Write("Small Enemies Killed: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(EnemyManager.smallEnemyDeathCounter);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Small Enemies HP: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(SmallEnemy.maxHealth);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        static void BigEnemyBar()
        {
            Console.Write("Big Enemies Killed: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(EnemyManager.bigEnemyDeathCounter);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Big Enemies HP: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(BigEnemyBodyPart.maxHealth);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        static void InfoBar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Action: ");
            Console.Write(InfoText);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void InfoBar2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FeedBack: ");
            Console.Write(InfoText2);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Items()
        {
            Console.Write("------Items-----");
            Console.WriteLine();
            Weapons();
            Armor();
        }
        static void Weapons()
        {
            if(PlayerStats.hasSword == true || PlayerStats.hasBow == true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Weapons: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
            if (PlayerStats.hasSword == true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Sword.name + ":");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Attack: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Sword.attack);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Range: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Sword.range + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Sword.level + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Key: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("E");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
            if (PlayerStats.hasBow == true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(ItemManager.Bow.name + ":  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Attack: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Bow.attack);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Range: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Bow.range + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Bow.level + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Key: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Q");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }
        static void Armor()
        {
            if (hasAnArmor == true)
            {
                PlayerStats.UpdateArmor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Armor: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
            if(PlayerStats.hasHelmet == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Helmet.name + ":         ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Armor: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Helmet.armor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Helmet.level + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if(PlayerStats.hasChestPlate == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ChestPlate.name + ":    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Armor: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.ChestPlate.armor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ChestPlate.level + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasArmBracers == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.ArmBracers.name + ":    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Armor: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.ArmBracers.armor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.ArmBracers.level + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasBoots == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Boots.name + ":          ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Armor: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Boots.armor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Boots.level + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (PlayerStats.hasGuntlet == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(ItemManager.Guntlet.name + ":        ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Armor: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Guntlet.armor);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Level: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ItemManager.Guntlet.level + " ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Attack Bonus: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ItemManager.Guntlet.attack + " ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
