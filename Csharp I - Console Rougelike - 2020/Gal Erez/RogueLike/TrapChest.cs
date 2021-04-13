using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class TrapChest
    {
        public static List<TrapChest> TChestList = new List<TrapChest>(50);
        public Position TChestPos = new Position();

        public float Damage;

        public TrapChest(int x, int y)
        {
            TChestPos = new Position(x, y);
            Damage = ((float)Player.Instance.CurrentHp / (float)Player.Instance.Hp) * 90;

            Misc.ChangeColor("Magenta");
            Console.SetCursorPosition(x, y);
            Console.Write("∩");
            Console.ResetColor();
            TChestList.Add(this);
        }
    }
}
