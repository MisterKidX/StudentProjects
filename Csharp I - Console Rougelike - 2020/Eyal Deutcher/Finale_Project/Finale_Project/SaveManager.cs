using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Finale_Project
{
    public class SaveManager
    {
        SaveFile gameSave;
        static string fileName = @"\GameSaveFile.txt";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\LaDungeon";
        List<string> lines = new List<string>();
        public bool SaveFileAndFolderCheck()
        {
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
                System.IO.File.Create(folderPath + fileName).Close();
                //createFolderAndFile
                return false;
            }
            else
            {
                //CheckFile
                if (!System.IO.File.Exists(folderPath+fileName))
                {
                    System.IO.File.Create(folderPath + fileName).Close();
                    //create new file
                    return false;
                }
                else
                {
                    //continue happily
                }
            }
            return true;
        }
        void SaveToExternalFile()
        {
            //enemyManager
            lines.Add(gameSave.smallEnemyDeathCounter.ToString());
            lines.Add(gameSave.bigEnemyDeathCounter.ToString());
            //playerStats
            lines.Add(gameSave.maxHealth.ToString());
            lines.Add(gameSave.health.ToString());
            lines.Add(gameSave.gold.ToString());
            lines.Add(gameSave.leather.ToString());
            lines.Add(gameSave.armor.ToString());
            //playerItemCheck
            lines.Add(gameSave.hasSword.ToString());
            lines.Add(gameSave.hasBow.ToString());
            lines.Add(gameSave.hasHelmet.ToString());
            lines.Add(gameSave.hasChestPlate.ToString());
            lines.Add(gameSave.hasArmBracers.ToString());
            lines.Add(gameSave.hasBoots.ToString());
            lines.Add(gameSave.hasGuntlet.ToString());
            //GameManagerStats
            lines.Add(gameSave.level.ToString());
            lines.Add(gameSave.firstMap.ToString());
            //Map
            lines.Add(gameSave.mapHight.ToString());
            lines.Add(gameSave.mapLength.ToString());
            lines.Add(gameSave.spawnWallChance.ToString());
            //Items
            //Sword
            lines.Add(gameSave.swordAttack.ToString());
            lines.Add(gameSave.swordRange.ToString());
            lines.Add(gameSave.swordArmor.ToString());
            lines.Add(gameSave.swordID.ToString());
            lines.Add(gameSave.swordBuyPrice.ToString());
            lines.Add(gameSave.swordUpgradeGoldPrice.ToString());
            lines.Add(gameSave.swordUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.swordLevel.ToString());
            lines.Add(gameSave.swordName);
            //Bow
            lines.Add(gameSave.bowAttack.ToString());
            lines.Add(gameSave.bowRange.ToString());
            lines.Add(gameSave.bowArmor.ToString());
            lines.Add(gameSave.bowID.ToString());
            lines.Add(gameSave.bowBuyPrice.ToString());
            lines.Add(gameSave.bowUpgradeGoldPrice.ToString());
            lines.Add(gameSave.bowUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.bowLevel.ToString());
            lines.Add(gameSave.bowName);
            //Helmet
            lines.Add(gameSave.helmetAttack.ToString());
            lines.Add(gameSave.helmetRange.ToString());
            lines.Add(gameSave.helmetArmor.ToString());
            lines.Add(gameSave.helmetID.ToString());
            lines.Add(gameSave.helmetBuyPrice.ToString());
            lines.Add(gameSave.helmetUpgradeGoldPrice.ToString());
            lines.Add(gameSave.helmetUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.helmetLevel.ToString());
            lines.Add(gameSave.helmetName);
            //ChestPlate
            lines.Add(gameSave.chestPlateAttack.ToString());
            lines.Add(gameSave.chestPlateRange.ToString());
            lines.Add(gameSave.chestPlateArmor.ToString());
            lines.Add(gameSave.chestPlateID.ToString());
            lines.Add(gameSave.chestPlateBuyPrice.ToString());
            lines.Add(gameSave.chestPlateUpgradeGoldPrice.ToString());
            lines.Add(gameSave.chestPlateUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.chestPlateLevel.ToString());
            lines.Add(gameSave.chestPlateName);
            //ArmBracers
            lines.Add(gameSave.armBracersAttack.ToString());
            lines.Add(gameSave.armBracersRange.ToString());
            lines.Add(gameSave.armBracersArmor.ToString());
            lines.Add(gameSave.armBracersID.ToString());
            lines.Add(gameSave.armBracersBuyPrice.ToString());
            lines.Add(gameSave.armBracersUpgradeGoldPrice.ToString());
            lines.Add(gameSave.armBracersUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.armBracersLevel.ToString());
            lines.Add(gameSave.armBracersName);
            //Boots
            lines.Add(gameSave.bootsAttack.ToString());
            lines.Add(gameSave.bootsRange.ToString());
            lines.Add(gameSave.bootsArmor.ToString());
            lines.Add(gameSave.bootsID.ToString());
            lines.Add(gameSave.bootsBuyPrice.ToString());
            lines.Add(gameSave.bootsUpgradeGoldPrice.ToString());
            lines.Add(gameSave.bootsUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.bootsLevel.ToString());
            lines.Add(gameSave.bootsName);
            //Guntlet
            lines.Add(gameSave.guntletAttack.ToString());
            lines.Add(gameSave.guntletRange.ToString());
            lines.Add(gameSave.guntletArmor.ToString());
            lines.Add(gameSave.guntletID.ToString());
            lines.Add(gameSave.guntletBuyPrice.ToString());
            lines.Add(gameSave.guntletUpgradeGoldPrice.ToString());
            lines.Add(gameSave.guntletUpgradeLeatherPrice.ToString());
            lines.Add(gameSave.guntletLevel.ToString());
            lines.Add(gameSave.guntletName);
            //MainMenu
            lines.Add(gameSave.playerName);

            //make data become string
            //parsing
            //change to lines
            //" / r""/n"
            System.Threading.Thread.Sleep(100);
            File.WriteAllLines(folderPath + fileName, lines);
        }
        void LoadFromExternalFile()
        {
            lines = File.ReadAllLines(folderPath + fileName).ToList();
            gameSave.smallEnemyDeathCounter = int.Parse(lines[0]);
            gameSave.bigEnemyDeathCounter = int.Parse(lines[1]);
            //
            gameSave.maxHealth = int.Parse(lines[2]);
            gameSave.health = int.Parse(lines[3]);
            gameSave.gold = int.Parse(lines[4]);
            gameSave.leather = int.Parse(lines[5]);
            gameSave.armor = int.Parse(lines[6]);
            //
            gameSave.hasSword = bool.Parse(lines[7]);
            gameSave.hasBow = bool.Parse(lines[8]);
            gameSave.hasHelmet = bool.Parse(lines[9]);
            gameSave.hasChestPlate = bool.Parse(lines[10]);
            gameSave.hasArmBracers = bool.Parse(lines[11]);
            gameSave.hasBoots = bool.Parse(lines[12]);
            gameSave.hasGuntlet = bool.Parse(lines[13]);
            //
            gameSave.level = int.Parse(lines[14]);
            gameSave.firstMap = bool.Parse(lines[15]);
            //
            gameSave.mapHight = int.Parse(lines[16]);
            gameSave.mapLength = int.Parse(lines[17]);
            gameSave.spawnWallChance = int.Parse(lines[18]);
            //Sword
            gameSave.swordAttack = int.Parse(lines[19]);
            gameSave.swordRange = int.Parse(lines[20]);
            gameSave.swordArmor = int.Parse(lines[21]);
            gameSave.swordID = int.Parse(lines[22]);
            gameSave.swordBuyPrice = int.Parse(lines[23]);
            gameSave.swordUpgradeGoldPrice = int.Parse(lines[24]);
            gameSave.swordUpgradeLeatherPrice = int.Parse(lines[25]);
            gameSave.swordLevel = int.Parse(lines[26]);
            gameSave.swordName = lines[27];
            //Bow
            gameSave.bowAttack = int.Parse(lines[28]);
            gameSave.bowRange = int.Parse(lines[29]);
            gameSave.bowArmor = int.Parse(lines[30]);
            gameSave.bowID = int.Parse(lines[31]);
            gameSave.bowBuyPrice = int.Parse(lines[32]);
            gameSave.bowUpgradeGoldPrice = int.Parse(lines[33]);
            gameSave.bowUpgradeLeatherPrice = int.Parse(lines[34]);
            gameSave.bowLevel = int.Parse(lines[35]);
            gameSave.bowName = lines[36];
            //Helmet
            gameSave.helmetAttack = int.Parse(lines[37]);
            gameSave.helmetRange = int.Parse(lines[38]);
            gameSave.helmetArmor = int.Parse(lines[39]);
            gameSave.helmetID = int.Parse(lines[40]);
            gameSave.helmetBuyPrice = int.Parse(lines[41]);
            gameSave.helmetUpgradeGoldPrice = int.Parse(lines[42]);
            gameSave.helmetUpgradeLeatherPrice = int.Parse(lines[43]);
            gameSave.helmetLevel = int.Parse(lines[44]);
            gameSave.helmetName = lines[45];
            //ChestPlate
            gameSave.chestPlateAttack = int.Parse(lines[46]);
            gameSave.chestPlateRange = int.Parse(lines[47]);
            gameSave.chestPlateArmor = int.Parse(lines[48]);
            gameSave.chestPlateID = int.Parse(lines[49]);
            gameSave.chestPlateBuyPrice = int.Parse(lines[50]);
            gameSave.chestPlateUpgradeGoldPrice = int.Parse(lines[51]);
            gameSave.chestPlateUpgradeLeatherPrice = int.Parse(lines[52]);
            gameSave.chestPlateLevel = int.Parse(lines[53]);
            gameSave.chestPlateName = lines[54];
            //ArmBracers
            gameSave.armBracersAttack = int.Parse(lines[55]);
            gameSave.armBracersRange = int.Parse(lines[56]);
            gameSave.armBracersArmor = int.Parse(lines[57]);
            gameSave.armBracersID = int.Parse(lines[58]);
            gameSave.armBracersBuyPrice = int.Parse(lines[59]);
            gameSave.armBracersUpgradeGoldPrice = int.Parse(lines[60]);
            gameSave.armBracersUpgradeLeatherPrice = int.Parse(lines[61]);
            gameSave.armBracersLevel = int.Parse(lines[62]);
            gameSave.armBracersName = lines[63];
            //Boots
            gameSave.bootsAttack = int.Parse(lines[64]);
            gameSave.bootsRange = int.Parse(lines[65]);
            gameSave.bootsArmor = int.Parse(lines[66]);
            gameSave.bootsID = int.Parse(lines[67]);
            gameSave.bootsBuyPrice = int.Parse(lines[68]);
            gameSave.bootsUpgradeGoldPrice = int.Parse(lines[69]);
            gameSave.bootsUpgradeLeatherPrice = int.Parse(lines[70]);
            gameSave.bootsLevel = int.Parse(lines[71]);
            gameSave.bootsName = lines[72];
            //Guntlet
            gameSave.guntletAttack = int.Parse(lines[73]);
            gameSave.guntletRange = int.Parse(lines[74]);
            gameSave.guntletArmor = int.Parse(lines[75]);
            gameSave.guntletID = int.Parse(lines[76]);
            gameSave.guntletBuyPrice = int.Parse(lines[77]);
            gameSave.guntletUpgradeGoldPrice = int.Parse(lines[78]);
            gameSave.guntletUpgradeLeatherPrice = int.Parse(lines[79]);
            gameSave.guntletLevel = int.Parse(lines[80]);
            gameSave.guntletName = lines[81];
            //MainMenu
            gameSave.playerName = lines[82];
            //translate string to data
        }
        public void Load()
        {
            gameSave = new SaveFile();
            LoadFromExternalFile();
            LoadComponentsToGame();
        }
        public void Save()
        {
            gameSave = new SaveFile();
            SaveComponentsToNewSave();
            SaveToExternalFile();
        }
        void SaveComponentsToNewSave()
        {
            gameSave.GetEnemyManagerStats(EnemyManager.smallEnemyDeathCounter, EnemyManager.bigEnemyDeathCounter);
            gameSave.GetPlayerStats(PlayerStats.maxHealth,PlayerStats.health,PlayerStats.gold,PlayerStats.leather,PlayerStats.armor);
            gameSave.GetItemCheck(PlayerStats.hasSword, PlayerStats.hasBow, PlayerStats.hasHelmet, PlayerStats.hasChestPlate, PlayerStats.hasArmBracers, PlayerStats.hasBoots, PlayerStats.hasGuntlet);
            gameSave.GetGameManagerStats(GameManager.level, GameManager.firstMap);
            gameSave.GetMapStats(GameManager.map.GetMapHight(), GameManager.map.GetMapLength(), GameManager.map.GetSpawnWallChance());
            gameSave.GetSwordStats(ItemManager.Sword);
            gameSave.GetBowStats(ItemManager.Bow);
            gameSave.GetHelmetStats(ItemManager.Helmet);
            gameSave.GetChestPlateStats(ItemManager.ChestPlate);
            gameSave.GetArmBracersStats(ItemManager.ArmBracers);
            gameSave.GetBootsStats(ItemManager.Boots);
            gameSave.GetGuntletStats(ItemManager.Guntlet);
            gameSave.GetMainMenuStats(MainMenu.playerName);

            //have function of gather information from different classes and put them in SaveFile Class
            //items
            //level
            //Playerstats
            //Enemies That Died
            //System.IO.File.WriteAllText();
            //XML CSV
        }
        void LoadComponentsToGame()
        {
            SetEnemyManagerStats();
            SetPlayerStats();
            SetPlayerItemsCheck();
            SetGameManagerStats();
            SetMapStats();
            SetSwordStats(ItemManager.Sword);
            SetBowStats(ItemManager.Bow);
            SetHelmetStats(ItemManager.Helmet);
            SetChestPlateStats(ItemManager.ChestPlate);
            SetArmBracersStats(ItemManager.ArmBracers);
            SetBootsStats(ItemManager.Boots);
            SetGuntletStats(ItemManager.Guntlet);
            SetMainMenuStats();
        }
        void SetEnemyManagerStats()
        {
            EnemyManager.smallEnemyDeathCounter = gameSave.smallEnemyDeathCounter;
            EnemyManager.bigEnemyDeathCounter = gameSave.bigEnemyDeathCounter;
        }
        void SetPlayerStats()
        {
            PlayerStats.maxHealth = gameSave.maxHealth;
            PlayerStats.health = gameSave.health;
            PlayerStats.gold = gameSave.gold;
            PlayerStats.leather = gameSave.leather;
            PlayerStats.armor = gameSave.armor;
        }
        void SetPlayerItemsCheck()
        {
            PlayerStats.hasSword = gameSave.hasSword;
            PlayerStats.hasBow = gameSave.hasBow;
            PlayerStats.hasHelmet = gameSave.hasHelmet;
            PlayerStats.hasChestPlate = gameSave.hasChestPlate;
            PlayerStats.hasArmBracers = gameSave.hasArmBracers;
            PlayerStats.hasBoots = gameSave.hasBoots;
            PlayerStats.hasGuntlet = gameSave.hasGuntlet;
        }
        void SetGameManagerStats()
        {
            GameManager.level = gameSave.level;
            GameManager.firstMap = gameSave.firstMap;
        }
        void SetMapStats()
        {
            GameManager.mapHightLoad = gameSave.mapHight;
            GameManager.mapLengthLoad =  gameSave.mapLength;
            GameManager.mapSpawnWallChanceLoad = gameSave.spawnWallChance;
        }
        void SetSwordStats(Item item)
        {
            item.attack = gameSave.swordAttack;
            item.range = gameSave.swordRange;
            item.armor = gameSave.swordArmor;
            item.id = gameSave.swordID;
            item.buyPrice = gameSave.swordBuyPrice;
            item.upgradeGoldPrice = gameSave.swordUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.swordUpgradeLeatherPrice;
            item.level = gameSave.swordLevel;
            item.name = gameSave.swordName;
        }
        void SetBowStats(Item item)
        {
            item.attack = gameSave.bowAttack;
            item.range = gameSave.bowRange;
            item.armor = gameSave.bowArmor;
            item.id = gameSave.bowID;
            item.buyPrice = gameSave.bowBuyPrice;
            item.upgradeGoldPrice = gameSave.bowUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.bowUpgradeLeatherPrice;
            item.level = gameSave.bowLevel;
            item.name = gameSave.bowName;
        }
        void SetHelmetStats(Item item)
        {
            item.attack = gameSave.helmetAttack;
            item.range = gameSave.helmetRange;
            item.armor = gameSave.helmetArmor;
            item.id = gameSave.helmetID;
            item.buyPrice = gameSave.helmetBuyPrice;
            item.upgradeGoldPrice = gameSave.helmetUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.helmetUpgradeLeatherPrice;
            item.level = gameSave.helmetLevel;
            item.name = gameSave.helmetName;
        }
        void SetChestPlateStats(Item item)
        {
            item.attack = gameSave.chestPlateAttack;
            item.range = gameSave.chestPlateRange;
            item.armor = gameSave.chestPlateArmor;
            item.id = gameSave.chestPlateID;
            item.buyPrice = gameSave.chestPlateBuyPrice;
            item.upgradeGoldPrice = gameSave.chestPlateUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.chestPlateUpgradeLeatherPrice;
            item.level = gameSave.chestPlateLevel;
            item.name = gameSave.chestPlateName;
        }
        void SetArmBracersStats(Item item)
        {
            item.attack = gameSave.armBracersAttack;
            item.range = gameSave.armBracersRange;
            item.armor = gameSave.armBracersArmor;
            item.id = gameSave.armBracersID;
            item.buyPrice = gameSave.armBracersBuyPrice;
            item.upgradeGoldPrice = gameSave.armBracersUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.armBracersUpgradeLeatherPrice;
            item.level = gameSave.armBracersLevel;
            item.name = gameSave.armBracersName;
        }
        void SetBootsStats(Item item)
        {
            item.attack = gameSave.bootsAttack;
            item.range = gameSave.bootsRange;
            item.armor = gameSave.bootsArmor;
            item.id = gameSave.bootsID;
            item.buyPrice = gameSave.bootsBuyPrice;
            item.upgradeGoldPrice = gameSave.bootsUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.bootsUpgradeLeatherPrice;
            item.level = gameSave.bootsLevel;
            item.name = gameSave.bootsName;
        }
        void SetGuntletStats(Item item)
        {
            item.attack = gameSave.guntletAttack;
            item.range = gameSave.guntletRange;
            item.armor = gameSave.guntletArmor;
            item.id = gameSave.guntletID;
            item.buyPrice = gameSave.guntletBuyPrice;
            item.upgradeGoldPrice = gameSave.guntletUpgradeGoldPrice;
            item.upgradeLeatherPrice = gameSave.guntletUpgradeLeatherPrice;
            item.level = gameSave.guntletLevel;
            item.name = gameSave.guntletName;
        }
        void SetMainMenuStats()
        {
            MainMenu.playerName = gameSave.playerName;
        }
    }
}
