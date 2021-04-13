using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Vendor: GameObject
    {
        #region Buy Items
        public static void BuySword()
        {
            PlayerStats.gold -= ItemManager.Sword.buyPrice;
            PlayerStats.hasSword = true;
            ItemManager.Sword.level++;
            Hud.InfoText2 = "Bought Sword";

        }
        public static void BuyBow()
        {
            PlayerStats.gold -= ItemManager.Bow.buyPrice;
            PlayerStats.hasBow = true;
            ItemManager.Bow.level++;
            Hud.InfoText2 = "Bought Bow";
        }
        public static void BuyHelmet()
        {
            PlayerStats.gold -= ItemManager.Helmet.buyPrice;
            PlayerStats.hasHelmet = true;
            ItemManager.Helmet.level++;
            Hud.hasAnArmor = true;
            Hud.InfoText2 = "Bought Helmet";
        }
        public static void BuyChestPlate()
        {
            PlayerStats.gold -= ItemManager.ChestPlate.buyPrice;
            PlayerStats.hasChestPlate = true;
            ItemManager.ChestPlate.level++;
            Hud.hasAnArmor = true;
            Hud.InfoText2 = "Bought Chest Plate";
        }
        public static void BuyArmBracers()
        {
            PlayerStats.gold -= ItemManager.ArmBracers.buyPrice;
            PlayerStats.hasArmBracers = true;
            ItemManager.ArmBracers.level++;
            Hud.hasAnArmor = true;
            Hud.InfoText2 = "Bought Arm Bracers";
        }
        public static void BuyBoots()
        {
            PlayerStats.gold -= ItemManager.Boots.buyPrice;
            PlayerStats.hasBoots = true;
            ItemManager.Boots.level++;
            Hud.hasAnArmor = true;
            Hud.InfoText2 = "Bought Boots";
        }
        public static void BuyGuntlet()
        {
            PlayerStats.gold -= ItemManager.Guntlet.buyPrice;
            PlayerStats.hasGuntlet = true;
            ItemManager.Guntlet.level++;
            Hud.hasAnArmor = true;
            Hud.InfoText2 = "Bought Guntlet";
        }
        #endregion
        #region Upgrade Items
        public static void UpgradeSword()
        {
            PlayerStats.gold -= ItemManager.Sword.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.Sword.upgradeLeatherPrice;
            ItemManager.Sword.level++;
            ItemManager.Sword.attack++;
            ItemManager.Sword.upgradeGoldPrice++;
            ItemManager.Sword.upgradeLeatherPrice += 4;
            Hud.InfoText2 = "Sword Upgraded";
        }
        public static void UpgradeBow()
        {
            PlayerStats.gold -= ItemManager.Bow.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.Bow.upgradeLeatherPrice;
            ItemManager.Bow.level++;
            ItemManager.Bow.attack++;
            ItemManager.Bow.upgradeGoldPrice++;
            ItemManager.Bow.upgradeLeatherPrice += 4;
            Hud.InfoText2 = "Bow Upgraded";
        }
        public static void UpgradeHelmet()
        {
            PlayerStats.gold -= ItemManager.Helmet.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.Helmet.upgradeLeatherPrice;

            ItemManager.Helmet.level++;
            ItemManager.Helmet.armor+=2;
            ItemManager.Helmet.upgradeGoldPrice++;
            ItemManager.Helmet.upgradeLeatherPrice += 3;
            Hud.InfoText2 = "Helmet Upgraded";
        }
        public static void UpgradeChestPlate()
        {
            PlayerStats.gold -= ItemManager.ChestPlate.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.ChestPlate.upgradeLeatherPrice;
            ItemManager.ChestPlate.level++;
            ItemManager.ChestPlate.armor+=3;
            ItemManager.ChestPlate.upgradeGoldPrice++;
            ItemManager.ChestPlate.upgradeLeatherPrice += 3;
            Hud.InfoText2 = "Chest Plate Upgraded";
        }
        public static void UpgradeArmBracers()
        {
            PlayerStats.gold -= ItemManager.ArmBracers.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.ArmBracers.upgradeLeatherPrice;
            ItemManager.ArmBracers.level++;
            ItemManager.ArmBracers.armor+=2;
            ItemManager.ArmBracers.upgradeGoldPrice++;
            ItemManager.ArmBracers.upgradeLeatherPrice += 3;
            Hud.InfoText2 = "Arm Bracers Upgraded";
        }
        public static void UpgradeBoots()
        {
            PlayerStats.gold -= ItemManager.Boots.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.Boots.upgradeLeatherPrice;
            ItemManager.Boots.level++;
            ItemManager.Boots.armor++;
            ItemManager.Boots.upgradeGoldPrice++;
            ItemManager.Boots.upgradeLeatherPrice += 2;
            Hud.InfoText2 = "Boots Upgraded";
        }
        public static void UpgradeGuntlet()
        {

            PlayerStats.gold -= ItemManager.Guntlet.upgradeGoldPrice;
            PlayerStats.leather -= ItemManager.Guntlet.upgradeLeatherPrice;
            ItemManager.Guntlet.level++;
            ItemManager.Guntlet.armor+=2;
            ItemManager.Guntlet.upgradeGoldPrice++;
            ItemManager.Guntlet.upgradeLeatherPrice += 3;
            Hud.InfoText2 = "Guntlet Upgraded";
            if (ItemManager.Guntlet.level %5 == 0)
            {
                GuntletSpecial();
            }
        }
        public static void GuntletSpecial()
        {
            ItemManager.Guntlet.attack+=2;
            Hud.InfoText2 = "Sword Upgraded and Attack of Guntlet Has Increaced by 2";
        }
        #endregion
        #region Upgrade Player Stats
        public static int refillHPCost = 1;
        public static int increaceMaxHPCost = 1;
        public static void RefillHP()
        {
            PlayerStats.gold -= refillHPCost;
            PlayerStats.health = PlayerStats.maxHealth;
            refillHPCost++;
            Hud.InfoText2 = "Refilled HP";
        }
        public static void IncreaceMaxHP()
        {
            PlayerStats.gold -= increaceMaxHPCost;
            PlayerStats.maxHealth++;
            PlayerStats.health++;
            increaceMaxHPCost++;
            Hud.InfoText2 = "Max HP is Increaced";
        }
        #endregion
    }
}
