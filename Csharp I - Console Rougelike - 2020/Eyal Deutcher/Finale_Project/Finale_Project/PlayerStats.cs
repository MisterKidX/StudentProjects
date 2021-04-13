using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class PlayerStats
    {

        public static int maxHealth = 5;
        public static int health = 5;
        public static int gold = 0;
        public static int leather = 0;
        public static int armor = 0;
        #region Items
        public static bool hasSword;
        public static bool hasBow;
        public static bool hasHelmet;
        public static bool hasChestPlate;
        public static bool hasArmBracers;
        public static bool hasBoots;
        public static bool hasGuntlet;
        #endregion
        public static void ReciveGold(int goldAmount)
        {
            gold += goldAmount; 
        }
        public int GetGold()
        {
            return gold;
        }
        public static void UpdateArmor()
        {
            armor = 0;
            if (hasHelmet == true)
            {
                armor += ItemManager.Helmet.armor;
            }
            if (hasChestPlate == true)
            {
                armor += ItemManager.ChestPlate.armor;
            }
            if (hasArmBracers == true)
            {
                armor += ItemManager.ArmBracers.armor;
            }
            if (hasBoots == true)
            {
                armor += ItemManager.Boots.armor;
            }
            if (hasGuntlet == true)
            {
                armor += ItemManager.Guntlet.armor;
            }
        }

    }

}
