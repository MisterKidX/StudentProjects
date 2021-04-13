using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    class PotionStore
    {
        public static List<PotionStore> potionStoreList = new List<PotionStore>(50);
        public Position potionStorePos = new Position();

        public string PotionStoreSymbol = "ô";

        public PotionStore(int x, int y)
        {
            potionStorePos = new Position(x, y);

            Misc.ChangeColor("Dark Magenta");
            Console.SetCursorPosition(x, y);
            Console.Write(PotionStoreSymbol); 
            Console.ResetColor();
            potionStoreList.Add(this);
        }
    }
}
