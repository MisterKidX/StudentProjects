using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class RewardChest
    {
        public static List<RewardChest> RChestList = new List<RewardChest>(50);
        public Position RChestPos = new Position();
        Random rand = new Random();

        public RewardChest(int x, int y)
        {
            RChestPos = new Position(x, y);

            EarringsItem.Instance.EarringSymbol = MapGenerator.Instance.Blank;
            Hud.Instance.EarringsColor = ConsoleColor.DarkCyan;

            Misc.ChangeColor("Magenta");
            Console.SetCursorPosition(x, y);
            Console.Write("∩");
            Console.ResetColor();
            RChestList.Add(this);
        }
    }
}
