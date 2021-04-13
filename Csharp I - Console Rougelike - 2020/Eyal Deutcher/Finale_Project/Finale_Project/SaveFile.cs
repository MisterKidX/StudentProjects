using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class SaveFile
    {
        //EnemyManager
        public int smallEnemyDeathCounter;
        public int bigEnemyDeathCounter;

        //PlayerStats
        public int maxHealth;
        public int health;
        public int gold;
        public int leather;
        public int armor;

        public bool hasSword;
        public bool hasBow;
        public bool hasHelmet;
        public bool hasChestPlate;
        public bool hasArmBracers;
        public bool hasBoots;
        public bool hasGuntlet;

        //GameManager
        public int level;
        public bool firstMap = false;

        //Map
        public int mapHight;
        public int mapLength;
        public int spawnWallChance = 0;

        //ItemManager
        //sword
        public int swordAttack;
        public int swordRange;
        public int swordArmor;
        public int swordID;
        public int swordBuyPrice;
        public int swordUpgradeGoldPrice;
        public int swordUpgradeLeatherPrice;
        public int swordLevel;
        public string swordName;
        //Bow
        public int bowAttack;
        public int bowRange;
        public int bowArmor;
        public int bowID;
        public int bowBuyPrice;
        public int bowUpgradeGoldPrice;
        public int bowUpgradeLeatherPrice;
        public int bowLevel;
        public string bowName;
        //Helmet
        public int helmetAttack;
        public int helmetRange;
        public int helmetArmor;
        public int helmetID;
        public int helmetBuyPrice;
        public int helmetUpgradeGoldPrice;
        public int helmetUpgradeLeatherPrice;
        public int helmetLevel;
        public string helmetName;
        //ChestPlate
        public int chestPlateAttack;
        public int chestPlateRange;
        public int chestPlateArmor;
        public int chestPlateID;
        public int chestPlateBuyPrice;
        public int chestPlateUpgradeGoldPrice;
        public int chestPlateUpgradeLeatherPrice;
        public int chestPlateLevel;
        public string chestPlateName;
        //ArmBracers
        public int armBracersAttack;
        public int armBracersRange;
        public int armBracersArmor;
        public int armBracersID;
        public int armBracersBuyPrice;
        public int armBracersUpgradeGoldPrice;
        public int armBracersUpgradeLeatherPrice;
        public int armBracersLevel;
        public string armBracersName;
        //Boots
        public int bootsAttack;
        public int bootsRange;
        public int bootsArmor;
        public int bootsID;
        public int bootsBuyPrice;
        public int bootsUpgradeGoldPrice;
        public int bootsUpgradeLeatherPrice;
        public int bootsLevel;
        public string bootsName;
        //Guntlet
        public int guntletAttack;
        public int guntletRange;
        public int guntletArmor;
        public int guntletID;
        public int guntletBuyPrice;
        public int guntletUpgradeGoldPrice;
        public int guntletUpgradeLeatherPrice;
        public int guntletLevel;
        public string guntletName;
        //mainMenu
        public string playerName;



        public void GetEnemyManagerStats(int smallEnemiesKilled,int bigEnemiesKilled )
        {
            smallEnemyDeathCounter = smallEnemiesKilled;
            bigEnemyDeathCounter = bigEnemiesKilled;
        }
        public void GetPlayerStats(int MaxHealth, int Health, int Gold, int Leather, int Armor)
        {
            maxHealth = MaxHealth;
            health = Health;
            gold = Gold;
            leather = Leather;
            armor = Armor;
        }
        public void GetItemCheck(bool HasSword, bool HasBow, bool HasHelmet, bool HasChestPlate, bool HasArmBracers, bool HasBoots, bool HasGuntlet)
        {
            hasSword = HasSword;
            hasBow = HasBow;
            hasHelmet = HasHelmet;
            hasChestPlate = HasChestPlate;
            hasArmBracers = HasArmBracers;
            hasBoots = HasBoots;
            hasGuntlet = HasGuntlet;
        }
        public void GetGameManagerStats(int Level, bool FirstMap)
        {
            level = Level;
            firstMap = FirstMap;
        }
        public void GetMapStats(int hight, int length, int spawnWallC)
        {
            mapHight = hight;
            mapLength = length;
            spawnWallChance = spawnWallC;
        }
        public void GetSwordStats(Item item)
        {
            swordAttack = item.attack;
            swordRange = item.range;
            swordArmor = item.armor;
            swordID = item.id;
            swordBuyPrice = item.buyPrice;
            swordUpgradeGoldPrice = item.upgradeGoldPrice;
            swordUpgradeLeatherPrice = item.upgradeLeatherPrice;
            swordLevel = item.level;
            swordName = item.name;
        }
        public void GetBowStats(Item item)
        {
            bowAttack = item.attack;
            bowRange = item.range;
            bowArmor = item.armor;
            bowID = item.id;
            bowBuyPrice = item.buyPrice;
            bowUpgradeGoldPrice = item.upgradeGoldPrice;
            bowUpgradeLeatherPrice = item.upgradeLeatherPrice;
            bowLevel = item.level;
            bowName = item.name;
        }
        public void GetHelmetStats(Item item)
        {
            helmetAttack = item.attack;
            helmetRange = item.range;
            helmetArmor = item.armor;
            helmetID = item.id;
            helmetBuyPrice = item.buyPrice;
            helmetUpgradeGoldPrice = item.upgradeGoldPrice;
            helmetUpgradeLeatherPrice = item.upgradeLeatherPrice;
            helmetLevel = item.level;
            helmetName = item.name;
        }
        public void GetChestPlateStats(Item item)
        {
            chestPlateAttack = item.attack;
            chestPlateRange = item.range;
            chestPlateArmor = item.armor;
            chestPlateID = item.id;
            chestPlateBuyPrice = item.buyPrice;
            chestPlateUpgradeGoldPrice = item.upgradeGoldPrice;
            chestPlateUpgradeLeatherPrice = item.upgradeLeatherPrice;
            chestPlateLevel = item.level;
            chestPlateName = item.name;
        }
        public void GetArmBracersStats(Item item)
        {
            armBracersAttack = item.attack;
            armBracersRange = item.range;
            armBracersArmor = item.armor;
            armBracersID = item.id;
            armBracersBuyPrice = item.buyPrice;
            armBracersUpgradeGoldPrice = item.upgradeGoldPrice;
            armBracersUpgradeLeatherPrice = item.upgradeLeatherPrice;
            armBracersLevel = item.level;
            armBracersName = item.name;
        }
        public void GetBootsStats(Item item)
        {
            bootsAttack = item.attack;
            bootsRange = item.range;
            bootsArmor = item.armor;
            bootsID = item.id;
            bootsBuyPrice = item.buyPrice;
            bootsUpgradeGoldPrice = item.upgradeGoldPrice;
            bootsUpgradeLeatherPrice = item.upgradeLeatherPrice;
            bootsLevel = item.level;
            bootsName = item.name;
        }
        public void GetGuntletStats(Item item)
        {
            guntletAttack = item.attack;
            guntletRange = item.range;
            guntletArmor = item.armor;
            guntletID = item.id;
            guntletBuyPrice = item.buyPrice;
            guntletUpgradeGoldPrice = item.upgradeGoldPrice;
            guntletUpgradeLeatherPrice = item.upgradeLeatherPrice;
            guntletLevel = item.level;
            guntletName = item.name;
        }
        public void GetMainMenuStats(string PlayerName)
        {
            playerName = PlayerName;
        }


    }
}
