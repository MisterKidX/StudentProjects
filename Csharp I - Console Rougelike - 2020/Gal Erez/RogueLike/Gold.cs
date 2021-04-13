using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class Gold
    {
        public static List<Gold> GoldList = new List<Gold>(50);
        public Position GoldPos = new Position();

        Random rand = new Random();

        public int Amount;

        public Gold(int x, int y)
        {
            GoldPos = new Position(x, y);

            int Chance = rand.Next(0, 99);
            System.Threading.Thread.Sleep(1);
            if (Chance >= 85)
            {
                Amount = 5;
            }
            else if (Chance >= 50)
            {
                Amount = 3;
            }
            else
            {
                Amount = 1;
            }

            Misc.ChangeColor("yellow");
            Console.SetCursorPosition(x, y);
            Console.Write("£");
            Console.ResetColor();
            GoldList.Add(this);
        }
    }
}
