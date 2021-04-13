using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    public class ItemManager
    {
        public static Item Sword = new Item(1, 1, 0, 1, 0, 1, 5,0, "Sword");
        public static Item Bow = new Item(1, 2, 0, 2, 5, 1, 5,0, "Bow");
        public static Item Helmet = new Item(0, 0, 2, 3, 4, 1, 3,0, "Helmet");
        public static Item ChestPlate = new Item(0, 0, 3, 4, 8, 3, 5,0, "Chest Plate");
        public static Item ArmBracers = new Item(0, 0, 2, 5, 4, 2, 3,0, "Arm Bracers");
        public static Item Boots = new Item(0, 0, 1, 6, 2, 1, 2,0, "Boots");
        public static Item Guntlet = new Item(1, 0, 1, 7, 5, 2, 5,0, "Guntlet");
    }
}
