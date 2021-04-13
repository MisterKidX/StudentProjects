using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Item
    {
        public string name;//sword shield wand armor ring dagger
        public int force;
        Random rnd = new Random();
        public int level;
        public ConsoleColor itemColor;
        public Item(int level)
        {
            this.level = level;
            switch (rnd.Next(1,7))
            {
                case 1:
                    name = "Sword";
                    break;
                case 2:
                    name = "Shield";
                    break;
                case 3:
                    name = "Wand";
                    break;
                case 4:
                    name = "Chainmail";
                    break;
                case 5:
                    name = "Magic Ring";
                    break;
                case 6:
                    name = "Dagger";
                    break;
                default:
                    break;
            }
            int x = rnd.Next(1, 100);
            if (x >= 1 && x <= 50)
            {
                x = 1;
            }
            else if (x >= 50 && x<= 75)
            {
                x = 2;
            }
            else if (x >= 75)
            {
                x = 3;
            }
            switch (x)
            {
                case 1:
                    force = level + rnd.Next(1, 3);
                    itemColor = ConsoleColor.Green;
                    break;
                case 2:
                    force = level + rnd.Next(2, 5);
                    itemColor = ConsoleColor.Blue;
                    break;
                case 3:
                    force = level + rnd.Next(4, 7);
                    itemColor = ConsoleColor.Magenta;
                    break;
                default:
                    break;
            }

        }
    }
}
