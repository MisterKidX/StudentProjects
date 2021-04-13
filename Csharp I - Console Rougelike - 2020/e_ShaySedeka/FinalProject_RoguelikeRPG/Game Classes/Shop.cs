using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_RoguelikeRPG
{
    class Shop
    {
        int armorLevel;
        int weaponLevel;

        public Shop()
        {
            armorLevel = 1;
            weaponLevel = 1;
        }

        public int ArmorLevel { get => armorLevel; set => armorLevel = value; }
        public int WeaponLevel { get => weaponLevel; set => weaponLevel = value; }

        public int GetArmorCost()
        {
            return ArmorLevel * GameDefinitions.ArmorCostModifier;
        }

        public int GetWeaponCost()
        {
            return WeaponLevel * GameDefinitions.WeaponCostModifier;
        }


    }
}
