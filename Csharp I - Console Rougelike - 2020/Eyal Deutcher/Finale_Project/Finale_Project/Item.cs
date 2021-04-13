using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class Item
    {
        //sword, attack, range 1
        //Bow, attack, range 2
        //Helmet, armor 2
        //chest plate, armor 3
        //arm bracers, armor 2
        //boots, armor 1, speed + 1(super complex)
        //guntlet, armor 1 , attack +1
        //if player has all items he get's a bonus armor from each piece level
        //Ass Protector , cant be attaccked from behind
        public string name;
        public int attack;
        public int range;
        public int armor;
        public int id;
        public int buyPrice;
        public int upgradeGoldPrice;
        public int upgradeLeatherPrice;
        public int level;
        public Item(int Attack, int Range, int Armor, int ID, int Price, int UpgradeGoldPrice,int UpgradeLeatherPrice, int Level, string Name)
        {
            attack = Attack;
            range = Range;
            armor = Armor;
            id = ID;
            buyPrice = Price;
            upgradeGoldPrice = UpgradeGoldPrice;
            upgradeLeatherPrice = UpgradeLeatherPrice;
            level = Level;
            name = Name;
        }
    }
}
